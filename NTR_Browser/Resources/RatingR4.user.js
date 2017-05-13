﻿function ApplyRatingR4() {


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

    var wage_rate = 19.76;

    var weightR4 = [[0.51872935, 0.29081119, 0.57222393, 0.89735816, 0.84487852, 0.50887940, 0.50887940, 0.13637928, 0.05248024, 0.09388931, 0.57549122, 0.00000000, 0.00000000, 0.0],	// DC
    [0.45240063, 0.31762087, 0.68150374, 0.77724031, 0.74690951, 0.50072196, 0.45947168, 0.17663123, 0.23886264, 0.18410349, 0.46453393, 0.00000000, 0.00000000, 0.0],	// DL/R
    [0.43789335, 0.31844356, 0.53515723, 0.63671706, 0.59109742, 0.51311701, 0.53184426, 0.32421168, 0.06318165, 0.27931537, 0.50093723, 0.19317517, 0.07490902, 0.0],	// DMC
    [0.42311032, 0.32315966, 0.62271745, 0.53932111, 0.51442838, 0.49835997, 0.47896659, 0.26434782, 0.22586124, 0.32182902, 0.45537227, 0.23961054, 0.09291562, 0.0],	// DML/R
    [0.31849880, 0.36581214, 0.50091016, 0.31726444, 0.28029020, 0.52022170, 0.55763723, 0.60199246, 0.10044356, 0.51811057, 0.38320838, 0.38594825, 0.14966211, 0.0],	// MC
    [0.35409971, 0.34443972, 0.64417234, 0.30427501, 0.27956082, 0.49925481, 0.46093655, 0.32887111, 0.38695101, 0.47884837, 0.37465446, 0.39194758, 0.15198852, 0.0],	// ML/R
    [0.32272636, 0.35024067, 0.48762872, 0.22888914, 0.19049636, 0.52620414, 0.57842512, 0.53330409, 0.07523792, 0.55942740, 0.39986691, 0.53866926, 0.20888391, 0.0],	// OMC
    [0.36311066, 0.33106245, 0.61831416, 0.19830147, 0.17415753, 0.50049575, 0.47737842, 0.28937553, 0.34729042, 0.52834210, 0.39939218, 0.55684664, 0.21593269, 0.0],	// OML/R
    [0.40622753, 0.29744114, 0.39446722, 0.09952139, 0.07503885, 0.50402399, 0.58505850, 0.36932466, 0.05210389, 0.53677990, 0.51998862, 0.83588627, 0.32413803, 0.0],	// F
    [0.37313433, 0.37313433, 0.37313433, 0.74626866, 0.52238806, 0.74626866, 0.52238806, 0.52238806, 0.37313433, 0.22388060, 0.22388060]];	// GK

    // RECb weights		Str				Sta				Pac				Mar				Tac				Wor				Pos				Pas				Cro				Tec				Hea				Fin				Lon				Set
    var weightRb = [[0.10493615, 0.05208547, 0.07934211, 0.14448971, 0.13159554, 0.06553072, 0.07778375, 0.06669303, 0.05158306, 0.02753168, 0.12055170, 0.01350989, 0.02549169, 0.03887550],	// DC
    [0.07715535, 0.04943315, 0.11627229, 0.11638685, 0.12893778, 0.07747251, 0.06370799, 0.03830611, 0.10361093, 0.06253997, 0.09128094, 0.01314110, 0.02449199, 0.03726305],	// DL/R
    [0.08219824, 0.08668831, 0.07434242, 0.09661001, 0.08894242, 0.08998026, 0.09281287, 0.08868309, 0.04753574, 0.06042619, 0.05396986, 0.05059984, 0.05660203, 0.03060871],	// DMC
    [0.06744248, 0.06641401, 0.09977251, 0.08253749, 0.09709316, 0.09241026, 0.08513703, 0.06127851, 0.10275520, 0.07985941, 0.04618960, 0.03927270, 0.05285911, 0.02697852],	// DML/R
    [0.07304213, 0.08174111, 0.07248656, 0.08482334, 0.07078726, 0.09568392, 0.09464529, 0.09580381, 0.04746231, 0.07093008, 0.04595281, 0.05955544, 0.07161249, 0.03547345],	// MC
    [0.06527363, 0.06410270, 0.09701305, 0.07406706, 0.08563595, 0.09648566, 0.08651209, 0.06357183, 0.10819222, 0.07386495, 0.03245554, 0.05430668, 0.06572005, 0.03279859],	// ML/R
    [0.07842736, 0.07744888, 0.07201150, 0.06734457, 0.05002348, 0.08350204, 0.08207655, 0.11181914, 0.03756112, 0.07486004, 0.06533972, 0.07457344, 0.09781475, 0.02719742],	// OMC
    [0.06545375, 0.06145378, 0.10503536, 0.06421508, 0.07627526, 0.09232981, 0.07763931, 0.07001035, 0.11307331, 0.07298351, 0.04248486, 0.06462713, 0.07038293, 0.02403557],	// OML/R
    [0.07738289, 0.05022488, 0.07790481, 0.01356516, 0.01038191, 0.06495444, 0.07721954, 0.07701905, 0.02680715, 0.07759692, 0.12701687, 0.15378395, 0.12808992, 0.03805251],	// F

    [0.07466384, 0.07466384, 0.07466384, 0.14932769, 0.10452938, 0.14932769, 0.10452938, 0.10344411, 0.07512610, 0.04492581, 0.04479831]];	// GK						

    // REC weights Str				   Sta				  Pac				 Mar				 Tac				 Wor				Pos				   Pas				  Cro				 Tec				Hea				   Fin				  Lon				 Set
    var weightR = [[0.653962303361921, 0.330014238020285, 0.562994547223387, 0.891800163983125, 0.871069095865164, 0.454514672470839, 0.555697278549252, 0.42777598627972, 0.338218821750765, 0.134348455965202, 0.796916786677566, 0.048831870932616, 0.116363443378865, 0.282347752982916],	//DC
    [0.565605120229193, 0.430973382039533, 0.917125432457378, 0.815702528287723, 0.99022325015212, 0.547995876625372, 0.522203232914265, 0.309928898819518, 0.837365352274204, 0.483822472259513, 0.656901420858592, 0.137582588344562, 0.163658117596413, 0.303915447383549],	//DL/R
    [0.55838825558912, 0.603683502357502, 0.563792314670998, 0.770425088563048, 0.641965853834719, 0.675495235675077, 0.683863478201805, 0.757342915150728, 0.473070797767482, 0.494107823556837, 0.397547163237438, 0.429660916538242, 0.56364174077388, 0.224791093448809],	//DMC
    [0.582074038075056, 0.420032202680124, 0.7887541874616, 0.726221389774063, 0.722972329840151, 0.737617252827595, 0.62234458453736, 0.466946909655194, 0.814382915598981, 0.561877829393632, 0.367446981999576, 0.360623408340649, 0.390057769678583, 0.249517737311268],	//DML/R
    [0.578431939417021, 0.778134685048085, 0.574726322388294, 0.71400292078636, 0.635403391007978, 0.822308254446722, 0.877857040588335, 0.864265671245476, 0.433450219618618, 0.697164252367046, 0.412568516841575, 0.586627586272733, 0.617905053049757, 0.308426814834866],	//MC
    [0.497429376361348, 0.545347364699553, 0.788280917110089, 0.578724574327427, 0.663235306043286, 0.772537143243647, 0.638706135095199, 0.538453108494387, 0.887935381275257, 0.572515970409641, 0.290549550901104, 0.476180499897665, 0.526149424898544, 0.287001645266184],	//ML/R
    [0.656437768926678, 0.617260722143117, 0.656569986958435, 0.63741054520629, 0.55148452726771, 0.922379789905246, 0.790553566121791, 0.999688557334153, 0.426203575603164, 0.778770912265944, 0.652374065121788, 0.662264393455567, 0.73120100926333, 0.274563618133769],	//OMC
    [0.483341947292063, 0.494773052635464, 0.799434804259974, 0.628789194186491, 0.633847969631333, 0.681354437033551, 0.671233869875345, 0.536121458625519, 0.849389745477645, 0.684067723274814, 0.389732973354501, 0.499972692291964, 0.577231818355874, 0.272773352088982],	//OML/R
    [0.493917051093473, 0.370423904816088, 0.532148929996192, 0.0629206658586336, 0.0904950078155216, 0.415494774080483, 0.54106107545574, 0.468181146095801, 0.158106484131194, 0.461125738338018, 0.83399612271067, 0.999828328674183, 0.827171977606305, 0.253225855459207],	//F
    //			   For  Rez    Vit  Ind  One  Ref Aer  Sar  Com    Deg    Aru
    [0.5, 0.333, 0.5, 1, 0.5, 1, 0.5, 0.5, 0.333, 0.333, 0.333]]; //GK

    //				DC		   DL/R		  DMC		  DML/R		  MC		  ML/R		  OMC		  OML/R		  F			  GK
    var recLast = [[14.866375, 15.980742, 15.8932675, 15.5835325, 17.6955092, 16.6189141, 18.1255351, 15.6304867, 13.2762119, 15],
    [18.95664, 22.895539, 23.1801296, 23.2813871, 26.8420884, 23.9940623, 27.8974544, 24.54323, 19.5088591, 22.3]];

    // L	DC	R	L	DMC	R	L	MC	R	L	OMC	R	F
    var positionsAll = [[2, 0, 2, 3, 1, 3, 4, 2, 4, 4, 3, 4, 4],	// D C
    [0, 2, 1, 1, 3, 2, 2, 4, 3, 3, 4, 4, 4],	// D L
    [1, 2, 0, 2, 3, 1, 3, 4, 2, 4, 4, 3, 4],	// D R
    [3, 1, 3, 2, 0, 2, 3, 1, 3, 4, 2, 4, 3],	// DM C
    [1, 3, 2, 0, 2, 1, 1, 3, 2, 2, 4, 3, 4],	// DM L
    [2, 3, 1, 1, 2, 0, 2, 3, 1, 3, 4, 2, 4],	// DM R
    [4, 2, 4, 3, 1, 3, 2, 0, 2, 3, 1, 3, 2],	// M C
    [2, 4, 3, 1, 3, 2, 0, 2, 1, 1, 3, 2, 4],	// M L
    [3, 4, 2, 2, 3, 1, 1, 2, 0, 2, 3, 1, 4],	// M R
    [4, 3, 4, 4, 2, 4, 3, 1, 3, 2, 0, 2, 1],	// OM C
    [3, 4, 4, 2, 4, 3, 1, 3, 2, 0, 2, 1, 3],	// OM L
    [4, 4, 3, 3, 4, 2, 2, 3, 1, 1, 2, 0, 3],	// OM R
    [4, 4, 4, 4, 3, 4, 4, 2, 4, 3, 1, 3, 0]];	// F

    var positionNames = ["D C", "D L", "D R", "DM C", "DM L", "DM R", "M C", "M L", "M R", "OM C", "OM L", "OM R", "F", "GK"];
    var positionFullNames = [
/* EN */["Defender Center", "Defender Left", "Defender Right", "Defensive Midfielder Center", "Defensive Midfielder Left", "Defensive Midfielder Right", "Midfielder Center", "Midfielder Left", "Midfielder Right", "Offensive Midfielder Center", "Offensive Midfielder Left", "Offensive Midfielder Right", "Forward", "Goalkeeper"],
/* JP */["ディフェンダー 中央", "ディフェンダー 左", "ディフェンダー 右", "守備的ミッドフィルダー 中央", "守備的ミッドフィルダー 左", "守備的ミッドフィルダー 右", "ミッドフィルダー 中央", "ミッドフィルダー 左", "ミッドフィルダー 右", "攻撃的ミッドフィルダー 中央", "攻撃的ミッドフィルダー 左", "攻撃的ミッドフィルダー 右", "フォワード", "ゴールキーパー"],
/* P  */["Obrońca środkowy", "Obrońca lewy", "Obrońca prawy", "Defensywny pomocnik środkowy", "Defensywny pomocnik lewy", "Defensywny pomocnik prawy", "Pomocnik środkowy", "Pomocnik lewy", "Pomocnik prawy", "Ofensywny pomocnik środkowy", "Ofensywny pomocnik lewy", "Ofensywny pomocnik prawy", "Napastnik", "Bramkarz"],
/* D  */["Forsvar Centralt", "Forsvar Venstre", "Forsvar Højre", "Defensiv Midtbane Centralt", "Defensiv Midtbane Venstre", "Defensiv Midtbane Højre", "Midtbane Centralt", "Midtbane Venstre", "Midtbane Højre", "Offensiv Midtbane Centralt", "Offensiv Midtbane Venstre", "Offensiv Midtbane Højre", "Angriber", "Målmand"],
/* I  */["Difensore Centrale", "Difensore Sinistro", "Difensore Destro", "Centrocampista Difensivo Centrale", "Centrocampista Difensivo Sinistro", "Centrocampista Difensivo Destro", "Centrocampista Centrale", "Centrocampista Sinistro", "Centrocampista Destro", "Centrocampista Offensivo Centrale", "Centrocampista Offensivo Sinistro", "Centrocampista Offensivo Destro", "Attaccante", "Portiere"],
/* H  */["Defensa Central", "Defensa Izquierdo", "Defensa Derecho", "Mediocampista Defensivo Central", "Mediocampista Defensivo Izquierdo", "Mediocampista Defensivo Derecho", "Mediocampista Central", "Mediocampista Izquierdo", "Mediocampista Derecho", "Mediocampista Ofensivo Central", "Mediocampista Ofensivo Izquierdo", "Mediocampista Ofensivo Derecho", "Delantero", "Portero"],
/* F  */["Défenseur Central", "Défenseur Gauche", "Défenseur Droit", "Milieu défensif Central", "Milieu défensif Gauche", "Milieu défensif Droit", "Milieu Central", "Milieu Gauche", "Milieu Droit", "Milieu offensif Central", "Milieu offensif Gauche", "Milieu offensif Droit", "Attaquant", "Gardien de but"],
/* A  */["Defender Center", "Defender Left", "Defender Right", "Defensive Midfielder Center", "Defensive Midfielder Left", "Defensive Midfielder Right", "Midfielder Center", "Midfielder Left", "Midfielder Right", "Offensive Midfielder Center", "Offensive Midfielder Left", "Offensive Midfielder Right", "Forward", "Goalkeeper"],
/* C  */["Obrambeni Sredina", "Obrambeni Lijevo", "Obrambeni Desno", "Defenzivni vezni Sredina", "Defenzivni vezni Lijevo", "Defenzivni vezni Desno", "Vezni Sredina", "Vezni Lijevo", "Vezni Desno", "Ofenzivni vezni Sredina", "Ofenzivni vezni Lijevo", "Ofenzivni vezni Desno", "Napadač", "Golman"],
/* G  */["Verteidiger Zentral", "Verteidiger Links", "Verteidiger Rechts", "Defensiver Mittelfeldspieler Zentral", "Defensiver Mittelfeldspieler Links", "Defensiver Mittelfeldspieler Rechts", "Mittelfeldspieler Zentral", "Mittelfeldspieler Links", "Mittelfeldspieler Rechts", "Offensiver Mittelfeldspieler Zentral", "Offensiver Mittelfeldspieler Links", "Offensiver Mittelfeldspieler Rechts", "Stürmer", "Torhüter"],
/* PO */["Defesa Centro", "Defesa Esquerdo", "Defesa Direito", "Médio Defensivo Centro", "Médio Defensivo Esquerdo", "Médio Defensivo Direito", "Medio Centro", "Medio Esquerdo", "Medio Direito", "Medio Ofensivo Centro", "Medio Ofensivo Esquerdo", "Medio Ofensivo Direito", "Avançado", "Guarda-Redes"],
/* R  */["Fundas Central", "Fundas Stânga", "Fundas Dreapta", "Mijlocas Defensiv Central", "Mijlocas Defensiv Stânga", "Mijlocas Defensiv Dreapta", "Mijlocas Central", "Mijlocas Stânga", "Mijlocas Dreapta", "Mijlocas Ofensiv Central", "Mijlocas Ofensiv Stânga", "Mijlocas Ofensiv Dreapta", "Atacant", "Portar"],
/* T  */["Defans Orta", "Defans Sol", "Defans Sağ", "Defansif Ortasaha Orta", "Defansif Ortasaha Sol", "Defansif Ortasaha Sağ", "Ortasaha Orta", "Ortasaha Sol", "Ortasaha Sağ", "Ofansif Ortasaha Orta", "Ofansif Ortasaha Sol", "Ofansif Ortasaha Sağ", "Forvet", "Kaleci"],
/* RU */["Defender Center", "Defender Left", "Defender Right", "Defensive Midfielder Center", "Defensive Midfielder Left", "Defensive Midfielder Right", "Midfielder Center", "Midfielder Left", "Midfielder Right", "Offensive Midfielder Center", "Offensive Midfielder Left", "Offensive Midfielder Right", "Forward", "Goalkeeper"],
/* CE */["Obránce Střední", "Obránce Levý", "Obránce Pravý", "Defenzivní Záložník Střední", "Defenzivní Záložník Levý", "Defenzivní Záložník Pravý", "Záložník Střední", "Záložník Levý", "Záložník Pravý", "Ofenzivní záložník Střední", "Ofenzivní záložník Levý", "Ofenzivní záložník Pravý", "Útočník", "Gólman"],
/* HU */["Védő , középső", "Védő , bal oldali", "Védő , jobb oldali", "Védekező Középpályás , középső", "Védekező Középpályás , bal oldali", "Védekező Középpályás , jobb oldali", "Középpályás , középső", "Középpályás , bal oldali", "Középpályás , jobb oldali", "Támadó középpályás , középső", "Támadó középpályás , bal oldali", "Támadó középpályás , jobb oldali", "Csatár", "Kapus"],
/* GE */["მცველი ცენტრალური", "მცველი მარცხენა", "მცველი მარჯვენა", "საყრდენი ნახევარმცველი ცენტრალური", "საყრდენი ნახევარმცველი მარცხენა", "საყრდენი ნახევარმცველი მარჯვენა", "ნახევარმცველი ცენტრალური", "ნახევარმცველი მარცხენა", "ნახევარმცველი მარჯვენა", "შემტევი ნახევარმცველი ცენტრალური", "შემტევი ნახევარმცველი მარცხენა", "შემტევი ნახევარმცველი მარჯვენა", "თავდამსხმელი", "მეკარე"],
/* FI */["Puolustaja Keski", "Puolustaja Vasen", "Puolustaja Oikea", "Puolustava Keskikenttä Keski", "Puolustava Keskikenttä Vasen", "Puolustava Keskikenttä Oikea", "Keskikenttä Keski", "Keskikenttä Vasen", "Keskikenttä Oikea", "Hyökkäävä Keskikenttä Keski", "Hyökkäävä Keskikenttä Vasen", "Hyökkäävä Keskikenttä Oikea", "Hyökkääjä", "Maalivahti"],
/* SV */["Försvarare Central", "Försvarare Vänster", "Försvarare Höger", "Defensiv Mittfältare Central", "Defensiv Mittfältare Vänster", "Defensiv Mittfältare Höger", "Mittfältare Central", "Mittfältare Vänster", "Mittfältare Höger", "Offensiv Mittfältare Central", "Offensiv Mittfältare Vänster", "Offensiv Mittfältare Höger", "Anfallare", "Målvakt"],
/* NO */["Forsvar Sentralt", "Forsvar Venstre", "Forsvar Høyre", "Defensiv Midtbane Sentralt", "Defensiv Midtbane Venstre", "Defensiv Midtbane Høyre", "Midtbane Sentralt", "Midtbane Venstre", "Midtbane Høyre", "Offensiv Midtbane Sentralt", "Offensiv Midtbane Venstre", "Offensiv Midtbane Høyre", "Angrep", "Keeper"],
/* SC */["Defender Centre", "Defender Left", "Defender Richt", "Defensive Midfielder Centre", "Defensive Midfielder Left", "Defensive Midfielder Richt", "Midfielder Centre", "Midfielder Left", "Midfielder Richt", "Offensive Midfielder Centre", "Offensive Midfielder Left", "Offensive Midfielder Richt", "Forward", "Goalkeeper"],
/* VL */["Verdediger Centraal", "Verdediger Links", "Verdediger Rechts", "Verdedigende Middenvelder Centraal", "Verdedigende Middenvelder Links", "Verdedigende Middenvelder Rechts", "Middenvelder Centraal", "Middenvelder Links", "Middenvelder Rechts", "Aanvallende Middenvelder Centraal", "Aanvallende Middenvelder Links", "Aanvallende Middenvelder Rechts", "Aanvaller", "Doelman"],
/* BR */["Zagueiro Central", "Zagueiro Esquerdo", "Zagueiro Direito", "Volante Central", "Volante Esquerdo", "Volante Direito", "Meio-Campista Central", "Meio-Campista Esquerdo", "Meio-Campista Direito", "Meia Ofensivo Central", "Meia Ofensivo Esquerdo", "Meia Ofensivo Direito", "Atacante", "Goleiro"],
/* GR */["Αμυντικός Κεντρικός", "Αμυντικός Αριστερός", "Αμυντικός Δεξιός", "Αμυντικός Μέσος Κεντρικός", "Αμυντικός Μέσος Αριστερός", "Αμυντικός Μέσος Δεξιός", "Μέσος Κεντρικός", "Μέσος Αριστερός", "Μέσος Δεξιός", "Επιθετικός μέσος Κεντρικός", "Επιθετικός μέσος Αριστερός", "Επιθετικός μέσος Δεξιός", "Επιθετικός", "Τερματοφύλακας"],
/* BG */["Защитник Централен", "Защитник Ляв", "Защитник Десен", "Дефанзивен Халф Централен", "Дефанзивен Халф Ляв", "Дефанзивен Халф Десен", "Халф Централен", "Халф Ляв", "Халф Десен", "Атакуващ Халф Централен", "Атакуващ Халф Ляв", "Атакуващ Халф Десен", "Нападател"],
    ];

    try {
        if (location.href.indexOf("/players/") != -1) {

            document.findPositionIndex = function (position) {
                var index = -1;
                for (var i = 0; i < positionFullNames.length; i++) {
                    for (var j = 0; j < positionFullNames[i].length; j++) {
                        if (position.indexOf(positionFullNames[i][j]) == 0) return j;
                    }
                }
                return index;
            };

            document.getSkills = function (table) {
                var skillArray = [];
                var tableData = table.getElementsByTagName("td");
                if (tableData.length > 1) {
                    for (var i = 0; i < 2; i++) {
                        for (var j = i; j < tableData.length; j += 2) {
                            if (tableData[j].innerHTML.indexOf("star.png") > 0) {
                                skillArray.push(20);
                            }
                            else if (tableData[j].innerHTML.indexOf("star_silver.png") > 0) {
                                skillArray.push(19);
                            }
                            else if (tableData[j].textContent.length != 0) {
                                skillArray.push(tableData[j].textContent);
                            }
                        }
                    }
                }
                return skillArray;
            };

            function funFix1(i) {
                i = (Math.round(i * 10) / 10).toFixed(1);
                return i;
            }

            function funFix2(i) {
                i = (Math.round(i * 100) / 100).toFixed(2);
                return i;
            }

            function funFix3(i) {
                i = (Math.round(i * 1000) / 1000).toFixed(3);
                return i;
            }

            function computeRating(table, skills) {
                var REREC = [[], [], []];
                var REREC2 = [];
                var FP = [];
                var positionCell = document.getElementsByClassName("favposition long")[0].childNodes;
                var positionArray = [];
                if (positionCell.length == 1) {
                    positionArray[0] = positionCell[0].textContent;
                } else if (positionCell.length == 2) {
                    positionArray[0] = positionCell[0].textContent + positionCell[1].textContent;
                } else if (positionCell[1].className == "split") {
                    positionArray[0] = positionCell[0].textContent + positionCell[3].textContent;
                    positionArray[1] = positionCell[2].textContent + positionCell[3].textContent;
                } else if (positionCell[3].className == "f") {
                    positionArray[0] = positionCell[0].textContent + positionCell[1].textContent;
                    positionArray[1] = positionCell[3].textContent;
                } else {
                    positionArray[0] = positionCell[0].textContent + positionCell[1].textContent;
                    positionArray[1] = positionCell[0].textContent + positionCell[3].textContent;
                }
                var gettr = document.getElementsByTagName("tr");
                var SI = new String(gettr[6].getElementsByTagName("td")[0].innerHTML).replace(/,/g, "");
                var rou = gettr[8].getElementsByTagName("td")[0].innerHTML;
                var rou2 = (3 / 100) * (100 - (100) * Math.pow(Math.E, -rou * 0.035));
                rou = Math.pow(5 / 3, Math.LOG2E * Math.log(rou * 10));
                for (var i = 0; i < positionArray.length; i++) {
                    var positionIndex = document.findPositionIndex(positionArray[i]);
                    FP[i] = positionIndex;
                    FP[i + 1] = FP[i];
                    if (positionIndex > -1) {
                        REREC2[i] = document.calculateREREC2(positionIndex, skills, SI);
                    }
                    if (i == 0) REREC = document.calculateREREC(positionIndex, skills, SI, rou2);
                }

                if (positionIndex == 13) {
                    var phySum = skills[0] * 1 + skills[1] * 1 + skills[2] * 1 + skills[7] * 1;
                    var tacSum = skills[4] * 1 + skills[6] * 1 + skills[8] * 1;
                    var tecSum = skills[3] * 1 + skills[5] * 1 + skills[9] * 1 + skills[10] * 1;
                    var weight = 48717927500;
                }
                else {
                    var phySum = skills[0] * 1 + skills[1] * 1 + skills[2] * 1 + skills[10] * 1;
                    var tacSum = skills[3] * 1 + skills[4] * 1 + skills[5] * 1 + skills[6] * 1;
                    var tecSum = skills[7] * 1 + skills[8] * 1 + skills[9] * 1 + skills[11] * 1 + skills[12] * 1 + skills[13] * 1;
                    var weight = 263533760000;
                }
                var allSum = phySum + tacSum + tecSum;
                var remainder = funFix1(Math.pow(2, Math.log(weight * SI) / Math.log(Math.pow(2, 7))) - allSum);

                var recth = document.createElement("div");
                var rectd = document.createElement("div");
                var recbth = document.createElement("div");
                var recbtd = document.createElement("div");
                var ratth = document.createElement("div");
                var rattd = document.createElement("div");
                rectd.setAttribute("style", "color: gold;");
                recbtd.setAttribute("style", "color: gold;");
                rattd.setAttribute("style", "color: gold;");

                var FP2 = [FP[0], FP[1]];
                for (i = 0; i < FP.length; i++) {
                    for (j = 0; 2 + j <= FP[i]; j += 2) FP[i]--;
                }
                var minR = [];
                if (FP[0] != FP[1]) {
                    rectd.innerHTML = REREC[0][FP[0]] + "/" + REREC[0][FP[1]];
                    recbtd.innerHTML = funFix2(REREC2[0]) + "/" + funFix2(REREC2[1]);
                    rattd.innerHTML = REREC[2][FP[0]] + "/" + REREC[2][FP[1]];
                    for (i = 1; i < 5; i++) {
                        minR[i] = funFix2(REREC[2][FP[0]] * (1 - (20 - skills[1]) * i / 200)) + "/" + funFix2(REREC[2][FP[1]] * (1 - (20 - skills[1]) * i / 200));
                    }
                    minR[0] = funFix2(REREC[2][FP[0]] * (1 - (20 - skills[1]) * 62 / 93 / 200)) + "/" + funFix2(REREC[2][FP[1]] * (1 - (20 - skills[1]) * 62 / 93 / 200));
                    var ratingR4 = rattd.innerHTML;
                    var rouEffect = funFix2(REREC[2][FP[0]] * 1 - REREC[1][FP[0]] * 1) + "/" + funFix2(REREC[2][FP[1]] * 1 - REREC[1][FP[1]] * 1);
                    var R4Pure = REREC[1][FP[0]] + "/" + REREC[1][FP[1]];
                    var ratingR2 = funFix2(REREC[1][FP[0]] * (1 + rou * 0.4 * 0.00405)) + "/" + funFix2(REREC[1][FP[1]] * (1 + rou * 0.4 * 0.00405));
                }
                else {
                    rectd.innerHTML = REREC[0][FP[0]];
                    recbtd.innerHTML = funFix2(REREC2[0]);
                    rattd.innerHTML = REREC[2][FP[0]];
                    if (skills.length == 11) var staGK = 4;
                    else var staGK = 1;
                    for (i = 1; i < 5; i++) {
                        minR[i] = funFix2(REREC[2][FP[0]] * (1 - (20 - skills[1]) * i / staGK / 200));
                    }
                    minR[0] = funFix2(REREC[2][FP[0]] * (1 - (20 - skills[1]) * 62 / 93 / staGK / 200));
                    var ratingR4 = rattd.innerHTML;
                    var rouEffect = funFix2(REREC[2][FP[0]] * 1 - REREC[1][FP[0]] * 1);
                    var R4Pure = REREC[1][FP[0]];
                    var ratingR2 = funFix2(R4Pure * (1 + rou * 0.4 * 0.00405));
                }
                recth.innerHTML = "<b style=\"color: gold;\">RERECb</b>";
                recbth.innerHTML = "<b style=\"color: gold;\">REREC</b>";
                ratth.innerHTML = "<b style=\"color: gold;\">RatingR4</b>";
                gettr[5].getElementsByTagName("th")[0].appendChild(recth);
                gettr[5].getElementsByTagName("td")[0].appendChild(rectd);
                gettr[5].getElementsByTagName("th")[0].appendChild(recbth);
                gettr[5].getElementsByTagName("td")[0].appendChild(recbtd);
                gettr[8].getElementsByTagName("th")[0].appendChild(ratth);
                gettr[8].getElementsByTagName("td")[0].appendChild(rattd);

                var playerID = location.pathname.match(/\d+/g);
                seasonTI(playerID[0], gettr, SI);

                var div_area = document.createElement('div');
                if (positionIndex != 13) {
                    var peak = [4, 4, 6];
                    var goldstar = 0;
                    for (j = 0; j < 2; j++) {
                        for (i = 0; i < 14; i++) {
                            if (j == 0 && skills[i] == 20) goldstar++;
                            if (j == 1 && skills[i] != 20) skills[i] = skills[i] * 1 + remainder / (14 - goldstar);
                        }
                    }
                    var CK = funFix2(skills[8] + skills[13] + skills[9] / 2 + rou2 * 2.5);
                    var FK = funFix2(skills[12] + skills[13] + skills[9] / 2 + rou2 * 2.5);
                    var PK = funFix2(skills[11] + skills[13] + skills[9] / 2 + rou2 * 2.5);
                    div_area.innerHTML = "<div style=\"position: absolute; z-index: 1; width: 175px; margin-top: 10px; background: #5F8D2D; padding-left: 5px; color: gold; border: 2px #333333 outset; display:inline;\"><table style=\"margin-top: 3px; margin-bottom: 6px;\"><tr><td>PhySum: </td><td>" + phySum + " (" + Math.round(phySum / peak[0] * 5) + "%)</td></tr><tr><td>TacSum: </td><td>" + tacSum + " (" + Math.round(tacSum / peak[1] * 5) + "%)</td></tr><tr><td>TecSum: </td><td>" + tecSum + " (" + Math.round(tecSum / peak[2] * 5) + "%)</td></tr><tr><td>AllSum: </td><td>" + allSum + " + " + remainder + " </td></tr><tr><td></td><td>&nbsp;</td></tr><tr><td>Corner: </td><td>" + CK + "</td></tr><tr><td>Freekick: </td><td>" + FK + "</td></tr><tr><td>Penalty: </td><td>" + PK + "</td></tr></tr><tr><td>&nbsp;</td></tr><tr><td>Rating-Pure: </td><td>" + R4Pure + "</td></tr><tr><td>RouEffect: </td><td>" + rouEffect + " </td></tr><tr><td>RatingR4: </td><td>" + ratingR4 + " </td></tr><tr><tr><td>65 min: </td><td>" + minR[1] + " </td></tr><tr><td>75 min: </td><td>" + minR[2] + " </td></tr><tr><td>85 min: </td><td>" + minR[4] + " </td></tr><tr><td>Full-time: </td><td>" + minR[0] + " </td></tr><td>RatingR2: </td><td>" + ratingR2 + " </td></tr></table></b></div>";
                }
                else {
                    var peak = [4, 3, 4];
                    div_area.innerHTML = "<div style=\"position: absolute; z-index: 1; width: 175px; margin-top: 10px; background: #5F8D2D; padding-left: 5px; color: gold; border: 2px #333333 outset; display:inline;\"><table style=\"margin-top: 3px; margin-bottom: 6px;\"><tr><td>PhySum: </td><td>" + phySum + " (" + Math.round(phySum / peak[0] * 5) + "%)</td></tr><tr><td>TacSum: </td><td>" + tacSum + " (" + Math.round(tacSum / peak[1] * 5) + "%)</td></tr><tr><td>TecSum: </td><td>" + tecSum + " (" + Math.round(tecSum / peak[2] * 5) + "%)</td></tr><tr><td>AllSum: </td><td>" + allSum + " + " + remainder + " </td></tr><tr><td></td><td>&nbsp;</td></tr><tr><td>Rating-Pure: </td><td>" + R4Pure + "</td></tr><tr><td>RouEffect: </td><td>" + rouEffect + " </td></tr><tr><td>RatingR4: </td><td>" + ratingR4 + " </td></tr><tr><td>65 min: </td><td>" + minR[1] + " </td></tr><tr><td>75 min: </td><td>" + minR[2] + " </td></tr><tr><td>85 min: </td><td>" + minR[4] + " </td></tr><tr><td>Full-time: </td><td>" + minR[0] + " </td></tr><tr><td>RatingR2: </td><td>" + ratingR2 + " </td></tr></table></b></div>";
                }
                document.getElementsByClassName("box")[0].appendChild(div_area);

                var hidden = document.getElementById("hidden_skill_table").getElementsByTagName("td");
                if (hidden[0].innerHTML != "") {
                    var x;
                    for (var i = 0; i < 4; i++) {
                        x = hidden[i].getAttribute("tooltip").match(/\d+/);
                        if (x < 10) x = " " + x;
                        hidden[i].setAttribute("style", "white-space: nowrap;");
                        hidden[i].innerHTML += " (" + x + "/20)";
                    }
                    if (positionIndex != 13) {
                        var div = document.createElement("div");
                        div.setAttribute("style", "position: absolute; z-index: 1; width: 175px; margin-top: 340px; background: #5F8D2D; padding-left: 5px; border: 2px #333333 outset; display:inline;");
                        div.innerHTML = "<p><b>RatingR4: All Positions</b></p>";
                        var table2 = document.createElement("table");
                        table2.setAttribute("border", "1");
                        table2.setAttribute("bordercolor", "YellowGreen");
                        table2.setAttribute("style", "width: 170px; margin-bottom: 7px;");
                        var tbody = document.createElement("tbody");
                        tbody.setAttribute("align", "center");
                        var adapt = hidden[3].getAttribute("tooltip").match(/\d+/);
                        var R4all = [REREC[2][1], REREC[2][0], REREC[2][1], REREC[2][3], REREC[2][2], REREC[2][3], REREC[2][5], REREC[2][4], REREC[2][5], REREC[2][7], REREC[2][6], REREC[2][7], REREC[2][8]];
                        for (var i = 0; i < 5; i++) {
                            var tr = document.createElement("tr");
                            for (var j = 0; j < 3; j++) {
                                var num = (4 - i) * 3 + j;
                                var td = document.createElement("td");
                                if (num < 12 || num == 13) {
                                    if (num == 13) num--;
                                    if (positionsAll[FP2[0]][num] > positionsAll[FP2[1]][num]) positionsAll[FP2[0]][num] = positionsAll[FP2[1]][num];
                                    td.innerHTML = funFix2(R4all[num] * (1 - (20 - adapt) * positionsAll[FP2[0]][num] / 200));
                                }
                                else td.innerHTML = "";
                                tr.appendChild(td);
                            }
                            tbody.appendChild(tr);
                        }
                        table2.appendChild(tbody);
                        div.appendChild(table2);
                        document.getElementsByClassName("box")[0].appendChild(div);
                    }
                }

                if (positionIndex != 13) {
                    var table2 = document.createElement("table");
                    var tbody = document.createElement("tbody");
                    table2.setAttribute("border", "1");
                    table2.setAttribute("bordercolor", "#6C9922");
                    table2.innerHTML = "<thead><tr><th></th><th>DC</th><th>DLR</th><th>DMC</th><th>DMLR</th><th>MC</th><th>MLR</th><th>OMC</th><th>OMLR</th><th>F</th></tr></thead>";
                    tbody.setAttribute("align", "center");
                    var tr = document.createElement("tr");

                    for (var i = 0; i < 3; i += 2) {
                        var th = document.createElement("th");
                        if (i == 0) th.innerHTML = "RECb";
                        else th.innerHTML = "R4";
                        tr.appendChild(th);

                        for (var j = 0; j < 9; j++) {
                            var td = document.createElement("td");
                            if (REREC[i][j] * 1 >= 100) REREC[i][j] = funFix1(REREC[i][j] * 1);
                            if (i == 0) REREC[i][j] = funFix2(REREC[i][j] * 1);
                            td.innerHTML = REREC[i][j];
                            tr.appendChild(td);
                        }
                        tbody.appendChild(tr);
                        table2.appendChild(tbody);

                        var tr = document.createElement("tr");
                        var th = document.createElement("th");
                        th.setAttribute("colspan", "4");
                        th.setAttribute("align", "center");
                        th.appendChild(table2);
                    }
                    tr.appendChild(th);
                    table.appendChild(tr);
                }

            }

            document.calculateREREC = function (positionIndex, skills, SI, rou) {
                if (positionIndex == 13) var weight = 48717927500;
                else var weight = 263533760000;
                var rec = [];			// RERECb
                var ratingR = [];		// RatingR4
                var ratingR4 = [];		// RatingR4 + routine
                var skillSum = 0;

                for (var i = 0; i < skills.length; i++) {
                    skillSum += parseInt(skills[i]);
                }
                for (i = 0; 2 + i <= positionIndex; i += 2) {		// TrExMaとRECのweight表のずれ修正
                    positionIndex--;
                }
                var remainder = Math.round((Math.pow(2, Math.log(weight * SI) / Math.log(Math.pow(2, 7))) - skillSum) * 10) / 10;		// RatingR4 remainder
                for (var i = 0; i < 10; i++) {
                    rec[i] = 0;
                    ratingR[i] = 0;
                }
                for (var j = 0; j < 9; j++) {		// All position
                    var remWeightREC = 0;		// REREC remainder weight sum
                    var remWeightRat = 0;		// RatingR4 remainder weight sum
                    var not20 = 0;					// 20以外のスキル数
                    if (positionIndex == 9) j = 9;	// GK

                    for (var i = 0; i < weightR[positionIndex].length; i++) {
                        rec[j] += skills[i] * weightRb[j][i];
                        ratingR[j] += skills[i] * weightR4[j][i];
                        if (skills[i] != 20) {
                            remWeightREC += weightRb[j][i];
                            remWeightRat += weightR4[j][i];
                            not20++;
                        }
                    }
                    if (remainder / not20 > 0.9 || not20 == 0) {
                        if (positionIndex == 9) not20 = 11;
                        else not20 = 14;
                        remWeightREC = 1;
                        remWeightRat = 5;
                    }

                    rec[j] = funFix3((rec[j] + remainder * remWeightREC / not20 - 2) / 3);
                    ratingR[j] += remainder * remWeightRat / not20;
                    ratingR4[j] = funFix2(ratingR[j] + rou * 5);
                    ratingR[j] = funFix2(ratingR[j]);
                    if (positionIndex == 9) j = 9;		// Loop end
                }

                var recAndRating = [rec, ratingR, ratingR4];
                return recAndRating;
            };

            document.calculateREREC2 = function (positionIndex, skills, SI) {
                if (positionIndex == 13) {
                    var skillWeightSum = Math.pow(SI, 0.143) / 0.02979;			// GK Skillsum
                    var weight = 48717927500;
                }
                else {
                    var skillWeightSum = Math.pow(SI, 1 / 6.99194) / 0.02336483;	// Other Skillsum
                    var weight = 263533760000;
                }
                var skillSum = 0;
                for (var j = 0; j < skills.length; j++) {
                    skillSum += parseInt(skills[j]);
                }
                var remainder = Math.round((Math.pow(2, Math.log(weight * SI) / Math.log(Math.pow(2, 7))) - skillSum) * 10) / 10;		// 正確な余り
                var rec = 0;
                var weightSum = 0;
                var not20 = 0;

                for (i = 0; 2 + i <= positionIndex; i += 2) {		// TrExMaとRECのweight表のずれ修正
                    positionIndex--;
                }
                skillWeightSum -= skillSum;			// REREC remainder
                for (var i = 0; i < weightR[positionIndex].length; i++) {
                    rec += skills[i] * weightR[positionIndex][i];
                    if (skills[i] != 20) {
                        weightSum += weightR[positionIndex][i];
                        not20++;
                    }
                }
                if (remainder / not20 > 0.9 || not20 == 0) {
                    weightSum = 0;
                    for (var i = 0; i < weightR[positionIndex].length; i++) weightSum += weightR[positionIndex][i];
                    if (positionIndex == 9) not20 = 11;
                    else not20 = 14;
                }
                rec += skillWeightSum * weightSum / not20;	// REREC Score
                if (positionIndex == 9) rec *= 1.27;					// GK
                rec = funFix2((rec - recLast[0][positionIndex]) / recLast[1][positionIndex]);

                return rec;
            };

            function seasonTI(playerID, gettr, SI) {
                var sith = document.createElement("div");
                var sitd = document.createElement("div");
                var sitd2 = document.createElement("div");
                var wage = new String(gettr[4].getElementsByTagName("span")[0].innerHTML).replace(/,/g, "");
                var today = new Date();
                var SS = new Date("04 17 2017 08:00:00 GMT");				// s50 start
                var training1 = new Date("04 17 2017 23:00:00 GMT");				// first training
                var day = (today.getTime() - training1.getTime()) / 1000 / 3600 / 24;
                while (day > 84 - 16 / 24) day -= 84;
                var session = Math.floor(day / 7) + 1;							// training sessions
                var ageMax = 20.1 + session / 12;							// max new player age

                var age = gettr[2].getElementsByTagName("td")[0].innerHTML;
                var yearidx = age.search(/\d\d/);
                var year = age.substr(yearidx, 2);
                age = age.slice(yearidx + 2);
                var month = age.replace(/\D+/g, "");
                age = year * 1 + month / 12;
                var check = today.getTime() - SS.getTime();
                var season = 84 * 24 * 3600 * 1000;
                var count = 0;

                while (check > season) {
                    check -= season;
                    count++;
                }

                if (document.getElementsByClassName("gk")[0] == null) var weight = 263533760000;
                else var weight = 48717927500;

                if (wage == 30000 || (playerID > 119142233 && count == 0)) {	// s50 youth player ID
                    sitd.innerHTML = "---";
                }
                else {
                    var TI1 = Math.pow(2, Math.log(weight * SI) / Math.log(Math.pow(2, 7))) - Math.pow(2, Math.log(weight * wage / (wage_rate)) / Math.log(Math.pow(2, 7)));
                    TI1 = Math.round(TI1 * 10);
                    var question = "";
                    if (session == 0) sitd.innerHTML = TI1;
                    else sitd.innerHTML = TI1 + " (" + funFix1(TI1 / session) + " x " + session + ")";
                }
                sith.setAttribute("style", "white-space: nowrap;");
                sith.innerHTML = "<b>Season TI</b>";
                gettr[6].getElementsByTagName("th")[0].appendChild(sith);
                gettr[6].getElementsByTagName("td")[0].appendChild(sitd);

                if (playerID > 118768860 && age < ageMax) {		// s50 BOT player ID
                    if (wage == 30000) sitd2.innerHTML = "---";
                    else {
                        wage_rate = 23.75;
                        var TI2 = Math.pow(2, Math.log(weight * SI) / Math.log(Math.pow(2, 7))) - Math.pow(2, Math.log(weight * wage / (wage_rate)) / Math.log(Math.pow(2, 7)));
                        sitd2.innerHTML = Math.round(TI2 * 10);
                    }
                    sith = document.createElement("div");
                    sith.setAttribute("style", "white-space: nowrap;");
                    sith.innerHTML = "<b>New player TI</b>";
                    gettr[6].getElementsByTagName("th")[0].appendChild(sith);
                    gettr[6].getElementsByTagName("td")[0].appendChild(sitd2);
                }
            }

            (function () {
                var playerTable = document.getElementsByClassName("skill_table zebra")[0];
                var skillArray = document.getSkills(playerTable);
                computeRating(playerTable, skillArray);
            })();
        }
    }
    catch (err)
    {

    }

    return "";
}