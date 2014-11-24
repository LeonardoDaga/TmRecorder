using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Common
{
    public class WindowWrapper : System.Windows.Forms.IWin32Window
    {
        public WindowWrapper(IntPtr handle)
        {
            _hwnd = handle;
        }

        public IntPtr Handle
        {
            get { return _hwnd; }
        }

        private IntPtr _hwnd;
    }

    public class Utility
    {
        public static float[] StringToFloatArray(string val)
        {
            string[] pars = val.Split(';');
            float[] f = new float[pars.Length];
            for (int i = 0; i < pars.Length; i++)
            {
                f[i] = float.Parse(pars[i], CommGlobal.ciUs);
            }
            return f;
        }

        public static float WeightedMean(string sTI)
        {
            string[] TI = sTI.Split(';');

            float g = 1.0f;
            float res = 0;
            float sumg = 0;

            for (int k = TI.Length - 1; (k >= 1) && (g > 0.1f); k--)
            {
                if (TI[k] == "") break;
                res += float.Parse(TI[k], CommGlobal.ciUs) * g;
                sumg += g;
                g *= 0.65f;
            }

            if (sumg == 0) return 0;
            return res / sumg;
        }

        public static string FloatArrayToString(float[] f)
        {
            string parameters = "";
            for (int i = 0; i < f.Length; i++)
            {
                parameters += f[i].ToString(CommGlobal.ciUs);
                if (i < f.Length - 1) parameters += ";";
            }
            return parameters;
        }

        public static string BArray2String(byte[] b)
        {
            string res = "";
            for (int i = 0; i < b.Length; i++)
            {
                res = res + b[i].ToString() + ";";
            }
            return res;
        }

        public static byte[] String2BArray(string s)
        {
            string[] sa = s.Split(';');
            byte[] b = new byte[sa.Length];

            for (int i = 0; i < sa.Length; i++)
            {
                b[i] = 0;
                if (sa[i].Length > 0)
                    b[i] = byte.Parse(sa[i]);
            }
            return b;
        }

        public static Color GradeColor(float grade)
        {
            if (grade < 20)
                return Color.RoyalBlue;
            else if (grade < 30)
                return Color.Cyan;
            else if (grade < 50)
                return Color.Lime;
            else if (grade < 60)
                return Color.Yellow;
            else if (grade < 70)
                return Color.Salmon;
            else if (grade < 85)
                return Color.Red;
            else
                return Color.Violet;
        }

        public static Rectangle StringToRect(string str)
        {
            string[] strs = str.Split(',');
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(int.Parse(strs[0]), int.Parse(strs[1]), int.Parse(strs[2]), int.Parse(strs[3]));
            return rect;
        }

        public static string RectToString(Rectangle rect)
        {
            return rect.X.ToString() + "," + rect.Y.ToString() + "," + rect.Width.ToString() + "," + rect.Height.ToString();
        }
    }

    public class Tm_Training
    {
        public enum eTrainingType
        {
            For = 1,
            Res = 2,
            Vel = 3,
            Mar = 4,
            Con = 5,
            Wor = 6,
            Pos = 7,
            Pas = 8,
            Cro = 9,
            Tec = 10,
            Tes = 11,
            Fin = 12,
            Dis = 13,
            Cal = 14,
            Pre = 4,
            Uno = 5,
            Rif = 6,
            Aer = 7,
            Ele = 8,
            Com = 9,
            Tir = 10,
            Lan = 11,
        }

        public static UInt64 OldTdsGiocatoriToTrCode2(TrainingDataSet.GiocatoriRow gr)
        {
            UInt64 res = 0;

            try
            {
                UInt64 fact = 1;
                for (int i = 1; i <= 14; i++, fact <<= 3)
                {
                    decimal tr = (decimal)gr[i];
                    UInt64 val = (UInt64)((int)tr + 2);
                    res = res + val * fact;
                }
            }
            catch (Exception)
            {
            }

            return res;
        }

        public static int[] OldTdsGiocatoriToTrCode(TrainingDataSet.GiocatoriRow gr)
        {
            int[] res = new int[2];
            res[0] = 0;
            res[1] = 0;

            try
            {
                int fact;
                for (int i = 1; i <= 14; i++)
                {
                    fact = 1 << (2 * i - 2);
                    if ((decimal)gr[i] == 1) res[0] += fact;
                    if ((decimal)gr[i] == -1) res[1] += fact;
                    fact = 1 << (2 * i - 1);
                    if ((decimal)gr[i] == 2) res[0] += fact;
                    if ((decimal)gr[i] == -2) res[1] += fact;
                }
            }
            catch (Exception ex)
            {
            }

            return res;
        }

        public static int[] OldTdsPortieriToTrCode(TrainingDataSet.PortieriRow pr)
        {
            int[] res = new int[2];
            res[0] = 0;
            res[1] = 0;

            int fact;
            for (int i = 1; i <= 11; i++)
            {
                fact = 1 << (2 * i - 2);
                if ((decimal)pr[i] == 1) res[0] += fact;
                if ((decimal)pr[i] == -1) res[1] += fact;
                fact = 1 << (2 * i - 1);
                if ((decimal)pr[i] == 2) res[0] += fact;
                if ((decimal)pr[i] == -2) res[1] += fact;
            }

            return res;
        }

        public static UInt64 OldTdsPortieriToTrCode2(TrainingDataSet.PortieriRow gr)
        {
            UInt64 res = 0;

            try
            {
                UInt64 fact = 1;
                for (int i = 1; i <= 11; i++, fact <<= 3)
                {
                    decimal tr = (decimal)gr[i];
                    UInt64 val = (UInt64)((int)tr + 2);
                    res = res + val * fact;
                }
            }
            catch (Exception)
            {
            }

            return res;
        }


        public static int TrCode2ToTrValue(UInt64 trCode, eTrainingType tType)
        {
            int i = (int)tType - 1;

            trCode >>= (3 * i);
            trCode &= 0x111;
            return (int)trCode - 2;
        }

        public static int TrCodeToTrValue(int[] trCode, eTrainingType tType)
        {
            int i = (int)tType;
            int fact;

            fact = 1 << (2 * i - 2);
            if ((trCode[0] & fact) > 0) return 1;
            if ((trCode[1] & fact) > 0) return -1;
            fact = 1 << (2 * i - 1);
            if ((trCode[0] & fact) > 0) return 2;
            if ((trCode[1] & fact) > 0) return -2;

            return 0;
        }
    }

    public class Tm_Utility
    {

        public static int ASItoWage(int ASI)
        {
            return ((int)(ASI * 23.75) < 30000) ? 30000 : (int)(ASI * 23.75);
        }

        public static decimal ASItoTI(decimal newASI, decimal oldASI, bool isGK)
        {
            decimal ssNew = ASItoSkSum(newASI, isGK);
            decimal ssOld = ASItoSkSum(oldASI, isGK);
            return 10.0M * (ssNew - ssOld);
        }

        public static float ASItoSkSum(float ASI, bool isGK)
        {
            double agk = 0.0297292420703342;
            double apl = 0.0233588510610715;
            if (isGK)
                return (float)(Math.Pow((double)ASI, 0.142857142857143) / agk);
            else
                return (float)(Math.Pow((double)ASI, 0.142857142857143) / apl);
        }

        public static decimal ASItoSkSum(decimal ASI, bool isGK)
        {
            return (decimal)ASItoSkSum((float)ASI, isGK);
        }

        public static float SkSumToASI(float skSum, bool isGK)
        {
            double agk = 0.0297292420703342;
            double apl = 0.0233588510610715;
            if (isGK)
                return (float)Math.Pow(agk * (double)skSum, 7.0);
            else
                return (float)Math.Pow(apl * (double)skSum, 7.0);
        }

        public static decimal SkSumToASI(decimal skSum, bool isGK)
        {
            return (decimal)SkSumToASI((float)skSum, isGK);
        }

        public static int FPToNumber(string p)
        {
            p = TM_Compatible.ConvertNewFP(p);
            switch (p)
            {
                case "GK": return 0;
                case "DC": return 10;
                case "DC/DL": return 11;
                case "DL/DC": return 11;
                case "DR/DC": return 12;
                case "DC/DR": return 12;
                case "DL": return 13;
                case "DL/DR": return 14;
                case "DR/DL": return 14;
                case "DR": return 15;
                case "DC/DMC": return 20;
                case "DMC/DC": return 20;
                case "DL/DML": return 21;
                case "DML/DL": return 21;
                case "DMR/DR": return 22;
                case "DR/DMR": return 22;
                case "DMC": return 30;
                case "DMC/DML": return 31;
                case "DMC/DMR": return 32;
                case "DML/DMC": return 31;
                case "DMR/DMC": return 32;
                case "DML": return 33;
                case "DML/DMR": return 34;
                case "DMR/DML": return 34;
                case "DMR": return 35;
                case "DMC/MC": return 40;
                case "MC/DMC": return 40;
                case "DML/ML": return 41;
                case "ML/DML": return 41;
                case "DMR/MR": return 42;
                case "MR/DMR": return 42;
                case "MC": return 50;
                case "MC/ML": return 51;
                case "ML/MC": return 51;
                case "MC/MR": return 52;
                case "MR/MC": return 52;
                case "ML": return 53;
                case "ML/MR": return 54;
                case "MR/ML": return 54;
                case "MR": return 55;
                case "MC/OMC": return 60;
                case "OMC/MC": return 60;
                case "ML/OML": return 61;
                case "OML/ML": return 61;
                case "MR/OMR": return 62;
                case "OMR/MR": return 62;
                case "OMC": return 70;
                case "OMC/OML": return 71;
                case "OML/OMC": return 71;
                case "OMC/OMR": return 72;
                case "OMR/OMC": return 72;
                case "OML": return 73;
                case "OML/OMR": return 74;
                case "OMR/OML": return 74;
                case "OMR": return 75;
                case "FC/OMC": return 80;
                case "OMC/FC": return 80;
                case "FC/OML": return 81;
                case "OML/FC": return 81;
                case "FC/OMR": return 82;
                case "OMR/FC": return 82;
                case "FC": return 90;
                default: break;
            }

            return -1;
        }

        public static float GetSkSumFromASI(int ASI, bool isGK)
        {
            return ASItoSkSum((float)ASI, isGK);
        }
    }

    public class CommGlobal
    {
        public static System.Globalization.CultureInfo ciUs = new System.Globalization.CultureInfo("en-US");
        public static System.Globalization.CultureInfo ciIt = new System.Globalization.CultureInfo("it-IT");
    }

    public class TM_Compatible
    {
        // D/DM L ==> DL/DML
        public static string ConvertNewFP(string FP)
        {
            FP = FP.Replace("\xa0", " ");

            string oldfp = "";
            string newfp = FP;

            newfp = newfp.Replace(" /", "/").Replace("/ ", "/");

            if (newfp.Contains(","))
            {
                string[] fo = newfp.Split(',');
                oldfp = ConvertNewFP(fo[0]) + "/FC";
                return oldfp;
            }

            if (newfp.Contains("F") && !newfp.Contains("FC"))
                newfp = newfp.Replace("F", "FC");
            if (newfp == "F") return "FC";
            if (!newfp.Contains(" ")) return newfp;

            string[] fp = newfp.Split(' ');
            string[] pos = fp[0].Split('/');


            if (fp[1].Length < 2)
            {
                if (pos.Length < 2)
                {
                    oldfp = fp[0] + fp[1];
                }
                else
                {
                    oldfp = pos[0] + fp[1] + "/" + pos[1] + fp[1];
                }
            }
            else
            {
                oldfp = pos[0] + fp[1][0] + "/" + pos[0] + fp[1][1];
            }

            return oldfp;
        }
    }

    public class TmSWD
    {
        public int Day {get; set;}
        public int Week  {get; set;}
        public int Season {get; set;}
        public int AbsWeek { get { return (Season - 1) * 12 + (Week - 1); } }
        public DateTime Date
        {
            get
            {
                TmWeek tmw = new TmWeek(Season, Week);
                return tmw.ToDate().AddDays(Day);
            }
        }

        public TmSWD(int absWeek)
        {
            Season = absWeek / 12 + 1;
            Week = absWeek - (Season-1) * 12 + 1;
            Day = 0;
        }

        public TmSWD(DateTime dateTime)
        {
            Season = TmWeek.GetSeason(dateTime);
            Week = TmWeek.GetTmAbsWk(dateTime) - (Season - 1) * 12;
            Day = TmWeek.GetTmAbsDay(dateTime) - (Season - 1) * 12 * 7 - (Week) * 7;
        }

        public override string ToString()
        {
            return string.Format("S{0}-W{1}-D{2}", Season.ToString("00"), Week.ToString("00"), Day);
        }
    }

    public class TmWeek
    {
        public int absweek = -1;

        // Timebase is the first tuesday of the first TM season
        public static readonly DateTime tmDay0 = new DateTime(2006, 1, 10, new System.Globalization.GregorianCalendar());

        public static TmWeek thisWeek()
        {
            return new TmWeek(DateTime.Now);
        }

        public TmWeek()
        {
        }

        public TmWeek(DateTime dt)
        {
            absweek = GetTmAbsWk(dt);
        }

        public TmWeek(int absWeek)
        {
            absweek = absWeek;
        }

        public TmWeek(string dayOrtmWeek)
        {
            if (dayOrtmWeek.Contains("/"))
            {
                DateTime dt = DateTime.Parse(dayOrtmWeek);
                absweek = GetTmAbsWk(dt);
            }
            else if (dayOrtmWeek[0] == 'S')
            {
                string[] spl = dayOrtmWeek.Split('-');
                int season = int.Parse(spl[0].Substring(1));
                int week = int.Parse(spl[1].Substring(1));
                absweek = (season - 1) * 12 + (week);
            }
            else if (dayOrtmWeek.Contains("-"))
            {
                string[] spl = dayOrtmWeek.Split('-');
                int season = int.Parse(spl[0]);
                int week = int.Parse(spl[1]);
                absweek = (season - 1) * 12 + (week - 1);
            }
        }

        public TmWeek(int season, int week)
        {
            absweek = (season - 1) * 12 + (week - 1);
        }

        public static TmWeek operator -(TmWeek week, int weekToSub)
        {
            return new TmWeek((int)(week.absweek - weekToSub));
        }

        public static TmWeek operator +(TmWeek week, int weekToAdd)
        {
            return new TmWeek((int)(week.absweek + weekToAdd));
        }

        static public int GetTmAbsWk(DateTime dt)
        {
            TimeSpan ts = dt - tmDay0;
            return (int)(ts.TotalDays / 7);
        }

        static public int GetTmAbsDay(DateTime dt)
        {
            TimeSpan ts = dt - tmDay0;
            return (int)(ts.TotalDays);
        }

        static public TmWeek GetAge(int absWeekBorn, DateTime now)
        {
            TmWeek tmNow = new TmWeek(now);
            return new TmWeek(tmNow.absweek - absWeekBorn);
        }

        public int Season
        {
            get { return (int)(1 + absweek / 12); }
        }

        public int Week
        {
            get { return (int)(1 + absweek % 12); }
        }

        public int Years
        {
            get { return (int)(absweek / 12); }
        }

        public int Months
        {
            get { return (int)(absweek % 12); }
        }

        public override string ToString()
        {
            return Season.ToString() + "-" + Week.ToString();
        }

        public DateTime ToDate()
        {
            return tmDay0.AddDays(7 * absweek);
        }

        public static string GenerateDatesString(int iniWeek, int thisWeek, char separator)
        {
            string str = "";
            TmWeek tmw = new TmWeek(0);

            for (int i = iniWeek; i <= thisWeek; i++)
            {
                tmw.absweek = i;
                str += "TW " + tmw.ToString() + separator;
            }

            return str;
        }

        public static int GetBornWeekFromAge(DateTime refDate, string Age)
        {
            TmWeek tmwNow = new TmWeek(refDate);
            string[] split = Age.Split(' ');
            int i = 0;
            int years = 0, month = 0;
            for (; i < split.Length; i++)
                if (int.TryParse(split[i], out years)) break;
            i++;

            for (; i < split.Length; i++)
                if (int.TryParse(split[i], out month)) break;

            if ((years == 0) && (month == 0)) return -1;

            int bornWeek = tmwNow.absweek - years * 12 - month;

            return bornWeek;
        }

        public static int GetBornWeekFromAge(DateTime refDate, int month, int years)
        {
            TmWeek tmwNow = new TmWeek(refDate);

            int bornWeek = tmwNow.absweek - years * 12 - month;

            return bornWeek;
        }

        public string ToAge(DateTime tmnow)
        {
            TmWeek tmwnow = new TmWeek(tmnow);
            int nWeek = tmwnow.absweek - this.absweek;
            TmWeek tmYears = new TmWeek(nWeek);
            return tmYears.Years.ToString() + "y " + tmYears.Months.ToString() + "m";
        }

        public static int GetSeason(DateTime dateTime)
        {
            TmWeek tmw = new TmWeek(dateTime);
            return tmw.Season;
        }

        public static DateTime GetDateTimeOfSeasonStart(int Season)
        {
            TmWeek tmw = new TmWeek(Season, 1);
            return tmw.ToDate();
        }

        public static TmWeek FromAge(int valY, int valM)
        {
            return new TmWeek(valY + 1, valM + 1);
        }

        public string ToAge(Languages.ILanguage iLanguage)
        {
            int nWeek = this.absweek;
            TmWeek tmYears = new TmWeek(nWeek);
            return tmYears.Years.ToString() + "y " + tmYears.Months.ToString() + "m";
        }

        public static string ToSWDString(DateTime dateTime)
        {
            int season = GetSeason(dateTime);
            int week = GetTmAbsWk(dateTime) - (season - 1) * 12;
            int day = GetTmAbsDay(dateTime) - (season - 1) * 12 * 7 - (week) * 7;

            return string.Format("S{0}-W{1}-D{2}", season.ToString("00"), week.ToString("00"), day);
        }

        public static DateTime SWDtoDateTime(string swdTime)
        {
            try
            {
                string[] spl = swdTime.Split('-');
                int season = int.Parse(spl[0].Substring(1));
                int week = int.Parse(spl[1].Substring(1));
                int day = int.Parse(spl[2].Substring(1));

                TmWeek tmw = new TmWeek(season, week);
                return tmw.ToDate().AddDays(day);
            }
            catch (Exception ex)
            {
                return DateTime.MinValue;
            }
        }

        public static TmSWD TmWeekToSWD(int tmweek)
        {
            DateTime dt = tmDay0.AddDays(7 * (tmweek + 1));
            return new TmSWD(dt);
        }
    }
}
