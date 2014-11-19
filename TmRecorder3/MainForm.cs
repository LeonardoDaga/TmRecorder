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

namespace TmRecorder3
{
    public partial class MainForm : Form
    {
        SplashForm sf = null;
        public EnumerableRowCollection<PlayerData> Players;

        public MainForm()
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

                var Dates = from c in DB.squadDB.HistData
                            group c by c.Week into g
                            select g;

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

            // c is an HistDataRow
            Players = from c in DB.squadDB.HistData
                      where c.Week == selectedItem.AbsWeek
                      select new PlayerData(c);

            FormatPlayersGrid();

            sf.Close();
        }

        private void FormatPlayersGrid()
        {
            dgPlayers.AutoGenerateColumns = false;
            varDataBindingSource.DataSource = Players;

            dgPlayers.Columns.Clear();
            dgPlayers.AddColumn("N", "Number", 20, AG_Style.Numeric | AG_Style.Frozen);
            dgPlayers.AddColumn("Age", "wBorn", 32, AG_Style.Age | AG_Style.Frozen);
            dgPlayers.AddColumn("Week", "SWeek", 50, AG_Style.String | AG_Style.Frozen);
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
            
            Players = from c in DB.squadDB.HistData
                      where c.Week == selectedItem.AbsWeek
                      select new PlayerData(c);
            varDataBindingSource.DataSource = Players;
        }
    }
}
