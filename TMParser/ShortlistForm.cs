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
using Languages;
using mshtml;

namespace TMRecorder
{
    public partial class ShortlistForm : Form
    {
        bool isDirty = false;
        TeamDS History_TeamDS = null;
        bool updateDeletedPlayers = true;

        public ShortlistForm(ref TeamDS teamDS_in)
        {
            InitializeComponent();

            History_TeamDS = teamDS_in;

            teamDS.CopyFrom(History_TeamDS);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            teamDS.CopyTo(History_TeamDS);
            History_TeamDS.Save(Program.Setts.DefaultDirectory, "Shortlist.3.xml");
        }

        private void ShortlistForm_Load(object sender, EventArgs e)
        {
            LoadGains();

            UpdateTables();

            bool showCstr = CheckLicense("LoadData", false);
            dgGiocatori.Columns["CStr"].Visible = showCstr;
            dgPortieri.Columns["CStrGK"].Visible = showCstr;

            tsBrowsePlayers.Visible = false;
        }

        private bool CheckLicense(string p, bool ask)
        {
            bool licenseChecked = true;

            double hashstr = (double)Program.Setts.MainSquadID.ToString().GetHashCode();

            UInt64 checkCode = (UInt64)(hashstr / (Int64)(DateTime.Now.Year / 2) * Math.E * 1000);
            licenseChecked = (Program.Setts.LicenseCode == checkCode);

            return licenseChecked;
        }

        private void LoadGains()
        {
            if (teamDS.LoadGains(Program.Setts.GainSet))
            {
                Program.Setts.GainSet = teamDS.GD.GainDSfilename;
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

            tabControl.SelectedTab = tabBrowser;
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

            tabControl.SelectedTab = tabBrowser;
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

        string doctext = "";
        private void tsbImport_Click(object sender, EventArgs e)
        {
            if (startnavigationAddress == "") return;

            if (startnavigationAddress.StartsWith("http://trophymanager.com/banners"))
            {
                return;
            }

            try
            {
                doctext = GetWebBrowserContent(startnavigationAddress);
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

            if (startnavigationAddress.Contains("/shortlist/"))
                page = "SourceURL:<NewTM - Shortlist>\n" + page;
            else if (startnavigationAddress.Contains("klubhus_squad.php"))
                page = "SourceURL:<NewTM - Clubhouse>\n" + page;
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

            if ((!page.Contains("NewTM - Shortlist"))&&
                (!page.Contains("NewTM - Clubhouse")))
            {
                return;
            }

            LoadHTMLfile_newPage(page);

            UpdateTables();
        }

        private string GetWebBrowserContent(string startnavigationAddress)
        {
            string doctext = "";

            if (startnavigationAddress.Contains("/shortlist/"))
            {
                doctext = Import_Shortlist_Adv();
                if ((doctext == "") || (doctext == null))
                {
                    if (doctext == null)
                        doctext = "GBC error: failed importing players  (text is null)";
                    else
                        doctext = "GBC error: failed importing players  (text is empty)";

                    FileInfo fi = new FileInfo(Program.Setts.DatafilePath + "\\shortlist_loader.js");
                    if (!fi.Exists)
                    {
                        doctext += "\nThe js does not exists in " + Program.Setts.DatafilePath;
                    }
                    else
                    {
                        doctext += "\nJs content (in " + Program.Setts.DatafilePath + "): \n";
                        doctext += System.IO.File.ReadAllText(Program.Setts.DatafilePath + "\\shortlist_loader.js");
                    }
                    doctext += "\n";
                }
            }
            else
            {
                doctext = "Doc Text: \n" + webBrowser.DocumentText;
            }

            return doctext;
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

            if (filename == "shortlist")
            {
                filename += "_" + filedate + ".htm";
            }
            else if (filename == "klubhus_squad")
            {
                filename += "_" + filedate + ".htm";
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

            if (specifyDate)
            {
                if (MessageBox.Show(Current.Language.IsThisFileRelativeToToday, Current.Language.LoadHTMData,
                                    MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    // Select the week number using the form
                    SelectDataDate sdd = new SelectDataDate();
                    if (sdd.ShowDialog() == DialogResult.OK)
                    {
                        dt = sdd.SelectedDate;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            if (page.Contains("NewTM - Shortlist"))
            {
                teamDS.LoadShortlistFromHTML_New(page, updateDeletedPlayers, dt);

                isDirty = true;
                return;
            }
            else if (page.Contains("TM - Shortlist"))
            {
                if (page.Contains("var players_ar"))
                    teamDS.LoadNewShortlistFromHTML(page, updateDeletedPlayers, dt);
                else
                    teamDS.LoadShortlistFromHTML(page, updateDeletedPlayers, dt);

                isDirty = true;
                return;
            }
            else if (page.Contains("TM - Clubhouse"))
            {
                teamDS.LoadClubhouseFromHTML(page, updateDeletedPlayers, dt);

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
            string address = e.Url.ToString();

            if (address.Contains("banners")) return;

            if (address.StartsWith("http://trophymanager.com/livematch.php?matchid="))
            {
                string kampid = address.Split('=')[1];
                navigationAddress = "http://trophymanager.com/matches/" + kampid + "/";
                webBrowser.Navigate(navigationAddress);
                startnavigationAddress = navigationAddress;
            }
            else if (address.StartsWith("http://trophymanager.com/"))
            {
                navigationAddress = address;
                startnavigationAddress = navigationAddress;

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
                navigationAddress = address;
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
            if (isDirty)
            {
                DialogResult dr = MessageBox.Show("Save the shortlist data before closing?", 
                    "Close Shortlist form", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    teamDS.CopyTo(History_TeamDS);
                    History_TeamDS.Save(Program.Setts.DefaultDirectory, "Shortlist.3.xml");
                }
            }
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
            updateDeletedPlayers = !updateDeletedPlayers;
            dontUpdateTheDeletedPlayersToolStripMenuItem.Checked = !updateDeletedPlayers;
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

            tabControl.SelectedTab = tabBrowser;
        }

        private void loadFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check the existence of the folder
            DirectoryInfo di = new DirectoryInfo(Path.Combine(Program.Setts.DefaultDirectory, "ImportedPages"));

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = di.FullName;
            openFileDialog.FileName = "shortlist_*.htm";
            openFileDialog.Filter = "HTML file (*.htm;*.html)|*.htm;*.html|All Files (*.*)|*.*";

            DateTime dt = DateTime.Today;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader file = new StreamReader(openFileDialog.FileName);
                string page = file.ReadToEnd();
                file.Close();

                page = "SourceURL:<TM - Shortlist>\n" + page;
                LoadHTMLfile_newPage(page, true);

                UpdateTables();
            }

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }
    }
}
