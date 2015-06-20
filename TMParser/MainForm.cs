using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TMRecorder.Properties;
using System.IO;
using System.Net;
using System.Diagnostics;
using DataGridViewCustomColumns;
using Common;
using Profile;
using Languages;
using NTR_Common;

using System.Reflection;
using mshtml;
using System.Threading;

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
        string navigationAddress = "";
        string startnavigationAddress = "";
        bool importWhenCompleted = false;
        string doctext = "";
        MatchAnalysis matchAnalysisDB = new MatchAnalysis();
        bool thisIsExtraTeam = false;

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

            InitializeComponent();

            InvalidateGrids();

            Program.Setts.Initialize(args);

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

                EnableActionAnalysis();

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

                tsBrowsePlayers.Visible = false;
                tsBrowseMatches.Visible = false;

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

        private void EnableActionAnalysis()
        {
            bool show = (Program.Setts.ShowActions != 0);

            //dgMatches.Columns["Analyzed"].Visible = show;
            dataGridView2.Columns["Analysis"].Visible = show;
            recalculatePlayersStatisticsToolStripMenuItem.Visible = show;
            analyzeMatchToolStripMenuItem.Visible = show;
        }

        private bool LoadData()
        {
            dP[1] = 1;
            sf.UpdateStatusMessage(2, "Loading gains...");
            LoadGains();

            dP[1] = 2;
            sf.UpdateStatusMessage(3, "Loading match types...");
            LoadMatchTypes();

            dP[1] = 3;
            sf.UpdateStatusMessage(5, "Loading History...");
            bool res = LoadHistory();

            dP[1] = 4;
            sf.UpdateStatusMessage(90, "Loading Matches...");
            LoadMatches();

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

        private void LoadMatchTypes()
        {
        }

        private void LoadMatches()
        {
            FileInfo fi = new FileInfo(Program.Setts.MatchAnalysisFile);
            if (fi.Exists)
                matchAnalysisDB.ReadXml(Program.Setts.MatchAnalysisFile);

            this.chkSquadMain.CheckedChanged -= new System.EventHandler(this.chkUpdateMatckList);
            this.chkSquadReserves.CheckedChanged -= new System.EventHandler(this.chkUpdateMatckList);

            if (Program.Setts.TeamMatchesShowMatches == 0)
            {
                chkSquadMain.Checked = false;
                chkSquadReserves.Checked = false;
            }
            else if (Program.Setts.TeamMatchesShowMatches == 1)
            {
                chkSquadMain.Checked = true;
                chkSquadReserves.Checked = false;
            }
            else
            {
                chkSquadMain.Checked = false;
                chkSquadReserves.Checked = true;
            }

            this.chkSquadMain.CheckedChanged += new System.EventHandler(this.chkUpdateMatckList);
            this.chkSquadReserves.CheckedChanged += new System.EventHandler(this.chkUpdateMatckList);

            string matchFilePath = Path.Combine(Program.Setts.DefaultDirectory, Program.Setts.MatchesFileName);

            fi = new FileInfo(matchFilePath);
            if (fi.Exists)
            {
                this.champDS.Match.Clear();
                this.champDS.PlyStats.Clear();
                //this.champDS.Clear();
                this.champDS.Match.BeginLoadData();
                this.champDS.PlyStats.BeginLoadData();
                this.champDS.ReadXml(matchFilePath);
                this.champDS.Match.EndLoadData();
                this.champDS.PlyStats.EndLoadData();

                this.champDS.TeamID = Program.Setts.MainSquadID;
                this.champDS.ReservesID = Program.Setts.ReserveSquadID;

                this.champDS.UpdateSeason(cmbSeason);
            }

            foreach (ChampDS.MatchRow row in champDS.Match)
            {
                if (row.IsisReservesNull())
                    row.isReserves = 0;
            }

            if ((champDS.Match.Count > 0) && (champDS.PlyStats.Count == 0))
            {
                reloadPlayersMatchStatsToolStripMenuItem_Click(null, EventArgs.Empty);
            }

            champDS.isDirty = false;
        }

        private void LoadReportAnalysisSetts()
        {
            FileInfo fi = new FileInfo(Program.Setts.ReportAnalysisFile);

            reportAnalysis.Clear();
            if (fi.Exists)
                reportAnalysis.ReadXml(Program.Setts.ReportAnalysisFile);
        }

        private void LoadHTMLfile(string page)
        {
            if (page.Contains("TM - Kamp"))
            {
                LoadKampFromHTMLcode(page);
                UpdateLackData();
                isDirty = true;
                return;
            }

            page = page.Replace("'", "");
            page = page.Replace('"', '\'');
            page = page.Replace("'>", ">");
            page = page.Replace("&#39;", "'");

            if (page.Contains("TM - Matches"))
            {
                LoadMatchesFromHTMLcode(page);
                isDirty = true;
                return;
            }

            DateTime dt = DateTime.Today;

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

            if (page.Contains("TM - Squad"))
            {
                History.LoadSquad(dt, page);
                isDirty = true;
            }
            else if (page.Contains("TM - Training_new"))
            {
                if (Program.Setts.PlayerType == 1)
                {
                    History.LoadTrainingNew(dt, page, dbTrainers);
                    isDirty = true;
                }
                else
                {
                    History.LoadTIfromTrainingNew(dt, page);
                    isDirty = true;
                }
            }
            else if (page.Contains("TM - Training"))
            {
                if (Program.Setts.PlayerType == 2)
                {
                    History.LoadTraining(dt, page, dbTrainers);
                    isDirty = true;
                }
                else
                {
                    MessageBox.Show(Current.Language.NonPROUsersMustPasteTheTrainingRegimesAllenamentoPage);
                    return;
                }
            }

            History.actualDts = History.LastTeam();

            if (History.actualDts != null)
            {
                dataGridGiocatori.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'A'");
                dataGridGiocatoriB.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'B'");
                dataGridPortieri.DataSource = History.actualDts.PortieriNSkill;
            }

            isDirty = true;

            SetLastTeam();
        }

        private int LoadMatchesFromHTMLcode_NewTM(string text)
        {
            string str = "l,c,f,fl,i";
            int cnt = 0;

            champDS.TeamID = Program.Setts.MainSquadID;
            champDS.ReservesID = Program.Setts.ReserveSquadID;
            cnt = champDS.LoadSeasonFile_NewTM(text, ref str, Program.Setts.DebugFunction,
                Program.Setts.ApplicationFolder);

            if (str == "") // Il programma si è accorto che le definizioni dei match types sono sbagliate
            {
                opzioniToolStripMenuItem1_Click(null, EventArgs.Empty);
                return cnt;
            }

            Program.Setts.MatchTypes = str;

            Program.Setts.Save();

            LoadMatchTypes();

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

            if (text.Contains("var week"))
                cnt = champDS.LoadSeasonFileFlash(text, ref str, Program.Setts.DebugFunction,
                    Program.Setts.ApplicationFolder);
            else
                champDS.LoadSeasonFileNonFlash(text, ref str);

            if (str == "") // Il programma si è accorto che le definizioni dei match types sono sbagliate
            {
                opzioniToolStripMenuItem1_Click(null, EventArgs.Empty);
                return cnt;
            }

            Program.Setts.MatchTypes = str;

            Program.Setts.Save();

            LoadMatchTypes();

            return cnt;
        }

        private void caricaFileSquadraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = Program.Setts.SquadFilename;
            openFileDialog.Filter = "HTML file (*.htm;*.html)|*.htm;*.html|All Files (*.*)|*.*";

            DateTime dt = DateTime.Today;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader file = new StreamReader(openFileDialog.FileName);
                string page = file.ReadToEnd();
                file.Close();

                if (Program.Setts.UseOldHTMLImportStyle)
                {
                    if ((!page.Contains("TM - Squad")) &&
                        (!page.Contains("TM - Kamp")) &&
                        (!page.Contains("TM - Training")) &&
                        (!page.Contains("TM - Matches")) &&
                        (!page.Contains("TM - Training_new")))
                    {
                        MessageBox.Show(Current.Language.TheClipboardDoesnTContainSquadTrainingOrMatchData +
                            Current.Language.ToUseThisMenuItemYouMustCopyTheContentOfThePageThatOpensWhenYou,
                            Current.Language.PasteFromClipboard, MessageBoxButtons.OK);
                        return;
                    }

                    LoadHTMLfile(page);
                }
                else
                {
                    if (page.Contains("players_ar"))
                    {
                        page = "TM - Squad\n" + page;
                    }

                    if ((!page.Contains("TM - Squad")) &&
                        (!page.Contains("TM - Kamp")) &&
                        (!page.Contains("TM - Training")) &&
                        (!page.Contains("TM - Matches")) &&
                        (!page.Contains("TM - Training_new")) &&
                        (!startnavigationAddress.Contains("showprofile.php?playerid=")) &&
                        (!page.Contains("TM - Staff_trainers")))
                    {
                        MessageBox.Show(Current.Language.TheClipboardDoesnTContainSquadTrainingOrMatchData +
                            Current.Language.ToUseThisMenuItemYouMustCopyTheContentOfThePageThatOpensWhenYou,
                            Current.Language.PasteFromClipboard, MessageBoxButtons.OK);
                        return;
                    }

                    LoadHTMLfile_newPage(page, true);
                }

                Program.Setts.SquadFilename = openFileDialog.FileName;
                Program.Setts.Save();
            }
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

        private void salvaComeXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            History.Save(Program.Setts.DefaultDirectory);
            isDirty = false;

            if (champDS.isDirty)
            {
                string matchFilePath = Path.Combine(Program.Setts.DefaultDirectory, Program.Setts.MatchesFileName);
                champDS.WriteXml(matchFilePath);
                champDS.isDirty = false;
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

                champDS.ReservesID = of.ReserveSquadID;

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

            if (champDS.isDirty)
            {
                DialogResult res = MessageBox.Show(Current.Language.SaveMatchesDataBeforeExit, "Team Recorder", MessageBoxButtons.YesNo);

                if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }

                if (res == DialogResult.Yes)
                {
                    string matchFilePath = Path.Combine(Program.Setts.DefaultDirectory, Program.Setts.MatchesFileName);
                    champDS.WriteXml(matchFilePath);
                    champDS.isDirty = false;
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
                dataGridGiocatori.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'A'");
                dataGridGiocatoriB.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'B'");
                dataGridPortieri.DataSource = History.actualDts.PortieriNSkill;
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

            dataGridGiocatori.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'A'");
            dataGridGiocatoriB.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'B'");
            dataGridPortieri.DataSource = History.actualDts.PortieriNSkill;

            if (toolDataList.SelectedIndex == 0) return;

            InvalidateGrids();

            UpdateShownGrid();

            ShowActualPlayers(dt);

            dataGridGiocatori.SetWhen(dt);
            dataGridGiocatoriB.SetWhen(dt);
            dataGridPortieri.SetWhen(dt);
            dataGridPlayersInfo.SetWhen(dt);

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

        private void EvidenceSkillsPortieriForQuality(int plID)
        {
            for (int i = 0; i < dataGridPortieri.Rows.Count; i++)
            {
                if (plID != -1)
                {
                    System.Windows.Forms.DataGridViewRow dvr = dataGridPortieri.Rows[i];
                    DataRowView drv = (DataRowView)dvr.DataBoundItem;
                    ExtTMDataSet.PortieriNSkillRow gsr = (ExtTMDataSet.PortieriNSkillRow)drv.Row;

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

                    SelectGainColor(gains[j], Style);

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

                    SelectGainColor(History.GD.K_GK(j) / 1.5f, Style);

                    dataGridPortieri[j + 6, i].Style = Style;
                }
            }
        }

        private void SelectGainColor(float f, DataGridViewCellStyle Style)
        {
            float grade = (float)(f * 10f);

            if (grade < 15)
                Style.BackColor = Color.FromArgb(255, 255, 255);
            else if (grade < 32)
                Style.BackColor = Color.FromArgb(255, 255, 192);
            else if (grade < 60)
                Style.BackColor = Color.FromArgb(255, 255, 0);
            else if (grade < 75)
                Style.BackColor = Color.FromArgb(255, 192, 0);
            else if (grade < 90)
                Style.BackColor = Color.FromArgb(255, 128, 0);
            else
                Style.BackColor = Color.FromArgb(255, 0, 0);

            Style.SelectionBackColor = Style.BackColor;

            Style.ForeColor = Color.Black;
            Style.SelectionForeColor = Color.Blue;
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

                ExtTMDataSet.GKHistoryDataTable table = History.GetGKHistory(ID);

                // Find the index corresponding to datetime
                int ix = 0;
                for (; ix < table.Rows.Count; ix++)
                {
                    ExtTMDataSet.GKHistoryRow gk = (ExtTMDataSet.GKHistoryRow)table.Rows[ix];
                    if (gk.Date == dt) break;
                }

                TmWeek tmwActual = new TmWeek(dt);

                if (ix == table.Rows.Count) continue;
                if (ix == 0) continue;

                int ixlast = ix;
                for (; ixlast >= 0; ixlast--)
                {
                    ExtTMDataSet.GKHistoryRow gk = (ExtTMDataSet.GKHistoryRow)table.Rows[ixlast];
                    TmWeek tmwLast = new TmWeek(gk.Date);
                    if (tmwLast.absweek < tmwActual.absweek) break;
                }

                if (ixlast < 0) continue;

                ExtTMDataSet.GKHistoryRow actual = (ExtTMDataSet.GKHistoryRow)table.Rows[ix];
                ExtTMDataSet.GKHistoryRow last = (ExtTMDataSet.GKHistoryRow)table.Rows[ixlast];

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

                ExtTMDataSet.GKHistoryDataTable table = History.GetGKHistory(ID);

                // Find the index corresponding to datetime
                int ix = 0;
                for (; ix < table.Rows.Count; ix++)
                {
                    ExtTMDataSet.GKHistoryRow gk = (ExtTMDataSet.GKHistoryRow)table.Rows[ix];
                    if (gk.Date == dt) break;
                }

                if (ix == table.Rows.Count) continue;
                if (ix == 0) continue;

                ExtTMDataSet.GKHistoryRow actual = (ExtTMDataSet.GKHistoryRow)table.Rows[ix];
                ExtTMDataSet.GKHistoryRow last = (ExtTMDataSet.GKHistoryRow)table.Rows[ix - 1];

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
                    if (pl.Date == dt) break;
                }

                TmWeek tmwActual = new TmWeek(dt);

                if (ix == table.Rows.Count) continue;
                if (ix == 0) continue;

                int ixlast = ix;
                for (; ixlast >= 0; ixlast--)
                {
                    ExtTMDataSet.PlayerHistoryRow pl = (ExtTMDataSet.PlayerHistoryRow)table.Rows[ixlast];
                    TmWeek tmwLast = new TmWeek(pl.Date);
                    if (tmwLast.absweek < tmwActual.absweek) break;
                }

                if (ixlast < 0) continue;

                ExtTMDataSet.PlayerHistoryRow actual = (ExtTMDataSet.PlayerHistoryRow)table.Rows[ix];
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
                EvidenceDiffForColumn(dgv, actual.Tir, last.Tir, i, 20);
                EvidenceDiffForColumn(dgv, actual.Cal, last.Cal, i, 21);
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
                    dataGridGiocatori.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'A'");
                    dataGridGiocatoriB.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'B'");
                    dataGridPortieri.DataSource = History.actualDts.PortieriNSkill;
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

            GKForm pf = new GKForm(History.actualDts.PortieriNSkill, History, ID, champDS.PlyStats);

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

        private void dataGridPlayersInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridView dgv = (DataGridView)sender;

            int ID = (int)dgv[0, e.RowIndex].Value;

            if (History.actualDts.GiocatoriNSkill.FindByPlayerID(ID) != null)
            {
                PlayerForm pf = new PlayerForm(History.actualDts.GiocatoriNSkill, History, ID, champDS.PlyStats);

                pf.ShowDialog();

                if (pf.isDirty) isDirty = true;
            }
            else
            {
                GKForm pf = new GKForm(History.actualDts.PortieriNSkill, History, ID, champDS.PlyStats);

                pf.ShowDialog();

                if (pf.isDirty) isDirty = true;
            }

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

            if (dataGridPlayersInfo.RowCount == 0)
                return;
            dataGridPlayersInfo.CurrentCell = dataGridPlayersInfo[2, e.RowIndex];
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
                dataGridGiocatori.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'A'");
                dataGridGiocatoriB.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'B'");
                dataGridPortieri.DataSource = History.actualDts.PortieriNSkill;
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

            dataGridGiocatori.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'A'");
            dataGridGiocatoriB.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'B'");

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

            dataGridGiocatori.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'A'");
            dataGridGiocatoriB.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'B'");

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
                dataGridGiocatori.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'A'", property);
            }
            else
            {
                dataGridGiocatoriB.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'B'", property);
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

            System.Data.DataRowView selMatch = (System.Data.DataRowView)dgMatches.SelectedRows[0].DataBoundItem;
            ChampDS.MatchRow matchRow = (ChampDS.MatchRow)selMatch.Row;

            string matchAddr = "http://trophymanager.com/matches/" + matchRow.MatchID + "/";

            navigationAddress = matchAddr;
            startnavigationAddress = navigationAddress;
            webBrowser.Navigate(navigationAddress);
        }

        public void LoadKampFromHTMLcode_NewTM(string page)
        {
            ChampDS.MatchRow matchRow = null;

            try
            {
                if (page.Contains("http://trophymanager.com/matches/"))
                {
                    string kampid = HTML_Parser.GetNumberAfter(page, "http://trophymanager.com/matches/");
                    matchRow = champDS.Match.FindByMatchID(int.Parse(kampid));

                    if (matchRow == null)
                    {
                        MessageBox.Show("The match has not been found in your list of matches, so you cannot download it\n" +
                            "Please update the matches list",
                            "Loading match");
                        return;
                    }
                }
                else
                {
                    if (dgMatches.SelectedRows.Count == 0) return;

                    System.Data.DataRowView selMatch = (System.Data.DataRowView)dgMatches.SelectedRows[0].DataBoundItem;
                    matchRow = (ChampDS.MatchRow)selMatch.Row;
                }
            }
            catch (Exception ex)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";
                SendFileTo.ErrorReport.Send(ex, page, Environment.StackTrace, swRelease);
                MessageBox.Show(Current.Language.SorryTheImportingProcessHasFailedIfYouClickedOkTheInfoOfTheErrorHave +
                    Current.Language.BeenSentToLedLennonThatWillRemoveThisBugAsSoonAsPossible);

                return;
            }

            try
            {
                if ((!matchRow.IsOppsClubIDNull()) && (page.Contains(matchRow.OppsClubID.ToString())))
                {
                    if (matchDS.Analyze_NewTM(page, ref matchRow))
                    {
                        Program.Setts.ClubNickname = matchDS.clubNick;
                        Program.Setts.Save();

                        // Read always the action analysis file
                        actionAnalysis.Clear();

                        FileInfo fi = new FileInfo(Program.Setts.ActionAnalysisFile);

                        matchRow.Report = true;

                        if (fi.Exists)
                        {
                            actionAnalysis.ReadXml(fi.FullName);

                            ActionList al = actionAnalysis.Analyze(matchDS,
                                                    ref matchRow);

                            foreach (ActionItem ai in al)
                            {
                                ChampDS.PlyStatsRow psr = champDS.PlyStats.FindByPlayerIDSeasonIDTypeStats(ai.playerID,
                                    TmWeek.GetSeason(matchRow.Date),
                                    matchRow.MatchType);

                                MatchDS.YourTeamPerfRow ytpr = matchDS.YourTeamPerf.FindByPlayerID(ai.playerID);
                                if (ytpr != null)
                                {
                                    ytpr.Analysis = ai.actions;
                                }

                                MatchDS.OppsTeamPerfRow otpr = matchDS.OppsTeamPerf.FindByPlayerID(ai.playerID);
                                if (otpr != null)
                                {
                                    otpr.Analysis = ai.actions;
                                }

                                if (psr == null) continue;

                                if (ai.actions != "")
                                    psr.SetAnalysis(matchRow.Date, ai.actions);

                                psr.SetVote(matchRow.Date, ytpr.Vote, ytpr.Position, matchDS.MeanVote);

                                if (ytpr != null)
                                {
                                    champDS.PlyStats.RefreshPlayerStats(
                                        ai.playerID,
                                        matchRow.MatchType,
                                        TmWeek.GetSeason(matchRow.Date));
                                }
                            }
                        }
                        else
                        {
                            foreach (MatchDS.YourTeamPerfRow ypr in matchDS.YourTeamPerf)
                            {
                                ChampDS.PlyStatsRow psr = champDS.PlyStats.FindByPlayerIDSeasonIDTypeStats(ypr.PlayerID,
                                    TmWeek.GetSeason(matchRow.Date),
                                    matchRow.MatchType);

                                if (ypr.IsNumberNull())
                                    continue;

                                if (psr == null)
                                {
                                    psr = champDS.PlyStats.NewPlyStatsRow();
                                    psr.SeasonID = TmWeek.GetSeason(matchRow.Date);
                                    psr.TypeStats = matchRow.MatchType;
                                    psr.PlayerID = ypr.PlayerID;

                                    champDS.PlyStats.AddPlyStatsRow(psr);
                                }

                                if ((ypr.Scored > 0) || (ypr.Assist > 0))
                                {
                                    string plActions = "";
                                    if (ypr.Scored > 0)
                                        plActions += ypr.Scored.ToString() + "gg,";
                                    if (ypr.Assist > 0)
                                        plActions += ypr.Assist.ToString() + "aa,";
                                    plActions = plActions.Trim(',');

                                    psr.SetAnalysis(matchRow.Date, plActions);
                                }

                                if (ypr.IsVoteNull())
                                    continue;

                                psr.SetVote(matchRow.Date, ypr.Vote, ypr.Position, matchDS.MeanVote);

                                champDS.PlyStats.RefreshPlayerStats(
                                    ypr.PlayerID,
                                    matchRow.MatchType,
                                    TmWeek.GetSeason(matchRow.Date));
                            }
                        }
                    }

                    matchDS.WriteXml(Path.Combine(Program.Setts.DefaultDirectory, "Match_" + matchRow.MatchID + ".xml"));

                    dgMatches_SelectionChanged(null, EventArgs.Empty);

                    champDS.isDirty = true;
                }
                else
                {
                    dgMatches.ClearSelection();

                    MessageBox.Show(Current.Language.PleaseSelectInTheTableTheMatchRowYouArePasting);
                }
            }
            catch (Exception e)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";
                SendFileTo.ErrorReport.Send(e, page, Environment.StackTrace, swRelease);
                MessageBox.Show(Current.Language.SorryTheImportingProcessHasFailedIfYouClickedOkTheInfoOfTheErrorHave +
                    Current.Language.BeenSentToLedLennonThatWillRemoveThisBugAsSoonAsPossible);
            }
        }

        public void LoadKampFromHTMLcode(string page)
        {
            ChampDS.MatchRow matchRow = null;

            try
            {
                if (page.Contains("kampid="))
                {
                    string kampid = HTML_Parser.GetNumberAfter(page, "kampid=");
                    matchRow = champDS.Match.FindByMatchID(int.Parse(kampid));

                    if (matchRow == null)
                    {
                        MessageBox.Show("The match has not been found in your list of matches, so you cannot download it\n" +
                            "Please update the matches list",
                            "Loading match");
                        return;
                    }
                }
                else
                {
                    if (dgMatches.SelectedRows.Count == 0) return;

                    System.Data.DataRowView selMatch = (System.Data.DataRowView)dgMatches.SelectedRows[0].DataBoundItem;
                    matchRow = (ChampDS.MatchRow)selMatch.Row;
                }
            }
            catch (Exception ex)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";
                SendFileTo.ErrorReport.Send(ex, page, Environment.StackTrace, swRelease);
                MessageBox.Show(Current.Language.SorryTheImportingProcessHasFailedIfYouClickedOkTheInfoOfTheErrorHave +
                    Current.Language.BeenSentToLedLennonThatWillRemoveThisBugAsSoonAsPossible);

                return;
            }

            try
            {
                if (!page.Contains("me_micro.gif"))
                {
                    MessageBox.Show("The page you are importing seems not to be valid. Please repeat import");
                    return;
                }

                if ((!matchRow.IsOppsClubIDNull()) && (page.Contains(matchRow.OppsClubID.ToString())))
                {
                    if (matchDS.Analyze(page, ref matchRow))
                    {
                        Program.Setts.ClubNickname = matchDS.clubNick;
                        Program.Setts.Save();

                        // Read always the action analysis file
                        actionAnalysis.Clear();

                        FileInfo fi = new FileInfo(Program.Setts.ActionAnalysisFile);

                        matchRow.Report = true;

                        if (fi.Exists)
                        {
                            actionAnalysis.ReadXml(fi.FullName);

                            ActionList al = actionAnalysis.Analyze(matchDS,
                                                    ref matchRow);

                            foreach (ActionItem ai in al)
                            {
                                ChampDS.PlyStatsRow psr = champDS.PlyStats.FindByPlayerIDSeasonIDTypeStats(ai.playerID,
                                    TmWeek.GetSeason(matchRow.Date),
                                    matchRow.MatchType);

                                MatchDS.YourTeamPerfRow ytpr = matchDS.YourTeamPerf.FindByPlayerID(ai.playerID);
                                if (ytpr != null)
                                {
                                    ytpr.Analysis = ai.actions;
                                }

                                MatchDS.OppsTeamPerfRow otpr = matchDS.OppsTeamPerf.FindByPlayerID(ai.playerID);
                                if (otpr != null)
                                {
                                    otpr.Analysis = ai.actions;
                                }

                                if (psr == null) continue;

                                if (ai.actions != "")
                                    psr.SetAnalysis(matchRow.Date, ai.actions);

                                psr.SetVote(matchRow.Date, ytpr.Vote, ytpr.Position, matchDS.MeanVote);

                                if (ytpr != null)
                                {
                                    champDS.PlyStats.RefreshPlayerStats(
                                        ai.playerID,
                                        matchRow.MatchType,
                                        TmWeek.GetSeason(matchRow.Date));
                                }
                            }
                        }
                        else
                        {
                            foreach (MatchDS.YourTeamPerfRow ypr in matchDS.YourTeamPerf)
                            {
                                ChampDS.PlyStatsRow psr = champDS.PlyStats.FindByPlayerIDSeasonIDTypeStats(ypr.PlayerID,
                                    TmWeek.GetSeason(matchRow.Date),
                                    matchRow.MatchType);

                                if (ypr.IsNumberNull())
                                    continue;

                                if (psr == null)
                                {
                                    psr = champDS.PlyStats.NewPlyStatsRow();
                                    psr.SeasonID = TmWeek.GetSeason(matchRow.Date);
                                    psr.TypeStats = matchRow.MatchType;
                                    psr.PlayerID = ypr.PlayerID;

                                    champDS.PlyStats.AddPlyStatsRow(psr);
                                }

                                if ((ypr.Scored > 0) || (ypr.Assist > 0))
                                {
                                    string plActions = "";
                                    if (ypr.Scored > 0)
                                        plActions += ypr.Scored.ToString() + "gg,";
                                    if (ypr.Assist > 0)
                                        plActions += ypr.Assist.ToString() + "aa,";
                                    plActions = plActions.Trim(',');

                                    psr.SetAnalysis(matchRow.Date, plActions);
                                }

                                if (ypr.IsVoteNull())
                                    continue;

                                psr.SetVote(matchRow.Date, ypr.Vote, ypr.Position, matchDS.MeanVote);

                                champDS.PlyStats.RefreshPlayerStats(
                                    ypr.PlayerID,
                                    matchRow.MatchType,
                                    TmWeek.GetSeason(matchRow.Date));
                            }
                        }
                    }

                    matchDS.WriteXml(Path.Combine(Program.Setts.DefaultDirectory, "Match_" + matchRow.MatchID + ".xml"));

                    dgMatches_SelectionChanged(null, EventArgs.Empty);

                    champDS.isDirty = true;
                }
                else
                {
                    dgMatches.ClearSelection();

                    MessageBox.Show(Current.Language.PleaseSelectInTheTableTheMatchRowYouArePasting);
                }
            }
            catch (Exception e)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";
                SendFileTo.ErrorReport.Send(e, page, Environment.StackTrace, swRelease);
                MessageBox.Show(Current.Language.SorryTheImportingProcessHasFailedIfYouClickedOkTheInfoOfTheErrorHave +
                    Current.Language.BeenSentToLedLennonThatWillRemoveThisBugAsSoonAsPossible);
            }
        }

        private void dgMatches_SelectionChanged(object sender, EventArgs e)
        {
            if (dgMatches.SelectedRows.Count == 0) return;

            System.Data.DataRowView selMatch = (System.Data.DataRowView)dgMatches.SelectedRows[0].DataBoundItem;
            ChampDS.MatchRow matchRow = (ChampDS.MatchRow)selMatch.Row;

            FileInfo fi = new FileInfo(Path.Combine(Program.Setts.DefaultDirectory, "Match_" + matchRow.MatchID + ".xml"));

            if (!fi.Exists)
            {
                matchRow.Report = false;
                matchDS.Clear();
                matchStats.MatchRow = null;

                champDS.isDirty = true;

                return;
            }

            matchStats.MatchRow = matchRow;

            matchDS.Clear();
            matchDS.ReadXml(Path.Combine(Program.Setts.DefaultDirectory, "Match_" + matchRow.MatchID + ".xml"));

            matchRow.Report = true;

            // Filling your formation
            Formation yf = new Formation(eFormationTypes.Type_Empty);
            foreach (MatchDS.YourTeamPerfRow row in matchDS.YourTeamPerf)
            {
                Player pl = yf.SetPlayer(row);
            }

            yourTeamLineup.formation = yf;

            Formation of = new Formation(eFormationTypes.Type_Empty);
            foreach (MatchDS.OppsTeamPerfRow row in matchDS.OppsTeamPerf)
            {
                Player pl = of.SetPlayer(row);
            }

            oppsTeamLineup.formation = of;


            if (!matchRow.IsInitDesciptionNull())
                txtMatchStart.Text = matchRow.InitDesciption;

            champDS.isDirty = true;
        }

        private void reloadPlayersMatchStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MatchDS mds = null;
            bool catched = false;

            DirectoryInfo di = new DirectoryInfo(Program.Setts.DefaultDirectory);
            if (!di.Exists) return;

            champDS.PlyStats.Clear();

            foreach (FileInfo fi in di.GetFiles("Match_*.xml"))
            {
                try
                {
                    mds = new MatchDS();

                    mds.ReadXml(fi.FullName);

                    ChampDS.MatchRow mr = champDS.Match.FindByMatchID(mds.MatchData[0].MatchID);

                    champDS.PlyStats.AddPlayerStats(mr, mds, Program.Setts.ClubNickname);

                }
                catch (Exception ex)
                {
                    if (catched) continue;
                    catched = true;

                    if (MessageBox.Show("Cannot import this page here. Here you can import only player profiles.\n" +
                        "Pressing OK, you send a report to Atletico Granata that will try to detect the reason of the error.",
                        "Import error", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        string swRelease = "Sw Release:" + Application.ProductName + "("
                           + Application.ProductVersion + ")";
                        string info = "";

                        string tempFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                        tempFolder = Path.Combine(tempFolder, "TmRecorder");

                        string pathfilename = Path.Combine(tempFolder, "tempFile.txt");
                        FileInfo fin = new FileInfo(pathfilename);

                        champDS.WriteXml(fin.FullName);
                        StreamReader file = new StreamReader(fi.FullName);
                        info += "ChampDS:\r\n" + file.ReadToEnd();
                        file.Close();

                        mds.WriteXml(fin.FullName);
                        file = new StreamReader(fin.FullName);
                        info += "MatchDS:\r\n" + file.ReadToEnd();
                        file.Close();

                        SendFileTo.ErrorReport.Send(ex, info, Environment.StackTrace, swRelease);
                    }
                }
            }

            UpdateLackData();

            champDS.isDirty = true;
        }

        private void UpdateLackData()
        {
            foreach (ChampDS.PlyStatsRow psr in champDS.PlyStats)
            {
                if (psr.IsNomeNull())
                {
                    ExtraDS.GiocatoriRow gr = extraDS.FindByPlayerID(psr.PlayerID);

                    if (gr != null)
                        psr.Nome = extraDS.FindByPlayerID(psr.PlayerID).Nome;
                }
            }
        }

        private void chkUpdateMatckList(object sender, EventArgs e)
        {
            string filter = "";

            if (chkMT1.Checked)
                filter = "(MatchType=0) OR (MatchType=5)";

            if (chkMT2.Checked)
            {
                if (filter != "") filter += " OR ";
                filter += "(MatchType>10) AND (MatchType<20)";
            }

            if (chkMT3.Checked)
            {
                if (filter != "") filter += " OR ";
                filter += "(MatchType=2)";
            }

            if (chkMT4.Checked)
            {
                if (filter != "") filter += " OR ";
                filter += "(MatchType=3)";
            }

            if (chkMT5.Checked)
            {
                if (filter != "") filter += " OR ";
                filter += "(MatchType>20)";
            }

            if ((chkHome.Checked) && (!chkAway.Checked))
            {
                if (filter != "") filter = "(" + filter + ") AND ";
                filter += "(isHome=True)";
            }

            if ((!chkHome.Checked) && (chkAway.Checked))
            {
                if (filter != "") filter = "(" + filter + ") AND ";
                filter += "(isHome=False)";
            }

            if ((!chkSquadMain.Checked) && (chkSquadReserves.Checked))
            {
                if (filter != "") filter = "(" + filter + ") AND ";
                filter += "(isReserves=1)";
            }

            if ((chkSquadMain.Checked) && (!chkSquadReserves.Checked))
            {
                if (filter != "") filter = "(" + filter + ") AND ";
                filter += "(isReserves=0)";
            }

            DateTime dt0 = TmWeek.GetDateTimeOfSeasonStart((int)cmbSeason.SelectedItem);
            DateTime dt1 = TmWeek.GetDateTimeOfSeasonStart((int)cmbSeason.SelectedItem + 1);
            {
                if (filter != "") filter = "(" + filter + ") AND ";
                filter += "(Date>='" + dt0.ToShortDateString() + "')"
                + " AND (Date<'" + dt1.ToShortDateString() + "')";
            }

            // filter += chkFr.Checked ? "(MatchType=0)" : "";
            matchBindingSource.Filter = filter;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Current.Language.FirstOfAllOpenTheCalendarPageOfYourTeamUsingTheRelativeButtonOnTheMatchMenu);
        }

        private void playersStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayersStats psf = new PlayersStats(champDS.PlyStats, this.extraDS);

            psf.ShowDialog();
        }

        private void deleteSelectedMatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Data.DataRowView selMatch = (System.Data.DataRowView)dgMatches.SelectedRows[0].DataBoundItem;
            ChampDS.MatchRow matchRow = (ChampDS.MatchRow)selMatch.Row;

            string matchname = matchRow.Home + " " + matchRow.Score.Trim("\r\n\t".ToCharArray()) + " " + matchRow.Away;
            if (MessageBox.Show(Current.Language.AreYouSureThatYouWantToRemoveTheMatch + matchname + "?", Current.Language.DeleteMatch,
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                champDS.Match.RemoveMatchRow(matchRow);
            }

            champDS.UpdateSeason(cmbSeason);
        }

        private void showMatchActionsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MatchActionsList mal = new MatchActionsList();

            mal.actionsDataTableBindingSource.DataSource = matchDS.Actions;

            System.Data.DataRowView selMatch = (System.Data.DataRowView)dgMatches.SelectedRows[0].DataBoundItem;
            ChampDS.MatchRow matchRow = (ChampDS.MatchRow)selMatch.Row;

            mal.Text = matchRow.Home + " " + matchRow.Score.Trim("\r\n\t".ToCharArray()) + " " + matchRow.Away;

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
            MatchOnField mof = new MatchOnField(this.champDS, this.extraDS, this.History);
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

        private void analyzeMatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgMatches.SelectedRows.Count == 0) return;

            System.Data.DataRowView selMatch = (System.Data.DataRowView)dgMatches.SelectedRows[0].DataBoundItem;
            ChampDS.MatchRow matchRow = (ChampDS.MatchRow)selMatch.Row;

            // Read always the action analysis file
            actionAnalysis.Clear();
            FileInfo fi = new FileInfo(Path.Combine(Program.Setts.DefaultDirectory,
                    Program.Setts.ActionAnalysisFile));
            if (!fi.Exists)
            {
                MessageBox.Show(Current.Language.TheActionAnalysisFileDoesNotExists +
                    Current.Language.PleaseDownloadItFromTheTmrecorderWebSiteAndThenSelectItFromTheToolsOptionsPanel);
                return;
            }

            actionAnalysis.ReadXml(fi.FullName);

            if (matchRow.Report == false)
            {
                MessageBox.Show(Current.Language.TheMatchHasNotBeenDownloadedFromTrophymanager);
                return;
            }

            if (matchRow.IsYourNickNull() || matchRow.IsOppsNickNull())
            {
                if (MessageBox.Show(Current.Language.TheInformationForThisMatchAreNotCompleteTheNickOfYourAndOppositeTeamHaveNotBeenSavedDoYouWantToSetYourselfTheNick, "Match info not complete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    PropertyEditor ped = new PropertyEditor();
                    editingMatchRow = matchRow;

                    ped.dialogBag.Properties.Add(new PropertySpec("Your Team Nick", typeof(string),
                        "Match Info", "The nick of your team",
                        ""));
                    ped.dialogBag.Properties.Add(new PropertySpec("Opposite Team Nick", typeof(string),
                        "Match Info", "The nick of the opposite team",
                        ""));

                    editingMatchRow.YourNick = "";
                    editingMatchRow.OppsNick = "";

                    ped.dialogBag.GetValue += new PropertySpecEventHandler(dialogBag_GetValue);
                    ped.dialogBag.SetValue += new PropertySpecEventHandler(dialogBag_SetValue);

                    ped.InitializeGrid();

                    ped.ShowDialog();
                }
                else return;
            }

            ActionList al = actionAnalysis.Analyze(matchDS,
                                    ref matchRow);

            foreach (ActionItem ai in al)
            {
                ChampDS.PlyStatsRow psr = champDS.PlyStats.FindByPlayerIDSeasonIDTypeStats(ai.playerID,
                    TmWeek.GetSeason(matchRow.Date),
                    matchRow.MatchType);

                MatchDS.YourTeamPerfRow ytpr = matchDS.YourTeamPerf.FindByPlayerID(ai.playerID);
                if (ytpr != null)
                {
                    ytpr.Analysis = ai.actions;
                }

                MatchDS.OppsTeamPerfRow otpr = matchDS.OppsTeamPerf.FindByPlayerID(ai.playerID);
                if (otpr != null)
                {
                    otpr.Analysis = ai.actions;
                }

                if (psr == null) continue;


                if (ai.actions != "")
                    psr.SetAnalysis(matchRow.Date, ai.actions);

                if (ytpr != null)
                {
                    psr.SetVote(matchRow.Date, ytpr.Vote, ytpr.Position, matchDS.MeanVote);
                    champDS.PlyStats.RefreshPlayerStats(
                        ai.playerID,
                        matchRow.MatchType,
                        TmWeek.GetSeason(matchRow.Date));
                }

                matchDS.WriteXml(Path.Combine(Program.Setts.DefaultDirectory, "Match_" + matchRow.MatchID + ".xml"));

                dgMatches_SelectionChanged(null, EventArgs.Empty);

                champDS.isDirty = true;
            }
        }

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
                "Hidden skills", "Hidden skills (1=Low, 20=High), as resulting from the scouts report",
                plRow.Professionalism));
            ped.dialogBag.Properties.Add(new PropertySpec("Aggressivity", typeof(float),
                "Hidden skills", "Hidden skills (1=Low, 20=High), as resulting from the scouts report",
                plRow.Aggressivity));
            ped.dialogBag.Properties.Add(new PropertySpec("Leadership", typeof(float),
                "Hidden skills", "Hidden skills (1=Low, 20=High), as resulting from the scouts report",
                plRow.Leadership));
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

        private void tsbSquadA_Click(object sender, EventArgs e)
        {
            navigationAddress = "http://trophymanager.com/squad.php";
            startnavigationAddress = navigationAddress;
            webBrowser.Navigate(navigationAddress);
        }

        private void webBrowser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress <= 0)
            {
                if (webBrowser.ReadyState == WebBrowserReadyState.Complete)
                {
                    tsbProgressText.Text = "100%";
                    tsbProgressBar.ForeColor = Color.Green;
                    tsbProgressBar.Value = 100;
                }
                return;
            }

            long maxProgress = e.MaximumProgress;
            if (maxProgress == 0)
                maxProgress = 1;
            int perc = (int)((e.CurrentProgress * 100) / maxProgress);
            if (perc > 100) perc = 100;
            if (perc < 0) perc = 0;
            tsbProgressBar.Value = perc;
            tsbProgressText.Text = perc.ToString() + "%";
            tsbProgressBar.ForeColor = Color.Blue;
        }

        private void webBrowser_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string actualUrl = e.Url.ToString();

            if (actualUrl == "http://trophymanager.com/players/#/a/true/b//")
                actualUrl = "http://trophymanager.com/players/";

            if (actualUrl != startnavigationAddress) return;

            // this.Text = "TMR Browser - Navigation Complete";
            tsbProgressBar.ForeColor = Color.Green;

            if (importWhenCompleted)
            {
                importWhenCompleted = false;
                Thread.Sleep(1000);
                tsbImport_Click(null, EventArgs.Empty);
            }
        }

        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            string url = e.Url.ToString();

            if (url.StartsWith("http://trophymanager.com/buy-pro/") ||
                url.StartsWith("http://trophymanager.com/banners.php"))
                return;

            if (url.StartsWith("http://trophymanager.com/"))
            {
                navigationAddress = e.Url.ToString();

                tbTxtAddress.Text = url;

                startnavigationAddress = navigationAddress;

                //tsBrowseMatches.Visible = false;
                //if (navigationAddress.Contains("showprofile.php?playerid="))
                //{
                //    lastBarPlayer = int.Parse(HTML_Parser.GetNumberAfter(navigationAddress, "playerid="));
                //    ExtraDS.GiocatoriRow gRow = extraDS.FindByPlayerID(lastBarPlayer);
                //    if (gRow == null)
                //    {
                //        tsBrowsePlayers.Visible = false;
                //        return;
                //    }
                //    tsBrowsePlayers.Visible = true;
                //    tsbNumberOfReviews.Text = gRow.ScoutReviews.Length + " Scout Reviews stored";
                //    tsbPlayers.Text = "[" + gRow.FP + "] " + gRow.Nome;
                //    AddMenuItem(tsbPlayers, "", null);
                //    for (int i = 0; i < extraDS.Giocatori.Count; i++)
                //    {
                //        ToolStripItem tsi = new ToolStripMenuItem();
                //        tsi.Text = "[" + extraDS.Giocatori[i].FP + "] " + extraDS.Giocatori[i].Nome;
                //        tsi.Tag = extraDS.Giocatori[i].PlayerID;
                //        tsi.Click += ChangePlayer_Click;
                //        AddMenuItem(tsbPlayers, extraDS.Giocatori[i].FP, tsi);
                //    }
                //}
                //else
                //{
                //    tsBrowsePlayers.Visible = false;
                //}
            }
            else
            {
                if (url != "about:blank")
                    navigationAddress = url;
            }

            tsbProgressBar.Value = 0;
            tsbProgressText.Text = "0%";
            tsbProgressBar.ForeColor = Color.Blue;
        }

        private void UpdateMatchesMenu()
        {
            ChampDS.MatchRow cmr = null;
            string[] matchTypes = Program.Setts.MatchTypes.Split(',');

            AddMenuItem(tsbMatches, "", null);
            int thisSeason = TmWeek.GetSeason(DateTime.Now);

            for (int i = 0; i < champDS.Match.Count; i++)
            {
                cmr = champDS.Match[i];
                if ((cmr.isReserves == 0) && (matchNavigationType == MatchNavigationType.NavigateReserves))
                    continue;
                if ((cmr.isReserves == 1) && (matchNavigationType == MatchNavigationType.NavigateMainTeam))
                    continue;
                if (TmWeek.GetSeason(cmr.Date) != thisSeason)
                    continue;

                ToolStripItem tsi = new ToolStripMenuItem();
                tsi.Text = "[" + matchTypes[cmr.MatchType] + "] " + cmr.Home + " " + cmr.Score + " " + cmr.Away;
                tsi.Tag = cmr.MatchID;
                tsi.Click += ChangeMatch_Click;
                AddMenuItem(tsbMatches, matchTypes[cmr.MatchType], tsi);
            }
        }

        private void AddMenuItem(ToolStripDropDownButton tsb, string FP, ToolStripItem tsi)
        {
            if (tsb == tsbPlayers)
            {
                if (tsi == null)
                {
                    gKToolStripMenuItem.DropDownItems.Clear();
                    dDefendersToolStripMenuItem.DropDownItems.Clear();
                    dMDefenderMidfieldersToolStripMenuItem.DropDownItems.Clear();
                    mMidfieldersToolStripMenuItem.DropDownItems.Clear();
                    oMOffenderMidfieldersToolStripMenuItem.DropDownItems.Clear();
                    fForwardsToolStripMenuItem.DropDownItems.Clear();
                    return;
                }

                string[] fps = FP.Split('/');

                foreach (string fp in fps)
                {
                    ToolStripItem itsi = new ToolStripMenuItem();
                    itsi.Click += ChangePlayer_Click;
                    itsi.Text = tsi.Text;
                    itsi.Tag = tsi.Tag;

                    if (fp == "GK")
                    {
                        gKToolStripMenuItem.DropDownItems.Add(itsi);
                    }
                    if ((fp == "DC") || (fp == "DL") || (fp == "DR"))
                    {
                        if (!FindItemInMenu(dDefendersToolStripMenuItem, itsi.Text))
                            dDefendersToolStripMenuItem.DropDownItems.Add(itsi);
                    }
                    if ((fp == "DMC") || (fp == "DML") || (fp == "DMR"))
                    {
                        if (!FindItemInMenu(dMDefenderMidfieldersToolStripMenuItem, itsi.Text))
                            dMDefenderMidfieldersToolStripMenuItem.DropDownItems.Add(itsi);
                    }
                    if ((fp == "MC") || (fp == "ML") || (fp == "MR"))
                    {
                        if (!FindItemInMenu(mMidfieldersToolStripMenuItem, itsi.Text))
                            mMidfieldersToolStripMenuItem.DropDownItems.Add(itsi);
                    }
                    if ((fp == "OMC") || (fp == "OML") || (fp == "OMR"))
                    {
                        if (!FindItemInMenu(oMOffenderMidfieldersToolStripMenuItem, itsi.Text))
                            oMOffenderMidfieldersToolStripMenuItem.DropDownItems.Add(itsi);
                    }
                    if (fp == "FC")
                    {
                        fForwardsToolStripMenuItem.DropDownItems.Add(itsi);
                    }
                }
            }
            else if (tsb == tsbMatches)
            {
                string[] matchTypes = Program.Setts.MatchTypes.Split(',');
                ToolStripDropDownItem[] tsbMatchesVect = new ToolStripDropDownItem[6];
                tsbMatchesVect[0] = tsbMatches0;
                tsbMatchesVect[1] = tsbMatches1;
                tsbMatchesVect[2] = tsbMatches2;
                tsbMatchesVect[3] = tsbMatches3;
                tsbMatchesVect[4] = tsbMatches4;
                tsbMatchesVect[5] = tsbMatches5;

                if (tsi == null)
                {
                    int i = 0;
                    for (; i < matchTypes.Length; i++)
                    {
                        tsbMatchesVect[i].DropDownItems.Clear();
                        tsbMatchesVect[i].Visible = true;
                        tsbMatchesVect[i].Text = "[" + matchTypes[i] + "] Matches";
                    }
                    for (; i < tsbMatchesVect.Length; i++)
                    {
                        tsbMatchesVect[i].Visible = false;
                    }
                    return;
                }

                ToolStripItem itsi = new ToolStripMenuItem();
                itsi.Click += ChangeMatch_Click;
                itsi.Text = tsi.Text;
                itsi.Tag = tsi.Tag;

                for (int i = 0; i < matchTypes.Length; i++)
                {
                    if (FP == matchTypes[i])
                    {
                        tsbMatchesVect[i].DropDownItems.Add(itsi);
                        break;
                    }
                }
            }
        }

        private bool FindItemInMenu(ToolStripMenuItem menu, string text)
        {
            bool found = false;
            foreach (ToolStripItem ftsi in menu.DropDownItems)
            {
                if (ftsi.Text == text)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        private void tsbSquadB_Click(object sender, EventArgs e)
        {
            navigationAddress = "http://trophymanager.com/squad.php?reserves";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
        }

        private void tsbTraining_Click(object sender, EventArgs e)
        {
            navigationAddress = "http://trophymanager.com/training/";
            startnavigationAddress = navigationAddress;
            webBrowser.Navigate(navigationAddress);

            if (Program.Setts.PlayerType != 2) // Non PRO player
                importWhenCompleted = true;
        }

        private void tsbOverview_Click(object sender, EventArgs e)
        {
            navigationAddress = "http://trophymanager.com/training.php";
            startnavigationAddress = navigationAddress;
            webBrowser.Navigate(navigationAddress);
        }

        private void tsbImport_Click(object sender, EventArgs e)
        {
            if (!startnavigationAddress.StartsWith("http://trophymanager.com/"))
                return;

            if (startnavigationAddress.StartsWith("http://trophymanager.com/buy-pro/") ||
                startnavigationAddress.StartsWith("http://trophymanager.com/forum/") ||
                startnavigationAddress.StartsWith("http://trophymanager.com/club/") ||
                startnavigationAddress.StartsWith("http://trophymanager.com/league/") ||
                startnavigationAddress.StartsWith("http://trophymanager.com/fixtures/league/") ||
                startnavigationAddress.StartsWith("http://trophymanager.com/home/"))
            {
                MessageBox.Show("This page cannot be imported in TmRecorder");
                return;
            }

            if (startnavigationAddress.StartsWith("http://trophymanager.com/players/"))
            {
                string str = HTML_Parser.GetNumberAfter(startnavigationAddress, "players/");
                if (str != "-1")
                {
                    MessageBox.Show("This page has to be imported in the Player Info Panel");
                    return;
                }
            }

            // Check if the team is the one actually used
            {
                doctext = webBrowser.DocumentText;
                int actualTeamId = 0;
                string actTeamIdString = HTML_Parser.GetNumberAfter(doctext, "SESSION[\"id\"] = ");
                int.TryParse(actTeamIdString, out actualTeamId);
                if ((actualTeamId != 0) && (Program.Setts.MainSquadID != 0) && (actualTeamId != Program.Setts.MainSquadID))
                {
                    MessageBox.Show("You are using the DB of " + Program.Setts.MainSquadName + " while you are trying to import a different team");
                    return;
                }
                else if (Program.Setts.MainSquadName == "")
                {
                    Program.Setts.MainSquadName = HTML_Parser.GetField(doctext, "SESSION[\"clubname\"] = '", "';");
                    Program.Setts.Save();
                    Text = "Trophy Manager - " + Program.Setts.MainSquadName + " - Team Recorder v." + Application.ProductVersion;
                }
            }

            try
            {
                doctext = GetWebBrowserContent(startnavigationAddress);
            }
            catch (Exception ex)
            {
                doctext = "Exception error:\nWeb Site: " + startnavigationAddress + "\nException: " + ex.Message;
            }

            string page = "";

            if (doctext.Contains("Javascript error: data doesn't exists"))
            {
                importWhenCompleted = true;
                return;
            }

            //if (doctext.Contains("Unable to get property 'lineup' of undefined or null reference"))
            //{
            //    string str = HTML_Parser.GetNumberAfter(startnavigationAddress, "matches/");
            //    if (MessageBox.Show("Error importing the Match number " + str + ". Maybe this match is not available anymore. Tag this match as not available?\n" +
            //        "Pressing OK, the match will not be scanned automatically anymore.",
            //        "Import error", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //    {
                    
            //        if (str != "-1")
            //        {
            //            int matchID = int.Parse(str);
            //            ChampDS.MatchRow mr = champDS.Match.FindByMatchID(matchID);
            //            if (mr == null)
            //            {
            //                MessageBox.Show("It seems that many errors occurs at the same time: please communicate the error id 29921 to led.lennon@gmail.com. Thanks.");
            //                return;
            //            }
            //            mr.Report = true;
            //        }
            //        return;
            //    }
            //}

            if (doctext.StartsWith("Exception error") || doctext.StartsWith("GBC error") || doctext.Contains("Javascript error"))
            {
                if (!doctext.Contains("forfait=yes"))
                    return;

                //page = doctext;

                //if (MessageBox.Show("There is an error importing the page.\n" +
                //    "Pressing OK, you send a report to Atletico Granata that will try to detect the reason of the error.",
                //    "Import error", MessageBoxButtons.OKCancel) == DialogResult.OK)
                //{
                //    string swRelease = "Sw Release:" + Application.ProductName + "("
                //       + Application.ProductVersion + ")";
                //    page = "Navigation Address: " + startnavigationAddress + "\n" + page;
                //    Exception ex = new Exception("Navigation error");
                //    SendFileTo.ErrorReport.Send(ex, page, Environment.StackTrace, swRelease);
                //}
            }

            page = startnavigationAddress + "\n" + doctext;

            if (page.Contains("You are not logged in"))
            {
                MessageBox.Show("You are not logged in. Please, login");
                return;
            }

            if (startnavigationAddress.Contains("tactics.php"))
                return;

            if (startnavigationAddress.Contains("squad.php?reserves"))
                page = "SourceURL:<TM - Squad - Reserves>\n" + page;
            else if (startnavigationAddress.Contains("players/"))
                page = "SourceURL:<NewTM - Squad>\n" + page;
            else if (startnavigationAddress.Contains("training-overview/advanced/"))
                page = "SourceURL:<NewTM - Training>\n" + page;
            else if (startnavigationAddress.Contains("training_new.php"))
                page = "SourceURL:<TM - Training_new>\n" + page;
            else if (startnavigationAddress.Contains("squad.php?reserves"))
                page = "SourceURL:<TM - Squad - Reserves>\n" + page;
            else if (startnavigationAddress.Contains("squad.php"))
                page = "SourceURL:<TM - Squad>\n" + page;
            else if (startnavigationAddress.Contains("training.php"))
                page = "SourceURL:<TM - Training>\n" + page;
            else if (startnavigationAddress.Contains("training/"))
                page = "SourceURL:<NewTM - TrainingNew>\n" + page;
            else if (startnavigationAddress.Contains("training_new.php"))
                page = "SourceURL:<TM - Training_new>\n" + page;
            else if (startnavigationAddress.Contains("matches.php"))
                page = "SourceURL:<TM - Matches>\n" + page;
            else if (startnavigationAddress.Contains("/fixtures/club/"))
                page = "SourceURL:<NewTM - Matches>\n" + page;
            else if (startnavigationAddress.Contains("kamp.php"))
                page = "SourceURL:<TM - Kamp>\n" + page;
            else if (startnavigationAddress.Contains("/matches/"))
                page = "SourceURL:<NewTM - Kamp>\n" + page;
            else if (startnavigationAddress.Contains("/trophymanager.com/scouts/"))
                page = "SourceURL:<NewTM - Scouts>\n" + page;
            else if (startnavigationAddress.Contains("showprofile.php?playerid="))
                page = "SourceURL:<TM - Player>\n" + page;
            else if (startnavigationAddress.Contains("staff_trainers.php"))
                page = "SourceURL:<TM - Staff_trainers>\n" + page;
            else if (startnavigationAddress.Contains("coaches/"))
                page = "SourceURL:<NewTM - Staff_trainers>\n" + page;
            else
            {
                if (startnavigationAddress.Contains("index.php"))
                {
                    MessageBox.Show("I'm sorry, but the Trophy Manager home page cannot be imported in TmRecorder. You think it could be useful? Contact me at led.lennon@gmail.com");
                    return;
                }

                if (startnavigationAddress.Contains("klubhus.php"))
                {
                    MessageBox.Show("I'm sorry, but the club house page cannot be imported in TmRecorder. You think it could be useful? Contact me at led.lennon@gmail.com");
                    return;
                }

                if (startnavigationAddress.Contains("shortlist.php"))
                {
                    MessageBox.Show("I'm sorry, but the shortlist page cannot be imported in TmRecorder. You think it could be useful? Contact me at led.lennon@gmail.com");
                    return;
                }

                if (startnavigationAddress.Contains("live_prematch.php"))
                {
                    MessageBox.Show("I'm sorry, this page cannot be imported now. Try once again to load this page.");
                    return;
                }

                if (MessageBox.Show("Cannot import this page here. Here you can import only squad, training, calendar and matches.\n" +
                    "Pressing OK, you send a report to Atletico Granata that will try to detect the reason of the error.",
                    "Import error", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string swRelease = "Sw Release:" + Application.ProductName + "("
                       + Application.ProductVersion + ")";
                    page = "Navigation Address: " + startnavigationAddress + "\n" + page;
                    Exception ex = new Exception("Navigation error");
                    SendFileTo.ErrorReport.Send(ex, page, Environment.StackTrace, swRelease);
                }
                return;
            }

            SaveImportedFile(page, webBrowser.Url);

            if ((!page.Contains("TM - Squad")) &&
                (!page.Contains("TM - Squad")) &&
                (!page.Contains("TM - Kamp")) &&
                (!page.Contains("TM - Training")) &&
                (!page.Contains("TM - Matches")) &&
                (!page.Contains("TM - Training_new")) &&
                (!page.Contains("TM - Scouts")) &&
                (!page.Contains("TM - Player")) &&
                (!page.Contains("TM - Staff_trainers")))
            {
                return;
            }

            LoadHTMLfile_newPage(page);

            ChampDS.MatchRow cmr = champDS.Match.FindByMatchID(lastBarMatch);
            tsBrowseMatches.Visible = (cmr != null) && (startnavigationAddress.Contains("kamp.php"));

            if (cmr != null)
            {
                if (cmr.Report == false)
                {
                    lblMatchStored.Text = "Match not stored";
                    lblMatchStored.ForeColor = Color.Red;
                }
                else
                {
                    lblMatchStored.Text = "Match stored";
                    lblMatchStored.ForeColor = Color.Green;
                }
            }

            champDS.UpdateSeason(cmbSeason);

            UpdateBrowserImportPanel();
        }

        private string GetWebBrowserContent(string startnavigationAddress)
        {
            string doctext = "";

            //if ((startnavigationAddress.Contains("showprofile.php?playerid=")))
            //{
            //    doctext = webBrowser.Document.Body.InnerHtml;
            //}
            //else 
            if (startnavigationAddress.Contains("/matches/"))
            {
                doctext = Import_Matches_Adv();
                if ((doctext == "") || (doctext == null))
                {
                    if (doctext == null)
                        doctext = "GBC error: failed importing players  (text is null)";
                    else
                        doctext = "GBC error: failed importing players  (text is empty)";

                    FileInfo fi = new FileInfo(Program.Setts.DatafilePath + "\\match_loader.js");
                    if (!fi.Exists)
                    {
                        doctext += "\nThe js does not exists in " + Program.Setts.DatafilePath;
                    }
                    else
                    {
                        doctext += "\nJs content (in " + Program.Setts.DatafilePath + "): \n";
                        doctext += System.IO.File.ReadAllText(Program.Setts.DatafilePath + "\\match_loader.js");
                    }
                    doctext += "\n";
                }
            }
            else if (startnavigationAddress.Contains("/players/#") || startnavigationAddress.EndsWith("/players/"))
            {
                doctext = Import_Players_Adv();
                if ((doctext == "") || (doctext == null))
                {
                    if (doctext == null)
                        doctext = "GBC error: failed importing players  (text is null)";
                    else
                        doctext = "GBC error: failed importing players  (text is empty)";

                    FileInfo fi = new FileInfo(Program.Setts.DatafilePath + "\\players_loader.js");
                    if (!fi.Exists)
                    {
                        doctext += "\nThe js does not exists in " + Program.Setts.DatafilePath;
                    }
                    else
                    {
                        doctext += "\nJs content (in " + Program.Setts.DatafilePath + "): \n";
                        doctext += System.IO.File.ReadAllText(Program.Setts.DatafilePath + "\\players_loader.js");
                    }
                    doctext += "\n";
                }

                if (Program.Setts.PlayerType == 2)
                {
                    string training_doctext = Import_Players_Training_Adv();
                    if ((training_doctext == "") || (training_doctext == null))
                    {
                        if (training_doctext == null)
                            training_doctext = "GBC error: failed importing players training  (text is null)";
                        else
                            training_doctext = "GBC error: failed importing players training  (text is empty)";

                        FileInfo fi = new FileInfo(Program.Setts.DatafilePath + "\\get_players_training_loader.js");
                        if (!fi.Exists)
                        {
                            training_doctext += "\nThe js does not exists in " + Program.Setts.DatafilePath;
                        }
                        else
                        {
                            training_doctext += "\nJs content (in " + Program.Setts.DatafilePath + "): \n";
                            training_doctext += System.IO.File.ReadAllText(Program.Setts.DatafilePath + "\\get_players_training_loader.js");
                        }
                        training_doctext += "\n";
                    }

                    doctext += "\n\r\n" + training_doctext;
                }
            }
            //else if (startnavigationAddress.Contains("/players/"))
            //{
            //    doctext = Import_Player_Adv();
            //}
            else if (startnavigationAddress.Contains("/fixtures/club/"))
            {
                doctext = Import_Fixtures_Adv();
                if ((doctext == "") || (doctext == null))
                {
                    if (doctext == null)
                        doctext = "GBC error: failed importing players  (text is null)";
                    else
                        doctext = "GBC error: failed importing players  (text is empty)";

                    FileInfo fi = new FileInfo(Program.Setts.DatafilePath + "\\fixture_loader.js");
                    if (!fi.Exists)
                    {
                        doctext += "\nThe js does not exists in " + Program.Setts.DatafilePath;
                    }
                    else
                    {
                        doctext += "\nJs content (in " + Program.Setts.DatafilePath + "): \n";
                        doctext += System.IO.File.ReadAllText(Program.Setts.DatafilePath + "\\fixture_loader.js");
                    }
                    doctext += "\n";
                }
            }
            else if (startnavigationAddress.Contains("/training/"))
            {
                doctext = Import_Training();
                if ((doctext == "") || (doctext == null))
                {
                    if (doctext == null)
                        doctext = "GBC error: failed importing training  (text is null)";
                    else
                        doctext = "GBC error: failed importing training  (text is empty)";

                    FileInfo fi = new FileInfo(Program.Setts.DatafilePath + "\\training_loader.js");
                    if (!fi.Exists)
                    {
                        doctext += "\nThe js does not exists in " + Program.Setts.DatafilePath;
                    }
                    else
                    {
                        doctext += "\nJs content (in " + Program.Setts.DatafilePath + "): \n";
                        doctext += System.IO.File.ReadAllText(Program.Setts.DatafilePath + "\\training_loader.js");
                    }
                    doctext += "\n";
                }
            }
            else
            {
                doctext = "Doc Text: \n" + webBrowser.DocumentText;
            }

            return doctext;
        }

        private string Import_Players_Training_Adv()
        {
            string pl_data = "";

            if (false) // (!CheckLicense("Import_Players_Training_Adv"))
            {
                pl_data = "License not valid";
                return pl_data;
            }

            try
            {
                HtmlElement head = webBrowser.Document.GetElementsByTagName("head")[0];
                HtmlElement scriptEl = webBrowser.Document.CreateElement("script");
                IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;

                element.text = System.IO.File.ReadAllText(Program.Setts.DatafilePath + "\\get_players_training_loader.js");
                HtmlElement res = head.AppendChild(scriptEl);
                pl_data = (string)webBrowser.Document.InvokeScript("get_players_training");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return pl_data;
        }

        private string Import_Players_Adv()
        {
            string pl_data = "";

            try
            {
                HtmlElement head = webBrowser.Document.GetElementsByTagName("head")[0];
                HtmlElement scriptEl = webBrowser.Document.CreateElement("script");
                IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;

                element.text = System.IO.File.ReadAllText(Program.Setts.DatafilePath + "\\players_loader.js");
                HtmlElement res = head.AppendChild(scriptEl);
                pl_data = (string)webBrowser.Document.InvokeScript("get_players");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return pl_data;
        }

        private string Import_Player_Adv()
        {
            string pl_data = "";

            try
            {
                object doc = webBrowser.Document.DomDocument;
                doctext = webBrowser.Document.Body.InnerHtml;

                HtmlElement head = webBrowser.Document.GetElementsByTagName("head")[0];
                HtmlElement scriptEl = webBrowser.Document.CreateElement("script");
                IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;
                return pl_data;

                element.text = System.IO.File.ReadAllText(Program.Setts.DatafilePath + "\\player_info_loader.js");
                HtmlElement res = head.AppendChild(scriptEl);
                pl_data = (string)webBrowser.Document.InvokeScript("get_player_info");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return pl_data;
        }

        private string Import_Matches_Adv()
        {
            string matches_data = "";

            try
            {
                HtmlElement head = webBrowser.Document.GetElementsByTagName("head")[0];
                HtmlElement scriptEl = webBrowser.Document.CreateElement("script");
                IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;

                element.text = System.IO.File.ReadAllText(Program.Setts.DatafilePath + "\\match_loader.js");
                HtmlElement res = head.AppendChild(scriptEl);
                string lineup = (string)webBrowser.Document.InvokeScript("get_lineup");
                string match_info = (string)webBrowser.Document.InvokeScript("get_match_info");
                string report = (string)webBrowser.Document.InvokeScript("get_report");

                matches_data = "<TABLE>" + lineup + "</TABLE>" +
                    "<TABLE>" + match_info + "</TABLE>" +
                    "<TABLE>" + report + "</TABLE>";

                if (matches_data.Contains("Javascript error"))
                {
                    //MessageBox.Show("Error executing java scripts");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return matches_data;
        }

        private string Import_Fixtures_Adv()
        {
            string fix_data = "";

            try
            {
                HtmlElement head = webBrowser.Document.GetElementsByTagName("head")[0];
                HtmlElement scriptEl = webBrowser.Document.CreateElement("script");
                IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;

                element.text = System.IO.File.ReadAllText(Program.Setts.DatafilePath + "\\fixture_loader.js");
                HtmlElement res = head.AppendChild(scriptEl);
                fix_data = (string)webBrowser.Document.InvokeScript("get_fixture");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return fix_data;
        }

        private string Import_Training()
        {
            string fix_data = "";

            try
            {
                HtmlElement head = webBrowser.Document.GetElementsByTagName("head")[0];
                HtmlElement scriptEl = webBrowser.Document.CreateElement("script");
                IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;

                element.text = System.IO.File.ReadAllText(Program.Setts.DatafilePath + "\\training_loader.js");
                HtmlElement res = head.AppendChild(scriptEl);
                fix_data = (string)webBrowser.Document.InvokeScript("get_training");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return fix_data;
        }

        /// <summary>
        /// Save imported file
        /// </summary>
        /// <param name="page"></param>
        /// <param name="url"></param>
        private void SaveImportedFile(string page, Uri url)
        {
            // Check the existence of the folder
            DirectoryInfo di = new DirectoryInfo(Path.Combine(Program.Setts.DefaultDirectory, "ImportedPages"));
            if (!di.Exists)
            {
                di.Create();
            }

            string filedate = TmWeek.ToSWDString(DateTime.Now);

            string filename = "NF-" + url.LocalPath.Replace(".php", "").Replace("/", "");

            if (filename == "kamp")
            {
                string kampid = HTML_Parser.GetField(webBrowser.Url.Query, "=", ",");
                filename += "_" + kampid + ".2.htm";
            }
            else if (filename == "matches")
            {
                if (url.ToString().Contains(Program.Setts.ReserveSquadID.ToString()))
                {
                    filename += "-res-" + TmWeek.GetSeason(DateTime.Now).ToString() + ".2.htm";
                }
                else
                    filename += "-" + TmWeek.GetSeason(DateTime.Now).ToString() + ".2.htm";
            }
            else if (filename == "players")
            {
                if (webBrowser.Url.ToString().Contains("reserves"))
                {
                    filename += "-res-" + filedate + ".2.htm";
                }
                else
                    filename += "-" + filedate + ".2.htm";
            }
            else if (filename == "showprofile")
            {
                string playerid = HTML_Parser.GetNumberAfter(url.ToString(), "playerid=");
                filename += "-" + playerid + "-" + filedate + ".2.htm";
            }
            else
            {
                filename += "-" + filedate + ".2.htm";
            }

            FileInfo fi = new FileInfo(Path.Combine(di.FullName, filename));

            StreamWriter file = new StreamWriter(fi.FullName);
            file.Write(page);
            file.Close();
        }

        private void LoadHTMLfile_newPage(string page)
        {
            LoadHTMLfile_newPage(page, false);
        }

        private void LoadHTMLfile_newPage(string page, bool specifyDate)
        {
            if ((page.Contains("NewTM - Staff_trainers")) ||
                (page.Contains("Navigation Address: http://trophymanager.com/coaches/")))
            {
                dbTrainers.ParseTrainers_NewTM(page);
                string strMsg = "Import complete:\n" + dbTrainers.Trainers.Count.ToString() + " trainers imported;\n";
                MessageBox.Show(strMsg, "TmRecorder");
                isDirty = true;
                return;
            }
            else if (page.Contains("TM - Staff_trainers"))
            {
                dbTrainers.ParseTrainers(page);
                extraDS.Scouts.ParseScoutPage(page);
                History.PlayersDS.Scouts.ParseScoutPage(page);
                string strMsg = "Import complete:\n" + dbTrainers.Trainers.Count.ToString() + " trainers imported;\n" +
                    extraDS.Scouts.Count.ToString() + " scouts imported;";
                MessageBox.Show(strMsg, "TmRecorder");
                isDirty = true;
                return;
            }

            if (page.Contains("NewTM - Kamp"))
            {
                page = startnavigationAddress + "\n" + page;
                LoadKampFromHTMLcode_NewTM(page);
                UpdateLackData();
                isDirty = true;
                return;
            }
            if (page.Contains("TM - Kamp"))
            {
                page = startnavigationAddress + "\n" + page;
                LoadKampFromHTMLcode(page);
                UpdateLackData();
                isDirty = true;
                return;
            }

            if (page.Contains("NewTM - Matches"))
            {
                int cnt = LoadMatchesFromHTMLcode_NewTM(page);
                string strMsg = "Import complete:\n" + cnt.ToString() + " new matches imported;\n";
                MessageBox.Show(strMsg, "TmRecorder");
                isDirty = true;
                return;
            }
            else if (page.Contains("TM - Matches"))
            {
                int cnt = LoadMatchesFromHTMLcode(page);
                string strMsg = "Import complete:\n" + cnt.ToString() + " new matches imported;\n";
                MessageBox.Show(strMsg, "TmRecorder");
                isDirty = true;
                return;
            }

            if ((page.Contains("TM - Player")) || (page.Contains("TM - Showprofile")))
            {
                // trova l'id dal titolo
                int playerID = 0;

                if (specifyDate) // Load from file
                    playerID = int.Parse(HTML_Parser.GetNumberAfter(page, "playerid="));
                else
                    playerID = int.Parse(HTML_Parser.GetNumberAfter(webBrowser.Url.ToString(), "playerid="));

                // cerca l'item di extrads da aggiornare
                ExtraDS.GiocatoriRow gRow = extraDS.FindByPlayerID(playerID);

                if (gRow == null) return;

                // aggiorna
                ExtraDS.ParsePlayerPage(page, ref gRow);

                gRow.isDirty = true;

                ExtraDS.GiocatoriRow hgRow = History.PlayersDS.Giocatori.FindByPlayerID(playerID);

                if (hgRow == null) return;

                hgRow.Nome = gRow.Nome;
                hgRow.Routine = gRow.Routine;
                hgRow.MediaVoto = gRow.MediaVoto;
                hgRow.wBorn = gRow.wBorn;
                hgRow.Note = gRow.Note;

                hgRow.ScoutDate = gRow.ScoutDate;
                hgRow.ScoutName = gRow.ScoutName;
                hgRow.ScoutVoto = gRow.ScoutVoto;
                hgRow.ScoutGiudizio = gRow.ScoutGiudizio;

                tsbNumberOfReviews.Text = gRow.ScoutReviews.Length + " Scout Reviews stored";

                hgRow.isDirty = true;
                History.UpdateDirtyPlayers();
                EvidenceSkillsPlayerForQuality(gRow.PlayerID, gRow.isYoungTeam == 1, gRow.FPn == 0);

                isDirty = true;
                return;
            }

            DateTime dt = DateTime.Today;

            if (specifyDate)
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

            if (page.Contains("NewTM - Scouts"))
            {
                int count = History.ImportScouts(page);

                if (count > 0)
                    isDirty = true;

                MessageBox.Show("Scouts imported: " + count.ToString() + " scout imported");
            }

            if ((page.Contains("NewTM - Squad")) ||
                (page.Contains("Navigation Address: http://trophymanager.com/players/")))
            {
                string[] stringSeparators = new string[] { "\n\r\n" };
                string[] pages = page.Split(stringSeparators, StringSplitOptions.None);

                if (((pages.Length < 2) && (Program.Setts.PlayerType == 2)) ||
                    ((pages.Length < 1) && (Program.Setts.PlayerType != 2)))
                {
                    string swRelease = "Sw Release:" + Application.ProductName + "("  + Application.ProductVersion + ")";
                    page = "Navigation Address: " + startnavigationAddress + "\n" + page;

                    string message = "Error retrieving data from the players page";
                    SendFileTo.ErrorReport.SendPage(message, page, Environment.StackTrace, swRelease);
                }
                else if (Program.Setts.PlayerType == 2)
                {
                    History.LoadSquad_NewTm(dt, pages[0]);
                    History.LoadTraining_NewTM2(dt, pages[1]);
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
            else if ((page.Contains("TM - Squad")) ||
                (page.Contains("Navigation Address: http://trophymanager.com/squad.php")))
            {
                History.LoadSquad_New(dt, page);
                isDirty = true;
                InvalidateGrids();
                UpdateShownGrid();
            }
            else if (page.Contains("NewTM - TrainingNew"))
            {
                int count = History.LoadTIfromTrainingNew_NewTM(dt, page);
                isDirty = true;
                MessageBox.Show("Training imported: " + count.ToString() + " players imported");
            }
            else if (page.Contains("TM - Training_new"))
            {
                if (Program.Setts.PlayerType == 1)
                {
                    page = page.Replace("'", "");
                    page = page.Replace('"', '\'');
                    page = page.Replace("'>", ">");
                    page = page.Replace("&#39;", "'");

                    History.LoadTrainingNew(dt, page, dbTrainers);
                    isDirty = true;
                }
                else
                {
                    History.LoadTIfromTrainingNew(dt, page);
                    isDirty = true;
                }
            }
            else if (page.Contains("NewTM - Training") ||
                     page.Contains("Navigation Address: http://trophymanager.com/training-overview/advanced/"))
            {
                if (Program.Setts.PlayerType == 2)
                {
                    History.LoadTraining_NewTM(dt, page, dbTrainers);
                    isDirty = true;
                }
                else
                {
                    MessageBox.Show(Current.Language.NonPROUsersMustPasteTheTrainingRegimesAllenamentoPage);
                    return;
                }
            }
            else if (page.Contains("TM - Training"))
            {
                if (Program.Setts.PlayerType == 2)
                {
                    History.LoadTraining(dt, page, dbTrainers);
                    isDirty = true;
                }
                else
                {
                    MessageBox.Show(Current.Language.NonPROUsersMustPasteTheTrainingRegimesAllenamentoPage);
                    return;
                }
            }

            History.actualDts = History.LastTeam();

            if (History.actualDts != null)
            {
                dataGridGiocatori.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'A'");
                dataGridGiocatoriB.DataSource = History.actualDts.GiocatoriNSkill.Select("Team = 'B'");
                dataGridPortieri.DataSource = History.actualDts.PortieriNSkill;
            }

            isDirty = true;

            SetLastTeam();
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            webBrowser.GoForward();
        }

        private void tsbPrev_Click(object sender, EventArgs e)
        {
            webBrowser.GoBack();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (Program.Setts.SettsRelease < 2)
            {
                Program.Setts.SettsRelease = 2;
                Program.Setts.Save();

                tabControl1.SelectedTab = tabBrowser;

            }
            navigationAddress = "http://trophymanager.com/club/";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
        }

        private void mainTeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            navigationAddress = "http://trophymanager.com/matches.php";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
        }

        private void reserveTeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            navigationAddress = "http://trophymanager.com/matches.php?showclub=" +
                Program.Setts.ReserveSquadID.ToString();
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
        }

        private void gotoAdobeFlashplayerPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            navigationAddress = "http://www.adobe.com/products/flashplayer/";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
        }

        private void tsbTrainers_Click(object sender, EventArgs e)
        {
            navigationAddress = "http://trophymanager.com/coaches/";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
        }

        #region Player Profiles Navigation
        enum NavigationType
        {
            NavigateProfiles,
            NavigateReports
        }

        NavigationType navigationType = NavigationType.NavigateProfiles;
        int lastBarPlayer = 0;
        int lastBarMatch = 0;

        private void tsbPrevPlayer_Click(object sender, EventArgs e)
        {
            ExtraDS.GiocatoriRow gRow = extraDS.FindByPlayerID(lastBarPlayer);

            int i = 0;
            for (; i < extraDS.Giocatori.Count; i++)
                if (gRow == extraDS.Giocatori[i]) break;

            i--;
            if (i == -1) i = extraDS.Giocatori.Count - 1;

            navigationAddress = "http://trophymanager.com/showprofile.php?playerid=" +
                extraDS.Giocatori[i].PlayerID.ToString();
            if (navigationType == NavigationType.NavigateReports)
                navigationAddress += "&scout_mode=1";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
        }

        private void tsbNextPlayer_Click(object sender, EventArgs e)
        {
            ExtraDS.GiocatoriRow gRow = extraDS.FindByPlayerID(lastBarPlayer);

            int i = 0;
            for (; i < extraDS.Giocatori.Count; i++)
                if (gRow == extraDS.Giocatori[i]) break;

            i++;
            if (i == extraDS.Giocatori.Count) i = 0;

            navigationAddress = "http://trophymanager.com/showprofile.php?playerid=" +
                extraDS.Giocatori[i].PlayerID.ToString();
            if (navigationType == NavigationType.NavigateReports)
                navigationAddress += "&scout_mode=1";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
        }

        private void navigateProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbNavigationType.Text = navigateProfilesToolStripMenuItem.Text;
            tsbNavigationType.Image = navigateProfilesToolStripMenuItem.Image;

            if (navigationType != NavigationType.NavigateProfiles)
            {
                navigationType = NavigationType.NavigateProfiles;
                navigationAddress = "http://trophymanager.com/showprofile.php?playerid=" +
                    lastBarPlayer.ToString();
                webBrowser.Navigate(navigationAddress);
                startnavigationAddress = navigationAddress;
            }
        }

        private void navigateReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbNavigationType.Text = navigateReportsToolStripMenuItem.Text;
            tsbNavigationType.Image = navigateReportsToolStripMenuItem.Image;

            if (navigationType != NavigationType.NavigateReports)
            {
                navigationType = NavigationType.NavigateReports;
                navigationAddress = "http://trophymanager.com/showprofile.php?playerid=" +
                    lastBarPlayer.ToString() + "&scout_mode=1";
                webBrowser.Navigate(navigationAddress);
                startnavigationAddress = navigationAddress;
            }
        }

        private void ChangePlayer_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsi = (ToolStripMenuItem)sender;
            navigationAddress = "http://trophymanager.com/showprofile.php?playerid=" +
                tsi.Tag.ToString();
            if (navigationType == NavigationType.NavigateReports)
                navigationAddress += "&scout_mode=1";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
        }
        #endregion

        private void lineupToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LineUp lineup = new LineUp(champDS, extraDS, History);
            lineup.ShowDialog();
        }

        private void gotoMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            navigationAddress = "http://trophymanager.com/";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
        }

        private void shortlistToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShortlistForm sf = new ShortlistForm(ref History.teamDS);
            sf.Show();
        }

        #region MatchBrowser Management
        enum MatchNavigationType
        {
            NavigateMainTeam,
            NavigateReserves,
        }

        MatchNavigationType matchNavigationType = MatchNavigationType.NavigateMainTeam;

        private void btnNextMatch_Click(object sender, EventArgs e)
        {
            ChampDS.MatchRow cmr = champDS.Match.FindByMatchID(lastBarMatch);

            int i = 0;
            for (; i < champDS.Match.Count; i++)
                if (cmr == champDS.Match[i]) break;

            int loop_count = 0;
            int thisSeason = TmWeek.GetSeason(DateTime.Now);
            i++;
            if (i == champDS.Match.Count)
                i = 0;

            for (; i < champDS.Match.Count; i++)
            {
                if (TmWeek.GetSeason(cmr.Date) != thisSeason) continue;
                if ((champDS.Match[i].isReserves == 1) &&
                    (matchNavigationType == MatchNavigationType.NavigateReserves)) break;
                if ((champDS.Match[i].isReserves == 0) &&
                    (matchNavigationType == MatchNavigationType.NavigateMainTeam)) break;
                if (i == champDS.Match.Count)
                {
                    i = 0;
                    if (loop_count++ == 2) return;
                }
            }

            ChampDS.MatchRow mr = champDS.Match[i];
            if (mr == null) return;
            int matchID = mr.MatchID;
            navigationAddress = "http://trophymanager.com/matches/" + matchID.ToString() + "/"; ;
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
        }

        private void btnPrevMatch_Click(object sender, EventArgs e)
        {
            ChampDS.MatchRow cmr = champDS.Match.FindByMatchID(lastBarMatch);

            int i = 0;
            for (; i < champDS.Match.Count; i++)
                if (cmr == champDS.Match[i]) break;

            int loop_count = 0;
            int thisSeason = TmWeek.GetSeason(DateTime.Now);

            i--;
            if (i == -1)
                i = champDS.Match.Count - 1;

            for (; i >= 0; i--)
            {
                if (TmWeek.GetSeason(champDS.Match[i].Date) != thisSeason) continue;
                if ((champDS.Match[i].isReserves == 1) &&
                    (matchNavigationType == MatchNavigationType.NavigateReserves)) break;
                if ((champDS.Match[i].isReserves == 0) &&
                    (matchNavigationType == MatchNavigationType.NavigateMainTeam)) break;
                if (i == 0)
                {
                    i = champDS.Match.Count - 1;
                    if (loop_count++ == 2) return;
                }
            }

            if (i == -1) return;
            int matchID = champDS.Match[i].MatchID;
            navigationAddress = "http://trophymanager.com/matches/" + matchID.ToString() + "/";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
        }

        private void tsbNavigateMainTeamMatches_Click(object sender, EventArgs e)
        {
            tsbMatchNavigationType.Text = tsbNavigateMainTeamMatches.Text;
            tsbMatchNavigationType.Image = tsbNavigateMainTeamMatches.Image;

            if (matchNavigationType != MatchNavigationType.NavigateMainTeam)
            {
                matchNavigationType = MatchNavigationType.NavigateMainTeam;
                UpdateMatchesMenu();
            }
        }

        private void tsbNavigateReservesMatches_Click(object sender, EventArgs e)
        {
            tsbMatchNavigationType.Text = tsbNavigateReservesMatches.Text;
            tsbMatchNavigationType.Image = tsbNavigateReservesMatches.Image;

            if (matchNavigationType != MatchNavigationType.NavigateReserves)
            {
                matchNavigationType = MatchNavigationType.NavigateReserves;
                UpdateMatchesMenu();
            }
        }

        private void ChangeMatch_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsi = (ToolStripMenuItem)sender;
            navigationAddress = "http://trophymanager.com/matches/" + tsi.Tag.ToString() + "/";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
        }
        #endregion

        private void loadFromBackupFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check the existence of the folder
            DirectoryInfo di = new DirectoryInfo(Path.Combine(Program.Setts.DefaultDirectory, "ImportedPages"));

            openFileDialog.InitialDirectory = di.FullName;
            openFileDialog.FileName = Path.Combine(di.FullName, "*.htm");
            openFileDialog.Filter = "HTML file (*.htm;*.html)|*.htm;*.html|All Files (*.*)|*.*";

            DateTime dt = DateTime.Today;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader file = new StreamReader(openFileDialog.FileName);
                string page = file.ReadToEnd();
                file.Close();

                LoadHTMLfile_newPage(page, true);

                ChampDS.MatchRow cmr = champDS.Match.FindByMatchID(lastBarMatch);
                tsBrowseMatches.Visible = (cmr != null);

                if (cmr != null)
                {
                    if (cmr.Report == false)
                    {
                        lblMatchStored.Text = "Match not stored";
                        lblMatchStored.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblMatchStored.Text = "Match stored";
                        lblMatchStored.ForeColor = Color.Green;
                    }
                }

                champDS.UpdateSeason(cmbSeason);
            }
        }

        private void sendThisPageToLedLennonForDebugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "You are sending this page to LedLennon for debug. If you want to add some more pages to improuve the \n" +
                "possibility to find the error, please send (after) also the squad page (eventually also the team B page) \n" +
                "leaving the same 'Your team' field. All these file are needed to generate exactly the environment in which the \n" +
                "bug has been generated. Please add your name and your info and email, so that Led may contact you to ask for\n" +
                "further info or advise you when a new release is available.\n";

            string doctext = "";

            if (startnavigationAddress == "") return;

            HtmlElementCollection hmtlElColl = webBrowser.Document.All;

            // Check if it's the right team
            {
                doctext = webBrowser.DocumentText;
                string num = HTML_Parser.GetNumberAfter(doctext, "SESSION[\"id\"] = ");
                int idsession = 0;
                int.TryParse(num, out idsession);
                if ((idsession != 0) && (Program.Setts.MainSquadID != 0) && (idsession != Program.Setts.MainSquadID))
                {
                    MessageBox.Show("This is not the team loaded actually in TmRecorder. Please open a new session for the other team.");
                }
            }

            try
            {
                doctext = GetWebBrowserContent(startnavigationAddress);
            }
            catch (FileNotFoundException fnfex)
            {
                MessageBox.Show(fnfex.Message);
                doctext = "";
            }

            if (doctext == "")
            {
                foreach (HtmlElement hel in webBrowser.Document.All)
                {
                    if (hel.InnerHtml != null)
                        doctext += hel.InnerHtml;
                }
            }

            string page = doctext;

            SaveImportedFile(page, webBrowser.Url);

            string swRelease = "Sw Release:" + Application.ProductName + "("
               + Application.ProductVersion + ")";
            page = "Navigation Address: " + startnavigationAddress + "\n" + page;
            Exception ex = new Exception("Navigation error");

            SendFileTo.ErrorReport.SendPage(message, page, Environment.StackTrace, swRelease);
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
            navigationAddress = "http://trophymanager.com/players/";
            startnavigationAddress = navigationAddress;
            webBrowser.Navigate(navigationAddress);
            if (tsbImportSquad.UnderColor != Color.DarkGreen)
                importWhenCompleted = true;
        }

        private void tsbImportTrainingOverview_Click(object sender, EventArgs e)
        {
            navigationAddress = "http://trophymanager.com/training-overview/advanced/";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
            // if ((tsbImportTrainingOverview.Enabled) && (tsbImportTrainingOverview.UnderColor != Color.DarkGreen))
            //     importWhenCompleted = true;
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
            int lastTrainingWeek = -1;

            if (eds != null)
            {
                lastUpdateWeek = TmWeek.GetTmAbsWk(eds.Date);

                if (History.TrainingHist.Count > 0)
                    lastTrainingWeek = TmWeek.GetTmAbsWk(History.TrainingHist.LastTraining().Date);
            }

            if (lastUpdateWeek == -1) // Never imported data
            {
                tsbImportSquad.ForeColor = Color.DarkRed;
                tsbImportSquad.ToolTipText = "Import squad data";
                tsbImportSquad.UnderColor = Color.DarkRed;
                tsbImportSquad.UnderText = "Click here";

                if (Program.Setts.PlayerType != 2) // Non PRO player
                    tsbTrainingTraining.Enabled = false;
            }
            else if (thisWeek > lastUpdateWeek)
            {
                tsbImportSquad.ForeColor = Color.DarkRed;
                tsbImportSquad.ToolTipText = "Squad data imported " + (thisWeek - lastUpdateWeek).ToString() + " weeks ago";
                tsbImportSquad.UnderColor = Color.DarkRed;
                tsbImportSquad.UnderText = "To import";

                if (Program.Setts.PlayerType != 2) // Non PRO player
                    tsbTrainingTraining.Enabled = true;
            }
            else
            {
                if (Program.Setts.PlayerType != 2) // Non PRO player
                    tsbTrainingTraining.Enabled = true;

                tsbImportSquad.ForeColor = Color.DarkGreen;
                tsbImportSquad.ToolTipText = "Squad data updated";
                tsbImportSquad.UnderText = "Import ok";
                tsbImportSquad.UnderColor = Color.DarkGreen;
            }

            if (!champDS.Match.UpdatedCalendar())
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

            if (!champDS.Match.UpdatedCalendarReserves())
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

            int matchToUpdate = champDS.Match.Updated();
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

            matchToUpdate = champDS.Match.UpdatedReserves();
            if (matchToUpdate > 0)
            {
                tsbMatchSquadB.ForeColor = Color.DarkRed;
                tsbMatchSquadB.ToolTipText = "There are at least " + matchToUpdate.ToString() + " match to update";
                tsbMatchSquadB.UnderText = "To import " + matchToUpdate.ToString();
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
            int matchToUpdate = champDS.Match.GetFirstMatchToUpdate();
            if (matchToUpdate == -1)
            {
                MessageBox.Show("There are no matches to show in this season");
                return;
            }

            navigationAddress = "http://trophymanager.com/matches/" + matchToUpdate.ToString() + "/";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
            //if (tsbMatchSquadA.UnderColor != Color.DarkGreen)
            //    importWhenCompleted = true;
        }

        private void tsbMatchSquadB_Click(object sender, EventArgs e)
        {
            int matchToUpdate = champDS.Match.GetFirstMatchToUpdateReserves();
            if (matchToUpdate == -1)
            {
                MessageBox.Show("There are no matches to show in this season");
                return;
            }

            navigationAddress = "http://trophymanager.com/matches/" + matchToUpdate.ToString() + "/";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
            //if (tsbMatchSquadB.UnderColor != Color.DarkGreen)
            //    importWhenCompleted = true;
        }

        private void tsbMatchListA_Click(object sender, EventArgs e)
        {
            navigationAddress = "http://trophymanager.com/fixtures/club/" + Program.Setts.MainSquadID + "/";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
            if ((tsbMatchListA.Enabled) && (tsbMatchListA.UnderColor != Color.DarkGreen))
                importWhenCompleted = true;
        }

        private void tsbMatchListB_Click(object sender, EventArgs e)
        {
            navigationAddress = "http://trophymanager.com/fixtures/club/" + Program.Setts.ReserveSquadID + "/";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
            if ((tsbMatchListB.Enabled) && (tsbMatchListB.UnderColor != Color.DarkGreen))
                importWhenCompleted = true;
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

        private void ChangeTeam_Adv(string id)
        {
            try
            {
                string function =
                    "function club_int_change(){$.post(\"/ajax/club_change.ajax.php\", {\"change\": " +
                    "\"club\",\"club_id\": " + id.ToString() + "}, function(data) { if (data != null) { if (data[\"success\"])" +
                    " page_refresh(); } }, \"json\");}";
                HtmlElement head = webBrowser.Document.GetElementsByTagName("head")[0];
                HtmlElement scriptEl = webBrowser.Document.CreateElement("script");
                IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;
                element.text = function;

                HtmlElement res = head.AppendChild(scriptEl);
                //object[] args = new object[2]; 
                //args[0] = 2097098;
                //args[1] = "club";
                webBrowser.Document.InvokeScript("club_int_change");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            tsbExtraTeam.DropDownItems.Clear();
            tsbExtraTeam.DropDownItems.Add(tsbChangeToConfiguredExtraTeam);

            if (thisIsExtraTeam) return;

            tsbExtraTeam.DropDownItems.Add(addExtraTeamToolStripMenuItem);

            tsbExtraTeam.DropDownItems.Add(new ToolStripSeparator());

            foreach (string key in dictExtraTeams.Keys)
            {
                ToolStripMenuItem tsi = new ToolStripMenuItem();
                tsi.Name = "menuExtra_" + key;
                tsi.Text = "Open TmRecorder session for " + dictExtraTeams[key] + " (" + key + ")";
                tsi.Tag = key;
                tsi.Click += new EventHandler(tsiOpenTmRecorderSession_Click);
                tsbExtraTeam.DropDownItems.Add(tsi);
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
            if (!startnavigationAddress.StartsWith(@"http://trophymanager.com/"))
            {
                MessageBox.Show("You cannot switch to the extra team pages if you are not navigating in the Trophy Manager website");
                return;
            }

            ChangeTeam_Adv(Program.Setts.MainSquadID.ToString());
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
            navigationAddress = "http://trophymanager.com/scouts/";
            startnavigationAddress = navigationAddress;
            webBrowser.Navigate(navigationAddress);

            if (Program.Setts.PlayerType != 2) // Non PRO player
                importWhenCompleted = true;
        }

        private void structuresEconomyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComputeStructures cs = new ComputeStructures();
            cs.Settings = Program.Setts.ComputeStructureSettings;
            cs.ShowDialog();
            Program.Setts.ComputeStructureSettings = cs.Settings;
            Program.Setts.Save();
        }

    }
}