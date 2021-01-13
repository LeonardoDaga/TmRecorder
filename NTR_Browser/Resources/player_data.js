function get_player_data()
{
	strout = "";

	try
	{
		strout = "player_id=" + player_id + ";\n";
		strout += "player_fp=" + player_fp + ";\n";
		strout += "player_name=" + player_name + ";\n";
		strout += "is_users_player=" + is_users_player + ";\n";
	}
	catch (err)
	{
		strout += ";error = " + err;
	}
	return strout;
}

function get_scout_info() {
	strout = "";

	try {
		if ($('#player_scout_new')[0].children.length > 0) {
			numScout = $('#player_scout_new>table:nth-child(1)>tbody').children().length - 1;
			for (var i = 2; i < numScout + 2; i++) {

				if (i == 2)
					strout += "ScoutInfo=";
				else
					strout += "|";

				var address = '#player_scout_new>table:nth-child(1)>tbody>tr:nth-child(' + i;
				for (var j = 1; j < 9; j++) {
					switch (j) {
						case 1: strout += 'Name:'; break;
						case 2: strout += ',Sen:'; break;
						case 3: strout += ',Yth:'; break;
						case 4: strout += ',Phy:'; break;
						case 5: strout += ',Tac:'; break;
						case 6: strout += ',Tec:'; break;
						case 7: strout += ',Dev:'; break;
						case 8: strout += ',Psy:'; break;
					}

					var child_address = address + ')>td:nth-child(' + j + ')';

					strout += $(child_address).text();
				}

			}

			var scout_reviews = $('#player_scout_new > div').length - 1;
			for (var k = 2; k < scout_reviews + 3; k++) {
				if ($("#player_scout_new > div:nth-child(" + k + ")")[0] === undefined)
					continue;
				strout += "\nReview:" + $("#player_scout_new > div:nth-child(" + k + ")")[0].outerText;
			}

			strout += "\n\n";
		}
	}
	catch (err) {
		strout += ";error = " + err;
	}
	return strout;
}

function get_player_history() {
	strout = "no data";

	if (player_history_data == null) return "Javascript error: data doesn't exists";

	if (player_history_data.table === undefined)
		return strout;

	total_history = player_history_data.table.total;

	strout = "";

	for (var j in total_history) {
		var seas_history = total_history[j];

		if (seas_history.season == "transfer") {
			strout += "season=transfer" + seas_history.season;
			strout += ";transferamount=" + seas_history.transferamount;
		}
		else {
			strout += "season=" + seas_history.season;
			strout += ";assists=" + seas_history.assists;
			strout += ";cards=" + seas_history.cards;
			strout += ";conceded=" + seas_history.conceded;
			strout += ";division=" + seas_history.division;
			strout += ";group=" + seas_history.group;
			strout += ";games=" + seas_history.games;
			strout += ";goals=" + seas_history.goals;
			if (seas_history.mom)
				strout += ";mom=" + seas_history.mom;
			strout += ";productivity=" + seas_history.productivity;
			strout += ";rating=" + seas_history.rating;
			strout += ";rating_avg=" + seas_history.rating_avg;
			strout += ";row_id=" + seas_history.row_id;
		}
		strout += "\n";
	}

	return strout;
}


function get_extra_info() {
	strout = "";

	try {
		var i;

		if ($("#hidden_skill_table > tbody > tr:nth-child(1) > th:nth-child(1)")[0].attributes["tooltip"] === undefined) {
			strout = "na";
			return strout;
        }

		// Injury
		var injString = $("#hidden_skill_table > tbody > tr:nth-child(1) > th:nth-child(1)")[0].attributes["tooltip"].value;
		strout += "inj:" + injString.match(/<strong[^>]*>([^<]+)<\/strong>/)[1] + ";\n";

		var aggString = $("#hidden_skill_table > tbody > tr:nth-child(1) > th:nth-child(3)")[0].attributes["tooltip"].value;
		strout += "agg:" + aggString.match(/<strong[^>]*>([^<]+)<\/strong>/)[1] + ";\n";

		var proString = $("#hidden_skill_table > tbody > tr:nth-child(2) > th:nth-child(1)")[0].attributes["tooltip"].value;
		strout += "pro:" + proString.match(/<strong[^>]*>([^<]+)<\/strong>/)[1] + ";\n";

		var adaString = $("#hidden_skill_table > tbody > tr:nth-child(2) > th:nth-child(3)")[0].attributes["tooltip"].value;
		strout += "ada:" + adaString.match(/<strong[^>]*>([^<]+)<\/strong>/)[1] + ";\n";		
	}
	catch (err) {
		strout = ";error = " + err;
	}
	return strout;
}