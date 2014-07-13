using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TeamFileEditor.Properties;
using System.IO;

namespace TeamFileEditor
{
    public partial class EditorMain : Form
    {
        public EditorMain()
        {
            InitializeComponent();
        }

        private void openListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvPlayers.AllowUserToAddRows = false;

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
                dB_TrophyDataSet2.Clear();
                dB_TrophyDataSet2.ReadXml(ofd.FileName);

                FileInfo fi = new FileInfo(ofd.FileName);
                this.Text = "Team File Editor - " + fi.Name;
                Settings.Default.LastFileUsed = ofd.FileName;
                Settings.Default.Save();
            }

            dgvPlayers.AllowUserToAddRows = true;
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
                sfd.FileName = "*.xml";
            }

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                dB_TrophyDataSet2.Date = dateTimePicker1.Value;
                dB_TrophyDataSet2.WriteXml(sfd.FileName);
                Settings.Default.LastFileUsed = sfd.FileName;
                Settings.Default.Save();
            }
        }

        private void copyListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                Clipboard.SetText(dB_TrophyDataSet2.GetPlayerTabbedList());
            }
            else
            {
                Clipboard.SetText(dB_TrophyDataSet2.GetGKTabbedList());
            }
        }

        private void pasteListFromExcelFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                dgvPlayers.AllowUserToAddRows = false;
                dB_TrophyDataSet2.PutPlayersTabbedList(Clipboard.GetText());
                dgvPlayers.AllowUserToAddRows = true;
            }
            else
            {
                dgvGK.AllowUserToAddRows = false;
                dB_TrophyDataSet2.PutGKTabbedList(Clipboard.GetText());
                dgvGK.AllowUserToAddRows = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvPlayers_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Player ID needs contents (ID must be unique)");
        }

        private void dgvGK_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Player ID needs contents (ID must be unique)");
        }
    }
}