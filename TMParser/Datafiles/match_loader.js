function get_lineup()
{
	strout = "";

	try
	{
		// lineup
		lineup = match_data["lineup"];

		strout += "<LINEUP_HOME>";
		for (var i in lineup["home"])
		{
			var lineup_data = lineup["home"][i];

			strout += "\r\n<PL>";
			strout += "age=" + lineup_data["age"];
			strout += ";fp=" + lineup_data["fp"];
			strout += ";mom=" + lineup_data["mom"];
			strout += ";name=" + lineup_data["name"];
			strout += ";no=" + lineup_data["no"];
			strout += ";player_id=" + lineup_data["player_id"];
			strout += ";position=" + lineup_data["position"];
			strout += ";rating=" + lineup_data["rating"];
			strout += ";rec=" + lineup_data["rec"];
			strout += ";routine=" + lineup_data["routine"];
			strout += "</PL>";
		}

		strout += "</LINEUP_HOME>\r\n<LINEUP_AWAY>";

		for (i in lineup["away"])
		{
			var lineup_data = lineup["away"][i];

			strout += "\r\n<PL>";
			strout += "age=" + lineup_data["age"];
			strout += ";fp=" + lineup_data["fp"];
			strout += ";mom=" + lineup_data["mom"];
			strout += ";name=" + lineup_data["name"];
			strout += ";no=" + lineup_data["no"];
			strout += ";player_id=" + lineup_data["player_id"];
			strout += ";position=" + lineup_data["position"];
			strout += ";rating=" + lineup_data["rating"];
			strout += ";rec=" + lineup_data["rec"];
			strout += ";routine=" + lineup_data["routine"];
			strout += "</PL>";
		}
		strout += "</LINEUP_AWAY>";
	}
	catch (err)
	{
		strout += ";Javascript error = " + err;
	}
		
	return strout;
}

function get_match_info() 
{
    strout = "";
    
    match_id = 0;
    
    
    
    home_id = match_data["club"]["home"]["id"];
    away_id = match_data["club"]["away"]["id"];
    
    // match_data
    match_info = match_data["match_data"];
	
	strout += "<MATCH_INFO>";

	try
	{
	    if (match_info["forfeit"])	strout += ";forfait=yes";
		
		strout += ";home_id=" + home_id;
		strout += ";away_id=" + away_id;
		strout += ";home_name=" + match_data["club"]["home"]["club_name"];
		strout += ";away_name=" + match_data["club"]["away"]["club_name"];
		strout += ";home_nick=" + match_data["club"]["home"]["club_nick"];
		strout += ";away_nick=" + match_data["club"]["away"]["club_nick"];
		strout += ";home_fans=" + match_data["club"]["home"]["fanclub"];
		strout += ";away_fans=" + match_data["club"]["away"]["fanclub"];
		strout += ";home_attstyle=" + match_info["attacking_style"]["home"];
		strout += ";away_attstyle=" + match_info["attacking_style"]["away"];
		strout += ";home_mentality=" + match_info["mentality"]["home"];
		strout += ";away_mentality=" + match_info["mentality"]["away"];
		
		strout += ";home_color=" + match_data["club"]["home"]["colors"]["club_color1"];
		strout += ";away_color=" + match_data["club"]["away"]["colors"]["club_color1"];
	
		strout += ";attendance=" + match_info["attendance"];
		strout += ";captain_home=" + match_info["captain"]["home"];
		strout += ";captain_away=" + match_info["captain"]["away"];
		strout += ";possession_home=" + match_info["possession"]["home"];
		strout += ";possession_away=" + match_info["possession"]["away"];
	
		strout += ";stadium=" + match_data["club"]["home"]["stadium"];
		strout += ";capacity=" + match_info["venue"]["capacity"];
		strout += ";city=" + match_info["venue"]["city"];
		strout += ";name=" + match_info["venue"]["name"];
		strout += ";weather=" + match_info["venue"]["weather"];
		strout += ";sprinklers=" + match_info["venue"]["sprinklers"];
		strout += ";draining=" + match_info["venue"]["draining"];
		strout += ";heating=" + match_info["venue"]["heating"];
		strout += ";pitch_condition=" + match_info["venue"]["pitch_condition"];
		strout += ";pitchcover=" + match_info["venue"]["pitchcover"];
		strout += ";matchtype=" + match_info["venue"]["matchtype"];
		strout += ";kickoff=" + match_info["venue"]["kickoff"];
	}
	catch (err)
	{
		strout += ";Javascript error=" + err;
	}
	strout += "</MATCH_INFO>";
	return strout;
}

function get_report() 
{
    strout = "";

    // report
    match_info = match_data["match_data"];
    report = match_data["report"];
	
	last_min = match_info["last_min"];	
	
	strout += "<REPORT>";

	try
	{
		for (var i=0; i <= last_min; i++) 
		{
		    if(!report[i]) continue;
		    for (var j in report[i]) 
		    {
		        
	    	    strout += "<MIN>";
	
	    	    strout += "min=" + i + ";";
	    	    strout += "club=" + report[i][j]["club"] + ";";
	    	    
	    	    if (report[i][j]["type"])
	    			strout += "type=" + report[i][j]["type"] + ";";
	
	    	    strout += "action=";
	    	    // Get the relative chance info
				if (report[i][j]["chance"])
				{
		    	    for (var n in report[i][j]["chance"]["text"])
		    	    {
		    	    	var chancet = report[i][j]["chance"]["text"][n];
		    	    	var chancev = report[i][j]["chance"]["video"][n];
		    	    	strout += "(text=" + chancet + ")";
		    	    	if (chancev != null)
		    	    	{
		    	    		strout += "(video=" + chancev + ")";
		    	    	}
		    	    }
		    	}
	    	    strout += ";";
	
	    	    if (!report[i][j]["parameters"])
	    	    {
	    	    	strout += ">\r\n";
	    	    	continue;
	    	    }
	    	    
	    	    for (var m in report[i][j]["parameters"]) 
	    	    {				
					var row = report[i][j]["parameters"][m];
					
					// Shot
					if (row["shot"]) 
					{
						strout += "<shot";
					    strout += ";team=" + row["shot"]["team"];
					    strout += ";target=" + row["shot"]["target"];
					    strout += ">;";
					}
					// Goal
					if (row["goal"]) 
					{
						strout += "<goal";
						strout += ";scorer=" + row["goal"]["player"];
						if (row["goal"]["assist"])
						{
							strout += ";assist=" + row["goal"]["assist"];
						}
						else
						{
							strout += ";assist=none";
						}
					    strout += ">;";
					}
	
					// Others
					if (row["set_piece"])
					{
						strout += "<set_piece=" + row["set_piece"] + ">;";
					}
					if (row["penalty"])
					{
						strout += "<penalty=" + row["penalty"] + ">;";
					}
					if (row["yellow"])
					{
						strout += "<yellow=" + row["yellow"] + ">;";
					}
					if (row["red"])
					{
						strout += "<red=" + row["red"] + ">;";
					}
					if (row["yellow_red"])
					{
						strout += "<yellow_red=" + row["yellow_red"] + ">;";
					}
					if (row["injury"])
					{
						strout += "<injury=" + row["injury"] + ">;";
					}
					if (row["sub"])
					{
						strout += "<sub_out=" + row["sub"]["player_out"];
						strout += ",in=" + row["sub"]["player_in"] + "(newpos=" + row["sub"]["player_position"] + ")>;";
					}
					// Mentality/Style change
					if (row["mentality_change"]) 
					{
						strout += "<mentality_change_team=" + row["mentality_change"]["team"];
						if (row["mentality_change"]["mentality"])
						{
							strout += ",mentality=" + row["mentality_change"]["team"];
						}
						else if (row["mentality_change"]["style"])
						{
							strout += ",style=" + row["mentality_change"]["style"];
						}
						strout += ">;";
					}
	            }
	            
	    	    strout += "</MIN>/r/n";	    	                				
	        }
		}
	}
	catch(err)
	{
		strout += "Javascript error = " + err;
	}
	
	strout += "</REPORT>";		

	return strout;
}