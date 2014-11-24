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
using NTR_Common;

namespace NTR_Db
{
    public partial class Data : Component
    {
        public int latestDataWeek = 0;
        public DateTime latestDataDay { get; set; }

        public Data()
        {
            InitializeComponent();

            InitializeNationsDS();

            latestDataDay = DateTime.MinValue;
        }

        public Data(IContainer container)
        {
            container.Add(this);

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

        public void Load(string dirPath, ref Common.SplashForm sf,
            bool trace)
        {
            // Load first the squad data
            FileInfo fi = new FileInfo(Path.Combine(dirPath, "Ntr_DB.5.xml"));

            if (!fi.Exists)
                LoadFromVersion4(dirPath, ref sf, trace);
        }

        public void LoadFromVersion4(string dirPath, ref Common.SplashForm sf,
            bool trace)
        {
            DefaultTraceListener tracer = new DefaultTraceListener();
            tracer.LogFileName = "./LoadFromPreviousDBlog.txt";

            if (trace) tracer.WriteLine("dirPath is" + dirPath);

            DirectoryInfo di = new DirectoryInfo(dirPath);

            if (!di.Exists)
            {
                MessageBox.Show("The data directory (" + dirPath + ") from where to load data does not exist",
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
            if (latestDataDay < dt)
                latestDataDay = dt;

            int week = TmWeek.GetTmAbsWk(dt);
            if (latestDataWeek < week)
                latestDataWeek = week;

            PlayersDS pds = new PlayersDS();
            foreach (TrainingDataSet.GiocatoriRow gr in tds.Giocatori)
            {
                if (pds == null) continue;

                UInt64 trCode = Tm_Training.OldTdsGiocatoriToTrCode2(gr);

                NTR_SquadDb.HistDataRow hdr = squadDB.HistData.FindByPlayerIDWeek(gr.PlayerID, week);

                if (hdr == null)
                {
                    hdr = squadDB.HistData.NewHistDataRow();
                    hdr.Week = week;
                    hdr.PlayerID = gr.PlayerID;
                    squadDB.HistData.AddHistDataRow(hdr);
                }

                hdr.Training = trCode;

                hdr._TI = (decimal)gr.TI;
            }
            foreach (TrainingDataSet.PortieriRow gr in tds.Portieri)
            {
                UInt64 trCode = Tm_Training.OldTdsPortieriToTrCode2(gr);

                NTR_SquadDb.HistDataRow hdr = squadDB.HistData.FindByPlayerIDWeek(gr.PlayerID, week);

                if (hdr == null)
                {
                    hdr = squadDB.HistData.NewHistDataRow();
                    hdr.Week = week;
                    hdr.PlayerID = gr.PlayerID;
                    squadDB.HistData.AddHistDataRow(hdr);
                }

                hdr.Training = trCode;

                hdr._TI = (decimal)gr.TI;
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
                    NTR_SquadDb.HistDataRow hdr = squadDB.HistData.NewHistDataRow();
                    hdr.ASI = gr.ASI;
                    hdr.Cal = gr.Cal;
                    hdr.Con = gr.Con;
                    hdr.Cro = gr.Cro;
                    hdr.Fin = gr.Fin;
                    hdr.For = gr.For;
                    hdr.Mar = gr.Mar;
                    hdr.Pas = gr.Pas;
                    hdr.Pos = gr.Pos;
                    hdr.Res = gr.Res;
                    hdr.Tec = gr.Tec;
                    hdr.Tes = gr.Tes;
                    hdr.Dis = gr.Tir;
                    hdr.Vel = gr.Vel;
                    hdr.Wor = gr.Wor;
                    hdr.Week = week;
                    hdr.PlayerID = gr.PlayerID;
                    hdr.Inj = (short)gr.Infortunato;
                    hdr.Ban = (short)gr.Squalificato;

                    squadDB.HistData.AddHistDataRow(hdr);
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);
                }
            }
            foreach (DB_TrophyDataSet2.PortieriRow gr in tds.Portieri)
            {
                try
                {
                    NTR_SquadDb.HistDataRow hdr = squadDB.HistData.NewHistDataRow();
                    hdr.ASI = gr.ASI;
                    hdr.Aer = gr.Aer;
                    hdr.Com = gr.Com;
                    hdr.Ele = gr.Ele;
                    hdr.For = gr.For;
                    hdr.Lan = gr.Lan;
                    hdr.Pre = gr.Pre;
                    hdr.Res = gr.Res;
                    hdr.Rif = gr.Rif;
                    hdr.Tir = gr.Tir;
                    hdr.Vel = gr.Vel;
                    hdr.Uno = gr.Uno;
                    hdr.PlayerID = gr.PlayerID;
                    hdr.Inj = (short)gr.Infortunato;
                    hdr.Ban = (short)gr.Squalificato;
                    hdr.Week = week;

                    squadDB.HistData.AddHistDataRow(hdr);
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);
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
                ScoutsNReviews.ScoutsRow ssr = scoutSkillsDS.Scouts.NewScoutsRow();
                ssr.ItemArray = esr.ItemArray;
                scoutSkillsDS.Scouts.AddScoutsRow(ssr);
            }

            squadDB.Clear();

            try
            {
                foreach (ExtraDS.GiocatoriRow gr in extraDS.Giocatori)
                {
                    NTR_SquadDb.PlayerRow pr = squadDB.Player.NewPlayerRow();

                    pr.Ada = gr.Ada;
                    pr.FP = gr.FP;
                    pr.FPn = gr.FPn;
                    pr.Nationality = gr.Nationality;
                    pr.Name = gr.Nome;
                    pr.No = gr.Numero;
                    pr.PlayerID = gr.PlayerID;

                    pr.wBorn = gr.wBorn;

                    if (!gr.IsAggressivityNull())
                        pr.Agg = gr.Aggressivity;
                    if (!gr.IsProfessionalismNull())
                        pr.Pro = gr.Professionalism;
                    if (!gr.IsLeadershipNull())
                        pr.Lea = gr.Leadership;

                    squadDB.Player.AddPlayerRow(pr);

                    NTR_SquadDb.TempDataRow tdr = squadDB.TempData.NewTempDataRow();
                    tdr.PlayerID = gr.PlayerID;
                    if (!gr.IsRoutineNull())
                        tdr.Rou = gr.Routine;
                    else
                        tdr.Rou = 0;
                    squadDB.TempData.AddTempDataRow(tdr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Clear()
        {
            gainDS.Clear();
            trainersSkillsDS.Clear();
            scoutSkillsDS.Clear();
            squadDB.Clear();
        }
    }

    public class PlayerData
    {
        private NTR_SquadDb.HistDataRow thisWeek;
        private NTR_SquadDb.HistDataRow prevWeek;

        public int Number { get; set; }
        public string Name { get; set; }
        public int Week { get; set; }
        public string SWeek { get { return (new TmSWD(Week)).ToString(); } }
        public intvar ASI { get; set; }
        public int wBorn { get; set; }
        public int FPn { get; set; }
        public string Nationality { get; set; }

        public decvar[] Skills = new decvar[14];

        public decvar Str { get { return Skills[0]; } set { Skills[0] = value; } }
        public decvar Pac { get { return Skills[1]; } set { Skills[1] = value; } }
        public decvar Sta { get { return Skills[2]; } set { Skills[2] = value; } }

        public decvar Mar { get { return Skills[3]; } set { Skills[3] = value; } }
        public decvar Tac { get { return Skills[4]; } set { Skills[4] = value; } }
        public decvar Wor { get { return Skills[5]; } set { Skills[5] = value; } }
        public decvar Pos { get { return Skills[6]; } set { Skills[6] = value; } }
        public decvar Pas { get { return Skills[7]; } set { Skills[7] = value; } }
        public decvar Cro { get { return Skills[8]; } set { Skills[8] = value; } }
        public decvar Tec { get { return Skills[9]; } set { Skills[9] = value; } }
        public decvar Hea { get { return Skills[10]; } set { Skills[10] = value; } }
        public decvar Fin { get { return Skills[11]; } set { Skills[11] = value; } }
        public decvar Lon { get { return Skills[12]; } set { Skills[12] = value; } }
        public decvar Set { get { return Skills[13]; } set { Skills[13] = value; } }

        public decvar SkillSum
        {
            get 
            {
                return Str + Pac + Sta + Mar + Tac + Wor + Pos + Pas + Cro + Tec + Hea + Fin + Lon + Set;
            }
        }

        public decimal SSD
        {
            get
            {
                return Tm_Utility.ASItoSkSum((decimal)ASI.actual, false) - this.SkillSum.actual;
            }
        }
        
        public decimal Rou { get; set; }

        public PlayerData(NTR_SquadDb.HistDataRow thisWeek, int absPrevWeek)
        {
            // TODO: Complete member initialization
            this.thisWeek = thisWeek;

            NTR_SquadDb DB = (NTR_SquadDb)thisWeek.Table.DataSet;

            if (absPrevWeek != -1)
            {
                NTR_SquadDb.HistDataDataTable histTable = (NTR_SquadDb.HistDataDataTable)thisWeek.Table;
                prevWeek = histTable.FindByPlayerIDWeek(thisWeek.PlayerID, absPrevWeek);
            }
            else
                prevWeek = null;

            Name = thisWeek.PlayerRow.Name;
            Week = thisWeek.Week;

            Number = thisWeek.PlayerRow.No;
            FPn = thisWeek.PlayerRow.FPn;
            wBorn = thisWeek.PlayerRow.wBorn;
            Nationality = thisWeek.PlayerRow.Nationality;

            NTR_SquadDb.TempDataRow tdr = DB.TempData.FindByPlayerID(thisWeek.PlayerID);
            
            if (tdr != null)
                Rou = tdr.Rou;

            if (prevWeek != null)
            {
                ASI = new intvar(thisWeek.ASI, prevWeek.ASI);
                Str = new decvar(thisWeek.For, prevWeek.For);
                Pac = new decvar(thisWeek.Vel, prevWeek.Vel);
                Sta = new decvar(thisWeek.Res, prevWeek.Res);

                Mar = new decvar(thisWeek.Mar, prevWeek.Mar);
                Tac = new decvar(thisWeek.Con, prevWeek.Con);
                Wor = new decvar(thisWeek.Wor, prevWeek.Wor);
                Pos = new decvar(thisWeek.Pos, prevWeek.Pos);
                Pas = new decvar(thisWeek.Pas, prevWeek.Pas);
                Cro = new decvar(thisWeek.Cro, prevWeek.Cro);
                Tec = new decvar(thisWeek.Tec, prevWeek.Tec);
                Hea = new decvar(thisWeek.Tes, prevWeek.Tes);
                Fin = new decvar(thisWeek.Fin, prevWeek.Fin);
                Lon = new decvar(thisWeek.Tir, prevWeek.Tir);
                Set = new decvar(thisWeek.Cal, prevWeek.Cal);
            }
            else
            {
                ASI = new intvar(thisWeek.ASI);
                Str = new decvar(thisWeek.For);
                Pac = new decvar(thisWeek.Vel);
                Sta = new decvar(thisWeek.Res);

                Mar = new decvar(thisWeek.Mar);
                Tac = new decvar(thisWeek.Con);
                Wor = new decvar(thisWeek.Wor);
                Pos = new decvar(thisWeek.Pos);
                Pas = new decvar(thisWeek.Pas);
                Cro = new decvar(thisWeek.Cro);
                Tec = new decvar(thisWeek.Tec);
                Hea = new decvar(thisWeek.Tes);
                Fin = new decvar(thisWeek.Fin);
                Lon = new decvar(thisWeek.Tir);
                Set = new decvar(thisWeek.Cal);
            }
        }
    }
}
