using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Common;

namespace TacticsEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Program.Setts.Initialize();
        }

        private void cmbActionConstruction_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ix = cmbActionConstruction.SelectedIndex - 1;
            if (ix > -1)
            {
                bindActionConstruction.Filter = "Action=" + ix.ToString();
            }
            else
            {
                bindActionConstruction.Filter = "";
            }
        }

        private void cmbActionFinalization_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ix = cmbActionFinalization.SelectedIndex - 1;
            if (ix > -1)
            {
                bindActionFinalization.Filter = "Action=" + ix.ToString();
            }
            else
            {
                bindActionFinalization.Filter = "";
            }
        }

        private void cmbOpponent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ix = cmbDefense.SelectedIndex - 1;
            if (ix > -1)
            {
                bindDefense.Filter = "Action=" + ix.ToString();
            }
            else
            {
                bindDefense.Filter = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbActionConstruction.SelectedIndex = 0;
            cmbActionFinalization.SelectedIndex = 0;
            cmbDefense.SelectedIndex = 0;

            FileInfo fi = new FileInfo(Program.Setts.LastFilename);
            if (fi.Exists)
                tacticsDS.ReadXml(Program.Setts.LastFilename);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = Program.Setts.LastFilename;
            sfd.DefaultExt = "*.xml";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                tacticsDS.WriteXml(sfd.FileName);
                Program.Setts.LastFilename = sfd.FileName;
                Program.Setts.Save();
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.FileName = Program.Setts.LastFilename;
            sfd.DefaultExt = "*.xml";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(sfd.FileName);
                if (fi.Exists)
                {
                    tacticsDS.ReadXml(sfd.FileName);
                    Program.Setts.LastFilename = sfd.FileName;
                    Program.Setts.Save();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgDefense_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void dgFinalization_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void dgConstruction_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            // e.Row.T
        }

        private void dgConstruction_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void dgConstruction_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // dgConstruction.Rows[e.RowIndex].DataBoundItem 
        }

        private void dgConstruction_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbActionConstruction.SelectedIndex == 0)
                return;

            DataRowView drv = (DataRowView)dgConstruction.Rows[e.RowIndex].DataBoundItem;
            TacticsDS.ActionConstructionRow acr = (TacticsDS.ActionConstructionRow)drv.Row;
            acr.Action = (cmbActionConstruction.SelectedIndex-1).ToString();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string copiedText = "";
            DataGridView dgControl = null;

            if (tabControl.SelectedTab == tabConstruction)
                dgControl = dgConstruction;
            else if (tabControl.SelectedTab == tabFinalization)
                dgControl = dgFinalization;
            else if (tabControl.SelectedTab == tabDefense)
                dgControl = dgDefense;
            else if (tabControl.SelectedTab == tabPage1)
                dgControl = dataGridView1;
            else if (tabControl.SelectedTab == tabPage2)
                dgControl = dataGridView2;

            if (dgControl != null)
            {
                int firstRow = dgControl.SelectedCells[0].RowIndex;
                int lastRow = dgControl.SelectedCells[dgControl.SelectedCells.Count - 1].RowIndex;
                if (firstRow > lastRow)
                {
                    int pivot = firstRow;
                    firstRow = lastRow;
                    lastRow = pivot;
                }

                foreach (DataGridViewRow row in dgControl.Rows)
                {
                    if (row.Index < firstRow) continue;
                    if (row.Index > lastRow) continue;

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Selected == false) continue;

                        copiedText += cell.Value.ToString() + "\t";
                    }

                    copiedText = copiedText.Trim('\t');
                    copiedText += "\n";
                }
                copiedText = copiedText.Trim('\n');
            }

            Clipboard.SetText(copiedText);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pastedText = Clipboard.GetText();

            DataGridView dgControl = null;
            ComboBox cmbControl = null;

            if (tabControl.SelectedTab == tabConstruction)
            {
                dgControl = dgConstruction;
                cmbControl = cmbActionConstruction;
            }
            else if (tabControl.SelectedTab == tabFinalization)
            {
                dgControl = dgFinalization;
                cmbControl = cmbActionFinalization;
            }
            else if (tabControl.SelectedTab == tabDefense)
            {
                dgControl = dgDefense;
                cmbControl = cmbDefense;
            }

            if (dgControl != null)
            {
                int firstRow = -1;
                int firstCol = -1;

                if (dgControl.SelectedCells.Count == 0)
                {
                    firstRow = 0;
                    firstCol = 0;
                }
                else
                {
                    firstRow = dgControl.SelectedCells[0].RowIndex;
                    firstCol = dgControl.SelectedCells[0].ColumnIndex;
                }

                string[] rows = pastedText.Split('\n');

                int iRow = firstRow;

                foreach (string row in rows)
                {
                    if (row == "") continue;
                    string[] items = row.Split('\t');

                    BindingSource bs = (BindingSource)dgControl.DataSource;
                    DataSet ds = (DataSet)bs.DataSource;
                    DataTable dt = ds.Tables[bs.DataMember];

                    if (iRow > dgControl.Rows.Count - 2)
                    {
                        DataRow dr = dt.NewRow();

                        int iCol = firstCol;

                        dr[0] = cmbControl.SelectedIndex-1;

                        foreach (string item in items)
                        {
                            dr[iCol+1] = item;
                            iCol++;
                        }
                        try
                        {
                            dt.Rows.Add(dr);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        int iCol = firstCol;

                        foreach (string item in items)
                        {
                            dgControl.Rows[iRow].Cells[iCol].Value = item;
                            iCol++;
                        }
                    }
                    iRow++;
                }
            }
        }

    }
}
