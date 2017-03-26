using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTR_Common
{

    public class TAC_PlWeights
    {
        public TAC_PlWeights(double[] weights, Tactics.Type tactics, int dora, int sps)
        {
            Tactics = tactics.ToString();
            Tactics.backColor = Color.LightGray;

            DorA = dora;
            FPos = NTR_Common.Tactics.eSpToString(sps);
            FPos.backColor = Color.LightYellow;

            Str = weights[0];
            Sta = weights[1];
            Pac = weights[2];
            Mar = weights[3];
            Tac = weights[4];
            Wor = weights[5];
            Pos = weights[6];
            Pas = weights[7];
            Cro = weights[8];
            Tec = weights[9];
            Hea = weights[10];
            Fin = weights[11];
            Lon = weights[12];
            Set = weights[13];
        }

        public FormattedString Tactics { get; set; }
        public int DorA { get; set; }
        public double Str { get; set; }
        public double Sta { get; set; }
        public double Pac { get; set; }
        public double Mar { get; set; }
        public double Tac { get; set; }
        public double Wor { get; set; }
        public double Pos { get; set; }
        public double Pas { get; set; }
        public double Cro { get; set; }
        public double Tec { get; set; }
        public double Hea { get; set; }
        public double Fin { get; set; }
        public double Lon { get; set; }
        public double Set { get; set; }
        public FormattedString FPos { get; set; }

        public double[] Row => new double[]
            {Str,Sta,Pac,
            Mar,Tac,Wor,
            Pos,Pas,Cro,
            Tec,Hea,Fin,
            Lon,Set};
    }

    public class TAC_GkWeights
    {
        public TAC_GkWeights(double[] weights, Tactics.Type tactics, int dora)
        {
            Tactics = tactics.ToString();
            Tactics.backColor = Color.LightYellow;
            DorA = dora;

            Str = weights[0];
            Sta = weights[1];
            Pac = weights[2];
            Han = weights[3];
            One = weights[4];
            Ref = weights[5];
            Aer = weights[6];
            Jum = weights[7];
            Com = weights[8];
            Kic = weights[9];
            Thr = weights[10];
        }

        public FormattedString Tactics { get; set; }
        public int DorA { get; set; }
        public double Str { get; set; }
        public double Sta { get; set; }
        public double Pac { get; set; }
        public double Han { get; set; }
        public double One { get; set; }
        public double Ref { get; set; }
        public double Aer { get; set; }
        public double Jum { get; set; }
        public double Com { get; set; }
        public double Kic { get; set; }
        public double Thr { get; set; }

        public double[] Row => new double[]
            {Str,Sta,Pac,
            Han,One,Ref,
            Aer,Jum,Com,
            Kic,Thr};
    }

    public class Tactics
    {
        public enum Type
        {
            Direct,
            Wings,
            ShortPass,
            LongBalls,
            Through
        }

        public enum Position : int
        {
            Attack = 0,
            Defense = 1,
        }

        public enum Skill
        {
            Str,
            Sta,
            Pac,
            Mar,
            Tak,
            Wor,
            Pos,
            Pas,
            Cro,
            Tec,
            Hea,
            Fin,
            Lon,
            Set
        }

        public static string eSpToString(int sp)
        {
            string res = "";

            if ((sp & (int)eSP.GK) > 0) res += "GK,";
            if ((sp & (int)eSP.DC) > 0) res += "DC,";
            if ((sp & (int)eSP.DL) > 0) res += "DL,";
            if ((sp & (int)eSP.DR) > 0) res += "DR,";
            if ((sp & (int)eSP.DMC) > 0) res += "DMC,";
            if ((sp & (int)eSP.DML) > 0) res += "DML,";
            if ((sp & (int)eSP.DMR) > 0) res += "DMR,";
            if ((sp & (int)eSP.MC) > 0) res += "MC,";
            if ((sp & (int)eSP.ML) > 0) res += "ML,";
            if ((sp & (int)eSP.MR) > 0) res += "MR,";
            if ((sp & (int)eSP.OMC) > 0) res += "OMC,";
            if ((sp & (int)eSP.OML) > 0) res += "OML,";
            if ((sp & (int)eSP.OMR) > 0) res += "OMR,";
            if ((sp & (int)eSP.FC) > 0) res += "FC,";

            return res.TrimEnd(',');
        }

        public static int  StringToeSp(string sp)
        {
            string[] sps = sp.Split(',');

            int res = 0;

            if (sps.Contains("GK")) res |= (int)eSP.GK;
            if (sps.Contains("DC")) res |= (int)eSP.DC;
            if (sps.Contains("DL")) res |= (int)eSP.DL;
            if (sps.Contains("DR")) res |= (int)eSP.DR;
            if (sps.Contains("DMC")) res |= (int)eSP.DMC;
            if (sps.Contains("DML")) res |= (int)eSP.DML;
            if (sps.Contains("DMR")) res |= (int)eSP.DMR;
            if (sps.Contains("MC")) res |= (int)eSP.MC;
            if (sps.Contains("ML")) res |= (int)eSP.ML;
            if (sps.Contains("MR")) res |= (int)eSP.MR;
            if (sps.Contains("OMC")) res |= (int)eSP.OMC;
            if (sps.Contains("OML")) res |= (int)eSP.OML;
            if (sps.Contains("OMR")) res |= (int)eSP.OMR;
            if (sps.Contains("FC")) res |= (int)eSP.FC;

            return res;
        }

        public static PlTacticsSPosDictionary WeightListToDict(List<TAC_PlWeights> tacPlWeights)
        {
            PlTacticsSPosDictionary dict = new PlTacticsSPosDictionary();

            try
            {
                for (int i = 0; i < tacPlWeights.Count; i++)
                {
                    TAC_PlWeights weights = tacPlWeights[i];

                    Tactics.Type tactics = (Tactics.Type)Enum.Parse(typeof(Tactics.Type), weights.Tactics.ToString());
                    int DorA = weights.DorA;
                    int SPs = Tactics.StringToeSp(weights.FPos.ToString());

                    var item = (SPs, weights.Row);

                    var entry = new List<(int SPs, double[])>
                    {
                        item,
                    };

                    var key = (tactics, DorA);

                    if (!dict.ContainsKey(key))
                        dict.Add(key, entry);
                    else
                        dict[key].Add(item);

                }
            }
            catch (FormatException) { throw new MException("Wrong input format!"); }
            return dict;
        }

        public static GkTacticsSPosDictionary WeightListToDict(List<TAC_GkWeights> tacGkWeights)
        {
            GkTacticsSPosDictionary dict = new GkTacticsSPosDictionary();

            try
            {
                for (int i = 0; i < tacGkWeights.Count; i++)
                {
                    TAC_GkWeights weights = tacGkWeights[i];

                    Tactics.Type tactics = (Tactics.Type)Enum.Parse(typeof(Tactics.Type), weights.Tactics.ToString());
                    int DorA = weights.DorA;

                    var key = (tactics, DorA);

                    dict.Add(key, weights.Row);
                }
            }
            catch (FormatException) { throw new MException("Wrong input format!"); }
            return dict;
        }

        //public static List<TAC_PlWeights> WeightsMatrixToPlayerWeightsTable(Matrix weights, string[,] rules)
        //{
        //    List<TAC_PlWeights> tacWeightsList = new List<TAC_PlWeights>();

        //    for (int row = 0; row < weights.Rows; row++)
        //    {
        //        TAC_PlWeights Weight = new TAC_PlWeights(weights, rules, row);
        //        tacWeightsList.Add(Weight);
        //    }

        //    return tacWeightsList;
        //}

        //internal static (Matrix weights, string[,] rules) PlayerWeightsTableToWeightsMatrix(List<TAC_PlayerWeights> tacWeightsList)
        //{
        //    Matrix weights = new Matrix(tacWeightsList.Count, 14);

        //    for (int r = 0; r < weights.Rows; r++)
        //    {
        //        double[] row = tacWeightsList[r].Row;

        //        for (int c = 0; c < weights.Cols; c++)
        //        {
        //            weights[r, c] = row[c];
        //        }
        //    }

        //    string [,] rules = new string[tacWeightsList.Count, 3];

        //    for (int r = 0; r < weights.Rows; r++)
        //    {
        //        rules[r, 0] = tacWeightsList[r].Tactics.ToString();
        //        rules[r, 1] = tacWeightsList[r].DorA.ToString();
        //        rules[r, 2] = tacWeightsList[r].FPos.ToString();
        //    }

        //    return (weights, rules);
        //}


    }

    public enum eSP
    {
        GK = 0x1,
        DC = 0x2,
        DL = 0x4,
        DR = 0x8,
        D = 0xe,
        DW = 0xc,
        DMC = 0x20,
        DML = 0x40,
        DMR = 0x80,
        DM = 0xe0,
        DMW = 0xc0,
        MC = 0x200,
        ML = 0x400,
        MR = 0x800,
        M = 0xe00,
        MW = 0xc00,
        OMC = 0x2000,
        OML = 0x4000,
        OMR = 0x8000,
        OM = 0xe000,
        OMW = 0xc000,
        FC = 0x20000,
    }

    public class PlTacticsSPosDictionary :
        Dictionary<(Tactics.Type tactics, int atk), List<(int SPs, double[] Weights)>>
    {
        public string ToString(IFormatProvider iFP) // Function returns PlTacticsSPosDictionary as a string file
        {
            string s = "";

            foreach (var entry in this)
            {
                foreach (var item in entry.Value)
                {
                    int Cols = item.Weights.Length;

                    s += entry.Key.tactics.ToString() + '\t';
                    s += entry.Key.atk.ToString() + '\t';

                    for (int j = 0; j < Cols; j++)
                    {
                        s += String.Format(iFP, "{0:G5}\t", item.Weights[j]);
                    }

                    s += Tactics.eSpToString(item.SPs);
                    s += ";...\n";

                }
            }
            s += ";";

            return s.Replace(";...\n;", ";");
        }

        public string ToExcelString() // Function returns PlTacticsSPosDictionary as a string file
        {
            string s = "";

            foreach (var entry in this)
            {
                foreach (var item in entry.Value)
                {
                    int Cols = item.Weights.Length;

                    s += entry.Key.tactics.ToString() + '\t';
                    s += entry.Key.atk.ToString() + '\t';

                    for (int j = 0; j < Cols; j++)
                    {
                        s += String.Format("{0:G5}\t", item.Weights[j]);
                    }

                    s += Tactics.eSpToString(item.SPs);
                    s += "\r\n";

                }
            }
            return s;
        }

        public static PlTacticsSPosDictionary Parse(string s, IFormatProvider iFP = null)    // Function parses the matrix from string file
        {
            string[] rows = Regex.Split(s, ";");
            string[] nums;

            PlTacticsSPosDictionary dict = new PlTacticsSPosDictionary();

            try
            {
                for (int i = 0; i < rows.Length; i++)
                {
                    if (rows[i] == "")
                        continue;

                    nums = rows[i].Split('\t');

                    if (nums.Length < 13)
                        continue;

                    var weights = new double[14];

                    Tactics.Type tactics = (Tactics.Type)Enum.Parse(typeof(Tactics.Type), nums[0]);

                    int DorA = 0;
                    int.TryParse(nums[1], out DorA);

                    int j;

                    for (j = 2; j < nums.Length-1; j++)
                    {
                        if (nums[j].Length > 0)
                        {
                            if (iFP == null)
                                weights[j - 2] = double.Parse(nums[j]);
                            else
                                weights[j - 2] = double.Parse(nums[j], iFP);
                        }
                    }

                    int SPs = Tactics.StringToeSp(nums[j]);

                    var item = (SPs, weights);

                    var entry = new List <(int SPs, double[])>
                    {
                        item,
                    };

                    var key = (tactics, DorA);

                    if (!dict.ContainsKey(key))
                        dict.Add(key, entry);
                    else
                        dict[key].Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in parsing tactics");
            }

            return dict;
        }
    }

    public class GkTacticsSPosDictionary : Dictionary<(Tactics.Type tactics, int atk), double[]>
    {
        public static GkTacticsSPosDictionary Parse(string s, IFormatProvider iFP = null)
        {
            string[] rows = Regex.Split(s, ";");
            string[] nums;

            GkTacticsSPosDictionary dict = new GkTacticsSPosDictionary();

            try
            {
                for (int i = 0; i < rows.Length; i++)
                {
                    if (rows[i] == "")
                        continue;

                    nums = rows[i].Split('\t');

                    if (nums.Length < 13)
                        continue;

                    var weights = new double[14];

                    Tactics.Type tactics = (Tactics.Type)Enum.Parse(typeof(Tactics.Type), nums[0]);

                    int DorA = 0;
                    int.TryParse(nums[1], out DorA);

                    int j;

                    for (j = 2; j < nums.Length; j++)
                    {
                        if (nums[j].Length > 0)
                        {
                            if(iFP == null)
                                weights[j - 2] = double.Parse(nums[j]);
                            else
                                weights[j - 2] = double.Parse(nums[j], iFP);
                        }
                    }

                    var entry = weights;
                    var key = (tactics, DorA);

                    dict.Add(key, entry);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in parsing tactics");
            }

            return dict;
        }

        public string ToExcelString() // Function returns GkTacticsSPosDictionary as a string file
        {
            string s = "";

            foreach (var entry in this)
            {
                double[] weights = entry.Value;

                int Cols = weights.Length;

                s += entry.Key.tactics.ToString() + '\t';
                s += entry.Key.atk.ToString() + '\t';

                for (int j = 0; j < Cols; j++)
                {
                    s += String.Format("{0:G5}", weights[j]);
                    if (j < Cols - 1)
                    {
                        s += "\t";
                    }
                }

                s += "\r\n";
            }

            return s;
        }

        public string ToString(IFormatProvider iFP) // Function returns GkTacticsSPosDictionary as a string file
        {
            string s = "";

            foreach (var entry in this)
            {
                double[] weights = entry.Value;

                int Cols = weights.Length;

                s += entry.Key.tactics.ToString() + '\t';
                s += entry.Key.atk.ToString() + '\t';

                for (int j = 0; j < Cols; j++)
                {
                    s += String.Format(iFP, "{0:G5}", weights[j]);
                    if (j < Cols - 1)
                    {
                        s += "\t";
                    }
                }

                s += ";...\n";
            }

            s += ";";

            return s.Replace(";...\n;", ";");
        }
    }
}
