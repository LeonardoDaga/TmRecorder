using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class AskForString : Form
    {
        public Button pressedButton = null;

        public AskForString()
        {
            InitializeComponent();
        }

        public string Message
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }
        }

        public string EntryText
        {
            get { return txtString.Text; }
            set { txtString.Text = value; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            pressedButton = btnOK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pressedButton = btnCancel;
            this.Close();
        }
    }
}
