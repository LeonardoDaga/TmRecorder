using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;
using System.IO;
using NTR_Forms;
using Languages;

namespace TmRecorder2
{
    public partial class MainForm : Form
    {
        SplashForm sf = null;

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

        private void importDataFromTmR1xFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

                    DB.LoadFromPreviousDB(Program.Setts.DefaultDirectory, ref sf, (Program.Setts.Trace > 0));

                    // DB.CleanOldData();
                }
                else
                {
                    DB.Load(Program.Setts.DefaultDirectory);
                }

                bindPL.DataSource = DB.teamDS;
                bindGK.DataSource = DB.teamDS;

                sf.Close();

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
        }

        private void OpenOptionsForm()
        {
            OptionsForm of = new OptionsForm();

            of.DataDirectory = Program.Setts.DefaultDirectory;
            of.InstallationDirectory = Program.Setts.InstallationDirectory;
            of.DefaultNation = Program.Setts.HomeNation;
            of.NormalizeGains = Program.Setts.NormalizeGains;
            of.GainSet = Program.Setts.GainSet;
            of.UseTMRBrowser = Program.Setts.UseTMRBrowser;
            of.MacthTypes = Program.Setts.MatchTypes;
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

            if (of.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void tsOptions_Click(object sender, EventArgs e)
        {
            OpenOptionsForm();
        }

    }
}
