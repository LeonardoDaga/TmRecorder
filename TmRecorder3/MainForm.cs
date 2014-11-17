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

        //public void FillTable()
        //{
        //    Players = from c in dataTemp.VarData
        //                  select new Player(c.PlayerRow.Nome, c.Week, c.ASI);

        //    varDataBindingSource.DataSource = Players;
        //}

        //private EnumerableRowCollection<Player> _Players;
        //public EnumerableRowCollection<Player> Players
        //{
        //    get { return _Players; }
        //    set { _Players = value; }
        //}

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

                    DB.Load(Program.Setts.DefaultDirectory, ref sf, (Program.Setts.Trace > 0));

                    // DB.CleanOldData();
                }
                else
                {
                    // DB.Load(Program.Setts.DefaultDirectory);
                }


                /*
                evidenceSkillsForGainsToolStripMenuItem.Checked = Program.Setts.EvidenceGain;
                evidenceSkillsForGainsMenuItem2.Checked = Program.Setts.EvidenceGain;

                if (Program.Setts.PlayerType == 2) // PRO player
                {
                }
                else
                {
                    tsbSquadA.Text = "Squad";
                    tsbOverview.Visible = false;
                    tsbSquadB.Visible = false;
                    reserveTeamToolStripMenuItem.Visible = false;
                }

                tsBrowsePlayers.Visible = false;
                tsBrowseMatches.Visible = false;
                */
            }
            catch (Exception ex)
            {
            }

            Players = from c in DB.squadDB.HistData
                      select new PlayerData(c.PlayerRow.Name, c.Week, c.ASI);

            varDataBindingSource.DataSource = Players;

            sf.Close();
        }
    }
}
