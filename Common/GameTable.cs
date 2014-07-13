using System.Collections.Generic;
namespace Common 
{
    public partial class GameTable 
    {
        public override string ToString()
        {
            string season = "";
            foreach (PerformancesRow pr in Performances)
            {
                if (!pr.IsSeasonNull()) season += "Sea=" + pr.Season.ToString();
                if (!pr.IsGPNull()) season += ";GP=" + pr.GP.ToString();
                if (!pr.IsGNull()) season += ";G=" + pr.G.ToString();
                if (!pr.IsANull()) season += ";A=" + pr.A.ToString();
                if (!pr.IsRatNull()) season += ";Rat=" + pr.Rat.ToString(CommGlobal.ciUs);
                if (!pr.IsCardsNull()) season += ";Cards=" + pr.Cards.ToString();
                if (!pr.IsMoMNull()) season += ";MoM=" + pr.MoM.ToString();
                if (!pr.IsRatDevNull()) season += ";RatDev=" + pr.RatDev.ToString(CommGlobal.ciUs);
                season += "|";
            }

            season = season.TrimEnd('|');
            return season;
        }

        public void LoadSeasonsStrings(string seasonsStr)
        {
            Performances.Clear();

            seasonsStr = seasonsStr.Replace(",", ".");
            string[] seasons = seasonsStr.Split('|');

            foreach (string season in seasons)
            {
                Dictionary<string,string> dict = HTML_Parser.String2Dictionary(season);

                PerformancesRow pr = Performances.NewPerformancesRow();

                if (dict.ContainsKey("Sea"))
                    pr.Season = int.Parse(dict["Sea"]);
                else
                    continue;
                if (dict.ContainsKey("GP")) pr.GP = int.Parse(dict["GP"]);
                if (dict.ContainsKey("G")) pr.G = int.Parse(dict["G"]);
                if (dict.ContainsKey("A")) pr.A = int.Parse(dict["A"]);
                if (dict.ContainsKey("Cards")) pr.Cards = int.Parse(dict["Cards"]);                
                if (dict.ContainsKey("MoM")) pr.MoM = int.Parse(dict["MoM"]);
                if (dict.ContainsKey("Rat")) pr.Rat = decimal.Parse(dict["Rat"], CommGlobal.ciUs);
                if (dict.ContainsKey("RatDev")) pr.RatDev = decimal.Parse(dict["RatDev"], CommGlobal.ciUs);

                int i = 0;
                for (; i < Performances.Count; i++)
                {
                    if (pr.Season > Performances[i].Season)
                        break;
                }

                if (i != Performances.Count)
                    Performances.Rows.InsertAt(pr, i);
                else
                    Performances.AddPerformancesRow(pr);
            }
        }

        internal static string UpdateGameTableString(int season, string prevTable, Db_TrophyDataSet.GiocatoriRow gr)
        {
            string seasonStr = "Sea=" + season.ToString();
            string outStr = "";
            prevTable = prevTable.Replace(",", ".");

            if (prevTable.Contains(seasonStr))
            {
                string[] seasons = prevTable.Split('|');

                for (int i = 0; i < seasons.Length; i++)
                {
                    if (seasons[i].Contains(seasonStr))
                    {
                        seasons[i] = seasonStr +
                            ";GP=" + gr.GP.ToString() +
                            ";G=" + gr.Goals.ToString() +
                            ";A=" + gr.Assist.ToString() +
                            ";Rat=" + gr.Rating.ToString() +
                            ";Cards=" + gr.Cards.ToString(CommGlobal.ciUs) +
                            ";MoM=" + gr.MoM.ToString() +
                            ";RatDev=0";
                        break;
                    }
                }

                foreach (string str in seasons)
                {
                    outStr += str + "|";
                }

                outStr.TrimEnd('|');
            }
            else
            {
                outStr = seasonStr +
                            ";GP=" + gr.GP.ToString() +
                            ";G=" + gr.Goals.ToString() +
                            ";A=" + gr.Assist.ToString() +
                            ";Rat=" + gr.Rating.ToString() +
                            ";Cards=" + gr.Cards.ToString(CommGlobal.ciUs) +
                            ";MoM=" + gr.MoM.ToString() +
                            ";RatDev=0" + "|" + prevTable;
            }



            return outStr;
        }

        internal static string UpdateGameTableString(int season, string prevTable, Db_TrophyDataSet.PortieriRow gr)
        {
            prevTable = prevTable.Replace(",", ".");
            string seasonStr = "Sea=" + season.ToString();
            string outStr = "";

            if (prevTable.Contains(seasonStr))
            {
                string[] seasons = prevTable.Split('|');

                for (int i = 0; i < seasons.Length; i++)
                {
                    if (seasons[i].Contains(seasonStr))
                    {
                        seasons[i] = seasonStr +
                            ";GP=" + gr.GP.ToString() +
                            ";G=" + gr.Goals.ToString() +
                            ";A=" + gr.Assist.ToString() +
                            ";Rat=" + gr.Rating.ToString(CommGlobal.ciUs) +
                            ";Cards=" + gr.Cards.ToString() +
                            ";MoM=" + gr.MoM.ToString() +
                            ";RatDev=0";
                        break;
                    }
                }

                foreach (string str in seasons)
                {
                    outStr += str + "|";
                }

                outStr.TrimEnd('|');
            }
            else
            {
                outStr = prevTable;
                if (outStr != "")
                    outStr += "|";
                outStr += seasonStr +
                            ";GP=" + gr.GP.ToString() +
                            ";G=" + gr.Goals.ToString() +
                            ";A=" + gr.Assist.ToString() +
                            ";Rat=" + gr.Rating.ToString(CommGlobal.ciUs) +
                            ";Cards=" + gr.Cards.ToString() +
                            ";MoM=" + gr.MoM.ToString() +
                            ";RatDev=0";
            }



            return outStr;
        }
    }
}
