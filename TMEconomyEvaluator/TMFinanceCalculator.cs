using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TMFinanceCalculator.Properties;

namespace TMFinanceCalculator
{
    public partial class TMEconomyCalculator : Form
    {
        float LeaguePosition = 0.0f;
        float LeagueGoalsAgaints = 0.0f;
        float LeagueGoalsScored = 0.0f;
        float LeagueWins = 0.0f;
        float Cup = 0.0f;

        public TMEconomyCalculator()
        {
            InitializeComponent();
        }

        float Division
        {
            get { return (float)numDivision.Value; }
        }

        float VipLevel
        {
            get { return (float)numVipLevel.Value; }
        }

        float BarLevel
        {
            get { return (float)numBar.Value; }
        }

        float SausageLevel
        {
            get { return (float)numSausage.Value; }
        }

        float ShopsLevel
        {
            get { return (float)numShops.Value; }
        }

        float StandsLevel
        {
            get { return (float)numStands.Value; }
        }

        float RestaurantLevel
        {
            get { return (float)numRestaurant.Value; }
        }

        float NumLeagueGolScored
        {
            get { return (float)numLeagueGolScored.Value; }
        }

        float NumLeagueGolAgainst
        {
            get { return (float)numLeagueGolAgainst.Value; }
        }

        float NumLeagueWins
        {
            get { return (float)numLeagueWins.Value; }
        }

        float NumLeaguePosition
        {
            get { return (float)numLeaguePosition.Value; }
        }

        float NumCupWins
        {
            get { return (float)numCupWins.Value; }
        }

        float NumSpectators
        {
            get { return (float)numSpectators.Value; }
        }

        float NumSupporters
        {
            get { return (float)numOfSupporters.Value; }
        }

        float SponsorIncomeMax
        {
            set { txtSponsorIncomeMax.Text = value.ToString("N0"); }
            get { return float.Parse(txtSponsorIncomeMax.Text); }
        }

        float SponsorSeasBonus
        {
            set { txtSponsorSeasBonus.Text = value.ToString("N0"); }
            get { return float.Parse(txtSponsorSeasBonus.Text); }
        }

        float IncomesSausages
        {
            set { txtIncomesSausages.Text = value.ToString("N0"); }
            get { return float.Parse(txtIncomesSausages.Text); }
        }

        float IncomesRest
        {
            set { txtIncomesRest.Text = value.ToString("N0"); }
            get { return float.Parse(txtIncomesRest.Text); }
        }

        float IncomesShops
        {
            set { txtIncomesShops.Text = value.ToString("N0"); }
            get { return float.Parse(txtIncomesShops.Text); }
        }

        float IncomesStands
        {
            set { txtIncomesStands.Text = value.ToString("N0"); }
            get { return float.Parse(txtIncomesStands.Text); }
        }

        float IncomesBar
        {
            set { txtIncomesBar.Text = value.ToString("N0"); }
            get { return float.Parse(txtIncomesBar.Text); }
        }

        float IncomesFDBase
        {
            set { txtFDbase.Text = value.ToString("N0"); }
            get { return float.Parse(txtFDbase.Text); }
        }

        float MaintSausages
        {
            set { txtMaintSausages.Text = value.ToString("N0"); }
            get { return float.Parse(txtMaintSausages.Text); }
        }

        float MaintBar
        {
            set { txtMaintBar.Text = value.ToString("N0"); }
            get { return float.Parse(txtMaintBar.Text); }
        }

        float MaintRest
        {
            set { txtMaintRest.Text = value.ToString("N0"); }
            get { return float.Parse(txtMaintRest.Text); }
        }

        float MaintShops
        {
            set { txtMaintShops.Text = value.ToString("N0"); }
            get { return float.Parse(txtMaintShops.Text); }
        }

        float MaintStands
        {
            set { txtMaintStands.Text = value.ToString("N0"); }
            get { return float.Parse(txtMaintStands.Text); }
        }

        float MaintVip
        {
            set { txtMaintVip.Text = value.ToString("N0"); }
            get { return float.Parse(txtMaintVip.Text); }
        }

        float TotMaintxSeason
        {
            set { txtTotMaintxSeason.Text = value.ToString("N0"); }
            get { return float.Parse(txtTotMaintxSeason.Text); }
        }

        float TotGain
        {
            set { txtTotGain.Text = value.ToString("N0"); }
            get { return float.Parse(txtTotGain.Text); }
        }

        float TotIncomes
        {
            set { txtTotIncomes.Text = value.ToString("N0"); }
            get { return float.Parse(txtTotIncomes.Text); }
        }

        private void chkLeaguePositionChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
                LeaguePosition = float.Parse((string)rb.Tag);
            UpdateResults();
        }

        private void chkLeagueGoalsAgaintsChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
                LeagueGoalsAgaints = float.Parse((string)rb.Tag);
            UpdateResults();
        }

        private void chkLeagueGoalsScoredChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
                LeagueGoalsScored = float.Parse((string)rb.Tag);
            UpdateResults();
        }

        private void chkLeagueWinsChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
                LeagueWins = float.Parse((string)rb.Tag);
            UpdateResults();
        }

        private void chkCupChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
                Cup = float.Parse((string)rb.Tag);
            UpdateResults();
        }

        private void numOfSpectChanged(object sender, EventArgs e)
        {
            UpdateResults();
        }

        private void numStructuresLevChanged(object sender, EventArgs e)
        {
            UpdateResults();
        }

        private void numVipLevChanged(object sender, EventArgs e)
        {
            UpdateObjectives();
            UpdateResults();
        }

        private void UpdateObjectives()
        {
            // League gol scored
            int numLeagueGolScored = (int)NumLeagueGolScored;
            int numLeagueGolAgainst = (int)NumLeagueGolAgainst;
            int numLeaguePosition = (int)NumLeaguePosition;
            int numCupWins = (int)NumCupWins;
            int numLeagueWins = (int)NumLeagueWins;
            int vipLevel = (int)VipLevel;

            if ((numLeagueGolScored >= 70) && (vipLevel >= 9)) rbLGS_5.Checked = true;
            else if ((numLeagueGolScored >= 60) && (vipLevel >= 5)) rbLGS_4.Checked = true;
            else if ((numLeagueGolScored >= 50) && (vipLevel >= 3)) rbLGS_3.Checked = true;
            else if ((numLeagueGolScored >= 40) && (vipLevel >= 1))  rbLGS_2.Checked = true;
            else if ((numLeagueGolScored >= 30) && (vipLevel >= 1))  rbLGS_1.Checked = true;
            else rbLGS_0.Checked = true;

            // League gol against
            if ((numLeagueGolAgainst < 30) && (vipLevel >= 9)) rbLGA_5.Checked = true;
            else if ((numLeagueGolAgainst < 40) && (vipLevel >= 6)) rbLGA_4.Checked = true;
            else if ((numLeagueGolAgainst < 50) && (vipLevel >= 4)) rbLGA_3.Checked = true;
            else if ((numLeagueGolAgainst < 60) && (vipLevel >= 2)) rbLGA_2.Checked = true;
            else if ((numLeagueGolAgainst < 70) && (vipLevel >= 1))  rbLGA_1.Checked = true;
            else rbLGA_0.Checked = true;

            // League position
            if ((numLeaguePosition <= 2) && (vipLevel >= 8)) rbLP_6.Checked = true;
            else if ((numLeaguePosition <= 4) && (vipLevel >= 7)) rbLP_5.Checked = true;
            else if ((numLeaguePosition <= 6) && (vipLevel >= 5)) rbLP_4.Checked = true;
            else if ((numLeaguePosition <= 9) && (vipLevel >= 3)) rbLP_3.Checked = true;
            else if ((numLeaguePosition <= 12) && (vipLevel >= 1))  rbLP_2.Checked = true;
            else if ((numLeaguePosition <= 16) && (vipLevel >= 1))  rbLP_1.Checked = true;
            else rbLP_0.Checked = true;

            // Cup Wins
            if ((numCupWins >= 5) && (vipLevel >= 10)) rbC_5.Checked = true;
            else if ((numCupWins >= 4) && (vipLevel >= 7)) rbC_4.Checked = true;
            else if ((numCupWins >= 3) && (vipLevel >= 4)) rbC_3.Checked = true;
            else if ((numCupWins >= 2) && (vipLevel >= 1))  rbC_2.Checked = true;
            else if ((numCupWins >= 1) && (vipLevel >= 1))  rbC_1.Checked = true;
            else rbC_0.Checked = true;

            // League Wins
            if ((numLeagueWins >= 25) && (vipLevel >= 10)) rbLW_5.Checked = true;
            else if ((numLeagueWins >= 20) && (vipLevel >= 8)) rbLW_4.Checked = true;
            else if ((numLeagueWins >= 15) && (vipLevel >= 6)) rbLW_3.Checked = true;
            else if ((numLeagueWins >= 10) && (vipLevel >= 2)) rbLW_2.Checked = true;
            else if ((numLeagueWins >= 5) && (vipLevel >= 1)) rbLW_1.Checked = true;
            else rbLW_0.Checked = true;
        }

        float CupBonus
        {
            get
            {
                if (Cup == -1) return 0.0f;
                return BonusBase((int)Division) *(1.0f + 0.1f * VipLevel) * BaseMultiplier((int)Cup);
            }
        }

        float LeagueGoalsScoredBonus
        {
            get
            {
                if (LeagueGoalsScored == -1) return 0.0f;
                return BonusBase((int)Division) * (1.0f + 0.1f * VipLevel) * BaseMultiplier((int)LeagueGoalsScored);
            }
        }

        float LeagueGoalsAgaintsBonus
        {
            get
            {
                if (LeagueGoalsAgaints == -1) return 0.0f;
                return BonusBase((int)Division) * (1.0f + 0.1f * VipLevel) * BaseMultiplier((int)LeagueGoalsAgaints);
            }
        }

        float LeaguePositionBonus
        {
            get
            {
                if (LeaguePosition == -1) return 0.0f;
                return BonusBase((int)Division) * (1.0f + 0.1f * VipLevel) * BaseMultiplier((int)LeaguePosition);
            }
        }

        float LeagueWinsBonus
        {
            get
            {
                if (LeagueWins == -1) return 0.0f;
                return BonusBase((int)Division) * (1.0f + 0.1f * VipLevel) * DblMultiplier((int)LeagueWins);
            }
        }

        private float BaseMultiplier(int level)
        {
            return (level == 0) ? 1.0f :
                (level == 1) ? 3.0f :
                (level == 2) ? 3.0f * 2.2f :
                (level == 3) ? 3.0f * 2.2f * 1.515152f :
                (level == 4) ? 3.0f * 2.2f * 1.515152f * 1.21f :
                (level == 5) ? 3.0f * 2.2f * 1.515152f * 1.21f * 1.19f : 0.0f;
        }

        private float DblMultiplier(int level)
        {
            return (level == 0) ? 1.0f:
                (level == 1) ? 3.0f * 2.2f :
                (level == 2) ? 3.0f * 2.2f * 1.515152f * 1.21f :
                (level == 3) ? 3.0f * 2.2f * 1.515152f * 1.21f :
                (level == 4) ? 3.0f * 2.2f * 1.515152f * 1.21f :
                (level == 5) ? 3.0f * 2.2f * 1.515152f * 1.21f : 0.0f;
        }

        private float BonusBase(int Division)
        {
            return (Division == 1) ? 1100000.0f :
                (Division == 2) ? 1000000.0f :
                (Division == 3) ? 900000.0f :
                (Division == 4) ? 830000.0f :
                (Division == 5) ? 740000.0f :
                (Division == 6) ? 650000.0f :
                (Division == 7) ? 560000.0f :
                (Division == 8) ? 470000.0f :
                (Division == 9) ? 380000.0f : 0.0f;

        }

        private void UpdateResults()
        {
            UpdateMaintCosts();
            UpdateIncomes();
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            TotMaintxSeason = MaintVip + MaintSausages + MaintRest + MaintBar + MaintShops + MaintStands;
            TotIncomes = IncomesBar + IncomesFDBase + IncomesRest + IncomesSausages + SponsorIncomeMax
                + SponsorSeasBonus + IncomesStands + IncomesShops;
            TotGain = TotIncomes - TotMaintxSeason;
        }

        private void UpdateIncomes()
        {
            SponsorIncomeMax = 8058789.0f + (8059.0f * VipLevel) + (306030.0f + 306.0f * VipLevel) * (8.0f - Division);
            SponsorSeasBonus = CupBonus + LeagueGoalsScoredBonus + LeagueGoalsAgaintsBonus + LeaguePositionBonus
                + LeagueWinsBonus;
            IncomesFDBase = 28.0f * NumSpectators * 17.0f;
            IncomesBar = 0.3f * BarLevel * Limit(NumSpectators, BarLevel) * 17.0f;
            IncomesSausages = 0.15f * SausageLevel * Limit(NumSpectators, SausageLevel) * 17.0f;
            IncomesRest = 1.5f * RestaurantLevel * Limit(NumSpectators, RestaurantLevel) * 17.0f;
            IncomesStands = (7.5f + 2.0f * StandsLevel) * Limit(NumSpectators, StandsLevel) * 17.0f;
            IncomesShops = LimitIncShops(ShopsLevel, NumSupporters * (25.0f + 0.5f * ShopsLevel)) * 17.0f;
        }

        private float Limit(float NumSpectators, float level)
        {
            int limitServ = 0;

            switch ((int)(level+0.1f))
            {
                case 1: limitServ = 1000; break;
                case 2: limitServ = 2500; break;
                case 3: limitServ = 5000; break;
                case 4: limitServ = 10000; break;
                case 5: limitServ = 15000; break;
                case 6: limitServ = 20000; break;
                case 7: limitServ = 35000; break;
                case 8: limitServ = 55000; break;
                case 9: limitServ = 75000; break;
                default: limitServ = 150000; break;
            }

            if (NumSpectators > limitServ)
                NumSpectators = limitServ;

            return NumSpectators;
        }

        private float LimitIncShops(float ShopsLevel, float incomes)
        {
            if (ShopsLevel == 0) return 0;
            else if ((ShopsLevel == 1) && (incomes > 51000)) return 51000;
            else if ((ShopsLevel == 2) && (incomes > 208000)) return 208000;
            else if ((ShopsLevel == 3) && (incomes > 477000)) return 477000;
            else if ((ShopsLevel == 4) && (incomes > 864000)) return 864000;
            else if ((ShopsLevel == 5) && (incomes > 1375000)) return 1375000;
            else if ((ShopsLevel == 6) && (incomes > 2016000)) return 2016000;
            else if ((ShopsLevel == 7) && (incomes > 2793000)) return 2793000;
            else return incomes;
        }

        private void UpdateMaintCosts()
        {
            switch ((int)BarLevel)
            {
                case 0: MaintBar = 0; break;
                case 1: MaintBar = 15000; break;
                case 2: MaintBar = 73869; break;
                case 3: MaintBar = 187703; break;
                case 4: MaintBar = 363772; break;
                case 5: MaintBar = 607746; break;
                case 6: MaintBar = 924356; break;
                case 7: MaintBar = 1317701; break;
            }
            MaintBar *= 12;

            switch ((int)RestaurantLevel)
            {
                case 0: MaintRest = 0; break;
                case 1: MaintRest = 12000; break;
                case 2: MaintRest = 70000; break;
                case 3: MaintRest = 190000; break;
                case 4: MaintRest = 400000; break;
                case 5: MaintRest = 700000; break;
                case 6: MaintRest = 1100000; break;
            }
            MaintRest *= 12;

            switch ((int)SausageLevel)
            {
                case 0: MaintSausages = 0; break;
                case 1: MaintSausages = 4000; break;
                case 2: MaintSausages = 20000; break;
                case 3: MaintSausages = 50000; break;
                case 4: MaintSausages = 97000; break;
                case 5: MaintSausages = 162000; break;
                case 6: MaintSausages = 246000; break;
                case 7: MaintSausages = 350000; break;
            }
            MaintSausages *= 12;

            switch ((int)ShopsLevel)
            {
                case 0: MaintShops = 0; break;
                case 1: MaintShops = 40000; break;
                case 2: MaintShops = 113137; break;
                case 3: MaintShops = 207846; break;
                case 4: MaintShops = 320000; break;
                case 5: MaintShops = 447214; break;
                case 6: MaintShops = 587878; break;
                case 7: MaintShops = 740810; break;
            }
            MaintShops *= 12;

            switch ((int)StandsLevel)
            {
                case 0: MaintStands = 0; break;
                case 1: MaintStands = 5500; break;
                case 2: MaintStands = 22000; break;
                case 3: MaintStands = 49000; break;
                case 4: MaintStands = 86000; break;
                case 5: MaintStands = 135000; break;
                case 6: MaintStands = 200000; break;
                case 7: MaintStands = 270000; break;
            }
            MaintStands *= 12;

            switch ((int)VipLevel)
            {
                case 0: MaintVip = 0; break;
                case 1: MaintVip = 167000; break;
                case 2: MaintVip = 503000; break;
                case 3: MaintVip = 914000; break;
                case 4: MaintVip = 1587000; break;
                case 5: MaintVip = 2415000; break;
                case 6: MaintVip = 3329000; break;
                case 7: MaintVip = 4336000; break;
                case 8: MaintVip = 5418000; break;
                case 9: MaintVip = 6652000; break;
                case 10: MaintVip = 8088000; break;
            }
            MaintVip *= 12;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateResults();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://trophymanager.com/klubhus.php?showclub=40442");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://trophymanager.com/klubhus.php?showclub=185445");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://trophymanager.com/klubhus.php?showclub=130611");
        }

        private void numExpectedResults_Changed(object sender, EventArgs e)
        {
            UpdateObjectives();
            UpdateResults();
        }
    }
}