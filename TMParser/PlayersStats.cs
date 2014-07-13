using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;
using TMRecorder.Properties;

namespace TMRecorder
{
    public partial class PlayersStats : Form
    {
        public ChampDS.PlyStatsDataTable plyStatsTable = null;

        public PlayersStats(ChampDS.PlyStatsDataTable plystatstable, ExtraDS extraDS)
        {
            InitializeComponent();

            this.plyStatsTable = plystatstable;

            foreach (ChampDS.PlyStatsRow psr in plystatstable)
            {
                ExtraDS.GiocatoriRow gr = extraDS.Giocatori.FindByPlayerID(psr.PlayerID);

                if (gr != null)
                    psr.isReserves = (gr.isYoungTeam > 0);

                // ExtraDS.GiocatoriRow gr in extraDS.Giocatori
            }

            Initialize();

            chkMT1.Checked = true;
            chkSquadMain.Checked = true;

            if (Program.Setts.ShowActions != 0)
            {
                dgPlayersStats.Columns["DefActs"].Visible = true;
                dgPlayersStats.Columns["OffActs"].Visible = true;
                dgPlayersStats.Columns["Errors"].Visible = true;
                dgPlayersStats.Columns["Shots"].Visible = true;

                dgPlayersStats.Columns["InShots"].Visible = true;
                dgPlayersStats.Columns["GKd"].Visible = true;
                dgPlayersStats.Columns["YellowCards"].Visible = true;
                dgPlayersStats.Columns["RedCards"].Visible = true;
            }

            SetFilter();
        }

        private void SetFilter()
        {
            if (cmbSeason.Items.Count == 0)
            {
                return;
            }

            string filter = "(PG > 0) AND (Nome > 'a') AND ";

            if (chkMT1.Checked) filter += "(TypeStats = 0)";
            else if (chkMT2.Checked) filter += "(TypeStats = 1)";
            else if (chkMT3.Checked) filter += "(TypeStats = 2)";
            else if (chkMT4.Checked) filter += "(TypeStats = 3)";
            else if (chkMT5.Checked) filter += "(TypeStats = 4)";
            else if (chkMT6.Checked) filter += "(TypeStats = 5)";
            else filter += "(TypeStats = 0)";

            filter += " AND (SeasonID = " + cmbSeason.SelectedItem + ")";

            if ((!chkSquadMain.Checked) && (chkSquadReserves.Checked))
            {
                if (filter != "") filter += " AND ";
                filter += "(isReserves=1)";
            }

            if ((chkSquadMain.Checked) && (!chkSquadReserves.Checked))
            {
                if (filter != "") filter += " AND ";
                filter += "(isReserves=0)";
            }

            matchBindingSource.Filter = filter;
        }

        private void Initialize()
        {
            ChampDS.PlyStatsRow[] drs = (ChampDS.PlyStatsRow[])plyStatsTable.Select();

            dgPlayersStats.DataSource = matchBindingSource;
            matchBindingSource.DataSource = plyStatsTable;

            LoadMatchTypes();

            FillSeasonCombo(drs);

            // Bisogna fare una funzione che aggiorna i dati delle statistiche, da chiamare ogni 
            // volta che una nuova partita viene caricata
        }

        private void LoadMatchTypes()
        {
            string[] str = Program.Setts.MatchTypes.Split(',');

            int i = 0;
            for (; i < str.Length; i++)
            {
                switch (i)
                {
                    case 0: chkMT1.Text = str[0]; chkMT1.Visible = true; break;
                    case 1: chkMT2.Text = str[1]; chkMT2.Visible = true; break;
                    case 2: chkMT3.Text = str[2]; chkMT3.Visible = true; break;
                    case 3: chkMT4.Text = str[3]; chkMT4.Visible = true; break;
                    case 4: chkMT5.Text = str[4]; chkMT5.Visible = true; break;
                    case 5: chkMT6.Text = str[5]; chkMT6.Visible = true; break;
                }
            }
            for (; i < 6; i++)
            {
                switch (i)
                {
                    case 0: chkMT1.Visible = false; break;
                    case 1: chkMT2.Visible = false; break;
                    case 2: chkMT3.Visible = false; break;
                    case 3: chkMT4.Visible = false; break;
                    case 4: chkMT5.Visible = false; break;
                    case 5: chkMT6.Visible = false; break;
                }
            }
        }

        private void FillSeasonCombo(ChampDS.PlyStatsRow[] drs)
        {
            List<int> seasons = new List<int>();

            foreach (ChampDS.PlyStatsRow psr in drs)
            {
                if (!seasons.Contains(psr.SeasonID))
                    seasons.Add(psr.SeasonID);
            }

            cmbSeason.Items.Clear();

            seasons.Sort();

            foreach (int season in seasons)
            {
                cmbSeason.Items.Add(season);
            }

            if (cmbSeason.Items.Count > 0)
                cmbSeason.SelectedIndex = cmbSeason.Items.Count - 1;
        }

        private void chk_MatchesTypeChanged(object sender, EventArgs e)
        {
            chkMT1.CheckedChanged -= chk_MatchesTypeChanged;
            chkMT2.CheckedChanged -= chk_MatchesTypeChanged;
            chkMT3.CheckedChanged -= chk_MatchesTypeChanged;
            chkMT4.CheckedChanged -= chk_MatchesTypeChanged;
            chkMT5.CheckedChanged -= chk_MatchesTypeChanged;
            chkMT6.CheckedChanged -= chk_MatchesTypeChanged;

            chkMT1.Checked = chkMT2.Checked = chkMT3.Checked = 
                chkMT4.Checked = chkMT5.Checked = chkMT6.Checked = false;

            if (sender != null)
            {
                ((CheckBox)sender).Checked = true;
            }

            chkMT1.CheckedChanged += chk_MatchesTypeChanged;
            chkMT2.CheckedChanged += chk_MatchesTypeChanged;
            chkMT3.CheckedChanged += chk_MatchesTypeChanged;
            chkMT4.CheckedChanged += chk_MatchesTypeChanged;
            chkMT5.CheckedChanged += chk_MatchesTypeChanged;
            chkMT6.CheckedChanged += chk_MatchesTypeChanged;

            SetFilter();
        }

        private void cmbSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFilter();
        }

        private void chkSquadMain_CheckedChanged(object sender, EventArgs e)
        {
            chkSquadMain.CheckedChanged -= chkSquadMain_CheckedChanged;
            chkSquadReserves.CheckedChanged -= chkSquadMain_CheckedChanged;

            chkSquadMain.Checked = chkSquadReserves.Checked = false;

            if (sender != null)
            {
                ((CheckBox)sender).Checked = true;
            }

            chkSquadMain.CheckedChanged += chkSquadMain_CheckedChanged;
            chkSquadReserves.CheckedChanged += chkSquadMain_CheckedChanged;

            SetFilter();
        }
    }
}