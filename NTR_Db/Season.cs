using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NTR_Db;
using Common;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace NTR_Db
{
    public class Seasons
    {
        private List<int> _seasonsWithData = null;
        public List<int> SeasonsWithData
        {
            get
            {
                List<DateTime> matchDates = (from c in seasonsDB.Match
                                             select c.Date).ToList();

                _seasonsWithData = new List<int>();
                foreach (DateTime dt in matchDates)
                {
                    int season = TmWeek.GetSeason(dt);
                    if (!_seasonsWithData.Contains(season))
                    {
                        _seasonsWithData.Add(season);
                    }
                }

                return _seasonsWithData;
            }
        }

        private TeamList _ownedSquadsList = null;
        public TeamList OwnedSquadsList
        {
            get
            {
                if (_ownedSquadsList == null)
                {
                    _ownedSquadsList = new TeamList();

                    List<NTR_SquadDb.TeamRow> OwnedSquads = (from c in seasonsDB.Team
                                                           where (c.Owner == true)
                                                           select c).ToList();

                    foreach (NTR_SquadDb.TeamRow tr in OwnedSquads)
                    {
                        _ownedSquadsList.Add(tr.TeamID, tr.Name);
                    }
                }
                return _ownedSquadsList;
            }
        }

        List<Team> OwnedTeams = new List<Team>();

        public void SetOwnedTeam(int teamID, string teamName, int reserveOfTeamID = 0)
        {
            NTR_SquadDb.TeamRow team = seasonsDB.Team.FindByTeamID(teamID);
            if (team == null)
            {
                team = seasonsDB.Team.NewTeamRow();
                team.TeamID = teamID;
                seasonsDB.Team.AddTeamRow(team);
            }

            team.Name = teamName;
            team.Owner = true;
            team.ReserveOf = reserveOfTeamID;

            OwnedTeams.Add(new Team(teamID, teamName));
        }

        private NTR_SquadDb seasonsDB = new NTR_SquadDb();

        public List<MatchData> GetSeasonMatchList(int season, int teamID, int homeOrAway, int matchType)
        {
            TmSeason actualSeason = new TmSeason(season);

            //var matchRowList = (from c in seasonsDB.Match
            //                     where (!c.IsDateNull()) && (c.Date > actualSeason.Start) && (c.Date < actualSeason.End) &&
            //                             ((c.OTeamID == teamID) || (c.YTeamID == teamID))
            //                     select c);

            //var matchRowListOrdered = matchRowList.OrderBy(p => p.Date);

            //List<MatchData> matchDataList = new List<MatchData>();
            //foreach (var matchRow in matchRowList)
            //{
            //    matchDataList.Add(new MatchData(matchRow));
            //}

            //return matchDataList;

            var matchDataSelection = (from c in seasonsDB.Match
                                      where (!c.IsDateNull()) && (c.Date > actualSeason.Start) && (c.Date < actualSeason.End) &&
                                              ((c.OTeamID == teamID) || (c.YTeamID == teamID))
                                      select new MatchData(c));

            if (homeOrAway != 0)
            {
                matchDataSelection = (from c in matchDataSelection
                                        where c.IsHome == (homeOrAway == 1)
                                        select c);
            }

            if ((matchType != 0) && (matchType != 31))
            {
                if ((matchType & 1) == 0)
                {
                    matchDataSelection = (from c in matchDataSelection
                                          where c.MatchType != 0 && c.MatchType != 5
                                          select c);
                }
                if ((matchType & 2) == 0)
                {
                    matchDataSelection = (from c in matchDataSelection
                                          where c.MatchType <= 10 || c.MatchType >= 20
                                          select c);
                }
                if ((matchType & 4) == 0)
                {
                    matchDataSelection = (from c in matchDataSelection
                                          where c.MatchType != 2
                                          select c);
                }
                if ((matchType & 8) == 0)
                {
                    matchDataSelection = (from c in matchDataSelection
                                          where c.MatchType != 3
                                          select c);
                }
                if ((matchType & 16) == 0)
                {
                    matchDataSelection = (from c in matchDataSelection
                                          where c.MatchType <= 20
                                          select c);
                }
            }

            return matchDataSelection.OrderBy(p => p.Date).ToList();

            //return (from c in seasonsDB.Match
            //        where (!c.IsDateNull()) && (c.Date > actualSeason.Start) && (c.Date < actualSeason.End) &&
            //                ((c.OTeamID == teamID) || (c.YTeamID == teamID))
            //        select new MatchData(c)).OrderBy(p => p.Date).ToList();
        }

        public void LoadSeasonsFromVersion3(string dirPath, ref SplashForm sf,
            bool trace)
        {
            DefaultTraceListener tracer = new DefaultTraceListener();
            tracer.LogFileName = "./LoadFromPreviousDBlog.txt";

            if (trace) tracer.WriteLine("dirPath is" + dirPath);

            DirectoryInfo di = new DirectoryInfo(dirPath);

            if (!di.Exists)
            {
                MessageBox.Show("The data directory (" + dirPath + ") from where to load data does not exist",
                    "Error loading from the previous DB");
                return;
            }

            sf.UpdateStatusMessage(0, "Loading From Seasons DB v.3...");

            // Getting matches data
            FileInfo fiMatchHistory = new FileInfo(Path.Combine(di.FullName, "MatchesHistory.3.xml"));
            LoadChampsDataVer3(fiMatchHistory);

            FileInfo[] fiMatchFiles = di.GetFiles("Match_*.xml");
            int cntfis = fiMatchFiles.Length;

            for (int i = 0; i < cntfis; i++)
            {
                FileInfo fiMatchFile = fiMatchFiles[i];

                sf.UpdateStatusMessage((i * 100) / cntfis, "Loading Matches from the DB v.3...");

                LoadMatchDataVer3(fiMatchFile);

                if (trace) tracer.WriteLine("Added Matches data from " + fiMatchFile.Name);
            }

            Invalidate();
        }

        private void Invalidate()
        {
            //_ownedSquadsList = null;
            //throw new NotImplementedException();
            //seasonsDB.Invalidate();
        }

        private void LoadMatchDataVer3(FileInfo fin)
        {
            MatchDS matchDS = new MatchDS();
            matchDS.ReadXml(fin.FullName);

            int matchID = int.Parse(HTML_Parser.GetNumberAfter(fin.FullName, "Match_"));

            NTR_SquadDb.MatchRow mrRow = seasonsDB.Match.FindByMatchID(matchID);
            int YTeamID = mrRow.YTeamID;
            int OTeamID = mrRow.OTeamID;

            try
            {

                foreach (MatchDS.YourTeamPerfRow perfRow in matchDS.YourTeamPerf)
                {
                    NTR_SquadDb.PlayerRow pr = seasonsDB.Player.FindByPlayerID(perfRow.PlayerID);
                    if (pr == null)
                    {
                        pr = seasonsDB.Player.NewPlayerRow();
                        pr.PlayerID = perfRow.PlayerID;
                        pr.Name = perfRow.Name;
                        seasonsDB.Player.AddPlayerRow(pr);
                    }

                    NTR_SquadDb.PlayerPerfRow ppr = seasonsDB.PlayerPerf.FindByMatchIDPlayerID(matchID, perfRow.PlayerID);
                    if (ppr == null)
                    {
                        ppr = seasonsDB.PlayerPerf.NewPlayerPerfRow();
                        ppr.PlayerID = perfRow.PlayerID;
                        ppr.MatchID = matchID;
                        seasonsDB.PlayerPerf.AddPlayerPerfRow(ppr);
                    }

                    pr.TeamID = YTeamID;
                    ppr.TeamID = YTeamID;
                    if (!perfRow.IsVoteNull())
                        ppr.Vote = perfRow.Vote;
                    ppr.Position = perfRow.Position;
                    ppr.Scored = perfRow.Scored;
                    ppr.Number = perfRow.Number;
                    ppr.Assist = perfRow.Assist;
                    ppr.Status = perfRow.Status;
                    ppr.NPos = perfRow.NPos;
                }
            }
            catch (Exception)
            {
            }

            try
            {
                foreach (MatchDS.OppsTeamPerfRow perfRow in matchDS.OppsTeamPerf)
                {
                    NTR_SquadDb.PlayerRow pr = seasonsDB.Player.FindByPlayerID(perfRow.PlayerID);
                    if (pr == null)
                    {
                        pr = seasonsDB.Player.NewPlayerRow();
                        pr.PlayerID = perfRow.PlayerID;

                        pr.TeamID = OTeamID;
                        pr.Name = perfRow.Name;
                        seasonsDB.Player.AddPlayerRow(pr);
                    }

                    NTR_SquadDb.PlayerPerfRow ppr = seasonsDB.PlayerPerf.FindByMatchIDPlayerID(matchID, perfRow.PlayerID);
                    if (ppr == null)
                    {
                        ppr = seasonsDB.PlayerPerf.NewPlayerPerfRow();
                        ppr.PlayerID = perfRow.PlayerID;
                        ppr.MatchID = matchID;
                        seasonsDB.PlayerPerf.AddPlayerPerfRow(ppr);
                    }

                    ppr.TeamID = OTeamID;
                    if (!perfRow.IsVoteNull())
                        ppr.Vote = perfRow.Vote;
                    ppr.Position = perfRow.Position;
                    ppr.Scored = perfRow.Scored;
                    ppr.Number = perfRow.Number;
                    ppr.Assist = perfRow.Assist;
                    ppr.Status = perfRow.Status;
                    ppr.NPos = perfRow.NPos;
                }
            }
            catch (Exception)
            {
            }

            // TODO: Save Actions
            int actionID = 0;
            int YTeamColor = -1;
            int OTeamColor = -1;

            foreach (MatchDS.ActionsRow actionsRow in matchDS.Actions)
            {
                NTR_SquadDb.ActionsRow ar = seasonsDB.Actions.FindByMatchIDActionID(matchID, actionID);
                if (ar == null)
                {
                    ar = seasonsDB.Actions.NewActionsRow();
                    ar.ActionID = actionID;
                    ar.MatchID = matchID;
                    seasonsDB.Actions.AddActionsRow(ar);
                }
                actionID++;

                ar.ActionCode = actionsRow.ActionCode;
                if (!actionsRow.IsActionTypeNull())
                    ar.ActionType = actionsRow.ActionType;
                ar.Description = actionsRow.Description;
                ar.FullDesc = actionsRow.FullDesc;
                ar.Time = actionsRow.Time;
                ar.TeamID = actionsRow.ID;

                if (ar.TeamID == YTeamID)
                    YTeamColor = actionsRow.Color;
                else
                    OTeamColor = actionsRow.Color;
            }

            NTR_SquadDb.TeamRow oTeamRow = seasonsDB.Team.FindByTeamID(OTeamID);
            oTeamRow.Color = OTeamColor;
            NTR_SquadDb.TeamRow yTeamRow = seasonsDB.Team.FindByTeamID(YTeamID);
            yTeamRow.Color = YTeamColor;

            Invalidate();
        }

        private void LoadChampsDataVer3(FileInfo fi)
        {
            try
            {
                ChampDS champDS = new ChampDS();
                champDS.ReadXml(fi.FullName);

                foreach (ChampDS.MatchRow omr in champDS.Match)
                {
                    NTR_SquadDb.MatchRow nmr = seasonsDB.Match.FindByMatchID(omr.MatchID);
                    if (nmr == null)
                    {
                        nmr = seasonsDB.Match.NewMatchRow();
                        nmr.MatchID = omr.MatchID;
                        seasonsDB.Match.AddMatchRow(nmr);
                    }

                    nmr.Date = omr.Date;
                    nmr.Score = omr.Score;
                    nmr.MatchType = omr.MatchType;
                    if (!omr.IsCrowdNull())
                    {
                        nmr.Crowd = omr.Crowd;
                        nmr.Stadium = omr.Stadium;
                        nmr.Pitch = omr.Pitch;
                        nmr.Weather = omr.Weather;
                        nmr.Lineups = omr.YourFormation + ";" + omr.OppsFormation;
                        nmr.Stats = omr.YourStats + ";" + omr.OppsStats;
                        nmr.Mentalities = omr.YourMentality + ";" + omr.OppsMentality;
                        nmr.AttackStyles = omr.YourAttackingStyle + ";" + omr.OppsAttackingStyle;
                    }
                    if (!omr.IsCardsNull())
                        nmr.Cards = omr.Cards;

                    nmr.Report = omr.Report;
                    nmr.isHome = omr.isHome;
                    nmr.Analyzed = omr.Analyzed;

                    // nmr.BestPlayer = omr.Best
                    nmr.OTeamID = omr.OppsClubID;

                    NTR_SquadDb.TeamRow oppsTeamRow = seasonsDB.Team.FindByTeamID(nmr.OTeamID);
                    if (oppsTeamRow == null)
                    {
                        oppsTeamRow = seasonsDB.Team.NewTeamRow();
                        oppsTeamRow.TeamID = nmr.OTeamID;
                        oppsTeamRow.Name = omr.OppsClubName;
                        oppsTeamRow.Owner = false;
                        seasonsDB.Team.AddTeamRow(oppsTeamRow);
                    }

                    if (!omr.IsOppsNickNull())
                    {
                        oppsTeamRow.Nick = omr.OppsNick;
                    }

                    var team = OwnedSquadsList.FindValue(omr.Home);
                    if (OwnedSquadsList.FindValue(omr.Home).Key != -1)
                    {
                        if (omr.isHome == false)
                        {
                            // The match hasn't been properly set

                        }
                        omr.isHome = true;
                    }
                    else
                    {
                        team = OwnedSquadsList.FindValue(omr.Away);
                        if (omr.isHome == true)
                        {
                            // The match hasn't been properly set

                        }
                        omr.isHome = false;
                    }

                    int myTeamId = team.Key;

                    NTR_SquadDb.TeamRow yourTeamRow = seasonsDB.Team.FindByTeamID(myTeamId);
                    if (!omr.IsYourNickNull())
                    {
                        yourTeamRow.Nick = omr.YourNick;
                    }

                    // Look for your teamID searching the players
                    nmr.YTeamID = myTeamId;
                }
            }
            catch (Exception)
            {
            }
        }

        public void Save(string dirPath)
        {
            FileInfo fi = new FileInfo(Path.Combine(dirPath, "Players.5.xml"));
            seasonsDB.Player.WriteXml(fi.FullName);

            seasonsDB.HistData.WriteXmlBySeason(dirPath);

            fi = new FileInfo(Path.Combine(dirPath, "ScoutReview.5.xml"));
            seasonsDB.ScoutReview.WriteXml(fi.FullName);

            fi = new FileInfo(Path.Combine(dirPath, "Scout.5.xml"));
            seasonsDB.Scout.WriteXml(fi.FullName);

            fi = new FileInfo(Path.Combine(dirPath, "TempData.5.xml"));
            seasonsDB.TempData.WriteXml(fi.FullName);

            fi = new FileInfo(Path.Combine(dirPath, "Team.5.xml"));
            seasonsDB.Team.WriteXml(fi.FullName);

            fi = new FileInfo(Path.Combine(dirPath, "TeamData.5.xml"));
            seasonsDB.TeamData.WriteXml(fi.FullName);

            fi = new FileInfo(Path.Combine(dirPath, "Match.5.xml"));
            seasonsDB.Match.WriteXml(fi.FullName);

            fi = new FileInfo(Path.Combine(dirPath, "PlayerPerf.5.xml"));
            seasonsDB.PlayerPerf.WriteXml(fi.FullName);

            seasonsDB.Actions.WriteXmlBySeason(dirPath);

            fi = new FileInfo(Path.Combine(dirPath, "ActionsDecoder.5.xml"));
            seasonsDB.ActionsDecoder.WriteXml(fi.FullName);
        }

        public void LoadSeasonsFromVersion5(string dirPath, ref SplashForm sf, bool v)
        {
            // Load first the squad data
            FileInfo fi = new FileInfo(Path.Combine(dirPath, "Players.5.xml"));

            if (fi.Exists)
            {
                DirectoryInfo di = new DirectoryInfo(dirPath);

                fi = new FileInfo(Path.Combine(dirPath, "Players.5.xml"));
                seasonsDB.Player.ReadXml(fi.FullName);

                FileInfo[] fis = di.GetFiles("HistData-*.5.xml");
                int cntfis = fis.Length;
                for (int i = 0; i < cntfis; i++)
                {
                    fi = fis[i];

                    NTR_SquadDb.HistDataDataTable tempHistDataDataTable = new NTR_SquadDb.HistDataDataTable();
                    tempHistDataDataTable.ReadXml(fi.FullName);
                    seasonsDB.HistData.Merge(tempHistDataDataTable);
                }

                fi = new FileInfo(Path.Combine(dirPath, "ScoutReview.5.xml"));
                seasonsDB.ScoutReview.ReadXml(fi.FullName);

                fi = new FileInfo(Path.Combine(dirPath, "Scout.5.xml"));
                seasonsDB.Scout.ReadXml(fi.FullName);

                fi = new FileInfo(Path.Combine(dirPath, "TempData.5.xml"));
                seasonsDB.TempData.ReadXml(fi.FullName);

                fi = new FileInfo(Path.Combine(dirPath, "Team.5.xml"));
                seasonsDB.Team.ReadXml(fi.FullName);

                fi = new FileInfo(Path.Combine(dirPath, "Match.5.xml"));
                if (fi.Exists)
                    seasonsDB.Match.ReadXml(fi.FullName);

                fi = new FileInfo(Path.Combine(dirPath, "TeamData.5.xml"));
                if (fi.Exists)
                    seasonsDB.TeamData.ReadXml(fi.FullName);

                fi = new FileInfo(Path.Combine(dirPath, "PlayerPerf.5.xml"));
                if (fi.Exists)
                    seasonsDB.PlayerPerf.ReadXml(fi.FullName);

                fis = di.GetFiles("Actions-*.5.xml");
                cntfis = fis.Length;
                for (int i = 0; i < cntfis; i++)
                {
                    fi = fis[i];

                    NTR_SquadDb.ActionsDataTable tempActionsDataDataTable = new NTR_SquadDb.ActionsDataTable();
                    tempActionsDataDataTable.ReadXml(fi.FullName);
                    seasonsDB.Actions.Merge(tempActionsDataDataTable);
                }

                fi = new FileInfo(Path.Combine(dirPath, "ActionsDecoder.5.xml"));
                if (fi.Exists)
                    seasonsDB.ActionsDecoder.ReadXml(fi.FullName);
            }
            Invalidate();
        }

        public List<Team> GetOwnedTeams()
        {
            return OwnedTeams;
        }

        public int[] GetSeasonsVector()
        {
            return SeasonsWithData.ToArray();
        }

        /*
        public void LoadChampDS(string matchFilePath)
        {
            ChampDS champDS = new ChampDS();

            champDS.ReadXml(matchFilePath);

            foreach (ChampDS.MatchRow row in champDS.Match)
            {
                int season = TmWeek.GetSeason(row.Date);

                Season thisSeason = GetOrCreateSeason(season);

                MatchData matchData = thisSeason.GetOrCreateMatch(row.MatchID);

                matchData.Analyzed = row.Analyzed;
                matchData.Away = row.Away;
                matchData.AwayPlayerPerf = null; // TODO
                matchData.BestPlayer = 0; // TODO
                if (!row.IsCardsNull())
                    matchData.Cards = row.Cards;

                if (!row.IsCrowdNull())
                {
                    matchData.Crowd = row.Crowd;
                    matchData.Stadium = row.Stadium;
                    matchData.Pitch = row.Pitch;
                    matchData.Weather = row.Weather;
                    matchData.LineUps = row.YourFormation + ";" + row.OppsFormation; 
                    matchData.Stats = row.YourStats + ";" + row.OppsStats;
                    matchData.Mentalities = row.YourMentality + ";" + row.OppsMentality;
                    matchData.AttackStyles = row.YourAttackingStyle + ";" + row.OppsAttackingStyle;
                }

                matchData.Date = row.Date;
                matchData.Home = row.Home;
                matchData.HomePlayerPerf = null; // TODO
                matchData.IsHome = false; // TODO
                matchData.MatchID = row.MatchID;
                matchData.MatchType = row.MatchType;
                matchData.OActions = ""; // TODO
                matchData.OTeamID = row.OppsClubID;
                matchData.Report = row.Report;
                matchData.Score = new MatchScore(row.Score, matchData.IsHome);
                matchData.ScoreString = row.Score;
                matchData.YActions = ""; // TODO
                matchData.YTeamID = 0; // TODO
            }
        }
        */
    }

    public class Team
    {
        public Team(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, ID);
        }
    }
}
