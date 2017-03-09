using System.Windows.Forms;
using Common;
using System.Collections.Generic;
namespace Common
{


    partial class TrainersSkills
    {
        public bool isDirty = false;

        public void LoadPasteTrainers()
        {
            if (!Clipboard.ContainsData(System.Windows.Forms.DataFormats.Html))
                return;

            foreach (TrainersRow row in Trainers)
            {
                row.inTeam = false;
            }

            string page = (string)Clipboard.GetData(DataFormats.Html);

            ParseTrainers(page);
        }

        public void ParseTrainers_NewTM(string page)
        {
            // There will be two tables (0: players, 1: GK)
            Trainers.Clear();

            List<string> rows = HTML_Parser.GetTags(page, "TR");

            foreach (string row in rows)
            {
                List<string> fds = HTML_Parser.GetTags(row, "TD");

                if (fds.Count < 5) continue;
                string idstring = HTML_Parser.GetNumberAfter(fds[9], "\", \"");
                if (idstring == "") continue;

                TrainersRow tr = Trainers.NewTrainersRow();

                string[] spl = fds[0].Split('(');
                tr.Name = spl[0].Trim();

                if (idstring != "")
                    tr.ID = int.Parse(idstring);
                else
                    tr.ID = tr.Name.GetHashCode();

                int i0;

                for (int i = 0; i < fds.Count; i++)
                {
                    if (fds[i].Contains("star.png")) fds[i] = "20";
                    if (fds[i].Contains("star_silver.png")) fds[i] = "19";
                    fds[i] = HTML_Parser.CleanTags(fds[i]);
                }

                for (i0 = 0; i0 < fds.Count; i0++)
                {
                    decimal d;
                    if (decimal.TryParse(fds[i0], out d)) break;
                }

                tr.Mot = decimal.Parse(fds[i0 + 0]);
                tr.Fis = decimal.Parse(fds[i0 + 1]);
                tr.Por = decimal.Parse(fds[i0 + 2]);
                tr.Dif = decimal.Parse(fds[i0 + 3]);
                tr.Tec = decimal.Parse(fds[i0 + 4]);
                tr.Win = decimal.Parse(fds[i0 + 5]);
                tr.Hea = decimal.Parse(fds[i0 + 6]);
                tr.Att = decimal.Parse(fds[i0 + 7]);

                tr.ComputeBestSkills();

                TrainersRow oldtr = Trainers.FindByID(tr.ID);
                if (oldtr != null)
                {
                    Trainers.RemoveTrainersRow(oldtr);
                }

                tr.inTeam = true;

                Trainers.AddTrainersRow(tr);
            }

            isDirty = true;
        }

        public void ParseTrainers(string page)
        {
            // There will be two tables (0: players, 1: GK)
            Trainers.Clear();

            List<string> rows = HTML_Parser.GetTags(page, "TR");

            foreach (string row in rows)
            {
                List<string> fds = HTML_Parser.GetTags(row, "TD");

                string idstring = HTML_Parser.GetNumberAfter(row, "staff_trainers.php?fire=");
                if (fds.Count < 5) continue;
                if (idstring == "") continue;

                TrainersRow tr = Trainers.NewTrainersRow();

                tr.Name = fds[0].Replace("\r\n", "").Replace("  ", " ");

                if (idstring != "")
                    tr.ID = int.Parse(idstring);
                else
                    tr.ID = tr.Name.GetHashCode();

                int i0;

                for (i0 = 0; i0 < fds.Count; i0++)
                {
                    decimal d;
                    if (decimal.TryParse(fds[i0], out d)) break;
                }

                for (int i = i0; i < i0 + 8; i++)
                {
                    if (fds[i].Contains("star.gif")) fds[i] = "20";
                    if (fds[i].Contains("star_silver.gif")) fds[i] = "19";
                    fds[i] = HTML_Parser.CleanTags(fds[i]);
                }

                tr.Mot = decimal.Parse(fds[i0 + 0]);
                tr.Fis = decimal.Parse(fds[i0 + 1]);
                tr.Por = decimal.Parse(fds[i0 + 2]);
                tr.Dif = decimal.Parse(fds[i0 + 3]);
                tr.Tec = decimal.Parse(fds[i0 + 4]);
                tr.Win = decimal.Parse(fds[i0 + 5]);
                tr.Hea = decimal.Parse(fds[i0 + 6]);
                tr.Att = decimal.Parse(fds[i0 + 7]);

                tr.ComputeBestSkills();

                TrainersRow oldtr = Trainers.FindByID(tr.ID);
                if (oldtr != null)
                {
                    Trainers.RemoveTrainersRow(oldtr);
                }

                tr.inTeam = true;

                Trainers.AddTrainersRow(tr);
            }

            isDirty = true;
        }

        public void ComputeBestCombination()
        {

        }

        public class TRow
        {
            public decimal res;
            public int[] ix = new int[5];

            public TRow(int ix1, int ix2, int ix3, decimal ires)
            {
                res = ires;
                ix[0] = ix1;
                ix[1] = ix2;
                ix[2] = ix3;
                ix[3] = -1;
            }

            public TRow(int ix1, int ix2, int ix3, int ix4, decimal ires)
            {
                res = ires;
                ix[0] = ix1;
                ix[1] = ix2;
                ix[2] = ix3;
                ix[3] = ix4;
                ix[4] = -1;
            }

            public TRow(int ix1, decimal ires)
            {
                res = ires;
                ix[0] = ix1;
                ix[1] = -1;
            }
        }

        public class OrderedResList : List<TRow>
        {
            public void Add(int ix1, int ix2, int ix3, decimal ires)
            {
                Add(new TRow(ix1, ix2, ix3, ires));

                RemoveWorst();
            }

            public void Add(int ix1, int ix2, int ix3, int ix4, decimal ires)
            {
                Add(new TRow(ix1, ix2, ix3, ix4, ires));

                RemoveWorst();
            }

            public void Add(int ix1, decimal ires)
            {
                Add(new TRow(ix1, ires));

                RemoveWorst();
            }

            private void RemoveWorst()
            {
                if (this.Count < 20) return;

                decimal worst = this[0].res;
                int ixw = 0;

                for (int i = 1; i < this.Count; i++)
                {
                    if (this[i].res < worst)
                    {
                        worst = this[i].res;
                        ixw = i;
                    }
                }

                this.Remove(this[ixw]);
            }

            public void Order()
            {
                int iMax, iMin;

                for (int i = 0; i < this.Count - 1; i++)
                {
                    // if (i > this.Count - i) break;
                    FindFirst(i, this.Count, out iMax, out iMin);

                    TRow vallet = this[i];
                    this[i] = this[iMax];
                    this[iMax] = vallet;

                    //vallet = this[this.Count - 1 - i];
                    //this[this.Count - 1 - i] = this[iMin];
                    //this[iMin] = vallet;
                }


            }

            private void FindFirst(int stt, int end, out int iMax, out int iMin)
            {
                int imin = stt, imax = stt;
                decimal min = this[stt].res;
                decimal max = min;

                for (int i = stt + 1; i < end; i++)
                {
                    decimal val = this[i].res;

                    if (val < min)
                    {
                        imin = i;
                        min = val;
                    }
                    else if (val > max)
                    {
                        imax = i;
                        max = val;
                    }
                }

                iMax = imax;
                iMin = imin;
            }

        }

        public partial class TrainersRow
        {
            // Data table of the resulting best skills
            public SkillsDataTable sdt = new SkillsDataTable();

            OrderedResList resList = new OrderedResList();

            public void ComputeBestSkills()
            {
                List<decimal> reslist = new List<decimal>();
                resList.Clear();

                for (int i = 3; i < 9; i++)
                {
                    for (int j = i + 1; j < 9; j++)
                    {
                        for (int k = j + 1; k < 9; k++)
                        {
                            decimal res = ComputeSkillRes(i, j, k);

                            resList.Add(i, j, k, res);

                            for (int l = k + 1; l < 9; l++)
                            {
                                res = ComputeSkillRes(i, j, k, l);

                                resList.Add(i, j, k, l, res);
                            }
                        }
                    }
                }

                decimal pres = ComputeSkillRes(2);
                resList.Add(2, pres);

                sdt.Clear();

                resList.Order();

                for (int i = 0; i < resList.Count; i++)
                {
                    SkillsRow sr = sdt.NewSkillsRow();
                    sr.Result = resList[i].res * 100;

                    int n = 0;
                    sr.BestSkills = "";
                    while (resList[i].ix[n] != -1)
                    {
                        int ibs = resList[i].ix[n];

                        switch (ibs)
                        {
                            case 1: sr.BestSkills += "Mot "; break;
                            case 2: sr.BestSkills += "GK "; break;
                            case 3: sr.BestSkills += "Phy "; break;
                            case 4: sr.BestSkills += "Def "; break;
                            case 5: sr.BestSkills += "Tec "; break;
                            case 6: sr.BestSkills += "Hea "; break;
                            case 7: sr.BestSkills += "Win "; break;
                            case 8: sr.BestSkills += "Att "; break;
                            default: break;
                        }

                        n++;
                    }

                    sdt.AddSkillsRow(sr);
                }
            }

            private decimal ComputeSkillRes(int i, int j, int k)
            {
                decimal v1 = (decimal)this[i];
                decimal v2 = (decimal)this[j];
                decimal v3 = (decimal)this[k];

                decimal mot = (decimal)this[1];

                decimal res = (mot / 20M * 0.5M + (v1 + v2 + v3) / 20M * 1.5M) / 5M;

                return res;
            }

            private decimal ComputeSkillRes(int i, int j, int k, int l)
            {
                decimal v1 = (decimal)this[i];
                decimal v2 = (decimal)this[j];
                decimal v3 = (decimal)this[k];
                decimal v4 = (decimal)this[l];

                decimal mot = (decimal)this[1];

                decimal res = (mot / 20M * 0.5M + (v1 + v2 + v3 + v4) / 20M * 1.5M) / 6.5M;

                return res;
            }

            private decimal ComputeSkillRes(int i)
            {
                decimal v1 = (decimal)this[i];

                decimal mot = (decimal)this[1];

                decimal res = (mot / 20M * 0.5M + (v1) / 20M * 1.5M) / 2M;

                return res;
            }

            public decimal GetPercentage(int program)
            {
                decimal ssk = 0;
                decimal nsk = 0;

                if ((program & 1) > 0)
                {
                    ssk += this.Fis;
                    nsk++;
                }
                if ((program & 2) > 0)
                {
                    ssk += this.Dif;
                    nsk++;
                }
                if ((program & 4) > 0)
                {
                    ssk += this.Tec;
                    nsk++;
                }
                if ((program & 8) > 0)
                {
                    ssk += this.Win;
                    nsk++;
                }
                if ((program & 16) > 0)
                {
                    ssk += this.Hea;
                    nsk++;
                }
                if ((program & 32) > 0)
                {
                    ssk += this.Att;
                    nsk++;
                }
                if (program == 0)
                    ssk = this.Por * 3;
                else
                    ssk = ssk / nsk * 3M;

                return (Mot / 20M * 0.5M + (ssk) / 20M * 1.5M) * 20M;
            }
        }
    }
}
