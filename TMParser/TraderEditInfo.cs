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
    public partial class TraderEditInfo : Form
    {
        public Trading trading = null;

        public TraderEditInfo()
        {
            InitializeComponent();
        }

        public void GetPlayer(ref Trading.PlayersRow pr)
        {
            pr.PlayerID = int.Parse(txtPlayerID.Text);
            pr.Name = txtName.Text;

            if (cmbNationality.SelectedItem != null)
            {
                string[] txts = cmbNationality.SelectedItem.ToString().Split(';');
                pr.Nation = txts[1];
            }

            if (txtSellPrice.Text != "")
                pr.SellPrice = int.Parse(txtSellPrice.Text);

            if (txtAcquisitionPrice.Text != "")
                pr.AcquirePrice = int.Parse(txtAcquisitionPrice.Text);
            if (txtStartASI.Text != "")
                pr.ASIwhenBuyed = int.Parse(txtStartASI.Text);
            if (txtEndASI.Text != "")
                pr.ASIwhenSold = int.Parse(txtEndASI.Text);

            pr.DateAcquire = TmWeek.GetTmAbsWk(dtFirstWeek.Value);
            pr.DateSell = TmWeek.GetTmAbsWk(dtLastWeek.Value);
        }

        public void SetPlayer(ref Trading.PlayersRow pr)
        {
            txtPlayerID.Text = pr.PlayerID.ToString();
            txtName.Text = pr.Name;

            if (pr.IsNationNull())
                pr.Nation = "aq";

            foreach (object item in cmbNationality.Items)
            {
                string[] txts = item.ToString().Split(';');
                
                if (txts[1] == pr.Nation)
                {
                    cmbNationality.SelectedItem = item;
                    break;
                }
            }

            if (!pr.IsSellPriceNull())
                txtSellPrice.Text = pr.SellPrice.ToString();
            if (!pr.IsAcquirePriceNull())
                txtAcquisitionPrice.Text = pr.AcquirePrice.ToString();
            if (!pr.IsASIwhenBuyedNull())
                txtStartASI.Text = pr.ASIwhenBuyed.ToString();
            if (!pr.IsASIwhenSoldNull())
                txtEndASI.Text = pr.ASIwhenSold.ToString();

            if (!pr.IsDateAcquireNull())
            {
                TmWeek tmw = new TmWeek(pr.DateAcquire);
                dtFirstWeek.Value = tmw.ToDate();
            }
            if (!pr.IsDateSellNull())
            {
                TmWeek tmw = new TmWeek(pr.DateSell);
                dtLastWeek.Value = tmw.ToDate();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}