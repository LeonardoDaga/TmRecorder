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

        static readonly float[] merchandisingRevPerFan = new float[] { 0, 20, 40, 60, 80, 100, 120, 140, 160, 180, 200 };
        static readonly float[] merchandisingWeekCost = new float[] { 0, 50000, 150000, 250000, 350000, 450000, 550000, 650000, 750000, 850000, 950000 };
        static readonly float[] merchandisingBuildCost = new float[] {80000, 160000, 300000, 600000, 1000000, 1400000, 1800000, 2500000, 3250000, 6500000 };

        static readonly float[] merchandStandRevPerSpectator = new float[] { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
        static readonly float[] merchandStandWeekCost = new float[] { 0, 112500, 225000, 337500, 450000, 562500, 675000, 787500, 900000, 1012500, 1125000 };
        static readonly float[] merchandStandBuildCost = new float[] {500000, 1000000, 2000000, 4000000, 8000000, 12000000, 16000000, 20000000, 30000000, 40000000 };

        static readonly float[] restaurantRevPerSpectator = new float[] { 0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };
        static readonly float[] restaurantWeekCost = new float[] { 0, 56250, 112500, 168750, 225000, 281250, 337500, 393750, 450000, 506250, 562500 };
        static readonly float[] restaurantBuildCost = new float[] { 250000, 500000, 1000000, 2000000, 4000000, 6000000, 8000000, 10000000, 15000000, 20000000 };

        static readonly float[] sausageRevPerSpectator = new float[] { 0f, 2.5f, 5.0f, 7.5f, 10.0f, 12.5f, 15.0f, 17.5f, 20.0f, 22.5f, 25.0f };
        static readonly float[] sausageWeekCost = new float[] { 0, 28125, 56250, 84375, 112500, 140625, 168750, 196875, 225000, 253125, 281250 };
        static readonly float[] sausageBuildCost = new float[] { 125000, 250000, 500000, 1000000, 2000000, 3000000, 4000000, 5000000, 7500000, 10000000 };

        static readonly float[] fastfoodRevPerSpectator = new float[] { 0, 4, 8, 12, 16, 20, 24, 28, 32, 36, 40 };
        static readonly float[] fastfoodWeekCost = new float[] { 0, 45000, 90000, 135000, 180000, 225000, 270000, 315000, 360000, 405000, 450000 };
        static readonly float[] fastfoodBuildCost = new float[] { 187000, 375000, 750000, 1500000, 3000000, 4500000, 6000000, 7500000, 11250000, 15000000 };

        static readonly float[] parkingAttendanceIncrement = new float[] { 0f, 0.01f, 0.02f, 0.03f, 0.04f, 0.05f, 0.06f, 0.07f, 0.08f, 0.09f, 0.10f };
        static readonly float[] parkingBuildCost = new float[] { 125000, 750000, 2250000, 5000000, 9000000, 15000000, 22500000, 30000000, 40000000, 50000000 };
        static readonly float[] parkingWeekCost = new float[] { 10000, 50000, 100000, 150000, 250000, 375000, 500000, 625000, 800000, 1000000 };

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

        bool ShowStadiumIncomes
        {
            get { return chkShowStadiumIncomes.Checked; }
            set { chkShowStadiumIncomes.Checked = value; }
        }

        int LevelMerchandisingStore
        {
            get { return (int)numLevMerchStore.Value; }
            set { numLevMerchStore.Value = (int)value; }
        }

        int LevelMerchandisingStand
        {
            get { return (int)numLevMerchStand.Value; }
            set { numLevMerchStand.Value = (int)value; }
        }

        int LevelFastFood
        {
            get { return (int)numLevFastFood.Value; }
            set { numLevFastFood.Value = (int)value; }
        }

        int LevelRestaurants
        {
            get { return (int)numLevRestaurants.Value; }
            set { numLevRestaurants.Value = (int)value; }
        }

        int LevelSausageStands
        {
            get { return (int)numLevSausageStand.Value; }
            set { numLevSausageStand.Value = (int)value; }
        }

        int LevelParking
        {
            get { return (int)numLevParking.Value; }
            set { numLevParking.Value = (int)value; }
        }

        int StadiumSizeIncrement
        {
            get { return (int)numStadSizeIncrement.Value; }
            set { numStadSizeIncrement.Value = (int)value; }
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
            Settings["LevelFastFood"] = LevelFastFood.ToString();
            Settings["LevelMerchandisingStand"] = LevelMerchandisingStand.ToString();
            Settings["LevelMerchandisingStore"] = LevelMerchandisingStore.ToString();
            Settings["LevelRestaurants"] = LevelRestaurants.ToString();
            Settings["LevelSausageStands"] = LevelSausageStands.ToString();
            Settings["StadiumSizeIncrement"] = StadiumSizeIncrement.ToString();
            Settings["LevelParking"] = LevelParking.ToString();
        }
        private void LoadSettings()
        {
            try
            {
                StadiumSize = int.Parse(Settings["StadiumSize"]);
                NumOfSupporters = int.Parse(Settings["NumOfSupporters"]);
                AverageAttendance = int.Parse(Settings["AverageAttendance"]);
                LevelFastFood = int.Parse(Settings["LevelFastFood"]);
                LevelMerchandisingStand = int.Parse(Settings["LevelMerchandisingStand"]);
                LevelMerchandisingStore = int.Parse(Settings["LevelMerchandisingStore"]);
                LevelRestaurants = int.Parse(Settings["LevelRestaurants"]);
                LevelSausageStands = int.Parse(Settings["LevelSausageStands"]);
                StadiumSizeIncrement = int.Parse(Settings["StadiumSizeIncrement"]);
                LevelParking = int.Parse(Settings["LevelParking"]);
            }
            catch(Exception ex)
            {}
        }

        public void DrawGraphStructures()
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
            for (int i = 1; i < 11; i++)
            {
                pplMerchandising.Add((double)i, (merchandisingRevPerFan[i] * NumOfSupporters - merchandisingWeekCost[i]) / 1000);
                pplRestaurants.Add((double)i, ((restaurantRevPerSpectator[i] * AverageAttendance)* 17 / 12 - restaurantWeekCost[i]) / 1000);
                pplMerchandiseStand.Add((double)i, ((merchandStandRevPerSpectator[i] * AverageAttendance) * 17 / 12 - merchandStandWeekCost[i]) / 1000);
                if (ShowStadiumIncomes)
                    pplStadium.Add((double)i, ((stadiumRevPerSpectator * AverageAttendance) * 17 /12 - stadiumCostPerSeat * StadiumSize) / 1000);
                pplSausage.Add((double)i, ((sausageRevPerSpectator[i] * AverageAttendance) * 17 / 12 - sausageWeekCost[i]) / 1000);
                pplFastFood.Add((double)i, ((fastfoodRevPerSpectator[i] * AverageAttendance) * 17 / 12 - fastfoodWeekCost[i]) / 1000);
            }

            LineItem myCurve1 = pane.AddCurve("Merchandise Store", pplMerchandising, Color.Blue);
            LineItem myCurve2 = pane.AddCurve("Restaurants Incomes", pplRestaurants, Color.Green);
            LineItem myCurve3 = null;
            if (ShowStadiumIncomes)
                myCurve3 = pane.AddCurve("Stadium Incomes", pplStadium, Color.Red);
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

        enum Structures
        {
            Stadium = 0,
            MerchandiseStore = 1,
            MerchandisingStands = 2,
            SausageStands = 3,
            Restaurants = 4,
            FastFood = 5,
            Parking = 6
        }

        private float Incomes(float averageAttendance,
            float numOfSupporters,
            float stadiumSize,
            int levelMerchandisingStore,
            int levelMerchandisingStand,
            int levelSausageStands,
            int levelRestaurants,
            int levelFastFood,
            int levelParking)
        {
            float ratioMatchWeek = 17f/12f;
            float val = (stadiumRevPerSpectator * averageAttendance) * ratioMatchWeek - stadiumCostPerSeat * stadiumSize +
                merchandisingRevPerFan[levelMerchandisingStore] * numOfSupporters - merchandisingWeekCost[levelMerchandisingStore] +
                (merchandStandRevPerSpectator[levelMerchandisingStand] * averageAttendance) * ratioMatchWeek - merchandStandWeekCost[levelMerchandisingStand] +
                (sausageRevPerSpectator[levelSausageStands] * averageAttendance) * ratioMatchWeek - sausageWeekCost[levelSausageStands] +
                (restaurantRevPerSpectator[levelRestaurants] * averageAttendance) * ratioMatchWeek - restaurantWeekCost[levelRestaurants] +
                (fastfoodRevPerSpectator[levelFastFood] * averageAttendance) * ratioMatchWeek - fastfoodWeekCost[levelFastFood]
                - parkingWeekCost[levelParking];
            return val;
        }

        private void DrawDifferentialStructures()
        {
            float[] differentialIncomes = new float[7];
            float[] constructionCosts = new float[7];

            int seatsIncrement = StadiumSizeIncrement;

            float baseValue = Incomes(AverageAttendance, NumOfSupporters, StadiumSize, LevelMerchandisingStore,
                LevelMerchandisingStand, LevelSausageStands, LevelRestaurants, LevelFastFood, LevelParking);

            differentialIncomes[(int)Structures.Stadium] = 
                (Incomes(AverageAttendance + seatsIncrement, NumOfSupporters, StadiumSize + seatsIncrement, LevelMerchandisingStore,
                LevelMerchandisingStand, LevelSausageStands, LevelRestaurants, LevelFastFood, LevelParking) - baseValue) / 1000;

            differentialIncomes[(int)Structures.MerchandiseStore] =
                (Incomes(AverageAttendance, NumOfSupporters, StadiumSize, LevelMerchandisingStore + 1,
                LevelMerchandisingStand, LevelSausageStands, LevelRestaurants, LevelFastFood, LevelParking) - baseValue) / 1000;

            differentialIncomes[(int)Structures.MerchandisingStands] =
                (Incomes(AverageAttendance, NumOfSupporters, StadiumSize, LevelMerchandisingStore,
                LevelMerchandisingStand + 1, LevelSausageStands, LevelRestaurants, LevelFastFood, LevelParking) - baseValue) / 1000;

            differentialIncomes[(int)Structures.SausageStands] =
                (Incomes(AverageAttendance, NumOfSupporters, StadiumSize, LevelMerchandisingStore,
                LevelMerchandisingStand, LevelSausageStands + 1, LevelRestaurants, LevelFastFood, LevelParking) - baseValue) / 1000;

            differentialIncomes[(int)Structures.Restaurants] =
                (Incomes(AverageAttendance, NumOfSupporters, StadiumSize, LevelMerchandisingStore,
                LevelMerchandisingStand, LevelSausageStands, LevelRestaurants + 1, LevelFastFood, LevelParking) - baseValue) / 1000;

            differentialIncomes[(int)Structures.FastFood] =
                (Incomes(AverageAttendance, NumOfSupporters, StadiumSize, LevelMerchandisingStore,
                LevelMerchandisingStand, LevelSausageStands, LevelRestaurants, LevelFastFood + 1, LevelParking) - baseValue) / 1000;

            differentialIncomes[(int)Structures.Parking] =
                (Incomes(Math.Min(AverageAttendance * (1 + parkingAttendanceIncrement[LevelParking+1]) / (1 + parkingAttendanceIncrement[LevelParking]), StadiumSize - 25), NumOfSupporters, StadiumSize, LevelMerchandisingStore,
                LevelMerchandisingStand, LevelSausageStands, LevelRestaurants, LevelFastFood, LevelParking) - baseValue) / 1000;

            //differentialIncomes[(int)Structures.Stadium] = ((stadiumRevPerSpectator * (AverageAttendance + seatsIncrement)) * 17 / 12 - stadiumCostPerSeat * (StadiumSize + seatsIncrement)) / 1000 -
            //    ((stadiumRevPerSpectator * AverageAttendance) * 17 / 12 - stadiumCostPerSeat * StadiumSize) / 1000;
            //differentialIncomes[(int)Structures.MerchandiseStore] = (merchandisingRevPerFan[LevelMerchandisingStore + 1] * NumOfSupporters - merchandisingWeekCost[LevelMerchandisingStore + 1]) / 1000 -
            //    (merchandisingRevPerFan[LevelMerchandisingStore] * NumOfSupporters - merchandisingWeekCost[LevelMerchandisingStore]) / 1000;
            //differentialIncomes[(int)Structures.MerchandisingStands] = ((merchandStandRevPerSpectator[LevelMerchandisingStand + 1] * AverageAttendance) * 17 / 12 - merchandStandWeekCost[LevelMerchandisingStand + 1]) / 1000 -
            //    ((merchandStandRevPerSpectator[LevelMerchandisingStand] * AverageAttendance) * 17 / 12 - merchandStandWeekCost[LevelMerchandisingStand]) / 1000;
            //differentialIncomes[(int)Structures.SausageStands] = ((sausageRevPerSpectator[LevelSausageStands + 1] * AverageAttendance) * 17 / 12 - sausageWeekCost[LevelSausageStands + 1]) / 1000 -
            //    ((sausageRevPerSpectator[LevelSausageStands] * AverageAttendance) * 17 / 12 - sausageWeekCost[LevelSausageStands]) / 1000;
            //differentialIncomes[(int)Structures.Restaurants] = ((restaurantRevPerSpectator[LevelRestaurants + 1] * AverageAttendance) * 17 / 12 - restaurantWeekCost[LevelRestaurants +1]) / 1000 -
            //    ((restaurantRevPerSpectator[LevelRestaurants] * AverageAttendance) * 17 / 12 - restaurantWeekCost[LevelRestaurants]) / 1000;
            //differentialIncomes[(int)Structures.FastFood] = ((fastfoodRevPerSpectator[LevelFastFood + 1] * AverageAttendance) * 17 / 12 - fastfoodWeekCost[LevelFastFood + 1]) / 1000 -
            //    ((fastfoodRevPerSpectator[LevelFastFood] * AverageAttendance) * 17 / 12 - fastfoodWeekCost[LevelFastFood]) / 1000;

            constructionCosts[(int)Structures.Stadium] = 10000 * seatsIncrement;
            constructionCosts[(int)Structures.MerchandiseStore] = merchandisingBuildCost[LevelMerchandisingStore];
            constructionCosts[(int)Structures.MerchandisingStands] = merchandStandBuildCost[LevelMerchandisingStand];
            constructionCosts[(int)Structures.SausageStands] = sausageBuildCost[LevelSausageStands];
            constructionCosts[(int)Structures.Restaurants] = restaurantBuildCost[LevelRestaurants];
            constructionCosts[(int)Structures.FastFood] = fastfoodBuildCost[LevelFastFood];
            constructionCosts[(int)Structures.Parking] = parkingBuildCost[LevelParking];

            string[] xLabels = { "Stad", "MStr", "MStn", "Saus", "Rest", "FastFd" , "Park"};

            GraphPane pane = graphDifferential.GraphPane;
            pane.CurveList.Clear();
            pane.GraphObjList.Clear();

            // Set the title and axis labels
            pane.Title.Text = "Differential Incomes per Structure";
            pane.YAxis.Title.Text = "Differential Income x Season (x1000) and Construction Costs";
            pane.XAxis.Title.Text = "Structure";

            // Enter some random data values
            double[] list1 = new double[7];
            double[] list2 = new double[7];

            double max = 0;
            for (int i = 0; i < 7; i++)
            {
                list1[i] = differentialIncomes[i] * 12;
                list2[i] = constructionCosts[i] / 1000.0;
            }

            BarItem myCurve1 = pane.AddBar("Incomes increments x Season", null, list1, Color.Yellow);
            BarItem myCurve2 = pane.AddBar("Building Costs", null, list2, Color.LightGreen);

            // Fill the axis background with a color gradient
            pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            // Draw the X tics between the labels instead of at the labels
            pane.XAxis.Scale.MajorStep = 1;

            // Make the bars horizontal by setting the BarBase to "Y"
            pane.BarSettings.Base = BarBase.X;
            pane.BarSettings.Type = BarType.Cluster;

            // Set the YAxis labels
            pane.XAxis.Scale.TextLabels = xLabels;
            // Set the YAxis to Text type
            pane.XAxis.Type = AxisType.Text;
            pane.XAxis.Scale.MinorStepAuto = false;
            pane.XAxis.Scale.MinAuto = false;

            // expand the range of the Y axis slightly to accommodate the labels
            //pane.YAxis.Scale.Max = max * 1.33;
            //pane.XAxis.Scale.Max = 13.5;

            graphDifferential.AxisChange();

            // Create a label for each bar
            CreateBarLabels(pane, true, "N0");
            MonthsToRecover(pane, "N1");

            graphDifferential.Refresh();
        }

        /// <summary>
        /// Write the percentage of the first curve respect to the second
        /// </summary>
        /// <param name="pane">The GraphPane in which to place the text labels.</param>
        private void MonthsToRecover(GraphPane pane, string valueFormat)
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
            CurveItem curve1 = pane.CurveList[0];
            CurveItem curve2 = pane.CurveList[1];

            // work with BarItems only
            BarItem bar = curve1 as BarItem;
            if (bar != null)
            {
                IPointList points1 = curve1.Points;
                IPointList points2 = curve2.Points;

                // Loop through each point in the BarItem
                for (int i = 0; i < points1.Count; i++)
                {
                    double val1 = (isVertical ? points1[i].Y : points1[i].X);
                    double val2 = (isVertical ? points2[i].Y : points2[i].X);
                    if (val1 == 0.0) continue;
                    if (val2 == 0.0) continue;

                    // Get the high, low and base values for the current bar
                    // note that this method will automatically calculate the "effective"
                    // values if the bar is stacked
                    double baseVal1, lowVal1, hiVal1;
                    double baseVal2, lowVal2, hiVal2;
                    valueHandler.GetValues(curve1, i, out baseVal1, out lowVal1, out hiVal1);
                    valueHandler.GetValues(curve2, i, out baseVal2, out lowVal2, out hiVal2);

                    // Get the value that corresponds to the center of the bar base
                    // This method figures out how the bars are positioned within a cluster
                    float centerVal = (float)valueHandler.BarCenterValue(bar,
                        bar.GetBarWidth(pane), i, baseVal1, curveIndex);

                    // Create a text label -- note that we have to go back to the original point
                    // data for this, since hiVal and lowVal could be "effective" values from a bar stack
                    string barLabelText = (val1*100/val2).ToString(valueFormat) + "%";

                    // Calculate the position of the label -- this is either the X or the Y coordinate
                    // depending on whether they are horizontal or vertical bars, respectively
                    float position = (float)Math.Max(hiVal1, hiVal2) + labelOffset;

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
                    label.FontSpec.Angle = isVertical ? 0 : -90;
                    label.Location.AlignH = AlignH.Left;
                    label.Location.AlignV = AlignV.Center;
                    label.FontSpec.Border.IsVisible = false;
                    label.FontSpec.Fill.IsVisible = false;

                    // Add the TextObj to the GraphPane
                    pane.GraphObjList.Add(label);
                }
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

        private void txtData_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DrawGraphStructures();
                DrawDifferentialStructures();
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
                DrawGraphStructures();
                DrawDifferentialStructures();
            }
            catch (Exception)
            {
            }
        }

        private void ComputeStructures_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void chkShowStadiumIncomes_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DrawGraphStructures();
            }
            catch (Exception)
            {
            }
        }

        private void level_NumChanged(object sender, EventArgs e)
        {
            try
            {
                DrawDifferentialStructures();
            }
            catch (Exception)
            {
            }
        }
    }
}