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

            NTR_SquadDb.MatchRow mrRow = squadDB.Match.FindByMatchID(matchID);
            int YTeamID = mrRow.YTeamID;
            int OTeamID = mrRow.OTeamID;

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
                ScoutsNReviews.ScoutsRow ssr = scoutSkillsDS.Scouts.NewScoutsRow();
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

        public void MergeContent(Content content)
        {
            NTR_SquadDb mergeDB = content.squadDB;

            if (mergeDB == null)
            {
                MessageBox.Show("Error loading the content of the page");
                return;
            }

            squadDB.Merge(mergeDB);

            squadDB.UpdateDecimals(content);

            latestDataWeek = content.Week;

            Invalidate();
        }

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
        }

        public Dictionary<int, string> Teams { get; set; }
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

        private bool isAttsComputed = false;
        private bool isSumComputed = false;

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
                    _Atts = this.GFun.GetAttitude(Skills, FPn, Rou, Ada);
                    isAttsComputed = true;
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

        public PlayerData(NTR_SquadDb.HistDataRow thisWeek, int absPrevWeek)
        {
            // TODO: Complete member initialization
            this.thisWeek = thisWeek;

            NTR_SquadDb DB = (NTR_SquadDb)thisWeek.Table.DataSet;
            GFun.GDS = DB.GDS;

            if (absPrevWeek != -1)
            {
                NTR_SquadDb.HistDataDataTable histTable = (NTR_SquadDb.HistDataDataTable)thisWeek.Table;
                prevWeek = histTable.FindByPlayerIDWeek(thisWeek.PlayerID, absPrevWeek);
            }
            else
                prevWeek = null;

            Name = thisWeek.PlayerRow.Name;
            Week = thisWeek.Week;
            Inj = thisWeek.Inj;
            Ban = thisWeek.Ban;

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
                try
                {
                    TI = new intvar((int)(thisWeek._TI), (int)(prevWeek._TI));
                }
                catch
                {
                    TI = new intvar((int)(thisWeek._TI), 0);
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
                try
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

        public intvar TI { get; set; }
    }

    public class MatchData
    {
        public MatchData(NTR_SquadDb.MatchRow mr)
        {
            Date = mr.Date;
            Crowd = mr.Crowd;
            if (!mr.IsCardsNull())
                Cards = mr.Cards;
            else
                Cards = "";
            if (!mr.IsBestPlayerNull())
                BestPlayer = mr.BestPlayer;
            else
                BestPlayer = 0;
            AttackStyles = mr.AttackStyles;
            Analyzed = mr.Analyzed;
            IsHome = mr.isHome;
            LineUps = mr.Lineups;
            MatchID = mr.MatchID;
            MatchType = mr.MatchType;
            Mentalities = mr.Mentalities;
            OTeamID = mr.OTeamID;
            Pitch = mr.Pitch;
            Report = mr.Report;
            Score = new MatchScore(mr.Score, IsHome);
            ScoreString = mr.Score;
            ScoreString.backColor = Score.ScoreColor;
            Stadium = mr.Stadium;
            Stats = mr.Stats;
            Weather = mr.Weather;
            YTeamID = mr.YTeamID;

            if (mr.isHome)
            {
                Home = mr.TeamRowByTeam_YTeam.Name;
                Away = mr.TeamRowByTeam_OTeam.Name;
                Home.isBold = true;
                Away.isBold = false;
                Home.tagColor = Color.FromArgb(mr.TeamRowByTeam_YTeam.IsColorNull() ? 0 : mr.TeamRowByTeam_YTeam.Color);
                Away.tagColor = Color.FromArgb(mr.TeamRowByTeam_OTeam.IsColorNull() ? 0 : mr.TeamRowByTeam_OTeam.Color);
            }
            else
            {
                Away = mr.TeamRowByTeam_YTeam.Name;
                Home = mr.TeamRowByTeam_OTeam.Name;
                Away.isBold = true;
                Home.isBold = false;
                Away.tagColor = Color.FromArgb(mr.TeamRowByTeam_YTeam.IsColorNull() ? 0 : mr.TeamRowByTeam_YTeam.Color);
                Home.tagColor = Color.FromArgb(mr.TeamRowByTeam_OTeam.IsColorNull() ? 0 : mr.TeamRowByTeam_OTeam.Color);
            }

            Away.backColor = Score.ScoreColor;
            Home.backColor = Score.ScoreColor;

            NTR_SquadDb squadDB = (NTR_SquadDb)mr.Table.DataSet;

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

        public DateTime Date { get; set; }
        public int Crowd { get; set; }
        public string Cards { get; set; }
        public int BestPlayer { get; set; }
        public string AttackStyles { get; set; }
        public int Analyzed { get; set; }
        public bool IsHome { get; set; }
        public string LineUps { get; set; }
        public int MatchID { get; set; }
        public byte MatchType { get; set; }
        public string Mentalities { get; set; }
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

        public EnumerableRowCollection<NTR_SquadDb.PlayerPerfRow> HomePlayerPerf { get; set; }
        public EnumerableRowCollection<NTR_SquadDb.PlayerPerfRow> AwayPlayerPerf { get; set; }
    }

    public class FormattedString
    {
        public bool isBold;
        public string value;
        public Color backColor = Color.White;
        public Color fontColor = Color.Black;
        public Color tagColor = Color.Black;

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
    }

    public class MatchScore
    {
        public int home;
        public int away;

        public Color ScoreColor
        {
            get
            {
                if (home == away)
                    return Color.LightGray;
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

            try
            {
                string[] str = score.Split('-');
                int.TryParse(str[0], out home);
                int.TryParse(str[1], out away);
            }
            catch
            {
                home = 0;
                away = 0;
            }
        }

        public bool IsHome { get; set; }
    }
}
