using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PlayerFileEditor.Properties;

namespace PlayerFileEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;

            OpenFileDialog ofd = new OpenFileDialog();
            Settings.Default.Reload();
            ofd.FileName = Settings.Default.LastFileUsed;
            ofd.Filter = "XML file|*.*.xml|All Files|*.*";

            if (ofd.FileName == "")
            {
                ofd.FileName = Application.StartupPath;
            }

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (extraDS.Giocatori.Count > 0)
                    if (MessageBox.Show("Delete previous list?", "Load List",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        extraDS.Clear();
                    }

                extraDS.ReadXml(ofd.FileName);
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
            sfd.Filter = "XML file|*.*.xml|All Files|*.*";
            if (sfd.FileName == "")
            {
                sfd.InitialDirectory = Application.StartupPath;
                sfd.FileName = "*.*.xml";
            }

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                extraDS.WriteXml(sfd.FileName);
                Settings.Default.LastFileUsed = sfd.FileName;
                Settings.Default.Save();
            }
        }

        private void copyListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(extraDS.GetTabbedList());
        }

        private void pasteListFromExcelFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            extraDS.PutTabbedList(Clipboard.GetText());
            dataGridView1.AllowUserToAddRows = true;
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Player ID needs contents (ID must be unique)");
        }
    }
}