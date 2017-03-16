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

        public RatingEditor()
        {
            InitializeComponent();
        }
        
        public RatingEditor(RatingFunction RF)
        {
            InitializeComponent();

            recWeights = Rating.WeightsMatrixToTable(RF.GetWeightREC());
            ratWeights = Rating.WeightsMatrixToTable(RF.GetWeightRat());
            recLfWeights = Rating.WeightsMatrixToPropTable(RF.GetWeightREClf());
            adaWeights = Rating.WeightsMatrixToAdaTable(RF.GetAdaptability());
        }

        private void RatingEditor_Load(object sender, EventArgs e)
        {
            FormatRECGrid();
            FormatRatGrid();
            FormatRECLfGrid();
            FormatAdaGrid();

            LoadTables();
        }

        private void LoadTables()
        {
            dgREC.DataCollection = recWeights;
            dgRat.DataCollection = ratWeights;
            dgRecLf.DataCollection = recLfWeights;
            dgAda.DataCollection = adaWeights;
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
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.FileName = refGainDS.GainDSfilename;
            //ofd.Filter = "TMGain Files|*.tmgain|All Files|*.*";

            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    refGainDS.Clear();
            //    refGainDS.ReadXml(ofd.FileName);
            //    refGainDS.GainDSfilename = ofd.FileName;
            //    txtGainSetName.Text = (string)refGainDS.SetName[0][0];
            //}
        }

        private void tbSaveFile_Click(object sender, EventArgs e)
        {
            //SaveFileDialog ofd = new SaveFileDialog();
            //ofd.FileName = refGainDS.GainDSfilename;
            //ofd.Filter = "TMGain Files|*.tmgain|All Files|*.*";

            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    refGainDS.WriteXml(ofd.FileName);
            //    refGainDS.GainDSfilename = ofd.FileName;
            //}
        }

        private void txtGainSetName_TextChanged(object sender, EventArgs e)
        {
            //this.Text = "Gain Set Editor - " + txtGainSetName.Text;
            //refGainDS.GainDSfilename = txtGainSetName.Text;
            //refGainDS.SetName[0][0] = txtGainSetName.Text;
        }

        private void tbExit_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.OK;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //string copy = "+\t";

            //string[] spec = new string[] { "DC", "DR", "DL", "DMC", "DMR", "DML", "MC", "MR", "ML", "OMC", "OMR", "OML", "FC" };

            //if (tabControl1.SelectedTab == tabRec)
            //{
            //    for (int j = 0; j < refGainDS.SkillFPGain.Columns.Count - 1; j++)
            //    {
            //        copy += spec[j] + "\t";
            //    }
            //    copy = copy.Remove(copy.Length - 1);
            //    copy += "\n";

            //    for (int i = 0; i < refGainDS.SkillFPGain.Rows.Count; i++)
            //    {
            //        for (int j = 0; j < refGainDS.SkillFPGain.Columns.Count; j++)
            //        {
            //            copy += refGainDS.SkillFPGain[i][j] + "\t";
            //        }

            //        copy = copy.Remove(copy.Length - 1);
            //        copy += "\n";
            //    }
            //}
            //else if (tabControl1.SelectedTab == tabRating)
            //{
            //    for (int j = 0; j < refGainDS.SpecFPAmpl.Columns.Count - 1; j++)
            //    {
            //        copy += spec[j] + "\t";
            //    }
            //    copy = copy.Remove(copy.Length - 1);
            //    copy += "\n";

            //    for (int i = 0; i < refGainDS.SpecFPAmpl.Rows.Count; i++)
            //    {
            //        for (int j = 0; j < refGainDS.SpecFPAmpl.Columns.Count; j++)
            //        {
            //            copy += refGainDS.SpecFPAmpl[i][j] + "\t";
            //        }

            //        copy = copy.Remove(copy.Length - 1);
            //        copy += "\n";
            //    }
            //}
            //else if (tabControl1.SelectedTab == tabGKSkillGain)
            //{
            //    copy = "+\tGK\n";

            //    for (int i = 0; i < refGainDS.SkillGKGain.Rows.Count; i++)
            //    {
            //        for (int j = 0; j < refGainDS.SkillGKGain.Columns.Count; j++)
            //        {
            //            copy += refGainDS.SkillGKGain[i][j] + "\t";
            //        }

            //        copy = copy.Remove(copy.Length - 1);
            //        copy += "\n";
            //    }
            //}

            //Clipboard.SetText(copy);
        }

        private void tbPaste_Click(object sender, EventArgs e)
        {
            //string paste = Clipboard.GetText();

            //if (tabControl1.SelectedTab == tabRec)
            //{
            //    string[] lines = paste.Split("\r\n".ToCharArray());

            //    int i = 0;
            //    foreach (string line in lines)
            //    {
            //        int j = 1;
            //        if (line.LastIndexOfAny("0123456789".ToCharArray()) == -1) continue;

            //        string[] items = line.Split('\t');

            //        foreach (string item in items)
            //        {
            //            if (item.LastIndexOfAny("0123456789".ToCharArray()) == -1) continue;

            //            refGainDS.SkillFPGain[i][j] = float.Parse(item);
            //            j++;
            //        }

            //        i++;
            //    }
            //}
            //else if (tabControl1.SelectedTab == tabRating)
            //{
            //    string[] lines = paste.Split("\r\n".ToCharArray());

            //    int i = 0;
            //    foreach (string line in lines)
            //    {
            //        int j = 1;
            //        if (line.LastIndexOfAny("0123456789".ToCharArray()) == -1) continue;

            //        string[] items = line.Split('\t');

            //        foreach (string item in items)
            //        {
            //            if (item.LastIndexOfAny("0123456789".ToCharArray()) == -1) continue;

            //            refGainDS.SpecFPAmpl[i][j] = float.Parse(item);
            //            j++;
            //        }

            //        i++;
            //    }
            //}
            //else if (tabControl1.SelectedTab == tabGKSkillGain)
            //{
            //    string[] lines = paste.Split("\r\n".ToCharArray());

            //    int i = 0;
            //    foreach (string line in lines)
            //    {
            //        int j = 1;
            //        if (line.LastIndexOfAny("0123456789".ToCharArray()) == -1) continue;

            //        string[] items = line.Split('\t');

            //        foreach (string item in items)
            //        {
            //            if (item.LastIndexOfAny("0123456789".ToCharArray()) == -1) continue;

            //            refGainDS.SkillGKGain[i][j] = float.Parse(item);
            //            j++;
            //        }

            //        i++;
            //    }
            //}

        }
    }
}