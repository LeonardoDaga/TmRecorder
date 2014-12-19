players = {};
post_players = {};
players_by_id = {}; // array of player_id : i - in player[i];
on_field = {};
on_subs = {};
on_field_assoc = {};
formation_by_pos = {};
positions = {};

function tactics_init(callback)
{
	data = {};
	
	data["formation"] = {"0":"gk", "1":"dl", "2":"dcl", "3":"dcr", "4":"dr", "5":"ml", "6":"mcl", "7":"mcr", "8":"mr", "9":"fcl", "10":"fcr"};
	data["formation_by_pos"] = {"0":"11", "1":"1", "2":"2", "3":null, "4":"3", "5":"4", "6":null, "7":null, "8":null, "9":null, "10":null, "11":"5", "12":"6", "13":null, "14":"7", "15":"8", "16":null, "17":null, "18":null, "19":null, "20":null, "21":"9", "22":null, "23":"10"};
	data["positions"] = {"0":"gk", "1":"dl", "2":"dcl", "3":"dc", "4":"dcr", "5":"dr", "6":"dml", "7":"dmcl", "8":"dmc", "9":"dmcr", "10":"dmr", "11":"ml", "12":"mcl", "13":"mc", "14":"mcr", "15":"mr", "16":"oml", "17":"omcl", "18":"omc", "19":"omcr", "20":"omr", "21":"fcl", "22":"fc", "23":"fcr"};
	data["formation_assoc"] = {"gk":"11", "dl":"1", "dcl":"2", "dcr":"3", "dr":"4", "ml":"5", "mcl":"6", "mcr":"7", "mr":"8", "fcl":"9", "fcr":"10"};
	data["defending"] = [0, 160, 240, 240, 240, 160, 105, 135, 135, 135, 105, 45, 50, 50, 50, 45, 20, 25, 25, 25, 20, 0, 0, 0];
	data["attacking_balanced"] = [0,2,0,0,0,2,6,5,5,5,6,10,10,10,10,10,16,16,16,16,16,22,22,22];
	data["attacking_shortpass"] = [0,0,0,0,0,0,6,6,6,6,6,12,12,12,12,12,18,18,18,18,18,24,24,24];
	data["attacking_wing"] = [0,0,0,0,0,0,6,6,6,6,6,12,12,12,12,12,18,18,18,18,18,24,24,24];
	data["attacking_counter"] = [0,0,0,0,0,0,6,6,6,6,6,12,12,12,12,12,18,18,18,18,18,24,24,24];
	data["attacking_longball"] = [0,0,0,0,0,0,6,2,2,2,6,6,6,6,6,6,12,12,12,12,12,18,18,18];
	data["attacking_through"] = [0,0,0,0,0,0,6,2,2,2,6,6,6,6,6,6,12,12,12,12,12,18,18,18];
	
	
	data["finishing"] = [30,70,53,33,30];
	data["heading"] = [65,15,12,32,65];
	data["longshots"] = [5,15,35,35,5];
	
	
	data["assist"] = [0,8,4,4,4,8,10,8,8,8,10,12,12,12,12,12,16,16,16,16,16,12,12,12];
	
	data["chance_types"] = {
							"gk": [0,0,0,0,0],
							"dl": [25,21,0,9,45],
							"dr": [25,21,0,9,45],
							"dcl": [45,25,26,4,0],
							"dc": [45,25,26,4,0],
							"dcr": [45,25,26,4,0],
							"dmr": [14,12,25,12,37],
							"dml": [14,12,25,12,37],
							"dmc": [22,15,51,12,0],
							"dmcl": [22,15,51,12,0],
							"dmcr": [22,15,51,12,0],
							"omr": [0,20,24,8,48],
							"oml": [0,20,24,8,48],
							"omc": [0,40,50,10,0],
							"omcr": [0,40,50,10,0],
							"omcl": [0,40,50,10,0],
							"mr": [10,20,15,10,45],
							"ml": [10,20,15,10,45],
							"mc": [15,20,50,15,0],
							"mcr": [15,20,50,15,0],
							"mcl": [15,20,50,15,0],
							"fcl": [0,40,50,10,0],
							"fc": [0,40,50,10,0],
							"fcr": [0,40,50,10,0],
						};
	
	data["players"] = {"0": {"no":"1", "player_id":"11", "lastname":"", "name":""},
						"1": {"no":"2", "player_id":"1", "lastname":"", "name":""},
						"2": {"no":"3", "player_id":"2", "lastname":"", "name":""},
						"3": {"no":"4", "player_id":"3", "lastname":"", "name":""},
						"4": {"no":"5", "player_id":"4", "lastname":"", "name":""},
						"5": {"no":"6", "player_id":"5", "lastname":"", "name":""},
						"6": {"no":"7", "player_id":"6", "lastname":"", "name":""},
						"7": {"no":"8", "player_id":"7", "lastname":"", "name":""},
						"8": {"no":"9", "player_id":"8", "lastname":"", "name":""},
						"9": {"no":"10", "player_id":"9", "lastname":"", "name":""},
						"10": {"no":"11", "player_id":"10", "lastname":"", "name":""}};

						
		players = data["players"];

		for(var i in players)
			{
				var p = players[i];
				players[i];
				players_by_id[p["player_id"]] = p;
			}
			on_field = data["formation"];
			formation_by_pos = data["formation_by_pos"];
	
			on_field_assoc = data["formation_assoc"];
			positions = data["positions"];
			tactics_field_players();

			make_droppable();
			if(typeof callback == "function"){
				callback.call(this);
			}

	make_tactics_drag_shirt("");
	hide_tactics_drag_shirt();
}

function tactics_list_players()
{
	var $list = $("#tactics_list_list");
	var $ul = $("<ul>").addClass("tactics_list");
	var gk_header = false;
	for(var i in players)
	{
		var p = players[i];
		if(p)
		{
				var str = "<div class=\"list_column no_col align_center\">"+p["no"]+"</div>"
					+"<div class=\"vert_split\"></div>"
					+ "<div class=\"list_column pos_col align_center\">"+p["favorite_position_short"]+"</div>"
					+"<div class=\"vert_split\"></div>"
					+ "<div class=\"list_column name_col\"><div class=\"padding\"><span class='player_name' player_id='"+p["player_id"]+"'>"+p["name"]+"</span></div></div>"
					+"<div class=\"vert_split\"></div>"

					+"<div class=\"clear\"></div>";
				var $li = $("<li>").html(str).appendTo($ul).attr("player_id",p["player_id"]).attr("player_link",p["player_id"]).attr("i",i).addClass("draggable").attr("player_no",p["no"]);
	//			$li.attr("lastname",p["lastname"]);
//				$li.hoverIntent(hoverIntentConfig);
				$li.mouseover(function(){$(this).addClass("hover")}).mouseout(function(){$(this).removeClass("hover")});
				$li.find(".favposition").removeClass("short");
				if(on_field[p["player_id"]]) {
					$li.addClass("on_field");
					$li.attr("position",on_field[p["player_id"]]);
				}
				if(on_subs[p["player_id"]]){
					$li.attr("position",on_subs[p["player_id"]]);
					$li.addClass("on_subs");
				}
				// Player link on CTRL+CLICK
				$li.find(".player_name").click(function(e){
					if(e.ctrlKey)
					{
						window.open("/players/"+$(this).attr("player_id")+"/"+$(this).html().replace(" ","_").replace(". ","_")+"/");
					}
				});
				make_draggable($li);
				activate_player_links($li);
		}
	} // i in players
	$list.html($ul);
	$list.verticalScroll({
		"force_scroll": true,
		"style":"dark",
		"scroll_width":25
	});
}

var sm_count = 0;

function calculate_stuff(player_id) {
	alert(player_id);
}
var fissi = 0;
function tactics_set_player(p,$elem)
{

	$("[icons='"+data["formation"][p["player_id"]]+"']").remove();
	if($elem.hasClass("field_player"))
	{
		$elem.attr("player_set","true");
		$elem.find(".field_player_name").html(p["lastname"]);
		$elem.find(".tactics_shirt").html(p["no"]);
		$elem.attr("player_no",p["no"]).attr("player_id",p["player_id"]).show();
		
	}
	

		
		var $icons = $elem.find(".icons");
		
		if($icons.length > 0) {
			$icons.remove();
		}
		
		if ($elem.attr("position")!="gk") {
			$icons = $("<div class=\"icons\" />").appendTo($elem);
			$icons.attr("icons", $elem.attr("position"));
		
			$icons.append(
				$("<span>").css({"color":"#CC0000", "font-weight":"bold"}).attr("player_id_attacking", p["player_id"]).html("Att: <br />"),
				$("<span>").css({"color":"#FFCC00", "font-weight":"bold"}).attr("player_id_assist", p["player_id"]).html("As: <br />"),
				$("<span>").css({"color":"#0099FF", "font-weight":"bold"}).attr("player_id_defending", p["player_id"]).html("D:")
			);
		}
	
	
	
	fissi++;
	if (fissi>10) {
		$(".error_field").hide();
				
		update_tooltips();
		update_defensive_bonus();
		update_possession_bonus();
		update_attacking_bonus();
	}
	if (p["no"] != "1"){
		make_draggable($elem);
	}
	
}

function update_defensive_bonus() {
	var bonus = -8;
	var defenders = 0;
	var central_defenders = 0;
	var wings = 0;
	for (var i=1;i<11;i++) {
		if (data["formation_by_pos"][i] && i<6) {
			bonus=bonus+2;
			defenders ++;
			if (i==1 || i==5) wings++;
			else central_defenders++;
		} else if (data["formation_by_pos"][i]) bonus++;
	}
	
	//penalty for too few central defenders if no wings
	if (central_defenders<3 && wings==0) {
		bonus = bonus - 1;
		$("#defense_center").show();
	}
	
	//too few central defenders no matter what
	if (central_defenders==0) {
		bonus = bonus - 2;
		$("#defense_center").show();
	} else if (central_defenders==1) {
		bonus = bonus - 1;
		$("#defense_center").show();	
	}
	
	//scewed formation
	if (wings==1) {
		bonus = bonus - 1;
		$("#defense_left").show();
		$("#defense_right").show();
	}
		
	if (bonus>2.5) bonus = 2.5;
	
	$("#defending_bonus").html(bonus);
}
function update_possession_bonus() {
	var bonus = -8;
	var midfielders = 0;
	var left_side = -1;
	var right_side = -1;
	var m_om = -4;
	
	var dm_mc = -1;
	var m_omc = -1;
	
	for (var i=6;i<21;i++) {
		if (data["formation_by_pos"][i] && (i<11 || i>15)) {
			bonus++;
			if (i>15) m_om = 0;
			
			if (i==17 || i==18 || i==19) m_omc = 0;
			if (i==7 || i ==8 || i==9) dm_mc = 0;
		} else if (data["formation_by_pos"][i]) {
			bonus = bonus +2;
			m_om = 0;
			
			if (i==12 || i==13 || i==14) {
				dm_mc = 0;
				m_omc = 0;
			}
		}
		
		if (data["formation_by_pos"][i]) {
			if (i==6 || i==11 || i==16) left_side = 0;
			else if (i==10 || i==15 || i==20) right_side = 0;
		}
	}
	
	var reset_left;
	var reset_right;
	if ((left_side<0 && (data["formation_by_pos"][12] && data["formation_by_pos"][13] && data["formation_by_pos"][14])==null) || (left_side<0 && right_side==0)) $("#midfield_left").show();
	else reset_left = true;
	
	if ((right_side<0 && (data["formation_by_pos"][12] && data["formation_by_pos"][13] && data["formation_by_pos"][14])==null) || (right_side<0 && left_side==0)) $("#midfield_right").show();
	else reset_right = true;
	
	if (reset_left) left_side = 0;
	if (reset_right) right_side = 0;
	
	if (dm_mc<0 && m_omc<0) $("#midfield").show();
	else if (m_om<0) $("#midfield_center").show();
	else if (dm_mc<0) $("#defensiv_midfield_center").show();
	else if (m_omc<0) $("#offensiv_midfield_center").show();
	
	if (data["formation_by_pos"][1] && data["formation_by_pos"][6] && data["formation_by_pos"][11] || (data["formation_by_pos"][16] && (!data["formation_by_pos"][1] && !data["formation_by_pos"][6] && !data["formation_by_pos"][11]))) {
		$("#wing_def_left").show();
		bonus--;
	} else if (data["formation_by_pos"][6] && data["formation_by_pos"][11] && data["formation_by_pos"][16]) {
		$("#wing_off_left").show();
		bonus--;
	}
	
	if (data["formation_by_pos"][5] && data["formation_by_pos"][10] && data["formation_by_pos"][15] || (data["formation_by_pos"][20] && (!data["formation_by_pos"][5] && !data["formation_by_pos"][10] && !data["formation_by_pos"][15])))  {
		$("#wing_def_right").show();
		bonus--;
	} else if (data["formation_by_pos"][10] && data["formation_by_pos"][15] && data["formation_by_pos"][20]) {
		$("#wing_off_right").show();
		bonus--;
	}
	
	if (m_omc<0 && dm_mc<0) bonus = bonus -3;
	else if (m_om==0 && (m_omc<0 || dm_mc<0)) bonus--;
	
	bonus = bonus + left_side + right_side + m_om;
	
	if (bonus>2.5) bonus = 2.5;
	$("#possession_bonus").html(bonus);
}
function update_attacking_bonus() {
	var bonus = -4;
	var forwards = -5;
	
	for (var i=16;i<24;i++) {
		if (data["formation_by_pos"][i] && i<21) {
			bonus++;
		} else if (data["formation_by_pos"][i]) {
			forwards = 0;
			bonus = bonus + 2;
		}
	}
	
	if (forwards<0) $("#attack_center").show();
	else if (bonus<-1) {
		bonus--;
		$("#attack_small").show();
	}
	
	bonus = bonus + forwards;
	if (bonus>2.5) bonus = 2.5;

	$("#attacking_bonus").html(bonus);
}

function update_tooltips() {
	var shortpassing = 0;
	var counter = 0;
	var through = 0;
	var wing = 0;
	var longball = 0;

	for (var i=01;i<24;i++) {
		if (data["formation_by_pos"][i]) {
			set_values(data["formation_by_pos"][i]);
			
			longball += data["chance_types"][data["positions"][i]][0];
			through += data["chance_types"][data["positions"][i]][1];
			shortpassing += data["chance_types"][data["positions"][i]][2];
			counter += data["chance_types"][data["positions"][i]][3];
			wing += data["chance_types"][data["positions"][i]][4];
		}
	}
	
	var final_shortpassing = Math.round(shortpassing/(shortpassing+counter+through+wing+longball)*100);
	var final_counter = Math.round(counter/(shortpassing+counter+through+wing+longball)*100);
	var final_through = Math.round(through/(shortpassing+counter+through+wing+longball)*100);
	var final_wing = Math.round(wing/(shortpassing+counter+through+wing+longball)*100);
	var final_longball = Math.round(longball/(shortpassing+counter+through+wing+longball)*100);
	
	if ($("#attack_type").val()==2) {
		final_shortpassing = final_shortpassing + 16;
		final_counter = final_counter-4;
		final_wing = final_wing-4;
		final_longball = final_longball-4;
		final_through = final_through-4;
	} else if ($("#attack_type").val()==3) {
		final_longball = final_longball +16;
		final_counter = final_counter-4;
		final_wing = final_wing-4;
		final_shortpassing = final_shortpassing-4;
		final_through = final_through-4;
	} else if ($("#attack_type").val()==4) {
		final_through = final_through +16;
		final_counter = final_counter-4;
		final_wing = final_wing-4;
		final_longball = final_longball-4;
		final_shortpassing = final_shortpassing-4;
		
	} else if ($("#attack_type").val()==5) {
		final_wing = final_wing + 16;
		
		final_counter = final_counter-4;
		final_shortpassing = final_shortpassing-4;
		final_longball = final_longball-4;
		final_through = final_through-4;
	} else if ($("#attack_type").val()==6) {
		final_counter = final_counter + 16;
		
		final_shortpassing = final_shortpassing -4;
		final_wing = final_wing -4;
		final_longball = final_longball -4;
		final_through = final_through -4;
		
	}
	$("#shortpassing_amount").addClass("chance_bar mid").css({"width":final_shortpassing*2.5+"px"});
	$("#counter_amount").addClass("chance_bar mid").css({"width":final_counter*2.5+"px"});
	$("#through_amount").addClass("chance_bar mid").css({"width":final_through*2.5+"px"});
	$("#wing_amount").addClass("chance_bar mid").css({"width":final_wing*2.5+"px"});
	$("#longball_amount").addClass("chance_bar mid").css({"width":final_longball*2.5+"px"});
	
	var heading = Math.round((data["heading"][0]*final_longball + data["heading"][1]*final_through + data["heading"][2]*final_shortpassing + data["heading"][3]*final_counter + data["heading"][4]*final_wing)/10)/10;
	
	var finishing = Math.round((data["finishing"][0]*final_longball + data["finishing"][1]*final_through + data["finishing"][2]*final_shortpassing + data["finishing"][3]*final_counter + data["finishing"][4]*final_wing)/10)/10;
	
	var longshots = Math.round((data["longshots"][0]*final_longball + data["longshots"][1]*final_through + data["longshots"][2]*final_shortpassing + data["longshots"][3]*final_counter + data["longshots"][4]*final_wing)/10)/10;
	
	$("#heading_amount").addClass("chance_bar att").css({"width":heading*2+"px"});
	$("#longshots_amount").addClass("chance_bar att").css({"width":longshots*2+"px"});
	$("#finishing_amount").addClass("chance_bar att").css({"width":finishing*2+"px"});
}

function set_values(player_id) {
	var defending_total = 0;
	var defending_players_own = 0;
	var assist_total = 0;
	var assist_players_own = 0;
	var attacking_total = 0;
	var attacking_players_own = 0;
	
	for (var i=1;i<24;i++) {
		var pos = data["formation_by_pos"][i];
		if (pos && typeof pos != "function") {
			defending_total += data["defending"][i];
			assist_total += data["assist"][i];
			attacking_total += data["attacking_balanced"][i];
		}
		
		if (pos==player_id) {
			defending_players_own = data["defending"][i];
			assist_players_own = data["assist"][i];
			attacking_players_own += data["attacking_balanced"][i];
		}
	}
	var attw = 2*Math.round(attacking_players_own/(attacking_total)*100)/1;
	var midw = 2*Math.round(assist_players_own/(assist_total)*100)/1;
	var defw = 2*Math.round(defending_players_own/(defending_total)*100)/1;
	var $att = $("[player_id_attacking='"+player_id+"']");
	var $mid = $("[player_id_assist='"+player_id+"']");
	var $def = $("[player_id_defending='"+player_id+"']");
	$att.html("<div class='chance_bar att' style='width:"+attw+"px'></div>");
	$mid.html("<div class='chance_bar mid' style='width:"+midw+"px'></div>");
	$def.html("<div class='chance_bar def' style='width:"+defw+"px'></div>");
	if(attw<=0) $att.css("visibility","hidden");
	else $att.css("visibility","visible");
	if(midw<=0) $mid.css("visibility","hidden");
	else $mid.css("visibility","visible");
	if(defw<=0) $def.css("visibility","hidden");
	else $def.css("visibility","visible");
	
}

function tactics_unset_player($elem)
{ // elem is
	hoverIntentConfigUnset = {
        interval: 300, // number = milliseconds for onMouseOver polling interval
        over: function() {
//			$(this).attr("tooltip","");
			return false;
        }, // function = onMouseOver callback (REQUIRED)
        out: function() {
			return false;
		} // function = onMouseOut callback (REQUIRED)
    };
	var $player = $("#player_"+$elem.attr("position"));
	if($player.hasClass("field_player"))
	{
		$player.attr("player_set","");
		$player.attr("player_no","").attr("player_id","").hide();
		$player.find(".tactics_shirt").html("").addClass("transp");
	}
	else if($player.hasClass("bench_player"))
	{
		$player.attr("player_set","");
		$player.find(".tactics_shirt").addClass("dashed transp").html("");
		$player.attr("player_id","").attr("player_no","");
	}
	$player.hoverIntent(hoverIntentConfigUnset);
}
function make_draggable($el)
{
	$el.draggable({
		helper: function(){
			var $shirt = make_tactics_drag_shirt(tactics_make_shirt($(this).attr("player_no"),"drag"));
			return $shirt;
		}, //"clone",
		cursorAt: { left: 15 },
//		create: function(e,ui){},
//		drag: function(e,ui){},
		start: function(e,ui)	{
			var p = players_by_id[$(this).attr("player_id")];
			
			$(this).addClass("active");
			$("#player_"+$(this).attr("position")).addClass("active");
			$(ui.helper).css({"width":"40px","z-index":"10","cursor":"pointer"}).attr("player_id",$(this).attr("player_id")).appendTo("body");

			$("#tactics_field .tactics_shirt.transp").parent().css("display","inline-block");
			
			
			$("[player_set=true]").find(".tactics_shirt").addClass("transp opacity");
			$(".droppable.disabled[player_set=true]").find(".tactics_shirt").removeClass("transp opacity");
		},
		stop: function(e,ui)
		{
			stop_drag($(this));
			$(this).removeClass("active");
		}
	});
}
function stop_drag($el)
{
	$(".droppable.disabled").droppable("option","disabled",false);
	$(".droppable.disabled").removeClass("disabled");
	$("[player_set=true]").find(".tactics_shirt").removeClass("transp opacity");
	$("#tactics_field .tactics_shirt.transp").parent().hide();
	$("#player_"+$el.attr("position")).removeClass("active");
}
function tactics_field_players()
{
	$("#tactics_field").html("");
	// Html classes and player positions on each line
	var player_lines = {
		"goalkeeper": {"left_block":0,"center_block":1,"right_block":0},
		"defenders": {"left_block":1,"center_block":3,"right_block":1},
		"def_midfielders": {"left_block":1,"center_block":3,"right_block":1},// center_block = 2, but with dmcl-dmc-dmcr as player positions
		"midfielders": {"left_block":1,"center_block":3,"right_block":1},
		"off_midfielders": {"left_block":1,"center_block":3,"right_block":1}, // center_block = 2, but with omcl-omc-omcr as player positions
		"forwards": {"left_block":0,"center_block":3,"right_block":0}
	};
	// Player position classes
	var player_classes = {
		"goalkeeper": "gk",
		"defenders": "def",
		"def_midfielders": "mid",
		"midfielders": "mid",
		"off_midfielders": "mid",
		"forwards": "forward"
	};
	// Position count
	var count = 0;
	for(var i in player_lines)
	{ // Make each line on the field
		var line = player_lines[i];
		var $line = $("<div>").addClass("field_line "+i).prependTo("#tactics_field");
		for(var j in line)
		{ // Make each block in the line (L-C-R)
			var block = line[j];
			var $block = $("<div>").addClass(j).appendTo($line);
			for(var k = 0; k < block; k++)
			{ // Make each player in the block
				if(positions[count] == "dmc" || positions[count] == "omc")
				{ // If dmc or omc - move player to dmr/omr and skip player insert
					if(formation_by_pos[count] > 0)
					{
						on_field[formation_by_pos[count]]= positions[count+1];
						formation_by_pos[count+1] = formation_by_pos[count];
						formation_by_pos[count] = null;
						on_field_assoc[positions[count]+"r"] = on_field_assoc[positions[count]];
						on_field_assoc[positions[count]] = null;
					}
				}
				else
				{ // Insert player on field
					var $player = $("<div>").addClass("field_player").attr("id","player_"+positions[count]).attr("position",positions[count]).appendTo($block).attr("position_key",count).attr("player_set",false).attr("show_flag",false);
					if(count > 0) $player.addClass("droppable");
					$shirt = $("<div class=\"tactics_shirt "+player_classes[i]+"\">").appendTo($player);
					$player.append("<div class=\"field_player_name\">");
					if(formation_by_pos[count] > 0)
					{
						var p = players_by_id[formation_by_pos[count]];
						tactics_set_player(p,$player);
					}
					else
					{
						$shirt.addClass("transp");
						$player.hide();
					}
					if($player.attr("player_no") != "1")
					{
						make_draggable($player);
					}
				}
				// Next position
				count++;
			} // k in block
		} // j in line
		// Clear line float
		$line.append("<div class=\"clear\"></div>");
	} // i in player_lines
}

function tactics_make_shirt(number,type)
{
	var $shirt = $("<div />").addClass("tactics_shirt "+type).html(number);
	return $shirt;
}
function tactics_make_player(player)
{
	var $player = $("<div>").addClass("field_player droppable");
}
function add_post_player(player,position)
{
	on_field_assoc[position] = player["player_id"];
//	post_players[player["player_id"]] = {"player":player,"position":position};
	post_players[player["player_id"]] = position;
}

function make_tactics_drag_shirt(shirt)
{
	if($("#tactics_drag_shirt").length == 0)
	{
		var $shirt = $("<div>").attr("id","tactics_drag_shirt").appendTo("body");
	}
	else{
		var $shirt = $("#tactics_drag_shirt");
	}
	$shirt.html(shirt).show();
	return $shirt;
}
function hide_tactics_drag_shirt()
{
	$("#tactics_drag_shirt").hide();
}

function mergeSort(arr,key,direction)
{
    if (arr.length < 2)
        return arr;
    var middle = parseInt(arr.length / 2);
    var left   = arr.slice(0, middle);
	var right  = arr.slice(middle, arr.length);
    return merge(mergeSort(left,key,direction), mergeSort(right,key,direction),key,direction);
}

function merge(left, right,key,direction)
{
    var result = [];

    while (left.length && right.length) {
		if(direction == "asc")
		{
			if (left[0][key] <= right[0][key]) {
				result.push(left.shift());
			} else {
				result.push(right.shift());
			}
		}
		else
		{
			if (left[0][key] <= right[0][key]) {
				result.push(right.shift());
			} else {
				result.push(left.shift());
			}
		}
    }

    while (left.length)
        result.push(left.shift());

    while (right.length)
        result.push(right.shift());

    return result;
}
// Object functions (assoc array)
function remove_elem_assoc(arr,key)
{
	var tmp_arr = {};
	for(var i in arr)
	{
		if(i != key)
		{
			tmp_arr[i] = arr[i];
		}
	}
	return tmp_arr;
}
function make_droppable()
{
	// Make players Droppable
	$( ".droppable" ).droppable({
		over: function(event,ui){
			if($(ui.draggable).attr("player_no") > 0)
			{ // Only players can be dropped (not CO)
				if($(this).find(".tactics_shirt").hasClass("transp"))
				{
					$( this ).find(".tactics_shirt").addClass( "drag active" );
				}
				else
				{
					$( this ).find(".tactics_shirt").addClass( "active" );
				}
			}
		},
		out: function(event,ui){
			if($(ui.draggable).attr("player_no") > 0)
			{ // Only players can be dropped (not CO)
				$( this )
					.find(".tactics_shirt").removeClass( "drag active" );
			}
		},
		drop: function( event, ui ) {
			if($(ui.draggable).attr("player_no") > 0)
			{ // Only players can be dropped (not CO)
				$(this).draggable("enable");
				// Set this position as player
				$( this ).find(".tactics_shirt").removeClass("transp drag active");
				// Swap Players
				var player_swapped = false;
				if($(this).attr("player_id") > 0)
				{ // Player already in droppable position
					var p = players_by_id[$(this).attr("player_id")];
					if($("#player_"+$(ui.draggable).attr("position")).length != 0)
					{ // Dragged player already on field or subs
						// Set player on droppable to dragged players position
						formation_by_pos[$(ui.draggable).attr("position_key")] = $(this).attr("player_id");
						tactics_set_player(p,$("#player_"+$(ui.draggable).attr("position")));
						// Post player on droppable ajax
						add_post_player(p,$(ui.draggable).attr("position"));

						if(on_field[$(ui.helper).attr("player_id")])
						{ // if dragged player is on field, add player on droppable to dragged's position and remove from subs
							on_subs = remove_elem_assoc(on_subs,p["player_id"]);
							on_field[p["player_id"]] = $(ui.draggable).attr("position");
						}
						else if(on_subs[$(ui.helper).attr("player_id")])
						{// if dragged player is on subs, add player on droppable to dragged's position and remove from field
							on_field = remove_elem_assoc(on_field,p["player_id"]);
							on_subs[p["player_id"]] = $(ui.draggable).attr("position");
						}
					}
					else
					{ // Player from the list
						// Remove swapped player from on_field
						on_field = remove_elem_assoc(on_field,p["player_id"]);
						on_subs = remove_elem_assoc(on_subs,p["player_id"]);
						add_post_player(p,"out");
						formation_by_pos[$(ui.draggable).attr("position_key")] = null;
					}
					player_swapped = true;
				}
				else
				{ // Player moved to empty space, so disable draggable
					$(ui.draggable).draggable("disable");
					formation_by_pos[$(ui.draggable).attr("position_key")] = null;
				}
				// Set player Info
				var p = players_by_id[$(ui.helper).attr("player_id")];
				formation_by_pos[$(this).attr("position_key")] = $(ui.helper).attr("player_id");
				tactics_set_player(p,$(this));
				// Ajax position
				add_post_player(p,$(this).attr("position"));
				// Move player, if already on field
				if((on_field[$(ui.helper).attr("player_id")] || on_subs[$(ui.helper).attr("player_id")])&& !player_swapped)
				{
					tactics_unset_player($(ui.draggable));
				}
				// Remove active class
				$(ui.draggable).removeClass("active");
				//

				if($(this).hasClass("field_player"))
				{
					on_field[p["player_id"]] = $(this).attr("position");
					on_subs = remove_elem_assoc(on_subs,p["player_id"]);
				}
				else if($(this).hasClass("bench_player"))
				{
					on_subs[p["player_id"]] = $(this).attr("position");
					on_field = remove_elem_assoc(on_field,p["player_id"]);
				}
	//			on_subs = remove_elem_assoc(on_subs,p["player_id"]);
				// Hide not set positions
	//			$("#tactics_field .tactics_shirt.transp").parent().hide();
				stop_drag($(ui.draggable));
				// Remove drag helper
				$(ui.helper).remove();
				tactics_list_players();
				// Post changes to db
			}
		}
	});
	// ** Make List droppable
	$("#tactics_list").droppable({
		over: function(){
			//Hover ?
		},
		out: function(){
			// Unhover
		},
		drop: function( event, ui ) {
			if($(ui.draggable).hasClass("field_player") || $(ui.draggable).hasClass("bench_player"))
			{
				var p = players_by_id[$(ui.helper).attr("player_id")];
				tactics_unset_player($(ui.draggable));
				$(ui.draggable).draggable("disable");
				if(!$(ui.draggable).hasClass("kick_player"))
				{
					add_post_player(p,"out");
					on_field = remove_elem_assoc(on_field,p["player_id"]);
					on_subs = remove_elem_assoc(on_subs,p["player_id"]);
					stop_drag($(ui.draggable));
					tactics_list_players();
					formation_by_pos[$(ui.draggable).attr("position_key")] = null;
				}
				else
				{
					add_post_player(0,$(ui.draggable).attr("position"));
				}
			}
		}
	});

	// ** Make kick takers and cappy droppable
	$(".droppable_kick").droppable({
		over: function(){
			$( this ).find(".tactics_shirt").addClass( "active" );
		},
		out: function(){
			$( this )
				.find(".tactics_shirt").removeClass( "active" );
		},
		drop: function( event, ui ) {
			// Set this position as player
			$( this ).find(".tactics_shirt").removeClass("transp active");
			stop_drag($(ui.draggable));
			var p = players_by_id[$(ui.helper).attr("player_id")];
			add_post_player(p,$(this).attr("position"));
			tactics_set_player(p,$(this));
			$( this ).draggable("enable");
		}
	});
}

// Document ready : initiate everything!
$(document).ready(function(){
	tactics_init();

});
