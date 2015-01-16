function get_training()
{
	strout = "";

	try
	{
		// lineup
		for (var i in players_list)
		{
			var player_data = players_list[i];

			strout += "id=" + player_data["id"];
			strout += ";training=" + player_data["training"];
			strout += ";\n";
		}
	}
	catch (err)
	{
		strout += ";Javascript error = " + err;
	}
		
	return strout;
}
