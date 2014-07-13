using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Common
{
    public partial class FillInfoMessageBox : Form
    {
        Userdata.InfoDataTable idt = new Userdata.InfoDataTable();

        public FillInfoMessageBox()
        {
            InitializeComponent();

            string filename = "userdata." + DateTime.Now.Hour.ToString() +
                DateTime.Now.Minute.ToString() + ".tmreport.txt";
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            appDataFolder = Path.Combine(appDataFolder, "TmRecorder");
            string pathfilename = Path.Combine(appDataFolder, filename);
            FileInfo fi = new FileInfo(pathfilename);

            if (fi.Exists)
            {
                idt.ReadXml(fi.FullName);
                Userdata.InfoRow ir = idt[0];

                NameUser = ir.NameUser;
                Team = ir.Team;
                Email = ir.Email;
            }            
        }

        public string Message
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value;  }
        }

        public string NameUser
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }

        public string Comments
        {
            get { return txtComments.Text; }
            set { txtComments.Text = value; }
        }

        public string Email
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text = value; }
        }

        public string Team
        {
            get { return txtTeam.Text; }
            set { txtTeam.Text = value; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string filename = "userdata." + DateTime.Now.Hour.ToString() +
                DateTime.Now.Minute.ToString() + ".tmreport.txt";
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            appDataFolder = Path.Combine(appDataFolder, "TmRecorder");
            string pathfilename = Path.Combine(appDataFolder, filename);
            FileInfo fi = new FileInfo(pathfilename);

            Userdata.InfoRow ir = null;

            if (idt.Rows.Count == 0)
            {
                ir = idt.NewInfoRow();
                idt.AddInfoRow(ir);
            }
            else
            {
                ir = idt[0];
            }

            ir.NameUser = NameUser;
            ir.Team = Team;
            ir.Email = Email;

            idt.WriteXml(fi.FullName);
        }
    }
}