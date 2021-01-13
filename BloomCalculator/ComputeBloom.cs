using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;
using ZedGraph;

namespace BloomCalculator
{
    public partial class ComputeBloom : Form
    {
        System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo("en-US", false).NumberFormat;

        class ASIpart
        {
            public TmWeek week;
            public decimal ASI;
        }

        class ASIhist : List<ASIpart>
        {
            public void Add(TmWeek w, decimal asi)
            {
                ASIpart ap = new ASIpart();
                ap.week = w;
                ap.ASI = asi;
                this.Add(ap);
            }
        }

        public bool isGK = false;

        private TmWeek age;
        int _bWeek = 0;

        public int ActualASI
        {
            get
            {
                int val = 0;
                int.TryParse(txtActualASI.Text, out val);
                return val;
            }
            set { txtActualASI.Text = value.ToString(); }
        }

        public TmWeek ActualAge
        {
            get
            {
                int valY = 0;
                int.TryParse(txtAge.Text, out valY);
                int valM = 0;
                int.TryParse(txtMonths.Text, out valM);
                return TmWeek.FromAge(valY, valM);
            }
        }

        public decimal CurrentSkillSum
        {
            get
            {
                if (txtCurrentSkillSum.Text != "")
                    return decimal.Parse(txtCurrentSkillSum.Text, nfi);
                else
                    return 0M;
            }
            set
            {
                txtCurrentSkillSum.Text = value.ToString("N1", nfi);
            }
        }

        public decimal EndOfBloomSkillSum
        {
            get
            {
                if (txtEndOfBloomSkillSum.Text == "---")
                    return CurrentSkillSum;
                else
                    return decimal.Parse(txtEndOfBloomSkillSum.Text, nfi);
            }
            set
            {
                if (value == CurrentSkillSum)
                    txtEndOfBloomSkillSum.Text = "---";
                else
                {
                    nfi.NumberDecimalDigits = 0;
                    txtEndOfBloomSkillSum.Text = value.ToString(nfi);
                }
            }
        }

        public decimal EndOfBloomASI
        {
            get
            {
                if (txtEndOfBloomASI.Text == "---")
                    return ActualASI;
                else
                {
                    nfi.NumberDecimalDigits = 1;
                    return decimal.Parse(txtEndOfBloomASI.Text, nfi);
                }
            }
            set
            {
                if (EndOfBloomSkillSum == CurrentSkillSum)
                    txtEndOfBloomASI.Text = "---";
                else
                {
                    nfi.NumberDecimalDigits = 0;
                    nfi.CurrencyGroupSeparator = "";
                    nfi.NumberGroupSeparator = "";
                    txtEndOfBloomASI.Text = value.ToString("N", nfi);
                }
            }
        }

        public decimal TopASI
        {
            get
            {
                decimal val = 0M;
                decimal.TryParse(txtTopASI.Text, System.Globalization.NumberStyles.Float,
                    nfi, out val);
                return val;
            }
            set
            {
                nfi.NumberDecimalDigits = 0;
                nfi.CurrencyGroupSeparator = "";
                nfi.NumberGroupSeparator = "";
                txtTopASI.Text = value.ToString("N", nfi);
            }
        }

        public int AgeStartOfBloom
        {
            get
            {
                int val = 0;
                int.TryParse(txtAgeStartOfBloom.Text, out val);
                return val;
            }
            set { txtAgeStartOfBloom.Text = value.ToString(); }
        }

        public decimal BeforeExplosionTI
        {
            get
            {
                nfi.NumberDecimalDigits = 1;

                decimal val = 0M;
                decimal.TryParse(txtBeforeExplTI.Text, System.Globalization.NumberStyles.Float,
                    nfi, out val);
                return val;
            }
            set
            {
                nfi.NumberDecimalDigits = 1;
                txtBeforeExplTI.Text = value.ToString("N", nfi);
            }
        }

        public decimal ActualTI
        {
            get
            {
                nfi.NumberDecimalDigits = 1;
                decimal val = 0M;
                decimal.TryParse(txtActualTI.Text, System.Globalization.NumberStyles.Float,
                    nfi, out val);
                return val;
            }
            set
            {
                nfi.NumberDecimalDigits = 1;
                txtActualTI.Text = value.ToString("N", nfi);
            }
        }

        public decimal ExplosionTI
        {
            get
            {
                nfi.NumberDecimalDigits = 1;
                decimal val = 0M;
                decimal.TryParse(txtExplosionTI.Text, System.Globalization.NumberStyles.Float,
                    nfi, out val);
                return val;
            }
            set
            {
                nfi.NumberDecimalDigits = 1;
                txtExplosionTI.Text = value.ToString("N", nfi);
            }
        }

        public decimal AfterBloomingTI
        {
            get
            {
                decimal val = 0M;
                decimal.TryParse(txtAfterBloomingTI.Text, System.Globalization.NumberStyles.Float,
                    nfi, out val);
                return val;
            }
            set
            {
                nfi.NumberDecimalDigits = 1;
                txtAfterBloomingTI.Text = value.ToString("N", nfi);
            }
        }

        public ComputeBloom()
        {
            InitializeComponent();
        }

        public void CalcBloom()
        {
            decimal skillsum = CurrentSkillSum;
            decimal currentTI = 0;
            decimal[] devTI = new decimal[40];

            if (age == null) return;
            txtBeforeExplTI.Enabled = ((age.Years < AgeStartOfBloom + 2) &&
                (age.Years >= AgeStartOfBloom)) &&
                (AgeStartOfBloom < 19);
            txtExplosionTI.Enabled = (age.Years < AgeStartOfBloom);
            txtAfterBloomingTI.Enabled = (age.Years < AgeStartOfBloom + 3);

            if (age.Years - AgeStartOfBloom >= 3)
            {
                // The player is already bloomed
                for (int years = age.Years; years <= 32; years++)
                {
                    devTI[years] = ActualTI + ((0M - ActualTI) * (decimal)(years - age.Years)) / (decimal)(30 - age.Years);
                }

            }
            else if ((age.Years - AgeStartOfBloom >= 0) && (age.Years - AgeStartOfBloom < 3))
            {
                // The player is blooming
                int yy = age.Years;

                if (AgeStartOfBloom >= 19)
                {
                    devTI[yy] = ActualTI;
                    devTI[yy + 1] = ActualTI * 0.97M;
                    devTI[yy + 2] = ActualTI * 0.94M;

                    int r = age.Years - AgeStartOfBloom;
                    // The player is already bloomed

                    for (int years = yy + 3 - r; years <= 32; years++)
                    {
                        devTI[years] = AfterBloomingTI + ((0M - AfterBloomingTI) * (decimal)(years - (yy + 3))) / (decimal)(30 - (yy + 3));
                    }
                }
                else if (yy == AgeStartOfBloom)
                {
                    devTI[yy] = ActualTI;

                    if ((yy + 1) < 19)
                        devTI[yy + 1] = ActualTI;
                    else
                        devTI[yy + 1] = ActualTI - BeforeExplosionTI / 2M;

                    if ((yy + 2) < 19)
                        devTI[yy + 2] = ActualTI;
                    else
                        devTI[yy + 2] = ActualTI - BeforeExplosionTI / 2M;

                    // The player is already bloomed
                    for (int years = yy + 3; years <= 32; years++)
                    {
                        devTI[years] = AfterBloomingTI + ((0M - AfterBloomingTI) * (decimal)(years - (yy + 3))) / (decimal)(30 - (yy + 3));
                    }
                }
                else if (yy == AgeStartOfBloom + 1)
                {
                    devTI[yy] = ActualTI;

                    if (yy == 18)
                        devTI[yy + 1] = ActualTI - BeforeExplosionTI / 2M;
                    else // (yy > 18) OR ((yy+1 < 19) && (yy < 19))
                        devTI[yy + 1] = ActualTI;

                    // The player is already bloomed
                    for (int years = yy + 2; years <= 32; years++)
                    {
                        devTI[years] = AfterBloomingTI + ((0M - AfterBloomingTI) * (decimal)(years - (yy + 2))) / (decimal)(30 - (yy + 2));
                    }
                }
                else if (yy == AgeStartOfBloom + 2)
                {
                    devTI[yy] = ActualTI;

                    // The player is already bloomed
                    for (int years = yy + 1; years <= 32; years++)
                    {
                        devTI[years] = AfterBloomingTI + ((0M - AfterBloomingTI) * (decimal)(years - (yy + 1))) / (decimal)(30 - (yy + 1));
                    }
                }
            }
            else // (yy < AgeStartOfBloom)
            {
                // The player is still not blooming
                int yy = age.Years;

                int years = yy;

                // The player is already bloomed
                for (; years < AgeStartOfBloom; years++)
                {
                    if (years < 19)
                        devTI[years] = ActualTI;
                    else if (yy < 19)
                        devTI[years] = ActualTI / 2M;
                    else
                        devTI[years] = ActualTI;
                }

                decimal lastTI = devTI[years - 1];

                // The player is already bloomed
                for (; years <= AgeStartOfBloom + 2; years++)
                {
                    if ((years < 19) || (AgeStartOfBloom > 18))
                        devTI[years] = ExplosionTI;
                    else
                        devTI[years] = ExplosionTI - lastTI / 2M;
                }

                int y0 = years;
                // The player is already bloomed
                for (; years <= 32; years++)
                {
                    devTI[years] = AfterBloomingTI + ((0M - AfterBloomingTI) * (decimal)(years - y0)) / (decimal)(30 - y0);
                }
            }

            EndOfBloomSkillSum = skillsum;

            decimal TirthyYearsSkillSum = 0M;
            PointPairList actualAsiPpl = new PointPairList();
            PointPairList actualTiPpl = new PointPairList();
            PointPairList actualStaPpl = new PointPairList();
            PointPairList actualWagePpl = new PointPairList();
            PointPairList actualCumWagePpl = new PointPairList();

            int wn = 0;
            int ageMonths = age.absweek;
            DateTime firstWeek = TmWeek.thisWeek().ToDate();
            firstWeek = age.ToDate();
            int staValue = Utility.SellToAgentPrice(this.isGK ? 0 : 1, ActualASI, ageMonths);
            int wage = Tm_Utility.ASItoWage(ActualASI, this.isGK ? 0 : 1);

            XDate xdate = (double)new XDate(firstWeek + TimeSpan.FromDays(7.0 * wn));
            wn++;
            actualAsiPpl.Add(xdate, (double)ActualASI);
            actualTiPpl.Add(xdate, (double)ActualTI);
            actualStaPpl.Add(xdate, (double)staValue);
            actualWagePpl.Add(xdate, (double)wage);

            double cumWage = wage;
            actualCumWagePpl.Add(xdate, (double)cumWage);

            for (int week = age.absweek + 1; week < 32 * 12; week++, wn++)
            {
                int years = week / 12;

                if (week == (AgeStartOfBloom + 3) * 12) // ((years == AgeStartOfBloom + 3)
                    EndOfBloomSkillSum = skillsum;

                if (week == 30 * 12) // ((years == AgeStartOfBloom + 3)
                {
                    TirthyYearsSkillSum = skillsum;
                }

                xdate = (double)new XDate(firstWeek + TimeSpan.FromDays(7.0 * wn));

                skillsum += 0.1M * devTI[years];

                double newASI = (double)ActualASI + (double)Tm_Utility.SkSumToASI(skillsum, isGK) - (double)Tm_Utility.SkSumToASI(CurrentSkillSum, isGK);

                actualAsiPpl.Add(xdate, newASI);
                actualTiPpl.Add(xdate, (double)devTI[years]);

                staValue = Utility.SellToAgentPrice(this.isGK ? 0 : 1, (int)newASI, week);
                wage = Tm_Utility.ASItoWage((int)newASI, this.isGK ? 0 : 1);
                cumWage += wage;

                actualStaPpl.Add(xdate, (double)staValue);
                actualWagePpl.Add(xdate, (double)wage);
                actualCumWagePpl.Add(xdate, (double)cumWage);
            }

            decimal DeltaBloomASI = 0;
            decimal Delta30sASI = 0;

            DeltaBloomASI = Tm_Utility.SkSumToASI(EndOfBloomSkillSum, isGK) - Tm_Utility.SkSumToASI(CurrentSkillSum, isGK);

            Delta30sASI = Tm_Utility.SkSumToASI(TirthyYearsSkillSum, isGK) - Tm_Utility.SkSumToASI(CurrentSkillSum, isGK);

            EndOfBloomASI = (decimal)ActualASI + DeltaBloomASI;
            TopASI = (decimal)ActualASI + Delta30sASI;

            FillAsiGraph(actualAsiPpl, actualTiPpl, actualStaPpl, actualWagePpl, actualCumWagePpl);
        }

        private void FillAsiGraph(PointPairList actualAsiPpl, PointPairList actualTiPpl
            , PointPairList actualStaPpl, PointPairList actualWagePpl, PointPairList actualCumWagePpl)
        {
            MasterPane master = graphASI.MasterPane;

            // Remove the default pane that comes with the ZedGraphControl.MasterPane
            master.PaneList.Clear();

            // Set the master pane title
            master.Title.Text = "Bloom Compuation";
            master.Title.IsVisible = true;

            // Fill the axis background with a color gradient
            master.Fill = new Fill(Color.FromArgb(240, 255, 240), Color.FromArgb(190, 255, 190), 90F);

            // Set the margins and the space between panes to 10 points
            master.Margin.All = 5;
            master.InnerPaneGap = 5;

            // 1o grafico
            {
                GraphPane pane = new GraphPane();

                // Set the title and axis labels
                pane.Title.Text = "ASI/TI Forecast";
                pane.YAxis.Title.Text = "ASI";
                pane.XAxis.Title.Text = "Years / Months";
                pane.XAxis.Type = AxisType.Date;
                pane.XAxis.Scale.MajorStep = 7 * 12;
                pane.XAxis.Scale.MinorStep = 1;
                pane.XAxis.Scale.MajorUnit = DateUnit.Day;
                pane.XAxis.Scale.Format = "TY";
                pane.YAxis.Color = Color.Blue;
                pane.YAxis.Scale.FontSpec.FontColor = Color.Blue;
                pane.YAxis.Title.FontSpec.FontColor = Color.Blue;

                pane.Y2Axis.Title.Text = "TI";
                pane.Y2Axis.IsVisible = true;
                pane.Y2Axis.IsAxisSegmentVisible = true;
                pane.Y2Axis.Color = Color.Red;
                pane.Y2Axis.Scale.FontSpec.FontColor = Color.Red;
                pane.Y2Axis.Title.FontSpec.FontColor = Color.Red;

                double dMin1 = double.MaxValue;
                double dMax1 = double.MinValue;
                double dMin2 = double.MaxValue;
                double dMax2 = double.MinValue;

                for (int i = 0; i < actualAsiPpl.Count; i++)
                {
                    dMin1 = Math.Min(dMin1, actualAsiPpl[i].Y);
                    dMax1 = Math.Max(dMax1, actualAsiPpl[i].Y);
                    dMin2 = Math.Min(dMin2, actualTiPpl[i].Y);
                    dMax2 = Math.Max(dMax2, actualTiPpl[i].Y);
                }

                double range1, step1, range2, step2;
                (range1, dMin1, dMax1, step1) = Utility.BestTicks(dMin1, dMax1);
                (range2, dMin2, dMax2, step2) = Utility.BestTicks(dMin2, dMax2);

                // Fill the axis background with a color gradient
                pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

                // Generate a red curve with "ASI" in the legend
                LineItem myCurve1 = pane.AddCurve("ASI Forecast", actualAsiPpl, Color.Blue);
                LineItem myCurve2 = pane.AddCurve("TI Forecast", actualTiPpl, Color.Red);

                myCurve2.IsVisible = true;
                myCurve2.IsY2Axis = true;

                // Make the symbols opaque by filling them with white
                myCurve1.Symbol.Fill = new Fill(Color.White);
                myCurve2.Symbol.Fill = new Fill(Color.Yellow);

                // Manually set the x axis range
                pane.YAxis.Scale.MajorStep = step1;
                pane.YAxis.Scale.MinorStep = step1 / 5;
                pane.YAxis.Scale.Min = dMin1;
                pane.YAxis.Scale.Max = dMax1;
                pane.Y2Axis.Scale.MajorStep = step2;
                pane.Y2Axis.Scale.MinorStep = step2 / 5;
                pane.Y2Axis.Scale.Min = dMin2;
                pane.Y2Axis.Scale.Max = dMax2;

                pane.YAxis.MajorGrid.IsVisible = true;
                pane.YAxis.MinorGrid.IsVisible = true;
                pane.Y2Axis.MajorGrid.IsVisible = true;
                pane.Y2Axis.MinorGrid.IsVisible = true;

                master.Add(pane);
            }


            // 2o grafico
            {
                GraphPane pane = new GraphPane();

                // Set the title and axis labels
                pane.Title.Text = "StA/Cumul. Wage Forecast";
                pane.YAxis.Title.Text = "StA/Cum.Wage";
                pane.XAxis.Title.Text = "Years / Months";
                pane.XAxis.Type = AxisType.Date;
                pane.XAxis.Scale.MajorStep = 7 * 12;
                pane.XAxis.Scale.MinorStep = 1;
                pane.XAxis.Scale.MajorUnit = DateUnit.Day;
                pane.XAxis.Scale.Format = "TY";

                pane.YAxis.Color = Color.Blue;
                pane.YAxis.Scale.FontSpec.FontColor = Color.Blue;
                pane.YAxis.Title.FontSpec.FontColor = Color.Blue;

                double dMin1 = double.MaxValue;
                double dMax1 = double.MinValue;

                for (int i = 0; i < actualStaPpl.Count; i++)
                {
                    dMin1 = Math.Min(dMin1, actualStaPpl[i].Y);
                    dMax1 = Math.Max(dMax1, actualStaPpl[i].Y);
                    dMin1 = Math.Min(dMin1, actualCumWagePpl[i].Y);
                    dMax1 = Math.Max(dMax1, actualCumWagePpl[i].Y);
                }

                double range1, step1, range2, step2;
                (range1, dMin1, dMax1, step1) = Utility.BestTicks(dMin1, dMax1);

                // Fill the axis background with a color gradient
                pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

                // Generate a red curve with "ASI" in the legend
                LineItem myCurve1 = pane.AddCurve("Selling to Agent Forecast", actualStaPpl, Color.Blue);
                LineItem myCurve3 = pane.AddCurve("Cum. Wage Forecast", actualCumWagePpl, Color.Red);

                // Make the symbols opaque by filling them with white
                myCurve1.Symbol.Fill = new Fill(Color.White);
                myCurve3.Symbol.Fill = new Fill(Color.Orange);

                // Manually set the x axis range
                pane.YAxis.Scale.MajorStep = step1;
                pane.YAxis.Scale.MinorStep = step1 / 5;
                pane.YAxis.Scale.Min = dMin1;
                pane.YAxis.Scale.Max = dMax1;

                pane.YAxis.MajorGrid.IsVisible = true;
                pane.YAxis.MinorGrid.IsVisible = true;

                master.Add(pane);
            }

            // 3o grafico
            {
                GraphPane pane = new GraphPane();

                // Set the title and axis labels
                pane.Title.Text = "Wage Forecast";
                pane.YAxis.Title.Text = "Wage";
                pane.XAxis.Title.Text = "Years / Months";
                pane.XAxis.Type = AxisType.Date;
                pane.XAxis.Scale.MajorStep = 7 * 12;
                pane.XAxis.Scale.MinorStep = 1;
                pane.XAxis.Scale.MajorUnit = DateUnit.Day;
                pane.XAxis.Scale.Format = "TY";

                pane.YAxis.Color = Color.Blue;
                pane.YAxis.Scale.FontSpec.FontColor = Color.Blue;
                pane.YAxis.Title.FontSpec.FontColor = Color.Blue;

                double dMin2 = double.MaxValue;
                double dMax2 = double.MinValue;

                for (int i = 0; i < actualWagePpl.Count; i++)
                {
                    dMin2 = Math.Min(dMin2, actualWagePpl[i].Y);
                    dMax2 = Math.Max(dMax2, actualWagePpl[i].Y);
                }

                double range2, step2;
                (range2, dMin2, dMax2, step2) = Utility.BestTicks(dMin2, dMax2);

                // Fill the axis background with a color gradient
                pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

                // Generate a red curve with "ASI" in the legend
                LineItem myCurve2 = pane.AddCurve("Wage Forecast", actualWagePpl, Color.Green);

                // Make the symbols opaque by filling them with white
                myCurve2.Symbol.Fill = new Fill(Color.Yellow);

                // Manually set the x axis range
                pane.YAxis.Scale.MajorStep = step2;
                pane.YAxis.Scale.MinorStep = step2 / 5;
                pane.YAxis.Scale.Min = dMin2;
                pane.YAxis.Scale.Max = dMax2;

                pane.YAxis.MajorGrid.IsVisible = true;
                pane.YAxis.MinorGrid.IsVisible = true;

                master.Add(pane);
            }

            // Tell ZedGraph to auto layout all the panes
            using (Graphics g = graphASI.CreateGraphics())
            {
                master.SetLayout(g, PaneLayout.ExplicitCol12);
                master.AxisChange(g);
            }

            graphASI.AxisChange();
            graphASI.Refresh();
        }

        private void txtData_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcBloom();
            }
            catch (Exception)
            {
            }
        }

        private void ComputeBloom_Load(object sender, EventArgs e)
        {
            Text = "Trophy Manager - Bloom Calculator v." + Application.ProductVersion;
            try
            {
                CalcBloom();
            }
            catch (Exception)
            {
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://trophymanager.com/klubhus.php?showclub=218974");
        }

        private void txtActualASI_TextChanged(object sender, EventArgs e)
        {
            CurrentSkillSum = Tm_Utility.ASItoSkSum((decimal)ActualASI, chkGK.Checked);
            CalcBloom();
        }

        private void chkGK_CheckedChanged(object sender, EventArgs e)
        {
            isGK = chkGK.Checked;
            txtActualASI_TextChanged(sender, e);
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            age = ActualAge;
            txtActualASI_TextChanged(sender, e);
        }
    }
}