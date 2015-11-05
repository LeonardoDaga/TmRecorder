function get_players_training()
{
	strout = "no data";

	try
	{
		if (arrows == null) return "Javascript error: arrows is null";
		strout = "";

		// Get data from months
		for (var i in arrows)
		{
			strout += "player=" + i + ";";
			strout += "ti=" + arrows[i].ti + ";";
			for (j = 0; j < arrows[i].raise.length; j++)
			{
				strout += j + "=" + arrows[i].raise[j] + ";";
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

get_players_training();