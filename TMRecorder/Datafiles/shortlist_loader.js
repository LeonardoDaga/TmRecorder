function get_shortlist()
{
	strout = "no data";

	ths = ["id", "name", "age", "club", "country", "fp", "str", "sta", "pac", "mar", "tac", "wor", "pos", "pas", "cro", "tec", "hea", "fin", "lon", "set", "rec", "asi", "routine", "timeleft", "curbid", "bid", "assists", "goals", "productivity", "wage", "gp", "mom"];
	gk_ths = ["id", "name", "age", "club", "country", "fp", "str", "sta", "pac", "han", "one", "ref", "ari", "jum", "com", "kic", "thr", "rec", "asi", "routine", "timeleft", "curbid", "bid", "wage", "gp", "mom"];

	if (players_ar == null) return "Javascript error: players_ar is null";
	strout = "";

	try
	{
		// Get data from months
		for (i = 0; i < players_ar.length; i++)
		{
			if (players_ar[i]["fp"] != "GK")
			{
				for (n = 0; n < ths.length; n++)
				{
					strout += ths[n] + "=" + players_ar[i][ths[n]] + ";";
				}
			}
			else
			{
				for (n = 0; n < gk_ths.length; n++)
				{
					strout += gk_ths[n] + "=" + players_ar[i][gk_ths[n]] + ";";
				}
			}
			strout += "\n";
		}
	}
	catch (err)
	{
		strout += ";Javascript error = " + err;
	}
	return strout;
}