using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ASI2TI
{
    public partial class ASI2TI : Form
    {
        public ASI2TI()
        {
            InitializeComponent();
        }

        public decimal ASILastWeek
        {
            get 
            {
                decimal value;
                if (decimal.TryParse(txtASILastWeek.Text, out value))
                    return value;
                else
                    return 0;
            }
            set { txtASILastWeek.Text = value.ToString("N2"); }
        }

        public decimal ASIthisWeek
        {
            get
            {
                decimal value;
                if (decimal.TryParse(txtASIthisWeek.Text, out value))
                    return value;
                else
                    return 0;
            }
            set { txtASIthisWeek.Text = value.ToString("N2"); }
        }

        public decimal ASIDifference
        {
            get { return decimal.Parse(txtASIDifference.Text); }
            set { txtASIDifference.Text = value.ToString("N2"); }
        }

        public decimal SkillSumLastWeek
        {
            get { return decimal.Parse(txtSkillSumLastWeek.Text); }
            set { txtSkillSumLastWeek.Text = value.ToString("N2"); }
        }

        public decimal SkillSumThisWeek
        {
            get { return decimal.Parse(txtSkillSumThisWeek.Text); }
            set { txtSkillSumThisWeek.Text = value.ToString("N2"); }
        }

        public decimal SkillSumChange
        {
            get { return decimal.Parse(txtSkillSumChange.Text); }
            set { txtSkillSumChange.Text = value.ToString("N2"); }
        }

        public decimal RelatedTI
        {
            get { return decimal.Parse(txtRelatedTI.Text); }
            set { txtRelatedTI.Text = value.ToString("N2"); }
        }

        private void txtASI_TextChanged(object sender, EventArgs e)
        {
            if (chkGK.Checked)
            {
                SkillSumLastWeek = (decimal)Math.Pow(10, ((Math.Log10((double)ASILastWeek) + 10.769) / 6.7284)) / 1.273M;
                SkillSumThisWeek = (decimal)Math.Pow(10, ((Math.Log10((double)ASIthisWeek) + 10.769) / 6.7284)) / 1.273M;
            }
            else
            {
                SkillSumLastWeek = (decimal)Math.Pow(10, ((Math.Log10((double)ASILastWeek) + 10.769) / 6.7284));
                SkillSumThisWeek = (decimal)Math.Pow(10, ((Math.Log10((double)ASIthisWeek) + 10.769) / 6.7284));
            }
            ASIDifference = ASIthisWeek - ASILastWeek;
            SkillSumChange = SkillSumThisWeek - SkillSumLastWeek;
            RelatedTI = (decimal)(10.0 * (double)SkillSumChange);
        }


    }
}