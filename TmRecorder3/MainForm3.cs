using Common;
using Languages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NTR_Forms;
using NTR_Db;
using NTR_Common;
using NTR_Controls;
using DataGridViewCustomColumns;

namespace TmRecorder3
{
    public partial class MainForm3 : Form
    {
        SplashForm sf = null;
        public EnumerableRowCollection<PlayerData> ThisWeekPlayers;
        public EnumerableRowCollection<MatchData> ThisSeasonMatches;
        public EnumerableRowCollection<PlayerData> ThisWeekGK;
        public EnumerableRowCollection<PlayerData> Players;
        public EnumerableRowCollection<PlayerData> GKs;

        NTR_SquadDb.ActionsTableDataTable AnalysisHome;
        NTR_SquadDb.ActionsTableDataTable AnalysisAway;
        ItemDictionary AnalysisMdHome;
        ItemDictionary AnalysisMdAway;

        public MainForm3()
        {
            InitializeComponent();

            Program.Setts.Initialize();

            LoadLanguage();

            SetLanguage();
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            bool settingsChanged = false;

            try
            {
                // Activating splash form
                sf = new SplashForm("TM - Team Recorder",
                            "Release " + Application.ProductVersion,
                            "Starting Application...");

                // Check if using a startup disk
                if (Program.Setts.UsingStartingPathDisk)
                {
                    FileInfo fiStartup = new FileInfo(Application.StartupPath);
                    string disk = fiStartup.FullName.Split(':')[0];

                    Program.Setts.SetDisk(disk);

                    Program.Setts.Save();
                }

                // Setting image of the splash banner
                string imagePath = Path.Combine(Program.Setts.InstallationDirectory, "splash-banners");
                DirectoryInfo di = new DirectoryInfo(imagePath);
                if (di.Exists)
                {
                    int iCnt = 0;

                    if ((iCnt = di.GetFiles("*.sps.jpg").Length) != 0)
                    {
                        Random rnd = new Random();
                        int i = rnd.Next(iCnt + 1);
                        if (i == iCnt) i = iCnt - 1;

                        FileInfo[] fi = di.GetFiles("*.sps.jpg");

                        sf.SetActualBackImage(fi[i]);
                    }
                }

                sf.Show();

                // Setting form title
                Text = "Trophy Manager - Team Recorder v." + Application.ProductVersion;

                if (settingsChanged)
                    Program.Setts.Save();

                DB.LoadGains(Program.Setts.GainSet);

                if (true) // (Program.Setts.FirstInstallation)
                {
                    SelectNationalityForm snf = new SelectNationalityForm();
                    snf.SetSource(DB);
                    snf.DefaultNation = Program.Setts.HomeNation;
                    if (snf.ShowDialog() != DialogResult.OK)
                    {
                        MessageBox.Show("You must select a start nation. The program will now close");
                        this.Close();
                        return;
                    }

                    Program.Setts.HomeNation = snf.DefaultNation;
                    Program.Setts.InstallationDirectory = Application.StartupPath;
                    Program.Setts.Save();

                    RadioButtonSelectOption rbso = new RadioButtonSelectOption();
                    string[] options = { "Not a TM PRO", "TM PRO User" };
                    rbso.ConfigureOptionsSelection(options,
                        "Are you a PRO user in Trophy Manager?\n Please, select an option.", "PRO Select");
                    rbso.Choice = (Program.Setts.PlayerType == 2) ? 1 :
                                  (Program.Setts.PlayerType == 1) ? 0 : 0;
                    if (rbso.ShowDialog() != DialogResult.OK)
                    {
                        MessageBox.Show("You must select if you are a PRO user. The program will now close");
                        this.Close();
                        return;
                    }

                    Program.Setts.PlayerType = (rbso.Choice == 0) ? 1 :
                        (rbso.Choice == 1) ? 2 : 0;
                    Program.Setts.FirstInstallation = false;
                    Program.Setts.Save();
                }

                dgPlayers.DataType = typeof(PlayerData);

                ntrBrowser.DefaultDirectory = Program.Setts.DefaultDirectory;

                tabMatches_Resize(sender, e);
            }
            catch (Exception)
            {
            }

            LoadDB();

            ntrBrowser.SourceDB = this.DB.squadDB;

            FormatPlayersGrid();
            FormatPlayersGridGK();
            UpdateTable();
            UpdateTableGK();

            LoadPlayers();
            LoadMatches();
        }

        private void SetDatesList()
        {
            List<int> weeks = DB.squadDB.WeeksWithData;

            TmSWD tmSwdSelected = null;
            cbDataDay.Items.Clear();
            cbDataDayGK.Items.Clear();

            foreach (int week in weeks)
            {
                TmSWD tmSWD = TmWeek.TmWeekToSWD(week);

                if (DB.latestDataWeek == week)
                    tmSwdSelected = tmSWD;

                cbDataDay.Items.Add(tmSWD);
                cbDataDayGK.Items.Add(tmSWD);
            }

            cbDataDay.SelectedItem = tmSwdSelected;
            cbDataDayGK.SelectedItem = tmSwdSelected;
        }

        private void LoadDB()
        {
            try
            {
                DB.Load(Program.Setts.DefaultDirectory, ref sf, (Program.Setts.Trace > 0));

                SetDatesList();
            }
            catch (Exception)
            {
            }
        }

        private void LoadOldDB(string folder)
        {
            try
            {
                DB.LoadOldDB(folder, ref sf, (Program.Setts.Trace > 0));
            }
            catch (Exception)
            {
            }
        }

        private void LoadPlayers()
        {
            if (cbDataDay.Items.Count == 0)
                return;

            if (cbDataDay.SelectedItem == null)
                cbDataDay.SelectedItem = cbDataDay.Items[0];

            TmSWD selectedItem = (TmSWD)cbDataDay.SelectedItem;

            int absPrevWeek = -1;
            if ((cbDataDay.SelectedIndex + 1) != cbDataDay.Items.Count)
            {
                TmSWD selectedItemPrev = (TmSWD)cbDataDay.Items[cbDataDay.SelectedIndex + 1];
                absPrevWeek = selectedItemPrev.AbsWeek;
            }

            ThisWeekPlayers = (from c in DB.squadDB.HistData
                               where (c.Week == selectedItem.AbsWeek) && (!c.PlayerRow.IsFPnNull()) && (c.PlayerRow.FPn != 0)
                              select new PlayerData(c, absPrevWeek)).OrderBy(p => p.Number);
            ThisWeekGK = (from c in DB.squadDB.HistData
                          where (c.Week == selectedItem.AbsWeek) && (!c.PlayerRow.IsFPnNull()) && (c.PlayerRow.FPn == 0)
                              select new PlayerData(c, absPrevWeek)).OrderBy(p => p.Number);

            FormatPlayersGrid();
            FormatPlayersGridGK();

            UpdateBrowserNavigationPanel();

            sf.Close();
        }

        private void LoadMatches()
        {
            cmbSeason.Items.Clear();
            foreach(int season in DB.squadDB.SeasonsWithData)
            {
                cmbSeason.Items.Add(season);
            }

            if (cmbSeason.Items.Count == 0)
                return;

            cmbSeason.SelectedItem = cmbSeason.Items[0];

            DateTime startDate = TmWeek.GetDateTimeOfSeasonStart((int)cmbSeason.SelectedItem);
            DateTime endDate = startDate.AddDays(7 * 12);

            ThisSeasonMatches = (from c in DB.squadDB.Match
                                 where (!c.IsDateNull()) && (c.Date > startDate) && (c.Date < endDate)
                                 select new MatchData(c)).OrderBy(p => p.Date);

            FormatMatchesGrid();
            // FormatStatsGrids();
        }

        private void UpdateBrowserNavigationPanel()
        {
            int thisWeek = TmWeek.thisWeek().absweek;
            int lastTrainingWeek = DB.latestDataWeek;

            if (lastTrainingWeek == -1) // Never imported data
            {
                tsbImportSquad.ForeColor = Color.DarkRed;
                tsbImportSquad.ToolTipText = "Import squad data (never imported)";
                tsbImportSquad.UnderColor = Color.DarkRed;
                tsbImportSquad.UnderText = "Click here";
            }
            else if (thisWeek > lastTrainingWeek)
            {
                tsbImportSquad.ForeColor = Color.DarkRed;
                tsbImportSquad.ToolTipText = "Squad data imported " + (thisWeek - lastTrainingWeek).ToString() + " weeks ago";
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

            //if (!champDS.Match.UpdatedCalendar())
            //{
            //    tsbMatchListA.ForeColor = Color.DarkRed;
            //    tsbMatchSquadA.Enabled = false;
            //    tsbMatchListA.ToolTipText = "Match List for Main Team not imported";
            //    tsbMatchListA.UnderText = "To import";
            //    tsbMatchListA.UnderColor = Color.DarkRed;
            //}
            //else
            //{
            //    tsbMatchListA.ForeColor = Color.DarkGreen;
            //    tsbMatchSquadA.Enabled = true;
            //    tsbMatchListA.ToolTipText = "Match List for Main Team OK";
            //    tsbMatchListA.UnderText = "Import ok";
            //    tsbMatchListA.UnderColor = Color.DarkGreen;
            //}

            //if (!champDS.Match.UpdatedCalendarReserves())
            //{
            //    tsbMatchListB.ForeColor = Color.DarkRed;
            //    tsbMatchSquadB.Enabled = false;
            //    tsbMatchListB.ToolTipText = "Match List for Reserves Team  not imported";
            //    tsbMatchListB.UnderText = "Not imported";
            //    tsbMatchListB.UnderColor = Color.DarkRed;
            //}
            //else
            //{
            //    tsbMatchListB.ForeColor = Color.DarkGreen;
            //    tsbMatchSquadB.Enabled = true;
            //    tsbMatchListB.ToolTipText = "Match List for Reserves Team OK";
            //    tsbMatchListB.UnderText = "Import ok";
            //    tsbMatchListB.UnderColor = Color.DarkGreen;
            //}

            //int matchToUpdate = champDS.Match.Updated();
            //if (matchToUpdate > 0)
            //{
            //    tsbMatchSquadA.ForeColor = Color.DarkRed;
            //    tsbMatchSquadA.ToolTipText = "There are at least " + matchToUpdate.ToString() + " match to update";
            //    tsbMatchSquadA.UnderText = "To import " + matchToUpdate.ToString();
            //    tsbMatchSquadA.UnderColor = Color.DarkRed;
            //}
            //else
            //{
            //    tsbMatchSquadA.ForeColor = Color.DarkGreen;
            //    tsbMatchSquadA.ToolTipText = "All the matches before today have been loaded";
            //    tsbMatchSquadA.UnderText = "Import ok";
            //    tsbMatchSquadA.UnderColor = Color.DarkGreen;
            //}

            //matchToUpdate = champDS.Match.UpdatedReserves();
            //if (matchToUpdate > 0)
            //{
            //    tsbMatchSquadB.ForeColor = Color.DarkRed;
            //    tsbMatchSquadB.ToolTipText = "There are at least " + matchToUpdate.ToString() + " match to update";
            //    tsbMatchSquadB.UnderText = "To import " + matchToUpdate.ToString();
            //    tsbMatchSquadB.UnderColor = Color.DarkRed;
            //}
            //else
            //{
            //    tsbMatchSquadB.ForeColor = Color.DarkGreen;
            //    tsbMatchSquadB.ToolTipText = "All the matches before today have been loaded";
            //    tsbMatchSquadB.UnderText = "Import ok";
            //    tsbMatchSquadB.UnderColor = Color.DarkGreen;
            //}
        }

        //private void FormatStatsGrids()
        //{
        //    dgAnalysisHome.AutoGenerateColumns = false;
        //    dgAnalysisHome.DataCollection = AnalysisHome;

        //    dgAnalysisHome.Columns.Clear();

        //    dgAnalysisHome.AddColumn("Name", "Name", 40, AG_Style.String | AG_Style.ResizeAllCells);
        //    dgAnalysisHome.AddColumn("Tot", "Total", 27, AG_Style.Numeric | AG_Style.N0);
        //    dgAnalysisHome.AddColumn("Fld", "Failed", 27, AG_Style.Numeric | AG_Style.N0);
        //    dgAnalysisHome.AddColumn("SOf", "Shot_off", 27, AG_Style.Numeric | AG_Style.N0);
        //    dgAnalysisHome.AddColumn("SIn", "Shot_in", 27, AG_Style.Numeric | AG_Style.N0);
        //    dgAnalysisHome.AddColumn("Gol", "Goal", 27, AG_Style.Numeric | AG_Style.N0);

        //    dgAnalysisAway.AutoGenerateColumns = false;
        //    dgAnalysisAway.DataCollection = AnalysisAway;

        //    dgAnalysisAway.Columns.Clear();

        //    dgAnalysisAway.AddColumn("Name", "Name", 40, AG_Style.String | AG_Style.ResizeAllCells);
        //    dgAnalysisAway.AddColumn("Tot", "Total", 27, AG_Style.String | AG_Style.N0);
        //    dgAnalysisAway.AddColumn("Fld", "Failed", 27, AG_Style.String | AG_Style.N0);
        //    dgAnalysisAway.AddColumn("SOf", "Shot_off", 27, AG_Style.String | AG_Style.N0);
        //    dgAnalysisAway.AddColumn("SIn", "Shot_in", 27, AG_Style.String | AG_Style.N0);
        //    dgAnalysisAway.AddColumn("Gol", "Goal", 27, AG_Style.String | AG_Style.N0);
        //}

        private void FormatMatchesGrid()
        {
            dgMatches.AutoGenerateColumns = false;
            dgMatches.DataCollection = ThisSeasonMatches;

            dgMatches.Columns.Clear();
            dgMatches.AddColumn("Date", "Date", 40, AG_Style.String | AG_Style.ResizeAllCells);
            dgMatches.AddColumn("Home", "Home", 90, AG_Style.FormatString | AG_Style.ResizeAllCells);
            dgMatches.AddColumn("-", "ScoreString", 20, AG_Style.FormatString | AG_Style.ResizeAllCells);
            dgMatches.AddColumn("Away", "Away", 90, AG_Style.FormatString | AG_Style.ResizeAllCells);
            dgMatches.AddColumn("Type", "MatchType", 35, AG_Style.MatchType);
            dgMatches.AddColumn("Crowd", "Crowd", 90, AG_Style.Numeric | AG_Style.ResizeAllCells);
        }

        private void FormatPlayersGrid()
        {
            dgPlayers.AutoGenerateColumns = false;
            dgPlayers.DataCollection = ThisWeekPlayers;

            dgPlayers.Columns.Clear();
            DataGridViewColumn numCol = dgPlayers.AddColumn("N", "Number", 20, AG_Style.Numeric | AG_Style.Frozen | AG_Style.N0);
            dgPlayers.AddColumn("FP", "FPn", 42, AG_Style.FavPosition | AG_Style.Frozen);
            dgPlayers.AddColumn("Name", "NameEx", 60, AG_Style.NameInj | AG_Style.Frozen | AG_Style.ResizeAllCells);
            dgPlayers.AddColumn("Age", "wBorn", 32, AG_Style.Age | AG_Style.Frozen);
            dgPlayers.AddColumn("Nat", "Nationality", 28, AG_Style.Nationality | AG_Style.Frozen);
            TMR_NumDecColumn dgvc = (TMR_NumDecColumn)dgPlayers.AddColumn("ASI", "ASI", 49, AG_Style.NumDec | AG_Style.Frozen);
            dgvc.CellColorStyles = CellColorStyleList.DefaultGainColorStyle();
            dgvc = (TMR_NumDecColumn)dgPlayers.AddColumn("TI", "TI", 32, AG_Style.NumDec | AG_Style.Frozen);
            dgvc.CellColorStyles = CellColorStyleList.DefaultGainColorStyle();

            AddPlayersSkillColumn("Str");
            AddPlayersSkillColumn("Pac");
            AddPlayersSkillColumn("Sta");

            AddPlayersSkillColumn("Mar");
            AddPlayersSkillColumn("Tac");
            AddPlayersSkillColumn("Wor");
            AddPlayersSkillColumn("Pos");
            AddPlayersSkillColumn("Pas");
            AddPlayersSkillColumn("Cro");
            AddPlayersSkillColumn("Tec");
            AddPlayersSkillColumn("Hea");
            AddPlayersSkillColumn("Fin");
            AddPlayersSkillColumn("Lon");
            AddPlayersSkillColumn("Set");

            dgPlayers.AddColumn("Rou", "Rou", 30, AG_Style.Numeric | AG_Style.RightJustified);
            dgPlayers.AddColumn("SSD", "SSD", 30, AG_Style.Numeric | AG_Style.RightJustified);
            dgPlayers.AddColumn("CStr", "CStr", 30, AG_Style.Numeric | AG_Style.RightJustified);

            DataGridViewCellStyle dgvcsPosCells = new DataGridViewCellStyle();
            dgvcsPosCells.Format = "N1";

            AddPlayersFpColumn("DC", dgvcsPosCells);
            AddPlayersFpColumn("DL", dgvcsPosCells);
            AddPlayersFpColumn("DR", dgvcsPosCells);
            AddPlayersFpColumn("DMC", dgvcsPosCells);
            AddPlayersFpColumn("DML", dgvcsPosCells);
            AddPlayersFpColumn("DMR", dgvcsPosCells);

            AddPlayersFpColumn("MC", dgvcsPosCells);
            AddPlayersFpColumn("ML", dgvcsPosCells);
            AddPlayersFpColumn("MR", dgvcsPosCells);
            AddPlayersFpColumn("OMC", dgvcsPosCells);
            AddPlayersFpColumn("OML", dgvcsPosCells);
            AddPlayersFpColumn("OMR", dgvcsPosCells);

            AddPlayersFpColumn("FC", dgvcsPosCells);
        }

        private void FormatPlayersGridGK()
        {
            dgPlayersGK.AutoGenerateColumns = false;

            try
            {
                dgPlayersGK.DataCollection = ThisWeekGK;
            }
            catch(Exception)
            {
            }

            dgPlayersGK.Columns.Clear();
            DataGridViewColumn numCol = dgPlayersGK.AddColumn("N", "Number", 20, AG_Style.Numeric | AG_Style.Frozen | AG_Style.N0);
            dgPlayersGK.AddColumn("Name", "NameEx", 60, AG_Style.NameInj | AG_Style.Frozen | AG_Style.ResizeAllCells);
            dgPlayersGK.AddColumn("Age", "wBorn", 32, AG_Style.Age | AG_Style.Frozen);
            dgPlayersGK.AddColumn("Nat", "Nationality", 28, AG_Style.Nationality | AG_Style.Frozen);
            TMR_NumDecColumn dgvc = (TMR_NumDecColumn)dgPlayersGK.AddColumn("ASI", "ASI", 49, AG_Style.NumDec | AG_Style.Frozen);
            dgvc.CellColorStyles = CellColorStyleList.DefaultGainColorStyle();
            dgvc = (TMR_NumDecColumn)dgPlayersGK.AddColumn("TI", "TI", 32, AG_Style.NumDec | AG_Style.Frozen);
            dgvc.CellColorStyles = CellColorStyleList.DefaultGainColorStyle();

            AddPlayersSkillColumnGK("Str");
            AddPlayersSkillColumnGK("Pac");
            AddPlayersSkillColumnGK("Sta");

            AddPlayersSkillColumnGK("Han");
            AddPlayersSkillColumnGK("One");
            AddPlayersSkillColumnGK("Ref");
            AddPlayersSkillColumnGK("Ari");
            AddPlayersSkillColumnGK("Jum");
            AddPlayersSkillColumnGK("Com");
            AddPlayersSkillColumnGK("Kic");
            AddPlayersSkillColumnGK("Thr");

            dgPlayersGK.AddColumn("Rou", "Rou", 30, AG_Style.Numeric | AG_Style.RightJustified);
            dgPlayersGK.AddColumn("SSD", "SSD", 30, AG_Style.Numeric | AG_Style.RightJustified);
            dgPlayersGK.AddColumn("CStr", "CStr", 30, AG_Style.Numeric | AG_Style.RightJustified);

            DataGridViewCellStyle dgvcsPosCells = new DataGridViewCellStyle();
            dgvcsPosCells.Format = "N1";

            AddPlayersFpColumnGK("GK", dgvcsPosCells);
        }

        private void AddPlayersFpColumn(string skill, DataGridViewCellStyle dgvcsPosCells)
        {
            TMR_NumDecColumn dgvc = (TMR_NumDecColumn)dgPlayers.AddColumn(skill, skill, 30, AG_Style.NumDec, dgvcsPosCells);
            dgvc.CellColorStyles = CellColorStyleList.DefaultFpColorStyle();
        }

        private void AddPlayersSkillColumn(string skill)
        {
            TMR_NumDecColumn dgvc = (TMR_NumDecColumn)dgPlayers.AddColumn(skill, skill, 25, AG_Style.NumDec);
            if (Program.Setts.EvidenceGain)
                dgvc.CellColorStyles = CellColorStyleList.DefaultGainColorStyle();
            else
                dgvc.CellColorStyles = CellColorStyleList.NoGainColorStyle();
        }

        private void AddPlayersFpColumnGK(string skill, DataGridViewCellStyle dgvcsPosCells)
        {
            TMR_NumDecColumn dgvc = (TMR_NumDecColumn)dgPlayersGK.AddColumn(skill, skill, 30, AG_Style.NumDec, dgvcsPosCells);
            dgvc.CellColorStyles = CellColorStyleList.DefaultFpColorStyle();
        }

        private void AddPlayersSkillColumnGK(string skill)
        {
            TMR_NumDecColumn dgvc = (TMR_NumDecColumn)dgPlayersGK.AddColumn(skill, skill, 26, AG_Style.NumDec);
            if (Program.Setts.EvidenceGain)
                dgvc.CellColorStyles = CellColorStyleList.DefaultGainColorStyle();
            else
                dgvc.CellColorStyles = CellColorStyleList.NoGainColorStyle();
        }

        private void reloadDataFromFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DB.Clear();
            LoadDB();
            LoadPlayers();
            LoadMatches();
        }

        private void cbDataDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbDataDayGK.SelectedItem = cbDataDay.SelectedItem;

            dgPlayers.DataCollection = null;
            TmSWD selectedItem = (TmSWD)cbDataDay.SelectedItem;
            int absPrevWeek = -1;
            if (cbDataDay.SelectedIndex != cbDataDay.Items.Count - 1)
            {
                TmSWD selectedItemPrev = (TmSWD)cbDataDay.Items[cbDataDay.SelectedIndex + 1];
                absPrevWeek = selectedItemPrev.AbsWeek;
            }

            ThisWeekPlayers = (from c in DB.squadDB.HistData
                               where (c.Week == selectedItem.AbsWeek) && (!c.PlayerRow.IsFPnNull()) && (c.PlayerRow.FPn != 0)
                              select new PlayerData(c, absPrevWeek)) as EnumerableRowCollection<PlayerData>;

            dgPlayers.SetWhen(selectedItem.Date);

            UpdateTable();
        }

        private void cbDataDayGK_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbDataDay.SelectedItem = cbDataDayGK.SelectedItem;

            dgPlayersGK.DataCollection = null;
            TmSWD selectedItem = (TmSWD)cbDataDayGK.SelectedItem;
            int absPrevWeek = -1;
            if (cbDataDayGK.SelectedIndex != cbDataDayGK.Items.Count - 1)
            {
                TmSWD selectedItemPrev = (TmSWD)cbDataDayGK.Items[cbDataDayGK.SelectedIndex + 1];
                absPrevWeek = selectedItemPrev.AbsWeek;
            }

            try
            {
                ThisWeekGK = (from c in DB.squadDB.HistData
                              where (c.Week == selectedItem.AbsWeek) && (!c.PlayerRow.IsFPnNull()) && (c.PlayerRow.FPn == 0)
                              select new PlayerData(c, absPrevWeek)) as EnumerableRowCollection<PlayerData>;
            }
            catch(Exception)
            {
            }

            dgPlayersGK.SetWhen(selectedItem.Date);

            UpdateTableGK();
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkO21GK.Checked != chkO21.Checked)
                chkO21GK.Checked = chkO21.Checked;
            if (chkU21GK.Checked != chkU21.Checked)
                chkU21GK.Checked = chkU21.Checked;
            if (chkBTeamGK.Checked != chkBTeam.Checked)
                chkBTeamGK.Checked = chkBTeam.Checked;

            dgPlayers.DataCollection = null;
            int absPrevWeek = -1;
            if (cbDataDay.SelectedIndex != cbDataDay.Items.Count - 1)
            {
                TmSWD selectedItemPrev = (TmSWD)cbDataDay.Items[cbDataDay.SelectedIndex + 1];
                absPrevWeek = selectedItemPrev.AbsWeek;
            }

            UpdateTable();
        }

        private void UpdateTable()
        {
            if (cbDataDay.Items.Count == 0)
                return;

            TmSWD selectedItem = (TmSWD)cbDataDay.SelectedItem;

            if (ThisWeekPlayers == null)
                return;

            EnumerableRowCollection<PlayerData> TempPlayers = (from c in ThisWeekPlayers
                      where (c.CStr > (decimal)qsMinRating.Value) &&
                          (((showD) && (c.FPn > 0) && (c.FPn < 30)) ||
                          ((showDM) && (c.FPn >= 20) && (c.FPn < 50)) ||
                          ((showM) && (c.FPn >= 40) && (c.FPn < 70)) ||
                          ((showOM) && (c.FPn >= 60) && (c.FPn < 90)) ||
                          ((showF) && (c.FPn >= 80) && (c.FPn <= 90)))
                      select c) as EnumerableRowCollection<PlayerData>;

            if (chkU21.Checked && !chkO21.Checked)
                TempPlayers = (from c in TempPlayers
                              where (c.wBorn > selectedItem.AbsWeek - 21 * 12)
                               select c) as EnumerableRowCollection<PlayerData>;
            else if (!chkU21.Checked && chkO21.Checked)
                TempPlayers = (from c in TempPlayers
                              where (c.wBorn < selectedItem.AbsWeek - 21 * 12)
                              select c) as EnumerableRowCollection<PlayerData>;

            if (chkBTeam.Checked)
                Players = (from c in TempPlayers
                          where (c.BTeam == true)
                           select c) as EnumerableRowCollection<PlayerData>;
            else
                Players = (from c in TempPlayers
                          where (c.BTeam == false)
                          select c) as EnumerableRowCollection<PlayerData>;

            dgPlayers.SetWhen(selectedItem.Date);

            if (Players.Count() > 0)
            {
                dgPlayers.DataCollection = Players;
            }
            else
            {
                dgPlayers.DataCollection = null;
                dgPlayers.Rows.Clear();
            }
        }

        private void UpdateTableGK()
        {
            if (cbDataDayGK.Items.Count == 0)
                return;

            TmSWD selectedItem = (TmSWD)cbDataDayGK.SelectedItem;

            EnumerableRowCollection<PlayerData> TempPlayers = (from c in ThisWeekGK
                                                               where (c.CStr > (decimal)qsMinRatingGK.Value) &&
                                                                   (c.FPn == 0) 
                                                               select c) as EnumerableRowCollection<PlayerData>;

            if (chkU21GK.Checked && !chkO21GK.Checked)
                TempPlayers = (from c in TempPlayers
                               where (c.wBorn > selectedItem.AbsWeek - 21 * 12)
                               select c) as EnumerableRowCollection<PlayerData>;
            else if (!chkU21GK.Checked && chkO21GK.Checked)
                TempPlayers = (from c in TempPlayers
                               where (c.wBorn < selectedItem.AbsWeek - 21 * 12)
                               select c) as EnumerableRowCollection<PlayerData>;

            if (chkBTeamGK.Checked)
                GKs = (from c in TempPlayers
                           where (c.BTeam == true)
                           select c) as EnumerableRowCollection<PlayerData>;
            else
                GKs = (from c in TempPlayers
                           where (c.BTeam == false)
                           select c) as EnumerableRowCollection<PlayerData>;

            dgPlayersGK.SetWhen(selectedItem.Date);

            if (GKs.Count() > 0)
            {
                dgPlayersGK.DataCollection = GKs;
            }
            else
            {
                dgPlayersGK.DataCollection = null;
                dgPlayersGK.Rows.Clear();
            }
        }

        public bool showD
        {
            get
            {
                return chkShowD.Checked ||
                    (!chkShowD.Checked && !chkShowDM.Checked && !chkShowM.Checked && !chkShowOM.Checked && !chkShowF.Checked);
            }
        }
        public bool showF
        {
            get
            {
                return chkShowF.Checked ||
                    (!chkShowD.Checked && !chkShowDM.Checked && !chkShowM.Checked && !chkShowOM.Checked && !chkShowF.Checked);
            }
        }
        public bool showM
        {
            get
            {
                return chkShowM.Checked ||
                    (!chkShowD.Checked && !chkShowDM.Checked && !chkShowM.Checked && !chkShowOM.Checked && !chkShowF.Checked);
            }
        }
        public bool showOM
        {
            get
            {
                return chkShowOM.Checked ||
                    (!chkShowD.Checked && !chkShowDM.Checked && !chkShowM.Checked && !chkShowOM.Checked && !chkShowF.Checked);
            }
        }
        public bool showDM
        {
            get
            {
                return chkShowDM.Checked ||
                    (!chkShowD.Checked && !chkShowDM.Checked && !chkShowM.Checked && !chkShowOM.Checked && !chkShowF.Checked);
            }
        }

        private void qsMinRating_ValueChanged(float NewValue)
        {
            if (qsMinRatingGK.Value != NewValue)
                qsMinRatingGK.Value = NewValue;
            UpdateTable();
        }

        private void qsMinRatingGK_ValueChanged(float NewValue)
        {
            if (qsMinRating.Value != NewValue)
                qsMinRating.Value = NewValue;
            UpdateTableGK();
        }

        private void dgPlayers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgPlayers.AeroDataGrid_ColumnHeaderMouseClick<PlayerData>(sender, e);
        }

        private void dgPlayersGK_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgPlayersGK.AeroDataGrid_ColumnHeaderMouseClick<PlayerData>(sender, e);
        }

        private void chkShowGK_CheckedChanged(object sender, EventArgs e)
        {
            if (chkO21.Checked != chkO21GK.Checked)
                chkO21.Checked = chkO21GK.Checked;
            if (chkU21.Checked != chkU21GK.Checked)
                chkU21.Checked = chkU21GK.Checked;
            if (chkBTeam.Checked != chkBTeamGK.Checked)
                chkBTeam.Checked = chkBTeamGK.Checked;

            dgPlayersGK.DataCollection = null;
            int absPrevWeek = -1;
            if (cbDataDayGK.SelectedIndex != cbDataDayGK.Items.Count - 1)
            {
                TmSWD selectedItemPrev = (TmSWD)cbDataDayGK.Items[cbDataDayGK.SelectedIndex + 1];
                absPrevWeek = selectedItemPrev.AbsWeek;
            }

            UpdateTableGK();
        }


        public bool stopCall { get; set; }

        private void contextMenuPlayersPage_Opening(object sender, CancelEventArgs e)
        {
            movePlayerToATeamToolStripMenuItem.Visible = chkBTeam.Checked;
            movePlayerToBTeamToolStripMenuItem.Visible = !chkBTeam.Checked;
        }

        private void movePlayerToBTeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<PlayerData> listPlayerData = new List<PlayerData>();

            if (tabMain.SelectedTab == tabSquad)
            {
                foreach (DataGridViewRow player in dgPlayers.SelectedRows)
                    listPlayerData.Add((PlayerData)player.DataBoundItem);

                foreach (PlayerData pd in listPlayerData)
                    pd.BTeam = true;

                UpdateTable();
            }
            else if (tabMain.SelectedTab == tabGK)
            {
                foreach (DataGridViewRow player in dgPlayersGK.SelectedRows)
                    listPlayerData.Add((PlayerData)player.DataBoundItem);

                foreach (PlayerData pd in listPlayerData)
                    pd.BTeam = true;

                UpdateTableGK();
            }
        }

        private void movePlayerToATeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<PlayerData> listPlayerData = new List<PlayerData>();

            if (tabMain.SelectedTab == tabSquad)
            {
                foreach (DataGridViewRow player in dgPlayers.SelectedRows)
                    listPlayerData.Add((PlayerData)player.DataBoundItem);

                foreach (PlayerData pd in listPlayerData)
                    pd.BTeam = false;

                UpdateTable();
            }
            else if (tabMain.SelectedTab == tabGK)
            {
                foreach (DataGridViewRow player in dgPlayersGK.SelectedRows)
                    listPlayerData.Add((PlayerData)player.DataBoundItem);

                foreach (PlayerData pd in listPlayerData)
                    pd.BTeam = false;

                UpdateTableGK();
            }
        }

        private void tsOptions_Click(object sender, EventArgs e)
        {
            OptionsForm of = new OptionsForm(Program.Setts, this.DB);
            if (of.ShowDialog() == DialogResult.OK)
            {
                FormatPlayersGrid();
                FormatPlayersGridGK();
                UpdateTable();
                UpdateTableGK();
            }
        }

        #region Browser Code
        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {

        }

        private void tsbPrevPlayer_Click(object sender, EventArgs e)
        {

        }

        private void tsbNextPlayer_Click(object sender, EventArgs e)
        {

        }

        private void navigateProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void navigateReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevMatch_Click(object sender, EventArgs e)
        {

        }

        private void btnNextMatch_Click(object sender, EventArgs e)
        {

        }

        private void tsbNavigateMainTeamMatches_Click(object sender, EventArgs e)
        {

        }

        private void tsbNavigateReservesMatches_Click(object sender, EventArgs e)
        {

        }

        private void addExtraTeamToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void tsbChangeToConfiguredExtraTeam_Click(object sender, EventArgs e)
        {

        }

        private void loadFromBackupFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sendThisPageToLedLennonForDebugToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsbScouts_Click(object sender, EventArgs e)
        {

        }

        private void tsbImportSquad_Click(object sender, EventArgs e)
        {
            ntrBrowser.Goto(Browser.Pages.Players);
        }

        private void tsbTrainingTraining_Click(object sender, EventArgs e)
        {

        }

        private void tsbMatchListA_Click(object sender, EventArgs e)
        {

        }

        private void tsbMatchListB_Click(object sender, EventArgs e)
        {

        }

        private void tsbMatchSquadA_Click(object sender, EventArgs e)
        {

        }

        private void tsbMatchSquadB_Click(object sender, EventArgs e)
        {

        }

        private void tsbImport_Click(object sender, EventArgs e)
        {
        }
        #endregion

        private void ntrBrowser_ImportedContent(Content content)
        {
            // Check if there is already a week in the code
            DB.MergeContent(content);

            DB.Save(Program.Setts.DefaultDirectory);

            SetDatesList();

            UpdateBrowserNavigationPanel();
        }

        private void reloadOldReleaseDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DB.OwnedSquadsList.Count == 0)
            {
                MessageBox.Show("Please import all the team you manage, first");
                return;
            }

            folderBrowserDialog.SelectedPath = Program.Setts.DefaultDirectory;
            folderBrowserDialog.Description = "Select the folder with old DB";

            if (folderBrowserDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
            {
                MessageBox.Show("You have to select a folder to load the data from the previous release", "Load Data from Old release");
                return;
            }

            DirectoryInfo di = new DirectoryInfo(folderBrowserDialog.SelectedPath);
            LoadOldDBRecursively(di);

            SetDatesList();

            DB.squadDB.UpdateDecimalsHistory();

            // Save in format 5
            DB.Save(Program.Setts.DefaultDirectory);

            LoadPlayers();
            LoadMatches();
        }

        private void LoadOldDBRecursively(DirectoryInfo di)
        {
            LoadOldDB(di.FullName);

            foreach (DirectoryInfo directory in di.GetDirectories())
                LoadOldDBRecursively(directory);
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


            lineupControl.SetMatchData(md, Program.Setts.YourTeamLeft);

            if ((!Program.Setts.YourTeamLeft) || md.IsHome)
            {
                lblNameTeamHome.Text = md.Home.value;
                lblNameTeamHome.ForeColor = md.Home.tagColor;
                lblNameTeamAway.Text = md.Away.value;
                lblNameTeamAway.ForeColor = md.Away.tagColor;
                lblScore.Text = md.ScoreString.value;
            }
            else
            {
                lblNameTeamHome.Text = md.Away.value;
                lblNameTeamHome.ForeColor = md.Away.tagColor;
                lblNameTeamAway.Text = md.Home.value;
                lblNameTeamAway.ForeColor = md.Home.tagColor;
                lblScore.Text = md.Score.away.ToString() + "-" + md.Score.home.ToString();
            }

            if (Program.Setts.YourTeamLeft || md.IsHome)
            {
                AnalysisHome = ActionsList.ParseAsTable(md.YActions);
                AnalysisAway = ActionsList.ParseAsTable(md.OActions);
                AnalysisMdHome = ActionsList.ParseAsItemDictionary(md.YActions);
                AnalysisMdAway = ActionsList.ParseAsItemDictionary(md.OActions);
            }
            else
            {
                AnalysisHome = ActionsList.ParseAsTable(md.OActions);
                AnalysisAway = ActionsList.ParseAsTable(md.YActions);
                AnalysisMdAway = ActionsList.ParseAsItemDictionary(md.YActions);
                AnalysisMdHome = ActionsList.ParseAsItemDictionary(md.OActions);
            }

            //dgAnalysisHome.DataCollection = AnalysisHome;
            //dgAnalysisAway.DataCollection = AnalysisAway;

            if (lblNameTeamHome.ForeColor.GetBrightness() > 0.45)
                lblNameTeamHome.ForeColor = Color.Black;
            if (lblNameTeamAway.ForeColor.GetBrightness() > 0.45)
                lblNameTeamAway.ForeColor = Color.Black;

            // Fill Matchstats
            string[] Stats = HTML_Parser.Split(md.Stats, ";;");
            msGameBreakDown.SetData("Possession,{0};Shots (Total),{0};Shots On Target,{0};Set Pieces,{0};Penalties,{0}",
                Stats);

            Dictionary<string, string> TM_Acronyms = new Dictionary<string, string>()
            {
                // Bal", "Count", "Wing", "Short", "Long", "Filt"
                // "Norm", "VeDef", "Def", "SlDef", "Norm", "SlOff", "Off", "VrOff"
                { "Bal", "Balanced"},
                { "Count", "Counterattack"},
                { "Wing", "Wing"},
                { "Short", "Short Passes"},
                { "Long", "Long Passes"},
                { "Filt", "Filtering"},
                { "VeDef", "Very Defensive"},
                { "Def", "Defensive"},
                { "SlDef", "Slightly Defensive"},
                { "SlOff", "Slightly Offensive"},
                { "Off", "Offensive"},
                { "VrOff", "Very Offensive"},
                { "Norm", "Normal"},
            };

            string[] Lineups = HTML_Parser.Split(md.LineUps, ";");
            string[] AttackStyles = HTML_Parser.Split(md.AttackStyles, ";");
            string[] Mentalities = HTML_Parser.Split(md.Mentalities, ";");
            string[] Tactics = null;
            if (Lineups != null)
            {
                Tactics = new string[2];
                Tactics[0] = Lineups[0] + ";" + TM_Acronyms[AttackStyles[0]] + ";" + TM_Acronyms[Mentalities[0]];
                Tactics[1] = Lineups[1] + ";" + TM_Acronyms[AttackStyles[1]] + ";" + TM_Acronyms[Mentalities[1]];
            }
            msTacticsBreakdown.SetData("Lineups,{0};AttackStyles,{0};Mentalities,{0}",
                Tactics);

            msActionsHome.SetItemDictionary(AnalysisMdHome);
            msActionsAway.SetItemDictionary(AnalysisMdAway);
        }

        private void btnEnlargeMatchWindow_Click(object sender, EventArgs e)
        {
            if (btnEnlargeMatchWindow.Text == ">>")
            {
                int offw = tabMatches.Width - 20;
                btnEnlargeMatchWindow.Text = "<<";
                dgMatches.Width = (offw * 75) / 100;

                lblNameTeamAway.Font = new Font(lblNameTeamAway.Font.FontFamily, 8f);
                lblNameTeamHome.Font = new Font(lblNameTeamAway.Font.FontFamily, 8f);
                lblScore.Font = new Font(lblNameTeamAway.Font.FontFamily, 8f);
            }
            else
            {
                btnEnlargeMatchWindow.Text = ">>";
                dgMatches.Width = 542;

                lblNameTeamAway.Font = new Font(lblNameTeamAway.Font.FontFamily, 14f);
                lblNameTeamHome.Font = new Font(lblNameTeamAway.Font.FontFamily, 14f);
                lblScore.Font = new Font(lblNameTeamAway.Font.FontFamily, 14f);
                lineupControl.SetFontSize(8f);
            }

            tabMatches_Resize(sender, e);
        }

        private void tabMatches_Resize(object sender, EventArgs e)
        {
            int offx = dgMatches.Width + 10;
            int offw = tabMatches.Width - offx - 10;

            if (btnEnlargeMatchWindow.Text == "<<")
            {
                offw = tabMatches.Width - 20;
                dgMatches.Width = (offw * 75) / 100;
                offx = dgMatches.Width + 10;
                offw = tabMatches.Width - offx - 10;
            }

            lblNameTeamHome.Left = offx;
            lblNameTeamHome.Width = (int)(offw * 4.5 / 10);
            lblNameTeamAway.Left = offx + (int)(offw * 5.5 / 10);
            lblNameTeamAway.Width = (int)(offw * 4.5 / 10);
            lblScore.Left = offx + (int)(offw * 4.5 / 10);
            lblScore.Width = (int)(offw / 10);

            lineupControl.Left = offx;
            lineupControl.Width = offw;
            lineupControl.Height = (offw * 60)/ 100;

            int iAnalysisWidth = 235;

            msActionsHome.Left = offx;
            msActionsHome.Width = iAnalysisWidth;
            msActionsHome.Top = lineupControl.Top + lineupControl.Height + 5;
            msActionsHome.Height = tabMatches.Height - lineupControl.Top - lineupControl.Height - 10;

            msActionsAway.Left = offx + offw - iAnalysisWidth;
            msActionsAway.Width = iAnalysisWidth;
            msActionsAway.Top = lineupControl.Top + lineupControl.Height + 5;
            msActionsAway.Height = tabMatches.Height - lineupControl.Top - lineupControl.Height - 10;

            msGameBreakDown.Top = lineupControl.Top + lineupControl.Height + 5;
            msGameBreakDown.Height = 102;
            msGameBreakDown.Left = offx + iAnalysisWidth + 5;
            msGameBreakDown.Width = offw - 2 * iAnalysisWidth - 10;

            msTacticsBreakdown.Top = msGameBreakDown.Top + msGameBreakDown.Height + 5;
            msTacticsBreakdown.Height = 85;
            msTacticsBreakdown.Left = offx + iAnalysisWidth + 5;
            msTacticsBreakdown.Width = offw - 2 * iAnalysisWidth - 10;

            lineupControl.SetFontSize(lineupControl.Width / 100f);
        }

        private void searchAndImportAllSavedPagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = Program.Setts.DefaultDirectory;
            folderBrowserDialog.Description = "Select the folder with saved pages";

            if (folderBrowserDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
            {
                MessageBox.Show("You have to select a folder to load the data from the previous release", "Load Data from saved pages");
                return;
            }

            DirectoryInfo di = new DirectoryInfo(folderBrowserDialog.SelectedPath);
            LoadSavedPagesRecursively(di);

            SetDatesList();

            DB.squadDB.UpdateDecimalsHistory();

            // Save in format 5
            DB.Save(Program.Setts.DefaultDirectory);

            LoadPlayers();
            LoadMatches();
        }

        private void LoadSavedPagesRecursively(DirectoryInfo di)
        {
            LoadSavedPages(di.FullName);

            foreach (DirectoryInfo directory in di.GetDirectories())
                LoadSavedPagesRecursively(directory);
        }

        private void LoadSavedPages(string folder)
        {
            try
            {
                DB.LoadSavedPages(folder, ref sf, (Program.Setts.Trace > 0));
            }
            catch (Exception)
            {
            }
        }

        private void recalculateDecimalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DB.squadDB.UpdateDecimalsHistory();

            DB.Save(Program.Setts.DefaultDirectory);

            LoadPlayers();
        }

        private void cmbSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime startDate = TmWeek.GetDateTimeOfSeasonStart((int)cmbSeason.SelectedItem);
            DateTime endDate = startDate.AddDays(7 * 12);

            ThisSeasonMatches = (from c in DB.squadDB.Match
                                 where (!c.IsDateNull()) && (c.Date < endDate) && (c.Date > startDate)
                                 select new MatchData(c)).OrderBy(p => p.Date);

            dgMatches.DataCollection = ThisSeasonMatches;
        }

        private void msActionsHome_Load(object sender, EventArgs e)
        {

        }

        private void openPlayerProfilePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow player;

            if (tabMain.SelectedTab == tabSquad)
            {
                player = dgPlayers.SelectedRows[0];
            }
            else if (tabMain.SelectedTab == tabGK)
            {
                player = dgPlayersGK.SelectedRows[0];
            }
            else
            {
                return;
            }

            PlayerData playerData = (PlayerData)player.DataBoundItem;

            TmSWD selectedWeek = (TmSWD)cbDataDay.SelectedItem;

            TR3_PlayerForm playerForm = new TR3_PlayerForm(DB.squadDB, playerData, selectedWeek);
            playerForm.ShowDialog();
        }
    }
}
