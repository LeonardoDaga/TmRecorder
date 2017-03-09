using System.Collections.Generic;
using System.Drawing;
using System;
namespace Common
{


    public partial class MatchList
    {
        public class TeamData
        {
            TeamListRow _tlr = null;

            public TeamData(TeamListRow tlr)
            {
                _tlr = tlr;
            }

            public override string ToString()
            {
                return _tlr.Name;
            }

            public int TeamID
            {
                get { return _tlr.TeamID; }
            }

            public TeamListRow tlr
            {
                get { return _tlr; }
            }
        }

        public class MatchData
        {
            MatchesListRow _mlr = null;

            public MatchData(MatchesListRow mlr)
            {
                _mlr = mlr;
            }

            public override string ToString()
            {
                return _mlr.Description;
            }

            public int MatchFkID
            {
                get { return _mlr.MatchFkID; }
            }
        }

        public bool ParseMatch(string sourcePage, ref MatchesListRow mlr)
        {
            int HomeID, AwayID;
            int firstColor = 0;
            bool isFirstColorYourTeam = false;
            string page = sourcePage;
            bool colorSetComplete = false;

            try
            {
                page = HTML_Parser.ConvertHTML(page);
                page = page.Replace("=\"", "=").Replace("\">", ">").Replace("='", "=").Replace("'>", ">");

                string score = HTML_Parser.GetFieldNC(page, "<h1 class=kamp id=score>", "</h1>");
                if (score == "")
                    score = HTML_Parser.GetFieldNC(page, "<h1 class=kamp' id=score>", "</h1>");
                score = score.Trim("\t\r\n ".ToCharArray());

                string HomeCards = "";

                string title1 = HTML_Parser.GetFieldNC(page, "<div class=kampnamehome>", "</div>");
                string title2 = HTML_Parser.GetFieldNC(page, "<div class=kampnameaway>", "</div>");

                string clubNick1 = HTML_Parser.GetFieldNC(title1, "<h2 class=kamp>(", ")</h2>");
                string clubNick2 = HTML_Parser.GetFieldNC(title2, "<h2 class=kamp>(", ")</h2>");

                List<string> tables = HTML_Parser.GetFields(page, "<table", "</table>");

                string stringVotes = (tables[3] + tables[4]);
                int matchFkID = stringVotes.GetHashCode();

                mlr.MatchFkID = matchFkID;

                // Getting colors of the squads
                {
                    string descr = tables[4];
                    List<string> fields = HTML_Parser.GetTags(descr, "tr");
                    int iFirstColor = -1;

                    for (int i = 0; i < fields.Count; i++)
                    {
                        List<string> items = HTML_Parser.GetTags(fields[i], "td");

                        string color = HTML_Parser.GetField(items[1], "#", ";");
                        int icolor = 0;
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
                                icolor = (Color.FromArgb(int.Parse(col[0]), int.Parse(col[1]), int.Parse(col[2]))).ToArgb();
                            }
                        }
                        else
                            icolor = int.Parse(color, System.Globalization.NumberStyles.HexNumber);

                        if (i == 0)
                        {
                            if (items[2].Contains(clubNick1))
                            {
                                mlr.HomeColor = icolor;
                                mlr.AwayColor = -1;
                            }
                            else
                            {
                                mlr.AwayColor = icolor;
                                mlr.HomeColor = -1;
                            }

                            iFirstColor = icolor;
                        }
                        else if (iFirstColor != icolor)
                        {
                            if (mlr.AwayColor == -1)
                            {
                                mlr.AwayColor = icolor;
                            }
                            else
                            {
                                mlr.HomeColor = icolor;
                            }
                            break;
                        }
                    }
                }

                //--------------------------------------------------------------
                // Ricerca dei campi nella tabella 0
                //--------------------------------------------------------------
                {
                    string descr = tables[0];

                    List<string> fields = HTML_Parser.GetTags(descr, "span");
                    string Stadium = fields[0];
                    int Crowd = int.Parse(fields[1]);

                    List<string> clubsID = HTML_Parser.GetFieldsCut(descr, "klubhus.php?showclub=", ">");

                    if (clubsID.Count > 0)
                    {
                        mlr.HomeID = int.Parse(clubsID[0]);
                        mlr.AwayID = int.Parse(clubsID[1]);
                    }
                    else
                    {
                        clubsID = HTML_Parser.GetFieldsCut(descr, "showcountry.php?showcountry=", ">");
                        mlr.HomeID = -clubsID[0].GetHashCode();
                        mlr.AwayID = -clubsID[1].GetHashCode();
                    }

                    mlr.YourFormation = fields[2];
                    mlr.OppsFormation = fields[3];

                    List<string> clubs = HTML_Parser.GetTags(descr, "a");
                    string Home = clubs[0].Replace("\r\n", "");
                    string Away = clubs[1].Replace("\r\n", "");

                    TeamListRow tlr = null;
                    if ((tlr = TeamList.FindByTeamID(mlr.HomeID)) == null)
                    {
                        tlr = TeamList.NewTeamListRow();
                        tlr.TeamID = mlr.HomeID;
                        tlr.Name = Home;
                        TeamList.AddTeamListRow(tlr);
                    }

                    if (!mlr.IsHomeColorNull())
                        tlr._1stColor = mlr.HomeColor;

                    if ((tlr = TeamList.FindByTeamID(mlr.AwayID)) == null)
                    {
                        tlr = TeamList.NewTeamListRow();
                        tlr.TeamID = mlr.AwayID;
                        tlr.Name = Away;
                        TeamList.AddTeamListRow(tlr);
                    }

                    if (!mlr.IsAwayColorNull())
                        tlr._2ndColor = mlr.AwayColor;

                    mlr.Minute0Descr = HTML_Parser.CleanTags(descr);
                    mlr.Description = Home + " " + score + " " + Away;
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

                        if (items.Count < 4) continue;
                        homeStats += items[1] + ";";
                        awayStats += items[3] + ";";
                    }

                    string YourStats = homeStats;
                    string OppsStats = awayStats;
                }

                //--------------------------------------------------------------
                // Ricerca dei campi nella tabella delle azioni
                //--------------------------------------------------------------
                {
                    string descr = tables[4];

                    List<string> fields = HTML_Parser.GetTags(descr, "tr");

                    int lastTime = 0;
                    for (int i = 0; i < fields.Count; i++)
                    {
                        List<string> items = HTML_Parser.GetTags(fields[i], "td");

                        int time = 0, Time;
                        string strtime = items[0].Replace(".&nbsp;", "");
                        strtime = strtime.TrimEnd(".Â ".ToCharArray());
                        if (int.TryParse(strtime, out time))
                            Time = time;
                        else
                            Time = lastTime;

                        string ActionType = HTML_Parser.GetField(items[1], "pics/", ".gif");

                        string color = HTML_Parser.GetNumberAfter(items[1], "#");
                        if (color == "")
                            color = HTML_Parser.GetField(items[1], "#", "'");

                        int actColor = 0;
                        if (color != "")
                            actColor = int.Parse(color, System.Globalization.NumberStyles.HexNumber);
                        else
                        {
                            if (color == "")
                            {
                                color = HTML_Parser.GetField(items[1], "rgb(", ")");
                            }
                            if (color != "")
                            {
                                string[] col = color.Split(',');
                                actColor = (Color.FromArgb(int.Parse(col[0]), int.Parse(col[1]), int.Parse(col[2]))).ToArgb();
                            }
                        }

                        string Description = items[2].Replace("\r\n", "");

                        if ((i == 0) && (Description.Contains(clubNick1)))
                        {
                            isFirstColorYourTeam = true;
                            firstColor = actColor;
                        }
                        else if (i == 0)
                        {
                            firstColor = actColor;
                        }

                        if ((i != 0) && (actColor != firstColor) && !colorSetComplete)
                        {
                            TeamListRow tlr = TeamList.FindByTeamID(mlr.HomeID);
                            tlr._1stColor = mlr.HomeColor;

                            tlr = TeamList.FindByTeamID(mlr.AwayID);
                            tlr._2ndColor = mlr.AwayColor;

                            colorSetComplete = true;
                        }

                        if ((ActionType == "me_yellow") ||
                            (ActionType == "me_yellow2") ||
                            (ActionType == "me_red"))
                        {
                            int home_card_id = 0;
                            int away_card_id = 0;
                            int card_type = (ActionType == "me_yellow") ? 1 :
                                (ActionType == "me_yellow2") ? 2 : 3;

                            if ((!mlr.IsHomeColorNull()) && (actColor == mlr.HomeColor))
                            {
                                List<string> tok = HTML_Parser.GetFieldsCut(Description, "<a href=showprofile.php?playerid=", ">");

                                foreach (string str in tok)
                                {
                                    int id = int.Parse(str);

                                    if (tables[3].Contains(str))
                                    {
                                        home_card_id = id;
                                        break;
                                    }
                                }
                            }

                            Description = Description.Replace("'>", ">");
                        }
                    }
                }

                //--------------------------------------------------------------
                // Ricerca dei campi nella tabella della Home Team
                //--------------------------------------------------------------
                {
                    string descr;

                    descr = tables[2];

                    List<string> fields = HTML_Parser.GetTags(descr, "tr");

                    for (int i = 2; i < fields.Count; i++)
                    {
                        TeamPerfRow tpr = this.TeamPerf.NewTeamPerfRow();

                        tpr.MatchFkID = matchFkID;
                        tpr.TeamID = mlr.HomeID;

                        List<string> tds = HTML_Parser.GetTags(fields[i], "td");
                        int plID;

                        PlayersListRow plr = null;

                        if (int.TryParse(HTML_Parser.GetNumberAfter(tds[1], "playerid="), out plID))
                        {
                            tpr.PlayerID = plID;

                            // If the player doesn't exist in the players list, create a new entry
                            plr = PlayersList.FindByTeamIDPlayerID(mlr.HomeID, tpr.PlayerID);
                            if (plr == null)
                            {
                                string Name = HTML_Parser.GetTag(tds[1], "span").Replace("&#39;", "'").Replace("&nbsp;", " ");
                                plr = PlayersList.NewPlayersListRow();
                                plr.TeamID = tpr.TeamID;
                                plr.PlayerID = tpr.PlayerID;
                                plr.Name = Name;
                                plr.Number = int.Parse(tds[0].TrimEnd('.'));
                                PlayersList.AddPlayersListRow(plr);
                            }

                            tds[1] = tds[1].Replace("rgb(", "rgb[");
                            if (tds[1].Contains("star.gif"))
                                tpr.Star = true;
                            if (tds[1].Contains("("))
                                tpr.Scored = int.Parse(HTML_Parser.GetField(tds[1], "(", ")"));
                            else
                                tpr.Scored = 0;
                        }
                        else
                        {
                            plr = PlayersList.CreateFakePlayer(mlr.HomeID);

                            plr.Name = "Unknown Player";
                            plr.Number = int.Parse(tds[0].TrimEnd('.'));

                            PlayersList.AddPlayersListRow(plr);

                            tpr.TeamID = mlr.AwayID;
                            tpr.PlayerID = plr.PlayerID;

                        }

                        tpr.Position = tds[2];

                        if (plr.IsUsedPosNull())
                            plr.UsedPos = tpr.Position;
                        else
                            plr.UsedPos += "/" + tpr.Position;

                        short vote;
                        if (short.TryParse(tds[3], out vote))
                            tpr.Vote = vote;

                        TeamPerfRow tprOld = null;
                        if ((tprOld = TeamPerf.FindByMatchFkIDTeamIDPlayerID(tpr.MatchFkID, tpr.TeamID, tpr.PlayerID)) != null)
                            TeamPerf.RemoveTeamPerfRow(tprOld);
                        TeamPerf.AddTeamPerfRow(tpr);
                    }
                }

                //--------------------------------------------------------------
                // Ricerca dei campi nella tabella Away Team
                //--------------------------------------------------------------
                {
                    string descr;

                    descr = tables[3];

                    List<string> fields = HTML_Parser.GetTags(descr, "tr");

                    for (int i = 2; i < fields.Count; i++)
                    {
                        TeamPerfRow tpr = this.TeamPerf.NewTeamPerfRow();

                        tpr.MatchFkID = matchFkID;

                        List<string> tds = HTML_Parser.GetTags(fields[i], "td");
                        int plID;

                        PlayersListRow plr = null;

                        if (int.TryParse(HTML_Parser.GetField(tds[1], "playerid=", ">"), out plID))
                        {
                            tpr.PlayerID = plID;
                            tpr.TeamID = mlr.AwayID;

                            // If the player doesn't exist in the players list, create a new entry
                            plr = PlayersList.FindByTeamIDPlayerID(mlr.AwayID, tpr.PlayerID);
                            if (plr == null)
                            {
                                string Name = HTML_Parser.GetTag(tds[1], "span").Replace("&#39;", "'").Replace("&nbsp;", " ");
                                plr = PlayersList.NewPlayersListRow();
                                plr.TeamID = tpr.TeamID;
                                plr.PlayerID = tpr.PlayerID;
                                plr.Name = Name;
                                plr.Number = int.Parse(tds[0].TrimEnd('.'));
                                PlayersList.AddPlayersListRow(plr);
                            }

                            tds[1] = tds[1].Replace("rgb(", "rgb[");
                            if (tds[1].Contains("star.gif"))
                                tpr.Star = true;
                            if (tds[1].Contains("("))
                                tpr.Scored = int.Parse(HTML_Parser.GetField(tds[1], "(", ")"));
                            else
                                tpr.Scored = 0;
                        }
                        else
                        {
                            plr = PlayersList.CreateFakePlayer(mlr.HomeID);

                            plr.Name = "Unknown Player";
                            plr.Number = int.Parse(tds[0].TrimEnd('.'));

                            PlayersList.AddPlayersListRow(plr);

                            tpr.TeamID = mlr.AwayID;
                            tpr.PlayerID = plr.PlayerID;
                        }

                        tpr.Position = tds[2];

                        if (plr.IsUsedPosNull())
                            plr.UsedPos = tpr.Position;
                        else
                            plr.UsedPos += "/" + tpr.Position;

                        short vote;
                        if (short.TryParse(tds[3], out vote))
                            tpr.Vote = vote;

                        TeamPerfRow tprOld = null;
                        if ((tprOld = TeamPerf.FindByMatchFkIDTeamIDPlayerID(tpr.MatchFkID, tpr.TeamID, tpr.PlayerID)) != null)
                            TeamPerf.RemoveTeamPerfRow(tprOld);
                        TeamPerf.AddTeamPerfRow(tpr);
                    }
                }

                //// Distribute the yellow and red cards between the players
                //// HOME
                //{
                //    string[] cards = HomeCards.Split(',');
                //    foreach (string card in cards)
                //    {
                //        if (card == "") continue;
                //        string[] items = card.Split('|');
                //        int playerID = int.Parse(items[0]);
                //        int type = int.Parse(items[1]);

                //        TeamPerfRow tpr = TeamPerf.FindByMatchFkIDTeamIDPlayerID(matchFkID, mlr.HomeID, playerID);
                //        tpr.Banned = type;
                //    }
                //}

                //// AWAY
                //{
                //    string[] cards = AwayCards.Split(',');
                //    foreach (string card in cards)
                //    {
                //        string[] items = card.Split('|');
                //        int playerID = int.Parse(items[0]);
                //        int type = int.Parse(items[1]);

                //        TeamPerfRow tpr = TeamPerf.FindByMatchFkIDTeamIDPlayerID(matchFkID, mlr.AwayID, playerID);
                //        tpr.Banned = type;
                //    }
                //}

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public partial class MatchesListRow
        {
            public bool Contains(int matchID)
            {
                return ((HomeID == matchID) || (AwayID == matchID));
            }
        }

        public partial class PlayersListRow
        {
            public int GetSkillBits()
            {
                if (IsForNull()) return 0;

                int skill = ((For > 14) ? 1 : 0) +
                        ((Vel > 14) ? 2 : 0) +
                        (((Mar + Con > 29)) ? 4 : 0) +
                        (((Wor + Pos > 29)) ? 8 : 0) +
                        (((Pas + Tec > 29)) ? 16 : 0) +
                        (((Vel + Cro + Tec > 44)) ? 32 : 0) +
                        (((Fin + Tir > 29)) ? 64 : 0) +
                        (((Tes > 14)) ? 128 : 0);

                if (IsStatusNull()) return skill;

                int stat = Status;
                skill += (((stat % 10) > 0) ? 1024 : 0) +
                    ((((stat / 10) % 10) > 0) ? 256 : 0);

                return skill;
            }

            public string GetSkillString()
            {
                if (IsForNull()) return "";

                return ((For > 14) ? "[Str]" : "") +
                    ((Vel > 14) ? "[Pac]" : "") +
                    (((Mar + Con > 29)) ? "[Def]" : "") +
                    (((Wor + Pos > 29)) ? "[Tac]" : "") +
                    (((Pas + Tec > 29)) ? "[Tec]" : "") +
                    (((Vel + Cro + Tec > 44)) ? "[Win]" : "") +
                    (((Fin + Tir > 29)) ? "[Fin]" : "") +
                    (((Tes > 14)) ? "[Tes]" : "");
            }
        }

        public partial class TeamPerfRow
        {
            // Status = Injuried + 10*Banned + 1000*StarPlayer + 10000*ScoredGoals
            public bool Star
            {
                set
                {
                    if (IsStatusNull())
                    {
                        if (!value) return;
                        Status = 0;
                    }

                    int lower = Status % 1000;
                    int upper = Status / 10000;

                    if (value == true)
                    {
                        Status = 1000 + lower + upper;
                    }
                    else
                    {
                        Status = lower + upper;
                    }
                }
                get
                {
                    if (IsStatusNull())
                        return false;
                    int star = (Status / 1000) % 10;
                    return (star > 0);
                }
            }

            // Banned = 1 : Yellow Card
            // Banned = 2 : 2 Yellow Card -> Red Card
            // Banned = 3 : Red Card
            public int Banned
            {
                set
                {
                    if (IsStatusNull())
                    {
                        if (value == 0) return;
                        Status = 0;
                    }

                    int lower = Status % 10;
                    int upper = Status / 100;

                    Status = 10 * value + lower + upper;
                }
                get
                {
                    if (IsStatusNull())
                        return 0;
                    return (Status / 10) % 10;
                }
            }

            public int Scored
            {
                set
                {
                    if (IsStatusNull())
                    {
                        if (value == 0) return;
                        Status = 0;
                    }

                    int lower = Status % 10000;
                    int upper = Status / 1000000;

                    Status = 10000 * value + lower + upper;
                }
                get
                {
                    if (IsStatusNull())
                        return 0;
                    return (Status / 10000) % 100;
                }
            }
        }

        public partial class PlayersListDataTable
        {
            internal PlayersListRow CreateFakePlayer(int teamID)
            {
                // Cerca un ID non usato, meglio usare i negativi
                PlayersListRow plr = NewPlayersListRow();
                plr.TeamID = teamID;

                System.Random rnd = new System.Random();
                plr.PlayerID = -rnd.Next();

                while (FindByTeamIDPlayerID(plr.TeamID, plr.PlayerID) != null)
                {
                    plr.PlayerID = -rnd.Next();
                }

                return plr;
            }
        }

        public void ParseAnalysis(string page)
        {
            page = page.Replace("'", "");
            page = page.Replace('"', '\'');
            page = page.Replace("'>", ">");
            page = page.Replace("='", "=");
            page = page.Replace("&#39;", "'");
            page = page.Replace("&amp;", "&");

            // Prima di tutto, identifica l'id della squadra
            string idstring = HTML_Parser.GetField(page, "analysis=tactical&showclub=", ">");
            int teamID = int.Parse(idstring);

            List<string> tables = HTML_Parser.GetFields(page, "<table", "</table>");

            List<string> rows = HTML_Parser.GetTags(tables[1], "tr");

            for (int i = 1; i < rows.Count; i++)
            {
                List<string> fields = HTML_Parser.GetTags(rows[i], "td");

                string idplayer = HTML_Parser.GetNumberAfter(fields[1], "playerid=");
                int playerID = int.Parse(idplayer);

                PlayersListRow plr = PlayersList.FindByTeamIDPlayerID(teamID, playerID);

                if (plr == null)
                {
                    plr = PlayersList.NewPlayersListRow();
                    plr.TeamID = teamID;
                    plr.PlayerID = playerID;

                    plr.Number = int.Parse(fields[0]);
                    plr.Name = HTML_Parser.GetField(fields[1], "<span>", "</span>");

                    PlayersList.AddPlayersListRow(plr);
                }

                plr.Nationality = HTML_Parser.GetField(fields[2], "flags/", ".png");
                plr.For = plr.Vel = plr.Res = plr.Mar = plr.Con = plr.Wor = plr.Pos =
                    plr.Pas = plr.Cro = plr.Tec = plr.Fin = plr.Tes = plr.Tir = 0;

                if (fields[3].Contains("gif"))
                {
                    plr.For = 15;
                }
                if (fields[4].Contains("gif"))
                {
                    plr.Vel = 15;
                }
                if (fields[5].Contains("gif"))
                {
                    plr.Con = 15;
                    plr.Mar = 15;
                }
                if (fields[6].Contains("gif"))
                {
                    plr.Wor = 15;
                    plr.Pos = 15;
                }
                if (fields[7].Contains("gif"))
                {
                    plr.Pas = 15;
                    plr.Tec = 15;
                }
                if (fields[8].Contains("gif"))
                {
                    if (plr.Vel < 15) plr.Vel = 14;
                    plr.Cro = 16;
                    plr.Tec = 15;
                }
                if (fields[9].Contains("gif"))
                {
                    plr.Fin = 16;
                    plr.Tir = 15;
                }
                if (fields[10].Contains("gif"))
                {
                    plr.Tes = 15;
                }

                plr.PG = int.Parse(fields[12]);
                plr.Gol = int.Parse(fields[13]);
                plr.Assist = int.Parse(fields[14]);
                plr.Cards = int.Parse(fields[15]);
                plr.MoM = int.Parse(fields[16]);
                plr.Val = float.Parse(fields[17], Common.CommGlobal.ciUs);

                if (fields[11].Contains("clubhouse_ban"))
                {
                    string str = HTML_Parser.CleanTags(fields[11]);
                    plr.Status = int.Parse(str);
                }
                if (fields[11].Contains("clubhouse_injury"))
                {
                    string str = HTML_Parser.CleanTags(fields[11]);
                    plr.Status = 10 * int.Parse(str);
                }

                plr.isAnalysys = true;
            }
        }
    }
}
