using System.Collections.Generic;
using Common;
using System;
using System.Globalization;

namespace NTR_Common
{
    public partial class PlayersDS
    {
        public partial class VarDataDataTable
        {
            public void CheckTI()
            {
                if (this.Count == 1) return;

                foreach (VarDataRow vdr in this)
                {
                    if (vdr.Is_TINull())
                    {
                        int nearestWeek = -1;
                        for (int i = 0; i < this.Count; i++)
                        {
                            int iWeek = this[i].Week;

                            if (iWeek == vdr.Week) continue;

                            if ((iWeek < vdr.Week) && (iWeek > nearestWeek))
                            {
                                nearestWeek = iWeek;
                                continue;
                            }
                        }

                        if (nearestWeek == -1)
                        {
                            vdr._TI = 0;
                            continue;
                        }

                        VarDataRow pvdr = this.FindByWeek(nearestWeek);
                        PlayersDS pds = (PlayersDS)this.DataSet;
                        FixDataRow fdr = pds.FixDataVal;
                        vdr._TI = Tm_Utility.ASItoTI(vdr.ASI, pvdr.ASI, fdr.FPn == 0) / ((decimal)(vdr.Week - nearestWeek));
                    }
                }
            }
        }

        public partial class VarDataRow
        {
            public decimal For
            {
                get { return _For; }
                set { _For = value; }
            }
            public decimal Res
            {
                get { return _Res; }
                set { _Res = value; }
            }
            public decimal Vel
            {
                get { return _Vel; }
                set { _Vel = value; }
            }
            public decimal Mar
            {
                get { return _Mar_Pre; }
                set { _Mar_Pre = value; }
            }
            public decimal Cro
            {
                get { return _Cro_Com; }
                set { _Cro_Com = value; }
            }
            public decimal Con
            {
                get { return _Con_Uno; }
                set { _Con_Uno = value; }
            }
            public decimal Pas
            {
                get { return _Pas_Ele; }
                set { _Pas_Ele = value; }
            }
            public decimal Pos
            {
                get { return _Pos_Aer; }
                set { _Pos_Aer = value; }
            }
            public decimal Tec
            {
                get { return _Tec_Tir; }
                set { _Tec_Tir = value; }
            }
            public decimal Tes
            {
                get { return _Tes_Lan; }
                set { _Tes_Lan = value; }
            }
            public decimal Wor
            {
                get { return _Wor_Rif; }
                set { _Wor_Rif = value; }
            }
            public decimal Pre
            {
                get { return _Mar_Pre; }
                set { _Mar_Pre = value; }
            }
            public decimal Com
            {
                get { return _Cro_Com; }
                set { _Cro_Com = value; }
            }
            public decimal Uno
            {
                get { return _Con_Uno; }
                set { _Con_Uno = value; }
            }
            public decimal Ele
            {
                get { return _Pas_Ele; }
                set { _Pas_Ele = value; }
            }
            public decimal Aer
            {
                get { return _Pos_Aer; }
                set { _Pos_Aer = value; }
            }
            public decimal Tir
            {
                get { return _Tec_Tir; }
                set { _Tec_Tir = value; }
            }
            public decimal Lan
            {
                get { return _Tes_Lan; }
                set { _Tes_Lan = value; }
            }
            public decimal Rif
            {
                get { return _Wor_Rif; }
                set { _Wor_Rif = value; }
            }
            public decimal Fin
            {
                get { return _Fin; }
                set { _Fin = value; }
            }
            public decimal Cal
            {
                get { return _Cal; }
                set { _Cal = value; }
            }
            public decimal Dis
            {
                get { return _Dis; }
                set { _Dis = value; }
            }

            VarDataRow _player_VDR_Change = null;
            public VarDataRow Player_VDR_Change
            {
                get
                {
                    VarDataDataTable vddt = (VarDataDataTable)Table;
                    int ix = vddt.Rows.IndexOf(this);
                    if ((ix > 0) && (ix < vddt.Count))
                    {
                        PlayersDS.VarDataRow precVDR = vddt[ix - 1];

                        _player_VDR_Change = vddt.NewVarDataRow();

                        _player_VDR_Change.ASI = this.ASI - precVDR.ASI;

                        for (int i = 0; i < 14; i++)
                        {
                            if (precVDR[i + 3] != DBNull.Value)
                                _player_VDR_Change[i + 3] = (decimal)this[i + 3] - (decimal)precVDR[i + 3];
                        }
                    }
                    else
                    {
                        PlayersDS.VarDataRow lastVDR = vddt[vddt.Count - 1];
                        _player_VDR_Change = vddt.NewVarDataRow();
                        _player_VDR_Change.ASI = 0;
                        for (int i = 0; i < 14; i++)
                        {
                            _player_VDR_Change[i + 3] = 0;
                        }
                    }

                    return _player_VDR_Change;
                }
            }

            public decimal[] Skills
            {
                get
                {
                    decimal[] skills = null;
                    if (this.Is_ForNull()) return skills;

                    if (!this.Is_FinNull())
                        skills = new decimal[14];
                    else
                        skills = new decimal[11];

                    skills[0] = this.For;
                    skills[1] = this.Res;
                    skills[2] = this.Vel;
                    skills[3] = this.Mar;
                    skills[4] = this.Con;
                    skills[5] = this.Wor;
                    skills[6] = this.Pos;
                    skills[7] = this.Pas;
                    skills[8] = this.Cro;
                    skills[9] = this.Tec;
                    skills[10] = this.Tes;
                    if (!this.Is_FinNull())
                    {
                        skills[11] = this.Fin;
                        skills[12] = this.Dis;
                        skills[13] = this.Cal;
                    }
                    return skills;
                }

                set
                {
                    decimal[] skills = value;
                    this.For = skills[0];
                    this.Res = skills[1];
                    this.Vel = skills[2];
                    this.Mar = skills[3];
                    this.Con = skills[4];
                    this.Wor = skills[5];
                    this.Pos = skills[6];
                    this.Pas = skills[7];
                    this.Cro = skills[8];
                    this.Tec = skills[9];
                    this.Tes = skills[10];

                    if (skills.Length == 14)
                    {
                        this.Fin = skills[11];
                        this.Dis = skills[12];
                        this.Cal = skills[13];
                    }
                }
            }
        }

        public partial class FixDataRow
        {
            #region BloomValues
            int _bloomStart = -1;
            public int wBloomStart
            {
                get
                {
                    if (_bloomStart == -1)
                    {
                        ParseBloomValues();
                    }
                    return _bloomStart;
                }
                set
                {
                    _bloomStart = value;
                    SetBloomValues();
                }
            }

            decimal _beforeExplTI = -100M;
            public decimal BeforeExplTI
            {
                get
                {
                    if (_beforeExplTI == -100M)
                    {
                        ParseBloomValues();
                        if (_beforeExplTI == -100M) return 0M;
                    }
                    return _beforeExplTI;
                }
                set
                {
                    _beforeExplTI = value;
                    SetBloomValues();
                }
            }

            decimal _explosionTI = -100M;
            public decimal ExplosionTI
            {
                get
                {
                    if (_explosionTI == -100M)
                    {
                        ParseBloomValues();
                        if (_explosionTI == -100M) return 0M;
                    }
                    return _explosionTI;
                }
                set
                {
                    _explosionTI = value;
                    SetBloomValues();
                }
            }

            decimal _afterBloomTI = -100M;
            public decimal AfterBloomTI
            {
                get
                {
                    if (_afterBloomTI == -100M)
                    {
                        ParseBloomValues();
                        if (_afterBloomTI == -100M) return 0M;
                    }
                    return _afterBloomTI;
                }
                set
                {
                    _afterBloomTI = value;
                    SetBloomValues();
                }
            }

            decimal _asi30 = -100M;
            public decimal Asi30
            {
                get
                {
                    if (_asi30 == -100M)
                    {
                        ParseBloomValues();
                        if (_asi30 == -100M) return 0M;
                    }
                    return _asi30;
                }
                set
                {
                    _asi30 = value;
                    SetBloomValues();
                }
            }

            decimal _asi25 = -100M;
            public decimal Asi25
            {
                get
                {
                    if (_asi25 == -100M)
                    {
                        ParseBloomValues();
                        if (_asi25 == -100M) return 0M;
                    }
                    return _asi25;
                }
                set
                {
                    _asi25 = value;
                    SetBloomValues();
                }
            }

            private void ParseBloomValues()
            {
                if (IswBloomDataNull()) return;
                string[] split = wBloomData.Split(';');
                if (split.Length > 0) _bloomStart = int.Parse(split[0]);
                if (split.Length > 1) _beforeExplTI = decimal.Parse(split[1]);
                if (split.Length > 2) _explosionTI = decimal.Parse(split[2]);
                if (split.Length > 3) _afterBloomTI = decimal.Parse(split[3]);
                if (split.Length > 4) _asi30 = decimal.Parse(split[4]);
                if (split.Length > 5) _asi25 = decimal.Parse(split[5]);
            }

            private void SetBloomValues()
            {
                wBloomData = _bloomStart.ToString();
                wBloomData += ";" + _beforeExplTI.ToString();
                wBloomData += ";" + _explosionTI.ToString();
                wBloomData += ";" + _afterBloomTI.ToString();
                wBloomData += ";" + _asi30.ToString();
                wBloomData += ";" + _asi25.ToString();
            }
            #endregion

            internal void FillWithScoutReviewList(List<ScoutReview> srList)
            {
                if (srList == null) return;
                this.ScoutGiudizio = "";
                this.ScoutName = "";
                this.ScoutDate = "";
                this.ScoutVoto = "";

                decimal sumVote = 0;

                foreach (ScoutReview sr in srList)
                {
                    this.ScoutGiudizio += sr.Review + "|";
                    this.ScoutName += sr.ScoutName + "|";
                    this.ScoutDate += TmWeek.ToSWDString(sr.Date) + "|";
                    this.ScoutVoto += sr.Vote.ToString() + "|";
                    sumVote += (decimal)sr.Vote;
                }

                this.ScoutGiudizio = this.ScoutGiudizio.TrimEnd('|');
                this.ScoutName = this.ScoutName.TrimEnd('|');
                this.ScoutDate = this.ScoutDate.TrimEnd('|');
                this.ScoutVoto = this.ScoutVoto.TrimEnd('|');

                if (srList.Count == 0)
                    this.MediaVoto = 0;
                else
                    this.MediaVoto = sumVote / (decimal)srList.Count;
            }
        }

        private string _fullTIHistory = "";
        public string FullTIHistory
        {
            get
            {
                if (_fullTIHistory != "")
                    return _fullTIHistory;

                TmWeek tmw = new TmWeek(VarData[0].Week);
                _fullTIHistory = TmWeek.ToSWDString(tmw.ToDate()) + ";";
                TmWeek now = TmWeek.thisWeek();

                for (int week = tmw.absweek; week <= now.absweek; week++)
                {
                    VarDataRow vdr = VarData.FindByWeek(week);
                    if (vdr == null)
                    {
                        _fullTIHistory += "-;";
                    }
                    else
                    {
                        _fullTIHistory += week.ToString() + ";";
                    }
                }

                return _fullTIHistory;
            }
        }

        public bool ParsePlayerPage(string page)
        {
            page = page.Replace("'", "");
            page = page.Replace('"', '\'');
            page = page.Replace("'>", ">");
            page = page.Replace("&#39;", "'");
            page = page.Replace(" \r\n", " ");
            bool scout_parsed = false;

            DateTime pageDate = DateTime.Now;

            List<string> tables = HTML_Parser.GetFullTags(page, "table");
            if (tables.Count == 0)
                return false;

            int dayOfTheWeek = TmWeek.GetTmAbsDay(DateTime.Now) % 7;
            VarDataRow vdr;
            if (dayOfTheWeek < 5)
            {
                vdr = this.VarData.FindByWeek(TmWeek.thisWeek().absweek - 1);
                if (vdr == null)
                {
                    VarDataRow vdrThisWeek = this.VarData.FindByWeek(TmWeek.thisWeek().absweek);
                    if (vdrThisWeek == null)
                        return false;

                    vdrThisWeek.Week = TmWeek.thisWeek().absweek - 1;

                    vdr = this.VarData.NewVarDataRow();
                    vdr.Week = TmWeek.thisWeek().absweek;
                    VarData.AddVarDataRow(vdr);
                }
                else
                {
                    vdr = this.VarData.FindByWeek(TmWeek.thisWeek().absweek);
                }
            }
            else
            {
                vdr = this.VarData.FindByWeek(TmWeek.thisWeek().absweek);
                if (vdr == null)
                {
                    vdr = this.VarData.NewVarDataRow();
                    vdr.Week = TmWeek.thisWeek().absweek;
                    VarData.AddVarDataRow(vdr);
                }
            }

            //// It's a base page
            //string[] pagelines = page.Split('\n');

            //for (int ix = 0; ix < pagelines.Length; ix++)
            //{
            //    string line = pagelines[ix];

            //    if (line.Contains("select_player"))
            //    {
            //        int index = 0;
            //        string Age = "";
            //        // The successive row contains the age info
            //        do
            //        {
            //            line = pagelines[ix];
            //            Age = HTML_Parser.GetField(line, "</strong>", "<", ref index);
            //            ix++;
            //        } while (Age == "");                    

            //        string Heigth = HTML_Parser.GetField(line, "</strong>", "<", ref index);
            //        string Weight = HTML_Parser.GetField(line, "</strong>", "<", ref index);

            //        FixDataVal.wBorn = TmWeek.GetBornWeekFromAge(pageDate, Age);

            //        continue;
            //    }

            //    if (line.Contains("'importage'"))
            //    {
            //        // Line containing Age, Height and Weight
            //        int index = 0;
            //        string training = HTML_Parser.GetField(line, "'importage', '", "');", ref index);

            //        //FixDataVal.SetTSINull();
            //        //FixDataVal.SetTI(pageDate, training);
            //        //FixDataVal.AvTSI = Utility.WeightedMean(FixDataVal.TSI);

            //        continue;
            //    }

            //    if (line.Contains("<!-- Header start -->"))
            //    {
            //        string full_line = "";
            //        ix++;

            //        for (; ix < pagelines.Length; ix++)
            //        {
            //            line = pagelines[ix];
            //            full_line += line.TrimEnd('\r');
            //            if (line.Contains("<!-- Header end -->")) break;
            //        }

            //        // Season line
            //        int index = 0;
            //        string FullName = HTML_Parser.GetField(full_line, "</div>", " <a href", ref index);
            //        string RealCountry = HTML_Parser.GetField(full_line, "showcountry=", "><img", ref index);
            //        FixDataVal.Nome = FullName.Replace("  ", " ");
            //        FixDataVal.Nationality = RealCountry;

            //        continue;
            //    }
            //} // end for (int ix = 0; ix < lines.Length; ix++)

            for (int ix = 0; ix < tables.Count; ix++)
            {
                string table = tables[ix];

                if (table.Contains("info_table"))
                {
                    // Line containing Age, Height and Weight
                    List<string> tagsTr = HTML_Parser.GetTags(table, "tr");

                    string td;
                    string val;

                    // Getting Wage
                    td = HTML_Parser.GetTag(tagsTr[4], "td");
                    val = HTML_Parser.CleanTags(td).Replace(",", "");
                    FixDataVal.Wage = int.Parse(val);

                    // Getting ASI
                    td = HTML_Parser.GetTag(tagsTr[6], "td");
                    val = HTML_Parser.CleanTags(td).Replace(",", "");
                    vdr.ASI = int.Parse(val);

                    // Getting ASI
                    td = HTML_Parser.GetTag(tagsTr[8], "td");
                    val = HTML_Parser.CleanTags(td);
                    FixDataVal.Rou = decimal.Parse(val, CommGlobal.ciUs);

                    continue;
                }

                if (table.Contains("skill_table") && !(table.Contains("hidden_skill_table")))
                {
                    List<string> tags = HTML_Parser.GetTags(table, "td");

                    // Parse td containing skills
                    for (int i = 0; i < tags.Count; i++)
                    {
                        if (tags[i].Contains("star.png"))
                            tags[i] = "20";
                        else if (tags[i].Contains("star_silver.png"))
                            tags[i] = "19";
                        else
                            tags[i] = HTML_Parser.CleanTags(tags[i]);
                    }

                    if (FixDataVal.FPn == 0) // It's a GK
                    {
                        vdr.For = decimal.Parse(tags[0]);
                        vdr.Res = decimal.Parse(tags[2]);
                        vdr.Vel = decimal.Parse(tags[4]);
                        vdr.Mar = decimal.Parse(tags[1]);
                        vdr.Con = decimal.Parse(tags[3]);
                        vdr.Wor = decimal.Parse(tags[5]);
                        vdr.Pos = decimal.Parse(tags[7]);
                        vdr.Pas = decimal.Parse(tags[9]);
                        vdr.Cro = decimal.Parse(tags[11]);
                        vdr.Tec = decimal.Parse(tags[13]);
                        vdr.Tes = decimal.Parse(tags[15]);
                    }
                    else
                    {
                        vdr.For = decimal.Parse(tags[0]);
                        vdr.Res = decimal.Parse(tags[2]);
                        vdr.Vel = decimal.Parse(tags[4]);
                        vdr.Mar = decimal.Parse(tags[6]);
                        vdr.Con = decimal.Parse(tags[8]);
                        vdr.Wor = decimal.Parse(tags[10]);
                        vdr.Pos = decimal.Parse(tags[12]);
                        vdr.Pas = decimal.Parse(tags[1]);
                        vdr.Cro = decimal.Parse(tags[3]);
                        vdr.Tec = decimal.Parse(tags[5]);
                        vdr.Tes = decimal.Parse(tags[7]);
                        vdr.Fin = decimal.Parse(tags[9]);
                        vdr.Dis = decimal.Parse(tags[11]);
                        vdr.Cal = decimal.Parse(tags[13]);
                    }

                }

                //if (table.Contains("<!-- Season -->"))
                //{
                //    List<string> rows = HTML_Parser.GetTags2(table, "tr");

                //    for (int ir = 1; ir < rows.Count; ir++)
                //    {
                //        List<string> tdFields = HTML_Parser.GetTags(rows[ir], "td");

                //        if (tdFields == null) continue;

                //        string Fee;

                //        if (tdFields.Count == 12)
                //        {
                //            // Season  = tdFields[0]; 
                //            // Club    = tdFields[1];; 
                //            // Nation  = tdFields[2]; 
                //            // Age     = tdFields[3]; 
                //            Fee = tdFields[4];
                //            // GP      = tdFields[5]; 
                //            // Gol     = tdFields[6]; 
                //            // Assist  = tdFields[7]; 
                //            // Prod    = tdFields[8]; 
                //            // Mom     = tdFields[9];
                //            // Cards   = tdFields[10];
                //            decimal avRating;
                //            decimal.TryParse(tdFields[11], NumberStyles.Float, CommGlobal.ciUs, out avRating);
                //            FixDataVal.AvRating = avRating;
                //            break; // Get only the first season
                //            // continue;
                //        }

                //        if (tdFields.Count == 9)
                //        {
                //            // GP      = tdFields[2; 
                //            // Gol     = tdFields[3]; 
                //            // Assist  = tdFields[4]; 
                //            // Prod    = tdFields[5]; 
                //            // Mom     = tdFields[6];
                //            // Cards   = tdFields[7];
                //            // float.TryParse(tdFields[8], out gr.AvRating);
                //        }
                //    }
                //}

                //if ((table.Contains("scouts.php") && !table.Contains("scouts_table") && (!scout_parsed)) ||
                //    ((ix < tables.Count - 1) && (ix == 1) && (tables[ix + 1].Contains("scouts.php"))))
                //{
                //    List<ScoutReview> srList = ScoutReview.ParseTable(table);

                //    FixDataVal.FillWithScoutReviewList(srList);

                //    scout_parsed = true;
                //}
            }

            return true;
        }

        public FixDataRow FixDataVal
        {
            get
            {
                if (FixData.Count == 0)
                {
                    FixDataRow fdr = FixData.NewFixDataRow();
                    fdr.PlayerID = 0;
                    FixData.AddFixDataRow(fdr);
                }
                return FixData[0];
            }
        }
    }
}