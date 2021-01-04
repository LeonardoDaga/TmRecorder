using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using Common;
using NTR_Db;
using System.Linq;
using static TMRecorder.TeamStats;

namespace TMRecorder
{
    public partial class TeamStatsForm : Form
    {
        public TeamStatsForm()
        {
            InitializeComponent();
        }

        public void FillSquadStatsGraphs(TeamStats teamStats)
        {
            FillAgeStatsGraph(teamStats);
            FillTotASIGraph(teamStats);
            FillSkillCountGraph(teamStats);
            FillSquadAgeGraph(teamStats.LastPlayers);
            FillSquadPlayersASIxPosition(teamStats.LastPlayers);
            FillSkillGrowth(teamStats);
            FillTeamFansHistory(teamStats);
            FillTeamValueGraph(teamStats);
        }


        public int[] GetStatsPlyASIxRule(List<ExtraDS.GiocatoriRow> gList, int minASI, int maxASI)
        {
            int[] SpecStats = new int[ExtraDS.specs.Length];

            foreach (ExtraDS.GiocatoriRow gr in gList)
            {
                if (gr.IsASINull()) continue;
                if ((gr.ASI < minASI) || (gr.ASI > maxASI)) continue;

                for (int i = 0; i < ExtraDS.specs.Length; i++)
                {
                    if (gr.FP.Contains(ExtraDS.specs[i]))
                        SpecStats[i]++;
                }
            }

            return SpecStats;
        }


        private void FillSquadPlayersASIxPosition(List<ExtraDS.GiocatoriRow> lastPlayers)
        {

            int[] StatsPlyASILT300 = GetStatsPlyASIxRule(lastPlayers, 0, 300);
            int[] StatsPlyASILT1000 = GetStatsPlyASIxRule(lastPlayers, 301, 1000);
            int[] StatsPlyASIGT1000 = GetStatsPlyASIxRule(lastPlayers, 1001, 10000);
            int[] StatsPlyASIGT10000 = GetStatsPlyASIxRule(lastPlayers, 10001, 100000);
            int[] StatsPlyASIGT100000 = GetStatsPlyASIxRule(lastPlayers, 100001, 10000000);

            GraphPane pane = graphSquadASI.GraphPane;
            pane.CurveList.Clear();
            pane.GraphObjList.Clear();

            // Set the title and axis labels
            pane.Title.Text = "Squad Players ASI x Position";
            pane.YAxis.Title.Text = "Number Of Players";
            pane.XAxis.Title.Text = "Position";

            // Enter some random data values
            double[] list1 = new double[ExtraDS.specs.Length];
            double[] list2 = new double[ExtraDS.specs.Length];
            double[] list3 = new double[ExtraDS.specs.Length];
            double[] list4 = new double[ExtraDS.specs.Length];
            double[] list5 = new double[ExtraDS.specs.Length];

            double count1 = 0;
            double count2 = 0;
            double count3 = 0;
            double count4 = 0;
            double count5 = 0;

            double max = 0;
            for (int i = 0; i < ExtraDS.specs.Length; i++)
            {
                count1 = (double)StatsPlyASILT300[i];
                count2 = (double)StatsPlyASILT1000[i];
                count3 = (double)StatsPlyASIGT1000[i];
                count4 = (double)StatsPlyASIGT10000[i];
                count5 = (double)StatsPlyASIGT100000[i];

                double sum = count1 + count2 + count3 + count4 + count5;
                if (max < sum) max = sum;

                list1[i] = count1;
                list2[i] = count2;
                list3[i] = count3;
                list4[i] = count4;
                list5[i] = count5;
            }

            BarItem myCurve1 = pane.AddBar("Ply x Position < 300 ASI", null, list1, Color.Yellow);
            BarItem myCurve2 = pane.AddBar("Ply x Position < 1000 ASI", null, list2, Color.LightGreen);
            BarItem myCurve3 = pane.AddBar("Ply x Position > 1000 ASI", null, list3, Color.Orange);
            BarItem myCurve4 = pane.AddBar("Ply x Position > 10000 ASI", null, list4, Color.OrangeRed);
            BarItem myCurve5 = pane.AddBar("Ply x Position > 100000 ASI", null, list5, Color.Purple);

            // Fill the axis background with a color gradient
            pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            // Draw the X tics between the labels instead of at the labels
            pane.XAxis.Scale.MajorStep = 1;

            // Make the bars horizontal by setting the BarBase to "Y"
            pane.BarSettings.Base = BarBase.X;
            pane.BarSettings.Type = BarType.Stack;

            // Set the YAxis labels
            pane.XAxis.Scale.TextLabels = ExtraDS.specs;
            // Set the YAxis to Text type
            pane.XAxis.Type = AxisType.Text;

            // expand the range of the Y axis slightly to accommodate the labels
            pane.YAxis.Scale.Max = max * 1.33;
            pane.XAxis.Scale.Max = 13.5;

            graphSquadASI.AxisChange();

            // Create a label for each bar
            CreateBarLabels(pane, true, "N0");

            graphSquadASI.Refresh();
        }


        private void FillSquadASIGraph(ExtraDS extraDS)
        {
            int[] StatsAge = extraDS.GetStatsAge();
            int[] StatsASI = extraDS.GetStatsASI();

            GraphPane pane = graphSquadASI.GraphPane;
            pane.CurveList.Clear();
            pane.GraphObjList.Clear();

            // Set the title and axis labels
            pane.Title.Text = "Squad Mean ASI x Age";
            pane.YAxis.Title.Text = "ASI";
            pane.XAxis.Title.Text = "Age";

            // Enter some random data values
            PointPairList list = new PointPairList();

            double count = 0;

            double max = 0;
            for (int i = 0; i < StatsASI.Length - 2; i++)
            {
                if (StatsAge[i + 2] > 0)
                    count = (double)StatsASI[i + 2] / (double)StatsAge[i + 2];
                else
                    count = 0;

                if (max < count) max = count;
                list.Add((double)(StatsASI[0] + i), count);
            }

            BarItem myCurve = pane.AddBar("Mean ASI x Age", list, Color.Blue);

            // Fill the axis background with a color gradient
            pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            // expand the range of the Y axis slightly to accommodate the labels
            pane.YAxis.Scale.Max = max * 1.33;
            pane.XAxis.Scale.Min = StatsASI[0] - 1;
            pane.XAxis.Scale.Max = StatsASI[1] + 1;

            graphSquadASI.AxisChange();

            // Create a label for each bar
            CreateBarLabels(pane, false, "N0");

            graphSquadASI.Refresh();
        }

        public int[] GetStatsAge(List<ExtraDS.GiocatoriRow> gList, int minASI, int maxASI)
        {
            int minAge = 100;
            int maxAge = 0;

            if (gList.Count == 0) return null;

            foreach (ExtraDS.GiocatoriRow gr in gList)
            {
                if (gr.IsEtàNull()) continue;
                if (minAge > gr.Età) minAge = gr.Età;
                if (maxAge < gr.Età) maxAge = gr.Età;
            }

            int[] AgeStats = new int[maxAge - minAge + 3];
            AgeStats[0] = minAge;
            AgeStats[1] = maxAge;

            foreach (ExtraDS.GiocatoriRow gr in gList)
            {
                if (gr.IsEtàNull()) continue;
                if (gr.IsASINull()) continue;
                if ((gr.ASI < minASI) || (gr.ASI > maxASI)) continue;

                AgeStats[2 + gr.Età - minAge]++;
            }

            return AgeStats;
        }

        private void FillSquadAgeGraph(List<ExtraDS.GiocatoriRow> lastPlayers)
        {
            int[] StatsAgeASILT300 = GetStatsAge(lastPlayers, 0, 300);
            int[] StatsAgeASILT1000 = GetStatsAge(lastPlayers, 301, 1000);
            int[] StatsAgeASIGT1000 = GetStatsAge(lastPlayers, 1001, 10000);
            int[] StatsAgeASIGT10000 = GetStatsAge(lastPlayers, 10001, 100000);
            int[] StatsAgeASIGT100000 = GetStatsAge(lastPlayers, 100001, 10000000);

            if (StatsAgeASILT300 == null) return;

            GraphPane pane = graphSquadAge.GraphPane;
            pane.CurveList.Clear();
            pane.GraphObjList.Clear();

            // Set the title and axis labels
            pane.Title.Text = "Squad Age";
            pane.YAxis.Title.Text = "Number of Players";
            pane.XAxis.Title.Text = "Age";

            // Enter some random data values
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            PointPairList list3 = new PointPairList();
            PointPairList list4 = new PointPairList();
            PointPairList list5 = new PointPairList();

            double count1 = 0;
            double count2 = 0;
            double count3 = 0;
            double count4 = 0;
            double count5 = 0;

            double max = 0;
            for (int i = 0; i < StatsAgeASILT300.Length - 2; i++)
            {
                count1 = (double)StatsAgeASILT300[i + 2];
                count2 = (double)StatsAgeASILT1000[i + 2];
                count3 = (double)StatsAgeASIGT1000[i + 2];
                count4 = (double)StatsAgeASIGT10000[i + 2];
                count5 = (double)StatsAgeASIGT100000[i + 2];

                if (max < count1) max = count1;
                if (max < count2) max = count2;
                if (max < count3) max = count3;
                if (max < count4) max = count4;
                if (max < count5) max = count5;

                list1.Add((double)(StatsAgeASILT300[0] + i), count1);
                list2.Add((double)(StatsAgeASILT300[0] + i), count2);
                list3.Add((double)(StatsAgeASILT300[0] + i), count3);
                list4.Add((double)(StatsAgeASILT300[0] + i), count4);
                list5.Add((double)(StatsAgeASILT300[0] + i), count5);
            }

            BarItem myCurve1 = pane.AddBar("Players x Age < 300 ASI", list1, Color.Yellow);
            BarItem myCurve2 = pane.AddBar("Players x Age < 1.000 ASI", list2, Color.LightGreen);
            BarItem myCurve3 = pane.AddBar("Players x Age > 1.000 ASI", list3, Color.Orange);
            BarItem myCurve4 = pane.AddBar("Players x Age > 10.000 ASI", list4, Color.OrangeRed);
            BarItem myCurve5 = pane.AddBar("Players x Age > 100.000 ASI", list5, Color.Purple);

            // Fill the axis background with a color gradient
            pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);
            pane.BarSettings.Type = BarType.Stack;

            // expand the range of the Y axis slightly to accommodate the labels
            pane.YAxis.Scale.Max = max * 1.33;
            pane.XAxis.Scale.Min = StatsAgeASILT300[0] - 1;
            pane.XAxis.Scale.Max = StatsAgeASILT300[1] + 1;

            graphSquadAge.AxisChange();

            // Create a label for each bar
            CreateBarLabels(pane, true, "N0");

            graphSquadAge.Refresh();
        }

        private void FillTeamValueGraph(TeamStats teamStats)
        {
            MasterPane master = graphTeamValueHistory.MasterPane;

            // Remove the default pane that comes with the ZedGraphControl.MasterPane
            master.PaneList.Clear();

            // Set the master pane title
            master.Title.Text = "Team Selling To Agent Value History";
            master.Title.IsVisible = true;

            // Fill the axis background with a color gradient
            master.Fill = new Fill(Color.FromArgb(240, 255, 240), Color.FromArgb(190, 255, 190), 90F);

            // Set the margins and the space between panes to 10 points
            master.Margin.All = 10;
            master.InnerPaneGap = 10;

            ValueHistoryList valueHistoryList = teamStats.ValueHistory;
            int count = valueHistoryList.Count;

            if (count == 0) return;

            double[] totValue = new double[count];
            double[] valGrowth = new double[count];
            double[] totWage = new double[count];
            double[] cumulatedWage = new double[count];
            double[] xdate = new double[count];
            double dMin = 1000.0;
            double dMax = -1.0;
            int i = 0;

            foreach (var row in valueHistoryList.OrderBy(gh => gh.Date))
            {
                totValue[i] = (double)(row.TotalValue);
                valGrowth[i] = (double)(row.ValueGrowth);
                totWage[i] = (double)(row.Wage);
                cumulatedWage[i] = (double)(row.CumulatedWage);
                xdate[i] = (double)new XDate(row.Date);
                dMax = Math.Max(dMax, row.TotalValue);
                dMin = Math.Min(dMin, row.TotalValue);
                dMax = Math.Max(dMax, row.ValueGrowth);
                dMin = Math.Min(dMin, row.ValueGrowth);
                dMax = Math.Max(dMax, row.Wage);
                dMin = Math.Min(dMin, row.Wage);
                i++;
            }

            LineItem myCurve;

            // 1o grafico
            {
                GraphPane pane = new GraphPane();
                pane.CurveList.Clear();

                // Set the title and axis labels
                pane.Title.Text = "Team StA Value History";
                pane.YAxis.Title.Text = "Value";
                pane.XAxis.Title.Text = "Weeks";
                pane.XAxis.Type = AxisType.Date;
                pane.XAxis.Scale.MajorStep = 7;
                pane.XAxis.Scale.MinorStep = 7;
                pane.XAxis.Scale.MajorUnit = DateUnit.Day;
                pane.XAxis.Scale.Format = "TW";

                // Fill the axis background with a color gradient
                pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

                // Generate a red curve with legend
                myCurve = pane.AddCurve("Team Value", xdate, totValue, Color.Blue);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Circle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                //myCurve = pane.AddCurve("Cumulated Wage", xdate, cumulatedWage, Color.Green);

                //// Make the symbols opaque by filling them with white
                //myCurve.Symbol.Type = SymbolType.Triangle;
                //myCurve.Symbol.Fill = new Fill(Color.White);

                // Manually set the x axis range
                pane.YAxis.Scale.MajorStep = 10000000;
                pane.YAxis.Scale.MinorStep = 5000000;

                pane.YAxis.MajorGrid.IsVisible = true;
                pane.YAxis.MinorGrid.IsVisible = true;

                master.Add(pane);
            }

            // 2o Grafico
            {
                GraphPane pane = new GraphPane();
                pane.CurveList.Clear();

                // Set the title and axis labels
                pane.Title.Text = "Team Value and Wage Growth";
                pane.YAxis.Title.Text = "Value";
                pane.XAxis.Title.Text = "Weeks";
                pane.XAxis.Type = AxisType.Date;
                pane.XAxis.Scale.MajorStep = 7;
                pane.XAxis.Scale.MinorStep = 7;
                pane.XAxis.Scale.MajorUnit = DateUnit.Day;
                pane.XAxis.Scale.Format = "TW";

                myCurve = pane.AddCurve("Value Week Growth", xdate, valGrowth, Color.Red);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Circle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                myCurve = pane.AddCurve("Team Wage", xdate, totWage, Color.Green);

                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Type = SymbolType.Triangle;
                myCurve.Symbol.Fill = new Fill(Color.White);

                // Manually set the x axis range
                pane.YAxis.Scale.MajorStep = 1000000;
                pane.YAxis.Scale.MinorStep = 500000;

                pane.YAxis.MajorGrid.IsVisible = true;
                pane.YAxis.MinorGrid.IsVisible = true;

                master.Add(pane);
            }

            // Tell ZedGraph to auto layout all the panes
            using (Graphics g = graphTeamValueHistory.CreateGraphics())
            {
                master.SetLayout(g, PaneLayout.SquareColPreferred);
                master.AxisChange(g);
            }
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
        private void CreateBarLabels(GraphPane pane, bool isBarCenter, string valueFormat)
        {
            bool isVertical = pane.BarSettings.Base == BarBase.X;

            // Make the gap between the bars and the labels = 2% of the axis range
            float labelOffset;
            if (isVertical)
                labelOffset = (float)(pane.YAxis.Scale.Max - pane.YAxis.Scale.Min) * 0.02f;
            else
                labelOffset = (float)(pane.XAxis.Scale.Max - pane.XAxis.Scale.Min) * 0.02f;

            // keep a count of the number of BarItems
            int curveIndex = 0;

            // Get a valuehandler to do some calculations for us
            ValueHandler valueHandler = new ValueHandler(pane, true);

            // Loop through each curve in the list
            foreach (CurveItem curve in pane.CurveList)
            {
                // work with BarItems only
                BarItem bar = curve as BarItem;
                if (bar != null)
                {
                    IPointList points = curve.Points;

                    // Loop through each point in the BarItem
                    for (int i = 0; i < points.Count; i++)
                    {
                        double val = (isVertical ? points[i].Y : points[i].X);
                        if (val == 0.0) continue;

                        // Get the high, low and base values for the current bar
                        // note that this method will automatically calculate the "effective"
                        // values if the bar is stacked
                        double baseVal, lowVal, hiVal;
                        valueHandler.GetValues(curve, i, out baseVal, out lowVal, out hiVal);

                        // Get the value that corresponds to the center of the bar base
                        // This method figures out how the bars are positioned within a cluster
                        float centerVal = (float)valueHandler.BarCenterValue(bar,
                            bar.GetBarWidth(pane), i, baseVal, curveIndex);

                        // Create a text label -- note that we have to go back to the original point
                        // data for this, since hiVal and lowVal could be "effective" values from a bar stack
                        string barLabelText = val.ToString(valueFormat);

                        // Calculate the position of the label -- this is either the X or the Y coordinate
                        // depending on whether they are horizontal or vertical bars, respectively
                        float position;
                        if (isBarCenter)
                            position = (float)(hiVal + lowVal) / 2.0f;
                        else
                            position = (float)hiVal + labelOffset;

                        // Create the new TextObj
                        TextObj label;
                        if (isVertical)
                            label = new TextObj(barLabelText, centerVal, position);
                        else
                            label = new TextObj(barLabelText, position, centerVal);

                        // Configure the TextObj
                        label.Location.CoordinateFrame = CoordType.AxisXYScale;
                        label.FontSpec.Size = 12;
                        label.FontSpec.FontColor = Color.Black;
                        label.FontSpec.Angle = isVertical ? 90 : 0;
                        label.Location.AlignH = isBarCenter ? AlignH.Center : AlignH.Left;
                        label.Location.AlignV = AlignV.Center;
                        label.FontSpec.Border.IsVisible = false;
                        label.FontSpec.Fill.IsVisible = false;

                        // Add the TextObj to the GraphPane
                        pane.GraphObjList.Add(label);
                    }
                }
                curveIndex++;
            }
        }

        private void FillTotASIGraph(TeamStats teamStats)
        {
            GraphPane pane = graphTotASIHistory.GraphPane;

            pane.CurveList.Clear();

            // Set the title and axis labels
            pane.Title.Text = "Team Total ASI";
            pane.YAxis.Title.Text = "Total ASI (kASI)";
            pane.XAxis.Title.Text = "Weeks";
            pane.XAxis.Type = AxisType.Date;
            pane.XAxis.Scale.MajorStep = 7;
            pane.XAxis.Scale.MinorStep = 7;
            pane.XAxis.Scale.MajorUnit = DateUnit.Day;
            pane.XAxis.Scale.Format = "TW";

            GrowthHistoryList growthHistoryList = teamStats.GrowthHistory;
            int count = growthHistoryList.Count;

            if (count == 0) return;

            double[] totASI = new double[count];
            double[] xdate = new double[count];
            double dMin = 1000.0;
            double dMax = -1.0;
            int i = 0;

            foreach (var row in growthHistoryList.OrderBy(gh => gh.Date))
            {
                totASI[i] = (double)(row.TotASI / 1000);
                xdate[i] = (double)new XDate(row.Date);
                dMax = Math.Max(dMax, row.TotASI / 1000);
                dMin = Math.Min(dMin, row.TotASI / 1000);
                i++;
            }

            // Fill the axis background with a color gradient
            pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            // Generate a red curve with legend
            LineItem myCurve = pane.AddCurve("Total ASI", xdate, totASI, Color.Blue);
            // Make the symbols opaque by filling them with white
            myCurve.Symbol.IsVisible = true;

            // Manually set the x axis range
            pane.YAxis.Scale.Min = dMin - 5;
            pane.YAxis.Scale.Max = dMax + 5;
            pane.XAxis.Scale.Min = xdate[0];
            pane.XAxis.Scale.Max = xdate[xdate.Length - 1];

            pane.YAxis.Scale.MinorStep = 5;
            pane.YAxis.Scale.MajorStep = 20;
        }

        private void FillSkillCountGraph(TeamStats teamStats)
        {
            GraphPane pane = graphSkillCount.GraphPane;

            pane.CurveList.Clear();

            // Set the title and axis labels
            pane.Title.Text = "Team Skill Count";
            pane.YAxis.Title.Text = "Total Skill";
            pane.XAxis.Title.Text = "Weeks";
            pane.XAxis.Type = AxisType.Date;
            pane.XAxis.Scale.MajorStep = 7;
            pane.XAxis.Scale.MinorStep = 7;
            pane.XAxis.Scale.MajorUnit = DateUnit.Day;
            pane.XAxis.Scale.Format = "TW";

            GrowthHistoryList growthHistoryList = teamStats.GrowthHistory;
            int count = growthHistoryList.Count;

            if (count == 0) return;

            double[] val = new double[count];
            double[] xdate = new double[count];
            double dMin = 10000000.0;
            double dMax = -1.0;

            int i = 0;
            foreach (var row in growthHistoryList.OrderBy(gh => gh.Date))
            {
                val[i] = (double)(row.SkillCount);
                xdate[i] = (double)new XDate(row.Date);
                dMax = Math.Max(dMax, (double)row.SkillCount);
                dMin = Math.Min(dMin, (double)row.SkillCount);
                i++;
            }

            // Fill the axis background with a color gradient
            pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            // Generate a red curve with legend
            LineItem myCurve = pane.AddCurve("Total Skill", xdate, val, Color.Blue);
            // Make the symbols opaque by filling them with white
            myCurve.Symbol.IsVisible = true;
            // Manually set the x axis range
            pane.YAxis.Scale.Min = dMin - 5;
            pane.YAxis.Scale.Max = dMax + 5;
            pane.XAxis.Scale.Min = xdate[0];
            pane.XAxis.Scale.Max = xdate[xdate.Length - 1];

            pane.YAxis.Scale.MinorStep = 50;
            pane.YAxis.Scale.MajorStep = 200;
        }

        private void FillTeamFansHistory(TeamStats teamStats)
        {
            GraphPane pane = graphTeamFans.GraphPane;

            pane.CurveList.Clear();

            // Set the title and axis labels
            pane.Title.Text = "Team Fans Growth";
            pane.YAxis.Title.Text = "Supporters number";
            pane.XAxis.Title.Text = "Weeks";
            pane.XAxis.Type = AxisType.Date;
            pane.XAxis.Scale.MajorStep = 7;
            pane.XAxis.Scale.MinorStep = 7;
            pane.XAxis.Scale.MajorUnit = DateUnit.Day;
            pane.XAxis.Scale.Format = "TW";

            var teamHistory = teamStats.TeamHistory;
            int count = teamHistory.Count + 1;

            double[] valFans = new double[count];
            double[] ddate = new double[count];
            XDate[] xdate = new XDate[count];
            double dMin = 10000000.0;
            double dMax = -1.0;

            var row = (from r in teamHistory select r).FirstOrDefault();

            if (row == null) return;

            xdate[0] = new XDate(row.Date);
            ddate[0] = (double)xdate[0];
            valFans[0] = (double)(row.Fans);

            int i = 1;
            foreach(var histRow in teamHistory)
            {
                valFans[i] = (double)(histRow.Fans);

                xdate[i] = new XDate(histRow.Date);
                ddate[i] = (double)xdate[i];

                dMax = Math.Max(dMax, valFans[i]);
                dMin = Math.Min(dMin, valFans[i]);

                i++;
            }

            // Fill the axis background with a color gradient
            pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            // Generate a red curve with legend
            LineItem myCurve = pane.AddCurve("Fans", ddate, valFans, Color.Blue);
            // Make the symbols opaque by filling them with white
            myCurve.Symbol.IsVisible = true;

            // Manually set the x axis range
            pane.YAxis.Scale.Min = dMin - 100;
            pane.YAxis.Scale.Max = dMax + 100;
            pane.XAxis.Scale.Min = ddate[0] - 1;
            pane.XAxis.Scale.Max = ddate[ddate.Length - 1] + 1;

            pane.YAxis.Scale.MinorStep = 2;
            pane.YAxis.Scale.MajorStep = 10;
        }


        private void FillSkillGrowth(TeamStats teamStats)
        {
            GraphPane pane = graphSkillGrowth.GraphPane;

            pane.CurveList.Clear();

            // Set the title and axis labels
            pane.Title.Text = "Team Skill Growth";
            pane.YAxis.Title.Text = "Delta Skill";
            pane.XAxis.Title.Text = "Weeks";
            pane.XAxis.Type = AxisType.Date;
            pane.XAxis.Scale.MajorStep = 7;
            pane.XAxis.Scale.MinorStep = 7;
            pane.XAxis.Scale.MajorUnit = DateUnit.Day;
            pane.XAxis.Scale.Format = "TW";

            GrowthHistoryList growthHistoryList = teamStats.GrowthHistory;
            int count = growthHistoryList.Count;

            int nonZeroCount = 0;
            int j = 0;
            foreach (var row in growthHistoryList.OrderBy(gh => gh.Date))
            {
                if ((row.DeltaSkillPos == 0) && (row.DeltaSkillNeg == 0)) continue;
                nonZeroCount++;
                j++;
            }

            if (nonZeroCount == 0) return;

            double[] valP = new double[nonZeroCount];
            double[] valN = new double[nonZeroCount];
            double[] ddate = new double[nonZeroCount];
            XDate[] xdate = new XDate[nonZeroCount];
            double dMin = 10000000.0;
            double dMax = -1.0;
            double ddateMin = double.MaxValue;
            double ddateMax = double.MinValue;

            int i = 0;
            foreach (var row in growthHistoryList.OrderBy(gh => gh.Date))
            {
                if ((row.DeltaSkillPos == 0) && (row.DeltaSkillNeg == 0)) continue;

                valP[i] = (double)(row.DeltaSkillPos);
                valN[i] = (double)(row.DeltaSkillNeg);

                xdate[i] = new XDate(row.Date);
                ddate[i] = (double)xdate[i];

                ddateMin = Math.Min(ddateMin, ddate[i]);
                ddateMax = Math.Max(ddateMax, ddate[i]);

                dMax = Math.Max(dMax, valP[i]);
                dMin = Math.Min(dMin, valN[i]);

                i++;
                if (i == nonZeroCount) break;
            }

            // Fill the axis background with a color gradient
            pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            // Generate a red curve with legend
            LineItem myCurve = pane.AddCurve("Delta Skill (pos)", ddate, valP, Color.Blue);
            // Make the symbols opaque by filling them with white
            myCurve.Symbol.IsVisible = true;

            // Generate a red curve with legend
            myCurve = pane.AddCurve("Delta Skill (neg)", ddate, valN, Color.Red);
            // Make the symbols opaque by filling them with white
            myCurve.Symbol.IsVisible = true;

            // Manually set the x axis range
            pane.YAxis.Scale.Min = dMin - 5;
            pane.YAxis.Scale.Max = dMax + 5;
            pane.XAxis.Scale.Min = ddateMin;
            pane.XAxis.Scale.Max = ddateMax;

            pane.YAxis.Scale.MinorStep = 2;
            pane.YAxis.Scale.MajorStep = 10;
        }

        private void FillAgeStatsGraph(TeamStats teamStats)
        {
            GraphPane pane = graphAgeHistory.GraphPane;

            pane.CurveList.Clear();

            // Set the title and axis labels
            pane.Title.Text = "Team Player's Age Stats";
            pane.YAxis.Title.Text = "Count";
            pane.XAxis.Title.Text = "Weeks";
            pane.XAxis.Type = AxisType.Date;
            pane.XAxis.Scale.MajorStep = 7;
            pane.XAxis.Scale.MinorStep = 7;
            pane.XAxis.Scale.MajorUnit = DateUnit.Day;
            pane.XAxis.Scale.Format = "TW";

            AgeHistoryList ageHistoryList = teamStats.AgeHistory;
            int count = ageHistoryList.Count;

            if (count == 0) return;

            double[] u18 = new double[count];
            double[] u21 = new double[count];
            double[] u24 = new double[count];
            double[] u30 = new double[count];
            double[] o30 = new double[count];
            double[] xdate = new double[count];
            double dMin = 0.0;
            double dMax = -1.0;

            int i = 0;
            foreach (var row in ageHistoryList.OrderBy(gh => gh.Date))
            {
                u18[i] = (double)(row.U18);
                u21[i] = (double)(row.U21 + row.U18);
                u24[i] = (double)(row.U24 + row.U21 + row.U18);
                u30[i] = (double)(row.U30 + row.U24 + row.U21 + row.U18);
                o30[i] = (double)(row.O30 + row.U30 + row.U24 + row.U21 + row.U18);
                xdate[i] = (double)new XDate(row.Date);
                dMax = Math.Max(dMax, o30[i]);
                i++;
            }

            // Fill the axis background with a color gradient
            pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            // Generate a red curve with legend
            LineItem myCurve = pane.AddCurve("Under 18", xdate, u18, Color.Green);
            // Make the symbols opaque by filling them with white
            // myCurve.Line.Fill = new Fill(Color.Green);
            myCurve.Symbol.IsVisible = true;

            // Generate a red curve with legend
            myCurve = pane.AddCurve("Under 21", xdate, u21, Color.Yellow);
            // myCurve.Line.Fill = new Fill(Color.Yellow);
            myCurve.Symbol.IsVisible = true;

            // Generate a red curve with legend
            myCurve = pane.AddCurve("Under 24", xdate, u24, Color.Orange);
            // myCurve.Line.Fill = new Fill(Color.Orange);
            myCurve.Symbol.IsVisible = true;

            // Generate a red curve with legend
            myCurve = pane.AddCurve("Under 30", xdate, u30, Color.Red);
            // myCurve.Line.Fill = new Fill(Color.Red);
            myCurve.Symbol.IsVisible = true;

            // Generate a red curve with legend
            myCurve = pane.AddCurve("Over 30", xdate, o30, Color.Violet);
            // myCurve.Line.Fill = new Fill(Color.Violet);
            myCurve.Symbol.IsVisible = true;

            // Manually set the x axis range
            pane.YAxis.Scale.Min = dMin;
            pane.YAxis.Scale.Max = dMax + 1.0;
            pane.XAxis.Scale.Min = xdate[0];
            pane.XAxis.Scale.Max = xdate[xdate.Length - 1];

            pane.YAxis.Scale.MinorStep = 1;
            pane.YAxis.Scale.MajorStep = 5;
        }

        private void TeamStatsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Rectangle pos = new Rectangle(DesktopBounds.X, DesktopBounds.Y, DesktopBounds.Width, DesktopBounds.Height);
            Program.Setts.TeamStatsFormPosition = pos;
            Program.Setts.Save();
        }

        private void TeamStatsForm_Load(object sender, EventArgs e)
        {
            Rectangle pos = Program.Setts.TeamStatsFormPosition;
            if (pos.Height + pos.Width > 0)
                this.SetDesktopBounds(pos.X, pos.Y, pos.Width, pos.Height);
        }
    }
}