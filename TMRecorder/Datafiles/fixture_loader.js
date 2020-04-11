function get_fixture()
{
	strout = "no data";
	match_count = 0;
	
	var data = fixture_data;
	if (data == null) return "Javascript error: data doesn't exists";
	strout = "";

	try {
	    // Get data from months
	    for (var i in data) {
	        match_count++;
	        var month = data[i];

	        for (var j in month["matches"]) {
	            var match = month["matches"][j];
	            if (match) {
	                strout += "date=" + match["date"];
	                strout += ";id=" + match["id"];
	                strout += ";type=" + match["matchtype"];
	                strout += ";result=" + match["result"];
	                strout += ";home=" + match["hometeam"];
	                strout += ";away=" + match["awayteam"];
	                strout += ";home_name=" + match["hometeam_name"];
	                strout += ";away_name=" + match["awayteam_name"];
	                strout += "\n";
	            }
	        }
	    }
	}
	catch (err) {
	    strout += ";Javascript error = " + err;
	}
	return strout;
}