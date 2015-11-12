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

            bool DialogResult = CheckXulDir(xulDir);

            if (DialogResult)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.SelectedPath = Properties.Settings.Default.xulRunnerPath;
                fbd.Description = "Select the Folder where the XUL dll is located";
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    xulDir = fbd.SelectedPath;
                    DialogResult = CheckXulDir(xulDir);
                }
            }

            if (!DialogResult)
            {
                Properties.Settings.Default.xulRunnerPath = xulDir;
                Properties.Settings.Default.Save();
            }
            else
            {
                MessageBox.Show("This application needs XUL, sorry");
                Close();
            }

            InitializeComponent();
            ntR_Browser1.SetXUL(xulDir);
        }

        private static bool CheckXulDir(string xulDir)
        {
            bool DialogResult = false;

            try
            {
                DirectoryInfo di = new DirectoryInfo(xulDir);
                if (di.Exists)
                {
                    FileInfo[] fis = di.GetFiles("xul.dll");
                    if (fis.Length == 0)
                    {
                        string message = string.Format("The folder {0} does not contain the xul DLL. Press OK to select another folder, otherwise press CANCEL to close the application.", Properties.Settings.Default.xulRunnerPath)
                            + "\nIf you want to download XUL, see instructions in http://tmr.insyde.it/xul";
                        if (MessageBox.Show(message, "Missing XUL Dll for TmRecorder", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                            DialogResult = true;
                    }
                }
                else
                {
                    DialogResult = true;
                }
            }
            catch (Exception)
            {
                DialogResult = true;
            }

            return DialogResult;
        }
    }
}
