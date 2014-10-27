using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;
using ZedGraph;

namespace TMRecorder
{
    public partial class ComputeStructures : Form
    {
        System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo("en-US", false).NumberFormat;

        static readonly float[] merchandisingRevPerFan = new float[] { 20, 40, 60, 80, 100, 120, 140, 160, 180, 200 };
        static readonly float[] merchandisingWeekCost = new float[] { 50000, 150000, 250000, 350000, 450000, 550000, 650000, 750000, 850000, 950000 };
        static readonly float[] merchandStandRevPerSpectator = new float[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
        static readonly float[] merchandStandWeekCost = new float[] { 112500, 225000, 337500, 450000, 562500, 675000, 787500, 900000, 1012500, 1125000 };
        static readonly float[] restaurantRevPerSpectator = new float[] { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };
        static readonly float[] restaurantWeekCost = new float[] { 56250, 112500, 168750, 225000, 281250, 337500, 393750, 450000, 506250, 562500 };
        static readonly float[] sausageRevPerSpectator = new float[] { 2.5f, 5.0f, 7.5f, 10.0f, 12.5f, 15.0f, 17.5f, 20.0f, 22.5f, 25.0f };
        static readonly float[] sausageWeekCost = new float[] { 28125, 56250, 84375, 112500, 140625, 168750, 196875, 225000, 253125, 281250 };
        static readonly float[] fastfoodRevPerSpectator = new float[] { 4, 8, 12, 16, 20, 24, 28, 32, 36, 40 };
        static readonly float[] fastfoodWeekCost = new float[] { 45000, 90000, 135000, 180000, 225000, 270000, 315000, 360000, 405000, 450000 };
        static readonly float stadiumRevPerSpectator = 200;
        static readonly float stadiumCostPerSeat = 35;

        public ComputeStructures()
        {
            InitializeComponent();
        }

        float AverageAttendance
        {
            get { return (float)numAverageAttendance.Value; }
            set { numAverageAttendance.Value = (int)value; }
        }

        float NumOfSupporters
        {
            get { return (float)numOfSupporters.Value; }
            set { numOfSupporters.Value = (int)value; }
        }

        float StadiumSize
        {
            get { return (float)numStadiumSize.Value; }
            set { numStadiumSize.Value = (int)value; }
        }

        public Dictionary<string, string> Settings
        {
            get;
            set; 
        }

        private void SaveSettings()
        {
            Settings["StadiumSize"] = StadiumSize.ToString();
            Settings["NumOfSupporters"] = NumOfSupporters.ToString();
            Settings["AverageAttendance"] = AverageAttendance.ToString();
        }
        private void LoadSettings()
        {
            try
            {
                StadiumSize = int.Parse(Settings["StadiumSize"]);
                NumOfSupporters = int.Parse(Settings["NumOfSupporters"]);
                AverageAttendance = int.Parse(Settings["AverageAttendance"]);
            }
            catch(Exception ex)
            {}
        }

        public void CalcStructures()
        {
            PointPairList pplMerchandising = new PointPairList();
            PointPairList pplMerchandiseStand = new PointPairList();
            PointPairList pplRestaurants = new PointPairList();
            PointPairList pplStadium = new PointPairList();
            PointPairList pplSausage = new PointPairList();
            PointPairList pplFastFood = new PointPairList();

            GraphPane pane = graphEconomy.GraphPane;
            pane.CurveList.Clear();
            pane.GraphObjList.Clear();

            // Set the title and axis labels
            pane.Title.Text = "Structures Economy";
            pane.YAxis.Title.Text = "Net Incomes x week (x1000)";
            pane.XAxis.Title.Text = "Level of the Structure";

            double max = 0;
            for (int i = 0; i < 10; i++)
            {
                pplMerchandising.Add((double)i + 1, (merchandisingRevPerFan[i] * NumOfSupporters - merchandisingWeekCost[i]) / 1000);
                pplRestaurants.Add((double)i + 1, ((restaurantRevPerSpectator[i] * AverageAttendance)* 17 / 12 - restaurantWeekCost[i]) / 1000);
                pplMerchandiseStand.Add((double)i + 1, ((merchandStandRevPerSpectator[i] * AverageAttendance) * 17 / 12 - merchandStandWeekCost[i]) / 1000);
                pplStadium.Add((double)i + 1, ((stadiumRevPerSpectator * AverageAttendance) * 17 /12 - stadiumCostPerSeat * StadiumSize) / 1000);
                pplSausage.Add((double)i + 1, ((sausageRevPerSpectator[i] * AverageAttendance) * 17 / 12 - sausageWeekCost[i]) / 1000);
                pplFastFood.Add((double)i + 1, ((fastfoodRevPerSpectator[i] * AverageAttendance) * 17 / 12 - fastfoodWeekCost[i]) / 1000);
            }

            LineItem myCurve1 = pane.AddCurve("Merchandise Store", pplMerchandising, Color.Blue);
            LineItem myCurve2 = pane.AddCurve("Restaurants Incomes", pplRestaurants, Color.Green);
            LineItem myCurve3 = pane.AddCurve("Stadium Incomes", pplStadium, Color.Red);
            LineItem myCurve4 = pane.AddCurve("Merchandise Stand", pplMerchandiseStand, Color.Orange);
            LineItem myCurve5 = pane.AddCurve("Sausage Stand", pplSausage, Color.Violet);
            LineItem myCurve6 = pane.AddCurve("Fast Food", pplFastFood, Color.Cyan);

            // Fill the axis background with a color gradient
            pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            // expand the range of the Y axis slightly to accommodate the labels
            //pane.YAxis.Scale.Max = max * 1.2;
            pane.XAxis.Scale.Min = 1;
            pane.XAxis.Scale.Max = 10;

            graphEconomy.AxisChange();

            // Create a label for each bar
            CreateBarLabels(pane, true, "N0");

            graphEconomy.Refresh();
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

        private void txtData_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcStructures();
            }
            catch (Exception)
            {
            }
        }

        private void ComputeStructures_Load(object sender, EventArgs e)
        {
            LoadSettings();

            try
            {
                CalcStructures();
            }
            catch (Exception)
            {
            }
        }

        private void ComputeStructures_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }
    }
}