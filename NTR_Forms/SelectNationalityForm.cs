using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NTR_Db;

namespace NTR_Forms
{
    public partial class SelectNationalityForm : Form
    {
        public SelectNationalityForm()
        {
            InitializeComponent();
        }

        public string DefaultNation
        {
            get { return (string)cbDefaultNation.SelectedValue; }
            set
            {
                cbDefaultNation.SelectedValue = value;
            }
        }

        public void SetSource(NTR_Common.Data db)
        {
            cbDefaultNation.DataSource = db.nationsDS.Names;
            cbDefaultNation.DisplayMember = "Name";
            cbDefaultNation.ValueMember = "Abbreviation";
        }

        public void SetSource(NTR_Db.Data db)
        {
            cbDefaultNation.DataSource = db.nationsDS.Names;
            cbDefaultNation.DisplayMember = "Name";
            cbDefaultNation.ValueMember = "Abbreviation";
        }
    }
}
