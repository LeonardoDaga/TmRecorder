using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationListEditor.Properties;

namespace NationListEditor
{
    public partial class EditorMain : Form
    {
        public EditorMain()
        {
            InitializeComponent();
        }

        private void openListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;

            OpenFileDialog ofd = new OpenFileDialog();
            Settings.Default.Reload();
            ofd.FileName = Settings.Default.LastFileUsed;
            ofd.Filter = "XML file|*.xml|All Files|*.*";

            if (ofd.FileName == "")
            {
                ofd.FileName = Application.StartupPath;
            }

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (dataSet1.NationNames.Count > 0)
                if (MessageBox.Show("Delete previous list?", "Load List",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dataSet1.Clear();
                }

                dataSet1.ReadXml(ofd.FileName);
                Settings.Default.LastFileUsed = ofd.FileName;
                Settings.Default.Save();
            }

            dataGridView1.AllowUserToAddRows = true;
        }

        private void saveListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            Settings.Default.Reload();
            sfd.FileName = Settings.Default.LastFileUsed;
            sfd.Filter = "XML file|*.xml|All Files|*.*";
            if (sfd.FileName == "")
            {
                sfd.InitialDirectory = Application.StartupPath;
                sfd.FileName = "*.xml";
            }

            // 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                dataSet1.WriteXml(sfd.FileName);
                Settings.Default.LastFileUsed = sfd.FileName;
                Settings.Default.Save();
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Both Nation Name and Abbreviation need contents (Abbreviation must be unique)");
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void copyListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(dataSet1.GetTabbedList());
        }

        private void pasteListFromExcelFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataSet1.PutTabbedList(Clipboard.GetText());
            dataGridView1.AllowUserToAddRows = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}