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
        public EnumerableRowCollection<PlayerData> ThisWeekGK;
        public EnumerableRowCollection<PlayerData> Players;
        public EnumerableRowCollection<PlayerData> GKs;
        Browser TheBrowser = new Browser();

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
            }
            catch (Exception ex)
            {
            }

            LoadPlayersDB();
        }

        private void LoadPlayersDB()
        {
            try
            {
                DB.Load(Program.Setts.DefaultDirectory, ref sf, (Program.Setts.Trace > 0));

                var Dates = (from c in DB.squadDB.HistData
                             group c by c.Week into g
                             select g).OrderByDescending(p => p.Key);

                TmSWD tmSwdSelected = null;
                cbDataDay.Items.Clear();
                cbDataDayGK.Items.Clear();

                foreach (var date in Dates)
                {
                    TmSWD tmSWD = TmWeek.TmWeekToSWD(date.Key);

                    if (DB.latestDataWeek == (int)date.Key)
                        tmSwdSelected = tmSWD;

                    cbDataDay.Items.Add(tmSWD);
                    cbDataDayGK.Items.Add(tmSWD);
                }

                cbDataDay.SelectedItem = tmSwdSelected;
                cbDataDayGK.SelectedItem = tmSwdSelected;
            }
            catch (Exception)
            {
            }

            TmSWD selectedItem = (TmSWD)cbDataDay.SelectedItem;

            int absPrevWeek = -1;
            if (cbDataDay.SelectedIndex != cbDataDay.Items.Count)
            {
                TmSWD selectedItemPrev = (TmSWD)cbDataDay.Items[cbDataDay.SelectedIndex + 1];
                absPrevWeek = selectedItemPrev.AbsWeek;
            }

            ThisWeekPlayers = (from c in DB.squadDB.HistData
                              where (c.Week == selectedItem.AbsWeek) && (c.PlayerRow.FPn != 0)
                              select new PlayerData(c, absPrevWeek)).OrderBy(p => p.Number);
            ThisWeekGK = (from c in DB.squadDB.HistData
                              where (c.Week == selectedItem.AbsWeek) && (c.PlayerRow.FPn == 0)
                              select new PlayerData(c, absPrevWeek)).OrderBy(p => p.Number);

            FormatPlayersGrid();
            FormatPlayersGridGK();

            sf.Close();
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
            dgPlayers.AddColumn("ASI", "ASI", 49, AG_Style.NumDec | AG_Style.Frozen);
            dgPlayers.AddColumn("TI", "TI", 32, AG_Style.NumDec | AG_Style.Frozen);

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
            dgPlayersGK.DataCollection = ThisWeekGK;

            dgPlayersGK.Columns.Clear();
            DataGridViewColumn numCol = dgPlayersGK.AddColumn("N", "Number", 20, AG_Style.Numeric | AG_Style.Frozen | AG_Style.N0);
            dgPlayersGK.AddColumn("Name", "NameEx", 60, AG_Style.NameInj | AG_Style.Frozen | AG_Style.ResizeAllCells);
            dgPlayersGK.AddColumn("Age", "wBorn", 32, AG_Style.Age | AG_Style.Frozen);
            dgPlayersGK.AddColumn("Nat", "Nationality", 28, AG_Style.Nationality | AG_Style.Frozen);
            dgPlayersGK.AddColumn("ASI", "ASI", 49, AG_Style.NumDec | AG_Style.Frozen);
            dgPlayersGK.AddColumn("TI", "TI", 32, AG_Style.NumDec | AG_Style.Frozen);

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
            LoadPlayersDB();
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
                              where (c.Week == selectedItem.AbsWeek) && (c.PlayerRow.FPn != 0)
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

            ThisWeekGK = (from c in DB.squadDB.HistData
                          where (c.Week == selectedItem.AbsWeek) && (c.PlayerRow.FPn == 0)
                          select new PlayerData(c, absPrevWeek)) as EnumerableRowCollection<PlayerData>;

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
            TmSWD selectedItem = (TmSWD)cbDataDay.SelectedItem;

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

        //private void dgPlayersGK_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if (e.RowIndex == -1)
        //        return;
        //    if (e.Button == System.Windows.Forms.MouseButtons.Left)
        //        return;

        //    if (Control.ModifierKeys != Keys.Control)
        //        foreach (DataGridViewRow row in dgPlayersGK.SelectedRows)
        //        {
        //            row.Selected = false;
        //        }

        //    dgPlayersGK.Rows[e.RowIndex].Selected = true; // !dgPlayersGK.Rows[e.RowIndex].Selected;
        //}

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
            OptionsForm of = new OptionsForm(Program.Setts);
            if (of.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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

        private void webBrowser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
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

        private void tsbPrev_Click(object sender, EventArgs e)
        {

        }

        private void tsbNext_Click(object sender, EventArgs e)
        {

        }

        private void addExtraTeamToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void tsbChangeToConfiguredExtraTeam_Click(object sender, EventArgs e)
        {

        }

        private void gotoMToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gotoAdobeFlashplayerPageToolStripMenuItem_Click(object sender, EventArgs e)
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
            TheBrowser.Import();
        }
        #endregion
    }
}
