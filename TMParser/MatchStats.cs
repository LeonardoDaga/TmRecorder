using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common;
using NTR_Db;
using NTR_Common;

namespace TMRecorder
{
    public partial class MatchStats : UserControl
    {
        public MatchStats()
        {
            InitializeComponent();
        }

        internal void SetMatchData(MatchData matchData)
        {
            if ((matchData != null) && (matchData.LineUps != null))
            {
                string[] lineUps = matchData.LineUps.Split(';');

                txtLineUp1.Text = lineUps[0];
                txtLineUp2.Text = lineUps[1];

                string[] Stats = matchData.Stats.Split(';');

                txtPossession1.Text = Stats[0];
                txtPossession2.Text = Stats[6];

                txtShots1.Text = Stats[1];
                txtShots2.Text = Stats[7];

                txtOnTarget1.Text = Stats[2];
                txtOnTarget2.Text = Stats[8];

                NTR_Formation yf = new NTR_Formation(eFormationTypes.Type_Empty);
                foreach (NTR_SquadDb.PlayerPerfRow row in matchData.YourPlayerPerf)
                {
                    Player pl = yf.SetYourPlayer(row);
                }

                yourTeamLineup.SetFormation(yf);

                NTR_Formation of = new NTR_Formation(eFormationTypes.Type_Empty);
                foreach (NTR_SquadDb.PlayerPerfRow row in matchData.OppsPlayerPerf)
                {
                    Player pl = of.SetOppsPlayer(row);
                }

                oppsTeamLineup.SetFormation(of);

                // Evaluating avg experience and avg rec
                ActionsList tempActionsList = ActionsList.Parse(matchData.OActions);
                ItemDictionary itemDictionary = ActionsList.ParseAsItemDictionary(matchData.OActions);

                string[] pitch = matchData.Pitch.Split(';');

                var yourAvgStats = ComputeStatistics(matchData.YourPlayerPerf, matchData.LastMin);
                var oppsAvgStats = ComputeStatistics(matchData.OppsPlayerPerf, matchData.LastMin);

                lblRecAvg1.Text = (yourAvgStats.RecSum / matchData.LastMin / 11).ToString("N2");
                lblRecAvg2.Text = (oppsAvgStats.RecSum / matchData.LastMin / 11).ToString("N2");
                lblRouAvg1.Text = (yourAvgStats.RouSum / matchData.LastMin / 11).ToString("N2");
                lblRouAvg2.Text = (oppsAvgStats.RouSum / matchData.LastMin / 11).ToString("N2");

                lblAttackStyle1.Text = matchData.YAttk;
                lblAttackStyle2.Text = matchData.OAttk;
                lblMentality1.Text = matchData.YMent;
                lblMentality2.Text = matchData.OMent;

                lblSprinklers.Text = (pitch[0] == "0") ? "No" : "Yes";
                lblDraining.Text = (pitch[1] == "0") ? "No" : "Yes";
                lblHeating.Text = (pitch[2] == "0") ? "No" : "Yes";

                int pitchConditions = 0;
                int.TryParse(pitch[3], out pitchConditions);

                lblPitchCondition.Text =
                    (pitchConditions <= 70) ? string.Format("Outstanding ({0}%)", pitchConditions) :
                    (pitchConditions <= 73) ? string.Format("Superb ({0}%)", pitchConditions) :
                    (pitchConditions <= 76) ? string.Format("Excellent ({0}%)", pitchConditions) :
                    (pitchConditions <= 82) ? string.Format("Good ({0}%)", pitchConditions) :
                    (pitchConditions <= 88) ? string.Format("Decent ({0}%)", pitchConditions) :
                    (pitchConditions <= 94) ? string.Format("Poor ({0}%)", pitchConditions) :
                    string.Format("Very Poor ({0}%)", pitchConditions);

                lblPitchCover.Text = (pitch[4] == "0") ? "No" : "Yes";

                int ix = weatherImgList.Images.IndexOfKey(matchData.Weather + ".png");
                if (ix != -1)
                {
                    pictWeather.Image = weatherImgList.Images[ix];
                }

                string num = HTML_Parser.GetFirstNumberInString(matchData.Weather);
                if (num == "1")
                    lblWeather.Text = "Very light";
                else if (num == "2")
                    lblWeather.Text = "Light";
                else if (num == "3")
                    lblWeather.Text = "Medium";
                else if (num == "4")
                    lblWeather.Text = "Heavy";
                else
                    lblWeather.Text = "Strong";

                actionsStats.ActionsToRows(matchData.YActions, matchData.OActions);
            }
            else
            {
                txtLineUp1.Text = "";
                txtLineUp2.Text = "";

                txtPossession1.Text = "";
                txtPossession2.Text = "";

                txtShots1.Text = "";
                txtShots2.Text = "";

                txtOnTarget1.Text = "";
                txtOnTarget2.Text = "";

                lblRecAvg1.Text = "";
                lblRecAvg2.Text = "";
                lblRouAvg1.Text = "";
                lblRouAvg2.Text = "";

                lblAttackStyle1.Text = "";
                lblAttackStyle2.Text = "";
                lblMentality1.Text = "";
                lblMentality2.Text = "";

                Formation yf = new Formation(eFormationTypes.Type_Empty);
                Formation of = new Formation(eFormationTypes.Type_Empty);
                yourTeamLineup.formation = yf;
                oppsTeamLineup.formation = of;

                lblSprinklers.Text = "nd";
                lblDraining.Text = "nd";
                lblHeating.Text = "nd";
                lblPitchCondition.Text = "nd";
                lblPitchCover.Text = "nd";

                lblWeather.Text = "nd";

                actionsStats.ActionsToRows(null, null);
            }
        }

        public class MatchComputedStats
        {
            public decimal RecSum = 0;
            public decimal RouSum = 0;
        }

        private MatchComputedStats ComputeStatistics(EnumerableRowCollection<NTR_SquadDb.PlayerPerfRow> yourPlayerPerf, int lastMin)
        {
            MatchComputedStats mcs = new MatchComputedStats();

            // Compute Rec Sum
            foreach (var playerPerf in yourPlayerPerf)
            {
                if (playerPerf.IsVoteNull())
                    continue;

                int numMin = lastMin;

                if (playerPerf.Status.Contains(">"))
                {
                    string value = HTML_Parser.GetNumberAfter(playerPerf.Status, ">");
                    numMin -= int.Parse(value);
                }
                if (playerPerf.Status.Contains("<"))
                {
                    string value = HTML_Parser.GetNumberAfter(playerPerf.Status, "<");
                    numMin -= lastMin - int.Parse(value);
                }

                mcs.RecSum += numMin * playerPerf.Rec;
                mcs.RouSum += numMin * playerPerf.Rou;
            }

            return mcs;
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }
    }
}
