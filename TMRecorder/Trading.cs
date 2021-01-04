using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static TMRecorder.PlayerStats;

namespace TMRecorder
{


    partial class Trading
    {
        partial class PlayersRow
        {
            internal void UpdateGain()
            {
                int gain = 0;
                bool set = false;
                if (!IsSellPriceNull()) { gain += SellPrice; set = true; }
                if (!IsAcquirePriceNull()) { gain -= AcquirePrice; set = true; }
                if (!IsManagCostNull()) { gain -= ManagCost; set = true; }
                if (set) Gain = gain;
            }
        }

        partial class PlayersDataTable
        {
        }

        internal void FillTradingList(TeamHistory teamHistory)
        {
            int count = 0;
            int version = 0;
            bool toUpdate = false;
            List<int> updatedPlayers = new List<int>();

            int lastWeek = 0;
            //foreach (Trading.PlayersRow pr in trading.Players)
            //{
            //    if (pr.IsDateSellNull()) continue;
            //    if (lastWeek < pr.DateSell)
            //        lastWeek = pr.DateSell;
            //}
            lastWeek = this.Players.Max(p => (p.IsDateSellNull() ? 0 : p.DateSell));

            ProgressForm pform = new ProgressForm();
            pform.progressBar.Maximum = teamHistory.Count;
            pform.progressBar.Value = 0;
            pform.Text = "Filling the trading list with your past players: Please wait";
            pform.lblProgressDescription.Text = "Adding History: Adding weeks from a total of " + pform.progressBar.Maximum.ToString();
            Form parent = Application.OpenForms[0];
            pform.Show(parent);
            parent.Refresh();
            pform.Refresh();

            int cntRefresh = 0;

            if (this.Info.Count == 0)
            {
                // Si inserisce il primo numero di versione
                version = 0;
                var infoRow = this.Info.NewInfoRow();
                infoRow.Version = version;
                this.Info.AddInfoRow(infoRow);
                toUpdate = true;
            }

            foreach (ExtTMDataSet eds in teamHistory)
            {
                DateTime dtDS = eds.WeekNoData[0].Date;
                int weekDS = TmWeek.GetTmAbsWk(dtDS);
                TmWeek tmw = new TmWeek(dtDS);

                count++;
                pform.lblProgressDescription.Text = "Adding History: Adding week " + count.ToString() +
                    " (" + tmw.ToString() + ") of " + teamHistory.Count.ToString();
                pform.Value = count;

                if ((!toUpdate) && (weekDS <= lastWeek)) continue;

                pform.Refresh();

                //if ((cntRefresh++ % 5) == 0) parent.Refresh();

                foreach (ExtTMDataSet.GiocatoriNSkillRow gnr in eds.GiocatoriNSkill)
                {
                    Trading.PlayersRow pr = Players.FindByPlayerID(gnr.PlayerID);

                    if ((!updatedPlayers.Contains(gnr.PlayerID)) || (pr == null))
                    {
                        bool prToAdd = false;
                        if (pr == null)
                        {
                            pr = Players.NewPlayersRow();
                            prToAdd = true;
                            pr.PlayerID = gnr.PlayerID;
                            string[] strs = gnr.Nome.Split('|');
                            pr.Name = strs[0];
                            pr.Nation = gnr.Nationality;
                        }

                        pr.DateAcquire = weekDS;
                        pr.DateSell = weekDS;
                        pr.ASIwhenSold = gnr.ASI;
                        pr.ASIwhenBuyed = gnr.ASI;
                        pr.WeekInTeam = 1;
                        pr.Age = gnr.Età;
                        pr.FPn = gnr.FPn;

                        var playersWage = Tm_Utility.ASItoWage(gnr.ASI, gnr.FPn);

                        pr.ManagCost = playersWage;

                        pr.Gain = -pr.ManagCost;
                        if (!pr.IsAcquirePriceNull())
                            pr.Gain -= pr.AcquirePrice;
                        if (!pr.IsSellPriceNull())
                            pr.Gain += pr.SellPrice;

                        if (prToAdd)
                            Players.AddPlayersRow(pr);

                        updatedPlayers.Add(gnr.PlayerID);
                    }
                    else
                    {
                        if (weekDS < pr.DateAcquire)
                        {
                            pr.DateAcquire = weekDS;
                            pr.ASIwhenBuyed = gnr.ASI;
                            pr.WeekInTeam = pr.DateSell - pr.DateAcquire;
                        }
                        if (weekDS > pr.DateSell)
                        {
                            pr.ASIwhenSold = gnr.ASI;
                            pr.WeekInTeam = pr.DateSell - pr.DateAcquire;

                            if (pr.IsManagCostNull())
                                pr.ManagCost = 0;

                            var playersWage = Tm_Utility.ASItoWage(gnr.ASI, gnr.FPn);

                            pr.ManagCost += playersWage * (weekDS - pr.DateSell);

                            pr.Gain = -pr.ManagCost;
                            if (!pr.IsAcquirePriceNull())
                                pr.Gain -= pr.AcquirePrice;
                            if (!pr.IsSellPriceNull())
                                pr.Gain += pr.SellPrice;

                            pr.DateSell = weekDS;
                        }

                        string[] strs = gnr.Nome.Split('|');
                        pr.Name = strs[0];
                        pr.Age = gnr.Età;
                        pr.FPn = gnr.FPn;
                    }
                }
            }

            pform.CodeClose();
        }

    }
}
