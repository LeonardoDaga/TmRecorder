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
                NTR_Db.NTR_SquadDb.ActionsRow ar = (NTR_Db.NTR_SquadDb.ActionsRow)dr.DataBoundItem;
                int arColor = ar.TeamRow.Color;
                dr.Cells[1].Style.ForeColor = Color.FromArgb((arColor & 0xff0000) / 0x10000, (arColor & 0xff00) / 0x100, arColor & 0xff);
            }
        }
    }
}