using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TMRecorder.Properties;
using System.IO;
using Common;
using FieldFormationControl;
using NTR_Db;

namespace TMRecorder
{
    public partial class LineUp : Form
    {
        /* Players defending against shortpassing attacks require (mar), (pos) and (wor)
         * to keep tight spacing on the attacker, and (tac) and (pac) to steer clear of 
         * trouble when organization fails. 
         * 
         * To dominate your opponent's wingers, you need to deploy full backs with good (pac), 
         * (tac) and (mar). Tactical skills like (pos) and (wor) may also come in 
         * handy, as wingers often represent a mobile and flimsy threat. Finally a 
         * teaspoon of (str) and (sta) may also give your full backs the edge needed. 
         * 
         * Long bombs hurled upfield present a deadly threat to most teams and the only way to 
         * counter these attacks is by employing a tactically sound defence and sturdy 
         * defenders. (Marking), (pac), (pos) and (wor) are all important factors to make 
         * the defensive machinery grind any long balls before they become dangerous. 
         * (Strength), (hea) and (tac) are necessary attributes if your team is to win 
         * the ball one-on-one. (Stamina) is, as always, a factor.
         */
        public MatchDS matchDS = null;
        public ExtraDS extraDS = null;
        public TeamHistory History = null;
        string isReservesFilter = "";
        string playerTypeFilter = "";
        bool browseLineup = false;

        private FieldPlayer[] fps = new FieldPlayer[6];
        private Seasons allSeasons;

        public class MatchItem
        {
            public MatchItem(MatchData matchdata)
            {
                matchData = matchdata;
            }

            public MatchData matchData
            {
                get;
                set;
            }

            public override string ToString()
            {
                return "[" + matchData.Date.ToShortDateString() + "] " + matchData.Home + " " + matchData.Score + " " + matchData.Away;
            }

            public int matchID
            {
                get
                {
                    return matchData.MatchID;
                }
            }
        }

        public LineUp(NTR_Db.Seasons allseasons, ExtraDS extrads, TeamHistory hist)
        {
            InitializeComponent();

            allSeasons = allseasons;
            extraDS = extrads;
            History = hist;

            FileInfo fi2 = new FileInfo(Program.Setts.TacticsDBFilename);
            if (!fi2.Exists)
            {
                MessageBox.Show("Due to a change in the LineUp tool, you need the TacticsFile.xml file that contains " +
                    "some new settings needed by the tool. Goto to the http://tmrecorder.insyde.it/tmrecorder/download/usefulfiles page " +
                    "and download the file, then put it in the following path: " +
                    Program.Setts.TacticsDBFilename, "Error loading the TacticsDBFilename", MessageBoxButtons.OK);
                return;
            }

            tacticsDS.ReadXml(Program.Setts.TacticsDBFilename);

            SetMenuFilter();

            FillComboList();

            FileInfo fi = new FileInfo(Path.Combine(Program.Setts.TeamDataFolder, "Lineups.txt"));
            if (fi.Exists)
            {
                lineupList.Load(fi.FullName);

                Formation form = lineupList.GetCurrentFormation();
                formationControl.ShowFormationPlayers(form);
                FillTactics(form);
            }

            playerTypeFilter = "FPn=0";
            playersList.SetPlayers((ExtraDS.GiocatoriRow[])extraDS.Giocatori.Select("FPn=0", "ASI DESC"),
                History.actualDts);

            formationControl.UpdateLPWithData(extraDS, History.actualDts);

            // FillTactics(null);

            formationControl.FormationChanged += new EventHandler(formationControl_FormationChanged);

            lineupList.SelectedFormationChanged += new LineupList.SelectedFormationChangedHandler(lineupList_SelectedFormationChanged);
        }

        void lineupList_SelectedFormationChanged(Formation newForm, Formation oldForm)
        {
            // lineupList.SetCurrentFormation(formationControl.GetFormationPlayers());

            if (browseLineup)
            {
                formationControl.ShowFormationPlayers(newForm);

                FillTactics(newForm);
            }
        }

        void formationControl_FormationChanged(object sender, EventArgs e)
        {
            Formation formation = (Formation)sender;

            FillTactics(formation);
        }

        private void FillTactics(MatchItem mi)
        {
            // throw new Exception("The method or operation is not implemented.");
            // FillTactics();
        }

        private void FillTactics(Formation formation)
        {
            float vBallKeeping = 0.0f, vBallGaining = 0.0f;
            float[] vAtC = new float[(int)TacticsDS.Tactics.Tot];
            float[] vAtF = new float[(int)TacticsDS.Tactics.Tot];
            float[] vDef = new float[(int)TacticsDS.Tactics.Tot];
            float vSquad = 0.0f;

            foreach (Player pl in formation.players)
            {
                if (pl.visible == false) continue;

                ExtraDS.GiocatoriRow gr = extraDS.Giocatori.FindByPlayerID(pl.playerID);

                if (gr == null) continue;

                if (gr.FPn == 0) // This is a GK
                {
                    ExtTMDataSet.GiocatoriNSkillRow gnsr = History.actualDts.GiocatoriNSkill.FindByPlayerID(pl.playerID);

                    vSquad += gnsr.PO;
                }
                else
                {
                    ExtTMDataSet.GiocatoriNSkillRow gnsr = History.actualDts.GiocatoriNSkill.FindByPlayerID(pl.playerID);

                    string pos = formation.GetPlayerPosition(pl);
                    vSquad += gnsr.GetSkVal(pos);

                    float[] fKB = tacticsDS.BallKeepingAndGaining(gnsr);

                    float[,] fTct = tacticsDS.TacticsScore(gnsr, (int)pl.bitPosition);

                    vBallKeeping += fKB[0];
                    vBallGaining += fKB[1];

                    for (int i = 0; i < (int)TacticsDS.Tactics.Tot; i++)
                    {
                        vAtC[i] += fTct[i, 0];
                        vAtF[i] += fTct[i, 1];
                        vDef[i] += fTct[i, 2];
                    }
                }
            }

            vSquad /= 11.0f;
            vBallKeeping /= 10.0f; // GK are not involved
            vBallGaining /= 10.0f; // GK are not involved
            for (int i = 0; i < (int)TacticsDS.Tactics.Tot; i++)
            {
                vAtC[i] /= 11.0f;
                vAtF[i] /= 11.0f;
                vDef[i] /= 11.0f;
            }

            lblFullTeamVal.Text = vSquad.ToString("N1") + "%";
            pbFullTeamVal.Value = (int)vSquad;

            lblBallKeeping.Text = vBallKeeping.ToString("N1");
            lblBallGaining.Text = vBallGaining.ToString("N1");

            lblBalAtt.Text = (vAtC[(int)TacticsDS.Tactics.Std] + vAtF[(int)TacticsDS.Tactics.Std]).ToString();
            lblDirAtt.Text = (vAtC[(int)TacticsDS.Tactics.Dir] + vAtF[(int)TacticsDS.Tactics.Dir]).ToString();
            lblShpAtt.Text = (vAtC[(int)TacticsDS.Tactics.ShP] + vAtF[(int)TacticsDS.Tactics.ShP]).ToString();
            lblThrAtt.Text = (vAtC[(int)TacticsDS.Tactics.ThP] + vAtF[(int)TacticsDS.Tactics.ThP]).ToString();
            lblWinAtt.Text = (vAtC[(int)TacticsDS.Tactics.Win] + vAtF[(int)TacticsDS.Tactics.Win]).ToString();
            lblLonAtt.Text = (vAtC[(int)TacticsDS.Tactics.Lon] + vAtF[(int)TacticsDS.Tactics.Lon]).ToString();

            lblBalDef.Text = (vDef[(int)TacticsDS.Tactics.Std]).ToString();
            lblDirDef.Text = (vDef[(int)TacticsDS.Tactics.Dir]).ToString();
            lblShpDef.Text = (vDef[(int)TacticsDS.Tactics.ShP]).ToString();
            lblThrDef.Text = (vDef[(int)TacticsDS.Tactics.ThP]).ToString();
            lblWinDef.Text = (vDef[(int)TacticsDS.Tactics.Win]).ToString();
            lblLonDef.Text = (vDef[(int)TacticsDS.Tactics.Lon]).ToString();
        }

        private void FillField(MatchItem mi)
        {
            Formation f = new Formation(eFormationTypes.Type_Empty);

            foreach (NTR_SquadDb.PlayerPerfRow row in mi.matchData.YourPlayerPerf)
            {
                Player pl = f.SetPlayer(row);
                ExtraDS.GiocatoriRow gr = extraDS.Giocatori.FindByPlayerID(row.PlayerID);

                if (pl == null)
                {
                    continue;
                }

                if (gr != null)
                {
                    if (gr.FPn != 0)
                    {
                        ExtTMDataSet.GiocatoriNSkillRow gnsr = History.actualDts.GiocatoriNSkill.FindByPlayerID(row.PlayerID);
                        pl.value = gnsr.GetSkVal(f.GetPlayerPosition(pl));
                    }
                    else
                    {
                        ExtTMDataSet.GiocatoriNSkillRow gnsr = History.actualDts.GiocatoriNSkill.FindByPlayerID(row.PlayerID);
                        pl.value = gnsr.PO;
                    }
                }

                if (gr != null)
                {
                    pl.number = gr.Numero;
                    pl.name = gr.Nome;
                    pl.pf = gr.FP;
                }
            }

            formationControl.ShowFormationPlayers(f);

            /*
            lblMatchStartInfo.Text = mi.mr.InitDesciption;
            */
        }

        private void tsMainSquadMatches_Click(object sender, EventArgs e)
        {
            Program.Setts.MatchOnFieldFilter = 1;
            SetMenuFilter();
            FillComboList();
        }

        private void tsReservesMatches_Click(object sender, EventArgs e)
        {
            Program.Setts.MatchOnFieldFilter = 2;
            SetMenuFilter();
            FillComboList();
        }

        private void SetMenuFilter()
        {
            switch (Program.Setts.MatchOnFieldFilter)
            {
                case 0: // All Matches
                    Program.Setts.MatchOnFieldFilter = 1;
                    tsMatchesType.Text = "Matches Type (Main Team Matches)";
                    break;
                case 1: // Main Team Matches
                    tsMatchesType.Text = "Matches Type (Main Team Matches)";
                    break;
                case 2: // Reserves Team Matches
                    tsMatchesType.Text = "Matches Type (Reserves Team Matches)";
                    break;
            }
            Program.Setts.Save();
        }

        private void FillComboList()
        {
            tcmbMatchList.SelectedIndexChanged -= tcmbMatchList_SelectedIndexChanged;

            tcmbMatchList.Items.Clear();

            MatchItem matchItem = null;
            MatchItem lastMatchItem = null;

            List<MatchData> allMatchesData;

            if (Program.Setts.MatchOnFieldFilter == 1)
            {
                allMatchesData = allSeasons.GetSeasonMatchList(-1, Program.Setts.MainSquadID, -1, -1, true);
            }
            else
            {
                allMatchesData = allSeasons.GetSeasonMatchList(-1, Program.Setts.ReserveSquadID, -1, -1, true);
            }

            foreach (MatchData matchData in allMatchesData)
            {
                matchItem = new MatchItem(matchData);

                tcmbMatchList.Items.Add(matchItem);
                lastMatchItem = matchItem;
            }

            if (lastMatchItem != null)
                tcmbMatchList.SelectedItem = lastMatchItem;

            tcmbMatchList.SelectedIndexChanged += tcmbMatchList_SelectedIndexChanged;
        }

        private void tsGoalKeepers_Click(object sender, EventArgs e)
        {
            tsddPlayerTypeMenu.Text = tsGoalKeepers.Text;
            tsddPlayerTypeMenu.ForeColor = tsGoalKeepers.ForeColor;
            playerTypeFilter = "FPn=0";
            UpdatePlayerList();
        }

        private void tsDefenders_Click(object sender, EventArgs e)
        {
            tsddPlayerTypeMenu.Text = tsDefenders.Text;
            tsddPlayerTypeMenu.ForeColor = tsDefenders.ForeColor;
            playerTypeFilter = "FPn>=10 AND FPn<30";
            UpdatePlayerList();
        }

        private void tsDefMid_Click(object sender, EventArgs e)
        {
            tsddPlayerTypeMenu.Text = tsDefMid.Text;
            tsddPlayerTypeMenu.ForeColor = tsDefMid.ForeColor;
            playerTypeFilter = "FPn>=20 AND FPn<50";
            UpdatePlayerList();
        }

        private void tsMidfielders_Click(object sender, EventArgs e)
        {
            tsddPlayerTypeMenu.Text = tsMidfielders.Text;
            tsddPlayerTypeMenu.ForeColor = tsMidfielders.ForeColor;
            playerTypeFilter = "FPn>=40 AND FPn<70";
            UpdatePlayerList();
        }

        private void tsOddMid_Click(object sender, EventArgs e)
        {
            tsddPlayerTypeMenu.Text = tsOddMid.Text;
            tsddPlayerTypeMenu.ForeColor = tsOddMid.ForeColor;
            playerTypeFilter = "FPn>=60 AND FPn<90";
            UpdatePlayerList();
        }

        private void tsForwards_Click(object sender, EventArgs e)
        {
            tsddPlayerTypeMenu.Text = tsForwards.Text;
            tsddPlayerTypeMenu.ForeColor = tsForwards.ForeColor;
            playerTypeFilter = "FPn>=80";
            UpdatePlayerList();
        }

        private void LineUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileInfo fi = new FileInfo(Path.Combine(Program.Setts.TeamDataFolder, "Lineups.txt"));
            lineupList.Save(fi.FullName);
        }

        private void allPlayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsddPlayersSquadSelection.Text = allPlayersToolStripMenuItem.Text;
            isReservesFilter = " AND (isYoungTeam >= 0)";
            UpdatePlayerList();
        }

        private void mainSquadPlayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsddPlayersSquadSelection.Text = mainSquadPlayersToolStripMenuItem.Text;
            isReservesFilter = " AND (isYoungTeam = 0)";
            UpdatePlayerList();
        }

        private void reserveSquadPlayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsddPlayersSquadSelection.Text = reserveSquadPlayersToolStripMenuItem.Text;
            isReservesFilter = " AND (isYoungTeam = 1)";
            UpdatePlayerList();
        }

        private void UpdatePlayerList()
        {
            playersList.SetPlayers((ExtraDS.GiocatoriRow[])extraDS.Giocatori.Select(playerTypeFilter + isReservesFilter, "ASI DESC"),
                History.actualDts);
        }

        private void tsbGetLineup_Click(object sender, EventArgs e)
        {
            Formation form = lineupList.GetCurrentFormation();
            formationControl.ShowFormationPlayers(form);
            FillTactics(form);
        }

        private void tsbInsertLineup_Click(object sender, EventArgs e)
        {
            lineupList.SetCurrentFormation(formationControl.GetFormationPlayers());
        }

        private void tsbBrowseLineup_Click(object sender, EventArgs e)
        {
            browseLineup = tsbBrowseLineup.Checked;
        }

        private void tcmbMatchList_Click(object sender, EventArgs e)
        {
        }

        private void tcmbMatchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MatchItem mi = (MatchItem)tcmbMatchList.SelectedItem;

            matchDS = new Common.MatchDS();

            FillField(mi);

            formationControl.UpdateLPWithData(extraDS, History.actualDts);

            FillTactics(formationControl.GetFormationPlayers());
        }
    }
}