using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common;

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

                    txtYellowCards1.Text = YourStats[3];
                    txtYellowCards2.Text = OppsStats[3];

                    txtRedCards1.Text = YourStats[4];
                    txtRedCards2.Text = OppsStats[4];
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

                    txtYellowCards1.Text = "";
                    txtYellowCards2.Text = "";

                    txtRedCards1.Text = "";
                    txtRedCards2.Text = "";
                }
            }
        }
    }
}
