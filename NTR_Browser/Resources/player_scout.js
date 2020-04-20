function get_scout()
{
	strout = "";

	try
	{
		var scout_section = $('#player_scout_new');
	}
	catch (err)
	{
		strout += ";error = " + err;
	}
	return strout;
}