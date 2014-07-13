using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TmRecorder2.Properties;
using Common;

namespace TmRecorder2
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

        public string MacthTypes
        {
            get { return txtMatchTypes.Text; }
            set { txtMatchTypes.Text = value; }
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

        public string GainSet
        {
            get { return txtGainSet.Text; }
            set { txtGainSet.Text = value; }
        }

        public string ActionAnalysisFile
        {
            get { return txtActionsAnalysisFile.Text; }
            set { txtActionsAnalysisFile.Text = value; }
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

            // Set controls visibility
            {
                label5.Visible = (Program.Setts.ShowActions > 0);
                txtActionsAnalysisFile.Visible = (Program.Setts.ShowActions > 0);
                btnActionAnalysisFile.Visible = (Program.Setts.ShowActions > 0);
            }

            txtboxReportAnalysisFile.Text = Path.GetFileName(Program.Setts.ReportAnalysisFile);

            nationNamesBindingSource.DataSource = Nations.Names;

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

        private void dgTrainersList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgTrainersList.SelectedRows.Count == 0) return;

            System.Data.DataRowView selTrainer = (System.Data.DataRowView)dgTrainersList.SelectedRows[0].DataBoundItem;
            TrainersSkills.TrainersRow rowTrainer = (TrainersSkills.TrainersRow)selTrainer.Row;
            rowTrainer.ComputeBestSkills();

            dgBestSkills.DataSource = rowTrainer.sdt;
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

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectFileDialog.Title = "Select file to load and replace the content of the grid with the content of the file";
            selectFileDialog.FileName = Program.Setts.ReportAnalysisFile;
            selectFileDialog.InitialDirectory = Path.GetDirectoryName(Program.Setts.ReportAnalysisFile);
            selectFileDialog.Filter = "Report Analysis File|*.xml|All Files|*.*";
            selectFileDialog.DefaultExt = "*.xml";
            if (selectFileDialog.ShowDialog() == DialogResult.OK)
            {
                optionsReportAnalysis.Clear();
                optionsReportAnalysis.ReadXml(selectFileDialog.FileName);
                Program.Setts.ReportAnalysisFile = selectFileDialog.FileName;

                txtboxReportAnalysisFile.Text = Path.GetFileName(selectFileDialog.FileName);
                Program.Setts.Save();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            optionsReportAnalysis.WriteXml(Program.Setts.ReportAnalysisFile);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.Title = "Select file to save and replace the content of the file with the content of the grid";
            saveFileDialog.FileName = Program.Setts.ReportAnalysisFile;
            saveFileDialog.InitialDirectory = Path.GetDirectoryName(Program.Setts.ReportAnalysisFile);
            saveFileDialog.Filter = "Report Analysis File|*.xml|All Files|*.*";
            saveFileDialog.DefaultExt = "*.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                optionsReportAnalysis.WriteXml(saveFileDialog.FileName);
                Program.Setts.ReportAnalysisFile = saveFileDialog.FileName;

                txtboxReportAnalysisFile.Text = Path.GetFileName(saveFileDialog.FileName);
                Program.Setts.Save();
            }
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
    }
}