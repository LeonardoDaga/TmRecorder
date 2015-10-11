using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common;
using NTR_Db;

namespace TMRecorder
{
    public partial class MatchStats : UserControl
    {
        public MatchStats()
        {
            InitializeComponent();
        }

        public ChampDS.MatchRow MatchRow
        {
            set
            {
                if (value != null)
                {
                    ChampDS.MatchRow mr = value;

                    if (mr.IsYourFormationNull()) return;

                    txtLineUp1.Text = mr.YourFormation;
                    txtLineUp2.Text = mr.OppsFormation;

                    if (mr.IsYourStatsNull()) return;

                    string[] YourStats = mr.YourStats.Split(';');
                    string[] OppsStats = mr.OppsStats.Split(';');

                    txtPossession1.Text = YourStats[0];
                    txtPossession2.Text = OppsStats[0];

                    txtShots1.Text = YourStats[1];
                    txtShots2.Text = OppsStats[1];

                    txtOnTarget1.Text = YourStats[2];
                    txtOnTarget2.Text = OppsStats[2];
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
                }
            }
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

                Formation yf = new Formation(eFormationTypes.Type_Empty);
                Formation of = new Formation(eFormationTypes.Type_Empty);
                yourTeamLineup.formation = yf;
                oppsTeamLineup.formation = of;
            }
        }
    }
}
