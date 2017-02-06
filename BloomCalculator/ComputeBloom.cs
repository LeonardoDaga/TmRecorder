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
            PointPairList ah = new PointPairList();
            PointPairList ati = new PointPairList();

            int wn = 0;
            DateTime firstWeek = TmWeek.thisWeek().ToDate();
            firstWeek = age.ToDate();

            XDate xdate = (double)new XDate(firstWeek + TimeSpan.FromDays(7.0 * wn));
            wn++;
            ah.Add(xdate, (double)ActualASI);
            ati.Add(xdate, (double)ActualTI);

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

                ah.Add(xdate, (double)ActualASI + (double)Tm_Utility.SkSumToASI(skillsum, isGK) - (double)Tm_Utility.SkSumToASI(CurrentSkillSum, isGK));

                ati.Add(xdate, (double)devTI[years]);
            }

            decimal DeltaBloomASI = 0;
            decimal Delta30sASI = 0;

            DeltaBloomASI = Tm_Utility.SkSumToASI(EndOfBloomSkillSum, isGK) - Tm_Utility.SkSumToASI(CurrentSkillSum, isGK);

            Delta30sASI = Tm_Utility.SkSumToASI(TirthyYearsSkillSum, isGK) - Tm_Utility.SkSumToASI(CurrentSkillSum, isGK);

            EndOfBloomASI = (decimal)ActualASI + DeltaBloomASI;
            TopASI = (decimal)ActualASI + Delta30sASI;

            FillAsiGraph(ah, ati);
        }

        private void FillAsiGraph(PointPairList ah, PointPairList ati)
        {
            GraphPane pane = graphASI.GraphPane;
            pane.CurveList.Clear();

            // Set the title and axis labels
            pane.Title.Text = "ASI/TI Forecast";
            pane.YAxis.Title.Text = "ASI";
            pane.Y2Axis.Title.Text = "TI";
            pane.XAxis.Title.Text = "Years / Months";
            pane.XAxis.Type = AxisType.Date;
            pane.XAxis.Scale.MajorStep = 7 * 12;
            pane.XAxis.Scale.MinorStep = 1;
            pane.XAxis.Scale.MajorUnit = DateUnit.Day;
            pane.XAxis.Scale.Format = "TY";
            pane.Y2Axis.IsVisible = true;
            pane.Y2Axis.IsAxisSegmentVisible = true;
            pane.YAxis.Color = Color.Blue;
            pane.Y2Axis.Color = Color.Red;
            pane.Y2Axis.Scale.FontSpec.FontColor = Color.Red;
            pane.Y2Axis.Title.FontSpec.FontColor = Color.Red;
            pane.YAxis.Scale.FontSpec.FontColor = Color.Blue;
            pane.YAxis.Title.FontSpec.FontColor = Color.Blue;

            double dMin1 = double.MaxValue;
            double dMax1 = double.MinValue;
            double dMin2 = double.MaxValue;
            double dMax2 = double.MinValue;

            for (int i = 0; i < ah.Count; i++)
            {
                dMin1 = Math.Min(dMin1, ah[i].Y);
                dMax1 = Math.Max(dMax1, ah[i].Y);
                dMin2 = Math.Min(dMin2, ati[i].Y);
                dMax2 = Math.Max(dMax2, ati[i].Y);
            }

            // Fill the axis background with a color gradient
            pane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            // Generate a red curve with "ASI" in the legend
            LineItem myCurve1 = pane.AddCurve("ASI Forecast", ah, Color.Blue);
            LineItem myCurve2 = pane.AddCurve("TI Forecast", ati, Color.Red);

            myCurve2.IsVisible = true;
            myCurve2.IsY2Axis = true;

            // Make the symbols opaque by filling them with white
            myCurve1.Symbol.Fill = new Fill(Color.White);
            myCurve2.Symbol.Fill = new Fill(Color.Yellow);

            // Manually set the x axis range
            pane.YAxis.Scale.Min = dMin1 - 1.0;
            pane.YAxis.Scale.Max = dMax1 + 1.0;
            pane.Y2Axis.Scale.Min = 0;
            pane.Y2Axis.Scale.Max = dMax2 + 1.0;
            pane.XAxis.Scale.Min = ah[0].X;
            pane.XAxis.Scale.Max = ah[ah.Count - 1].X;

            pane.YAxis.Scale.MajorStep = (double)((int)((dMax1) / 10.0));
            pane.YAxis.Scale.MinorStep = (double)((int)(dMax1 / 50.0));
            pane.Y2Axis.Scale.MajorStep = (double)((int)((dMax2) / 10.0));
            pane.Y2Axis.Scale.MinorStep = (double)((int)(dMax2 / 50.0));
            if (pane.YAxis.Scale.MajorStep == 0) pane.YAxis.Scale.MajorStep = 1;
            if (pane.YAxis.Scale.MinorStep == 0) pane.YAxis.Scale.MinorStep = 1;
            if (pane.Y2Axis.Scale.MajorStep == 0) pane.Y2Axis.Scale.MajorStep = 1;
            if (pane.Y2Axis.Scale.MinorStep == 0) pane.Y2Axis.Scale.MinorStep = 1;

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