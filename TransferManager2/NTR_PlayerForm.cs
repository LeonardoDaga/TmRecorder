using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NTR_Common;
using Common;
using System.Diagnostics;
using System.IO;

namespace TransferManager
{
    public partial class NTR_PlayerForm : Form
    {
        TSquad Squad = null;
        TeamDS teamDS = null;
        int actPlayerID = -1;
        public bool isDirty = false;

        public NTR_PlayerForm(TeamDS teamds,
                               int playerID,
                               TSquad squad)
        {
            InitializeComponent();

            // Store structures
            teamDS = teamds;
            Squad = squad;
            actPlayerID = playerID;
        }

        private void PlayerForm_Load(object sender, EventArgs e)
        {
            Initialize(actPlayerID);
            FillPlayerBar(actPlayerID);
        }

        public void Initialize(int playerID)
        {
            actPlayerID = playerID;

            TeamDS.GiocatoriNSkillRow gsr = teamDS.GiocatoriNSkill.FindByPlayerID(actPlayerID);
            playerData.PlayerRow = gsr;
            label1.Text = gsr.Nome;

            Squad[playerID].VarData.CheckTI();

            bindingSource.Filter = "";
            bindingSource.Sort = "Week DESC";
            bindingSource.DataSource = Squad[playerID].VarData;
            // dataGridHistory.DataSource = Squad[playerID].VarData;

            SetColumns();
            SetFP(gsr.FP);

            if (gsr.FPn == 0)
                EvidenceSkillsPortieriForGains();
            else
                EvidenceSkillsGiocatoriForGains();
        }

        #region Graphical features
        private void SetFP(string FP)
        {
            string[] FPs = FP.Split('/');
            if (FPs.Length == 1)
            {
                lblFP1.Text = FPs[0];
                SetLabelBack(lblFP1, FPs[0]);
                lblFP2.Visible = false;
            }
            else if (FPs.Length == 2)
            {
                lblFP1.Text = FPs[0];
                lblFP2.Text = FPs[1];
                SetLabelBack(lblFP1, FPs[0]);
                SetLabelBack(lblFP2, FPs[1]);
                lblFP2.Visible = true;
            }
        }
        private void SetLabelBack(Label lblFP, string FP)
        {
            int FPn = Tm_Utility.FPToNumber(FP);

            switch (FPn)
            {
                case 0:
                    lblFP.BackColor = Color.Blue;
                    break;
                case 10:
                case 13:
                case 15:
                    lblFP.BackColor = Color.FromArgb(0, 255, 255);
                    break;
                case 30:
                case 33:
                case 35:
                    lblFP.BackColor = Color.FromArgb(198, 255, 148);
                    break;
                case 50:
                case 53:
                case 55:
                    lblFP.BackColor = Color.FromArgb(255, 255, 2);
                    break;
                case 70:
                case 73:
                case 75:
                    lblFP.BackColor = Color.FromArgb(255, 101, 2);
                    break;
                case 90:
                    lblFP.BackColor = Color.FromArgb(255, 0, 0);
                    break;
            }
        }
        private void SetColumns()
        {
            TeamDS.GiocatoriNSkillRow gsr = teamDS.GiocatoriNSkill.FindByPlayerID(actPlayerID);
            if (gsr.FPn != 0)
            {
                forDataGridViewTextBoxColumn.HeaderText = "Str";
                resDataGridViewTextBoxColumn.HeaderText = "Sta";
                velDataGridViewTextBoxColumn.HeaderText = "Pac";
                marPreDataGridViewTextBoxColumn.HeaderText = "Mar";
                conUnoDataGridViewTextBoxColumn.HeaderText = "Tak";
                worRifDataGridViewTextBoxColumn.HeaderText = "Wor";
                posAerDataGridViewTextBoxColumn.HeaderText = "Pos";
                pasEleDataGridViewTextBoxColumn.HeaderText = "Pas";
                croComDataGridViewTextBoxColumn.HeaderText = "Cro";
                tecTirDataGridViewTextBoxColumn.HeaderText = "Tec";
                tesLanDataGridViewTextBoxColumn.HeaderText = "Hea";
                finDataGridViewTextBoxColumn.HeaderText = "Fin";
                disDataGridViewTextBoxColumn.HeaderText = "Lon";
                calDataGridViewTextBoxColumn.HeaderText = "Set";
                finDataGridViewTextBoxColumn.Visible = true;
                disDataGridViewTextBoxColumn.Visible = true;
                calDataGridViewTextBoxColumn.Visible = true;
            }
            else
            {
                forDataGridViewTextBoxColumn.HeaderText = "Str";
                resDataGridViewTextBoxColumn.HeaderText = "Sta";
                velDataGridViewTextBoxColumn.HeaderText = "Pac";
                marPreDataGridViewTextBoxColumn.HeaderText = "Han";
                conUnoDataGridViewTextBoxColumn.HeaderText = "One";
                worRifDataGridViewTextBoxColumn.HeaderText = "Ref";
                posAerDataGridViewTextBoxColumn.HeaderText = "Ari";
                pasEleDataGridViewTextBoxColumn.HeaderText = "Jum";
                croComDataGridViewTextBoxColumn.HeaderText = "Com";
                tecTirDataGridViewTextBoxColumn.HeaderText = "Kic";
                tesLanDataGridViewTextBoxColumn.HeaderText = "Thr";
                finDataGridViewTextBoxColumn.Visible = false;
                disDataGridViewTextBoxColumn.Visible = false;
                calDataGridViewTextBoxColumn.Visible = false;
            }
        }
        private void EvidenceSkillsGiocatoriForGains()
        {
            DataGridView dgv = dataGridHistory;

            string[] spec = new string[] { "DC", "DR", "DL", "DMC", "DMR", 
                "DML", "MC", "MR", "ML", "OMC", "OMR", "OML", "FC" };

            TeamDS.GiocatoriNSkillRow gsr = teamDS.GiocatoriNSkill.FindByPlayerID(actPlayerID);
            string FP = gsr.FP;
            string[] FPs = FP.Split('/');


            if (FPs.Length == 1)
            {
                int n;
                for (n = 0; n < 13; n++)
                    if (FP == spec[n]) break;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    // Evidenzia solo le colonne degli skills
                    for (int j = 0; j < 14; j++)
                    {
                        DataGridViewCellStyle Style = new DataGridViewCellStyle();
                        ColorUtilities.SelectGainColor(teamDS.GD.K_FP(j, n), ref Style);

                        dgv[j + 2, i].Style = Style;
                    }
                }
            }
            else
            {
                int n1, n2;
                for (n1 = 0; n1 < 13; n1++)
                    if (FPs[0] == spec[n1]) break;
                for (n2 = 0; n2 < 13; n2++)
                    if (FPs[1] == spec[n2]) break;
                string FP1 = FPs[0];
                string FP2 = FPs[1];

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    // Evidenzia solo le colonne degli skills
                    for (int j = 0; j < 14; j++)
                    {
                        DataGridViewCellStyle Style = new DataGridViewCellStyle();
                        float maxGain = Math.Max(teamDS.GD.K_FP(j, n1), teamDS.GD.K_FP(j, n2));
                        ColorUtilities.SelectGainColor(maxGain, ref Style);

                        dgv[j + 2, i].Style = Style;
                    }
                }
            }
        }
        private void EvidenceSkillsPortieriForGains()
        {
            DataGridView dgv = dataGridHistory;

            TeamDS.GiocatoriNSkillRow gsr = teamDS.GiocatoriNSkill.FindByPlayerID(actPlayerID);

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                // Evidenzia solo le colonne degli skills
                for (int j = 0; j < 11; j++)
                {
                    DataGridViewCellStyle Style = new DataGridViewCellStyle();
                    ColorUtilities.SelectGainColor(teamDS.GD.K_GK(j) / 1.5f, ref Style);

                    dgv[j + 2, i].Style = Style;
                }
            }
        }
        #endregion

        private void tsPrevPlayer_Click(object sender, EventArgs e)
        {
            int prevID = teamDS.GiocatoriNSkill.GetPrevID(actPlayerID);
            Initialize(prevID);

            if (tabControl1.SelectedTab == tabPlayerBrowser)
            {
                tsbLoadPlayerPage_Click(sender, e);
            }
            else
            {
                FillPlayerBar(actPlayerID);
            }
        }

        private void tsNextPlayer_Click(object sender, EventArgs e)
        {
            int nextID = teamDS.GiocatoriNSkill.GetNextID(actPlayerID);
            Initialize(nextID);
            FillPlayerBar(actPlayerID);

            if (tabControl1.SelectedTab == tabPlayerBrowser)
            {
                tsbLoadPlayerPage_Click(sender, e);
            }
            else
            {
                FillPlayerBar(actPlayerID);
            }
        }

        private void tsbExplorePlayer_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPlayerBrowser;
            tsbLoadPlayerPage_Click(sender, e);
        }

        private void btnPastePlayerHTML_Click(object sender, EventArgs e)
        {
            //TeamDS.GiocatoriNSkillRow playerDatarow = (TeamDS.GiocatoriNSkillRow)GDT.Rows[iActualPlayer];
            //TMRecorder.ExtraDS.GiocatoriRow gRow = History.PlayersDS.Giocatori.FindByPlayerID(playerDatarow.PlayerID);

            string page = "";
            if (Clipboard.ContainsData(DataFormats.Html))
            {
                page = (string)Clipboard.GetData(DataFormats.Html);

                if (page.Contains("SourceURL:http://trophymanager.com/showprofile.php"))
                    page = page.Replace("http://trophymanager.com/showprofile.php", "SourceURL:<TM - Showprofile>");
                else
                    page = "";
            }

            if (page == "")
                page = Clipboard.GetText();

            if (!page.Contains("TM - Showprofile"))
            {
                MessageBox.Show("The pasted HTML code is not valid");
                return;
            }

            teamDS.ParsePlayerPage(page, actPlayerID);

            TeamDS.GiocatoriNSkillRow gsr = teamDS.GiocatoriNSkill.FindByPlayerID(actPlayerID);
            playerData.PlayerRow = gsr;
        }

        string navigationAddress = "";
        string startnavigationAddress = "";
        private void tsbLoadPlayerPage_Click(object sender, EventArgs e)
        {
            navigationAddress = "http://trophymanager.com/players/" + actPlayerID.ToString() + "/";
            if (navigationType == NavigationType.NavigateReports)
                navigationAddress += "#/page/scout/";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
        }

        #region WebBrowser Navigation
        private void webBrowser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress <= 0)
            {
                if (webBrowser.ReadyState == WebBrowserReadyState.Complete)
                {
                    tsbProgressText.Text = "100%";
                    tsbProgressBar.ForeColor = Color.Green;
                    tsbProgressBar.Value = 100;
                }
                return;
            }
            int perc = (int)((e.CurrentProgress * 100) / e.MaximumProgress);
            if (perc < 0) perc = 0;
            if (perc > 100) perc = 100;
            tsbProgressBar.Value = perc;
            tsbProgressText.Text = perc.ToString() + "%";
            tsbProgressBar.ForeColor = Color.Blue;
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.ToString() != navigationAddress) return;

            // this.Text = "TMR Browser - Navigation Complete";
            tsbProgressBar.ForeColor = Color.Green;
        }

        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.ToString().StartsWith("http://trophymanager.com/livematch.php?matchid="))
            {
                string kampid = e.Url.ToString().Split('=')[1];
                navigationAddress = "http://trophymanager.com/kamp.php?kampid=" + kampid + ",0,0&show=report";
                webBrowser.Navigate(navigationAddress);
                startnavigationAddress = navigationAddress;
            }
            else if (e.Url.ToString().StartsWith("http://trophymanager.com/"))
            {
                navigationAddress = e.Url.ToString();

                if (navigationAddress.Contains("banners.php")) return;

                startnavigationAddress = navigationAddress;

                if (startnavigationAddress.Contains("http://trophymanager.com/players/"))
                {

                    lastBarPlayer = int.Parse(HTML_Parser.GetNumberAfter(startnavigationAddress, "/players/"));

                    FillPlayerBar(lastBarPlayer);
                }
                else
                {
                    tsBrowsePlayers.Visible = false;
                }
            }
            else
            {
                navigationAddress = e.Url.ToString();
            }

            tsbProgressBar.Value = 0;
            tsbProgressText.Text = "0%";
            tsbProgressBar.ForeColor = Color.Blue;
        }

        private void FillPlayerBar(int playerID)
        {
            TeamDS.GiocatoriNSkillRow gRow = teamDS.GiocatoriNSkill.FindByPlayerID(playerID);

            if (gRow == null)
            {
                tsBrowsePlayers.Visible = false;
                return;
            }

            tsBrowsePlayers.Visible = true;

            //tsbNumberOfReviews.Text = gRow.ScoutReviews.Length + " Scout Reviews stored";

            tsbPlayers.Text = "[" + gRow.FP + "] " + gRow.Nome;

            AddMenuItem(tsbPlayers, "", null);
            for (int i = 0; i < teamDS.GiocatoriNSkill.Count; i++)
            {
                ToolStripItem tsi = new ToolStripMenuItem();
                tsi.Text = "[" + teamDS.GiocatoriNSkill[i].FP + "] " + teamDS.GiocatoriNSkill[i].Nome;
                tsi.Tag = teamDS.GiocatoriNSkill[i].PlayerID;
                tsi.Click += ChangePlayer_Click;
                AddMenuItem(tsbPlayers, teamDS.GiocatoriNSkill[i].FP, tsi);
            }
        }
        #endregion

        private void navigateProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbNavigationType.Text = navigateProfilesToolStripMenuItem.Text;
            tsbNavigationType.Image = navigateProfilesToolStripMenuItem.Image;

            if (navigationType != NavigationType.NavigateProfiles)
            {
                navigationType = NavigationType.NavigateProfiles;
                navigationAddress = "http://trophymanager.com/players/" +
                    actPlayerID.ToString() + "/";
                webBrowser.Navigate(navigationAddress);
                startnavigationAddress = navigationAddress;
            }
        }

        private void navigateReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbNavigationType.Text = navigateReportsToolStripMenuItem.Text;
            tsbNavigationType.Image = navigateReportsToolStripMenuItem.Image;

            if (navigationType != NavigationType.NavigateReports)
            {
                navigationType = NavigationType.NavigateReports;
                navigationAddress = "http://trophymanager.com/players/" +
                    actPlayerID.ToString() + "/#/page/scout/";
                webBrowser.Navigate(navigationAddress);
                startnavigationAddress = navigationAddress;
            }
        }

        string doctext = "";
        private void tsbImport_Click(object sender, EventArgs e)
        {
            if (startnavigationAddress == "") return;

            HtmlElementCollection hmtlElColl = webBrowser.Document.All;

            try
            {
                if (startnavigationAddress.Contains("http://trophymanager.com/players/"))
                {
                    if (webBrowser.Document.Body == null) return;
                    doctext = webBrowser.Document.Body.InnerHtml;
                }
                else
                    doctext = webBrowser.DocumentText;
            }
            catch (FileNotFoundException)
            {
                doctext = "";
            }

            if (doctext == "")
            {
                foreach (HtmlElement hel in webBrowser.Document.All)
                {
                    if (hel.InnerHtml != null)
                        doctext += hel.InnerHtml;
                }
            }

            string page = doctext;

            SaveImportedFile(page, webBrowser.Url);

            if (startnavigationAddress.Contains("http://trophymanager.com/players/"))
                page = "SourceURL:<TM - Showprofile>\n" + page;
            else
            {
                if (MessageBox.Show("Cannot import this page here. Here you can import only player profiles.\n" +
                    "Pressing OK, you send a report to Atletico Granata that will try to detect the reason of the error.",
                    "Import error", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string swRelease = "Sw Release:" + Application.ProductName + "("
                       + Application.ProductVersion + ")";
                    page = "Navigation Address: " + startnavigationAddress + "\n" + page;
                    Exception ex = new Exception("Navigation error");
                    SendFileTo.ErrorReport.Send(ex, page, Environment.StackTrace, swRelease);
                }
                return;
            }

            if (!page.Contains("TM - Showprofile"))
            {
                return;
            }

            Squad[actPlayerID].ParsePlayerPage(page);

            TeamDS.GiocatoriNSkillRow gsr = teamDS.GiocatoriNSkill.FindByPlayerID(actPlayerID);
            PlayersDS.FixDataRow fdr = Squad[actPlayerID].FixDataVal;
            PlayersDS.VarDataRow vdr = Squad[actPlayerID].VarData.FindByWeek(TmWeek.thisWeek().absweek);

            gsr.Nome = fdr.Nome;
            gsr.Nationality = fdr.Nationality;
            gsr.wBorn = fdr.wBorn;

            if (fdr.IsRouNull()) fdr.Rou = 0;
            gsr.Rou = fdr.Rou;

            if (vdr.Skills != null)
                gsr.Skills = vdr.Skills;
            
            if (!vdr.IsASINull())
                gsr.ASI = vdr.ASI;

            int thisweek = TmWeek.thisWeek().absweek;
            int i = 1;
            for (; i < 5; i++)
            {
                int pastweek = thisweek - i;

                PlayersDS.VarDataRow pvdr = Squad[actPlayerID].VarData.FindByWeek(pastweek);

                if (pvdr != null)
                {
                    vdr._TI = gsr.cTI = Tm_Utility.ASItoTI(gsr.ASI, pvdr.ASI, gsr.FPn == 0) / ((decimal)i);
                    break;
                }
            }            

            Initialize(actPlayerID);

            isDirty = true;
        }

        private void SaveImportedFile(string page, Uri url)
        {
            // Check the existence of the folder
            DirectoryInfo di = new DirectoryInfo(Path.Combine(Program.Setts.DefaultDirectory, "ImportedPages"));
            if (!di.Exists)
            {
                di.Create();
            }

            string filedate = TmWeek.ToSWDString(DateTime.Now);

            string filename = url.LocalPath.Replace(".php", "").Replace("/", "");

            if (filename == "showprofile")
            {
                string playerid = HTML_Parser.GetNumberAfter(url.ToString(), "playerid=");
                filename += "_" + playerid + "_" + filedate + ".htm";
            }

            FileInfo fi = new FileInfo(Path.Combine(di.FullName, filename));

            StreamWriter file = new StreamWriter(fi.FullName);
            file.Write(page);
            file.Close();
        }

        private void tsbComputeGrowth_Click(object sender, EventArgs e)
        {
            PlayersDS pDS = teamDS.Squad[actPlayerID];
            PlayersDS.FixDataRow fDR = pDS.FixData[0];
            TeamDS.GiocatoriNSkillRow gRow = teamDS.GiocatoriNSkill.FindByPlayerID(actPlayerID);

            ComputeBloom cb = new ComputeBloom();
            cb.ActualASI = gRow.ASI;
            cb.CurrentSkillSum = (decimal)Tm_Utility.ASItoSkSum((decimal)gRow.ASI, false);
            cb.RealSkillSum = gRow.SkillSum;

            WeekHistorical whTI = new WeekHistorical(pDS.FullTIHistory);
            if (!float.IsNaN(whTI.ActualTI))
                cb.ActualTI = (decimal)whTI.ActualTI;
            else
                cb.ActualTI = 0;

            cb.PlayerNameAndID = gRow.Nome + "\n(" + gRow.PlayerID.ToString() + ")";

            if (fDR.wBloomStart == -1)
            {
                fDR.wBloomStart = whTI.FindBloomStart();

                cb.AgeStartOfBloom = (fDR.wBloomStart - gRow.wBorn) / 12;
                cb.ExplosionTI = fDR.ExplosionTI;
                cb.AfterBloomingTI = fDR.AfterBloomTI;
                cb.BeforeExplosionTI = fDR.BeforeExplTI;
            }
            else
            {
                cb.AgeStartOfBloom = (fDR.wBloomStart - gRow.wBorn) / 12;
                cb.ExplosionTI = fDR.ExplosionTI;
                cb.AfterBloomingTI = fDR.AfterBloomTI;
                cb.BeforeExplosionTI = fDR.BeforeExplTI;
            }

            int savedBloomStart = cb.AgeStartOfBloom;

            cb.isGK = false;
            cb.PlayerBornWeek = gRow.wBorn;
            cb.ShowDialog();

            if ((savedBloomStart != cb.AgeStartOfBloom) ||
                (fDR.ExplosionTI != cb.ExplosionTI) ||
                (fDR.AfterBloomTI != cb.AfterBloomingTI) ||
                (fDR.BeforeExplTI != cb.BeforeExplosionTI))
            {
                fDR.wBloomStart = gRow.wBorn + cb.AgeStartOfBloom * 12;
                fDR.ExplosionTI = cb.ExplosionTI;
                fDR.AfterBloomTI = cb.AfterBloomingTI;
                fDR.BeforeExplTI = cb.BeforeExplosionTI;
            }

            fDR.Asi25 = (decimal)(int)cb.ASI25;
            fDR.Asi30 = (decimal)(int)cb.ASI30;

            isDirty = true;
        }

        private void AddMenuItem(ToolStripDropDownButton tsbPlayers, string FP, ToolStripItem tsi)
        {
            if (tsi == null)
            {
                gKToolStripMenuItem.DropDownItems.Clear();
                dDefendersToolStripMenuItem.DropDownItems.Clear();
                dMDefenderMidfieldersToolStripMenuItem.DropDownItems.Clear();
                mMidfieldersToolStripMenuItem.DropDownItems.Clear();
                oMOffenderMidfieldersToolStripMenuItem.DropDownItems.Clear();
                fForwardsToolStripMenuItem.DropDownItems.Clear();
                return;
            }

            string[] fps = FP.Split('/');

            foreach (string fp in fps)
            {
                ToolStripItem itsi = new ToolStripMenuItem();
                itsi.Click += ChangePlayer_Click;
                itsi.Text = tsi.Text;
                itsi.Tag = tsi.Tag;

                if (fp == "GK")
                {
                    if (gKToolStripMenuItem.DropDownItems.Count > 20) continue;
                    gKToolStripMenuItem.DropDownItems.Add(itsi);
                }
                if ((fp == "DC") || (fp == "DL") || (fp == "DR"))
                {
                    if (dDefendersToolStripMenuItem.DropDownItems.Count > 20) continue;
                    if (!FindItemInMenu(dDefendersToolStripMenuItem, itsi.Text))
                        dDefendersToolStripMenuItem.DropDownItems.Add(itsi);
                }
                if ((fp == "DMC") || (fp == "DML") || (fp == "DMR"))
                {
                    if (dMDefenderMidfieldersToolStripMenuItem.DropDownItems.Count > 20) continue;
                    if (!FindItemInMenu(dMDefenderMidfieldersToolStripMenuItem, itsi.Text))
                        dMDefenderMidfieldersToolStripMenuItem.DropDownItems.Add(itsi);
                }
                if ((fp == "MC") || (fp == "ML") || (fp == "MR"))
                {
                    if (mMidfieldersToolStripMenuItem.DropDownItems.Count > 20) continue;
                    if (!FindItemInMenu(mMidfieldersToolStripMenuItem, itsi.Text))
                        mMidfieldersToolStripMenuItem.DropDownItems.Add(itsi);
                }
                if ((fp == "OMC") || (fp == "OML") || (fp == "OMR"))
                {
                    if (oMOffenderMidfieldersToolStripMenuItem.DropDownItems.Count > 20) continue;
                    if (!FindItemInMenu(oMOffenderMidfieldersToolStripMenuItem, itsi.Text))
                        oMOffenderMidfieldersToolStripMenuItem.DropDownItems.Add(itsi);
                }
                if (fp == "FC")
                {
                    if (fForwardsToolStripMenuItem.DropDownItems.Count > 20) continue;
                    fForwardsToolStripMenuItem.DropDownItems.Add(itsi);
                }
            }
        }

        private bool FindItemInMenu(ToolStripMenuItem menu, string text)
        {
            bool found = false;
            foreach (ToolStripItem ftsi in menu.DropDownItems)
            {
                if (ftsi.Text == text)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        #region Player Profiles Navigation
        enum NavigationType
        {
            NavigateProfiles,
            NavigateReports
        }
        
        NavigationType navigationType = NavigationType.NavigateProfiles;
        int lastBarPlayer = 0;
        private void ChangePlayer_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsi = (ToolStripMenuItem)sender;
            int changeID = (int)tsi.Tag;
            Initialize(changeID);

            if (tabControl1.SelectedTab == tabPlayerBrowser)
            {
                tsbLoadPlayerPage_Click(sender, e);
            }
            else
            {
                FillPlayerBar(changeID);
            }
        }
        #endregion

        private void dataGridHistory_Sorted(object sender, EventArgs e)
        {
            Initialize(actPlayerID);
        }

        private void tsBrowsePlayers_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}