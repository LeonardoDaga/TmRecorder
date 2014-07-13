using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;

namespace TMR_Lineup
{
    public partial class FormationSelector : Form
    {
        public Formation SelectedFormation = new Formation(eFormationTypes.Type_4_4_2);

        public FormationSelector()
        {
            InitializeComponent();

            cmbFormationType.Items.Clear();

            foreach (eFormationTypes type in Enum.GetValues(typeof(eFormationTypes)))
            {
                Formation form = new Formation(type);
                cmbFormationType.Items.Add(form);
                if (type == SelectedFormation.Type)
                    SelectedFormation = form;
            }

            cmbFormationType.SelectedItem = SelectedFormation;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectedFormation = (Formation)cmbFormationType.SelectedItem;
            this.Close();
        }

        private void FormationSelector_Load(object sender, EventArgs e)
        {

        }
    }
}