using NTR_Common;
using NTR_Db;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NTR_Controls
{
    public partial class RatingEditor : Form
    {
        public List<REC_Weights> recWeights { get; private set; }
        public List<REC_Weights> ratWeights { get; private set; }
        public List<ADA_Weights> adaWeights { get; private set; }
        public List<PROP_Weights> recLfWeights { get; private set; }

        private double _rouFactor;
        public double RouFactor
        {
            get
            {
                try
                {
                    return double.Parse(txtRoutineFactor.Text, Common.CommGlobal.ciInv);
                }
                catch
                {
                    return 0.0;
                }
            }
            private set
            {
                txtRoutineFactor.Text = string.Format(Common.CommGlobal.ciInv, "{0}", value);
            }
        }

        private eRatingFunctionType _funType;
        public eRatingFunctionType FunType
        {
            get
            {
                return (eRatingFunctionType)cmbFunctionType.SelectedIndex;
            }
            private set
            {
                cmbFunctionType.SelectedIndex = (int)value;
            }
        }

        public string FileName { get; private set; }

        public RatingEditor()
        {
            InitializeComponent();
        }

        public RatingEditor(RatingFunction RF)
        {
            InitializeComponent();

            CopyRFLocally(RF);
        }

        private void CopyRFLocally(RatingFunction RF)
        {
            recWeights = Rating.WeightsMatrixToTable(RF.WeightREC);
            ratWeights = Rating.WeightsMatrixToTable(RF.WeightRat);
            recLfWeights = Rating.WeightsMatrixToPropTable(RF.WeightREClf);
            adaWeights = Rating.WeightsMatrixToAdaTable(RF.Adaptability);

            _rouFactor = RF.RoutineFactor;
            _funType = RF.RatingFunctionType;
            FileName = RF.SettingsFilename;

            FillComboFunctionType();
            LoadTables();
        }

        private void RatingEditor_Load(object sender, EventArgs e)
        {
            FormatRECGrid();
            FormatRatGrid();
            FormatRECLfGrid();
            FormatAdaGrid();

            FillComboFunctionType();
            LoadTables();
        }

        private void FillComboFunctionType()
        {
            cmbFunctionType.Items.Clear();
            foreach (eRatingFunctionType functionType in Enum.GetValues(typeof(eRatingFunctionType)))
            {
                cmbFunctionType.Items.Add(functionType.ToString());
            }
        }

        private void LoadTables()
        {
            dgREC.DataCollection = recWeights;
            dgRat.DataCollection = ratWeights;
            dgRecLf.DataCollection = recLfWeights;
            dgAda.DataCollection = adaWeights;

            RouFactor = _rouFactor;
            FunType = _funType;

            this.Text = "Rating Editor - " + FileName;
        }

        private void FormatRECGrid()
        {
            dgREC.AutoGenerateColumns = false;

            dgREC.Columns.Clear();

            dgREC.AddColumn("Skill", "Skill", 42, AG_Style.FormatString | AG_Style.ReadOnly);
            dgREC.AddColumn("DC", "DC", 42, AG_Style.Numeric | AG_Style.N3);
            dgREC.AddColumn("DL", "DL", 42, AG_Style.Numeric | AG_Style.N3);
            dgREC.AddColumn("DR", "DR", 42, AG_Style.Numeric | AG_Style.N3);
            dgREC.AddColumn("DMC", "DMC", 42, AG_Style.Numeric | AG_Style.N3);
            dgREC.AddColumn("DML", "DML", 42, AG_Style.Numeric | AG_Style.N3);
            dgREC.AddColumn("DMR", "DMR", 42, AG_Style.Numeric | AG_Style.N3);
            dgREC.AddColumn("MC", "MC", 42, AG_Style.Numeric | AG_Style.N3);
            dgREC.AddColumn("ML", "ML", 42, AG_Style.Numeric | AG_Style.N3);
            dgREC.AddColumn("MR", "MR", 42, AG_Style.Numeric | AG_Style.N3);
            dgREC.AddColumn("OMC", "OMC", 42, AG_Style.Numeric | AG_Style.N3);
            dgREC.AddColumn("OML", "OML", 42, AG_Style.Numeric | AG_Style.N3);
            dgREC.AddColumn("OMR", "OMR", 42, AG_Style.Numeric | AG_Style.N3);
            dgREC.AddColumn("FC", "FC", 42, AG_Style.Numeric | AG_Style.N3);
            dgREC.AddColumn("SkillGk", "SkillGk", 42, AG_Style.FormatString | AG_Style.ReadOnly);
            dgREC.AddColumn("GK", "GK", 42, AG_Style.Numeric | AG_Style.N3);
        }

        private void FormatRatGrid()
        {
            dgRat.AutoGenerateColumns = false;

            dgRat.Columns.Clear();

            dgRat.AddColumn("Skill", "Skill", 42, AG_Style.FormatString | AG_Style.ReadOnly);
            dgRat.AddColumn("DC", "DC", 42, AG_Style.Numeric | AG_Style.N3);
            dgRat.AddColumn("DL", "DL", 42, AG_Style.Numeric | AG_Style.N3);
            dgRat.AddColumn("DR", "DR", 42, AG_Style.Numeric | AG_Style.N3);
            dgRat.AddColumn("DMC", "DMC", 42, AG_Style.Numeric | AG_Style.N3);
            dgRat.AddColumn("DML", "DML", 42, AG_Style.Numeric | AG_Style.N3);
            dgRat.AddColumn("DMR", "DMR", 42, AG_Style.Numeric | AG_Style.N3);
            dgRat.AddColumn("MC", "MC", 42, AG_Style.Numeric | AG_Style.N3);
            dgRat.AddColumn("ML", "ML", 42, AG_Style.Numeric | AG_Style.N3);
            dgRat.AddColumn("MR", "MR", 42, AG_Style.Numeric | AG_Style.N3);
            dgRat.AddColumn("OMC", "OMC", 42, AG_Style.Numeric | AG_Style.N3);
            dgRat.AddColumn("OML", "OML", 42, AG_Style.Numeric | AG_Style.N3);
            dgRat.AddColumn("OMR", "OMR", 42, AG_Style.Numeric | AG_Style.N3);
            dgRat.AddColumn("FC", "FC", 42, AG_Style.Numeric | AG_Style.N3);
            dgRat.AddColumn("SkillGk", "SkillGk", 42, AG_Style.FormatString | AG_Style.ReadOnly);
            dgRat.AddColumn("GK", "GK", 42, AG_Style.Numeric | AG_Style.N3);
        }

        private void FormatRECLfGrid()
        {
            dgRecLf.AutoGenerateColumns = false;

            dgRecLf.Columns.Clear();

            dgRecLf.AddColumn("Coefficent", "Coefficent", 65, AG_Style.FormatString | AG_Style.ReadOnly);
            dgRecLf.AddColumn("DC", "DC", 42, AG_Style.Numeric | AG_Style.N3);
            dgRecLf.AddColumn("DL", "DL", 42, AG_Style.Numeric | AG_Style.N3);
            dgRecLf.AddColumn("DR", "DR", 42, AG_Style.Numeric | AG_Style.N3);
            dgRecLf.AddColumn("DMC", "DMC", 42, AG_Style.Numeric | AG_Style.N3);
            dgRecLf.AddColumn("DML", "DML", 42, AG_Style.Numeric | AG_Style.N3);
            dgRecLf.AddColumn("DMR", "DMR", 42, AG_Style.Numeric | AG_Style.N3);
            dgRecLf.AddColumn("MC", "MC", 42, AG_Style.Numeric | AG_Style.N3);
            dgRecLf.AddColumn("ML", "ML", 42, AG_Style.Numeric | AG_Style.N3);
            dgRecLf.AddColumn("MR", "MR", 42, AG_Style.Numeric | AG_Style.N3);
            dgRecLf.AddColumn("OMC", "OMC", 42, AG_Style.Numeric | AG_Style.N3);
            dgRecLf.AddColumn("OML", "OML", 42, AG_Style.Numeric | AG_Style.N3);
            dgRecLf.AddColumn("OMR", "OMR", 42, AG_Style.Numeric | AG_Style.N3);
            dgRecLf.AddColumn("FC", "FC", 42, AG_Style.Numeric | AG_Style.N3);
            dgRecLf.AddColumn("GK", "GK", 42, AG_Style.Numeric | AG_Style.N3);
        }

        private void FormatAdaGrid()
        {
            dgAda.AutoGenerateColumns = false;

            dgAda.Columns.Clear();

            dgAda.AddColumn("Position", "Position", 65, AG_Style.FormatString | AG_Style.ReadOnly);
            dgAda.AddColumn("DC", "DC", 42, AG_Style.Numeric | AG_Style.N3);
            dgAda.AddColumn("DL", "DL", 42, AG_Style.Numeric | AG_Style.N3);
            dgAda.AddColumn("DR", "DR", 42, AG_Style.Numeric | AG_Style.N3);
            dgAda.AddColumn("DMC", "DMC", 42, AG_Style.Numeric | AG_Style.N3);
            dgAda.AddColumn("DML", "DML", 42, AG_Style.Numeric | AG_Style.N3);
            dgAda.AddColumn("DMR", "DMR", 42, AG_Style.Numeric | AG_Style.N3);
            dgAda.AddColumn("MC", "MC", 42, AG_Style.Numeric | AG_Style.N3);
            dgAda.AddColumn("ML", "ML", 42, AG_Style.Numeric | AG_Style.N3);
            dgAda.AddColumn("MR", "MR", 42, AG_Style.Numeric | AG_Style.N3);
            dgAda.AddColumn("OMC", "OMC", 42, AG_Style.Numeric | AG_Style.N3);
            dgAda.AddColumn("OML", "OML", 42, AG_Style.Numeric | AG_Style.N3);
            dgAda.AddColumn("OMR", "OMR", 42, AG_Style.Numeric | AG_Style.N3);
            dgAda.AddColumn("FC", "FC", 42, AG_Style.Numeric | AG_Style.N3);
        }

        private void tbOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = FileName;
            ofd.Filter = "Rating Files|*.rating|All Files|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                RatingFunction RF = RatingFunction.Load(ofd.FileName);
                RF.SettingsFilename = ofd.FileName;
                FileName = ofd.FileName;

                CopyRFLocally(RF);
            }

        }

        private void tbSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.FileName = FileName;
            ofd.Filter = "Rating Files|*.rating|All Files|*.*";

            RatingFunction RF = RatingFunction.Create(_funType, 
                recWeights, 
                ratWeights, 
                recLfWeights, 
                adaWeights,
                _rouFactor,
                FileName);

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                RF.SettingsFilename = ofd.FileName;
                FileName = ofd.FileName;
                RF.Save();
            }
        }

        private void tbCopy_Click(object sender, EventArgs e)
        {
            string copy = "";

            RatingFunction RF = RatingFunction.Create(_funType,
                                                    recWeights,
                                                    ratWeights,
                                                    recLfWeights,
                                                    adaWeights,
                                                    _rouFactor,
                                                    FileName);

            if (tabControl1.SelectedTab == tabRec)
            {
                string[] rows = { "Str", "Sta", "Pac", "Mar", "Tac", "Wor", "Pos", "Pas", "Cro", "Tec", "Hea", "Fin", "Lon", "Set" };
                string[] cols = { "DC", "DL", "DR", "DMC", "DML", "DMR", "MC", "ML", "MR", "OMC", "OML", "OMR", "FC", "GK" };
                copy = RF.WeightREC.ToExcelString(rows, cols);
            }
            else if (tabControl1.SelectedTab == tabRating)
            {
                string[] rows = { "Str", "Sta", "Pac", "Mar", "Tac", "Wor", "Pos", "Pas", "Cro", "Tec", "Hea", "Fin", "Lon", "Set" };
                string[] cols = { "DC", "DL", "DR", "DMC", "DML", "DMR", "MC", "ML", "MR", "OMC", "OML", "OMR", "FC", "GK" };
                copy = RF.WeightRat.ToExcelString(rows, cols);
            }
            else if (tabControl1.SelectedTab == tabRecLinFun)
            {
                string[] rows = { "K0", "K1" };
                string[] cols = { "DC", "DL", "DR", "DMC", "DML", "DMR", "MC", "ML", "MR", "OMC", "OML", "OMR", "FC", "GK" };
                copy = RF.WeightREClf.ToExcelString(rows, cols);
            }
            else if (tabControl1.SelectedTab == tabAda)
            {
                string[] rows = { "DC", "DL", "DR", "DMC", "DML", "DMR", "MC", "ML", "MR", "OMC", "OML", "OMR", "FC" };
                string[] cols = { "DC", "DL", "DR", "DMC", "DML", "DMR", "MC", "ML", "MR", "OMC", "OML", "OMR", "FC" };
                copy = RF.Adaptability.ToExcelString(rows, cols);
            }

            Clipboard.SetText(copy);
        }

        private void tbPaste_Click(object sender, EventArgs e)
        {
            string paste = Clipboard.GetText();

            paste = paste.Replace("\r\n", ";\n");

            RatingFunction RF = new RatingFunction();

            if (tabControl1.SelectedTab == tabRec)
            {
                recWeights = Rating.WeightsMatrixToTable(WeightMatrix.ParseExcel(paste).Transpose());
            }
            else if (tabControl1.SelectedTab == tabRating)
            {
                ratWeights = Rating.WeightsMatrixToTable(WeightMatrix.ParseExcel(paste).Transpose());
            }
            else if (tabControl1.SelectedTab == tabRecLinFun)
            {
                recLfWeights = Rating.WeightsMatrixToPropTable(WeightMatrix.ParseExcel(paste).Transpose());
            }
            else if (tabControl1.SelectedTab == tabAda)
            {
                adaWeights = Rating.WeightsMatrixToAdaTable(WeightMatrix.ParseExcel(paste).Transpose());
            }

            LoadTables();

        }

        private void RatingEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            if ((result = MessageBox.Show("Accept and Close (Yes), Reject Changes and Close (NO), or Don't close (Cancel)",
                "Rating Editor", MessageBoxButtons.YesNoCancel)) == DialogResult.Cancel)
            {
                return;
            }

            this.DialogResult = result;

            if (this.DialogResult == DialogResult.Cancel)
                e.Cancel = true;
        }
    }
}