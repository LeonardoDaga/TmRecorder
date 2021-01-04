using NTR_Db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A_TestForm
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();

            RatingR3.TestRating();

            this.Load += TestForm_Load;
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
        }

        private void btnOpenDialog_Click(object sender, EventArgs e)
        {
            BrowserDialog dlgBrowser = new BrowserDialog();
            dlgBrowser.ShowDialog();
        }
    }
}
