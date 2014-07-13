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

namespace TMRecorder
{
    public partial class GKForm : Form
    {
        private TeamHistory History;
        private ExtTMDataSet.PortieriNSkillDataTable GDT;
        private int iActualPlayer;
        private bool playerInfoChanged = false;
        public bool isDirty = false;
        public ChampDS.PlyStatsDataTable plyStatsTable = null;

        public int actPlayerID
        {
            get
            {
                ExtTMDataSet.PortieriNSkillRow playerDatarow = (ExtTMDataSet.PortieriNSkillRow)GDT.Rows[iActualPlayer];
                return playerDatarow.PlayerID;
            }
        }

        public int Wage
        {
            set { lblWage.Text = value.ToString(); }
        }

        public string Age
        {
            set { lblAge.Text = value; }
        }

        public int ASI
        {
            set { lblASI.Text = value.ToString(); }
        }

        public string PlayerName
        {
            set { lblName.Text = value.Split('|')[0]; }
        }

        public decimal Routine
        {
            set { lblRoutine.Text = value.ToString(); }
        }

        public GKForm(ExtTMDataSet.PortieriNSkillDataTable gdt,
                         TeamHistory hist,
                         int ID,
                         ChampDS.PlyStatsDataTable plystatstable)
        {
            InitializeComponent();

            SetLanguage();

            this.plyStatsTable = plystatstable;

            History = hist;

            GDT = gdt;

            ExtTMDataSet.PortieriNSkillRow row = gdt.FindByPlayerID(ID);
            for (int n = 0; n < gdt.Rows.Count; n++)
            {
                if (row == gdt.Rows[n])
                {
                    iActualPlayer = n;
                    break;
                }
            }

            Initialize();
        }

        public void Initialize(int playerID)
        {
            for (int n = 0; n < GDT.Rows.Count; n++)
            {
                ExtTMDataSet.PortieriNSkillRow playerDatarow = (ExtTMDataSet.PortieriNSkillRow)GDT.Rows[n];
                if (playerDatarow.PlayerID == playerID)
                {
                    iActualPlayer = n;
                    break;
                }
            }

            Initialize();
        }

        public void Initialize()
        {
            ExtTMDataSet.PortieriNSkillRow playerDatarow = (ExtTMDataSet.PortieriNSkillRow)GDT.Rows[iActualPlayer];

            ExtTMDataSet.GKHistoryDataTable table = History.GetGKHistory(playerDatarow.PlayerID);

            FillBaseData(playerDatarow);

            FillPlayerData((ExtTMDataSet.GKHistoryRow)table.Rows[table.Rows.Count - 1]);

            FillSkillGraph(table);

            FillASIGraph(table);

            FillTIGraph(table);

            FillInjuriesGraph(table);

            FillSpecsGraph(table);

            FillPlayerInfo(true);

            string expression = "(PlayerID = " + playerDatarow.PlayerID + ")";
            ChampDS.PlyStatsRow[] drs = (ChampDS.PlyStatsRow[])plyStatsTable.Select(expression);

            FillSeasonCombo(drs);
            chkShowPosition.Checked = Program.Setts.ShowPosition;
            chkNormalized.Checked = Program.Setts.ShowStatsNormalized;

            FillMatchStatsGraph(plyStatsTable);

            playerInfoChanged = false;

            FillPlayerBar(playerDatarow.PlayerID);

            FillTagsBar(History.reportParser);

            if (tabControl1.SelectedTab == tabPlayerBrowser)
            {
                tsbLoadPlayerPage_Click(null, EventArgs.Empty);
            }

            this.Refresh();
        }

        private void FillTagsBar(ReportParser reportParser)
        {
            SetTagBar(reportParser, tagsBarAgg, "Aggressivity");
            SetTagBar(reportParser, tagsBarPro, "Professionalism");
            SetTagBar(reportParser, tagsBarLea, "Charisma");
            SetTagBar(reportParser, tagsBarPhy, "Physique");
            SetTagBar(reportParser, tagsBarTac, "Tactics");
            SetTagBar(reportParser, tagsBarTec, "Technics");
        }

        private void SetTagBar(ReportParser reportParser, TagsBar tagsBar, string report)
        {
            tagsBar.Tags = new List<string>();
            if (!reportParser.Dict.ContainsKey(report))
                return;
            int cnt = reportParser.Dict[report].Count;
            tagsBar.Min = 1;
            tagsBar.Max = cnt;
            foreach (KeyValuePair<int, string> key in reportParser.Dict[report])
            {
                tagsBar.Tags.Add(key.Value);
            }
            tagsBar.Invalidate();
        }

        private void FillSeasonCombo(ChampDS.PlyStatsRow[] drs)
        {
            List<int> seasons = new List<int>();

            foreach (ChampDS.PlyStatsRow psr in drs)
            {
                if (!seasons.Contains(psr.SeasonID))
                    seasons.Add(psr.SeasonID);
            }

            cmbSeason.Items.Clear();

            foreach (int season in seasons)
            {
                cmbSeason.Items.Add(season);
            }

            if (cmbSeason.Items.Count > 0)
                cmbSeason.SelectedIndex = cmbSeason.Items.Count - 1;
        }

        private void FillMatchStatsGraph(ChampDS.PlyStatsDataTable psDT)
        {
            GraphPane pane = graphPerf.GraphPane;
            pane.CurveList.Clear();

            // Set the title and axis labels
            pane.Title.Text = "Performance History";
            pane.YAxis.Title.Text = "Match Vote";
            pane.XAxis.Title.Text = "Weeks";
            pane.XAxis.Type = AxisType.Date;
            pane.XAxis.Scale.MajorStep = 7;
            pane.XAxis.Scale.MinorStep = 7;
            pane.XAxis.Scale.MajorUnit = DateUnit.Day;
            pane.XAxis.Scale.Format = "TW";

            // Enter some random data values
            string[] MatchTypes = "L,C,F,FL,LL".Split(',');
            int numOfMatchTypes = MatchTypes.Length;
            List<PointPairList> votes = new List<PointPairList>();
            string[][] votesStr = new string[numOfMatchTypes][];

            pane.GraphObjList.Clear();

            if (cmbSeason.Items.Count == 0) return;

            int season = (int)(cmbSeason.SelectedItem);

            ExtTMDataSet.PortieriNSkillRow playerDatarow = (ExtTMDataSet.PortieriNSkillRow)GDT.Rows[iActualPlayer];
            string expression = "(PlayerID = " + playerDatarow.PlayerID + ") AND (SeasonID = " + season + ")";
            ChampDS.PlyStatsRow[] drs = (ChampDS.PlyStatsRow[])plyStatsTable.Select(expression);

            foreach (ChampDS.PlyStatsRow psr in drs)
            {
                if (psr.IsVotesNull()) continue;
                
                int type = psr.TypeStats;
                if (type > 20) type = 4;
                else if (type > 10) type = 1;
                else if (type == 5) type = 0;
                votesStr[type] = psr.Votes.Split(';');
            }

            XDate xdateMin = XDate.XLDayMax;
            XDate xdateMax = XDate.XLDayMin;

            // Fill the axis background with a color gradient
            pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            Color[] colors = {Color.Red, Color.Blue, Color.Green, Color.Violet, 
                Color.Turquoise, Color.Cyan};

            for (int mt = 0; mt < numOfMatchTypes; mt++)
            {
                votes.Add(new PointPairList());

                if (votesStr[mt] == null) continue;

                for (int i = 0; i < votesStr[mt].Length; i++)
                {
                    string[] part = votesStr[mt][i].Split('|');

                    DateTime dt = TmWeek.SWDtoDateTime(part[0]);
                    XDate xdate = new XDate(dt);

                    if (xdate < xdateMin) xdateMin = xdate;
                    if (xdate > xdateMax) xdateMax = xdate;

                    float vote;
                    if (chkNormalized.Checked)
                        vote = float.Parse(part[3]);
                    else
                        vote = float.Parse(part[2]);

                    votes[mt].Add(xdate, vote, part[1]);
                }

                votes[mt].Sort(SortType.XValues);

                LineItem myCurve = pane.AddCurve(MatchTypes[mt], votes[mt], colors[mt]);
                myCurve.Symbol.Fill = new Fill(Color.White);
            }

            // Manually set the x axis range
            pane.YAxis.Scale.Min = 0;
            pane.YAxis.Scale.Max = 10;
            pane.XAxis.Scale.Min = xdateMin;
            pane.XAxis.Scale.Max = xdateMax;

            if (xdateMin == xdateMax)
            {
                pane.XAxis.Scale.Min -= 7;
                pane.XAxis.Scale.Max += 7;
            }

            pane.YAxis.Scale.MajorStep = 2;
            pane.YAxis.Scale.MinorStep = 1;
            if (pane.YAxis.Scale.MajorStep == 0) pane.YAxis.Scale.MajorStep = 1;
            if (pane.YAxis.Scale.MinorStep == 0) pane.YAxis.Scale.MinorStep = 1;

            pane.XAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.IsVisible = true;

            if (chkShowPosition.Checked) CreateBarLabels(pane);

            graphPerf.Refresh();
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

        private void FillASIGraph(ExtTMDataSet.GKHistoryDataTable table)
        {
            GraphPane pane = graphASI.GraphPane;
            pane.CurveList.Clear();

            // Set the title and axis labels
            pane.Title.Text = "ASI History";
            pane.YAxis.Title.Text = "ASI";
            pane.Y2Axis.Title.Text = "Delta ASI";
            pane.XAxis.Title.Text = "Weeks";

            // Enter some random data values
            PointPairList dataASI = new PointPairList();
            PointPairList deltaASI = new PointPairList();
            double dDataASI;
            double xdate = 0.0;
            double xdelta = 0.0;
            double xdate0 = 0.0;
            double xdateN = 0.0;

            double dMax = 0.0;
            double dMin2 = 0.0;
            double dMax2 = 0.0;

            int deltaASIcount = 0;
            int lastASI = 0;
            double lastXdate = 0.0;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                ExtTMDataSet.GKHistoryRow pr = (ExtTMDataSet.GKHistoryRow)table.Rows[i];

                dDataASI = pr.ASI;
                xdate = (double)new XDate(pr.Date);

                if (i == 0)
                {
                    lastASI = pr.ASI;
                    xdate0 = xdate;
                }

                if (lastASI != pr.ASI) deltaASIcount++;

                dMax = Math.Max(dMax, dDataASI);

                dataASI.Add(xdate, dDataASI);

                lastASI = pr.ASI;
            }

            xdateN = xdate;

            int count = 0;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                ExtTMDataSet.GKHistoryRow pr = (ExtTMDataSet.GKHistoryRow)table.Rows[i];

                xdate = (double)new XDate(pr.Date);

                if (i == 0)
                {
                    lastASI = pr.ASI;
                    lastXdate = xdate;
                }

                if (lastASI == pr.ASI) continue;

                dDataASI = (double)(pr.ASI - lastASI);
                xdelta = Utility.TrainingWeeksInDates(lastXdate, xdate);
                // xdelta = (double)(((int)(xdate - lastXdate))/7);
                dMax2 = Math.Max(dMax2, dDataASI / xdelta);
                dMin2 = Math.Min(dMin2, dDataASI / xdelta);

                if (xdelta == 0) xdelta = 1;
                deltaASI.Add(xdate, dDataASI / xdelta);

                lastASI = pr.ASI;
                lastXdate = xdate;


                count++;
            }

            // Fill the axis background with a color gradient
            pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            // Generate a red curve with "ASI" in the legend
            LineItem asiCurve = pane.AddCurve("ASI", dataASI, Color.Red);

            // Generate a red curve with "ASI" in the legend
            LineItem deltaAsiCurve = pane.AddCurve("Delta ASI", deltaASI, Color.Blue);
            deltaAsiCurve.IsY2Axis = true;
            deltaAsiCurve.YAxisIndex = 0;

            // Make the symbols opaque by filling them with white
            asiCurve.Symbol.Fill = new Fill(Color.White);

            // Show the x axis grid
            pane.XAxis.Type = AxisType.Date;
            pane.XAxis.Scale.MajorStep = 7;
            pane.XAxis.Scale.MinorStep = 7;
            pane.XAxis.Scale.MajorUnit = DateUnit.Day;
            pane.XAxis.Scale.Format = "TW";
            pane.XAxis.Scale.Min = xdate0;
            pane.XAxis.Scale.Max = xdateN;
            pane.XAxis.MajorGrid.IsVisible = true;

            // Manually set the x axis range
            pane.YAxis.Scale.Min = 0;
            pane.YAxis.Scale.Max = (double)((int)(dMax / 100.0)) * 100.0 + 100;
            pane.YAxis.MajorTic.IsOpposite = false;
            pane.YAxis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            pane.YAxis.MajorGrid.IsZeroLine = false;
            pane.YAxis.Scale.Align = AlignP.Inside;
            pane.YAxis.Scale.MajorStep = (double)((int)((dMax) / 10.0));
            pane.YAxis.Scale.MinorStep = (double)((int)(dMax / 50.0));
            if (pane.YAxis.Scale.MajorStep == 0) pane.YAxis.Scale.MajorStep = 1;
            if (pane.YAxis.Scale.MinorStep == 0) pane.YAxis.Scale.MinorStep = 1;

            pane.Y2Axis.IsVisible = true;
            pane.Y2Axis.Scale.FontSpec.FontColor = Color.Blue;
            pane.Y2Axis.Title.FontSpec.FontColor = Color.Blue;
            pane.Y2Axis.Color = Color.Orange;
            pane.Y2Axis.IsAxisSegmentVisible = true;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            pane.Y2Axis.MajorTic.IsOpposite = false;
            pane.Y2Axis.MinorTic.IsOpposite = false;
            pane.Y2Axis.Scale.Max = dMax2 + (dMax2 - dMin2) / 10.0;
            pane.Y2Axis.Scale.Min = dMin2 - (dMax2 - dMin2) / 10.0;
            pane.Y2Axis.Scale.Align = AlignP.Inside;
            pane.Y2Axis.MajorGrid.IsVisible = true;

            graphASI.AxisChange();
            graphASI.Refresh();
        }

        private void FillInjuriesGraph(ExtTMDataSet.GKHistoryDataTable table)
        {
            GraphPane pane = graphInjuries.GraphPane;
            pane.CurveList.Clear();

            // Set the title and axis labels
            pane.Title.Text = "Injuries History";
            pane.YAxis.Title.Text = "Injuries Level";
            pane.XAxis.Title.Text = "Weeks";
            pane.XAxis.Type = AxisType.Date;
            pane.XAxis.Scale.MajorStep = 7;
            pane.XAxis.Scale.MinorStep = 7;
            pane.XAxis.Scale.MajorUnit = DateUnit.Day;
            pane.XAxis.Scale.Format = "TW";

            // Enter some random data values
            double[] dDataInj = new double[table.Rows.Count];
            double[] xdate = new double[table.Rows.Count];
            double dMin = 1.0;
            double dMax = -1.0;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                ExtTMDataSet.GKHistoryRow pr = (ExtTMDataSet.GKHistoryRow)table.Rows[i];

                dDataInj[i] = (double)pr.Infortunato;
                xdate[i] = (double)new XDate(pr.Date);
                dMin = Math.Min(dMin, dDataInj[i]);
                dMax = Math.Max(dMax, dDataInj[i]);
            }

            // Fill the axis background with a color gradient
            pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            // Generate a red curve with "ASI" in the legend
            LineItem myCurve = pane.AddCurve("Injuries", xdate, dDataInj, Color.Red);

            // Make the symbols opaque by filling them with white
            myCurve.Symbol.Fill = new Fill(Color.White);

            // Manually set the x axis range
            pane.YAxis.Scale.Min = dMin - 1.0;
            pane.YAxis.Scale.Max = dMax + 1.0;
            pane.XAxis.Scale.Min = xdate[0];
            pane.XAxis.Scale.Max = xdate[xdate.Length - 1];

            pane.YAxis.Scale.MajorStep = (double)((int)((dMax) / 10.0));
            pane.YAxis.Scale.MinorStep = (double)((int)(dMax / 50.0));
            if (pane.YAxis.Scale.MajorStep == 0) pane.YAxis.Scale.MajorStep = 1;
            if (pane.YAxis.Scale.MinorStep == 0) pane.YAxis.Scale.MinorStep = 1;
        }

        private void FillBaseData(ExtTMDataSet.PortieriNSkillRow playerDatarow)
        {
            ExtraDS.GiocatoriRow gRow = History.PlayersDS.Giocatori.FindByPlayerID(playerDatarow.PlayerID);
            PlayerName = gRow.Nome;

            if ((gRow.IswBornNull()) || (gRow.wBorn == -9999))
                Age = playerDatarow.Età.ToString() + "y -m";
            else
            {
                TmWeek tmw = new TmWeek(gRow.wBorn);
                Age = tmw.ToAge(DateTime.Now);
            }

            if (!gRow.IsWageNull())
                Wage = gRow.Wage;
            else if (playerDatarow.IsWageNull())
                Wage = 0;
            else
                Wage = playerDatarow.Wage;

            if (!gRow.IsRoutineNull())
                Routine = gRow.Routine;
            else
                Routine = 0;
        }

        private void FillPlayerData(ExtTMDataSet.GKHistoryRow dataRow)
        {
            this.gkData1.GKRow = dataRow;

            ASI = dataRow.ASI;
        }

        internal void FillSkillGraph(ExtTMDataSet.GKHistoryDataTable table)
        {
            MasterPane master = graphSkills.MasterPane;

            // Remove the default pane that comes with the ZedGraphControl.MasterPane
            master.PaneList.Clear();

            // Set the master pane title
            master.Title.Text = "Player History";
            master.Title.IsVisible = true;

            // Fill the axis background with a color gradient
            master.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            // Set the margins and the space between panes to 10 points
            master.Margin.All = 10;
            master.InnerPaneGap = 10;

            double[] dDataFor = new double[table.Rows.Count];
            double[] dDataVel = new double[table.Rows.Count];
            double[] dDataRes = new double[table.Rows.Count];
            double[] dDataPre = new double[table.Rows.Count];
            double[] dDataUno = new double[table.Rows.Count];
            double[] dDataRif = new double[table.Rows.Count];
            double[] dDataAer = new double[table.Rows.Count];
            double[] dDataEle = new double[table.Rows.Count];
            double[] dDataCom = new double[table.Rows.Count];
            double[] dDataTir = new double[table.Rows.Count];
            double[] dDataLan = new double[table.Rows.Count];
            double[] xdate = new double[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++)
            {
                ExtTMDataSet.GKHistoryRow pr = (ExtTMDataSet.GKHistoryRow)table.Rows[i];

                dDataFor[i] = (double)pr.For;
                dDataVel[i] = (double)pr.Vel;
                dDataRes[i] = (double)pr.Res;
                dDataPre[i] = (double)pr.Pre;
                dDataUno[i] = (double)pr.Uno;
                dDataRif[i] = (double)pr.Rif;
                dDataAer[i] = (double)pr.Aer;
                dDataEle[i] = (double)pr.Ele;
                dDataCom[i] = (double)pr.Com;
                dDataTir[i] = (double)pr.Tir;
                dDataLan[i] = (double)pr.Lan;
                xdate[i] = (double)new XDate(pr.Date);
            }

            LineItem myCurve;

            // 1o grafico
            {
                GraphPane pane = new GraphPane();

                pane.Title.Text = "Physic Skills";
                pane.YAxis.Title.Text = "Skill Value";
                pane.XAxis.Title.Text = "Weeks";
                pane.XAxis.Type = AxisType.Date;
                pane.XAxis.Scale.MajorStep = 7;
                pane.XAxis.Scale.MinorStep = 7;
                pane.XAxis.Scale.MajorUnit = DateUnit.Day;
                pane.XAxis.Scale.Format = "TW";

                // Fill the axis background with a color gradient
                pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);
                // pane.BaseDimension = 6.0F;

                // Generate a red curve with "For" in the legend
                myCurve = pane.AddCurve("For", xdate, dDataFor, Color.DarkGreen);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Diamond;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Res" in the legend
                myCurve = pane.AddCurve("Res", xdate, dDataRes, Color.Indigo);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Circle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Vel" in the legend
                myCurve = pane.AddCurve("Vel", xdate, dDataVel, Color.Turquoise);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Triangle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Manually set the x axis range
                pane.YAxis.Scale.Min = 0;
                pane.YAxis.Scale.Max = 20;
                pane.YAxis.Scale.MajorStep = 5;
                pane.YAxis.Scale.MinorStep = 1;

                master.Add(pane);
            }

            // 2o grafico
            {
                GraphPane pane = new GraphPane();

                pane.Title.Text = "Goal Defense Skills";
                pane.YAxis.Title.Text = "Skill Value";
                pane.XAxis.Title.Text = "Weeks";
                pane.XAxis.Type = AxisType.Date;
                pane.XAxis.Scale.MajorStep = 7;
                pane.XAxis.Scale.MinorStep = 7;
                pane.XAxis.Scale.MajorUnit = DateUnit.Day;
                pane.XAxis.Scale.Format = "TW";

                // Fill the axis background with a color gradient
                pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);
                // pane.BaseDimension = 6.0F;

                // Generate a red curve with "Pre" in the legend
                myCurve = pane.AddCurve("Pre", xdate, dDataPre, Color.Blue);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Circle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Uno" in the legend
                myCurve = pane.AddCurve("Uno", xdate, dDataUno, Color.Green);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Diamond;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Rif" in the legend
                myCurve = pane.AddCurve("Rif", xdate, dDataRif, Color.Brown);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Triangle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Manually set the x axis range
                pane.YAxis.Scale.Min = 0;
                pane.YAxis.Scale.Max = 20;
                pane.YAxis.Scale.MajorStep = 5;
                pane.YAxis.Scale.MinorStep = 1;

                master.Add(pane);
            }

            // 3o grafico
            {
                GraphPane pane = new GraphPane();

                pane.Title.Text = "Area Defense Skills";
                pane.YAxis.Title.Text = "Skill Value";
                pane.XAxis.Title.Text = "Weeks";
                pane.XAxis.Type = AxisType.Date;
                pane.XAxis.Scale.MajorStep = 7;
                pane.XAxis.Scale.MinorStep = 7;
                pane.XAxis.Scale.MajorUnit = DateUnit.Day;
                pane.XAxis.Scale.Format = "TW";

                // Fill the axis background with a color gradient
                pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);
                // pane.BaseDimension = 6.0F;

                // Generate a red curve with "Aer" in the legend
                myCurve = pane.AddCurve("Aer", xdate, dDataAer, Color.Black);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Circle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Ele" in the legend
                myCurve = pane.AddCurve("Ele", xdate, dDataEle, Color.Cyan);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Diamond;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Manually set the x axis range
                pane.YAxis.Scale.Min = 0;
                pane.YAxis.Scale.Max = 20;
                pane.YAxis.Scale.MajorStep = 5;
                pane.YAxis.Scale.MinorStep = 1;

                master.Add(pane);
            }

            // 4o grafico
            {
                GraphPane pane = new GraphPane();

                pane.Title.Text = "Offensive Skills";
                pane.YAxis.Title.Text = "Skill Value";
                pane.XAxis.Title.Text = "Weeks";
                pane.XAxis.Type = AxisType.Date;
                pane.XAxis.Scale.MajorStep = 7;
                pane.XAxis.Scale.MinorStep = 7;
                pane.XAxis.Scale.MajorUnit = DateUnit.Day;
                pane.XAxis.Scale.Format = "TW";

                // Fill the axis background with a color gradient
                pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);
                // pane.BaseDimension = 6.0F;

                // Generate a red curve with "Com" in the legend
                myCurve = pane.AddCurve(Current.Language.Com, xdate, dDataCom, Color.Blue);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Diamond;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Tir" in the legend
                myCurve = pane.AddCurve("Tir", xdate, dDataTir, Color.Red);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Square;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Generate a red curve with "Lan" in the legend
                myCurve = pane.AddCurve("Lan", xdate, dDataLan, Color.SlateGray);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Triangle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Manually set the x axis range
                pane.YAxis.Scale.Min = 0;
                pane.YAxis.Scale.Max = 20;
                pane.YAxis.Scale.MajorStep = 5;
                pane.YAxis.Scale.MinorStep = 1;

                master.Add(pane);
            }

            // Tell ZedGraph to auto layout all the panes
            using (Graphics g = graphSkills.CreateGraphics())
            {
                master.SetLayout(g, PaneLayout.SquareColPreferred);
                master.AxisChange(g);
            }
        }

        internal void FillSpecsGraph(ExtTMDataSet.GKHistoryDataTable table)
        {
            MasterPane master = graphSpecs.MasterPane;

            // Remove the default pane that comes with the ZedGraphControl.MasterPane
            master.PaneList.Clear();

            // Set the master pane title
            master.Title.Text = "Specialities History";
            master.Title.IsVisible = true;

            // Fill the axis background with a color gradient
            master.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            // Set the margins and the space between panes to 10 points
            master.Margin.All = 10;
            master.InnerPaneGap = 10;

            double[] dGK = new double[table.Rows.Count];
            double[] xdate = new double[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++)
            {
                ExtTMDataSet.GKHistoryRow pr = (ExtTMDataSet.GKHistoryRow)table.Rows[i];

                dGK[i] = pr.PO;
                xdate[i] = (double)new XDate(pr.Date);
            }

            LineItem myCurve;

            // 1o grafico
            {
                GraphPane pane = new GraphPane();

                pane.Title.Text = "GK Speciality";
                pane.YAxis.Title.Text = "Specs Value";
                pane.XAxis.Title.Text = "Weeks";
                pane.XAxis.Type = AxisType.Date;
                pane.XAxis.Scale.MajorStep = 7;
                pane.XAxis.Scale.MinorStep = 7;
                pane.XAxis.Scale.MajorUnit = DateUnit.Day;
                pane.XAxis.Scale.Format = "TW";

                // Fill the axis background with a color gradient
                pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

                // Generate a red curve with "For" in the legend
                myCurve = pane.AddCurve("GK", xdate, dGK, Color.DarkGreen);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Circle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Manually set the x axis range
                pane.YAxis.Scale.MajorStep = 5;
                pane.YAxis.Scale.MinorStep = 1;

                master.Add(pane);
            }

            // Tell ZedGraph to auto layout all the panes
            using (Graphics g = graphSkills.CreateGraphics())
            {
                master.SetLayout(g, PaneLayout.SquareColPreferred);
                master.AxisChange(g);
            }
        }

        private void FillTIGraph(ExtTMDataSet.GKHistoryDataTable table)
        {
            ExtTMDataSet.PortieriNSkillRow playerDatarow = (ExtTMDataSet.PortieriNSkillRow)GDT.Rows[iActualPlayer];
            ExtraDS.GiocatoriRow gRow = History.PlayersDS.Giocatori.FindByPlayerID(playerDatarow.PlayerID);

            if ((gRow.IsTSINull()) || (gRow.TSI == ""))
            {
                gRow.TSI = TmWeek.ToSWDString(DateTime.Today);
            }

            WeekHistorical whTI = new WeekHistorical(gRow.TSI);

            DateTime firstTI = whTI.lastWeek.ToDate();

            GraphPane pane = graphTI.GraphPane;
            pane.CurveList.Clear();

            // Set the title and axis labels
            if (chkShowTGI.Checked)
            {
                pane.Title.Text = "TI and TGI History";
                pane.YAxis.Title.Text = "TI and TGI";
            }
            else
            {
                pane.Title.Text = "TI History";
                pane.YAxis.Title.Text = "TI";
            }
            pane.XAxis.Title.Text = "Weeks";

            // Enter some random data values
            PointPairList dataTI = new PointPairList();
            PointPairList dataTGI = new PointPairList();

            double dMax = 0.0;
            double dMin2 = 0.0;
            double dMax2 = 0.0;

            double xdate = 0.0;
            double xdate0 = 0.0;

            int tsiCount = whTI.Count;
            for (int i = 0; i < tsiCount; i++)
            {
                double dDataTI = 0.0;

                if (float.IsNaN(whTI[i]))
                    continue;
                else
                    dDataTI = (double)(decimal)(whTI[i]);

                xdate = (double)new XDate(firstTI + TimeSpan.FromDays(7.0 * i));
                dataTI.Add(xdate, dDataTI);

                dMax = Math.Max(dMax, dDataTI);
            }

            int lastASI = 0;
            double lastXdate = 0.0;

            if (chkShowTGI.Checked)
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    ExtTMDataSet.GKHistoryRow pr = (ExtTMDataSet.GKHistoryRow)table.Rows[i];
                    xdate = (double)new XDate(pr.Date);

                    if (i == 0)
                    {
                        lastASI = pr.ASI;
                        lastXdate = xdate;
                        xdate0 = xdate;
                    }

                    if (lastASI == pr.ASI) continue;

                    double dDataASI = (double)(pr.ASI - lastASI);
                    double xdelta = Utility.TrainingWeeksInDates(lastXdate, xdate);
                    if (xdelta == 0) continue;

                    double deltaASI = dDataASI / xdelta;
                    double TGI = deltaASI * 200 / ((pr.ASI + lastASI) / 2.0);
                    dataTGI.Add(xdate, TGI);

                    dMax2 = Math.Max(dMax2, TGI);
                    dMin2 = Math.Min(dMin2, TGI);

                    lastASI = pr.ASI;
                    lastXdate = xdate;
                }

            // Fill the axis background with a color gradient
            pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            // Generate a red curve with "TI" in the legend
            LineItem myCurve1 = pane.AddCurve("TI", dataTI, Color.Red);

            LineItem myCurve2 = null;
            if (chkShowTGI.Checked)
                myCurve2 = pane.AddCurve("TGI", dataTGI, Color.Blue);

            // Make the symbols opaque by filling them with white
            myCurve1.Symbol.Fill = new Fill(Color.White);

            // Manually set the x axis range
            pane.YAxis.Scale.Min = 0;

            if (dataTI.Count > 0)
            {
                pane.XAxis.Scale.Min = dataTI[0].X;
                pane.XAxis.Scale.Max = dataTI[dataTI.Count - 1].X;
            }
            else
            {
                pane.XAxis.Scale.Min = double.MaxValue;
                pane.XAxis.Scale.Max = double.MinValue;
            }

            if (chkShowTGI.Checked)
                if (dataTGI.Count > 0)
                {
                    pane.XAxis.Scale.Min = Math.Min(dataTGI[0].X, pane.XAxis.Scale.Min);
                    pane.XAxis.Scale.Max = Math.Max(dataTGI[dataTGI.Count - 1].X, pane.XAxis.Scale.Max);
                }

            // Show the x axis grid
            pane.XAxis.Type = AxisType.Date;
            pane.XAxis.Scale.MajorStep = 7;
            pane.XAxis.Scale.MinorStep = 7;
            pane.XAxis.Scale.MajorUnit = DateUnit.Day;
            pane.XAxis.Scale.Format = "TW";
            pane.XAxis.MajorGrid.IsVisible = true;

            // Manually set the x axis range
            pane.YAxis.Scale.Min = dMin2;
            if (chkShowTGI.Checked)
                pane.YAxis.Scale.Max = Math.Max(dMax, dMax2);
            else
                pane.YAxis.Scale.Max = dMax;
            pane.YAxis.MajorTic.IsOpposite = false;
            pane.YAxis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            pane.YAxis.MajorGrid.IsZeroLine = true;
            pane.YAxis.Color = Color.Orange;
            pane.YAxis.Scale.Align = AlignP.Inside;
            pane.YAxis.Scale.MajorStep = (double)((int)((pane.YAxis.Scale.Max) / 10.0));
            pane.YAxis.Scale.MinorStep = (double)((int)(pane.YAxis.Scale.MajorStep / 5.0));
            if (pane.YAxis.Scale.MajorStep == 0) pane.YAxis.Scale.MajorStep = 1;
            if (pane.YAxis.Scale.MinorStep == 0) pane.YAxis.Scale.MinorStep = 1;

            graphTI.AxisChange();
            graphTI.Refresh();
        }


        private void tabSkills_Resize(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            iActualPlayer++;

            if (iActualPlayer > GDT.Rows.Count - 1)
            {
                iActualPlayer = 0;
            }

            Initialize();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            iActualPlayer--;

            if (iActualPlayer < 0)
            {
                iActualPlayer = GDT.Rows.Count - 1;
            }

            Initialize();
        }

        private void FillPlayerInfo(bool reset)
        {
            ExtTMDataSet.PortieriNSkillRow playerDatarow = (ExtTMDataSet.PortieriNSkillRow)GDT.Rows[iActualPlayer];
            ExtraDS.GiocatoriRow gRow = History.PlayersDS.Giocatori.FindByPlayerID(playerDatarow.PlayerID);
            txtNotes.Text = gRow.Note;

            scoutsNReviews.Scouts.Clear();
            foreach (ExtraDS.ScoutsRow sr in History.PlayersDS.Scouts)
            {
                ScoutsNReviews.ScoutsRow srn = scoutsNReviews.Scouts.NewScoutsRow();
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
            scoutsNReviews.FillTables(gRow, History.reportParser);

            reviewDataTableBindingSource.Filter = "PlayerID=" + gRow.PlayerID.ToString();

            txtNotes.Text = gRow.Note;

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

            if (!gRow.IsAggressivityNull())
                tagsBarAgg.Value = (decimal)gRow.Aggressivity / 2M;
            else
                tagsBarAgg.Value = 0;

            if (!gRow.IsProfessionalismNull())
                tagsBarPro.Value = (decimal)gRow.Professionalism / 2M;
            else
                tagsBarPro.Value = 0;

            if (!gRow.IsLeadershipNull())
                tagsBarLea.Value = (decimal)gRow.Leadership / 2M;
            else
                tagsBarLea.Value = 0;

            tagsBarPhy.Value = (decimal)gRow.Physics / 5M;
            tagsBarTac.Value = (decimal)gRow.Tactics / 5M;
            tagsBarTec.Value = (decimal)gRow.Technics / 5M;

            string gameTable = "";
            if (!gRow.IsGameTableNull())
                gameTable = gRow.GameTable;
            gameTableDS.LoadSeasonsStrings(gameTable);
        }

        private void StorePlayerInfo()
        {
            ExtTMDataSet.PortieriNSkillRow playerDatarow = (ExtTMDataSet.PortieriNSkillRow)GDT.Rows[iActualPlayer];
            ExtraDS.GiocatoriRow gRow = History.PlayersDS.Giocatori.FindByPlayerID(playerDatarow.PlayerID);
            gRow.Note = txtNotes.Text;
        }


        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            playerInfoChanged = true;
        }

        private void playersMainPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtTMDataSet.PortieriNSkillRow playerDatarow = (ExtTMDataSet.PortieriNSkillRow)GDT.Rows[iActualPlayer];
            Clipboard.SetText("http://trophymanager.com/players/" + playerDatarow.PlayerID.ToString());
        }

        private void playersScoutPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtTMDataSet.PortieriNSkillRow playerDatarow = (ExtTMDataSet.PortieriNSkillRow)GDT.Rows[iActualPlayer];
            Clipboard.SetText("http://trophymanager.com/players/" + playerDatarow.PlayerID.ToString() + "&scout_mode=1");
        }

        private void openPlayerPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPlayerBrowser;
            tsbLoadPlayerPage_Click(sender, e);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string arg = "http://trophymanager.com/club/11816/";

            if (Program.Setts.UseTMRBrowser)
            {
                string processName = Application.StartupPath + "/TMRBrowser.exe";
                FileInfo fi = new FileInfo(processName);

                if (!fi.Exists)
                    MessageBox.Show(Current.Language.TheTMRBrowserTMRBrowserExeDoesnTExistAtTheGivenPath +
                        Application.StartupPath + ")", "TM Recorder", MessageBoxButtons.OK);
                else
                    Process.Start(processName, arg);
            }
            else
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(arg);
                Process.Start(startInfo);
            }
        }

        private void chkShowTGI_CheckedChanged(object sender, EventArgs e)
        {
            ExtTMDataSet.PortieriNSkillRow playerDatarow = (ExtTMDataSet.PortieriNSkillRow)GDT.Rows[iActualPlayer];
            ExtTMDataSet.GKHistoryDataTable table = History.GetGKHistory(playerDatarow.PlayerID);
            FillTIGraph(table);
            Program.Setts.ShowTGI = chkShowTGI.Checked;
            Program.Setts.Save();
        }

        private void tsbComputeGrowth_Click(object sender, EventArgs e)
        {
            ExtTMDataSet.PortieriNSkillRow playerDatarow = (ExtTMDataSet.PortieriNSkillRow)GDT.Rows[iActualPlayer];
            ExtTMDataSet.GKHistoryDataTable table = History.GetGKHistory(playerDatarow.PlayerID);

            ExtraDS.GiocatoriRow gRow = History.PlayersDS.Giocatori.FindByPlayerID(playerDatarow.PlayerID);
            

            ComputeBloom cb = new ComputeBloom();
            cb.ActualASI = gRow.ASI;
            cb.CurrentSkillSum = (decimal)Tm_Utility.ASItoSkSum((decimal)gRow.ASI, true);
            cb.RealSkillSum = playerDatarow.SkillSum;

            WeekHistorical whTI = new WeekHistorical(gRow.TSI);

            cb.ActualTI = (decimal)whTI.ActualTI;
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

            cb.isGK = true;
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

        private void cmbSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkNormalized_CheckedChanged(null, EventArgs.Empty);
        }

        private void chkNormalized_CheckedChanged(object sender, EventArgs e)
        {
            ExtTMDataSet.PortieriNSkillRow playerDatarow = (ExtTMDataSet.PortieriNSkillRow)GDT.Rows[iActualPlayer];
            FillMatchStatsGraph(plyStatsTable);

            Program.Setts.ShowStatsNormalized = chkNormalized.Checked;
            Program.Setts.ShowPosition = chkShowPosition.Checked;
            Program.Setts.Save();
        }

        string navigationAddress = "";
        string startnavigationAddress = "";
        private void tsbLoadPlayerPage_Click(object sender, EventArgs e)
        {
            navigationAddress = "http://trophymanager.com/players/" +
                actPlayerID.ToString();
            if (navigationType == NavigationType.NavigateReports)
                navigationAddress += "/#/page/scout/";
            webBrowser.Navigate(navigationAddress);
            startnavigationAddress = navigationAddress;
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

        private void tsbImport_Click(object sender, EventArgs e)
        {
            string doctext = "";

            if (startnavigationAddress == "") return;

            HtmlElementCollection hmtlElColl = webBrowser.Document.All;

            try
            {
                if (HTML_Parser.GetNumberAfter(startnavigationAddress, "http://trophymanager.com/players/") != "-1")
                {
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

            if (HTML_Parser.GetNumberAfter(startnavigationAddress, "http://trophymanager.com/players/") != "-1")
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

            ExtTMDataSet.PortieriNSkillRow playerDatarow = (ExtTMDataSet.PortieriNSkillRow)GDT.Rows[iActualPlayer];
            ExtraDS.GiocatoriRow gRow = History.PlayersDS.Giocatori.FindByPlayerID(playerDatarow.PlayerID);

            ExtraDS.ParsePlayerPage_NewTM(page, ref gRow, History.reportParser);

            // Aggiorna i dati di basi
            gRow.FPn = Tm_Utility.FPToNumber(gRow.FP);
            FillBaseData(playerDatarow);

            isDirty = true;

            ExtTMDataSet.GKHistoryDataTable table = History.GetGKHistory(playerDatarow.PlayerID);
            FillTIGraph(table);

            gRow.SetAddedSkill(scoutsNReviews, History.reportParser);

            FillPlayerInfo(false);

            gRow.isDirty = true;
        }

        private void navigateProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbNavigationType.Text = navigateProfilesToolStripMenuItem.Text;
            tsbNavigationType.Image = navigateProfilesToolStripMenuItem.Image;

            if (navigationType != NavigationType.NavigateProfiles)
            {
                navigationType = NavigationType.NavigateProfiles;
                navigationAddress = "http://trophymanager.com/players/" +
                    actPlayerID.ToString();
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
            int maxProgress = (int)e.MaximumProgress;
            if (maxProgress == 0) maxProgress = 1;
            int perc = (int)((e.CurrentProgress * 100) / maxProgress);
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
                navigationAddress = "http://trophymanager.com/matches/" + kampid + "/";
                webBrowser.Navigate(navigationAddress);
                startnavigationAddress = navigationAddress;
            }
            else if (e.Url.ToString().StartsWith("http://trophymanager.com/"))
            {
                navigationAddress = e.Url.ToString();
                startnavigationAddress = navigationAddress;

                if (startnavigationAddress.Contains("http://trophymanager.com/players/"))
                {

                    lastBarPlayer = int.Parse(HTML_Parser.GetNumberAfter(startnavigationAddress, "/players/"));

                    if (lastBarPlayer != -1)
                        FillPlayerBar(lastBarPlayer);
                    tsBrowsePlayers.Visible = true;
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
            ExtTMDataSet.PortieriNSkillRow gRow = (ExtTMDataSet.PortieriNSkillRow)GDT.FindByPlayerID(playerID);

            if (gRow == null)
            {
                tsBrowsePlayers.Visible = false;
                return;
            }

            tsBrowsePlayers.Visible = true;

            //tsbNumberOfReviews.Text = gRow.ScoutReviews.Length + " Scout Reviews stored";

            tsbPlayers.Text = "[GK] " + gRow.Nome.Split('|')[0];

            AddMenuItem(tsbPlayers, "", null);
            for (int i = 0; i < GDT.Count; i++)
            {
                ToolStripItem tsi = new ToolStripMenuItem();
                tsi.Text = "[GK] " + GDT[i].Nome.Split('|')[0];
                tsi.Tag = GDT[i].PlayerID;
                tsi.Click += ChangePlayer_Click;
                AddMenuItem(tsbPlayers, "GK", tsi);
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
                gKToolStripMenuItem.DropDownItems.Clear();
                //dDefendersToolStripMenuItem.DropDownItems.Clear();
                //dMDefenderMidfieldersToolStripMenuItem.DropDownItems.Clear();
                //mMidfieldersToolStripMenuItem.DropDownItems.Clear();
                //oMOffenderMidfieldersToolStripMenuItem.DropDownItems.Clear();
                //fForwardsToolStripMenuItem.DropDownItems.Clear();
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
                    gKToolStripMenuItem.DropDownItems.Add(itsi);
                }
                //if ((fp == "DC") || (fp == "DL") || (fp == "DR"))
                //{
                //    if (!FindItemInMenu(dDefendersToolStripMenuItem, itsi.Text))
                //        dDefendersToolStripMenuItem.DropDownItems.Add(itsi);
                //}
                //if ((fp == "DMC") || (fp == "DML") || (fp == "DMR"))
                //{
                //    if (!FindItemInMenu(dMDefenderMidfieldersToolStripMenuItem, itsi.Text))
                //        dMDefenderMidfieldersToolStripMenuItem.DropDownItems.Add(itsi);
                //}
                //if ((fp == "MC") || (fp == "ML") || (fp == "MR"))
                //{
                //    if (!FindItemInMenu(mMidfieldersToolStripMenuItem, itsi.Text))
                //        mMidfieldersToolStripMenuItem.DropDownItems.Add(itsi);
                //}
                //if ((fp == "OMC") || (fp == "OML") || (fp == "OMR"))
                //{
                //    if (!FindItemInMenu(oMOffenderMidfieldersToolStripMenuItem, itsi.Text))
                //        oMOffenderMidfieldersToolStripMenuItem.DropDownItems.Add(itsi);
                //}
                //if (fp == "FC")
                //{
                //    fForwardsToolStripMenuItem.DropDownItems.Add(itsi);
                //}
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
            Rectangle pos = Program.Setts.GKFormPosition;

            if (pos.Height + pos.Width > 0)
                this.SetDesktopBounds(pos.X, pos.Y, pos.Width, pos.Height);
        }

        private void GKForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Rectangle pos = new Rectangle(DesktopBounds.X, DesktopBounds.Y, DesktopBounds.Width, DesktopBounds.Height);
            Program.Setts.GKFormPosition = pos;
            Program.Setts.Save();
        }
    }
}