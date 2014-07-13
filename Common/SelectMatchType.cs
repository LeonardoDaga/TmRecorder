using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class SelectMatchType : Form
    {
        public SelectMatchType()
        {
            InitializeComponent();
        }

        public eMatchType MatchType
        {
            get 
            {
                if (rbCupMatch.Checked) return eMatchType.CUP;
                if (rbFriendlyLeagueMatch.Checked) return eMatchType.FLEAGUE;
                if (rbFriendlyMatch.Checked) return eMatchType.FRIENDLY;
                if (rbInternationalMatch.Checked) return eMatchType.INTERNATIONAL;
                // if (rbLeagueMatch.Checked) return eMatchType.CHAMP;
                return eMatchType.CHAMP;
            }
            set
            {
                switch (value)
                {
                    case eMatchType.CHAMP: rbLeagueMatch.Checked = true; break;
                    case eMatchType.CUP: rbCupMatch.Checked = true; break;
                    case eMatchType.FLEAGUE: rbFriendlyLeagueMatch.Checked = true; break;
                    case eMatchType.FRIENDLY: rbFriendlyMatch.Checked = true; break;
                    case eMatchType.INTERNATIONAL: rbInternationalMatch.Checked = true; break;
                }
            }
        }

        public string MatchTypeName
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
