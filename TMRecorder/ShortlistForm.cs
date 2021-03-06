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
using NTR_Db;
using DataGridViewCustomColumns;
using NTR_Controls;
using System.Linq;

namespace TMRecorder
{
    public partial class ShortlistForm : Form
    {
        bool isDirty = false;
        private NTR_SquadDb DB;
        List<NTR_Db.PlayerData> plShortlist;
        List<NTR_Db.PlayerData> gkShortlist;
        RatingFunction RF;

        bool uploadOnlyListedPlayers
        {
            get { return updateOnlyListedPlayersToolStripMenuItem.Checked; }
        }

        public ShortlistForm(ReportParser reportParser, 
            RatingFunction rf)
        {
            InitializeComponent();

            RF = rf;

            this.reportParser = reportParser;

            updateOnlyListedPlayersToolStripMenuItem.Checked = Program.Setts.ShortlistUploadOnlyListedPlayers;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(Path.Combine(Program.Setts.DefaultDirectory, "Shortlist.5.xml"));

            DB.WriteXml(fi.FullName);
        }

        private async void ShortlistForm_Load(object sender, EventArgs e)
        {
            Rectangle pos = Program.Setts.ShortlistFormPosition;
            if (pos.Height + pos.Width > 0)
                this.SetDesktopBounds(pos.X, pos.Y, pos.Width, pos.Height);

            DB = new NTR_SquadDb();

            LoadShortlist();

            LoadSearchMenuItems();

            FormatPlayersGridPl();
            FormatPlayersGridGK();

            UpdateShortlist();

            dgPlayers.ColumnHeaderMouseClick += dgPlayers_ColumnHeaderMouseClick;
            dgPlayersGK.ColumnHeaderMouseClick += dgPlayersGK_ColumnHeaderMouseClick;

            webBrowser.Goto(TM_Pages.Shortlist);
        }

        private void LoadShortlist()
        {
            DB.Clear();

            FileInfo fi = new FileInfo(Path.Combine(Program.Setts.DefaultDirectory, "Shortlist.5.xml"));
            if (fi.Exists)
                DB.ReadXml(fi.FullName);
        }

        private void UpdateShortlist()
        {
            var tempshortlist = (from c in DB.Shortlist
                                 select new NTR_Db.PlayerData(c, RF));

            plShortlist = (from c in tempshortlist
                           where c.FPn > 0
                           select c).OrderBy(p => p.FPn).ToList();
            gkShortlist = (from c in tempshortlist
                           where c.FPn == 0
                           select c).ToList();

            dgPlayers.DataCollection = plShortlist;
            dgPlayersGK.DataCollection = gkShortlist;
        }

        private void openPlayersPageInTheTrophyManagerWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dgv;

            if (tabControl.SelectedTab == tabPlayers)
                dgv = dgPlayers;
            else
                dgv = dgPlayersGK;

            DataGridViewRow row = dgv.SelectedRows[0];

            NTR_Db.PlayerData playerData = (NTR_Db.PlayerData)row.DataBoundItem;
            int PlayerID = playerData.playerID;

            string navigationAddress = TM_Pages.Players + PlayerID.ToString() + "/";

            webBrowser.Goto(navigationAddress);
            startnavigationAddress = navigationAddress;

            tabControl.SelectedTab = tabBrowser;
        }

        private void openPlayersScoutPageInTheTrophyManagerWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dgv;

            if (tabControl.SelectedTab == tabPlayers)
                dgv = dgPlayers;
            else
                dgv = dgPlayersGK;

            if (dgv.SelectedRows.Count < 1) return;

            DataGridViewRow row = dgv.SelectedRows[0];

            NTR_Db.PlayerData playerData = (NTR_Db.PlayerData)row.DataBoundItem;
            int PlayerID = playerData.playerID;

            string navigationAddress = TM_Pages.Players + PlayerID.ToString() + "/#/page/scout/";

            webBrowser.Goto(navigationAddress);
            startnavigationAddress = navigationAddress;

            tabControl.SelectedTab = tabBrowser;
        }

        private void openPlayersPropertyPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dgv;

            if (tabControl.SelectedTab == tabPlayers)
                dgv = dgPlayers;
            else
                dgv = dgPlayersGK;

            if (dgv.SelectedRows.Count < 1) return;

            DataGridViewRow row = dgv.SelectedRows[0];
            NTR_Db.PlayerData playerData = (NTR_Db.PlayerData)row.DataBoundItem;

            PlayerFormSL pf = new PlayerFormSL(playerData, this.reportParser, RF);
            pf.ShowDialog();

            if (pf.isDirty)
            {
                isDirty = true;
                UpdateShortlist();
            }
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
            else
                return;

            SaveImportedFile(content, address);

            LoadHTMLfile_newPage(content);

            UpdateShortlist();
        }

        private void SaveImportedFile(string page, string address)
        {
            // Check the existence of the folder
            DirectoryInfo di = new DirectoryInfo(Path.Combine(Program.Setts.DefaultDirectory, "ImportedPages"));
            if (!di.Exists)
            {
                di.Create();
            }

            string filedate = TmWeek.ToSWDString(DateTime.Now);
            string filetime = DateTime.Now.ToLongTimeString().Replace(":","");
            string filename = "";

            if (address.Contains("shortlist"))
            {
                filename = "shortlist_" + filedate + "_" + filetime + ".htm";
            }
            else if (address.Contains("transfer"))
            {
                filename = "transfer_" + filedate + "_" + filetime + ".htm";
            }
            else
                return;

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
                DB.LoadShortlist(page, uploadOnlyListedPlayers);

                isDirty = true;
                return;
            }
            else if (page.Contains("NewTM - Transfer"))
            {
                DB.LoadTransferList(page, uploadOnlyListedPlayers);

                isDirty = true;
                return;
            }
        }

        string navigationAddress = "";
        string startnavigationAddress = "";
        private readonly ReportParser reportParser;

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

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveSelectedPlayersFromDb(false);
        }

        private void RemoveSelectedPlayersFromDb(bool evenFromMainDb)
        {
            DataGridView dgv = null;

            if (tabControl.SelectedTab == tabPlayers) dgv = dgPlayers;
            if (tabControl.SelectedTab == tabGK) dgv = dgPlayersGK;

            if (dgv == null)
            {
                MessageBox.Show("You can call this operation only when a players tab is selected");
                return;
            }

            if (dgv.SelectedRows.Count > 0)
            {
                string names = "";

                int[] plToRemove = new int[dgv.SelectedRows.Count];
                for (int i = 0; i < dgv.SelectedRows.Count; i++)
                {
                    NTR_Db.PlayerData drv = (NTR_Db.PlayerData)dgv.SelectedRows[i].DataBoundItem;
                    names += drv.Name + ",";
                    plToRemove[i] = drv.playerID;
                }

                names = names.TrimEnd(',');

                DialogResult dr = MessageBox.Show("Delete the selected players (" + names + ")?", "Remove players",
                    MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;

                foreach (int id in plToRemove)
                {
                    var playerToRemoveRow = DB.Shortlist.FindByPlayerID(id);
                    if (playerToRemoveRow != null)
                    DB.Shortlist.RemoveShortlistRow(playerToRemoveRow);

                    if (evenFromMainDb)
                    {
                        var playerRow = DB.Player.FindByPlayerID(id);
                        if (playerRow != null)
                            DB.Player.RemovePlayerRow(playerRow);
                    }
                }

                isDirty = true;
            }

            UpdateShortlist();
        }

        private void dgPortieri_Sorted(object sender, EventArgs e)
        {
            //UpdateTables(dgPlayersGK);
        }

        private void openPlayersTeamPageInTrophyBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dgv;

            if (tabControl.SelectedTab == tabPlayers)
                dgv = dgPlayers;
            else
                dgv = dgPlayersGK;

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

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void updateOnlyListedPlayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //updateOnlyListedPlayersToolStripMenuItem.Checked = !updateOnlyListedPlayersToolStripMenuItem.Checked;
        }

        private void dgPlayers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgPlayers.AeroDataGrid_ColumnHeaderMouseClick<NTR_Db.PlayerData>(sender, e);
        }

        private void dgPlayersGK_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgPlayersGK.AeroDataGrid_ColumnHeaderMouseClick<NTR_Db.PlayerData>(sender, e);
        }

        private void FormatPlayersGridPl()
        {
            dgPlayers.AutoGenerateColumns = false;

            dgPlayers.Columns.Clear();
            dgPlayers.AddColumn("FP", "FPn", 42, AG_Style.FavPosition | AG_Style.Frozen);
            dgPlayers.AddColumn("Name", "NameEx", 60, AG_Style.NameInj | AG_Style.Frozen | AG_Style.ResizeAllCells);
            dgPlayers.AddColumn("Age", "wBorn", 32, AG_Style.Age | AG_Style.Frozen);
            dgPlayers.AddColumn("Nat", "Nationality", 28, AG_Style.Nationality | AG_Style.Frozen);
            TMR_NumDecColumn dgvc = (TMR_NumDecColumn)dgPlayers.AddColumn("ASI", "ASI", 49, AG_Style.NumDec | AG_Style.Frozen);
            dgvc.CellColorStyles = CellColorStyleList.DefaultGainColorStyle();

            AddPlayersSkillColumn("Str");
            AddPlayersSkillColumn("Pac");
            AddPlayersSkillColumn("Sta");

            AddPlayersSkillColumn("Mar");
            AddPlayersSkillColumn("Tac");
            AddPlayersSkillColumn("Wor");
            AddPlayersSkillColumn("Pos");
            AddPlayersSkillColumn("Pas");
            AddPlayersSkillColumn("Cro");
            AddPlayersSkillColumn("Tec");
            AddPlayersSkillColumn("Hea");
            AddPlayersSkillColumn("Fin");
            AddPlayersSkillColumn("Lon");
            AddPlayersSkillColumn("Set");

            dgPlayers.AddColumn("Rou", "Rou", 30, AG_Style.Numeric | AG_Style.RightJustified);
            dgPlayers.AddColumn("SSD", "SSD", 30, AG_Style.Numeric | AG_Style.RightJustified);
            dgPlayers.AddColumn(RF.ShortName, "RfRec", 38, AG_Style.Numeric | AG_Style.RightJustified | AG_Style.N2);
            dgPlayers.AddColumn("Rec", "Rec", 30, AG_Style.Numeric | AG_Style.RightJustified);
            dgvc = (TMR_NumDecColumn)dgPlayers.AddColumn("TI", "TI", 32, AG_Style.NumDec | AG_Style.Frozen);
            dgvc.CellColorStyles = CellColorStyleList.DefaultGainColorStyle();

            DataGridViewCellStyle dgvcsPosCells = new DataGridViewCellStyle();
            dgvcsPosCells.Format = "N1";

            AddPlayersFpColumn("DC", dgvcsPosCells);
            AddPlayersFpColumn("DL", dgvcsPosCells);
            AddPlayersFpColumn("DR", dgvcsPosCells);
            AddPlayersFpColumn("DMC", dgvcsPosCells);
            AddPlayersFpColumn("DML", dgvcsPosCells);
            AddPlayersFpColumn("DMR", dgvcsPosCells);

            AddPlayersFpColumn("MC", dgvcsPosCells);
            AddPlayersFpColumn("ML", dgvcsPosCells);
            AddPlayersFpColumn("MR", dgvcsPosCells);
            AddPlayersFpColumn("OMC", dgvcsPosCells);
            AddPlayersFpColumn("OML", dgvcsPosCells);
            AddPlayersFpColumn("OMR", dgvcsPosCells);

            AddPlayersFpColumn("FC", dgvcsPosCells);

            var col = dgPlayers.AddColumn("Bid(Ml)", "BidValue", 45, AG_Style.Numeric | AG_Style.N2, "Bid in Millions");
            col.DefaultCellStyle.NullValue = "-";
            dgPlayers.AddColumn("Bid End", "BidEnd", 69, AG_Style.Time_ddmm_hhmm);
        }

        private void FormatPlayersGridGK()
        {
            dgPlayersGK.AutoGenerateColumns = false;

            dgPlayersGK.Columns.Clear();
            dgPlayersGK.AddColumn("Name", "NameEx", 60, AG_Style.NameInj | AG_Style.Frozen | AG_Style.ResizeAllCells);
            dgPlayersGK.AddColumn("Age", "wBorn", 32, AG_Style.Age | AG_Style.Frozen);
            dgPlayersGK.AddColumn("Nat", "Nationality", 28, AG_Style.Nationality | AG_Style.Frozen);
            TMR_NumDecColumn dgvc = (TMR_NumDecColumn)dgPlayersGK.AddColumn("ASI", "ASI", 49, AG_Style.NumDec | AG_Style.Frozen);
            dgvc.CellColorStyles = CellColorStyleList.DefaultGainColorStyle();

            AddPlayersSkillColumnGK("Str");
            AddPlayersSkillColumnGK("Pac");
            AddPlayersSkillColumnGK("Sta");

            AddPlayersSkillColumnGK("Han");
            AddPlayersSkillColumnGK("One");
            AddPlayersSkillColumnGK("Ref");
            AddPlayersSkillColumnGK("Ari");
            AddPlayersSkillColumnGK("Jum");
            AddPlayersSkillColumnGK("Com");
            AddPlayersSkillColumnGK("Kic");
            AddPlayersSkillColumnGK("Thr");

            dgPlayersGK.AddColumn("Rou", "Rou", 30, AG_Style.Numeric | AG_Style.RightJustified);
            dgPlayersGK.AddColumn("SSD", "SSD", 30, AG_Style.Numeric | AG_Style.RightJustified);
            dgPlayers.AddColumn(RF.ShortName, "RfRec", 38, AG_Style.Numeric | AG_Style.RightJustified | AG_Style.N2);
            dgPlayersGK.AddColumn("Rec", "Rec", 30, AG_Style.Numeric | AG_Style.RightJustified);
            dgvc = (TMR_NumDecColumn)dgPlayersGK.AddColumn("TI", "TI", 32, AG_Style.NumDec | AG_Style.Frozen);
            dgvc.CellColorStyles = CellColorStyleList.DefaultGainColorStyle();

            DataGridViewCellStyle dgvcsPosCells = new DataGridViewCellStyle();
            dgvcsPosCells.Format = "N1";

            AddPlayersFpColumnGK("GK", dgvcsPosCells);

            var col = dgPlayersGK.AddColumn("Bid(Ml)", "BidValue", 45, AG_Style.Numeric | AG_Style.N2, "Bid in Millions");
            col.DefaultCellStyle.NullValue = "-";
            dgPlayersGK.AddColumn("Bid End", "BidEnd", 69, AG_Style.Time_ddmm_hhmm);
        }

        #region Grid formatting
        private void AddPlayersFpColumn(string skill, DataGridViewCellStyle dgvcsPosCells)
        {
            TMR_NumDecColumn dgvc = (TMR_NumDecColumn)dgPlayers.AddColumn(skill, skill, 30, AG_Style.NumDec, dgvcsPosCells);
            dgvc.CellColorStyles = CellColorStyleList.DefaultFpColorStyle();
        }

        private void AddPlayersSkillColumn(string skill)
        {
            string translatedSkill = Current.Language.Get(skill);
            TMR_NumDecColumn dgvc = (TMR_NumDecColumn)dgPlayers.AddColumn(translatedSkill, skill, 25, AG_Style.NumDec);
            if (Program.Setts.EvidenceGain)
                dgvc.CellColorStyles = CellColorStyleList.DefaultGainColorStyle();
            else
                dgvc.CellColorStyles = CellColorStyleList.NoGainColorStyle();
        }

        private void AddPlayersFpColumnGK(string skill, DataGridViewCellStyle dgvcsPosCells)
        {
            TMR_NumDecColumn dgvc = (TMR_NumDecColumn)dgPlayersGK.AddColumn(skill, skill, 30, AG_Style.NumDec, dgvcsPosCells);
            dgvc.CellColorStyles = CellColorStyleList.DefaultFpColorStyle();
        }

        private void AddPlayersSkillColumnGK(string skill)
        {
            string translatedSkill = Current.Language.Get(skill);
            TMR_NumDecColumn dgvc = (TMR_NumDecColumn)dgPlayersGK.AddColumn(translatedSkill, skill, 26, AG_Style.NumDec);
            if (Program.Setts.EvidenceGain)
                dgvc.CellColorStyles = CellColorStyleList.DefaultGainColorStyle();
            else
                dgvc.CellColorStyles = CellColorStyleList.NoGainColorStyle();
        }
        #endregion

        private void clearShortlistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This operation will delete only the players from the list. Data of the players' history will remain in the DB.", "Clear shortlist", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            DB.Shortlist.Clear();
            UpdateShortlist();
        }

        private void clearShortlistDBforgetAllPastImportedDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This operation will delete all the data from the Shortlist DB (not the one of your team), even the data related to the players' history", "Clear shortlist", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            DB.Clear();
            UpdateShortlist();
        }

        private void deleteSelectedPlayersFromVisualizationAndDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveSelectedPlayersFromDb(true);
        }

        private void saveSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AskForString afs = new AskForString();
            afs.Message = "Insert a short string representing the search";
            afs.EntryText = "ex.: 3.5* FC International";
            afs.Text = "Add a menu search item";
            while (true)
            {
                if (afs.ShowDialog() != DialogResult.OK)
                    return;
                if (afs.Text.Contains("=") || afs.Text.Contains(";"))
                {
                    MessageBox.Show("Entered text cannot contains \"=\" or \";\" ");
                    continue;
                }
                break;
            }

            var miNewSearch = new ToolStripMenuItem(afs.EntryText);
            miNewSearch.Tag = webBrowser.NavigationAddress;
            miNewSearch.Click += searchMenuItem_Click;
            tsSearches.DropDownItems.Add(miNewSearch);

            var deleteItem = new ToolStripMenuItem();
            deleteItem.Text = "Remove Search";
            deleteItem.Tag = miNewSearch;
            deleteItem.Click += DeleteItem_Click;
            miNewSearch.DropDownItems.Add(deleteItem);

            SaveSearchMenuItems();
        }

        private void SaveSearchMenuItems()
        {
            string txtItemsString = "";

            foreach (ToolStripMenuItem item in tsSearches.DropDownItems)
            {
                txtItemsString += item.Text + "=" + (string)item.Tag + ";";
            }

            Program.Setts.ShortlistSearches = txtItemsString;
            Program.Setts.Save();
        }

        private void LoadSearchMenuItems()
        {
            string[] menuItemsStrings = Program.Setts.ShortlistSearches.Split(';');

            foreach (string item in menuItemsStrings)
            {
                if (item == "") continue;

                string[] itemSplit = item.Split('=');

                var miNewSearch = new ToolStripMenuItem(itemSplit[0]);
                miNewSearch.Tag = itemSplit[1];
                miNewSearch.Click += searchMenuItem_Click;
                tsSearches.DropDownItems.Add(miNewSearch);

                var deleteItem = new ToolStripMenuItem();
                deleteItem.Text = "Remove Search";
                deleteItem.Tag = miNewSearch;
                deleteItem.Click += DeleteItem_Click;
                miNewSearch.DropDownItems.Add(deleteItem);
            }
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ti = (ToolStripMenuItem)sender;
            tsSearches.DropDownItems.Remove((ToolStripMenuItem)ti.Tag);
        }

        private void searchMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ti = (ToolStripMenuItem)sender;

            webBrowser.Goto((string)ti.Tag);
        }

        private void ShortlistForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Rectangle pos = new Rectangle(DesktopBounds.X, DesktopBounds.Y, DesktopBounds.Width, DesktopBounds.Height);
            Program.Setts.ShortlistFormPosition = pos;
            Program.Setts.Save();

            if (isDirty)
            {
                DialogResult dr = MessageBox.Show("Save the shortlist data before closing?",
                    "Close Shortlist form", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    FileInfo fi = new FileInfo(Path.Combine(Program.Setts.DefaultDirectory, "Shortlist.5.xml"));

                    DB.WriteXml(fi.FullName);
                }
            }

            webBrowser.Close();
        }

        private void ShortlistForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            webBrowser.Dispose();
        }
    }
}
