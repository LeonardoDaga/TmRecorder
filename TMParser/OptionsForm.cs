using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TMRecorder.Properties;
using Common;
using System.Diagnostics;

namespace TMRecorder
{
    public partial class OptionsForm : Form
    {
        NationsDS Nations = null;

        public Function.FunctionType RoutineFunction
        {
            get
            {
                switch (cmbRoutineFunction.SelectedIndex)
                {
                    case 0: return Function.FunctionType.Linear;
                    case 1: return Function.FunctionType.Exponential;
                    case 2: return Function.FunctionType.Log;
                    case 3: return Function.FunctionType.Quadratic;
                    default: return Function.FunctionType.None;
                }
            }
            set
            {
                switch (value)
                {
                    case Function.FunctionType.Linear: cmbRoutineFunction.SelectedIndex = 0; break;
                    case Function.FunctionType.Exponential: cmbRoutineFunction.SelectedIndex = 1; break;
                    case Function.FunctionType.Log: cmbRoutineFunction.SelectedIndex = 2; break;
                    case Function.FunctionType.Quadratic: cmbRoutineFunction.SelectedIndex = 3; break;
                    case Function.FunctionType.None: cmbRoutineFunction.SelectedIndex = 4; break;
                }
            }
        }

        public float[] RoutineParameters
        {
            get
            {
                try
                {
                    return Common.Utility.StringToFloatArray(txtRoutineParameters.Text);
                }
                catch (Exception)
                {
                    return new float[] { 1.0F, 0.0F };
                }
            }
            set
            {
                txtRoutineParameters.Text = Common.Utility.FloatArrayToString(value);
            }
        }

        public int PlayerType
        {
            get 
            {
                if (rbPro.Checked)
                    return 2;
                else if (rbNonPro.Checked)
                    return 1;
                else
                    return 0;
            }
            
            set 
            {
                if (value == 0)
                {
                    rbPro.Checked = false;
                    rbNonPro.Checked = false;
                }
                else if (value == 1)
                {
                    rbPro.Checked = false;
                    rbNonPro.Checked = true;
                }
                else if (value == 2)
                {
                    rbPro.Checked = true;
                    rbNonPro.Checked = false;
                }
            }
        }

        public int ShowMatchOptions
        {
            get 
            {
                if ((chkShowMainMatches.Checked) && (!chkShowReservesMatches.Checked))
                    return 1;
                else if ((!chkShowMainMatches.Checked) && (chkShowReservesMatches.Checked))
                    return 2;
                else // ((chkShowMainMatches.Checked == 0) && (chkShowReservesMatches == 0))
                    return 0;
            }
            set 
            {
                if (value == 1)
                {
                    chkShowMainMatches.Checked = true;
                    chkShowReservesMatches.Checked = false;
                }
                else if (value == 2)
                {
                    chkShowMainMatches.Checked = false;
                    chkShowReservesMatches.Checked = true;
                }
                else
                {
                    chkShowMainMatches.Checked = false;
                    chkShowReservesMatches.Checked = false;
                }
            }
        }

        public string MainSquadName
        {
            get { return txtMainSquadName.Text; }
            set { txtMainSquadName.Text = value; }
        }

        public string ReserveSquadName
        {
            get { return txtReserveSquadName.Text; }
            set { txtReserveSquadName.Text = value; }
        }

        public int MainSquadID
        {
            get { return int.Parse(txtMainSquadID.Text); }
            set { txtMainSquadID.Text = value.ToString(); }
        }

        public int ReserveSquadID
        {
            get { return int.Parse(txtReserveSquadID.Text); }
            set { txtReserveSquadID.Text = value.ToString(); }
        }

        public string DataDirectory
        {
            get { return txtDataDirectory.Text; }
            set { txtDataDirectory.Text = value; }
        }

        public string InstallationDirectory
        {
            get { return txtInstallationDirectory.Text; }
            set { txtInstallationDirectory.Text = value; }
        }

        public bool NormalizeGains
        {
            get { return chkNormalizeGains.Checked; }
            set { chkNormalizeGains.Checked = value; }
        }

        public bool EvidenceGains
        {
            get { return chkEvidenceGains.Checked; }
            set { chkEvidenceGains.Checked = value; }
        }

        DirectoryInfo diReportFile = null;
        public string ReportParsingFile
        {
            get
            {
                FileInfo fi = new FileInfo(Path.Combine(diReportFile.Name, (string)lbReportFileLanguage.SelectedItem));
                return fi.FullName;
            }
            set
            {
                FileInfo fiSelected = new FileInfo(value);
                diReportFile = new DirectoryInfo(fiSelected.DirectoryName);

                if (!diReportFile.Exists)
                {
                    MessageBox.Show("Error accessing the folder " + fiSelected.DirectoryName + ". I suggest you to reinstall the application");
                    value = "NoReportParsingFile";
                    return;
                }

                lbReportFileLanguage.Items.Clear();

                FileInfo[] fis = diReportFile.GetFiles("ReportParsingFile.*.txt");
                foreach (FileInfo fi in fis)
                {
                    lbReportFileLanguage.Items.Add(fi.Name);
                }

                lbReportFileLanguage.SelectedItem = fiSelected.Name;
            }
        }

        DirectoryInfo diGains = null;
        public string GainSet
        {
            get 
            {
                FileInfo fi = new FileInfo(Path.Combine(diGains.Name, (string)lbGainSet.SelectedItem));
                return fi.FullName; 
            }
            set 
            {
                FileInfo fiSelected = new FileInfo(value);
                diGains = new DirectoryInfo(fiSelected.DirectoryName);

                lbGainSet.Items.Clear();

                FileInfo[] fis = diGains.GetFiles("*.tmgain*");
                foreach (FileInfo fi in fis)
                {
                    lbGainSet.Items.Add(fi.Name);
                }

                lbGainSet.SelectedItem = fiSelected.Name;
            }
        }

        public string ActionAnalysisFile
        {
            get { return txtActionsAnalysisFile.Text; }
            set { txtActionsAnalysisFile.Text = value; }
        }

        private string _matchAnalysisFile;
        public string MatchAnalysisFile
        {
            get { return _matchAnalysisFile; }
            set { _matchAnalysisFile = value; }
        }

        public bool UseTMRBrowser
        {
            get { return chkUseTMBrowser.Checked; }
            set { chkUseTMBrowser.Checked = value; }
        }

        public bool UseStartupDisk
        {
            get { return chkUseStartupDisk.Checked; }
            set { chkUseStartupDisk.Checked = value; }
        }

        public bool UseOldHTMLImportStyle
        {
            get { return chkUseOldHTMLImport.Checked; }
            set { chkUseOldHTMLImport.Checked = value; }
        }
        public string UsedLanguage
        {
            get { return cmbLanguage.SelectedItem.ToString().Split(';')[1]; }
            set 
            {
                foreach (string item in cmbLanguage.Items)
                {
                    if (item.Split(';')[1] == value)
                    {
                        cmbLanguage.SelectedItem = item;
                        return;
                    }
                }
            }
        }

        public string DefaultNation
        {
            get { return (string)cbDefaultNation.SelectedValue; }
            set
            {
                cbDefaultNation.SelectedValue = value;
            }
        }

        public OptionsForm()
        {
            InitializeComponent();

            SetLanguage();

            Nations = new NationsDS();

            Nations.SetDefaultValues();

            /*
            string filename = Program.Setts.NationListFile;
            FileInfo fi = new FileInfo(filename);

            Options tmpOptions = new Options();
            if (fi.Exists == true)
            {
                tmpOptions.ReadXml(fi.FullName);
            }
            */

            // Set controls visibility
            {
                label5.Visible = (Program.Setts.ShowActions > 0);
                txtActionsAnalysisFile.Visible = (Program.Setts.ShowActions > 0);
                btnActionAnalysisFile.Visible = (Program.Setts.ShowActions > 0);
            }

            nationNamesBindingSource.DataSource = Nations.Names;
            // nationNamesBindingSource.DataMember = Options.NationNames;

            /*
            while ((fi.Exists == false)||(tmpOptions.NationNames.Count == 0))
            {
                OpenFileDialog ofn = new OpenFileDialog();
                ofn.Title = "Select the Nation List file";
                ofn.InitialDirectory = Application.StartupPath;
                DialogResult dr = ofn.ShowDialog();

                if (dr == DialogResult.Cancel)
                {
                    if (MessageBox.Show("You must select a valid Nation list file, or exit application", "TM Recorder Startup", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        Application.Exit();
                        return;
                    }
                }
                else
                {
                    if (ofn.FileName == "") continue;

                    fi = new FileInfo(ofn.FileName);

                    tmpOptions.ReadXml(fi.FullName);

                    if (tmpOptions.NationNames.Count == 0)
                    {
                        if (MessageBox.Show("You must select a valid Nation list file, or exit application", "TM Recorder Startup", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        {
                            Application.Exit();
                            return;
                        }
                    }
                }
            }

            Options.ReadXml(fi.FullName);

            Program.Setts.NationListFile = fi.FullName;
            */

            Program.Setts.Save();
        }

        private void btnSelectDataDirectory_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = DataDirectory;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                DataDirectory = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnInstallationDirectory_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = InstallationDirectory;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                InstallationDirectory = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnSelectGainSet_Click(object sender, EventArgs e)
        {
            selectFileDialog.FileName = GainSet;
            selectFileDialog.Filter = "TMGain File (*.tmgain;*.tmgain.xml)|*.tmgain;*.tmgain.xml|All Files|*.*";
            selectFileDialog.DefaultExt = "*.tmgain*";
            selectFileDialog.InitialDirectory = GainSet;
            if (selectFileDialog.ShowDialog() == DialogResult.OK)
            {
                GainSet = selectFileDialog.FileName;
            }
        }

        private void pasteScoutListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Paste scout list
            string paste = Clipboard.GetText();

            extraDS.Scouts.ParseScoutPage(paste);
        }

        private void btnSelectReportAnalysisFile_Click(object sender, EventArgs e)
        {
        }

        private void dgReportAnalysisChanged(object sender, DataGridViewCellEventArgs e)
        {
            optionsReportAnalysis.Changed = true;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabScout)
            {
                dataGridView1.Select();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://trophymanager.com/staff_trainers.php");
        }

        private void pasteOptionFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabScout)
                pasteScoutListToolStripMenuItem_Click(sender, e);
            else
                pasteTrainersListToolStripMenuItem_Click(sender, e);
        }

        private void pasteTrainersListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbTrainers.LoadPasteTrainers();

            dbTrainers.ComputeBestCombination();
        }

        private void rbPro_CheckedChanged(object sender, EventArgs e)
        {
            txtReserveSquadID.Enabled = rbPro.Checked;
            txtReserveSquadName.Enabled = rbPro.Checked;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void whatToDoHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fill this cells with the phrases that scouts uses to review your players and the numeric\n"+
                "value (in a scale from 1 to 10) relative to each phrase (i.e He has a strong feeling that Antonio is\n" +
                "a normal bloomer (vote 2, review = “normal bloomer”) and has most of his development ahead of him. Fabio also \n"+
                "noticed that Antonio demonstrates superb leadership ability (vote 9, review = “superb leadership ability”).");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            optionsReportAnalysis.WriteXml(Program.Setts.ReportAnalysisFile);
        }

        private void btnActionAnalysisFile_Click(object sender, EventArgs e)
        {
            selectFileDialog.FileName = ActionAnalysisFile;
            selectFileDialog.Filter = "Actions Analysis File (*.aa.xml)|*.aa.xml|All Files|*.*";
            selectFileDialog.DefaultExt = "*.aa.xml";
            selectFileDialog.InitialDirectory = ActionAnalysisFile;
            if (selectFileDialog.ShowDialog() == DialogResult.OK)
            {
                ActionAnalysisFile = selectFileDialog.FileName;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://trophymanager.com/scouts.php");
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
        }

        private void btnSaveMatchAnalysisFile_Click(object sender, EventArgs e)
        {
            matchAnalysisDB.WriteXml(MatchAnalysisFile);

            saveFileDialog.Title = "Select the file name of the file to save";
            saveFileDialog.FileName = Program.Setts.MatchAnalysisFile;
            saveFileDialog.InitialDirectory = Path.GetDirectoryName(Program.Setts.MatchAnalysisFile);
            saveFileDialog.Filter = "Match Analysis File|*.*.xml|All Files|*.*";
            saveFileDialog.DefaultExt = "*.*.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                matchAnalysisDB.WriteXml(saveFileDialog.FileName);
                Program.Setts.MatchAnalysisFile = saveFileDialog.FileName;
                MatchAnalysisFile = saveFileDialog.FileName;
                Program.Setts.Save();
            }
        }

        private void btnOpenReportFile_Click(object sender, EventArgs e)
        {
            Process.Start(ReportParsingFile);
        }
    }
}