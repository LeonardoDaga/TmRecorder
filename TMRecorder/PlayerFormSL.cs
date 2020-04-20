using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using System.Diagnostics;
using TMRecorder.Properties;
using Common;
using System.IO;
using Languages;
using SendFileTo;
using NTR_Common;
using NTR_Browser;
using NTR_Db;
using System.Linq;
using NTR_Controls;
using DataGridViewCustomColumns;

namespace TMRecorder
{
    public partial class PlayerFormSL : Form
    {
        private int selectedPlayerCnt;
        private bool playerInfoChanged = false;
        public bool isDirty = false;
        NTR_SquadDb DB = null;
        ReportParser reportParser;

        private RatingFunction _RF;
        RatingFunction RF
        {
            get { return _RF; }
            set
            {
                playerDataCnt.RF = value;
                this._RF = value;
            }
        }

        public int selectedPlayerID
        {
            get
            {
                return selectedPlayerData.playerID;
            }
        }

        public int Wage
        {
            set { playerDataCnt.Wage = value; }
        }
        
        public decimal BloomAgeView
        {
            set {playerDataCnt.BloomAge = value; }
        }

        public PlayerFormSL(NTR_Db.PlayerData playerData,
                            ReportParser reportParser,
                            RatingFunction rf)
        {
            InitializeComponent();

            RF = rf;

            SetLanguage();

            DB = playerData.DB;
            selectedPlayerData = playerData;

            int playerID = playerData.playerID;

            NTR_SquadDb.ShortlistRow sr = DB.Shortlist.FindByPlayerID(playerID);

            for (int n = 0; n < DB.Shortlist.Rows.Count; n++)
            {
                if (sr == DB.Shortlist.Rows[n])
                {
                    selectedPlayerCnt = n;
                    break;
                }
            }

            GetPlayerHistory();

            this.reportParser = reportParser;

            Initialize();

            webBrowser.SelectedReportParser = this.reportParser;

            webBrowser.GotoPlayer(selectedPlayerID, NTR_Browser.NTR_Browser.PlayerNavigationType.NavigateReports);
        }

        public void GetPlayerHistory()
        {
            var playerHRCollection = (from c in DB.HistData
                                      where (c.PlayerID == selectedPlayerID)
                                      select c);

            var playerHistoryList = playerHRCollection.OrderBy(p => p.Week).ToList();

            playerHistory = new PlayerHistory(playerHistoryList);
        }

        public void Initialize(int playerID)
        {
            NTR_SquadDb.ShortlistRow sr = DB.Shortlist.FindByPlayerID(playerID);

            for (int n = 0; n < DB.Shortlist.Rows.Count; n++)
            {
                if (sr == DB.Shortlist.Rows[n])
                {
                    selectedPlayerCnt = n;
                    selectedPlayerData = new NTR_Db.PlayerData(sr, RF);
                    break;
                }
            }

            Initialize();
        }

        public void InitializeByCount(int playerCnt)
        {
            selectedPlayerCnt = playerCnt;

            NTR_SquadDb.ShortlistRow sr = (NTR_SquadDb.ShortlistRow)DB.Shortlist.Rows[playerCnt];

            selectedPlayerData = new NTR_Db.PlayerData(sr, RF);

            Initialize();
        }

        public void Initialize()
        {
            FillBaseData(selectedPlayerData);

            FormatTrainingGrid();
            UpdateTrainingList();

            playerInfoChanged = false;

            SetupTagsBars(reportParser);

            FillPlayerBar(selectedPlayerData.playerID);

            if (tabControlPlayerHistory.SelectedTab == tabPlayerBrowser)
            {
                tsbLoadPlayerPage_Click(null, EventArgs.Empty);
            }

            this.Refresh();
        }

        private void UpdateTrainingList()
        {
            GetPlayerHistory();

            if (playerHistory.Count == 0) return;

            List<NTR_Db.PlayerData> trainingDataList = new List<NTR_Db.PlayerData>();

            for (int i = 0; i < playerHistory.Count - 1; i++)
            {
                trainingDataList.Add(new NTR_Db.PlayerData(playerHistory[i+1], playerHistory[i], RF));
            }
            trainingDataList.Add(new NTR_Db.PlayerData(playerHistory[0], null, RF));

            dgTraining.DataCollection = trainingDataList;
        }

        private void FormatTrainingGrid()
        {
            dgTraining.AutoGenerateColumns = false;

            dgTraining.Columns.Clear();
            TMR_AgeColumn colAge = (TMR_AgeColumn)dgTraining.AddColumn("Age", "wBorn", 32, AG_Style.Age | AG_Style.Frozen);
            TMR_AgeColumn colWeek = (TMR_AgeColumn)dgTraining.AddColumn("Week", "Week", 50, AG_Style.Age | AG_Style.Frozen);
            TMR_NumDecColumn dgvc = (TMR_NumDecColumn)dgTraining.AddColumn("ASI", "ASI", 49, AG_Style.NumDec | AG_Style.Frozen);
            dgvc.CellColorStyles = CellColorStyleList.DefaultGainColorStyle();
            TMR_NumDecColumn dgvcTI = (TMR_NumDecColumn)dgTraining.AddColumn("TI", "TI", 49, AG_Style.NumDec | AG_Style.Frozen);
            dgvcTI.CellColorStyles = CellColorStyleList.DefaultGainColorStyle();

            AddTrainingSkillColumn("Str");
            AddTrainingSkillColumn("Pac");
            AddTrainingSkillColumn("Sta");

            if (selectedPlayerData.FPn == 0)
            {
                AddTrainingSkillColumn("Han");
                AddTrainingSkillColumn("One");
                AddTrainingSkillColumn("Ref");
                AddTrainingSkillColumn("Ari");
                AddTrainingSkillColumn("Jum");
                AddTrainingSkillColumn("Com");
                AddTrainingSkillColumn("Kic");
                AddTrainingSkillColumn("Thr");
            }
            else
            {
                AddTrainingSkillColumn("Mar");
                AddTrainingSkillColumn("Tac");
                AddTrainingSkillColumn("Wor");
                AddTrainingSkillColumn("Pos");
                AddTrainingSkillColumn("Pas");
                AddTrainingSkillColumn("Cro");
                AddTrainingSkillColumn("Tec");
                AddTrainingSkillColumn("Hea");
                AddTrainingSkillColumn("Fin");
                AddTrainingSkillColumn("Lon");
                AddTrainingSkillColumn("Set");
            }

            colAge.When = DateTime.Now;
            colWeek.When = TmWeek.tmDay0;
        }

        private void AddTrainingSkillColumn(string skill)
        {
            string translatedSkill = Current.Language.Get(skill);
            TMR_NumDecColumn dgvc = (TMR_NumDecColumn)dgTraining.AddColumn(translatedSkill, skill, 25, AG_Style.NumDec);
            if (Program.Setts.EvidenceGain)
                dgvc.CellColorStyles = CellColorStyleList.DefaultGainColorStyle();
            else
                dgvc.CellColorStyles = CellColorStyleList.NoGainColorStyle();
        }

        private void FillTagsBars(NTR_Db.PlayerData selectedPlayerData)
        {
            if (selectedPlayerData.Aggressivity != null)
                tagsBarAgg.Value = (decimal)(float)(selectedPlayerData.Aggressivity) / 5M + 1;
            if (selectedPlayerData.Professionalism != null)
                tagsBarPro.Value = (decimal)(float)(selectedPlayerData.Professionalism) / 5M + 1;
            if (selectedPlayerData.Leadership != null)
                tagsBarLea.Value = (decimal)(float)(selectedPlayerData.Leadership) / 5M + 1;
            if (selectedPlayerData.Physics != null)
                tagsBarPhy.Value = (decimal)selectedPlayerData.Physics;
            if (selectedPlayerData.Tactics != null)
                tagsBarTac.Value = (decimal)selectedPlayerData.Tactics;
            if (selectedPlayerData.Technics != null)
                tagsBarTec.Value = (decimal)selectedPlayerData.Technics;
        }

        private void SetupTagsBars(ReportParser reportParser)
        {
            SetupTagBar(reportParser, tagsBarAgg, "Aggressivity");
            SetupTagBar(reportParser, tagsBarPro, "Professionalism");
            SetupTagBar(reportParser, tagsBarLea, "Charisma");
            SetupTagBar(reportParser, tagsBarPhy, "Physique", 0, 20);
            SetupTagBar(reportParser, tagsBarTac, "Tactics", 0, 20);
            SetupTagBar(reportParser, tagsBarTec, "Technics", 0, 20);
        }

        private void SetupTagBar(ReportParser reportParser, TagsBar tagsBar, string report, decimal min = 1M, decimal max = -1M)
        {
            tagsBar.Tags = new List<string>();
            if (!reportParser.Dict.ContainsKey(report))
                return;
            int cnt = reportParser.Dict[report].Count;
            tagsBar.Min = min;
            
            if (max == -1M)
                tagsBar.Max = cnt;
            else
                tagsBar.Max = max;

            foreach (KeyValuePair<int, string> key in reportParser.Dict[report])
            {
                tagsBar.Tags.Add(key.Value);
            }
            tagsBar.Invalidate();       
        }

        /// <summary>
        /// Create a TextLabel for each bar in the GraphPane.
        /// Call this method only after calling AxisChange()
        /// </summary>
        /// <remarks>
        /// This method will go through the bars, create a label that corresponds to the bar value,
        /// and place it on the graph depending on user preferences.  This works for horizontal or
        /// vertical bars in clusters or stacks.</remarks>
        /// <param name="pane">The GraphPane in which to place the text labels.</param>
        /// <param name="isBarCenter">true to center the labels inside the bars, false to
        /// place the labels just above the top of the bar.</param>
        /// <param name="valueFormat">The double.ToString string format to use for creating
        /// the labels
        /// </param>
        private void CreateBarLabels(GraphPane pane)
        {
            // Make the gap between the bars and the labels = 2% of the axis range
            float labelOffset = (float)(pane.YAxis.Scale.Max - pane.YAxis.Scale.Min) * 0.02f;

            // keep a count of the number of BarItems
            int curveIndex = 0;

            // Get a valuehandler to do some calculations for us
            ValueHandler valueHandler = new ValueHandler(pane, true);

            // Loop through each curve in the list
            foreach (CurveItem curve in pane.CurveList)
            {
                IPointList points = curve.Points;

                // Loop through each point in the BarItem
                for (int i = 0; i < points.Count; i++)
                {
                    double val = points[i].Y;
                    if (val == 0.0) continue;

                    // Get the high, low and base values for the current bar
                    // note that this method will automatically calculate the "effective"
                    // values if the bar is stacked
                    double baseVal, lowVal, hiVal;
                    valueHandler.GetValues(curve, i, out baseVal, out lowVal, out hiVal);

                    // Get the value that corresponds to the center of the bar base
                    // This method figures out how the bars are positioned within a cluster
                    float centerVal = (float)valueHandler.BarCenterValue(curve,
                        0, i, baseVal, curveIndex);

                    // Create a text label -- note that we have to go back to the original point
                    // data for this, since hiVal and lowVal could be "effective" values from a bar stack
                    string barLabelText = (string)points[i].Tag;

                    // Calculate the position of the label -- this is either the X or the Y coordinate
                    // depending on whether they are horizontal or vertical bars, respectively
                    float position;
                    position = (float)hiVal; // (hiVal + lowVal) / 2.0f;

                    // Create the new TextObj
                    float offset = 0.35f;
                    TextObj label = new TextObj(barLabelText.ToUpper(), centerVal, position - offset);

                    // Configure the TextObj
                    label.Location.Width = 1;
                    label.Location.CoordinateFrame = CoordType.AxisXYScale;
                    label.FontSpec.Size = 9;
                    label.FontSpec.FontColor = Color.Black;
                    label.FontSpec.Angle = 0;
                    label.Location.AlignH = AlignH.Center;
                    label.Location.AlignV = AlignV.Center;
                    label.FontSpec.Border.IsVisible = false;
                    label.FontSpec.Fill.IsVisible = false;

                    // Add the TextObj to the GraphPane
                    pane.GraphObjList.Add(label);
                }

                curveIndex++;
            }
        }

        /*
        private void FillPlayerInfo(bool reset)
        {
            TeamDS.GiocatoriNSkillRow playerDatarow = (TeamDS.GiocatoriNSkillRow)GDT.Rows[selectedPlayerCnt];
            TeamDS.GiocatoriNSkillRow selectedPlayerData = teamDS.GiocatoriNSkill.FindByPlayerID(playerDatarow.PlayerID);

            scoutsNReviews.Scouts.Clear();
            foreach (ExtraDS.ScoutsRow sr in History.PlayersDS.Scouts)
            {
                Common.ScoutsNReviews.ScoutsRow srn = scoutsNReviews.Scouts.NewScoutsRow();
                srn.Name = sr.Name;
                srn.Physical = sr.Physical;
                srn.Psychology = sr.Psychology;
                srn.Development = sr.Development;
                srn.Senior = sr.Senior;
                srn.Youth = sr.Youth;
                srn.Tactical = sr.Tactical;
                srn.Technical = sr.Technical;
                scoutsNReviews.Scouts.AddScoutsRow(srn);
            }

            scoutsNReviews.Review.Clear();
            //scoutsNReviews.FillTables(selectedPlayerData, History.reportParser);

            reviewDataTableBindingSource.Filter = "PlayerID=" + selectedPlayerData.PlayerID.ToString();

            txtNotes.Text = selectedPlayerData.Notes;

            foreach (DataGridViewColumn col in dgReviews.Columns)
            {
                if (col.GetType() == typeof(DataGridViewCustomColumns.TMR_ReportColumn))
                {
                    DataGridViewCustomColumns.TMR_ReportColumn repCol = 
                        (DataGridViewCustomColumns.TMR_ReportColumn)col;

                    repCol.reportParser = History.reportParser;
                    repCol.FPn = selectedPlayerData.FPn;
                }
            }
        }

        private void StorePlayerInfo()
        {
            TeamDS.GiocatoriNSkillRow playerDatarow = (TeamDS.GiocatoriNSkillRow)GDT.Rows[selectedPlayerCnt];
            ExtraDS.GiocatoriRow selectedPlayerData = History.PlayersDS.Giocatori.FindByPlayerID(playerDatarow.PlayerID);
            selectedPlayerData.Note = txtNotes.Text;
        }
        */
        private void FillBaseData(NTR_Db.PlayerData playerData)
        {
            playerDataCnt.SetPlayerData(playerData);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            selectedPlayerCnt++;

            if (selectedPlayerCnt > DB.Shortlist.Rows.Count - 1)
            {
                selectedPlayerCnt = 0;
            }

            InitializeByCount(selectedPlayerCnt);

            webBrowser.GotoPlayer(selectedPlayerID, NTR_Browser.NTR_Browser.PlayerNavigationType.NavigateReports);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            selectedPlayerCnt--;

            if (selectedPlayerCnt < 0)
            {
                selectedPlayerCnt = DB.Shortlist.Rows.Count - 1;
            }

            InitializeByCount(selectedPlayerCnt);

            webBrowser.GotoPlayer(selectedPlayerID, NTR_Browser.NTR_Browser.PlayerNavigationType.NavigateReports);
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            playerInfoChanged = true;
        }

        private void openPlayerPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControlPlayerHistory.SelectedTab = tabPlayerBrowser;
            tsbLoadPlayerPage_Click(sender, e);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string arg = "http://trophymanager.com/club/11816/";

            ProcessStartInfo startInfo = new ProcessStartInfo(arg);
            Process.Start(startInfo);
        }

        private void tsbComputeGrowth_Click(object sender, EventArgs e)
        {
            ComputeBloom cb = new ComputeBloom();
            cb.ActualASI = selectedPlayerData.ASI.actual;
            cb.CurrentSkillSum = (decimal)Tm_Utility.ASItoSkSum((decimal)selectedPlayerData.ASI.actual, false);
            cb.RealSkillSum = selectedPlayerData.SkillSum.actual;

            cb.ActualTI = 0;

            cb.PlayerNameAndID = selectedPlayerData.Name + "\n(" + selectedPlayerID.ToString() + ")";

            cb.AgeStartOfBloom = (selectedPlayerData.wBloomStart - selectedPlayerData.wBorn) / 12;
            cb.ExplosionTI = selectedPlayerData.ExplosionTI;
            cb.AfterBloomingTI = selectedPlayerData.AfterBloomTI;
            cb.BeforeExplosionTI = selectedPlayerData.BeforeExplTI;

            int savedBloomStart = cb.AgeStartOfBloom;

            cb.isGK = false;
            cb.PlayerBornWeek = selectedPlayerData.wBorn;
            cb.ShowDialog();

            if ((savedBloomStart != cb.AgeStartOfBloom) ||
                (selectedPlayerData.ExplosionTI != cb.ExplosionTI) ||
                (selectedPlayerData.AfterBloomTI != cb.AfterBloomingTI) ||
                (selectedPlayerData.BeforeExplTI != cb.BeforeExplosionTI))
            {
                selectedPlayerData.wBloomStart = selectedPlayerData.wBorn + cb.AgeStartOfBloom * 12;
                selectedPlayerData.ExplosionTI = cb.ExplosionTI;
                selectedPlayerData.AfterBloomTI = cb.AfterBloomingTI;
                selectedPlayerData.BeforeExplTI = cb.BeforeExplosionTI;
                selectedPlayerData.isBloomDataDirty = true;
                isDirty = true;
            }

            selectedPlayerData.isBloomDataDirty = true;
            selectedPlayerData.Asi25 = (decimal)(int)cb.ASI25;
            selectedPlayerData.Asi30 = (decimal)(int)cb.ASI30;
        }

        string navigationAddress = "";
        string startnavigationAddress = "";
        private void tsbLoadPlayerPage_Click(object sender, EventArgs e)
        {
            webBrowser.GotoPlayer(selectedPlayerID, NTR_Browser.NTR_Browser.PlayerNavigationType.NavigateReports);
        }

        #region Player Profiles Navigation
        enum NavigationType
        {
            NavigateProfiles,
            NavigateReports
        }

        NavigationType navigationType = NavigationType.NavigateReports;
        int lastBarPlayer = 0;
        private PlayerHistory playerHistory;
        private NTR_Db.PlayerData selectedPlayerData;

        private void ChangePlayer_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsi = (ToolStripMenuItem)sender;
            int changeID = (int)tsi.Tag;
            Initialize(changeID);

            //if (tabControl1.SelectedTab == tabPlayerBrowser)
            //{
                tsbLoadPlayerPage_Click(sender, e);
            //}
            //else
            //{
            //    FillPlayerBar(changeID);
            //}
        }

        private void FillPlayerBar(int playerID)
        {

            //tsBrowsePlayers.Visible = true;

            //tsbNumberOfReviews.Text = selectedPlayerData.ScoutReviews.Length + " Scout Reviews stored";

            tsbPlayers.Text = "[" + Tm_Utility.FPnToFP(selectedPlayerData.FPn) + "] " + selectedPlayerData.Name;

            AddMenuItem(tsbPlayers, "", null);
            foreach(NTR_SquadDb.ShortlistRow sr in DB.Shortlist)
            {
                ToolStripItem tsi = new ToolStripMenuItem();
                NTR_Db.PlayerData pd = new NTR_Db.PlayerData(sr, RF);

                string FP = Tm_Utility.FPnToFP(pd.FPn);
                tsi.Text = "[" + FP + "] " + pd.Name;
                tsi.Tag = pd.playerID;
                tsi.Click += ChangePlayer_Click;
                AddMenuItem(tsbPlayers, FP, tsi);
            }
        }
        #endregion

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

        private void AddMenuItem(ToolStripDropDownButton tsbPlayers, string FP, ToolStripItem tsi)
        {
            if (tsi == null)
            {
                // gKToolStripMenuItem.DropDownItems.Clear();
                gkGoalkeepersToolStripMenuItem.DropDownItems.Clear();
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
                    if (!FindItemInMenu(gkGoalkeepersToolStripMenuItem, itsi.Text))
                        gkGoalkeepersToolStripMenuItem.DropDownItems.Add(itsi);
                }
                if ((fp == "DC") || (fp == "DL") || (fp == "DR"))
                {
                    if (!FindItemInMenu(dDefendersToolStripMenuItem, itsi.Text))
                        dDefendersToolStripMenuItem.DropDownItems.Add(itsi);
                }
                if ((fp == "DMC") || (fp == "DML") || (fp == "DMR"))
                {
                    if (!FindItemInMenu(dMDefenderMidfieldersToolStripMenuItem, itsi.Text))
                        dMDefenderMidfieldersToolStripMenuItem.DropDownItems.Add(itsi);
                }
                if ((fp == "MC") || (fp == "ML") || (fp == "MR"))
                {
                    if (!FindItemInMenu(mMidfieldersToolStripMenuItem, itsi.Text))
                        mMidfieldersToolStripMenuItem.DropDownItems.Add(itsi);
                }
                if ((fp == "OMC") || (fp == "OML") || (fp == "OMR"))
                {
                    if (!FindItemInMenu(oMOffenderMidfieldersToolStripMenuItem, itsi.Text))
                        oMOffenderMidfieldersToolStripMenuItem.DropDownItems.Add(itsi);
                }
                if (fp == "FC")
                {
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

        private void PlayerForm_Load(object sender, EventArgs e)
        {
            Rectangle pos = Program.Setts.PlayerFormPosition;

            if (pos.Height + pos.Width > 0)
                this.SetDesktopBounds(pos.X, pos.Y, pos.Width, pos.Height);

            PlayerForm_SizeChanged(this, EventArgs.Empty);
        }

        private void PlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Rectangle pos = new Rectangle(DesktopBounds.X, DesktopBounds.Y, DesktopBounds.Width, DesktopBounds.Height);
            Program.Setts.PlayerFormPosition = pos;
            Program.Setts.Save();
            this.SuspendLayout();
            this.Controls.Remove(this.webBrowser);
            this.ResumeLayout(false);
            webBrowser.Dispose();
            webBrowser = null;
        }

        private void reviewDataTableBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void PlayerForm_SizeChanged(object sender, EventArgs e)
        {
            tagsBarPhy.Left = 0;
            tagsBarTac.Left = tabPlayerScouting.Width/6;
            tagsBarTec.Left = 2*tabPlayerScouting.Width / 6;
            tagsBarLea.Left = 3 * tabPlayerScouting.Width / 6;
            tagsBarAgg.Left = 4* tabPlayerScouting.Width / 6;
            tagsBarPro.Left = 5 * tabPlayerScouting.Width / 6;

            tagsBarPhy.Width = tabPlayerScouting.Width / 6;
            tagsBarTac.Width = tabPlayerScouting.Width / 6;
            tagsBarTec.Width = tabPlayerScouting.Width / 6;
            tagsBarLea.Width = tabPlayerScouting.Width / 6;
            tagsBarAgg.Width = tabPlayerScouting.Width / 6;
            tagsBarPro.Width = tabPlayerScouting.Width / 6;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlPlayerHistory.SelectedTab == tabPlayerScouting)
                PlayerForm_SizeChanged(this, EventArgs.Empty);
        }

        private void toolStripLabel3_DoubleClick(object sender, EventArgs e)
        {
            string arg = "http://trophymanager.com/club/2925434/";

            ProcessStartInfo startInfo = new ProcessStartInfo(arg);
            Process.Start(startInfo);
        }

        private void webBrowser_ImportedContent(string content, string address)
        {
            selectedPlayerData.ParsePageContent(content);

            selectedPlayerData.FillScoutsInfo(content);

            selectedPlayerData.ParseReviewsToSpecialities(reportParser);

            FillBaseData(selectedPlayerData);

            FillTagsBars(selectedPlayerData);

            GetPlayerHistory();

            UpdateTrainingList();

            isDirty = true;
        }

        private void UpdateHistoryScouts()
        {
            //History.PlayersDS.Scouts.Clear();
            //foreach (var sr in scoutsNReviews.Scouts)
            //{
            //    var srn = History.PlayersDS.Scouts.NewScoutsRow();
            //    srn.Name = sr.Name;
            //    srn.Physical = sr.Physical;
            //    srn.Psychology = sr.Psychology;
            //    srn.Development = sr.Development;
            //    srn.Senior = sr.Senior;
            //    srn.Youth = sr.Youth;
            //    srn.Tactical = sr.Tactical;
            //    srn.Technical = sr.Technical;
            //    History.PlayersDS.Scouts.AddScoutsRow(srn);
            //}
        }
    }

    public class PlayerHistory : List<NTR_SquadDb.HistDataRow>
    {
        public PlayerHistory(List<NTR_SquadDb.HistDataRow> s)
        {
            this.Clear();
            this.AddRange(s);
        }

        internal string getTIs()
        {
            string TIs = "";

            if (this.Count > 0)
                TIs = (new TmWeek(this[0].Week)).ToString();

            foreach (NTR_SquadDb.HistDataRow hr in this)
            {
                TIs += ";" + hr.TI.ToString();
            }
            return TIs;
        }
    }
}