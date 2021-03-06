using Common;
using Languages;
using NTR_Common;
using SendFileTo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NTR_Db
{
    public enum ContentType
    {
        Squad,
        Training,
    }

    public class Content
    {
        public int TeamID;

        public string ClubName { get; set; }

        public string DocText { get; set; }

        public int MainSquadID { get; set; }

        public int ReserveSquadID { get; set; }

        public NTR_SquadDb squadDB { get; set; }

        public int Week { get; set; }

        public void ParsePage(string page, string address, int importWeek = -1)
        {
            if (page.Contains("http://trophymanager.com/players/"))
            {
                string[] stringSeparators = new string[] { "\n\r\n" };
                string[] pages = page.Split(stringSeparators, StringSplitOptions.None);

                if (pages.Length < 2)
                {
                    string swRelease = "Sw Release:" + Application.ProductName + "(" + Application.ProductVersion + ")";
                    page = "Navigation Address: " + address + "\n" + page;

                    string message = "Error retrieving data from the players page";
                    SendFileTo.ErrorReport.SendPage(message, page, Environment.StackTrace, swRelease);
                }
                else
                {
                    // Get the actual week
                    if (importWeek == -1)
                        this.Week = TmWeek.thisWeek().absweek;
                    else
                        this.Week = importWeek;

                    LoadSquad(pages[0]);
                    LoadTraining(pages[1]);
                }
            }
            else if (page.Contains("http://trophymanager.com/matches/"))
            {
                LoadMatches(page);
            }
            else if (page.Contains("http://trophymanager.com/fixtures/club/"))
            {
                LoadFixtures(page);
            }
        }

        private int LoadFixtures(string page)
        {
            int cnt = 0;

            string strTeamId = HTML_Parser.GetNumberAfter(page, "fixtures/club/");
            TeamID = int.Parse(strTeamId);

            // Get the items
            string[] rows = page.Split('\n');

            foreach (string row in rows)
            {
                if (!row.Contains(";")) continue;

                Dictionary<string, string> items = HTML_Parser.CreateDictionary(row, ';');

                int matchId = int.Parse(items["id"]);

                NTR_SquadDb.MatchRow matchRow = squadDB.Match.FindByMatchID(matchId);
                if (matchRow == null)
                {
                    matchRow = squadDB.Match.NewMatchRow();
                    matchRow.MatchID = matchId;
                    squadDB.Match.AddMatchRow(matchRow);
                }

                // First, get the day number
                matchRow.Date = DateTime.Parse(items["date"]);
                matchRow.Score = items["result"];

                int home = int.Parse(items["home"]);
                int away = int.Parse(items["away"]);

                matchRow.isHome = (home == TeamID);

                int OTeamID = 0;
                string OTeamName = "";

                if (matchRow.isHome)
                {
                    matchRow.Analyzed = 0;
                    matchRow.YTeamID = home;
                    matchRow.TeamRowByTeam_YTeam.Name = items["home_name"];
                    OTeamID = away;
                    OTeamName = items["away_name"];
                }
                else if (away == this.TeamID)
                {
                    matchRow.Analyzed = 0;
                    matchRow.YTeamID = away;
                    matchRow.TeamRowByTeam_YTeam.Name = items["away_name"];
                    OTeamID = home;
                    OTeamName = items["home_name"];
                }

                NTR_SquadDb.TeamRow trow = this.squadDB.Team.FindByTeamID(OTeamID);
                if (trow == null)
                {
                    trow = this.squadDB.Team.NewTeamRow();
                    trow.TeamID = OTeamID;
                    trow.Owner = false;
                    squadDB.Team.AddTeamRow(trow);
                }

                matchRow.OTeamID = OTeamID;
                matchRow.TeamRowByTeam_OTeam.Name = OTeamName;

                if (items["type"] == "l")
                    matchRow.MatchType = (byte)0;
                else if (items["type"] == "f")
                    matchRow.MatchType = (byte)2;
                else if (items["type"] == "fl")
                    matchRow.MatchType = (byte)3;
                else if (items["type"].StartsWith("p"))
                {
                    byte i = byte.Parse(items["type"].Substring(1));
                    matchRow.MatchType = (byte)(10 + i);
                }
                else if (items["type"].StartsWith("ue"))
                {
                    byte i = byte.Parse(items["type"].Substring(2));
                    matchRow.MatchType = (byte)(20 + i);
                }
                else if (items["type"].StartsWith("lq"))
                {
                    matchRow.MatchType = (byte)5; // Qualificazioni campionato
                }
                else
                {
                    matchRow.MatchType = (byte)4; // Altra internazionale
                }

                cnt++;
            }

            return cnt;
        }

        private bool LoadMatches(string page)
        {
            if (page.Contains("Javascript error")) return false;

            string lineup_home_str = HTML_Parser.GetTag(page, "LINEUP_HOME");
            string lineup_away_str = HTML_Parser.GetTag(page, "LINEUP_AWAY");
            string match_info_str = HTML_Parser.GetTag(page, "MATCH_INFO");
            string report = HTML_Parser.GetTag(page, "REPORT");

            if (match_info_str.Contains("forfait=yes")) return false;

            string[] att_styles = { "Bal", "Bal", "Count", "Wing", "Short", "Long", "Filt" };
            string[] mentality = { "Norm", "VeDef", "Def", "SlDef", "Norm", "SlOff", "Off", "VrOff" };
            string[] focus = { "-", "Balanced", "Left", "Center", "Right" };

            string matchIdStr = HTML_Parser.GetNumberAfter(page, TM_Pages.Matches);
            int matchId = int.Parse(matchIdStr);

            if (squadDB == null)
                squadDB = new NTR_SquadDb();

            NTR_SquadDb.MatchRow matchRow = squadDB.Match.FindByMatchID(matchId);
            if (matchRow == null)
            {
                matchRow = squadDB.Match.NewMatchRow();
                matchRow.MatchID = matchId;
                squadDB.Match.AddMatchRow(matchRow);
            }

            try
            {
                List<string> home_pl = HTML_Parser.GetTags(lineup_home_str, "PL");
                List<string> away_pl = HTML_Parser.GetTags(lineup_away_str, "PL");

                Dictionary<string, string> match_info = HTML_Parser.CreateDictionary(match_info_str.Trim(';'), ';');

                int homeTeamId = int.Parse(match_info["home_id"]);
                int awayTeamId = int.Parse(match_info["away_id"]);

                NTR_SquadDb.TeamRow homeTeamRow = squadDB.Team.FindByTeamID(homeTeamId);
                if (homeTeamRow == null)
                {
                    homeTeamRow = squadDB.Team.NewTeamRow();
                    homeTeamRow.TeamID = homeTeamId;
                    squadDB.Team.AddTeamRow(homeTeamRow);
                }
                homeTeamRow.Nick = match_info["home_nick"];
               
                NTR_SquadDb.TeamRow awayTeamRow = squadDB.Team.FindByTeamID(awayTeamId);
                if (awayTeamRow == null)
                {
                    awayTeamRow = squadDB.Team.NewTeamRow();
                    awayTeamRow.TeamID = awayTeamId;
                    squadDB.Team.AddTeamRow(awayTeamRow);
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
                    matchRow.FocusSides = focus[int.Parse(match_info["home_focus_side"])] + ";" + focus[int.Parse(match_info["away_focus_side"])];
                }
                else
                {
                    matchRow.Mentalities = mentality[int.Parse(match_info["away_mentality"])] + ";" + mentality[int.Parse(match_info["home_mentality"])];
                    matchRow.AttackStyles = att_styles[int.Parse(match_info["away_attstyle"])] + ";" + att_styles[int.Parse(match_info["home_attstyle"])];
                    matchRow.FocusSides = focus[int.Parse(match_info["away_focus_side"])] + ";" + focus[int.Parse(match_info["home_focus_side"])];
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
                    NTR_SquadDb.PlayerRow pl = squadDB.Player.FindByPlayerID(playerID);
                    if (pl == null)
                    {
                        pl = squadDB.Player.NewPlayerRow();
                        pl.PlayerID = playerID;
                        pl.Name = team["name"];
                        squadDB.Player.AddPlayerRow(pl);
                    }
                    pl.TeamID = homeTeamId;

                    NTR_SquadDb.PlayerPerfRow ppr = squadDB.PlayerPerf.FindByMatchIDPlayerID(matchId, playerID);
                    if (ppr == null)
                    {
                        ppr = squadDB.PlayerPerf.NewPlayerPerfRow();
                        ppr.MatchID = matchId;
                        ppr.PlayerID = playerID;
                        squadDB.PlayerPerf.AddPlayerPerfRow(ppr);
                    }

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
                    ppr.Rec = decimal.Parse(team["rec"]);
                    if (team["mom"] == "1")
                        matchRow.BestPlayer = ppr.PlayerID;

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
                    NTR_SquadDb.PlayerRow pl = squadDB.Player.FindByPlayerID(playerID);
                    if (pl == null)
                    {
                        pl = squadDB.Player.NewPlayerRow();
                        pl.PlayerID = playerID;
                        pl.Name = team["name"];
                        squadDB.Player.AddPlayerRow(pl);
                    }
                    pl.TeamID = awayTeamId;

                    NTR_SquadDb.PlayerPerfRow ppr = squadDB.PlayerPerf.FindByMatchIDPlayerID(matchId, playerID);
                    if (ppr == null)
                    {
                        ppr = squadDB.PlayerPerf.NewPlayerPerfRow();
                        ppr.MatchID = matchId;
                        ppr.PlayerID = playerID;
                        squadDB.PlayerPerf.AddPlayerPerfRow(ppr);
                    }

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
                    ppr.Rec = decimal.Parse(team["rec"]);
                    if (team["mom"] == "1")
                        matchRow.BestPlayer = ppr.PlayerID;

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

                    NTR_SquadDb.ActionsRow atr = squadDB.Actions.NewActionsRow();
                    atr.ActionCode = items["type"];
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

                        NTR_SquadDb.PlayerRow pr = squadDB.Player.FindByPlayerID(numPl);
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

                    NTR_SquadDb.ActionsDecoderRow actionDecRow = squadDB.ActionsDecoder.FindByActionCode(atr.ActionCode);
                    if (actionDecRow == null)
                    {
                        actionDecRow = squadDB.ActionsDecoder.NewActionsDecoderRow();
                        actionDecRow.ActionCode = atr.ActionCode;
                        squadDB.ActionsDecoder.AddActionsDecoderRow(actionDecRow);

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

                    squadDB.Actions.AddActionsRow(atr);
                    
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

                foreach(KeyValuePair<int, ActionsList> actionList in playerActionListDict)
                {
                    NTR_SquadDb.PlayerPerfRow ppr = squadDB.PlayerPerf.FindByMatchIDPlayerID(matchId, actionList.Key);
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
                    NTR_SquadDb.PlayerPerfRow ppr = squadDB.PlayerPerf.FindByMatchIDPlayerID(matchId, gp);
                    if (ppr != null) { ppr.Scored += 1; continue; }
                }

                // Assegna gli assist
                foreach (int gp in asstPlayers)
                {
                    NTR_SquadDb.PlayerPerfRow ppr = squadDB.PlayerPerf.FindByMatchIDPlayerID(matchId, gp);
                    if (ppr != null) { ppr.Assist += 1; continue; }
                }

                // Assegna gli infortuni
                foreach (int gp in injrPlayers)
                {
                    NTR_SquadDb.PlayerPerfRow ppr = squadDB.PlayerPerf.FindByMatchIDPlayerID(matchId, gp);
                    if (ppr != null) { ppr.Status += "I"; continue; }
                }

                // Assegna i gialli
                foreach (int gp in yelcPlayers)
                {
                    NTR_SquadDb.PlayerPerfRow ppr = squadDB.PlayerPerf.FindByMatchIDPlayerID(matchId, gp);
                    if (ppr != null) { ppr.Status += "Y"; continue; }
                }

                // Assegna i rossi
                foreach (int gp in redcPlayers)
                {
                    NTR_SquadDb.PlayerPerfRow ppr = squadDB.PlayerPerf.FindByMatchIDPlayerID(matchId, gp);
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

        private void LoadSquad(string squad)
        {
            string originalSquadString = squad;
            short isReserves = 0;
            int player = 0;

            try
            {
                // Creates the DB where to put the results, in case it's not already created
                if (squadDB == null)
                    squadDB = new NTR_SquadDb();

                {
                    int Id = 0;

                    int.TryParse(HTML_Parser.GetNumberAfter(originalSquadString, "A_team="), out Id);
                    MainSquadID = Id;
                    NTR_SquadDb.TeamRow tr = squadDB.Team.FindByTeamID(Id);
                    if (tr == null)
                    {
                        tr = squadDB.Team.NewTeamRow();
                        tr.TeamID = Id;
                        if (Id == TeamID)
                            tr.Name = ClubName;
                        else
                            tr.Name = "";
                        squadDB.Team.AddTeamRow(tr);
                    }
                    tr.Owner = true;
                    tr.ReserveOf = 0;

                    int.TryParse(HTML_Parser.GetNumberAfter(originalSquadString, "B_team="), out Id);
                    ReserveSquadID = Id;

                    if (Id != 0)
                    {
                        tr = squadDB.Team.FindByTeamID(Id);
                        if (tr == null)
                        {
                            tr = squadDB.Team.NewTeamRow();
                            tr.TeamID = Id;
                            tr.Name = "";
                            squadDB.Team.AddTeamRow(tr);
                        }
                        tr.Owner = true;
                        tr.ReserveOf = 0;
                    }
                }

                // squad = HTML_Parser.ConvertHTML_Text(squad);
                squad = HTML_Parser.ConvertUnicodes_Text(squad);
                squad = HTML_Parser.ConvertUnicodes_MoreText(squad);

                string[] plRows = squad.Split('\n');

                // Row 0 is the table header
                for (player = 0; player < plRows.Length; player++)
                {
                    if (!plRows[player].Contains("id=")) continue;

                    string strPlayer = plRows[player].Trim(';');

                    ParsePlayer(strPlayer);
                }
            }
            catch (Exception e)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";

                string info = "";

                string filename = "dbinfo." + DateTime.Now.Hour.ToString() +
                    DateTime.Now.Minute.ToString() + ".tmreport.txt";
                string pathfilename = Path.Combine(Application.LocalUserAppDataPath, filename);
                FileInfo fi = new FileInfo(pathfilename);

                squadDB.WriteXml(fi.FullName);

                StreamReader file = new StreamReader(fi.FullName);
                info += "SquadDB:\r\n" + file.ReadToEnd();
                file.Close();

                info += "isReserves:" + isReserves.ToString();
                info += "player:" + player.ToString();
                info += "Squad:" + originalSquadString;

                ErrorReport.Send(e, info, Environment.StackTrace, swRelease);
                MessageBox.Show(Current.Language.SorryTheImportingProcessHasFailedIfYouClickedOkTheInfoOfTheErrorHave +
                    Current.Language.BeenSentToLedLennonThatWillRemoveThisBugAsSoonAsPossible);
            }
        }

        private void LoadTraining(string page)
        {
            string[] playersTr = page.Split('\n');

            if (playersTr.Length == 0)
            {
                MessageBox.Show("Cannot import training", "Content/LoadTraining Function Error", MessageBoxButtons.OK);
                return;
            }

            foreach (string playerTr in playersTr)
            {
                Dictionary<string, string> data = TM_Parser.CreateDictionary_NewTm(playerTr);

                if (data.Count == 0) continue;

                // Row 0 is the table header
                int playerID = int.Parse(data["player"]);

                NTR_SquadDb.HistDataRow histRow = squadDB.HistData.FindByPlayerIDWeek(playerID, this.Week);
                if (histRow == null)
                {
                    // But the history row should already exist
                    histRow = squadDB.HistData.NewHistDataRow();
                    histRow.PlayerID = playerID;
                    histRow.Week = this.Week;
                    squadDB.HistData.AddHistDataRow(histRow);
                }

                int TI = int.Parse(data["ti"]);

                bool isGK = (histRow.PlayerRow.FPn == 0);
                UInt64 trCode = Tm_Training.TrainingDataToTrCode2(data, isGK);

                histRow.Training = trCode;
                histRow._TI = TI;
            }
        }

        public void ParsePlayer(string strPlayer)
        {
            // Creates the DB where to put the results, in case it's not already created
            if (squadDB == null)
                squadDB = new NTR_SquadDb();

            strPlayer = strPlayer.Replace("{", "");
            Dictionary<string, string> data = TM_Parser.CreateDictionary_NewTm(strPlayer);

            // Find the player in the DB
            int playerID = int.Parse(data["id"]);
            NTR_SquadDb.PlayerRow playerRow = squadDB.Player.FindByPlayerID(playerID);
            if (playerRow == null)
            {
                playerRow = squadDB.Player.NewPlayerRow();
                playerRow.PlayerID = playerID;
                squadDB.Player.AddPlayerRow(playerRow);
            }            

            NTR_SquadDb.HistDataRow histRow = squadDB.HistData.FindByPlayerIDWeek(playerID, this.Week);
            if (histRow == null)
            {
                histRow = squadDB.HistData.NewHistDataRow();
                histRow.PlayerID = playerID;
                histRow.Week = this.Week;
                squadDB.HistData.AddHistDataRow(histRow);
            }

            NTR_SquadDb.TempDataRow tempRow = squadDB.TempData.FindByPlayerID(playerID);
            if (tempRow == null)
            {
                tempRow = squadDB.TempData.NewTempDataRow();
                tempRow.PlayerID = playerID;
                squadDB.TempData.AddTempDataRow(tempRow);
            }

            histRow.Inj = 0;
            histRow.Ban = 0;

            // Row0: Numero
            playerRow.No = int.Parse(data["no"]);

            if (data["inj"] != "null")
                histRow.Inj = short.Parse(data["inj"]);
            histRow.Ban = short.Parse(data["ban_points"]);

            playerRow.Name = data["name"].Replace("  ", " ");
            playerRow.Nationality = data["country"];
            playerRow.wBorn = TmWeek.GetBornWeekFromAgeString(data["age"]);
            playerRow.FP = TM_Compatible.ConvertNewFP(data["fp"]);
            playerRow.FPn = Tm_Utility.FPToNumber(playerRow.FP);

            if (playerRow.FPn > 0)
            {
                histRow.For = int.Parse(data["str"]);
                histRow.Res = int.Parse(data["sta"]);
                histRow.Vel = int.Parse(data["pac"]);

                histRow.Mar = int.Parse(data["mar"]);
                histRow.Con = int.Parse(data["tac"]);
                histRow.Wor = int.Parse(data["wor"]);
                histRow.Pos = int.Parse(data["pos"]);
                histRow.Pas = int.Parse(data["pas"]);
                histRow.Cro = int.Parse(data["cro"]);
                histRow.Tec = int.Parse(data["tec"]);
                histRow.Tes = int.Parse(data["hea"]);
                histRow.Fin = int.Parse(data["fin"]);
                histRow.Dis = int.Parse(data["lon"]);
                histRow.Cal = int.Parse(data["set"]);
            }
            else
            {
                histRow.For = int.Parse(data["str"]);
                histRow.Res = int.Parse(data["sta"]);
                histRow.Vel = int.Parse(data["pac"]);

                histRow.Pre = int.Parse(data["han"]);
                histRow.Uno = int.Parse(data["one"]);
                histRow.Rif = int.Parse(data["ref"]);
                histRow.Aer = int.Parse(data["ari"]);
                histRow.Ele = int.Parse(data["jum"]);
                histRow.Com = int.Parse(data["com"]);
                histRow.Tir = int.Parse(data["kic"]);
                histRow.Lan = int.Parse(data["thr"]);
            }

            histRow.ASI = int.Parse(data["asi"]);

            DateTime dateOfImportWeek = (new TmWeek(this.Week)).ToDate();

            if (tempRow.IsUpdateDateNull())
                tempRow.UpdateDate = dateOfImportWeek;

            if (tempRow.UpdateDate <= dateOfImportWeek)
            {
                tempRow.UpdateDate = dateOfImportWeek;
                tempRow.Rou = decimal.Parse(data["routine"], Common.CommGlobal.ciUs);
            }            
        }
    }
}
