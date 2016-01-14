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
using mshtml;
using NTR_WebBrowser;

namespace TMRecorder
{
    public partial class PlayerFormSL : Form
    {
        private TeamHistory History;
        public TeamDS.GiocatoriNSkillDataTable GDT;
        private int actualPlayerCnt;
        private bool playerInfoChanged = false;
        public bool isDirty = false;
        public NTR_Db.Seasons allSeasons = null;
        public int actPlayerID
        {
            get
            {
                TeamDS.GiocatoriNSkillRow playerDatarow = (TeamDS.GiocatoriNSkillRow)GDT.Rows[actualPlayerCnt];
                return playerDatarow.PlayerID;
            }
        }

        public int Wage
        {
            set { playerData.Wage = value; }
        }
        
        public decimal BloomAgeView
        {
            set {playerData.BloomAge = value; }
        }

        public PlayerFormSL(TeamDS.GiocatoriNSkillDataTable gdt,
                         NTR_Db.Seasons allseason)
        {
            // Only for debug
            InitializeComponent();

            SetLanguage();

            this.allSeasons = allseason;

            GDT = gdt;
        }

        public PlayerFormSL(TeamDS.GiocatoriNSkillDataTable gdt,
                         TeamHistory hist,
                         int ID,
                         NTR_Db.Seasons allseasons)
        {
            InitializeComponent();

            SetLanguage();

            this.allSeasons = allseasons;

            History = hist;

            GDT = gdt;

            TeamDS.GiocatoriNSkillRow row = gdt.FindByPlayerID(ID);
            for (int n = 0; n < gdt.Rows.Count; n++)
            {
                if (row == gdt.Rows[n])
                {
                    actualPlayerCnt = n;
                    break;
                }
            }

            Initialize();            

            chkNormalized_CheckedChanged(null, EventArgs.Empty);

            webBrowser.SelectedReportParser = History.reportParser;
            webBrowser.GotoPlayer(ID, NTR_Browser.PlayerNavigationType.NavigateReports);
        }

        public void Initialize(int playerID)
        {
            for (int n = 0; n < GDT.Rows.Count; n++)
            {
                ExtTMDataSet.GiocatoriNSkillRow playerDatarow = (ExtTMDataSet.GiocatoriNSkillRow)GDT.Rows[n];
                if (playerDatarow.PlayerID == playerID)
                {
                    actualPlayerCnt = n;
                    break;
                }
            }

            Initialize();
        }

        public void Initialize()
        {
            TeamDS.GiocatoriNSkillRow playerDatarow = (TeamDS.GiocatoriNSkillRow)GDT.Rows[actualPlayerCnt];

            ExtTMDataSet.PlayerHistoryDataTable table = History.GetPlayerHistory(playerDatarow.PlayerID);

            FillBaseData(playerDatarow);

            if (playerDatarow.FPn == 0)
            {
                FillTrainingTable_Gk(playerDatarow.PlayerID);
            }
            else
            {
                FillTrainingTable_Pl(playerDatarow.PlayerID);
            }

            FillPlayerInfo(true);

            playerInfoChanged = false;

            SetupTagsBars(History.reportParser);

            FillPlayerBar(playerDatarow.PlayerID);

            if (tabControlPlayerHistory.SelectedTab == tabPlayerBrowser)
            {
                tsbLoadPlayerPage_Click(null, EventArgs.Empty);
            }

            this.Refresh();
        }

        private void FillTagsBars(ExtraDS.GiocatoriRow gRow)
        {
            if (!gRow.IsAggressivityNull())
                tagsBarAgg.Value = (decimal)gRow.Aggressivity / 5M + 1;
            else
                tagsBarAgg.Value = 0;

            if (!gRow.IsProfessionalismNull())
                tagsBarPro.Value = (decimal)gRow.Professionalism / 5M + 1;
            else
                tagsBarPro.Value = 0;

            if (!gRow.IsLeadershipNull())
                tagsBarLea.Value = (decimal)gRow.Leadership / 5M + 1;
            else
                tagsBarLea.Value = 0;

            tagsBarPhy.Value = (decimal)gRow.Physics;
            tagsBarTac.Value = (decimal)gRow.Tactics;
            tagsBarTec.Value = (decimal)gRow.Technics;
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

        private void FillTrainingTable_Gk(int playerID)
        {
            finDataGridViewTextBoxColumn.Visible = false;
            setDataGridViewTextBoxColumn.Visible = false;
            lonDataGridViewTextBoxColumn.Visible = false;
            trainingTypesColumn.Visible = false;

            this.marDataGridViewTextBoxColumn.HeaderText = Current.Language.Han;
            this.conDataGridViewTextBoxColumn.HeaderText = Current.Language.One;
            this.worDataGridViewTextBoxColumn.HeaderText = Current.Language.Ref;
            this.posDataGridViewTextBoxColumn.HeaderText = Current.Language.Ari;
            this.pasDataGridViewTextBoxColumn.HeaderText = Current.Language.Jum;
            this.croDataGridViewTextBoxColumn.HeaderText = Current.Language.Com;
            this.tecDataGridViewTextBoxColumn.HeaderText = Current.Language.Kic;
            this.tesDataGridViewTextBoxColumn.HeaderText = Current.Language.Thr;

            playerTraining.Clear();

            History.FillGKTrainingTable(playerTraining, playerID);

            dgTraining.SetWhen(DateTime.Now);
        }

        private void FillTrainingTable_Pl(int playerID)
        {
            finDataGridViewTextBoxColumn.Visible = true;
            setDataGridViewTextBoxColumn.Visible = true;
            lonDataGridViewTextBoxColumn.Visible = true;
            trainingTypesColumn.Visible = true;

            this.marDataGridViewTextBoxColumn.HeaderText = Current.Language.Mar;
            this.conDataGridViewTextBoxColumn.HeaderText = Current.Language.Tak;
            this.worDataGridViewTextBoxColumn.HeaderText = Current.Language.Wor;
            this.posDataGridViewTextBoxColumn.HeaderText = Current.Language.Pos;
            this.pasDataGridViewTextBoxColumn.HeaderText = Current.Language.Pas;
            this.croDataGridViewTextBoxColumn.HeaderText = Current.Language.Cro;
            this.tecDataGridViewTextBoxColumn.HeaderText = Current.Language.Tec;
            this.tesDataGridViewTextBoxColumn.HeaderText = Current.Language.Hea;
            this.finDataGridViewTextBoxColumn.HeaderText = Current.Language.Fin;
            this.lonDataGridViewTextBoxColumn.HeaderText = Current.Language.Lon;
            this.setDataGridViewTextBoxColumn.HeaderText = Current.Language.Set;

            playerTraining.Clear();

            History.FillPLTrainingTable(playerTraining, playerID);

            dgTraining.SetWhen(DateTime.Now);
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

        private void FillPlayerInfo(bool reset)
        {
            TeamDS.GiocatoriNSkillRow playerDatarow = (TeamDS.GiocatoriNSkillRow)GDT.Rows[actualPlayerCnt];
            TeamDS.GiocatoriNSkillRow gRow = teamDS.GiocatoriNSkill.FindByPlayerID(playerDatarow.PlayerID);

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
            //scoutsNReviews.FillTables(gRow, History.reportParser);

            reviewDataTableBindingSource.Filter = "PlayerID=" + gRow.PlayerID.ToString();

            txtNotes.Text = gRow.Notes;

            foreach (DataGridViewColumn col in dgReviews.Columns)
            {
                if (col.GetType() == typeof(DataGridViewCustomColumns.TMR_ReportColumn))
                {
                    DataGridViewCustomColumns.TMR_ReportColumn repCol = 
                        (DataGridViewCustomColumns.TMR_ReportColumn)col;

                    repCol.reportParser = History.reportParser;
                    repCol.FPn = gRow.FPn;
                }
            }

            //FillTagsBars(gRow);

            //string gameTable = "";
            //if (!gRow.IsGameTableNull())
            //    gameTable = gRow.GameTable;
            //gameTableDS.LoadSeasonsStrings(gameTable);

            //if (gRow.wBloomStart != -1) 
            //    BloomAgeView = (gRow.wBloomStart - gRow.wBorn) / 12;
            //else
            //    BloomAgeView = -1M;
        }

        private void StorePlayerInfo()
        {
            TeamDS.GiocatoriNSkillRow playerDatarow = (TeamDS.GiocatoriNSkillRow)GDT.Rows[actualPlayerCnt];
            ExtraDS.GiocatoriRow gRow = History.PlayersDS.Giocatori.FindByPlayerID(playerDatarow.PlayerID);
            gRow.Note = txtNotes.Text;
        }

        private void FillBaseData(TeamDS.GiocatoriNSkillRow playerDatarow)
        {
            ExtraDS.GiocatoriRow gRow = History.PlayersDS.Giocatori.FindByPlayerID(playerDatarow.PlayerID);

            playerData.PlayerRow = playerDatarow;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            actualPlayerCnt++;

            if (actualPlayerCnt > GDT.Rows.Count - 1)
            {
                actualPlayerCnt = 0;
            }

            Initialize();

            webBrowser.GotoPlayer(actPlayerID, NTR_Browser.PlayerNavigationType.NavigateReports);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            actualPlayerCnt--;

            if (actualPlayerCnt < 0)
            {
                actualPlayerCnt = GDT.Rows.Count - 1;
            }

            Initialize();

            webBrowser.GotoPlayer(actPlayerID, NTR_Browser.PlayerNavigationType.NavigateReports);
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            playerInfoChanged = true;
        }

        private void playersMainPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtTMDataSet.GiocatoriNSkillRow playerDatarow = (ExtTMDataSet.GiocatoriNSkillRow)GDT.Rows[actualPlayerCnt];
            Clipboard.SetText("http://trophymanager.com/players/" + playerDatarow.PlayerID.ToString());
        }

        private void playersScoutPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtTMDataSet.GiocatoriNSkillRow playerDatarow = (ExtTMDataSet.GiocatoriNSkillRow)GDT.Rows[actualPlayerCnt];
            Clipboard.SetText("http://trophymanager.com/players/" + playerDatarow.PlayerID.ToString() + "/#/page/scout/");
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

        private void chkShowTGI_CheckedChanged(object sender, EventArgs e)
        {
            ExtTMDataSet.GiocatoriNSkillRow playerDatarow = (ExtTMDataSet.GiocatoriNSkillRow)GDT.Rows[actualPlayerCnt];
            ExtTMDataSet.PlayerHistoryDataTable table = History.GetPlayerHistory(playerDatarow.PlayerID);
            Program.Setts.Save();
        }

        private void exportInExcelFormat_Click(object sender, EventArgs e)
        {
            ExtTMDataSet.GiocatoriNSkillRow playerDatarow = (ExtTMDataSet.GiocatoriNSkillRow)GDT.Rows[actualPlayerCnt];
            ExtTMDataSet.PlayerHistoryDataTable table = History.GetPlayerHistory(playerDatarow.PlayerID);
            ExtraDS.GiocatoriRow gRow = History.PlayersDS.Giocatori.FindByPlayerID(playerDatarow.PlayerID);
            WeekHistorical whTI = new WeekHistorical(gRow.TSI);
            WeekHistorical whASI = new WeekHistorical(whTI.lastWeek);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                ExtTMDataSet.PlayerHistoryRow pr = (ExtTMDataSet.PlayerHistoryRow)table.Rows[i];
                whASI.Set(pr.Date, pr.ASI);
            }

            int iniWeek = Math.Min(whASI.lastWeek.absweek, whTI.lastWeek.absweek);
            int thisWeek = TmWeek.thisWeek().absweek;

            string dates = TmWeek.GenerateDatesString(iniWeek, thisWeek, '\t');
            string asiHist = whASI.GenerateHistoryString(iniWeek, thisWeek, '\t');
            string tiHist = whTI.GenerateHistoryString(iniWeek, thisWeek, '\t');

            Clipboard.SetText("Date\t" + dates +
                "\r\nASI\t" + asiHist +
                "\r\nTI\t" + tiHist);

            MessageBox.Show("The history of the player has been copied into the clipboard. \n" +
                "Open now Excel and paste into a sheet", "Copy to Excel");
        }

        private void chkNormalized_CheckedChanged(object sender, EventArgs e)
        {
            ExtTMDataSet.GiocatoriNSkillRow playerDatarow = (ExtTMDataSet.GiocatoriNSkillRow)GDT.Rows[actualPlayerCnt];
            Program.Setts.Save();
        }

        private void cmbSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkNormalized_CheckedChanged(null, EventArgs.Empty);
        }

        private void tsbComputeGrowth_Click(object sender, EventArgs e)
        {
            ExtTMDataSet.GiocatoriNSkillRow playerDatarow = (ExtTMDataSet.GiocatoriNSkillRow)GDT.Rows[actualPlayerCnt];
            ExtTMDataSet.PlayerHistoryDataTable table = History.GetPlayerHistory(playerDatarow.PlayerID);

            ExtraDS.GiocatoriRow gRow = History.PlayersDS.Giocatori.FindByPlayerID(playerDatarow.PlayerID);


            ComputeBloom cb = new ComputeBloom();
            cb.ActualASI = gRow.ASI;
            cb.CurrentSkillSum = (decimal)Tm_Utility.ASItoSkSum((decimal)gRow.ASI, false);
            cb.RealSkillSum = playerDatarow.SkillSum;

            WeekHistorical whTI = new WeekHistorical(gRow.TSI);
            if (!float.IsNaN(whTI.ActualTI))
                cb.ActualTI = (decimal)whTI.ActualTI;
            else
                cb.ActualTI = 0;

            cb.PlayerNameAndID = gRow.Nome + "\n(" + gRow.PlayerID.ToString() + ")";

            if (gRow.wBloomStart == -1)
            {
                gRow.wBloomStart = whTI.FindBloomStart();

                cb.AgeStartOfBloom = (gRow.wBloomStart - gRow.wBorn) / 12;
                cb.ExplosionTI = gRow.ExplosionTI;
                cb.AfterBloomingTI = gRow.AfterBloomTI;
                cb.BeforeExplosionTI = gRow.BeforeExplTI;
            }
            else
            {
                cb.AgeStartOfBloom = (gRow.wBloomStart - gRow.wBorn) / 12;
                cb.ExplosionTI = gRow.ExplosionTI;
                cb.AfterBloomingTI = gRow.AfterBloomTI;
                cb.BeforeExplosionTI = gRow.BeforeExplTI;
            }

            int savedBloomStart = cb.AgeStartOfBloom;

            cb.isGK = false;
            cb.PlayerBornWeek = gRow.wBorn;
            cb.ShowDialog();

            if ((savedBloomStart != cb.AgeStartOfBloom) ||
                (gRow.ExplosionTI != cb.ExplosionTI) ||
                (gRow.AfterBloomTI != cb.AfterBloomingTI) ||
                (gRow.BeforeExplTI != cb.BeforeExplosionTI))
            {
                gRow.wBloomStart = gRow.wBorn + cb.AgeStartOfBloom * 12;
                gRow.ExplosionTI = cb.ExplosionTI;
                gRow.AfterBloomTI = cb.AfterBloomingTI;
                gRow.BeforeExplTI = cb.BeforeExplosionTI;
                gRow.isDirty = true;
                isDirty = true;
            }
            gRow.isDirty = true;
            gRow.Asi25 = (decimal)(int)cb.ASI25;
            gRow.Asi30 = (decimal)(int)cb.ASI30;
        }

        private void btnGetVotenSkillAuto_Click(object sender, EventArgs e)
        {
            ExtTMDataSet.GiocatoriNSkillRow playerDatarow = (ExtTMDataSet.GiocatoriNSkillRow)GDT.Rows[actualPlayerCnt];

            FileInfo fi = new FileInfo(Program.Setts.ReportAnalysisFile);

            ReportAnalysis.Clear();
            if (fi.Exists)
                ReportAnalysis.ReadXml(Program.Setts.ReportAnalysisFile);

            History.PlayersDS.ParseScoutReviewForHiddenData(ReportAnalysis, playerDatarow.PlayerID);
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void chkNormalized_Click(object sender, EventArgs e)
        {
        }

        private void whatToDoHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Set here which is the potential of your player as is indicated from the scouts.\n" +
                "Remember that each scout has the a different ability of reviewing a skill of player, \n" +
                "so set the potential accordingly. These values will be used to find which is the best \n" +
                "training program for your player.");
        }

        private void getPotentialForThisPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtTMDataSet.GiocatoriNSkillRow playerDatarow = (ExtTMDataSet.GiocatoriNSkillRow)GDT.Rows[actualPlayerCnt];

            FileInfo fi = new FileInfo(Program.Setts.ReportAnalysisFile);

            ReportAnalysis.Clear();
            if (fi.Exists)
                ReportAnalysis.ReadXml(Program.Setts.ReportAnalysisFile);

            History.PlayersDS.ParseScoutReviewForHiddenData(ReportAnalysis, playerDatarow.PlayerID);
        }

        string navigationAddress = "";
        string startnavigationAddress = "";
        private void tsbLoadPlayerPage_Click(object sender, EventArgs e)
        {
            webBrowser.GotoPlayer(actPlayerID, NTR_Browser.PlayerNavigationType.NavigateReports);
        }

        #region Player Profiles Navigation
        enum NavigationType
        {
            NavigateProfiles,
            NavigateReports
        }

        NavigationType navigationType = NavigationType.NavigateReports;
        int lastBarPlayer = 0;
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
            TeamDS.GiocatoriNSkillRow gRow = (TeamDS.GiocatoriNSkillRow)GDT.FindByPlayerID(playerID);

            if (gRow == null)
            {
                //tsBrowsePlayers.Visible = false;
                return;
            }

            //tsBrowsePlayers.Visible = true;

            //tsbNumberOfReviews.Text = gRow.ScoutReviews.Length + " Scout Reviews stored";

            tsbPlayers.Text = "[" + gRow.FP + "] " + gRow.Nome.Split('|')[0];

            AddMenuItem(tsbPlayers, "", null);
            for (int i = 0; i < GDT.Count; i++)
            {
                ToolStripItem tsi = new ToolStripMenuItem();
                tsi.Text = "[" + GDT[i].FP + "] " + GDT[i].Nome.Split('|')[0];
                tsi.Tag = GDT[i].PlayerID;
                tsi.Click += ChangePlayer_Click;
                AddMenuItem(tsbPlayers, GDT[i].FP, tsi);
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
            TeamDS.GiocatoriNSkillRow playerDatarow = (TeamDS.GiocatoriNSkillRow)GDT.Rows[actualPlayerCnt];
            ExtraDS.GiocatoriRow gRow = History.PlayersDS.Giocatori.FindByPlayerID(playerDatarow.PlayerID);

            scoutsNReviews.FillScoutsInfo(content);

            ExtraDS.ParsePlayerPage_NTR(content, ref gRow);

            // Aggiorna i dati di basi
            playerDatarow.FP = gRow.FP;
            playerDatarow.FPn = gRow.FPn;

            isDirty = true;

            ExtTMDataSet.PlayerHistoryDataTable table = History.GetPlayerHistory(playerDatarow.PlayerID);
            // FillTIGraph(table);

            gRow.ParseReviewsToSpecialities(scoutsNReviews, History.reportParser);

            gRow.ComputeBloomingFromGiudizio(scoutsNReviews);

            FillBaseData(playerDatarow);

            UpdateHistoryScouts();

            scoutsNReviews.Review.Clear();
            scoutsNReviews.FillTables(gRow, History.reportParser);

            FillTagsBars(gRow);

            gRow.isDirty = true;
        }

        private void UpdateHistoryScouts()
        {
            History.PlayersDS.Scouts.Clear();
            foreach (var sr in scoutsNReviews.Scouts)
            {
                var srn = History.PlayersDS.Scouts.NewScoutsRow();
                srn.Name = sr.Name;
                srn.Physical = sr.Physical;
                srn.Psychology = sr.Psychology;
                srn.Development = sr.Development;
                srn.Senior = sr.Senior;
                srn.Youth = sr.Youth;
                srn.Tactical = sr.Tactical;
                srn.Technical = sr.Technical;
                History.PlayersDS.Scouts.AddScoutsRow(srn);
            }
        }
    }
}