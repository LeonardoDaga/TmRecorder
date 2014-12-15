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
        public EnumerableRowCollection<PlayerData> Players;

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

                foreach (var date in Dates)
                {
                    TmSWD tmSWD = TmWeek.TmWeekToSWD(date.Key);

                    if (DB.latestDataWeek == (int)date.Key)
                        tmSwdSelected = tmSWD;

                    cbDataDay.Items.Add(tmSWD);
                }

                cbDataDay.SelectedItem = tmSwdSelected;
                // dtDataDay.Value = DB.latestDataDay;
                // DB.CleanOldData();
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

            ThisWeekPlayers = from c in DB.squadDB.HistData
                              where (c.Week == selectedItem.AbsWeek) && (c.PlayerRow.FPn != 0)
                              select new PlayerData(c, absPrevWeek);

            FormatPlayersGrid();

            sf.Close();
        }

        private void FormatPlayersGrid()
        {
            dgPlayers.AutoGenerateColumns = false;
            varDataBindingSource.DataSource = ThisWeekPlayers;

            dgPlayers.Columns.Clear();
            dgPlayers.AddColumn("N", "Number", 20, AG_Style.Numeric | AG_Style.Frozen);
            dgPlayers.AddColumn("FP", "FPn", 42, AG_Style.FavPosition | AG_Style.Frozen);
            dgPlayers.AddColumn("Name", "Name", 60, AG_Style.NameInj | AG_Style.Frozen | AG_Style.ResizeAllCells);
            dgPlayers.AddColumn("Age", "wBorn", 32, AG_Style.Age | AG_Style.Frozen);
            dgPlayers.AddColumn("Nat", "Nationality", 28, AG_Style.Nationality | AG_Style.Frozen);
            dgPlayers.AddColumn("ASI", "ASI", 49, AG_Style.NumDec | AG_Style.Frozen);

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

        private void AddPlayersFpColumn(string skill, DataGridViewCellStyle dgvcsPosCells)
        {
            TMR_NumDecColumn dgvc = (TMR_NumDecColumn)dgPlayers.AddColumn(skill, skill, 30, AG_Style.NumDec, dgvcsPosCells);
            dgvc.CellColorStyles = CellColorStyleList.DefaultFpColorStyle();
        }

        private void AddPlayersSkillColumn(string skill)
        {
            TMR_NumDecColumn dgvc = (TMR_NumDecColumn)dgPlayers.AddColumn(skill, skill, 25, AG_Style.NumDec);
            dgvc.CellColorStyles = CellColorStyleList.DefaultGainColorStyle();
        }

        private void reloadDataFromFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DB.Clear();
            LoadPlayersDB();
        }

        private void cbDataDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            varDataBindingSource.DataSource = null;
            TmSWD selectedItem = (TmSWD)cbDataDay.SelectedItem;
            int absPrevWeek = -1;
            if (cbDataDay.SelectedIndex != cbDataDay.Items.Count - 1)
            {
                TmSWD selectedItemPrev = (TmSWD)cbDataDay.Items[cbDataDay.SelectedIndex + 1];
                absPrevWeek = selectedItemPrev.AbsWeek;
            }

            ThisWeekPlayers = from c in DB.squadDB.HistData
                              where (c.Week == selectedItem.AbsWeek) && (c.PlayerRow.FPn != 0)
                              select new PlayerData(c, absPrevWeek);

            dgPlayers.SetWhen(selectedItem.Date);
            varDataBindingSource.DataSource = ThisWeekPlayers;
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            varDataBindingSource.DataSource = null;
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

            Players = from c in ThisWeekPlayers
                      where (c.CStr > (decimal)qsMinRating.Value) &&
                          (((showD) && (c.FPn > 0) && (c.FPn < 30)) ||
                          ((showDM) && (c.FPn >= 20) && (c.FPn < 50)) ||
                          ((showM) && (c.FPn >= 40) && (c.FPn < 70)) ||
                          ((showOM) && (c.FPn >= 60) && (c.FPn < 90)) ||
                          ((showF) && (c.FPn >= 80) && (c.FPn <= 90)))
                      select c;

            //if (chkU21.Checked && !chkO21.Checked)
            //    TempPlayers = from c in TempPlayers
            //              where (c.wBorn > selectedItem.AbsWeek - 21 * 12)
            //              select c;
            //else if (chkU21.Checked && !chkO21.Checked)
            //    TempPlayers = from c in TempPlayers
            //              where (c.wBorn < selectedItem.AbsWeek - 21 * 12)
            //              select c;

            //if (chkBTeam.Checked)
            //    Players = from c in TempPlayers
            //              where (c.BTeam == true)
            //              select c;
            //else
            //    Players = from c in TempPlayers
            //              where (c.BTeam == false)
            //              select c;

            dgPlayers.SetWhen(selectedItem.Date);
            varDataBindingSource.DataSource = Players;

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
            UpdateTable();
        }

    }
}
