using NTR_Common;
using NTR_Db;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NTR_Controls
{
    public partial class TacticsEditor : Form
    {
        public string fileName { get; private set; }
        public List<TAC_PlWeights> tacPlWeights { get; private set; }
        public List<TAC_GkWeights> tacGkWeights { get; private set; }
        public List<TAC_Tac2ActWeights> tacTac2ActWeights { get; private set; }
        public List<TAC_PossessionWeights> tacPossessionWeights { get; private set; }
        public List<TAC_ActionWeights> tacActionConstructionWeights { get; private set; }
        public List<TAC_ActionWeights> tacActionFinalizationWeights { get; private set; }
        public List<TAC_ActionWeights> tacDefenseWeights { get; private set; }

        public TacticsEditor()
        {
            InitializeComponent();
        }

        public TacticsEditor(TacticsFunction TF)
        {
            InitializeComponent();

            CopyTFLocally(TF);
        }

        private void CopyTFLocally(TacticsFunction TF)
        {
            tacPlWeights = TacticsFunction.PlWeightsMatrixToTable(TF._plTacticsSPosDict);
            tacGkWeights = TacticsFunction.GkWeightsMatrixToTable(TF._gkTacticsSPosDict);
            tacTac2ActWeights = TacticsFunction.TacticsToAcionMatrixToTable(TF._tacticsToActionDict);
            tacPossessionWeights = TacticsFunction.PossessionMatrixToTable(TF._possessionDict);
            tacActionConstructionWeights = TacticsFunction.ActionMatrixToTable(TF._actionConstructionDict);
            tacActionFinalizationWeights = TacticsFunction.ActionMatrixToTable(TF._actionFinalizationDict);
            tacDefenseWeights = TacticsFunction.ActionMatrixToTable(TF._actionDefensiveDict);

            fileName = TF.SettingsFilename;

            LoadTables();
        }

        private void RatingEditor_Load(object sender, EventArgs e)
        {
            FormatTacPlGrid();
            FormatTacGkGrid();
            FormatTacticsToActionGrid();
            FormatPossessionGrid();
            FormatActionConstructionGrid();
            FormatActionFinalizationGrid();
            FormatDefenseGrid();

            LoadTables();
        }

        private void LoadTables()
        {
            dgPlTactics.DataCollection = tacPlWeights;
            dgGkTactics.DataCollection = tacGkWeights;
            dgTacticsToAction.DataCollection = tacTac2ActWeights;
            dgPossession.DataCollection = tacPossessionWeights;
            dgActionConstruction.DataCollection = tacActionConstructionWeights;
            dgActionFinalization.DataCollection = tacActionFinalizationWeights;
            dgDefense.DataCollection = tacDefenseWeights;

            this.Text = "Tactics Editor - " + fileName;
        }

        private void FormatDefenseGrid()
        {
            dgDefense.AutoGenerateColumns = false;

            dgDefense.Columns.Clear();

            dgDefense.AddColumn("Tactics", "Tactics", 60, AG_Style.FormatString | AG_Style.ReadOnly);
            dgDefense.AddColumn("Str", "Str", 42, AG_Style.Numeric | AG_Style.N3);
            dgDefense.AddColumn("Sta", "Sta", 42, AG_Style.Numeric | AG_Style.N3);
            dgDefense.AddColumn("Pac", "Pac", 42, AG_Style.Numeric | AG_Style.N3);
            dgDefense.AddColumn("Mar", "Mar", 42, AG_Style.Numeric | AG_Style.N3);
            dgDefense.AddColumn("Tac", "Tac", 42, AG_Style.Numeric | AG_Style.N3);
            dgDefense.AddColumn("Wor", "Wor", 42, AG_Style.Numeric | AG_Style.N3);
            dgDefense.AddColumn("Pos", "Pos", 42, AG_Style.Numeric | AG_Style.N3);
            dgDefense.AddColumn("Pas", "Pas", 42, AG_Style.Numeric | AG_Style.N3);
            dgDefense.AddColumn("Cro", "Cro", 42, AG_Style.Numeric | AG_Style.N3);
            dgDefense.AddColumn("Tec", "Tec", 42, AG_Style.Numeric | AG_Style.N3);
            dgDefense.AddColumn("Hea", "Hea", 42, AG_Style.Numeric | AG_Style.N3);
            dgDefense.AddColumn("Fin", "Fin", 42, AG_Style.Numeric | AG_Style.N3);
            dgDefense.AddColumn("Lon", "Lon", 42, AG_Style.Numeric | AG_Style.N3);
            dgDefense.AddColumn("Set", "Set", 42, AG_Style.Numeric | AG_Style.N3);
            dgDefense.AddColumn("FPos", "FPos", 300, AG_Style.FormatString);
        }

        private void FormatActionFinalizationGrid()
        {
            dgActionFinalization.AutoGenerateColumns = false;

            dgActionFinalization.Columns.Clear();

            dgActionFinalization.AddColumn("Tactics", "Tactics", 60, AG_Style.FormatString | AG_Style.ReadOnly);
            dgActionFinalization.AddColumn("Str", "Str", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionFinalization.AddColumn("Sta", "Sta", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionFinalization.AddColumn("Pac", "Pac", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionFinalization.AddColumn("Mar", "Mar", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionFinalization.AddColumn("Tac", "Tac", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionFinalization.AddColumn("Wor", "Wor", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionFinalization.AddColumn("Pos", "Pos", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionFinalization.AddColumn("Pas", "Pas", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionFinalization.AddColumn("Cro", "Cro", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionFinalization.AddColumn("Tec", "Tec", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionFinalization.AddColumn("Hea", "Hea", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionFinalization.AddColumn("Fin", "Fin", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionFinalization.AddColumn("Lon", "Lon", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionFinalization.AddColumn("Set", "Set", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionFinalization.AddColumn("FPos", "FPos", 300, AG_Style.FormatString);
        }

        private void FormatActionConstructionGrid()
        {
            dgActionConstruction.AutoGenerateColumns = false;

            dgActionConstruction.Columns.Clear();

            dgActionConstruction.AddColumn("Tactics", "Tactics", 60, AG_Style.FormatString | AG_Style.ReadOnly);
            dgActionConstruction.AddColumn("Str", "Str", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionConstruction.AddColumn("Sta", "Sta", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionConstruction.AddColumn("Pac", "Pac", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionConstruction.AddColumn("Mar", "Mar", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionConstruction.AddColumn("Tac", "Tac", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionConstruction.AddColumn("Wor", "Wor", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionConstruction.AddColumn("Pos", "Pos", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionConstruction.AddColumn("Pas", "Pas", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionConstruction.AddColumn("Cro", "Cro", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionConstruction.AddColumn("Tec", "Tec", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionConstruction.AddColumn("Hea", "Hea", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionConstruction.AddColumn("Fin", "Fin", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionConstruction.AddColumn("Lon", "Lon", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionConstruction.AddColumn("Set", "Set", 42, AG_Style.Numeric | AG_Style.N3);
            dgActionConstruction.AddColumn("FPos", "FPos", 300, AG_Style.FormatString);
        }

        private void FormatPossessionGrid()
        {
            dgPossession.AutoGenerateColumns = false;

            dgPossession.Columns.Clear();

            dgPossession.AddColumn("Mode", "Mode", 60, AG_Style.FormatString | AG_Style.ReadOnly);
            dgPossession.AddColumn("Str", "Str", 42, AG_Style.Numeric | AG_Style.N3);
            dgPossession.AddColumn("Sta", "Sta", 42, AG_Style.Numeric | AG_Style.N3);
            dgPossession.AddColumn("Pac", "Pac", 42, AG_Style.Numeric | AG_Style.N3);
            dgPossession.AddColumn("Mar", "Mar", 42, AG_Style.Numeric | AG_Style.N3);
            dgPossession.AddColumn("Tac", "Tac", 42, AG_Style.Numeric | AG_Style.N3);
            dgPossession.AddColumn("Wor", "Wor", 42, AG_Style.Numeric | AG_Style.N3);
            dgPossession.AddColumn("Pos", "Pos", 42, AG_Style.Numeric | AG_Style.N3);
            dgPossession.AddColumn("Pas", "Pas", 42, AG_Style.Numeric | AG_Style.N3);
            dgPossession.AddColumn("Cro", "Cro", 42, AG_Style.Numeric | AG_Style.N3);
            dgPossession.AddColumn("Tec", "Tec", 42, AG_Style.Numeric | AG_Style.N3);
            dgPossession.AddColumn("Hea", "Hea", 42, AG_Style.Numeric | AG_Style.N3);
            dgPossession.AddColumn("Fin", "Fin", 42, AG_Style.Numeric | AG_Style.N3);
            dgPossession.AddColumn("Lon", "Lon", 42, AG_Style.Numeric | AG_Style.N3);
            dgPossession.AddColumn("Set", "Set", 42, AG_Style.Numeric | AG_Style.N3);
        }


        private void FormatTacPlGrid()
        {
            dgPlTactics.AutoGenerateColumns = false;

            dgPlTactics.Columns.Clear();

            dgPlTactics.AddColumn("Tactics", "Tactics", 60, AG_Style.FormatString | AG_Style.ReadOnly);
            dgPlTactics.AddColumn("DorA", "DorA", 50, AG_Style.Numeric | AG_Style.N0);
            dgPlTactics.AddColumn("Str", "Str", 42, AG_Style.Numeric | AG_Style.N3);
            dgPlTactics.AddColumn("Sta", "Sta", 42, AG_Style.Numeric | AG_Style.N3);
            dgPlTactics.AddColumn("Pac", "Pac", 42, AG_Style.Numeric | AG_Style.N3);
            dgPlTactics.AddColumn("Mar", "Mar", 42, AG_Style.Numeric | AG_Style.N3);
            dgPlTactics.AddColumn("Tac", "Tac", 42, AG_Style.Numeric | AG_Style.N3);
            dgPlTactics.AddColumn("Wor", "Wor", 42, AG_Style.Numeric | AG_Style.N3);
            dgPlTactics.AddColumn("Pos", "Pos", 42, AG_Style.Numeric | AG_Style.N3);
            dgPlTactics.AddColumn("Pas", "Pas", 42, AG_Style.Numeric | AG_Style.N3);
            dgPlTactics.AddColumn("Cro", "Cro", 42, AG_Style.Numeric | AG_Style.N3);
            dgPlTactics.AddColumn("Tec", "Tec", 42, AG_Style.Numeric | AG_Style.N3);
            dgPlTactics.AddColumn("Hea", "Hea", 42, AG_Style.Numeric | AG_Style.N3);
            dgPlTactics.AddColumn("Fin", "Fin", 42, AG_Style.Numeric | AG_Style.N3);
            dgPlTactics.AddColumn("Lon", "Lon", 42, AG_Style.Numeric | AG_Style.N3);
            dgPlTactics.AddColumn("Set", "Set", 42, AG_Style.Numeric | AG_Style.N3);
            dgPlTactics.AddColumn("Fav. Position", "FPos", 300, AG_Style.FormatString);
        }

        private void FormatTacGkGrid()
        {
            dgGkTactics.AutoGenerateColumns = false;

            dgGkTactics.Columns.Clear();

            dgGkTactics.AddColumn("Tactics", "Tactics", 60, AG_Style.FormatString | AG_Style.ReadOnly);
            dgGkTactics.AddColumn("DorA", "DorA", 50, AG_Style.Numeric | AG_Style.N0);
            dgGkTactics.AddColumn("Str", "Str", 42, AG_Style.Numeric | AG_Style.N3);
            dgGkTactics.AddColumn("Sta", "Sta", 42, AG_Style.Numeric | AG_Style.N3);
            dgGkTactics.AddColumn("Pac", "Pac", 42, AG_Style.Numeric | AG_Style.N3);
            dgGkTactics.AddColumn("Han", "Han", 42, AG_Style.Numeric | AG_Style.N3);
            dgGkTactics.AddColumn("One", "One", 42, AG_Style.Numeric | AG_Style.N3);
            dgGkTactics.AddColumn("Ref", "Ref", 42, AG_Style.Numeric | AG_Style.N3);
            dgGkTactics.AddColumn("Aer", "Aer", 42, AG_Style.Numeric | AG_Style.N3);
            dgGkTactics.AddColumn("Jum", "Jum", 42, AG_Style.Numeric | AG_Style.N3);
            dgGkTactics.AddColumn("Com", "Com", 42, AG_Style.Numeric | AG_Style.N3);
            dgGkTactics.AddColumn("Kic", "Kic", 42, AG_Style.Numeric | AG_Style.N3);
            dgGkTactics.AddColumn("Thr", "Thr", 42, AG_Style.Numeric | AG_Style.N3);
        }

        private void FormatTacticsToActionGrid()
        {
            dgTacticsToAction.AutoGenerateColumns = false;

            dgTacticsToAction.Columns.Clear();

            dgTacticsToAction.AddColumn("Tactics", "Tactics", 60, AG_Style.FormatString | AG_Style.ReadOnly);
            dgTacticsToAction.AddColumn("Cor", "Cor", 42, AG_Style.Numeric | AG_Style.N3);
            dgTacticsToAction.AddColumn("Cro", "Cro", 42, AG_Style.Numeric | AG_Style.N3);
            dgTacticsToAction.AddColumn("Dir", "Dir", 42, AG_Style.Numeric | AG_Style.N3);
            dgTacticsToAction.AddColumn("Fil", "Fil", 42, AG_Style.Numeric | AG_Style.N3);
            dgTacticsToAction.AddColumn("Fre", "Fre", 42, AG_Style.Numeric | AG_Style.N3);
            dgTacticsToAction.AddColumn("Lon", "Lon", 42, AG_Style.Numeric | AG_Style.N3);
            dgTacticsToAction.AddColumn("Pen", "Pen", 42, AG_Style.Numeric | AG_Style.N3);
            dgTacticsToAction.AddColumn("Sho", "Sho", 42, AG_Style.Numeric | AG_Style.N3);
        }


        private void tbOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = fileName;
            ofd.Filter = "Tactics Files|*.tactics|All Files|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TacticsFunction TF = TacticsFunction.Load(ofd.FileName);
                TF.SettingsFilename = ofd.FileName;
                fileName = ofd.FileName;

                CopyTFLocally(TF);
            }

        }

        private void tbSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.FileName = fileName;
            ofd.Filter = "Tactics Files|*.tactics|All Files|*.*";

            TacticsFunction TF = TacticsFunction.Create(
                tacPlWeights,
                tacGkWeights,
                tacTac2ActWeights,
                tacPossessionWeights,
                tacActionConstructionWeights,
                tacActionFinalizationWeights,
                tacDefenseWeights,
                fileName);

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TF.SettingsFilename = ofd.FileName;
                fileName = ofd.FileName;
                TF.Save();
            }
        }

        private void tbCopy_Click(object sender, EventArgs e)
        {
            string copy;

            TacticsFunction TF = TacticsFunction.Create(
                tacPlWeights,
                tacGkWeights,
                tacTac2ActWeights,
                tacPossessionWeights,
                tacActionConstructionWeights,
                tacActionFinalizationWeights,
                tacDefenseWeights,
                fileName);

            if (tabControl.SelectedTab == tabPlTactics)
            {
                copy = TF.PlTacticsSPosDict.ToExcelString();
            }
            else if (tabControl.SelectedTab == tabGkTactics)
            {
                copy = TF.GkTacticsSPosDict.ToExcelString();
            }
            else if (tabControl.SelectedTab == tabTacticsToAction)
            {
                copy = TF.TacticsToAcionDict.ToExcelString();
            }
            else if (tabControl.SelectedTab == tabPossession)
            {
                copy = TF.PossessionDict.ToExcelString();
            }
            else if (tabControl.SelectedTab == tabActionConstruction)
            {
                copy = TF.ActionConstructionDict.ToExcelString();
            }
            else if (tabControl.SelectedTab == tabActionFinalization)
            {
                copy = TF.ActionFinalizationDict.ToExcelString();
            }
            else // if (tabControl.SelectedTab == tabDefense)
            {
                copy = TF.ActionDefensiveDict.ToExcelString();
            }

            Clipboard.SetText(copy);
        }

        private void tbPaste_Click(object sender, EventArgs e)
        {
            string paste = Clipboard.GetText();
            paste = paste.Replace("\r\n", ";\n");

            if (tabControl.SelectedTab == tabPlTactics)
            {
                PlTacticsSPosDictionary dict = PlTacticsSPosDictionary.Parse(paste);
                tacPlWeights = TacticsFunction.PlWeightsMatrixToTable(dict);
            }
            else
            {
                GkTacticsSPosDictionary dict = GkTacticsSPosDictionary.Parse(paste);
                tacGkWeights = TacticsFunction.GkWeightsMatrixToTable(dict);
            }

            LoadTables();
        }

        private void TacticsEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            if ((result = MessageBox.Show("Accept and Close (Yes), Reject Changes and Close (NO), or Don't close (Cancel)",
                "Tactics Editor", MessageBoxButtons.YesNoCancel)) == DialogResult.Cancel)
            {
                return;
            }

            this.DialogResult = result;

            if (this.DialogResult == DialogResult.Cancel)
                e.Cancel = true;
        }
    }
}