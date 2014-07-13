using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TMRecorder
{
    public partial class MatchActionsList : Form
    {
        public MatchActionsList()
        {
            InitializeComponent();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                Common.MatchDS.ActionsRow ar = (Common.MatchDS.ActionsRow)(((System.Data.DataRowView)(dr.DataBoundItem)).Row);
                dr.Cells[1].Style.ForeColor = Color.FromArgb((ar.Color & 0xff0000) / 0x10000, (ar.Color & 0xff00) / 0x100, ar.Color & 0xff);
            }
        }
    }
}