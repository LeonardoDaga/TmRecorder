using System;
using System.IO;
using System.Windows.Forms;

namespace A_TestForm
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            string xulDir = Properties.Settings.Default.xulRunnerPath;

            InitializeComponent();
            string xulRunnerPath = ntR_Browser1.CheckXulInitialization(Properties.Settings.Default.xulRunnerPath);

            if (xulRunnerPath == "")
                Close();

            Properties.Settings.Default.xulRunnerPath = xulRunnerPath;
        }
    }
}
