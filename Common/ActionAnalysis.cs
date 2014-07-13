using System.Collections.Generic;
using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
namespace Common {

    partial class ActionAnalysis
    {
        partial class TranslatedActionsDataTable
        {
        }
    
        partial class ActionsDataTable
        {
        }
    
        partial class LanguageActionsDataTable
        {
        }
    
        partial class ActionParsingDataTable
        {
        }

        public ActionList Analyze(MatchDS matchDS, 
                            ref ChampDS.MatchRow matchRow)
        {
            ActionList al = new ActionList();

            //foreach (MatchDS.ActionsRow ar in matchDS.Actions)
            //{
            //    string desc = ar.Description;

            //    List<int> PlIDs = ActionAnalysis.CleanActionRow(ref desc, matchRow.YourNick, matchRow.OppsNick);
            //    if (PlIDs == null) continue;

            //    int IdDesc = desc.GetHashCode();

            //    ActionParsingRow apr = ActionParsing.FindByIDLanguageID(IdDesc, "");

            //    if (apr != null)
            //    {
            //        ar.ID = IdDesc;
            //        int ix = 0;
            //        string plActions = "";

            //        foreach (int plID in PlIDs)
            //        {
            //            switch (ix)
            //            {
            //                case 0: plActions = apr.Code1; break;
            //                case 1: plActions = apr.Code2; break;
            //                case 2: plActions = apr.Code3; break;
            //                case 3: plActions = apr.Code4; break;
            //            }

            //            al.AddAnalysis(plID, plActions);

            //            ix++;
            //        }
            //    }
            //    else
            //    {
            //        al.UntranslatedActions++;
            //    }
            //}

            //matchRow.Analyzed = ((al.TranslatedActions * 100)/(al.TranslatedActions+al.UntranslatedActions));

            return al;
        }

        public void BackupAnalysis(MatchDS matchDS, ref ChampDS.MatchRow matchRow)
        {
            ActionList al = new ActionList();

            // matchRow.YourStats
        }

        public static List<int> CleanActionRow(ref string desc, string cn1, string cn2)
        {
            List<string> lstr = HTML_Parser.GetFullTags(desc, "a");

            if (lstr.Count == 0) return null;

            List<string> P = new List<string>();
            List<int> PlIDs = new List<int>();

            foreach (string plref in lstr)
            {
                if (P.Count == 0)
                {
                    P.Add(plref);
                    string id = HTML_Parser.GetField(plref, "playerid=", ">");

                    if (id != "")
                        PlIDs.Add(int.Parse(id));
                    continue;
                }

                bool found = false;
                foreach (string p in P)
                {
                    if (p == plref)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    string newref = plref.Replace("#", "");
                    P.Add(newref);
                    string id = HTML_Parser.GetField(newref, "playerid=", ">");
                    if (id != "")
                    PlIDs.Add(int.Parse(id));
                }
            }

            for (int i = 0; i < P.Count; i++)
            {
                desc = desc.Replace(P[i], "[P" + (i + 1).ToString() + "]");
            }

            desc = desc.Replace(cn1, "[TEAM]");
            desc = desc.Replace(cn2, "[TEAM]");

            desc = HTML_Parser.ReplaceNumbOutsideTags(desc, "[", "]");

            return PlIDs;
        }

        public bool AnalyzeReport(string sourcePage)
        {
            int HomeID, AwayID;
            int firstColor = 0;
            bool isFirstColorYourTeam = false;
            string page = sourcePage;

            int matchid = int.Parse(HTML_Parser.GetNumberAfter(page, "kampid="));

            try
            {
                page = HTML_Parser.ConvertHTML(page);
                page = page.Replace("=\"", "=").Replace("\">", ">").Replace("='", "=").Replace("'>", ">");

                string title1 = HTML_Parser.GetField(page, "<div class=kampnamehome", "</div>");
                string title2 = HTML_Parser.GetField(page, "<div class=kampnameaway", "</div>");

                string homeNick = HTML_Parser.GetField(title1, "<h2 class=kamp>(", ")</h2>");
                string awayNick = HTML_Parser.GetField(title2, "<h2 class=kamp>(", ")</h2>");

                List<string> tables = HTML_Parser.GetFields(page, "<table", "</table>");

                TranslatedMatchesRow tmr = this.TranslatedMatches.FindByMatchID(matchid);
                if (tmr == null)
                {
                    tmr = this.TranslatedMatches.NewTranslatedMatchesRow();
                    tmr.MatchID = matchid;
                    TranslatedMatches.AddTranslatedMatchesRow(tmr);
                }

                //--------------------------------------------------------------
                // Ricerca dei campi nella tabella 0
                //--------------------------------------------------------------
                {
                    string descr = tables[0].Replace(".\r\n", ". ").Replace("\r\n", " ");
                    descr = descr.Replace("  ", " ").Replace("Â", "");

                    List<string> fields = HTML_Parser.GetTags(descr, "span");

                    List<string> clubsID = HTML_Parser.GetFieldsCut(descr, "klubhus.php?showclub=", ">");

                    HomeID = int.Parse(clubsID[0]);
                    AwayID = int.Parse(clubsID[1]);
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
                }

                //--------------------------------------------------------------
                // Ricerca dei campi nella tabella della Your Team
                //--------------------------------------------------------------
                List<int> homePlIds = new List<int>();
                List<int> awayPlIds = new List<int>();
                List<int> homeGkIds = new List<int>();
                List<int> awayGkIds = new List<int>();

                {
                    string descr = tables[2];

                    List<string> fields = HTML_Parser.GetTags(descr, "tr");

                    for (int i = 2; i < fields.Count; i++)
                    {
                        List<string> tds = HTML_Parser.GetTags(fields[i], "td");
                        int plID;
                        if (int.TryParse(HTML_Parser.GetField(tds[1], "playerid=", ">"), out plID))
                        {
                            homePlIds.Add(plID);
                        }

                        string Position = tds[2];

                        if ((i == 2) || (Position == "GK") || (Position == "SUB1"))
                            homeGkIds.Add(plID);
                    }
                }

                //--------------------------------------------------------------
                // Ricerca dei campi nella tabella Opps Team
                //--------------------------------------------------------------
                {
                    string descr = tables[3];

                    List<string> fields = HTML_Parser.GetTags(descr, "tr");

                    for (int i = 2; i < fields.Count; i++)
                    {
                        List<string> tds = HTML_Parser.GetTags(fields[i], "td");
                        int plID;
                        if (int.TryParse(HTML_Parser.GetField(tds[1], "playerid=", ">"), out plID))
                        {
                            awayPlIds.Add(plID);
                        }

                        string Position = tds[2];

                        if ((i == 2) || (Position == "GK") || (Position == "SUB1"))
                            awayGkIds.Add(plID);
                    }
                }

                // Find the language
                string language = HTML_Parser.GetField(page, "language=", "'");
                if (language == "it")
                {
                    tmr.Languages = "it";
                }
                else
                {
                    tmr.Languages += language;
                }

                //--------------------------------------------------------------
                // Ricerca dei campi nella tabella delle azioni
                //--------------------------------------------------------------
                {
                    string actions = tables[4].Replace("Â", "");

                    List<string> fields = HTML_Parser.GetTags(actions, "tr");

                    int homeColor = 0;
                    int awayColor = 0;

                    int homeScore = 0;
                    int awayScore = 0;

                    string strScore = "0-0";

                    int initColor = 0;
                    bool homeIsFirstColor = false;
                    string description = "";

                    int lastTime = 0;

                    for (int i = 0; i < fields.Count; i++)
                    {
                        ActionsRow atr = Actions.NewActionsRow();
                        ActionsIDsRow aidr = ActionsIDs.NewActionsIDsRow();
                        int actionColor = 0;

                        List<string> items = HTML_Parser.GetTags(fields[i], "td");

                        string min = items[0].Replace(".&nbsp;", "");

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
                                actionColor = (Color.FromArgb(int.Parse(col[0]), int.Parse(col[1]), int.Parse(col[2]))).ToArgb();
                            }
                        }
                        else
                            actionColor = int.Parse(color, System.Globalization.NumberStyles.HexNumber);

                        description = items[2].Replace("\r\n", " ").Replace("  ", " ");

                        if (i == 0)
                        {
                            if (description.Contains(homeNick))
                            {
                                initColor = actionColor;
                                homeIsFirstColor = true;
                                continue;
                            }
                            else
                            {
                                homeIsFirstColor = false;
                                initColor = actionColor;
                                continue;
                            }
                        }

                        bool homeAction = false;
                        if (((actionColor == initColor) && homeIsFirstColor) ||
                            ((actionColor != initColor) && (!homeIsFirstColor)))
                        {
                            homeAction = true;
                        }

                        // Substitution of nicks
                        if (homeAction)
                        {
                            description = description.Replace(homeNick, "[AT]");
                            description = description.Replace(awayNick, "[DT]");
                        }
                        else
                        {
                            description = description.Replace(homeNick, "[DT]");
                            description = description.Replace(awayNick, "[AT]");
                        }

                        // Substitution of the tags with the ID
                        List<string> tags = HTML_Parser.GetFullTags(description, "a");
                        List<int> idsInDesc = new List<int>();
                        foreach (string tag in tags)
                        {
                            string id = HTML_Parser.GetNumberAfter(tag, "playerid=");
                            description = description.Replace(tag, id);
                            int iid = int.Parse(id);
                            if (!idsInDesc.Contains(iid))
                                idsInDesc.Add(iid);
                        }

                        // Substitution of players
                        string homePL, awayPL;

                        List<int> attIds, defIds;

                        if (homeAction)
                        {
                            attIds = homePlIds;
                            defIds = awayPlIds;
                        }
                        else
                        {
                            attIds = awayPlIds;
                            defIds = homePlIds;
                        }

                        int pl = 0;
                        foreach (int id in idsInDesc)
                        {
                            if (attIds.Contains(id))
                            {
                                pl++;
                                if (pl == 1)
                                {
                                    description = description.Replace(id.ToString(), "[Aa]");
                                    atr.CodeA1 = "";
                                    aidr.A1 = id;
                                }
                                else
                                {
                                    description = description.Replace(id.ToString(), "[Ab]");
                                    atr.CodeA2 = "";
                                    aidr.A2 = id;
                                }
                            }
                        }
                        pl = 0;
                        foreach (int id in idsInDesc)
                        {
                            if (defIds.Contains(id))
                            {
                                pl++;
                                if (pl == 1)
                                {
                                    description = description.Replace(id.ToString(), "[Da]");
                                    atr.CodeD1 = "";
                                    aidr.D1 = id;
                                }
                                else
                                {
                                    description = description.Replace(id.ToString(), "[Db]");
                                    atr.CodeD2 = "";
                                    aidr.D2 = id;
                                }
                            }
                        }

                        // Conta i gol segnati
                        if (atr.ActionType == "me_goal2")
                        {
                            if (homeAction)
                                homeScore++;
                            else
                                awayScore++;

                            strScore = homeScore.ToString() + "-" + awayScore.ToString();
                        }

                        // Rimpiazza l'eventuale presenza di un punteggio nella stringa 
                        description = description.Replace(strScore, "[SC]");

                        // Rimpiazza l'eventuale presenza del minuto di gioco 
                        description = description.Replace(min.ToString(), "[NUM]");

                        // Rimpiazza l'eventuale presenza di altri numeri con la stessa stringa
                        string num;
                        while ((num = HTML_Parser.GetFirstNumberInString(description)) != "")
                        {
                            description = description.Replace(num, "[NUM]");
                        }

                        atr.Description = description;
                        atr.ID = description.GetHashCode();

                        if (Actions.FindByID(atr.ID) != null)
                            continue;

                        Actions.AddActionsRow(atr);

                        aidr.ID = atr.ID;
                        aidr.numAction = i;
                        aidr.MatchID = matchid;
                        ActionsIDs.AddActionsIDsRow(aidr);

                        if (language == "it")
                        {
                            LanguageActionsRow lar = LanguageActions.NewLanguageActionsRow();
                            lar.ID = atr.ID;
                            lar.EN = atr.ID;
                            lar.ES = atr.ID;
                            lar.FR = atr.ID;
                            lar.PT = atr.ID;
                            LanguageActions.AddLanguageActionsRow(lar);
                        }
                        else
                        {
                            ActionsIDsRow airf = this.ActionsIDs.FindByMatchIDnumAction(matchid, i);
                            LanguageActionsRow lar = LanguageActions.FindByID(airf.ID);

                            if (language == "en")
                            {
                                lar.EN = atr.ID;
                            }
                            else if (language == "es")
                            {
                                lar.ES = atr.ID;
                            }
                            else if (language == "fr")
                            {
                                lar.FR = atr.ID;
                            }
                            else if (language == "pt")
                            {
                                lar.PT = atr.ID;
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void ConvertMinToNum()
        {
            try
            {
                for (int i = 0; i < Actions.Count; i++)
                {
                    ActionsRow ar = Actions[i];

                    string description = ar.Description;

                    if (description.Contains("[MIN]"))
                    {
                        description = description.Replace("[MIN]", "[NUM]");
                    }

                    string num;
                    while ((num = HTML_Parser.GetFirstNumberInString(description)) != "")
                    {
                        description = description.Replace(num, "[NUM]");
                    }

                    int id = description.GetHashCode();
                    if (id != ar.ID)
                    {
                        ActionsRow adupr = Actions.FindByID(id);
                        ActionsIDsRow air = null;
                        TranslatedActionsRow tar = null;
                        LanguageActionsRow lar = null;

                        if (adupr != null)
                        {
                            air = null; // ActionsIDs.FindByID(id);
                            ActionsIDs.RemoveActionsIDsRow(air);

                            tar = TranslatedActions.FindByIDLanguageID(id, "it");
                            if (tar != null)
                            {
                                tar.ID = id;
                                TranslatedActions.RemoveTranslatedActionsRow(tar);
                            }

                            lar = LanguageActions.FindByID(id);
                            LanguageActions.RemoveLanguageActionsRow(lar);

                            Actions.RemoveActionsRow(adupr);
                        }

                        air = null; // ActionsIDs.FindByID(ar.ID);
                        air.ID = id;

                        tar = TranslatedActions.FindByIDLanguageID(ar.ID, "it");
                        if (tar != null)
                            tar.ID = id;

                        lar = LanguageActions.FindByID(ar.ID);
                        lar.ID = id;
                        lar.FR = id;
                        lar.EN = id;
                        lar.ES = id;
                        lar.PT = id;

                        ar.ID = id;
                        ar.Description = description;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
