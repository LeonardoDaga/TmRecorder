using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NTR_Common;
using System.IO;
using Common;
using System.Reflection;
using System.Diagnostics;
using mshtml;

namespace TransferManager
{
    public partial class TManForm : Form
    {
        bool isDirty = false;
        bool updateDeletedPlayers = true;

        public TManForm(string[] args)
        {
            InitializeComponent();

            Program.Setts.Initialize(args);

            LoadData();
        }

        void LoadData()
        {
            try
            {
                if (Program.Setts.AutoSaveAndLoad)
                {
                    FileInfo fi = new FileInfo(Path.Combine(Program.Setts.DefaultDirectory, "LastSearchData.xml"));

                    if (fi.Exists) teamDS.Load(fi);
                }
            }
            catch (Exception)
            {
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            teamDS.Save(Program.Setts.DefaultDirectory, "Transfer.3.xml");
        }

        private void loadTransferListFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            teamDS.Load(Program.Setts.DefaultDirectory, "Transfer.3.xml");

            EvidenceSkillsGiocatoriForQuality(-1);
            EvidenceSkillsGiocatoriForGains();
            EvidenceSkillsPortieriForQuality(-1);
            EvidenceSkillsPortieriForGains();
        }

        private void ShortlistForm_Load(object sender, EventArgs e)
        {
            Text = "Trophy Manager - TransferManager v." + Application.ProductVersion;

            LoadGains();

            UpdateTables();

            tsBrowsePlayers.Visible = false;

            try
            {
                teamDS.LoadBidAlarms();
            }
            catch (Exception)
            {
            }

            timer1.Enabled = teamDS.CheckPendingAlarms();
            dontUpdateTheDeletedPlayersToolStripMenuItem.Checked = Program.Setts.RefreshDataOnly;
            evidenceGainsOnThePlayerTableToolStripMenuItem.Checked = Program.Setts.EvidenceGain;
        }

        private void LoadGains()
        {
            if (teamDS.LoadGains(Program.Setts.GainDSfilename))
            {
                Program.Setts.GainDSfilename = teamDS.GD.GainDSfilename;
                Program.Setts.Save();
            }

            teamDS.GD.NormalizeGains = Program.Setts.NormalizeGains;
        }

        private void openPlayersPageInTheTrophyManagerWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dgv;

            if (tabControl.SelectedTab == tabPlayers)
                dgv = dgGiocatori;
            else
                dgv = dgPortieri;

            DataGridViewRow row = dgv.SelectedRows[0];

            DataRowView drv = (DataRowView)row.DataBoundItem;
            TeamDS.GiocatoriNSkillRow gsr = (TeamDS.GiocatoriNSkillRow)drv.Row;
            int PlayerID = gsr.PlayerID;

            string navigationAddress = "http://trophymanager.com/players/" + PlayerID.ToString() + "/";

            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;

            tabControl.SelectedTab = tabPage1;
        }

        private void openPlayersScoutPageInTheTrophyManagerWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dgv;

            if (tabControl.SelectedTab == tabPlayers)
                dgv = dgGiocatori;
            else
                dgv = dgPortieri;

            if (dgv.SelectedRows.Count < 1) return;

            DataGridViewRow row = dgv.SelectedRows[0];

            DataRowView drv = (DataRowView)row.DataBoundItem;
            TeamDS.GiocatoriNSkillRow gsr = (TeamDS.GiocatoriNSkillRow)drv.Row;
            int PlayerID = gsr.PlayerID;

            string navigationAddress = "http://trophymanager.com/players/" + PlayerID.ToString() + "/#/page/scout/";

            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;

            tabControl.SelectedTab = tabPage1;
        }

        private void openPlayersPropertyPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dgv;

            if (tabControl.SelectedTab == tabPlayers)
                dgv = dgGiocatori;
            else
                dgv = dgPortieri;

            if (dgv.SelectedRows.Count < 1) return;

            DataGridViewRow row = dgv.SelectedRows[0];
            DataRowView drv = (DataRowView)row.DataBoundItem;
            TeamDS.GiocatoriNSkillRow gsr = (TeamDS.GiocatoriNSkillRow)drv.Row;

            NTR_PlayerForm pf = new NTR_PlayerForm(teamDS, gsr.PlayerID, teamDS.Squad);
            pf.ShowDialog();

            if (pf.isDirty) isDirty = true;
        }

        private void dgGiocatori_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            openPlayersPropertyPageToolStripMenuItem_Click(sender, EventArgs.Empty);
        }

        private string Import_Transfer_Adv()
        {
            string pl_data = "";

            try
            {
                object doc = webBrowser.Document.DomDocument;
                doctext = webBrowser.Document.Body.InnerHtml;

                HtmlElement head = webBrowser.Document.GetElementsByTagName("head")[0];
                HtmlElement scriptEl = webBrowser.Document.CreateElement("script");
                IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;

                element.text = System.IO.File.ReadAllText(Program.Setts.DatafilePath + "\\transfer_loader.js");
                HtmlElement res = head.AppendChild(scriptEl);
                pl_data = (string)webBrowser.Document.InvokeScript("get_transfer");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return pl_data;
        }

        private string Import_Shortlist_Adv()
        {
            string pl_data = "";

            try
            {
                HtmlElement head = webBrowser.Document.GetElementsByTagName("head")[0];
                HtmlElement scriptEl = webBrowser.Document.CreateElement("script");
                IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;

                element.text = System.IO.File.ReadAllText(Program.Setts.DatafilePath + "\\shortlist_loader.js");
                HtmlElement res = head.AppendChild(scriptEl);
                pl_data = (string)webBrowser.Document.InvokeScript("get_shortlist");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return pl_data;
        }

        string doctext = "";
        private void tsbImport_Click(object sender, EventArgs e)
        {
            if (startnavigationAddress == "") return;

            try
            {
                if (startnavigationAddress.Contains("/transfer/"))
                {
                    doctext = Import_Transfer_Adv();
                }
                else if (startnavigationAddress.Contains("/shortlist/"))
                {
                    doctext = Import_Shortlist_Adv();
                }
                else
                {
                    doctext = "Doc Text: \n" + webBrowser.DocumentText;
                }
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

            if (startnavigationAddress.Contains("shortlist.php"))
                page = "SourceURL:<TM - Shortlist>\n" + page;
            else if (startnavigationAddress.Contains("klubhus_squad.php"))
                page = "SourceURL:<TM - Clubhouse>\n" + page;
            else if (startnavigationAddress.Contains("/transfer/"))
                page = "SourceURL:<NewTM - Transfer>\n" + page;
            else if (startnavigationAddress.Contains("/shortlist/"))
                page = "SourceURL:<NewTM - Shortlist>\n" + page;
            else
            {
                if (MessageBox.Show("Cannot import this page here. Here you can import only shortlists.\n" +
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

            if ((!page.Contains("TM - Shortlist")) &&
                (!page.Contains("TM - Clubhouse")) &&
                (!page.Contains("NewTM - Shortlist")) &&
                (!page.Contains("NewTM - Transfer")))
            {
                return;
            }

            LoadHTMLfile_newPage(page);

            UpdateTables();
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
            string filehour = DateTime.Now.Hour.ToString() + "_" +
                DateTime.Now.Minute.ToString();

            if (filename == "shortlist")
            {
                filename += "_" + filedate + ".htm";
            }
            else if (filename == "klubhus_squad")
            {
                filename += "_" + filedate + ".htm";
            }
            else if (filename == "transfer")
            {
                filename += "_" + filedate + "_" + filehour + ".htm";
            }

            FileInfo fi = new FileInfo(Path.Combine(di.FullName, filename));

            StreamWriter file = new StreamWriter(fi.FullName);
            file.Write(page);
            file.Close();
        }

        private void LoadHTMLfile_newPage(string page)
        {
            LoadHTMLfile_newPage(page, false);
        }

        private void LoadHTMLfile_newPage(string page, bool specifyDate)
        {
            DateTime dt = DateTime.Now;

            if (page.Contains("NewTM - Shortlist"))
            {
                teamDS.LoadShortlistFromHTML_New(page, updateDeletedPlayers, dt);

                isDirty = true;
                return;
            }
            if (page.Contains("TM - Clubhouse"))
            {
                teamDS.LoadClubhouseFromHTML(page, updateDeletedPlayers, dt);

                isDirty = true;
                return;
            }
            if (page.Contains("NewTM - Transfer"))
            {
                teamDS.LoadTransferFromHTML(page, updateDeletedPlayers);

                isDirty = true;
                return;
            }
        }

        private void UpdateTables(DataGridView dgv)
        {
            if (dgv == dgGiocatori)
            {
                tabControl.SelectedTab = tabPlayers;
                EvidenceSkillsGiocatoriForGains();
                EvidenceSkillsGiocatoriForQuality(-1);
            }
            if (dgv == dgPortieri)
            {
                tabControl.SelectedTab = tabGK;
                EvidenceSkillsPortieriForGains();
                EvidenceSkillsPortieriForQuality(-1);
            }
        }

        private void UpdateTables()
        {
            TabPage lastSelectedTab = tabControl.SelectedTab;

            tabControl.SelectedTab = tabPlayers;
            EvidenceSkillsGiocatoriForGains();
            EvidenceSkillsGiocatoriForQuality(-1);

            tabControl.SelectedTab = tabGK;
            EvidenceSkillsPortieriForGains();
            EvidenceSkillsPortieriForQuality(-1);

            tabControl.SelectedTab = lastSelectedTab;
        }

        private void EvidenceSkillsGiocatoriForGains()
        {
            DataGridView dgv = dgGiocatori;

            if (!Program.Setts.EvidenceGain)
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < 14; j++)
                    {
                        dgv[j + 5, i].Style = dgv[j + 6, i].OwningColumn.DefaultCellStyle;
                    }
                }
                return;
            }

            string[] spec = new string[] { "DC", "DR", "DL", "DMC", "DMR", 
                "DML", "MC", "MR", "ML", "OMC", "OMR", "OML", "FC" };
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                System.Windows.Forms.DataGridViewRow dvr = dgv.Rows[i];
                DataRowView dr = (DataRowView)dvr.DataBoundItem;
                TeamDS.GiocatoriNSkillRow gsr = (TeamDS.GiocatoriNSkillRow)dr.Row;

                string FP = gsr.FP;
                string[] FPs = FP.Split('/');

                if (FPs.Length == 1)
                {
                    int n;
                    for (n = 0; n < 13; n++)
                        if (FP == spec[n]) break;

                    // Evidenzia solo le colonne degli skills
                    for (int j = 0; j < 14; j++)
                    {
                        DataGridViewCellStyle Style = new DataGridViewCellStyle();

                        ColorUtilities.SelectGainColor(teamDS.GD.K_FP(j, n), ref Style);

                        dgv[j + 5, i].Style = Style;
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

                    // Evidenzia solo le colonne degli skills
                    for (int j = 0; j < 14; j++)
                    {
                        DataGridViewCellStyle Style = new DataGridViewCellStyle();

                        float maxGain = Math.Max(teamDS.GD.K_FP(j, n1), teamDS.GD.K_FP(j, n2));
                        ColorUtilities.SelectGainColor(maxGain, ref Style);

                        dgv[j + 5, i].Style = Style;
                    }
                }
            }
        }

        /// <summary>
        /// Evidence the skill of all players
        /// </summary>
        /// <param name="plID">-1 to evidence all players, use the PlayerID to renew only the evidencing of 
        /// a player</param>
        private void EvidenceSkillsGiocatoriForQuality(int plID)
        {
            DataGridView dgv = dgGiocatori;

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (plID != -1)
                {
                    System.Windows.Forms.DataGridViewRow dvr = dgv.Rows[i];
                    TeamDS.GiocatoriNSkillRow gsr = (TeamDS.GiocatoriNSkillRow)dvr.DataBoundItem;

                    if (plID != gsr.PlayerID)
                        continue;
                }

                // Evidenzia solo le colonne degli skills
                for (int j = 24; j < 37; j++)
                {
                    float f = (float)dgv[j, i].Value;
                    if (f > 100) f = 100;
                    if (f < 0) f = 0;

                    DataGridViewCellStyle Style = new DataGridViewCellStyle();

                    SelectStyleColor(f, ref Style);
                    Style.BackColor = Color.FromArgb(0, 64, 0);
                    Style.SelectionBackColor = Color.FromArgb(0, 192, 0);
                    Style.Format = "N1";

                    dgv[j, i].Style = Style;
                }

                if (plID != -1)
                    return;
            }
        }

        private void EvidenceSkillsPortieriForQuality(int plID)
        {
            DataGridView dgv = dgPortieri;

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (plID != -1)
                {
                    System.Windows.Forms.DataGridViewRow dvr = dgv.Rows[i];
                    TeamDS.GiocatoriNSkillRow gsr = (TeamDS.GiocatoriNSkillRow)dvr.DataBoundItem;

                    if (plID != gsr.PlayerID)
                        continue;
                }

                // Evidenzia solo le colonne degli skills
                for (int j = 21; j < 22; j++)
                {
                    float f = (float)dgPortieri[j, i].Value;
                    if (f > 100) f = 100;
                    if (f < 0) f = 0;

                    DataGridViewCellStyle Style = new DataGridViewCellStyle();

                    SelectStyleColor(f, ref Style);
                    Style.BackColor = Color.FromArgb(0, 64, 0);
                    Style.SelectionBackColor = Color.FromArgb(0, 192, 0);
                    Style.Format = "N1";

                    dgPortieri[j, i].Style = Style;
                }

                if (plID != -1)
                    return;
            }
        }
        private void EvidenceSkillsPortieriForGains()
        {
            if (!Program.Setts.EvidenceGain)
            {
                for (int i = 0; i < dgPortieri.Rows.Count; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        dgPortieri[j + 5, i].Style = dgPortieri[j + 6, i].OwningColumn.DefaultCellStyle;
                    }
                }
                return;
            }


            for (int i = 0; i < dgPortieri.Rows.Count; i++)
            {
                // Evidenzia solo le colonne degli skills
                for (int j = 0; j < 11; j++)
                {
                    DataGridViewCellStyle Style = new DataGridViewCellStyle();

                    ColorUtilities.SelectGainColor(teamDS.GD.K_GK(j) / 1.5f, ref Style);

                    dgPortieri[j + 5, i].Style = Style;
                }
            }
        }
        private static void SelectStyleColor(float f, ref DataGridViewCellStyle Style)
        {
            switch ((int)(f / 10))
            {
                case 0:
                case 1:
                    Style.SelectionForeColor = Style.ForeColor = Color.RoyalBlue;
                    break;
                case 2:
                    Style.SelectionForeColor = Style.ForeColor = Color.Cyan;
                    break;
                case 3:
                case 4:
                    Style.SelectionForeColor = Style.ForeColor = Color.Lime;
                    break;
                case 5:
                    Style.SelectionForeColor = Style.ForeColor = Color.Yellow;
                    break;
                case 6:
                    Style.SelectionForeColor = Style.ForeColor = Color.Salmon;
                    break;
                case 7:
                case 8:
                    Style.SelectionForeColor = Style.ForeColor = Color.Red;
                    break;
                default:
                    Style.SelectionForeColor = Style.ForeColor = Color.Violet;
                    break;
            }
        }

        private void dgGiocatori_Sorted(object sender, EventArgs e)
        {
            UpdateTables(dgGiocatori);
        }

        string navigationAddress = "";
        string startnavigationAddress = "";

        private void tsbNext_Click(object sender, EventArgs e)
        {
            webBrowser.GoForward();
        }

        private void tsbPrev_Click(object sender, EventArgs e)
        {
            webBrowser.GoBack();
        }

        private void gotoMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            navigationAddress = "http://trophymanager.com/";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
        }

        private void gotoAdobeFlashplayerPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            navigationAddress = "http://www.adobe.com/products/flashplayer/";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
        }

        private void tsbShortlist_Click(object sender, EventArgs e)
        {
            navigationAddress = "http://trophymanager.com/shortlist/#misc";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
        }

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
            long maxProgr = e.MaximumProgress;
            if (maxProgr <= 0) maxProgr = 1;
            int perc = (int)((e.CurrentProgress * 100) / maxProgr);

            if (perc > 100) perc = 100;
            if (perc < 0) perc = 0;
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

                if (startnavigationAddress.Contains("showprofile.php?playerid="))
                {

                    lastBarPlayer = int.Parse(HTML_Parser.GetNumberAfter(startnavigationAddress, "playerid="));

                    TeamDS.GiocatoriNSkillRow gRow = teamDS.GiocatoriNSkill.FindByPlayerID(lastBarPlayer);

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

        private void tsbPrevPlayer_Click(object sender, EventArgs e)
        {
            TeamDS.GiocatoriNSkillRow gRow = teamDS.GiocatoriNSkill.FindByPlayerID(lastBarPlayer);

            int i = 0;
            for (; i < teamDS.GiocatoriNSkill.Count; i++)
                if (gRow == teamDS.GiocatoriNSkill[i]) break;

            i--;
            if (i == -1) i = teamDS.GiocatoriNSkill.Count - 1;

            navigationAddress = "http://trophymanager.com/showprofile.php?playerid=" +
                teamDS.GiocatoriNSkill[i].PlayerID.ToString();
            if (navigationType == NavigationType.NavigateReports)
                navigationAddress += "&scout_mode=1";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
        }

        private void tsbNextPlayer_Click(object sender, EventArgs e)
        {
            TeamDS.GiocatoriNSkillRow gRow = teamDS.GiocatoriNSkill.FindByPlayerID(lastBarPlayer);

            int i = 0;
            for (; i < teamDS.GiocatoriNSkill.Count; i++)
                if (gRow == teamDS.GiocatoriNSkill[i]) break;

            i++;
            if (i == teamDS.GiocatoriNSkill.Count) i = 0;

            navigationAddress = "http://trophymanager.com/showprofile.php?playerid=" +
                teamDS.GiocatoriNSkill[i].PlayerID.ToString();
            if (navigationType == NavigationType.NavigateReports)
                navigationAddress += "&scout_mode=1";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
        }

        private void navigateProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbNavigationType.Text = navigateProfilesToolStripMenuItem.Text;
            tsbNavigationType.Image = navigateProfilesToolStripMenuItem.Image;

            if (navigationType != NavigationType.NavigateProfiles)
            {
                navigationType = NavigationType.NavigateProfiles;
                navigationAddress = "http://trophymanager.com/showprofile.php?playerid=" +
                    lastBarPlayer.ToString();
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
                navigationAddress = "http://trophymanager.com/showprofile.php?playerid=" +
                    lastBarPlayer.ToString() + "&scout_mode=1";
                webBrowser.Navigate(navigationAddress);
                startnavigationAddress = navigationAddress;
            }
        }

        private void ChangePlayer_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsi = (ToolStripMenuItem)sender;
            navigationAddress = "http://trophymanager.com/showprofile.php?playerid=" +
                tsi.Tag.ToString();
            if (navigationType == NavigationType.NavigateReports)
                navigationAddress += "&scout_mode=1";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
        }
        #endregion

        private void ShortlistForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.Setts.AutoSaveAndLoad)
            {
                FileInfo fi = new FileInfo(Path.Combine(Program.Setts.DefaultDirectory, "LastSearchData.xml"));

                if (fi.Exists) fi.Delete();

                teamDS.Save(fi);
            }
            else if (isDirty)
            {
                DialogResult dr = MessageBox.Show("Save the Transfer data list before closing?",
                    "Close Transfer Manager", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    teamDS.Save(Program.Setts.DefaultDirectory, "Transfer.3.xml");
                }
                else if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }

            Program.Setts.Save();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dgv = null;

            if (tabControl.SelectedTab == tabPlayers) dgv = dgGiocatori;
            if (tabControl.SelectedTab == tabGK) dgv = dgPortieri;

            if (dgv.SelectedRows.Count > 0)
            {
                string names = ""; 

                int[] plToRemove = new int[dgv.SelectedRows.Count];
                for (int i = 0; i < dgv.SelectedRows.Count; i++)
                {
                    DataRowView drv = (DataRowView)dgv.SelectedRows[i].DataBoundItem;
                    TeamDS.GiocatoriNSkillRow gnsr = (TeamDS.GiocatoriNSkillRow)drv.Row;
                    names += gnsr.Nome + ",";
                    plToRemove[i] = gnsr.PlayerID;
                }

                names = names.TrimEnd(',');

                DialogResult dr = MessageBox.Show("Delete the selected players (" + names + ")?", "Remove players", 
                    MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;

                foreach (int id in plToRemove)
                {
                    TeamDS.GiocatoriNSkillRow gnsr = teamDS.GiocatoriNSkill.FindByPlayerID(id);
                    teamDS.GiocatoriNSkill.RemoveGiocatoriNSkillRow(gnsr);
                }

                isDirty = true;
            }
        }

        private void dgPortieri_Sorted(object sender, EventArgs e)
        {
            UpdateTables(dgPortieri);
        }

        private void dontUpdateTheDeletedPlayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Setts.RefreshDataOnly = !Program.Setts.RefreshDataOnly;
            dontUpdateTheDeletedPlayersToolStripMenuItem.Checked = Program.Setts.RefreshDataOnly;
        }

        private void openPlayersTeamPageInTrophyBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dgv;

            if (tabControl.SelectedTab == tabPlayers)
                dgv = dgGiocatori;
            else
                dgv = dgPortieri;

            if (dgv.SelectedRows.Count < 1) return;

            DataGridViewRow row = dgv.SelectedRows[0];

            DataRowView drv = (DataRowView)row.DataBoundItem;
            TeamDS.GiocatoriNSkillRow gsr = (TeamDS.GiocatoriNSkillRow)drv.Row;
            int TeamID = gsr.TeamID;

            string navigationAddress = "http://trophymanager.com/club/" + TeamID.ToString() + "/squad/";

            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;

            tabControl.SelectedTab = tabPage1;
        }

        private void addAlarmForThisPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgGiocatori.SelectedRows)
            {
                DataRowView drv = (DataRowView)row.DataBoundItem;
                teamDS.AddEndBidAlarm((TeamDS.GiocatoriNSkillRow)drv.Row);
            }
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            teamDS.CheckPendingAlarms();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm opt = new OptionsForm();

            opt.NormalizeGains = Program.Setts.NormalizeGains;
            opt.GainSetFile = Program.Setts.GainDSfilename;
            opt.AlarmFile = Program.Setts.RingWavefile;
            opt.PlaySound = Program.Setts.PlaySound;
            opt.DefaultNation = Program.Setts.HomeNation;
            opt.AutoLoadAndSave = Program.Setts.AutoSaveAndLoad;
            opt.EvidenceGains = Program.Setts.EvidenceGain;

            if (opt.ShowDialog() == DialogResult.OK)
            {
                if (Program.Setts.GainDSfilename != opt.GainSetFile)
                {
                    if (MessageBox.Show("Changing gainset you'll lose all the changes 'till the last save. Continue?",
                        "Change Gainset", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return;
                    }
                    Program.Setts.GainDSfilename = opt.GainSetFile;
                    teamDS.Clear();
                    LoadData();
                    ShortlistForm_Load(null, EventArgs.Empty);
                }


                if (Program.Setts.NormalizeGains != opt.NormalizeGains)
                {
                    Program.Setts.NormalizeGains = opt.NormalizeGains;
                    teamDS.RecalculateSpecData(teamDS.GD);
                }

                Program.Setts.RingWavefile = opt.AlarmFile;
                Program.Setts.PlaySound = opt.PlaySound;
                Program.Setts.HomeNation = opt.DefaultNation;
                Program.Setts.AutoSaveAndLoad = opt.AutoLoadAndSave;
                Program.Setts.EvidenceGain = opt.EvidenceGains;

                Program.Setts.Save();
            }
        }

        private void saveTLFileAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Transfer list XML file|transfer*.xml|XML file|*.xml|All Files|*.*";

            FileInfo fil = new FileInfo(Program.Setts.LastFileUsed);

            if (fil.Exists)
            {
                sfd.InitialDirectory = fil.Directory.FullName;
                sfd.FileName = fil.Name;
            }

            if (sfd.FileName == "")
            {
                sfd.InitialDirectory = Program.Setts.DefaultDirectory;
                sfd.FileName = "*.xml";
            }

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(sfd.FileName);
                teamDS.Save(fi);

                Program.Setts.LastFileUsed = sfd.FileName;
                Program.Setts.Save();
            }
        }

        private void loadAnotherTransferListFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Transfer list XML file|transfer*.xml|XML file|*.xml|All Files|*.*";

            FileInfo fil = new FileInfo(Program.Setts.LastFileUsed);

            if (fil.Exists)
            {
                ofd.InitialDirectory = fil.Directory.FullName;
                ofd.FileName = fil.Name;
            }

            if (ofd.FileName == "")
            {
                ofd.FileName = Program.Setts.DefaultDirectory;
            }

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (teamDS.GiocatoriNSkill.Count > 0)
                {
                    if (MessageBox.Show("Delete previous list?", "Load List",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        teamDS.Clear();
                    }
                }

                FileInfo fi = new FileInfo(ofd.FileName);

                teamDS.Load(fi);

                EvidenceSkillsGiocatoriForQuality(-1);
                EvidenceSkillsGiocatoriForGains();
                EvidenceSkillsPortieriForQuality(-1);
                EvidenceSkillsPortieriForGains();

                Program.Setts.LastFileUsed = ofd.FileName;
                Program.Setts.Save();
            }
        }

        private void dgGiocatori_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void clearListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            teamDS.AlarmList.Clear();
            teamDS.GiocatoriNSkill.Clear();
            teamDS.Squad.Clear();
            teamDS.Clear();
        }

        private void copyListInExcelFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int nRows = teamDS.GiocatoriNSkill.Rows.Count;
            string data = "";

            foreach (TeamDS.GiocatoriNSkillRow gsr in teamDS.GiocatoriNSkill)
            {
                object[] objs = gsr.ItemArray;

                for (int i = 0; i < objs.Length; i++)
                {
                    string val = objs[i].ToString();
                    data += val + "\t";
                }

                data += "\r\n";
            }

            Clipboard.SetText(data);
        }

        private void setWeightFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Changing gainset you'll lose all the changes 'till the last save. Continue?",
                        "Change Gainset", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            LoadGains(Program.Setts.GainDSfilename, true);
            teamDS.Clear();
            LoadData();
            ShortlistForm_Load(null, EventArgs.Empty);
        }

        internal bool LoadGains(string gainSetName, bool forceGainReq)
        {
            FileInfo fi = new FileInfo(gainSetName);

            if ((fi.Exists) && (!forceGainReq))
            {
                teamDS.GD.Clear();
                teamDS.GD.ReadXml(gainSetName);
                teamDS.GD.GainDSfilename = gainSetName;
                return true;
            }
            else
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.FileName = teamDS.GD.GainDSfilename;
                ofd.Filter = "TMGain Files|*.tmgain;*.tmgain.xml|All Files|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    teamDS.GD.GainDSfilename = ofd.FileName;
                    Program.Setts.GainDSfilename = ofd.FileName;
                    return LoadGains(teamDS.GD.GainDSfilename, false);
                }
                else
                {
                    return false;
                }
            }
        }

        private void aSIToTICalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string processName = Application.StartupPath + "/ASI2TI.exe";

            FileInfo fi = new FileInfo(processName);

            if (!fi.Exists)
                MessageBox.Show("The ASI to TI application (ASI2TI.exe) doesn't exist at the given path (" +
                    Application.StartupPath + ")", "Transfer Manager", MessageBoxButtons.OK);
            else
                Process.Start(processName);
        }

        private void importFromTheImportedPagesDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(Path.Combine(Program.Setts.DefaultDirectory, "ImportedPages"));

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = di.FullName;

            ofd.Filter = "Imported pages file|transfer_*.htm|HTM file|*.htm|All Files|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                string page = sr.ReadToEnd();
                sr.Close();

                teamDS.LoadTransferFromHTML(page, updateDeletedPlayers);

                MessageBox.Show("Import of the file " + ofd.FileName + " complete");
            }
        }

        private void evidenceGainsOnThePlayerTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Setts.EvidenceGain = !Program.Setts.EvidenceGain;
            EvidenceSkillsGiocatoriForGains();
            EvidenceSkillsPortieriForGains();
            evidenceGainsOnThePlayerTableToolStripMenuItem.Checked = Program.Setts.EvidenceGain;
        }

        private void tsbTransfer_Click(object sender, EventArgs e)
        {
            navigationAddress = "http://trophymanager.com/transfer/";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
        }
    }
}
