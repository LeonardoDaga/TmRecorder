using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TMRecorder
{
    public partial class AddExtraTeam : Form
    {
        private int _TeamID = 0;
        public int TeamID
        {
            get
            {
                return _TeamID;
            }
            set
            {
                txtID.Text = value.ToString();
            }
        }

        public string TeamName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }

        public AddExtraTeam()
        {
            InitializeComponent();
        }

        private void AddExtraTeam_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!int.TryParse(txtID.Text, out _TeamID))
            {
                MessageBox.Show("The ID number is not valid");
                e.Cancel = true;
            }
        }
    }
}
