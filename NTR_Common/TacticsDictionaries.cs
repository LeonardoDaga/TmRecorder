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

    public class TAC_Tac2ActWeights
    {
        public TAC_Tac2ActWeights(double[] weights, Tactics.Type tactics)
        {
            Tactics = tactics.ToString();
            Tactics.backColor = Color.LightYellow;

            Sho = weights[0];
            Cro = weights[1];
            Lon = weights[2];
            Dir = weights[3];
            Fil = weights[4];
            Fre = weights[5];
            Cor = weights[6];
            Pen = weights[7];
        }

        public FormattedString Tactics { get; set; }
        public double Sho { get; set; }
        public double Cro { get; set; }
        public double Lon { get; set; }
        public double Dir { get; set; }
        public double Fil { get; set; }
        public double Fre { get; set; }
        public double Cor { get; set; }
        public double Pen { get; set; }

        public double[] Row => new double[]
            {Sho,Cro,Lon,
            Dir,Fil,Fre,
            Cor,Pen};
    }

    public class TAC_PossessionWeights
    {
        public TAC_PossessionWeights(double[] weights, Tactics.Possession mode)
        {
            Mode = mode.ToString();
            Mode.backColor = Color.LightGray;

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

        public FormattedString Mode { get; set; }
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

        public double[] Row => new double[]
            {Str,Sta,Pac,
            Mar,Tac,Wor,
            Pos,Pas,Cro,
            Tec,Hea,Fin,
            Lon,Set};
    }

    public class TAC_ActionWeights
    {
        public TAC_ActionWeights(double[] weights, Tactics.ActionType actionType, int sps)
        {
            Tactics = actionType.ToString();
            Tactics.backColor = Color.LightGray;

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

    public class Tactics
    {
        public enum Type
        {
            Dir,
            Win,
            Sho,
            Lon,
            Thr,
            Std,
            Tot
        }

        public enum ActionType
        {
            Shp,
            Win,
            Lon,
            Dir,
            Thr,
            Fre,
            Cor,
            Pen,
            Tot
        }

        public enum Possession : int
        {
            Keeping = 0,
            Gaining = 1
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

        #region WeightListToDict
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

        public static TacticsToAcionDictionary WeightListToDict(List<TAC_Tac2ActWeights> _tac2Actweights)
        {
            TacticsToAcionDictionary dict = new TacticsToAcionDictionary();

            try
            {
                for (int i = 0; i < _tac2Actweights.Count; i++)
                {
                    TAC_Tac2ActWeights weights = _tac2Actweights[i];

                    Tactics.Type tactics = (Tactics.Type)Enum.Parse(typeof(Tactics.Type), weights.Tactics.ToString());

                    var key = tactics;

                    dict.Add(key, weights.Row);
                }
            }
            catch (FormatException) { throw new MException("Wrong input format!"); }
            return dict;
        }

        public static PossessionDictionary WeightListToDict(List<TAC_PossessionWeights> _tac2Actweights)
        {
            PossessionDictionary dict = new PossessionDictionary();

            try
            {
                for (int i = 0; i < _tac2Actweights.Count; i++)
                {
                    TAC_PossessionWeights weights = _tac2Actweights[i];

                    Tactics.Possession mode = (Tactics.Possession)Enum.Parse(typeof(Tactics.Possession), weights.Mode.ToString());

                    var key = mode;

                    dict.Add(key, weights.Row);
                }
            }
            catch (FormatException) { throw new MException("Wrong input format!"); }
            return dict;
        }

        public static ActionDictionary WeightListToDict(List<TAC_ActionWeights> _tac2Actweights)
        {
            ActionDictionary dict = new ActionDictionary();

            try
            {
                for (int i = 0; i < _tac2Actweights.Count; i++)
                {
                    TAC_ActionWeights weights = _tac2Actweights[i];

                    Tactics.ActionType tactics = (Tactics.ActionType)Enum.Parse(typeof(Tactics.ActionType), weights.Tactics.ToString());
                    int SPs = Tactics.StringToeSp(weights.FPos.ToString());

                    var key = (tactics, SPs);

                    dict.Add(key, weights.Row);
                }
            }
            catch (FormatException) { throw new MException("Wrong input format!"); }
            return dict;
        }
        #endregion
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

    public class TacticsToAcionDictionary : Dictionary<Tactics.Type, double[]>
    {
        public static TacticsToAcionDictionary Parse(string s, IFormatProvider iFP = null)
        {
            string[] rows = Regex.Split(s, ";");
            string[] nums;

            TacticsToAcionDictionary dict = new TacticsToAcionDictionary();

            try
            {
                for (int i = 0; i < rows.Length; i++)
                {
                    if (rows[i] == "")
                        continue;

                    nums = rows[i].Split('\t');

                    if (nums.Length < 8)
                        continue;

                    var weights = new double[8];

                    Tactics.Type tactics = (Tactics.Type)Enum.Parse(typeof(Tactics.Type), nums[0]);

                    int j;

                    for (j = 1; j < nums.Length; j++)
                    {
                        if (nums[j].Length > 0)
                        {
                            if (iFP == null)
                                weights[j - 1] = double.Parse(nums[j]);
                            else
                                weights[j - 1] = double.Parse(nums[j], iFP);
                        }
                    }

                    var entry = weights;
                    var key = tactics;

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

                s += entry.Key.ToString() + '\t';

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

                s += entry.Key.ToString() + '\t';

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

    public class PossessionDictionary : Dictionary<Tactics.Possession, double[]>
    {
        public static PossessionDictionary Parse(string s, IFormatProvider iFP = null)
        {
            string[] rows = Regex.Split(s, ";");
            string[] nums;

            PossessionDictionary dict = new PossessionDictionary();

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

                    Tactics.Possession possession = (Tactics.Possession)Enum.Parse(typeof(Tactics.Possession), nums[0]);

                    int j;

                    for (j = 1; j < nums.Length; j++)
                    {
                        if (nums[j].Length > 0)
                        {
                            if (iFP == null)
                                weights[j - 1] = double.Parse(nums[j]);
                            else
                                weights[j - 1] = double.Parse(nums[j], iFP);
                        }
                    }

                    var entry = weights;
                    var key = possession;

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

                s += entry.Key.ToString() + '\t';

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

                s += entry.Key.ToString() + '\t';

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

    public class ActionDictionary : Dictionary<(Tactics.ActionType actionType, int SPs), double[]>
    {
        public static ActionDictionary Parse(string s, IFormatProvider iFP = null)
        {
            string[] rows = Regex.Split(s, ";");
            string[] nums;

            ActionDictionary dict = new ActionDictionary();

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

                    Tactics.ActionType actionType = (Tactics.ActionType)Enum.Parse(typeof(Tactics.ActionType), nums[0]);

                    int SPs = Tactics.StringToeSp(nums[1]);

                    int j;

                    for (j = 2; j < nums.Length; j++)
                    {
                        if (nums[j].Length > 0)
                        {
                            if (iFP == null)
                                weights[j - 2] = double.Parse(nums[j]);
                            else
                                weights[j - 2] = double.Parse(nums[j], iFP);
                        }
                    }

                    var entry = weights;
                    var key = (actionType, SPs);

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

                s += entry.Key.actionType.ToString() + '\t';
                s += Tactics.eSpToString(entry.Key.SPs)+ '\t';

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

                s += entry.Key.actionType.ToString() + '\t';
                s += Tactics.eSpToString(entry.Key.SPs) + '\t';

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
