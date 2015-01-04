using NTR_Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TmRecorder3
{
    public partial class OptionsForm : Form
    {
        private AppSettings appSettings;
        private Common.NationsDS Nations;

        public OptionsForm()
        {
            InitializeComponent();
        }

        public OptionsForm(AppSettings appSettings)
        {
            InitializeComponent();

            this.appSettings = appSettings;
        }

        #region Property easy access
        public string DataDirectory
        {
            get { return txtDataDirectory.Text; }
            set { txtDataDirectory.Text = value; }
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

        public string DefaultNation
        {
            get { return (string)cbDefaultNation.SelectedValue; }
            set
            {
                cbDefaultNation.SelectedValue = value;
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

        DirectoryInfo diGains = null;
        public string GainSet
        {
            get
            {
                FileInfo fi = new FileInfo(Path.Combine(diGains.FullName, (string)lbGainSet.SelectedItem));
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

        #endregion

        public void UpdateControlsWithSettings()
        {
            // Folders
            DataDirectory = appSettings.DefaultDirectory;

            // Pro / NoPro
            PlayerType = appSettings.PlayerType;

            // Name of the team
            DefaultNation = appSettings.HomeNation;

            MainSquadName = appSettings.MainSquadName;
            ReserveSquadName = appSettings.ReserveSquadName;
            MainSquadID = appSettings.MainSquadID;
            ReserveSquadID = appSettings.ReserveSquadID;

            // Gains
            GainSet = appSettings.GainSet;

            NormalizeGains = appSettings.NormalizeGains;
            EvidenceGains = appSettings.EvidenceGain;

            // Routine
            RoutineParameters = appSettings.RouParams;
            RoutineFunction = appSettings.RouFunction;
        }

        private void UpdateSettingsWithControls()
        {
            // Folders
            appSettings.DefaultDirectory = DataDirectory;

            // Pro / NoPro
            appSettings.PlayerType = PlayerType;

            // Name of the team
            appSettings.HomeNation = DefaultNation;

            appSettings.MainSquadName = MainSquadName;
            appSettings.ReserveSquadName = ReserveSquadName;
            appSettings.MainSquadID = MainSquadID;
            appSettings.ReserveSquadID = ReserveSquadID;

            // Gains
            appSettings.GainSet = GainSet;

            appSettings.NormalizeGains = NormalizeGains;
            appSettings.EvidenceGain = EvidenceGains;

            // Routine
            appSettings.RouParams = RoutineParameters;
            appSettings.RouFunction = RoutineFunction;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            UpdateSettingsWithControls();
        }

        private void btnSelectDataDirectory_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = DataDirectory;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                DataDirectory = folderBrowserDialog.SelectedPath;
            }
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            Nations = new Common.NationsDS();
            Nations.SetDefaultValues();
            nationNamesBindingSource.DataSource = Nations.Names;

            UpdateControlsWithSettings();
        }

    }
}
