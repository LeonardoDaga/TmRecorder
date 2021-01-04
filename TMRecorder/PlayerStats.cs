using Common;
using NTR_Db;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TMRecorder
{
    public class PlayerStats
    {
        public class ValueHistoryItem
        {
            public DateTime Date;
            public long TotalValue;
            public int ValueGrowth;
            public int Wage;
            public int CumulatedWage;
        }

        public class ValueHistoryList : List<ValueHistoryItem> { }

        public ValueHistoryList ValueHistory = new ValueHistoryList();

        public PlayerStats(TeamHistory teamHistory, int playerID)
        {
            FillPlayerStats(teamHistory, playerID);
        }

        internal void FillPlayerStats(TeamHistory teamHistory, int playerID)
        {
            ValueHistory.Clear();

            Dictionary<int, (int wage, int season)> playersWage = new Dictionary<int, (int wage, int season)>();
            long lastPlayerValue = 0;
            int lastCumulatedWage = 0;
            DateTime lastPlayerValueDate = DateTime.MinValue;
            TmWeek age;

            foreach (ExtTMDataSet tds in teamHistory)
            {
                ValueHistoryItem vrow = new ValueHistoryItem();
                vrow.Date = tds.Date;

                var row = tds.GiocatoriNSkill.SingleOrDefault(p => p.PlayerID == playerID);
                if (row == null) continue;
                
                {
                    int season = TmWeek.GetSeason(vrow.Date);
                    int ID = row.PlayerID;
                    int SI = row.ASI;

                    if (!playersWage.ContainsKey(ID))
                    {
                        playersWage.Add(ID, (0, 0));
                    }

                    if (playersWage[ID].season != season)
                    {
                        // Update player wage
                        playersWage[ID] = (Tm_Utility.ASItoWage(SI, row.FPn), season);
                    }

                    vrow.Wage = (playersWage[ID].wage < 30000)? 30000: playersWage[ID].wage;

                    age = TmWeek.GetAge(row.wBorn, vrow.Date);

                    vrow.TotalValue = Common.Utility.SellToAgentPrice(row.FPn, SI, age.Years * 12 + age.Months);
                }


                if (lastPlayerValue == 0)
                {
                    vrow.ValueGrowth = 0;
                    lastCumulatedWage = vrow.Wage;
                }
                else
                {
                    int tdsWeek = TmWeek.DateTimeToSWD(tds.Date).AbsWeek;
                    int lastWeek = TmWeek.DateTimeToSWD(lastPlayerValueDate).AbsWeek;
                    if (lastWeek == tdsWeek) continue;
                    vrow.ValueGrowth = (int)(vrow.TotalValue - lastPlayerValue) / (tdsWeek - lastWeek);
                    lastCumulatedWage += vrow.Wage * (tdsWeek - lastWeek);
                }

                vrow.CumulatedWage = lastCumulatedWage;
                lastPlayerValue = vrow.TotalValue;
                lastPlayerValueDate = tds.Date;

                ValueHistory.Add(vrow);
            }
        }
    }
}