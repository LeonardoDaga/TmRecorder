using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NTR_Common
{
    public partial class AlarmForm : Form
    {
        public AlarmForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int res;

            if ((int.TryParse(txtMinutesBefore.Text, out res))&&
                (int.TryParse(txtPlayerID.Text, out res)))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Error", "You must type valid integer numbers in the minutes and id fields");
        }
    }
}