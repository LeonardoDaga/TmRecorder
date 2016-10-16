function get_history() {
    strout = "no data";

    if (player_history_data == null) return "Javascript error: data doesn't exists";

    total_history = player_history_data.table.total;

    strout = "";

    for (var j in total_history) {
        var seas_history = total_history[j];

        if (seas_history.season == "transfer")
        {
            strout += "season=transfer" + seas_history.season;
            strout += ";transferamount=" + seas_history.transferamount;
        }
        else
        {
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