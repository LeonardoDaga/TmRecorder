// ==UserScript==
// @name           TransferList TI_Skills_Decimals
// @include         http://trophymanager.com/*
// @include        http://trophymanager.com/players/*
// @include        http://test.trophymanager.com/*

// @version  xx
// @description  xx

// @namespace https://greasyfork.org/users/7445
// ==/UserScript==


// @version        2.2.3

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Customize Section: Customize TrophyBuddy to suit your personal preferences																		///
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//																														///
var myclubid = " ";		// if myclubid = "", some functions won't work. Add your team-id like this: var myclubid = "22882" to unlock those additional features			///
var menubar = "yes";		// switch yes/no to turn the menubar on/off																///
var sidebar = "no";		// switch yes/no to turn the sidebar on/off																///
var PlayerDataPlus = "yes";	// switch yes/no to turn the PlayerDataPlus on/off															///
var PlayerDataPlusPosition = "topleft"; // you can choose between "topleft" and "bottomleft"	and "inside"											///
var hovermenu = "yes";	// switch to "yes" to bring back the old hover menu style from TM1.1	(adapted from TM Auxiliary and slightly modified)					///			
var alt_training = "no";	// switch to "yes" to show an alternate version of the training overview (adapted from TM Auxiliary and slightly modified)				///
var old_skills = "no";		// switch to "yes" to to bring back the old look of the skills on the player page (adapted from TM Auxiliary and slightly modified)			///
var bronze_stars = "yes";	// switch to "no" to to add bronze stars for skill values 18 for coaches and scouts										///
var oldpos = "no";			// switch to "yes" to to bring back the old look of player positions														///
//																														///
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

var language = "pl";     // choose your language, check supported languages below:

var rou_factor = 0.00405;

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//												SUPPORTED LANGUAGES														///
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//																														///
//The following languages are supported right now: 																						///
//																														///
//	ar = Arabic																												///
//	da = Danish																												///																																					///
//	de = German																											///
//	en = English																												///
//	fr = French																												///
//	he = Hebrew																											///
//	hu = Hungarian																											///
//	pl = Polish																												///
//	ro = Romanian																											///
//	sl = Slovakian																											///
//																														///
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

YourRecentPosts = "Moje ostatnie posty";
GoYourRecentPosts = "Moje ostatnie posty";

switch (language) {

//ARABIC
 case "ar":
		var Home = "?????? ????????";
		var CheckYourMails = "???????";
		var League = "??????";
		var Cup = "?????";
		var Exit = "????? ????";
			
		var GoCurrentBids = "???? ?????? ???????";
		var GoTactics = "??????";
		var GoYouthAcademy = "???? ??? ???????? ??????";
		var GoHireCoaches = "????? ?? ?????? ???";
		var GoHireScouts = "????? ?? ?????? ???";
		var GoMyCoaches = "???? ??? ????? ????? ?????? ????????";
		var GoMyScouts = "???? ??? ????? ????? ?????? ????????";
		var GoScoutReports = "???? ?? ??? ?????? ???????";
		var GoPlayerNotes = "???? ??????? ????????";
		var GoTrainingOverview = "???? ????? ???????";
		var GoTrainingTeams = "?????? ???????? ?????????";
		var GoForum = "???? ?????????";
		var GoTMUserGuide = "???? ???? ????????";
		var GoTBConference = "????? ????? ????";
		
		var GoTransferForum = "???? ??? ????? ??????????";
		var GoGeneralForum = "???? ??? ??????? ???????";
		var GoAnnouncementForum = "???? ??? ????? ???????";
		//var GoFederations = "?????????";
		
	var Team = "??????";	
		var CurrentBids = "?????? ???????";
		var Squad = "????????";
		var Tactics = "?????";
		var YouthAcademy = "??????????";
	var Staff = "????????";
		var HireCoaches = "????? ?? ????";
		var HireScouts = "????";
		var ScoutReports = "?????? ???????";
		var MyCoaches = "????????";
		var MyScouts = "???????";
	var Training = "???????";	
		var PlayerNotes = "?????????";
		var TrainingOverview = "???????? ?????????";
		var TrainingTeams = "??????? ?????????";
	var Community = "???????";
		var Forum = "???????";
		var TMUserGuide = "???? ????????";
		var TBConference = "????? ????? ????";
	break;

	
//DANISH
case "da":
		var Home = "Hjemme";
		var CheckYourMails = "Læs Dine Beskeder";
		var League = "Liga";
		var Cup = "Pokal";
		var Exit = "Forlad TrophyManager";

		var GoCurrentBids = "Se Bud";
		var GoTactics = "Gå til Taktik";
		var GoYouthAcademy = "Gå til Ungdomsakademi";
		var GoHireCoaches = "Hyr nye Trænere";
		var GoHireScouts = "Hyr nye Scouts";
		var GoMyCoaches = "Se dine trænere";
		var GoMyScouts = "Se dine scouts";
		var GoScoutReports = "Se scoutrapporter";
		var GoPlayerNotes = "Se spiller noter";
		var GoTrainingOverview = "Se træningsresultat";
		var GoTrainingTeams = "Ændre træningshold";
		var GoForum = "Gå til forummet";
		var GoTMUserGuide = "Læs brugermanualen";
		var GoTBConference = "Gå til TrophyBuddy-Konferencen";

		var GoTransferForum = "Gå til Transfer forummet";
		var GoGeneralForum = "Gå til Generalt forummet";
		var GoAnnouncementForum = "Gå til Announcement";
		//var GoFederations = "Gå til Konferencer";

	var Team = "Hold";
		var CurrentBids = "Nuværende Bud";
		var Squad = "Trup";
		var Tactics = "Taktik";
		var YouthAcademy = "Ungdomsakadami";
	var Staff = "Staff";
		var HireCoaches = "Hyr Trænere";
		var HireScouts = "Hyr Trænere";
		var ScoutReports = "Scout Rapporter";
		var MyCoaches = "Mine Trænere";
		var MyScouts = "Mine Scouts";
	var Training = "Træning";
		var PlayerNotes = "Spiller Noter";
		var TrainingOverview = "Trænings Overblik";
		var TrainingTeams = "Trænings Hold";
	var Community = "Community-Links";
		var Forum = "Forum";
		var TMUserGuide = "TM-Brugermanual";
		var TBConference = "TrophyBuddy-Konference";
	break;
	
	
//GERMAN	
case "de":
	var Home = "Startseite";
	var CheckYourMails = "Zum Postfach wechseln";
	var League = "Liga";
	var Cup = "Pokal";
	var Exit = "Ausloggen";
				
		var GoCurrentBids = "Laufende Transfergebote anschauen";
		var GoTactics = "Zum Taktikbereich";
		var GoSquad = "Przeglad Skladu";
 		var GoYouthAcademy = "Die Jugendakademie besuchen";	
		var GoYouthAcademyy = "Go to Youth Academy";
		var GoHireCoaches = "Neue Trainer einstellen";
		var GoHireScouts = "Neue Scouts einstellen";
		var GoMyCoaches = "Sieh dir deine Trainer an";
		var GoMyScouts = "Sieh dir deine Scouts an";		
		var	GoScoutReports = "Schau dir deine Scout-Reporte an";
		var GoPlayerNotes = "Spielernotizen aufrufen";		
		var GoTrainingOverview = "Überprüfe die Trainingsergebnisse";
		var GoTrainingTeams = "Passe deine Trainingsgruppen an";
		var GoForum = "Durchstöbere die Foren";
		var GoTMUserGuide = "Lies das Handbuch";
		var GoTBConference = "Feedback geben";
		
		var GoTransferForum = "Das Transferforum besuchen";
		var GoGeneralForum = "Das Generalforum besuchen";
		var GoAnnouncementForum = "Halte Ausschau nach neuen Ankündigungen der Entwickler";
		//var GoFederations = "Föderationen besuchen";
	
	var Team = "Team";
		var CurrentBids = "Aktuelle Gebote";			
		var Squad = "Mannschaftsübersicht";
		var Tactics = "Taktiken";
		var YouthAcademy = "Jugendakademie";
		var YouthAcademyy = "Youth Academy";
	var Staff = "Mitarbeiter";
		var HireCoaches = "Trainer";
		var HireScouts = "Scouts kaufen";
		var ScoutReports = "Scout Reporte";
		var MyCoaches = "MyTrainer";
		var MyScouts = "MyScouts";
	var Training = "Training";	
		var PlayerNotes = "Spielernotizen";
		var TrainingOverview = "Trainingsübersicht";
		var TrainingTeams = "Trainingsgruppen";
	var Community = "Community-Links";	
		var Forum = "Forum";
		var TMUserGuide = "TM-Handbuch";
		var TBConference = "TrophyBuddy-Feedback";
	break;	
	
	
// ENGLISH
case "en":
		var Home = "Home";
		var CheckYourMails = "Check your mails";
		var League = "League";
		var Cup = "Cup";
		var Exit = "Exit TrophyManager";
			
		var GoCurrentBids = "See Current Bids";
		var GoTactics = "Go to Tactics";
 		var GoYouthAcademy = "Asystent-Taktyka";	
		var GoYouthAcademyy = "Go to Youth Academy";	
		var GoHireCoaches = "Hire new coaches";
		var GoHireScouts = "Hire new scouts";
		var GoMyCoaches = "Take a look at your coaches";
		var GoMyScouts = "Take a look at your scouts";
		var	GoScoutReports = "Check what you have scouted";
		var GoPlayerNotes = "See your player notes";		
		var GoTrainingOverview = "Check the training results";
		var GoTrainingTeams = "Change your training teams";
		var GoForum = "Browse forums";
		var GoTMUserGuide = "Read the User-Guide";
		var GoTBConference = "Enter the TrophyBuddy-Conference";
		
		var GoTransferForum = "Go to Transfer forum";
		var GoGeneralForum = "Go to General forum";
		var GoAnnouncementForum = "Go to Announcement forum";
		//var GoFederations = "Go to Federations";
		
	var Team = "Team";	
		var CurrentBids = "Current Bids";
		var Squad = "Squad";
		var Tactics = "Tactics";
		var YouthAcademy = "Asystent-Taktyka";
		var YouthAcademyy = "Youth Academy";
	var Staff = "Staff";
		var HireCoaches = "Hire Coaches";
		var HireScouts = "Scouts";
		var ScoutReports = "Scout Reports";
		var MyCoaches = "MyCoaches";				
		var MyScouts = "MyScouts";
	var Training = "Training";	
		var PlayerNotes = "Player Notes";
		var TrainingOverview = "Training Overview"; 
		var TrainingTeams = "Training Teams";
	var Community = "Community-Links";	
		var Forum = "Forum";
		var TMUserGuide = "TM-UserGuide";
		var TBConference = "TrophyBuddy-Conference";
	break;


//FRENCH
 case "fr":
		var Home = "Accueil";
		var CheckYourMails = "Messages";
		var League = "Tournoi";
		var Cup = "Coupe";
		var Exit = "Déconnexion";
			
		var GoCurrentBids = "Enchères en cours";
		var GoTactics = "Tactiques";
		var GoYouthAcademy = "Centre de formation";
		var GoHireCoaches = "Recruter un coach";
		var GoHireScouts = "Recruter un scout";
		var GoMyCoaches = "Coachs";
		var GoMyScouts = "Scouts";
		var GoScoutReports = "Rapports de scout";
		var GoPlayerNotes = "Notes";
		var GoTrainingOverview = "Compte rendu entraînement";
		var GoTrainingTeams = "Entraînement";
		var GoForum = "Forum";
		var GoTMUserGuide = "Manuel de jeu";
		var GoTBConference = "TrophyBuddy Conference";
		
		var GoTransferForum = "Forum des transferts";
		var GoGeneralForum = "Forum général";
		var GoAnnouncementForum = "Annonces officielles";
		//var GoFederations = "Fédérations";
		
	var Team = "Team";
		var CurrentBids = "Enchères actuelles";
		var Squad = "Équipe";
		var Tactics = "Tactiques";
		var YouthAcademy = "Centre de formation";
	var Staff = "Staff";
		var HireCoaches = "Recruter un coach";
		var HireScouts = "Recruter un scout";
		var ScoutReports = "Rapport de scout";
		var MyCoaches = "Mes coachs";
		var MyScouts = "Mes scouts";
	var Training = "Entraînement";
		var PlayerNotes = "Notes joueurs";
		var TrainingOverview = "Compte rendu d'entraînement";
		var TrainingTeams = "Equipe d'entraînement";
	var Community = "Communautés";
		var Forum = "Forum";
		var TMUserGuide = "TM-Manuel de jeu";
		var TBConference = "TrophyBuddy-Conference";
	break;	
	
	
//HEBREW
 case "he":
		var Home = "???";
		var CheckYourMails = "???? ?? ????? ???";
		var League = "???";
		var Cup = "????";
		var Exit = "?? ?????? ???'?";

		var GoCurrentBids = "??? ????? ???????";
		var GoTactics = "???? ???????";
		var GoYouthAcademy = "???? ??????? ?????";
		var GoHireCoaches = "???? ?????? ?????";
		var GoHireScouts = "???? ??????? ?????";
		var GoMyCoaches = "??? ??? ??????? ???";
		var GoMyScouts = "??? ??? ???????? ???";
		var GoScoutReports = "???? ?? ?????? ?????? ?? ??????";
		var GoPlayerNotes = "??? ?? ????? ?? ??????";
		var GoTrainingOverview = "???? ?? ?????? ????????";
		var GoTrainingTeams = "??? ?? ?????? ?????? ???";
		var GoForum = "???? ??????";
		var GoTMUserGuide = "??? ?? ??????-??????";
		var GoTBConference = "???? ?????? ??????-??? ??????";

		var GoTransferForum = "???? ?????? ??????";
		var GoGeneralForum = "???? ?????? ?????";
		var GoAnnouncementForum = "???? ?????? ???????";
		//var GoFederations = "???? ????????";

	var Team = "?????";
		var CurrentBids = "????? ???????";
		var Squad = "???";
		var Tactics = "??????";
		var YouthAcademy = "?????? ????";
	var Staff = "????";
		var HireCoaches = "???? ??????";
		var HireScouts = "???? ???????";
		var ScoutReports = "????? ???????";
		var MyCoaches = "??????? ???";
		var MyScouts = "???????? ???";
	var Training = "???????";
		var PlayerNotes = "????? ????";
		var TrainingOverview = "????? ?????";
		var TrainingTeams = "?????? ?????";
	var Community = "????-?????";
		var Forum = "?????";
		var TMUserGuide = "?????-?????";
		var TBConference = "????? ??????-???";
	break;		
	

//HUNGARIAN
 case "hu":
		var Home = "Otthon";
		var CheckYourMails = "Levelek";
		var League = "Bajnokság";
		var Cup = "Kupa";
		var Exit = "Kilépés";

		var GoCurrentBids = "Aktív licitek";
		var GoTactics = "Taktika módosítása";
		var GoYouthAcademy = "Ifiakadémia meglátogatása";
		var GoHireCoaches = "Új edzö felvétele";
		var GoHireScouts = "Új megfigyelö felvétele";
		var GoMyCoaches = "Edzök igazgatása";
		var GoMyScouts = "Megfigyelök igazgatása";
		var GoScoutReports = "Jelentések böngészése";
		var GoPlayerNotes = "Játékos jegyzetek";
		var GoTrainingOverview = "Edzés áttekintés";
		var GoTrainingTeams = "Edzésprogram módosítása";
		var GoForum = "Fórum böngészés";
		var GoTMUserGuide = "TM-Kézikönyv";
		var GoTBConference = "TrophyBuddy-Szövetség";

		var GoTransferForum = "Átigazolási fórum - angol";
		var GoGeneralForum = "Globális fórum - angol";
		var GoAnnouncementForum = "Bejelentés fórum - angol";
		//var GoFederations = "Szövetségek";

	var Team = "Csapat";
		var CurrentBids = "Licitek";
		var Squad = "Keret";
		var Tactics = "Taktika";
		var YouthAcademy = "Ifiakadémia";
	var Staff = "Stáb";
		var HireCoaches = "Edzö felvétele";
		var HireScouts = "Scoutok";
		var ScoutReports = "Scout jelentések";
		var MyCoaches = "Edzöim";
		var MyScouts = "Scoutjaim";
	var Training = "Edzés";
		var PlayerNotes = "Jegyzetek";
		var TrainingOverview = "Edzés jelentés";
		var TrainingTeams = "Edzésprogramok";
	var Community = "Közösség";
		var Forum = "Fórum";
		var TMUserGuide = "TM-Ismertetö";
		var TBConference = "TrophyBuddy-Szövetség";
	break;	

	
//POLISH	
	case "pl":
		var Home = "Klub";
		var CheckYourMailss = "Ogloszenia";
		var CheckYourMails = "Wiadomosci";
		var League = "Liga";
		var Cup = "Liga Team B";
		var Exit = "Banned";
			
		var GoCurrentBids = "Oferty transferowe";
		var GoSquad = "Przeglad Skladu";
		var GoTactics = "Taktyka";
		var GoToYouthAcademy = "Asystent-Taktyka";
		var GoToYouthAcademyy = "Ekonomia";	
		var GoPlayerNotes = "Akademia Mlodziezy";
		var GoHireCoaches = "Zatrudnij Trenerów";
		var GoHireScouts = "Zatrudnij Skautów";
		var GoScoutReports = "Raporty Skautów";
		var GoTrainingOverview = "Wyniki treningu";
		var GoTrainingTeams = "Ustawienie treningu";
		var GoForum = "Forum";
		var GoTMUserGuide = "Podrecznik TM";
		var GoTBConference = "Strona o TrophyBuddy";
		
		var GoTransferForum = "Pomoc forum";
		var GoGeneralForum = "General forum";
		var GoAnnouncementForum = "Bugs forum";
		//var GoFederations = "Go to Federations";
		
		var Team = "FC_Barcelona.";
			var CurrentBids = "Oferty transferowe";
			var Squad = "Przeglad Skladu";
			var Tactics = "Taktyka";
			var YouthAcademy = "Asystent-Taktyka";
			var YouthAcademyy = "Ekonomia";
			var PlayerNotes = "Akademia Mlodziezy";
			var PlayerNotess = "Fanklub";
		var Staff = "Personel";
			var HireCoaches = "Zatrudnij Trenerów";
			var HireScouts = "Zatrudnij Skautów";
			var ScoutReports = "Raporty Skautów";
			var MyCoaches = "Trenerzy";
			var MyScouts = "Skauci";
		var Training = "Trening";
			var TrainingOverview = "Wyniki treningu";
			var TrainingTeams = "Ustawienie treningu";
		var Community = "Linki";
			var Forum = "Forum";
			var TMUserGuide = "Podrecznik TM";
			var TBConference = "TrophyBuddy";
			var TBConferencee = "Calculator";
	break;

	
//ROMANIAN	
	case "ro":
			var Home = "Acasa";
			var CheckYourMails = "Verifica mesajele";
			var League = "Liga";
			var Cup = "Cupa";
			var Exit = "Iesire";

			var GoCurrentBids = "Licitatii";
			var GoTactics = "Tactici";
			var GoYouthAcademy = "Academia de tineret";
			var GoHireCoaches = "Angajeaza antrenori";
			var GoHireScouts = "Angajeaza scouteri";
			var GoMyCoaches = "Antrenori";
			var GoMyScouts = "Scouteri";
			var GoScoutReports = "Rapoarte";
			var GoPlayerNotes = "Notite";
			var GoTrainingOverview = "Vizualizare antrenament";
			var GoTrainingTeams = "Grupe de antrenament";
			var GoForum = "Citeste forumul";
			var GoTMUserGuide = "Citeste manualul";
			var GoTBConference = "Intra la Conferinta TrophyBuddy";

			var GoTransferForum = "Forum transferuri";
			var GoGeneralForum = "Forum global";
			var GoAnnouncementForum = "Forum anunturi";
			//var GoFederations = "Forum federatii";

		var Team = "Echipa";
			var CurrentBids = "Licitatii";
			var Squad = "Jucatori";
			var Tactics = "Tactici";
			var YouthAcademy = "Academia de tineret";
		var Staff = "Staff";
			var HireCoaches = "Angajare antrenori";
			var HireScouts = "Scouteri";
			var ScoutReports = "Rapoarte";
			var MyCoaches = "Antrenorii";
			var MyScouts = "Scouterii mei";
		var Training = "Antrenament";
			var PlayerNotes = "Notite";
			var TrainingOverview = "Vizualizare antr.";
			var TrainingTeams = "Grupe de antr.";
		var Community = "Comunitate";
			var Forum = "Forum";
			var TMUserGuide = "Manual-TM";
			var TBConference = "Conferinta TrophyBuddy";
	break;	
	
	
//SLOVAC	
	case "sl":
		var Home = "Doma";
		var CheckYourMails = "Pozri maily";
		var League = "Liga";
		var Cup = "Pohár";
		var Exit = "Odhlás sa z TrophyManager";

		var GoCurrentBids = "Ponuky";
		var GoTactics = "Taktia";
		var GoYouthAcademy = "Juniory";
		var GoHireCoaches = "Najat trénerov";
		var GoHireScouts = "Najat skautov";
		var GoMyCoaches = "Tréneri";
		var GoMyScouts = "Skauti";
		var GoScoutReports = "Správy skautov";
		var GoPlayerNotes = "Poznámky o hrácoch";
		var GoTrainingOverview = "Prehlad tréningu";
		var GoTrainingTeams = "Nastavenie tréningu";
		var GoForum = "Fórum";
		var GoTMUserGuide = "User-Guide fórum";
		var GoTBConference = "TrophyBuddy-Conference fórum";

		var GoTransferForum = "Transfer fórum";
		var GoGeneralForum = "General fórum";
		var GoAnnouncementForum = "Announcement fórum";
		//var GoFederations = "Federations fórum";

	var Team = "Klub";
		var CurrentBids = "Ponuky";
		var Squad = "Hráci";
		var Tactics = "Taktika";
		var YouthAcademy = "Juniory";
	var Staff = "Personál";
		var HireCoaches = "Najat trénerov";
		var HireScouts = "Skauti";
		var ScoutReports = "Správy skautov";
		var MyCoaches = "Moji tréneri";
		var MyScouts = "Moji skauti";
	var Training = "Tréning";
		var PlayerNotes = "Poznámky hrácov";
		var TrainingOverview = "Prehlad tréningu";
		var TrainingTeams = "Tréning";
	var Community = "Comunita";
		var Forum = "Fórum";
		var TMUserGuide = "TM-UserGuide";
		var TBConference = "TrophyBuddy-Conference"; 
	break;
	
}
// ==/UserScript==

var myurl=document.URL;

if (myurl.match(/scouts/)) {

	if (document.URL == "http://trophymanager.com/scouts/hire/") {

		if (bronze_stars == "no") {
	
			var load,execute,loadAndExecute;load=function(a,b,c){var d;d=document.createElement("script"),d.setAttribute("src",a),b!=null&&d.addEventListener("load",b),c!=null&&d.addEventListener("error",c),document.body.appendChild(d);return d},execute=function(a){var b,c;typeof a=="function"?b="("+a+")();":b=a,c=document.createElement("script"),c.textContent=b,document.body.appendChild(c);return c},loadAndExecute=function(a,b){return load(a,function(){return execute(b)})};
			loadAndExecute("//ajax.googleapis.com/ajax/libs/jquery/1.6.4/jquery.min.js", function() {

				// Show the stars!
				$('td.align_center:contains("18")').html('<img src="http://www.patrick-meurer.de/tm/bronze_star.png">');
				$('td.align_center:contains("19")').html('<img src="/pics/star_silver.png">');
				$('td.align_center:contains("20")').html('<img src="/pics/star.png">');
				$('td.align_center').css('font-weight', 'bold');
			});
		}
		else {

			var load,execute,loadAndExecute;load=function(a,b,c){var d;d=document.createElement("script"),d.setAttribute("src",a),b!=null&&d.addEventListener("load",b),c!=null&&d.addEventListener("error",c),document.body.appendChild(d);return d},execute=function(a){var b,c;typeof a=="function"?b="("+a+")();":b=a,c=document.createElement("script"),c.textContent=b,document.body.appendChild(c);return c},loadAndExecute=function(a,b){return load(a,function(){return execute(b)})};
			loadAndExecute("//ajax.googleapis.com/ajax/libs/jquery/1.6.4/jquery.min.js", function() {

				// Show the stars!
				$('td.align_center:contains("19")').html('<img src="/pics/star_silver.png">');
				$('td.align_center:contains("20")').html('<img src="/pics/star.png">');
				$('td.align_center').css('font-weight', 'bold');
			});		
		
		}

	}
	else {
/*		
		if (bronze_stars == "no") {
		
			var load,execute,loadAndExecute;load=function(a,b,c){var d;d=document.createElement("script"),d.setAttribute("src",a),b!=null&&d.addEventListener("load",b),c!=null&&d.addEventListener("error",c),document.body.appendChild(d);return d},execute=function(a){var b,c;typeof a=="function"?b="("+a+")();":b=a,c=document.createElement("script"),c.textContent=b,document.body.appendChild(c);return c},loadAndExecute=function(a,b){return load(a,function(){return execute(b)})};
			loadAndExecute("//ajax.googleapis.com/ajax/libs/jquery/1.6.4/jquery.min.js", function() {

				// Show the stars!
				$('table.border_bottom td:contains("18")').html('<img src="http://www.patrick-meurer.de/tm/bronze_star.png">');
				$('table.border_bottom:eq(0) tr:eq(1) td:contains("19")').html('<img src="/pics/star_silver.png">');
				$('table.border_bottom td:contains("20")').html('<img src="/pics/star.png">');
				$('table.border_bottom td').css('font-weight', 'bold');	
				
			});	
		}
		else {
		
			var load,execute,loadAndExecute;load=function(a,b,c){var d;d=document.createElement("script"),d.setAttribute("src",a),b!=null&&d.addEventListener("load",b),c!=null&&d.addEventListener("error",c),document.body.appendChild(d);return d},execute=function(a){var b,c;typeof a=="function"?b="("+a+")();":b=a,c=document.createElement("script"),c.textContent=b,document.body.appendChild(c);return c},loadAndExecute=function(a,b){return load(a,function(){return execute(b)})};
			loadAndExecute("//ajax.googleapis.com/ajax/libs/jquery/1.6.4/jquery.min.js", function() {

				// Show the stars!
				$('table.border_bottom td:contains("19")').html('<img src="/pics/star_silver.png">');
				$('table.border_bottom td:contains("20")').html('<img src="/pics/star.png">');
				$('table.border_bottom td').css('font-weight', 'bold');	
			});	
		
		}*/
	}
}

if (myurl.match(/coaches/)) {

	if (document.URL == "http://trophymanager.com/coaches/hire/") {
	
		if (bronze_stars == "no") {
	
			var load,execute,loadAndExecute;load=function(a,b,c){var d;d=document.createElement("script"),d.setAttribute("src",a),b!=null&&d.addEventListener("load",b),c!=null&&d.addEventListener("error",c),document.body.appendChild(d);return d},execute=function(a){var b,c;typeof a=="function"?b="("+a+")();":b=a,c=document.createElement("script"),c.textContent=b,document.body.appendChild(c);return c},loadAndExecute=function(a,b){return load(a,function(){return execute(b)})};
			loadAndExecute("//ajax.googleapis.com/ajax/libs/jquery/1.6.4/jquery.min.js", function() {

				// Show the stars!
				$('td.align_center:contains("18")').html('<img src="http://www.patrick-meurer.de/tm/bronze_star.png">');
				$('td.align_center:contains("19")').html('<img src="/pics/star_silver.png">');
				$('td.align_center:contains("20")').html('<img src="/pics/star.png">');
				$('td.align_center').css('font-weight', 'bold');
			});
		}
		else {

			var load,execute,loadAndExecute;load=function(a,b,c){var d;d=document.createElement("script"),d.setAttribute("src",a),b!=null&&d.addEventListener("load",b),c!=null&&d.addEventListener("error",c),document.body.appendChild(d);return d},execute=function(a){var b,c;typeof a=="function"?b="("+a+")();":b=a,c=document.createElement("script"),c.textContent=b,document.body.appendChild(c);return c},loadAndExecute=function(a,b){return load(a,function(){return execute(b)})};
			loadAndExecute("//ajax.googleapis.com/ajax/libs/jquery/1.6.4/jquery.min.js", function() {

				// Show the stars!
				$('td.align_center:contains("19")').html('<img src="/pics/star_silver.png">');
				$('td.align_center:contains("20")').html('<img src="/pics/star.png">');
				$('td.align_center').css('font-weight', 'bold');
			});		
		
		}
	}
	else {
		
		if (bronze_stars == "no") {	
			var load,execute,loadAndExecute;load=function(a,b,c){var d;d=document.createElement("script"),d.setAttribute("src",a),b!=null&&d.addEventListener("load",b),c!=null&&d.addEventListener("error",c),document.body.appendChild(d);return d},execute=function(a){var b,c;typeof a=="function"?b="("+a+")();":b=a,c=document.createElement("script"),c.textContent=b,document.body.appendChild(c);return c},loadAndExecute=function(a,b){return load(a,function(){return execute(b)})};
			loadAndExecute("//ajax.googleapis.com/ajax/libs/jquery/1.6.4/jquery.min.js", function() {

				// Show the stars!
				$('td:contains("18")').html('<img src="http://www.patrick-meurer.de/tm/bronze_star.png">');
				$('td:contains("19")').html('<img src="/pics/star_silver.png">');
				$('td:contains("20")').html('<img src="/pics/star.png">');
				$('td').css('font-weight', 'bold');	
			});	
		}
		else {
			var load,execute,loadAndExecute;load=function(a,b,c){var d;d=document.createElement("script"),d.setAttribute("src",a),b!=null&&d.addEventListener("load",b),c!=null&&d.addEventListener("error",c),document.body.appendChild(d);return d},execute=function(a){var b,c;typeof a=="function"?b="("+a+")();":b=a,c=document.createElement("script"),c.textContent=b,document.body.appendChild(c);return c},loadAndExecute=function(a,b){return load(a,function(){return execute(b)})};
			loadAndExecute("//ajax.googleapis.com/ajax/libs/jquery/1.6.4/jquery.min.js", function() {

				// Show the stars!
				$('td:contains("19")').html('<img src="/pics/star_silver.png">');
				$('td:contains("20")').html('<img src="/pics/star.png">');
				$('td').css('font-weight', 'bold');	
			});	
		
		}
	}
}

	
//Jugendspieler: Position auslesen
/*	pos_y = aux[n].cells[4].innerHTML;
	}

	var skillsumspan_HL = document.createElement("span");
	skillsumspan_HL.innerHTML="<div style=\"color: gold;\"><b>TB-Rating</b></div>";
	document.getElementsByTagName("table")[0].getElementsByTagName('tr')[7].getElementsByTagName('th')[0].appendChild(skillsumspan_HL);

}
}
*/

if (myurl.match(/training-overview/)) {
	
	if (document.URL == "http://trophymanager.com/training-overview/advanced/") {
	if (alt_training = "yes") {
		var load,execute,loadAndExecute;load=function(a,b,c){var d;d=document.createElement("script"),d.setAttribute("src",a),b!=null&&d.addEventListener("load",b),c!=null&&d.addEventListener("error",c),document.body.appendChild(d);return d},execute=function(a){var b,c;typeof a=="function"?b="("+a+")();":b=a,c=document.createElement("script"),c.textContent=b,document.body.appendChild(c);return c},loadAndExecute=function(a,b){return load(a,function(){return execute(b)})};

		loadAndExecute("//ajax.googleapis.com/ajax/libs/jquery/1.6.4/jquery.min.js", function() {
		    	
			//gray alternating table background
			$('table.zebra tr').css('background-color', '#222222');
			$('table.zebra tr.odd').css('background-color', 'rgb(48, 48, 48)');

			// Small training increases
			$('span.training_small').css('border', '1px rgb(141, 182, 82) solid');
			$('span.training_small').css('background-color', '#45521E');

			// Small training decreases
			$('span.training_part_down').css('border', '1px #D7220E solid');
			$('span.training_part_down').css('background-color', '#502927');

			// Big training increases
			$('span.training_big').css('font-size', '15px');
			$('span.training_big').css('font-weight', 'normal');
			//$('span.training_big').css('text-decoration', 'blink');
			$('span.training_big').css('background-color', '#93B751');
			$('span.training_big').css('color', '#000000');

			// Big training decreases
			$('span.training_down').css('font-size', '13px');
			$('span.training_down').css('font-weight', 'normal');
			$('span.training_down').css('background-color', '#D7220E');
			$('span.training_down').css('color', '#000000');

			// Increase all skill space sizes
			$('span.training_big, span.training_small, span.training_part_down, span.training_down, span.subtle').css('width', '15px');

			// No changes
			$('span.subtle').css('color', '#FFFFFF');

			// Remove position background
			$('table.zebra tr .favposition').css('background-color', '#222222');
			$('table.zebra tr.odd .favposition').css('background-color', 'rgb(48, 48, 48)');

			// Add borders to sides of tables
			$('table.zebra').css('border-left', '3px #222222 solid');
			$('table.zebra').css('border-right', '3px #222222 solid');

			// Intensity & +/- alignment
			$('table.zebra tr td:nth-child(18)').css('padding-right', '12px');
			$('table.zebra tr th:nth-child(19)').css('width', '34px');
			$('table.zebra tr td:nth-child(19) span').css('width', '32px');

			// Intensity & +/- alignment for goalie coach
			$('table.zebra:eq(5) tr td:nth-child(15)').css('padding-right', '12px');
			$('table.zebra:eq(5) tr th:nth-child(15)').css('width', '34px');
			$('table.zebra:eq(5) tr td:nth-child(16) span').css('width', '32px');

			// Coach headers
			$('h3').css('background-color', '#222222');

			// Show the stars!
			//$('span:contains("19")').html('<img src="/pics/star_silver.png">');
			//$('span:contains("20")').html('<img src="/pics/star.png">');
			
			//19 to SilverStar
			$('span.training_part_down:contains("19")').html('<img src="/pics/star_silver.png">');
			$('span.training_down:contains("19")').html('<img src="/pics/star_silver.png">');
			$('span.subtle:contains("19")').html('<img src="/pics/star_silver.png">');
			$('span.training_big:contains("19")').html('<img src="/pics/star_silver.png">');
			$('span.training_big:contains("19")').html('<img src="/pics/star_silver.png">');
			
			//20 to GoldStar
			$('span.training_part_down:contains("20")').html('<img src="/pics/star.png">');
			$('span.training_down:contains("20")').html('<img src="/pics/star.png">');
			$('span.subtle:contains("20")').html('<img src="/pics/star.png">');
			$('span.training_small:contains("20")').html('<img src="/pics/star.png">');
			$('span.training_big:contains("20")').html('<img src="/pics/star.png">');
			
		});
	}
	else {
	
	}
	}
	else {

	}

}


	
if (myurl.match(/club/)) {

	var checktable = document.getElementsByTagName("table")[0];
	checktable = checktable.getAttribute("class");
	
	if (checktable == "zebra padding") {
	
	var checksquad = document.getElementsByTagName("a")[8];
	checksquad = checksquad.getAttribute("href");
	checksquad = checksquad.replace(/[^a-zA-Z 0-9]+/g,'');
	checksquad = checksquad.replace("club", "");
	/*
		var load,execute,loadAndExecute;load=function(a,b,c){var d;d=document.createElement("script"),d.setAttribute("src",a),b!=null&&d.addEventListener("load",b),c!=null&&d.addEventListener("error",c),document.body.appendChild(d);return d},execute=function(a){var b,c;typeof a=="function"?b="("+a+")();":b=a,c=document.createElement("script"),c.textContent=b,document.body.appendChild(c);return c},loadAndExecute=function(a,b){return load(a,function(){return execute(b)})};

		loadAndExecute("//ajax.googleapis.com/ajax/libs/jquery/1.6.4/jquery.min.js", function() {

			//$('div.std p').css('font-weight', 'bold');
			//$('div.std').css('background-color', '#502927'); // Change Background Color
			//$('td.align_center:contains("19")').html('<img src="/pics/star_silver.png">');
			//$('td.align_center:contains("20")').html('<img src="/pics/star.png">');
			//$('td.align_center').css('font-weight', 'bold');
		});
	*/
	
	
	}
	else {
	
		if (document.URL == "http://trophymanager.com/account/club-info/"){
		
		}
		else {
	
			league_try = document.getElementsByTagName("a")[17].getAttribute("href");
			league_try = league_try.search("league");
			if (league_try != -1) {
				n=0;
			}
			else {
				n=1;
			}
			var leaguecheck = document.getElementsByTagName("a")[n+17];
			leaguecheck = leaguecheck.getAttribute("href");
			leaguecheck = leaguecheck.replace("/league/", "");
			//leaguecheck = leaguecheck.replace("/league/", "");
			leaguecheck = leaguecheck.substr(3,leaguecheck.length);
			leaguecheck = leaguecheck.replace(/[^a-zA-Z 0-9]+/g,'');
			leaguecheck = leaguecheck.substr(0,1) + '.' + leaguecheck.substr(1,leaguecheck.length);
			//alert(leaguecheck)
			
			var oldleague = document.createElement("span");
			oldleague.innerHTML="<span style=\"color: gold;\"><b> (" + leaguecheck + ")</b></span>";
			document.getElementsByTagName("a")[n+17].appendChild(oldleague);

		}
	}
}


if (myurl.match(/league/)) {

	var check_statpage = document.URL;
	check_statpage = check_statpage.search("statistics");
	
	if (check_statpage != -1) {
	
		
	}
	else {
/*	//alert(check_statpage)
	var load,execute,loadAndExecute;load=function(a,b,c){var d;d=document.createElement("script"),d.setAttribute("src",a),b!=null&&d.addEventListener("load",b),c!=null&&d.addEventListener("error",c),document.body.appendChild(d);return d},execute=function(a){var b,c;typeof a=="function"?b="("+a+")();":b=a,c=document.createElement("script"),c.textContent=b,document.body.appendChild(c);return c},loadAndExecute=function(a,b){return load(a,function(){return execute(b)})};

		loadAndExecute("//ajax.googleapis.com/ajax/libs/jquery/1.6.4/jquery.min.js", function() {

			$('div.add_comment a').css('font-weight', 'bold');
			$('div.add_comment a').css('font-size', '1.5em');
			//$('div.std').css('background-color', '#502927'); // Change Background Color
			//$('td.align_center:contains("19")').html('<img src="/pics/star_silver.png">');
			//$('td.align_center:contains("20")').html('<img src="/pics/star.png">');
			//$('td.align_center').css('font-weight', 'bold');
		});
*/	
	}
}

if (myurl.match(/youth-development/)) {


     var div_area = document.createElement('div');
	div_area.innerHTML="<div id=\"area\" style=\"position: absolute; z-index: 1000; width: 175px; margin-top: 25px; color: #ff9900; -moz-opacity: .8; text-align: middle; color: gold; display:inline;\"><table style=\"margin-bottom: -1em; background: #5F8D2D; border: 2px #275502 outset;\"><tr><th style=\"padding-left: 5px;\">Gwiazdki</th><th title=\"The potential values from old TM\">Stary Potencjal</th></tr><tr><td><img src=\"http://trophymanager.com/pics/star.png\"><img src=\"http://trophymanager.com/pics/star.png\"><img src=\"http://trophymanager.com/pics/star.png\"><img src=\"http://trophymanager.com/pics/star.png\"><img src=\"http://trophymanager.com/pics/star.png\"></td><td title=\"+ Best 19*\">best19-20</td></tr><tr><td><img src=\"http://trophymanager.com/pics/star.png\"><img src=\"http://trophymanager.com/pics/star.png\"><img src=\"http://trophymanager.com/pics/star.png\"><img src=\"http://trophymanager.com/pics/star.png\"><img src=\"http://trophymanager.com/pics/half_star.png\"></td><td title=\"+ Worst 20*\">17-18-19</td></tr><tr><td><img src=\"http://trophymanager.com/pics/star.png\"><img src=\"http://trophymanager.com/pics/star.png\"><img src=\"http://trophymanager.com/pics/star.png\"><img src=\"http://trophymanager.com/pics/star.png\"><img src=\"http://trophymanager.com/pics/dark_star.png\"></td><td>15-16</td></tr><tr><td><img src=\"http://trophymanager.com/pics/star.png\"><img src=\"http://trophymanager.com/pics/star.png\"><img src=\"http://trophymanager.com/pics/star.png\"><img src=\"http://trophymanager.com/pics/half_star.png\"><img src=\"http://trophymanager.com/pics/dark_star.png\"></td><td>13-14</td></tr><tr><td><img src=\"http://trophymanager.com/pics/star.png\"><img src=\"http://trophymanager.com/pics/star.png\"><img src=\"http://trophymanager.com/pics/star.png\"><img src=\"http://trophymanager.com/pics/dark_star.png\"><img src=\"http://trophymanager.com/pics/dark_star.png\"></td><td>11-12</td></tr><tr><td><img src=\"http://trophymanager.com/pics/star.png\"><img src=\"http://trophymanager.com/pics/star.png\"><img src=\"http://trophymanager.com/pics/half_star.png\"><img src=\"http://trophymanager.com/pics/dark_star.png\"><img src=\"http://trophymanager.com/pics/dark_star.png\"></td><td>9-10</td></tr><tr><td><img src=\"http://trophymanager.com/pics/star.png\"><img src=\"http://trophymanager.com/pics/star.png\"><img src=\"http://trophymanager.com/pics/dark_star.png\"><img src=\"http://trophymanager.com/pics/dark_star.png\"><img src=\"http://trophymanager.com/pics/dark_star.png\"></td><td>7-8</td></tr></table></div>";
	document.getElementsByTagName("div")[18].appendChild(div_area);

}




//alert ("Skript ist aktiv")

if (myurl.match(/players/))  { // hier wird geprueft, ob das die richtige Seite ist

	var check_statpage = document.URL;
	check_statpage = check_statpage.search("statistics");


		if (document.URL == "http://trophymanager.com/players/"){
		
		function embed() {
		var oldFunc = makeTable;

		makeTable = function() {

        
        
		myTable = document.createElement('table');
		myTable.className = "hover zebra";

		construct_th();
		var z=0;
		for (i=0; i<players_ar.length; i++) {
			if (players_ar[i]["fp"] != "GK" && add_me(players_ar[i]) && filter_squads()) {
				construct_tr(players_ar[i], z);
				z++;
			}
		}
		if (z == 0) {
			var myRow = myTable.insertRow(-1);
			var myCell = myRow.insertCell(-1);
			myCell.colSpan = 24;
			myCell.innerHTML = other_header;
		}
	    if (filters_ar[1] == 1) {
	        var myRow = myTable.insertRow(-1);
	        var myCell = myRow.insertCell(-1);
	        myCell.className = "splitter";
	        myCell.colSpan = "50";
	        myCell.innerHTML = gk_header;
	        construct_th(true);
	        z=0;
	        for (i=0; i<players_ar.length; i++) {
	            if (players_ar[i]["fp"] == "GK" && filter_squads()) {
	                if (!(players_ar[i]["age"] < age_min || players_ar[i]["age"] > age_max)) {
	                    construct_tr(players_ar[i], z, true);
	                    z++;
	                }
	            }
	        }
	    }
	    $e("sq").innerHTML = "";
	    $e("sq").appendChild(myTable);
	    activate_player_links($(myTable).find("[player_link]"));
	    init_tooltip_by_elems($(myTable).find("[tooltip]"))
	    zebra();

	    };
		}

		var inject = document.createElement("script");

		inject.setAttribute("type", "text/javascript");
		inject.appendChild(document.createTextNode("(" + embed + ")()"));

		document.body.appendChild(inject);


		var load,execute,loadAndExecute;load=function(a,b,c){var d;d=document.createElement("script"),d.setAttribute("src",a),b!=null&&d.addEventListener("load",b),c!=null&&d.addEventListener("error",c),document.body.appendChild(d);return d},execute=function(a){var b,c;typeof a=="function"?b="("+a+")();":b=a,c=document.createElement("script"),c.textContent=b,document.body.appendChild(c);return c},loadAndExecute=function(a,b){return load(a,function(){return execute(b)})};

		loadAndExecute("//ajax.googleapis.com/ajax/libs/jquery/1.6.4/jquery.min.js", function() {

		    $.noConflict();
		    jQuery(document).ready(function($) {
		       // $('table.zebra th:eq(0)').click();
		  });
		});
		
		}
		else if (check_statpage != -1) {
		}
		
		else {
		
		counttables = document.getElementsByTagName("table").length;
		//alert (counttables)
		var c = 0;
		
		if (counttables == 3) {
			aux = document.getElementsByTagName("table")[1]; // holt die gesamte Tabelle
		}
		else {
			aux = document.getElementsByTagName("table")[2]; // holt die gesamte Tabelle
		}
		auxx = document.getElementsByTagName("table")[0]; // holt die gesamte Tabelle		
		pos_td = document.getElementsByTagName("strong")[1]; // holt die gesamte Tabelle
		auxspan = document.getElementsByTagName("span")[28]; // holt die gesamte Tabelle
		aux2 = document.getElementsByTagName("p")[0]; // holt die gesamte Tabelle
		aux3 = document.getElementsByTagName("p")[1]; // holt die gesamte Tabelle
		aux4 = document.getElementsByTagName("p")[2]; // holt die gesamte Tabelle
		
		if (old_skills == "yes") {
		
		var load,execute,loadAndExecute;load=function(a,b,c){var d;d=document.createElement("script"),d.setAttribute("src",a),b!=null&&d.addEventListener("load",b),c!=null&&d.addEventListener("error",c),document.body.appendChild(d);return d},execute=function(a){var b,c;typeof a=="function"?b="("+a+")();":b=a,c=document.createElement("script"),c.textContent=b,document.body.appendChild(c);return c},loadAndExecute=function(a,b){return load(a,function(){return execute(b)})};

		loadAndExecute("//ajax.googleapis.com/ajax/libs/jquery/1.6.4/jquery.min.js", function () {

		$.noConflict();
		jQuery(document).ready(function ($) {

    // Destination table
    var newskills =
      '<table id="new_skill_table">' +
      '<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>' +
      '<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>' +
      '<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>' +
      '<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>' +
      '</table>';

    // Hide current skills, insert new skills
    $('table.skill_table').toggle();
    $('table.skill_table').after(newskills);

    // Arrays for skill data
    var attributeNames = new Array();
    var attributeValues = new Array();

    // Load skill data
    $('table.skill_table tr th:nth-child(1)').each(function (index) {
      storeData($(this));
    });

    $('table.skill_table tr th:nth-child(3)').each(function (index) {
      storeData($(this));
    });

    // Inject first row of attributes
    $.each(attributeNames, function (index) {
      $('table#new_skill_table tr:eq(0) td:eq(' + index + ')').html(attributeNames[index].substr(0, 3));
      $('table#new_skill_table tr:eq(1) td:eq(' + index + ')').html(attributeValues[index]);
    });

    // Inject second row of attributes (14 attributes for non-goalies)
    if (attributeNames.length == 18) {
      $.each(attributeNames.slice(9), function (index) {
        $('table#new_skill_table tr:eq(2) td:eq(' + index + ')').html(attributeNames[index + 9].substr(0, 3));
        $('table#new_skill_table tr:eq(3) td:eq(' + index + ')').html(attributeValues[index + 9]);
      });
    }
    else {
      $.each(attributeNames.slice(7), function (index) {
        $('table#new_skill_table tr:eq(2) td:eq(' + (index + 3) + ')').html(attributeNames[index + 9].substr(0, 3));
        $('table#new_skill_table tr:eq(3) td:eq(' + (index + 3) + ')').html(attributeValues[index + 9]);
      });
    }

    // Format new skills
    $('table#new_skill_table tr td').css('text-align', 'center');
    $('table#new_skill_table tr td').css('width', '14.2%');
    $('table#new_skill_table tr:nth-child(even)').css('background-color', '#649024');
    $('table#new_skill_table tr td img').css('margin-bottom', '4px');
	$('table#new_skill_table tr:eq(0) td').css('font-weight', 'bold');
	$('table#new_skill_table tr:eq(2) td').css('font-weight', 'bold');
	
	$('span.gk:contains("Goalkeeper")').html('<span class="gk" style="font-size: 1em;">GK </span>');
	$('span.d:contains("Defender")').html('<span class="def" style="font-size: 1em;">D </span>');
	$('span.dm:contains("Defensive Midfielder")').html('<span class="dmid" style="font-size: 1em;">DM </span>');
	$('span.m:contains("Midfielder")').html('<span class="mid" style="font-size: 1em;">M </span>');
	$('span.om:contains("Offensive Midfielder")').html('<span class="omid" style="font-size: 1em;">OM </span>');
	$('span.f:contains("Forward")').html('<span class="fc" style="font-size: 1em;">F </span>');
	$('span.side:contains("Left")').html('<span class="left" style="font-size: 1em;">L</span>');
	$('span.side:contains("Center")').html('<span class="center" style="font-size: 1em;">C</span>');
	$('span.side:contains("Right")').html('<span class="right" style="font-size: 1em;">R</span>');
	
	
	// Format recommendation stars
    $('table.info_table tr td img').css('margin-bottom', '3px');
    $('table.info_table tr td img.flag').css('margin-bottom', '1px');

    // Show player details by default
    if (!$("#player_info").is(":visible")) {
      $("#player_info_arrow").click();
    }
    setClubList();

    // Store attributes to arrays
    function storeData(attribute) {

      // Only store attributes with values
      if (attribute.html() != '') {
        attributeNames.push(attribute.html());
        attributeValues.push(attribute.next().html());
      }
    }

    function sleep(ms) {
      var dt = new Date();
      dt.setTime(dt.getTime() + ms);
      while (new Date().getTime() < dt.getTime());
    }

    function setClubList() {
      // Show clubs for every line of history
      var lastClub;
      $('table.history_table div.club_name').each(function (index) {
        var currentClub = $(this).html();

        // Replace club name on dash, store club name otherwise
        if (currentClub == '-') {
          $(this).html(lastClub);
        }
        else {
          lastClub = currentClub;
        }
      });
    }
  });
});
			
	}
	else {
	
	}

	asi_check = auxx.getElementsByTagName("tr")[6].getElementsByTagName("td")[0].innerHTML;
	//alert(asi_check.search("pics"))
	if (asi_check.search("pics") != -1) {
		var zeile = 0
		var skillindex_yes = 0
	}
	else {
	
	if ( !isNaN( parseFloat(asi_check) ) ) { // ist eine Zahl
	//asi_check = asi_check.search(",") 
	//if (asi_check != -1) {
		var zeile = 0
		var skillindex_yes = 1
	}
	else {
		var zeile = 0
		var skillindex_yes = 0
	}
	}
	//	var asi = asi_check.getElementsByTagName("span")[0].innerHTML;
		
		
// fuer jeden Skill muss so geprueft werden, ob ein img-Tag oder ein span-Tag innerhalb der tabellenzelle vorliegt
	
//Strength
stae_td = aux.getElementsByTagName("tr")[zeile].getElementsByTagName("td")[0];

if(stae_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen
{
var stae = stae_td.getElementsByTagName("span")[0].innerHTML;
//alert ("span " + stae)
}
else if(stae_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen
var stae = stae_td.getElementsByTagName("img")[0].getAttribute("alt");
//alert ("img " + stae)
}
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen
var stae = aux.rows[zeile].cells[1].innerHTML;
//alert ("normal " + stae)
}
//Stamina
kon_td = aux.getElementsByTagName("tr")[zeile+1].getElementsByTagName("td")[0];

if(kon_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen
{
var kon = kon_td.getElementsByTagName("span")[0].innerHTML;
//alert ("span " + kon)
}
else if(kon_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen
var kon = kon_td.getElementsByTagName("img")[0].getAttribute("alt");
//alert ("img " + kon)
}
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen
var kon = aux.rows[zeile+1].cells[1].innerHTML;
//alert ("normal " + kon)
}

//Pace
ges_td = aux.getElementsByTagName("tr")[zeile+2].getElementsByTagName("td")[0];

if(ges_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen
{
var ges = ges_td.getElementsByTagName("span")[0].innerHTML;
//alert ("span " + ges)
}
else if(ges_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen
var ges = ges_td.getElementsByTagName("img")[0].getAttribute("alt");
//alert ("img " + ges)
}
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen
var ges = aux.rows[zeile+2].cells[1].innerHTML;
//alert ("normal " + ges)
}

//Marking
man_td = aux.getElementsByTagName("tr")[zeile+3].getElementsByTagName("td")[0];

if(man_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen
{
var man = man_td.getElementsByTagName("span")[0].innerHTML;
//alert ("span " + man)
}
else if(man_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen
var man = man_td.getElementsByTagName("img")[0].getAttribute("alt");
//alert ("img " + man)
}
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen
var man = aux.rows[zeile+3].cells[1].innerHTML;
//alert ("normal " + man)
}

//Tackling
zwe_td = aux.getElementsByTagName("tr")[zeile+4].getElementsByTagName("td")[0];

if(zwe_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen
{
var zwe = zwe_td.getElementsByTagName("span")[0].innerHTML;
//alert ("span " + zwe)
}
else if(zwe_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen
var zwe = zwe_td.getElementsByTagName("img")[0].getAttribute("alt");
//alert ("img " + zwe)
}
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen
var zwe = aux.rows[zeile+4].cells[1].innerHTML;
//alert ("normal " + zwe)
}

//Workrate
lau_td = aux.getElementsByTagName("tr")[zeile+5].getElementsByTagName("td")[0];

if(lau_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen
{
var lau = lau_td.getElementsByTagName("span")[0].innerHTML;
//alert ("span " + lau)
}
else if(lau_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen
var lau = lau_td.getElementsByTagName("img")[0].getAttribute("alt");
//alert ("img " + lau)
}
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen
var lau = aux.rows[zeile+5].cells[1].innerHTML;
//alert ("normal " + lau)
}

//Positioning
ste_td = aux.getElementsByTagName("tr")[zeile+6].getElementsByTagName("td")[0];

if(ste_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen
{
var ste = ste_td.getElementsByTagName("span")[0].innerHTML;
//alert ("span " + ste)
}
else if(ste_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen
var ste = ste_td.getElementsByTagName("img")[0].getAttribute("alt");
//alert ("img " + ste)
}
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen
var ste = aux.rows[zeile+6].cells[1].innerHTML;
//alert ("normal " + ste)
}

//Passing
pass_td = aux.getElementsByTagName("tr")[zeile].getElementsByTagName("td")[1];

if(pass_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen
{
var pass = pass_td.getElementsByTagName("span")[0].innerHTML;
//alert ("span " + pass)
}
else if(pass_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen
var pass = pass_td.getElementsByTagName("img")[0].getAttribute("alt");
//alert ("img " + pass)
}
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen
var pass = aux.rows[zeile].cells[3].innerHTML;
//alert ("normal " + pass)
}

//Crossing
fla_td = aux.getElementsByTagName("tr")[zeile+1].getElementsByTagName("td")[1];

if(fla_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen
{
var fla = fla_td.getElementsByTagName("span")[0].innerHTML;
//alert ("span " + fla)
}
else if(fla_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen
var fla = fla_td.getElementsByTagName("img")[0].getAttribute("alt");
//alert ("img " + fla)
}
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen
var fla = aux.rows[zeile+1].cells[3].innerHTML;
//alert ("normal " + fla)
}

//Technique
tec_td = aux.getElementsByTagName("tr")[zeile+2].getElementsByTagName("td")[1];

if(tec_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen
{
var tec = tec_td.getElementsByTagName("span")[0].innerHTML;
//alert ("span " + tec)
}
else if(tec_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen
var tec = tec_td.getElementsByTagName("img")[0].getAttribute("alt");
//alert ("img " + tec)
}
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen
var tec = aux.rows[zeile+2].cells[3].innerHTML;
//alert ("normal " + tec)
}

//Heading
kop_td = aux.getElementsByTagName("tr")[zeile+3].getElementsByTagName("td")[1];

if(kop_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen
{
var kop = kop_td.getElementsByTagName("span")[0].innerHTML;
//alert ("span " + kop)
}
else if(kop_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen
var kop = kop_td.getElementsByTagName("img")[0].getAttribute("alt");
//alert ("img " + kop)
}
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen
var kop = aux.rows[zeile+3].cells[3].innerHTML;
//alert ("normal " + kop)
}

//Shooting
tor_td = aux.getElementsByTagName("tr")[zeile+4].getElementsByTagName("td")[1];

if(tor_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen
{
var tor = tor_td.getElementsByTagName("span")[0].innerHTML;
//alert ("span " + tor)
}
else if(tor_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen
var tor = tor_td.getElementsByTagName("img")[0].getAttribute("alt");
//alert ("img " + tor)
}
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen
var tor = aux.rows[zeile+4].cells[3].innerHTML;
//alert ("normal " + tor)
}

//Longshots
wei_td = aux.getElementsByTagName("tr")[zeile+5].getElementsByTagName("td")[1];

if(wei_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen
{
var wei = wei_td.getElementsByTagName("span")[0].innerHTML;
//alert ("span " + wei)
}
else if(wei_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen
var wei = wei_td.getElementsByTagName("img")[0].getAttribute("alt");
//alert ("img " + wei)
}
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen
var wei = aux.rows[zeile+5].cells[3].innerHTML;
//alert ("normal " + wei)
}

//Setpieces
sta_td = aux.getElementsByTagName("tr")[zeile+6].getElementsByTagName("td")[1];

if(sta_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen
{
var sta = sta_td.getElementsByTagName("span")[0].innerHTML;
//alert ("span " + sta)
}
else if(sta_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen
var sta = sta_td.getElementsByTagName("img")[0].getAttribute("alt");
//alert ("img " + sta)
}
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen
var sta = aux.rows[zeile+6].cells[3].innerHTML;
//alert ("normal " + sta)
}



//LP, XP, ASI und Gehalt auslesen
		
		//Playername
		var name = document.title; // holt den Titel-Tag
		name = name.substring(0,name.length-20);
		//alert(name)	

		//Country
		country = document.getElementsByTagName("img")[2].getAttribute("src");
			switch (country) {
		
				case ("/pics/flags/gradient/de.png"):
					country = "Germany";
					//alert(country)
				break;

				default:
					country = "Country not included yet";
					//alert(country)
			}
		
		verein_td = auxx.getElementsByTagName("tr")[1].getElementsByTagName("td")[0];
		var verein = verein_td.getElementsByTagName("a")[0].innerHTML;
		var clubid = verein_td.getElementsByTagName("a")[0].getAttribute("href");
		clubid = clubid.substring(6,clubid.length-1);
		//alert(verein)
		//alert(clubid)

		//Routine
		var rou = auxx.rows[zeile+skillindex_yes+7].cells[1].innerHTML;
		//alert(rou)

		//Wage
		gehalt_td = auxx.getElementsByTagName("tr")[4].getElementsByTagName("td")[0];
		var gehalt = gehalt_td.getElementsByTagName("span")[0].innerHTML;
		//alert(gehalt)		
		
		//var asi = auxx.rows[5].cells[1].innerHTML;
		//asi = asi.replace("&nbsp;", "");
		//alert(asi)
		
/*		var status = auxx.rows[6].cells[1].innerHTML;
		if (status == '<img src="/pics/mini_green_check.png"> ') {
		status = "Gesund";
		//alert(status)
		}

		//status = status.substring(0,6);
		if (status == "Gesund") {
			status = status;
			//alert(status)
		}
		else if(aux.rows[7].cells[0].getElementsByTagName("img")[0].getAttribute("title") == "Dieser Spieler ist gesperrt"){
				var status = aux.rows[7].cells[0].getElementsByTagName("span")[0].innerHTML;
				alert(status)
				status = status.replace("&nbsp;", "");
				status = status.replace("&nbsp;", "");
				alert(status)
				status = 'Sperre:' + status;
		}
		else if(aux.rows[7].cells[0].getElementsByTagName("img")[0].getAttribute("title") == "Dieser Spieler ist verletzt") {
				var status = aux.rows[7].cells[0].innerHTML;
				status = status.substring(130,status.length-69);
				status = 'Verletzung:' + status;
		}
*/		
/*		alter_td = auxx.getElementsByTagName("tr")[2].getElementsByTagName("td")[0];		
		var alter = auxx.rows[2].cells[1].innerHTML;
			alter = alter.substring(24,alter.length-70);
			alter_year = alter.substring(0,2);
			alter_month = alter.substring(3,alter.length);
			alter_month = alter_month.replace("Jahre","");
			alter_month = alter_month.replace("Monate","");
			alter_month = alter_month.replace(/ /i,"");
			alter = alter_year + "-" + alter_month;
*/			//alert(alter)


		//Position
		var pos_zweinull = document.getElementsByTagName("strong")[1].getElementsByTagName("span"); // holt alle Spanelemente
		var poslength = pos_zweinull.length;
		//alert (poslength)
		if (poslength == 2) {
			var pos = document.getElementsByTagName("strong")[1].getElementsByTagName("span")[1].innerHTML;
			//alert(pos)
		}
		else if (poslength == 3) {
			var pos1 = document.getElementsByTagName("strong")[1].getElementsByTagName("span")[1].innerHTML;
			var pos2 = document.getElementsByTagName("strong")[1].getElementsByTagName("span")[2].innerHTML;
			pos = pos1 + pos2;
			//alert(pos)
		}
		else if (poslength == 5) {
			var pos1 = document.getElementsByTagName("strong")[1].getElementsByTagName("span")[1].innerHTML;
			var pos2 = document.getElementsByTagName("strong")[1].getElementsByTagName("span")[2].innerHTML;
			var pos3 = document.getElementsByTagName("strong")[1].getElementsByTagName("span")[3].innerHTML;
			var pos4 = document.getElementsByTagName("strong")[1].getElementsByTagName("span")[4].innerHTML;
			pos = pos1 + pos2 + pos3 + pos4;
			//alert(pos)
		}

		switch (pos) {
		case "Bramkarz":	pos = "GK"; break;
		
		case "Obronca lewy": pos = "D L"; break;
		case "Obronca srodkowy": pos = "D C"; break;
		case "Obronca prawy": pos = "D R"; break;
		case "Obronca srodkowy/prawy": pos = "D CR"; break;
		case "Obronca prawy/srodkowy": pos = "D RC"; break;
		case "Obronca lewy/prawy": pos = "D LR"; break;
		case "Obronca prawy/lewy": pos = "D RL"; break;
		case "Obronca lewy/srodkowy": pos = "D LC"; break;
		case "Obronca srodkowy/lewy": pos = "D CL"; break;
		
		case "Obronca/Defensywny pomocnik lewy": pos = "D/DM L"; break;
		case "Defensywny pomocnik/Obronca lewy": pos = "DM/D L"; break;
		case "Obronca/Defensywny pomocnik prawy": pos = "D/DM R"; break;
		case "Defensywny pomocnik/Obronca prawy": pos = "DM/D R"; break;
		case "Obronca/Defensywny pomocnik srodkowy": pos = "D/DM C"; break;
		case "Defensywny pomocnik/Obronca srodkowy": pos = "DM/D C"; break;
		
		case "Obronca/Pomocnik lewy": pos = "D/M L"; break;
		case "Pomocnik/Obronca lewy": pos = "M/D L"; break;
		case "Obronca/Pomocnik prawy": pos = "D/M R"; break;
		case "Pomocnik/Obronca prawy": pos = "M/D R"; break;
		case "Obronca/Pomocnik srodkowy": pos = "D/M C"; break;
		case "Pomocnik/Obronca srodkowy": pos = "M/D C"; break;
		
		case "Obronca lewy/Napastnik": pos = "D L, F"; break; 
        case "Obronca srodkowy/Napastnik": pos = "D C, F"; break; 
        case "Obronca prawy/Napastnik": pos = "D R, F"; break; 
        case "Napastnik/Obronca lewy": pos = "F, D L"; break; 
        case "Napastnik/Obronca srodkowy": pos = "F, D C"; break; 
        case "Napastnik/Obronca prawy": pos = "F, D R"; break; 
		
		case "Defensywny pomocnik lewy": pos = "DM L"; break;
		case "Defensywny pomocnik srodkowy": pos = "DM C"; break;
		case "Defensywny pomocnik prawy": pos = "DM R"; break;
		case "Defensywny pomocnik lewy/srodkowy": pos = "DM LC"; break;
		case "Defensywny pomocnik srodkowy/lewy": pos = "DM CL"; break;
		case "Defensywny pomocnik srodkowy/prawy": pos = "DM CR"; break;
		case "Defensywny pomocnik prawy/srodkowy": pos = "DM RC"; break;
		case "Defensywny pomocnik lewy/prawy": pos = "DM LR"; break;
		case "Defensywny pomocnik prawy/lewy": pos = "DM RL"; break;
		
		case "Defensywny pomocnik/Pomocnik lewy": pos = "DM/M L"; break;
		case "Pomocnik/Defensywny pomocnik lewy": pos = "M/DM L"; break;
		case "Defensywny pomocnik/Pomocnik srodkowy": pos = "DM/M C"; break;
		case "Pomocnik/Defensywny pomocnik srodkowy": pos = "M/DM C"; break;
		case "Defensywny pomocnik/Pomocnik prawy": pos = "DM/M R"; break;
		case "Pomocnik/Defensywny pomocnik prawy": pos = "M/DM R"; break;
		
		case "Defensywny pomocnik lewy/Napastnik": pos = "DM L, F"; break;
		case "Napastnik/Defensywny pomocnik lewy": pos = "F, DM L"; break;
		case "Defensywny pomocnik srodkowy/Napastnik": pos = "DM C, F"; break;
		case "Napastnik/Defensywny pomocnik srodkowy": pos = "F, DM C"; break;
		case "Defensywny pomocnik prawy/Napastnik": pos = "DM R, F"; break;
		case "Napastnik/Defensywny pomocnik prawy": pos = "F, DM R"; break;
		
		case "Pomocnik lewy": pos = "M L"; break;
		case "Pomocnik srodkowy": pos = "M C"; break;
		case "Pomocnik prawy": pos = "M R"; break;
		case "Pomocnik lewy/srodkowy": pos = "M LC"; break;
		case "Pomocnik srodkowy/lewy": pos = "M CL"; break;
		case "Pomocnik lewy/prawy": pos = "M LR"; break;
		case "Pomocnik prawy/lewy": pos = "M RL"; break;
		case "Pomocnik srodkowy/prawy": pos = "M CR"; break;
		case "Pomocnik prawy/srodkowy": pos = "M RC"; break;
		
		case "Pomocnik lewy/Napastnik": pos = "M L, F"; break;
		case "Pomocnik srodkowy/Napastnik": pos = "M C, F"; break;
		case "Pomocnik prawy/Napastnik": pos = "M R, F"; break;
		case "Napastnik/Pomocnik lewy": pos = "F, M L"; break;
		case "Napastnik/Pomocnik srodkowy": pos = "F, M C"; break;
		case "Napastnik/Pomocnik prawy": pos = "F, M R"; break;
	
		
		case "Pomocnik/Ofensywny pomocnik lewy": pos = "M/OM L"; break;
		case "Ofensywny pomocnik/Pomocnik lewy": pos = "OM/M L"; break;
		case "Pomocnik/Ofensywny pomocnik srodkowy": pos = "M/OM C"; break;
		case "Ofensywny pomocnik/Pomocnik srodkowy": pos = "OM/M C"; break;
		case "Pomocnik/Ofensywny pomocnik prawy": pos = "M/OM R"; break;
		case "Ofensywny pomocnik/Pomocnik prawy": pos = "OM/M R"; break;
		
		case "Ofensywny pomocnik lewy": pos = "OM L"; break;
		case "Ofensywny pomocnik srodkowy": pos = "OM C"; break;
		case "Ofensywny pomocnik prawy": pos = "OM R"; break;
		case "Ofensywny pomocnik lewy/srodkowy": pos = "OM LC"; break;
		case "Ofensywny pomocnik srodkowy/lewy": pos = "OM CL"; break;
		case "Ofensywny pomocnik srodkowy/prawy": pos = "OM CR"; break;
		case "Ofensywny pomocnik prawy/srodkowy": pos = "OM RC"; break;
		case "Ofensywny pomocnik lewy/prawy": pos = "OM LR"; break
		case "Ofensywny pomocnik prawy/lewy": pos = "OM RL"; break
		
		case "Ofensywny pomocnik lewy/Napastnik": pos = "OM L, F"; break;
		case "Napastnik/Ofensywny pomocnik lewy": pos = "F, OM L "; break;
		case "Ofensywny pomocnik srodkowy/Napastnik": pos = "OM C, F"; break;
		case "Napastnik/Ofensywny pomocnik srodkowy": pos = "F, OM C"; break;
		case "Ofensywny pomocnik prawy/Napastnik": pos = "OM R, F"; break;
		case "Napastnik/Ofensywny pomocnik prawy": pos = "F, OM R"; break;
		
		case "Napastnik": pos = "F"; break;
		
		default: alert("TM2.0 currently only works in English. Please contact me if you want a different language version.")
		}

		//alert ("pos: " + pos)
		stae=parseInt(stae);
		kon=parseInt(kon);
		ges=parseInt(ges);
		man=parseInt(man);
		zwe=parseInt(zwe);
		lau=parseInt(lau);
		ste=parseInt(ste);
		pass=parseInt(pass);
		fla=parseInt(fla);
		tec=parseInt(tec);
		kop=parseInt(kop);
		tor=parseInt(tor);
		wei=parseInt(wei);
		sta=parseInt(sta);
		abw=parseInt(abw);
		
		// Skillsummen berechnen je nachdem wie deinen Positionen heissen
				
	switch (pos) {

		case "GK":
//		alert ("case gk")

				//Abwurf
				abw_td = aux.getElementsByTagName("tr")[zeile+7].getElementsByTagName("td")[1];

				if(abw_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen
				{
				var abw = abw_td.getElementsByTagName("span")[0].innerHTML;
				//alert ("span " + abw)
				}
				else if(abw_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen
				var abw = abw_td.getElementsByTagName("img")[0].getAttribute("alt");
				//alert ("img " + abw)
				}
				else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen
				var abw = aux.rows[zeile+7].cells[3].innerHTML;
				//alert ("normal " + abw)
				}
			abw=parseInt(abw);
			//GK-Skills
			//pass = Handling .:. tec = Reflexes .:. stae = Strength .:. kon = Stamina .:. ges = Pace .:. wei = Communication .:. sta = Kicking .:. abw = Throwing .:. tor = Jumping .:. kop = Arial .:. fla = One //
			//var skillsumme = (((10.83333*pass) + (9.999982*tec) + 5.833338*(stae+ges+tor+fla+kop))/10)*(1+rou_factor*rou);
			//var skillsumme = (((10.83333*pass) + (9.999982*tec) + 5.833338*(stae+ges+zwe+ste+kop)+0.00*(kon+tor+wei+sta))/10)*(1+rou_factor*rou);
			var skillsumme = ((7.46268654*(pass + tec) + 5.223881*(fla + kop + tor) + 3.73134327*(stae + kon + ges + wei) + 2.238806*(sta + abw))/10)*(1+rou_factor*rou);
		break;

		case "Defender ":
		case "D C": 
//		alert ("case dc")		
			var skillsumme = ((6.98324*(man + zwe + stae + kop + ges) + 4.067738*(pass + fla + tec) + 0.5761173*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme = ((5.263158*stae + 2.631579*kon + 3.94736838*ges + 7.236842*man + 6.57894754*zwe + 3.28947377*lau + 3.94736838*ste + 3.28947377*pass + 2.631579*fla + 1.31578946*tec + 5.92105246*kop + 0.657894731*tor + 1.31578946*wei + 1.97368419*sta)/10)*(1+rou_factor*rou);
		break;

		case "D L":
//		alert ("case dl")
			var skillsumme = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + ste) + 0.6601167*(kon + lau + pass + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme = ((3.84615374*stae + 2.56410265*kon + 5.769231*ges + 5.769231*man + 6.41025639*zwe + 3.84615374*lau + 3.20512819*ste + 1.92307687*pass + 5.1282053*fla + 3.20512819*tec + 4.48717928*kop + 0.641025662*tor + 1.28205132*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
		break;

		case "D R":
//		alert ("case dr")		
			var skillsumme = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + ste) + 0.6601167*(kon + lau + pass + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme = ((3.84615374*stae + 2.56410265*kon + 5.769231*ges + 5.769231*man + 6.41025639*zwe + 3.84615374*lau + 3.20512819*ste + 1.92307687*pass + 5.1282053*fla + 3.20512819*tec + 4.48717928*kop + 0.641025662*tor + 1.28205132*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
		break;

		case "D LR":
//		alert ("case dlr")
			var skillsumme = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + ste) + 0.6601167*(kon + lau + pass + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme = ((3.84615374*stae + 2.56410265*kon + 5.769231*ges + 5.769231*man + 6.41025639*zwe + 3.84615374*lau + 3.20512819*ste + 1.92307687*pass + 5.1282053*fla + 3.20512819*tec + 4.48717928*kop + 0.641025662*tor + 1.28205132*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
		break;
		
		case "D RL":
//		alert ("case dlr")
			var skillsumme = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + ste) + 0.6601167*(kon + lau + pass + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme = ((3.84615374*stae + 2.56410265*kon + 5.769231*ges + 5.769231*man + 6.41025639*zwe + 3.84615374*lau + 3.20512819*ste + 1.92307687*pass + 5.1282053*fla + 3.20512819*tec + 4.48717928*kop + 0.641025662*tor + 1.28205132*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
		break;

		case "D CR":
			var skillsumme1 = ((6.98324*(man + zwe + stae + kop + ges) + 4.067738*(pass + fla + tec) + 0.5761173*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + ste) + 0.6601167*(kon + lau + pass + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((5.263158*stae + 2.631579*kon + 3.94736838*ges + 7.236842*man + 6.57894754*zwe + 3.28947377*lau + 3.94736838*ste + 3.28947377*pass + 2.631579*fla + 1.31578946*tec + 5.92105246*kop + 0.657894731*tor + 1.31578946*wei + 1.97368419*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.84615374*stae + 2.56410265*kon + 5.769231*ges + 5.769231*man + 6.41025639*zwe + 3.84615374*lau + 3.20512819*ste + 1.92307687*pass + 5.1282053*fla + 3.20512819*tec + 4.48717928*kop + 0.641025662*tor + 1.28205132*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "D RC":
			var skillsumme1 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + ste) + 0.6601167*(kon + lau + pass + tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((6.98324*(man + zwe + stae + kop + ges) + 4.067738*(pass + fla + tec) + 0.5761173*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.84615374*stae + 2.56410265*kon + 5.769231*ges + 5.769231*man + 6.41025639*zwe + 3.84615374*lau + 3.20512819*ste + 1.92307687*pass + 5.1282053*fla + 3.20512819*tec + 4.48717928*kop + 0.641025662*tor + 1.28205132*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((5.263158*stae + 2.631579*kon + 3.94736838*ges + 7.236842*man + 6.57894754*zwe + 3.28947377*lau + 3.94736838*ste + 3.28947377*pass + 2.631579*fla + 1.31578946*tec + 5.92105246*kop + 0.657894731*tor + 1.31578946*wei + 1.97368419*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "D LC":
			var skillsumme1 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + ste) + 0.6601167*(kon + lau + pass + tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((6.98324*(man + zwe + stae + kop + ges) + 4.067738*(pass + fla + tec) + 0.5761173*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.84615374*stae + 2.56410265*kon + 5.769231*ges + 5.769231*man + 6.41025639*zwe + 3.84615374*lau + 3.20512819*ste + 1.92307687*pass + 5.1282053*fla + 3.20512819*tec + 4.48717928*kop + 0.641025662*tor + 1.28205132*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);			
			//var skillsumme2 = ((5.263158*stae + 2.631579*kon + 3.94736838*ges + 7.236842*man + 6.57894754*zwe + 3.28947377*lau + 3.94736838*ste + 3.28947377*pass + 2.631579*fla + 1.31578946*tec + 5.92105246*kop + 0.657894731*tor + 1.31578946*wei + 1.97368419*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;		
		
		case "D CL":
			var skillsumme1 = ((6.98324*(man + zwe + stae + kop + ges) + 4.067738*(pass + fla + tec) + 0.5761173*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + ste) + 0.6601167*(kon + lau + pass + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((5.263158*stae + 2.631579*kon + 3.94736838*ges + 7.236842*man + 6.57894754*zwe + 3.28947377*lau + 3.94736838*ste + 3.28947377*pass + 2.631579*fla + 1.31578946*tec + 5.92105246*kop + 0.657894731*tor + 1.31578946*wei + 1.97368419*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.84615374*stae + 2.56410265*kon + 5.769231*ges + 5.769231*man + 6.41025639*zwe + 3.84615374*lau + 3.20512819*ste + 1.92307687*pass + 5.1282053*fla + 3.20512819*tec + 4.48717928*kop + 0.641025662*tor + 1.28205132*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);			
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;		

		case "D/DM C":
			var skillsumme1 = ((6.98324*(man + zwe + stae + kop + ges) + 4.067738*(pass + fla + tec) + 0.5761173*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((5.263158*(ste + lau + pass + man + zwe + stae + kop) + 3.070175*(kon + ges + fla + tec) + 0.4385965*(tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((5.263158*stae + 2.631579*kon + 3.94736838*ges + 7.236842*man + 6.57894754*zwe + 3.28947377*lau + 3.94736838*ste + 3.28947377*pass + 2.631579*fla + 1.31578946*tec + 5.92105246*kop + 0.657894731*tor + 1.31578946*wei + 1.97368419*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.88654542*stae + 4.12940073*kon + 3.42679548*ges + 4.31633234*man + 4.174524*zwe + 4.978852*lau + 4.488497*ste + 4.69665146*pass + 3.00994468*fla + 3.15018058*tec + 2.76461983*kop + 2.23897719*tor + 3.171397*wei + 1.94508481*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "DM/D C":
			var skillsumme1 = ((5.263158*(ste + lau + pass + man + zwe + stae + kop) + 3.070175*(kon + ges + fla + tec) + 0.4385965*(tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((6.98324*(man + zwe + stae + kop + ges) + 4.067738*(pass + fla + tec) + 0.5761173*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.88654542*stae + 4.12940073*kon + 3.42679548*ges + 4.31633234*man + 4.174524*zwe + 4.978852*lau + 4.488497*ste + 4.69665146*pass + 3.00994468*fla + 3.15018058*tec + 2.76461983*kop + 2.23897719*tor + 3.171397*wei + 1.94508481*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((5.263158*stae + 2.631579*kon + 3.94736838*ges + 7.236842*man + 6.57894754*zwe + 3.28947377*lau + 3.94736838*ste + 3.28947377*pass + 2.631579*fla + 1.31578946*tec + 5.92105246*kop + 0.657894731*tor + 1.31578946*wei + 1.97368419*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;

		case "D/DM R":
			var skillsumme1 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + ste) + 0.6601167*(kon + lau + pass + tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + pass) + 0.6601167*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.84615374*stae + 2.56410265*kon + 5.769231*ges + 5.769231*man + 6.41025639*zwe + 3.84615374*lau + 3.20512819*ste + 1.92307687*pass + 5.1282053*fla + 3.20512819*tec + 4.48717928*kop + 0.641025662*tor + 1.28205132*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.1392417*stae + 3.07755566*kon + 5.25320959*ges + 4.238464*man + 4.91002226*zwe + 4.84742928*lau + 3.75742078*ste + 3.173591*pass + 5.093115*fla + 3.4703362*tec + 2.83058333*kop + 2.089457*tor + 2.735374*wei + 1.704412*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "DM/D R":
			var skillsumme1 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + ste) + 0.6601167*(kon + lau + pass + tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + pass) + 0.6601167*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.84615374*stae + 2.56410265*kon + 5.769231*ges + 5.769231*man + 6.41025639*zwe + 3.84615374*lau + 3.20512819*ste + 1.92307687*pass + 5.1282053*fla + 3.20512819*tec + 4.48717928*kop + 0.641025662*tor + 1.28205132*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.1392417*stae + 3.07755566*kon + 5.25320959*ges + 4.238464*man + 4.91002226*zwe + 4.84742928*lau + 3.75742078*ste + 3.173591*pass + 5.093115*fla + 3.4703362*tec + 2.83058333*kop + 2.089457*tor + 2.735374*wei + 1.704412*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;

		case "D/DM L":
			var skillsumme1 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + ste) + 0.6601167*(kon + lau + pass + tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + pass) + 0.6601167*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.84615374*stae + 2.56410265*kon + 5.769231*ges + 5.769231*man + 6.41025639*zwe + 3.84615374*lau + 3.20512819*ste + 1.92307687*pass + 5.1282053*fla + 3.20512819*tec + 4.48717928*kop + 0.641025662*tor + 1.28205132*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.1392417*stae + 3.07755566*kon + 5.25320959*ges + 4.238464*man + 4.91002226*zwe + 4.84742928*lau + 3.75742078*ste + 3.173591*pass + 5.093115*fla + 3.4703362*tec + 2.83058333*kop + 2.089457*tor + 2.735374*wei + 1.704412*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "DM/D L":
			var skillsumme1 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + ste) + 0.6601167*(kon + lau + pass + tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + pass) + 0.6601167*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.84615374*stae + 2.56410265*kon + 5.769231*ges + 5.769231*man + 6.41025639*zwe + 3.84615374*lau + 3.20512819*ste + 1.92307687*pass + 5.1282053*fla + 3.20512819*tec + 4.48717928*kop + 0.641025662*tor + 1.28205132*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.1392417*stae + 3.07755566*kon + 5.25320959*ges + 4.238464*man + 4.91002226*zwe + 4.84742928*lau + 3.75742078*ste + 3.173591*pass + 5.093115*fla + 3.4703362*tec + 2.83058333*kop + 2.089457*tor + 2.735374*wei + 1.704412*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "D/M C":
			var skillsumme1 = ((6.98324*(man + zwe + stae + kop + ges) + 4.067738*(pass + fla + tec) + 0.5761173*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((6.182408*(ste + lau + man + zwe + pass + tec) + 3.604903*(kon + kop + stae) + 0.5227109*(ges + fla + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((5.263158*stae + 2.631579*kon + 3.94736838*ges + 7.236842*man + 6.57894754*zwe + 3.28947377*lau + 3.94736838*ste + 3.28947377*pass + 2.631579*fla + 1.31578946*tec + 5.92105246*kop + 0.657894731*tor + 1.31578946*wei + 1.97368419*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.57142854*stae + 4.16666651*kon + 3.57142854*ges + 4.16666651*man + 3.57142854*zwe + 4.76190472*lau + 4.76190472*ste + 4.76190472*pass + 2.38095236*fla + 3.57142854*tec + 2.38095236*kop + 2.97619057*tor + 3.57142854*wei + 1.78571427*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "M/D C":
			var skillsumme1 = ((6.182408*(ste + lau + man + zwe + pass + tec) + 3.604903*(kon + kop + stae) + 0.5227109*(ges + fla + tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((6.98324*(man + zwe + stae + kop + ges) + 4.067738*(pass + fla + tec) + 0.5761173*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.57142854*stae + 4.16666651*kon + 3.57142854*ges + 4.16666651*man + 3.57142854*zwe + 4.76190472*lau + 4.76190472*ste + 4.76190472*pass + 2.38095236*fla + 3.57142854*tec + 2.38095236*kop + 2.97619057*tor + 3.57142854*wei + 1.78571427*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((5.263158*stae + 2.631579*kon + 3.94736838*ges + 7.236842*man + 6.57894754*zwe + 3.28947377*lau + 3.94736838*ste + 3.28947377*pass + 2.631579*fla + 1.31578946*tec + 5.92105246*kop + 0.657894731*tor + 1.31578946*wei + 1.97368419*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "D/M R":
			var skillsumme1 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + ste) + 0.6601167*(kon + lau + pass + tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((5.041541*(ste + lau + man + zwe + pass + tec + fla + ges) + 2.945619*(kon + kop + stae) + 0.4154079*(tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.84615374*stae + 2.56410265*kon + 5.769231*ges + 5.769231*man + 6.41025639*zwe + 3.84615374*lau + 3.20512819*ste + 1.92307687*pass + 5.1282053*fla + 3.20512819*tec + 4.48717928*kop + 0.641025662*tor + 1.28205132*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.22580647*stae + 3.22580647*kon + 4.83871*ges + 3.76344085*man + 4.30107546*zwe + 4.83871*lau + 4.30107546*ste + 3.22580647*pass + 5.376344*fla + 3.76344085*tec + 1.61290324*kop + 2.688172*tor + 3.22580647*wei + 1.61290324*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "M/D R":
			var skillsumme1 = ((5.041541*(ste + lau + man + zwe + pass + tec + fla + ges) + 2.945619*(kon + kop + stae) + 0.4154079*(tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + ste) + 0.6601167*(kon + lau + pass + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.22580647*stae + 3.22580647*kon + 4.83871*ges + 3.76344085*man + 4.30107546*zwe + 4.83871*lau + 4.30107546*ste + 3.22580647*pass + 5.376344*fla + 3.76344085*tec + 1.61290324*kop + 2.688172*tor + 3.22580647*wei + 1.61290324*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.84615374*stae + 2.56410265*kon + 5.769231*ges + 5.769231*man + 6.41025639*zwe + 3.84615374*lau + 3.20512819*ste + 1.92307687*pass + 5.1282053*fla + 3.20512819*tec + 4.48717928*kop + 0.641025662*tor + 1.28205132*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "D/M L":
			var skillsumme1 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + ste) + 0.6601167*(kon + lau + pass + tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((5.041541*(ste + lau + man + zwe + pass + tec + fla + ges) + 2.945619*(kon + kop + stae) + 0.4154079*(tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.84615374*stae + 2.56410265*kon + 5.769231*ges + 5.769231*man + 6.41025639*zwe + 3.84615374*lau + 3.20512819*ste + 1.92307687*pass + 5.1282053*fla + 3.20512819*tec + 4.48717928*kop + 0.641025662*tor + 1.28205132*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.22580647*stae + 3.22580647*kon + 4.83871*ges + 3.76344085*man + 4.30107546*zwe + 4.83871*lau + 4.30107546*ste + 3.22580647*pass + 5.376344*fla + 3.76344085*tec + 1.61290324*kop + 2.688172*tor + 3.22580647*wei + 1.61290324*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "M/D L":
			var skillsumme1 = ((5.041541*(ste + lau + man + zwe + pass + tec + fla + ges) + 2.945619*(kon + kop + stae) + 0.4154079*(tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + ste) + 0.6601167*(kon + lau + pass + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.22580647*stae + 3.22580647*kon + 4.83871*ges + 3.76344085*man + 4.30107546*zwe + 4.83871*lau + 4.30107546*ste + 3.22580647*pass + 5.376344*fla + 3.76344085*tec + 1.61290324*kop + 2.688172*tor + 3.22580647*wei + 1.61290324*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.84615374*stae + 2.56410265*kon + 5.769231*ges + 5.769231*man + 6.41025639*zwe + 3.84615374*lau + 3.20512819*ste + 1.92307687*pass + 5.1282053*fla + 3.20512819*tec + 4.48717928*kop + 0.641025662*tor + 1.28205132*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;

		case "D C, F": 
            var skillsumme1 = ((6.98324*(man + zwe + stae + kop + ges) + 4.067738*(pass + fla + tec) + 0.5761173*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou); 
            var skillsumme2 = ((6.903289*(stae + kop + tor + wei) + 4.021492*(kon + ges + lau + ste + tec) + 0.5698469*(man + zwe + fla + pass + sta))/10)*(1+rou_factor*rou); 
            //var skillsumme1 = ((5.263158*stae + 2.631579*kon + 3.94736838*ges + 7.236842*man + 6.57894754*zwe + 3.28947377*lau + 3.94736838*ste + 3.28947377*pass + 2.631579*fla + 1.31578946*tec + 5.92105246*kop + 0.657894731*tor + 1.31578946*wei + 1.97368419*sta)/10)*(1+rou_factor*rou); 
            //var skillsumme2 = ((3.84615374*stae + 2.56410265*kon + 3.84615374*ges + 0.641025662*man + 0.641025662*zwe + 3.20512819*lau + 3.84615374*ste + 3.84615374*pass + 1.28205132*fla + 3.84615374*tec + 6.41025639*kop + 7.69230747*tor + 6.41025639*wei + 1.92307687*sta)/10)*(1+rou_factor*rou); 
            skillsumme1 = new String(skillsumme1.toFixed(2)); 
            skillsumme2 = new String(skillsumme2.toFixed(2)); 
            var skillsumme_str = skillsumme1 + "/" + skillsumme2; 
        break; 

        case "F, D C": 
            var skillsumme1 = ((6.903289*(stae + kop + tor + wei) + 4.021492*(kon + ges + lau + ste + tec) + 0.5698469*(man + zwe + fla + pass + sta))/10)*(1+rou_factor*rou); 
            var skillsumme2 = ((6.98324*(man + zwe + stae + kop + ges) + 4.067738*(pass + fla + tec) + 0.5761173*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou); 
            //var skillsumme1 = ((3.84615374*stae + 2.56410265*kon + 3.84615374*ges + 0.641025662*man + 0.641025662*zwe + 3.20512819*lau + 3.84615374*ste + 3.84615374*pass + 1.28205132*fla + 3.84615374*tec + 6.41025639*kop + 7.69230747*tor + 6.41025639*wei + 1.92307687*sta)/10)*(1+rou_factor*rou); 
            //var skillsumme2 = ((5.263158*stae + 2.631579*kon + 3.94736838*ges + 7.236842*man + 6.57894754*zwe + 3.28947377*lau + 3.94736838*ste + 3.28947377*pass + 2.631579*fla + 1.31578946*tec + 5.92105246*kop + 0.657894731*tor + 1.31578946*wei + 1.97368419*sta)/10)*(1+rou_factor*rou); 
            skillsumme1 = new String(skillsumme1.toFixed(2)); 
            skillsumme2 = new String(skillsumme2.toFixed(2)); 
            var skillsumme_str = skillsumme1 + "/" + skillsumme2; 
        break; 

        case "D L, F": 
            var skillsumme1 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + ste) + 0.6601167*(kon + lau + pass + tor + wei + sta))/10)*(1+rou_factor*rou); 
            var skillsumme2 = ((6.903289*(stae + kop + tor + wei) + 4.021492*(kon + ges + lau + ste + tec) + 0.5698469*(man + zwe + fla + pass + sta))/10)*(1+rou_factor*rou); 
            //var skillsumme1 = ((3.84615374*stae + 2.56410265*kon + 5.769231*ges + 5.769231*man + 6.41025639*zwe + 3.84615374*lau + 3.20512819*ste + 1.92307687*pass + 5.1282053*fla + 3.20512819*tec + 4.48717928*kop + 0.641025662*tor + 1.28205132*wei + 1.92307687*sta)/10)*(1+rou_factor*rou); 
            //var skillsumme2 = ((3.84615374*stae + 2.56410265*kon + 3.84615374*ges + 0.641025662*man + 0.641025662*zwe + 3.20512819*lau + 3.84615374*ste + 3.84615374*pass + 1.28205132*fla + 3.84615374*tec + 6.41025639*kop + 7.69230747*tor + 6.41025639*wei + 1.92307687*sta)/10)*(1+rou_factor*rou); 
            skillsumme1 = new String(skillsumme1.toFixed(2)); 
            skillsumme2 = new String(skillsumme2.toFixed(2)); 
            var skillsumme_str = skillsumme1 + "/" + skillsumme2; 
        break; 

        case "F, D L": 
            var skillsumme1 = ((6.903289*(stae + kop + tor + wei) + 4.021492*(kon + ges + lau + ste + tec) + 0.5698469*(man + zwe + fla + pass + sta))/10)*(1+rou_factor*rou); 
            var skillsumme2 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + ste) + 0.6601167*(kon + lau + pass + tor + wei + sta))/10)*(1+rou_factor*rou); 
            //var skillsumme1 = ((3.84615374*stae + 2.56410265*kon + 3.84615374*ges + 0.641025662*man + 0.641025662*zwe + 3.20512819*lau + 3.84615374*ste + 3.84615374*pass + 1.28205132*fla + 3.84615374*tec + 6.41025639*kop + 7.69230747*tor + 6.41025639*wei + 1.92307687*sta)/10)*(1+rou_factor*rou); 
            //var skillsumme2 = ((3.84615374*stae + 2.56410265*kon + 5.769231*ges + 5.769231*man + 6.41025639*zwe + 3.84615374*lau + 3.20512819*ste + 1.92307687*pass + 5.1282053*fla + 3.20512819*tec + 4.48717928*kop + 0.641025662*tor + 1.28205132*wei + 1.92307687*sta)/10)*(1+rou_factor*rou); 
            skillsumme1 = new String(skillsumme1.toFixed(2)); 
            skillsumme2 = new String(skillsumme2.toFixed(2)); 
            var skillsumme_str = skillsumme1 + "/" + skillsumme2; 
        break; 

        case "D R, F": 
            var skillsumme1 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + ste) + 0.6601167*(kon + lau + pass + tor + wei + sta))/10)*(1+rou_factor*rou); 
            var skillsumme2 = ((6.903289*(stae + kop + tor + wei) + 4.021492*(kon + ges + lau + ste + tec) + 0.5698469*(man + zwe + fla + pass + sta))/10)*(1+rou_factor*rou); 
            //var skillsumme1 = ((3.84615374*stae + 2.56410265*kon + 5.769231*ges + 5.769231*man + 6.41025639*zwe + 3.84615374*lau + 3.20512819*ste + 1.92307687*pass + 5.1282053*fla + 3.20512819*tec + 4.48717928*kop + 0.641025662*tor + 1.28205132*wei + 1.92307687*sta)/10)*(1+rou_factor*rou); 
            //var skillsumme2 = ((3.84615374*stae + 2.56410265*kon + 3.84615374*ges + 0.641025662*man + 0.641025662*zwe + 3.20512819*lau + 3.84615374*ste + 3.84615374*pass + 1.28205132*fla + 3.84615374*tec + 6.41025639*kop + 7.69230747*tor + 6.41025639*wei + 1.92307687*sta)/10)*(1+rou_factor*rou); 
            skillsumme1 = new String(skillsumme1.toFixed(2)); 
            skillsumme2 = new String(skillsumme2.toFixed(2)); 
            var skillsumme_str = skillsumme1 + "/" + skillsumme2; 
        break; 

        case "F, D R": 
            var skillsumme1 = ((6.903289*(stae + kop + tor + wei) + 4.021492*(kon + ges + lau + ste + tec) + 0.5698469*(man + zwe + fla + pass + sta))/10)*(1+rou_factor*rou); 
            var skillsumme2 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + ste) + 0.6601167*(kon + lau + pass + tor + wei + sta))/10)*(1+rou_factor*rou); 
            //var skillsumme1 = ((3.84615374*stae + 2.56410265*kon + 3.84615374*ges + 0.641025662*man + 0.641025662*zwe + 3.20512819*lau + 3.84615374*ste + 3.84615374*pass + 1.28205132*fla + 3.84615374*tec + 6.41025639*kop + 7.69230747*tor + 6.41025639*wei + 1.92307687*sta)/10)*(1+rou_factor*rou); 
            //var skillsumme2 = ((3.84615374*stae + 2.56410265*kon + 5.769231*ges + 5.769231*man + 6.41025639*zwe + 3.84615374*lau + 3.20512819*ste + 1.92307687*pass + 5.1282053*fla + 3.20512819*tec + 4.48717928*kop + 0.641025662*tor + 1.28205132*wei + 1.92307687*sta)/10)*(1+rou_factor*rou); 
            skillsumme1 = new String(skillsumme1.toFixed(2)); 
            skillsumme2 = new String(skillsumme2.toFixed(2)); 
            var skillsumme_str = skillsumme1 + "/" + skillsumme2; 
        break; 

		
		case "DM C":
//		alert ("case dmc")		
			var skillsumme = ((5.263158*(ste + lau + pass + man + zwe + stae + kop) + 3.070175*(kon + ges + fla + tec) + 0.4385965*(tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme = ((3.88654542*stae + 4.12940073*kon + 3.42679548*ges + 4.31633234*man + 4.174524*zwe + 4.978852*lau + 4.488497*ste + 4.69665146*pass + 3.00994468*fla + 3.15018058*tec + 2.76461983*kop + 2.23897719*tor + 3.171397*wei + 1.94508481*sta)/10)*(1+rou_factor*rou);
		break;

		case "DM L":
//		alert ("case dml")		
			var skillsumme = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + pass) + 0.6601167*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme = ((3.1392417*stae + 3.07755566*kon + 5.25320959*ges + 4.238464*man + 4.91002226*zwe + 4.84742928*lau + 3.75742078*ste + 3.173591*pass + 5.093115*fla + 3.4703362*tec + 2.83058333*kop + 2.089457*tor + 2.735374*wei + 1.704412*sta)/10)*(1+rou_factor*rou);
		break;

		case "DM R":
//		alert ("case dmr")		
			var skillsumme = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + pass) + 0.6601167*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme = ((3.1392417*stae + 3.07755566*kon + 5.25320959*ges + 4.238464*man + 4.91002226*zwe + 4.84742928*lau + 3.75742078*ste + 3.173591*pass + 5.093115*fla + 3.4703362*tec + 2.83058333*kop + 2.089457*tor + 2.735374*wei + 1.704412*sta)/10)*(1+rou_factor*rou);
		break;

		case "DM LR":
//		alert ("case dmlr")		
			var skillsumme = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + pass) + 0.6601167*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme = ((3.1392417*stae + 3.07755566*kon + 5.25320959*ges + 4.238464*man + 4.91002226*zwe + 4.84742928*lau + 3.75742078*ste + 3.173591*pass + 5.093115*fla + 3.4703362*tec + 2.83058333*kop + 2.089457*tor + 2.735374*wei + 1.704412*sta)/10)*(1+rou_factor*rou);
		break;
		
		case "DM RL":
//		alert ("case dmlr")		
			var skillsumme = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + pass) + 0.6601167*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme = ((3.1392417*stae + 3.07755566*kon + 5.25320959*ges + 4.238464*man + 4.91002226*zwe + 4.84742928*lau + 3.75742078*ste + 3.173591*pass + 5.093115*fla + 3.4703362*tec + 2.83058333*kop + 2.089457*tor + 2.735374*wei + 1.704412*sta)/10)*(1+rou_factor*rou);
		break;

		case "DM CR":
			var skillsumme1 = ((5.263158*(ste + lau + pass + man + zwe + stae + kop) + 3.070175*(kon + ges + fla + tec) + 0.4385965*(tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + pass) + 0.6601167*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.88654542*stae + 4.12940073*kon + 3.42679548*ges + 4.31633234*man + 4.174524*zwe + 4.978852*lau + 4.488497*ste + 4.69665146*pass + 3.00994468*fla + 3.15018058*tec + 2.76461983*kop + 2.23897719*tor + 3.171397*wei + 1.94508481*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.1392417*stae + 3.07755566*kon + 5.25320959*ges + 4.238464*man + 4.91002226*zwe + 4.84742928*lau + 3.75742078*ste + 3.173591*pass + 5.093115*fla + 3.4703362*tec + 2.83058333*kop + 2.089457*tor + 2.735374*wei + 1.704412*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "DM RC":
			var skillsumme1 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + pass) + 0.6601167*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((5.263158*(ste + lau + pass + man + zwe + stae + kop) + 3.070175*(kon + ges + fla + tec) + 0.4385965*(tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.1392417*stae + 3.07755566*kon + 5.25320959*ges + 4.238464*man + 4.91002226*zwe + 4.84742928*lau + 3.75742078*ste + 3.173591*pass + 5.093115*fla + 3.4703362*tec + 2.83058333*kop + 2.089457*tor + 2.735374*wei + 1.704412*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.88654542*stae + 4.12940073*kon + 3.42679548*ges + 4.31633234*man + 4.174524*zwe + 4.978852*lau + 4.488497*ste + 4.69665146*pass + 3.00994468*fla + 3.15018058*tec + 2.76461983*kop + 2.23897719*tor + 3.171397*wei + 1.94508481*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;

		case "DM LC":
			var skillsumme1 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + pass) + 0.6601167*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((5.263158*(ste + lau + pass + man + zwe + stae + kop) + 3.070175*(kon + ges + fla + tec) + 0.4385965*(tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.1392417*stae + 3.07755566*kon + 5.25320959*ges + 4.238464*man + 4.91002226*zwe + 4.84742928*lau + 3.75742078*ste + 3.173591*pass + 5.093115*fla + 3.4703362*tec + 2.83058333*kop + 2.089457*tor + 2.735374*wei + 1.704412*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.88654542*stae + 4.12940073*kon + 3.42679548*ges + 4.31633234*man + 4.174524*zwe + 4.978852*lau + 4.488497*ste + 4.69665146*pass + 3.00994468*fla + 3.15018058*tec + 2.76461983*kop + 2.23897719*tor + 3.171397*wei + 1.94508481*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "DM CL":
			var skillsumme1 = ((5.263158*(ste + lau + pass + man + zwe + stae + kop) + 3.070175*(kon + ges + fla + tec) + 0.4385965*(tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + pass) + 0.6601167*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.88654542*stae + 4.12940073*kon + 3.42679548*ges + 4.31633234*man + 4.174524*zwe + 4.978852*lau + 4.488497*ste + 4.69665146*pass + 3.00994468*fla + 3.15018058*tec + 2.76461983*kop + 2.23897719*tor + 3.171397*wei + 1.94508481*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.1392417*stae + 3.07755566*kon + 5.25320959*ges + 4.238464*man + 4.91002226*zwe + 4.84742928*lau + 3.75742078*ste + 3.173591*pass + 5.093115*fla + 3.4703362*tec + 2.83058333*kop + 2.089457*tor + 2.735374*wei + 1.704412*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;

		case "DM/M C":
			var skillsumme1 = ((5.263158*(ste + lau + pass + man + zwe + stae + kop) + 3.070175*(kon + ges + fla + tec) + 0.4385965*(tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((6.182408*(ste + lau + man + zwe + pass + tec) + 3.604903*(kon + kop + stae) + 0.5227109*(ges + fla + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.88654542*stae + 4.12940073*kon + 3.42679548*ges + 4.31633234*man + 4.174524*zwe + 4.978852*lau + 4.488497*ste + 4.69665146*pass + 3.00994468*fla + 3.15018058*tec + 2.76461983*kop + 2.23897719*tor + 3.171397*wei + 1.94508481*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.57142854*stae + 4.16666651*kon + 3.57142854*ges + 4.16666651*man + 3.57142854*zwe + 4.76190472*lau + 4.76190472*ste + 4.76190472*pass + 2.38095236*fla + 3.57142854*tec + 2.38095236*kop + 2.97619057*tor + 3.57142854*wei + 1.78571427*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "M/DM C":
			var skillsumme1 = ((6.182408*(ste + lau + man + zwe + pass + tec) + 3.604903*(kon + kop + stae) + 0.5227109*(ges + fla + tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((5.263158*(ste + lau + pass + man + zwe + stae + kop) + 3.070175*(kon + ges + fla + tec) + 0.4385965*(tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.57142854*stae + 4.16666651*kon + 3.57142854*ges + 4.16666651*man + 3.57142854*zwe + 4.76190472*lau + 4.76190472*ste + 4.76190472*pass + 2.38095236*fla + 3.57142854*tec + 2.38095236*kop + 2.97619057*tor + 3.57142854*wei + 1.78571427*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.88654542*stae + 4.12940073*kon + 3.42679548*ges + 4.31633234*man + 4.174524*zwe + 4.978852*lau + 4.488497*ste + 4.69665146*pass + 3.00994468*fla + 3.15018058*tec + 2.76461983*kop + 2.23897719*tor + 3.171397*wei + 1.94508481*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;

		case "DM/M R":
			var skillsumme1 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + pass) + 0.6601167*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((5.041541*(ste + lau + man + zwe + pass + tec + fla + ges) + 2.945619*(kon + kop + stae) + 0.4154079*(tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.1392417*stae + 3.07755566*kon + 5.25320959*ges + 4.238464*man + 4.91002226*zwe + 4.84742928*lau + 3.75742078*ste + 3.173591*pass + 5.093115*fla + 3.4703362*tec + 2.83058333*kop + 2.089457*tor + 2.735374*wei + 1.704412*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.22580647*stae + 3.22580647*kon + 4.83871*ges + 3.76344085*man + 4.30107546*zwe + 4.83871*lau + 4.30107546*ste + 3.22580647*pass + 5.376344*fla + 3.76344085*tec + 1.61290324*kop + 2.688172*tor + 3.22580647*wei + 1.61290324*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "M/DM R":
			var skillsumme1 = ((5.041541*(ste + lau + man + zwe + pass + tec + fla + ges) + 2.945619*(kon + kop + stae) + 0.4154079*(tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + pass) + 0.6601167*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.22580647*stae + 3.22580647*kon + 4.83871*ges + 3.76344085*man + 4.30107546*zwe + 4.83871*lau + 4.30107546*ste + 3.22580647*pass + 5.376344*fla + 3.76344085*tec + 1.61290324*kop + 2.688172*tor + 3.22580647*wei + 1.61290324*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.1392417*stae + 3.07755566*kon + 5.25320959*ges + 4.238464*man + 4.91002226*zwe + 4.84742928*lau + 3.75742078*ste + 3.173591*pass + 5.093115*fla + 3.4703362*tec + 2.83058333*kop + 2.089457*tor + 2.735374*wei + 1.704412*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;

		case "DM/M L":
			var skillsumme1 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + pass) + 0.6601167*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((5.041541*(ste + lau + man + zwe + pass + tec + fla + ges) + 2.945619*(kon + kop + stae) + 0.4154079*(tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.1392417*stae + 3.07755566*kon + 5.25320959*ges + 4.238464*man + 4.91002226*zwe + 4.84742928*lau + 3.75742078*ste + 3.173591*pass + 5.093115*fla + 3.4703362*tec + 2.83058333*kop + 2.089457*tor + 2.735374*wei + 1.704412*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.22580647*stae + 3.22580647*kon + 4.83871*ges + 3.76344085*man + 4.30107546*zwe + 4.83871*lau + 4.30107546*ste + 3.22580647*pass + 5.376344*fla + 3.76344085*tec + 1.61290324*kop + 2.688172*tor + 3.22580647*wei + 1.61290324*sta)/10)*(1+rou_factor*rou);			
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "M/DM L":
			var skillsumme1 = ((5.041541*(ste + lau + man + zwe + pass + tec + fla + ges) + 2.945619*(kon + kop + stae) + 0.4154079*(tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + pass) + 0.6601167*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.22580647*stae + 3.22580647*kon + 4.83871*ges + 3.76344085*man + 4.30107546*zwe + 4.83871*lau + 4.30107546*ste + 3.22580647*pass + 5.376344*fla + 3.76344085*tec + 1.61290324*kop + 2.688172*tor + 3.22580647*wei + 1.61290324*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.1392417*stae + 3.07755566*kon + 5.25320959*ges + 4.238464*man + 4.91002226*zwe + 4.84742928*lau + 3.75742078*ste + 3.173591*pass + 5.093115*fla + 3.4703362*tec + 2.83058333*kop + 2.089457*tor + 2.735374*wei + 1.704412*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "DM C, F":
			var skillsumme1 = ((5.263158*(ste + lau + pass + man + zwe + stae + kop) + 3.070175*(kon + ges + fla + tec) + 0.4385965*(tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((6.903289*(stae + kop + tor + wei) + 4.021492*(kon + ges + lau + ste + tec) + 0.5698469*(man + zwe + fla + pass + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.88654542*stae + 4.12940073*kon + 3.42679548*ges + 4.31633234*man + 4.174524*zwe + 4.978852*lau + 4.488497*ste + 4.69665146*pass + 3.00994468*fla + 3.15018058*tec + 2.76461983*kop + 2.23897719*tor + 3.171397*wei + 1.94508481*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.84615374*stae + 2.56410265*kon + 3.84615374*ges + 0.641025662*man + 0.641025662*zwe + 3.20512819*lau + 3.84615374*ste + 3.84615374*pass + 1.28205132*fla + 3.84615374*tec + 6.41025639*kop + 7.69230747*tor + 6.41025639*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "F, DM C":
			var skillsumme1 = ((6.903289*(stae + kop + tor + wei) + 4.021492*(kon + ges + lau + ste + tec) + 0.5698469*(man + zwe + fla + pass + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((5.263158*(ste + lau + pass + man + zwe + stae + kop) + 3.070175*(kon + ges + fla + tec) + 0.4385965*(tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.84615374*stae + 2.56410265*kon + 3.84615374*ges + 0.641025662*man + 0.641025662*zwe + 3.20512819*lau + 3.84615374*ste + 3.84615374*pass + 1.28205132*fla + 3.84615374*tec + 6.41025639*kop + 7.69230747*tor + 6.41025639*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.88654542*stae + 4.12940073*kon + 3.42679548*ges + 4.31633234*man + 4.174524*zwe + 4.978852*lau + 4.488497*ste + 4.69665146*pass + 3.00994468*fla + 3.15018058*tec + 2.76461983*kop + 2.23897719*tor + 3.171397*wei + 1.94508481*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "DM R, F":
			var skillsumme1 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + pass) + 0.6601167*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((6.903289*(stae + kop + tor + wei) + 4.021492*(kon + ges + lau + ste + tec) + 0.5698469*(man + zwe + fla + pass + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.1392417*stae + 3.07755566*kon + 5.25320959*ges + 4.238464*man + 4.91002226*zwe + 4.84742928*lau + 3.75742078*ste + 3.173591*pass + 5.093115*fla + 3.4703362*tec + 2.83058333*kop + 2.089457*tor + 2.735374*wei + 1.704412*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.84615374*stae + 2.56410265*kon + 3.84615374*ges + 0.641025662*man + 0.641025662*zwe + 3.20512819*lau + 3.84615374*ste + 3.84615374*pass + 1.28205132*fla + 3.84615374*tec + 6.41025639*kop + 7.69230747*tor + 6.41025639*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "F, DM R":
			var skillsumme1 = ((6.903289*(stae + kop + tor + wei) + 4.021492*(kon + ges + lau + ste + tec) + 0.5698469*(man + zwe + fla + pass + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + pass) + 0.6601167*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.84615374*stae + 2.56410265*kon + 3.84615374*ges + 0.641025662*man + 0.641025662*zwe + 3.20512819*lau + 3.84615374*ste + 3.84615374*pass + 1.28205132*fla + 3.84615374*tec + 6.41025639*kop + 7.69230747*tor + 6.41025639*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.1392417*stae + 3.07755566*kon + 5.25320959*ges + 4.238464*man + 4.91002226*zwe + 4.84742928*lau + 3.75742078*ste + 3.173591*pass + 5.093115*fla + 3.4703362*tec + 2.83058333*kop + 2.089457*tor + 2.735374*wei + 1.704412*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "DM L, F":
			var skillsumme1 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + pass) + 0.6601167*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((6.903289*(stae + kop + tor + wei) + 4.021492*(kon + ges + lau + ste + tec) + 0.5698469*(man + zwe + fla + pass + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.1392417*stae + 3.07755566*kon + 5.25320959*ges + 4.238464*man + 4.91002226*zwe + 4.84742928*lau + 3.75742078*ste + 3.173591*pass + 5.093115*fla + 3.4703362*tec + 2.83058333*kop + 2.089457*tor + 2.735374*wei + 1.704412*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.84615374*stae + 2.56410265*kon + 3.84615374*ges + 0.641025662*man + 0.641025662*zwe + 3.20512819*lau + 3.84615374*ste + 3.84615374*pass + 1.28205132*fla + 3.84615374*tec + 6.41025639*kop + 7.69230747*tor + 6.41025639*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "F, DM L":
			var skillsumme1 = ((6.903289*(stae + kop + tor + wei) + 4.021492*(kon + ges + lau + ste + tec) + 0.5698469*(man + zwe + fla + pass + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((7.890697*(ges + man + zwe) + 4.605465*(stae + kop + tec + fla + pass) + 0.6601167*(kon + lau + ste + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.84615374*stae + 2.56410265*kon + 3.84615374*ges + 0.641025662*man + 0.641025662*zwe + 3.20512819*lau + 3.84615374*ste + 3.84615374*pass + 1.28205132*fla + 3.84615374*tec + 6.41025639*kop + 7.69230747*tor + 6.41025639*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.1392417*stae + 3.07755566*kon + 5.25320959*ges + 4.238464*man + 4.91002226*zwe + 4.84742928*lau + 3.75742078*ste + 3.173591*pass + 5.093115*fla + 3.4703362*tec + 2.83058333*kop + 2.089457*tor + 2.735374*wei + 1.704412*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;

		case "M C":
//		alert ("case mc")		
			var skillsumme = ((6.182408*(ste + lau + man + zwe + pass + tec) + 3.604903*(kon + kop + stae) + 0.5227109*(ges + fla + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme = ((3.57142854*stae + 4.16666651*kon + 3.57142854*ges + 4.16666651*man + 3.57142854*zwe + 4.76190472*lau + 4.76190472*ste + 4.76190472*pass + 2.38095236*fla + 3.57142854*tec + 2.38095236*kop + 2.97619057*tor + 3.57142854*wei + 1.78571427*sta)/10)*(1+rou_factor*rou);
		break;

		case "M L":
//		alert ("case ml")		
			var skillsumme = ((5.041541*(ste + lau + man + zwe + pass + tec + fla + ges) + 2.945619*(kon + kop + stae) + 0.4154079*(tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme = ((3.22580647*stae + 3.22580647*kon + 4.83871*ges + 3.76344085*man + 4.30107546*zwe + 4.83871*lau + 4.30107546*ste + 3.22580647*pass + 5.376344*fla + 3.76344085*tec + 1.61290324*kop + 2.688172*tor + 3.22580647*wei + 1.61290324*sta)/10)*(1+rou_factor*rou);
		break;

		case "M R":
//		alert ("case mr")		
			var skillsumme = ((5.041541*(ste + lau + man + zwe + pass + tec + fla + ges) + 2.945619*(kon + kop + stae) + 0.4154079*(tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme = ((3.22580647*stae + 3.22580647*kon + 4.83871*ges + 3.76344085*man + 4.30107546*zwe + 4.83871*lau + 4.30107546*ste + 3.22580647*pass + 5.376344*fla + 3.76344085*tec + 1.61290324*kop + 2.688172*tor + 3.22580647*wei + 1.61290324*sta)/10)*(1+rou_factor*rou);
		break;

		case "M LR":
//		alert ("case mlr")		
			var skillsumme = ((5.041541*(ste + lau + man + zwe + pass + tec + fla + ges) + 2.945619*(kon + kop + stae) + 0.4154079*(tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme = ((3.22580647*stae + 3.22580647*kon + 4.83871*ges + 3.76344085*man + 4.30107546*zwe + 4.83871*lau + 4.30107546*ste + 3.22580647*pass + 5.376344*fla + 3.76344085*tec + 1.61290324*kop + 2.688172*tor + 3.22580647*wei + 1.61290324*sta)/10)*(1+rou_factor*rou);
		break;
		
		case "M RL":
//		alert ("case mlr")		
			var skillsumme = ((5.041541*(ste + lau + man + zwe + pass + tec + fla + ges) + 2.945619*(kon + kop + stae) + 0.4154079*(tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme = ((3.22580647*stae + 3.22580647*kon + 4.83871*ges + 3.76344085*man + 4.30107546*zwe + 4.83871*lau + 4.30107546*ste + 3.22580647*pass + 5.376344*fla + 3.76344085*tec + 1.61290324*kop + 2.688172*tor + 3.22580647*wei + 1.61290324*sta)/10)*(1+rou_factor*rou);
		break;
		
		case "M CR":
			var skillsumme1 = ((6.182408*(ste + lau + man + zwe + pass + tec) + 3.604903*(kon + kop + stae) + 0.5227109*(ges + fla + tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((5.041541*(ste + lau + man + zwe + pass + tec + fla + ges) + 2.945619*(kon + kop + stae) + 0.4154079*(tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.57142854*stae + 4.16666651*kon + 3.57142854*ges + 4.16666651*man + 3.57142854*zwe + 4.76190472*lau + 4.76190472*ste + 4.76190472*pass + 2.38095236*fla + 3.57142854*tec + 2.38095236*kop + 2.97619057*tor + 3.57142854*wei + 1.78571427*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.22580647*stae + 3.22580647*kon + 4.83871*ges + 3.76344085*man + 4.30107546*zwe + 4.83871*lau + 4.30107546*ste + 3.22580647*pass + 5.376344*fla + 3.76344085*tec + 1.61290324*kop + 2.688172*tor + 3.22580647*wei + 1.61290324*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "M RC":
			var skillsumme1 = ((5.041541*(ste + lau + man + zwe + pass + tec + fla + ges) + 2.945619*(kon + kop + stae) + 0.4154079*(tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((6.182408*(ste + lau + man + zwe + pass + tec) + 3.604903*(kon + kop + stae) + 0.5227109*(ges + fla + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.22580647*stae + 3.22580647*kon + 4.83871*ges + 3.76344085*man + 4.30107546*zwe + 4.83871*lau + 4.30107546*ste + 3.22580647*pass + 5.376344*fla + 3.76344085*tec + 1.61290324*kop + 2.688172*tor + 3.22580647*wei + 1.61290324*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.57142854*stae + 4.16666651*kon + 3.57142854*ges + 4.16666651*man + 3.57142854*zwe + 4.76190472*lau + 4.76190472*ste + 4.76190472*pass + 2.38095236*fla + 3.57142854*tec + 2.38095236*kop + 2.97619057*tor + 3.57142854*wei + 1.78571427*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "M LC":
			var skillsumme1 = ((5.041541*(ste + lau + man + zwe + pass + tec + fla + ges) + 2.945619*(kon + kop + stae) + 0.4154079*(tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((6.182408*(ste + lau + man + zwe + pass + tec) + 3.604903*(kon + kop + stae) + 0.5227109*(ges + fla + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.22580647*stae + 3.22580647*kon + 4.83871*ges + 3.76344085*man + 4.30107546*zwe + 4.83871*lau + 4.30107546*ste + 3.22580647*pass + 5.376344*fla + 3.76344085*tec + 1.61290324*kop + 2.688172*tor + 3.22580647*wei + 1.61290324*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.57142854*stae + 4.16666651*kon + 3.57142854*ges + 4.16666651*man + 3.57142854*zwe + 4.76190472*lau + 4.76190472*ste + 4.76190472*pass + 2.38095236*fla + 3.57142854*tec + 2.38095236*kop + 2.97619057*tor + 3.57142854*wei + 1.78571427*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;		

		case "M CL":
			var skillsumme1 = ((6.182408*(ste + lau + man + zwe + pass + tec) + 3.604903*(kon + kop + stae) + 0.5227109*(ges + fla + tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((5.041541*(ste + lau + man + zwe + pass + tec + fla + ges) + 2.945619*(kon + kop + stae) + 0.4154079*(tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.57142854*stae + 4.16666651*kon + 3.57142854*ges + 4.16666651*man + 3.57142854*zwe + 4.76190472*lau + 4.76190472*ste + 4.76190472*pass + 2.38095236*fla + 3.57142854*tec + 2.38095236*kop + 2.97619057*tor + 3.57142854*wei + 1.78571427*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.22580647*stae + 3.22580647*kon + 4.83871*ges + 3.76344085*man + 4.30107546*zwe + 4.83871*lau + 4.30107546*ste + 3.22580647*pass + 5.376344*fla + 3.76344085*tec + 1.61290324*kop + 2.688172*tor + 3.22580647*wei + 1.61290324*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;			

		case "M/OM C":
			var skillsumme1 = ((6.182408*(ste + lau + man + zwe + pass + tec) + 3.604903*(kon + kop + stae) + 0.5227109*(ges + fla + tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((5.824724*(lau + kop + pass + tec + tor + wei) + 3.402209*(ste + stae + man + zwe) + 0.4809405*(fla + kon + ges + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.57142854*stae + 4.16666651*kon + 3.57142854*ges + 4.16666651*man + 3.57142854*zwe + 4.76190472*lau + 4.76190472*ste + 4.76190472*pass + 2.38095236*fla + 3.57142854*tec + 2.38095236*kop + 2.97619057*tor + 3.57142854*wei + 1.78571427*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.036602*stae + 3.82313943*kon + 3.86811256*ges + 2.16804*man + 2.716975*zwe + 4.52750063*lau + 4.27351856*ste + 6.163243*pass + 1.71992743*fla + 4.530125*tec + 3.28732085*kop + 4.00246334*tor + 4.26543236*wei + 1.59337246*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "OM/M C":
			var skillsumme1 = ((5.824724*(lau + kop + pass + tec + tor + wei) + 3.402209*(ste + stae + man + zwe) + 0.4809405*(fla + kon + ges + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((6.182408*(ste + lau + man + zwe + pass + tec) + 3.604903*(kon + kop + stae) + 0.5227109*(ges + fla + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.036602*stae + 3.82313943*kon + 3.86811256*ges + 2.16804*man + 2.716975*zwe + 4.52750063*lau + 4.27351856*ste + 6.163243*pass + 1.71992743*fla + 4.530125*tec + 3.28732085*kop + 4.00246334*tor + 4.26543236*wei + 1.59337246*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.57142854*stae + 4.16666651*kon + 3.57142854*ges + 4.16666651*man + 3.57142854*zwe + 4.76190472*lau + 4.76190472*ste + 4.76190472*pass + 2.38095236*fla + 3.57142854*tec + 2.38095236*kop + 2.97619057*tor + 3.57142854*wei + 1.78571427*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;

		case "M/OM R":
			var skillsumme1 = ((5.041541*(ste + lau + man + zwe + pass + tec + fla + ges) + 2.945619*(kon + kop + stae) + 0.4154079*(tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((6.807867*(ges + tec + fla) + 3.97882*(lau + ste + tor + wei + kop + stae + kon) + 0.5748866*(man + zwe + pass + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.22580647*stae + 3.22580647*kon + 4.83871*ges + 3.76344085*man + 4.30107546*zwe + 4.83871*lau + 4.30107546*ste + 3.22580647*pass + 5.376344*fla + 3.76344085*tec + 1.61290324*kop + 2.688172*tor + 3.22580647*wei + 1.61290324*sta)/10)*(1+rou_factor*rou);	
			//var skillsumme2 = ((3.26353669*stae + 2.770136*kon + 4.873922*ges + 3.52015066*man + 3.48778987*zwe + 4.4060216*lau + 4.425333*ste + 3.69829655*pass + 5.533843*fla + 3.884195*tec + 1.62157047*kop + 3.26996684*tor + 3.769781*wei + 1.73895681*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "OM/M R":
			var skillsumme1 = ((6.807867*(ges + tec + fla) + 3.97882*(lau + ste + tor + wei + kop + stae + kon) + 0.5748866*(man + zwe + pass + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((5.041541*(ste + lau + man + zwe + pass + tec + fla + ges) + 2.945619*(kon + kop + stae) + 0.4154079*(tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.26353669*stae + 2.770136*kon + 4.873922*ges + 3.52015066*man + 3.48778987*zwe + 4.4060216*lau + 4.425333*ste + 3.69829655*pass + 5.533843*fla + 3.884195*tec + 1.62157047*kop + 3.26996684*tor + 3.769781*wei + 1.73895681*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.22580647*stae + 3.22580647*kon + 4.83871*ges + 3.76344085*man + 4.30107546*zwe + 4.83871*lau + 4.30107546*ste + 3.22580647*pass + 5.376344*fla + 3.76344085*tec + 1.61290324*kop + 2.688172*tor + 3.22580647*wei + 1.61290324*sta)/10)*(1+rou_factor*rou);	
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;

		case "M/OM L":
			var skillsumme1 = ((5.041541*(ste + lau + man + zwe + pass + tec + fla + ges) + 2.945619*(kon + kop + stae) + 0.4154079*(tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((6.807867*(ges + tec + fla) + 3.97882*(lau + ste + tor + wei + kop + stae + kon) + 0.5748866*(man + zwe + pass + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.22580647*stae + 3.22580647*kon + 4.83871*ges + 3.76344085*man + 4.30107546*zwe + 4.83871*lau + 4.30107546*ste + 3.22580647*pass + 5.376344*fla + 3.76344085*tec + 1.61290324*kop + 2.688172*tor + 3.22580647*wei + 1.61290324*sta)/10)*(1+rou_factor*rou);	
			//var skillsumme2 = ((3.26353669*stae + 2.770136*kon + 4.873922*ges + 3.52015066*man + 3.48778987*zwe + 4.4060216*lau + 4.425333*ste + 3.69829655*pass + 5.533843*fla + 3.884195*tec + 1.62157047*kop + 3.26996684*tor + 3.769781*wei + 1.73895681*sta)/10)*(1+rou_factor*rou);			
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "OM/M L":
			var skillsumme1 = ((6.807867*(ges + tec + fla) + 3.97882*(lau + ste + tor + wei + kop + stae + kon) + 0.5748866*(man + zwe + pass + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((5.041541*(ste + lau + man + zwe + pass + tec + fla + ges) + 2.945619*(kon + kop + stae) + 0.4154079*(tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.26353669*stae + 2.770136*kon + 4.873922*ges + 3.52015066*man + 3.48778987*zwe + 4.4060216*lau + 4.425333*ste + 3.69829655*pass + 5.533843*fla + 3.884195*tec + 1.62157047*kop + 3.26996684*tor + 3.769781*wei + 1.73895681*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.22580647*stae + 3.22580647*kon + 4.83871*ges + 3.76344085*man + 4.30107546*zwe + 4.83871*lau + 4.30107546*ste + 3.22580647*pass + 5.376344*fla + 3.76344085*tec + 1.61290324*kop + 2.688172*tor + 3.22580647*wei + 1.61290324*sta)/10)*(1+rou_factor*rou);	
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "M C, F":
			var skillsumme1 = ((6.182408*(ste + lau + man + zwe + pass + tec) + 3.604903*(kon + kop + stae) + 0.5227109*(ges + fla + tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((6.903289*(stae + kop + tor + wei) + 4.021492*(kon + ges + lau + ste + tec) + 0.5698469*(man + zwe + fla + pass + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.57142854*stae + 4.16666651*kon + 3.57142854*ges + 4.16666651*man + 3.57142854*zwe + 4.76190472*lau + 4.76190472*ste + 4.76190472*pass + 2.38095236*fla + 3.57142854*tec + 2.38095236*kop + 2.97619057*tor + 3.57142854*wei + 1.78571427*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.84615374*stae + 2.56410265*kon + 3.84615374*ges + 0.641025662*man + 0.641025662*zwe + 3.20512819*lau + 3.84615374*ste + 3.84615374*pass + 1.28205132*fla + 3.84615374*tec + 6.41025639*kop + 7.69230747*tor + 6.41025639*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "F, M C":
			var skillsumme1 = ((6.903289*(stae + kop + tor + wei) + 4.021492*(kon + ges + lau + ste + tec) + 0.5698469*(man + zwe + fla + pass + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((6.182408*(ste + lau + man + zwe + pass + tec) + 3.604903*(kon + kop + stae) + 0.5227109*(ges + fla + tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.84615374*stae + 2.56410265*kon + 3.84615374*ges + 0.641025662*man + 0.641025662*zwe + 3.20512819*lau + 3.84615374*ste + 3.84615374*pass + 1.28205132*fla + 3.84615374*tec + 6.41025639*kop + 7.69230747*tor + 6.41025639*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.57142854*stae + 4.16666651*kon + 3.57142854*ges + 4.16666651*man + 3.57142854*zwe + 4.76190472*lau + 4.76190472*ste + 4.76190472*pass + 2.38095236*fla + 3.57142854*tec + 2.38095236*kop + 2.97619057*tor + 3.57142854*wei + 1.78571427*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "M L, F":
			var skillsumme1 = ((5.041541*(ste + lau + man + zwe + pass + tec + fla + ges) + 2.945619*(kon + kop + stae) + 0.4154079*(tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((6.903289*(stae + kop + tor + wei) + 4.021492*(kon + ges + lau + ste + tec) + 0.5698469*(man + zwe + fla + pass + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.22580647*stae + 3.22580647*kon + 4.83871*ges + 3.76344085*man + 4.30107546*zwe + 4.83871*lau + 4.30107546*ste + 3.22580647*pass + 5.376344*fla + 3.76344085*tec + 1.61290324*kop + 2.688172*tor + 3.22580647*wei + 1.61290324*sta)/10)*(1+rou_factor*rou);	
			//var skillsumme2 = ((3.84615374*stae + 2.56410265*kon + 3.84615374*ges + 0.641025662*man + 0.641025662*zwe + 3.20512819*lau + 3.84615374*ste + 3.84615374*pass + 1.28205132*fla + 3.84615374*tec + 6.41025639*kop + 7.69230747*tor + 6.41025639*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "F, M L":
			var skillsumme1 = ((6.903289*(stae + kop + tor + wei) + 4.021492*(kon + ges + lau + ste + tec) + 0.5698469*(man + zwe + fla + pass + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((5.041541*(ste + lau + man + zwe + pass + tec + fla + ges) + 2.945619*(kon + kop + stae) + 0.4154079*(tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.84615374*stae + 2.56410265*kon + 3.84615374*ges + 0.641025662*man + 0.641025662*zwe + 3.20512819*lau + 3.84615374*ste + 3.84615374*pass + 1.28205132*fla + 3.84615374*tec + 6.41025639*kop + 7.69230747*tor + 6.41025639*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.22580647*stae + 3.22580647*kon + 4.83871*ges + 3.76344085*man + 4.30107546*zwe + 4.83871*lau + 4.30107546*ste + 3.22580647*pass + 5.376344*fla + 3.76344085*tec + 1.61290324*kop + 2.688172*tor + 3.22580647*wei + 1.61290324*sta)/10)*(1+rou_factor*rou);	
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "M R, F":
			var skillsumme1 = ((5.041541*(ste + lau + man + zwe + pass + tec + fla + ges) + 2.945619*(kon + kop + stae) + 0.4154079*(tor + wei + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((6.903289*(stae + kop + tor + wei) + 4.021492*(kon + ges + lau + ste + tec) + 0.5698469*(man + zwe + fla + pass + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.22580647*stae + 3.22580647*kon + 4.83871*ges + 3.76344085*man + 4.30107546*zwe + 4.83871*lau + 4.30107546*ste + 3.22580647*pass + 5.376344*fla + 3.76344085*tec + 1.61290324*kop + 2.688172*tor + 3.22580647*wei + 1.61290324*sta)/10)*(1+rou_factor*rou);	
			//var skillsumme2 = ((3.84615374*stae + 2.56410265*kon + 3.84615374*ges + 0.641025662*man + 0.641025662*zwe + 3.20512819*lau + 3.84615374*ste + 3.84615374*pass + 1.28205132*fla + 3.84615374*tec + 6.41025639*kop + 7.69230747*tor + 6.41025639*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "F, M R":
			var skillsumme1 = ((6.903289*(stae + kop + tor + wei) + 4.021492*(kon + ges + lau + ste + tec) + 0.5698469*(man + zwe + fla + pass + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((5.041541*(ste + lau + man + zwe + pass + tec + fla + ges) + 2.945619*(kon + kop + stae) + 0.4154079*(tor + wei + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.84615374*stae + 2.56410265*kon + 3.84615374*ges + 0.641025662*man + 0.641025662*zwe + 3.20512819*lau + 3.84615374*ste + 3.84615374*pass + 1.28205132*fla + 3.84615374*tec + 6.41025639*kop + 7.69230747*tor + 6.41025639*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.22580647*stae + 3.22580647*kon + 4.83871*ges + 3.76344085*man + 4.30107546*zwe + 4.83871*lau + 4.30107546*ste + 3.22580647*pass + 5.376344*fla + 3.76344085*tec + 1.61290324*kop + 2.688172*tor + 3.22580647*wei + 1.61290324*sta)/10)*(1+rou_factor*rou);	
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;

		case "OM C":
//		alert ("case omc")
			var skillsumme = ((5.824724*(lau + kop + pass + tec + tor + wei) + 3.402209*(ste + stae + man + zwe) + 0.4809405*(fla + kon + ges + sta))/10)*(1+rou_factor*rou);
			//var skillsumme = ((3.036602*stae + 3.82313943*kon + 3.86811256*ges + 2.16804*man + 2.716975*zwe + 4.52750063*lau + 4.27351856*ste + 6.163243*pass + 1.71992743*fla + 4.530125*tec + 3.28732085*kop + 4.00246334*tor + 4.26543236*wei + 1.59337246*sta)/10)*(1+rou_factor*rou);
		break;

		case "OM L":
//		alert ("case oml")
			var skillsumme = ((6.807867*(ges + tec + fla) + 3.97882*(lau + ste + tor + wei + kop + stae + kon) + 0.5748866*(man + zwe + pass + sta))/10)*(1+rou_factor*rou);
			//var skillsumme = ((3.26353669*stae + 2.770136*kon + 4.873922*ges + 3.52015066*man + 3.48778987*zwe + 4.4060216*lau + 4.425333*ste + 3.69829655*pass + 5.533843*fla + 3.884195*tec + 1.62157047*kop + 3.26996684*tor + 3.769781*wei + 1.73895681*sta)/10)*(1+rou_factor*rou);
		break;

		case "OM R":
//		alert ("case omr")
			var skillsumme = ((6.807867*(ges + tec + fla) + 3.97882*(lau + ste + tor + wei + kop + stae + kon) + 0.5748866*(man + zwe + pass + sta))/10)*(1+rou_factor*rou);
			//var skillsumme = ((3.26353669*stae + 2.770136*kon + 4.873922*ges + 3.52015066*man + 3.48778987*zwe + 4.4060216*lau + 4.425333*ste + 3.69829655*pass + 5.533843*fla + 3.884195*tec + 1.62157047*kop + 3.26996684*tor + 3.769781*wei + 1.73895681*sta)/10)*(1+rou_factor*rou);
		break;

		case "OM LR":
//		alert ("case omlr")
			var skillsumme = ((6.807867*(ges + tec + fla) + 3.97882*(lau + ste + tor + wei + kop + stae + kon) + 0.5748866*(man + zwe + pass + sta))/10)*(1+rou_factor*rou);
			//var skillsumme = ((3.26353669*stae + 2.770136*kon + 4.873922*ges + 3.52015066*man + 3.48778987*zwe + 4.4060216*lau + 4.425333*ste + 3.69829655*pass + 5.533843*fla + 3.884195*tec + 1.62157047*kop + 3.26996684*tor + 3.769781*wei + 1.73895681*sta)/10)*(1+rou_factor*rou);
		break;
		
		case "OM RL":
//		alert ("case omlr")
			var skillsumme = ((6.807867*(ges + tec + fla) + 3.97882*(lau + ste + tor + wei + kop + stae + kon) + 0.5748866*(man + zwe + pass + sta))/10)*(1+rou_factor*rou);
			//var skillsumme = ((3.26353669*stae + 2.770136*kon + 4.873922*ges + 3.52015066*man + 3.48778987*zwe + 4.4060216*lau + 4.425333*ste + 3.69829655*pass + 5.533843*fla + 3.884195*tec + 1.62157047*kop + 3.26996684*tor + 3.769781*wei + 1.73895681*sta)/10)*(1+rou_factor*rou);
		break;

		case "OM CR":
			var skillsumme1 = ((5.824724*(lau + kop + pass + tec + tor + wei) + 3.402209*(ste + stae + man + zwe) + 0.4809405*(fla + kon + ges + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((6.807867*(ges + tec + fla) + 3.97882*(lau + ste + tor + wei + kop + stae + kon) + 0.5748866*(man + zwe + pass + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.036602*stae + 3.82313943*kon + 3.86811256*ges + 2.16804*man + 2.716975*zwe + 4.52750063*lau + 4.27351856*ste + 6.163243*pass + 1.71992743*fla + 4.530125*tec + 3.28732085*kop + 4.00246334*tor + 4.26543236*wei + 1.59337246*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.26353669*stae + 2.770136*kon + 4.873922*ges + 3.52015066*man + 3.48778987*zwe + 4.4060216*lau + 4.425333*ste + 3.69829655*pass + 5.533843*fla + 3.884195*tec + 1.62157047*kop + 3.26996684*tor + 3.769781*wei + 1.73895681*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "OM RC":
			var skillsumme1 = ((6.807867*(ges + tec + fla) + 3.97882*(lau + ste + tor + wei + kop + stae + kon) + 0.5748866*(man + zwe + pass + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((5.824724*(lau + kop + pass + tec + tor + wei) + 3.402209*(ste + stae + man + zwe) + 0.4809405*(fla + kon + ges + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.26353669*stae + 2.770136*kon + 4.873922*ges + 3.52015066*man + 3.48778987*zwe + 4.4060216*lau + 4.425333*ste + 3.69829655*pass + 5.533843*fla + 3.884195*tec + 1.62157047*kop + 3.26996684*tor + 3.769781*wei + 1.73895681*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.036602*stae + 3.82313943*kon + 3.86811256*ges + 2.16804*man + 2.716975*zwe + 4.52750063*lau + 4.27351856*ste + 6.163243*pass + 1.71992743*fla + 4.530125*tec + 3.28732085*kop + 4.00246334*tor + 4.26543236*wei + 1.59337246*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;

		case "OM LC":
			var skillsumme1 = ((6.807867*(ges + tec + fla) + 3.97882*(lau + ste + tor + wei + kop + stae + kon) + 0.5748866*(man + zwe + pass + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((5.824724*(lau + kop + pass + tec + tor + wei) + 3.402209*(ste + stae + man + zwe) + 0.4809405*(fla + kon + ges + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.26353669*stae + 2.770136*kon + 4.873922*ges + 3.52015066*man + 3.48778987*zwe + 4.4060216*lau + 4.425333*ste + 3.69829655*pass + 5.533843*fla + 3.884195*tec + 1.62157047*kop + 3.26996684*tor + 3.769781*wei + 1.73895681*sta)/10)*(1+rou_factor*rou);			
			//var skillsumme2 = ((3.036602*stae + 3.82313943*kon + 3.86811256*ges + 2.16804*man + 2.716975*zwe + 4.52750063*lau + 4.27351856*ste + 6.163243*pass + 1.71992743*fla + 4.530125*tec + 3.28732085*kop + 4.00246334*tor + 4.26543236*wei + 1.59337246*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "OM CL":
			var skillsumme1 = ((5.824724*(lau + kop + pass + tec + tor + wei) + 3.402209*(ste + stae + man + zwe) + 0.4809405*(fla + kon + ges + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((6.807867*(ges + tec + fla) + 3.97882*(lau + ste + tor + wei + kop + stae + kon) + 0.5748866*(man + zwe + pass + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.036602*stae + 3.82313943*kon + 3.86811256*ges + 2.16804*man + 2.716975*zwe + 4.52750063*lau + 4.27351856*ste + 6.163243*pass + 1.71992743*fla + 4.530125*tec + 3.28732085*kop + 4.00246334*tor + 4.26543236*wei + 1.59337246*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.26353669*stae + 2.770136*kon + 4.873922*ges + 3.52015066*man + 3.48778987*zwe + 4.4060216*lau + 4.425333*ste + 3.69829655*pass + 5.533843*fla + 3.884195*tec + 1.62157047*kop + 3.26996684*tor + 3.769781*wei + 1.73895681*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;

		case "OM C, F":
			var skillsumme1 = ((5.824724*(lau + kop + pass + tec + tor + wei) + 3.402209*(ste + stae + man + zwe) + 0.4809405*(fla + kon + ges + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((6.903289*(stae + kop + tor + wei) + 4.021492*(kon + ges + lau + ste + tec) + 0.5698469*(man + zwe + fla + pass + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.036602*stae + 3.82313943*kon + 3.86811256*ges + 2.16804*man + 2.716975*zwe + 4.52750063*lau + 4.27351856*ste + 6.163243*pass + 1.71992743*fla + 4.530125*tec + 3.28732085*kop + 4.00246334*tor + 4.26543236*wei + 1.59337246*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.84615374*stae + 2.56410265*kon + 3.84615374*ges + 0.641025662*man + 0.641025662*zwe + 3.20512819*lau + 3.84615374*ste + 3.84615374*pass + 1.28205132*fla + 3.84615374*tec + 6.41025639*kop + 7.69230747*tor + 6.41025639*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "F, OM C":
			var skillsumme1 = ((6.903289*(stae + kop + tor + wei) + 4.021492*(kon + ges + lau + ste + tec) + 0.5698469*(man + zwe + fla + pass + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((5.824724*(lau + kop + pass + tec + tor + wei) + 3.402209*(ste + stae + man + zwe) + 0.4809405*(fla + kon + ges + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.84615374*stae + 2.56410265*kon + 3.84615374*ges + 0.641025662*man + 0.641025662*zwe + 3.20512819*lau + 3.84615374*ste + 3.84615374*pass + 1.28205132*fla + 3.84615374*tec + 6.41025639*kop + 7.69230747*tor + 6.41025639*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.036602*stae + 3.82313943*kon + 3.86811256*ges + 2.16804*man + 2.716975*zwe + 4.52750063*lau + 4.27351856*ste + 6.163243*pass + 1.71992743*fla + 4.530125*tec + 3.28732085*kop + 4.00246334*tor + 4.26543236*wei + 1.59337246*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;

		case "OM R, F":
			var skillsumme1 = ((6.807867*(ges + tec + fla) + 3.97882*(lau + ste + tor + wei + kop + stae + kon) + 0.5748866*(man + zwe + pass + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((6.903289*(stae + kop + tor + wei) + 4.021492*(kon + ges + lau + ste + tec) + 0.5698469*(man + zwe + fla + pass + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.26353669*stae + 2.770136*kon + 4.873922*ges + 3.52015066*man + 3.48778987*zwe + 4.4060216*lau + 4.425333*ste + 3.69829655*pass + 5.533843*fla + 3.884195*tec + 1.62157047*kop + 3.26996684*tor + 3.769781*wei + 1.73895681*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.84615374*stae + 2.56410265*kon + 3.84615374*ges + 0.641025662*man + 0.641025662*zwe + 3.20512819*lau + 3.84615374*ste + 3.84615374*pass + 1.28205132*fla + 3.84615374*tec + 6.41025639*kop + 7.69230747*tor + 6.41025639*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "F, OM R":
			var skillsumme1 = ((6.903289*(stae + kop + tor + wei) + 4.021492*(kon + ges + lau + ste + tec) + 0.5698469*(man + zwe + fla + pass + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((6.807867*(ges + tec + fla) + 3.97882*(lau + ste + tor + wei + kop + stae + kon) + 0.5748866*(man + zwe + pass + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.84615374*stae + 2.56410265*kon + 3.84615374*ges + 0.641025662*man + 0.641025662*zwe + 3.20512819*lau + 3.84615374*ste + 3.84615374*pass + 1.28205132*fla + 3.84615374*tec + 6.41025639*kop + 7.69230747*tor + 6.41025639*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.26353669*stae + 2.770136*kon + 4.873922*ges + 3.52015066*man + 3.48778987*zwe + 4.4060216*lau + 4.425333*ste + 3.69829655*pass + 5.533843*fla + 3.884195*tec + 1.62157047*kop + 3.26996684*tor + 3.769781*wei + 1.73895681*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;

		case "OM L, F":
			var skillsumme1 = ((6.807867*(ges + tec + fla) + 3.97882*(lau + ste + tor + wei + kop + stae + kon) + 0.5748866*(man + zwe + pass + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((6.903289*(stae + kop + tor + wei) + 4.021492*(kon + ges + lau + ste + tec) + 0.5698469*(man + zwe + fla + pass + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.26353669*stae + 2.770136*kon + 4.873922*ges + 3.52015066*man + 3.48778987*zwe + 4.4060216*lau + 4.425333*ste + 3.69829655*pass + 5.533843*fla + 3.884195*tec + 1.62157047*kop + 3.26996684*tor + 3.769781*wei + 1.73895681*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.84615374*stae + 2.56410265*kon + 3.84615374*ges + 0.641025662*man + 0.641025662*zwe + 3.20512819*lau + 3.84615374*ste + 3.84615374*pass + 1.28205132*fla + 3.84615374*tec + 6.41025639*kop + 7.69230747*tor + 6.41025639*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);			
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;
		
		case "F, OM L":
			var skillsumme1 = ((6.903289*(stae + kop + tor + wei) + 4.021492*(kon + ges + lau + ste + tec) + 0.5698469*(man + zwe + fla + pass + sta))/10)*(1+rou_factor*rou);
			var skillsumme2 = ((6.807867*(ges + tec + fla) + 3.97882*(lau + ste + tor + wei + kop + stae + kon) + 0.5748866*(man + zwe + pass + sta))/10)*(1+rou_factor*rou);
			//var skillsumme1 = ((3.84615374*stae + 2.56410265*kon + 3.84615374*ges + 0.641025662*man + 0.641025662*zwe + 3.20512819*lau + 3.84615374*ste + 3.84615374*pass + 1.28205132*fla + 3.84615374*tec + 6.41025639*kop + 7.69230747*tor + 6.41025639*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
			//var skillsumme2 = ((3.26353669*stae + 2.770136*kon + 4.873922*ges + 3.52015066*man + 3.48778987*zwe + 4.4060216*lau + 4.425333*ste + 3.69829655*pass + 5.533843*fla + 3.884195*tec + 1.62157047*kop + 3.26996684*tor + 3.769781*wei + 1.73895681*sta)/10)*(1+rou_factor*rou);
			skillsumme1 = new String(skillsumme1.toFixed(2));
			skillsumme2 = new String(skillsumme2.toFixed(2));
			var skillsumme_str = skillsumme1 + "/" + skillsumme2;
		break;

		case "F":
		//alert ("case f")
			var skillsumme = ((6.903289*(stae + kop + tor + wei) + 4.021492*(kon + ges + lau + ste + tec) + 0.5698469*(man + zwe + fla + pass + sta))/10)*(1+rou_factor*rou);
			//var skillsumme = ((3.84615374*stae + 2.56410265*kon + 3.84615374*ges + 0.641025662*man + 0.641025662*zwe + 3.20512819*lau + 3.84615374*ste + 3.84615374*pass + 1.28205132*fla + 3.84615374*tec + 6.41025639*kop + 7.69230747*tor + 6.41025639*wei + 1.92307687*sta)/10)*(1+rou_factor*rou);
		break;


	default:
		var skillsumme = "Unknown Position";

}

		if(typeof skillsumme_str == 'undefined')
		{
			skillsumme=parseFloat(skillsumme.toFixed(2));
		}
		else{
			skillsumme=skillsumme_str;
		}
	
	//Einfuegen eines span-elements hinter FP
	var skillsumspan_HL = document.createElement("span");
	skillsumspan_HL.innerHTML="<div style=\"color: white;\">Ocena Pozycji</div>";
	document.getElementsByTagName("table")[0].getElementsByTagName('tr')[zeile+skillindex_yes+7].getElementsByTagName('th')[0].appendChild(skillsumspan_HL);

	//Einfuegen eines span-elements hinter F
	var skillsumspan_value = document.createElement("span");
	skillsumspan_value.innerHTML="<div style=\"color: white;\">" + skillsumme + "</div>";
	document.getElementsByTagName("table")[0].getElementsByTagName('tr')[zeile+skillindex_yes+7].getElementsByTagName('td')[0].appendChild(skillsumspan_value); 

//	Bereich zum Kopieren der Skills

/*	var div2 = document.createElement('div');
	div2.innerHTML="<div id=\"DB\" style=\"position: fixed; background-color: white; color: gray; bottom: 2px; right: 5px; height: 35px; width: 350px; -moz-opacity: .8; text-align: left; border: 2px #333333 outset; display:inline;\">" + name + "; (" + id + "); " + pos + "; " + stae + "; " + kon + "; " + ges + "; " + man + "; " + zwe + "; " + lau + "; " + ste + "; " + pass + "; " + fla + "; " + tec + "; " + kop + "; " + tor + "; " + wei + "; " + sta + "; " + skillsumme + "; " + rou + "; " + gehalt + "; " + asi + "</div>";
	document.body.appendChild(div2);
*/
//	var area_phy = stae + kon + ges + kop;
//	var area_tac = man + zwe + lau + ste;
	if ((pos == "D/DM L") || (pos == "D/DM R")) {
		var skillworou = (skillsumme1)/(1+rou_factor*rou);
		skillworou=parseFloat(skillworou.toFixed(2));
		var effect_rou = skillsumme1-skillworou;
		effect_rou=parseFloat(effect_rou.toFixed(2));
	}
	else if ((pos == "DM/M L") || (pos == "DM/M C") || (pos == "DM/M R") || (pos == "D/DM C") || (pos == "D CR") || (pos == "D LC") || (pos == "DM LC") || (pos == "DM CR") || (pos == "M CR") || (pos == "M LC") || (pos == "M/OM C") || (pos == "M/OM L") || (pos == "M/OM R") || (pos == "OM CR") || (pos == "OM LC") || (pos == "OM C, F") || (pos == "OM L, F") || (pos == "OM R, F"))  {
		var skillworou1 = (skillsumme1)/(1+rou_factor*rou);
		var skillworou2 = (skillsumme2)/(1+rou_factor*rou);
		skillworou1 = new String(skillworou1.toFixed(2));
		skillworou2 = new String(skillworou2.toFixed(2));
		var skillworou = skillworou1 + "/" + skillworou2;
		
		var effect_rou1 = skillsumme1-skillworou1;
		var effect_rou2 = skillsumme2-skillworou2;
		effect_rou1 = new String(effect_rou1.toFixed(2));
		effect_rou2 = new String(effect_rou2.toFixed(2));
		effect_rou = effect_rou1 + "/" + effect_rou2;		
	}
	else {
		var skillworou = (skillsumme)/(1+rou_factor*rou);
		skillworou=parseFloat(skillworou.toFixed(2));
		var effect_rou = skillsumme-skillworou;
		effect_rou=parseFloat(effect_rou.toFixed(2));
	}

	switch(pos) {
		case("GK"): 
		//var area_tec = "tba";
		//var area_tac = "tba";
		//var area_phy = "tba";
		var area_tec = tec + pass + sta + abw;
		var area_phy = stae + kon + ges + tor;
		var area_tac = fla + wei + kop;
		break;
		
		default:
		var area_phy = stae + kon + ges + kop; 
		var area_tac = man + zwe + lau + ste;		
		var area_tec = pass + fla + tec + tor + wei + sta;
		
	}
	var skillsum = area_phy + area_tec + area_tac;
	
	
	if (PlayerDataPlus == "yes") {
	
		if (PlayerDataPlusPosition == "topleft")  {
	
			var div_area = document.createElement('div');
			div_area.innerHTML="<div id=\"area\" style=\"position: absolute; z-index: 1000; background: #5F8D2D; color: #ff9900; top: 330px; left: 375px; width: 177px; padding-left: 5px; -moz-opacity: .8; text-align: middle; color: gold; border: 2px #275502 outset; display:inline;\"><p style=\"text-decoration: underline;\"><b>Dane Zawodnika:<\p><table style=\"margin-top: -1em; margin-left: 1em; margin-bottom: 1em;\"><tr><td>PhySum: " + area_phy + "</td><tr><td>TacSum: " + area_tac + " </td><tr><td>TecSum: " + area_tec + " </td><tr><td>AllSum: " + skillsum + "</td></tr></table></b></div>";
			document.body.appendChild(div_area);
			
		}
		else if (PlayerDataPlusPosition == "bottomleft")  {
		
			var div_area = document.createElement('div');
			div_area.innerHTML="<div id=\"area\" style=\"position: fixed; z-index: 1000; background: #5F8D2D; color: #ff9900; bottom: 10px; left: 25px; width: 250px; padding-left: 5px; -moz-opacity: .8; text-align: middle; color: gold; border: 2px #275502 outset; display:inline;\"><p style=\"text-decoration: underline;\"><b>PlayerData+:<\p><table style=\"margin-top: -1em; margin-left: 1em; margin-bottom: 1em;\"><tr><td>PhySum: " + area_phy + "</td><td>TB-Rating: " + skillsumme + " </td></tr><tr><td>TacSum: " + area_tac + " </td><td>RouEffect: " + effect_rou + " </td></tr><tr><td>TecSum: " + area_tec + " </td><td>TB-Pure: " + skillworou + "</td></tr><tr><td>AllSum: " + skillsum + "</td></tr></table></b></div>";
			document.body.appendChild(div_area);
			
		}
		else {
		
			var div_area = document.createElement('div');
			div_area.innerHTML="<div id=\"area\" style=\"position: absolute; z-index: 1000; width: 177px; margin-top: 15px; background: #5F8D2D; color: #ff9900; padding-left: 5px; -moz-opacity: .8; text-align: middle; color: gold; border: 2px #275502 outset; display:inline;\"><p style=\"text-decoration: underline;\"><b>Dane Zawodnika:<\p><table style=\"margin-top: -1em; margin-bottom: 1em;\"><tr><td>PhySum: </td><td>" + area_phy + "</td></tr><tr><td>TacSum: </td><td>" + area_tac + " </td></tr><tr><td>TecSum: </td><td>" + area_tec + " </td></tr><tr><td>AllSum: </td><td>" + skillsum + "</td></tr><tr><td>&nbsp;</td></tr><tr><td>Rating: </td><td>" + skillsumme + " </td></tr><tr><td>RouEffect: </td><td>" + effect_rou + " </td></tr><tr><td>TB-Pure: </td><td>" + skillworou + "</td></tr></table></b></div>";
			document.getElementsByTagName("div")[18].appendChild(div_area);
		
		}
	}	
	else {
	
	}
	
	/****************************************************************************************/
	/* Inject form                                        */
	/****************************************************************************************/

/*	var TMDB = document.createElement("span"); // erzeugt ein html-span-tag
	
	var Tform="<form action='http://patrick-meurer.de/tmdb/tmdb.php' target='_self' accept-charset='UTF-8' method='post' style='display:inline;'>";	

	Tform=Tform+"<input name='id' type='hidden' value='"+id+"' />";
	Tform=Tform+"<input name='name' type='hidden' value='"+name+"' />";
	Tform=Tform+"<input name='alter' type='hidden' value='"+alter+"' />";
	Tform=Tform+"<input name='clubid' type='hidden' value='"+clubid+"' />";
//	Tform=Tform+"<input name='nplayer' type='hidden' value='"+nplayer+"' />";
	Tform=Tform+"<input name='pos' type='hidden' value='"+pos+"' />";
	Tform=Tform+"<input name='skillsumme' type='hidden' value='"+skillsumme+"' />";
	Tform=Tform+"<input name='stae' type='hidden' value='"+stae+"' />";
	Tform=Tform+"<input name='kon' type='hidden' value='"+kon+"' />";
	Tform=Tform+"<input name='ges' type='hidden' value='"+ges+"' />";
	Tform=Tform+"<input name='man' type='hidden' value='"+man+"' />";
	Tform=Tform+"<input name='zwe' type='hidden' value='"+zwe+"' />";
	Tform=Tform+"<input name='lau' type='hidden' value='"+lau+"' />";
	Tform=Tform+"<input name='ste' type='hidden' value='"+ste+"' />";
	Tform=Tform+"<input name='pass' type='hidden' value='"+pass+"' />";
	Tform=Tform+"<input name='fla' type='hidden' value='"+fla+"' />";
	Tform=Tform+"<input name='tec' type='hidden' value='"+tec+"' />";
	Tform=Tform+"<input name='kop' type='hidden' value='"+kop+"' />";
	Tform=Tform+"<input name='tor' type='hidden' value='"+tor+"' />";
	Tform=Tform+"<input name='wei' type='hidden' value='"+wei+"' />";
	Tform=Tform+"<input name='sta' type='hidden' value='"+sta+"' />";
	Tform=Tform+"<input name='rou' type='hidden' value='"+rou+"' />";
	Tform=Tform+"<input name='gehalt' type='hidden' value='"+gehalt+"' />";
	Tform=Tform+"<input name='asi' type='hidden' value='"+asi+"' />";
	Tform=Tform+"<input name='status' type='hidden' value='"+status+"' />";
	Tform=Tform+"<input type='submit' name='button' value='Absenden'></form><br />";
*/	
//	alert ("Summe: " + skillsumme)
} // if showprofile
}
if (myurl.match(/.*/))
{
/*	
function hide (member) {
        if (document.getElementById) {
            if (document.getElementById(member).style.display = "inline") {
                document.getElementById(member).style.display = "none";
            } else {
                document.getElementById(member).style.display = "inline";
            }
        }
}
*/
/*var divswitch = document.createElement('div');
appdivswitch = document.body.appendChild(divswitch);
appdivswitch.innerHTML = '<div><a href="javascript:ToggleMenu();">Menu</a></div>';
*/

if (hovermenu == "yes") {

var load,execute,loadAndExecute;load=function(a,b,c){var d;d=document.createElement("script"),d.setAttribute("src",a),b!=null&&d.addEventListener("load",b),c!=null&&d.addEventListener("error",c),document.body.appendChild(d);return d},execute=function(a){var b,c;typeof a=="function"?b="("+a+")();":b=a,c=document.createElement("script"),c.textContent=b,document.body.appendChild(c);return c},loadAndExecute=function(a,b){return load(a,function(){return execute(b)})};

loadAndExecute("//ajax.googleapis.com/ajax/libs/jquery/1.6.4/jquery.min.js", function() {

    $.noConflict();
    jQuery(document).ready(function($) {
    $('#top_menu ul li a').bind('mouseover', function() { 
		top_menu["change"]($(this).attr('top_menu'), false);
	});
  });
});

}
else  {

}


//Menu bottom right
if (menubar == "yes") {
var div1 = document.createElement('div');
appdiv1 = document.body.appendChild(div1);
appdiv1.innerHTML = '<div id="menu" style="position: fixed; z-index: 1000; bottom: 0px; right: 85px; height: 30px; width: 150px; -moz-opacity: .8; text-align: left; outset; background: url(http://www.patrick-meurer.de/tm/TrophyBuddy_menu2.png);">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="position:relative; top:5px;left:222px"><a href="http://trophymanager.com/club/"><img src="" title="' + Home + '" style="height: 20px;"></a></span>&nbsp;&nbsp;<span style="position:relative; top:222px;left:0px"><a href="http://trophymanager.com/home/box"><img src="" title="' + CheckYourMails + '" style="height: 20px;"></a></span>&nbsp;&nbsp;&nbsp;<span style="position:relative; top:222px;left:0px"><a href="http://trophymanager.com/league/"><img src="" title="' + League + '" style="height: 20px;"></a></span>&nbsp;&nbsp;&nbsp;&nbsp;<span style="position:relative; top:-700px;left:-966px"><a href="http://trophymanager.com/?logout"><img src="http://oi60.tinypic.com/34e6m3c.jpg" title="' + Exit + '" style="height: 400px;"></a></span><span style="position:relative; top: -1333px; left: -1555px"><a href="http://trophymanager.com/?logout"><img src="http://oi61.tinypic.com/6r6fj4.jpg" title="' + Exit + '" style="height: 1111px;"></a></span></div>';
}
else {
}
/*
var TMDB = document.createElement("span"); // erzeugt ein html-span-tag
TMDB.innerHTML=Tform;
document.getElementById("lastspan").appendChild(TMDB);
*/
if (sidebar == "yes") {
	if (myclubid == "") {
	Navigationsbereich
	var div = document.createElement('div');
	//appdiv = document.body.appendChild(div);
	appdiv.innerHTML = '<div id="tbuddy" style="position: fixed; z-index: 1000; top: 150px; left: 25px; height: 500px; width: 130px; -moz-opacity: .8; text-align: left; border: 2px #333333 outset; display:inline;"><img src="http://patrick-meurer.de/tm/TrophyBuddy21.png"><li><a href="http://http://trophymanager.com/club//" target="_self" style="list-style-type:disc; margin-top: 0px; padding-left: 0px;" title="' + Team + '">' + Team + ' </a></li><li><a href="http://trophymanager.com/bids/" target="_self" style="font-size: 10px; color: gold;" title="' + GoCurrentBids + '">' + CurrentBids + '</a></li><li><a href="http://trophymanager.com/tactics/" target="_self" style="font-size: 10px; color: gold;" title="Go to Tactics">' + Tactics + '</a></li><li><a href="http://trophymanager.com/assistant-manager/" target="_self" style="font-size: 10px; color: gold;" title="' + GoYouthAcademy + '">' + YouthAcademy + '</a></li><li><a href="http://trophymanager.com/finances/" target="_self" style="font-size: 10px; color: gold;" title="' + GoYouthAcademyy + '">' + YouthAcademyy + '</a></li><li><a href="http://trophymanager.com/youth-development/" target="_self" style="font-size: 10px; color: gold;" title="' + GoPlayerNotes + '">' + PlayerNotes + '</a></li></ul><p style="text-decoration: underline;">' + Staff + '</p><ul style="list-style-type:disc; margin-top: 0px; padding-left: 20px;"><li><a href="http://trophymanager.com/coaches/hire/" target="_self" style="font-size: 10px; color: gold;" title="' + GoHireCoaches + '">' + HireCoaches + '</a> | <a href="http://trophymanager.com/scouts/hire/" target="_self" style="font-size: 10px; color: gold;" title="' + GoHireScouts + '">' + HireScouts + '</a></li><li><a href="http://trophymanager.com/scouts/" target="_self" style="font-size: 10px; color: gold;" title="' + GoScoutReports + '">' + ScoutReports + '</a></li><li><a href="http://trophymanager.com/coaches/" target="_self" style="font-size: 10px; color: gold;" titles="' + GoMyCoaches + '">' + MyCoaches + '</a> | <a href="http://trophymanager.com/scouts/" target="_self" style="font-size: 10px; color: gold;" titles="' + GoMyScouts + '">' + MyScouts + '</a></li></ul><p style="text-decoration: underline;">' + Training + '</p><ul style="list-style-type:disc; margin-top: 0px; padding-left: 20px;"><li><a href="http://trophymanager.com/training-overview/advanced/" target="_self" style="font-size: 10px; color: gold;" title="' + GoTrainingOverview + '">' + TrainingOverview + '</a></li><li><a href="http://trophymanager.com/training/" target="_self" style="font-size: 10px; color: gold;" title="' + GoTrainingTeams + '">' + TrainingTeams + '</a></li></ul><p style="text-decoration: underline;">' + Community + '</p><ul style="list-style-type:disc; margin-top: 0px; padding-left: 20px;"><li><a href="http://trophymanager.com/forum/" target="_self" style="font-size: 10px; color: gold;" title="' + GoForum + '">' + Forum + '</a> ( <a href="http://trophymanager.com/forum/pl/help/" title="' + GoTransferForum + '">P</a> | <a href="http://trophymanager.com/forum/int/general/" title="' + GoGeneralForum + '">G</a> | <a href="http://trophymanager.com/forum/int/announcements/" title="' + GoAnnouncementForum + '">A</a> )</li><li><a href="http://trophymanager.com/forum/int/recent-posts/" target="_self" style="font-size: 10px; color: gold;" title="' + GoYourRecentPosts + '">' + YourRecentPosts + '</a></li><li><a href="http://trophymanager.com/user-guide/" target="_self" style="font-size: 10px; color: gold;" title="' + GoTMUserGuide + '">' + TMUserGuide + '</a></li><li><a href="http://trophymanager.com/forum/conference/18/" target="_self" style="font-size: 10px; color: gold;" title="' + GoTBConference + '">' + TBConference + '</a></li></ul></div>';
	//appdiv.innerHTML = '<div id="tbuddy" style="position: fixed; z-index: 1000; top: 150px; left: 25px; height: 500px; width: 130px; -moz-opacity: .8; text-align: left; border: 2px #333333 outset; display:inline;"><img src="http://patrick-meurer.de/tm/TrophyBuddy21.png"><li><a href="http://trophymanager.com/club/" target="_self" style="list-style-type:disc; margin-top: 0px; padding-left: 0px;" title="' + Team + '">' + Team + ' </a></li><li><a href="http://trophymanager.com/bids/" target="_self" style="font-size: 10px; color: gold;" title="' + GoCurrentBids + '">' + CurrentBids + '</a></li><li><a href="http://trophymanager.com/tactics/" target="_self" style="font-size: 10px; color: gold;" title="Go to Tactics">' + Tactics + '</a></li><li><a href="http://trophymanager.com/assistant-manager/" target="_self" style="font-size: 10px; color: gold;" title="' + GoYouthAcademy + '">' + YouthAcademy + '</a></li><li><a href="http://trophymanager.com/finances/" target="_self" style="font-size: 10px; color: gold;" title="' + GoYouthAcademyy + '">' + YouthAcademyy + '</a></li><li><a href="http://trophymanager.com/youth-development/" target="_self" style="font-size: 10px; color: gold;" title="' + GoPlayerNotes + '>' + PlayerNotes + '</a></li></ul><p style="text-decoration: underline;">' + Staff + '</p><ul style="list-style-type:disc; margin-top: 0px; padding-left: 20px;"><li><a href="http://trophymanager.com/coaches/hire/" target="_self" style="font-size: 10px; color: gold;" title="' + GoHireCoaches + '">' + HireCoaches + '</a> | <a href="http://trophymanager.com/scouts/hire/" target="_self" style="font-size: 10px; color: gold;" title="' + GoHireScouts + '">' + HireScouts + '</a></li><li><a href="http://trophymanager.com/scouts/" target="_self" style="font-size: 10px; color: gold;" title="' + GoScoutReports + '">' + ScoutReports + '</a></li><li><a href="http://trophymanager.com/coaches/" target="_self" style="font-size: 10px; color: gold;" titles="' + GoMyCoaches + '">' + MyCoaches + '</a> | <a href="http://trophymanager.com/scouts/" target="_self" style="font-size: 10px; color: gold;" titles="' + GoMyScouts + '">' + MyScouts + '</a></li></ul><p style="text-decoration: underline;">' + Training + '</p><ul style="list-style-type:disc; margin-top: 0px; padding-left: 20px;"><li><a href="http://trophymanager.com/training-overview/advanced/" target="_self" style="font-size: 10px; color: gold;" title="' + GoTrainingOverview + '">' + TrainingOverview + '</a></li><li><a href="http://trophymanager.com/training/" target="_self" style="font-size: 10px; color: gold;" title="' + GoTrainingTeams + '">' + TrainingTeams + '</a></li></ul><p style="text-decoration: underline;">' + Community + '</p><ul style="list-style-type:disc; margin-top: 0px; padding-left: 20px;"><li><a href="http://trophymanager.com/forum/" target="_self" style="font-size: 10px; color: gold;" title="' + GoForum + '">' + Forum + '</a> ( <a href="http://trophymanager.com/forum/pl/help/" title="' + GoTransferForum + '">P</a> | <a href="http://trophymanager.com/forum/int/general/" title="' + GoGeneralForum + '">G</a> | <a href="http://trophymanager.com/forum/int/announcements/" title="' + GoAnnouncementForum + '">A</a> | <a href="http://trophymanager.com/forum/federations" title="' + GoFederations + '">F</a> )</li><li><a href="http://trophymanager.com/user-guide/" target="_self" style="font-size: 10px; color: gold;" title="' + GoTMUserGuide + '">' + TMUserGuide + '</a></li><li><a href="http://trophymanager.com/forum/conference/18/" target="_self" style="font-size: 10px; color: gold;" title="' + GoTBConference + '">' + TBConference + '</a></li></ul></div>';	
	}
	else {
	//Navigationsbereich
	var div = document.createElement('div');
	appdiv = document.body.appendChild(div);
	appdiv.innerHTML = '<div id="tbuddy" style="position: fixed; z-index: 1000; top: 130px; left: 20px; height: 537px; width: 124px; -moz-opacity: .8; text-align: left; border: 2px #275502 outset; display:inline;"><span style="position:relative; top:0px;left:0px"><a href="http://trophymanager.com/forum/int/announcements/"><img src="http://iv.pl/images/69124859116527337779.gif" title="' + CheckYourMailss + '" style="height: 42px;"></a></span></p></p><span><a href="http://trophymanager.com/club/" target="_self" style="font-size: margin-top: 0px; padding-left: 0px;" title="' + Team + '">' + Team + '<ul style="list-style-type:disc; margin-top: 0px; padding-left: 10px;"></a></span><li><a href="http://trophymanager.com/bids/" target="_self" style="font-size: 10px; color: gold;" title="' + GoCurrentBids + '">' + CurrentBids + '</a></li><li><a href="http://trophymanager.com/club/' + myclubid + '/squad/" target="_self" style="font-size: 10px; color: gold;" title="Przeglad Skladu">' + Squad + '</a></li><li><a href="http://trophymanager.com/tactics/" target="_self" style="font-size: 10px; color: gold;" title="Taktyka">' + Tactics + '</a></li><li><a href="http://trophymanager.com/assistant-manager/" target="_self" style="font-size: 10px; color: gold;" title="Asystent-Taktyka">' + YouthAcademy + '</a></li><li><a href="http://trophymanager.com/finances/" target="_self" style="font-size: 10px; color: gold;" title="Ekonomia">' + YouthAcademyy + '</a></li><li><a href="http://trophymanager.com/youth-development/" target="_self" style="font-size: 10px; color: gold;" title="' + GoPlayerNotes + '">' + PlayerNotes + '</a></li><li><a href="http://trophymanager.com/_test_t" target="_self" style="font-size: 10px; color: gold;" title="Fanklub">' + PlayerNotess + '</a></li></ul></p><a href="http://trophymanager.com/teamsters/" target="_self" style="font-size: margin-top: 0px; padding-left: 0px;" title="' + Staff + '">' + Staff+ '<ul style="list-style-type:disc; margin-top: 0px; padding-left: 10px;"><li><a href="http://trophymanager.com/scouts/hire/" target="_self" style="font-size: 10px; color: gold;" title="' + GoHireScouts + '">' + HireScouts + '</a></li><li><a href="http://trophymanager.com/scouts/" target="_self" style="font-size: 10px; color: gold;" title="' + GoScoutReports + '">' + ScoutReports + '</a></li></li></ul></p><a href="http://trophymanager.com/training-overview/simple/" target="_self" style="font-size: margin-top: 0px; padding-left: 0px;" title="' + Training + '">' + Training+ '<ul style="list-style-type:disc; margin-top: 0px; padding-left: 10px;"></a><li><a href="http://trophymanager.com/training-overview/advanced/" target="_self" style="font-size: 10px; color: gold;" title="' + GoTrainingOverview + '">' + TrainingOverview + '</a></li><li><a href="http://trophymanager.com/training/" target="_self" style="font-size: 10px; color: gold;" title="' + GoTrainingTeams + '">' + TrainingTeams + '</a></li></ul></p><a href="http://trophymanager.com/forum/int/conferences/" target="_self" style="font-size: margin-top: 0px; padding-left: 0px;" title="' + Community + '">' + Community + '<ul style="list-style-type:disc; margin-top: 0px; padding-left: 10px;"></a><li><a href="http://trophymanager.com/forum/" target="_self" style="font-size: 10px; color: gold;" title="' + GoForum + '">' + Forum + '</a> ( <a href="http://trophymanager.com/forum/pl/help/" title="' + GoTransferForum + '">P</a> | <a href="http://trophymanager.com/forum/int/general/" title="' + GoGeneralForum + '">G</a> | <a href="http://trophymanager.com/forum/int/bugs/" title="' + GoAnnouncementForum + '">B</a> )</li><li><a href="http://trophymanager.com/forum/int/recent-posts/" target="_self" style="font-size: 10px; color: gold;" title="' + GoYourRecentPosts + '">' + YourRecentPosts + '</a></li><li><a href="http://trophymanager.com/user-guide/" target="_self" style="font-size: 10px; color: gold;" title="' + GoTMUserGuide + '">' + TMUserGuide + '</a></li><li><a href="http://trophymanager.com/forum/conference/18/" target="_self" style="font-size: 10px; color: gold;" title="' + GoTBConference + '">' + TBConference + '</a></li><li><a href="http://www.mathopenref.com/calculator.html" target="_self" style="font-size: 10px; color: gold;" title="Obliczanie odsetek: (suma/0,2)^0,7x0,75">' + TBConferencee + '</a></li><p></p><p></p><span style="position:relative; top:1px;left:-10px"><a href="http://trophymanager.com/free-pro/"><img src="http://iv.pl/images/07418830052396598983.gif" title="Darmowe pro" style="height: 22px;"></a></span></div>';
	}
}
else {
}
}
//Transferseite




if (myurl.match(/shortlist.*/))  {

/*skillsumspan_value = document.createElement("th");
skillsumspan_value.innerHTML="<th><strong></strong></th>";
skillsumspan2_value = document.createElement("th");
skillsumspan2_value.innerHTML="<th><strong>TB-Rating</strong></th>";
document.getElementsByTagName("table")[0].getElementsByTagName('tr')[0].insertBefore(skillsumspan_value, document.getElementsByTagName("table")[0].getElementsByTagName('tr')[0].getElementsByTagName('th')[16]);
document.getElementsByTagName("table")[0].getElementsByTagName('tr')[1].insertBefore(skillsumspan2_value, document.getElementsByTagName("table")[0].getElementsByTagName('tr')[1].getElementsByTagName('th')[16]);
*/
aux = document.getElementsByTagName("table")[0].getElementsByTagName("tr"); // holt alle Tabellenzeilen
for (var n = 0; n < aux.length; n++) {
	
	zeile=aux[n];
	skillsumme="";
	skillsumme_str="";

//Jugendspieler: Position auslesen
	pos_y = aux[n].cells[4].innerHTML;
	}
//	alert(pos_y)
}