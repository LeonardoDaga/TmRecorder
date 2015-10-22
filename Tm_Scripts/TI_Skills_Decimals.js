// ==UserScript== 
// @name TransferList TI_Skills_Decimals 
// @include trophymanager.com/* 
// @include trophymanager.com/players/* 
// @include test.trophymanager.com/* 
// @description 1 
//@version 1 


// @version 0.0.1.20150909113555 
// @namespace greasyfork.org/users/7445 
// ==/UserScript== 


// @version 2.2.3 

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
// Customize Section: Customize TrophyBuddy to suit your personal preferences /// 
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
//	/// 
var myclubid = " ";	// if myclubid = "", some functions won't work. Add your team-id like this: var myclubid = "22882" to unlock those additional features	/// 
var menubar = "yes";	// switch yes/no to turn the menubar on/off	/// 
var sidebar = "no";	// switch yes/no to turn the sidebar on/off	/// 
var PlayerDataPlus = "yes";	// switch yes/no to turn the PlayerDataPlus on/off	/// 
var PlayerDataPlusPosition = "topleft"; // you can choose between "topleft" and "bottomleft"	and "inside"	/// 
var hovermenu = "yes";	// switch to "yes" to bring back the old hover menu style from TM1.1	(adapted from TM Auxiliary and slightly modified)	///	
var alt_training = "no";	// switch to "yes" to show an alternate version of the training overview (adapted from TM Auxiliary and slightly modified)	/// 
var old_skills = "no";	// switch to "yes" to to bring back the old look of the skills on the player page (adapted from TM Auxiliary and slightly modified)	/// 
var bronze_stars = "yes";	// switch to "no" to to add bronze stars for skill values 18 for coaches and scouts	/// 
var oldpos = "no";	// switch to "yes" to to bring back the old look of player positions	/// 
//	/// 
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

var language = "pl"; // choose your language, check supported languages below: 

var rou_factor = 0.00405; 

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
//	SUPPORTED LANGUAGES	/// 
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
//	/// 
//The following languages are supported right now: /// 
//	/// 
//	ar = Arabic	/// 
//	da = Danish	///	/// 
//	de = German	/// 
//	en = English	/// 
//	fr = French	/// 
//	he = Hebrew	/// 
//	hu = Hungarian	/// 
//	pl = Polish	/// 
//	ro = Romanian	/// 
//	sl = Slovakian	/// 
//	/// 
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

if (document.URL == "trophymanager.com/scouts/hire/") { 

if (bronze_stars == "no") { 

var load,execute,loadAndExecute;load=function(a,b,c){var d;d=document.createElement("script"),d.setAttribute("src",a),b!=null&&d.addEventListener("load",b),c!=null&&d.addEventListener("error",c),document.body.appendChild(d);return d},execute=function(a){var b,c;typeof a=="function"?b="("+a+")();":b=a,c=document.createElement("script"),c.textContent=b,document.body.appendChild(c);return c},loadAndExecute=function(a,b){return load(a,function(){return execute(b)})}; 
loadAndExecute("//ajax.googleapis.com/ajax/libs/jquery/1.6.4/jquery.min.js", function() { 

// Show the stars! 
$('td.align_center:contains("18")').html('<img src="patrick-meurer.de/tm/bronze_star.png">'); 
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
$('table.border_bottom td:contains("18")').html('<img src="patrick-meurer.de/tm/bronze_star.png">'); 
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

if (document.URL == "trophymanager.com/coaches/hire/") { 

if (bronze_stars == "no") { 

var load,execute,loadAndExecute;load=function(a,b,c){var d;d=document.createElement("script"),d.setAttribute("src",a),b!=null&&d.addEventListener("load",b),c!=null&&d.addEventListener("error",c),document.body.appendChild(d);return d},execute=function(a){var b,c;typeof a=="function"?b="("+a+")();":b=a,c=document.createElement("script"),c.textContent=b,document.body.appendChild(c);return c},loadAndExecute=function(a,b){return load(a,function(){return execute(b)})}; 
loadAndExecute("//ajax.googleapis.com/ajax/libs/jquery/1.6.4/jquery.min.js", function() { 

// Show the stars! 
$('td.align_center:contains("18")').html('<img src="patrick-meurer.de/tm/bronze_star.png">'); 
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
$('td:contains("18")').html('<img src="patrick-meurer.de/tm/bronze_star.png">');
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
/*	pos_y = aux.cells.innerHTML; 
} 

var skillsumspan_HL = document.createElement("span"); 
skillsumspan_HL.innerHTML="<div style=\"color: gold;\"><b>TB-Rating</b></div>"; 
document.getElementsByTagName("table").getElementsByTagName('tr').getElementsByTagName('th').appendChild(skillsumspan_HL); 

} 
} 
*/ 

if (myurl.match(/training-overview/)) { 

if (document.URL == "trophymanager.com/training-overview/advanced/") { 
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

var checktable = document.getElementsByTagName("table"); 
checktable = checktable.getAttribute("class"); 

if (checktable == "zebra padding") { 

var checksquad = document.getElementsByTagName("a"); 
checksquad = checksquad.getAttribute("href"); 
checksquad = checksquad.replace(/+/g,''); 
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

if (document.URL == "trophymanager.com/account/club-info/"){ 

} 
else { 

league_try = document.getElementsByTagName("a").getAttribute("href"); 
league_try = league_try.search("league"); 
if (league_try != -1) { 
n=0; 
} 
else { 
n=1; 
} 
var leaguecheck = document.getElementsByTagName("a"); 
leaguecheck = leaguecheck.getAttribute("href"); 
leaguecheck = leaguecheck.replace("/league/", ""); 
//leaguecheck = leaguecheck.replace("/league/", ""); 
leaguecheck = leaguecheck.substr(3,leaguecheck.length); 
leaguecheck = leaguecheck.replace(/+/g,''); 
leaguecheck = leaguecheck.substr(0,1) + '.' + leaguecheck.substr(1,leaguecheck.length); 
//alert(leaguecheck) 

var oldleague = document.createElement("span"); 
oldleague.innerHTML="<span style=\"color: gold;\"><b> (" + leaguecheck + ")</b></span>"; 
document.getElementsByTagName("a").appendChild(oldleague); 

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
div_area.innerHTML="<div id=\"area\" style=\"position: absolute; z-index: 1000; width: 175px; margin-top: 25px; color: #ff9900; -moz-opacity: .8; text-align: middle; color: gold; display:inline;\"><table style=\"margin-bottom: -1em; background: #5F8D2D; border: 2px #275502 outset;\"><tr><th style=\"padding-left: 5px;\">Gwiazdki</th><th title=\"The potential values from old TM\">Stary Potencjal</th></tr><tr><td><img src=\"trophymanager.com/pics/star.png\"><img src=\"trophymanager.com/pics/star.png\"><img src=\"trophymanager.com/pics/star.png\"><img src=\"trophymanager.com/pics/star.png\"><img src=\"trophymanager.com/pics/star.png\"></td>&l... title=\"+ Best 19*\">best19-20</td></tr><tr><td><img src=\"trophymanager.com/pics/star.png\"><img src=\"trophymanager.com/pics/star.png\"><img src=\"trophymanager.com/pics/star.png\"><img src=\"trophymanager.com/pics/star.png\"><img src=\"trophymanager.com/pics/half_star.png\"></td&... title=\"+ Worst 20*\">17-18-19</td></tr><tr><td><img src=\"trophymanager.com/pics/star.png\"><img src=\"trophymanager.com/pics/star.png\"><img src=\"trophymanager.com/pics/star.png\"><img src=\"trophymanager.com/pics/star.png\"><img src=\"trophymanager.com/pics/dark_star.png\"></td&... src=\"trophymanager.com/pics/star.png\"><img src=\"trophymanager.com/pics/star.png\"><img src=\"trophymanager.com/pics/star.png\"><img src=\"trophymanager.com/pics/half_star.png\"><img src=\"trophymanager.com/pics/dark_star.png\"></td&... src=\"trophymanager.com/pics/star.png\"><img src=\"trophymanager.com/pics/star.png\"><img src=\"trophymanager.com/pics/star.png\"><img src=\"trophymanager.com/pics/dark_star.png\"><img src=\"trophymanager.com/pics/dark_star.png\"></td&... src=\"trophymanager.com/pics/star.png\"><img src=\"trophymanager.com/pics/star.png\"><img src=\"trophymanager.com/pics/half_star.png\"><img src=\"trophymanager.com/pics/dark_star.png\"><img src=\"trophymanager.com/pics/dark_star.png\"></td&... src=\"trophymanager.com/pics/star.png\"><img src=\"trophymanager.com/pics/star.png\"><img src=\"trophymanager.com/pics/dark_star.png\"><img src=\"trophymanager.com/pics/dark_star.png\"><img src=\"trophymanager.com/pics/dark_star.png\"></td&... 
document.getElementsByTagName("div").appendChild(div_area); 

} 




//alert ("Skript ist aktiv") 

if (myurl.match(/players/)) { // hier wird geprueft, ob das die richtige Seite ist 

var check_statpage = document.URL; 
check_statpage = check_statpage.search("statistics"); 


if (document.URL == "trophymanager.com/players/"){ 

function embed() { 
var oldFunc = makeTable; 

makeTable = function() { 



myTable = document.createElement('table'); 
myTable.className = "hover zebra"; 

construct_th(); 
var z=0; 
for (i=0; i<players_ar.length; i++) { 
if (players_ar != "GK" && add_me(players_ar) && filter_squads()) { 
construct_tr(players_ar, z); 
z++; 
} 
} 
if (z == 0) { 
var myRow = myTable.insertRow(-1); 
var myCell = myRow.insertCell(-1); 
myCell.colSpan = 24; 
myCell.innerHTML = other_header; 
} 
if (filters_ar == 1) { 
var myRow = myTable.insertRow(-1); 
var myCell = myRow.insertCell(-1); 
myCell.className = "splitter"; 
myCell.colSpan = "50"; 
myCell.innerHTML = gk_header; 
construct_th(true); 
z=0; 
for (i=0; i<players_ar.length; i++) { 
if (players_ar == "GK" && filter_squads()) { 
if (!(players_ar < age_min || players_ar > age_max)) { 
construct_tr(players_ar, z, true); 
z++; 
} 
} 
} 
} 
$e("sq").innerHTML = ""; 
$e("sq").appendChild(myTable); 
activate_player_links($(myTable).find("")); 
init_tooltip_by_elems($(myTable).find("")) 
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
aux = document.getElementsByTagName("table"); // holt die gesamte Tabelle 
} 
else { 
aux = document.getElementsByTagName("table"); // holt die gesamte Tabelle 
} 
auxx = document.getElementsByTagName("table"); // holt die gesamte Tabelle	
pos_td = document.getElementsByTagName("strong"); // holt die gesamte Tabelle 
auxspan = document.getElementsByTagName("span"); // holt die gesamte Tabelle 
aux2 = document.getElementsByTagName("p"); // holt die gesamte Tabelle 
aux3 = document.getElementsByTagName("p"); // holt die gesamte Tabelle 
aux4 = document.getElementsByTagName("p"); // holt die gesamte Tabelle 

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
$('table#new_skill_table tr:eq(0) td:eq(' + index + ')').html(attributeNames.substr(0, 3)); 
$('table#new_skill_table tr:eq(1) td:eq(' + index + ')').html(attributeValues); 
}); 

// Inject second row of attributes (14 attributes for non-goalies) 
if (attributeNames.length == 18) { 
$.each(attributeNames.slice(9), function (index) { 
$('table#new_skill_table tr:eq(2) td:eq(' + index + ')').html(attributeNames.substr(0, 3)); 
$('table#new_skill_table tr:eq(3) td:eq(' + index + ')').html(attributeValues); 
}); 
} 
else { 
$.each(attributeNames.slice(7), function (index) { 
$('table#new_skill_table tr:eq(2) td:eq(' + (index + 3) + ')').html(attributeNames.substr(0, 3)); 
$('table#new_skill_table tr:eq(3) td:eq(' + (index + 3) + ')').html(attributeValues); 
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

asi_check = auxx.getElementsByTagName("tr").getElementsByTagName("td").innerHTML; 
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
//	var asi = asi_check.getElementsByTagName("span").innerHTML; 


// fuer jeden Skill muss so geprueft werden, ob ein img-Tag oder ein span-Tag innerhalb der tabellenzelle vorliegt 

//Strength 
stae_td = aux.getElementsByTagName("tr").getElementsByTagName("td"); 

if(stae_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen 
{ 
var stae = stae_td.getElementsByTagName("span").innerHTML; 
//alert ("span " + stae) 
} 
else if(stae_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen 
var stae = stae_td.getElementsByTagName("img").getAttribute("alt"); 
//alert ("img " + stae) 
} 
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen 
var stae = aux.rows.cells.innerHTML; 
//alert ("normal " + stae) 
} 
//Stamina 
kon_td = aux.getElementsByTagName("tr").getElementsByTagName("td"); 

if(kon_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen 
{ 
var kon = kon_td.getElementsByTagName("span").innerHTML; 
//alert ("span " + kon) 
} 
else if(kon_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen 
var kon = kon_td.getElementsByTagName("img").getAttribute("alt"); 
//alert ("img " + kon) 
} 
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen 
var kon = aux.rows.cells.innerHTML; 
//alert ("normal " + kon) 
} 

//Pace 
ges_td = aux.getElementsByTagName("tr").getElementsByTagName("td"); 

if(ges_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen 
{ 
var ges = ges_td.getElementsByTagName("span").innerHTML; 
//alert ("span " + ges) 
} 
else if(ges_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen 
var ges = ges_td.getElementsByTagName("img").getAttribute("alt"); 
//alert ("img " + ges) 
} 
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen 
var ges = aux.rows.cells.innerHTML; 
//alert ("normal " + ges) 
} 

//Marking 
man_td = aux.getElementsByTagName("tr").getElementsByTagName("td"); 

if(man_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen 
{ 
var man = man_td.getElementsByTagName("span").innerHTML; 
//alert ("span " + man) 
} 
else if(man_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen 
var man = man_td.getElementsByTagName("img").getAttribute("alt"); 
//alert ("img " + man) 
} 
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen 
var man = aux.rows.cells.innerHTML; 
//alert ("normal " + man) 
} 

//Tackling 
zwe_td = aux.getElementsByTagName("tr").getElementsByTagName("td"); 

if(zwe_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen 
{ 
var zwe = zwe_td.getElementsByTagName("span").innerHTML; 
//alert ("span " + zwe) 
} 
else if(zwe_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen 
var zwe = zwe_td.getElementsByTagName("img").getAttribute("alt"); 
//alert ("img " + zwe) 
} 
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen 
var zwe = aux.rows.cells.innerHTML; 
//alert ("normal " + zwe) 
} 

//Workrate 
lau_td = aux.getElementsByTagName("tr").getElementsByTagName("td"); 

if(lau_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen 
{ 
var lau = lau_td.getElementsByTagName("span").innerHTML; 
//alert ("span " + lau) 
} 
else if(lau_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen 
var lau = lau_td.getElementsByTagName("img").getAttribute("alt"); 
//alert ("img " + lau) 
} 
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen 
var lau = aux.rows.cells.innerHTML; 
//alert ("normal " + lau) 
} 

//Positioning 
ste_td = aux.getElementsByTagName("tr").getElementsByTagName("td"); 

if(ste_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen 
{ 
var ste = ste_td.getElementsByTagName("span").innerHTML; 
//alert ("span " + ste) 
} 
else if(ste_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen 
var ste = ste_td.getElementsByTagName("img").getAttribute("alt"); 
//alert ("img " + ste) 
} 
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen 
var ste = aux.rows.cells.innerHTML; 
//alert ("normal " + ste) 
} 

//Passing 
pass_td = aux.getElementsByTagName("tr").getElementsByTagName("td"); 

if(pass_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen 
{ 
var pass = pass_td.getElementsByTagName("span").innerHTML; 
//alert ("span " + pass) 
} 
else if(pass_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen 
var pass = pass_td.getElementsByTagName("img").getAttribute("alt"); 
//alert ("img " + pass) 
} 
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen 
var pass = aux.rows.cells.innerHTML; 
//alert ("normal " + pass) 
} 

//Crossing 
fla_td = aux.getElementsByTagName("tr").getElementsByTagName("td"); 

if(fla_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen 
{ 
var fla = fla_td.getElementsByTagName("span").innerHTML; 
//alert ("span " + fla) 
} 
else if(fla_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen 
var fla = fla_td.getElementsByTagName("img").getAttribute("alt"); 
//alert ("img " + fla) 
} 
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen 
var fla = aux.rows.cells.innerHTML; 
//alert ("normal " + fla) 
} 

//Technique 
tec_td = aux.getElementsByTagName("tr").getElementsByTagName("td"); 

if(tec_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen 
{ 
var tec = tec_td.getElementsByTagName("span").innerHTML; 
//alert ("span " + tec) 
} 
else if(tec_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen 
var tec = tec_td.getElementsByTagName("img").getAttribute("alt"); 
//alert ("img " + tec) 
} 
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen 
var tec = aux.rows.cells.innerHTML; 
//alert ("normal " + tec) 
} 

//Heading 
kop_td = aux.getElementsByTagName("tr").getElementsByTagName("td"); 

if(kop_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen 
{ 
var kop = kop_td.getElementsByTagName("span").innerHTML; 
//alert ("span " + kop) 
} 
else if(kop_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen 
var kop = kop_td.getElementsByTagName("img").getAttribute("alt"); 
//alert ("img " + kop) 
} 
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen 
var kop = aux.rows.cells.innerHTML; 
//alert ("normal " + kop) 
} 

//Shooting 
tor_td = aux.getElementsByTagName("tr").getElementsByTagName("td"); 

if(tor_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen 
{ 
var tor = tor_td.getElementsByTagName("span").innerHTML; 
//alert ("span " + tor) 
} 
else if(tor_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen 
var tor = tor_td.getElementsByTagName("img").getAttribute("alt"); 
//alert ("img " + tor) 
} 
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen 
var tor = aux.rows.cells.innerHTML; 
//alert ("normal " + tor) 
} 

//Longshots 
wei_td = aux.getElementsByTagName("tr").getElementsByTagName("td"); 

if(wei_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen 
{ 
var wei = wei_td.getElementsByTagName("span").innerHTML; 
//alert ("span " + wei) 
} 
else if(wei_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen 
var wei = wei_td.getElementsByTagName("img").getAttribute("alt"); 
//alert ("img " + wei) 
} 
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen 
var wei = aux.rows.cells.innerHTML; 
//alert ("normal " + wei) 
} 

//Setpieces 
sta_td = aux.getElementsByTagName("tr").getElementsByTagName("td"); 

if(sta_td.getElementsByTagName("span").length==1) // wenn span Tag, wird der Inhalt des ersten Span-Tags ausgelesen 
{ 
var sta = sta_td.getElementsByTagName("span").innerHTML; 
//alert ("span " + sta) 
} 
else if(sta_td.getElementsByTagName("img").length==1){ // wenn img Tag, wird das alt-Atribut des ersten img-Tags ausgelesen 
var sta = sta_td.getElementsByTagName("img").getAttribute("alt"); 
//alert ("img " + sta) 
} 
else{ // wenn keins von beiden, wird der Inhalt der Tabellenzelle uebernommen 
var sta = aux.rows.cells.innerHTML; 
//alert ("normal " + sta) 
} 



//LP, XP, ASI und Gehalt auslesen 

//Playername 
var name = document.title; // holt den Titel-Tag 
name = name.substring(0,name.length-20); 
//alert(name)	

//Country 
country = document.getElementsByTagName("img").getAttribute("src"); 
switch (country) { 

case ("/pics/flags/gradient/de.png"): 
country = "Germany"; 
//alert(country) 
break; 

default: 
country = "Country not included yet"; 
//alert(country) 
} 

verein_td = auxx.getElementsByTagName("tr").getElementsByTagName("td"); 
var verein = verein_td.getElementsByTagName("a").innerHTML; 
var clubid = verein_td.getElementsByTagName("a").getAttribute("href"); 
clubid = clubid.substring(6,clubid.length-1); 
//alert(verein) 
//alert(clubid) 

//Routine 
var rou = auxx.rows.cells.innerHTML; 
//alert(rou) 

//Wage 
gehalt_td = auxx.getElementsByTagName("tr").getElementsByTagName("td"); 
var gehalt = gehalt_td.getElementsByTagName("span").innerHTML; 
//alert(gehalt)	

//var asi = auxx.rows.cells.innerHTML; 
//asi = asi.replace(" ", ""); 
//alert(asi) 

/*	var status = auxx.rows.cells.innerHTML; 
if (status == '<img src="/pics/mini_green_check.png"> ') { 
status = "Gesund"; 
//alert(status) 
} 

//status = status.substring(0,6); 
if (status == "Gesund") { 
status = status; 
//alert(status) 
} 
else if(aux.rows.cells.getElementsByTagName("img").getAttribute("title") == "Dieser Spieler ist gesperrt"){ 
var status = aux.rows.cells.getElementsByTagName("span").innerHTML; 
alert(status) 
status = status.replace(" ", ""); 
status = status.replace(" ", ""); 
alert(status) 
status = 'Sperre:' + status; 
} 
else if(aux.rows.cells.getElementsByTagName("img").getAttribute("title") == "Dieser Spieler ist verletzt") { 
var status = aux.rows.cells.innerHTML; 
status = status.substring(130,status.length-69); 
status = 'Verletzung:' + status; 
} 
*/	
/*	alter_td = auxx.getElementsByTagName("tr").getElementsByTagName("td");	
var alter = auxx.rows.cells.innerHTML; 
alter = alter.substring(24,alter.length-70); 
alter_year = alter.substring(0,2); 
alter_month = alter.substring(3,alter.length); 
alter_month = alter_month.replace("Jahre",""); 
alter_month = alter_month.replace("Monate",""); 
alter_month = alter_month.replace(/ /i,""); 
alter = alter_year + "-" + alter_month; 
*/	//alert(alter) 


//Position 
var pos_zweinull = document.getElementsByTagName("strong").getElementsByTagName("span"); // holt alle Spanelemente 
var poslength = pos_zweinull.length; 
//alert (poslength) 
if (poslength == 2) { 
var pos = document.getElementsByTagName("strong").getElementsByTagName("span").innerHTML; 
//alert(pos) 
} 
else if (poslength == 3) { 
var pos1 = document.getElementsByTagName("strong").getElementsByTagName("span").innerHTML; 
var pos2 = document.getElementsByTagName("strong").getElementsByTagName("span").innerHTML; 
pos = pos1 + pos2; 
//alert(pos) 
} 
else if (poslength == 5) { 
var pos1 = document.getElementsByTagName("strong").getElementsByTagName("span").innerHTML; 
var pos2 = document.getElementsByTagName("strong").getElementsByTagName("span").innerHTML; 
var pos3 = document.getElementsByTagName("strong").getElementsByTagName("span").innerHTML; 
var pos4 = document.getElementsByTagName("strong").getElementsByTagName("span").innerHTML; 
pos = pos1 + pos2 + pos3 + pos4; 
//alert(pos) 
} 

}