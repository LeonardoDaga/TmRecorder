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
        public bool IsDirty { get; set; }

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

        public List<PlayerStats> GetPlayerStatsListByTeam(int season, int teamId, int matchType)
        {
            DateTime dtStart, dtEnd;

            if (season != -1)
            {
                TmSeason tmSeason = new TmSeason(season);
                dtStart = tmSeason.Start;
                dtEnd = tmSeason.End;
            }
            else
            {
                TmSeason tmSeason = new TmSeason(1);
                dtStart = tmSeason.Start;
                dtEnd = DateTime.Now;
            }

            var playerPerfs = (from c in seasonsDB.PlayerPerf
                              where (c.PlayerRow.TeamID == teamId) && (c.MatchRow.Date > dtStart)
                              && (c.MatchRow.Date > dtEnd)
                              select c);

            if ((matchType != 0) && (matchType != 31))
            {
                if ((matchType & 1) == 0)
                {
                    playerPerfs = (from c in playerPerfs
                                   where c.MatchRow.MatchType != 0 && c.MatchRow.MatchType != 5
                                   select c);
                }
                if ((matchType & 2) == 0)
                {
                    playerPerfs = (from c in playerPerfs
                                   where c.MatchRow.MatchType <= 10 || c.MatchRow.MatchType >= 20
                                   select c);
                }
                if ((matchType & 4) == 0)
                {
                    playerPerfs = (from c in playerPerfs
                                   where c.MatchRow.MatchType != 2
                                   select c);
                }
                if ((matchType & 8) == 0)
                {
                    playerPerfs = (from c in playerPerfs
                                   where c.MatchRow.MatchType != 3
                                   select c);
                }
                if ((matchType & 16) == 0)
                {
                    playerPerfs = (from c in playerPerfs
                                   where c.MatchRow.MatchType <= 20
                                   select c);
                }
            }

            List<NTR_SquadDb.PlayerPerfRow> playerPerfsList = playerPerfs.OrderBy(p => p.MatchRow.Date).ToList();

            return CreateStats(playerPerfsList);
        }

        private List<PlayerStats> CreateStats(List<NTR_SquadDb.PlayerPerfRow> playerPerfs)
        {
            List<PlayerStats> playersStatsList = new List<PlayerStats>();

            foreach(var playerPerf in playerPerfs)
            {
                var playerStats = playersStatsList.Find(p => p.PlayerId == playerPerf.PlayerID);

                if (playerStats == null)
                {
                    playerStats = new PlayerStats();
                    playerStats.Add(playerPerf);
                    playersStatsList.Add(playerStats);
                }
                else
                {
                    playerStats.Add(playerPerf);
                }
            }

            return playersStatsList;
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

        public bool RemoveMatchFromDB(int matchID)
        {
            NTR_SquadDb.MatchRow matchRow = seasonsDB.Match.FindByMatchID(matchID);

            if (matchRow != null)
            {
                seasonsDB.Match.RemoveMatchRow(matchRow);
                return true;
            }

            return false;
        }

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
                    ppr.Rec = 1;
                    ppr.Rou = 3.3M;
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
                    ppr.Rec = 1;
                    ppr.Rou = 3.3M;
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
                else
                    ar.ActionType = "";
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

        public List<NTR_SquadDb.ActionsRow> GetMatchActions(int matchID)
        {
            return (from c in seasonsDB.Actions
                    where c.MatchID == matchID
                    select c).OrderBy(p => p.Time).ToList();
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

        public List<NTR_SquadDb.PlayerPerfRow> GetPlayerPerfList(int actualPlayerID, int season)
        {
            DateTime dtStart, dtEnd;

            if (season != -1)
            {
                TmSeason tmSeason = new TmSeason(season);
                dtStart = tmSeason.Start;
                dtEnd = tmSeason.End;
            }
            else
            {
                TmSeason tmSeason = new TmSeason(1);
                dtStart = tmSeason.Start;
                dtEnd = DateTime.Now;
            }

            var playerPerf = (from c in seasonsDB.PlayerPerf
                              where (c.PlayerID == actualPlayerID) && (c.MatchRow.Date > dtStart)
                              && (c.MatchRow.Date < dtEnd)
                              select c).OrderBy(p => p.MatchRow.Date).ToList();

            return playerPerf;
        }

        public List<Team> GetOwnedTeams()
        {
            return OwnedTeams;
        }

        public int[] GetSeasonsVector()
        {
            return SeasonsWithData.ToArray();
        }

        public bool IsUpdatedCalendar(int teamID)
        {
            int thisSeason = TmWeek.thisSeason().Season;

            List<MatchData> matchDataList = GetSeasonMatchList(thisSeason, teamID, 0, 1);

            return (matchDataList.Count > 0);
        }

        public int NumberOfMatchesToUpdate(int teamID)
        {
            TmSeason actualSeason = TmWeek.thisSeason();
            DateTime dtYesterday = DateTime.Now.AddDays(-1);

            var matchDataSelection = (from c in seasonsDB.Match
                                      where (!c.IsDateNull()) && (c.Date > actualSeason.Start) && (c.Date < dtYesterday)
                                              && (c.Report == false) && ((c.OTeamID == teamID) || (c.YTeamID == teamID))
                                      select new MatchData(c));

            return matchDataSelection.Count();
        }

        public MatchData GetFirstMatchToUpdate(int teamID)
        {
            TmSeason actualSeason = TmWeek.thisSeason();
            DateTime dtYesterday = DateTime.Now.AddDays(-1);

            var matchDataSelection = (from c in seasonsDB.Match
                                      where (!c.IsDateNull()) && (c.Date > actualSeason.Start) && (c.Date < dtYesterday)
                                              && (c.Report == false) && ((c.OTeamID == teamID) || (c.YTeamID == teamID))
                                      select new MatchData(c));

            return matchDataSelection.First();
        }

        public bool LoadMatch(string page)
        {
            if (page.Contains("Javascript error")) return false;

            string lineup_home_str = HTML_Parser.GetTag(page, "LINEUP_HOME");
            string lineup_away_str = HTML_Parser.GetTag(page, "LINEUP_AWAY");
            string match_info_str = HTML_Parser.GetTag(page, "MATCH_INFO");
            string report = HTML_Parser.GetTag(page, "REPORT");

            if (match_info_str.Contains("forfait=yes")) return false;

            string[] att_styles = { "Bal", "Bal", "Count", "Wing", "Short", "Long", "Filt" };
            string[] mentality = { "Norm", "VeDef", "Def", "SlDef", "Norm", "SlOff", "Off", "VrOff" };

            string matchIdStr = HTML_Parser.GetNumberAfter(page, "http://trophymanager.com/matches/");
            int matchId = int.Parse(matchIdStr);

            NTR_SquadDb.MatchRow matchRow = seasonsDB.Match.FindByMatchID(matchId);
            if (matchRow == null)
            {
                matchRow = seasonsDB.Match.NewMatchRow();
                matchRow.MatchID = matchId;
                seasonsDB.Match.AddMatchRow(matchRow);
            }

            try
            {
                List<string> home_pl = HTML_Parser.GetTags(lineup_home_str, "PL");
                List<string> away_pl = HTML_Parser.GetTags(lineup_away_str, "PL");

                Dictionary<string, string> match_info = HTML_Parser.CreateDictionary(match_info_str.Trim(';'), ';');

                int homeTeamId = int.Parse(match_info["home_id"]);
                int awayTeamId = int.Parse(match_info["away_id"]);

                NTR_SquadDb.TeamRow homeTeamRow = seasonsDB.Team.FindByTeamID(homeTeamId);
                if (homeTeamRow == null)
                {
                    homeTeamRow = seasonsDB.Team.NewTeamRow();
                    homeTeamRow.TeamID = homeTeamId;
                    seasonsDB.Team.AddTeamRow(homeTeamRow);
                }
                homeTeamRow.Nick = match_info["home_nick"];

                NTR_SquadDb.TeamRow awayTeamRow = seasonsDB.Team.FindByTeamID(awayTeamId);
                if (awayTeamRow == null)
                {
                    awayTeamRow = seasonsDB.Team.NewTeamRow();
                    awayTeamRow.TeamID = awayTeamId;
                    seasonsDB.Team.AddTeamRow(awayTeamRow);
                }
                awayTeamRow.Nick = match_info["away_nick"];

                matchRow.Stadium = match_info["stadium"];
                matchRow.Crowd = int.Parse(match_info["attendance"]);

                if (!homeTeamRow.IsOwnerNull())
                    matchRow.isHome = homeTeamRow.Owner;
                else
                    matchRow.isHome = false;

                int yourTeamId = matchRow.isHome ? homeTeamId : awayTeamId;
                int oppsTeamId = matchRow.isHome ? awayTeamId : homeTeamId;

                if (matchRow.isHome)
                {
                    matchRow.Mentalities = mentality[int.Parse(match_info["home_mentality"])] + ";" + mentality[int.Parse(match_info["away_mentality"])];
                    matchRow.AttackStyles = att_styles[int.Parse(match_info["home_attstyle"])] + ";" + att_styles[int.Parse(match_info["away_attstyle"])];
                }
                else
                {
                    matchRow.Mentalities = mentality[int.Parse(match_info["away_mentality"])] + ";" + mentality[int.Parse(match_info["home_mentality"])];
                    matchRow.AttackStyles = att_styles[int.Parse(match_info["away_attstyle"])] + ";" + att_styles[int.Parse(match_info["home_attstyle"])];
                }

                // Getting pitch and weather data
                matchRow.Pitch = match_info["sprinklers"] + ";" +
                     match_info["draining"] + ";" +
                     match_info["heating"] + ";" +
                     match_info["pitch_condition"] + ";" +
                     match_info["pitchcover"];
                matchRow.Weather = match_info["weather"];

                int pl_def = 0;
                int pl_mid = 0;
                int pl_att = 0;

                List<int> homePlayers = new List<int>();
                foreach (string player_row in home_pl)
                {
                    Dictionary<string, string> team = HTML_Parser.CreateDictionary(player_row, ';');

                    string pos = team["position"];

                    if ((pos.StartsWith("dc")) || (pos == "dr") || (pos == "dl"))
                    {
                        pl_def++;
                    }
                    else if (pos.StartsWith("fc"))
                    {
                        pl_att++;
                    }
                    else if ((pos.StartsWith("m")) || (pos.StartsWith("dm")) || pos.StartsWith("om"))
                    {
                        pl_mid++;
                    }

                    int teamID = homeTeamId;

                    int playerID = int.Parse(team["player_id"]);
                    NTR_SquadDb.PlayerRow pl = seasonsDB.Player.FindByPlayerID(playerID);
                    if (pl == null)
                    {
                        pl = seasonsDB.Player.NewPlayerRow();
                        pl.PlayerID = playerID;
                        pl.Name = team["name"];
                        seasonsDB.Player.AddPlayerRow(pl);
                    }
                    pl.TeamID = homeTeamId;

                    NTR_SquadDb.PlayerPerfRow ppr = seasonsDB.PlayerPerf.FindByMatchIDPlayerID(matchId, playerID);
                    if (ppr == null)
                    {
                        ppr = seasonsDB.PlayerPerf.NewPlayerPerfRow();
                        ppr.MatchID = matchId;
                        ppr.PlayerID = playerID;
                        seasonsDB.PlayerPerf.AddPlayerPerfRow(ppr);
                    }

                    pl.FP = team["fp"].ToUpper();
                    pl.FP = pl.FP.Replace(',', '/');
                    pl.FPn = Tm_Utility.FPToNumber(pl.FP);
                    ppr.TeamID = homeTeamId;
                    ppr.Assist = 0;
                    if (team["no"] == "null") team["no"] = "0";
                    ppr.Number = int.Parse(team["no"]);
                    ppr.Position = team["position"];
                    ppr.Scored = 0;
                    if (team["rating"] != "0")
                        ppr.Vote = float.Parse(team["rating"], System.Globalization.NumberStyles.Any, CommGlobal.ciUs);
                    ppr.NPos = Pos.ToCode(ppr.Position);
                    ppr.Status = "";
                    ppr.Rec = decimal.Parse(team["rec"], CommGlobal.ciUs);
                    if (team["mom"] == "1")
                        matchRow.BestPlayer = ppr.PlayerID;
                    ppr.Rou = decimal.Parse(team["routine"], CommGlobal.ciUs);

                    homePlayers.Add(playerID);
                }

                string homeformation = pl_def.ToString() + "-" + pl_mid.ToString() + "-" + pl_att.ToString();

                pl_att = pl_def = pl_mid = 0;

                List<int> awayPlayers = new List<int>();
                foreach (string player_row in away_pl)
                {
                    Dictionary<string, string> team = HTML_Parser.CreateDictionary(player_row, ';');

                    string pos = team["position"];

                    if ((pos.StartsWith("dc")) || (pos == "dr") || (pos == "dl"))
                    {
                        pl_def++;
                    }
                    else if (pos.StartsWith("fc"))
                    {
                        pl_att++;
                    }
                    else if ((pos.StartsWith("m")) || (pos.StartsWith("dm")) || pos.StartsWith("om"))
                    {
                        pl_mid++;
                    }

                    int teamID = awayTeamId;

                    int playerID = int.Parse(team["player_id"]);
                    NTR_SquadDb.PlayerRow pl = seasonsDB.Player.FindByPlayerID(playerID);
                    if (pl == null)
                    {
                        pl = seasonsDB.Player.NewPlayerRow();
                        pl.PlayerID = playerID;
                        pl.Name = team["name"];
                        seasonsDB.Player.AddPlayerRow(pl);
                    }
                    pl.TeamID = awayTeamId;

                    NTR_SquadDb.PlayerPerfRow ppr = seasonsDB.PlayerPerf.FindByMatchIDPlayerID(matchId, playerID);
                    if (ppr == null)
                    {
                        ppr = seasonsDB.PlayerPerf.NewPlayerPerfRow();
                        ppr.MatchID = matchId;
                        ppr.PlayerID = playerID;
                        seasonsDB.PlayerPerf.AddPlayerPerfRow(ppr);
                    }

                    pl.FP = team["fp"].ToUpper();
                    pl.FP = pl.FP.Replace(',', '/');
                    pl.FPn = Tm_Utility.FPToNumber(pl.FP);
                    ppr.TeamID = awayTeamId;
                    ppr.Assist = 0;
                    if (team["no"] == "null") team["no"] = "0";
                    ppr.Number = int.Parse(team["no"]);
                    ppr.Position = team["position"];
                    ppr.Scored = 0;
                    if (team["rating"] != "0")
                        ppr.Vote = float.Parse(team["rating"], System.Globalization.NumberStyles.Any, CommGlobal.ciUs);
                    ppr.NPos = Pos.ToCode(ppr.Position);
                    ppr.Status = "";
                    ppr.Rec = decimal.Parse(team["rec"], CommGlobal.ciUs);
                    if (team["mom"] == "1")
                        matchRow.BestPlayer = ppr.PlayerID;
                    ppr.Rou = decimal.Parse(team["routine"], CommGlobal.ciUs);

                    awayPlayers.Add(playerID);
                }

                string awayformation = pl_def.ToString() + "-" + pl_mid.ToString() + "-" + pl_att.ToString();
                if (matchRow.isHome)
                {
                    matchRow.Lineups = homeformation + ";" + awayformation;
                }
                else
                {
                    matchRow.Lineups = awayformation + ";" + homeformation;
                }

                List<string> mins = HTML_Parser.GetTags(report, "MIN");

                int homeGoal = 0;
                int awayGoal = 0;
                int homeTiriIn = 0;
                int awayTiriIn = 0;
                int homeTiriTot = 0;
                int awayTiriTot = 0;
                int homeYellow = 0;
                int awayYellow = 0;
                int homeRed = 0;
                int awayRed = 0;
                int homeSetPc = 0;
                int awaySetPc = 0;
                int homeDef = 0;
                int awayDef = 0;

                List<int> goalPlayers = new List<int>();
                List<int> asstPlayers = new List<int>();
                List<int> stpcPlayers = new List<int>();
                List<int> yelcPlayers = new List<int>();
                List<int> redcPlayers = new List<int>();
                List<int> injrPlayers = new List<int>();

                ActionsList yourActionsList = new ActionsList();
                ActionsList oppsActionsList = new ActionsList();
                Dictionary<int, ActionsList> playerActionListDict = new Dictionary<int, ActionsList>();

                foreach (string min in mins)
                {
                    string min_mod = min.Replace("action=(", "").Replace(")(", ";").Replace(")", "");
                    Dictionary<string, string> items = HTML_Parser.CreateDictionary(min_mod, ';');

                    if ((items["club"] == "undefined") || (items["club"] == "0") || (items["club"] == "null")) continue;

                    bool isHome = (items["club"] == homeTeamId.ToString());
                    // if (!isHome && (items["club"] != AwayID.ToString())) continue;

                    NTR_SquadDb.ActionsRow atr = seasonsDB.Actions.NewActionsRow();
                    atr.ActionCode = items["type"];
                    atr.ActionType = atr.ActionCode;
                    atr.FullDesc = min;
                    string strColor = isHome ? match_info["home_color"] : match_info["away_color"];
                    if ((strColor == "undefined") || (strColor == "")) strColor = "0000FF";

                    if (isHome)
                        homeTeamRow.Color = int.Parse(strColor, System.Globalization.NumberStyles.HexNumber);

                    if (!items.ContainsKey("text"))
                    {
                        continue;
                    }

                    atr.Time = int.Parse(items["min"]);
                    atr.TeamID = int.Parse(items["club"]);
                    atr.MatchID = matchId;

                    string description = items["text"];
                    string attPlayers = "";
                    string defPlayers = "";

                    while (description.Contains("[player="))
                    {
                        string strnum = HTML_Parser.GetNumberAfter(description, "[player=");
                        if (strnum == "]") strnum = "";
                        int numPl = 0;
                        if (!int.TryParse(strnum, out numPl))
                        {
                            description = description.Replace("[player=" + strnum + "]", "(unknown)");
                            continue;
                        }

                        NTR_SquadDb.PlayerRow pr = seasonsDB.Player.FindByPlayerID(numPl);
                        string name = pr.Name;

                        description = description.Replace("[player=" + strnum + "]", name);

                        if (pr.TeamRow.TeamID == atr.TeamID)
                        {
                            attPlayers += numPl.ToString() + ",";
                        }
                        else
                        {
                            defPlayers += numPl.ToString() + ",";
                        }
                    }

                    atr.Attackers = attPlayers;
                    atr.Defenders = defPlayers;

                    atr.Description = description;

                    NTR_SquadDb.ActionsDecoderRow actionDecRow = seasonsDB.ActionsDecoder.FindByActionCode(atr.ActionCode);
                    if (actionDecRow == null)
                    {
                        actionDecRow = seasonsDB.ActionsDecoder.NewActionsDecoderRow();
                        actionDecRow.ActionCode = atr.ActionCode;
                        seasonsDB.ActionsDecoder.AddActionsDecoderRow(actionDecRow);

                        ActionDecoder actionDecoderDlg = new ActionDecoder();
                        actionDecoderDlg.Data = actionDecRow;
                        actionDecoderDlg.Description = description;
                        actionDecoderDlg.FullDescription = atr.FullDesc;

                        if (actionDecoderDlg.ShowDialog() == DialogResult.Cancel)
                        {
                            if (MessageBox.Show("Do you want to continue with the next action [press OK] or cancel [press Cancel] the analysis of the actions at all for this match?", "Actions analysis", MessageBoxButtons.OKCancel) == DialogResult.OK)
                                continue;
                            else
                                break;
                        }
                    }

                    seasonsDB.Actions.AddActionsRow(atr);

                    if (atr.TeamID == yourTeamId)
                        yourActionsList.AddNewAttackAction(actionDecRow);
                    else
                        oppsActionsList.AddNewAttackAction(actionDecRow);

                    List<int> playerIds = HTML_Parser.GetNumbersBetween(atr.FullDesc, "[player=", "]");
                    foreach (int playerId in playerIds)
                    {
                        if (!playerActionListDict.ContainsKey(playerId))
                            playerActionListDict.Add(playerId, new ActionsList());

                        ActionsList playerActionList = playerActionListDict[playerId];

                        int playerTeamId = -1;
                        if (homePlayers.Contains(playerId))
                            playerTeamId = homeTeamId;
                        else
                            playerTeamId = awayTeamId;

                        if (atr.TeamID == playerTeamId)
                            playerActionList.AddNewAttackAction(actionDecRow);
                        else
                            playerActionList.AddNewDefendAction(actionDecRow);
                    }

                    if (items.ContainsKey("injury"))
                    {
                        injrPlayers.Add(int.Parse(items["injury"]));
                    }
                    else if (items.ContainsKey("scorer"))
                    {
                        goalPlayers.Add(int.Parse(items["scorer"]));
                        if (isHome) homeGoal++; else awayGoal++;
                        if (isHome) homeTiriIn++; else awayTiriIn++;
                        if (isHome) homeTiriTot++; else awayTiriTot++;
                        if ((items["assist"] != "none"))
                            asstPlayers.Add(int.Parse(items["assist"]));
                    }
                    else if (items.ContainsKey("target"))
                    {
                        if (items["target"] == "on")
                        {
                            if (isHome) homeTiriIn++; else awayTiriIn++;
                            if (isHome) homeTiriTot++; else awayTiriTot++;
                        }
                        else
                        {
                            if (isHome) homeTiriTot++; else awayTiriTot++;
                        }
                    }
                    else if (items.ContainsKey("set_piece"))
                    {
                        stpcPlayers.Add(int.Parse(items["set_piece"]));
                        if (isHome) homeSetPc++; else awaySetPc++;

                        if (items.ContainsKey("target"))
                        {
                            if (items["target"] == "on")
                            {
                                if (isHome) homeTiriIn++; else awayTiriIn++;
                                if (isHome) homeTiriTot++; else awayTiriTot++;
                            }
                            else
                            {
                                if (isHome) homeTiriTot++; else awayTiriTot++;
                            }
                        }
                    }
                    else if (items.ContainsKey("yellow_red"))
                    {
                        yelcPlayers.Add(int.Parse(items["yellow_red"]));
                        if (isHome) awayYellow++; else homeYellow++;
                        redcPlayers.Add(int.Parse(items["yellow_red"]));
                        if (isHome) awayRed++; else homeRed++;
                    }
                    else if (items.ContainsKey("yellow"))
                    {
                        yelcPlayers.Add(int.Parse(items["yellow"]));
                        if (isHome) awayYellow++; else homeYellow++;
                    }
                    else if (items.ContainsKey("red"))
                    {
                        redcPlayers.Add(int.Parse(items["red"]));
                        if (isHome) awayRed++; else homeRed++;
                    }
                    else
                    {
                        if (isHome) awayDef++; else homeDef++;
                    }
                }

                matchRow.Score = homeGoal.ToString() + "-" + awayGoal.ToString();

                matchRow.OActions = oppsActionsList.ToString();
                matchRow.YActions = yourActionsList.ToString();

                matchRow.OTeamID = oppsTeamId;
                matchRow.YTeamID = yourTeamId;

                matchRow.Analyzed = 1;
                matchRow.Report = true;

                string type = match_info["matchtype"];
                if (type == "l")
                    matchRow.MatchType = (byte)0;
                else if (type == "f")
                    matchRow.MatchType = (byte)2;
                else if (type == "fl")
                    matchRow.MatchType = (byte)3;
                else if (type.StartsWith("p"))
                {
                    byte i = byte.Parse(type.Substring(1));
                    matchRow.MatchType = (byte)(10 + i);
                }
                else if (type.StartsWith("ue"))
                {
                    byte i = byte.Parse(type.Substring(2));
                    matchRow.MatchType = (byte)(20 + i);
                }
                else if (type.StartsWith("lq"))
                {
                    matchRow.MatchType = (byte)5; // Qualificazioni campionato
                }
                else
                {
                    matchRow.MatchType = (byte)4; // Altra internazionale
                }

                long iKickOff = long.Parse(match_info["kickoff"]);

                DateTime dt = new DateTime(1970, 1, 1, 1, 0, 0);
                matchRow.Date = dt.AddSeconds((double)iKickOff);

                foreach (KeyValuePair<int, ActionsList> actionList in playerActionListDict)
                {
                    NTR_SquadDb.PlayerPerfRow ppr = seasonsDB.PlayerPerf.FindByMatchIDPlayerID(matchId, actionList.Key);
                    if (ppr != null)
                        ppr.Actions = actionList.Value.ToString();
                }

                ActionsList tempActionsList = ActionsList.Parse(matchRow.OActions);

                string home_stats = match_info["possession_home"] + "%;" +
                    homeTiriTot.ToString() + ";" +
                    homeTiriIn.ToString() + ";" +
                    homeYellow.ToString() + ";" +
                    homeRed.ToString() + ";";
                string away_stats = match_info["possession_away"] + "%;" +
                    awayTiriTot.ToString() + ";" +
                    awayTiriIn.ToString() + ";" +
                    awayYellow.ToString() + ";" +
                    awayRed.ToString() + ";";

                if (matchRow.isHome)
                {
                    matchRow.Stats = home_stats + ";" + away_stats;
                }
                else
                {
                    matchRow.Stats = away_stats + ";" + home_stats;
                }

                // Assegna i gol
                foreach (int gp in goalPlayers)
                {
                    NTR_SquadDb.PlayerPerfRow ppr = seasonsDB.PlayerPerf.FindByMatchIDPlayerID(matchId, gp);
                    if (ppr != null) { ppr.Scored += 1; continue; }
                }

                // Assegna gli assist
                foreach (int gp in asstPlayers)
                {
                    NTR_SquadDb.PlayerPerfRow ppr = seasonsDB.PlayerPerf.FindByMatchIDPlayerID(matchId, gp);
                    if (ppr != null) { ppr.Assist += 1; continue; }
                }

                // Assegna gli infortuni
                foreach (int gp in injrPlayers)
                {
                    NTR_SquadDb.PlayerPerfRow ppr = seasonsDB.PlayerPerf.FindByMatchIDPlayerID(matchId, gp);
                    if (ppr != null) { ppr.Status += "I"; continue; }
                }

                // Assegna i gialli
                foreach (int gp in yelcPlayers)
                {
                    NTR_SquadDb.PlayerPerfRow ppr = seasonsDB.PlayerPerf.FindByMatchIDPlayerID(matchId, gp);
                    if (ppr != null) { ppr.Status += "Y"; continue; }
                }

                // Assegna i rossi
                foreach (int gp in redcPlayers)
                {
                    NTR_SquadDb.PlayerPerfRow ppr = seasonsDB.PlayerPerf.FindByMatchIDPlayerID(matchId, gp);
                    if (ppr != null) { ppr.Status += "R"; continue; }
                }

                if (matchRow.isHome)
                    matchRow.TeamRowByTeam_OTeam.Name = match_info["away_name"];
                else
                    matchRow.TeamRowByTeam_OTeam.Name = match_info["home_name"];

                string oppsColor = matchRow.isHome ? match_info["away_color"] : match_info["home_color"];
                if ((oppsColor == "undefined") || (oppsColor == "")) oppsColor = "0000FF";

                if (matchRow.isHome)
                    matchRow.TeamRowByTeam_OTeam.Color = int.Parse(oppsColor, System.Globalization.NumberStyles.HexNumber);

                matchRow.TeamRowByTeam_OTeam.Owner = false;

                return true;
            }
            catch (Exception ex)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";
                string reportInfo = "";

                string filename = "matchRowTable." + DateTime.Now.Hour.ToString() +
                    DateTime.Now.Minute.ToString() + ".tmreport.txt";

                string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                appDataFolder = Path.Combine(appDataFolder, "TmRecorder");

                string pathfilename = Path.Combine(appDataFolder, filename);
                FileInfo fi = new FileInfo(pathfilename);

                matchRow.Table.WriteXml(fi.FullName);
                StreamReader file = new StreamReader(fi.FullName);
                reportInfo += "PlayersDS:\r\n" + file.ReadToEnd();
                file.Close();

                reportInfo += "\r\nPage:\r\n" + page;

                SendFileTo.ErrorReport.Send(ex, reportInfo, Environment.StackTrace, swRelease);
                MessageBox.Show("Sorry. The importing process has failed. If you clicked ok, the info of the error have " +
                    "been sent to Led Lennon that will remove this bug as soon as possible.");

                return false;
            }
        }

        public class PlayerStats
        {
            public int Assist { get; private set; }
            public float AvgVote { get; private set; }
            public int FPn { get; private set; }
            public int GamePlayed { get; private set; }
            public int Injuries { get; private set; }
            public string Name { get; private set; }
            public int PlayerId { get; internal set; }
            public int Red { get; private set; }
            public int Scored { get; private set; }
            public float SdVote { get; private set; }
            public float Vote2 { get; private set; }
            public int Yellow { get; private set; }

            internal void Add(NTR_SquadDb.PlayerPerfRow playerPerf)
            {
                this.Name = playerPerf.PlayerRow.Name;
                this.PlayerId = playerPerf.PlayerID;

                if (playerPerf.IsVoteNull())
                    return;

                if (playerPerf.PlayerRow.IsFPNull())
                    this.FPn = 0;
                else
                    this.FPn = playerPerf.PlayerRow.FPn;

                this.GamePlayed += 1;
                this.AvgVote = (this.AvgVote * (this.GamePlayed - 1) + playerPerf.Vote) / this.GamePlayed;
                this.Vote2 += (playerPerf.Vote * playerPerf.Vote);
                float variance = (this.Vote2 - this.AvgVote * this.AvgVote * this.GamePlayed) / this.GamePlayed;
                if (variance < 0) variance = 0;
                this.SdVote = (float)Math.Sqrt(variance);
                this.Scored += playerPerf.Scored;
                this.Assist += playerPerf.Assist;

                if (playerPerf.Status.Contains("YYR"))
                {
                    this.Yellow += 2;
                    this.Red += 1;
                }
                else if (playerPerf.Status.Contains("R"))
                {
                    this.Red += 1;
                }
                else if (playerPerf.Status.Contains("Y"))
                {
                    this.Yellow += 1;
                }
                else if (playerPerf.Status.Contains("I"))
                {
                    this.Injuries += 1;
                }
            }
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
