using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;

namespace TMRecorder
{
    public partial class StartInfoBox : Form
    {
        NationsDS Nations = null;

        public StartInfoBox()
        {
            InitializeComponent();

            SetLanguage();

            Nations = new NationsDS();

            Nations.SetDefaultValues();

            nationNamesBindingSource.DataSource = Nations.Names;

            Program.Setts.Save();
        }

        public string DataDirectory
        {
            get { return txtDataDirectory.Text; }
            set { txtDataDirectory.Text = value; }
        }

        public string UsedLanguage
        {
            get { return cmbLanguage.SelectedItem.ToString().Split(';')[1]; }
            set
            {
                foreach (string item in cmbLanguage.Items)
                {
                    if (item.Split(';')[1] == value)
                    {
                        cmbLanguage.SelectedItem = item;
                        return;
                    }
                }
            }
        }

        public string DefaultNation
        {
            get { return (string)cbDefaultNation.SelectedValue; }
            set
            {
                cbDefaultNation.SelectedValue = value;
            }
        }

        private void btnSelectDataDirectory_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = DataDirectory;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                DataDirectory = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
