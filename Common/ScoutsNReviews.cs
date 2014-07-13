using System;
using System.Collections.Generic;
namespace Common 
{    
    public partial class ScoutsNReviews 
    {
        partial class ReviewDataTable
        {
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
                    Dictionary<string, string> dict = HTML_Parser.String2Dictionary(gRow.ScoutReviews[i]);
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
