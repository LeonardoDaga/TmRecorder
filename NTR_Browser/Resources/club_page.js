function RatingFunction () {
    // ==UserScript==
    // @name           RatingR4 beta season 50
    // @version        1.2
    // @description    REREC(+b), Season TI, RatingR4(beta) JP/EN
    // @include			http://trophymanager.com/players/*
    // @include			https://trophymanager.com/players/*
    // @include			https://fb.trophymanager.com/players/*
    // @exclude			http://trophymanager.com/players/compare/*
    // @exclude			https://trophymanager.com/players/compare/*
    // @exclude			https://fb.trophymanager.com/players/compare/*
    // ==/UserScript==


    var player_info = {};
    var strout = "";

    var result = "Script started";

    try {
        result += "\nTry In";

        var gettr = document.getElementsByTagName("tr");
        var SI = new String(gettr[6].getElementsByTagName("td")[0].innerHTML).replace(/,/g, "");
        var rou = gettr[8].getElementsByTagName("td")[0].innerHTML;

        player_info.SI = SI;
        player_info.rou = rou;

        var wage = new String(gettr[4].getElementsByTagName("span")[0].innerHTML).replace(/,/g, "");
        var today = new Date();
        var SS = new Date("04 17 2017 08:00:00 GMT");				// s50 start
        var training1 = new Date("04 17 2017 23:00:00 GMT");				// first training
        var day = (today.getTime() - training1.getTime()) / 1000 / 3600 / 24;
        while (day > 84 - 16 / 24) day -= 84;

        var age = gettr[2].getElementsByTagName("td")[0].innerHTML;
        var yearidx = age.search(/\d\d/);
        var year = age.substr(yearidx, 2);
        age = age.slice(yearidx + 2);
        var month = age.replace(/\D+/g, "");
        age = year * 1 + month / 12;

        player_info.years = year;
        player_info.months = month;
        player_info.wage = wage;

        strout += "agey=" + player_info.years + ";\n";
        strout += "agem=" + player_info.months + ";\n";
        strout += "wage=" + player_info.wage + ";\n";
        strout += "SI=" + player_info.SI + ";\n";
        strout += "rou=" + player_info.rou + ";\n";
    }
    catch (err) {
        result += "\nError catched: " + err;
    }

    return strout + result;
}

RatingFunction();