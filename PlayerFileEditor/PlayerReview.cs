using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PlayerFileEditor;
using Common;

namespace TMRecorder
{

    public partial class PlayerReview : UserControl
    {
        List<ScoutReview> srList = null;
        public bool InfoChanged = false;
        bool readOnlyStatus = true;
        public EventHandler isDataChanged;
        ExtraDS.GiocatoriRow gRow = null;
        int lastShowRev = 0;
        bool listenToValueChange = true;

        public ExtraDS.GiocatoriRow plGiocatoriRow
        {
            set { gRow = value; }
            get { return gRow; }
        }

        public PlayerReview()
        {
            InitializeComponent();
            numShowRev.Value = 1;
            lastShowRev = 0;
        }

        public bool ReadOnly
        {
            get { return readOnlyStatus; }
            set
            {
                readOnlyStatus = value;
                txtScoutReview.ReadOnly = readOnlyStatus;
                txtScoutVote.ReadOnly = readOnlyStatus;
                txtScout.ReadOnly = readOnlyStatus;
                txtDate.ReadOnly = readOnlyStatus;
            }
        }

        private void btnPasteScoutData_Click(object sender, EventArgs e)
        {
            srList = ScoutReview.Parse(Clipboard.GetText());

            lblTotal.Text = "of " + srList.Count.ToString();

            listenToValueChange = false;
            numShowRev.Minimum = 1;
            numShowRev.Maximum = srList.Count;
            numShowRev.Value = 1;
            listenToValueChange = true;

            if (srList.Count == 0)
            {
                DisplayReview(-1);
                return;
            }

            DisplayReview(0);

            chkChangeInfos.CheckState = CheckState.Checked;
            chkChangeInfos.Text = "Confirm";
            ReadOnly = false;
            InfoChanged = true;
        }

        public void DisplayReview(int nRev)
        {
            if (nRev == -1)
            {
                txtScoutVote.Text = "";
                txtScoutReview.Text = "";
                txtScout.Text = "";
                txtDate.Text = "";
            }
            else
            {
                txtScoutVote.Text = srList[nRev].Vote.ToString();
                txtScoutReview.Text = srList[nRev].Review;
                txtScout.Text = srList[nRev].ScoutName;
                txtDate.Text = srList[nRev].Date.ToShortDateString();
            }
        }

        private void txtDataChanged(object sender, EventArgs e)
        {
            InfoChanged = true;
        }

        public void FillPlayerInfo(ExtraDS.GiocatoriRow gRow, bool reset)
        {
            srList = ScoutReview.FillWithGiocatoriRow(gRow);

            if (srList == null)
            {
                numShowRev.Minimum = 0;
                numShowRev.Maximum = 0;
                listenToValueChange = false;
                numShowRev.Value = 0;
                listenToValueChange = true;
                lastShowRev = 1;
                DisplayReview(-1);
                lblTotal.Text = "of 0";
                return;
            }

            listenToValueChange = false;
            numShowRev.Minimum = 1;
            numShowRev.Maximum = srList.Count;

            if ((numShowRev.Value > srList.Count) || reset)
            {
                DisplayReview(0);
                listenToValueChange = false;
                numShowRev.Value = 1;
                listenToValueChange = true;
                lastShowRev = 0;
            }
            else
                DisplayReview((int)numShowRev.Value - 1);

            listenToValueChange = true;
            lblTotal.Text = "of " + srList.Count.ToString();
        }

        public void StorePlayerInfo(ref ExtraDS.GiocatoriRow gRow)
        {
            GetDisplayedReview(lastShowRev);
            gRow.FillWithScoutReviewList(srList);
        }

        private void numShowRev_ValueChanged(object sender, EventArgs e)
        {
            if (srList == null) return;
            if (!listenToValueChange) return; 
            
            GetDisplayedReview(lastShowRev);
            lastShowRev = (int)numShowRev.Value-1;
            DisplayReview((int)numShowRev.Value-1);
        }

        private void GetDisplayedReview(int nRev)
        {
            srList[nRev].Vote = int.Parse(txtScoutVote.Text);
            srList[nRev].Review = txtScoutReview.Text;
            srList[nRev].ScoutName = txtScout.Text;
            srList[nRev].Date = DateTime.Parse(txtDate.Text);
        }

        private void addScoutReviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScoutReview sr = new ScoutReview();
            sr.Vote = 1;
            sr.Review = "Review";
            sr.ScoutName = "ScoutName";
            sr.Date = DateTime.Now;

            if (srList == null)
                srList = new List<ScoutReview>();
            srList.Add(sr);

            listenToValueChange = false;
            numShowRev.Minimum = 1;
            numShowRev.Maximum = srList.Count;
            numShowRev.Value = srList.Count;
            lastShowRev = srList.Count - 1;
            listenToValueChange = true;
            lblTotal.Text = "of " + srList.Count.ToString();
            DisplayReview(srList.Count - 1);

            chkChangeInfos.Checked = true;

            InfoChanged = true;
        }

        private void deleteScoutReviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n = (int)numShowRev.Value - 1;
            srList.Remove(srList[n]);
            if (srList.Count > n)
                DisplayReview(n);
            else if (srList.Count == n)
                DisplayReview(n - 1);
            else if (srList.Count > 0)
                DisplayReview(0);
            else
                DisplayReview(-1);

            if (srList.Count > 0)
            {
                listenToValueChange = false;
                numShowRev.Minimum = 1;
                numShowRev.Maximum = srList.Count;
                listenToValueChange = true;
            }
            else
            {
                listenToValueChange = false;
                numShowRev.Minimum = 0;
                numShowRev.Maximum = 0;
                numShowRev.Value = 0;
                listenToValueChange = true;
            }

            lblTotal.Text = "of " + srList.Count.ToString();

            chkChangeInfos.Checked = true;

            InfoChanged = true;
        }
    }
}
