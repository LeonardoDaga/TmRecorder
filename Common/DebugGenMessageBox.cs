using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Common
{
    public partial class DebugGenMessageBox : Form
    {
        Userdata.InfoDataTable idt = new Userdata.InfoDataTable();

        public DebugGenMessageBox()
        {
            InitializeComponent();
        }

        public string Message
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value;  }
        }

        public string EmailBody
        {
            get { return txtEmailBody.Text; }
            set { txtEmailBody.Text = value; }
        }

        private string _emailAttachment;
        public string EmailAttachment
        {
            get { return _emailAttachment; }
            set { _emailAttachment = value; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveDebug_Click(object sender, EventArgs e)
        {
            string filename = "userdata." + DateTime.Now.Month.ToString("00") +
                DateTime.Now.Day.ToString("00") + "." + DateTime.Now.Hour.ToString("00") +
                DateTime.Now.Minute.ToString("00") + ".tmreport";
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            appDataFolder = Path.Combine(appDataFolder, "TmRecorder");
            string pathfilename = Path.Combine(appDataFolder, filename);

            DirectoryInfo di = new DirectoryInfo(appDataFolder);
            FileInfo[] fis = di.GetFiles("*.tmreport");
            foreach (FileInfo fid in fis)
            {
                fid.Delete();
            }

            FileInfo fi = null;
            try
            {
                fi = new FileInfo(pathfilename);
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Sorry, but I'm not able to create the file that has this name: \n\"" +
                    pathfilename + "\"\nThen it's impossible to send the error report. Please, send this " +
                    "info to Atletico Granata or send an email to led.lennon@gmail.com");
                return;
            }

            StreamWriter fileWriter = new StreamWriter(fi.FullName);
            fileWriter.Write(_emailAttachment);
            fileWriter.Close();

            ProcessStartInfo psi = new ProcessStartInfo("explorer.exe", fi.Directory.FullName);
            Process.Start(psi);
        }
    }
}