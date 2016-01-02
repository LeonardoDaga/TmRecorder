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
using NTR_Db;

namespace TMRecorder
{
    public partial class ShortlistForm : Form
    {
        bool isDirty = false;
        TeamDS History_TeamDS = null;
        bool updateDeletedPlayers = true;
        private Seasons AllSeasons;
        private TeamHistory History;

        public ShortlistForm(Seasons allSeasons, TeamHistory history)
        {
            AllSeasons = allSeasons;
            History = history;

            InitializeComponent();

            updateOnlyListedPlayersToolStripMenuItem.Checked = Program.Setts.ShortlistUploadOnlyListedPlayers;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            teamDS.CopyTo(History_TeamDS);
            AllSeasons.SaveShortlist(Program.Setts.DefaultDirectory, "Shortlist.5.xml");
        }

        private void ShortlistForm_Load(object sender, EventArgs e)
        {
            AllSeasons.LoadShortlist(Program.Setts.DefaultDirectory, "Shortlist.5.xml");
            LoadGains();
            UpdateTables();
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

            webBrowser.Goto(navigationAddress);
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

            webBrowser.Goto(navigationAddress);
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

            PlayerFormSL pf = new PlayerFormSL(History.actualDts.GiocatoriNSkill, History, gsr.PlayerID, AllSeasons);
            pf.ShowDialog();

            if (pf.isDirty) isDirty = true;
        }

        private void dgGiocatori_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            openPlayersPropertyPageToolStripMenuItem_Click(sender, EventArgs.Empty);
        }

        string doctext = "";
        private void webBrowser_ImportedContent(string content, string address)
        {
            if (address.Contains("/shortlist/"))
                content = "NewTM - Shortlist;\n" + content;
            else if (address.Contains("/transfer/"))
                content = "NewTM - Transfer;\n" + content;

            LoadHTMLfile_newPage(content);

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

                AllSeasons.LoadShortlist(page);

                isDirty = true;
                return;
            }
            else if (page.Contains("NewTM - Transfer"))
            {
                teamDS.LoadTransferlistFromHTML_New(page, updateDeletedPlayers, dt);

                AllSeasons.LoadTransferList(page);

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

        private void gotoMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            navigationAddress = "http://trophymanager.com/";
            webBrowser.Goto(navigationAddress);
            startnavigationAddress = navigationAddress;
        }

        private void gotoAdobeFlashplayerPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            navigationAddress = "http://www.adobe.com/products/flashplayer/";
            webBrowser.Goto(navigationAddress);
            startnavigationAddress = navigationAddress;
        }

        private void tsbShortlist_Click(object sender, EventArgs e)
        {
            navigationAddress = "http://trophymanager.com/shortlist/#misc";
            webBrowser.Goto(navigationAddress);
            startnavigationAddress = navigationAddress;
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

            webBrowser.Goto(navigationAddress);
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

        private void updateOnlyListedPlayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateDeletedPlayers = !updateOnlyListedPlayersToolStripMenuItem.Checked;
        }
    }
}
