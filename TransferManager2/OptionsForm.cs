using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TransferManager.Properties;
using System.IO;
using Common;

namespace TransferManager
{
    public partial class OptionsForm : Form
    {
        NationsDS Nations = null;

        public bool AutoLoadAndSave
        {
            get { return chkAutoLoadAndSave.Checked; }
            set { chkAutoLoadAndSave.Checked = value; }
        }

        public string GainSetFile
        {
            get { return txtGainSet.Text; }
            set { txtGainSet.Text = value; }
        }

        public string AlarmFile
        {
            get { return txtAlarmFile.Text; }
            set { txtAlarmFile.Text = value; }
        }

        public bool NormalizeGains
        {
            get { return chkNormalizeGains.Checked; }
            set { chkNormalizeGains.Checked = value; }
        }

        public bool EvidenceGains
        {
            get { return chkEvidenceGain.Checked; }
            set { chkEvidenceGain.Checked = value; }
        }

        public bool PlaySound
        {
            get { return chkPlaySound.Checked; }
            set { chkPlaySound.Checked = value; }
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

            Settings.Default.Reload();

            Nations = new NationsDS();

            Nations.SetDefaultValues();

            nationNamesBindingSource.DataSource = Nations.Names;

            Program.Setts.Save();
        }

        private void btnGainSet_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = GainSetFile;
            ofd.Filter = "TMGain Files|*.tmgain|All Files|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                GainSetFile = ofd.FileName;
            }
        }

        private void btnAlarmFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = AlarmFile;
            ofd.Filter = "Wave Files|*.wav|All Files|*.*";

            FileInfo fi = new FileInfo(AlarmFile);
            if (!fi.Exists) ofd.FileName = "";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                AlarmFile = ofd.FileName;
            }
        }

    }
}