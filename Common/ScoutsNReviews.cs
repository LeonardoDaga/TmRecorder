using System;
using System.Collections.Generic;
namespace Common 
{    
    public partial class ScoutsNReviews 
    {
        public bool isDirty { get; set; }

        partial class ReviewDataTable
        {
        }

        public void FillScoutsInfo(string content)
        {
            Dictionary<string, string> dictValues = HTML_Parser.CreateDictionary(content, ';');

            string scoutsInfo = dictValues["ScoutInfo"].Replace(":", "=");

            string[] scouts = scoutsInfo.Split('|');

            Dictionary<string, string> scoutInfo = new Dictionary<string, string>();
            foreach (string scout in scouts)
            {
                scoutInfo = HTML_Parser.CreateDictionary(scout, ',');

                ScoutsRow sr = Scouts.FindByName(scoutInfo["Name"]);
                if (sr == null)
                {
                    sr = Scouts.NewScoutsRow();
                    sr.Name = scoutInfo["Name"];

                    Scouts.AddScoutsRow(sr);
                }
                sr.Development = short.Parse(scoutInfo["Dev"]);
                sr.Physical = short.Parse(scoutInfo["Phy"]);
                sr.Psychology = short.Parse(scoutInfo["Psy"]);
                sr.Senior = short.Parse(scoutInfo["Sen"]);
                sr.Tactical = short.Parse(scoutInfo["Tac"]);
                sr.Technical = short.Parse(scoutInfo["Tec"]);
                sr.Youth = short.Parse(scoutInfo["Yth"]);
                this.isDirty = true;
            }
        }

        public void FillTables(ExtraDS.GiocatoriRow gRow, ReportParser reportParser)
        {
            for (int i = 0; i < gRow.ScoutNames.Length; i++)
            {
                DateTime dt = gRow.ScoutDates[i];
                string scout = gRow.ScoutNames[i];
                int id = gRow.PlayerID;

                ReviewRow rrow = Review.FindByPlayerIDScoutNameDate(id, scout, dt);
                if (rrow == null)
                {
                    rrow = Review.NewReviewRow();
                    rrow.PlayerID = id;
                    rrow.ScoutName = scout;
                    rrow.Date = dt;
                    Review.AddReviewRow(rrow);
                }

                try
                {
                    string scoutReview = gRow.ScoutReviews[i].Replace(":", "=");
                    scoutReview = scoutReview.Replace(";", ",");
                    Dictionary<string, string> dict = HTML_Parser.CreateDictionary(scoutReview, ',');

                    if (dict.ContainsKey("Dev")) rrow.Development = short.Parse(dict["Dev"]);
                    if (dict.ContainsKey("Tec")) rrow.Technics = short.Parse(dict["Tec"]);
                    if (dict.ContainsKey("Tac")) rrow.Tactics = short.Parse(dict["Tac"]);
                    if (dict.ContainsKey("Pro")) rrow.Professionalism = short.Parse(dict["Pro"]);
                    if (dict.ContainsKey("Lea")) rrow.Charisma = short.Parse(dict["Lea"]);
                    if (dict.ContainsKey("Agg")) rrow.Aggressivity = short.Parse(dict["Agg"]);
                    if (dict.ContainsKey("Phy")) rrow.Physique = short.Parse(dict["Phy"]);
                    if (dict.ContainsKey("Blo")) rrow.Blooming = short.Parse(dict["Blo"]);
                    if (dict.ContainsKey("BlS")) rrow.Blooming_Status = short.Parse(dict["BlS"]);
                    if (dict.ContainsKey("Age")) rrow.Age = short.Parse(dict["Age"]);
                    if (dict.ContainsKey("Spe")) rrow.Speciality = short.Parse(dict["Spe"]);
                }
                catch
                {
                    continue;
                }

                rrow.Vote = gRow.ScoutVotes[i];
            }            
        }
    }
}
