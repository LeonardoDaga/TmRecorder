using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using Common;

namespace TMRecorder
{
    public partial class TeamStatsForm : Form
    {
        public TeamStatsForm()
        {
            InitializeComponent();
        }

        public void FillSquadGraphs(ExtraDS extraDS)
        {
            FillSquadAgeGraph(extraDS);
            FillSquadPlayersASIxPosition(extraDS);
        }

        private void FillSquadPlayersASIxPosition(ExtraDS extraDS)
        {
            int[] StatsPlyASILT300 = extraDS.GetStatsPlyASIxRule(0, 300);
            int[] StatsPlyASILT1000 = extraDS.GetStatsPlyASIxRule(301, 1000);
            int[] StatsPlyASIGT1000 = extraDS.GetStatsPlyASIxRule(1001, 10000);
            int[] StatsPlyASIGT10000 = extraDS.GetStatsPlyASIxRule(10001, 100000);

            GraphPane pane = graphSquadASI.GraphPane;
            pane.CurveList.Clear();
            pane.GraphObjList.Clear();

            // Set the title and axis labels
            pane.Title.Text = "Squad Players ASI x Position";
            pane.YAxis.Title.Text = "Number Of Players";
            pane.XAxis.Title.Text = "Position";

            // Enter some random data values
            double[] list1 = new double[extraDS.specs.Length];
            double[] list2 = new double[extraDS.specs.Length];
            double[] list3 = new double[extraDS.specs.Length];
            double[] list4 = new double[extraDS.specs.Length];

            double count1 = 0;
            double count2 = 0;
            double count3 = 0;
            double count4 = 0;

            double max = 0;
            for (int i = 0; i < extraDS.specs.Length; i++)
            {
                count1 = (double)StatsPlyASILT300[i];
                count2 = (double)StatsPlyASILT1000[i];
                count3 = (double)StatsPlyASIGT1000[i];
                count4 = (double)StatsPlyASIGT10000[i];
                double sum = count1 + count2 + count3 + count4;
                if (max < sum) max = sum;
                if (max < sum) max = sum;
                if (max < sum) max = sum;
                if (max < sum) max = sum;

                list1[i] = count1;
                list2[i] = count2;
                list3[i] = count3;
                list4[i] = count4;
            }

            BarItem myCurve1 = pane.AddBar("Ply x Position < 300 ASI", null, list1, Color.Yellow);
            BarItem myCurve2 = pane.AddBar("Ply x Position < 1000 ASI", null, list2, Color.LightGreen);
            BarItem myCurve3 = pane.AddBar("Ply x Position > 1000 ASI", null, list3, Color.Orange);
            BarItem myCurve4 = pane.AddBar("Ply x Position > 10000 ASI", null, list4, Color.OrangeRed);

            // Fill the axis background with a color gradient
            pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            // Draw the X tics between the labels instead of at the labels
            pane.XAxis.Scale.MajorStep = 1;

            // Make the bars horizontal by setting the BarBase to "Y"
            pane.BarSettings.Base = BarBase.X;
            pane.BarSettings.Type = BarType.Stack;

            // Set the YAxis labels
            pane.XAxis.Scale.TextLabels = extraDS.specs;
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

        private void FillSquadAgeGraph(ExtraDS extraDS)
        {
            int[] StatsAgeASILT300 = extraDS.GetStatsAge(0, 300);
            int[] StatsAgeASILT1000 = extraDS.GetStatsAge(301, 1000);
            int[] StatsAgeASIGT1000 = extraDS.GetStatsAge(1001, 10000);
            int[] StatsAgeASIGT10000 = extraDS.GetStatsAge(10001, 10000000);

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

            double count1 = 0;
            double count2 = 0;
            double count3 = 0;
            double count4 = 0;

            double max = 0;
            for (int i = 0; i < StatsAgeASILT300.Length - 2; i++)
            {
                count1 = (double)StatsAgeASILT300[i + 2];
                count2 = (double)StatsAgeASILT1000[i + 2];
                count3 = (double)StatsAgeASIGT1000[i + 2];
                count4 = (double)StatsAgeASIGT10000[i + 2];

                if (max < count1) max = count1;
                if (max < count2) max = count2;
                if (max < count3) max = count3;
                if (max < count4) max = count4;

                list1.Add((double)(StatsAgeASILT300[0] + i), count1);
                list2.Add((double)(StatsAgeASILT300[0] + i), count2);
                list3.Add((double)(StatsAgeASILT300[0] + i), count3);
                list4.Add((double)(StatsAgeASILT300[0] + i), count4);
            }

            BarItem myCurve1 = pane.AddBar("Players x Age < 300 ASI", list1, Color.Yellow);
            BarItem myCurve2 = pane.AddBar("Players x Age < 1000 ASI", list2, Color.LightGreen);
            BarItem myCurve3 = pane.AddBar("Players x Age > 1000 ASI", list3, Color.Orange);
            BarItem myCurve4 = pane.AddBar("Players x Age > 10000 ASI", list4, Color.OrangeRed);

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

        public void FillSquadStatsGraphs(TeamStats teamStats)
        {
            FillAgeStatsGraph(teamStats);
            FillTotASIGraph(teamStats);
            FillSkillCountGraph(teamStats);
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

            TeamStats.GrowthHistoryDataTable table = teamStats.GrowthHistory;
            int count = table.Rows.Count;

            if (count == 0) return;

            double[] totASI = new double[count];
            double[] xdate = new double[count];
            double dMin = 1000.0;
            double dMax = -1.0;

            for (int i = 0; i < count; i++)
            {
                TeamStats.GrowthHistoryRow row = (TeamStats.GrowthHistoryRow)table.Rows[i];

                totASI[i] = (double)(row.TotASI / 1000);
                xdate[i] = (double)new XDate(row.Date);
                dMax = Math.Max(dMax, row.TotASI / 1000);
                dMin = Math.Min(dMin, row.TotASI / 1000);
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

            TeamStats.GrowthHistoryDataTable table = teamStats.GrowthHistory;
            int count = table.Rows.Count;

            if (count == 0) return;

            double[] val = new double[count];
            double[] xdate = new double[count];
            double dMin = 10000000.0;
            double dMax = -1.0;

            for (int i = 0; i < count; i++)
            {
                TeamStats.GrowthHistoryRow row = (TeamStats.GrowthHistoryRow)table.Rows[i];

                val[i] = (double)(row.SkillCount);
                xdate[i] = (double)new XDate(row.Date);
                dMax = Math.Max(dMax, (double)row.SkillCount);
                dMin = Math.Min(dMin, (double)row.SkillCount);
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

            TeamStats.GrowthHistoryDataTable table = teamStats.GrowthHistory;
            int count = table.Rows.Count;

            int nonZeroCount = 0;
            for (int j = 0; j < count; j++)
            {
                TeamStats.GrowthHistoryRow row = (TeamStats.GrowthHistoryRow)table.Rows[j];
                if ((row.DeltaSkillPos == 0) && (row.DeltaSkillNeg == 0)) continue;
                nonZeroCount++;
            }

            if (nonZeroCount == 0) return;

            double[] valP = new double[nonZeroCount];
            double[] valN = new double[nonZeroCount];
            double[] ddate = new double[nonZeroCount];
            XDate[] xdate = new XDate[nonZeroCount];
            double dMin = 10000000.0;
            double dMax = -1.0;

            int i = 0;
            for (int j = 0; (j < count) && (i < nonZeroCount); j++)
            {
                TeamStats.GrowthHistoryRow row = (TeamStats.GrowthHistoryRow)table.Rows[j];

                if ((row.DeltaSkillPos == 0) && (row.DeltaSkillNeg == 0)) continue;

                valP[i] = (double)(row.DeltaSkillPos);
                valN[i] = (double)(row.DeltaSkillNeg);

                xdate[i] = new XDate(row.Date);
                ddate[i] = (double)xdate[i];

                //if (i != 0)
                //{
                //    double nDays = ddate[i] - ddate[i - 1];

                //    if (nDays > 7.0)
                //    {
                //        int daysToTuesdayP = xdate[i - 1].DateTime.DayOfWeek - DayOfWeek.Tuesday;
                //        int daysToTuesdayN = xdate[i].DateTime.DayOfWeek - DayOfWeek.Tuesday;
                //        if (daysToTuesdayP < 0) daysToTuesdayP = 7 + daysToTuesdayP;
                //        if (daysToTuesdayN < 0) daysToTuesdayN = 7 + daysToTuesdayN;
                //        int nWeek = ((int)nDays - daysToTuesdayN + daysToTuesdayP) / 7;
                //        if (nWeek == 0) nWeek = 1;
                //        valP[i] = valP[i] / nWeek;
                //        valN[i] = valN[i] / nWeek;
                //    }
                //}

                dMax = Math.Max(dMax, valP[i]);
                dMin = Math.Min(dMin, valN[i]);

                i++;
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
            pane.XAxis.Scale.Min = ddate[0];
            pane.XAxis.Scale.Max = ddate[ddate.Length - 1];

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

            TeamStats.AgeHistoryDataTable table = teamStats.AgeHistory;
            int count = table.Rows.Count;

            if (count == 0) return;

            double[] u18 = new double[count];
            double[] u21 = new double[count];
            double[] u24 = new double[count];
            double[] u30 = new double[count];
            double[] o30 = new double[count];
            double[] xdate = new double[count];
            double dMin = 0.0;
            double dMax = -1.0;

            for (int i = 0; i < count; i++)
            {
                TeamStats.AgeHistoryRow row = (TeamStats.AgeHistoryRow)table.Rows[i];

                u18[i] = (double)(row.U18);
                u21[i] = (double)(row.U21 + row.U18);
                u24[i] = (double)(row.U24 + row.U21 + row.U18);
                u30[i] = (double)(row.U30 + row.U24 + row.U21 + row.U18);
                o30[i] = (double)(row.O30 + row.U30 + row.U24 + row.U21 + row.U18);
                xdate[i] = (double)new XDate(row.Date);
                dMax = Math.Max(dMax, o30[i]);
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

        internal void FillTrainingHistory(ListTrainingDataSet2 trainingHist)
        {
            TeamStats teamStats = new TeamStats();

            foreach(var training in trainingHist)
            {
                float deltaSkillPos = 0;
                float deltaSkillNeg = 0;

                foreach (var player in training.Giocatori)
                {
                    deltaSkillPos += player.DeltaSkillPos();
                    deltaSkillNeg += player.DeltaSkillNeg();
                }

                foreach (var player in training.Portieri)
                {
                    deltaSkillPos += player.DeltaSkillPos();
                    deltaSkillNeg += player.DeltaSkillNeg();
                }

                var growthRow = teamStats.GrowthHistory.NewGrowthHistoryRow();
                growthRow.Date = training.Date;
                growthRow.DeltaSkillPos = (decimal)deltaSkillPos;
                growthRow.DeltaSkillNeg = (decimal)deltaSkillNeg;
                teamStats.GrowthHistory.AddGrowthHistoryRow(growthRow);
            }

            FillSkillGrowth(teamStats);
        }
    }
}