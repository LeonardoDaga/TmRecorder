using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class ScoutReview
    {
        public string Review;
        public int Vote;
        public string ScoutName;
        public DateTime Date;

        public static List<ScoutReview> Parse(string reviews)
        {
            int n = 0;
            List<ScoutReview> reviewList = new List<ScoutReview>();

            string[] lines = reviews.Replace("\r", "").Trim("\n".ToCharArray()).Split("\n".ToCharArray());

            while (n < lines.Length)
            {
                for (; n < lines.Length; n++)
                {
                    if (lines[n].Contains("[") || lines[n].Contains("20")) break;
                }

                ScoutReview sr = null;

                if (n == lines.Length) break;

                if (lines[n].Contains("20")) // Riga che contiene il responso del settore giovanile
                {
                    sr = new ScoutReview();
                    string[] strs = lines[n].Split('\t');
                    if (strs.Length != 2)
                    {
                        n++;
                        continue;
                    }
                    if (!DateTime.TryParse(strs[1], out sr.Date))
                    {
                        n++;
                        sr = null;
                        break;
                    }
                    sr.ScoutName = strs[0];
                    sr.Review = lines[n + 1];

                    int pos1 = sr.Review.IndexOf("(");
                    int pos2 = sr.Review.IndexOf(")");
                    sr.Vote = int.Parse(lines[n + 1].Substring(pos1 + 1, pos2 - pos1 - 1));

                    n += 2;
                }
                else // C'è l'indicazione di data
                {
                    while (true)
                    {
                        int pos = lines[n + 3].IndexOf("20");
                        if (pos == -1)
                        {
                            n++;
                            sr = null;
                            break;
                        }


                        sr = new ScoutReview();
                        if (!DateTime.TryParse(lines[n + 3].Substring(pos), out sr.Date))
                        {
                            n++;
                            sr = null;
                            break;
                        }

                        sr.ScoutName = lines[n].Trim("[]".ToCharArray());

                        sr.Review = lines[n + 4];
                        int pos1 = sr.Review.IndexOf("(");
                        int pos2 = sr.Review.IndexOf(")");

                        if (pos1 == -1)
                        {
                            sr.Vote = 1;
                        }
                        else
                        {
                            sr.Vote = int.Parse(lines[n + 4].Substring(pos1 + 1, pos2 - pos1 - 1));
                        }

                        n += 5;

                        break;
                    }
                }

                if (sr != null) reviewList.Add(sr);
            }

            return reviewList;
        }

        public static List<ScoutReview> ParseTable(string reviews)
        {
            int n = 0;
            List<ScoutReview> reviewList = new List<ScoutReview>();

            string[] lines_array = reviews.Replace("\r", "").Trim("\n".ToCharArray()).Split("\n".ToCharArray());
            List<string> lines = Common.HTML_Parser.GetTags(reviews, "tr");

            while (n < lines.Count)
            {
                for (; n < lines.Count; n++)
                {
                    if (lines[n].Contains("[") || lines[n].Contains("20")) break;
                }

                ScoutReview sr = null;

                if (n == lines.Count) break;

                string cl_str1 = lines[n].Replace("]<", "]\t<");
                string cl_str2 = cl_str1.Replace(">20", ">\t20");
                string cl_str = Common.HTML_Parser.CleanTags(cl_str2);
                if (cl_str.Contains("\t20")) // Riga che contiene il responso del settore giovanile
                {
                    sr = new ScoutReview();
                    string[] strs = cl_str.Split('\t');
                    if ((strs.Length < 2) || (strs.Length > 3))
                    {
                        n++;
                        continue;
                    }
                    if (!DateTime.TryParse(strs[strs.Length - 1], out sr.Date))
                    {
                        n++;
                        sr = null;
                        break;
                    }
                    sr.ScoutName = strs[0].Trim("[]".ToCharArray());
                    sr.Review = Common.HTML_Parser.CleanTags(lines[n + 1]).Replace("  ", " ");

                    int pos1 = sr.Review.IndexOf("(");
                    int pos2 = sr.Review.IndexOf(")");
                    if ((pos1 != -1) && (pos2 != -1))
                        sr.Vote = int.Parse(sr.Review.Substring(pos1 + 1, pos2 - pos1 - 1));
                    else
                        sr.Vote = 0;

                    n += 2;
                }

                if (sr != null) 
                    reviewList.Add(sr);
                else
                    n++;
            }

            return reviewList;
        }

        public static List<ScoutReview> FillWithGiocatoriRow(ExtraDS.GiocatoriRow gRow)
        {
            List<ScoutReview> reviewList = new List<ScoutReview>();

            if (gRow.numReview == 0) return null;
            if ((gRow.numReview == 1) && (gRow.ScoutReviews[0].Length == 0)) return null;

            string[] scouts = gRow.ScoutNames;
            DateTime[] dates = gRow.ScoutDates;
            int[] votes = gRow.ScoutVotes;
            string[] reviews = gRow.ScoutReviews;

            for (int i = 0;
                (i < scouts.Length) && (i < reviews.Length) &&
                (i < dates.Length) && (i < votes.Length);
                i++)
            {
                ScoutReview sr = new ScoutReview();
                sr.Date = dates[i];
                sr.Review = reviews[i];
                sr.ScoutName = scouts[i];
                sr.Vote = votes[i];
                reviewList.Add(sr);
            }

            return reviewList;
        }

        /*
        public static List<ScoutReview> Parse(string reviews)
        {
            int n = 0;
            List<ScoutReview> reviewList = new List<ScoutReview>();

            string[] lines = reviews.Replace("\r", "").Trim("\n".ToCharArray()).Split("\n".ToCharArray());

            while (n < lines.Length)
            {
                for (; n < lines.Length; n++)
                {
                    if (lines[n].Contains("20")) break;
                }

                ScoutReview sr = new ScoutReview();

                if (n == lines.Length) // Non c'è l'indicazione di data
                {
                    n = lines.Length - 1;

                    sr.Date = DateTime.MinValue;
                    sr.Review = lines[n];

                    n++;
                }
                else // C'è l'indicazione di data
                {
                    int pos = lines[n].IndexOf("20");

                    sr.Date = DateTime.Parse(lines[n].Substring(pos));
                    sr.ScoutName = lines[n].Substring(0, pos - 1);

                    sr.Review = lines[n + 1];
                    int pos1 = sr.Review.IndexOf("(");
                    int pos2 = sr.Review.IndexOf(")");

                    sr.Vote = int.Parse(lines[n + 1].Substring(pos1 + 1, pos2 - pos1 - 1));

                    n += 2;
                }

                reviewList.Add(sr);
            }

            return reviewList;
        }

        internal static List<ScoutReview> FillWithGiocatoriRow(ExtraDS.GiocatoriRow gRow)
        {
            List<ScoutReview> reviewList = new List<ScoutReview>();

            if (gRow.numReview == 0) return null;

            string[] scouts = gRow.ScoutNames;
            DateTime[] dates = gRow.ScoutDates;
            int[] votes = gRow.ScoutVotes;
            string[] reviews = gRow.ScoutReviews;

            for (int i = 0;
                (i < scouts.Length) && (i < reviews.Length) &&
                (i < dates.Length) && (i < votes.Length);
                i++)
            {
                ScoutReview sr = new ScoutReview();
                sr.Date = dates[i];
                sr.Review = reviews[i];
                sr.ScoutName = scouts[i];
                sr.Vote = votes[i];
                reviewList.Add(sr);
            }

            return reviewList;
        }
         * */
    }
}
