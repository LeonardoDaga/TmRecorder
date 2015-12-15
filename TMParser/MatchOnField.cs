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
    public partial class MatchOnField : Form
    {
        public Seasons AllSeasons = null;
        public ExtraDS extraDS = null;
        public TeamHistory History = null;

        private FieldPlayer[] fps = new FieldPlayer[6];

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

        public MatchOnField(NTR_Db.Seasons allSeasons, ExtraDS extrads, TeamHistory hist)
        {
            InitializeComponent();

            AllSeasons = allSeasons;
            extraDS = extrads;
            History = hist;

            fps[0] = fp1;
            fps[1] = fp2;
            fps[2] = fp3;
            fps[3] = fp4;
            fps[4] = fp5;
            fps[5] = fp6;

            SetMenuFilter();

            FillComboList();
        }

        private void SetMenuFilter()
        {
            switch (Program.Setts.MatchOnFieldFilter)
            {
                case 0: // All Matches
                    tsMatchTypeDDB.Text = "All Matches";
                    break;
                case 1: // Main Team Matches
                    tsMatchTypeDDB.Text = "Main Team Matches";
                    break;
                case 2: // Reserves Team Matches
                    tsMatchTypeDDB.Text = "Reserves Team Matches";
                    break;
            }
        }

        private void FillTactics(MatchItem mi)
        {
            float vBal = 0.0f, vDir = 0.0f, vWin = 0.0f, vShP = 0.0f, vLnB = 0.0f, vThB = 0.0f;
            Formation f = new Formation(eFormationTypes.Type_Empty);
            lblTacticsComment.Text = "";

            if (History.Count == 0)
            {
                lblTacticsComment.Text = "There is no team history to compute the tactics efficacy for this match";
            }

            ExtTMDataSet extDS = History.DS_BeforeDate(mi.matchData.Date);
            if (extDS == null)
            {
                // Non ci sono dati prima di questa data
                if (History.Count == 0) return;
                extDS = History[0];
                lblTacticsComment.Text = "There are no team data before the date of this match to compute correctly the tactics efficacy for this match";
            }

            foreach (var row in mi.matchData.YourPlayerPerf)
            {

                Player pl = f.FindPlayer(row.Position.ToUpper());

                if (pl == null) continue;

                ExtTMDataSet.GiocatoriNSkillRow gr = extDS.GiocatoriNSkill.FindByPlayerID(row.PlayerID);
                if (gr != null)
                {
                    float skVal = gr.GetSkVal(row.Position.ToUpper());

                    //-----------------------------------------------------------------
                    // Compute the Balanced value
                    vBal += skVal;

                    //-----------------------------------------------------------------
                    // Compute the Direct value
                    // Defenders and midfielders are quick and have good passing skill
                    if (((pl.bitPosition & BitP.DEF) | (pl.bitPosition & BitP.MID)) > 0)
                    {
                        float mul = 1.0f + 0.2f * ((float)gr.Pas - 10.0f) / 10.0f
                             + 0.2f * ((float)gr.Vel - 10.0f) / 10.0f;
                        vDir += skVal * mul;
                    }
                    else
                        vDir += skVal;

                    //-----------------------------------------------------------------
                    // Compute the Wings value
                    // Wings must have cross, pace and technique
                    if ((pl.bitPosition & BitP.WIN) > 0)
                    {
                        float mul = 1.0f + 0.32f * ((float)gr.Vel - 10.0f) / 10.0f
                            + 0.32f * ((float)gr.Tec - 10.0f) / 10.0f
                            + 0.32f * ((float)gr.Cro - 10.0f) / 10.0f;
                        vWin += skVal * mul;
                    }
                    else
                        vWin += skVal;

                    //-----------------------------------------------------------------
                    // Compute the Short Passing value
                    // Attackers and midfielders should have good passing skill and Work rate
                    if (((pl.bitPosition & BitP.OFF) | (pl.bitPosition & BitP.MID)) > 0)
                    {
                        float mul = 1.0f + 0.22f * ((float)gr.Pas - 10.0f) / 10.0f
                             + 0.22f * ((float)gr.Wor - 10.0f) / 10.0f;
                        vShP += skVal * mul;
                    }
                    else
                        vShP += skVal;

                    //-----------------------------------------------------------------
                    // Compute the Long Balls value
                    // Attackers and midfielders should have good passing skill and Work rate
                    if (((pl.bitPosition & BitP.DEF) | (pl.bitPosition & BitP.MID)) > 0)
                    {
                        float mul = 1.0f + 0.2f * ((float)gr.Pas - 10.0f) / 10.0f
                             + 0.2f * ((float)gr.Cro - 10.0f) / 10.0f;
                        vLnB += skVal * mul;
                    }
                    else
                        vLnB += skVal;

                    //-----------------------------------------------------------------
                    // Compute the Through Balls value
                    // Attackers and midfielders should have good passing skill and Work rate
                    if ((pl.bitPosition & BitP.OFF) > 0)
                    {
                        float mul = 1.0f + 0.32f * ((float)gr.Pas - 10.0f) / 10.0f
                             + 0.32f * ((float)gr.Vel - 10.0f) / 10.0f;
                        vThB += skVal * mul;
                    }
                    else
                        vThB += skVal;

                    continue;
                }

                ExtTMDataSet.GiocatoriNSkillRow pr = extDS.GiocatoriNSkill.FindByPlayerID(row.PlayerID);
                if (pr != null)
                {
                    float skVal = pr.PO;

                    // Compute the Balanced value
                    vBal += skVal;
                    vDir += skVal;
                    vWin += skVal;
                    vShP += skVal;
                    vLnB += skVal;
                    vThB += skVal;

                    continue;
                }

                // Player not found
                lblTacticsComment.Text = "There are no data for some players. The computed tactics efficacy for this match is not complete.";
            }

            vBal /= 11;
            vDir /= 11;
            vWin /= 11;
            vLnB /= 11;
            vShP /= 11;
            vThB /= 11;

            pbBal.Value = (int)(vBal < 100 ? vBal : 100);
            pbDir.Value = (int)(vDir < 100 ? vDir : 100);
            pbWin.Value = (int)(vWin < 100 ? vWin : 100);
            pbLnB.Value = (int)(vLnB < 100 ? vLnB : 100);
            pbShP.Value = (int)(vShP < 100 ? vShP : 100);
            pbThB.Value = (int)(vThB < 100 ? vThB : 100);

            lblBal.Text = "Balanced (" + vBal.ToString("N1") + " points)";
            lblDir.Text = "Direct Attack (" + vDir.ToString("N1") + " points)";
            lblWin.Text = "Wings Attack (" + vWin.ToString("N1") + " points)";
            lblLnB.Text = "Long Balls (" + vLnB.ToString("N1") + " points)";
            lblShP.Text = "Short Passing (" + vShP.ToString("N1") + " points)";
            lblThB.Text = "Through Balls (" + vThB.ToString("N1") + " points)";
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
                allMatchesData = AllSeasons.GetSeasonMatchList(-1, Program.Setts.MainSquadID, -1, -1, true);
            }
            else
            {
                allMatchesData = AllSeasons.GetSeasonMatchList(-1, Program.Setts.ReserveSquadID, -1, -1, true);
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

        private void tcmbMatchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MatchItem mi = (MatchItem)tcmbMatchList.SelectedItem;

            FillField(mi);

            FillTactics(mi);
        }

        private void FillField(MatchItem mi)
        {
            NTR_Formation f = new NTR_Formation(eFormationTypes.Type_Empty);
            int i = 0;

            foreach (FieldPlayer fp in fps)
            {
                fp.Visible = false;
            }

            foreach (var row in mi.matchData.YourPlayerPerf)
            {
                Player pl = f.SetYourPlayer(row);
                ExtraDS.GiocatoriRow gr = extraDS.Giocatori.FindByPlayerID(row.PlayerID);

                if (pl == null)
                {
                    if (gr == null) continue;

                    pl = new Player(BitP.NON);
                    pl.number = gr.Numero;
                    pl.name = gr.Nome;
                    pl.pf = gr.FP;
                    pl.visible = true;
                    pl.vote = -1;
                    int res;
                    if (int.TryParse(row.Position, out res))
                    {
                        pl.info = "+" + row.Position;
                    }
                    else
                    {
                        pl.info = row.Position;
                    }

                    if (i >= fps.Length) break;

                    fps[i].Data = pl;
                    i++;
                    continue;
                }

                if (gr != null)
                {
                    pl.number = gr.Numero;
                    pl.name = gr.Nome;
                    pl.pf = gr.FP;
                }
                pl.value = pl.vote;
            }

            formationControl.ShowFormationPlayers(f);
        }

        private void allMatchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Setts.MatchOnFieldFilter = 0;
            Program.Setts.Save();
            SetMenuFilter();
            FillComboList();
        }

        private void mainSquadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Setts.MatchOnFieldFilter = 1;
            Program.Setts.Save();
            SetMenuFilter();
            FillComboList();
        }

        private void reservesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Setts.MatchOnFieldFilter = 2;
            Program.Setts.Save();
            SetMenuFilter();
            FillComboList();
        }
    }
}