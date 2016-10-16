using System;
using System.Collections.Generic;
using System.Text;
using ZedGraph;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using TMRecorder.Properties;
using Common;
using Languages;
using System.Text.RegularExpressions;

namespace TMRecorder
{
    public class CommGlobal
    {
        public static System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
    }

    public class SkillVariation
    {
        public int posDeltaSk = 0;
        public int posDeltaDec = 0;
        public int negDeltaSk = 0;
        public int negDeltaDec = 0;
        public int totCount = 0;

        public static SkillVariation operator +(SkillVariation sv1, SkillVariation sv2)
        {
            SkillVariation sv = sv1;
            sv.posDeltaSk += sv2.posDeltaSk;
            sv.posDeltaDec += sv2.posDeltaDec;
            sv.negDeltaSk += sv2.negDeltaSk;
            sv.negDeltaDec += sv2.negDeltaDec;
            sv.totCount += sv2.totCount;
            return sv;
        }

        public static SkillVariation Calc(decimal actualval, decimal lastval)
        {
            SkillVariation sv = new SkillVariation();

            if ((int)actualval > (int)lastval)
            {
                sv.posDeltaSk = 1;
            }
            else if (actualval > lastval)
            {
                sv.posDeltaDec = 1;
            }
            else if ((int)actualval < (int)lastval)
            {
                sv.negDeltaSk = 1;
            }
            else if (actualval < lastval)
            {
                sv.negDeltaDec = 1;
            }

            return sv;
        }

        public static SkillVariation Calc(ExtTMDataSet.PlayerHistoryRow actual,
                                          ExtTMDataSet.PlayerHistoryRow last)
        {
            SkillVariation sv = new SkillVariation();
            sv += SkillVariation.Calc(actual.For, last.For);
            sv += SkillVariation.Calc(actual.Res, last.Res);
            sv += SkillVariation.Calc(actual.Vel, last.Vel);
            sv += SkillVariation.Calc(actual.Mar, last.Mar);
            sv += SkillVariation.Calc(actual.Con, last.Con);
            sv += SkillVariation.Calc(actual.Wor, last.Wor);
            sv += SkillVariation.Calc(actual.Pos, last.Pos);
            sv += SkillVariation.Calc(actual.Pas, last.Pas);
            sv += SkillVariation.Calc(actual.Cro, last.Cro);
            sv += SkillVariation.Calc(actual.Tec, last.Tec);
            sv += SkillVariation.Calc(actual.Tes, last.Tes);
            sv += SkillVariation.Calc(actual.Fin, last.Fin);
            sv += SkillVariation.Calc(actual.Lon, last.Lon);
            sv += SkillVariation.Calc(actual.Set, last.Set);

            return sv;
        }
    }

    class Utility
    {
        static public double TrainingWeeksInDates(double dFrom, double dTo)
        {
            DateTime dtFrom = XDate.XLDateToDateTime(dFrom);
            DateTime dtTo = XDate.XLDateToDateTime(dTo);

            // Move to the past tuesday
            if (dtFrom.DayOfWeek > DayOfWeek.Tuesday)
                dtFrom = dtFrom.AddDays(-(dtFrom.DayOfWeek - DayOfWeek.Tuesday));
            else if (dtFrom.DayOfWeek < DayOfWeek.Tuesday)
                dtFrom = dtFrom.AddDays(-(5 + dtFrom.DayOfWeek - DayOfWeek.Sunday));

            // Move to the past tuesday
            if (dtTo.DayOfWeek > DayOfWeek.Tuesday)
                dtTo = dtTo.AddDays(-(dtTo.DayOfWeek - DayOfWeek.Tuesday));
            else if (dtTo.DayOfWeek < DayOfWeek.Tuesday)
                dtTo = dtTo.AddDays(-(5 + dtTo.DayOfWeek - DayOfWeek.Sunday));

            TimeSpan ts = dtTo - dtFrom;
            return (double)ts.Days / 7;
        }

        static public int TmWeek(DateTime dt)
        {
            int d = dt.DayOfYear;
            int rest = (dt.DayOfYear - (int)dt.DayOfWeek) % 7;
            return (4 + d - rest) / 7;
        }

        static public bool IsInTheSameTmWeek(DateTime dt1, DateTime dt2)
        {
            TmWeek tmw1 = new TmWeek(dt1);
            TmWeek tmw2 = new TmWeek(dt2);

            return (tmw1.absweek == tmw2.absweek);

            //int d1 = dt1.DayOfYear;
            //int d2 = dt2.DayOfYear;
            //int rest = (dt1.DayOfYear - (int)dt1.DayOfWeek) % 7;
            //int w1 = (5 + d1 - rest) / 7;
            ////int rem1 = (5 + d1 - rest) % 7;
            //int w2 = (5 + d2 - rest) / 7;
            ////int rem2 = (5 + d2 - rest) % 7;
            //return (w1 == w2);
        }

        internal static void OpenPage(string arg)
        {
            if (Program.Setts.UseTMRBrowser)
            {
                string processName = Application.StartupPath + "/TMRBrowser.exe";
                FileInfo fi = new FileInfo(processName);

                if (!fi.Exists)
                    MessageBox.Show(Current.Language.TheTMRBrowserTMRBrowserExeDoesnTExistAtTheGivenPath +
                        Application.StartupPath + ")", "TM Recorder", MessageBoxButtons.OK);
                else
                    Process.Start(processName, arg);
            }
            else
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(arg);
                // startInfo.Arguments = arg;
                try
                {
                    Process.Start(startInfo);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error starting a web application for the web page: " + arg);
                }
            }
        }

        internal static bool IsNumeric(string name)
        {
            return Regex.IsMatch(name, @"^\d+$");
        }
    }
}
