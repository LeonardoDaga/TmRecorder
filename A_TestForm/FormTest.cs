using NTR_Controls;
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
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();

            Gecko.Xpcom.Initialize("c:\\xulrunner");

            webBrowser.Navigate("http://www.trophymanager.com");
        }

        private void matchStats1_Load(object sender, EventArgs e)
        {
        }

        
    }
}
