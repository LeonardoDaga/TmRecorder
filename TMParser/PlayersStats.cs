using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;
using NTR_Db;
using TMRecorder.Properties;
using NTR_Controls;

namespace TMRecorder
{
    public partial class PlayersStats : Form
    {
        private Seasons AllSeasons;

        public List<MatchData> SeasonMatchList { get; private set; }

        public PlayersStats(Seasons allseasons, ExtraDS extraDS)
        {
            InitializeComponent();

            CreateDataListColumns();

            AllSeasons = allseasons;

            FillCmbMatchesSeasons();
            FillCmbMatchesSquads();

            MatchListUpdateSeason();
        }

        private void CreateDataListColumns()
        {
            dgPlayersStats.AutoGenerateColumns = false;
            dgPlayersStats.Columns.Clear();
            dgPlayersStats.AddColumn("Name", "Name", 60, AG_Style.String | AG_Style.ResizeAllCells);
            dgPlayersStats.AddColumn("FP", "FPn", 40, AG_Style.FavPosition, "Favoured Position");
            dgPlayersStats.AddColumn("GP", "GamePlayed", 40, AG_Style.Numeric, "Game Played");
            dgPlayersStats.AddColumn("Goal", "Scored", 40, AG_Style.Numeric, "Goal");
            dgPlayersStats.AddColumn("Assist", "Assist", 40, AG_Style.Numeric, "Assist");
            dgPlayersStats.AddColumn("Vote", "AvgVote", 40, AG_Style.Numeric | AG_Style.N1, "Average Vote");
            dgPlayersStats.AddColumn("Vote SD", "SdVote", 40, AG_Style.Numeric | AG_Style.N1, "Average Vote");
        }

        private void UpdateMatchList_Click(object sender, EventArgs e)
        {
            MatchListUpdateSeason();
        }

        private void FillCmbMatchesSquads()
        {
            cmbSquad.Items.Clear();

            List<Team> ownedTeams = AllSeasons.GetOwnedTeams();
            foreach (Team team in ownedTeams)
            {
                cmbSquad.Items.Add(team);
            }

            if (cmbSquad.Items.Count > 0)
                cmbSquad.SelectedItem = ownedTeams[0];
        }

        private void FillCmbMatchesSeasons()
        {
            cmbSeason.Items.Clear();

            foreach (int season in AllSeasons.GetSeasonsVector())
            {
                cmbSeason.Items.Add(season);
            }

            if (cmbSeason.Items.Count == 0)
                return;

            cmbSeason.SelectedItem = TmWeek.thisSeason().Season;
        }


        private void MatchListUpdateSeason()
        {
            if (cmbSquad.SelectedItem == null)
                return;

            if (cmbSeason.SelectedItem == null)
                return;

            int season = (int)cmbSeason.SelectedItem;
            int teamId = ((Team)cmbSquad.SelectedItem).ID;

            int matchType = 0;
            matchType += chkMT1.Checked ? 1 : 0;
            matchType += chkMT2.Checked ? 2 : 0;
            matchType += chkMT3.Checked ? 4 : 0;
            matchType += chkMT4.Checked ? 8 : 0;
            matchType += chkMT5.Checked ? 16 : 0;
            matchType = (matchType > 0) ? matchType : 31;

            // Initialize list with the actual season
            var statList = AllSeasons.GetPlayerStatsListByTeam(season, teamId, matchType);

            dgPlayersStats.DataCollection = statList;
        }


    }
}