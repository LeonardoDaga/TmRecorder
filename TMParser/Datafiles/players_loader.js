function get_players()
{
	strout = "no data";

	ths = ["id", "no", "name", "age", "fp", "str", "sta", "pac", "mar", "tac", "wor", "pos", "pas", "cro", "tec", "hea", "fin", "lon", "set", "rec", "rat", "routine", "wage", "asi", "inj", "ban_points", "retire", "country", "goals", "assists", "gp", "cards", "mom", "club", "txt", "ban"];
	gk_ths = ["id", "no", "name", "age", "fp", "str", "sta", "pac", "han", "one", "ref", "ari", "jum", "com", "kic", "thr", "rec", "rat", "routine", "wage", "asi", "inj", "ban_points", "retire", "country", "goals", "assists", "gp", "cards", "mom", "club", "txt", "ban"];

	if (players_ar == null) return "Javascript error: players_ar is null";
	strout = "";

	try
	{
		strout += "A_team=" + SESSION["id"] + ";\n";
		strout += "B_team=" + SESSION["b_team"] + ";\n";
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

			var plot = players_ar[i].plot;
			
			strout += "TIs=";
			for(var k in plot)
			{
				strout += plot[k] + ","
			}

			strout += ";\n";
		}
	}
	catch (err)
	{
		strout += ";Javascript error = " + err;
	}
	return strout;
}