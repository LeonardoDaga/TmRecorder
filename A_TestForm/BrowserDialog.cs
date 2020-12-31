using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_TestForm
{
    public partial class BrowserDialog : Form
    {
        public BrowserDialog()
        {
            InitializeComponent();
        }

        private void BrowserDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            ntR_Browser1.Dispose();
        }
    }
}
