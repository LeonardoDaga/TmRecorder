namespace Common 
{    
    public partial class MatchAnalysis 
    {
        public void ParseDescription(ChampDS.MatchRow matchRow)
        {
            string descr = matchRow.InitDesciption;

            int[] i = new int[2];
            int n = 0;
            string[] str = new string[4];

            foreach (MatchAttackingStyleRow mar in this.MatchAttackingStyle)
            {
                if ((i[n] = descr.IndexOf(mar.IdentificationString)) == -1)
                    continue;
                str[n] = mar.Brief;
                n = n + 1;
                if (n == 2) break;

                if ((i[n] = descr.IndexOf(mar.IdentificationString, i[n-1]+1)) == -1)
                    continue;
                str[n] = mar.Brief;
                n = n + 1;
                break;
            }

            if (i[0] < i[1])
            {
                matchRow.YourAttackingStyle = str[matchRow.isHome ? 0 : 1];
                matchRow.OppsAttackingStyle = str[matchRow.isHome ? 1 : 0];
            }
            else
            {
                matchRow.YourAttackingStyle = str[matchRow.isHome ? 1 : 0];
                matchRow.OppsAttackingStyle = str[matchRow.isHome ? 0 : 1];
            }

            n = 0;

            foreach (MatchMentalityRow mmr in this.MatchMentality)
            {
                if ((i[n] = descr.IndexOf(mmr.IdentificationString)) == -1)
                    continue;
                str[n] = mmr.Brief;
                n = n + 1;
                if (n == 2) break;

                if ((i[n] = descr.IndexOf(mmr.IdentificationString, i[n - 1] + 1)) == -1)
                    continue;
                str[n] = mmr.Brief;
                n = n + 1;
                break;
            }


            if (i[0] < i[1])
            {
                matchRow.YourMentality = str[matchRow.isHome ? 0 : 1];
                matchRow.OppsMentality = str[matchRow.isHome ? 1 : 0];
            }
            else
            {
                matchRow.YourMentality = str[matchRow.isHome ? 1 : 0];
                matchRow.OppsMentality = str[matchRow.isHome ? 0 : 1];
            }
        }
    }
}
