using NTR_Db;
using System;
using System.Windows.Forms;

namespace NTR_Controls
{
    public partial class RatingEditor : Form
    {
        public RatingEditor()
        {
            InitializeComponent();
        }
        
        public RatingEditor(RatingFunction RF)
        {
            InitializeComponent();

            FormatPlayersGrid();

            LoadTables(RF);
        }

        private void LoadTables(RatingFunction RF)
        {
            var recWeights = Rating.WeightsMatrixToTable(RF.GetWeightRat());

            dgREC.DataCollection = recWeights;
        }

        private void FormatPlayersGrid()
        {
            dgREC.AutoGenerateColumns = false;

            dgREC.Columns.Clear();

            dgREC.AddColumn("Skill", "Skill", 42, AG_Style.String);
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
            dgREC.AddColumn("SkillGk", "SkillGk", 42, AG_Style.String);
            dgREC.AddColumn("GK", "GK", 42, AG_Style.Numeric | AG_Style.N3);
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