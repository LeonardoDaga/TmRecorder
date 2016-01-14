using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using DataGridViewCustomColumns;
using Common;
using Languages;
using NTR_Db;
using NTR_Controls;

using mshtml;
using System.Linq;

namespace TMRecorder
{
    public partial class MainForm : Form
    {
        bool isDirty = false;
        string lastPropertySort = "";

        TeamHistory History = null;
        ReportAnalysis reportAnalysis = new ReportAnalysis();
        public TeamStats teamStats = new TeamStats();
        TrainersSkills dbTrainers = new TrainersSkills();
        // WebBrowser webBrowser = new WebBrowser();
        bool enableTracing = false;
        string urlAddress = "http://tmrecorder.insyde.it/releasesinfo.txt";
        ChampDS.MatchRow editingMatchRow = null;
        ExtraDS.GiocatoriRow editingPlayerRow = null;
        int[] dP;
        SplashForm sf = null;
        string doctext = "";
        MatchAnalysis matchAnalysisDB = new MatchAnalysis();
        bool thisIsExtraTeam = false;
        public Seasons AllSeasons = new Seasons();
        List<MatchData> SeasonMatchList = null;

        public enum e_GridTab : int
        {
            SQUAD_A = 0,
            SQUAD_B = 1,
            SQUAD_GK = 2,
            GRID_TAB_TOT_NUM = 3
        }

        bool[] gridUpdateStatus = new bool[(int)e_GridTab.GRID_TAB_TOT_NUM];

        #region DEBUGGING
        System.Diagnostics.BooleanSwitch dataSwitch =
           new System.Diagnostics.BooleanSwitch("Data", "DataAccess module");
        System.Diagnostics.TraceSwitch generalSwitch =
           new System.Diagnostics.TraceSwitch("General",
           "Entire application");
        #endregion

        public MainForm(string[] args)
        {
            if (args.Length > 0)
                thisIsExtraTeam = true;

            Program.Setts.Initialize(args);

            BrowserEmulationVersion currentEmulationVersion = InternetExplorerBrowserEmulation.GetBrowserEmulationVersion();
            if (currentEmulationVersion == BrowserEmulationVersion.Default)
                currentEmulationVersion = BrowserEmulationVersion.Version8;
            InternetExplorerBrowserEmulation.SetBrowserEmulationVersion(currentEmulationVersion);

            InitializeComponent();

            InitializeBrowser();

            InvalidateGrids();

            AllSeasons.AutoconvertActions = Program.Setts.AutoconvertActions;

            LoadLanguage();

            SetLanguage();

            #region Debugging Initialization

            if (!enableTracing) return;

            // Creates the text file that the trace listener will write to.
            System.IO.FileStream myTraceLog = new
               System.IO.FileStream("D:\\TMRecorderTraceLog.txt",
               System.IO.FileMode.OpenOrCreate);
            // Creates the new trace listener.
            System.Diagnostics.TextWriterTraceListener myListener =
               new System.Diagnostics.TextWriterTraceListener(myTraceLog);

            System.Diagnostics.Trace.Listeners.Add(myListener);
            #endregion
        }

        private void InitializeBrowser()
        {
            if (!webBrowser.CheckXulInitialization())
                Close();
        }

        private void LoadLanguage()
        {
            if (Program.Setts.Language == "en")
                Current.Language = new English();
            else if (Program.Setts.Language == "it")
                Current.Language = new Italian();
            else if (Program.Setts.Language == "fr")
                Current.Language = new French();
            else if (Program.Setts.Language == "es")
                Current.Language = new Spanish();
            else if (Program.Setts.Language == "pt")
                Current.Language = new Portuguese();
        }

        void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.ToString() != urlAddress) return;

            //ReleaseInfo = HTML_Parser.GetTag(webBrowser.DocumentText, "PRE");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bool settingsChanged = false;

            try
            {
                Rectangle pos = Program.Setts.MainFormPosition;

                if (pos.X < 0) pos.X = 0;
                if (pos.Y < 0) pos.Y = 0;
                if (pos.Width < 500) pos.Width = 1000;
                if (pos.Height < 250) pos.Height = 590;
                if (pos.Width > 2000) pos.Width = 2000;
                if (pos.Height > 2000) pos.Height = 2000;
                if (pos.Height + pos.Width > 0)
                    this.SetDesktopBounds(pos.X, pos.Y, pos.Width, pos.Height);

                dP = new int[5];

                dP[0] = dP[1] = dP[2] = dP[3] = 0;

                string info = (dP[0] + "," + dP[1] + "," + dP[2] + "," + dP[3]).ToString();

                if (Program.Setts.MatchesFileName != "MatchesHistory.3.xml")
                {
                    MessageBox.Show(this, Current.Language.ChangeNamingStandard + Program.Setts.DefaultDirectory, "TmRecorder", MessageBoxButtons.OK);

                    AsyncProgressForm apf = new AsyncProgressForm(AsyncProgressForm.ChangeFileNamesStandard);
                    apf.ShowDialog();

                    apf = new AsyncProgressForm(AsyncProgressForm.ChangeXmlFileNamesStandard);
                    apf.ShowDialog();

                    Program.Setts.MatchesFileName = "MatchesHistory.3.xml";
                    Program.Setts.Save();
                }

                dP[0] = 1;

                History = new TeamHistory();

                sf = new SplashForm("TM - Team Recorder",
                    "Release " + Application.ProductVersion,
                    "Starting Application...");

                dP[0] = 2;

                // webBrowser.Navigate(urlAddress);

                // sf.UpdateStatusMessage(1, "Getting Info from the website...");

                if (Program.Setts.MainSquadName != "")
                    Text = "Trophy Manager - " + Program.Setts.MainSquadName + " - Team Recorder v." + Application.ProductVersion;
                else
                    Text = "Trophy Manager - Team Recorder v." + Application.ProductVersion;

                if (Program.Setts.UsingStartingPathDisk)
                {
                    FileInfo fiStartup = new FileInfo(Application.StartupPath);
                    string disk = fiStartup.FullName.Split(':')[0];

                    Program.Setts.SetDisk(disk);

                    Program.Setts.Save();
                }

                dP[0] = 3;

                if (settingsChanged)
                    Program.Setts.Save();

                dP[0] = 4;

                string imagePath = Path.Combine(Program.Setts.InstallationDirectory, "splash-banners");
                DirectoryInfo di = new DirectoryInfo(imagePath);
                if (di.Exists)
                {
                    dP[1] = 1;

                    int iCnt = 0;

                    if ((iCnt = di.GetFiles("*.sps.jpg").Length) != 0)
                    {
                        dP[1] = 2;

                        Random rnd = new Random();
                        int i = rnd.Next(iCnt + 1);
                        if (i == iCnt) i = iCnt - 1;

                        FileInfo[] fi = di.GetFiles("*.sps.jpg");

                        sf.SetActualBackImage(fi[i]);
                    }
                }

                sf.Show();

                History.dbTrainers = dbTrainers;

                dP[0] = 5; dP[1] = 0;

                if (Program.Setts.InstallationDirectory == ".\\")
                    Program.Setts.InstallationDirectory = Application.StartupPath;

                if (!LoadData())
                {
                    dP[0] = 6; dP[1] = 0;
                    CollectInitialInformation();
                }

                dP[0] = 7; dP[1] = 0;

                if (Program.Setts.PlayerType == 0)
                {
                    if (MessageBox.Show(Current.Language.AreYouAPROUserYouCanChangeYourStatusInTheOptionForm,
                        Current.Language.PROTypeSelection, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        Program.Setts.PlayerType = 2;
                    else
                        Program.Setts.PlayerType = 1;
                }

                Program.Setts.Save();

                sf.Close();
                // Text = "TM Team Recorder - Release " 

                evidenceSkillsForGainsToolStripMenuItem.Checked = Program.Setts.EvidenceGain;
                evidenceSkillsForGainsMenuItem2.Checked = Program.Setts.EvidenceGain;

                if (Program.Setts.PlayerType != 2) // PRO player
                {
                    tsbImportSquad.Text = "Squad";
                    tsbMatchListA.Text = "Squad";
                    tsbMatchListB.Visible = false;
                    tsbMatchSquadA.Text = "Squad";
                    tsbMatchSquadB.Visible = false;
                }

                UpdateShownGrid();
            }
            catch (Exception ex)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";
                string info = (dP[0] + "," + dP[1] + "," + dP[2] + "," + dP[3]).ToString();

                string message = "An error occurred. Would you like to send an error report to Led Lennon?\n" +
                              "The error report will be sent using an email account created just for \n"
                             + "tmrecorder bug report on gmail.com. Add some comments if you like and PLEASE add your data\n" +
                             "(your team name or id) so that I can contact you as soon as the problem is solved.";

                SendFileTo.ErrorReport.Send(ex, info, Environment.StackTrace, swRelease);
            }
        }

        private bool LoadData()
        {
            dP[1] = 1;
            sf.UpdateStatusMessage(2, "Loading gains...");
            LoadGains();

            dP[1] = 3;
            sf.UpdateStatusMessage(5, "Loading History...");
            bool res = LoadHistory();

            dP[1] = 4;
            sf.UpdateStatusMessage(90, "Loading Matches...");
            LoadMatches(sf);

            dP[1] = 5;
            SetLastTeam();

            dP[1] = 6;
            LoadReportAnalysisSetts();

            dP[1] = 7;
            UpdateLackData();

            dP[1] = 8;
            LoadTrainers();

            dP[1] = 9;

            UpdateExtraTeamMenu();

            dP[1] = 10;

            bool showCstr = true;
            dataGridGiocatori.Columns["CStrA"].Visible = showCstr;
            dataGridGiocatoriB.Columns["CStrB"].Visible = showCstr;
            dataGridPortieri.Columns["CStrGK"].Visible = showCstr;

            History.reportParser = new ReportParser(Program.Setts.ReportParsingFile);

            return res;
        }

        private void LoadTrainers()
        {
            dbTrainers.Clear();
            FileInfo fi = new FileInfo(Path.Combine(Program.Setts.DefaultDirectory, "SquadTrainers.xml"));
            if (fi.Exists)
            {
                try
                {
                    dbTrainers.ReadXml(fi.FullName);
                }
                catch (ConstraintException)
                {
                    // MessageBox.Show("The trainer list contains some errors. It will be edited automatically to remove copy of the same trainer");
                }
            }

            for (int i = 0; i < dbTrainers.Trainers.Count; i++)
            {
                TrainersSkills.TrainersRow tr1 = dbTrainers.Trainers[i];

                for (int j = i + 1; j < dbTrainers.Trainers.Count; j++)
                {
                    TrainersSkills.TrainersRow tr2 = dbTrainers.Trainers[j];

                    if (tr1.ID == tr2.ID)
                    {
                        dbTrainers.Trainers.RemoveTrainersRow(tr2);
                        dbTrainers.isDirty = true;
                    }
                }

                if (tr1.IsinTeamNull())
                {
                    tr1.inTeam = true;
                    dbTrainers.isDirty = true;
                }
            }
        }

        private void SaveTrainers()
        {
            FileInfo fi = new FileInfo(Path.Combine(Program.Setts.DefaultDirectory, "SquadTrainers.xml"));
            dbTrainers.WriteXml(fi.FullName);
        }

        private void LoadMatches(SplashForm sf)
        {
            FileInfo fi = new FileInfo(Program.Setts.MatchAnalysisFile);
            if (fi.Exists)
                matchAnalysisDB.ReadXml(Program.Setts.MatchAnalysisFile);

            string matchFilePath = Path.Combine(Program.Setts.DefaultDirectory, Program.Setts.MatchesFileName);

            string dirPath = Program.Setts.DefaultDirectory;
            DirectoryInfo di = new DirectoryInfo(dirPath);

            if (!di.Exists)
                di.Create();

            FileInfo[] fis = di.GetFiles("*.5.xml");

            if (fis.Length > 0)
            {
                // Load the data version 5
                AllSeasons.LoadSeasonsFromVersion5(dirPath, ref sf, true);
            }
            else
            {
                // Load the data version 3
                fi = new FileInfo(matchFilePath);
                if (fi.Exists)
                {
                    string actionDecoderFilePath = Path.Combine(Program.Setts.DatafilePath, "ActionsDecoder.5.xml");
                    AllSeasons.LoadSeasonsFromVersion3(dirPath, ref sf, true);
                    AllSeasons.LoadActionDecoder5(ref sf, actionDecoderFilePath);
                }
            }

            AllSeasons.SetOwnedTeam(Program.Setts.MainSquadID, Program.Setts.MainSquadName);
            AllSeasons.SetOwnedTeam(Program.Setts.ReserveSquadID, Program.Setts.ReserveSquadName, Program.Setts.MainSquadID);

            FormatMatchesAndPerfGrid();

            FillCmbMatchesSeasons();
            FillCmbMatchesSquads();

            MatchListUpdateSeason();

            AllSeasons.IsDirty = false;
        }

        private void FillCmbMatchesSquads()
        {
            cmbSquad.Items.Clear();

            List<Team> ownedAndImportedTeams = AllSeasons.GetOwnedAndImportedTeams();

            foreach (Team team in ownedAndImportedTeams)
            {
                cmbSquad.Items.Add(team);
            }

            if (cmbSquad.Items.Count > 0)
                cmbSquad.SelectedItem = ownedAndImportedTeams[0];
        }

        private void FillCmbMatchesSeasons()
        {
            cmbSeason.Items.Clear();

            foreach (int season in AllSeasons.GetSeasonsVector())
            {
                cmbSeason.Items.Add(season);
            }

            if (cmbSeason.Items.Count == 0)
                return;

            cmbSeason.SelectedItem = TmWeek.thisSeason().Season;
        }

        private void MatchListUpdateSeason()
        {
            if (cmbSquad.SelectedItem == null)
                return;

            if (cmbSeason.SelectedItem == null)
                return;

            int season = (int)cmbSeason.SelectedItem;
            int teamId = ((Team)cmbSquad.SelectedItem).ID;
            int homeOrAway = chkHome.Checked ? 1 :
                chkAway.Checked ? 2 : 0;

            int matchType = 0;
            matchType += chkMT1.Checked ? 1 : 0;
            matchType += chkMT2.Checked ? 2 : 0;
            matchType += chkMT3.Checked ? 4 : 0;
            matchType += chkMT4.Checked ? 8 : 0;
            matchType += chkMT5.Checked ? 16 : 0;
            matchType = (matchType > 0) ? matchType : 31;

            // Initialize list with the actual season
            var tempMatchList = AllSeasons.GetSeasonMatchList(season, teamId, homeOrAway, matchType);

            SeasonMatchList = tempMatchList;

            dgMatches.DataCollection = SeasonMatchList;
        }

        private void LoadReportAnalysisSetts()
        {
            FileInfo fi = new FileInfo(Program.Setts.ReportAnalysisFile);

            reportAnalysis.Clear();
            if (fi.Exists)
                reportAnalysis.ReadXml(Program.Setts.ReportAnalysisFile);
        }

        private int LoadMatchesFromHTMLcode_NewTM(string text, bool quiet = false)
        {
            string str = "l,c,f,fl,i";
            int cnt = 0;

            //champDS.TeamID = Program.Setts.MainSquadID;
            //champDS.ReservesID = Program.Setts.ReserveSquadID;
            //cnt = champDS.LoadSeasonFile_NewTM(text, ref str, Program.Setts.DebugFunction,
            //    Program.Setts.ApplicationFolder);

            if (str == "") // Il programma si è accorto che le definizioni dei match types sono sbagliate
            {
                opzioniToolStripMenuItem1_Click(null, EventArgs.Empty);
                return cnt;
            }

            Program.Setts.MatchTypes = str;

            Program.Setts.Save();

            return cnt;
        }

        private int LoadMatchesFromHTMLcode(string text)
        {
            string str = Program.Setts.MatchTypes;
            int cnt = 0;

            if (str.Contains("\""))
            {
                str = str.Replace("\"", "");
            }

            //if (text.Contains("var week"))
            //    cnt = champDS.LoadSeasonFileFlash(text, ref str, Program.Setts.DebugFunction,
            //        Program.Setts.ApplicationFolder);
            //else
            //    champDS.LoadSeasonFileNonFlash(text, ref str);

            if (str == "") // Il programma si è accorto che le definizioni dei match types sono sbagliate
            {
                opzioniToolStripMenuItem1_Click(null, EventArgs.Empty);
                return cnt;
            }

            Program.Setts.MatchTypes = str;

            Program.Setts.Save();

            return cnt;
        }

        private void FormatMatchesAndPerfGrid()
        {
            dgMatches.AutoGenerateColumns = false;

            dgMatches.Columns.Clear();
            dgMatches.AddColumn("Date", "Date", 74, AG_Style.String);
            dgMatches.AddColumn("Home", "Home", 90, AG_Style.FormatString | AG_Style.ResizeAllCells);
            dgMatches.AddColumn("-", "ScoreString", 20, AG_Style.FormatString | AG_Style.ResizeAllCells);
            dgMatches.AddColumn("Away", "Away", 90, AG_Style.FormatString | AG_Style.ResizeAllCells);
            dgMatches.AddColumn("Type", "MatchType", 35, AG_Style.MatchType);
            dgMatches.AddColumn("Crowd", "Crowd", 55, AG_Style.Numeric);
            dgMatches.AddColumn("YMent", "YMent", 38, AG_Style.String, "Your team mentality");
            dgMatches.AddColumn("YAttk", "YAttk", 38, AG_Style.String, "Your team attacking style");
            dgMatches.AddColumn("OMent", "OMent", 38, AG_Style.String, "Opposite team mentality");
            dgMatches.AddColumn("OAttk", "OAttk", 38, AG_Style.String, "Opposite team attacking style");

            dgYourTeamPerf.AutoGenerateColumns = false;
            dgYourTeamPerf.Columns.Clear();
            dgYourTeamPerf.AddColumn("Name", "NameExt", 50, AG_Style.TextAndImage | AG_Style.ResizeAllCells);
            dgYourTeamPerf.AddColumn("Pos", "Position", 30, AG_Style.FavPosition );
            dgYourTeamPerf.AddColumn("FP", "FPn", 40, AG_Style.FavPosition, "Favoured Position");
            dgYourTeamPerf.AddColumn("Vot", "Vote", 30, AG_Style.Numeric | AG_Style.N1 );
            dgYourTeamPerf.AddColumn("Rec", "RecExt", 57, AG_Style.Stars);
            dgYourTeamPerf.AddColumn("Rou", "Rou", 30, AG_Style.Numeric | AG_Style.N1);

            dgOppsTeamPerf.AutoGenerateColumns = false;
            dgOppsTeamPerf.Columns.Clear();
            dgOppsTeamPerf.AddColumn("Name", "NameExt", 50, AG_Style.TextAndImage | AG_Style.ResizeAllCells);
            dgOppsTeamPerf.AddColumn("Pos", "Position", 30, AG_Style.FavPosition);
            dgOppsTeamPerf.AddColumn("FP", "FPn", 40, AG_Style.FavPosition, "Favoured Position");
            dgOppsTeamPerf.AddColumn("Vot", "Vote", 30, AG_Style.Numeric | AG_Style.N1);
            dgOppsTeamPerf.AddColumn("Rec", "RecExt", 57, AG_Style.Stars);
            dgOppsTeamPerf.AddColumn("Rou", "Rou", 30, AG_Style.Numeric | AG_Style.N1);
        }

        private void UpdateTeamDateList()
        {
            toolDataList.Items.Clear();
            foreach (string str in History.DataDateList())
            {
                toolDataList.Items.Add(str);
            }

            toolDataList.SelectedIndex = History.IndexOf(History.actualDts);
        }

        private void salvaTeamData_Click(object sender, EventArgs e)
        {
            History.Save(Program.Setts.DefaultDirectory);
            isDirty = false;

            if (AllSeasons.IsDirty)
            {
                AllSeasons.Save(Program.Setts.DefaultDirectory);
                //string matchFilePath = Path.Combine(Program.Setts.DefaultDirectory, Program.Setts.MatchesFileName);
                //champDS.WriteXml(matchFilePath);
                AllSeasons.IsDirty = false;
            }

            History.teamDS.Save(Program.Setts.DefaultDirectory, "Shortlist.3.xml");

            SaveTrainers();
        }

        private void salvaConNomeComeXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "TM_" + DateTime.Now.Year.ToString() +
                DateTime.Now.DayOfYear.ToString() + ".xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                db_TrophyDataSet.WriteXml(saveFileDialog.FileName);
        }

        private void caricaFileSquadraDaXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "TM_*.xml";
            openFileDialog.Filter = "XML file|*.xml|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                db_TrophyDataSet.ReadXml(openFileDialog.FileName);
            }

            //dataGridGiocatori.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dataGridPortieri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void CollectInitialInformation()
        {
            StartInfoBox sib = new StartInfoBox();

            sib.DataDirectory = Program.Setts.DefaultDirectory;
            sib.DefaultNation = Program.Setts.HomeNation;
            sib.UsedLanguage = Program.Setts.Language;

            dP[1]++;
            dP[2] = 0;

            if (sib.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo di = new DirectoryInfo(sib.DataDirectory);

                dP[2]++;
                if (di.Exists)
                {
                    if (Program.Setts.DefaultDirectory != di.FullName)
                    {
                        dP[3]++;
                        if (MessageBox.Show(Current.Language.ReloadSquadDataFromTheSelectedDirectory,
                            Current.Language.ChangedDefaultDirectory,
                            MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            dP[3]++;
                            Program.Setts.DefaultDirectory = di.FullName;
                            //reg.SetValue("Settings", "DefaultDirectory", di.FullName);
                            History.Clear();
                            if (History.PlayersDS != null) History.PlayersDS.Clear();
                            dP[3]++;
                            LoadData();
                        }
                    }
                }
                else // di not exists
                {
                    di.Create();
                    Program.Setts.DefaultDirectory = di.FullName;
                    History.Clear();
                    if (History.PlayersDS != null) History.PlayersDS.Clear();
                }

                dP[2]++;
                dP[3] = 0;
                Program.Setts.HomeNation = sib.DefaultNation;

                if (Program.Setts.Language != sib.UsedLanguage)
                {
                    Program.Setts.Language = sib.UsedLanguage;
                    LoadLanguage();
                    MessageBox.Show("You must restart TmRecorder to change the language");
                }

                isDirty = true;
                Program.Setts.Save();
            }
        }

        private void opzioniToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dP[1] = 0;
            OptionsForm of = new OptionsForm();

            of.DataDirectory = Program.Setts.DefaultDirectory;
            of.InstallationDirectory = Program.Setts.InstallationDirectory;
            of.DefaultNation = Program.Setts.HomeNation;
            of.NormalizeGains = Program.Setts.NormalizeGains;
            of.GainSet = Program.Setts.GainSet;
            of.ReportParsingFile = Program.Setts.ReportParsingFile;
            dP[1]++;
            of.optionsReportAnalysis.CopyReportAnalysis(this.reportAnalysis);
            of.UseTMRBrowser = Program.Setts.UseTMRBrowser;
            of.MainSquadName = Program.Setts.MainSquadName;
            of.MainSquadID = Program.Setts.MainSquadID;
            of.ReserveSquadName = Program.Setts.ReserveSquadName;
            of.ReserveSquadID = Program.Setts.ReserveSquadID;
            of.PlayerType = Program.Setts.PlayerType;
            of.ActionAnalysisFile = Program.Setts.ActionAnalysisFile;
            of.EvidenceGains = Program.Setts.EvidenceGain;
            of.UseStartupDisk = Program.Setts.UsingStartingPathDisk;
            of.UseOldHTMLImportStyle = Program.Setts.UseOldHTMLImportStyle;
            of.RoutineFunction = Program.Setts.RouFunction;
            of.RoutineParameters = Program.Setts.RouParams;
            of.UsedLanguage = Program.Setts.Language;
            of.ShowMatchOptions = Program.Setts.TeamMatchesShowMatches;
            of.MatchAnalysisFile = Program.Setts.MatchAnalysisFile;

            dP[1]++;
            dP[2] = 0;
            of.dbTrainers.Trainers.Clear();
            foreach (TrainersSkills.TrainersRow sr in dbTrainers.Trainers)
            {
                dP[2]++;
                TrainersSkills.TrainersRow isr = of.dbTrainers.Trainers.NewTrainersRow();
                isr.ItemArray = sr.ItemArray;
                of.dbTrainers.Trainers.AddTrainersRow(isr);
            }
            of.dbTrainers.isDirty = false;

            dP[1]++;
            dP[2] = 0;
            of.extraDS.Scouts.Clear();
            if (History.PlayersDS != null)
            {
                foreach (ExtraDS.ScoutsRow sr in History.PlayersDS.Scouts)
                {
                    dP[2]++;
                    ExtraDS.ScoutsRow isr = of.extraDS.Scouts.NewScoutsRow();
                    isr.ItemArray = sr.ItemArray;
                    of.extraDS.Scouts.AddScoutsRow(isr);
                }
            }

            dP[1]++;
            dP[2] = 0;
            dP[3] = 0;
            if (of.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo di = new DirectoryInfo(of.DataDirectory);

                dP[2]++;
                if (di.Exists)
                {
                    if (Program.Setts.DefaultDirectory != di.FullName)
                    {
                        dP[3]++;
                        if (MessageBox.Show(Current.Language.ReloadSquadDataFromTheSelectedDirectory,
                            Current.Language.ChangedDefaultDirectory,
                            MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            dP[3]++;
                            Program.Setts.DefaultDirectory = di.FullName;
                            //reg.SetValue("Settings", "DefaultDirectory", di.FullName);
                            History.Clear();
                            if (History.PlayersDS != null) History.PlayersDS.Clear();
                            dP[3]++;
                            LoadData();
                        }
                    }
                }
                else // di not exists
                {
                    di.Create();
                    Program.Setts.DefaultDirectory = di.FullName;
                    History.Clear();
                    if (History.PlayersDS != null) History.PlayersDS.Clear();
                }

                dP[2]++;
                dP[3] = 0;
                di = new DirectoryInfo(of.InstallationDirectory);
                if (Program.Setts.InstallationDirectory != di.FullName)
                {
                    Program.Setts.InstallationDirectory = di.FullName;
                    //reg.SetValue("Settings", "InstallationDirectory", di.FullName);
                }

                dP[2]++;
                reportAnalysis.CopyReportAnalysis(of.optionsReportAnalysis);
                if (of.optionsReportAnalysis.Changed)
                {
                    reportAnalysis.WriteXml(Program.Setts.ReportAnalysisFile);
                }
                reportAnalysis.Changed = false;

                dP[2]++;
                Program.Setts.HomeNation = of.DefaultNation;
                Program.Setts.UseTMRBrowser = of.UseTMRBrowser;
                Program.Setts.MainSquadName = of.MainSquadName;
                Program.Setts.MainSquadID = of.MainSquadID;
                Program.Setts.ReserveSquadName = of.ReserveSquadName;
                Program.Setts.ReserveSquadID = of.ReserveSquadID;
                Program.Setts.PlayerType = of.PlayerType;
                Program.Setts.EvidenceGain = of.EvidenceGains;
                Program.Setts.TeamMatchesShowMatches = of.ShowMatchOptions;
                EvidenceSkillsGiocatoriForGains();
                EvidenceSkillsPortieriForGains();
                evidenceSkillsForGainsToolStripMenuItem.Checked = Program.Setts.EvidenceGain;
                evidenceSkillsForGainsMenuItem2.Checked = Program.Setts.EvidenceGain;

                Program.Setts.UsingStartingPathDisk = of.UseStartupDisk;
                Program.Setts.UseOldHTMLImportStyle = of.UseOldHTMLImportStyle;
                Program.Setts.MatchAnalysisFile = of.MatchAnalysisFile;

                FileInfo fi = new FileInfo(Program.Setts.MatchAnalysisFile);
                if (fi.Exists)
                {
                    matchAnalysisDB.Clear();
                    matchAnalysisDB.ReadXml(Program.Setts.MatchAnalysisFile);
                }

                if (Program.Setts.Language != of.UsedLanguage)
                {
                    Program.Setts.Language = of.UsedLanguage;
                    LoadLanguage();
                    MessageBox.Show("You must restart TmRecorder to change the language");
                }

                dP[2]++;
                Program.Setts.RouFunction = of.RoutineFunction;
                Program.Setts.RouParams = of.RoutineParameters;
                History.GD.funRou = new Common.Function(Program.Setts.RouFunction, Program.Setts.RouParams);

                if (History.actualDts != null)
                    History.actualDts.RecalculateSpecData(History.PFun);

                dP[2]++;
                EvidenceSkillsGiocatoriForQuality();

                dP[2]++;
                if ((Program.Setts.NormalizeGains != of.NormalizeGains) ||
                    (Program.Setts.GainSet != of.GainSet))
                {
                    Program.Setts.NormalizeGains = of.NormalizeGains;
                    Program.Setts.GainSet = of.GainSet;
                    History.Clear();
                    LoadData();
                }

                if (Program.Setts.ReportParsingFile != of.ReportParsingFile)
                {
                    History.reportParser = new ReportParser(of.ReportParsingFile);
                    Program.Setts.ReportParsingFile = of.ReportParsingFile;
                }

                dP[2]++;
                if (Program.Setts.ActionAnalysisFile != of.ActionAnalysisFile)
                {
                    Program.Setts.ActionAnalysisFile = of.ActionAnalysisFile;
                    actionAnalysis.ReadXml(Path.Combine(Program.Setts.DefaultDirectory, Program.Setts.ActionAnalysisFile));
                }

                dP[2]++;
                try
                {
                    if (History.PlayersDS != null) History.PlayersDS.Scouts.Clear();
                    extraDS.Scouts.Clear();
                    foreach (ExtraDS.ScoutsRow sr in of.extraDS.Scouts)
                    {
                        if (History.PlayersDS == null) History.PlayersDS = new ExtraDS();
                        ExtraDS.ScoutsRow isr = History.PlayersDS.Scouts.NewScoutsRow();
                        isr.ItemArray = sr.ItemArray;
                        History.PlayersDS.Scouts.AddScoutsRow(isr);
                        ExtraDS.ScoutsRow nisr = extraDS.Scouts.NewScoutsRow();
                        nisr.ItemArray = sr.ItemArray;
                        extraDS.Scouts.AddScoutsRow(nisr);
                    }
                }
                catch (Exception)
                {
                }

                dP[2]++;
                if (of.dbTrainers.isDirty)
                {
                    dbTrainers.Trainers.Clear();
                    foreach (TrainersSkills.TrainersRow sr in of.dbTrainers.Trainers)
                    {
                        TrainersSkills.TrainersRow isr = dbTrainers.Trainers.NewTrainersRow();
                        isr.ItemArray = sr.ItemArray;
                        dbTrainers.Trainers.AddTrainersRow(isr);
                    }

                    dbTrainers.isDirty = true;
                }

                dP[2]++;
                isDirty = true;
                Program.Setts.Save();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Rectangle pos = new Rectangle(DesktopBounds.X, DesktopBounds.Y, DesktopBounds.Width, DesktopBounds.Height);
            Program.Setts.MainFormPosition = pos;
            Program.Setts.Save();

            if (isDirty)
            {
                DialogResult res = MessageBox.Show(Current.Language.SaveDataBeforeExit, "Team Recorder", MessageBoxButtons.YesNoCancel);

                if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }

                if (res == DialogResult.Yes)
                {
                    SaveHistory();
                }
            }

            if (dbTrainers.isDirty)
            {
                SaveTrainers();
            }

            if (AllSeasons.IsDirty)
            {
                DialogResult res = MessageBox.Show(Current.Language.SaveMatchesDataBeforeExit, "Team Recorder", MessageBoxButtons.YesNo);

                if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }

                if (res == DialogResult.Yes)
                {
                    AllSeasons.Save(Program.Setts.DefaultDirectory);
                    AllSeasons.IsDirty = false;
                }
            }
        }

        private void LoadGains()
        {
            if (History.LoadGains(Program.Setts.GainSet))
            {
                Program.Setts.GainSet = History.GD.GainDSfilename;
                Program.Setts.Save();
            }
            else
            {
                DirectoryInfo di = new DirectoryInfo(Program.Setts.DatafilePath);

                FileInfo fi = new FileInfo(Path.Combine(di.FullName, "Default.tmgain.xml"));
                if (fi.Exists)
                {
                    Program.Setts.GainSet = fi.FullName;
                    Program.Setts.Save();
                }
            }
        }

        private bool LoadHistory()
        {
            bool res = History.Load(Program.Setts.DefaultDirectory, ref sf);

            History.teamDS.Load(Program.Setts.DefaultDirectory, "Shortlist.3.xml");

            if (History.PlayersDS == null) return res;

            History.FillTeamStats(ref teamStats);

            extraDS.Scouts.Clear();
            foreach (ExtraDS.ScoutsRow isr in History.PlayersDS.Scouts)
            {
                ExtraDS.ScoutsRow nisr = extraDS.Scouts.NewScoutsRow();
                nisr.ItemArray = isr.ItemArray;
                extraDS.Scouts.AddScoutsRow(nisr);
            }

            History.ComputeStats();

            return res;
        }

        private void RecalcHistory()
        {
            History.RecalcDataFromGains();
        }

        private void SetLastTeam()
        {
            History.actualDts = History.LastTeam();

            if (History.actualDts == null)
            {
                dataGridGiocatori.DataSource = null;
                dataGridGiocatoriB.DataSource = null;
                dataGridPortieri.DataSource = null;
                dataGridPlayersInfo.DataSource = null;
            }
            else
            {
                dataGridGiocatori.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'A' AND FPn > 0");
                dataGridGiocatoriB.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'B' AND FPn > 0");
                dataGridPortieri.DataSource = History.actualDts.GiocatoriNSkill.Select("FPn = 0");
                ShowActualPlayers(History.actualDts.Date);
                dataGridPlayersInfo.DataSource = extraDS.Giocatori;
            }

            UpdateTeamDateList();
        }

        private void SaveHistory()
        {
            History.Save(Program.Setts.DefaultDirectory);
            isDirty = false;

            History.teamDS.Save(Program.Setts.DefaultDirectory, "Shortlist.3.xml");
        }

        private void toolDataList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Parse((string)toolDataList.SelectedItem);
            History.actualDts = History.DSfromDate(dt);

            if (History.actualDts == null) return;

            dataGridGiocatori.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'A' AND FPn > 0");
            dataGridGiocatoriB.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'B' AND FPn > 0");
            dataGridPortieri.DataSource = History.actualDts.GiocatoriNSkill.Select("FPn = 0");

            if (toolDataList.SelectedIndex == 0) return;

            InvalidateGrids();

            UpdateShownGrid();

            ShowActualPlayers(dt);

            dataGridPlayersInfo.DataSource = extraDS.Giocatori;
        }

        private void InvalidateGrids()
        {
            InvalidateGrids(null);
        }

        private void InvalidateGrids(object sender)
        {
            if (sender == null)
            {
                gridUpdateStatus[(int)e_GridTab.SQUAD_A] = false;
                gridUpdateStatus[(int)e_GridTab.SQUAD_B] = false;
                gridUpdateStatus[(int)e_GridTab.SQUAD_GK] = false;
            }
            if (sender == dataGridGiocatori)
                gridUpdateStatus[(int)e_GridTab.SQUAD_A] = false;
            if (sender == dataGridGiocatoriB)
                gridUpdateStatus[(int)e_GridTab.SQUAD_B] = false;
            if (sender == dataGridPortieri)
                gridUpdateStatus[(int)e_GridTab.SQUAD_GK] = false;
        }

        private void ShowActualPlayers(DateTime dt)
        {
            dataGridGiocatori.SetWhen(dt);
            dataGridGiocatoriB.SetWhen(dt);
            dataGridPortieri.SetWhen(dt);
            dataGridPlayersInfo.SetWhen(dt);
            History.FillActualPlayersList(extraDS, dt);
        }

        private void EvidenceSkillsGiocatoriForQuality()
        {
            EvidenceSkillsGiocatoriForQuality(dataGridGiocatori, -1);
            EvidenceSkillsGiocatoriForQuality(dataGridGiocatoriB, -1);
        }

        private void EvidenceSkillsPlayerForQuality(int ID,
            bool isYoung, bool isGK)
        {
            if (isGK)
                EvidenceSkillsPortieriForQuality(ID);
            else if (!isYoung)
                EvidenceSkillsGiocatoriForQuality(dataGridGiocatori, ID);
            else
                EvidenceSkillsGiocatoriForQuality(dataGridGiocatoriB, ID);
        }

        private void EvidenceSkillsGiocatoriForQuality(DataGridView dgv, int plID)
        {
            EvidenceSkillsGiocatoriForGains(dgv);

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (plID != -1)
                {
                    System.Windows.Forms.DataGridViewRow dvr = dgv.Rows[i];
                    ExtTMDataSet.GiocatoriNSkillRow gsr = (ExtTMDataSet.GiocatoriNSkillRow)dvr.DataBoundItem;

                    if (plID != gsr.PlayerID)
                        continue;
                }

                // Evidenzia solo le colonne degli skills
                for (int j = 26; j < 40; j++)
                {
                    object o = dgv[j, i].Value;

                    float f = 0f;
                    if (o.GetType() == typeof(float))
                        f = (float)o;
                    else if (o.GetType() == typeof(decimal))
                        f = (float)(decimal)o;

                    if (f > 100) f = 100;
                    if (f < 0) f = 0;

                    DataGridViewCellStyle Style = new DataGridViewCellStyle();

                    SelectStyleColor(f, Style);
                    // Style.Format = "N0";
                    // Style.Font = new Font("Arial Narrow", 8);

                    dgv[j, i].Style = Style;
                    // dgv.Columns[j].Width = 24;
                }

                if (plID != -1)
                    return;
            }
        }

        private void EvidenceSkillsPortieri()
        {
            EvidenceSkillsPortieriForQuality(-1);
            EvidenceSkillsPortieriForGains();
        }

        private void EvidenceSkillsGiocatori(DataGridView dgGiocatori)
        {
            EvidenceSkillsGiocatoriForQuality(dgGiocatori, -1);
            EvidenceSkillsGiocatoriForGains(dgGiocatori);
        }

        private void EvidenceSkillsPortieriForQuality(int plID)
        {
            for (int i = 0; i < dataGridPortieri.Rows.Count; i++)
            {
                if (plID != -1)
                {
                    DataGridViewRow dvr = dataGridPortieri.Rows[i];
                    ExtTMDataSet.GiocatoriNSkillRow gsr = (ExtTMDataSet.GiocatoriNSkillRow)dvr.DataBoundItem;

                    if (plID != gsr.PlayerID)
                        continue;
                }

                // Evidenzia solo le colonne degli skills
                for (int j = 21; j < 23; j++)
                {
                    float f = (float)dataGridPortieri[j, i].Value;
                    if (f > 100) f = 100;
                    if (f < 0) f = 0;

                    DataGridViewCellStyle Style = new DataGridViewCellStyle();

                    SelectStyleColor(f, Style);

                    dataGridPortieri[j, i].Style = Style;
                }

                if (plID != -1)
                    return;
            }
        }

        private static void SelectStyleColor(float f, DataGridViewCellStyle Style)
        {
            Style.SelectionForeColor = Style.ForeColor = Common.Utility.GradeColor(f);
        }

        private void EvidenceSkillsGiocatoriForGains()
        {
            EvidenceSkillsGiocatoriForGains(dataGridGiocatori);
            EvidenceSkillsGiocatoriForGains(dataGridGiocatoriB);
        }

        float[] ComputeGains(string fp)
        {
            string FP = TM_Compatible.ConvertNewFP(fp);

            string[] spec = new string[] { "DC", "DR", "DL", "DMC", "DMR",
                    "DML", "MC", "MR", "ML", "OMC", "OMR", "OML", "FC" };

            string[] FPs = FP.Split('/');

            float[] gains = new float[14];

            if (FPs.Length == 1)
            {
                int n;
                for (n = 0; n < 13; n++)
                    if (FP == spec[n]) break;

                // Evidenzia solo le colonne degli skills
                for (int j = 0; j < 14; j++)
                {
                    DataGridViewCellStyle Style = new DataGridViewCellStyle();

                    gains[j] = History.GD.K_FP(j, n);
                }
            }
            else
            {
                int n1, n2;
                for (n1 = 0; n1 < 13; n1++)
                    if (FPs[0] == spec[n1]) break;
                for (n2 = 0; n2 < 13; n2++)
                    if (FPs[1] == spec[n2]) break;
                string FP1 = FPs[0];
                string FP2 = FPs[1];

                // Evidenzia solo le colonne degli skills
                for (int j = 0; j < 14; j++)
                {
                    DataGridViewCellStyle Style = new DataGridViewCellStyle();

                    gains[j] = Math.Max(History.GD.K_FP(j, n1), History.GD.K_FP(j, n2));
                }
            }

            return gains;
        }

        private void EvidenceSkillsGiocatoriForGains(DataGridView dgv)
        {
            if (!Program.Setts.EvidenceGain)
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < 14; j++)
                    {
                        dgv[j + 8, i].Style = dgv[j + 8, i].OwningColumn.DefaultCellStyle;
                    }
                }
                return;
            }

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                System.Windows.Forms.DataGridViewRow dvr = dgv.Rows[i];
                ExtTMDataSet.GiocatoriNSkillRow gsr = (ExtTMDataSet.GiocatoriNSkillRow)dvr.DataBoundItem;

                float[] gains = ComputeGains(gsr.FP);

                for (int j = 0; j < 14; j++)
                {
                    DataGridViewCellStyle Style = new DataGridViewCellStyle();

                    ColorUtilities.SelectGainColor(gains[j], ref Style);

                    dgv[j + 8, i].Style = Style;
                }
            }
        }

        private void EvidenceSkillsPortieriForGains()
        {
            if (!Program.Setts.EvidenceGain)
            {
                for (int i = 0; i < dataGridPortieri.Rows.Count; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        dataGridPortieri[j + 6, i].Style = dataGridPortieri[j + 6, i].OwningColumn.DefaultCellStyle;
                    }
                }
                return;
            }


            for (int i = 0; i < dataGridPortieri.Rows.Count; i++)
            {
                // Evidenzia solo le colonne degli skills
                for (int j = 0; j < 11; j++)
                {
                    DataGridViewCellStyle Style = new DataGridViewCellStyle();

                    ColorUtilities.SelectGainColor(History.GD.K_GK(j) / 1.5f, ref Style);

                    dataGridPortieri[j + 6, i].Style = Style;
                }
            }
        }

        /// <summary>
        /// Evidence the difference of the skills respect to the last week
        /// </summary>
        private void FillForDifferencePortieri()
        {
            if (toolDataList.SelectedItem == null) return;

            DateTime dt = DateTime.Parse((string)toolDataList.SelectedItem);

            if (History.Count < 2) return;

            for (int i = 0; i < dataGridPortieri.Rows.Count; i++)
            {
                int ID = (int)dataGridPortieri[0, i].Value;

                ExtTMDataSet.PlayerHistoryDataTable table = History.GetPlayerHistory(ID);

                // Find the index corresponding to datetime
                int ix = 0;
                for (; ix < table.Rows.Count; ix++)
                {
                    ExtTMDataSet.PlayerHistoryRow gk = (ExtTMDataSet.PlayerHistoryRow)table.Rows[ix];
                    if (gk.Date.Date == dt) break;
                }

                TmWeek tmwActual = new TmWeek(dt);

                if (ix == table.Rows.Count) continue;
                if (ix == 0) continue;

                int ixlast = ix;
                for (; ixlast >= 0; ixlast--)
                {
                    ExtTMDataSet.PlayerHistoryRow gk = (ExtTMDataSet.PlayerHistoryRow)table.Rows[ixlast];
                    TmWeek tmwLast = new TmWeek(gk.Date);
                    if (tmwLast.absweek < tmwActual.absweek) break;
                }

                if (ixlast < 0) continue;

                ExtTMDataSet.PlayerHistoryRow actual = (ExtTMDataSet.PlayerHistoryRow)table.Rows[ix];
                ExtTMDataSet.PlayerHistoryRow last = (ExtTMDataSet.PlayerHistoryRow)table.Rows[ixlast];

                EvidenceDiffForColumn(dataGridPortieri, actual.ASI, last.ASI, i, 5);
                EvidenceDiffForColumn(dataGridPortieri, actual.For, last.For, i, 6);
                EvidenceDiffForColumn(dataGridPortieri, actual.Res, last.Res, i, 7);
                EvidenceDiffForColumn(dataGridPortieri, actual.Vel, last.Vel, i, 8);
                EvidenceDiffForColumn(dataGridPortieri, actual.Pre, last.Pre, i, 9);
                EvidenceDiffForColumn(dataGridPortieri, actual.Uno, last.Uno, i, 10);
                EvidenceDiffForColumn(dataGridPortieri, actual.Rif, last.Rif, i, 11);
                EvidenceDiffForColumn(dataGridPortieri, actual.Aer, last.Aer, i, 12);
                EvidenceDiffForColumn(dataGridPortieri, actual.Ele, last.Ele, i, 13);
                EvidenceDiffForColumn(dataGridPortieri, actual.Com, last.Com, i, 14);
                EvidenceDiffForColumn(dataGridPortieri, actual.Tir, last.Tir, i, 15);
            }
        }

        private SkillVariation CalcForDifference()
        {
            SkillVariation sv = new SkillVariation();
            sv += CalcForDifferenceGiocatori(dataGridGiocatori);
            sv += CalcForDifferenceGiocatori(dataGridGiocatoriB);
            sv += CalcForDifferencePortieri();
            return sv;
        }

        private SkillVariation CalcForDifferenceGiocatori(DataGridView dgv)
        {
            SkillVariation sv = new SkillVariation();

            if (toolDataList.SelectedItem == null) return sv;

            DateTime dt = DateTime.Parse((string)toolDataList.SelectedItem);

            if (History.Count < 2) return sv;

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                int ID = 0;

                try
                {
                    ID = (int)dgv[0, i].Value;
                }
                catch (System.Reflection.TargetInvocationException)
                {
                    continue;
                }

                ExtTMDataSet.PlayerHistoryDataTable table = History.GetPlayerHistory(ID);

                // Find the index corresponding to datetime
                int ix = 0;
                for (; ix < table.Rows.Count; ix++)
                {
                    ExtTMDataSet.PlayerHistoryRow pl = (ExtTMDataSet.PlayerHistoryRow)table.Rows[ix];
                    if (pl.Date == dt) break;
                }

                if (ix == table.Rows.Count) continue;
                if (ix == 0) continue;

                ExtTMDataSet.PlayerHistoryRow actual = (ExtTMDataSet.PlayerHistoryRow)table.Rows[ix];
                ExtTMDataSet.PlayerHistoryRow last = (ExtTMDataSet.PlayerHistoryRow)table.Rows[ix - 1];

                sv += SkillVariation.Calc(actual, last);

                sv.totCount++;
            }

            return sv;
        }

        private SkillVariation CalcForDifferencePortieri()
        {
            SkillVariation sv = new SkillVariation();

            if (toolDataList.SelectedItem == null) return sv;

            DateTime dt = DateTime.Parse((string)toolDataList.SelectedItem);

            if (History.Count < 2) return sv;

            for (int i = 0; i < dataGridPortieri.Rows.Count; i++)
            {
                int ID = (int)dataGridPortieri[0, i].Value;

                ExtTMDataSet.PlayerHistoryDataTable table = History.GetPlayerHistory(ID);

                // Find the index corresponding to datetime
                int ix = 0;
                for (; ix < table.Rows.Count; ix++)
                {
                    ExtTMDataSet.PlayerHistoryRow gk = (ExtTMDataSet.PlayerHistoryRow)table.Rows[ix];
                    if (gk.Date == dt) break;
                }

                if (ix == table.Rows.Count) continue;
                if (ix == 0) continue;

                ExtTMDataSet.PlayerHistoryRow actual = (ExtTMDataSet.PlayerHistoryRow)table.Rows[ix];
                ExtTMDataSet.PlayerHistoryRow last = (ExtTMDataSet.PlayerHistoryRow)table.Rows[ix - 1];

                sv += SkillVariation.Calc(actual, last);

                sv.totCount++;
            }

            return sv;
        }

        private void FillForDifferenceGiocatori()
        {
            FillForDifferenceGiocatori(dataGridGiocatori);
            FillForDifferenceGiocatori(dataGridGiocatoriB);
        }

        private void FillForDifferenceGiocatori(DataGridView dgv)
        {
            if (toolDataList.SelectedItem == null) return;

            DateTime dt = DateTime.Parse((string)toolDataList.SelectedItem);

            if (History.Count < 2) return;

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                int ID = 0;

                try
                {
                    ID = (int)dgv[0, i].Value;
                }
                catch (System.Reflection.TargetInvocationException)
                {
                    continue;
                }

                ExtTMDataSet.PlayerHistoryDataTable table = History.GetPlayerHistory(ID);

                // Find the index corresponding to datetime
                int ix = 0;
                for (; ix < table.Rows.Count; ix++)
                {
                    ExtTMDataSet.PlayerHistoryRow pl = (ExtTMDataSet.PlayerHistoryRow)table.Rows[ix];
                    if (pl.Date.Date == dt) break;
                }

                TmWeek tmwActual = new TmWeek(dt);

                //if (ix == table.Rows.Count) continue;
                if (ix == 0) continue;

                ExtTMDataSet.PlayerHistoryRow actual = (ExtTMDataSet.PlayerHistoryRow)table.Rows[ix];
                    if (actual.IsFinNull()) continue;

                int ixlast = ix;
                for (; ixlast >= 0; ixlast--)
                {
                    ExtTMDataSet.PlayerHistoryRow pl = (ExtTMDataSet.PlayerHistoryRow)table.Rows[ixlast];
                    TmWeek tmwLast = new TmWeek(pl.Date);
                    if (tmwLast.absweek < tmwActual.absweek) break;
                }

                if (ixlast < 0) continue;

                ExtTMDataSet.PlayerHistoryRow last = (ExtTMDataSet.PlayerHistoryRow)table.Rows[ixlast];

                EvidenceDiffForColumn(dgv, actual.ASI, last.ASI, i, 6);
                EvidenceDiffForColumn(dgv, actual.For, last.For, i, 8);
                EvidenceDiffForColumn(dgv, actual.Res, last.Res, i, 9);
                EvidenceDiffForColumn(dgv, actual.Vel, last.Vel, i, 10);
                EvidenceDiffForColumn(dgv, actual.Mar, last.Mar, i, 11);
                EvidenceDiffForColumn(dgv, actual.Con, last.Con, i, 12);
                EvidenceDiffForColumn(dgv, actual.Wor, last.Wor, i, 13);
                EvidenceDiffForColumn(dgv, actual.Pos, last.Pos, i, 14);
                EvidenceDiffForColumn(dgv, actual.Pas, last.Pas, i, 15);
                EvidenceDiffForColumn(dgv, actual.Cro, last.Cro, i, 16);
                EvidenceDiffForColumn(dgv, actual.Tec, last.Tec, i, 17);
                EvidenceDiffForColumn(dgv, actual.Tes, last.Tes, i, 18);
                EvidenceDiffForColumn(dgv, actual.Fin, last.Fin, i, 19);
                EvidenceDiffForColumn(dgv, actual.Lon, last.Lon, i, 20);
                EvidenceDiffForColumn(dgv, actual.Set, last.Set, i, 21);
            }
        }

        private void EvidenceDiffForColumn(DataGridView dg, decimal actualval, decimal lastval, int row, int col)
        {
            DataGridViewCellStyle IncStyle = new DataGridViewCellStyle();
            IncStyle.Font = new Font(dg.DefaultCellStyle.Font, FontStyle.Regular);
            IncStyle.ForeColor = Color.Green;
            DataGridViewCellStyle DecStyle = new DataGridViewCellStyle();
            DecStyle.Font = new Font(dg.DefaultCellStyle.Font, FontStyle.Regular);
            DecStyle.ForeColor = Color.Red;
            DataGridViewCellStyle NormStyle = new DataGridViewCellStyle();
            NormStyle.Font = dg.DefaultCellStyle.Font;

            TMR_NumDecCell ndc = (TMR_NumDecCell)dg[col, row];

            if (ndc.OwningColumn.HeaderText == "ASI")
                ndc.filterASIvalue = true;

            ndc.Style = NormStyle;
            if ((int)actualval > (int)lastval)
            {
                ndc.Style = IncStyle;
                ndc.Tag = 2;
            }
            else if (actualval > lastval)
            {
                ndc.Tag = 1;
            }
            else if ((int)actualval < (int)lastval)
            {
                ndc.Style = DecStyle;
                ndc.Tag = -2;
            }
            else if (actualval < lastval)
            {
                ndc.Tag = -1;
            }
            else
            {
                ndc.Tag = 0;
            }
        }

        private void deleteDataSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolDataList.SelectedItem == null) return;

            if (MessageBox.Show(Current.Language.DataItemRelativeToWeek + (string)toolDataList.SelectedItem + Current.Language.WillBeDefinivelyRemovedContinue, Current.Language.RemoveDataItem, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DateTime dt = DateTime.Parse((string)toolDataList.SelectedItem);
                History.DeleteDay(Program.Setts.DefaultDirectory,
                                    dt);

                History.actualDts = History.LastTeam();

                if (History.actualDts == null)
                {
                    dataGridGiocatori.DataSource = null;
                    dataGridGiocatoriB.DataSource = null;
                    dataGridPortieri.DataSource = null;
                }
                else
                {
                    dataGridGiocatori.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'A' AND FPn > 0");
                    dataGridGiocatoriB.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'B' AND FPn > 0");
                    dataGridPortieri.DataSource = History.actualDts.GiocatoriNSkill.Select("FPn = 0");
                }

                UpdateTeamDateList();
            }
        }

        private void dataGridGiocatori_Sorted(object sender, EventArgs e)
        {
            InvalidateGrids(sender);
            UpdateShownGrid();
        }

        private void dataGridPortieri_Sorted(object sender, EventArgs e)
        {
            InvalidateGrids(sender);
            UpdateShownGrid();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {

        }


        private void dataGridPortieri_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int ID = (int)dataGridPortieri[0, e.RowIndex].Value;

            PlayerForm pf = new PlayerForm(History.actualDts.GiocatoriNSkill, History, ID, AllSeasons);

            pf.ShowDialog();

            if (pf.isDirty) isDirty = true;

            History.UpdateDirtyPlayers();

            // Update display of dirty players (function to be separated)
            foreach (ExtraDS.GiocatoriRow grow in History.PlayersDS.Giocatori)
            {
                if (!grow.isDirty) continue;
                EvidenceSkillsPlayerForQuality(grow.PlayerID, grow.isYoungTeam == 1, grow.FPn == 0);

                ExtraDS.GiocatoriRow egrow = extraDS.FindByPlayerID(grow.PlayerID);
                egrow.Routine = grow.Routine;

                egrow.ScoutVoto = grow.ScoutVoto;
                egrow.ScoutName = grow.ScoutName;
                egrow.ScoutGiudizio = grow.ScoutGiudizio;
                egrow.ScoutDate = grow.ScoutDate;
                egrow.Nome = grow.Nome;
                egrow.MediaVoto = grow.MediaVoto;
                egrow.wBorn = grow.wBorn;
                egrow.Note = grow.Note;

                egrow.wBloomStart = grow.wBloomStart;
                egrow.ExplosionTI = grow.ExplosionTI;
                egrow.AfterBloomTI = grow.AfterBloomTI;
                egrow.BeforeExplTI = grow.BeforeExplTI;
                egrow.Asi25 = grow.Asi25;
                egrow.Asi30 = grow.Asi30;

                if (!grow.IsProfessionalismNull()) egrow.Professionalism = grow.Professionalism;
                if (!grow.IsAggressivityNull()) egrow.Aggressivity = grow.Aggressivity;
                if (!grow.IsLeadershipNull()) egrow.Leadership = grow.Leadership;
                if (!grow.IsSpecialityNull()) egrow.Speciality = grow.Speciality;

                grow.isDirty = false;
            }
        }

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {

        }

        private void editGainSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (History.EditGainSet())
            {
                Program.Setts.GainSet = History.GD.GainDSfilename;
                History.RecalcDataFromGains();
                SetLastTeam();
            }
        }

        private void deleteOldPlayersDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Current.Language.PressingYESAllDataOfPlayersThatAreNoMoreInYourTeamWillBeDeleted,
                Current.Language.DeletingOldPlayersFromDatabase, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                History.DeleteOldPlayers();
            }
        }

        // Item selected with double click
        private void dataGridPlayersInfo_CellDoubleClick(object sender, object o)
        {
            AeroDataGrid dgGiocatori = null;

            if (sender.GetType() == typeof(AeroDataGrid))
            {
                dgGiocatori = (AeroDataGrid)sender;
            }
            else if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
                ContextMenuStrip cmStrip = (ContextMenuStrip)menuItem.Owner;
                dgGiocatori = (AeroDataGrid)cmStrip.SourceControl;
            }

            if (dgGiocatori == null)
                return;

            int PlayerID = -1;
            if (o.GetType() == typeof(DataGridViewCellEventArgs))
            {
                DataGridViewCellEventArgs e = (DataGridViewCellEventArgs)o;

                if (dgGiocatori.Rows[e.RowIndex].DataBoundItem.GetType() == typeof(DataRowView))
                {
                    DataRowView drv = (DataRowView)dgGiocatori.Rows[e.RowIndex].DataBoundItem;
                    ExtraDS.GiocatoriRow selPlayer = (ExtraDS.GiocatoriRow)drv.Row;
                    PlayerID = selPlayer.PlayerID;
                }
                else
                {
                    ExtTMDataSet.GiocatoriNSkillRow selPlayer = (ExtTMDataSet.GiocatoriNSkillRow)dgGiocatori.Rows[e.RowIndex].DataBoundItem;
                    PlayerID = selPlayer.PlayerID;
                }
            }
            else if (o.GetType() == typeof(EventArgs))
            {
                if (dgGiocatori.SelectedRows[0].DataBoundItem.GetType() == typeof(DataRowView))
                {
                    DataRowView drv = (DataRowView)dgGiocatori.SelectedRows[0].DataBoundItem;
                    ExtraDS.GiocatoriRow selPlayer = (ExtraDS.GiocatoriRow)drv.Row;
                    PlayerID = selPlayer.PlayerID;
                }
                else
                {
                    ExtTMDataSet.GiocatoriNSkillRow selPlayer = (ExtTMDataSet.GiocatoriNSkillRow)dgGiocatori.SelectedRows[0].DataBoundItem;
                    PlayerID = selPlayer.PlayerID;
                }
            }

            OpenPlayerInfoDialog(PlayerID);
        }

        // Item selected with double click
        private void OpenPlayerInfoDialog(int playerID)
        {
            if (History.actualDts.GiocatoriNSkill.FindByPlayerID(playerID) != null)
            {
                PlayerForm pf = new PlayerForm(History.actualDts.GiocatoriNSkill, History, playerID, AllSeasons);

                pf.ShowDialog();

                if (pf.isDirty) isDirty = true;

                pf.Dispose();
            }
            else
            {
                PlayerForm pf = new PlayerForm(History.actualDts.GiocatoriNSkill, History, playerID, AllSeasons);

                pf.ShowDialog();

                if (pf.isDirty) isDirty = true;

                pf.Dispose();
            }

            History.UpdateDirtyPlayers();

            // Update display of dirty players (function to be separated)
            foreach (ExtraDS.GiocatoriRow grow in History.PlayersDS.Giocatori)
            {
                if (!grow.isDirty) continue;
                EvidenceSkillsPlayerForQuality(grow.PlayerID, grow.isYoungTeam == 1, grow.FPn == 0);

                ExtraDS.GiocatoriRow egrow = extraDS.FindByPlayerID(grow.PlayerID);

                if (egrow == null)
                {
                    egrow = extraDS.Giocatori.NewGiocatoriRow();
                    egrow.ItemArray = grow.ItemArray;
                    extraDS.Giocatori.AddGiocatoriRow(egrow);
                }

                egrow.Routine = grow.Routine;
                egrow.ScoutVoto = grow.ScoutVoto;
                egrow.ScoutName = grow.ScoutName;
                egrow.ScoutGiudizio = grow.ScoutGiudizio;
                egrow.ScoutDate = grow.ScoutDate;
                egrow.Nome = grow.Nome;
                egrow.MediaVoto = grow.MediaVoto;
                egrow.wBorn = grow.wBorn;
                egrow.Note = grow.Note;

                egrow.wBloomStart = grow.wBloomStart;
                egrow.ExplosionTI = grow.ExplosionTI;
                egrow.AfterBloomTI = grow.AfterBloomTI;
                egrow.BeforeExplTI = grow.BeforeExplTI;
                egrow.Asi25 = grow.Asi25;
                egrow.Asi30 = grow.Asi30;

                if (!grow.IsProfessionalismNull()) egrow.Professionalism = grow.Professionalism;
                if (!grow.IsAggressivityNull()) egrow.Aggressivity = grow.Aggressivity;
                if (!grow.IsLeadershipNull()) egrow.Leadership = grow.Leadership;
                if (!grow.IsSpecialityNull()) egrow.Speciality = grow.Speciality;
                if (!grow.IsHiddenRevealedNull()) egrow.HiddenRevealed = grow.HiddenRevealed;
                if (!grow.IsRecNull()) egrow.Rec = grow.Rec;
                if (!grow.IsInjPronNull()) egrow.InjPron = grow.InjPron;
                if (!grow.IsAdaNull()) egrow.Ada = grow.Ada;
                if (!grow.IsPotentialNull()) egrow.Potential = grow.Potential;

                grow.isDirty = false;
            }

            if (dataGridPlayersInfo.RowCount == 0)
                return;
        }

        private void nationListEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string processName = Application.StartupPath + "/NationListEditor.exe";
            Process.Start(processName);
        }

        private void teamFileEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string processName = Application.StartupPath + "/TeamFileEditor.exe";

            FileInfo fi = new FileInfo(processName);

            if (!fi.Exists)
                MessageBox.Show(Current.Language.TheTeamFileEditorTeamFileEditorExeDoesnTExistAtTheGivenPath +
                    Application.StartupPath + ")", "TM Recorder", MessageBoxButtons.OK);
            else
                Process.Start(processName);
        }

        private void playerFileEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string processName = Application.StartupPath + "/PlayerFileEditor.exe";

            FileInfo fi = new FileInfo(processName);

            if (!fi.Exists)
                MessageBox.Show(Current.Language.ThePlayerFileEditorPlayerFileEditorExeDoesnTExistAtTheGivenPath +
                    Application.StartupPath + ")", "TM Recorder", MessageBoxButtons.OK);
            else
                Process.Start(processName);
        }

        private void transferManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string processName = Application.StartupPath + "/TransferManager.exe";

            FileInfo fi = new FileInfo(processName);

            if (!fi.Exists)
                MessageBox.Show(Current.Language.TheTransferManagerTransferManagerExeDoesnTExistAtTheGivenPath +
                    Application.StartupPath + ")", "TM Recorder", MessageBoxButtons.OK);
            else
                Process.Start(processName);
        }

        private void tmrBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string processName = Application.StartupPath + "/TMRBrowser.exe";

            FileInfo fi = new FileInfo(processName);

            if (!fi.Exists)
                MessageBox.Show(Current.Language.TheTMRBrowserTMRBrowserExeDoesnTExistAtTheGivenPath +
                    Application.StartupPath + ")", "TM Recorder", MessageBoxButtons.OK);
            else
                Process.Start(processName);
        }

        private void toolLoadFromExcelForm_Click(object sender, EventArgs e)
        {
            //WebClient client = new WebClient();
            //String htmlCode = client.DownloadString("http://trophymanager.com/squad.php");

            if ((!Clipboard.ContainsText(TextDataFormat.Text)) || (!Clipboard.GetText().Contains("Excel Squad Form")))
            {
                MessageBox.Show(Current.Language.TheClipboardDoesnTContainsExcelSquadFormData, Current.Language.LoadFromExcelForm, MessageBoxButtons.OK);
                return;
            }

            DateTime dt = DateTime.Today;

            string text = Clipboard.GetText();
            if (text.Contains("Date:"))
            {
                string[] lines = text.Split('\n');
                foreach (string line in lines)
                {
                    if (line.Contains("Date:"))
                    {
                        string date = line.Split('\t')[1];
                        bool res = DateTime.TryParse(date, out dt);
                        if (!res)
                        {
                            MessageBox.Show(Current.Language.DateFormatNotValid + date, Current.Language.LoadFromExcelForm);
                            return;
                        }
                        break;
                    }
                }
            }

            {
                // Select the week number using the form
                SelectDataDate sdd = new SelectDataDate();
                sdd.SelectedDate = dt;
                sdd.Text = "Confirm the date";
                if (sdd.ShowDialog() == DialogResult.OK)
                {
                    dt = sdd.SelectedDate;
                }
                else
                {
                    return;
                }
            }

            History.LoadSquadFileFromExcelForm(dt);

            History.actualDts = History.LastTeam();

            if (History.actualDts != null)
            {
                dataGridGiocatori.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'A' AND FPn > 0");
                dataGridGiocatoriB.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'B' AND FPn > 0");
                dataGridPortieri.DataSource = History.actualDts.GiocatoriNSkill.Select("FPn = 0");
            }

            isDirty = true;

            UpdateTeamDateList();
        }

        private void recalculatePlayersScoutVoteMeanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (History.PlayersDS == null) return;
            History.PlayersDS.RecomputePlayersMeanVote();
            extraDS.RecomputePlayersMeanVote();
            isDirty = true;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (this.tabControl1.SelectedTab == tabATeamPage)
            {
                movePlayerToATeamToolStripMenuItem.Visible = false;
                movePlayerToBTeamToolStripMenuItem.Visible = true;
            }
            else
            {
                movePlayerToATeamToolStripMenuItem.Visible = true;
                movePlayerToBTeamToolStripMenuItem.Visible = false;
            }
        }

        private void movePlayerToATeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in dataGridGiocatoriB.SelectedRows)
            {
                int ID = (int)dgvr.Cells[0].Value;

                History.actualDts.MovePlayerToOtherTeam(ID, "A");
                extraDS.SetSquad(ID, "A");
                History.PlayersDS.SetSquad(ID, "A");
            }

            dataGridGiocatori.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'A' AND FPn > 0");
            dataGridGiocatoriB.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'B' AND FPn > 0");

            FillForDifferenceGiocatori();
            EvidenceSkillsGiocatoriForQuality();
        }

        private void movePlayerToBTeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in dataGridGiocatori.SelectedRows)
            {
                int ID = (int)dgvr.Cells[0].Value;

                History.actualDts.MovePlayerToOtherTeam(ID, "B");
                extraDS.SetSquad(ID, "B");
                History.PlayersDS.SetSquad(ID, "B");
            }

            dataGridGiocatori.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'A' AND FPn > 0");
            dataGridGiocatoriB.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'B' AND FPn > 0");

            FillForDifferenceGiocatori();
            EvidenceSkillsGiocatoriForQuality();
        }

        private void dataGridGiocatori_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            string property = dgv.Columns[e.ColumnIndex].DataPropertyName;

            if (property == "FPn")
            {
                if (lastPropertySort == property + " ASC" + dgv.Name)
                    property = property + " DESC";
                else
                    property = property + " ASC";
            }
            else
            {
                if (lastPropertySort == property + " DESC" + dgv.Name)
                    property = property + " ASC";
                else
                    property = property + " DESC";
            }

            lastPropertySort = property + dgv.Name;

            if (dgv == dataGridGiocatori)
            {
                dataGridGiocatori.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'A' AND FPn > 0", property);
            }
            else
            {
                dataGridGiocatoriB.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'B' AND FPn > 0", property);
            }

            FillForDifferenceGiocatori(dgv);
            EvidenceSkillsGiocatoriForQuality(dgv, -1);
            EvidenceSkillsGiocatoriForGains(dgv);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }

        private void importPlayersDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = Program.Setts.PlayersPagesFolder;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Program.Setts.PlayersPagesFolder = folderBrowserDialog.SelectedPath;
                Program.Setts.Save();
            }
            else
                return;

            History.PlayersDS.GetDataFromPrivatePages(folderBrowserDialog.SelectedPath);
            SetLastTeam();
        }

        private void openPlayersWebPagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dgv = null;
            if (tabControl1.SelectedTab == tabATeamPage)
                dgv = dataGridGiocatori;
            else if (tabControl1.SelectedTab == tabBTeamPage)
                dgv = dataGridGiocatoriB;
            else if (tabControl1.SelectedTab == tabGK)
                dgv = dataGridPortieri;
            else
                dgv = dataGridPlayersInfo;

            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                int PlayerID = (int)row.Cells[0].Value;

                string arg = "http://trophymanager.com/showprofile.php?playerid=" + PlayerID.ToString();

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
                    Process.Start(startInfo);
                }
            }
        }

        private void openPlayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dgv = null;
            if (tabControl1.SelectedTab == tabATeamPage)
                dgv = dataGridGiocatori;
            else if (tabControl1.SelectedTab == tabBTeamPage)
                dgv = dataGridGiocatoriB;
            else if (tabControl1.SelectedTab == tabGK)
                dgv = dataGridPortieri;
            else
                dgv = dataGridPlayersInfo;

            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                int PlayerID = (int)row.Cells[0].Value;

                string arg = "http://trophymanager.com/showprofile.php?playerid=" + PlayerID.ToString() + "&scout_mode=1";

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
                    Process.Start(startInfo);
                }
            }
        }

        private void dataGridPlayersInfo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void parseScoutReviewForHiddenDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (History.PlayersDS == null) return;
            History.PlayersDS.ParseScoutReviewForHiddenData(reportAnalysis, -1);
            extraDS.ParseScoutReviewForHiddenData(reportAnalysis, -1);
            isDirty = true;
        }

        private void reapplyTrainingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            History.ReapplyTrainings(extraDS);
            SetLastTeam();
        }

        private void exportTrainingWeekInTheClipboardInExcelFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            History.ExportThisWeekTrainingInExcelFormat(History.actualDts.Date);
        }

        private void importTrainingWeekFromClipboardInExcelFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Today;
            if (MessageBox.Show(Current.Language.IsThisFileRelativeToToday, Current.Language.LoadTrainingDataInExcelFormat,
                               MessageBoxButtons.YesNo) == DialogResult.No)
            {
                // Select the week number using the form
                SelectDataDate sdd = new SelectDataDate();
                if (sdd.ShowDialog() == DialogResult.OK)
                {
                    dt = sdd.SelectedDate;
                }
                else
                {
                    return;
                }
            }

            History.ImportThisWeekTrainingInExcelFormat(dt);
            History.ReapplyTrainings(extraDS);
        }

        private void displayStatisticsForThisWeekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            History.DisplayTrainingStatsForThisWeek(History.actualDts.Date, CalcForDifference(), teamStats);
        }

        private void clearDecimalsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            History.ClearAllDecimals();
            SetLastTeam();
        }

        private void teamStatistiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeamStatsForm tsf = new TeamStatsForm();

            tsf.FillSquadGraphs(extraDS);

            tsf.FillSquadStatsGraphs(teamStats);

            tsf.ShowDialog();
        }

        private void gotoCalendarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string arg = "http://trophymanager.com/fixtures/club/" + Program.Setts.MainSquadID + "/";
            Utility.OpenPage(arg);
        }

        private void gotoMatchReportPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabBrowser;

            MatchData selMatch = (MatchData)dgMatches.SelectedRows[0].DataBoundItem;

            string matchAddr = "http://trophymanager.com/matches/" + selMatch.MatchID + "/";

            webBrowser.Goto(matchAddr);
        }

        public void LoadKampFromHTMLcode_NewTM(string page)
        {
            //    ChampDS.MatchRow matchRow = null;

            //    try
            //    {
            //        if (page.Contains("http://trophymanager.com/matches/"))
            //        {
            //            string kampid = HTML_Parser.GetNumberAfter(page, "http://trophymanager.com/matches/");
            //            matchRow = champDS.Match.FindByMatchID(int.Parse(kampid));

            //            if (matchRow == null)
            //            {
            //                MessageBox.Show("The match has not been found in your list of matches, so you cannot download it\n" +
            //                    "Please update the matches list",
            //                    "Loading match");
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            if (dgMatches.SelectedRows.Count == 0) return;

            //            System.Data.DataRowView selMatch = (System.Data.DataRowView)dgMatches.SelectedRows[0].DataBoundItem;
            //            matchRow = (ChampDS.MatchRow)selMatch.Row;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        string swRelease = "Sw Release:" + Application.ProductName + "("
            //            + Application.ProductVersion + ")";
            //        SendFileTo.ErrorReport.Send(ex, page, Environment.StackTrace, swRelease);
            //        MessageBox.Show(Current.Language.SorryTheImportingProcessHasFailedIfYouClickedOkTheInfoOfTheErrorHave +
            //            Current.Language.BeenSentToLedLennonThatWillRemoveThisBugAsSoonAsPossible);

            //        return;
            //    }

            //    try
            //    {
            //        if ((!matchRow.IsOppsClubIDNull()) && (page.Contains(matchRow.OppsClubID.ToString())))
            //        {
            //            if (matchDS.Analyze_NewTM(page, ref matchRow))
            //            {
            //                Program.Setts.ClubNickname = matchDS.clubNick;
            //                Program.Setts.Save();

            //                // Read always the action analysis file
            //                actionAnalysis.Clear();

            //                FileInfo fi = new FileInfo(Program.Setts.ActionAnalysisFile);

            //                matchRow.Report = true;

            //                if (fi.Exists)
            //                {
            //                    actionAnalysis.ReadXml(fi.FullName);

            //                    ActionList al = actionAnalysis.Analyze(matchDS,
            //                                            ref matchRow);

            //                    foreach (ActionItem ai in al)
            //                    {
            //                        ChampDS.PlyStatsRow psr = champDS.PlyStats.FindByPlayerIDSeasonIDTypeStats(ai.playerID,
            //                            TmWeek.GetSeason(matchRow.Date),
            //                            matchRow.MatchType);

            //                        MatchDS.YourTeamPerfRow ytpr = matchDS.YourTeamPerf.FindByPlayerID(ai.playerID);
            //                        if (ytpr != null)
            //                        {
            //                            ytpr.Analysis = ai.actions;
            //                        }

            //                        MatchDS.OppsTeamPerfRow otpr = matchDS.OppsTeamPerf.FindByPlayerID(ai.playerID);
            //                        if (otpr != null)
            //                        {
            //                            otpr.Analysis = ai.actions;
            //                        }

            //                        if (psr == null) continue;

            //                        if (ai.actions != "")
            //                            psr.SetAnalysis(matchRow.Date, ai.actions);

            //                        psr.SetVote(matchRow.Date, ytpr.Vote, ytpr.Position, matchDS.MeanVote);

            //                        if (ytpr != null)
            //                        {
            //                            champDS.PlyStats.RefreshPlayerStats(
            //                                ai.playerID,
            //                                matchRow.MatchType,
            //                                TmWeek.GetSeason(matchRow.Date));
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    foreach (MatchDS.YourTeamPerfRow ypr in matchDS.YourTeamPerf)
            //                    {
            //                        ChampDS.PlyStatsRow psr = champDS.PlyStats.FindByPlayerIDSeasonIDTypeStats(ypr.PlayerID,
            //                            TmWeek.GetSeason(matchRow.Date),
            //                            matchRow.MatchType);

            //                        if (ypr.IsNumberNull())
            //                            continue;

            //                        if (psr == null)
            //                        {
            //                            psr = champDS.PlyStats.NewPlyStatsRow();
            //                            psr.SeasonID = TmWeek.GetSeason(matchRow.Date);
            //                            psr.TypeStats = matchRow.MatchType;
            //                            psr.PlayerID = ypr.PlayerID;

            //                            champDS.PlyStats.AddPlyStatsRow(psr);
            //                        }

            //                        if ((ypr.Scored > 0) || (ypr.Assist > 0))
            //                        {
            //                            string plActions = "";
            //                            if (ypr.Scored > 0)
            //                                plActions += ypr.Scored.ToString() + "gg,";
            //                            if (ypr.Assist > 0)
            //                                plActions += ypr.Assist.ToString() + "aa,";
            //                            plActions = plActions.Trim(',');

            //                            psr.SetAnalysis(matchRow.Date, plActions);
            //                        }

            //                        if (ypr.IsVoteNull())
            //                            continue;

            //                        psr.SetVote(matchRow.Date, ypr.Vote, ypr.Position, matchDS.MeanVote);

            //                        champDS.PlyStats.RefreshPlayerStats(
            //                            ypr.PlayerID,
            //                            matchRow.MatchType,
            //                            TmWeek.GetSeason(matchRow.Date));
            //                    }
            //                }
            //            }

            //            matchDS.WriteXml(Path.Combine(Program.Setts.DefaultDirectory, "Match_" + matchRow.MatchID + ".xml"));

            //            dgMatches_SelectionChanged(null, EventArgs.Empty);

            //            AllSeasons.IsDirty = true;
            //        }
            //        else
            //        {
            //            dgMatches.ClearSelection();

            //            MessageBox.Show(Current.Language.PleaseSelectInTheTableTheMatchRowYouArePasting);
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        string swRelease = "Sw Release:" + Application.ProductName + "("
            //            + Application.ProductVersion + ")";
            //        SendFileTo.ErrorReport.Send(e, page, Environment.StackTrace, swRelease);
            //        MessageBox.Show(Current.Language.SorryTheImportingProcessHasFailedIfYouClickedOkTheInfoOfTheErrorHave +
            //            Current.Language.BeenSentToLedLennonThatWillRemoveThisBugAsSoonAsPossible);
            //    }
        }

        private void reloadPlayersMatchStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    MatchDS mds = null;
            //    bool catched = false;

            //    DirectoryInfo di = new DirectoryInfo(Program.Setts.DefaultDirectory);
            //    if (!di.Exists) return;

            //    champDS.PlyStats.Clear();

            //    foreach (FileInfo fi in di.GetFiles("Match_*.xml"))
            //    {
            //        try
            //        {
            //            mds = new MatchDS();

            //            mds.ReadXml(fi.FullName);

            //            ChampDS.MatchRow mr = champDS.Match.FindByMatchID(mds.MatchData[0].MatchID);

            //            champDS.PlyStats.AddPlayerStats(mr, mds, Program.Setts.ClubNickname);

            //        }
            //        catch (Exception ex)
            //        {
            //            if (catched) continue;
            //            catched = true;

            //            if (MessageBox.Show("Cannot import this page here. Here you can import only player profiles.\n" +
            //                "Pressing OK, you send a report to Atletico Granata that will try to detect the reason of the error.",
            //                "Import error", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //            {
            //                string swRelease = "Sw Release:" + Application.ProductName + "("
            //                   + Application.ProductVersion + ")";
            //                string info = "";

            //                string tempFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //                tempFolder = Path.Combine(tempFolder, "TmRecorder");

            //                string pathfilename = Path.Combine(tempFolder, "tempFile.txt");
            //                FileInfo fin = new FileInfo(pathfilename);

            //                champDS.WriteXml(fin.FullName);
            //                StreamReader file = new StreamReader(fi.FullName);
            //                info += "ChampDS:\r\n" + file.ReadToEnd();
            //                file.Close();

            //                mds.WriteXml(fin.FullName);
            //                file = new StreamReader(fin.FullName);
            //                info += "MatchDS:\r\n" + file.ReadToEnd();
            //                file.Close();

            //                SendFileTo.ErrorReport.Send(ex, info, Environment.StackTrace, swRelease);
            //            }
            //        }
            //    }

            //    UpdateLackData();

            //    AllSeasons.IsDirty = true;
        }

        private void UpdateLackData()
        {
            FillCmbMatchesSeasons();

            MatchListUpdateSeason();

            //foreach (ChampDS.PlyStatsRow psr in champDS.PlyStats)
            //{
            //    if (psr.IsNomeNull())
            //    {
            //        ExtraDS.GiocatoriRow gr = extraDS.FindByPlayerID(psr.PlayerID);

            //        if (gr != null)
            //            psr.Nome = extraDS.FindByPlayerID(psr.PlayerID).Nome;
            //    }
            //}
        }

        private void chkUpdateMatchList(object sender, EventArgs e)
        {
            MatchListUpdateSeason();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Current.Language.FirstOfAllOpenTheCalendarPageOfYourTeamUsingTheRelativeButtonOnTheMatchMenu);
        }

        private void playersStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayersStats psf = new PlayersStats(AllSeasons, this.extraDS);

            psf.ShowDialog();
        }

        private void deleteSelectedMatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MatchData selMatch = (MatchData)dgMatches.SelectedRows[0].DataBoundItem;

            string matchAddr = "http://trophymanager.com/matches/" + selMatch.MatchID + "/";

            string matchname = selMatch.Home + " - " + selMatch.Away;
            if (MessageBox.Show(Current.Language.AreYouSureThatYouWantToRemoveTheMatch + matchname + "?", Current.Language.DeleteMatch,
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                dgMatches.DataCollection = null;

                AllSeasons.RemoveMatchFromDB(selMatch.MatchID);
                SeasonMatchList.Remove(selMatch);

                dgMatches.DataCollection = SeasonMatchList;
            }
        }

        private void showMatchActionsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MatchData selMatch = (MatchData)dgMatches.SelectedRows[0].DataBoundItem;

            MatchActionsList mal = new MatchActionsList();

            mal.actionsDataTableBindingSource.DataSource = AllSeasons.GetMatchActions(selMatch.MatchID);

            mal.Text = selMatch.Home + " " + selMatch.ScoreString.ToString() + " " + selMatch.Away;

            mal.ShowDialog();
        }

        private void dgMatches_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            showMatchActionsListToolStripMenuItem_Click(null, EventArgs.Empty);
        }

        private void tMFinanceCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string processName = Application.StartupPath + "/TMFinanceCalculator.exe";

            FileInfo fi = new FileInfo(processName);

            if (!fi.Exists)
                MessageBox.Show(Current.Language.TheTransferManagerTransferManagerExeDoesnTExistAtTheGivenPath +
                    Application.StartupPath + ")", "TM Recorder", MessageBoxButtons.OK);
            else
                Process.Start(processName);
        }

        private void showMatchesPerformarcesOnTheFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MatchOnField mof = new MatchOnField(AllSeasons, this.extraDS, this.History);
            mof.Show();
        }

        private void trainersEvaluationFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Trainers tf = new Trainers();
            tf.ShowDialog();
        }

        private void tradToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TraderForm tf = new TraderForm();

            History.FillTradingList(tf.trading);

            tf.Show(this);
        }

        private void aSIToTICalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string processName = Application.StartupPath + "/ASI2TI.exe";

            FileInfo fi = new FileInfo(processName);

            if (!fi.Exists)
                MessageBox.Show(Current.Language.TheASIToTIApplicationASI2TIExeDoesnTExistAtTheGivenPath +
                    Application.StartupPath + ")", "TM Recorder", MessageBoxButtons.OK);
            else
                Process.Start(processName);
        }

        private void youthDevelopmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YouthDevelopment yd = new YouthDevelopment();
            yd.ShowDialog();
        }

        private void actionAnalysisEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string processName = Program.Setts.InstallationDirectory + "/ActionAnalysisEditor.exe";

            FileInfo fi = new FileInfo(processName);

            if (!fi.Exists)
                MessageBox.Show(Current.Language.TheActionAnalysisEditorActionAnalysisEditorExeDoesnTExistAtTheGivenPath +
                    Program.Setts.InstallationDirectory + ")", "TM Recorder", MessageBoxButtons.OK);
            else
                Process.Start(processName);
        }

        private void recalculatePlayersStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Current.Language.ThisOperationHasNotBeenImplemented);
        }

        //private void analyzeMatchToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (dgMatches.SelectedRows.Count == 0) return;

        //    System.Data.DataRowView selMatch = (System.Data.DataRowView)dgMatches.SelectedRows[0].DataBoundItem;
        //    ChampDS.MatchRow matchRow = (ChampDS.MatchRow)selMatch.Row;

        //    // Read always the action analysis file
        //    actionAnalysis.Clear();
        //    FileInfo fi = new FileInfo(Path.Combine(Program.Setts.DefaultDirectory,
        //            Program.Setts.ActionAnalysisFile));
        //    if (!fi.Exists)
        //    {
        //        MessageBox.Show(Current.Language.TheActionAnalysisFileDoesNotExists +
        //            Current.Language.PleaseDownloadItFromTheTmrecorderWebSiteAndThenSelectItFromTheToolsOptionsPanel);
        //        return;
        //    }

        //    actionAnalysis.ReadXml(fi.FullName);

        //    if (matchRow.Report == false)
        //    {
        //        MessageBox.Show(Current.Language.TheMatchHasNotBeenDownloadedFromTrophymanager);
        //        return;
        //    }

        //    if (matchRow.IsYourNickNull() || matchRow.IsOppsNickNull())
        //    {
        //        if (MessageBox.Show(Current.Language.TheInformationForThisMatchAreNotCompleteTheNickOfYourAndOppositeTeamHaveNotBeenSavedDoYouWantToSetYourselfTheNick, "Match info not complete", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //        {
        //            PropertyEditor ped = new PropertyEditor();
        //            editingMatchRow = matchRow;

        //            ped.dialogBag.Properties.Add(new PropertySpec("Your Team Nick", typeof(string),
        //                "Match Info", "The nick of your team",
        //                ""));
        //            ped.dialogBag.Properties.Add(new PropertySpec("Opposite Team Nick", typeof(string),
        //                "Match Info", "The nick of the opposite team",
        //                ""));

        //            editingMatchRow.YourNick = "";
        //            editingMatchRow.OppsNick = "";

        //            ped.dialogBag.GetValue += new PropertySpecEventHandler(dialogBag_GetValue);
        //            ped.dialogBag.SetValue += new PropertySpecEventHandler(dialogBag_SetValue);

        //            ped.InitializeGrid();

        //            ped.ShowDialog();
        //        }
        //        else return;
        //    }

        //    ActionList al = actionAnalysis.Analyze(matchDS,
        //                            ref matchRow);

        //    foreach (ActionItem ai in al)
        //    {
        //        ChampDS.PlyStatsRow psr = champDS.PlyStats.FindByPlayerIDSeasonIDTypeStats(ai.playerID,
        //            TmWeek.GetSeason(matchRow.Date),
        //            matchRow.MatchType);

        //        MatchDS.YourTeamPerfRow ytpr = matchDS.YourTeamPerf.FindByPlayerID(ai.playerID);
        //        if (ytpr != null)
        //        {
        //            ytpr.Analysis = ai.actions;
        //        }

        //        MatchDS.OppsTeamPerfRow otpr = matchDS.OppsTeamPerf.FindByPlayerID(ai.playerID);
        //        if (otpr != null)
        //        {
        //            otpr.Analysis = ai.actions;
        //        }

        //        if (psr == null) continue;


        //        if (ai.actions != "")
        //            psr.SetAnalysis(matchRow.Date, ai.actions);

        //        if (ytpr != null)
        //        {
        //            psr.SetVote(matchRow.Date, ytpr.Vote, ytpr.Position, matchDS.MeanVote);
        //            champDS.PlyStats.RefreshPlayerStats(
        //                ai.playerID,
        //                matchRow.MatchType,
        //                TmWeek.GetSeason(matchRow.Date));
        //        }

        //        matchDS.WriteXml(Path.Combine(Program.Setts.DefaultDirectory, "Match_" + matchRow.MatchID + ".xml"));

        //        dgMatches_SelectionChanged(null, EventArgs.Empty);

        //        AllSeasons.IsDirty = true;
        //    }
        //}

        void dialogBag_SetValue(object sender, PropertySpecEventArgs e)
        {
            switch (e.Property.Name)
            {
                case "Your Team Nick": editingMatchRow.YourNick = (string)e.Value; break;
                case "Opposite Team Nick": editingMatchRow.OppsNick = (string)e.Value; break;
            }
        }

        void dialogBag_GetValue(object sender, PropertySpecEventArgs e)
        {
            switch (e.Property.Name)
            {
                case "Your Team Nick": e.Value = editingMatchRow.YourNick; break;
                case "Opposite Team Nick": e.Value = editingMatchRow.OppsNick; break;
            }
        }


        private void changePlayerPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridPlayersInfo.SelectedRows.Count == 0) return;

            System.Data.DataRowView selPlayer = (System.Data.DataRowView)dataGridPlayersInfo.SelectedRows[0].DataBoundItem;
            ExtraDS.GiocatoriRow plRow = (ExtraDS.GiocatoriRow)selPlayer.Row;

            PropertyEditor ped = new PropertyEditor();
            editingPlayerRow = plRow;
            ped.Text = "Player " + plRow.Nome + " Properties";

            if (plRow.IsRoutineNull()) plRow.Routine = 0;
            if (plRow.IsProfessionalismNull()) plRow.Professionalism = 0;
            if (plRow.IsAggressivityNull()) plRow.Aggressivity = 0;
            if (plRow.IsLeadershipNull()) plRow.Leadership = 0;
            if (plRow.IsAbilityNull()) plRow.Ability = 0;
            if (plRow.IsInjPronNull()) plRow.InjPron = 0;

            ped.dialogBag.Properties.Add(new PropertySpec("Adaptability", typeof(decimal),
                "Player Info", "Adaptability of the player: it'I a value from 0 (min adaptability) to 20 (max)",
                plRow.Ada));
            ped.dialogBag.Properties.Add(new PropertySpec("Name", typeof(string),
                "Player Info", "Name of the player",
                plRow.Nome));
            ped.dialogBag.Properties.Add(new PropertySpec("Notes", typeof(string),
                "Player Info", "Notes about the player",
                plRow.Note));
            ped.dialogBag.Properties.Add(new PropertySpec("Routine", typeof(decimal),
                "Player Info", "Cumulated Routine of the player",
                plRow.Routine));

            ped.dialogBag.Properties.Add(new PropertySpec("AfterBloomTI", typeof(decimal),
                "Blooming Info", "TI just after the blooming period",
                plRow.AfterBloomTI));
            ped.dialogBag.Properties.Add(new PropertySpec("BeforeBloomTI", typeof(decimal),
                "Blooming Info", "TI just before the blooming period",
                plRow.BeforeExplTI));
            ped.dialogBag.Properties.Add(new PropertySpec("ExplosionTI", typeof(decimal),
                "Blooming Info", "TI just after the blooming start",
                plRow.ExplosionTI));

            ped.dialogBag.Properties.Add(new PropertySpec("Professionalism", typeof(float),
                "Hidden skills", "Hidden skills (1=Low, 10=High), multiply by 2 the value of the scouts report",
                plRow.Professionalism));
            ped.dialogBag.Properties.Add(new PropertySpec("Aggressivity", typeof(float),
                "Hidden skills", "Hidden skills (1=Low, 10=High), multiply by 2 the value of the scouts report",
                plRow.Aggressivity));
            ped.dialogBag.Properties.Add(new PropertySpec("Leadership", typeof(float),
                "Hidden skills", "Hidden skills (1=Low, 10=High), multiply by 2 the value of the scouts report",
                plRow.Leadership));
            ped.dialogBag.Properties.Add(new PropertySpec("InjuryProneness", typeof(decimal),
                "Hidden skills", "Hidden skills (1=Low, 10=High), take the value from hidden skills, if you know it",
                plRow.InjPron));
            ped.dialogBag.Properties.Add(new PropertySpec("Potential", typeof(float),
                "Hidden skills", "Hidden skills (1=Low, 20=High), as resulting from the scouts report" +
                "\nThis skill indicate the potential of the player",
                plRow.Ability));

            int AgeStartOfBloom = (plRow.wBloomStart - plRow.wBorn) / 12;
            ped.dialogBag.Properties.Add(new PropertySpec("Bloom Start Age", typeof(int),
                "Blooming Info", "The bloom start age, as reported from the scouts",
                AgeStartOfBloom));

            ped.dialogBag.GetValue += new PropertySpecEventHandler(dialogBag_PlayerGetValue);
            ped.dialogBag.SetValue += new PropertySpecEventHandler(dialogBag_PlayerSetValue);

            ped.InitializeGrid();

            ped.ShowDialog();

            ExtraDS.GiocatoriRow hgr = History.PlayersDS.FindByPlayerID(plRow.PlayerID);
            hgr.ItemArray = plRow.ItemArray;

            isDirty = true;
        }

        void dialogBag_PlayerGetValue(object sender, PropertySpecEventArgs e)
        {
            int AgeStartOfBloom;

            switch (e.Property.Name)
            {
                case "Adaptability": e.Value = editingPlayerRow.Ada; break;
                case "Name": e.Value = editingPlayerRow.Nome; break;
                case "Notes": e.Value = editingPlayerRow.Note; break;
                case "Routine": e.Value = editingPlayerRow.Routine; break;
                case "AfterBloomTI": e.Value = editingPlayerRow.AfterBloomTI; break;
                case "BeforeBloomTI": e.Value = editingPlayerRow.BeforeExplTI; break;
                case "ExplosionTI": e.Value = editingPlayerRow.ExplosionTI; break;
                case "Bloom Start Age":
                    AgeStartOfBloom = (editingPlayerRow.wBloomStart - editingPlayerRow.wBorn) / 12;
                    e.Value = AgeStartOfBloom;
                    break;
                case "Professionalism": e.Value = editingPlayerRow.Professionalism; break;
                case "InjuryProneness": e.Value = editingPlayerRow.InjPron; break;
                case "Leadership": e.Value = editingPlayerRow.Leadership; break;
                case "Aggressivity": e.Value = editingPlayerRow.Aggressivity; break;
                case "Potential": e.Value = editingPlayerRow.Ability; break;
            }
        }

        void dialogBag_PlayerSetValue(object sender, PropertySpecEventArgs e)
        {
            int AgeStartOfBloom;

            switch (e.Property.Name)
            {
                case "Adaptability":
                    {
                        bool isGK = (editingPlayerRow.FP == "GK");
                        bool isYoung = (editingPlayerRow.isYoungTeam == 1);
                        editingPlayerRow.Ada = (decimal)e.Value;
                        History.UpdatePlayerDB(editingPlayerRow.PlayerID, "Ada",
                            editingPlayerRow.Ada);
                        EvidenceSkillsPlayerForQuality(editingPlayerRow.PlayerID, isGK, isYoung);
                    }
                    break;
                case "Name":
                    editingPlayerRow.Nome = (string)e.Value;
                    History.UpdatePlayerDB(editingPlayerRow.PlayerID, "Nome",
                        editingPlayerRow.Nome);
                    break;
                case "Notes": editingPlayerRow.Note = (string)e.Value; break;
                case "Routine":
                    {
                        bool isGK = (editingPlayerRow.FP == "GK");
                        bool isYoung = (editingPlayerRow.isYoungTeam == 1);
                        editingPlayerRow.Routine = (decimal)e.Value;
                        History.UpdatePlayerDB(editingPlayerRow.PlayerID, "Rou",
                            editingPlayerRow.Routine);
                        EvidenceSkillsPlayerForQuality(editingPlayerRow.PlayerID, isYoung, isGK);
                    }
                    break;
                case "AfterBloomTI": editingPlayerRow.AfterBloomTI = (decimal)e.Value; break;
                case "BeforeBloomTI": editingPlayerRow.BeforeExplTI = (decimal)e.Value; break;
                case "ExplosionTI": editingPlayerRow.ExplosionTI = (decimal)e.Value; break;
                case "Bloom Start Age":
                    AgeStartOfBloom = (int)e.Value;
                    editingPlayerRow.wBloomStart = editingPlayerRow.wBorn + AgeStartOfBloom * 12;
                    break;
                case "Professionalism": editingPlayerRow.Professionalism = (float)e.Value; break;
                case "InjuryProneness": editingPlayerRow.InjPron = (decimal)e.Value; break;
                case "Leadership": editingPlayerRow.Leadership = (float)e.Value; break;
                case "Aggressivity": editingPlayerRow.Aggressivity = (float)e.Value; break;
                case "Potential": editingPlayerRow.Ability = (float)e.Value; break;
            }
        }

        private void evidenceSkillsForGainsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Setts.EvidenceGain = !Program.Setts.EvidenceGain;
            Program.Setts.Save();

            EvidenceSkillsPortieriForGains();
            EvidenceSkillsGiocatoriForGains();

            evidenceSkillsForGainsToolStripMenuItem.Checked = Program.Setts.EvidenceGain;
            evidenceSkillsForGainsMenuItem2.Checked = Program.Setts.EvidenceGain;
            evidenceSkillsForGainsMenuItemGK.Checked = Program.Setts.EvidenceGain;
        }

        private void gotoTheTmRecorderWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string arg = "http://www.facebook.com/pages/Tmrecorder/503894159654279";
            Utility.OpenPage(arg);
        }

        private void gotoTheTmRecorderFederationInTrophyManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string arg = "http://trophymanager.com/forum.php?show=c771";
            Utility.OpenPage(arg);
        }

        private void frequentlyAskedQuestionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string arg = "http://tmrecorder.insyde.it/tmrecorder/english-faq";
            Utility.OpenPage(arg);
        }

        private void iTDomandeFrequentiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string arg = "http://tmrecorder.insyde.it/tmrecorder/manuale-in-italiano/tmrecorder-faq---italiano";
            Utility.OpenPage(arg);
        }

        private void tsbTraining_Click(object sender, EventArgs e)
        {
            webBrowser.Goto(TM_Pages.Training);
        }

        /// <summary>
        /// Save imported file
        /// </summary>
        /// <param name="page"></param>
        /// <param name="address"></param>
        private void SaveImportedFile(string page, string address)
        {
            // Check the existence of the folder
            DirectoryInfo di = new DirectoryInfo(Path.Combine(Program.Setts.DefaultDirectory, "ImportedPages"));
            if (!di.Exists)
            {
                di.Create();
            }

            if (address.Contains(TM_Pages.Home))
                address = address.Replace(TM_Pages.Home, "");

            string filedate = TmWeek.ToSWDString(DateTime.Now);

            string filename = "NF-" + address.Replace(".php", "").Replace("/", "");

            filename += "-" + filedate + ".2.htm";

            FileInfo fi = new FileInfo(Path.Combine(di.FullName, filename));

            StreamWriter file = new StreamWriter(fi.FullName);
            file.Write(page);
            file.Close();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (Program.Setts.SettsRelease < 2)
            {
                Program.Setts.SettsRelease = 2;
                Program.Setts.Save();

                tabControl1.SelectedTab = tabBrowser;

            }

            webBrowser.Goto(TM_Pages.TmrWebSite);
        }

        private void lineupToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LineUp lineup = new LineUp(AllSeasons, extraDS, History);
            lineup.ShowDialog();
        }

        private void shortlistToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShortlistForm sf = new ShortlistForm();
            sf.ShowDialog();
        }

        private void toolStripMenu_SetBloomingAge_Click(object sender, EventArgs e)
        {
            if (dataGridPlayersInfo.SelectedRows.Count == 0) return;

            System.Data.DataRowView selPlayer = (System.Data.DataRowView)dataGridPlayersInfo.SelectedRows[0].DataBoundItem;
            ExtraDS.GiocatoriRow plRow = (ExtraDS.GiocatoriRow)selPlayer.Row;

            ToolStripDropDownItem ddi = (ToolStripDropDownItem)sender;

            int bloomingAge = int.Parse(ddi.Text);

            plRow.wBloomStart = plRow.wBorn + bloomingAge * 12;
        }

        private void toolStripMenu_SetBloomingPhase_Click(object sender, EventArgs e)
        {
            if (dataGridPlayersInfo.SelectedRows.Count == 0) return;

            System.Data.DataRowView selPlayer = (System.Data.DataRowView)dataGridPlayersInfo.SelectedRows[0].DataBoundItem;
            ExtraDS.GiocatoriRow plRow = (ExtraDS.GiocatoriRow)selPlayer.Row;

            int playerAge = (TmWeek.thisWeek().absweek - plRow.wBorn) / 12;
            int bloomingAge = 0;

            if (sender == miNotBloomedUToolStripMenuItem)
                bloomingAge = playerAge + 1;
            else if (sender == mi1stYearToolStripMenuItem)
                bloomingAge = playerAge;
            else if (sender == mi2ndYearToolStripMenuItem)
                bloomingAge = playerAge - 1;
            else if (sender == mi3rdYearToolStripMenuItem)
                bloomingAge = playerAge - 2;
            else
                bloomingAge = playerAge - 3;

            plRow.wBloomStart = plRow.wBorn + bloomingAge * 12;
        }

        private void contextMenuPlInfo_Opening(object sender, CancelEventArgs e)
        {
            if (dataGridPlayersInfo.SelectedRows.Count == 0) return;

            System.Data.DataRowView selPlayer = (System.Data.DataRowView)dataGridPlayersInfo.SelectedRows[0].DataBoundItem;
            ExtraDS.GiocatoriRow plRow = (ExtraDS.GiocatoriRow)selPlayer.Row;

            int AgeStartOfBloom = (plRow.wBloomStart - plRow.wBorn) / 12;

            string ageOfBloom = AgeStartOfBloom.ToString();

            foreach (ToolStripMenuItem tsi in setAgeToolStripMenuItem.DropDownItems)
            {
                if (tsi.Text == ageOfBloom) tsi.Checked = true;
                else tsi.Checked = false;
            }

            int playerAge = (TmWeek.thisWeek().absweek - plRow.wBorn) / 12;

            foreach (ToolStripMenuItem tsi in setPhaseToolStripMenuItem.DropDownItems)
            {
                tsi.Checked = false;
            }

            if (playerAge - AgeStartOfBloom >= 3)
                miCompletelyBloomedEToolStripMenuItem.Checked = true;
            else if (playerAge - AgeStartOfBloom == 0)
                mi1stYearToolStripMenuItem.Checked = true;
            else if (playerAge - AgeStartOfBloom == 1)
                mi2ndYearToolStripMenuItem.Checked = true;
            else if (playerAge - AgeStartOfBloom == 2)
                mi3rdYearToolStripMenuItem.Checked = true;
            else if (playerAge - AgeStartOfBloom < 0)
                miNotBloomedUToolStripMenuItem.Checked = true;

        }

        private void tsbImportSquadA_Click(object sender, EventArgs e)
        {
            webBrowser.Goto(TM_Pages.Players);
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabBrowser)
            {
                UpdateBrowserImportPanel();
            }
        }

        public void UpdateBrowserImportPanel()
        {
            int thisWeek = TmWeek.thisWeek().absweek;
            ExtTMDataSet eds = History.LastTeam();
            int lastUpdateWeek = -1;
            bool trainingProgramUpdated = false;

            if (eds != null)
            {
                lastUpdateWeek = TmWeek.GetTmAbsWk(eds.Date);

                if (History.TrainingHist.Count > 0)
                {
                    trainingProgramUpdated = History.TrainingHist.LastTraining().ProgramUpdated;
                }
            }

            if (lastUpdateWeek == -1) // Never imported data
            {
                tsbImportSquad.ForeColor = Color.DarkRed;
                tsbImportSquad.ToolTipText = "Import squad data";
                tsbImportSquad.UnderColor = Color.DarkRed;
                tsbImportSquad.UnderText = "Click here";
            }
            else if (thisWeek > lastUpdateWeek)
            {
                tsbImportSquad.ForeColor = Color.DarkRed;
                tsbImportSquad.ToolTipText = "Squad data imported " + (thisWeek - lastUpdateWeek).ToString() + " weeks ago";
                tsbImportSquad.UnderColor = Color.DarkRed;
                tsbImportSquad.UnderText = "To import";
            }
            else
            {
                tsbImportSquad.ForeColor = Color.DarkGreen;
                tsbImportSquad.ToolTipText = "Squad data updated";
                tsbImportSquad.UnderText = "Import ok";
                tsbImportSquad.UnderColor = Color.DarkGreen;
            }

            if (Program.Setts.PlayerType != 2)
            {
                tsbTrainingTraining.Enabled = false;
            }
            else if (thisWeek > lastUpdateWeek)
            {
                tsbTrainingTraining.Enabled = false;
                tsbTrainingTraining.ForeColor = Color.DarkRed;
                tsbTrainingTraining.ToolTipText = string.Format("The team data is to import.");
                tsbTrainingTraining.UnderColor = Color.DarkRed;
                tsbTrainingTraining.UnderText = "Team to update";
            }
            else if (!trainingProgramUpdated)
            {
                tsbTrainingTraining.Enabled = true;
                tsbTrainingTraining.ForeColor = Color.DarkRed;
                tsbTrainingTraining.ToolTipText = string.Format("Training Program has not been updated");
                tsbTrainingTraining.UnderColor = Color.DarkRed;
                tsbTrainingTraining.UnderText = "To import";
            }
            else
            {
                tsbTrainingTraining.Enabled = true;
                tsbTrainingTraining.ForeColor = Color.DarkGreen;
                tsbTrainingTraining.ToolTipText = "Training Updated";
                tsbTrainingTraining.UnderColor = Color.DarkGreen;
                tsbTrainingTraining.UnderText = "Import Ok";
            }

            if (!AllSeasons.IsUpdatedCalendar(Program.Setts.MainSquadID))
            {
                tsbMatchListA.ForeColor = Color.DarkRed;
                tsbMatchSquadA.Enabled = false;
                tsbMatchListA.ToolTipText = "Match List for Main Team not imported";
                tsbMatchListA.UnderText = "To import";
                tsbMatchListA.UnderColor = Color.DarkRed;
            }
            else
            {
                tsbMatchListA.ForeColor = Color.DarkGreen;
                tsbMatchSquadA.Enabled = true;
                tsbMatchListA.ToolTipText = "Match List for Main Team OK";
                tsbMatchListA.UnderText = "Import ok";
                tsbMatchListA.UnderColor = Color.DarkGreen;
            }

            if (!AllSeasons.IsUpdatedCalendar(Program.Setts.ReserveSquadID))
            {
                tsbMatchListB.ForeColor = Color.DarkRed;
                tsbMatchSquadB.Enabled = false;
                tsbMatchListB.ToolTipText = "Match List for Reserves Team  not imported";
                tsbMatchListB.UnderText = "Not imported";
                tsbMatchListB.UnderColor = Color.DarkRed;
            }
            else
            {
                tsbMatchListB.ForeColor = Color.DarkGreen;
                tsbMatchSquadB.Enabled = true;
                tsbMatchListB.ToolTipText = "Match List for Reserves Team OK";
                tsbMatchListB.UnderText = "Import ok";
                tsbMatchListB.UnderColor = Color.DarkGreen;
            }

            int matchToUpdate = AllSeasons.NumberOfMatchesToUpdate(Program.Setts.MainSquadID);
            if (matchToUpdate > 0)
            {
                tsbMatchSquadA.ForeColor = Color.DarkRed;
                tsbMatchSquadA.ToolTipText = "There are at least " + matchToUpdate.ToString() + " match to update";
                tsbMatchSquadA.UnderText = "To import " + matchToUpdate.ToString();
                tsbMatchSquadA.UnderColor = Color.DarkRed;
            }
            else
            {
                tsbMatchSquadA.ForeColor = Color.DarkGreen;
                tsbMatchSquadA.ToolTipText = "All the matches before today have been loaded";
                tsbMatchSquadA.UnderText = "Import ok";
                tsbMatchSquadA.UnderColor = Color.DarkGreen;
            }

            matchToUpdate = AllSeasons.NumberOfMatchesToUpdate(Program.Setts.ReserveSquadID);
            if (matchToUpdate > 0)
            {
                tsbMatchSquadB.ForeColor = Color.DarkRed;
                tsbMatchSquadB.ToolTipText = "There are at least " + matchToUpdate + " match to update";
                tsbMatchSquadB.UnderText = "To import " + matchToUpdate;
                tsbMatchSquadB.UnderColor = Color.DarkRed;
            }
            else
            {
                tsbMatchSquadB.ForeColor = Color.DarkGreen;
                tsbMatchSquadB.ToolTipText = "All the matches before today have been loaded";
                tsbMatchSquadB.UnderText = "Import ok";
                tsbMatchSquadB.UnderColor = Color.DarkGreen;
            }
        }

        private void tsbMatchSquadA_Click(object sender, EventArgs e)
        {
            MatchData matchToUpdate = AllSeasons.GetFirstMatchToUpdate(Program.Setts.MainSquadID);

            if (matchToUpdate == null)
            {
                MessageBox.Show("There are no matches to update in this season");
                return;
            }

            webBrowser.Goto("http://trophymanager.com/matches/" + matchToUpdate.MatchID + "/");
        }

        private void tsbMatchSquadB_Click(object sender, EventArgs e)
        {
            MatchData matchToUpdate = AllSeasons.GetFirstMatchToUpdate(Program.Setts.ReserveSquadID);

            if (matchToUpdate == null)
            {
                MessageBox.Show("There are no matches to update in this season");
                return;
            }

            webBrowser.Goto("http://trophymanager.com/matches/" + matchToUpdate.MatchID + "/");
        }

        private void tsbMatchListA_Click(object sender, EventArgs e)
        {
            webBrowser.Goto("http://trophymanager.com/fixtures/club/" + Program.Setts.MainSquadID + "/");
        }

        private void tsbMatchListB_Click(object sender, EventArgs e)
        {
            webBrowser.Goto("http://trophymanager.com/fixtures/club/" + Program.Setts.ReserveSquadID + "/");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateShownGrid();
        }

        private void UpdateShownGrid()
        {
            if (tabControl1.SelectedTab == tabATeamPage)
            {
                if (gridUpdateStatus[(int)e_GridTab.SQUAD_A])
                    return;
                FillForDifferenceGiocatori(dataGridGiocatori);
                EvidenceSkillsGiocatoriForQuality(dataGridGiocatori, -1);
                gridUpdateStatus[(int)e_GridTab.SQUAD_A] = true;
            }

            if (tabControl1.SelectedTab == tabBTeamPage)
            {
                if (gridUpdateStatus[(int)e_GridTab.SQUAD_B])
                    return;
                FillForDifferenceGiocatori(dataGridGiocatoriB);
                EvidenceSkillsGiocatoriForQuality(dataGridGiocatoriB, -1);
                gridUpdateStatus[(int)e_GridTab.SQUAD_B] = true;
            }

            if (tabControl1.SelectedTab == tabGK)
            {
                if (gridUpdateStatus[(int)e_GridTab.SQUAD_GK])
                    return;
                FillForDifferencePortieri();
                EvidenceSkillsPortieri();
                gridUpdateStatus[(int)e_GridTab.SQUAD_GK] = true;
            }
        }

        private void parseMatchesForMentalityAndAttackingStyleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void parseMatchForMentalityAndAttackingStylesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Data.DataRowView selMatch = (System.Data.DataRowView)dgMatches.SelectedRows[0].DataBoundItem;
            ChampDS.MatchRow matchRow = (ChampDS.MatchRow)selMatch.Row;

            matchAnalysisDB.ParseDescription(matchRow);
        }

        private void addExtraTeamToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddExtraTeam aetDlg = new AddExtraTeam();
            if (aetDlg.ShowDialog() == DialogResult.OK)
            {
                Dictionary<string, string> dictExtraTeams = Program.Setts.ExtraTeams;
                dictExtraTeams.Add(aetDlg.TeamID.ToString(), aetDlg.TeamName);
                Program.Setts.ExtraTeams = dictExtraTeams;
                UpdateExtraTeamMenu();
            }
        }

        private void UpdateExtraTeamMenu()
        {
            Dictionary<string, string> dictExtraTeams = Program.Setts.ExtraTeams;
            tsbExtraTeamMenu.DropDownItems.Clear();
            tsbExtraTeamMenu.DropDownItems.Add(tsbChangeToConfiguredExtraTeam);

            if (thisIsExtraTeam) return;

            tsbExtraTeamMenu.DropDownItems.Add(addExtraTeamToolStripMenuItem);

            tsbExtraTeamMenu.DropDownItems.Add(new ToolStripSeparator());

            foreach (string key in dictExtraTeams.Keys)
            {
                ToolStripMenuItem tsi = new ToolStripMenuItem();
                tsi.Name = "menuExtra_" + key;
                tsi.Text = "Open TmRecorder session for " + dictExtraTeams[key] + " (" + key + ")";
                tsi.Tag = key;
                tsi.Click += new EventHandler(tsiOpenTmRecorderSession_Click);
                tsbExtraTeamMenu.DropDownItems.Add(tsi);
            }
        }

        void tsiOpenTmRecorderSession_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            FileInfo fi = new FileInfo(Application.StartupPath + "\\TMRecorder.exe");
            if (!fi.Exists)
            {
                MessageBox.Show("There is no application to start in " + fi.FullName);
                return;
            }
            psi.FileName = fi.FullName;

            ToolStripItem tsi = (ToolStripItem)sender;
            string key = (string)tsi.Tag;

            string TeamName = Program.Setts.ExtraTeams[key];

            psi.Arguments = key;

            Process.Start(psi);
        }

        private void tsbChangeToConfiguredExtraTeam_Click(object sender, EventArgs e)
        {
            if (!webBrowser.StartnavigationAddress.StartsWith(@"http://trophymanager.com/"))
            {
                MessageBox.Show("You cannot switch to the extra team pages if you are not navigating in the Trophy Manager website");
                return;
            }

            webBrowser.ChangeTeam_Adv(Program.Setts.MainSquadID.ToString());
        }

        private void tsbFacebook_Click(object sender, EventArgs e)
        {
            string arg = "http://www.facebook.com/pages/Tmrecorder/503894159654279";
            Utility.OpenPage(arg);
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            toolLoadFromExcelForm_Click(sender, e);
        }

        private void exportTeamInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            History.ExportTeamInExcelFormat(History.actualDts.Date);
        }

        private void tsbScouts_Click(object sender, EventArgs e)
        {
            webBrowser.Goto(TM_Pages.Scouts);
        }

        private void structuresEconomyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComputeStructures cs = new ComputeStructures();
            cs.Settings = Program.Setts.ComputeStructureSettings;
            cs.ShowDialog();
            Program.Setts.ComputeStructureSettings = cs.Settings;
            Program.Setts.Save();
        }

        private void reloadAllTheImportedPlayerPagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This operation will overwrite your actual history with the content of the imported pages." +
                "It's an operation that is advised just if you lost a lot of data for any reason" +
                " (see in the web site http://tmr.inside.it/ for more info: Lost pages)") == System.Windows.Forms.DialogResult.Cancel)
                return;

            folderBrowserDialog.SelectedPath = Program.Setts.DefaultDirectory;
            folderBrowserDialog.Description = "Select the folder with saved pages";

            if (folderBrowserDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            SplashForm sf = new SplashForm("TM - Team Recorder",
                    "Release " + Application.ProductVersion,
                    "Loading Players From the saved pages...");
            sf.Show();

            DirectoryInfo di = new DirectoryInfo(folderBrowserDialog.SelectedPath);
            LoadSavedPlayerPagesRecursively(di, ref sf);

            sf.Close();
            sf.Dispose();
            sf = null;

            UpdateTeamDateList();

            History.ReapplyTrainings(extraDS);

            SetLastTeam();
        }

        private void reloadAllTheImportedFixturesAndMatchesPagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This operation will overwrite your actual history with the content of the imported pages." +
                "It's an operation that is advised just if you lost a lot of data for any reason" +
                " (see in the web site http://tmr.inside.it/ for more info: Lost pages)") == System.Windows.Forms.DialogResult.Cancel)
                return;

            folderBrowserDialog.SelectedPath = Program.Setts.DefaultDirectory;
            folderBrowserDialog.Description = "Select the folder with saved matches pages";

            if (folderBrowserDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            SplashForm sf = new SplashForm("TM - Team Recorder",
                    "Release " + Application.ProductVersion,
                    "Loading Players From the saved pages...");

            DirectoryInfo di = new DirectoryInfo(folderBrowserDialog.SelectedPath);
            LoadSavedFixturesAndMatchesPagesRecursively(di, ref sf, (Program.Setts.Trace > 0));

            sf.Close();
            sf.Dispose();
            sf = null;

            UpdateTeamDateList();

            SetLastTeam();
        }

        private void LoadSavedPlayerPagesRecursively(DirectoryInfo di, ref SplashForm sf)
        {
            LoadSavedPlayerPages(di.FullName);

            foreach (DirectoryInfo directory in di.GetDirectories())
                LoadSavedPlayerPagesRecursively(directory, ref sf);
        }

        private void LoadSavedFixturesAndMatchesPagesRecursively(DirectoryInfo di, ref SplashForm sf, bool trace)
        {
            LoadSavedFixturesAndMatchesPages(di.FullName, ref sf, trace);

            foreach (DirectoryInfo directory in di.GetDirectories())
                LoadSavedFixturesAndMatchesPagesRecursively(directory, ref sf, trace);
        }

        private void LoadSavedPlayerPages(string folder)
        {
            try
            {
                LoadSavedPlayerPages(folder, ref sf, (Program.Setts.Trace > 0));
            }
            catch (Exception)
            {
            }
        }

        public void LoadSavedPlayerPages(string dirPath, ref Common.SplashForm sf, bool trace)
        {
            // Select first all the team files
            // Name template: NF-players-S37-W10-D6.2.htm
            DirectoryInfo di = new DirectoryInfo(dirPath);

            sf.UpdateStatusMessage(0, string.Format("Scanning folder {0}...", di.Name));

            sf.Show();

            FileInfo[] fis = di.GetFiles("NF-players-*.2.htm*");
            int fisTot = fis.Length;
            int cnt = 0;
            foreach (FileInfo fi in fis)
            {
                StreamReader file = new StreamReader(fi.FullName);

                string playersPage = file.ReadToEnd();

                file.Close();

                string[] str = fi.FullName.Split('-');
                string dateString = str[2] + "-" + str[3] + "-" + str[4];
                int importWeek = TmWeek.SWDtoTmWeek(dateString).absweek;

                // The navigation address is not necessary in this case
                LoadHTMLfile_newPage(playersPage, "", true, importWeek, true);

                sf.progressvalue = (cnt * 100) / fisTot;
                sf.Refresh();
                sf.UpdateStatusMessage(0, string.Format("Loading Players Data {0} of {1}", cnt, fisTot));

                cnt++;
                //content.ParsePage(playersPage, "http://trophymanager.com/players/", importWeek);
            }

            Invalidate();
        }

        public void LoadSavedFixturesAndMatchesPages(string dirPath, ref Common.SplashForm sf, bool trace)
        {
            // Select first all the team files
            // Name template: NF-players-S37-W10-D6.2.htm
            DirectoryInfo di = new DirectoryInfo(dirPath);

            sf.UpdateStatusMessage(0, string.Format("Scanning folder {0} for Fixtures files", di.Name));

            sf.Show();

            FileInfo[] fis = di.GetFiles("NF-fixturesclub*.2.htm*");
            int fisTot = fis.Length;
            int cnt = 0;

            foreach (FileInfo fi in fis)
            {
                StreamReader file = new StreamReader(fi.FullName);

                string fixturesPage = file.ReadToEnd();

                file.Close();

                string[] str = fi.FullName.Split('-');
                string dateString = str[2] + "-" + str[3] + "-" + str[4];
                int importWeek = TmWeek.SWDtoTmWeek(dateString).absweek;

                string clubId = HTML_Parser.GetNumberAfter(fi.FullName, "NF-fixturesclub");

                // the navigation address is not needed
                LoadHTMLfile_newPage(fixturesPage, "", true, importWeek, true);

                sf.progressvalue = (cnt * 100) / fisTot;
                sf.Refresh();
                sf.UpdateStatusMessage(0, string.Format("Loading Fixtures {0} of {1}", cnt, fisTot));

                cnt++;
                // content.ParsePage(fixturesPage, "http://trophymanager.com/fixtures/club/" + clubId + "//", importWeek);
            }

            // Select the matches files
            // Name template: NF-matches79252194-S37-W10-D6.2.htm
            di = new DirectoryInfo(dirPath);

            sf.UpdateStatusMessage(0, "Loading Matches From the saved pages...");

            fis = di.GetFiles("NF-matches*.2.htm*");
            fisTot = fis.Length;
            cnt = 0;
            foreach (FileInfo fi in di.GetFiles("NF-matches*.2.htm*"))
            {
                StreamReader file = new StreamReader(fi.FullName);

                string matchPage = file.ReadToEnd();

                file.Close();

                string[] str = fi.FullName.Split('-');
                string dateString = str[2] + "-" + str[3] + "-" + str[4];
                int importWeek = TmWeek.SWDtoTmWeek(dateString).absweek;

                string matchId = HTML_Parser.GetNumberAfter(fi.FullName, "NF-matches");

                // The navigation address is not necessary
                LoadHTMLfile_newPage(matchPage, "", true, importWeek, true);

                sf.progressvalue = (cnt * 100) / fisTot;
                sf.Refresh();
                sf.UpdateStatusMessage(0, string.Format("Loading Match {0} of {1}", cnt, fisTot));

                cnt++;
                // content.ParsePage(matchPage, "http://trophymanager.com/matches/" + matchId + "//", importWeek);
            }

            UpdateLackData();

            Invalidate();
        }

        private void dgMatches_SelectionChanged(object sender, EventArgs e)
        {
            AeroDataGrid adg = (AeroDataGrid)sender;
            if (adg.SelectedRows.Count == 0)
                return;
            DataGridViewRow row = adg.SelectedRows[0];

            MatchData md = null;
            try
            {
                md = (MatchData)row.DataBoundItem;
            }
            catch (Exception)
            {
                return;
            }

            EnumerableRowCollection<NTR_SquadDb.PlayerPerfRow> yourPlayersPerfRows;
            EnumerableRowCollection<NTR_SquadDb.PlayerPerfRow> oppsPlayersPerfRows;

            bool IsHome = (md.Home.value == (cmbSquad.SelectedItem as Team).Name);

            if (IsHome)
            {
                yourPlayersPerfRows = md.HomePlayerPerf;
                oppsPlayersPerfRows = md.AwayPlayerPerf;
                lblNameYourTeam.Text = md.Home.ToString();
                lblNameYourTeam.ForeColor = md.Home.tagColor;
                lblNameOppsTeam.Text = md.Away.ToString();
                lblNameOppsTeam.ForeColor = md.Away.tagColor;
                lblMatchScore.Text = md.Score.ToString();
            }
            else
            {
                oppsPlayersPerfRows = md.HomePlayerPerf;
                yourPlayersPerfRows = md.AwayPlayerPerf;
                lblNameOppsTeam.Text = md.Home.ToString();
                lblNameOppsTeam.ForeColor = md.Home.tagColor;
                lblNameYourTeam.Text = md.Away.ToString();
                lblNameYourTeam.ForeColor = md.Away.tagColor;
                lblMatchScore.Text = md.Score.Inverse();
            }

            if (lblNameYourTeam.ForeColor.GetBrightness() > 0.75)
                lblNameYourTeam.ForeColor = Color.Black;
            if (lblNameOppsTeam.ForeColor.GetBrightness() > 0.75)
                lblNameOppsTeam.ForeColor = Color.Black;

            if (yourPlayersPerfRows != null)
            {
                List<PlayerPerfData> yourPlayerPerfData = (from c in yourPlayersPerfRows
                                                           select new PlayerPerfData(c)).OrderBy(p => p.NPos).ToList();
                List<PlayerPerfData> oppsPlayerPerfData = (from c in oppsPlayersPerfRows
                                                           select new PlayerPerfData(c)).OrderBy(p => p.NPos).ToList();


                dgYourTeamPerf.DataCollection = yourPlayerPerfData;
                dgOppsTeamPerf.DataCollection = oppsPlayerPerfData;
            }
            else
            {
                dgYourTeamPerf.DataCollection = null;
                dgOppsTeamPerf.DataCollection = null;
            }

            matchStats.SetMatchData(md);
        }

        private void dgMatches_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tabControl1.SelectedTab = tabBrowser;

            MatchData selMatch = (MatchData)dgMatches.Rows[e.RowIndex].DataBoundItem;

            string matchAddr = "http://trophymanager.com/matches/" + selMatch.MatchID + "/";

            webBrowser.Goto(matchAddr);
        }

        private void tsmGotoPlayerPageInBrowser_Click(object sender, object o)
        {
            tabControl1.SelectedTab = tabBrowser;

            string matchAddr = GetMatchAddress(sender, o);
            webBrowser.Goto(matchAddr);
        }

        private string GetMatchAddress(object sender, object o)
        {
            AeroDataGrid dgPerfPlayers = null;

            if (sender.GetType() == typeof(AeroDataGrid))
            {
                dgPerfPlayers = (AeroDataGrid)sender;
            }
            else if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
                ContextMenuStrip cmStrip = (ContextMenuStrip)menuItem.Owner;
                dgPerfPlayers = (AeroDataGrid)cmStrip.SourceControl;
            }

            PlayerPerfData selPlayer = null;
            if (o.GetType() == typeof(DataGridViewCellEventArgs))
            {
                DataGridViewCellEventArgs e = (DataGridViewCellEventArgs)o;
                selPlayer = (PlayerPerfData)dgPerfPlayers.Rows[e.RowIndex].DataBoundItem;
            }
            else if (o.GetType() == typeof(EventArgs))
            {
                selPlayer = (PlayerPerfData)dgPerfPlayers.SelectedRows[0].DataBoundItem;
            }

            return "http://trophymanager.com/players/" + selPlayer.PlayerID + "/";
        }

        private void toolStripLabel6_DoubleClick(object sender, EventArgs e)
        {
            string arg = "http://trophymanager.com/club/2925434/";

            ProcessStartInfo startInfo = new ProcessStartInfo(arg);
            Process.Start(startInfo);
        }

        private void openPlayerPageInTheInternalBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabBrowser;

            AeroDataGrid dgGiocatori = null;

            if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
                ContextMenuStrip cmStrip = (ContextMenuStrip)menuItem.Owner;
                dgGiocatori = (AeroDataGrid)cmStrip.SourceControl;
            }

            int playerID; 
            if (dgGiocatori == dataGridPortieri)
            {
                DataRowView drv = (DataRowView)dgGiocatori.SelectedRows[0].DataBoundItem;
                ExtTMDataSet.GiocatoriNSkillRow selPlayer = (ExtTMDataSet.GiocatoriNSkillRow)drv.Row;
                playerID = selPlayer.PlayerID;
            }
            else
            {
                if (dgGiocatori.SelectedRows[0].DataBoundItem.GetType() == typeof(DataRowView))
                {
                    DataRowView drv = (DataRowView)dgGiocatori.SelectedRows[0].DataBoundItem;
                    ExtraDS.GiocatoriRow selPlayer = (ExtraDS.GiocatoriRow)drv.Row;
                    playerID = selPlayer.PlayerID;
                }
                else
                {
                    ExtTMDataSet.GiocatoriNSkillRow selPlayer = (ExtTMDataSet.GiocatoriNSkillRow)dgGiocatori.SelectedRows[0].DataBoundItem;
                    playerID = selPlayer.PlayerID;
                }
            }

            string matchAddr = "http://trophymanager.com/players/" + playerID + "/";

            webBrowser.Goto(matchAddr);
        }

        private void openPlayerPageInAnExternalBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AeroDataGrid dgGiocatori = null;

            if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
                ContextMenuStrip cmStrip = (ContextMenuStrip)menuItem.Owner;
                dgGiocatori = (AeroDataGrid)cmStrip.SourceControl;
            }

            int playerID;
            if (dgGiocatori == dataGridPortieri)
            {
                DataRowView drv = (DataRowView)dgGiocatori.SelectedRows[0].DataBoundItem;
                ExtTMDataSet.GiocatoriNSkillRow selPlayer = (ExtTMDataSet.GiocatoriNSkillRow)drv.Row;
                playerID = selPlayer.PlayerID;
            }
            else
            {
                if (dgGiocatori.SelectedRows[0].DataBoundItem.GetType() == typeof(DataRowView))
                {
                    DataRowView drv = (DataRowView)dgGiocatori.SelectedRows[0].DataBoundItem;
                    ExtraDS.GiocatoriRow selPlayer = (ExtraDS.GiocatoriRow)drv.Row;
                    playerID = selPlayer.PlayerID;
                }
                else
                {
                    ExtTMDataSet.GiocatoriNSkillRow selPlayer = (ExtTMDataSet.GiocatoriNSkillRow)dgGiocatori.SelectedRows[0].DataBoundItem;
                    playerID = selPlayer.PlayerID;
                }
            }

            string matchAddr = "http://trophymanager.com/players/" + playerID + "/";

            Process.Start(matchAddr);
        }

        private void copyMatchDataInPlainTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AeroDataGrid dgPerfPlayers = null;

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            ContextMenuStrip cmStrip = (ContextMenuStrip)menuItem.Owner;
            dgPerfPlayers = (AeroDataGrid)cmStrip.SourceControl;

            PlayerPerfData selPlayer = null;
            selPlayer = (PlayerPerfData)dgPerfPlayers.SelectedRows[0].DataBoundItem;

            string playersMatchData =
                selPlayer.MatchData.Home.ToString() + " " 
                + selPlayer.MatchData.Score.ToString() 
                + " " 
                + selPlayer.MatchData.Away.ToString() + "\t"
                + selPlayer.Name + "\t"
                + selPlayer.Vote + "\t"
                + selPlayer.Rou + "\t"
                + selPlayer.Status + "\t"
                + selPlayer.Rec;

            Clipboard.SetText(playersMatchData);
        }

        private void openPlayerPageInAnExternalBrowserToolStripMenuItem1_Click(object sender, object o)
        {
            tabControl1.SelectedTab = tabBrowser;

            string matchAddress = GetMatchAddress(sender, o);
            Process.Start(matchAddress);
        }

        private void dataGridPlayersInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridPlayersInfo_CellDoubleClick(sender, (object)e);
        }

        private void tsmGotoPlayerPageInBrowser_Click(object sender, DataGridViewCellEventArgs e)
        {
            tsmGotoPlayerPageInBrowser_Click(sender, (object)e);
        }

        private void webBrowser_ImportedContent(string page, string address)
        {
            page = address + "\n" + page;

            if (address == TM_Pages.Players)
                page = "SourceURL:<NewTM - Squad>\n" + page;
            else if (address == TM_Pages.Training)
                page = "SourceURL:<NewTM - TrainingNew>\n" + page;
            else if (address.Contains("/fixtures/club/"))
                page = "SourceURL:<NewTM - Matches>\n" + page;
            else if (address.Contains("/matches/"))
                page = "SourceURL:<NewTM - Kamp>\n" + page;
            else
                return;

            SaveImportedFile(page, address);

            LoadHTMLfile_newPage(page, address);

            UpdateBrowserImportPanel();
        }

        private void LoadHTMLfile_newPage(string page, string navigationAddress, bool specifyDate = false, int importWeek = -1, bool quiet = false)
        {
            if (page.Contains("NewTM - Kamp"))
            {
                page = navigationAddress + "\n" + page;
                AllSeasons.LoadMatch(page, quiet);
                if (!quiet) UpdateLackData();
                isDirty = true;
                AllSeasons.IsDirty = true;
                return;
            }

            if (page.Contains("NewTM - Matches"))
            {
                int cnt = AllSeasons.LoadFixture(page, quiet);

                if (!quiet)
                {
                    string strMsg = "Import complete:\n" + cnt.ToString() + " new matches imported;\n";
                    MessageBox.Show(strMsg, "TmRecorder");
                }

                FillCmbMatchesSquads();

                AllSeasons.IsDirty = true;
                isDirty = true;
                return;
            }

            DateTime dt = DateTime.Now;

            if (!specifyDate)
                dt = DateTime.Now;
            else if (specifyDate && (importWeek == -1))
            {
                if (MessageBox.Show(Current.Language.IsThisFileRelativeToToday, Current.Language.LoadHTMData,
                                    MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    // Select the week number using the form
                    SelectDataDate sdd = new SelectDataDate();
                    if (sdd.ShowDialog() == DialogResult.OK)
                    {
                        dt = sdd.SelectedDate;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                dt = (new TmWeek(importWeek)).ToDate();
            }

            if (page.Contains("NewTM - Scouts"))
            {
                int count = History.ImportScouts(page);

                if (count > 0)
                    isDirty = true;

                MessageBox.Show("Scouts imported: " + count.ToString() + " scout imported");
            }

            if (navigationAddress == TM_Pages.Players)
            {
                string[] stringSeparators = new string[] { "\n\r\n" };
                string[] pages = page.Split(stringSeparators, StringSplitOptions.None);

                if ((pages.Length < 2) && (Program.Setts.PlayerType == 2))
                {
                    try
                    {
                        History.LoadSquad_NewTm(dt, pages[0]);
                        isDirty = true;
                        InvalidateGrids();
                        UpdateShownGrid();
                    }
                    catch (Exception)
                    {

                        string swRelease = "Sw Release:" + Application.ProductName + "(" + Application.ProductVersion + ")";
                        page = "Navigation Address: " + navigationAddress + "\n" + page;

                        string message = "Error retrieving data from the players page";
                        SendFileTo.ErrorReport.SendPage(message, page, Environment.StackTrace, swRelease);
                    }
                }
                else if ((pages.Length < 1) && (Program.Setts.PlayerType != 2))
                {
                    string swRelease = "Sw Release:" + Application.ProductName + "(" + Application.ProductVersion + ")";
                    page = "Navigation Address: " + navigationAddress + "\n" + page;

                    string message = "Error retrieving data from the players page";
                    SendFileTo.ErrorReport.SendPage(message, page, Environment.StackTrace, swRelease);
                }
                else if (Program.Setts.PlayerType == 2)
                {
                    History.LoadSquad_NewTm(dt, pages[0], quiet);
                    History.LoadTraining_NewTM2(dt, pages[1], quiet);
                    isDirty = true;
                    InvalidateGrids();
                    UpdateShownGrid();
                }
                else if (Program.Setts.PlayerType == 1)
                {
                    History.LoadSquad_NewTm(dt, pages[0]);
                    isDirty = true;
                    InvalidateGrids();
                    UpdateShownGrid();
                }
            }

            if (navigationAddress == TM_Pages.Training)
            {
                int count = History.LoadTIfromTrainingNew_NewTM(dt, page);
                isDirty = true;
                MessageBox.Show("Training imported: " + count.ToString() + " players imported");
            }

            History.actualDts = History.LastTeam();

            if (History.actualDts != null)
            {
                dataGridGiocatori.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'A' AND FPn > 0");
                dataGridGiocatoriB.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'B' AND FPn > 0");
                dataGridPortieri.DataSource = History.actualDts.GiocatoriNSkill.Select("FPn = 0");
            }

            isDirty = true;

            SetLastTeam();
        }

    }
}