using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.IO;

namespace Common
{
    partial class MatchDS
    {
        partial class ParsedActionsDataTable
        {
            // Type codification:
            // Type =XYZZ
            // X = Action type: 1: Attack, 2: Defensive
            // Attack/Defense actions: 
            // Y = 0: Goal
            //     1: Shot
            //     2: Shotoff
            //     3: Chance
            //     4: Yellow
            //     5: Red
            //     6: CP
            // Yellow: 
            // Z = 0: light yellow
            //     1: heavy yellow
            // Goal actions: 
            // Z = 0: CP 
            //     11: Rilancio dal portiere (assist)
            //     14: Cross and assist (assist)
            //     15: Long passage (assist)
            //     20: Shot
            //     21: Head shot
            //     30: GK saved
            //     31: GK failed saving
            // CP actions: 
            // Z = 0: CP very far
            //     1: CP near gol
            //     2: easy to save CP saved from GK
            //     3: promising CP saved from GK
            //     4: promising CP 
            // Attack actions (Shot, shotoff, chance): 
            // Z = 0: Unsuccessful corner or CP
            //     3: Failed head shot
            //     4: Unsuccessfull shot (or shotoff)
            //     6: Unsuccessful long shot
            //     5: Tackled
            //     6: Failed dribbling
            //     7: Failed counterattack
            //     6: Failed shot
            //     9: Failed cross
            //     16: Attempted corner
            //     15: Attempted passage
            //     16: Attempted dribbling
            //     17: Failed shot, near gol
            //     21: Successful dribbling and assist (assist no goal)
            //     22: Successful head shot
            //     23: Successful long passage (assist no goal)
            //     27: Successful counterattack
            //     27: Successful corner
            //     27: Successful cross (assist no goal)
            //     28: Filtering assist passage (assist no goal)
            //     29: Successful counterattack and assist (assist no goal)
            // Defensive actions (Shot, shotoff, chance): 
            // Z = 1: Failed takle on dribbling
            //     2: Failed head contrast
            //     2: Failed contrast
            //     2: Failed marking
            //     10: Successful takle on corner or CP
            //     12: GK saved on shot (w/o reference)
            //     13: Successful takle on shot
            //     14: Successful takle on action
            //     15: Successful takle on long passage
            //     15: Successful takle on filtering passage
            //     13: Successful takle on dribbling
            //     16: Blocked counterattack
            //     17: Very hard goal save (GK)
            //     18: Easy goal save (GK)
        }

        partial class OppsTeamPerfDataTable
        {
            internal void SortByPosition()
            {
                int nPlayers = this.Rows.Count;

                OppsTeamPerfDataTable table = new OppsTeamPerfDataTable();
                while (table.Rows.Count < nPlayers)
                {
                    int min = 100;
                    int pmin = -1;

                    int thisPlayers = this.Rows.Count;

                    // find minimum npos in this
                    for (int i = 0; i < thisPlayers; i++)
                    {
                        if (this[i].NPos < min)
                        {
                            min = this[i].NPos;
                            pmin = i;
                        }
                    }

                    if (pmin != -1)
                    {
                        OppsTeamPerfRow ypr = this[pmin];
                        table.ImportRow(ypr);
                        this.RemoveOppsTeamPerfRow(ypr);
                    }
                }

                foreach (OppsTeamPerfRow ypr in table)
                {
                    this.ImportRow(ypr);
                }
            }
        }

        partial class YourTeamPerfDataTable
        {
            internal void SortByPosition()
            {
                int nPlayers = this.Rows.Count;

                YourTeamPerfDataTable table = new YourTeamPerfDataTable();
                while (table.Rows.Count < nPlayers)
                {
                    int min = 100;
                    int pmin = -1;

                    int thisPlayers = this.Rows.Count;

                    // find minimum npos in this
                    for (int i = 0; i < thisPlayers; i++)
                    {
                        if (this[i].NPos < min)
                        {
                            min = this[i].NPos;
                            pmin = i;
                        }
                    }

                    if (pmin != -1)
                    {
                        YourTeamPerfRow ypr = this[pmin];
                        table.ImportRow(ypr);
                        this.RemoveYourTeamPerfRow(ypr);
                    }
                }

                foreach (YourTeamPerfRow ypr in table)
                {
                    this.ImportRow(ypr);
                }
            }
        }

        public string clubNick = "";
        public string[] clubNicks = new string[2];

        public bool Analyze(string sourcePage, ref ChampDS.MatchRow matchRow)
        {
            int HomeID, AwayID;
            int firstColor = 0;
            bool isFirstColorYourTeam = false;
            string page = sourcePage;

            try
            {

                page = HTML_Parser.ConvertHTML(page);
                // page = page.Replace("Ã", "").Replace("Â", "");
                page = page.Replace("=\"", "=").Replace("\">", ">").Replace("='", "=").Replace("'>", ">");

                string score = HTML_Parser.GetFieldInTags(page, "id=score");
                matchRow.Score = score.Trim("\t\r\n ".ToCharArray());

                string title = "";
                string title1 = HTML_Parser.GetField(page, "<div class=kampnamehome", "</div>");
                string title2 = HTML_Parser.GetField(page, "<div class=kampnameaway", "</div>");

                if (matchRow.isHome)
                    title = title1;
                else
                    title = title2;

                clubNick = HTML_Parser.GetField(title, "<h2 class=kamp>(", ")</h2>");
                clubNicks[0] = HTML_Parser.GetField(title1, "<h2 class=kamp>(", ")</h2>");
                clubNicks[1] = HTML_Parser.GetField(title2, "<h2 class=kamp>(", ")</h2>");

                if (matchRow.isHome)
                {
                    matchRow.YourNick = clubNicks[0];
                    matchRow.OppsNick = clubNicks[1];
                }
                else
                {
                    matchRow.YourNick = clubNicks[1];
                    matchRow.OppsNick = clubNicks[0];
                }

                List<string> tables = HTML_Parser.GetFields(page, "<table", "</table>");

                this.Clear();

                this.MatchData.AddMatchDataRow(matchRow.MatchID, 0, 0, 0, 0);
                if (tables.Count == 0)
                    return true;

                //--------------------------------------------------------------
                // Ricerca dei campi nella tabella 0
                //--------------------------------------------------------------
                {
                    string descr = tables[0].Replace(".\r\n", ". ").Replace("\r\n", " ");
                    descr = descr.Replace("  ", " ").Replace("Â", "");

                    List<string> fields = HTML_Parser.GetTags(descr, "span");
                    matchRow.Stadium = fields[0];
                    matchRow.Crowd = int.Parse(fields[1]);

                    List<string> clubsID = HTML_Parser.GetFieldsCut(descr, "klubhus.php?showclub=", ">");

                    HomeID = int.Parse(clubsID[0]);
                    AwayID = int.Parse(clubsID[1]);

                    if (matchRow.isHome)
                    {
                        matchRow.YourFormation = fields[2];
                        matchRow.OppsFormation = fields[3];
                        matchRow.OppsClubID = AwayID;
                    }
                    else
                    {
                        matchRow.YourFormation = fields[3];
                        matchRow.OppsFormation = fields[2];
                        matchRow.OppsClubID = HomeID;
                    }

                    MatchData[0].OppsTeamID = matchRow.OppsClubID;

                    List<string> clubs = HTML_Parser.GetTags(descr, "a");
                    matchRow.Home = clubs[0];
                    matchRow.Away = clubs[1];

                    matchRow.InitDesciption = HTML_Parser.CleanTags(descr).Trim(' ');
                }

                //--------------------------------------------------------------
                // Ricerca dei campi nella tabella delle statistiche delle squadre
                //--------------------------------------------------------------
                {
                    string descr = tables[1];
                    string homeStats = "", awayStats = "";

                    List<string> fields = HTML_Parser.GetTags(descr, "tr");

                    for (int i = 1; i < fields.Count; i++)
                    {
                        List<string> items = HTML_Parser.GetTags(fields[i], "td");

                        homeStats += items[1] + ";";
                        awayStats += items[3] + ";";
                    }

                    if (matchRow.isHome)
                    {
                        matchRow.YourStats = homeStats;
                        matchRow.OppsStats = awayStats;
                    }
                    else
                    {
                        matchRow.OppsStats = homeStats;
                        matchRow.YourStats = awayStats;
                    }
                }

                //--------------------------------------------------------------
                // Ricerca dei campi nella tabella della Your Team
                //--------------------------------------------------------------
                {
                    string descr;
                    if (matchRow.isHome)
                        descr = tables[2];
                    else
                        descr = tables[3];

                    List<string> fields = HTML_Parser.GetTags(descr, "tr");

                    for (int i = 2; i < fields.Count; i++)
                    {
                        YourTeamPerfRow ppr = YourTeamPerf.NewYourTeamPerfRow();

                        List<string> tds = HTML_Parser.GetTags(fields[i], "td");
                        int plID;
                        if (int.TryParse(HTML_Parser.GetField(tds[1], "playerid=", ">"), out plID))
                        {
                            ppr.PlayerID = plID;
                            ppr.Assist = 0;
                            string name = HTML_Parser.GetTag(tds[1], "span");
                            name = name.Replace("&#39;", "'").Replace("&nbsp;", " ").Replace("\r\n", "");
                            ppr.Name = name.Replace("  ", " ");
                            if (tds[1].Contains("star.gif"))
                                this.MatchData[0].BestPlayer = ppr.PlayerID;

                            int number;
                            if (int.TryParse(tds[0].Trim('.'), out number))
                                ppr.Number = number;

                            string scored = HTML_Parser.CleanTagsWithRest(tds[1]);
                            if (scored.Contains("("))
                            {
                                ppr.Scored = int.Parse(HTML_Parser.GetField(scored, "(", ")"));
                            }
                            else
                                ppr.Scored = 0;
                        }
                        else
                        {
                            ppr.PlayerID = i;
                            ppr.Name = "Unknown Player";
                        }

                        ppr.Position = tds[2];
                        // ppr.Position = TM_Compatible.ConvertNewFP(ppr.Position);

                        short vote;
                        if (short.TryParse(tds[3], out vote))
                            ppr.Vote = vote;

                        YourTeamPerf.AddYourTeamPerfRow(ppr);
                    }
                }

                //--------------------------------------------------------------
                // Ricerca dei campi nella tabella Opps Team
                //--------------------------------------------------------------
                {
                    string descr;
                    if (matchRow.isHome)
                        descr = tables[3];
                    else
                        descr = tables[2];

                    List<string> fields = HTML_Parser.GetTags(descr, "tr");

                    for (int i = 2; i < fields.Count; i++)
                    {
                        OppsTeamPerfRow ppr = OppsTeamPerf.NewOppsTeamPerfRow();

                        List<string> tds = HTML_Parser.GetTags(fields[i], "td");
                        int plID;
                        if (int.TryParse(HTML_Parser.GetField(tds[1], "playerid=", ">"), out plID))
                        {
                            ppr.PlayerID = plID;
                            ppr.Assist = 0;
                            string name = HTML_Parser.GetTag(tds[1], "span");
                            name = name.Replace("&#39;", "'").Replace("&nbsp;", " ").Replace("\r\n", "");
                            // name = HTML_Parser.ConvertHTML(name);
                            ppr.Name = name.Replace("  ", " ");
                            if (tds[1].Contains("star.gif"))
                                this.MatchData[0].BestPlayer = ppr.PlayerID;

                            int number;
                            if (int.TryParse(tds[0].Trim('.'), out number))
                                ppr.Number = number;

                            string scored = HTML_Parser.CleanTagsWithRest(tds[1]);
                            if (scored.Contains("("))
                            {
                                ppr.Scored = int.Parse(HTML_Parser.GetField(scored, "(", ")"));
                            }
                            else
                                ppr.Scored = 0;
                        }
                        else
                        {
                            ppr.PlayerID = i;
                            ppr.Name = "Unknown Player";
                        }

                        ppr.Position = tds[2];
                        //ppr.Position = TM_Compatible.ConvertNewFP(ppr.Position);

                        short vote;
                        if (short.TryParse(tds[3], out vote))
                            ppr.Vote = vote;

                        OppsTeamPerf.AddOppsTeamPerfRow(ppr);
                    }
                }

                List<int> goalPlayers = new List<int>();
                List<int> errPlayers = new List<int>();
                //--------------------------------------------------------------
                // Ricerca dei campi nella tabella delle azioni
                //--------------------------------------------------------------
                {
                    string descr = tables[4].Replace("Â", "");

                    List<string> fields = HTML_Parser.GetTags(descr, "tr");

                    int lastTime = 0;
                    for (int i = 0; i < fields.Count; i++)
                    {
                        ActionsRow atr = Actions.NewActionsRow();

                        List<string> items = HTML_Parser.GetTags(fields[i], "td");

                        int time = 0;
                        string timeinfo = items[0].Replace(".&nbsp;", "");
                        timeinfo = timeinfo.Split('.')[0];
                        if (int.TryParse(timeinfo, out time))
                            atr.Time = time;
                        else
                            atr.Time = lastTime;
                        lastTime = atr.Time;
                        atr.ActionType = HTML_Parser.GetField(items[1], "pics/", ".gif");
                        string color = HTML_Parser.GetField(items[1], "#", ";");
                        if (color == "")
                            color = HTML_Parser.GetField(items[1], "#", "'");
                        if (color == "")
                            color = HTML_Parser.GetField(items[1], "#", "\"");
                        if (color == "")
                        {
                            color = HTML_Parser.GetField(items[1], "rgb(", ");>");
                            if (color != "")
                            {
                                string[] col = color.Split(',');
                                atr.Color = (Color.FromArgb(int.Parse(col[0]), int.Parse(col[1]), int.Parse(col[2]))).ToArgb();
                            }
                        }
                        else
                            atr.Color = int.Parse(color, System.Globalization.NumberStyles.HexNumber);

                        atr.Description = items[2].Replace("\r\n", " ").Replace("  ", " ");

                        if ((i == 0) && (atr.Description.Contains(clubNick)))
                        {
                            isFirstColorYourTeam = true;
                            firstColor = atr.Color;
                        }
                        else if (i == 0)
                        {
                            firstColor = atr.Color;
                        }

                        bool myTeamAction = false;
                        if (((atr.Color == firstColor) && isFirstColorYourTeam) ||
                            ((atr.Color != firstColor) && !isFirstColorYourTeam))
                        {
                            myTeamAction = true;
                        }

                        if ((atr.ActionType == "me_yellow") ||
                            (atr.ActionType == "me_yellow2") ||
                            (atr.ActionType == "me_red"))
                        {
                            int card_id = 0;
                            int card_type = (atr.ActionType == "me_yellow") ? 1 :
                                (atr.ActionType == "me_yellow2") ? 2 : 3;

                            if (myTeamAction)
                            {
                                List<int> ids = HTML_Parser.FindPlayersID(atr.Description);

                                foreach (int id in ids)
                                {
                                    if (matchRow.isHome)
                                    {
                                        if (tables[3].Contains(id.ToString()))
                                        {
                                            card_id = id;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (tables[4].Contains(id.ToString()))
                                        {
                                            card_id = id;
                                            break;
                                        }
                                    }
                                }
                            }

                            if (card_id != 0)
                            {
                                string str = card_id.ToString() + "|" + card_type.ToString();
                                if ((matchRow.IsCardsNull()) || (matchRow.Cards == ""))
                                {
                                    matchRow.Cards = str;
                                }
                                else
                                {
                                    matchRow.Cards += "," + str;
                                }
                            }
                        }
                        else if (atr.ActionType == "me_goal2")
                        {
                            List<int> ids = HTML_Parser.FindPlayersID(atr.Description);

                            // verifica che non ci siano duplicati nella lista degli id
                            for (int k = 0; k < ids.Count; k++)
                            {
                                for (int j = k + 1; j < ids.Count; j++)
                                {
                                    if (ids[k] == ids[j])
                                    {
                                        ids.RemoveAt(j);
                                        j = j - 1;
                                    }
                                }
                            }

                            foreach (int id in ids)
                            {
                                if (myTeamAction) // Azione della mia squadra
                                {
                                    if (YourTeamPerf.FindByPlayerID(id) != null)
                                        goalPlayers.Add(id);
                                    else
                                        errPlayers.Add(id);
                                }
                                else
                                {
                                    if (YourTeamPerf.FindByPlayerID(id) != null)
                                        errPlayers.Add(id);
                                    else
                                        goalPlayers.Add(id);
                                }
                            }
                        }

                        // atr.Description = HTML_Parser.ConvertHTML(atr.Description);
                        Actions.AddActionsRow(atr);
                    }
                }

                // Distinzione degli assistman dagli scorer
                foreach (YourTeamPerfRow ypr in YourTeamPerf)
                {
                    if (ypr.IsScoredNull()) continue;
                    for (int i = 0; i < ypr.Scored; i++)
                    {
                        goalPlayers.Remove(ypr.PlayerID);
                    }
                }
                foreach (OppsTeamPerfRow opr in OppsTeamPerf)
                {
                    if (opr.IsScoredNull()) continue;
                    for (int i = 0; i < opr.Scored; i++)
                    {
                        goalPlayers.Remove(opr.PlayerID);
                    }
                }

                // Assegna gli assist
                foreach (int gp in goalPlayers)
                {
                    YourTeamPerfRow ypr = YourTeamPerf.FindByPlayerID(gp);
                    if (ypr != null)
                    {
                        ypr.Assist += 1;
                        continue;
                    }
                    OppsTeamPerfRow opr = OppsTeamPerf.FindByPlayerID(gp);
                    if (opr != null)
                    {
                        opr.Assist += 1;
                        continue;
                    }
                }

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

        public void LoadKampFile(int matchID, string page)
        {
        }

        private float meanVote = 0.0f;
        public float MeanVote
        {
            get
            {
                if (meanVote != 0.0) return meanVote;
                float sum = 0f;
                float cnt = 0f;

                foreach (MatchDS.YourTeamPerfRow pr in YourTeamPerf)
                {
                    if (pr.IsVoteNull()) continue;
                    sum += pr.Vote;
                    cnt += 1f;
                }

                meanVote = sum / cnt;
                return meanVote;
            }
        }

        public bool Analyze_NewTM(string sourcePage, ref ChampDS.MatchRow matchRow)
        {
            int HomeID, AwayID;
            int firstColor = 0;
            bool isFirstColorYourTeam = false;
            string page = sourcePage;
            string lineup_home_str = HTML_Parser.GetTag(page, "LINEUP_HOME");
            string lineup_away_str = HTML_Parser.GetTag(page, "LINEUP_AWAY");
            string match_info_str = HTML_Parser.GetTag(page, "MATCH_INFO");
            string report = HTML_Parser.GetTag(page, "REPORT");

            if (match_info_str.Contains("forfait=yes")) return true;

            string[] att_styles = { "Bal", "Bal", "Count", "Wing", "Short", "Long", "Filt" };
            // { "Norm", "VeDef", "Def", "SlDef", "Norm", "SlOff", "Off", "VrOff"};
            string[] mentality = { "Norm", "VeDef", "Def", "SlDef", "Norm", "SlOff", "Off", "VrOff" };
            string[] focus_side = { "-", "Balanced", "Left", "Central", "Right" };

            try
            {
                List<string> home_pl = HTML_Parser.GetTags(lineup_home_str, "PL");
                List<string> away_pl = HTML_Parser.GetTags(lineup_away_str, "PL");

                this.Clear();

                this.MatchData.AddMatchDataRow(matchRow.MatchID, 0, 0, 0, 0);

                Dictionary<string, string> match_info = HTML_Parser.CreateDictionary(match_info_str.Trim(';'), ';');

                if (matchRow.isHome)
                {
                    matchRow.YourNick = match_info["home_nick"];
                    matchRow.OppsNick = match_info["away_nick"];
                }
                else
                {
                    matchRow.YourNick = match_info["away_nick"];
                    matchRow.OppsNick = match_info["home_nick"];
                }

                this.clubNick = matchRow.YourNick;

                if (match_info.ContainsKey("stadium"))
                    matchRow.Stadium = match_info["stadium"];
                else
                    matchRow.Stadium = "undefined";

                int crowd = 0;
                if (int.TryParse(match_info["attendance"], out crowd))
                    matchRow.Crowd = crowd;

                if (matchRow.isHome)
                {
                    matchRow.YourAttackingStyle = att_styles[int.Parse(match_info["home_attstyle"])];
                    matchRow.OppsAttackingStyle = att_styles[int.Parse(match_info["away_attstyle"])];
                    matchRow.YourMentality = mentality[int.Parse(match_info["home_mentality"])];
                    matchRow.OppsMentality = mentality[int.Parse(match_info["away_mentality"])];
                    matchRow.YourFocusSide = focus_side[int.Parse(match_info["home_focus_side"])];
                    matchRow.OppsFocusSide = focus_side[int.Parse(match_info["away_focus_side"])];
                }
                else
                {
                    matchRow.YourAttackingStyle = att_styles[int.Parse(match_info["away_attstyle"])];
                    matchRow.OppsAttackingStyle = att_styles[int.Parse(match_info["home_attstyle"])];
                    matchRow.YourMentality = mentality[int.Parse(match_info["away_mentality"])];
                    matchRow.OppsMentality = mentality[int.Parse(match_info["home_mentality"])];
                    matchRow.YourFocusSide = focus_side[int.Parse(match_info["away_focus_side"])];
                    matchRow.OppsFocusSide = focus_side[int.Parse(match_info["home_focus_side"])];
                }

                // Getting pitch and weather data
                if (match_info.ContainsKey("sprinklers"))
                {
                    matchRow.Pitch = match_info["sprinklers"] + ";" +
                         match_info["draining"] + ";" +
                         match_info["heating"] + ";" +
                         match_info["pitch_condition"] + ";" +
                         match_info["pitchcover"];
                    matchRow.Weather = match_info["weather"];
                }
                else
                {
                    matchRow.Pitch = "0;0;0;0;0";
                    matchRow.Weather = "undf";
                }

                HomeID = int.Parse(match_info["home_id"]);
                AwayID = int.Parse(match_info["away_id"]);

                int pl_def = 0;
                int pl_mid = 0;
                int pl_att = 0;

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

                    if (matchRow.isHome)
                    {
                        YourTeamPerfRow ppr = YourTeamPerf.NewYourTeamPerfRow();
                        ppr.PlayerID = int.Parse(team["player_id"]);
                        ppr.Assist = 0;
                        ppr.Name = team["name"];
                        if (team["no"] == "null") team["no"] = "0";
                        ppr.Number = int.Parse(team["no"]);
                        ppr.Position = team["position"];
                        ppr.Scored = 0;
                        if (team["rating"] != "0")
                            ppr.Vote = float.Parse(team["rating"], System.Globalization.NumberStyles.Any, CommGlobal.ciUs);
                        ppr.NPos = Pos.ToCode(ppr.Position);
                        ppr.Status = "";
                        if (team["mom"] == "1") this.MatchData[0].BestPlayer = ppr.PlayerID;
                        YourTeamPerf.AddYourTeamPerfRow(ppr);
                    }
                    else
                    {
                        OppsTeamPerfRow ppr = OppsTeamPerf.NewOppsTeamPerfRow();
                        ppr.PlayerID = int.Parse(team["player_id"]);
                        ppr.Assist = 0;
                        ppr.Name = team["name"];
                        if (team["no"] == "null") team["no"] = "0";
                        ppr.Number = int.Parse(team["no"]);
                        ppr.Position = team["position"];
                        ppr.Scored = 0;
                        if (team["rating"] != "0")
                            ppr.Vote = float.Parse(team["rating"], System.Globalization.NumberStyles.Any, CommGlobal.ciUs);
                        ppr.NPos = Pos.ToCode(ppr.Position);
                        ppr.Status = "";
                        if (team["mom"] == "1") this.MatchData[0].BestPlayer = ppr.PlayerID;
                        OppsTeamPerf.AddOppsTeamPerfRow(ppr);
                    }
                }

                string formation = pl_def.ToString() + "-" + pl_mid.ToString() + "-" + pl_att.ToString();
                if (matchRow.isHome)
                {
                    matchRow.YourFormation = formation;
                }
                else
                {
                    matchRow.OppsFormation = formation;
                }

                pl_att = pl_def = pl_mid = 0;

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

                    if (!matchRow.isHome)
                    {
                        YourTeamPerfRow ppr = YourTeamPerf.NewYourTeamPerfRow();
                        ppr.PlayerID = int.Parse(team["player_id"]);
                        ppr.Assist = 0;
                        ppr.Name = team["name"];
                        if (team["no"] == "null") team["no"] = "0";
                        ppr.Number = int.Parse(team["no"]);
                        ppr.Position = team["position"];
                        ppr.Scored = 0;
                        if (team["rating"] != "0")
                            ppr.Vote = float.Parse(team["rating"], System.Globalization.NumberStyles.Any, CommGlobal.ciUs);
                        ppr.NPos = Pos.ToCode(ppr.Position);
                        ppr.Status = "";
                        if (team["mom"] == "1") this.MatchData[0].BestPlayer = ppr.PlayerID;
                        YourTeamPerf.AddYourTeamPerfRow(ppr);
                    }
                    else
                    {
                        OppsTeamPerfRow ppr = OppsTeamPerf.NewOppsTeamPerfRow();
                        ppr.PlayerID = int.Parse(team["player_id"]);
                        ppr.Assist = 0;
                        ppr.Name = team["name"];
                        if (team["no"] == "null") team["no"] = "0";
                        ppr.Number = int.Parse(team["no"]);
                        ppr.Position = team["position"];
                        ppr.Scored = 0;
                        if (team["rating"] != "0")
                            ppr.Vote = float.Parse(team["rating"], System.Globalization.NumberStyles.Any, CommGlobal.ciUs);
                        ppr.NPos = Pos.ToCode(ppr.Position);
                        ppr.Status = "";
                        if (team["mom"] == "1") this.MatchData[0].BestPlayer = ppr.PlayerID;
                        OppsTeamPerf.AddOppsTeamPerfRow(ppr);
                    }
                }

                YourTeamPerf.SortByPosition();
                OppsTeamPerf.SortByPosition();

                formation = pl_def.ToString() + "-" + pl_mid.ToString() + "-" + pl_att.ToString();
                if (!matchRow.isHome)
                {
                    matchRow.YourFormation = formation;
                }
                else
                {
                    matchRow.OppsFormation = formation;
                }

                if (match_info.ContainsKey("city"))
                {
                    matchRow.InitDesciption = "In " + match_info["city"] + " at stadium " + match_info["stadium"];
                    matchRow.InitDesciption += " there is a crowd of " + match_info["attendance"];
                }
                else
                {
                    matchRow.InitDesciption = "Initial description not available";
                }

                if (!report.Contains("MIN"))
                    return true;

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

                foreach (string min in mins)
                {
                    string min_mod = min.Replace("action=(", "").Replace(")(", ";").Replace(")", "");
                    Dictionary<string, string> items = HTML_Parser.CreateDictionary(min_mod, ';');

                    if ((items["club"] == "undefined") || (items["club"] == "0") || (items["club"] == "null")) continue;
                    bool isHome = items["club"] == HomeID.ToString();
                    // if (!isHome && (items["club"] != AwayID.ToString())) continue;

                    ActionsRow atr = Actions.NewActionsRow();
                    atr.ActionCode = items["type"];
                    atr.FullDesc = min;
                    string strColor = isHome ? match_info["home_color"] : match_info["away_color"];
                    if ((strColor == "undefined") || (strColor == "")) strColor = "0000FF";
                    atr.Color = int.Parse(strColor, System.Globalization.NumberStyles.HexNumber);

                    if (!items.ContainsKey("text"))
                    {
                        continue;
                    }

                    string description = items["text"];
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

                        string name = "";
                        YourTeamPerfRow ypr = YourTeamPerf.FindByPlayerID(numPl);
                        if (ypr != null) { name = ypr.Name; }
                        OppsTeamPerfRow opr = OppsTeamPerf.FindByPlayerID(numPl);
                        if (opr != null) { name = opr.Name; }

                        description = description.Replace("[player=" + strnum + "]", name);
                    }
                    atr.Description = description;
                    atr.Time = int.Parse(items["min"]);
                    atr.ID = int.Parse(items["club"]);

                    Actions.AddActionsRow(atr);

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
                    matchRow.YourStats = home_stats;
                    matchRow.OppsStats = away_stats;
                }
                else
                {
                    matchRow.YourStats = away_stats;
                    matchRow.OppsStats = home_stats;
                }

                // Assegna i gol
                foreach (int gp in goalPlayers)
                {
                    YourTeamPerfRow ypr = YourTeamPerf.FindByPlayerID(gp);
                    if (ypr != null) { ypr.Scored += 1; continue; }
                    OppsTeamPerfRow opr = OppsTeamPerf.FindByPlayerID(gp);
                    if (opr != null) { opr.Scored += 1; continue; }
                }

                // Assegna gli assist
                foreach (int gp in asstPlayers)
                {
                    YourTeamPerfRow ypr = YourTeamPerf.FindByPlayerID(gp);
                    if (ypr != null) { ypr.Assist += 1; continue; }
                    OppsTeamPerfRow opr = OppsTeamPerf.FindByPlayerID(gp);
                    if (opr != null) { opr.Assist += 1; continue; }
                }

                // Assegna gli infortuni
                foreach (int gp in injrPlayers)
                {
                    YourTeamPerfRow ypr = YourTeamPerf.FindByPlayerID(gp);
                    if (ypr != null) { ypr.Status += "I"; continue; }
                    OppsTeamPerfRow opr = OppsTeamPerf.FindByPlayerID(gp);
                    if (opr != null) { opr.Status += "I"; continue; }
                }

                // Assegna i gialli
                foreach (int gp in yelcPlayers)
                {
                    YourTeamPerfRow ypr = YourTeamPerf.FindByPlayerID(gp);
                    if (ypr != null) { ypr.Status += "Y"; continue; }
                    OppsTeamPerfRow opr = OppsTeamPerf.FindByPlayerID(gp);
                    if (opr != null) { opr.Status += "Y"; continue; }
                }
                // Assegna i gialli
                foreach (int gp in redcPlayers)
                {
                    YourTeamPerfRow ypr = YourTeamPerf.FindByPlayerID(gp);
                    if (ypr != null) { ypr.Status += "R"; continue; }
                    OppsTeamPerfRow opr = OppsTeamPerf.FindByPlayerID(gp);
                    if (opr != null) { opr.Status += "R"; continue; }
                }

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
    }
}
