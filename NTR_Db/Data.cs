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
using System.IO.Compression;
using System.Drawing;
using System.Linq;
using System.Collections;

namespace NTR_Db
{
    public partial class Data : Component
    {
        public int latestDataWeek = -1;
        public DateTime latestDataDay { get; set; }

        private TeamList _ownedSquadsList = null;
        public TeamList OwnedSquadsList
        {
            get
            {
                if (_ownedSquadsList == null)
                {
                    _ownedSquadsList = new TeamList();

                    EnumerableRowCollection<NTR_SquadDb.TeamRow> OwnedSquads = (from c in squadDB.Team
                                                                    where (c.Owner == true)
                                                                    select c);
                    foreach (NTR_SquadDb.TeamRow tr in OwnedSquads)
                    {
                        _ownedSquadsList.Add(tr.TeamID, tr.Name);
                    }
                }
                return _ownedSquadsList;
            }
        }

        public Data()
        {
            InitializeComponent();

            InitializeNationsDS();

            latestDataDay = DateTime.MinValue;

            squadDB.GDS = this.gainDS;
        }

        public Data(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            InitializeNationsDS();

            squadDB.GDS = this.gainDS;
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

        public void LoadOldDB(string dirPath, ref Common.SplashForm sf, bool trace)
        {
            LoadFromVersion4(dirPath, ref sf, trace);

            Invalidate();
        }

        public void Load(string dirPath, ref Common.SplashForm sf,
            bool trace)
        {
            // Load first the squad data
            FileInfo fi = new FileInfo(Path.Combine(dirPath, "Players.5.xml"));

            if (fi.Exists)
            {
                DirectoryInfo di = new DirectoryInfo(dirPath);

                fi = new FileInfo(Path.Combine(dirPath, "Players.5.xml"));
                squadDB.Player.ReadXml(fi.FullName);

                FileInfo[] fis = di.GetFiles("HistData-*.5.xml");
                int cntfis = fis.Length;
                for (int i = 0; i < cntfis; i++)
                {
                    fi = fis[i];

                    NTR_SquadDb.HistDataDataTable tempHistDataDataTable = new NTR_SquadDb.HistDataDataTable();
                    tempHistDataDataTable.ReadXml(fi.FullName);
                    squadDB.HistData.Merge(tempHistDataDataTable);
                }

                fi = new FileInfo(Path.Combine(dirPath, "ScoutReview.5.xml"));
                squadDB.ScoutReview.ReadXml(fi.FullName);

                fi = new FileInfo(Path.Combine(dirPath, "Scout.5.xml"));
                squadDB.Scout.ReadXml(fi.FullName);

                fi = new FileInfo(Path.Combine(dirPath, "TempData.5.xml"));
                squadDB.TempData.ReadXml(fi.FullName);

                fi = new FileInfo(Path.Combine(dirPath, "Team.5.xml"));
                squadDB.Team.ReadXml(fi.FullName);

                fi = new FileInfo(Path.Combine(dirPath, "Match.5.xml"));
                if (fi.Exists)
                    squadDB.Match.ReadXml(fi.FullName);

                fi = new FileInfo(Path.Combine(dirPath, "TeamData.5.xml"));
                if (fi.Exists)
                    squadDB.TeamData.ReadXml(fi.FullName);

                fi = new FileInfo(Path.Combine(dirPath, "PlayerPerf.5.xml"));
                if (fi.Exists)
                    squadDB.PlayerPerf.ReadXml(fi.FullName);

                fi = new FileInfo(Path.Combine(dirPath, "Actions.5.xml"));
                if (fi.Exists)
                    squadDB.Actions.ReadXml(fi.FullName);

                fi = new FileInfo(Path.Combine(dirPath, "ActionsDecoder.5.xml"));
                if (fi.Exists)
                    squadDB.ActionsDecoder.ReadXml(fi.FullName);

                latestDataWeek = -1;
                foreach (NTR_SquadDb.HistDataRow histDataRow in squadDB.HistData)
                {
                    if (latestDataWeek < histDataRow.Week)
                        latestDataWeek = histDataRow.Week;
                }
            }
            Invalidate();
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

            // Getting History data
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

            // Getting training data
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

            // Getting matches data
            FileInfo fin = new FileInfo(Path.Combine(di.FullName, "MatchesHistory.3.xml"));
            AddChampsDataFromOldXML(fin);

            fis = di.GetFiles("Match_*.xml");
            cntfis = fis.Length;

            for (int i = 0; i < cntfis; i++)
            {
                fin = fis[i];

                sf.UpdateStatusMessage((i * 100) / cntfis, "Loading Matches from the old DB...");

                AddMatchDataFromXML(fin);

                if (trace) tracer.WriteLine("Added Matches data from " + fin.Name);
            }

            Invalidate();
        }

        private void AddMatchDataFromXML(FileInfo fin)
        {
            MatchDS matchDS = new MatchDS();
            matchDS.ReadXml(fin.FullName);

            int matchID = int.Parse(HTML_Parser.GetNumberAfter(fin.FullName, "Match_"));

            NTR_SquadDb.MatchRow matchRow = squadDB.Match.FindByMatchID(matchID);
            int YTeamID = matchRow.YTeamID;
            int OTeamID = matchRow.OTeamID;

            try
            {

                foreach (MatchDS.YourTeamPerfRow perfRow in matchDS.YourTeamPerf)
                {
                    NTR_SquadDb.PlayerRow pr = squadDB.Player.FindByPlayerID(perfRow.PlayerID);
                    if (pr == null)
                    {
                        pr = squadDB.Player.NewPlayerRow();
                        pr.PlayerID = perfRow.PlayerID;
                        pr.Name = perfRow.Name;
                        squadDB.Player.AddPlayerRow(pr);
                    }

                    NTR_SquadDb.PlayerPerfRow ppr = squadDB.PlayerPerf.FindByMatchIDPlayerID(matchID, perfRow.PlayerID);
                    if (ppr == null)
                    {
                        ppr = squadDB.PlayerPerf.NewPlayerPerfRow();
                        ppr.PlayerID = perfRow.PlayerID;
                        ppr.MatchID = matchID;
                        squadDB.PlayerPerf.AddPlayerPerfRow(ppr);
                    }

                    pr.TeamID = YTeamID;
                    ppr.TeamID = YTeamID;
                    if (!perfRow.IsVoteNull())
                        ppr.Vote = perfRow.Vote;
                    ppr.Position = perfRow.Position;
                    ppr.Scored = perfRow.Scored;
                    ppr.Number = perfRow.Number;
                    ppr.Assist = perfRow.Assist;
                    ppr.Status = perfRow.Status;
                    ppr.NPos = perfRow.NPos;
                }
            }
            catch (Exception)
            {
            }

            try
            {
                foreach (MatchDS.OppsTeamPerfRow perfRow in matchDS.OppsTeamPerf)
                {
                    NTR_SquadDb.PlayerRow pr = squadDB.Player.FindByPlayerID(perfRow.PlayerID);
                    if (pr == null)
                    {
                        pr = squadDB.Player.NewPlayerRow();
                        pr.PlayerID = perfRow.PlayerID;

                        pr.TeamID = OTeamID;
                        pr.Name = perfRow.Name;
                        squadDB.Player.AddPlayerRow(pr);
                    }

                    NTR_SquadDb.PlayerPerfRow ppr = squadDB.PlayerPerf.FindByMatchIDPlayerID(matchID, perfRow.PlayerID);
                    if (ppr == null)
                    {
                        ppr = squadDB.PlayerPerf.NewPlayerPerfRow();
                        ppr.PlayerID = perfRow.PlayerID;
                        ppr.MatchID = matchID;
                        squadDB.PlayerPerf.AddPlayerPerfRow(ppr);
                    }

                    ppr.TeamID = OTeamID;
                    if (!perfRow.IsVoteNull())
                        ppr.Vote = perfRow.Vote;
                    ppr.Position = perfRow.Position;
                    ppr.Scored = perfRow.Scored;
                    ppr.Number = perfRow.Number;
                    ppr.Assist = perfRow.Assist;
                    ppr.Status = perfRow.Status;
                    ppr.NPos = perfRow.NPos;
                }
            }
            catch(Exception)
            {
            }

            // TODO: Save Actions
            int actionID = 0;
            int YTeamColor = -1;
            int OTeamColor = -1;

            foreach (MatchDS.ActionsRow actionsRow in matchDS.Actions)
            {
                NTR_SquadDb.ActionsRow ar = squadDB.Actions.FindByMatchIDActionID(matchID, actionID);
                if (ar == null)
                {
                    ar = squadDB.Actions.NewActionsRow();
                    ar.ActionID = actionID;
                    ar.MatchID = matchID;
                    squadDB.Actions.AddActionsRow(ar);
                }
                actionID++;

                ar.ActionCode = actionsRow.ActionCode;
                if (!actionsRow.IsActionTypeNull())
                    ar.ActionType = actionsRow.ActionType;
                ar.Description = actionsRow.Description;
                ar.FullDesc = actionsRow.FullDesc;
                ar.Time = actionsRow.Time;
                ar.TeamID = actionsRow.ID;

                if (ar.TeamID == YTeamID)
                    YTeamColor = actionsRow.Color;
                else
                    OTeamColor = actionsRow.Color;
            }

            NTR_SquadDb.TeamRow oTeamRow = squadDB.Team.FindByTeamID(OTeamID);
            oTeamRow.Color = OTeamColor;
            NTR_SquadDb.TeamRow yTeamRow = squadDB.Team.FindByTeamID(YTeamID);
            yTeamRow.Color = YTeamColor;

            Invalidate();
        }

        private void AddChampsDataFromOldXML(FileInfo fi)
        {
            try
            {
                ChampDS champDS = new ChampDS();
                champDS.ReadXml(fi.FullName);

                foreach (ChampDS.MatchRow omr in champDS.Match)
                {
                    NTR_SquadDb.MatchRow nmr = squadDB.Match.FindByMatchID(omr.MatchID);
                    if (nmr == null)
                    {
                        nmr = squadDB.Match.NewMatchRow();
                        nmr.MatchID = omr.MatchID;
                        squadDB.Match.AddMatchRow(nmr);
                    }

                    nmr.Date = omr.Date;
                    nmr.Score = omr.Score;
                    nmr.MatchType = omr.MatchType;
                    if (!omr.IsCrowdNull())
                    {
                        nmr.Crowd = omr.Crowd;
                        nmr.Stadium = omr.Stadium;
                        nmr.Pitch = omr.Pitch;
                        nmr.Weather = omr.Weather;
                        nmr.Lineups = omr.YourFormation + ";" + omr.OppsFormation;
                        nmr.Stats = omr.YourStats + ";" + omr.OppsStats;
                        nmr.Mentalities = omr.YourMentality + ";" + omr.OppsMentality;
                        nmr.AttackStyles = omr.YourAttackingStyle + ";" + omr.OppsAttackingStyle;
                    }
                    if (!omr.IsCardsNull())
                        nmr.Cards = omr.Cards;

                    nmr.Report = omr.Report;
                    nmr.isHome = omr.isHome;
                    nmr.Analyzed = omr.Analyzed;

                    // nmr.BestPlayer = omr.Best
                    nmr.OTeamID = omr.OppsClubID;

                    NTR_SquadDb.TeamRow oppsTeamRow = squadDB.Team.FindByTeamID(nmr.OTeamID);
                    if (oppsTeamRow == null)
                    {
                        oppsTeamRow = squadDB.Team.NewTeamRow();
                        oppsTeamRow.TeamID = nmr.OTeamID;
                        oppsTeamRow.Name = omr.OppsClubName;
                        oppsTeamRow.Owner = false;
                        squadDB.Team.AddTeamRow(oppsTeamRow);
                    }

                    if (!omr.IsOppsNickNull())
                    {
                        oppsTeamRow.Nick = omr.OppsNick;
                    }

                    var team = OwnedSquadsList.FindValue(omr.isHome ? omr.Home : omr.Away);
                    int myTeamId = team.Key;

                    NTR_SquadDb.TeamRow yourTeamRow = squadDB.Team.FindByTeamID(myTeamId);
                    if (!omr.IsYourNickNull())
                    {
                        yourTeamRow.Nick = omr.YourNick;
                    }

                    // Look for your teamID searching the players
                    nmr.YTeamID = myTeamId;
                }
            }
            catch (Exception)
            {
            }
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
            foreach (ExtraDS.ScoutsRow esr in extraDS.Scouts)
            {
                Common.ScoutsNReviews.ScoutsRow ssr = scoutSkillsDS.Scouts.NewScoutsRow();
                ssr.ItemArray = esr.ItemArray;
                scoutSkillsDS.Scouts.AddScoutsRow(ssr);
            }

            try
            {
                foreach (ExtraDS.GiocatoriRow gr in extraDS.Giocatori)
                {
                    NTR_SquadDb.PlayerRow pr = squadDB.Player.FindByPlayerID(gr.PlayerID);
                    if (pr == null)
                    {
                        pr = squadDB.Player.NewPlayerRow();
                        pr.PlayerID = gr.PlayerID;
                        squadDB.Player.AddPlayerRow(pr);
                    }

                    pr.Ada = gr.Ada;
                    pr.FP = gr.FP;
                    pr.FPn = gr.FPn;
                    pr.Nationality = gr.Nationality;
                    pr.Name = gr.Nome;
                    pr.No = gr.Numero;

                    pr.wBorn = gr.wBorn;

                    if (!gr.IsAggressivityNull())
                        pr.Agg = gr.Aggressivity;
                    if (!gr.IsProfessionalismNull())
                        pr.Pro = gr.Professionalism;
                    if (!gr.IsLeadershipNull())
                        pr.Lea = gr.Leadership;                    

                    NTR_SquadDb.TempDataRow tdr = squadDB.TempData.FindByPlayerID(gr.PlayerID);
                    if(tdr == null)
                    {
                        tdr = squadDB.TempData.NewTempDataRow();
                        tdr.PlayerID = gr.PlayerID;
                        squadDB.TempData.AddTempDataRow(tdr);
                    }

                    if (!gr.IsRoutineNull())
                        if (tdr.IsRouNull())
                            tdr.Rou = gr.Routine;
                        else
                            tdr.Rou = (tdr.Rou > gr.Routine) ? tdr.Rou : tdr.Rou = gr.Routine;
                    else
                        tdr.Rou = 0;                    
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
            Invalidate();
        }

        //public void MergeContent(Content content)
        //{
        //    NTR_SquadDb mergeDB = content.squadDB;

        //    if (mergeDB == null)
        //    {
        //        MessageBox.Show("Error loading the content of the page");
        //        return;
        //    }

        //    squadDB.Merge(mergeDB);

        //    squadDB.UpdateDecimals(content);

        //    latestDataWeek = content.Week;

        //    Invalidate();
        //}

        private void Invalidate()
        {
            _ownedSquadsList = null;
            squadDB.Invalidate();
        }

        public void Save(string dirPath)
        {
            // Use it to write it compressed
            //FileStream outfile = new FileStream("TmDB.xmz", FileMode.Create, FileAccess.Write);
            //GZipStream ZipStream = new GZipStream(outfile, CompressionMode.Compress, false);

            //squadDB.WriteXml(ZipStream);

            //ZipStream.Close(); // important to close this first to flush compressed stream
            //outfile.Close(); // important to close this second to flush output stream

            FileInfo fi = new FileInfo(Path.Combine(dirPath, "Players.5.xml"));
            squadDB.Player.WriteXml(fi.FullName);
            
            List<int> weeks = squadDB.WeeksWithData;
            foreach (int week in weeks)
            {
                string filterWeek = "Week=" + week.ToString();

                string filename = "HistData-Week" + week.ToString() + ".5.xml";
                fi = new FileInfo(Path.Combine(dirPath, filename));

                NTR_SquadDb.HistDataDataTable tempHistDataDataTable = new NTR_SquadDb.HistDataDataTable();

                NTR_SquadDb.HistDataRow[] arrHistDataRows = (NTR_SquadDb.HistDataRow[])squadDB.HistData.Select(filterWeek);

                foreach (NTR_SquadDb.HistDataRow histDataRow in arrHistDataRows)
                {
                    NTR_SquadDb.HistDataRow newHistDataRow = tempHistDataDataTable.NewHistDataRow();
                    newHistDataRow.ItemArray = histDataRow.ItemArray;
                    tempHistDataDataTable.AddHistDataRow(newHistDataRow);
                }

                tempHistDataDataTable.WriteXml(fi.FullName);
            }

            fi = new FileInfo(Path.Combine(dirPath, "ScoutReview.5.xml"));
            squadDB.ScoutReview.WriteXml(fi.FullName);

            fi = new FileInfo(Path.Combine(dirPath, "Scout.5.xml"));
            squadDB.Scout.WriteXml(fi.FullName);

            fi = new FileInfo(Path.Combine(dirPath, "TempData.5.xml"));
            squadDB.TempData.WriteXml(fi.FullName);

            fi = new FileInfo(Path.Combine(dirPath, "Team.5.xml"));
            squadDB.Team.WriteXml(fi.FullName);

            fi = new FileInfo(Path.Combine(dirPath, "TeamData.5.xml"));
            squadDB.TeamData.WriteXml(fi.FullName);

            fi = new FileInfo(Path.Combine(dirPath, "Match.5.xml"));
            squadDB.Match.WriteXml(fi.FullName);

            fi = new FileInfo(Path.Combine(dirPath, "PlayerPerf.5.xml"));
            squadDB.PlayerPerf.WriteXml(fi.FullName);

            fi = new FileInfo(Path.Combine(dirPath, "Actions.5.xml"));
            squadDB.Actions.WriteXml(fi.FullName);

            fi = new FileInfo(Path.Combine(dirPath, "ActionsDecoder.5.xml"));
            squadDB.ActionsDecoder.WriteXml(fi.FullName);
        }

        public Dictionary<int, string> Teams { get; set; }

        public void LoadSavedPages(string dirPath, ref Common.SplashForm sf, bool trace)
        {
            // Select first all the team files
            // Name template: NF-players-S37-W10-D6.2.htm
            DirectoryInfo di = new DirectoryInfo(dirPath);

            sf.UpdateStatusMessage(0, "Loading Players From the saved pages...");

            foreach (FileInfo fi in di.GetFiles("NF-players-*.2.htm*"))
            {
                StreamReader file = new StreamReader(fi.FullName);

                string playersPage = file.ReadToEnd();

                file.Close();

                Content content = new Content();
                content.squadDB = this.squadDB;

                string[] str = fi.FullName.Split('-');
                string dateString = str[2] + "-" + str[3] + "-" + str[4];
                int importWeek = TmWeek.SWDtoTmWeek(dateString).absweek;

                content.ParsePage(playersPage, "http://trophymanager.com/players/", importWeek);
            }

            // Select first all the team files
            // Name template: NF-fixturesclub3350340-S37-W10-D6.2.htm
            di = new DirectoryInfo(dirPath);

            sf.UpdateStatusMessage(0, "Loading Fixtures From the saved pages...");

            foreach (FileInfo fi in di.GetFiles("NF-fixturesclub*.2.htm*"))
            {
                StreamReader file = new StreamReader(fi.FullName);

                string fixturesPage = file.ReadToEnd();

                file.Close();

                Content content = new Content();
                content.squadDB = this.squadDB;

                string[] str = fi.FullName.Split('-');
                string dateString = str[2] + "-" + str[3] + "-" + str[4];
                int importWeek = TmWeek.SWDtoTmWeek(dateString).absweek;

                string clubId = HTML_Parser.GetNumberAfter(fi.FullName, "NF-fixturesclub");

                content.ParsePage(fixturesPage, "http://trophymanager.com/fixtures/club/" + clubId + "//", importWeek);
            }

            // Select the matches files
            // Name template: NF-matches79252194-S37-W10-D6.2.htm
            di = new DirectoryInfo(dirPath);

            sf.UpdateStatusMessage(0, "Loading Matches From the saved pages...");

            foreach (FileInfo fi in di.GetFiles("NF-matches*.2.htm*"))
            {
                StreamReader file = new StreamReader(fi.FullName);

                string matchPage = file.ReadToEnd();

                file.Close();

                Content content = new Content();
                content.squadDB = this.squadDB;

                string[] str = fi.FullName.Split('-');
                string dateString = str[2] + "-" + str[3] + "-" + str[4];
                int importWeek = TmWeek.SWDtoTmWeek(dateString).absweek;

                string matchId = HTML_Parser.GetNumberAfter(fi.FullName, "NF-matches");

                content.ParsePage(matchPage, "http://trophymanager.com/matches/" + matchId + "//", importWeek);
            }

            Invalidate();
        }
    }

    public class TeamList: Dictionary<int, string>
    {
        public KeyValuePair<int, string> FindValue(string name)
        {
            if (!this.ContainsValue(name))
                return new KeyValuePair<int,string>(-1, "");

            foreach(var squad in this)
            {
                if (squad.Value == name)
                    return squad;
            }

            return new KeyValuePair<int, string>(-1, "");
        }
    }

    public class PlayerData 
    {
        private NTR_SquadDb.HistDataRow thisWeek;
        private NTR_SquadDb.HistDataRow prevWeek;
        public NTR_SquadDb DB { get; }

        private bool isAttsComputed = false;
        private bool isSumComputed = false;
        private bool isDirty = false;

        private void dirt()
        {
            isSumComputed = false;
            isAttsComputed = false;
        }

        public int Number { get; set; }
        public string Name { get; set; }
        public string NameEx 
        { 
            get
            {
                return Name + "|" + Inj + "|" + Ban;
            }
        }
        public int Week { get; set; }
        public string SWeek { get { return (new TmSWD(Week)).ToString(); } }
        public intvar ASI { get; set; }
        public int wBorn { get; set; }
        public int FPn { get; set; }
        public string Nationality { get; set; }
        public int playerID { get; set; }

        public string Age
        {
            get
            {
                TmWeek tmw = new TmWeek(wBorn);
                return tmw.ToAge(DateTime.Now);
            }
        }

        private NTR_GainFunction GFun = new NTR_RusCheratte_Function();

        public decvar[] Skills = new decvar[14];

        public enum eSkill
        {
            Str = (int)0,
            Pac = (int)1,
            Sta = (int)2,

            Mar = (int)3,
            Tac = (int)4,
            Wor = (int)5,
            Pos = (int)6,
            Pas = (int)7,
            Cro = (int)8,
            Tec = (int)9,
            Hea = (int)10,
            Fin = (int)11,
            Lon = (int)12,
            Set = (int)13,
        }

        public decvar Str { get { return Skills[(int)eSkill.Str]; } set { Skills[(int)eSkill.Str] = value; dirt(); } }
        public decvar Pac { get { return Skills[1]; } set { Skills[1] = value; dirt(); } }
        public decvar Sta { get { return Skills[2]; } set { Skills[2] = value; dirt(); } }

        public decvar Mar { get { return Skills[3]; } set { Skills[3] = value; dirt(); } }
        public decvar Tac { get { return Skills[4]; } set { Skills[4] = value; dirt(); } }
        public decvar Wor { get { return Skills[5]; } set { Skills[5] = value; dirt(); } }
        public decvar Pos { get { return Skills[6]; } set { Skills[6] = value; dirt(); } }
        public decvar Pas { get { return Skills[7]; } set { Skills[7] = value; dirt(); } }
        public decvar Cro { get { return Skills[8]; } set { Skills[8] = value; dirt(); } }
        public decvar Tec { get { return Skills[9]; } set { Skills[9] = value; dirt(); } }
        public decvar Hea { get { return Skills[10]; } set { Skills[10] = value; dirt(); } }
        public decvar Fin { get { return Skills[11]; } set { Skills[11] = value; dirt(); } }
        public decvar Lon { get { return Skills[12]; } set { Skills[12] = value; dirt(); } }
        public decvar Set { get { return Skills[13]; } set { Skills[13] = value; dirt(); } }

        public decvar Han { get { return Skills[3]; } set { Skills[3] = value; dirt(); } }
        public decvar One { get { return Skills[4]; } set { Skills[4] = value; dirt(); } }
        public decvar Ref { get { return Skills[5]; } set { Skills[5] = value; dirt(); } }
        public decvar Ari { get { return Skills[6]; } set { Skills[6] = value; dirt(); } }
        public decvar Jum { get { return Skills[7]; } set { Skills[7] = value; dirt(); } }
        public decvar Com { get { return Skills[8]; } set { Skills[8] = value; dirt(); } }
        public decvar Kic { get { return Skills[9]; } set { Skills[9] = value; dirt(); } }
        public decvar Thr { get { return Skills[10]; } set { Skills[10] = value; dirt(); } }

        private decvar _SkillSum;
        public decvar SkillSum
        {
            get
            {
                if (!isSumComputed)
                {
                    if (FPn == 0)
                        _SkillSum = Str + Pac + Sta + Mar + Tac + Wor + Pos + Pas + Cro + Tec + Hea;
                    else
                        _SkillSum = Str + Pac + Sta + Mar + Tac + Wor + Pos + Pas + Cro + Tec + Hea + Fin + Lon + Set;
                    isSumComputed = true;
                }
                return _SkillSum;
            }
        }

        public decimal SSD
        {
            get
            {
                if (ASI == null)
                    return 0;
                return Tm_Utility.ASItoSkSum((decimal)ASI.actual, FPn == 0) - this.SkillSum.actual;
            }
        }

        public decimal Rou { get; set; }
        public decimal CStr { get; set; }
        public decimal Ada { get; set; }
        public bool BTeam 
        { 
            get
            {
                try
                {
                    return thisWeek.PlayerRow.BTeam;
                }
                catch (Exception)
                {
                    thisWeek.PlayerRow.BTeam = false;
                    return false;
                }
            }
            set
            {
                thisWeek.PlayerRow.BTeam = value;
            }
        }


        private decimal[] _Atts = new decimal[14];

        public decimal[] Atts
        {
            get
            {
                if (!isAttsComputed)
                {
                    if (Skills[0] != null)
                    {
                        _Atts = this.GFun.GetAttitude(Skills, FPn, Rou, Ada);
                        isAttsComputed = true;
                    }
                }
                return _Atts;
            }
        }
        
        public enum eAttitude
        {
            DC = (int)0,
            DR = (int)1,
            DL = (int)2,
            DMC = (int)3,
            DMR = (int)4,
            DML = (int)5,
            MC = (int)6,
            MR = (int)7,
            ML = (int)8,
            OMC = (int)9,
            OMR = (int)10,
            OML = (int)11,
            FC = (int)12,
            GK = (int)0,
        }

        public decimal GK { get { return Atts[(int)eAttitude.GK]; } }
        public decimal DC { get { return Atts[(int)eAttitude.DC]; } }
        public decimal DR { get { return Atts[(int)eAttitude.DR]; } }
        public decimal DL { get { return Atts[(int)eAttitude.DL]; } }
        public decimal DMC { get { return Atts[(int)eAttitude.DMC]; } }
        public decimal DMR { get { return Atts[(int)eAttitude.DMR]; } }
        public decimal DML { get { return Atts[(int)eAttitude.DML]; } }
        public decimal MC { get { return Atts[(int)eAttitude.MC]; } }
        public decimal MR { get { return Atts[(int)eAttitude.MR]; } }
        public decimal ML { get { return Atts[(int)eAttitude.ML]; } }
        public decimal OMC { get { return Atts[(int)eAttitude.OMC]; } }
        public decimal OMR { get { return Atts[(int)eAttitude.OMR]; } }
        public decimal OML { get { return Atts[(int)eAttitude.OML]; } }
        public decimal FC { get { return Atts[(int)eAttitude.FC]; } }

        public PlayerData(NTR_SquadDb.ShortlistRow sr)
        {
            playerID = sr.PlayerID;

            var pr = sr.PlayerRow;

            DB = (NTR_SquadDb)sr.Table.DataSet;
            GFun.GDS = DB.GDS;

            Name = pr.Name;

            NTR_SquadDb.HistDataRow thisWeek = null;
            NTR_SquadDb.HistDataRow prevWeek = null;
            foreach (var weekData in pr.GetHistDataRows())
            {
                if (thisWeek == null)
                {
                    thisWeek = weekData;
                    continue;
                }

                int week = weekData.Week;
                if (week > thisWeek.Week)
                {
                    prevWeek = thisWeek;
                    thisWeek = weekData;
                }
                else if ((prevWeek == null) || (week > prevWeek.Week))
                {
                    prevWeek = weekData;
                }

            }

            Week = thisWeek.Week;
            if (!thisWeek.IsInjNull())
                Inj = thisWeek.Inj;
            if (!thisWeek.IsBanNull())
                Ban = thisWeek.Ban;

            if (!pr.IsNoNull())
                Number = pr.No;
            FPn = pr.FPn;
            wBorn = pr.wBorn;

            if (!pr.IswBloomDataNull())
                wBloomData = pr.wBloomData;

            Nationality = pr.Nationality;

            NTR_SquadDb.TempDataRow tdr = DB.TempData.FindByPlayerID(thisWeek.PlayerID);

            if (tdr != null)
            {
                if (!tdr.IsRouNull())
                    Rou = tdr.Rou;

                if (!tdr.IsNoteNull())
                    Note = tdr.Note;
                else
                    Note = "";

                if (!tdr.IsWageNull())
                {
                    Wage = tdr.Wage;
                }
                else
                {
                    Wage = (int)(((double)thisWeek.ASI) * 24.795);
                }
            }

            if (prevWeek != null)
            {
                ASI = new intvar(thisWeek.ASI, prevWeek.ASI);
                try
                {
                    if (!thisWeek.Is_TINull() && !prevWeek.Is_TINull())
                        TI = new intvar((int)(thisWeek._TI), (int)(prevWeek._TI));
                    else if (!thisWeek.Is_TINull() && prevWeek.Is_TINull())
                        TI = new intvar((int)(thisWeek._TI), 0);
                    else
                        TI = new intvar(0, 0);
                }
                catch
                {
                    TI = new intvar(0, 0);
                }
                Str = new decvar(thisWeek.For, prevWeek.For, 10 * DB.GDS.K_FPn_Max((int)eSkill.Str, FPn));
                Pac = new decvar(thisWeek.Vel, prevWeek.Vel, 10 * DB.GDS.K_FPn_Max((int)eSkill.Pac, FPn));
                Sta = new decvar(thisWeek.Res, prevWeek.Res, 10 * DB.GDS.K_FPn_Max((int)eSkill.Sta, FPn));

                Mar = new decvar(thisWeek.Mar, prevWeek.Mar, 10 * DB.GDS.K_FPn_Max((int)eSkill.Mar, FPn));
                Tac = new decvar(thisWeek.Con, prevWeek.Con, 10 * DB.GDS.K_FPn_Max((int)eSkill.Tac, FPn));
                Wor = new decvar(thisWeek.Wor, prevWeek.Wor, 10 * DB.GDS.K_FPn_Max((int)eSkill.Wor, FPn));
                Pos = new decvar(thisWeek.Pos, prevWeek.Pos, 10 * DB.GDS.K_FPn_Max((int)eSkill.Pos, FPn));
                Pas = new decvar(thisWeek.Pas, prevWeek.Pas, 10 * DB.GDS.K_FPn_Max((int)eSkill.Pas, FPn));
                Cro = new decvar(thisWeek.Cro, prevWeek.Cro, 10 * DB.GDS.K_FPn_Max((int)eSkill.Cro, FPn));
                Tec = new decvar(thisWeek.Tec, prevWeek.Tec, 10 * DB.GDS.K_FPn_Max((int)eSkill.Tec, FPn));
                Hea = new decvar(thisWeek.Tes, prevWeek.Tes, 10 * DB.GDS.K_FPn_Max((int)eSkill.Hea, FPn));
                if (FPn != 0)
                {
                    Fin = new decvar(thisWeek.Fin, prevWeek.Fin, 10 * DB.GDS.K_FPn_Max((int)eSkill.Fin, FPn));
                    Lon = new decvar(thisWeek.Dis, prevWeek.Dis, 10 * DB.GDS.K_FPn_Max((int)eSkill.Lon, FPn));
                    Set = new decvar(thisWeek.Cal, prevWeek.Cal, 10 * DB.GDS.K_FPn_Max((int)eSkill.Set, FPn));
                }
            }
            else
            {
                ASI = new intvar(thisWeek.ASI);
                if (thisWeek.Is_TINull())
                    TI = new intvar(0, 0);
                else try
                {
                    TI = new intvar((int)(thisWeek._TI), int.MinValue);
                }
                catch
                {
                    TI = new intvar(0, 0);
                }
                Str = new decvar(thisWeek.For, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Str, FPn));
                Pac = new decvar(thisWeek.Vel, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Pac, FPn));
                Sta = new decvar(thisWeek.Res, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Sta, FPn));

                Mar = new decvar(thisWeek.Mar, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Mar, FPn));
                Tac = new decvar(thisWeek.Con, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Tac, FPn));
                Wor = new decvar(thisWeek.Wor, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Wor, FPn));
                Pos = new decvar(thisWeek.Pos, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Pos, FPn));
                Pas = new decvar(thisWeek.Pas, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Pas, FPn));
                Cro = new decvar(thisWeek.Cro, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Cro, FPn));
                Tec = new decvar(thisWeek.Tec, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Tec, FPn));
                Hea = new decvar(thisWeek.Tes, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Hea, FPn));
                if (FPn != 0)
                {
                    Fin = new decvar(thisWeek.Fin, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Fin, FPn));
                    Lon = new decvar(thisWeek.Dis, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Lon, FPn));
                    Set = new decvar(thisWeek.Cal, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Set, FPn));
                }
            }

            decimal kRou = (decimal)DB.GDS.funRou.Value((float)Rou);

            if (FPn != 0)
                CStr = (decimal)MaxAttsToStar(MaxAtts() / 5M / kRou * ((SkillSum.actual + SSD) / SkillSum.actual));
            else
                CStr = (decimal)MaxAttsToStar(GK / 5M / kRou * ((SkillSum.actual + SSD) / SkillSum.actual));

            if (!tdr.IsRecNull())
                Rec = tdr.Rec / 2.0M;

            NTR_SquadDb.ShortlistRow shr = DB.Shortlist.FindByPlayerID(playerID);
            AlarmSet = false;
            if (!shr.IsAlarmTimeNull())
                AlarmSet = true;
            if (!shr.IsBidNull())
                BidValue = shr.Bid / 1e6M;
            if (!shr.IsTimeExpireNull())
                BidEnd = shr.TimeExpire;
        }

        public PlayerData(NTR_SquadDb.HistDataRow thisWeek, int absPrevWeek)
        {
            // TODO: Complete member initialization
            this.thisWeek = thisWeek;

            DB = (NTR_SquadDb)thisWeek.Table.DataSet;
            GFun.GDS = DB.GDS;

            playerID = thisWeek.PlayerID;

            if (absPrevWeek != -1)
            {
                NTR_SquadDb.HistDataDataTable histTable = (NTR_SquadDb.HistDataDataTable)thisWeek.Table;
                prevWeek = histTable.FindByPlayerIDWeek(thisWeek.PlayerID, absPrevWeek);
            }
            else
                prevWeek = null;

            FillWithWeeks(thisWeek, prevWeek);
        }

        public PlayerData(NTR_SquadDb.HistDataRow thisWeek, NTR_SquadDb.HistDataRow prevWeek)
        {
            // TODO: Complete member initialization
            this.thisWeek = thisWeek;

            DB = (NTR_SquadDb)thisWeek.Table.DataSet;
            GFun.GDS = DB.GDS;

            playerID = thisWeek.PlayerID;

            FillWithWeeks(thisWeek, prevWeek);
        }

        public PlayerData(ExtTMDataSet.GiocatoriNSkillRow thisWeek, 
                          ExtTMDataSet[] lastTwoWeeks, 
                          GainDS GDS, 
                          ExtraDS.GiocatoriRow gr,
                          List<NTR_SquadDb.PlayerPerfRow> pprList)
        {
            Name = thisWeek.Nome;
            Week = TmWeek.thisWeek().absweek;
            GFun.GDS = GDS;

            FPn = thisWeek.FPn;
            wBorn = thisWeek.wBorn;

            Inj = (short)thisWeek.Infortunato;
            Ban = (short)thisWeek.Squalificato;
            
            Number = thisWeek.Numero;

            Nationality = thisWeek.Nationality;

            playerID = thisWeek.PlayerID;

            #region Rating management
            var ratings = (from c in pprList
                           where c.PlayerID == playerID && !c.IsVoteNull()
                           select c).ToArray();
            Color deadGreen = Color.FromArgb(214, 235, 214);
            if (ratings.Length > 0)
            {
                int count = ratings.Count();
                float sum = 0;
                float sum2 = 0;

                if (count > 1)
                {
                    for (int i = 0; i < count; i++)
                    {
                        float vote = ratings[i].Vote;
                        sum += vote;
                        sum2 += vote * vote;
                    }

                    float average = sum / count;
                    float std = (sum2 - sum * sum / count) / count;
                    AvRat = new FormattedString(string.Format("{0:0.00}", average));
                    AvRat.ToolTip = string.Format("{0} matches, Std = {1}", count, std);
                    AvRat.backColor = deadGreen;
                    if (count < 3)
                        AvRat.fontColor = Color.DarkCyan;
                    else if (count < 10)
                        AvRat.fontColor = Color.DarkGreen;
                    else if (count < 20)
                        AvRat.fontColor = Color.Navy;
                    else
                        AvRat.fontColor = Color.DarkViolet;
                }
                else
                {
                    float average = ratings[0].Vote;
                    AvRat = new FormattedString(string.Format("{0:0.00}", average));
                    AvRat.ToolTip = "Just 1 match";
                    AvRat.fontColor = Color.DarkCyan;
                    AvRat.backColor = deadGreen;
                }
            }
            else
            {
                AvRat = new FormattedString("-");
                AvRat.ToolTip = "No matches played";
                AvRat.backColor = deadGreen;
            }
            #endregion

            ExtTMDataSet.GiocatoriNSkillRow prevWeek = null;
            if (lastTwoWeeks[1] != null)
                prevWeek = lastTwoWeeks[1].GiocatoriNSkill.FindByPlayerID(playerID);

            Rou = thisWeek.Rou;
            Wage = thisWeek.Wage;
            TeamSq = thisWeek.Team;

            if (prevWeek != null)
            {
                ASI = new intvar(thisWeek.ASI, prevWeek.ASI);
                try
                {
                    if (!thisWeek.IsTINull() && !prevWeek.IsTINull())
                        TI = new intvar((int)(thisWeek.TI), (int)(prevWeek.TI));
                    else if (!thisWeek.IsTINull() && prevWeek.IsTINull())
                        TI = new intvar((int)(thisWeek.TI), 0);
                    else
                        TI = new intvar(0, 0);
                }
                catch
                {
                    TI = new intvar(0, 0);
                }
                Str = new decvar(thisWeek.For, prevWeek.For, 10 * GDS.K_FPn_Max((int)eSkill.Str, FPn));
                Pac = new decvar(thisWeek.Vel, prevWeek.Vel, 10 * GDS.K_FPn_Max((int)eSkill.Pac, FPn));
                Sta = new decvar(thisWeek.Res, prevWeek.Res, 10 * GDS.K_FPn_Max((int)eSkill.Sta, FPn));

                Mar = new decvar(thisWeek.Mar, prevWeek.Mar, 10 * GDS.K_FPn_Max((int)eSkill.Mar, FPn));
                Tac = new decvar(thisWeek.Con, prevWeek.Con, 10 * GDS.K_FPn_Max((int)eSkill.Tac, FPn));
                Wor = new decvar(thisWeek.Wor, prevWeek.Wor, 10 * GDS.K_FPn_Max((int)eSkill.Wor, FPn));
                Pos = new decvar(thisWeek.Pos, prevWeek.Pos, 10 * GDS.K_FPn_Max((int)eSkill.Pos, FPn));
                Pas = new decvar(thisWeek.Pas, prevWeek.Pas, 10 * GDS.K_FPn_Max((int)eSkill.Pas, FPn));
                Cro = new decvar(thisWeek.Cro, prevWeek.Cro, 10 * GDS.K_FPn_Max((int)eSkill.Cro, FPn));
                Tec = new decvar(thisWeek.Tec, prevWeek.Tec, 10 * GDS.K_FPn_Max((int)eSkill.Tec, FPn));
                Hea = new decvar(thisWeek.Tes, prevWeek.Tes, 10 * GDS.K_FPn_Max((int)eSkill.Hea, FPn));
                if (FPn != 0)
                {
                    Fin = new decvar(thisWeek.Fin, prevWeek.Fin, 10 * GDS.K_FPn_Max((int)eSkill.Fin, FPn));
                    Lon = new decvar(thisWeek.Lon, prevWeek.Lon, 10 * GDS.K_FPn_Max((int)eSkill.Lon, FPn));
                    Set = new decvar(thisWeek.Set, prevWeek.Set, 10 * GDS.K_FPn_Max((int)eSkill.Set, FPn));
                }
            }
            else
            {
                ASI = new intvar(thisWeek.ASI);

                if (!thisWeek.IsTINull())
                    TI = new intvar((int)(thisWeek.TI), int.MinValue);
                else
                    TI = new intvar(0, 0);

                Str = new decvar(thisWeek.For, decimal.MinValue, 10 * GDS.K_FPn_Max((int)eSkill.Str, FPn));
                Pac = new decvar(thisWeek.Vel, decimal.MinValue, 10 * GDS.K_FPn_Max((int)eSkill.Pac, FPn));
                Sta = new decvar(thisWeek.Res, decimal.MinValue, 10 * GDS.K_FPn_Max((int)eSkill.Sta, FPn));

                Mar = new decvar(thisWeek.Mar, decimal.MinValue, 10 * GDS.K_FPn_Max((int)eSkill.Mar, FPn));
                Tac = new decvar(thisWeek.Con, decimal.MinValue, 10 * GDS.K_FPn_Max((int)eSkill.Tac, FPn));
                Wor = new decvar(thisWeek.Wor, decimal.MinValue, 10 * GDS.K_FPn_Max((int)eSkill.Wor, FPn));
                Pos = new decvar(thisWeek.Pos, decimal.MinValue, 10 * GDS.K_FPn_Max((int)eSkill.Pos, FPn));
                Pas = new decvar(thisWeek.Pas, decimal.MinValue, 10 * GDS.K_FPn_Max((int)eSkill.Pas, FPn));
                Cro = new decvar(thisWeek.Cro, decimal.MinValue, 10 * GDS.K_FPn_Max((int)eSkill.Cro, FPn));
                Tec = new decvar(thisWeek.Tec, decimal.MinValue, 10 * GDS.K_FPn_Max((int)eSkill.Tec, FPn));
                Hea = new decvar(thisWeek.Tes, decimal.MinValue, 10 * GDS.K_FPn_Max((int)eSkill.Hea, FPn));
                if (FPn != 0)
                {
                    Fin = new decvar(thisWeek.Fin, decimal.MinValue, 10 * GDS.K_FPn_Max((int)eSkill.Fin, FPn));
                    Lon = new decvar(thisWeek.Lon, decimal.MinValue, 10 * GDS.K_FPn_Max((int)eSkill.Lon, FPn));
                    Set = new decvar(thisWeek.Set, decimal.MinValue, 10 * GDS.K_FPn_Max((int)eSkill.Set, FPn));
                }
            }

            decimal kRou = (decimal)GDS.funRou.Value((float)Rou);

            if (FPn != 0)
                CStr = (decimal)MaxAttsToStar(MaxAtts() / 5M / kRou * ((SkillSum.actual + SSD) / SkillSum.actual));
            else
                CStr = (decimal)MaxAttsToStar(GK / 5M / kRou * ((SkillSum.actual + SSD) / SkillSum.actual));

            if ((FPn != 0) || (!gr.IsAdaNull()))
                Ada = gr.Ada;

            Rec = thisWeek.Rec;
            OSi = GFun.GetOSi(thisWeek.Atts, thisWeek.Skills);

            if (!gr.IswBloomDataNull())
            {
                wBloomData = gr.wBloomData;
            }

            this.AvTI = gr.AvTI();
            this.Votes = gr.ScoutVoto;

            if (!thisWeek.IsHidSkNull()) this.HidSk = thisWeek.HidSk;

            if (!gr.IsProfessionalismNull()) this.Professionalism = gr.Professionalism;
            if (!gr.IsAggressivityNull()) this.Aggressivity = gr.Aggressivity;
            if (!gr.IsInjPronNull()) this.InjPron = gr.InjPron;
            if (!gr.IsLeadershipNull()) this.Leadership = gr.Leadership;
            if (!gr.IsPotentialNull()) this.Potential = gr.Potential;
        }

        public void FillWithWeeks(NTR_SquadDb.HistDataRow thisWeek, NTR_SquadDb.HistDataRow prevWeek)
        { 
            Name = thisWeek.PlayerRow.Name;
            Week = thisWeek.Week;

            if (!thisWeek.IsInjNull())
                Inj = thisWeek.Inj;
            if (!thisWeek.IsBanNull())
                Ban = thisWeek.Ban;
            if (!thisWeek.PlayerRow.IsNoNull())
                Number = thisWeek.PlayerRow.No;

            FPn = thisWeek.PlayerRow.FPn;
            wBorn = thisWeek.PlayerRow.wBorn;

            if (!thisWeek.PlayerRow.IswBloomDataNull())
                wBloomData = thisWeek.PlayerRow.wBloomData;

            Nationality = thisWeek.PlayerRow.Nationality;            

            NTR_SquadDb.TempDataRow tdr = DB.TempData.FindByPlayerID(thisWeek.PlayerID);

            if (tdr != null)
            {
                if(!tdr.IsRouNull())
                    Rou = tdr.Rou;

                if (!tdr.IsNoteNull())
                    Note = tdr.Note;
                else
                    Note = "";

                if (!tdr.IsWageNull())
                {
                    Wage = tdr.Wage;
                }
                else
                {
                    Wage = (int)(((double)thisWeek.ASI) * 24.795);
                }
            }

            if (prevWeek != null)
            {
                ASI = new intvar(thisWeek.ASI, prevWeek.ASI);
                try
                {
                    if (!thisWeek.Is_TINull() && !prevWeek.Is_TINull()) 
                        TI = new intvar((int)(thisWeek._TI), (int)(prevWeek._TI));
                    else if (!thisWeek.Is_TINull() && prevWeek.Is_TINull())
                        TI = new intvar((int)(thisWeek._TI), 0);
                    else
                        TI = new intvar(0, 0);
                }
                catch
                {
                    TI = new intvar(0, 0);
                }
                Str = new decvar(thisWeek.For, prevWeek.For, 10 * DB.GDS.K_FPn_Max((int)eSkill.Str, FPn));
                Pac = new decvar(thisWeek.Vel, prevWeek.Vel, 10 * DB.GDS.K_FPn_Max((int)eSkill.Pac, FPn));
                Sta = new decvar(thisWeek.Res, prevWeek.Res, 10 * DB.GDS.K_FPn_Max((int)eSkill.Sta, FPn));

                Mar = new decvar(thisWeek.Mar, prevWeek.Mar, 10 * DB.GDS.K_FPn_Max((int)eSkill.Mar, FPn));
                Tac = new decvar(thisWeek.Con, prevWeek.Con, 10 * DB.GDS.K_FPn_Max((int)eSkill.Tac, FPn));
                Wor = new decvar(thisWeek.Wor, prevWeek.Wor, 10 * DB.GDS.K_FPn_Max((int)eSkill.Wor, FPn));
                Pos = new decvar(thisWeek.Pos, prevWeek.Pos, 10 * DB.GDS.K_FPn_Max((int)eSkill.Pos, FPn));
                Pas = new decvar(thisWeek.Pas, prevWeek.Pas, 10 * DB.GDS.K_FPn_Max((int)eSkill.Pas, FPn));
                Cro = new decvar(thisWeek.Cro, prevWeek.Cro, 10 * DB.GDS.K_FPn_Max((int)eSkill.Cro, FPn));
                Tec = new decvar(thisWeek.Tec, prevWeek.Tec, 10 * DB.GDS.K_FPn_Max((int)eSkill.Tec, FPn));
                Hea = new decvar(thisWeek.Tes, prevWeek.Tes, 10 * DB.GDS.K_FPn_Max((int)eSkill.Hea, FPn));
                if (FPn != 0)
                {
                    Fin = new decvar(thisWeek.Fin, prevWeek.Fin, 10 * DB.GDS.K_FPn_Max((int)eSkill.Fin, FPn));
                    Lon = new decvar(thisWeek.Dis, prevWeek.Dis, 10 * DB.GDS.K_FPn_Max((int)eSkill.Lon, FPn));
                    Set = new decvar(thisWeek.Cal, prevWeek.Cal, 10 * DB.GDS.K_FPn_Max((int)eSkill.Set, FPn));
                }
            }
            else
            {
                ASI = new intvar(thisWeek.ASI);
                
                if (!thisWeek.Is_TINull())
                    TI = new intvar((int)(thisWeek._TI), int.MinValue);
                else
                    TI = new intvar(0, 0);

                Str = new decvar(thisWeek.For, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Str, FPn));
                Pac = new decvar(thisWeek.Vel, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Pac, FPn));
                Sta = new decvar(thisWeek.Res, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Sta, FPn));

                Mar = new decvar(thisWeek.Mar, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Mar, FPn));
                Tac = new decvar(thisWeek.Con, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Tac, FPn));
                Wor = new decvar(thisWeek.Wor, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Wor, FPn));
                Pos = new decvar(thisWeek.Pos, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Pos, FPn));
                Pas = new decvar(thisWeek.Pas, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Pas, FPn));
                Cro = new decvar(thisWeek.Cro, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Cro, FPn));
                Tec = new decvar(thisWeek.Tec, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Tec, FPn));
                Hea = new decvar(thisWeek.Tes, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Hea, FPn));
                if (FPn != 0)
                {
                    Fin = new decvar(thisWeek.Fin, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Fin, FPn));
                    Lon = new decvar(thisWeek.Dis, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Lon, FPn));
                    Set = new decvar(thisWeek.Cal, decimal.MinValue, 10 * DB.GDS.K_FPn_Max((int)eSkill.Set, FPn));
                }
            }

            decimal kRou = (decimal)DB.GDS.funRou.Value((float)Rou);
            
            if (FPn != 0)
                CStr = (decimal)MaxAttsToStar(MaxAtts() / 5M / kRou * ((SkillSum.actual + SSD) / SkillSum.actual));
            else
                CStr = (decimal)MaxAttsToStar(GK / 5M / kRou * ((SkillSum.actual + SSD) / SkillSum.actual));

            if (!tdr.IsRecNull())
                Rec = tdr.Rec/2.0M;

            NTR_SquadDb.PlayerRow pr = DB.Player.FindByPlayerID(thisWeek.PlayerID);

            if (!pr.IsAggNull()) this.Aggressivity = pr.Agg;
            if (!pr.IsLeaNull()) this.Leadership = pr.Lea;
            if (!pr.IsProNull()) this.Professionalism = pr.Pro;
            if (!pr.IsPhyNull()) this.Physics = pr.Phy;
            if (!pr.IsTacNull()) this.Tactics = pr.Tac;
            if (!pr.IsTecNull()) this.Technics = pr.Tec;
        }



        public decimal MaxAtts()
        {
            decimal max = 0;
            max = (DL > max) ? DL : max;
            max = (DR > max) ? DR : max;
            max = (DC > max) ? DC : max;
            max = (DML > max) ? DML : max;
            max = (DMR > max) ? DMR : max;
            max = (DMC > max) ? DMC : max;
            max = (ML > max) ? ML : max;
            max = (MR > max) ? MR : max;
            max = (MC > max) ? MC : max;
            max = (OML > max) ? OML : max;
            max = (OMR > max) ? OMR : max;
            max = (OMC > max) ? OMC : max;
            max = (FC > max) ? FC : max;
            return max;
        }

        public decimal MaxAttsToStar(decimal a)
        {
            return (a - 2.0M) / 3.0M;
        }

        public short Inj { get; set; }
        public short Ban { get; set; }
        public decimal Rec { get; set; }

        public intvar TI { get; set; }
        public int Wage { get; private set; }
        public string Note { get; private set; }

        #region BloomValues

        public string wBloomData { get; private set; }

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
        public object Asi30
        {
            get
            {
                if (_asi30 == -100M)
                {
                    ParseBloomValues();
                    if (_asi30 == -100M) return null;
                }
                return _asi30;
            }
            set
            {
                if (value == null) return;
                _asi30 = (decimal)value;
                SetBloomValues();
            }
        }

        decimal _asi25 = -100M;
        public object Asi25
        {
            get
            {
                if (_asi25 == -100M)
                {
                    ParseBloomValues();
                    if (_asi25 == -100M) return null;
                }
                return _asi25;
            }
            set
            {
                if (value == null) return;
                _asi25 = (decimal)value;
                SetBloomValues();
            }
        }

        public bool isBloomDataDirty { get; set; }
        public bool AlarmSet { get; private set; }

        private object _bidValue = null;
        public object BidValue
        {
            get { return _bidValue; }
            set { _bidValue = value; }
        }
        public object _bidEnd = null;

        public object BidEnd
        {
            get
            {
                return _bidEnd;
            }
            set
            {
                _bidEnd = value;
            }
        }

        public FormattedString AvRat { get; set; }
        public object Aggressivity { get; set; }
        public object Professionalism { get; set; }
        public object Leadership { get; set; }
        public object Physics { get; set; }
        public object Technics { get; set; }
        public object Tactics { get; set; }
        public string Speciality { get; private set; }
        public object Potential { get; private set; }
        public bool HiddenRevealed { get; private set; }
        public string HidSk { get; private set; }
        public string TeamSq { get; private set; }
        public decimal OSi { get; private set; }

        public int Blooming
        {
            get
            {
                return 0;
            }
        }

        public decimal InjPron { get; private set; }
        public float AvTI { get; private set; }
        public string Votes { get; private set; }

        private void ParseBloomValues()
        {
            if (wBloomData == null) return;
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

        public void ParseReviewsToSpecialities(ReportParser reportParser)
        {
            float Tec = 0; float f_Tec = 0;
            float Tac = 0; float f_Tac = 0;
            float Pro = 0; float f_Pro = 0;
            float Lea = 0; float f_Lea = 0;
            float Agg = 0; float f_Agg = 0;
            float Phy = 0; float f_Phy = 0;
            float Pot = 0; float f_Pot = 0;

            var Scouts = DB.Scout;
            var playerData = DB.Player.FindByPlayerID(playerID);
            NTR_SquadDb.ScoutReviewRow[] Reviews = playerData.GetScoutReviewRows();

            // Reset professionality
            for (int i = 0; i < Reviews.Length; i++)
            {
                string review = Reviews[i].Review.Replace(":", "=");
                Dictionary<string, string> dict = HTML_Parser.CreateDictionary(review, ',');

                var sr = (from c in Scouts where c.ScoutID == Reviews[i].ScoutID select c).First();

                if (sr == null)
                {
                    sr = Scouts.NewScoutRow();
                    sr.Tec = 5;
                    sr.Tac = 5;
                    sr.Psy = 5;
                    sr.Phy = 5;
                    sr.Dev = 5;
                    sr.Sen = 5;
                    sr.Name = "Scout " + i.ToString();
                }

                if (dict.ContainsKey("Tec"))
                {
                    Tec += float.Parse(dict["Tec"]) * (float)sr.Tec;
                    f_Tec += (float)sr.Tec;
                }
                if (dict.ContainsKey("Pot"))
                {
                    Pot += float.Parse(dict["Pot"]) * (float)sr.Dev;
                    f_Pot += (float)sr.Dev;
                }
                if (dict.ContainsKey("Tac"))
                {
                    Tac += float.Parse(dict["Tac"]) * (float)sr.Tac;
                    f_Tac += (float)sr.Tac;
                }
                if (dict.ContainsKey("Pro"))
                {
                    Pro += float.Parse(dict["Pro"]) * (float)sr.Psy;
                    f_Pro += (float)sr.Psy;
                }
                if (dict.ContainsKey("Lea"))
                {
                    Lea += float.Parse(dict["Lea"]) * (float)sr.Psy;
                    f_Lea += (float)sr.Psy;
                }
                if (dict.ContainsKey("Agg"))
                {
                    Agg += float.Parse(dict["Agg"]) * (float)sr.Psy;
                    f_Agg += (float)sr.Psy;
                }
                if (dict.ContainsKey("Phy"))
                {
                    Phy += float.Parse(dict["Phy"]) * (float)sr.Phy;
                    f_Phy += (float)sr.Phy;
                }
                if (dict.ContainsKey("Spe"))
                {
                    int spec = int.Parse(dict["Spe"]);
                    string skill = reportParser.Dict["Player_Skill"][spec];
                    Speciality = skill.Substring(0, 3);
                }

                //if (dict.ContainsKey("Dev")) rrow.Development = short.Parse(dict["Dev"]);
                //if (dict.ContainsKey("Blo")) rrow.Blooming = short.Parse(dict["Blo"]);
                //if (dict.ContainsKey("BlS")) rrow.BloomingStatus = short.Parse(dict["BlS"]);
                //if (dict.ContainsKey("Age")) rrow.Age = short.Parse(dict["Age"]);
                //if (dict.ContainsKey("Spe")) rrow.Speciality = short.Parse(dict["Spe"]);

            }

            if (!HiddenRevealed)
            {
                Professionalism = null;
                Aggressivity = null;
                if (f_Pro != 0) Professionalism = (Pro / f_Pro - 1) * 5;
                if (f_Agg != 0) Aggressivity = (Agg / f_Agg - 1) * 5;
            }

            Leadership = null;

            if (f_Lea != 0) Leadership = (Lea / f_Lea - 1) * 5;
            if (f_Phy != 0) Physics = (decimal)(Phy / f_Phy - 1) * 6.66M;
            if (f_Tec != 0) Technics = (decimal)(Tec / f_Tec - 1) * 6.66M;
            if (f_Tac != 0) Tactics = (decimal)(Tac / f_Tac - 1) * 6.66M;
            if (f_Pot != 0) Potential = Pot / f_Pot;

            if (Professionalism != null) playerData.Pro = (float)Professionalism;
            if (Aggressivity != null) playerData.Agg = (float)Aggressivity;
            if (Leadership != null) playerData.Lea = (float)Leadership;
            if (Physics != null) playerData.Phy = (decimal)Physics;
            if (Technics != null) playerData.Tec = (decimal)Technics;
            if (Tactics != null) playerData.Tac = (decimal)Tactics;
        }

        public void ParsePageContent(string page)
        {
            Dictionary<string, string> dictValues = HTML_Parser.CreateDictionary(page, ';');

            if (!dictValues.ContainsKey("BornWeek")) return;

            // Filling the player data
            Name = dictValues["PlayerName"];
            FPn = int.Parse(dictValues["FPn"]);
            wBorn = int.Parse(dictValues["BornWeek"]);
            Wage = int.Parse(dictValues["Wage"]);
            Rou = decimal.Parse(dictValues["Routine"]);

            if (Week != TmWeek.thisWeek().absweek)
            {
                ASI.prev = ASI.actual;
            }

            ASI.actual = int.Parse(dictValues["ASI"]);

            // Filling the DB
            NTR_SquadDb.PlayerRow pr = DB.Player.FindByPlayerID(playerID);
            pr.Name = Name;
            pr.FPn = FPn;
            pr.wBorn = wBorn;

            if (dictValues.ContainsKey("Aggressivity"))
            {
                // Hidden values are available
                Aggressivity = int.Parse(dictValues["Aggressivity"]);
                Inj = short.Parse(dictValues["InjPron"]);
                Professionalism = int.Parse(dictValues["Professionalism"]);
                Ada = int.Parse(dictValues["Ada"]);

                // Filling the DB
                pr.Agg = (float)Aggressivity;
                pr.Inj = Inj;
                pr.Pro = (float)Professionalism;
                pr.Ada = Ada;
            }

            NTR_SquadDb.HistDataRow hr = DB.HistData.FindByPlayerIDWeek(playerID, TmWeek.thisWeek().absweek);
            if (hr == null)
            {
                hr = DB.HistData.NewHistDataRow();
                hr.PlayerID = playerID;
                hr.Week = TmWeek.thisWeek().absweek;
                DB.HistData.AddHistDataRow(hr);
            }

            hr.ASI = int.Parse(dictValues["ASI"]);

            hr.For = decimal.Parse(dictValues["Str"]);
            hr.Pas = decimal.Parse(dictValues["Pas"]);
            hr.Res = decimal.Parse(dictValues["Sta"]);
            hr.Cro = decimal.Parse(dictValues["Cro"]);
            hr.Vel = decimal.Parse(dictValues["Vel"]);
            hr.Tec = decimal.Parse(dictValues["Tec"]);
            hr.Mar = decimal.Parse(dictValues["Mar"]);
            hr.Tes = decimal.Parse(dictValues["Hea"]);
            hr.Wor = decimal.Parse(dictValues["Wor"]);
            hr.Dis = decimal.Parse(dictValues["Lon"]);
            hr.Pos = decimal.Parse(dictValues["Pos"]);
            hr.Cal = decimal.Parse(dictValues["Set"]);

            var phr = DB.HistData.FindByPlayerIDWeek(playerID, TmWeek.thisWeek().absweek - 1);
            if (phr != null)
            {
                var weight = 48717927500;
                if (pr.FPn == 0)
                    weight = 263533760000;

                // Compute TI
                hr.TI = Math.Round((decimal)(Math.Pow(2, Math.Log(weight * hr.ASI) / Math.Log(Math.Pow(2, 7))) - Math.Pow(2, Math.Log(weight * phr.ASI) / Math.Log(Math.Pow(2, 7))))*10M);
            }

            NTR_SquadDb.TempDataRow tr = DB.TempData.FindByPlayerID(playerID);
            if (tr == null)
            {
                tr = DB.TempData.NewTempDataRow();
                tr.PlayerID = playerID;
                DB.TempData.AddTempDataRow(tr);
            }

            tr.Wage = Wage;
            tr.Rou = Rou;

            string[] scoutNamesArray = dictValues["ScoutName"].Split('|');
            string[] scoutDatesArray = dictValues["ScoutDate"].Split('|');
            string[] scoutVotesArray = dictValues["ScoutVoto"].Split('|');
            string[] scoutReviewsArray = dictValues["ScoutGiudizio"].Split('|');

            if ((scoutNamesArray.Length == 1) && (scoutNamesArray[0] == ""))
                return;

            for (int i = 0; i < scoutNamesArray.Length; i++)
            {
                string scoutName = scoutNamesArray[i];
                DateTime reviewDate = TmWeek.SWDtoDateTime(scoutDatesArray[i]);

                NTR_SquadDb.ScoutRow sr = (from c in DB.Scout where c.Name == scoutName select c).First();

                if (sr == null)
                {
                    sr = DB.Scout.NewScoutRow();
                    sr.Name = scoutName;
                    DB.Scout.AddScoutRow(sr);
                }

                NTR_SquadDb.ScoutReviewRow srr = DB.ScoutReview.FindByPlayerIDScoutIDDate(playerID, sr.ScoutID, reviewDate);

                if (srr == null)
                {
                    srr = DB.ScoutReview.NewScoutReviewRow();
                    srr.PlayerID = playerID;
                    srr.ScoutID = sr.ScoutID;
                    srr.Date = reviewDate;
                    DB.ScoutReview.AddScoutReviewRow(srr);
                }

                srr.Review = scoutReviewsArray[i];
                srr.Vote = int.Parse(scoutVotesArray[i]);
            }
        }

        public void FillScoutsInfo(string content)
        {
            Dictionary<string, string> dictValues = HTML_Parser.CreateDictionary(content, ';');

            string scoutsInfo = dictValues["ScoutInfo"].Replace(":", "=");
            if (scoutsInfo.Length == 0) return;

            string[] scouts = scoutsInfo.Split('|');

            Dictionary<string, string> scoutInfo = new Dictionary<string, string>();
            foreach (string scout in scouts)
            {
                scoutInfo = HTML_Parser.CreateDictionary(scout, ',');

                var srScouts = (from c in DB.Scout where c.Name == scoutInfo["Name"] select c);

                NTR_SquadDb.ScoutRow sr = null;
                if (srScouts.Count() > 0)
                    sr = srScouts.First();

                if (sr == null)
                {
                    sr = DB.Scout.NewScoutRow();
                    sr.Name = scoutInfo["Name"];
                    sr.ScoutID = DB.Scout.Count;
                    DB.Scout.AddScoutRow(sr);
                }

                sr.Dev = short.Parse(scoutInfo["Dev"]);
                sr.Phy = short.Parse(scoutInfo["Phy"]);
                sr.Psy = short.Parse(scoutInfo["Psy"]);
                sr.Sen = short.Parse(scoutInfo["Sen"]);
                sr.Tac = short.Parse(scoutInfo["Tac"]);
                sr.Tec = short.Parse(scoutInfo["Tec"]);
                sr.Yth = short.Parse(scoutInfo["Yth"]);
            }
        }

        /// <summary>
        /// This function returns REREC values (3 values, rec, ratingR2 and ratingR2 modified by
        /// the routine
        /// </summary>
        /// <param name="gnsRow"></param>
        /// <returns></returns>
        public RatingR2 CalculateREREC()
        {
            decimal skillWeightSum, weight;
            decimal SI = ASI.actual;
            decimal rou = Rou;

            RatingR2 R2 = new RatingR2();

            if (FPn == 0) // The player is a GK
            {
                skillWeightSum = (decimal)(Math.Pow((double)SI, 0.143) / 0.02979);
                weight = 48717927500;
            }
            else
            {
                skillWeightSum = (decimal)(Math.Pow((double)SI, 1 / 6.99194) / 0.02336483);
                weight = 263533760000;
            }

            decimal skillSum = SkillSum.actual;

            // REREC remainder
            skillWeightSum -= skillSum;

            // RatingR2 remainder
            var remainder = Math.Round((Math.Pow(2.0, Math.Log((double)(weight * SI)) / Math.Log(Math.Pow(2, 7))) - (double)skillSum) * 10.0) / 10.0;

            int[] positionIndex = RatingR2.GetPositionIndex(FPn);

            for (int n = 0; n < 2; n++)
            {
                for (int i = 0; i <= positionIndex[n] - 2; i += 2)
                {		// TrExMaとRECのweight表のずれ修正
                    positionIndex[n]--;
                }

                for (int i = 0; i < 10; i++)
                {
                    R2.rec[i] = 0;
                    R2.ratingR[i] = 0;
                }

                for (var j = 0; j < 9; j++) // All position
                {
                    var remainderWeight = 0.0;		// REREC remainder weight sum
                    var remainderWeight2 = 0.0;		// RatingR2 remainder weight sum
                    var not20 = 0;					// 20以外のスキル数
                    if (positionIndex[n] == 9) j = 9;	// GK

                    for (var i = 0; i < 14; i++)
                    {
                        R2.rec[j] += Skills[i].actual * (decimal)RatingR2.weightR[j, i];
                        R2.ratingR[j] += Skills[i].actual * (decimal)RatingR2.weightR2[j, i];

                        if (Skills[i].actual != 20M)
                        {
                            remainderWeight += RatingR2.weightR[j, i];
                            remainderWeight2 += RatingR2.weightR2[j, i];
                            not20 += 1;
                        }
                    }

                    R2.rec[j] += (decimal)(skillWeightSum * (decimal)remainderWeight / (decimal)not20);		//REREC Score

                    if (positionIndex[n] == 9)
                        R2.rec[j] *= 1.27M;					//GK

                    R2.rec[j] = RatingR2.funFix((decimal)(((double)R2.rec[j] - RatingR2.recLast[0, j]) / RatingR2.recLast[1, j]));
                    R2.ratingR[j] += (decimal)(remainder * remainderWeight2 / not20);
                    R2.ratingR2[j] = RatingR2.funFix(R2.ratingR[j] * (1M + rou * RatingR2.rou_factor));
                    R2.ratingR[j] = RatingR2.funFix(R2.ratingR[j]);

                    if (positionIndex[n] == 9)
                        j = 9;		// Loop end
                }
            }

            R2.TransformToTMR();
            return R2;
        }

        #endregion

    }

    public class PlayerPerfData
    {
        public PlayerPerfData(NTR_SquadDb.PlayerPerfRow c)
        {
            NPos = c.NPos;
            Name = c.PlayerRow.Name;
            PlayerID = c.PlayerID;
            if (!c.PlayerRow.IsNationalityNull())
                Nationality = c.PlayerRow.Nationality;
            Position = c.Position;
            if (!c.IsVoteNull())
                Vote = c.Vote;
            if (!c.IsRecNull())
                Rec = c.Rec;
            if (!c.IsRouNull())
                Rou = c.Rou;
            if (!c.IsScoredNull())
                Scored = c.Scored;
            if (!c.IsAssistNull())
                Assist = c.Assist;
            if (!c.IsStatusNull())
                Status = c.Status;
             if (!c.PlayerRow.IsFPNull())
                FPn = c.PlayerRow.FPn;
            this.MatchData = new MatchData(c.MatchRow);
        }

        public string Name { get; set; }
        public string NameExt
        {
            get
            {
                string res = "Text=" + Name;
                if (Scored > 0)
                    res += ";Goal=" + Scored.ToString();
                if (Assist > 0)
                    res += ";Assist=" + Assist.ToString();
                if (Status.Contains("YYR<"))
                {
                    string value = HTML_Parser.GetNumberAfter(Status, "R<");
                    res += string.Format(";Yellow=1;YellowRed=1;RMin={0}", value);
                }
                else if (Status.Contains("YYR"))
                    res += ";Yellow=1;YellowRed=1";
                else if (Status.Contains("YR<"))
                {
                    string value = HTML_Parser.GetNumberAfter(Status, "R<");
                    res += string.Format(";Yellow=1;Red=1;RMin={0}", value);
                }
                else if (Status.Contains("YR"))
                    res += ";Yellow=1;Red=1";
                else if (Status.Contains("Y"))
                    res += ";Yellow=1";
                else if (Status.Contains("R<"))
                {
                    string value = HTML_Parser.GetNumberAfter(Status, "R<");
                    res += string.Format(";Red=1;RMin={0}", value);
                }
                else if (Status.Contains("R"))
                    res += ";Red=1";
                else if (Status.Contains("I"))
                    res += ";Injury=1";
                if (Status.Contains("S<"))
                {
                    string value = HTML_Parser.GetNumberAfter(Status, "S<");
                    res += string.Format(";SubOut=1;SMin={0}", value);
                }
                else if (Status.Contains("S>"))
                {
                    string value = HTML_Parser.GetNumberAfter(Status, "S>");
                    res += string.Format(";SubIn=1;SMin={0}", value);
                }
                return res;
            }
        }
        public string Position { get; set; }
        public int NPos { get; set; }
        public string Nationality { get; private set; }
        public float Vote { get; private set; }
        public decimal Rec { get; private set; }
        public string RecExt
        {
            get
            {
                return Rec.ToString("N1", CommGlobal.ciUs);
            }
        }
        public decimal Rou { get; private set; }
        public int Scored { get; private set; }
        public int Assist { get; private set; }
        public string Status { get; private set; }
        public int FPn { get; private set; }
        public int PlayerID { get; private set; }
        public MatchData MatchData { get; private set; }
    }

    public class MatchData
    {
        public MatchData(NTR_SquadDb.MatchRow mr)
        {
            Date = mr.Date.Date;

            if (!mr.IsCrowdNull()) 
                Crowd = mr.Crowd;
            if (!mr.IsCardsNull())
                Cards = mr.Cards;
            else
                Cards = "";
            if (!mr.IsBestPlayerNull())
                BestPlayer = mr.BestPlayer;
            else
                BestPlayer = 0;

            Analyzed = mr.Analyzed;

            // This operation is to recover the status before 2.10.1.1
            NTR_SquadDb.TeamRow HomeRow = mr.isHome ? mr.TeamRowByTeam_YTeam : mr.TeamRowByTeam_OTeam;
            NTR_SquadDb.TeamRow AwayRow = mr.isHome ? mr.TeamRowByTeam_OTeam : mr.TeamRowByTeam_YTeam;

            if (!HomeRow.IsOwnerNull() && (HomeRow.Owner))
                IsHome = true;
            else if (!HomeRow.IsOwnerNull() && (AwayRow.Owner))
                IsHome = false;
            else if (!HomeRow.IsImportedNull() && (HomeRow.Imported))
                IsHome = true;
            else
                IsHome = false;

            MatchID = mr.MatchID;
            MatchType = mr.MatchType;
            OTeamID = mr.OTeamID;
            Report = mr.Report;
            YTeamID = mr.YTeamID;


            if (Report)
            {
                if (!mr.IsYActionsNull())
                    YActions = mr.YActions;
                if (!mr.IsOActionsNull())
                    OActions = mr.OActions;
                if (!mr.IsAttackStylesNull())
                {
                    string[] AttackStyles = mr.AttackStyles.Split(';');
                    YAttk = AttackStyles[0];
                    OAttk = AttackStyles[1];
                    LineUps = mr.Lineups;
                    Pitch = mr.Pitch;
                    string[] Mentalities = mr.Mentalities.Split(';');
                    YMent = Mentalities[0];
                    OMent = Mentalities[1];
                }
                else
                {
                    Report = false;
                }
            }

            Score = new MatchScore(mr.Score, IsHome);

            if (mr.Analyzed == 2)
                Score.forfait = true;

            ScoreString = mr.Score;
            ScoreString.backColor = Score.ScoreColor;

            if (!mr.IsStadiumNull())
            {
                Stadium = mr.Stadium;
                if (!mr.IsStatsNull())
                    Stats = mr.Stats;
                if (!mr.IsWeatherNull())
                    Weather = mr.Weather;
            }

            Home = "";
            Away = "";

            try
            {
                if (mr.isHome)
                {
                    Home.isBold = true;
                    Away.isBold = false;
                    Home = mr.TeamRowByTeam_YTeam.Name;
                    Away = mr.TeamRowByTeam_OTeam.Name;
                    Home.tagColor = Color.FromArgb(mr.TeamRowByTeam_YTeam.IsColorNull() ? 0 : mr.TeamRowByTeam_YTeam.Color);
                    Away.tagColor = Color.FromArgb(mr.TeamRowByTeam_OTeam.IsColorNull() ? 0 : mr.TeamRowByTeam_OTeam.Color);
                }
                else
                {
                    Away.isBold = true;
                    Home.isBold = false;
                    Away = mr.TeamRowByTeam_YTeam.Name;
                    Home = mr.TeamRowByTeam_OTeam.Name;
                    Away.tagColor = Color.FromArgb(mr.TeamRowByTeam_YTeam.IsColorNull() ? 0 : mr.TeamRowByTeam_YTeam.Color);
                    Home.tagColor = Color.FromArgb(mr.TeamRowByTeam_OTeam.IsColorNull() ? 0 : mr.TeamRowByTeam_OTeam.Color);
                }
            }
            catch
            {
            }

            Away.backColor = Score.ScoreColor;
            Home.backColor = Score.ScoreColor;

            NTR_SquadDb squadDB = (NTR_SquadDb)mr.Table.DataSet;

            AllActions = (from c in squadDB.Actions
                          where c.MatchID == mr.MatchID
                          select c).OrderBy(p => p.Time);

            if (!mr.IsLastMinNull())
                LastMin = mr.LastMin;
            else
                LastMin = 90;

            if (mr.Report)
            {
                try
                {
                    if (mr.isHome)
                    {
                        HomePlayerPerf = from c in squadDB.PlayerPerf
                                         where (c.MatchID == mr.MatchID) && (c.TeamID == mr.YTeamID)
                                         select c;
                        AwayPlayerPerf = from c in squadDB.PlayerPerf
                                         where (c.MatchID == mr.MatchID) && (c.TeamID == mr.OTeamID)
                                         select c;
                    }
                    else
                    {
                        HomePlayerPerf = from c in squadDB.PlayerPerf
                                         where (c.MatchID == mr.MatchID) && (c.TeamID == mr.OTeamID)
                                         select c;
                        AwayPlayerPerf = from c in squadDB.PlayerPerf
                                         where (c.MatchID == mr.MatchID) && (c.TeamID == mr.YTeamID)
                                         select c;
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        public DateTime Date { get; set; }
        public int Crowd { get; set; }
        public string Cards { get; set; }
        public int BestPlayer { get; set; }
        public string YAttk { get; set; }
        public string OAttk { get; set; }
        public int Analyzed { get; set; }
        public bool IsHome { get; set; }
        public string LineUps { get; set; }
        public int MatchID { get; set; }
        public byte MatchType { get; set; }
        public string YMent { get; set; }
        public string OMent { get; set; }
        public int OTeamID { get; set; }
        public string Pitch { get; set; }
        public bool Report { get; set; }
        public MatchScore Score { get; set; }
        public string Stadium { get; set; }
        public string Stats { get; set; }
        public string Weather { get; set; }
        public int YTeamID { get; set; }
        public FormattedString ScoreString { get; set; }
        public FormattedString Home { get; set; }
        public FormattedString Away { get; set; }
        public string YActions { get; set; }
        public string OActions { get; set; }

        public EnumerableRowCollection<NTR_SquadDb.PlayerPerfRow> HomePlayerPerf { get; set; }
        public EnumerableRowCollection<NTR_SquadDb.PlayerPerfRow> AwayPlayerPerf { get; set; }

        public EnumerableRowCollection<NTR_SquadDb.PlayerPerfRow> YourPlayerPerf
        {
            get
            {
                return IsHome ? HomePlayerPerf : AwayPlayerPerf;
            }
        }
        public EnumerableRowCollection<NTR_SquadDb.PlayerPerfRow> OppsPlayerPerf
        {
            get
            {
                return !IsHome ? HomePlayerPerf : AwayPlayerPerf;
            }
        }

        public OrderedEnumerableRowCollection<NTR_SquadDb.ActionsRow> AllActions { get; private set; }
        public int LastMin { get; private set; }
    }

    public class FormattedString : IComparable<FormattedString>
    {
        public bool isBold;
        public string value;
        public Color backColor = Color.White;
        public Color fontColor = Color.Black;
        public Color tagColor = Color.Black;

        public string ToolTip { get; set; }

        public FormattedString(string s)
        {
            value = s;
        }

        public static implicit operator FormattedString(string s)
        {
            return new FormattedString(s);
        }

        public override string ToString()
        {
            return value;
        }

        public int CompareTo(FormattedString other)
        {
            return this.ToString().CompareTo(other.ToString());
        }
    }

    public class MatchScore
    {
        public int home;
        public int away;
        public bool valid = true;
        public bool forfait = false;

        public Color ScoreColor
        {
            get
            {
                if (forfait)
                    return Color.Beige;
                else if (!valid)
                    return Color.LightGray;
                else if (home == away)
                    return Color.FromArgb(230,230,0);
                else if ((home < away) && IsHome)
                    return Color.LightSalmon;
                else if ((home > away) && !IsHome)
                    return Color.LightSalmon;
                else
                    return Color.LightGreen;
            }
        }

        public MatchScore(string score, bool isHome)
        {
            IsHome = isHome;
            if (score == "null")
            {
                home = 0;
                away = 0;
                valid = false;
                return;
            }
            try
            {
                string[] str = score.Split('-');
                if (str.Length == 1)
                {
                    home = 0;
                    away = 0;
                    return;
                }
                int.TryParse(str[0], out home);
                int.TryParse(str[1], out away);
            }
            catch
            {
                home = 0;
                away = 0;
                valid = false;
            }
        }

        public override string ToString()
        {
            if (forfait)
                return "ff";
            if (!valid)
                return "np";
            return string.Format("{0}-{1}", home, away);
        }

        public string Inverse()
        {
            if (forfait)
                return "ff";
            if (!valid)
                return "np";

            return string.Format("{1}-{0}", home, away);
        }

        public bool IsHome { get; set; }
    }
}