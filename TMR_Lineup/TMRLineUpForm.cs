using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TMR_Lineup;
using Common;
using System.IO;
using System.Diagnostics;

namespace FieldFormationControl
{
    public partial class TestForm : Form
    {
        FieldPlayer lastSelectedfp = null;
        bool dirty = false;
        bool browsingTeam = false;

        public TestForm()
        {
            InitializeComponent();

            FileInfo fi = new FileInfo("MatchList.xml");
            if (fi.Exists)
                matchListDS.ReadXml(fi.FullName);

            Program.Setts.Initialize();

            SetComboSources();
        }

        private void SetComboSources()
        {
            cmbTeam1.ComboBox.DataSource = bindTeam1;
            cmbTeam1.ComboBox.DisplayMember = "Name";
            if (cmbTeam1.ComboBox.Items.Count > 0)
                cmbTeam1.ComboBox.SelectedIndex = 0;

            cmbTeam2.ComboBox.DataSource = bindTeam2;
            cmbTeam2.ComboBox.DisplayMember = "Name";
            if (cmbTeam2.ComboBox.Items.Count > 1)
                cmbTeam2.ComboBox.SelectedIndex = 1;

            cmbMatch1.ComboBox.DataSource = bindLeftMatch;
            cmbMatch1.ComboBox.DisplayMember = "Description";
            if (cmbMatch1.ComboBox.Items.Count > 0)
                cmbMatch1.ComboBox.SelectedIndex = 0;

            cmbMatch2.ComboBox.DataSource = bindRightMatch;
            cmbMatch2.ComboBox.DisplayMember = "Description";
            if (cmbMatch2.ComboBox.Items.Count > 0)
                cmbMatch2.ComboBox.SelectedIndex = 0;
        }

        private void selectYourFormationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormationSelector fs = new FormationSelector();
            fs.Text = "Select Your Formation";
            fs.ShowDialog();

            formationControl.YourFormationType = fs.SelectedFormation.Type;
            formationControl.Y_SetPlayersMenu(playerY_ContextMenu);
        }

        private void selectOppositeFormationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormationSelector fs = new FormationSelector();
            fs.Text = "Select Opposite Formation";
            fs.ShowDialog();

            formationControl.OppFormationType = fs.SelectedFormation.Type;
            formationControl.O_SetPlayersMenu(playerO_ContextMenu);
        }

        private void pasteHTMLData_Click(object sender, EventArgs e)
        {
            string html = "";
            if (Clipboard.ContainsData(System.Windows.Forms.DataFormats.Html))
            {
                object str = Clipboard.GetData(DataFormats.Html);
                html = (string)str;

                if (html.Contains("SourceURL:http://trophymanager.com/kamp.php"))
                    html = html.Replace("SourceURL:http://trophymanager.com/kamp.php", "SourceURL:<title>TM - Kamp</title>");
                else if (html.Contains("SourceURL:http://trophymanager.com/assistant_manager.php"))
                    html = html.Replace("SourceURL:http://trophymanager.com/assistant_manager.php", "SourceURL:<title>TM - Assistant_manager</title>");
                else
                    html = "";
            }
            else 
                html = Clipboard.GetText();

            if (html.IndexOf("<title>TM - Kamp</title>", StringComparison.InvariantCultureIgnoreCase) != -1)
            {
                html = HTML_Parser.ConvertHTML(html);
                pasteMatchEvaluation(html);
                dirty = true;
            }
            else if (html.IndexOf("<title>TM - Assistant_manager</title>", StringComparison.InvariantCultureIgnoreCase) != -1)
            {
                html = HTML_Parser.ConvertHTML(html);
                pasteAssistantEvaluation(html);
                dirty = true;
            }
        }

        private void pasteAssistantEvaluation(string html)
        {
            matchListDS.ParseAnalysis(html);

            Y_FillFormationControl();
            O_FillFormationControl();
        }

        private void pasteMatchEvaluation(string html)
        {
            MatchList.MatchesListRow mlr = matchListDS.MatchesList.NewMatchesListRow();
            if (!matchListDS.ParseMatch(html, ref mlr)) return;

            if (matchListDS.MatchesList.Count == 1)
            {
                cmbTeam1.SelectedIndex = 0;
                cmbTeam2.SelectedIndex = 1;
            }

            Y_FillFormationControl();

            O_FillFormationControl();
        }

        private void Y_FillFormationControl()
        {
            if (cmbTeam1.SelectedItem == null) return;
            if (cmbMatch1.SelectedItem == null) return;
            DataRowView drvt1 = (DataRowView)cmbTeam1.SelectedItem;
            DataRowView drvm1 = (DataRowView)cmbMatch1.SelectedItem;
            MatchList.TeamListRow tlr1 = (MatchList.TeamListRow)drvt1.Row;
            MatchList.MatchesListRow mlr1 = (MatchList.MatchesListRow)drvm1.Row;

            //-----------------------------------------------------------------------
            // Your formation
            //-----------------------------------------------------------------------
            Formation yf = new Formation(eFormationTypes.Type_Empty);

            if (!tlr1.Is_1stColorNull())
                yf.TeamColor = Color.FromArgb(tlr1._1stColor);
            else if (!tlr1.Is_2ndColorNull())
                yf.TeamColor = Color.FromArgb(tlr1._2ndColor);
            else
                yf.TeamColor = Color.DarkRed;

            string filter1 = "(MatchFkID = " + mlr1.MatchFkID.ToString() + " AND TeamID = " +
                tlr1.TeamID.ToString() + ")";

            DataRow[] drs1 = matchListDS.TeamPerf.Select(filter1);

            foreach (DataRow dr in drs1)
            {
                MatchList.TeamPerfRow tpr = (MatchList.TeamPerfRow)dr;
                MatchList.PlayersListRow plr = matchListDS.PlayersList.FindByTeamIDPlayerID(tlr1.TeamID, tpr.PlayerID);
                Player pl = yf.SetPlayer(tpr, plr);
            }

            string filter1b = "(TeamID = " + tlr1.TeamID.ToString() + ")";
            DataRow[] drs1b = matchListDS.PlayersList.Select(filter1b);

            ToolStripMenuItem mi = (ToolStripMenuItem)playerY_ContextMenu.Items[0];
            mi.DropDownItems.Clear();
            mi.DropDownOpening += new EventHandler(mi_DropDownOpening);

            string poslist = "GK,DC,DL,DR,DMC,DML,DMR,MC,ML,MR,OMC,OML,OMR,FC,OTHERS";
            string[] posm = poslist.Split(',');
            ToolStripMenuItem miOthers = null;
            foreach (string pos in posm)
            {
                miOthers = new ToolStripMenuItem(pos);
                mi.DropDownItems.Add(miOthers);
            }

            foreach (DataRow dr in drs1b)
            {
                MatchList.PlayersListRow plr = (MatchList.PlayersListRow)dr;

                if (plr.IsUsedPosNull())
                {
                    ToolStripItem tsi = new ToolStripMenuItem(plr.Name + " " + plr.GetSkillString());
                    tsi.Click += new System.EventHandler(changeY_PlayerToolStripMenuItem_Click);
                    tsi.Tag = plr;
                    miOthers.DropDownItems.Add(tsi);
                }
                else
                {
                    string[] rules = plr.UsedPos.Split('/');
                    string usedrules = "";

                    foreach (string rule0 in rules)
                    {
                        string rule = rule0;

                        if (usedrules.Contains(rule + "/")) continue;

                        usedrules += rule + "/";

                        if ((rule == "dcl") || (rule == "dcr")) rule = "dc";
                        if ((rule == "dmcl") || (rule == "dmcr")) rule = "dmc";
                        if ((rule == "mcl") || (rule == "mcr")) rule = "mc";
                        if ((rule == "omcl") || (rule == "omcr")) rule = "omc";
                        if ((rule == "fcl") || (rule == "fcr")) rule = "fc";
                        if (rule.Contains("sub")) rule = "OTHERS";

                        ToolStripItem mis = null;
                        foreach (ToolStripMenuItem mi0 in mi.DropDownItems)
                        {
                            if (mi0.Text == rule.ToUpper())
                            {
                                mis = mi0;
                                break;
                            }
                        }

                        ToolStripMenuItem miNew = null;
                        if (mis == null)
                        {
                            miNew = new ToolStripMenuItem(rule.ToUpper());
                            mi.DropDownItems.Add(miNew);
                        }
                        else
                            miNew = (ToolStripMenuItem)mis;

                        ToolStripMenuItem tsmi = new ToolStripMenuItem(plr.Name + " " + plr.GetSkillString());
                        tsmi.Click += new EventHandler(changeY_PlayerToolStripMenuItem_Click);
                        tsmi.Tag = plr;
                        miNew.DropDownItems.Add(tsmi);
                    }

                    plr.UsedPos = usedrules.TrimEnd('/');
                }
            }

            formationControl.Y_ShowFormationPlayers(yf);
            formationControl.Y_SetPlayersMenu(playerY_ContextMenu);
        }

        void mi_DropDownOpening(object sender, EventArgs e)
        {
            ToolStripDropDownItem ddi = (ToolStripDropDownItem)sender;
            ContextMenuStrip cms = (ContextMenuStrip)ddi.Owner;

            lastSelectedfp = (FieldPlayer)cms.SourceControl;
        }

        private void O_FillFormationControl()
        {
            if (cmbTeam2.SelectedItem == null) return;
            if (cmbMatch2.SelectedItem == null) return;
            DataRowView drvt2 = (DataRowView)cmbTeam2.SelectedItem;
            DataRowView drvm2 = (DataRowView)cmbMatch2.SelectedItem;
            MatchList.TeamListRow tlr2 = (MatchList.TeamListRow)drvt2.Row;
            MatchList.MatchesListRow mlr2 = (MatchList.MatchesListRow)drvm2.Row;

            //-----------------------------------------------------------------------
            // Opposite formation
            //-----------------------------------------------------------------------
            Formation of = new Formation(eFormationTypes.Type_Empty);

            if (!tlr2.Is_1stColorNull())
                of.TeamColor = Color.FromArgb(tlr2._1stColor);
            else if (!tlr2.Is_2ndColorNull())
                of.TeamColor = Color.FromArgb(tlr2._2ndColor);
            else
                of.TeamColor = Color.Yellow;

            string filter2 = "(MatchFkID = " + mlr2.MatchFkID.ToString() + " AND TeamID = " +
                tlr2.TeamID.ToString() + ")";
            DataRow[] drs2 = matchListDS.TeamPerf.Select(filter2);

            foreach (DataRow dr in drs2)
            {
                MatchList.TeamPerfRow tpr = (MatchList.TeamPerfRow)dr;
                MatchList.PlayersListRow plr = matchListDS.PlayersList.FindByTeamIDPlayerID(tlr2.TeamID, tpr.PlayerID);
                Player pl = of.SetPlayer(tpr, plr);
            }

            string filter2b = "(TeamID = " + tlr2.TeamID.ToString() + ")";
            DataRow[] drs2b = matchListDS.PlayersList.Select(filter2b);

            ToolStripMenuItem mi = (ToolStripMenuItem)playerO_ContextMenu.Items[0];
            mi.DropDownItems.Clear();
            mi.DropDownOpening += new EventHandler(mi_DropDownOpening);

            string poslist = "GK,DC,DL,DR,DMC,DML,DMR,MC,ML,MR,OMC,OML,OMR,FC,OTHERS";
            string[] posm = poslist.Split(',');
            ToolStripMenuItem miOthers = null;
            foreach (string pos in posm)
            {
                miOthers = new ToolStripMenuItem(pos);
                mi.DropDownItems.Add(miOthers);
            }

            foreach (DataRow dr in drs2b)
            {
                MatchList.PlayersListRow plr = (MatchList.PlayersListRow)dr;

                if (plr.IsUsedPosNull())
                {
                    ToolStripItem tsi = new ToolStripMenuItem(plr.Name + " " + plr.GetSkillString());
                    tsi.Click += new System.EventHandler(changeO_PlayerToolStripMenuItem_Click);
                    tsi.Tag = plr;
                    miOthers.DropDownItems.Add(tsi);
                }
                else
                {
                    string[] rules = plr.UsedPos.Split('/');
                    string usedrules = "";

                    foreach (string rule0 in rules)
                    {
                        string rule = rule0;

                        if (usedrules.Contains(rule + "/")) continue;

                        usedrules += rule + "/";
                        
                        if ((rule == "dcl") || (rule == "dcr")) rule = "dc";
                        if ((rule == "dmcl") || (rule == "dmcr")) rule = "dmc";
                        if ((rule == "mcl") || (rule == "mcr")) rule = "mc";
                        if ((rule == "omcl") || (rule == "omcr")) rule = "omc";
                        if ((rule == "fcl") || (rule == "fcr")) rule = "fc";
                        if (rule.Contains("sub")) rule = "OTHERS";

                        ToolStripItem mis = null;
                        foreach (ToolStripMenuItem mi0 in mi.DropDownItems)
                        {
                            if (mi0.Text == rule.ToUpper())
                            {
                                mis = mi0;
                                break;
                            }
                        }

                        ToolStripMenuItem miNew = null;
                        if (mis == null)
                        {
                            miNew = new ToolStripMenuItem(rule.ToUpper());
                            mi.DropDownItems.Add(miNew);
                        }
                        else
                        {
                            miNew = (ToolStripMenuItem)mis;
                        }

                        ToolStripMenuItem tsmi = new ToolStripMenuItem(plr.Name + " " + plr.GetSkillString());
                        tsmi.Click += new EventHandler(changeO_PlayerToolStripMenuItem_Click);
                        tsmi.Tag = plr;
                        miNew.DropDownItems.Add(tsmi);
                    }

                    plr.UsedPos = usedrules.TrimEnd('/');
                }
            }

            formationControl.O_ShowFormationPlayers(of);
            formationControl.O_SetPlayersMenu(playerO_ContextMenu);
        }

        private void cmbTeam1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTeam1.SelectedItem == null) return;
            DataRowView drv = (DataRowView)cmbTeam1.SelectedItem;
            MatchList.TeamListRow tlr = (MatchList.TeamListRow)drv.Row;
            string filter = "(HomeID = " + tlr.TeamID + ") OR (AwayID = " + tlr.TeamID + ")";
            bindLeftMatch.Filter = filter;

            Y_FillFormationControl();
        }

        private void cmbTeam2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTeam2.SelectedItem == null) return;
            DataRowView drv = (DataRowView)cmbTeam2.SelectedItem;
            MatchList.TeamListRow tlr = (MatchList.TeamListRow)drv.Row;
            string filter = "(HomeID = " + tlr.TeamID + ") OR (AwayID = " + tlr.TeamID + ")";
            bindRightMatch.Filter = filter;

            O_FillFormationControl();
        }

        private void cmbMatch1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Y_FillFormationControl();
        }

        private void cmbMatch2_SelectedIndexChanged(object sender, EventArgs e)
        {
            O_FillFormationControl();
        }

        private void saveDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            matchListDS.WriteXml("MatchList.xml");
            dirty = false;
        }

        private void loadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            matchListDS.Clear();

            FileInfo fi = new FileInfo("MatchList.xml");
            if (fi.Exists)
                matchListDS.ReadXml(fi.FullName);
            else
            {
                MessageBox.Show("Sorry, no match list to load");
                return;
            }

            SetComboSources();
            dirty = false;
        }

        private void clearDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("All the data of the matches will be removed. Continue?", "TMR Lineup", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            matchListDS.Clear();

            SetComboSources();

            dirty = false;
        }

        public void changeY_PlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;

            MatchList.PlayersListRow plr = (MatchList.PlayersListRow)mi.Tag;

            if (lastSelectedfp == null) return;

            Formation f = formationControl.lastY_Formation;
            Player pl = f.SetPlayer((int)lastSelectedfp.PlayerID, plr);

            lastSelectedfp.Data = pl;
        }

        public void changeO_PlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;

            MatchList.PlayersListRow plr = (MatchList.PlayersListRow)mi.Tag;

            if (lastSelectedfp == null) return;

            Formation f = formationControl.lastO_Formation;
            Player pl = f.SetPlayer((int)lastSelectedfp.PlayerID, plr);

            lastSelectedfp.Data = pl;
        }

        private void btnAnalyzerLeft_Click(object sender, EventArgs e)
        {
            if (cmbTeam1.SelectedItem == null)
            {
                MessageBox.Show("You must select a left team squad, first");
                return;
            }

            DataRowView drv = (DataRowView)cmbTeam1.SelectedItem;
            MatchList.TeamListRow tlr = (MatchList.TeamListRow)drv.Row;

            isBrowsingTeam = true;

            string filter = "(TeamID = " + tlr.TeamID.ToString() + ")";

            DataRow[] drs = matchListDS.PlayersList.Select(filter);
            MatchList.PlayersListRow plr = (MatchList.PlayersListRow)drs[0];

            navigationAddress = "http://trophymanager.com/showprofile.php?playerid=" + plr.PlayerID;
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;

            System.Diagnostics.Process.Start("http://trophymanager.com/assistant_manager.php?analysis=squad&showclub=" + tlr.TeamID.ToString());
        }

        private void btnAnalyzerRight_Click(object sender, EventArgs e)
        {
            if (cmbTeam2.SelectedItem == null)
            {
                MessageBox.Show("You must select a right team squad, first");
                return;
            }

            DataRowView drv = (DataRowView)cmbTeam2.SelectedItem;
            MatchList.TeamListRow tlr = (MatchList.TeamListRow)drv.Row;

            System.Diagnostics.Process.Start("http://trophymanager.com/assistant_manager.php?analysis=squad&showclub=" + tlr.TeamID.ToString());
        }

        private void showPlayersMeanVoteToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem ddi = (ToolStripMenuItem)sender;
            formationControl.lastY_Formation.ShowValue = ddi.Checked;
            formationControl.lastO_Formation.ShowValue = ddi.Checked;

            formationControl.Y_ShowFormationPlayers(formationControl.lastY_Formation);
            formationControl.O_ShowFormationPlayers(formationControl.lastO_Formation);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.dirty)
            {
                DialogResult res = MessageBox.Show("There are some info that have been added and are not saved. Save before closing?",
                    "TMR LineUp Closing", MessageBoxButtons.YesNoCancel);

                if (res == DialogResult.Yes)
                {
                    saveDataToolStripMenuItem_Click(this, EventArgs.Empty);
                    return;
                }
                if (res == DialogResult.No)
                {
                    return;
                }
                if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void TestForm_Load(object sender, EventArgs e)
        {

        }

        private void gotoPlayerPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem ddi = (ToolStripDropDownItem)sender;
            ContextMenuStrip cms = (ContextMenuStrip)ddi.Owner;

            lastSelectedfp = (FieldPlayer)cms.SourceControl;

            string str = "http://trophymanager.com/showprofile.php?playerid=" + lastSelectedfp.PlayerID.ToString();
            ProcessStartInfo startInfo = new ProcessStartInfo(str);

            Process.Start(startInfo);
        }

        #region WebBrowser Navigation
        string navigationAddress = "";
        string startnavigationAddress = "";

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
            if ((e.Url.ToString().StartsWith("http://trophymanager.com/livematch.php?matchid=")) ||
                (e.Url.ToString().StartsWith("http://trophymanager.com/live_prematch.php?matchid=")))
            {
                string kampid = e.Url.ToString().Split('=')[1];
                navigationAddress = "http://trophymanager.com/kamp.php?kampid=" + kampid + ",0,0&show=report";
                webBrowser.Navigate(navigationAddress);
                startnavigationAddress = navigationAddress;
            }
            else
            {
                navigationAddress = e.Url.ToString();
            }

            tsbProgressBar.Value = 0;
            tsbProgressText.Text = "0%";
            tsbProgressBar.ForeColor = Color.Blue;
        }
        #endregion

        private void tsbLoadPlayerPage_Click(object sender, EventArgs e)
        {
            navigationAddress = "http://trophymanager.com";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
        }

        private void tsbImport_Click(object sender, EventArgs e)
        {
            string doctext = "";

            if (startnavigationAddress == "") return;

            HtmlElementCollection hmtlElColl = webBrowser.Document.All;

            try
            {
                if (startnavigationAddress.Contains("kamp.php"))
                {
                    doctext = webBrowser.Document.Body.InnerHtml;
                }
                else
                {
                    doctext = webBrowser.DocumentText;
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

            if (startnavigationAddress.Contains("kamp.php"))
                page = "SourceURL:<Kamp>\n" + page;
            else
            {
                MessageBox.Show("Cannot import this page here. Here you can import only match pages.",
                    "Import error", MessageBoxButtons.OK);
                return;
            }

            if (!page.Contains("<Kamp>"))
            {
                return;
            }


            MatchList.MatchesListRow matchRow = matchListDS.MatchesList.NewMatchesListRow();
            if (matchListDS.ParseMatch(page, ref matchRow))
                matchListDS.MatchesList.AddMatchesListRow(matchRow);
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

        private void tsbNext_Click(object sender, EventArgs e)
        {
            webBrowser.GoForward();
        }

        private void tsbPrev_Click(object sender, EventArgs e)
        {
            webBrowser.GoBack();
        }
    }
}