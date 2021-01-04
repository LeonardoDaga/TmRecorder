using Common;
using NTR_Db;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TMRecorder
{
    public class TeamStats
    {
        public class AgeHistoryItem
        {
            public DateTime Date;
            public int U18;
            public int U21;
            public int U24;
            public int U30;
            public int O30;
        }

        public class GrowthHistoryItem
        {
            public DateTime Date;
            public double SkillCount;
            public int TotASI;
            public double DeltaSkillPos;
            public double DeltaSkillNeg;
        }

        public class ValueHistoryItem
        {
            public static double GkWageRate = 23.75;
            public static double PlWageRate = 15.8079;

            public DateTime Date;
            public long TotalValue;
            public int ValueGrowth;
            public int Wage;
            public long CumulatedWage;
        }

        public class TeamItem
        {
            public int PlayerID;
            public int Age;
            public int Rec;
            public int SI;
        }

        public class TeamHistoryItem
        {
            public DateTime Date;
            public int Fans;
            public long Cash;
        }

        public class ValueHistoryList : List<ValueHistoryItem> { }
        public class AgeHistoryList : List<AgeHistoryItem> { }
        public class GrowthHistoryList : List<GrowthHistoryItem> { }
        public class TeamList : List<TeamItem> { }
        public class TeamHistoryList : List<TeamHistoryItem> { }

        public AgeHistoryList AgeHistory = new AgeHistoryList();
        public GrowthHistoryList GrowthHistory = new GrowthHistoryList();
        public ValueHistoryList ValueHistory = new ValueHistoryList();
        public TeamList Team = new TeamList();
        public TeamHistoryList TeamHistory = new TeamHistoryList();
        public List<ExtraDS.GiocatoriRow> LastPlayers; 

        public TeamStats(TeamHistory teamHistory, Seasons allSeasons, int mainSquadID)
        {
            FillTeamStats(teamHistory);

            var lastDate = teamHistory.PlayersDS.Giocatori.Max(g => g.LastData);

            LastPlayers = teamHistory.PlayersDS.Giocatori
                .Where(g => g.LastData == lastDate)
                .ToList();

            FillTrainingHistory(teamHistory.TrainingHist);

            FillFansHistory(allSeasons, mainSquadID);
        }

        class PlayerInfo
        {
            public int Wage;
            public int Season;
            public Dictionary<DateTime, int> Value = new Dictionary<DateTime, int>();
        }

        internal void FillTeamStats(TeamHistory teamHistory)
        {
            AgeHistory.Clear();
            GrowthHistory.Clear();
            ValueHistory.Clear();

            Dictionary<int, PlayerInfo> playersInfo = new Dictionary<int, PlayerInfo>();

            ExtTMDataSet lasttds = null;
            long lastTeamValue = 0;
            long lastCumulatedWage = 0;
            DateTime lastTeamValueDate = DateTime.MinValue;

            foreach (ExtTMDataSet tds in teamHistory)
            {
                AgeHistoryItem arow = new AgeHistoryItem();
                arow.Date = tds.Date;

                GrowthHistoryItem grow = new GrowthHistoryItem();
                grow.Date = tds.Date;

                ValueHistoryItem vrow = new ValueHistoryItem();
                vrow.Date = tds.Date;

                grow.SkillCount = 0;
                grow.DeltaSkillNeg = 0;
                grow.DeltaSkillPos = 0;

                foreach (ExtTMDataSet.GiocatoriNSkillRow row in tds.GiocatoriNSkill)
                {
                    if (row.Età <= 18) arow.U18++;
                    else if (row.Età <= 21) arow.U21++;
                    else if (row.Età <= 24) arow.U24++;
                    else if (row.Età <= 30) arow.U30++;
                    else arow.O30++;

                    grow.SkillCount += (double)row.SkillSum;

                    grow.TotASI += row.ASI;

                    if (lasttds != null)
                    {
                        ExtTMDataSet.GiocatoriNSkillRow lastrow = lasttds.GiocatoriNSkill.FindByPlayerID(row.PlayerID);

                        if (lastrow != null)
                        {
                            decimal delta = row.SkillSum - lastrow.SkillSum;
                            if (delta > 0)
                                grow.DeltaSkillPos += (double)delta;
                            else
                                grow.DeltaSkillNeg += (double)delta;
                        }
                    }

                    int season = TmWeek.GetSeason(vrow.Date);
                    int ID = row.PlayerID;
                    int SI = row.ASI;

                    if (!playersInfo.ContainsKey(ID))
                    {
                        playersInfo.Add(ID, new PlayerInfo());
                    }

                    if (playersInfo[ID].Season != season)
                    {
                        // Update player wage
                        if (row.FPn == 0)
                        {
                            playersInfo[ID].Wage = (int)(SI * ValueHistoryItem.GkWageRate);
                            playersInfo[ID].Season = season;
                        }
                        else
                        {
                            playersInfo[ID].Wage = (int)(SI * ValueHistoryItem.PlWageRate);
                            playersInfo[ID].Season = season;
                        }
                    }

                    vrow.Wage += (playersInfo[ID].Wage < 30000) ? 30000 : playersInfo[ID].Wage;

                    TmWeek age = TmWeek.GetAge(row.wBorn, vrow.Date);

                    vrow.TotalValue += Common.Utility.SellToAgentPrice(row.FPn, SI, age.Years * 12 + age.Months);

                    playersInfo[ID].Value[tds.Date] = Common.Utility.SellToAgentPrice(row.FPn, SI, age.Years * 12 + age.Months);
                }

                if (lastCumulatedWage == 0)
                {
                    lastCumulatedWage = vrow.Wage;
                }
                else
                {
                    int tdsWeek = TmWeek.DateTimeToSWD(tds.Date).AbsWeek;
                    int lastWeek = TmWeek.DateTimeToSWD(lastTeamValueDate).AbsWeek;
                    if (lastWeek == tdsWeek) continue;
                    lastCumulatedWage += vrow.Wage * (tdsWeek - lastWeek);
                }

                vrow.CumulatedWage = lastCumulatedWage;
                lastTeamValue = vrow.TotalValue;
                lastTeamValueDate = tds.Date;

                lasttds = tds;

                AgeHistory.Add(arow);
                GrowthHistory.Add(grow);
                ValueHistory.Add(vrow);
            }

            foreach(var playerInfo in playersInfo)
            {
                long lastPlayerValue = 0;
                DateTime lastPlayerValueDate = DateTime.MinValue;

                foreach (var value in playerInfo.Value.Value)
                {
                    var vrow = ValueHistory.SingleOrDefault(vh => vh.Date == value.Key);
                    if (vrow == null) continue;

                    if (lastPlayerValue != 0)
                    {
                        int tdsWeek = TmWeek.DateTimeToSWD(value.Key).AbsWeek;
                        int lastWeek = TmWeek.DateTimeToSWD(lastPlayerValueDate).AbsWeek;
                        if (lastWeek == tdsWeek) continue;
                        vrow.ValueGrowth += (int)(value.Value - lastPlayerValue) / (tdsWeek - lastWeek);
                    }

                    lastPlayerValueDate = value.Key;
                    lastPlayerValue = value.Value;
                }
            }
        }

        internal void FillTrainingHistory(ListTrainingDataSet2 trainingHist)
        {
            foreach (var training in trainingHist)
            {
                float deltaSkillPos = 0;
                float deltaSkillNeg = 0;

                foreach (var player in training.Giocatori)
                {
                    deltaSkillPos += player.DeltaSkillPos();
                    deltaSkillNeg += player.DeltaSkillNeg();
                }

                foreach (var player in training.Portieri)
                {
                    deltaSkillPos += player.DeltaSkillPos();
                    deltaSkillNeg += player.DeltaSkillNeg();
                }

                var growthRow = GrowthHistory.SingleOrDefault(gh => gh.Date == training.Date);

                if (growthRow == null)
                    continue;

                growthRow.Date = training.Date;
                growthRow.DeltaSkillPos = deltaSkillPos;
                growthRow.DeltaSkillNeg = deltaSkillNeg;
            }
        }

        internal void FillFansHistory(Seasons allSeasons, int clubID)
        {
            List<NTR_SquadDb.TeamDataRow> clubData = allSeasons.GetClubData(clubID);

            foreach (var row in clubData)
            {
                TeamHistoryItem teamHistoryRow = TeamHistory.SingleOrDefault(th => th.Date == row.Date);

                if (teamHistoryRow == null)
                {
                    teamHistoryRow = new TeamHistoryItem();
                    teamHistoryRow.Date = row.Date;
                    teamHistoryRow.Cash = row.Cash;
                    teamHistoryRow.Fans = row.NumSupporters;
                    TeamHistory.Add(teamHistoryRow);
                }
            }
        }
    }
}