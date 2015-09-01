using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using TMRecorder.Properties;
using System.Globalization;
using Common;
using SendFileTo;
using Languages;
using System.Diagnostics;
using NTR_Common;

namespace TMRecorder
{
    public class TDSComparer : IComparer<ExtTMDataSet>
    {
        public int Compare(ExtTMDataSet x, ExtTMDataSet y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    return x.Date.CompareTo(y.Date);
                }
            }
        }
    }

    public class ListTrainingDataSet : List<TrainingDataSet>
    {
        public bool sorted = false;

        internal TrainingDataSet LastTraining()
        {
            if (!sorted)
            {
                this.Sort(CompareTrainingByDate);
                sorted = true;
            }

            return this[0];
        }

        public new void Add(TrainingDataSet tds)
        {
            base.Add(tds);
            sorted = false;
        }

        public new void Insert(int index, TrainingDataSet tds)
        {
            base.Insert(index, tds);
            sorted = false;
        }

        public static int CompareTrainingByDate(TrainingDataSet tds1, TrainingDataSet tds2)
        {
            if (tds1.WeekNoData[0].Date == tds2.WeekNoData[0].Date)
                return 0;
            else if (tds1.WeekNoData[0].Date > tds2.WeekNoData[0].Date)
                return -1;
            else
                return 1;
        }
    }

    public class TeamHistory : List<ExtTMDataSet>
    {
        public Gain_Function PFun = null;
        public ExtraDS PlayersDS = null;
        public float release = 1.0f;
        public ListTrainingDataSet TrainingHist = new ListTrainingDataSet();
        public TrainersSkills dbTrainers = null;
        public ExtTMDataSet actualDts = null;
        public TeamDS teamDS = new TeamDS();
        public ReportParser reportParser = null;

        public Common.GainDS GD
        {
            get { return PFun.gds; }
        }

        public TeamHistory()
        {
            //if (Program.Setts.GainFunction == Gain_Function.FunctionType.RusCheratte)
            //    PFun = new RusCheratte_Function();
            //else if (Program.Setts.GainFunction == Gain_Function.FunctionType.AtleticoCassina)
            //    PFun = new AtleticoCassina_Function();
            //else
            //    PFun = new RusCheratte_Function();
            PFun = new RusCheratte_Function();

            PFun.gds = new Common.GainDS();

            GD.funRou = new Common.Function(Program.Setts.RouFunction, Program.Setts.RouParams);
        }

        private void AddData(TrainingDataSet trainingDataSet)
        {
            ApplyTI_TrainingDataSet(PlayersDS, trainingDataSet);

            int ix = 0;

            // Update the Training DataSet
            for (; ix < TrainingHist.Count; ix++)
            {
                if (Utility.IsInTheSameTmWeek(TrainingHist[ix].Date, trainingDataSet.Date))
                {
                    if (MessageBox.Show(Current.Language.ThereIsAlreadyATrainingDataSetInTheSameWeekOfTheOneYouAreAdding +
                        Current.Language.DoYouWantToReplaceTheDataSetThatIsInTheSameWeek,
                        Current.Language.TrainingLoad, MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                    else
                    {
                        TrainingHist.RemoveAt(ix);
                        TrainingHist.Insert(ix, trainingDataSet);
                        DisplayStats(trainingDataSet, null, null);
                        break;
                    }
                }
            }

            if (ix == TrainingHist.Count)
            {
                // Find the right place where to insert the data set
                for (ix = 0; ix < TrainingHist.Count; ix++)
                {
                    if (TrainingHist[ix].Date < trainingDataSet.Date) continue;

                    break;
                }

                // Found!
                TrainingHist.Insert(ix, trainingDataSet);
                DisplayStats(trainingDataSet, null, null);
            }

            for (ix = 0; ix < this.Count; ix++)
            {
                if (this[ix].Date < trainingDataSet.Date) continue;

                break;
            }

            if (ix == this.Count)
            {
                MessageBox.Show(Current.Language.ThereMustBeAtLeastASquadDataSetAfterOrInTheSameDateOfATrainingSession +
                    Current.Language.LoadASquadFileFirst, Current.Language.TrainingLoad, MessageBoxButtons.OK);
                return;
            }

            int ixAfter = ix;
            for (ix = ixAfter; ix < this.Count; ix++)
            {
                this[ix].IncSkill_TrainingDataSet(trainingDataSet, this[ixAfter]);
            }
            for (ix = ixAfter - 1; ix >= 0; ix--)
            {
                this[ix].DecSkill_TrainingDataSet(trainingDataSet, this[ixAfter]);
            }
        }

        private void DisplayStats(TrainingDataSet tds, SkillVariation sv,
                                   TeamStats.GrowthHistoryRow gsRow)
        {
            int lg = 0, dg = 0, lr = 0, dr = 0;
            decimal tsiCount = 0.0M;
            int cg = 0, cp = 0;
            string stats = "";
            int ct = 0;

            if (tds != null)
            {
                foreach (TrainingDataSet.GiocatoriRow tdsRow in tds.Giocatori)
                {
                    for (int skill = 1; skill <= 14; skill++)
                    {
                        if ((decimal)tdsRow.ItemArray[skill] == 1M) lg++;
                        if ((decimal)tdsRow.ItemArray[skill] == 2M) dg++;
                        if ((decimal)tdsRow.ItemArray[skill] == -2M) dr++;
                        if ((decimal)tdsRow.ItemArray[skill] == -1M) lr++;
                    }
                    tsiCount += (decimal)tdsRow.TI;
                }

                foreach (TrainingDataSet.PortieriRow tdsRow in tds.Portieri)
                {
                    for (int skill = 1; skill <= 11; skill++)
                    {
                        if ((decimal)tdsRow.ItemArray[skill] == 1M) lg++;
                        if ((decimal)tdsRow.ItemArray[skill] == 2M) dg++;
                        if ((decimal)tdsRow.ItemArray[skill] == -2M) dr++;
                        if ((decimal)tdsRow.ItemArray[skill] == -1M) lr++;
                    }

                    tsiCount += (decimal)tdsRow.TI;
                }

                cg = tds.Giocatori.Count;
                cp = tds.Portieri.Count;

                ct = cp + cg;

                stats = Current.Language.TrophyManagerReportLightGreenArrows + lg.ToString() + "\r\n";
                stats += Current.Language.DarkGreenArrows + dg.ToString() + "\r\n";
                stats += Current.Language.LightRedArrows + lr.ToString() + "\r\n";
                stats += Current.Language.DarkRedArrows + dr.ToString() + "\r\n";
                stats += Current.Language.TotalTeamTI + tsiCount.ToString() + "\r\n\r\n";
                stats += Current.Language.TrophyManagerStatisticsDeltaSkills + dg.ToString() + "/-" + dr.ToString() + "\r\n";
                stats += Current.Language.Mean + ((float)dg / (float)ct).ToString("N2") + "/-" + ((float)dr / (float)ct).ToString("N2") + "\r\n";
                stats += Current.Language.DeltaDecimals + lg.ToString() + "/-" + lr.ToString() + "\r\n";
                stats += Current.Language.TotalMean + (((float)dg + (float)lg / 10f) / (float)ct).ToString("N2") + "/-" + (((float)dr + (float)lr / 10f) / (float)ct).ToString("N2") + "\r\n";
            }
            else
            {
                stats = Current.Language.TrophyManagerReportStillNotAvailableForThisWeek;

                ct = sv.totCount;
            }


            if (sv != null)
            {
                dg = sv.posDeltaSk; lg = sv.posDeltaDec;
                dr = sv.negDeltaSk; lr = sv.negDeltaDec;
                stats += "\r\n" + Current.Language.TrophyManagerReportLightGreenArrows + lg.ToString() + "\r\n";
                stats += Current.Language.DarkGreenArrows + dg.ToString() + "\r\n";
                stats += Current.Language.LightRedArrows + lr.ToString() + "\r\n";
                stats += Current.Language.DarkRedArrows + dr.ToString() + "\r\n";
                stats += Current.Language.TMRecorderStatisticsDeltaSkills + dg.ToString() + "/-" + dr.ToString() + "\r\n";
                stats += Current.Language.Mean + ((float)dg / (float)ct).ToString("N2") + "/-" + ((float)dr / (float)ct).ToString("N2") + "\r\n";
                stats += Current.Language.DeltaDecimals + lg.ToString() + "/-" + lr.ToString() + "\r\n";
                stats += Current.Language.TotalMean + (((float)dg + (float)lg / 10f) / (float)ct).ToString("N2") + "/-" + (((float)dr + (float)lr / 10f) / (float)ct).ToString("N2") + "\r\n";
            }

            if (gsRow != null)
            {
                if (tds == null) stats += Current.Language.WarningTEMPORARY;
                stats += Current.Language.RealDeltaSkills + gsRow.DeltaSkillPos.ToString() + "/" + gsRow.DeltaSkillNeg.ToString() + "\r\n";
                stats += Current.Language.RealMean + (((float)gsRow.DeltaSkillPos) / (float)ct).ToString("N2") + "/" + (((float)gsRow.DeltaSkillNeg) / (float)ct).ToString("N2") + "\r\n";
            }

            StatisticsBox sb = new StatisticsBox();
            sb.txtTextStatistics.Text = stats;
            sb.ShowDialog();
        }

        private void AddData(Db_TrophyDataSet db_TrophyDataSet, short isReserves)
        {
            int ix = 0;

            for (; ix < this.Count; ix++)
            {
                if (this[ix].Date < db_TrophyDataSet.Date) continue;

                break;
            }

            if ((ix < this.Count) && (this[ix].Date == db_TrophyDataSet.Date))
            {
                // Dataset already exist: substitute data
                ExtTMDataSet eds = this[ix];

                if (ix > 0)
                    eds.FillWithDb_TrophyDataSet(PlayersDS, db_TrophyDataSet, PFun, this[ix - 1],
                        isReserves, Program.Setts.TeamDataFolder);
                else
                    eds.FillWithDb_TrophyDataSet(PlayersDS, db_TrophyDataSet, PFun, null,
                        isReserves, Program.Setts.TeamDataFolder);
            }
            else
            {
                // New data set, create a new one

                // Fill ExtTMDataSet with Db_TrophyDataSet
                ExtTMDataSet eds = new ExtTMDataSet();

                if (ix > 0)
                    eds.FillWithDb_TrophyDataSet(PlayersDS, db_TrophyDataSet, PFun, this[ix - 1],
                        isReserves, Program.Setts.TeamDataFolder);
                else
                    eds.FillWithDb_TrophyDataSet(PlayersDS, db_TrophyDataSet, PFun, null,
                        isReserves, Program.Setts.TeamDataFolder);

                this.Insert(ix, eds);
            }
        }

        private void AddData_NewTM(Db_TrophyDataSet db_TrophyDataSet)
        {
            int ix = 0;

            for (; ix < this.Count; ix++)
            {
                if (this[ix].Date < db_TrophyDataSet.Date) continue;

                break;
            }

            if ((ix < this.Count) && (this[ix].Date == db_TrophyDataSet.Date))
            {
                // Dataset already exist: substitute data
                ExtTMDataSet eds = this[ix];

                if (ix > 0)
                    eds.FillWithDb_TrophyDataSet_NewTM(PlayersDS, db_TrophyDataSet, PFun, this[ix - 1],
                        Program.Setts.TeamDataFolder);
                else
                    eds.FillWithDb_TrophyDataSet_NewTM(PlayersDS, db_TrophyDataSet, PFun, null,
                        Program.Setts.TeamDataFolder);
            }
            else
            {
                // New data set, create a new one

                // Fill ExtTMDataSet with Db_TrophyDataSet
                ExtTMDataSet eds = new ExtTMDataSet();

                if (ix > 0)
                    eds.FillWithDb_TrophyDataSet_NewTM(PlayersDS, db_TrophyDataSet, PFun, this[ix - 1],
                        Program.Setts.TeamDataFolder);
                else
                    eds.FillWithDb_TrophyDataSet_NewTM(PlayersDS, db_TrophyDataSet, PFun, null,
                        Program.Setts.TeamDataFolder);

                this.Insert(ix, eds);
            }
        }

        public new void Add(ExtTMDataSet eds)
        {
            sorted = false;
            base.Add(eds);
        }

        public new void Insert(int index, ExtTMDataSet eds)
        {
            sorted = false;
            base.Insert(index, eds);
        }

        public void Insert(int index, DB_TrophyDataSet2 tds)
        {
            // Fill ExtTMDataSet with Db_TrophyDataSet
            ExtTMDataSet eds = new ExtTMDataSet();
            eds.FillWithDb_TrophyDataSet2(PlayersDS, tds, PFun, Program.Setts.TeamDataFolder);
            eds.fiSource = tds.fiSource;
            this.Insert(index, eds);
        }

        public void UpdateDirtyPlayers()
        {
            foreach (ExtraDS.GiocatoriRow grow in PlayersDS.Giocatori)
            {
                if (!grow.isDirty) continue;

                // Update full history
                foreach (ExtTMDataSet tds in this)
                {
                    ExtTMDataSet.GiocatoriNSkillRow row = tds.GiocatoriNSkill.FindByPlayerID(grow.PlayerID);

                    if (row != null)
                    {
                        int wDiff = TmWeek.GetTmAbsWk(DateTime.Now) - TmWeek.GetTmAbsWk(tds.Date);

                        if (!grow.IswBornNull())
                            row.wBorn = grow.wBorn + wDiff;
                        else
                        {
                            row.wBorn = TmWeek.GetBornWeekFromAge(tds.Date, 0, grow.Et‡);
                        }

                        row.Nome = grow.Nome + "|" + row.Infortunato.ToString() + "|" + row.Squalificato.ToString()
                                    + "|" + grow.isYoungTeam.ToString();

                        decimal professionalism = -1;
                        if (!grow.IsProfessionalismNull())
                            professionalism = (decimal)grow.Professionalism;

                        decimal leadership = -1;
                        if (!grow.IsLeadershipNull())
                            leadership = (decimal)grow.Leadership;

                        decimal injury = -1;
                        if (!grow.IsInjPronNull())
                            injury = grow.InjPron;

                        decimal aggressivity = -1;
                        if (!grow.IsAggressivityNull())
                            aggressivity = (decimal)grow.Aggressivity;

                        row.HidSk = "Pro=" + professionalism +
                            ";Lea=" + leadership +
                            ";Inj=" + injury +
                            ";Agg=" + aggressivity;

                        continue;
                    }

                    // Se Ë arrivato qui vuol dire che non era tra i giocatori, ma Ë tra i portieri,
                    // oppure a quel tempo non era ancora in squadra
                    ExtTMDataSet.PortieriNSkillRow prow = tds.PortieriNSkill.FindByPlayerID(grow.PlayerID);

                    if (prow != null)
                    {
                        int wDiff = TmWeek.GetTmAbsWk(DateTime.Now) - TmWeek.GetTmAbsWk(tds.Date);

                        if (!grow.IswBornNull())
                            prow.wBorn = grow.wBorn + wDiff;
                        else
                        {
                            prow.wBorn = TmWeek.GetBornWeekFromAge(tds.Date, 0, grow.Et‡);
                        }

                        prow.Nome = grow.Nome + "|" + prow.Infortunato.ToString() + "|" + prow.Squalificato.ToString()
                                    + "|" + grow.isYoungTeam.ToString();
                        continue;
                    }
                }

                // Update only last dataset
                {
                    ExtTMDataSet tds = this.actualDts;

                    ExtTMDataSet.GiocatoriNSkillRow row = tds.GiocatoriNSkill.FindByPlayerID(grow.PlayerID);

                    if (row != null)
                    {
                        row.Rou = grow.Routine;
                        row.TI = grow.LastTI;
                        row.Nome = grow.Nome + "|" + row.Infortunato.ToString() + "|" + row.Squalificato.ToString()
                                    + "|" + grow.isYoungTeam.ToString();
                        int wDiff = TmWeek.GetTmAbsWk(DateTime.Now) - TmWeek.GetTmAbsWk(tds.Date);

                        if (!grow.IswBornNull())
                            row.wBorn = grow.wBorn + wDiff;
                        else
                        {
                            row.wBorn = TmWeek.GetBornWeekFromAge(tds.Date, 0, grow.Et‡);
                        }

                        decimal professionalism = -1;
                        if (!grow.IsProfessionalismNull())
                            professionalism = (decimal)grow.Professionalism;

                        decimal leadership = -1;
                        if (!grow.IsLeadershipNull())
                            leadership = (decimal)grow.Leadership;

                        decimal injury = -1;
                        if (!grow.IsInjPronNull())
                            injury = grow.InjPron;

                        decimal aggressivity = -1;
                        if (!grow.IsAggressivityNull())
                            aggressivity = (decimal)grow.Aggressivity;

                        row.HidSk = "Pro=" + professionalism +
                            ";Lea=" + leadership +
                            ";Inj=" + injury +
                            ";Agg=" + aggressivity;

                        continue;
                    }

                    // Se Ë arrivato qui vuol dire che non era tra i giocatori, ma Ë tra i portieri
                    ExtTMDataSet.PortieriNSkillRow prow = tds.PortieriNSkill.FindByPlayerID(grow.PlayerID);

                    if (prow != null)
                    {
                        prow.Rou = grow.Routine;
                        prow.TI = grow.LastTI;
                        prow.Nome = grow.Nome + "|" + prow.Infortunato.ToString() + "|" + prow.Squalificato.ToString()
                                    + "|" + grow.isYoungTeam.ToString();

                        int wDiff = TmWeek.GetTmAbsWk(DateTime.Now) - TmWeek.GetTmAbsWk(tds.Date);
                        if (!grow.IswBornNull())
                            prow.wBorn = grow.wBorn + wDiff;
                        else
                        {
                            prow.wBorn = TmWeek.GetBornWeekFromAge(tds.Date, 0, grow.Et‡);
                        }
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// Racalculate the Spec Data for the entire history for all players
        /// </summary>
        public void RecalcDataFromGains()
        {
            foreach (ExtTMDataSet eds in this)
            {
                eds.RecalculateSpecData(PFun);
            }
        }

        /// <summary>
        /// Racalculate the Spec Data for the entire history, just for the required player
        /// </summary>
        /// <param name="plyID">player ID</param>
        public void RecalcDataFromGains(int plyID)
        {
            foreach (ExtTMDataSet eds in this)
            {
                eds.RecalculateSpecData(PFun, plyID);
            }
        }

        public void ClearAllDecimals()
        {
            foreach (ExtTMDataSet eds in this)
            {
                foreach (ExtTMDataSet.GiocatoriNSkillRow edsRow in eds.GiocatoriNSkill)
                {
                    edsRow.Cal = (int)(edsRow.Cal);
                    edsRow.Con = (int)(edsRow.Con);
                    edsRow.Cro = (int)(edsRow.Cro);
                    edsRow.Fin = (int)(edsRow.Fin);
                    edsRow.For = (int)(edsRow.For);
                    edsRow.Mar = (int)(edsRow.Mar);
                    edsRow.Pas = (int)(edsRow.Pas);
                    edsRow.Pos = (int)(edsRow.Pos);
                    edsRow.Res = (int)(edsRow.Res);
                    edsRow.Tec = (int)(edsRow.Tec);
                    edsRow.Tes = (int)(edsRow.Tes);
                    edsRow.Tir = (int)(edsRow.Tir);
                    edsRow.Vel = (int)(edsRow.Vel);
                    edsRow.Wor = (int)(edsRow.Wor);
                }

                foreach (ExtTMDataSet.PortieriNSkillRow edsRow in eds.PortieriNSkill)
                {
                    edsRow.For = (int)(edsRow.For);
                    edsRow.Res = (int)(edsRow.Res);
                    edsRow.Tir = (int)(edsRow.Tir);
                    edsRow.Vel = (int)(edsRow.Vel);
                    edsRow.Aer = (int)(edsRow.Aer);
                    edsRow.Com = (int)(edsRow.Com);
                    edsRow.Ele = (int)(edsRow.Ele);
                    edsRow.Lan = (int)(edsRow.Lan);
                    edsRow.Pre = (int)(edsRow.Pre);
                    edsRow.Rif = (int)(edsRow.Rif);
                    edsRow.Uno = (int)(edsRow.Uno);
                }
            }
        }

        private void AddDataFromXML(FileInfo xmlfi)
        {
            if (xmlfi.Extension == ".xml")
            {
                try
                {
                    Db_TrophyDataSet tds = new Db_TrophyDataSet();
                    tds.ReadXml(xmlfi.FullName);
                    AddData(tds, -1);
                    PlayersDS.AddPlyrDataFromTDS(tds, -1);
                }
                catch (Exception)
                {
                    MessageBox.Show(Current.Language.TheFile + xmlfi.Name + Current.Language.IsNotAValidFile, Current.Language.ErrorLoadingAFile);
                }
            }
        }

        internal void Save(string dataDirectory)
        {
            DirectoryInfo di = new DirectoryInfo(dataDirectory);
            if (!di.Exists) di.Create();
            foreach (ExtTMDataSet ETDS in this)
            {
                if (release == 0.0f)
                {
                    Db_TrophyDataSet tds = ETDS.Get_TDS();
                    tds.WriteXml(dataDirectory + "/TM_" + TmWeek.ToSWDString(tds.Date) + ".xml");
                }
                else if (release == 1.0f)
                {
                    DB_TrophyDataSet2 tds = ETDS.Get_TDS2();
                    tds.WriteXml(dataDirectory + "/HistTM-" + TmWeek.ToSWDString(tds.Date) + ".2.xml");
                }
            }

            if (PlayersDS != null)
            {
                // ExtraDS.GiocatoriRow gr = PlayersDS.Giocatori.FindByPlayerID(2201368);
                PlayersDS.WriteXml(dataDirectory + "/TeamPlayersDB.3.xml");
            }

            foreach (TrainingDataSet TDS in TrainingHist)
            {
                TDS.WriteXml(dataDirectory + "/TrainTM-" + TmWeek.ToSWDString(TDS.Date) + ".2.xml");
            }
        }



        internal bool Load(string dataDirectory, ref Common.SplashForm sf)
        {
            bool trace = (Program.Setts.Trace > 0);

            DefaultTraceListener tracer = new DefaultTraceListener();
            tracer.LogFileName = "./tmrecorderlog.txt";


            DirectoryInfo di = null;

            try
            {
                di = new DirectoryInfo(dataDirectory);
            }
            catch (Exception)
            {
                return false;
            }

            if (trace) tracer.WriteLine("DataDirectory is" + dataDirectory);

            TrainingHist.Clear();
            if (trace) tracer.WriteLine("History Cleared");

            if (trace) tracer.Flush();

            if (!di.Exists) return false;

            if (di.GetFiles("*.*.xml").Length != 0)
            {
                float tot = (float)di.GetFiles("*.*.xml").Length;
                float cnt = 5.0F;
                int icnt = 0;

                // Using data type 2.0
                foreach (FileInfo fi in di.GetFiles("TeamPlayersDB.3.xml"))
                {
                    cnt += 85.0F / tot;
                    if (icnt != (int)cnt)
                    {
                        icnt = (int)cnt;
                        sf.UpdateStatusMessage(icnt, "Loading Players DB...");
                    }
                    AddPlyrDataFromXML(fi);
                    if (trace) tracer.WriteLine("Added player data from " + fi.Name);
                }
                if (trace) tracer.Flush();
                foreach (FileInfo fi in di.GetFiles("HistTM-*.2.xml"))
                {
                    cnt += 85.0F / tot;
                    if (icnt != (int)cnt)
                    {
                        icnt = (int)cnt;
                        sf.UpdateStatusMessage(icnt, "Loading History...");
                    }
                    AddHistDataFromXML(fi);
                    if (trace) tracer.WriteLine("Added History data from " + fi.Name);
                }
                if (trace) tracer.Flush();
                foreach (FileInfo fi in di.GetFiles("TrainTM-*.2.xml"))
                {
                    cnt += 85.0F / tot;
                    if (icnt != (int)cnt)
                    {
                        icnt = (int)cnt;
                        sf.UpdateStatusMessage(icnt, "Loading Training...");
                    }
                    AddTrainingDataFromXML(fi);
                    if (trace) tracer.WriteLine("Added Training data from " + fi.Name);
                }
                if (trace) tracer.Flush();

                if (trace) tracer.WriteLine("Result: ");
                if (trace) tracer.WriteLine(" " + this.Count.ToString() + " Squad dataset loaded");
                if (trace) tracer.WriteLine(" " + this.TrainingHist.Count + " Training dataset loaded");

                return true;
            }
            else if (di.GetFiles("*.xml").Length != 0)
            {
                // Using data type 1.0

                // Bisogna creare la struttura dati per il nuovo formato
                PlayersDS = new ExtraDS();

                foreach (FileInfo fi in di.GetFiles("TM_*.xml"))
                {
                    AddDataFromXML(fi);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private void AddHistDataFromXML(FileInfo xmlfi)
        {
            try
            {
                DB_TrophyDataSet2 tds = new DB_TrophyDataSet2();
                tds.ReadXml(xmlfi.FullName);
                tds.fiSource = xmlfi;
                AddData2(tds);
            }
            catch (Exception)
            {
                MessageBox.Show(Current.Language.TheFile + xmlfi.Name + Current.Language.IsNotAValidFile, Current.Language.ErrorLoadingAFile);
            }
        }

        private void AddTrainingDataFromXML(FileInfo xmlfi)
        {
            try
            {
                TrainingDataSet tds = new TrainingDataSet();
                tds.ReadXml(xmlfi.FullName);
                TrainingHist.Add(tds);
            }
            catch (Exception)
            {
                MessageBox.Show(Current.Language.TheFile + xmlfi.Name + Current.Language.IsNotAValidFile, Current.Language.ErrorLoadingAFile);
            }
        }

        private void AddData2(DB_TrophyDataSet2 db_TrophyDataSet)
        {
            int ix = 0;

            //--------------------------------------------------
            // Search an index where to put the new data set
            for (; ix < this.Count; ix++)
            {
                if (this[ix].Date < db_TrophyDataSet.Date) continue;

                break;
            }

            //--------------------------------------------------
            // Check if there is a data set with the same date
            if ((ix < this.Count) && (this[ix].Date == db_TrophyDataSet.Date))
            {
                DialogResult res = MessageBox.Show("There is already a data set with this the same date (previous:" +
                    this[ix].fiSource.Name + ", new:" + db_TrophyDataSet.fiSource.Name +
                    "): substitute?\n(Yes->Delete the prev file, No->Delete the new file, Cancel->Use the old file and do not cancel anything)", "Data set load", MessageBoxButtons.YesNoCancel);
                if (res == DialogResult.No)
                {
                    File.Move(db_TrophyDataSet.fiSource.FullName, db_TrophyDataSet.fiSource.FullName + "." + ix.ToString() + ".bkp");
                    return;
                }
                else if (res == DialogResult.Yes)
                {
                    File.Move(this[ix].fiSource.FullName, this[ix].fiSource.FullName + "." + ix.ToString() + ".bkp");
                    this.RemoveAt(ix);
                    sorted = false;
                }
                else if (res == DialogResult.Cancel)
                {
                    return;
                }
            }

            //--------------------------------------------------
            // Insert the data set
            this.Insert(ix, db_TrophyDataSet);
        }

        private void AddPlyrDataFromXML(FileInfo xmlfi)
        {
            try
            {
                PlayersDS = null;
                PlayersDS = new ExtraDS();
                PlayersDS.ReadXml(xmlfi.FullName);

                foreach (ExtraDS.GiocatoriRow gr in PlayersDS.Giocatori)
                {
                    if (gr.IswBornNull())
                    {
                        if (gr.IsEt‡Null()) continue;
                        gr.wBorn = TmWeek.GetBornWeekFromAge(DateTime.Now, gr.Et‡.ToString());
                    }
                    if (gr.IsFPnNull())
                    {
                        gr.FPn = Tm_Utility.FPToNumber(gr.FP);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Current.Language.TheFile + xmlfi.Name + Current.Language.IsNotAValidFileExceptionLoadingTheFile + ex.Message, Current.Language.ErrorLoadingAFile);
            }
        }

        bool sorted = false;
        internal ExtTMDataSet LastTeam()
        {
            if (!sorted)
            {
                TDSComparer comparer = new TDSComparer();

                this.Sort(comparer);

                sorted = true;
            }

            if (this.Count == 0) return null;
            return this[this.Count - 1];
        }

        internal string[] DataDateList()
        {
            string[] itemList = new string[this.Count];

            int ix = 0;

            for (; ix < this.Count; ix++)
            {
                itemList[ix] = this[ix].Date.ToShortDateString();
            }

            return itemList;
        }

        internal void DeleteDay(string dataDirectory, DateTime date)
        {
            ExtTMDataSet tds = DSfromDate(date);

            if (tds == null) return;
            this.Remove(tds);

            string filename = Path.Combine(dataDirectory, "TM_" + tds.Date.Year.ToString() + "_"
                     + tds.Date.DayOfYear.ToString() + ".xml");

            FileInfo fi = new FileInfo(filename);
            if (fi.Exists)
                fi.Delete();

            filename = Path.Combine(dataDirectory, "TM_" + TmWeek.ToSWDString(tds.Date) + ".xml");

            fi = new FileInfo(filename);
            if (fi.Exists)
                fi.Delete();

            filename = Path.Combine(dataDirectory, "HistTM_" + tds.Date.Year.ToString() + "_"
                     + tds.Date.DayOfYear.ToString() + ".2.xml");

            fi = new FileInfo(filename);
            if (fi.Exists)
                fi.Delete();

            filename = Path.Combine(dataDirectory, "HistTM_" + TmWeek.ToSWDString(tds.Date) + ".2.xml");

            fi = new FileInfo(filename);
            if (fi.Exists)
                fi.Delete();

            filename = Path.Combine(dataDirectory, "HistTM-" + TmWeek.ToSWDString(tds.Date) + ".2.xml");

            fi = new FileInfo(filename);
            if (fi.Exists)
                fi.Delete();
        }

        public ExtTMDataSet.PlayerHistoryDataTable GetPlayerHistory(int playerID)
        {
            ExtTMDataSet.PlayerHistoryDataTable table = new ExtTMDataSet.PlayerHistoryDataTable();

            foreach (ExtTMDataSet tds in this)
            {
                ExtTMDataSet.GiocatoriNSkillRow row = null;
                if ((row = tds.GiocatoriNSkill.FindByPlayerID(playerID)) != null)
                {
                    ExtTMDataSet.PlayerHistoryRow hrow = (ExtTMDataSet.PlayerHistoryRow)table.NewRow();

                    for (int i = 1, j = 7; i < hrow.Table.Columns.Count; i++, j++)
                    {
                        hrow[i] = row[j];
                    }
                    hrow.Date = tds.Date;

                    table.Rows.Add(hrow);
                }
            }

            return table;
        }

        internal ExtTMDataSet DSfromDate(DateTime dt)
        {
            int ix = 0;
            for (; ix < this.Count; ix++)
            {
                if ((this[ix].Date.DayOfYear == dt.DayOfYear) && (this[ix].Date.Year == dt.Year))
                {
                    return this[ix];
                }
            }

            MessageBox.Show("Error: Date not found");
            return null;
        }

        internal ExtTMDataSet.GKHistoryDataTable GetGKHistory(int playerID)
        {
            ExtTMDataSet.GKHistoryDataTable table = new ExtTMDataSet.GKHistoryDataTable();

            foreach (ExtTMDataSet tds in this)
            {
                ExtTMDataSet.PortieriNSkillRow row = null;
                if ((row = tds.PortieriNSkill.FindByPlayerID(playerID)) != null)
                {
                    ExtTMDataSet.GKHistoryRow hrow = (ExtTMDataSet.GKHistoryRow)table.NewRow();

                    for (int i = 1, j = 5; i < hrow.Table.Columns.Count; i++, j++)
                    {
                        hrow[i] = row[j];
                    }
                    hrow.Date = tds.Date;

                    table.Rows.Add(hrow);
                }
            }

            return table;
        }

        internal void LoadTraining_NewTM(DateTime dt, string squad, TrainersSkills trainers)
        {
            try
            {
                if (trainers.Trainers.Count == 0)
                {
                    MessageBox.Show(Current.Language.YouHaveToPasteTheTrainersOptionsTrainersPageBeforeToEnterANewTrainingSession);
                    return;
                }

                TrainingDataSet trainingDataSet = new TrainingDataSet();
                trainingDataSet.Date = dt;

                trainingDataSet.Giocatori.Clear();
                trainingDataSet.Portieri.Clear();
                trainingDataSet.Trainers.Clear();

                // There will be two tables (0: players, 1: GK)
                List<string> tables = HTML_Parser.GetTags(squad, "TABLE");

                if (tables.Count == 0)
                {
                    MessageBox.Show(Current.Language.TheContentOfWhatYouPastedIsNotTheOneExpected, "Error", MessageBoxButtons.OK);
                    return;
                }

                int cnt = 0;
                int[] trainerID = new int[6];

                List<string> trainersRow = HTML_Parser.GetTags(squad, "h3 ");
                foreach (string row in trainersRow)
                {
                    if (row.Contains("training_prog"))
                    {
                        trainerID[cnt] = TM_Parser.ParseTrainerTraining_NewTM(ref trainingDataSet, row, trainers);
                        if (trainerID[cnt] == -1)
                        {
                            cnt++;
                            continue;
                        }
                    }
                    cnt++;
                }

                cnt = 0;
                foreach (string table in tables)
                {
                    List<string> plRows = HTML_Parser.GetTags(table, "TR");


                    // Row 0 is the table header
                    for (int player = 0; player < plRows.Count; player++)
                    {

                        if (plRows[player].Contains("training_prog"))
                        {
                            trainerID[cnt] = TM_Parser.ParseTrainerTraining_NewTM(ref trainingDataSet, plRows[player], trainers);
                            if (trainerID[cnt] == -1)
                                continue;
                        }

                        if (!plRows[player].Contains("player_link=")) continue;

                        if (!plRows[player].Contains("\"gk\""))
                        {
                            TrainingDataSet.GiocatoriRow row = (TrainingDataSet.GiocatoriRow)trainingDataSet.Giocatori.NewRow();

                            if (!TM_Parser.ParsePlayerTraining_NewTM(ref row, plRows[player]))
                                continue;

                            row.TrainerID = trainerID[cnt];
                            trainingDataSet.Giocatori.AddGiocatoriRow(row);
                        }
                        else
                        {
                            TrainingDataSet.PortieriRow row = (TrainingDataSet.PortieriRow)trainingDataSet.Portieri.NewRow();

                            if (!TM_Parser.ParseTrainingGK_NewTM(ref row, plRows[player]))
                                continue;

                            row.TrainerID = trainerID[cnt];
                            trainingDataSet.Portieri.AddPortieriRow(row);
                        }
                    }
                    cnt++;
                }

                AddData(trainingDataSet);

                UpdateAges(trainingDataSet);
            }
            catch (Exception e)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";
                ErrorReport.Send(e, squad, Environment.StackTrace, swRelease);
                MessageBox.Show(Current.Language.SorryTheImportingProcessHasFailedIfYouClickedOkTheInfoOfTheErrorHave +
                    Current.Language.BeenSentToLedLennonThatWillRemoveThisBugAsSoonAsPossible);
            }
        }

        internal void LoadTraining_NewTM2(DateTime dt, string squad)
        {
            try
            {
                TrainingDataSet trainingDataSet = new TrainingDataSet();
                trainingDataSet.Date = dt;

                trainingDataSet.Giocatori.Clear();
                trainingDataSet.Portieri.Clear();

                // There will be two tables (0: players, 1: GK)
                string[] playersTr = squad.Split('\n');

                if (playersTr.Length == 0)
                {
                    MessageBox.Show(Current.Language.TheContentOfWhatYouPastedIsNotTheOneExpected, "Error", MessageBoxButtons.OK);
                    return;
                }

                int cnt = 0;

                foreach (string playerTr in playersTr)
                {
                    Dictionary<string, string> plRow = TM_Parser.CreateDictionaryNewTm(playerTr);

                    if (plRow.Count == 0) continue;

                    // Row 0 is the table header
                    int id = int.Parse(plRow["player"]);

                    if (actualDts == null)
                        actualDts = LastTeam();

                    ExtTMDataSet.GiocatoriNSkillRow gnsr = actualDts.GiocatoriNSkill.FindByPlayerID(id);
                    if (gnsr == null)
                    {
                        // It's a GK
                        TrainingDataSet.PortieriRow row = (TrainingDataSet.PortieriRow)trainingDataSet.Portieri.NewRow();

                        if (!TM_Parser.ParseGKTraining_NewTM2(ref row, plRow))
                            continue;

                        trainingDataSet.Portieri.AddPortieriRow(row);

                    }
                    else
                    {
                        // It's a Player
                        TrainingDataSet.GiocatoriRow row = (TrainingDataSet.GiocatoriRow)trainingDataSet.Giocatori.NewRow();

                        if (!TM_Parser.ParsePlayerTraining_NewTM2(ref row, plRow))
                            continue;

                        trainingDataSet.Giocatori.AddGiocatoriRow(row);
                    }

                    cnt++;
                }

                AddData(trainingDataSet);

                // UpdateAges(trainingDataSet);
            }
            catch (Exception e)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";
                ErrorReport.Send(e, squad, Environment.StackTrace, swRelease);
                MessageBox.Show(Current.Language.SorryTheImportingProcessHasFailedIfYouClickedOkTheInfoOfTheErrorHave +
                    Current.Language.BeenSentToLedLennonThatWillRemoveThisBugAsSoonAsPossible);
            }
        }

        private void UpdateAges(TrainingDataSet trainingDataSet)
        {
            foreach (TrainingDataSet.GiocatoriRow gr in trainingDataSet.Giocatori)
            {
                ExtraDS.GiocatoriRow egr = PlayersDS.Giocatori.FindByPlayerID(gr.PlayerID);

                string[] spl = gr.Age.Split(',');
                int year = int.Parse(spl[0]);
                int month = int.Parse(spl[1]);
                int wBorn = TmWeek.GetBornWeekFromAge(DateTime.Now, month, year);

                if (wBorn < egr.wBorn)
                {
                    egr.wBorn = wBorn;
                    ExtTMDataSet.GiocatoriNSkillRow ergr = this.actualDts.GiocatoriNSkill.FindByPlayerID(gr.PlayerID);
                    ergr.wBorn = wBorn;
                }
            }
            foreach (TrainingDataSet.PortieriRow gr in trainingDataSet.Portieri)
            {
                ExtraDS.GiocatoriRow egr = PlayersDS.Giocatori.FindByPlayerID(gr.PlayerID);

                string[] spl = gr.Age.Split(',');
                int year = int.Parse(spl[0]);
                int month = int.Parse(spl[1]);
                int wBorn = TmWeek.GetBornWeekFromAge(DateTime.Now, month, year);

                if (wBorn < egr.wBorn)
                {
                    egr.wBorn = wBorn;
                    ExtTMDataSet.PortieriNSkillRow ergr = this.actualDts.PortieriNSkill.FindByPlayerID(gr.PlayerID);
                    ergr.wBorn = wBorn;
                }
            }
        }

        internal void LoadTraining(DateTime dt, string squad, TrainersSkills trainers)
        {
            try
            {
                if (trainers.Trainers.Count == 0)
                {
                    MessageBox.Show(Current.Language.YouHaveToPasteTheTrainersOptionsTrainersPageBeforeToEnterANewTrainingSession);
                    return;
                }

                TrainingDataSet trainingDataSet = new TrainingDataSet();
                trainingDataSet.Date = dt;

                trainingDataSet.Giocatori.Clear();
                trainingDataSet.Portieri.Clear();
                trainingDataSet.Trainers.Clear();

                // There will be two tables (0: players, 1: GK)
                List<string> tables = HTML_Parser.GetTags(squad, "TABLE");

                if (tables.Count == 0)
                {
                    MessageBox.Show(Current.Language.TheContentOfWhatYouPastedIsNotTheOneExpected, "Error", MessageBoxButtons.OK);
                    return;
                }

                // Get all rows of the players table
                List<string> plRows = HTML_Parser.GetTags(tables[0], "TR");

                string str = "";
                if ((str = HTML_Parser.GetTag(plRows[0], "span")) == "...")
                {
                    str = HTML_Parser.GetTag(plRows[0], "td");
                    str = HTML_Parser.CleanTags(str);
                    MessageBox.Show(str + "\n" + Current.Language.YouCannotPasteARunningTrainingYouMustWaitTheEndOfTheTraining,
                        Current.Language.TrainingPasteError);
                    return;
                }


                int trainerID = 0;

                // Row 0 is the table header
                for (int player = 0; player < plRows.Count; player++)
                {

                    if (plRows[player].Contains("training_prog"))
                    {
                        trainerID = TM_Parser.ParseTrainerTraining(ref trainingDataSet, plRows[player], trainers);
                        if (trainerID == -1)
                            continue;
                    }

                    if (!plRows[player].Contains("playerid=")) continue;

                    if (!plRows[player].Contains("training_g"))
                    {
                        TrainingDataSet.GiocatoriRow row = (TrainingDataSet.GiocatoriRow)trainingDataSet.Giocatori.NewRow();

                        if (!TM_Parser.ParsePlayerTraining(ref row, plRows[player]))
                            continue;

                        row.TrainerID = trainerID;
                        trainingDataSet.Giocatori.AddGiocatoriRow(row);
                    }
                    else
                    {
                        TrainingDataSet.PortieriRow row = (TrainingDataSet.PortieriRow)trainingDataSet.Portieri.NewRow();

                        if (!TM_Parser.ParseTrainingGK(ref row, plRows[player]))
                            continue;

                        row.TrainerID = trainerID;
                        trainingDataSet.Portieri.AddPortieriRow(row);
                    }
                }

                AddData(trainingDataSet);
            }
            catch (Exception e)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";
                ErrorReport.Send(e, squad, Environment.StackTrace, swRelease);
                MessageBox.Show(Current.Language.SorryTheImportingProcessHasFailedIfYouClickedOkTheInfoOfTheErrorHave +
                    Current.Language.BeenSentToLedLennonThatWillRemoveThisBugAsSoonAsPossible);
            }
        }

        internal void LoadTrainingNew_NewTM(DateTime dt, string squad, TrainersSkills trainers)
        {
            string originalSquadString = squad;
            TrainingDataSet trainingDataSet = new TrainingDataSet();

            try
            {
                trainingDataSet.Date = dt;

                trainingDataSet.Giocatori.Clear();
                trainingDataSet.Portieri.Clear();
                trainingDataSet.Trainers.Clear();

                // There will be two tables (0: players, 1: GK)
                string players = HTML_Parser.GetFieldNC(squad, "players : ", "\n");
                string gks = HTML_Parser.GetFieldNC(squad, "gks : ", "\n");
                string trainstr = HTML_Parser.GetFieldNC(squad, "coaches : ", "\n");
                string programs = HTML_Parser.GetFieldNC(squad, "program : ", "\n");

                // Get all rows of the players table
                players = players.Replace("¬§", "§");
                gks = gks.Replace("¬§", "§");
                trainstr = trainstr.Replace("¬§", "§");
                programs = programs.Replace("¬§", "§");
                string[] plRows = players.Split('§');
                string[] gkRows = gks.Split('§');
                string[] trRows = trainstr.Split('§');
                string[] prRows = programs.Split('§');

                // Row 0 is the table header
                for (int itr = 0; itr < trRows.Length; itr++)
                {
                    TrainersSkills.TrainersRow trow = (TrainersSkills.TrainersRow)trainers.Trainers.NewRow();

                    // if (!TM_Parser.ParsePlayerTrainingNew(ref row, plRows[player]))
                    //     continue;
                    if (!TM_Parser.ParseTrainerTrainingNew(ref trow, trRows[itr]))
                        continue;

                    TrainersSkills.TrainersRow toldrow = trainers.Trainers.FindByID(trow.ID);

                    if (toldrow == null)
                    {
                        trainers.Trainers.AddTrainersRow(trow);
                        trainers.isDirty = true;
                        continue;
                    }

                    if (toldrow.Name.Contains("."))
                    {
                        toldrow.Name = trow.Name;
                    }
                }

                // Row 0 is the table header
                for (int player = 0; player < plRows.Length; player++)
                {
                    TrainingDataSet.GiocatoriRow row = (TrainingDataSet.GiocatoriRow)trainingDataSet.Giocatori.NewRow();

                    if (!TM_Parser.ParsePlayerTrainingNew(ref row, plRows[player]))
                        continue;

                    ExtraDS.GiocatoriRow gr = PlayersDS.FindByPlayerID(row.PlayerID);
                    if (gr != null)
                        gr.SetTINew(dt, plRows[player], false);

                    trainingDataSet.Giocatori.AddGiocatoriRow(row);
                }

                // Row 0 is the table header
                for (int player = 0; player < gkRows.Length; player++)
                {
                    TrainingDataSet.PortieriRow row = (TrainingDataSet.PortieriRow)trainingDataSet.Portieri.NewRow();

                    if (!TM_Parser.ParseTrainingGKNew(ref row, gkRows[player]))
                        continue;

                    ExtraDS.GiocatoriRow gr = PlayersDS.FindByPlayerID(row.PlayerID);
                    if (gr != null)
                        gr.SetTINew(dt, gkRows[player], true);

                    trainingDataSet.Portieri.AddPortieriRow(row);
                }

                // Row 0 is the table header
                for (int ipr = 0; ipr < prRows.Length; ipr++)
                {
                    string[] mstr = prRows[ipr].Split(';');

                    // Analyze the program
                    string[] str = mstr[0].Split(',');

                    int program = 0;
                    if (str[6] == "") continue;

                    int trainerID = int.Parse(str[6]);
                    TrainingDataSet.TrainersRow tr = trainingDataSet.Trainers.FindByID(trainerID);

                    if (tr == null)
                    {
                        tr = trainingDataSet.Trainers.NewTrainersRow();
                        tr.ID = trainerID;
                        trainingDataSet.Trainers.AddTrainersRow(tr);
                    }

                    TrainersSkills.TrainersRow trr = trainers.Trainers.FindByID(trainerID);

                    if (str[0] == "1") program += 1;
                    if (str[1] == "1") program += 2;
                    if (str[2] == "1") program += 4;
                    if (str[3] == "1") program += 8;
                    if (str[4] == "1") program += 16;
                    if (str[5] == "1") program += 32;

                    tr.Program = program;
                    tr.Percentage = (int)(trr.GetPercentage(program) + 0.4999M);
                    tr.Name = trr.Name;

                    str = mstr[1].Split(',');

                    foreach (string s in str)
                    {
                        if (s.Trim() == "") continue;

                        int plID = int.Parse(s);

                        TrainingDataSet.GiocatoriRow gr = trainingDataSet.Giocatori.FindByPlayerID(plID);

                        if (gr == null)
                        {
                            TrainingDataSet.PortieriRow pr = trainingDataSet.Portieri.FindByPlayerID(plID);
                            pr.TrainerID = trainerID;
                        }
                        else
                            gr.TrainerID = trainerID;
                    }
                }

                AddData(trainingDataSet);
            }
            catch (Exception e)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";

                string info = "";

                string filename = "dbinfo." + DateTime.Now.Hour.ToString() +
                    DateTime.Now.Minute.ToString() + ".tmreport.txt";
                string pathfilename = Path.Combine(Program.Setts.TeamDataFolder, filename);
                FileInfo fi = new FileInfo(pathfilename);

                PlayersDS.WriteXml(fi.FullName);

                StreamReader file = new StreamReader(fi.FullName);
                info += "PlayersDS:\r\n" + file.ReadToEnd();
                file.Close();

                trainingDataSet.WriteXml(fi.FullName);

                file = new StreamReader(fi.FullName);
                info += "trainingDataSet:\r\n" + file.ReadToEnd();
                file.Close();

                trainers.WriteXml(fi.FullName);

                file = new StreamReader(fi.FullName);
                info += "trainers:\r\n" + file.ReadToEnd();
                file.Close();

                info += "Squad:" + originalSquadString;

                ErrorReport.Send(e, info, Environment.StackTrace, swRelease);
                MessageBox.Show(Current.Language.SorryTheImportingProcessHasFailedIfYouClickedOkTheInfoOfTheErrorHave +
                    Current.Language.BeenSentToLedLennonThatWillRemoveThisBugAsSoonAsPossible);
            }
        }
        internal void LoadTrainingNew(DateTime dt, string squad, TrainersSkills trainers)
        {
            string originalSquadString = squad;
            TrainingDataSet trainingDataSet = new TrainingDataSet();

            try
            {
                trainingDataSet.Date = dt;

                trainingDataSet.Giocatori.Clear();
                trainingDataSet.Portieri.Clear();
                trainingDataSet.Trainers.Clear();

                // There will be two tables (0: players, 1: GK)
                string players = HTML_Parser.GetFieldNC(squad, "'players', ", ");");
                string gks = HTML_Parser.GetFieldNC(squad, "'gks', ", ");");
                string trainstr = HTML_Parser.GetFieldNC(squad, "'coaches', ", ");");
                string programs = HTML_Parser.GetFieldNC(squad, "'program', ", ");");

                // Get all rows of the players table
                players = players.Replace("¬§", "§");
                gks = gks.Replace("¬§", "§");
                trainstr = trainstr.Replace("¬§", "§");
                programs = programs.Replace("¬§", "§");
                string[] plRows = players.Split('§');
                string[] gkRows = gks.Split('§');
                string[] trRows = trainstr.Split('§');
                string[] prRows = programs.Split('§');

                // Row 0 is the table header
                for (int itr = 0; itr < trRows.Length; itr++)
                {
                    TrainersSkills.TrainersRow trow = (TrainersSkills.TrainersRow)trainers.Trainers.NewRow();

                    // if (!TM_Parser.ParsePlayerTrainingNew(ref row, plRows[player]))
                    //     continue;
                    if (!TM_Parser.ParseTrainerTrainingNew(ref trow, trRows[itr]))
                        continue;

                    TrainersSkills.TrainersRow toldrow = trainers.Trainers.FindByID(trow.ID);

                    if (toldrow == null)
                    {
                        trainers.Trainers.AddTrainersRow(trow);
                        trainers.isDirty = true;
                        continue;
                    }

                    if (toldrow.Name.Contains("."))
                    {
                        toldrow.Name = trow.Name;
                    }
                }

                // Row 0 is the table header
                for (int player = 0; player < plRows.Length; player++)
                {
                    TrainingDataSet.GiocatoriRow row = (TrainingDataSet.GiocatoriRow)trainingDataSet.Giocatori.NewRow();

                    if (!TM_Parser.ParsePlayerTrainingNew(ref row, plRows[player]))
                        continue;

                    ExtraDS.GiocatoriRow gr = PlayersDS.FindByPlayerID(row.PlayerID);
                    if (gr != null)
                        gr.SetTINew(dt, plRows[player], false);

                    trainingDataSet.Giocatori.AddGiocatoriRow(row);
                }

                // Row 0 is the table header
                for (int player = 0; player < gkRows.Length; player++)
                {
                    TrainingDataSet.PortieriRow row = (TrainingDataSet.PortieriRow)trainingDataSet.Portieri.NewRow();

                    if (!TM_Parser.ParseTrainingGKNew(ref row, gkRows[player]))
                        continue;

                    ExtraDS.GiocatoriRow gr = PlayersDS.FindByPlayerID(row.PlayerID);
                    if (gr != null)
                        gr.SetTINew(dt, gkRows[player], true);

                    trainingDataSet.Portieri.AddPortieriRow(row);
                }

                // Row 0 is the table header
                for (int ipr = 0; ipr < prRows.Length; ipr++)
                {
                    string[] mstr = prRows[ipr].Split(';');

                    // Analyze the program
                    string[] str = mstr[0].Split(',');

                    int program = 0;
                    if (str[6] == "") continue;

                    int trainerID = int.Parse(str[6]);
                    TrainingDataSet.TrainersRow tr = trainingDataSet.Trainers.FindByID(trainerID);

                    if (tr == null)
                    {
                        tr = trainingDataSet.Trainers.NewTrainersRow();
                        tr.ID = trainerID;
                        trainingDataSet.Trainers.AddTrainersRow(tr);
                    }

                    TrainersSkills.TrainersRow trr = trainers.Trainers.FindByID(trainerID);

                    if (str[0] == "1") program += 1;
                    if (str[1] == "1") program += 2;
                    if (str[2] == "1") program += 4;
                    if (str[3] == "1") program += 8;
                    if (str[4] == "1") program += 16;
                    if (str[5] == "1") program += 32;

                    tr.Program = program;
                    tr.Percentage = (int)(trr.GetPercentage(program) + 0.4999M);
                    tr.Name = trr.Name;

                    str = mstr[1].Split(',');

                    foreach (string s in str)
                    {
                        if (s.Trim() == "") continue;

                        int plID = int.Parse(s);

                        TrainingDataSet.GiocatoriRow gr = trainingDataSet.Giocatori.FindByPlayerID(plID);

                        if (gr == null)
                        {
                            TrainingDataSet.PortieriRow pr = trainingDataSet.Portieri.FindByPlayerID(plID);
                            pr.TrainerID = trainerID;
                        }
                        else
                            gr.TrainerID = trainerID;
                    }
                }

                AddData(trainingDataSet);
            }
            catch (Exception e)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";

                string info = "";

                string filename = "dbinfo." + DateTime.Now.Hour.ToString() +
                    DateTime.Now.Minute.ToString() + ".tmreport.txt";
                string pathfilename = Path.Combine(Program.Setts.TeamDataFolder, filename);
                FileInfo fi = new FileInfo(pathfilename);

                PlayersDS.WriteXml(fi.FullName);

                StreamReader file = new StreamReader(fi.FullName);
                info += "PlayersDS:\r\n" + file.ReadToEnd();
                file.Close();

                trainingDataSet.WriteXml(fi.FullName);

                file = new StreamReader(fi.FullName);
                info += "trainingDataSet:\r\n" + file.ReadToEnd();
                file.Close();

                trainers.WriteXml(fi.FullName);

                file = new StreamReader(fi.FullName);
                info += "trainers:\r\n" + file.ReadToEnd();
                file.Close();

                info += "Squad:" + originalSquadString;

                ErrorReport.Send(e, info, Environment.StackTrace, swRelease);
                MessageBox.Show(Current.Language.SorryTheImportingProcessHasFailedIfYouClickedOkTheInfoOfTheErrorHave +
                    Current.Language.BeenSentToLedLennonThatWillRemoveThisBugAsSoonAsPossible);
            }
        }

        internal int LoadTIfromTrainingNew_NewTM(DateTime dt, string squad)
        {
            int count = 0;
            try
            {
                string[] strs = squad.Split('\n');
                foreach (string str in strs)
                {
                    if (!str.Contains("id=")) continue;

                    Dictionary<string, string> dict = HTML_Parser.String2Dictionary(str);

                    int id = int.Parse(dict["id"]);
                    int training = int.Parse(dict["training"]);

                    TrainingDataSet tds = TrainingHist.LastTraining();

                    if ((tds.Date - DateTime.Now) < new TimeSpan(7, 0, 0))
                    {
                        TrainingDataSet.GiocatoriRow gr = tds.Giocatori.FindByPlayerID(id);
                        if (gr != null)
                        {
                            gr.TrainerID = -training;
                            count++;
                            continue;
                        }

                        TrainingDataSet.PortieriRow pr = tds.Portieri.FindByPlayerID(id);
                        if (pr != null)
                        {
                            pr.TrainerID = -training;
                            count++;
                            continue;
                        }
                    }
                    else
                    {
                        MessageBox.Show("You have to import the squad before importing the training for the same week");
                        return 0;
                    }
                }

                return count;
            }
            catch (Exception e)
            {
                string info = "";
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";

                string filename = "dbinfo." + DateTime.Now.Hour.ToString() +
                    DateTime.Now.Minute.ToString() + ".tmreport.txt";
                string pathfilename = Path.Combine(Program.Setts.TeamDataFolder, filename);
                FileInfo fi = new FileInfo(pathfilename);

                PlayersDS.WriteXml(fi.FullName);
                StreamReader file = new StreamReader(fi.FullName);
                info += "PlayersDS:\r\n" + file.ReadToEnd();
                file.Close();

                info += "Squad:\r\n" + squad;

                ErrorReport.Send(e, info, Environment.StackTrace, swRelease);
                MessageBox.Show(Current.Language.SorryTheImportingProcessHasFailedIfYouClickedOkTheInfoOfTheErrorHave +
                    Current.Language.BeenSentToLedLennonThatWillRemoveThisBugAsSoonAsPossible);

                return 0;
            }
        }
        internal void LoadTIfromTrainingNew(DateTime dt, string squad)
        {
            try
            {
                TrainingDataSet trainingDataSet = new TrainingDataSet();
                trainingDataSet.Date = dt;

                trainingDataSet.Giocatori.Clear();
                trainingDataSet.Portieri.Clear();
                trainingDataSet.Trainers.Clear();

                // There will be two tables (0: players, 1: GK)
                string players = HTML_Parser.GetFieldNC(squad, "'players', ", ");");
                string gks = HTML_Parser.GetFieldNC(squad, "'gks', ", ");");
                string trainstr = HTML_Parser.GetFieldNC(squad, "'coaches', ", ");");
                string programs = HTML_Parser.GetFieldNC(squad, "'program', ", ");");

                // Get all rows of the players table
                players = players.Replace("¬§", "§");
                gks = gks.Replace("¬§", "§");
                trainstr = trainstr.Replace("¬§", "§");
                programs = programs.Replace("¬§", "§");
                string[] plRows = players.Split('§');
                string[] gkRows = gks.Split('§');
                string[] trRows = trainstr.Split('§');
                string[] prRows = programs.Split('§');

                // Row 0 is the table header
                for (int player = 0; player < plRows.Length; player++)
                {
                    TrainingDataSet.GiocatoriRow row = (TrainingDataSet.GiocatoriRow)trainingDataSet.Giocatori.NewRow();

                    if (!TM_Parser.ParsePlayerTrainingNew(ref row, plRows[player]))
                        continue;

                    ExtraDS.GiocatoriRow gr = PlayersDS.FindByPlayerID(row.PlayerID);

                    if (gr != null)
                        gr.SetTINew(dt, plRows[player], false);
                    else
                    {
                        MessageBox.Show("You tried to import training for the player whose id is " + row.PlayerID.ToString() +
                            " while it is not contained in your squad history. Please update your team before",
                            "Error importing a player");
                        return;
                    }
                }

                // Row 0 is the table header
                for (int player = 0; player < gkRows.Length; player++)
                {
                    TrainingDataSet.PortieriRow row = (TrainingDataSet.PortieriRow)trainingDataSet.Portieri.NewRow();

                    if (!TM_Parser.ParseTrainingGKNew(ref row, gkRows[player]))
                        continue;

                    ExtraDS.GiocatoriRow gr = PlayersDS.FindByPlayerID(row.PlayerID);
                    if (gr != null)
                        gr.SetTINew(dt, plRows[player], true);
                    else
                    {
                        MessageBox.Show("You tried to import training for the player whose id is " + row.PlayerID.ToString() +
                            " while it is not contained in your squad history. Please update your team before",
                            "Error importing a player");
                    }
                }
            }
            catch (Exception e)
            {
                string info = "";
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";

                string filename = "dbinfo." + DateTime.Now.Hour.ToString() +
                    DateTime.Now.Minute.ToString() + ".tmreport.txt";
                string pathfilename = Path.Combine(Program.Setts.TeamDataFolder, filename);
                FileInfo fi = new FileInfo(pathfilename);

                PlayersDS.WriteXml(fi.FullName);
                StreamReader file = new StreamReader(fi.FullName);
                info += "PlayersDS:\r\n" + file.ReadToEnd();
                file.Close();

                info += "Squad:\r\n" + squad;

                ErrorReport.Send(e, info, Environment.StackTrace, swRelease);
                MessageBox.Show(Current.Language.SorryTheImportingProcessHasFailedIfYouClickedOkTheInfoOfTheErrorHave +
                    Current.Language.BeenSentToLedLennonThatWillRemoveThisBugAsSoonAsPossible);
            }
        }

        internal void LoadSquad(DateTime dt, string squad)
        {
            if (squad.Contains("var players_ar"))
            {
                squad = squad.Replace("\'", "\"");
                LoadSquad_New(dt, squad);
            }

            try
            {
                short isReserves = 0;

                if (squad.Contains("challenges.php?reserves"))
                    isReserves = 1;

                squad = HTML_Parser.ConvertHTML(squad);

                Db_TrophyDataSet db_TrophyDataSet = null;
                db_TrophyDataSet = new Db_TrophyDataSet();
                db_TrophyDataSet.Date = dt;
                db_TrophyDataSet.Giocatori.Clear();
                db_TrophyDataSet.Portieri.Clear();

                // There will be two tables (0: players, 1: GK)
                List<string> tables = HTML_Parser.GetTags(squad, "TABLE");

                if (tables.Count == 0)
                {
                    MessageBox.Show(Current.Language.TheContentOfWhatYouPastedIsNotTheOneExpected, "Error", MessageBoxButtons.OK);
                    return;
                }

                // Get all rows of the players table
                List<string> plRows = HTML_Parser.GetTags(tables[0], "TR");

                // Row 0 is the table header
                for (int player = 1; player < plRows.Count; player++)
                {
                    Db_TrophyDataSet.GiocatoriRow row = (Db_TrophyDataSet.GiocatoriRow)db_TrophyDataSet.Giocatori.NewRow();

                    TM_Parser.ParsePlayer(ref row, plRows[player]);

                    db_TrophyDataSet.Giocatori.AddGiocatoriRow(row);
                }

                // Get all rows of the gk table
                List<string> gkRows = HTML_Parser.GetTags(tables[1], "TR");

                // Row 0 is the table header
                for (int player = 0; player < gkRows.Count; player++)
                {
                    if (gkRows[player].Contains("ASI")) continue;

                    Db_TrophyDataSet.PortieriRow row = (Db_TrophyDataSet.PortieriRow)db_TrophyDataSet.Portieri.NewRow();

                    TM_Parser.ParseGK(ref row, gkRows[player]);

                    if (row != null)
                        db_TrophyDataSet.Portieri.AddPortieriRow(row);
                }

                // Aggiunge i dati alla history
                AddData(db_TrophyDataSet, isReserves);

                // Aggiunge i dati alle extra info
                if (PlayersDS == null) PlayersDS = new ExtraDS();
                PlayersDS.AddPlyrDataFromTDS(db_TrophyDataSet, isReserves);
            }
            catch (Exception e)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";
                ErrorReport.Send(e, squad, Environment.StackTrace, swRelease);
                MessageBox.Show(Current.Language.SorryTheImportingProcessHasFailedIfYouClickedOkTheInfoOfTheErrorHave +
                    Current.Language.BeenSentToLedLennonThatWillRemoveThisBugAsSoonAsPossible);
            }
        }

        internal void LoadSquad_New(DateTime dt, string squad)
        {
            string originalSquadString = squad;
            Db_TrophyDataSet db_TrophyDataSet = null;
            short isReserves = 0;
            int player = 0;

            try
            {

                if (squad.Contains("SourceURL:<TM - Squad - Reserves>"))
                    isReserves = 1;

                squad = HTML_Parser.ConvertHTML_Text(squad);

                db_TrophyDataSet = new Db_TrophyDataSet();
                db_TrophyDataSet.Date = dt;
                db_TrophyDataSet.Giocatori.Clear();
                db_TrophyDataSet.Portieri.Clear();

                string players_ar = HTML_Parser.GetField(squad, "var players_ar = [", "}]") + "}";
                List<string> plRows = HTML_Parser.GetFields(players_ar, "{", "}");

                // Try to parse only the first row for the squadId
                if (plRows.Count > 0)
                {
                    Dictionary<string, string> data = TM_Parser.CreateDictionary(plRows[0]);
                    int squadID = int.Parse(data["club"]);
                    if ((isReserves == 0) && (Program.Setts.MainSquadID == 0))
                    {
                        Program.Setts.MainSquadID = int.Parse(data["club"]);
                    }
                    else if ((squadID != Program.Setts.MainSquadID) && (Program.Setts.ReserveSquadID == 0))
                    {
                        Program.Setts.ReserveSquadID = int.Parse(data["club"]);
                    }
                    Program.Setts.Save();
                }

                // Row 0 is the table header
                for (player = 0; player < plRows.Count; player++)
                {
                    if (plRows[player].Contains("GK"))
                    {
                        Db_TrophyDataSet.PortieriRow row = (Db_TrophyDataSet.PortieriRow)db_TrophyDataSet.Portieri.NewRow();

                        string strrow = plRows[player].Replace("|", "");
                        TM_Parser.ParseGK_New(ref row, strrow);

                        if (row != null)
                            db_TrophyDataSet.Portieri.AddPortieriRow(row);
                    }
                    else
                    {
                        Db_TrophyDataSet.GiocatoriRow row = (Db_TrophyDataSet.GiocatoriRow)db_TrophyDataSet.Giocatori.NewRow();

                        string strrow = plRows[player].Replace("|", "");
                        TM_Parser.ParsePlayer_New(ref row, strrow);

                        if (row != null)
                            db_TrophyDataSet.Giocatori.AddGiocatoriRow(row);
                    }
                }

                // Aggiunge i dati alla history
                AddData(db_TrophyDataSet, isReserves);

                // Aggiunge i dati alle extra info
                if (PlayersDS == null) PlayersDS = new ExtraDS();
                PlayersDS.AddPlyrDataFromTDS(db_TrophyDataSet, isReserves);
            }
            catch (Exception e)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";

                string info = "";

                string filename = "dbinfo." + DateTime.Now.Hour.ToString() +
                    DateTime.Now.Minute.ToString() + ".tmreport.txt";
                string pathfilename = Path.Combine(Program.Setts.TeamDataFolder, filename);
                FileInfo fi = new FileInfo(pathfilename);

                PlayersDS.WriteXml(fi.FullName);

                StreamReader file = new StreamReader(fi.FullName);
                info += "PlayersDS:\r\n" + file.ReadToEnd();
                file.Close();

                db_TrophyDataSet.WriteXml(fi.FullName);

                file = new StreamReader(fi.FullName);
                info += "TDS:\r\n" + file.ReadToEnd();
                file.Close();

                info += "isReserves:" + isReserves.ToString();
                info += "player:" + player.ToString();
                info += "Squad:" + originalSquadString;

                ErrorReport.Send(e, info, Environment.StackTrace, swRelease);
                MessageBox.Show(Current.Language.SorryTheImportingProcessHasFailedIfYouClickedOkTheInfoOfTheErrorHave +
                    Current.Language.BeenSentToLedLennonThatWillRemoveThisBugAsSoonAsPossible);
            }
        }

        internal void LoadSquad_NewTm(NTR_Db.Content content)
        {
            DateTime dt = DateTime.Now;
            string squad = "";
            string originalSquadString = squad;
            Db_TrophyDataSet db_TrophyDataSet = null;
            short isReserves = 0;
            int player = 0;

            try
            {
                if (Program.Setts.MainSquadID <= 0)
                {
                    Program.Setts.MainSquadID = content.MainSquadID;
                    Program.Setts.Save();
                }
                if (Program.Setts.ReserveSquadID <= 0)
                {
                    Program.Setts.ReserveSquadID = content.ReserveSquadID;
                    Program.Setts.Save();
                }

                db_TrophyDataSet = new Db_TrophyDataSet();
                db_TrophyDataSet.Date = dt;
                db_TrophyDataSet.Giocatori.Clear();
                db_TrophyDataSet.Portieri.Clear();

                foreach(NTR_Db.NTR_SquadDb.HistDataRow historyRow in content.squadDB.HistData)
                {
                    if (historyRow.PlayerRow.FPn == 0)
                    {
                        Db_TrophyDataSet.PortieriRow row = (Db_TrophyDataSet.PortieriRow)db_TrophyDataSet.Portieri.NewRow();

                        ImportContentInPortieriRow(row, historyRow);

                        row.IsReserve = (short)((historyRow.PlayerRow.TeamID == content.MainSquadID) ? 0 : 1);

                        if (row != null)
                            db_TrophyDataSet.Portieri.AddPortieriRow(row);
                    }
                    else
                    {
                        Db_TrophyDataSet.GiocatoriRow row = (Db_TrophyDataSet.GiocatoriRow)db_TrophyDataSet.Giocatori.NewRow();

                        ImportContentInGiocatoriRow(row, historyRow);

                        row.IsReserve = (short)((historyRow.PlayerRow.TeamID == content.MainSquadID) ? 0 : 1);
                        row.FP = historyRow.PlayerRow.FP;

                        if (row != null)
                            db_TrophyDataSet.Giocatori.AddGiocatoriRow(row);
                    }
                }

                // Aggiunge i dati alla history
                AddData_NewTM(db_TrophyDataSet);

                // Aggiunge i dati alle extra info
                if (PlayersDS == null) PlayersDS = new ExtraDS();
                PlayersDS.AddPlyrDataFromTDS_NewTM(db_TrophyDataSet);
            }
            catch (Exception e)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";

                string info = "";

                string filename = "dbinfo." + DateTime.Now.Hour.ToString() +
                    DateTime.Now.Minute.ToString() + ".tmreport.txt";
                string pathfilename = Path.Combine(Program.Setts.TeamDataFolder, filename);
                FileInfo fi = new FileInfo(pathfilename);

                PlayersDS.WriteXml(fi.FullName);

                StreamReader file = new StreamReader(fi.FullName);
                info += "PlayersDS:\r\n" + file.ReadToEnd();
                file.Close();

                db_TrophyDataSet.WriteXml(fi.FullName);

                file = new StreamReader(fi.FullName);
                info += "TDS:\r\n" + file.ReadToEnd();
                file.Close();

                info += "isReserves:" + isReserves.ToString();
                info += "player:" + player.ToString();
                info += "Squad:" + originalSquadString;

                ErrorReport.Send(e, info, Environment.StackTrace, swRelease);
                MessageBox.Show(Current.Language.SorryTheImportingProcessHasFailedIfYouClickedOkTheInfoOfTheErrorHave +
                    Current.Language.BeenSentToLedLennonThatWillRemoveThisBugAsSoonAsPossible);
            }
        }

        private void ImportContentInPortieriRow(Db_TrophyDataSet.PortieriRow row, NTR_Db.NTR_SquadDb.HistDataRow historyRow)
        {
            row.Aer = historyRow.Aer;
            row.ASI = historyRow.ASI;
            row.Com = historyRow.Com;
            row.Ele = historyRow.Ele;
            row.For = historyRow.For;
            row.Infortunato = historyRow.Inj;
            row.Lan = historyRow.Lan;
            row.Pre = historyRow.Pre;
            row.Res = historyRow.Res;
            row.Rif = historyRow.Rif;
            row.Tir = historyRow.Tir;
            row.Uno = historyRow.Uno;
            row.Vel = historyRow.Vel;

            var playerRow = historyRow.PlayerRow;
            row.Et‡ = playerRow.Age();
            row.Mesi = TmWeek.GetAge(playerRow.wBorn, DateTime.Now).Months;
            row.Nationality = playerRow.Nationality;
            row.Nome = playerRow.Name;
            row.Note = playerRow.Notes;
            row.Numero = playerRow.No;
            row.PlayerID = playerRow.PlayerID;
            row.Squalificato = historyRow.Ban;
            row.TIs = playerRow.TIs;
            row.InFormazione = false;

            var seasonRow = historyRow.PlayerRow.GetThisSeasonRow();

            row.Cards = seasonRow.Cards;
            row.Assist = seasonRow.Assists;
            row.Goals = seasonRow.Goals;
            row.MoM = seasonRow.MoM;
            row.GP = seasonRow.Gp;
            //row.Rating = seasonRow.Rating;
            row.Rec = seasonRow.Rec;
            row.Retire = (int)seasonRow.Retire;
            row.Routine = seasonRow.Rou;
            row.Wage = seasonRow.Wage;
            row.Rating = seasonRow.Rating;
        }

        private void ImportContentInGiocatoriRow(Db_TrophyDataSet.GiocatoriRow row, NTR_Db.NTR_SquadDb.HistDataRow historyRow)
        {
            row.ASI = historyRow.ASI;
            row.Cal = historyRow.Cal;
            row.Con = historyRow.Con;
            row.Cro = historyRow.Cro;
            row.Fin = historyRow.Fin;
            row.For = historyRow.For;
            row.Infortunato = historyRow.Inj;
            row.Mar = historyRow.Mar;
            row.Pas = historyRow.Pas;
            row.Pos = historyRow.Pos;
            row.Res = historyRow.Res;
            row.Tec = historyRow.Tec;
            row.Tes = historyRow.Tes;
            row.Tir = historyRow.Tir;
            row.Vel = historyRow.Vel;
            row.Wor = historyRow.Wor;

            var playerRow = historyRow.PlayerRow;
            row.Ada = (int)playerRow.Ada;
            row.Et‡ = playerRow.Age();
            row.Mesi = TmWeek.GetAge(playerRow.wBorn, DateTime.Now).Months;
            row.Nationality = playerRow.Nationality;
            row.Nome = playerRow.Name;
            row.Note = playerRow.Notes;
            row.Numero = playerRow.No;
            row.PlayerID = playerRow.PlayerID;
            row.Squalificato = historyRow.Ban;
            row.TIs = playerRow.TIs;
            row.InFormazione = false;

            var seasonRow = historyRow.PlayerRow.GetThisSeasonRow();

            row.Cards = seasonRow.Cards;
            row.Assist = seasonRow.Assists;
            row.Goals = seasonRow.Goals;
            row.MoM = seasonRow.MoM;
            row.GP = seasonRow.Gp;
            //row.Rating = seasonRow.Rating;
            row.Rec = seasonRow.Rec;
            row.Retire = (int)seasonRow.Retire;
            row.Routine = seasonRow.Rou;
            row.Wage = seasonRow.Wage;
            row.Rating = seasonRow.Rating;
        }

        internal bool LoadGains(string gainSetName)
        {
            FileInfo fi = new FileInfo(gainSetName);

            if (fi.Exists)
            {
                GD.Clear();

                try
                {
                    GD.ReadXml(gainSetName);
                }
                catch (Exception)
                {
                    MessageBox.Show("The read of the Gain set has generated an error. The default gainset has been selected.\n Please change the gain set using the Options panel");
                    GD.SetDefaultValues();
                    return false;
                }

                GD.GainDSfilename = gainSetName;
                return true;
            }
            else
            {
                return false;

                //if (false) // (MessageBox.Show(Current.Language.SelectAGainSetReplyYesOrUseADefaultSetReplyNo,
                //    // Current.Language.TMRecorderLoadGainSet, MessageBoxButtons.YesNo) == DialogResult.Yes)
                //{
                //    OpenFileDialog ofd = new OpenFileDialog();
                //    ofd.FileName = GD.GainDSfilename;
                //    ofd.Filter = "TMGain File (*.tmgain;*.tmgain.xml)|*.tmgain;*.tmgain.xml|All Files|*.*";
                //    ofd.DefaultExt = "*.tmgain*";

                //    if (ofd.ShowDialog() == DialogResult.OK)
                //    {
                //        GD.GainDSfilename = ofd.FileName;
                //        return LoadGains(GD.GainDSfilename);
                //    }
                //    else
                //    {
                //        GD.SetDefaultValues();
                //        return false;
                //    }
                //}
                //else
                //{
                //    GD.SetDefaultValues();

                //    SaveFileDialog ofd = new SaveFileDialog();
                //    ofd.FileName = "Default.tmgain";
                //    ofd.Filter = "TMGain File (*.tmgain;*.tmgain.xml)|*.tmgain;*.tmgain.xml|All Files|*.*";
                //    ofd.DefaultExt = "*.tmgain*"; 
                //    ofd.Title = Current.Language.SelectTheLocationWhereToSaveTheGainFile;

                //    if (ofd.ShowDialog() == DialogResult.OK)
                //    {
                //        GD.GainDSfilename = ofd.FileName;
                //        GD.WriteXml(GD.GainDSfilename);
                //        return true;
                //    }

                //    return false;
                //}
            }
        }

        internal bool EditGainSet()
        {
            GainSetEditor gse = new GainSetEditor(ref PFun.gds);
            if (gse.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            return false;
        }

        internal void DeleteOldPlayers()
        {
            MessageBox.Show("The method or operation is still not implemented.");
        }

        internal void FillActualPlayersList(ExtraDS eds, DateTime dt)
        {
            eds.Giocatori.Clear();

            PlayersDS.FillWithActualPlayers(eds, dt);
        }

        internal void LoadSquadFileFromExcelForm(DateTime dt)
        {
            int NotFoundPlayers = 0;
            string playersNotFound = "\n";

            if (PlayersDS == null)
            {
                MessageBox.Show(Current.Language.YouHaveToImportALeastOneSquadHtmFileBeforeImportingYourPlayers);
                return;
            }

            Db_TrophyDataSet db_TrophyDataSet = new Db_TrophyDataSet();
            db_TrophyDataSet.Date = dt;

            string squad = Clipboard.GetText();

            db_TrophyDataSet.Giocatori.Clear();
            db_TrophyDataSet.Portieri.Clear();

            // Separate the lines
            string[] lines = squad.Split('\n');

            // Find the start of players group
            int i = 0;
            for (; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] item = line.Split('\t');

                if (item[0].Trim(' ') == "No") break;
            }

            i++;

            // Start of players group found
            for (; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] item = line.Split('\t');

                if (item[0].Trim(' ') == "No") break;
                if (line.Length < 18) continue;

                string Name = item[2].Trim(' ').Trim((char)0xa0); ;
                if (Name == "") continue;

                int plID = 0;
                if (!int.TryParse(item[1], out plID))
                    PlayersDS.FindPlayerIDByName(Name);

                if (plID == 0)
                {
                    NotFoundPlayers++;
                    playersNotFound += Name + "\n";
                    continue;
                }

                Db_TrophyDataSet.GiocatoriRow row = (Db_TrophyDataSet.GiocatoriRow)db_TrophyDataSet.Giocatori.NewRow();

                row.PlayerID = plID;
                row.Numero = int.Parse(item[0].Trim(' '));
                row.Nome = Name;
                string[] etaStr = item[3].Split('.');
                row.Et‡ = int.Parse(etaStr[0]);
                row.Mesi = int.Parse(etaStr[1]);
                row.FP = item[4].Trim(' ');

                int k = 5;

                // Row5: Forma
                row.For = int.Parse(item[k++].Trim(' '));

                // Row6: Resistenza
                row.Res = int.Parse(item[k++].Trim(' '));

                // Row7: Velocit‡
                row.Vel = int.Parse(item[k++].Trim(' '));

                if (item[k] == "") k++;

                // Row8: Marcatura
                row.Mar = int.Parse(item[k++].Trim(' '));

                // Row9: Contrasto
                row.Con = int.Parse(item[k++].Trim(' '));

                // Row10: Impegno
                row.Wor = int.Parse(item[k++].Trim(' '));

                // Row11: Posizioni
                row.Pos = int.Parse(item[k++].Trim(' '));

                // Row12: Passaggi
                row.Pas = int.Parse(item[k++].Trim(' '));

                // Row13: Cross
                row.Cro = int.Parse(item[k++].Trim(' '));

                // Row14: Tecnica
                row.Tec = int.Parse(item[k++].Trim(' '));

                // Row15: Colpo di testa
                row.Tes = int.Parse(item[k++].Trim(' '));

                // Row16: Finalizzazione
                row.Fin = int.Parse(item[k++].Trim(' '));

                // Row17: Tiro dalla distanza
                row.Tir = int.Parse(item[k++].Trim(' '));

                // Row18: Calci di punizioni
                row.Cal = int.Parse(item[k++].Trim(' '));

                // Row19: ASI
                string ASI = item[k++].Trim(' ');
                ASI = ASI.Replace('.', ',');
                ASI = ASI.Replace(",", "");
                row.ASI = int.Parse(ASI);

                row.Nationality = Program.Setts.HomeNation;
                row.InFormazione = false;
                row.Infortunato = 0;
                row.Squalificato = 0;

                db_TrophyDataSet.Giocatori.AddGiocatoriRow(row);
            }

            i++;

            // Start of GK group found
            for (; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] item = line.Split('\t');

                if (item[0].Trim(' ') == "No") break;

                if (line.Length < 18) continue;
                string Name = item[2].Trim(' ').Trim((char)0xa0);
                Name = Name.Replace("  ", " ");
                Name = Name.Replace("  ", " ");
                Name = Name.Replace("  ", " ");
                if (Name == "") continue;

                int plID = 0;
                if (!int.TryParse(item[1], out plID))
                    PlayersDS.FindPlayerIDByName(Name);

                if (plID == 0)
                {
                    NotFoundPlayers++;
                    playersNotFound += Name + "\n";
                    continue;
                }

                Db_TrophyDataSet.PortieriRow row = (Db_TrophyDataSet.PortieriRow)db_TrophyDataSet.Portieri.NewRow();

                row.PlayerID = plID;
                row.Numero = int.Parse(item[0].Trim(' '));
                row.Nome = Name;
                string[] etaStr = item[3].Split('.');
                row.Et‡ = int.Parse(etaStr[0]);
                row.Mesi = int.Parse(etaStr[1]);

                int k = 5;

                // Row5: Forma
                row.For = int.Parse(item[k++].Trim(' '));

                // Row6: Resistenza
                row.Res = int.Parse(item[k++].Trim(' '));

                // Row7: Velocit‡
                row.Vel = int.Parse(item[k++].Trim(' '));

                if (item[k] == "") k++;

                // Row8: Presa
                row.Pre = int.Parse(item[k++].Trim(' '));

                // Row9: Uno contro Uno
                row.Uno = int.Parse(item[k++].Trim(' '));

                // Row10: Riflessi
                row.Rif = int.Parse(item[k++].Trim(' '));

                // Row11: Autorit‡ aerea
                row.Aer = int.Parse(item[k++].Trim(' '));

                // Row12: Elevazione
                row.Ele = int.Parse(item[k++].Trim(' '));

                // Row13: Comunicazione
                row.Com = int.Parse(item[k++].Trim(' '));

                // Row14: Tiro
                row.Tir = int.Parse(item[k++].Trim(' '));

                // Row15: Lanci
                row.Lan = int.Parse(item[k++].Trim(' '));

                k += 3;

                // Row19: ASI
                string ASI = item[k++].Trim(' ');
                ASI = ASI.Replace('.', ',');
                ASI = ASI.Replace(",", "");
                row.ASI = int.Parse(ASI, NumberFormatInfo.InvariantInfo);

                row.InFormazione = false;
                row.Infortunato = 0;
                row.Squalificato = 0;

                row.Nationality = Program.Setts.HomeNation;

                db_TrophyDataSet.Portieri.AddPortieriRow(row);
            }

            if (NotFoundPlayers > 0)
            {
                if (MessageBox.Show("In the imported list: the following players are not been found:"
                    + playersNotFound + "Countinue?",
                    "Importing players from Excel", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }

            AddData(db_TrophyDataSet, -1);
        }

        internal void FillTeamStats(ref TeamStats teamStats)
        {
            teamStats.AgeHistory.Clear();
            teamStats.GrowthHistory.Clear();

            ExtTMDataSet lasttds = null;
            foreach (ExtTMDataSet tds in this)
            {
                TeamStats.AgeHistoryRow arow = teamStats.AgeHistory.NewAgeHistoryRow();
                arow.Date = tds.Date;

                TeamStats.GrowthHistoryRow grow = teamStats.GrowthHistory.NewGrowthHistoryRow();
                grow.Date = tds.Date;

                grow.SkillCount = 0;
                grow.DeltaSkillNeg = 0;
                grow.DeltaSkillPos = 0;

                foreach (ExtTMDataSet.GiocatoriNSkillRow row in tds.GiocatoriNSkill)
                {
                    if (row.Et‡ <= 18) arow.U18++;
                    else if (row.Et‡ <= 21) arow.U21++;
                    else if (row.Et‡ <= 24) arow.U24++;
                    else if (row.Et‡ <= 30) arow.U30++;
                    else arow.O30++;

                    grow.SkillCount += row.SkillSum;

                    grow.TotASI += row.ASI;

                    if (lasttds != null)
                    {
                        ExtTMDataSet.GiocatoriNSkillRow lastrow = lasttds.GiocatoriNSkill.FindByPlayerID(row.PlayerID);

                        if (lastrow != null)
                        {
                            decimal delta = row.SkillSum - lastrow.SkillSum;
                            if (delta > 0)
                                grow.DeltaSkillPos += delta;
                            else
                                grow.DeltaSkillNeg += delta;
                        }
                    }
                }

                foreach (ExtTMDataSet.PortieriNSkillRow row in tds.PortieriNSkill)
                {
                    if (row.Et‡ <= 18) arow.U18++;
                    else if (row.Et‡ <= 21) arow.U21++;
                    else if (row.Et‡ <= 24) arow.U24++;
                    else if (row.Et‡ <= 30) arow.U30++;
                    else arow.O30++;

                    grow.SkillCount += row.SkillSum;

                    grow.TotASI += row.ASI;

                    if (lasttds != null)
                    {
                        ExtTMDataSet.GiocatoriNSkillRow lastrow = lasttds.GiocatoriNSkill.FindByPlayerID(row.PlayerID);

                        if (lastrow != null)
                        {
                            decimal delta = row.SkillSum - lastrow.SkillSum;
                            if (delta > 0)
                                grow.DeltaSkillPos += delta;
                            else
                                grow.DeltaSkillNeg += delta;
                        }
                    }
                }

                lasttds = tds;

                teamStats.AgeHistory.AddAgeHistoryRow(arow);
                teamStats.GrowthHistory.AddGrowthHistoryRow(grow);
            }
        }


        internal void ReapplyTrainings(ExtraDS extraDS)
        {
            ClearAllDecimals();
            foreach (TrainingDataSet tds in TrainingHist)
            {
                ApplyTI_TrainingDataSet(PlayersDS, tds);
                ApplyTI_TrainingDataSet(extraDS, tds);

                int ix = 0;
                for (ix = 0; ix < this.Count; ix++)
                {
                    if (this[ix].Date < tds.Date) continue;

                    break;
                }

                if (ix == this.Count)
                {
                    MessageBox.Show(Current.Language.ThereMustBeAtLeastASquadDataSetAfterOrInTheSameDateOfATrainingSession +
                        Current.Language.LoadASquadFileFirst, Current.Language.TrainingLoad, MessageBoxButtons.OK);
                    return;
                }

                int ixAfter = ix;
                for (ix = ixAfter; ix < this.Count; ix++)
                {
                    // Applica il Training Data Set su tutti i set successivi
                    this[ix].IncSkill_TrainingDataSet(tds, this[ixAfter]);
                }
                for (ix = ixAfter - 1; ix >= 0; ix--)
                {
                    // Leva il Training Data Set da tutti i set precedenti
                    this[ix].DecSkill_TrainingDataSet(tds, this[ixAfter]);
                }
            }
        }

        internal void ApplyTI_TrainingDataSet(ExtraDS eds,
                                                TrainingDataSet tds)
        {
            foreach (TrainingDataSet.GiocatoriRow tdsRow in tds.Giocatori)
            {
                ExtraDS.GiocatoriRow gRow = eds.FindByPlayerID(tdsRow.PlayerID);

                if (gRow == null) continue;
                gRow.SetTI(tds.Date, tdsRow.TI.ToString());
                gRow.AvTSI = Common.Utility.WeightedMean(gRow.TSI);

                if (actualDts == null) continue;
                ExtTMDataSet.GiocatoriNSkillRow gnsrow = actualDts.GiocatoriNSkill.FindByPlayerID(tdsRow.PlayerID);
                if (gnsrow != null)
                    gnsrow.TI = gRow.LastTI;
            }

            foreach (TrainingDataSet.PortieriRow tdsRow in tds.Portieri)
            {
                ExtraDS.GiocatoriRow gRow = eds.FindByPlayerID(tdsRow.PlayerID);

                if (gRow == null) continue;
                gRow.SetTI(tds.Date, tdsRow.TI.ToString());
                gRow.AvTSI = Common.Utility.WeightedMean(gRow.TSI);

                if (actualDts == null) continue;
                ExtTMDataSet.PortieriNSkillRow pnsrow = actualDts.PortieriNSkill.FindByPlayerID(tdsRow.PlayerID);
                if (pnsrow != null)
                    pnsrow.TI = gRow.LastTI;
            }
        }

        internal void ExportThisWeekTrainingInExcelFormat(DateTime dt)
        {
            // Find this week training
            int ix = 0;
            for (; ix < TrainingHist.Count; ix++)
            {
                if (dt == TrainingHist[ix].Date)
                    break;
            }

            if (ix == TrainingHist.Count)
            {
                MessageBox.Show(Current.Language.YouMustSelectADateInWhichYouPastedATrainingPage,
                    Current.Language.ExportTrainingToClipboard);
                return;
            }

            string strToClip = "Name\tID\tStr\tSta\tPac\tMar\tTac\tWor\tPos\tPas\tCro\tTec\tHea\tFin\tLon\tSet\tTI\tTrainer\r\n";
            foreach (TrainingDataSet.GiocatoriRow gr in TrainingHist[ix].Giocatori)
            {
                strToClip += this.PlayersDS.FindByPlayerID(gr.PlayerID).Nome + "\t";
                strToClip += gr.ToExcelString() + "\r\n";
            }


            strToClip += "Name\tID\tStr\tSta\tPac\tHan\tOne\tRef\tAri\tJum\tCom\tKic\tThr\t-\t-\t-\tTI\tTrainer\r\n";
            foreach (TrainingDataSet.PortieriRow gr in TrainingHist[ix].Portieri)
            {
                strToClip += this.PlayersDS.FindByPlayerID(gr.PlayerID).Nome + "\t";
                strToClip += gr.ToExcelString() + "\r\n";
            }

            Clipboard.SetText(strToClip);
        }

        internal void ImportThisWeekTrainingInExcelFormat(DateTime dateTime)
        {
            string fromClip = Clipboard.GetText();

            string[] lines = fromClip.Split("\r\n".ToCharArray());

            TrainingDataSet tds = new TrainingDataSet();
            tds.Date = dateTime;

            foreach (string line in lines)
            {

                string[] items = line.Split('\t');
                int ID;

                if (items.Length < 2) continue;

                if (int.TryParse(items[1], out ID))
                {
                    if (this.PlayersDS.FindByPlayerID(ID).FP != "GK")
                    {
                        TrainingDataSet.GiocatoriRow plrow = tds.Giocatori.NewGiocatoriRow();
                        plrow.ParseExcelString(items);
                        tds.Giocatori.AddGiocatoriRow(plrow);
                    }
                    else
                    {
                        TrainingDataSet.PortieriRow row = tds.Portieri.NewPortieriRow();
                        row.ParseExcelString(items);
                        tds.Portieri.AddPortieriRow(row);
                    }
                }
            }

            AddData(tds);
        }

        internal void DisplayTrainingStatsForThisWeek(DateTime dt, SkillVariation sv,
                                                      TeamStats ts)
        {
            // Find this week training
            int ix = 0;
            for (; ix < TrainingHist.Count; ix++)
            {
                if (dt == TrainingHist[ix].Date)
                    break;
            }

            TrainingDataSet tds = null;
            if (ix != TrainingHist.Count)
            {
                tds = TrainingHist[ix];
            }

            TeamStats.GrowthHistoryRow gsRow = ts.GrowthHistory.FindByDate(dt);

            DisplayStats(tds, sv, gsRow);
        }

        internal void ExportTeamInExcelFormat(DateTime dateTime)
        {
            ExtTMDataSet eds = DSfromDate(dateTime);
            if (eds == null) return;

            string strToClip = "ID\tNum\tNat\tName\tAge\tFP\tAda\tStr\tSta\tPac\tMar\tTac\tWor\tPos\tPas\tCro\tTec\tHea\tFin\tLon\tSet\tASI\t\r\n";
            foreach (ExtTMDataSet.GiocatoriNSkillRow gr in eds.GiocatoriNSkill)
            {
                strToClip += gr.ToExcelString() + "\r\n";
            }

            strToClip += "ID\tNum\tNat\tName\tAge\tStr\tSta\tPac\tHan\tOne\tRef\tAri\tJum\tCom\tKic\tThr\tASI\t\r\n";
            foreach (ExtTMDataSet.PortieriNSkillRow gr in eds.PortieriNSkill)
            {
                strToClip += gr.ToExcelString() + "\r\n";
            }


            Clipboard.SetText(strToClip);
        }

        internal void UpdatePlayers()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        internal ExtTMDataSet DS_BeforeDate(DateTime dt)
        {
            int ix = this.Count - 1;

            for (; ix >= 0; ix--)
            {
                if (this[ix].Date > dt) continue;

                return this[ix];
            }

            return null;
        }

        internal void ComputeStats()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        internal void FillTradingList(Trading trading)
        {
            int count = 0;

            int lastWeek = 0;
            foreach (Trading.PlayersRow pr in trading.Players)
            {
                if (pr.IsDateSellNull()) continue;
                if (lastWeek < pr.DateSell)
                    lastWeek = pr.DateSell;
            }

            ProgressForm pform = new ProgressForm();
            pform.progressBar.Maximum = this.Count;
            pform.progressBar.Value = 0;
            pform.Text = "Filling the trading list with your past players: Please wait";
            pform.lblProgressDescription.Text = "Adding History: Adding weeks from a total of " + pform.progressBar.Maximum.ToString();
            Form parent = Application.OpenForms[0];
            pform.Show(parent);
            parent.Refresh();
            pform.Refresh();

            int cntRefresh = 0;

            foreach (ExtTMDataSet eds in this)
            {
                DateTime dtDS = eds.WeekNoData[0].Date;
                int weekDS = TmWeek.GetTmAbsWk(dtDS);
                TmWeek tmw = new TmWeek(dtDS);

                count++;
                pform.lblProgressDescription.Text = "Adding History: Adding week " + count.ToString() +
                    " (" + tmw.ToString() + ") of " + this.Count.ToString();
                pform.Value = count;

                if (weekDS <= lastWeek) continue;

                pform.Refresh();

                if ((cntRefresh++ % 5) == 0) parent.Refresh();

                foreach (ExtTMDataSet.GiocatoriNSkillRow gnr in eds.GiocatoriNSkill)
                {
                    Trading.PlayersRow pr = trading.Players.FindByPlayerID(gnr.PlayerID);

                    if (pr == null)
                    {
                        pr = trading.Players.NewPlayersRow();

                        pr.PlayerID = gnr.PlayerID;
                        string[] strs = gnr.Nome.Split('|');
                        pr.Name = strs[0];
                        pr.Nation = gnr.Nationality;
                        pr.DateAcquire = weekDS;
                        pr.DateSell = weekDS;
                        pr.ASIwhenSold = gnr.ASI;
                        pr.ASIwhenBuyed = gnr.ASI;
                        pr.WeekInTeam = 1;
                        pr.Age = gnr.Et‡;

                        trading.Players.AddPlayersRow(pr);
                    }
                    else
                    {
                        if (weekDS < pr.DateAcquire)
                        {
                            pr.DateAcquire = weekDS;
                            pr.ASIwhenBuyed = gnr.ASI;
                            pr.WeekInTeam = pr.DateSell - pr.DateAcquire;
                        }
                        if (weekDS > pr.DateSell)
                        {
                            pr.DateSell = weekDS;
                            pr.ASIwhenSold = gnr.ASI;
                            pr.WeekInTeam = pr.DateSell - pr.DateAcquire;
                        }
                        string[] strs = gnr.Nome.Split('|');
                        pr.Name = strs[0];
                        pr.Age = gnr.Et‡;
                        pr.ManagCost = TraderForm.ManagementCost(pr);
                    }
                }

                foreach (ExtTMDataSet.PortieriNSkillRow gnr in eds.PortieriNSkill)
                {
                    Trading.PlayersRow pr = trading.Players.FindByPlayerID(gnr.PlayerID);

                    if (pr == null)
                    {
                        pr = trading.Players.NewPlayersRow();

                        pr.PlayerID = gnr.PlayerID;
                        string[] strs = gnr.Nome.Split('|');
                        pr.Name = strs[0];
                        pr.Nation = gnr.Nationality;
                        pr.DateAcquire = weekDS;
                        pr.DateSell = weekDS;
                        pr.ASIwhenSold = gnr.ASI;
                        pr.ASIwhenBuyed = gnr.ASI;
                        pr.WeekInTeam = 1;
                        pr.Age = gnr.Et‡;

                        trading.Players.AddPlayersRow(pr);
                    }
                    else
                    {
                        if (weekDS < pr.DateAcquire)
                        {
                            pr.DateAcquire = weekDS;
                            pr.ASIwhenBuyed = gnr.ASI;
                            pr.WeekInTeam = pr.DateSell - pr.DateAcquire;
                        }
                        if (weekDS > pr.DateSell)
                        {
                            pr.DateSell = weekDS;
                            pr.ASIwhenSold = gnr.ASI;
                            pr.WeekInTeam = pr.DateSell - pr.DateAcquire;
                        }
                        string[] strs = gnr.Nome.Split('|');
                        pr.Name = strs[0];
                        pr.Age = gnr.Et‡;
                        pr.ManagCost = TraderForm.ManagementCost(pr);
                    }
                }
            }

            pform.CodeClose();
        }

        internal void FillPLTrainingTable(PlayerTraining playerTraining, int playerID)
        {
            ExtraDS.GiocatoriRow egr = PlayersDS.Giocatori.FindByPlayerID(playerID);
            int ix = -1;
            TrainingDataSet tds_in = null;
            int check = 0;

            TrainingHist.Sort(ListTrainingDataSet.CompareTrainingByDate);

            try
            {
                foreach (TrainingDataSet tds in TrainingHist)
                {
                    tds_in = tds;

                    TrainingDataSet.GiocatoriRow gr = tds.Giocatori.FindByPlayerID(playerID);
                    if (gr == null) continue;

                    PlayerTraining.TrainingRow tr = playerTraining.Training.NewTrainingRow();
                    tr.absWeek = TmWeek.GetTmAbsWk(tds.WeekNoData[0].Date);

                    int cnt = 0;
                    ix = this.Count - 1;
                    check++;
                    while (TmWeek.GetTmAbsWk(this[ix].Date) != tr.absWeek)
                    {
                        check++;
                        ix = ix - 1;
                        cnt = cnt + 1;

                        if (ix == -1) ix = this.Count - 1;
                        if (cnt == this.Count * 2) break;
                    }

                    check++;
                    if (cnt == this.Count * 2) continue; // not found

                    ExtTMDataSet.GiocatoriNSkillRow gsr = this[ix].GiocatoriNSkill.FindByPlayerID(playerID);

                    if (gsr == null) continue;

                    check++;
                    tr.For = gr.For + 2 + (int)gsr.For * 100;
                    tr.Res = gr.Res + 2 + (int)gsr.Res * 100;
                    tr.Vel = gr.Vel + 2 + (int)gsr.Vel * 100;
                    tr.Mar = gr.Mar + 2 + (int)gsr.Mar * 100;
                    tr.Con = gr.Con + 2 + (int)gsr.Con * 100;
                    tr.Wor = gr.Wor + 2 + (int)gsr.Wor * 100;
                    tr.Pos = gr.Pos + 2 + (int)gsr.Pos * 100;
                    tr.Pas = gr.Pas + 2 + (int)gsr.Pas * 100;
                    tr.Tec = gr.Tec + 2 + (int)gsr.Tec * 100;
                    tr.Tes = gr.Tes + 2 + (int)gsr.Tes * 100;
                    tr.Tir = gr.Tir + 2 + (int)gsr.Tir * 100;
                    tr.Fin = gr.Fin + 2 + (int)gsr.Fin * 100;
                    tr.Cal = gr.Cal + 2 + (int)gsr.Cal * 100;
                    tr.Cro = gr.Cro + 2 + (int)gsr.Cro * 100;

                    check++;
                    tr.Age = egr.wBorn + (TmWeek.thisWeek().absweek - tr.absWeek);
                    tr.TI = gr.TI;

                    check++;
                    if (!gr.IsTrainerIDNull() && gr.TrainerID != 0)
                    {
                        if (gr.TrainerID > 0)
                        {
                            TrainingDataSet.TrainersRow trr = tds.Trainers.FindByID(gr.TrainerID);
                            if (trr == null)
                            {
                                tr.TrainerName = "No Name";
                                tr.Percentage = 0;
                            }
                            else
                            {
                                tr.TrainerName = trr.Name;
                                tr.Percentage = trr.Percentage;
                            }
                            tr.Program = "";

                            TrainersSkills.TrainersRow tstr = null;
                            if (dbTrainers != null)
                                tstr = dbTrainers.Trainers.FindByID(gr.TrainerID);

                            check++;
                            if (tstr != null)
                            {
                                if (!tstr.IsMotNull())
                                    tr.TrainerMot = (int)tstr.Mot;

                                if ((trr.Program & 1) > 0)
                                {
                                    tr.For += 10;
                                    tr.Res += 10;
                                    tr.Wor += 10;
                                    tr.Program += "Phy:" + tstr.Fis.ToString() + ";";
                                }
                                if ((trr.Program & 2) > 0)
                                {
                                    tr.Mar += 20;
                                    tr.Con += 20;
                                    tr.Program += "Def:" + tstr.Dif.ToString() + ";";
                                }
                                if ((trr.Program & 4) > 0)
                                {
                                    tr.Pas += 30;
                                    tr.Cal += 30;
                                    tr.Tec += 30;
                                    tr.Program += "Tec:" + tstr.Tec.ToString() + ";";
                                }
                                if ((trr.Program & 8) > 0)
                                {
                                    tr.Vel += 40;
                                    tr.Cro += 40;
                                    tr.Program += "Win:" + tstr.Win.ToString() + ";";
                                }
                                if ((trr.Program & 16) > 0)
                                {
                                    tr.Tes += 50;
                                    tr.Pos += 50;
                                    tr.Program += "Hea:" + tstr.Hea.ToString() + ";";
                                }
                                if ((trr.Program & 32) > 0)
                                {
                                    tr.Fin += 60;
                                    tr.Tir += 60;
                                    tr.Program += "Att:" + tstr.Att.ToString() + ";";
                                }
                            }
                            else
                            {
                                tr.Program = "-";
                            }
                        }
                        else
                        {
                            int trainingType = -gr.TrainerID;
                            switch (trainingType)
                            {
                                case 1:
                                    tr.TrainerName = "Allenamento Tecnico";
                                    tr.Program = "Tec;Pas;Set;";
                                    tr.Tec += 30;
                                    tr.Pas += 30;
                                    tr.Cal += 30;
                                    break;
                                case 2:
                                    tr.TrainerName = "Allenamento Fisico";
                                    tr.Program = "Str;Sta;Pac;Wor;";
                                    tr.For += 10;
                                    tr.Res += 10;
                                    tr.Vel += 10;
                                    tr.Wor += 10;
                                    break;
                                case 3:
                                    tr.TrainerName = "Allenamento Tattico";
                                    tr.Program = "Wor;Pos;Pas;";
                                    tr.Wor += 50;
                                    tr.Pos += 50;
                                    tr.Pas += 50;
                                    break;
                                case 4:
                                    tr.TrainerName = "Allenamento Finalizzazione";
                                    tr.Program = "Fin;Lon;Hea;";
                                    tr.Fin += 60;
                                    tr.Tir += 60;
                                    tr.Tes += 60;
                                    break;
                                case 5:
                                    tr.TrainerName = "Allenamento Difensivo";
                                    tr.Program = "Mar;Tak;Pos;Hea;";
                                    tr.Mar += 20;
                                    tr.Con += 20;
                                    tr.Pos += 20;
                                    tr.Tes += 20;
                                    break;
                                case 6:
                                    tr.TrainerName = "Allenamento Fascia";
                                    tr.Program = "Cro;Pac;Tec;";
                                    tr.Cro += 40;
                                    tr.Vel += 40;
                                    tr.Tec += 40;
                                    break;
                                case 7:
                                    tr.Program = "GK;";
                                    break;
                            }
                        }
                    }
                    else
                    {
                        tr.TrainerName = "-";
                        tr.Program = "-";
                    }

                    check++;
                    PlayerTraining.TrainingRow trp = playerTraining.Training.FindByabsWeek(tr.absWeek);
                    if (trp == null)
                        playerTraining.Training.AddTrainingRow(tr);
                    else
                    {
                        //playerTraining.Training.RemoveTrainingRow(trp);
                        //playerTraining.Training.AddTrainingRow(tr);
                    }
                }
            }
            catch (Exception e)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";

                string info = "playerID = " + playerID.ToString() + "\r\n";
                info += "check = " + check.ToString() + "\r\n";
                info += "ix = " + ix.ToString() + "\r\n";
                info += "this.Count = " + this.Count.ToString() + "\r\n";

                string filename = "dbinfo." + DateTime.Now.Hour.ToString() +
                    DateTime.Now.Minute.ToString() + ".tmreport.txt";
                string pathfilename = Path.Combine(Program.Setts.TeamDataFolder, filename);
                FileInfo fi = new FileInfo(pathfilename);

                if (PlayersDS != null)
                {
                    PlayersDS.WriteXml(fi.FullName);
                    StreamReader file = new StreamReader(fi.FullName);
                    info += "PlayersDS:\r\n" + file.ReadToEnd();
                    file.Close();
                }
                else
                {
                    info += "\r\nPlayerTraining:null\r\n";
                }

                if (playerTraining != null)
                {
                    playerTraining.WriteXml(fi.FullName);
                    StreamReader file = new StreamReader(fi.FullName);
                    info += "PlayerTraining:\r\n" + file.ReadToEnd();
                    file.Close();
                }
                else
                {
                    info += "\r\nPlayerTraining:null\r\n";
                }

                if (dbTrainers != null)
                {
                    dbTrainers.WriteXml(fi.FullName);
                    StreamReader file = new StreamReader(fi.FullName);
                    info += "dbTrainers:\r\n" + file.ReadToEnd();
                    file.Close();
                }
                else
                {
                    info += "\r\ndbTrainers:null\r\n";
                }

                if ((ix > this.Count - 1) || (ix < 0))
                {
                    info += "\r\nix out of limits\r\n";
                }
                else if (this[ix] != null)
                {
                    this[ix].WriteXml(fi.FullName);
                    StreamReader file = new StreamReader(fi.FullName);
                    info += "\r\nthis[ix]:\r\n" + file.ReadToEnd();
                    file.Close();
                }
                else
                {
                    info += "\r\nthis[ix]:null\r\n";
                }

                if (tds_in != null)
                {
                    tds_in.WriteXml(fi.FullName);
                    StreamReader file = new StreamReader(fi.FullName);
                    info += "tds_in:\r\n" + file.ReadToEnd();
                    file.Close();
                }
                else
                {
                    info += "tds_in:null\r\n";
                }

                ErrorReport.Send(e, info, Environment.StackTrace, swRelease);
                MessageBox.Show(Current.Language.SorryTheImportingProcessHasFailedIfYouClickedOkTheInfoOfTheErrorHave +
                    Current.Language.BeenSentToLedLennonThatWillRemoveThisBugAsSoonAsPossible);
            }

        }

        internal void FillGKTrainingTable(PlayerTraining playerTraining, int playerID)
        {
            ExtraDS.GiocatoriRow egr = PlayersDS.Giocatori.FindByPlayerID(playerID);
            int ix = -1;
            TrainingDataSet tds_in = null;
            int check = 0;

            TrainingHist.Sort(ListTrainingDataSet.CompareTrainingByDate);

            try
            {
                foreach (TrainingDataSet tds in TrainingHist)
                {
                    tds_in = tds;

                    TrainingDataSet.PortieriRow gr = tds.Portieri.FindByPlayerID(playerID);
                    if (gr == null) continue;

                    PlayerTraining.TrainingRow tr = playerTraining.Training.NewTrainingRow();
                    tr.absWeek = TmWeek.GetTmAbsWk(tds.WeekNoData[0].Date);

                    int cnt = 0;
                    ix = this.Count - 1;
                    check++;
                    while (TmWeek.GetTmAbsWk(this[ix].Date) != tr.absWeek)
                    {
                        check++;
                        ix = ix - 1;
                        cnt = cnt + 1;

                        if (ix == -1) ix = this.Count - 1;
                        if (cnt == this.Count * 2) break;
                    }

                    check++;
                    if (cnt == this.Count * 2) continue; // not found

                    ExtTMDataSet.PortieriNSkillRow gsr = this[ix].PortieriNSkill.FindByPlayerID(playerID);

                    if (gsr == null) continue;

                    check++;
                    tr.For = gr.For + 2 + (int)gsr.For * 100;
                    tr.Res = gr.Res + 2 + (int)gsr.Res * 100;
                    tr.Vel = gr.Vel + 2 + (int)gsr.Vel * 100;
                    tr.Mar = gr.Pre + 2 + (int)gsr.Pre * 100;
                    tr.Con = gr.Uno + 2 + (int)gsr.Uno * 100;
                    tr.Wor = gr.Rif + 2 + (int)gsr.Rif * 100;
                    tr.Pos = gr.Aer + 2 + (int)gsr.Aer * 100;
                    tr.Pas = gr.Ele + 2 + (int)gsr.Ele * 100;
                    tr.Cro = gr.Com + 2 + (int)gsr.Com * 100;
                    tr.Tec = gr.Tir + 2 + (int)gsr.Tir * 100;
                    tr.Tes = gr.Lan + 2 + (int)gsr.Lan * 100;

                    check++;
                    tr.Age = egr.wBorn + (TmWeek.thisWeek().absweek - tr.absWeek);
                    tr.TI = gr.TI;

                    check++;
                    if (!gr.IsTrainerIDNull() && gr.TrainerID != 0)
                    {
                        if (gr.TrainerID > 0)
                        {
                            TrainingDataSet.TrainersRow trr = tds.Trainers.FindByID(gr.TrainerID);
                            if (trr == null)
                            {
                                tr.TrainerName = "No Name";
                                tr.Percentage = 0;
                            }
                            else
                            {
                                tr.TrainerName = trr.Name;
                                tr.Percentage = trr.Percentage;
                            }
                            tr.Program = "";

                            TrainersSkills.TrainersRow tstr = null;
                            if (dbTrainers != null)
                                tstr = dbTrainers.Trainers.FindByID(gr.TrainerID);

                            check++;
                            if (tstr != null)
                            {
                                if (!tstr.IsMotNull())
                                    tr.TrainerMot = (int)tstr.Mot;

                                if ((trr.Program & 1) > 0)
                                {
                                    tr.For += 10;
                                    tr.Res += 10;
                                    tr.Wor += 10;
                                    tr.Program += "Phy:" + tstr.Fis.ToString() + ";";
                                }
                                if ((trr.Program & 2) > 0)
                                {
                                    tr.Mar += 20;
                                    tr.Con += 20;
                                    tr.Program += "Def:" + tstr.Dif.ToString() + ";";
                                }
                                if ((trr.Program & 4) > 0)
                                {
                                    tr.Pas += 30;
                                    tr.Cal += 30;
                                    tr.Tec += 30;
                                    tr.Program += "Tec:" + tstr.Tec.ToString() + ";";
                                }
                                if ((trr.Program & 8) > 0)
                                {
                                    tr.Vel += 40;
                                    tr.Cro += 40;
                                    tr.Program += "Win:" + tstr.Win.ToString() + ";";
                                }
                                if ((trr.Program & 16) > 0)
                                {
                                    tr.Tes += 50;
                                    tr.Pos += 50;
                                    tr.Program += "Hea:" + tstr.Hea.ToString() + ";";
                                }
                                if ((trr.Program & 32) > 0)
                                {
                                    tr.Fin += 60;
                                    tr.Tir += 60;
                                    tr.Program += "Att:" + tstr.Att.ToString() + ";";
                                }
                            }
                            else
                            {
                                tr.Program = "-";
                            }
                        }
                        else
                        {
                            int trainingType = -gr.TrainerID;
                            switch (trainingType)
                            {
                                case 1:
                                    tr.TrainerName = "Allenamento Tecnico";
                                    tr.Program = "Tec;Pas;Set;";
                                    tr.Tec += 30;
                                    tr.Pas += 30;
                                    tr.Cal += 30;
                                    break;
                                case 2:
                                    tr.TrainerName = "Allenamento Fisico";
                                    tr.Program = "Str;Sta;Pac;Wor;";
                                    tr.For += 10;
                                    tr.Res += 10;
                                    tr.Vel += 10;
                                    tr.Wor += 10;
                                    break;
                                case 3:
                                    tr.TrainerName = "Allenamento Tattico";
                                    tr.Program = "Wor;Pos;Pas;";
                                    tr.Wor += 50;
                                    tr.Pos += 50;
                                    tr.Pas += 50;
                                    break;
                                case 4:
                                    tr.TrainerName = "Allenamento Finalizzazione";
                                    tr.Program = "Fin;Lon;Hea;";
                                    tr.Fin += 60;
                                    tr.Tir += 60;
                                    tr.Tes += 60;
                                    break;
                                case 5:
                                    tr.TrainerName = "Allenamento Difensivo";
                                    tr.Program = "Mar;Tak;Pos;Hea;";
                                    tr.Mar += 20;
                                    tr.Con += 20;
                                    tr.Pos += 20;
                                    tr.Tes += 20;
                                    break;
                                case 6:
                                    tr.TrainerName = "Allenamento Fascia";
                                    tr.Program = "Cro;Pac;Tec;";
                                    tr.Cro += 40;
                                    tr.Vel += 40;
                                    tr.Tec += 40;
                                    break;
                                case 7:
                                    tr.Program = "GK;";
                                    break;
                            }
                        }
                    }
                    else
                    {
                        tr.TrainerName = "-";
                        tr.Program = "-";
                    }

                    check++;
                    PlayerTraining.TrainingRow trp = playerTraining.Training.FindByabsWeek(tr.absWeek);
                    if (trp == null)
                        playerTraining.Training.AddTrainingRow(tr);
                    else
                    {
                        //playerTraining.Training.RemoveTrainingRow(trp);
                        //playerTraining.Training.AddTrainingRow(tr);
                    }
                }
            }
            catch (Exception e)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";

                string info = "playerID = " + playerID.ToString() + "\r\n";
                info += "check = " + check.ToString() + "\r\n";
                info += "ix = " + ix.ToString() + "\r\n";
                info += "this.Count = " + this.Count.ToString() + "\r\n";

                string filename = "dbinfo." + DateTime.Now.Hour.ToString() +
                    DateTime.Now.Minute.ToString() + ".tmreport.txt";
                string pathfilename = Path.Combine(Program.Setts.TeamDataFolder, filename);
                FileInfo fi = new FileInfo(pathfilename);

                if (PlayersDS != null)
                {
                    PlayersDS.WriteXml(fi.FullName);
                    StreamReader file = new StreamReader(fi.FullName);
                    info += "PlayersDS:\r\n" + file.ReadToEnd();
                    file.Close();
                }
                else
                {
                    info += "\r\nPlayerTraining:null\r\n";
                }

                if (playerTraining != null)
                {
                    playerTraining.WriteXml(fi.FullName);
                    StreamReader file = new StreamReader(fi.FullName);
                    info += "PlayerTraining:\r\n" + file.ReadToEnd();
                    file.Close();
                }
                else
                {
                    info += "\r\nPlayerTraining:null\r\n";
                }

                if (dbTrainers != null)
                {
                    dbTrainers.WriteXml(fi.FullName);
                    StreamReader file = new StreamReader(fi.FullName);
                    info += "dbTrainers:\r\n" + file.ReadToEnd();
                    file.Close();
                }
                else
                {
                    info += "\r\ndbTrainers:null\r\n";
                }

                if ((ix > this.Count - 1) || (ix < 0))
                {
                    info += "\r\nix out of limits\r\n";
                }
                else if (this[ix] != null)
                {
                    this[ix].WriteXml(fi.FullName);
                    StreamReader file = new StreamReader(fi.FullName);
                    info += "\r\nthis[ix]:\r\n" + file.ReadToEnd();
                    file.Close();
                }
                else
                {
                    info += "\r\nthis[ix]:null\r\n";
                }

                if (tds_in != null)
                {
                    tds_in.WriteXml(fi.FullName);
                    StreamReader file = new StreamReader(fi.FullName);
                    info += "tds_in:\r\n" + file.ReadToEnd();
                    file.Close();
                }
                else
                {
                    info += "tds_in:null\r\n";
                }

                ErrorReport.Send(e, info, Environment.StackTrace, swRelease);
                MessageBox.Show(Current.Language.SorryTheImportingProcessHasFailedIfYouClickedOkTheInfoOfTheErrorHave +
                    Current.Language.BeenSentToLedLennonThatWillRemoveThisBugAsSoonAsPossible);
            }

        }

        internal void UpdatePlayerDB(int ID, string item, object value)
        {
            if (item == "Ada")
            {
                ExtTMDataSet.GiocatoriNSkillRow gsr = actualDts.GiocatoriNSkill.FindByPlayerID(ID);
                if (gsr != null)
                {
                    gsr.Ada = (decimal)value;
                }

                actualDts.RecalculateSpecData(PFun, ID);
            }
            else if (item == "Rou")
            {
                ExtraDS.GiocatoriRow gr = PlayersDS.FindByPlayerID(ID);
                if (gr != null)
                    gr.Routine = (decimal)value;

                ExtTMDataSet.GiocatoriNSkillRow gsr = actualDts.GiocatoriNSkill.FindByPlayerID(ID);
                if (gsr != null)
                {
                    gsr.Rou = (decimal)value;
                }

                ExtTMDataSet.PortieriNSkillRow psr = actualDts.PortieriNSkill.FindByPlayerID(ID);
                if (psr != null)
                {
                    psr.Rou = (decimal)value;
                }

                actualDts.RecalculateSpecData(PFun, ID);
            }
            else if (item == "Nome")
            {
                ExtTMDataSet.GiocatoriNSkillRow gsr = actualDts.GiocatoriNSkill.FindByPlayerID(ID);
                if (gsr != null)
                {
                    gsr.Nome = (string)value;
                }

                ExtTMDataSet.PortieriNSkillRow psr = actualDts.PortieriNSkill.FindByPlayerID(ID);
                if (psr != null)
                {
                    psr.Nome = (string)value;
                }
            }
        }


        internal int ImportScouts(string page)
        {
            PlayersDS.Scouts.Clear();
            return PlayersDS.Scouts.ParseScoutPage(page);
        }
    }
}
