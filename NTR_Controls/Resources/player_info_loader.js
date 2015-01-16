function get_player_info()
{
	strout = "no data";

	ths = ["id", "name", "age", "asi", "str", "sta", "pac", "mar", "tac", "wor", "pos", "pas", "cro", "tec",
			"hea", "fin", "lon", "set", "rec", "routine", "nat", "club_id", "club_name", "time", "bid"];
	gk_ths = ["id", "name", "age", "asi", "str", "sta", "pac", "han", "one", "ref", "ari", "jum", "com", "kic", "thr",
			"rec", "routine", "nat", "club_id", "club_name", "time", "bid"];

	if (transfer_info_ar == null) return strout;
	strout = "";

	try
	{
		// Get data from months
		for (i = 0; i < transfer_info_ar.length; i++)
		{
			if (transfer_info_ar[i]["fp"][0] != "gk")
			{
				for (n = 0; n < ths.length; n++)
				{
					strout += ths[n] + "=" + transfer_info_ar[i][ths[n]] + ";";
				}
				if (transfer_info_ar[i]["fp"][1] == "")
					strout += "fp=" + transfer_info_ar[i]["fp"][0] + ";";
				else
					strout += "fp=" + transfer_info_ar[i]["fp"][0] + "/" + transfer_info_ar[i]["fp"][1] + ";";
			}
			else
			{
				for (n = 0; n < gk_ths.length; n++)
				{
					strout += gk_ths[n] + "=" + transfer_info_ar[i][gk_ths[n]] + ";";
				}
				strout += "fp=gk;";
			}
			strout += "\n";
		}
	}
	catch (err)
	{
		strout += ";error = " + err;
	}
	return strout;
}