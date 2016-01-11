using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Data;
using Common;
using System.Windows.Forms;
using Languages;

namespace NTR_Common
{
    public partial class Data : Component
    {
        Dictionary<int, PlayersDS> Squad = new Dictionary<int, PlayersDS>();
        public int latestDataWeek = 0;

        public Data()
        {
            InitializeComponent();

            InitializeNationsDS();
        }

        private void InitializeNationsDS()
        {
            for (int i = 0; i < nationsDS.nations.GetLength(0); i++)
            {
                NationsDS.NamesRow nr = nationsDS.Names.NewNamesRow();
                nr.Name = nationsDS.nations[i, 0];
                nr.Abbreviation = nationsDS.nations[i, 1];
                nationsDS.Names.AddNamesRow(nr);
            }
        }

        public Data(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            InitializeNationsDS();
        }

        public void Load(string dirPath)
        {
            // Load first the squad data
            FileInfo fi = new FileInfo(Path.Combine(dirPath, "TeamDB.3.xml"));

            if (fi.Exists)
                teamDS.ReadXml(fi.FullName);

            // InTeam values:
            // 0: Not in any team
            // 1: Shortlisted
            // 2: Shortlisted and considered in team
            // 3: In team
            foreach (TeamDS.GiocatoriNSkillRow gsr in teamDS.GiocatoriNSkill)
            {
                if (gsr.InTeam < 2) continue;

                string playerDataFile = Path.Combine(dirPath, "Player-" + gsr.PlayerID + ".4.xml");
                fi = new FileInfo(playerDataFile);

                if (!Squad.ContainsKey(gsr.PlayerID))
                    Squad.Add(gsr.PlayerID, new PlayersDS());

                Squad[gsr.PlayerID].ReadXml(playerDataFile);
            }
        }

        public bool LoadGains(string gainSetName)
        {
            FileInfo fi = new FileInfo(gainSetName);

            if (fi.Exists)
            {
                gainDS.Clear();

                try
                {
                    gainDS.ReadXml(gainSetName);
                }
                catch (Exception)
                {
                    MessageBox.Show("The read of the Gain set " + 
                        gainSetName + " has generated an error. The default gainset has been selected.\n Please change the gain set using the Options panel");
                    gainDS.SetDefaultValues();
                    return false;
                }

                gainDS.GainDSfilename = gainSetName;
                return true;
            }
            else
            {
                gainDS.SetDefaultValues();
                return false;
            }
        }

        public void LoadFromPreviousDB(string dataDirectory, ref Common.SplashForm sf,
            bool trace)
        {
            DefaultTraceListener tracer = new DefaultTraceListener();
            tracer.LogFileName = "./LoadFromPreviousDBlog.txt";

            if (trace) tracer.WriteLine("DataDirectory is" + dataDirectory);

            DirectoryInfo di = new DirectoryInfo(dataDirectory);

            if (!di.Exists)
            {
                MessageBox.Show("The data directory (" + dataDirectory + ") from where to load data does not exist",
                    "Error loading from the previous DB");
                return;
            }

            sf.UpdateStatusMessage(0, "Loading From old Players DB...");

            foreach (FileInfo fi in di.GetFiles("TeamPlayersDB.3.xml"))
            {
                AddTeamPlayerDB(fi);
                if (trace) tracer.WriteLine("Added player DB from " + fi.Name);
            }
            if (trace) tracer.Flush();
            FileInfo[] fis = di.GetFiles("HistTM-*.2.xml");
            int cntfis = fis.Length;
            for (int i=0; i<cntfis; i++)
            {
                FileInfo fi = fis[i];

                sf.UpdateStatusMessage((i*100)/cntfis, "Loading History from the old DB...");

                AddHistDataFromXML(fi);

                if (trace) tracer.WriteLine("Added History data from " + fi.Name);
            }
            if (trace) tracer.Flush();
            fis = di.GetFiles("TrainTM-*.2.xml");
            cntfis = fis.Length;
            for (int i = 0; i < cntfis; i++)            
            {
                FileInfo fi = fis[i];

                sf.UpdateStatusMessage((i * 100) / cntfis, "Loading Training from the old DB...");

                AddTrainingDataFromXML(fi);
                
                if (trace) tracer.WriteLine("Added Training data from " + fi.Name);
            }
            if (trace) tracer.Flush();
        }

        #region SUPPORT FOR OLD DATA VERSION
        private void AddTrainingDataFromXML(FileInfo fi)
        {
            try
            {
                TrainingDataSet tds = new TrainingDataSet();
                tds.ReadXml(fi.FullName);
                AddTrainingOld(tds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Current.Language.TheFile + fi.Name + Current.Language.IsNotAValidFile + "Error:" + ex.Message, Current.Language.ErrorLoadingAFile);
            }
        }

        private void AddTrainingOld(TrainingDataSet tds)
        {
            DateTime dt = tds.Date;
            int week = TmWeek.GetTmAbsWk(dt);
            if (latestDataWeek < week)
                latestDataWeek = week;

            foreach (TrainingDataSet.GiocatoriRow gr in tds.Giocatori)
            {
                if (!Squad.ContainsKey(gr.PlayerID)) continue;
                PlayersDS pds = Squad[gr.PlayerID];
                if (pds == null) continue;

                int[] trCode = Tm_Training.OldTdsGiocatoriToTrCode(gr);

                PlayersDS.VarDataRow vdr = pds.VarData.FindByWeek(week);
                if (vdr == null)
                {
                    vdr = pds.VarData.NewVarDataRow();
                    vdr.Week = week;
                    pds.VarData.AddVarDataRow(vdr);
                }
                vdr.TrCodeP = trCode[0];
                vdr.TrCodeN = trCode[1];

                if (!gr.IsTrainerIDNull())
                    vdr.TrainerID = gr.TrainerID;
                vdr._TI = (decimal)gr.TI;
            }
            foreach (TrainingDataSet.PortieriRow gr in tds.Portieri)
            {
                if (!Squad.ContainsKey(gr.PlayerID)) continue;
                PlayersDS pds = Squad[gr.PlayerID];

                int[] trCode = Tm_Training.OldTdsPortieriToTrCode(gr);

                PlayersDS.VarDataRow vdr = pds.VarData.FindByWeek(week);

                if (vdr == null)
                {
                    vdr = pds.VarData.NewVarDataRow();
                    vdr.Week = week;
                    pds.VarData.AddVarDataRow(vdr);
                }
                vdr.TrCodeP = trCode[0];
                vdr.TrCodeN = trCode[1];
                if (!gr.IsTrainerIDNull())
                    vdr.TrainerID = gr.TrainerID;
                vdr._TI = (decimal)gr.TI;
            }
        }

        private void AddHistDataFromXML(FileInfo fi)
        {
            try
            {
                DB_TrophyDataSet2 tds = new DB_TrophyDataSet2();
                tds.ReadXml(fi.FullName);
                tds.fiSource = fi;
                AddHistDataOld(tds);
            }
            catch (Exception)
            {
                MessageBox.Show(Current.Language.TheFile + fi.Name + Current.Language.IsNotAValidFile, Current.Language.ErrorLoadingAFile);
            }            
        }

        private void AddHistDataOld(DB_TrophyDataSet2 tds)
        {
            DateTime dt = tds.Date;
            int week = TmWeek.GetTmAbsWk(dt);
            foreach (DB_TrophyDataSet2.GiocatoriRow gr in tds.Giocatori)
            {
                try
                {
                    PlayersDS pds = null;
                    if (!Squad.ContainsKey(gr.PlayerID))
                    {
                        pds = new PlayersDS();
                        Squad.Add(gr.PlayerID, pds);
                        pds.FixDataVal.PlayerID = gr.PlayerID;
                    }
                    else
                    {
                        pds = Squad[gr.PlayerID];
                    }

                    PlayersDS.FixDataRow fdr = pds.FixDataVal;

                    PlayersDS.VarDataRow vdr = pds.VarData.NewVarDataRow();
                    vdr.ASI = gr.ASI;
                    vdr.Cal = gr.Cal;
                    vdr.Con = gr.Con;
                    vdr.Cro = gr.Cro;
                    vdr.Fin = gr.Fin;
                    vdr.For = gr.For;
                    //gr.Infortunato;
                    vdr.Mar = gr.Mar;
                    vdr.Pas = gr.Pas;
                    vdr.Pos = gr.Pos;
                    vdr.Res = gr.Res;
                    //gr.Squalificato;
                    vdr.Tec = gr.Tec;
                    vdr.Tes = gr.Tes;
                    vdr.Dis = gr.Tir;
                    vdr.Vel = gr.Vel;
                    vdr.Wor = gr.Wor;
                    vdr.Week = week;

                    TeamDS.GiocatoriNSkillRow gnsr = null;
                        
                    bool addedPlayer = false;
                    gnsr = teamDS.GiocatoriNSkill.FindByPlayerID(gr.PlayerID);
                    if (gnsr == null)
                    { 
                        addedPlayer = true;
                        gnsr = teamDS.GiocatoriNSkill.NewGiocatoriNSkillRow();
                    }

                    gnsr.ASI = gr.ASI;
                    gnsr.Cal = gr.Cal;
                    gnsr.Con = gr.Con;
                    gnsr.Cro = gr.Cro;
                    gnsr.Fin = gr.Fin;
                    gnsr.For = gr.For;
                    gnsr.Mar = gr.Mar;
                    gnsr.Pas = gr.Pas;
                    gnsr.Pos = gr.Pos;
                    gnsr.Res = gr.Res;
                    gnsr.Tec = gr.Tec;
                    gnsr.Tes = gr.Tes;
                    gnsr.Dis = gr.Tir;
                    gnsr.Vel = gr.Vel;
                    gnsr.Wor = gr.Wor;

                    if (gnsr.IsLastWeekNull())
                        gnsr.LastWeek = week;
                    else if (gnsr.LastWeek < week)
                        gnsr.LastWeek = week;

                    if (addedPlayer)
                    {
                        teamDS.GiocatoriNSkill.AddGiocatoriNSkillRow(gnsr);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            foreach (DB_TrophyDataSet2.PortieriRow gr in tds.Portieri)
            {
                try
                {
                    PlayersDS pds = null;
                    if (!Squad.ContainsKey(gr.PlayerID))
                    {
                        pds = new PlayersDS();
                        Squad.Add(gr.PlayerID, pds);
                        pds.FixDataVal.PlayerID = gr.PlayerID;
                    }
                    else
                    {
                        pds = Squad[gr.PlayerID];
                    }

                    PlayersDS.FixDataRow fdr = pds.FixDataVal;

                    PlayersDS.VarDataRow vdr = pds.VarData.NewVarDataRow();
                    vdr.ASI = gr.ASI;
                    vdr.Aer = gr.Aer;
                    vdr.Com = gr.Com;
                    vdr.Ele = gr.Ele;
                    vdr.For = gr.For;
                    //gr.Infortunato;
                    vdr.Lan = gr.Lan;
                    vdr.Pre = gr.Pre;
                    vdr.Res = gr.Res;
                    vdr.Rif = gr.Rif;
                    //gr.Squalificato;
                    vdr.Tir = gr.Tir;
                    vdr.Vel = gr.Vel;
                    vdr.Week = TmWeek.GetTmAbsWk(dt);

                    TeamDS.GiocatoriNSkillRow gnsr = null;

                    bool addedPlayer = false;
                    gnsr = teamDS.GiocatoriNSkill.FindByPlayerID(gr.PlayerID);
                    if (gnsr == null)
                    {
                        addedPlayer = true;
                        gnsr = teamDS.GiocatoriNSkill.NewGiocatoriNSkillRow();
                    }

                    gnsr.ASI = gr.ASI;
                    gnsr.Aer = gr.Aer;
                    gnsr.Com = gr.Com;
                    gnsr.Ele = gr.Ele;
                    gnsr.For = gr.For;
                    //gr.Infortunato;
                    gnsr.Lan = gr.Lan;
                    gnsr.Pre = gr.Pre;
                    gnsr.Res = gr.Res;
                    gnsr.Rif = gr.Rif;
                    //gr.Squalificato;
                    gnsr.Tir = gr.Tir;
                    gnsr.Vel = gr.Vel;

                    if (gnsr.IsLastWeekNull())
                        gnsr.LastWeek = week;
                    else if (gnsr.LastWeek < week)
                        gnsr.LastWeek = week;

                    if (addedPlayer)
                    {
                        teamDS.GiocatoriNSkill.AddGiocatoriNSkillRow(gnsr);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void AddTeamPlayerDB(FileInfo xmlfi)
        {
            ExtraDS extraDS = new ExtraDS();

            try
            {
                extraDS.ReadXml(xmlfi.FullName);

                foreach (ExtraDS.GiocatoriRow gr in extraDS.Giocatori)
                {
                    if (gr.IswBornNull())
                    {
                        if (gr.IsEtàNull()) continue;
                        gr.wBorn = TmWeek.GetBornWeekFromAge(DateTime.Now, gr.Età.ToString());
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

            //-------------------------------------------
            // Put old DS in the new DS
            //-------------------------------------------

            // SCOUTS
            scoutSkillsDS.Clear();
            foreach (ExtraDS.ScoutsRow esr in extraDS.Scouts)
            {
                Common.ScoutsNReviews.ScoutsRow ssr = scoutSkillsDS.Scouts.NewScoutsRow();
                ssr.ItemArray = esr.ItemArray;
                scoutSkillsDS.Scouts.AddScoutsRow(ssr);
            }

            teamDS.Clear();
            Squad.Clear();

            try
            {
                foreach (ExtraDS.GiocatoriRow gr in extraDS.Giocatori)
                {
                    TeamDS.GiocatoriNSkillRow gnsr = teamDS.GiocatoriNSkill.NewGiocatoriNSkillRow();
                    gnsr.Ada = gr.Ada;
                    if (gr.IsEtàNull()) continue;

                    gnsr.Age = gr.Età;
                    if (gr.IsASINull()) continue;
                    gnsr.ASI = gr.ASI;
                    gnsr.cTI = gr.LastTI;
                    gnsr.FP = gr.FP;
                    gnsr.FPn = gr.FPn;
                    gnsr.Nationality = gr.Nationality;
                    gnsr.Nome = gr.Nome;
                    gnsr.Numero = gr.Numero;
                    gnsr.PlayerID = gr.PlayerID;
                    if (!gr.IsRoutineNull())
                        gnsr.Rou = gr.Routine;
                    else
                        gnsr.Rou = 0;
                    gnsr.wBorn = gr.wBorn;

                    if (!gr.IsAggressivityNull())
                        gnsr.Agg = gr.Aggressivity;
                    if (!gr.IsProfessionalismNull())
                        gnsr.Pro = gr.Professionalism;
                    if (!gr.IsLeadershipNull())
                        gnsr.Lea = gr.Leadership;

                    teamDS.GiocatoriNSkill.AddGiocatoriNSkillRow(gnsr);

                    if (!Squad.ContainsKey(gr.PlayerID))
                    {
                        PlayersDS pds = new PlayersDS();
                        PlayersDS.FixDataRow fdr = pds.FixDataVal;
                        fdr.Ada = gnsr.Ada;
                        fdr.FP = gnsr.FP;
                        fdr.FPn = gr.FPn;
                        fdr.Nationality = gr.Nationality;
                        fdr.Nome = gr.Nome;
                        fdr.Numero = gr.Numero;
                        fdr.PlayerID = gr.PlayerID;

                        if (!gr.IsRoutineNull())
                            fdr.Rou = gr.Routine;
                        else
                            fdr.Rou = 0;

                        fdr.wBorn = gr.wBorn;

                        if (!gnsr.IsAggNull())
                            fdr.Agg = gnsr.Agg;
                        if (!gnsr.IsProNull())
                            fdr.Pro = gnsr.Pro;
                        if (!gnsr.IsLeaNull())
                            fdr.Lea = gnsr.Lea;

                        Squad.Add(gr.PlayerID, pds);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        public void CleanOldData()
        {
            for (int i=0; i<teamDS.GiocatoriNSkill.Count; i++)
            {
                TeamDS.GiocatoriNSkillRow gr = teamDS.GiocatoriNSkill[i];
            
                if (gr.IsLastWeekNull())
                {
                    teamDS.GiocatoriNSkill.RemoveGiocatoriNSkillRow(gr);
                    i = i - 1;
                    continue;
                }

                if (gr.LastWeek < latestDataWeek-1)
                {
                    teamDS.GiocatoriNSkill.RemoveGiocatoriNSkillRow(gr);
                    i = i - 1;
                }
            }
        }
    }
}
