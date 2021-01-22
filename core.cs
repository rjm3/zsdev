// ZSDEV MAIN FUNCTIONS

$AutoRespawn = 1;

$zs::mapon = 1;

$zstracking = 0;

//------------------------------------------------------------------------

// ZS TELNET SETUP

$zs::telnetfirst = "9630";
$zs::telnetlast = "19699";

$TelnetPassword = "3483ASJFOIJEW2093";

exec(ZSTELNET);
$TelnetPort = getWord($TelnetPort,0);
echo("> TELNET PORT " @ $TelnetPort);

//------------------------------------------------------------------------

// INITIAL LOAD

function zs::firstload()
{
	echo(">>> ZS INIT LOAD");
	if ($zs::initload == "") {
		$server::password = "3779201JA";
		schedule("zs::isfirstload();",10);
	}
}

function zs::isfirstload()
{
	echo(">>> FIRST LOAD");
        exec(ZSTELNET);
	$TelnetPort = getWord($TelnetPort,0);
        %telnet = $TelnetPort;
        if (%telnet > $zs::telnetlast)
    		%telnet = $zs::telnetfirst;
        echo(">> TELNET PORT " @ %telnet);
        $TelnetPort = %telnet;
        $TelnetPassword = "JRUWPQLSQ";
        export("$TelnetPort", "config\\ZSTELNET.cs", false);
	schedule("exec(item);",1);
	schedule("server::loadMission(\"zs_test_night\");",5);
	$zs::initload = 1;
}

function zs::unlockServer()
{
	echo(">>> SERVER UNLOCKING");
	$server::password = "";
}

zs::firstload();

//------------------------------------------------------------------------

function dbecho(%one,%two) 
{
	echo(%one @ ": " @ %two);
}

function IsCrashString(%string)
{
	%tab = 0;
	%nl = 0;
	%hex = 0;
	%crash = False;
	for (%i=0; (%letter = String::getSubStr(%string, %i, 1)) != ""; %i++)
	{
		if (%letter == "\t")
			%tab++;
		else if (%letter == "\n")
			%nl++;
		else if (String::findSubStr(escapeString(%letter), "\\x") == 0)
			%hex++;
	}
	if (String::findsubStr(%string,"\\x") != -1)
			%hex++;
	if (String::findsubStr(%string,"\\t") != -1)
			%tab++;
	if (String::findsubStr(%string,"\\n") != -1)
			%nl++;

	if(%tab || %nl || %hex)
		%crash = True;

	return %crash;
}

//------------------------------------------------------------------------

function remoteInventoryMode()
{
	//do nothing
}

function remoteCommandMode()
{
	//do nothing
}

function remoteToggleInventoryMode()
{
	//do nothing
}

function remoteToggleCommandMode()
{
	//do nothing
}

function remotefetchData()
{
	// do nothing
}

//------------------------------------------------------------------------

function ircChat(%name,%msg)
{
	MessageAll(3,"(irc) "@%name@": "@%msg);
}

function zs::ircUsers()
{
	%players = 0;
	%names = "";
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		%name = Client::GetName(%cl);
		%players++;
		%names = %names @ %name @ " ";
	}
	if (%players)
		echo("ZSIRC:PLAYERS " @ %players @ " player(s): " @ %names);
	else
		echo("ZSIRC:PLAYERS 0");
}

function onClientJoin(%client, %msg)
{
	// NO DEDICATED
	%name = Client::GetName(%client);
        GameBase::SetTeam(%client,0);
	zs::defaultPlayer(%client);
	schedule("zs::CheckForZombie();",1);
}

function Game::onPlayerConnected(%playerId)
{
	%name = Client::GetName(%playerId);
	$zs::isadmin[%name] = 0;
        schedule("zs::BanCheck(" @ %playerId @ ");",1);
	%playerId.scoreKills = 0;
   	%playerId.scoreDeaths = 0;
	%playerId.score = 0;
   	%playerId.justConnected = true;
   	$menuMode[%playerId] = "None";
   	Game::refreshClientScore(%playerId);
	%client = %playerId;
     	GameBase::SetTeam(%playerId,0);
	zs::defaultPlayer(%playerId);
	if (getNumClients() == 0)
		schedule("zs::CheckForZombie();",3);
	else
		schedule("zs::GameStartedZombie(" @ %client @ ");",3);
}

function Server::onClientDisconnect(%clientId)
{
	%name = Client::GetName(%clientId);
	$zs::isadmin[%name] = 0;
	// Need to kill the player off here to make everything
	// is cleaned up properly.
   	%player = Client::getOwnedObject(%clientId);
   	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%player);
	  	Player::kill(%player);
	}

   	Client::setControlObject(%clientId, -1);
   	Client::leaveGame(%clientId);
   	Game::CheckTourneyMatchStart();
   	if(getNumClients() == 1) // this is the last client.
    		  Server::refreshData();
	echo("Client Dropped - Checking for zombie...");
	zs::defaultPlayer(%clientId);
	Schedule("zs::GameOverCheck();",5);
	//schedule("zs::CheckForZombie();",5);
	$server::password = "";
}

function zs::defaultPlayer(%id)
{
	%name = Client::GetName(%id);
	$zs::zombieclass[%name] = "zombie";
	$zs::killedzombies[%name] = 0;
	$zs::killedhumans[%name] = 0;
	$zs::reloading[%name] = 0;
	$zs::newzombie[%name] = 0;
	$zs::targeting[%name] = 0;
	$zs::flashlight[%name] = 0;
	$zs::specialweapon[%name] = 0;
	$zs::lastdamage[%name] = "";
	$zs::poison[%name] = 0;
	if ($zstracking)
		$zs::locked[%name] = 1;
	else
		$zs::locked[%name] = 0;
	$zsstats::points[%name] = 0;
	$zs::id[%name] = %id;
	$zs::onspawn[%name] = 0;
	$zs::afk[%name] = 0;
}

function zs::defaultPlayerNoLock(%id)
{
	%name = Client::GetName(%id);
	$zs::zombieclass[%name] = "zombie";
	$zs::killedzombies[%name] = 0;
	$zs::killedhumans[%name] = 0;
	$zs::reloading[%name] = 0;
	$zs::newzombie[%name] = 0;
	$zs::targeting[%name] = 0;
	$zs::flashlight[%name] = 0;
	$zs::specialweapon[%name] = 0;
	$zs::lastdamage[%name] = "";
	$zs::poison[%name] = 0;
	$zs::id[%name] = %id;
	$zs::onspawn[%name] = 0;
	$zs::afk[%name] = 0;
}

//-------------------------------------------------------------------------
// ZS AFK CHECK (SEMI)

function zs::AfkList()
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		zs::AfkCheck(%cl);
	}
}

function zs::AfkCheck(%id)
{
	%name = Client::GetName(%id);
	%spawn = $zs::onspawn[%name];
	if (Client::GetOwnedObject(%id) == -1 || %spawn == 0) {
		%afk = $zs::afk[%name];
		if (%afk > 2) {
			zs::TempBan(%id,60,"AFK");
			zs::Kick(%id,"AFK");
		}
		$zs::afk[%name]++;
	}
}

//-------------------------------------------------------------------------

// ADMIN FUNCTIONS

function zs::AdminMe(%id)
{
	%name = Client::GetName(%id);
	if (string::findSubStr(%name," ") == -1) {
		if ($zs::locked[%name] != 1) {
			echo("ZSADMINME " @ %name @ " " @ %id);
		}
	}
}

function zs::AdminUp(%name,%id)
{
	$zs::isadmin[%name] = 1;
	Client::SendMessage(%id,0,"You have been granted admin access.");
}

function zs::KickBadAdminLogin(%id)
{
	zs::TempBan(%id,120,"Not Admin");
	Net::Kick(%id,"You are not admin! DO NOT USE THIS COMMAND!");
}

function zs::TempBan(%id,%sec,%reason)
{
	%ip = Client::GetTransportAddress(%id);
	echo("ZSTEMPBAN " @ %ip @ " " @ %sec @ " " @ %reason);
	BanList::Add(%ip,%sec);
}

function zs::Ban(%id,%reason)
{
	%ip = Client::GetTransportAddress(%id);
	echo("ZSBAN " @ %ip @ " " @ %reason);
	Net::Kick(%id,"You are banned for " @ %reason);
	BanLit::Add(%ip,1000);
}

function zs::BanCheck(%id)
{
	%ip = Client::GetTransportAddress(%id);
	echo("ZSBANCHECK " @ %ip @ " " @ %id);
}

function zs::isTempBanned(%id,%remain,%reason)
{
	%ip = Client::GetTransportAddress(%id);
	Net::Kick(%id,"You are temp banned for " @ %reason @ " Time remaining: " @ %remain @ " seconds\n");
	BanList::Add(%ip,%remain);
}

function zs::isBanned(%id,%reason)
{
	%ip = Client::GetTransportAddress(%id);
	Net::Kick(%id,"You are banned for " @ %reason);
	BanList::Add(%ip,99999);
}

function zs::Kick(%id,%msg)
{
	schedule("Net::Kick(" @ %id @ "," @ %msg @ ");",3);
}

function zs::CheckAdmin(%id)
{
	%name = Client::GetName(%id);
	echo("ZSCHECKADMIN " @ %name);
}

function zs::IsAdmin(%name)
{
	$zs::isadmin[%name] = 1;
	//MessageAll(3,%name @ " was made an Admin.");
}

//-------------------------------------------------------------------------

function zs::GameStartedZombie(%id)
{
	echo("ZS GAME STARTED ZOMBIE");
	%players = 0;
	%clientlist = "";
	%zombs = 0;
	for (%cl = Client::GetFirst(); %cl != -1; %cl = Client::GetNext(%cl)) {
		%players++;
		%team = Client::GetTeam(%cl);
		if (%team == 1)
			%zombs++;
	}
	%zombreq = 0;
	if (%players >= 1 && %players <= 4 && %zombs == 0)
			%zombreq = 1;
	else {
		%i = %players;
		while (%i > 0) {
			%zombreq++;
			%i = %i - 4;
		}
	}
	%makezombs = %zombreq - %zombs;
	echo("MAKE ZOMBS GAME STARTED " @ %makezombs);
	if (%makezombs)
		zs::MakeZombie(%id);
}

function zs::CheckForZombie() 
{
	echo("ZS CHECK FOR ZOMBIE");
	%players = 0;
	%clientlist = "";
	%zombs = 0;
	for (%cl = Client::GetFirst(); %cl != -1; %cl = Client::GetNext(%cl)) {
		%players++;
		%clientlist = %clientlist @ "" @ %cl @ " ";
		%team = Client::GetTeam(%cl);
		if (%team == 1)
			%zombs++;
	}
	echo("CLIENT LIST " @ %clientlist);
	%zombreq = 0;
	if (%players >= 1 && %players <= 4)
			%zombreq = 1;
	else {
		%i = %players;
		while (%i > 0) {
			%zombreq++;
			%i = %i - 4;
		}
	}
	%makezombs = %zombreq - %zombs;
	echo("MAKE ZOMBS " @ %makezombs);
	if (%makezombs)
		zs::PickZombies(%makezombs,%clientlist,%players);		
}

function zs::PickZombies(%ammount,%list,%players)
{
	echo("PICK ZOMBS " @ %ammount @ "' " @ %list @ "' PLAYERS " @ %players);
	for (%i = 0; %i <= 31; %i++) {
		$zszombpick[%i] = 0;
	}
	%i = 1;
	%zomblist = "";
	while (%i <= %ammount) {
		%ran = floor(getRandom() * %players);
		echo("ZOMB PICK RAN " @ %ran);
		%picked = $zszombpick[%ran];
		if (!%picked) {
			%zomblist = %zomblist @ "" @ getWord(%list,%ran) @ " ";
			$zszombpick[%ran] = 1;
			%i++;
		}
		else {
			%i = %i;
		}
	}
	%i = 1;
	while (%i <= %ammount) {
		%id = getWord(%zomblist,(%i - 1));
		zs::MakeZombie(%id);
		%i++;
	}
}

function zs::MakeZombie(%cl) 
{
	GameBase::SetTeam(%cl,1);
	%player = Client::getOwnedObject(%cl);
	GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) + 999999);
	Player::BlowUp(%player);
	Player::Kill(%cl);
	%name = Client::GetName(%cl);
	zs::defaultPlayerNoLock(%cl);
	$zsstats::startundead[%name] = getSimTime();
	$zsstats::onteam[%name] = 1;
	%zombiefound = 1;
}

function zs::CreateZombie()
{
	echo("Finding Random Zombies...");
	zs::CheckForZombies();	
}

function zs::InitMission()
{
	echo("ZS INIT MISSION ACTIVATED.");
	$zombieswon = 0;
	$zs::lasthuman = 0;
	$zs::infliction = 0;
	$zs::inflictionon = 0;
	$zs::regenon = 0;
	$zs::checktime = 0;
}

//---------------------------------------------------------------------------------------------------

// ZS GAME PLAY STATS

function zs::NewUser(%name,%password,%id)
{
 	CenterPrint(%id,"<jc>Your user account " @ %name @ " was created with password: " @ %password,10);
	$zs::locked[%name] = 0;
	zs::CheckIfMapPlayer(%id);
}

function zs::WrongPassword(%id)
{
	schedule("CenterPrint("@%id@",\"<jc>The password you supplied is incorrect!\",99999);",1);
	schedule("Net::Kick(" @ %id @ ",\"Incorrect user password!\");",10);
}

function zs::Login(%name,%id,%points)
{
	Client::SendMessage(%id,2,"You have successfully logged in.");
	$zs::locked[%name] = 0;
	$zsstats::points[%name] = %points;
	zs::CheckIfMapPlayer(%id);
        schedule("zs::CheckAdmin(" @ %id @ ");",3);
}

function zs::CheckLogin(%id) 
{
	echo("CHECKING LOGIN");
	%name = Client::GetName(%id);
	if ($zstracking) {
		echo("IS ZS TRACKING");
		%password = $Client::info[%id, 5];
		%namecheck = 1;
		%passcheck = 1;

		echo("PASSWORD IS '" @ %password @ "'");
		// CHECK FOR INVALID NAME
		if (string::findsubstr(%name,":") != -1) %namecheck = 0;
		if (string::findsubstr(%name," ") != -1) %namecheck = 0;
		if (string::findsubstr(%name,"$") != -1) %namecheck = 0;
		if (string::findsubstr(%name,"\"") != -1) %namecheck = 0;
		if (string::findsubstr(%name,"%") != -1) %namecheck = 0;
		if (string::findsubstr(%name,".") != -1) %namecheck = 0;
		//if (string::findsubstr(%name,">") != -1) %namecheck = 0;
		//if (string::findsubstr(%name,"<") != -1) %namecheck = 0;
		//if (string::findsubstr(%name,")") != -1) %namecheck = 0;
		//if (string::findsubstr(%name,"(") != -1) %namecheck = 0;
		//if (string::findsubstr(%name,"[") != -1) %namecheck = 0;
		//if (string::findsubstr(%name,"]") != -1) %namecheck = 0;
		//if (string::findsubstr(%name,"\\") != -1) %namecheck = 0;
		//if (string::findsubstr(%name,"/") != -1) %namecheck = 0;
		// CHECK FOR INVALID PASS
		if (string::findsubstr(%password,":") != -1) %passcheck = 0;
		if (string::findsubstr(%password," ") != -1) %passcheck = 0;
		if (string::findsubstr(%password,"$") != -1) %passcheck = 0;
		if (string::findsubstr(%password,"\"") != -1) %passcheck = 0;
		if (string::findsubstr(%password,"%") != -1) %passcheck = 0;
		if (string::findsubstr(%password,".") != -1) %passcheck = 0;
		//if (string::findsubstr(%password,">") != -1) %passcheck = 0;
		//if (string::findsubstr(%password,"<") != -1) %passcheck = 0;
		//if (string::findsubstr(%password,")") != -1) %passcheck = 0;
		//if (string::findsubstr(%password,"(") != -1) %passcheck = 0;
		//if (string::findsubstr(%password,"[") != -1) %passcheck = 0;
		//if (string::findsubstr(%password,"]") != -1) %passcheck = 0;
		//if (string::findsubstr(%password,"\\") != -1) %passcheck = 0;
		//if (string::findsubstr(%password,"/") != -1) %passcheck = 0;
		
		if (%password == "") {
			echo("PASSWORD BLANK");
			schedule("CenterPrint("@%id@",\"<jc>You must supply a password in your 'other' info!\",999999);",1);
			schedule("Net::Kick("@%id@",\"You must supply a password in your 'other' info\");",10);
		}
		else {
			if (%passcheck && %namecheck) {
				%ip = Client::GetTransportAddress(%id);
				echo("IP IS " @ %ip);
				echo("DOING ZS LOGIN");
				echo("ZSLOGIN "@%name@" "@%password@" "@%id@" "@%ip);
			}
			else {
				echo("INVALID CHARACTERS " @ %namecheck @ " passcheck" @ %passcheck);
				schedule("CenterPrint("@%id@",\"<jc>You are using invalid characters in your name or password!\",999999);",1);
				schedule("Net::Kick("@%id@",\"You are using invalid characters!\");",10);
			}
		}
	}
	else {
		$zs::locked[%name] = 0;
	}
}

function zs::FreshCheckLogin()
{
	MessageAll(2,"Checking log in status for all players...");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		if ($zstracking) {
			zs::LoginKill(%cl);
			zs::CheckLogin(%cl);
		}
	}
}

function zs::LoginKill(%cl)
{
	%name = Client::GetName(%cl);
	if ($zstracking)
		$zs::locked[%name] = 1;
	if ($matchstarted) {
		%player = Client::getOwnedObject(%cl);
		GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) + 999999);
		Player::BlowUp(%player);
		Player::Kill(%cl);
	}
}

function zs::defaultMapPlayers()
{
	$zs::mapon++;
	$zsstats::mapplayers = 0;
	$zsendtime = 0;
}

function zs::CheckIfMapPlayer(%id)
{
	echo("CHECKING IF MAP PLAYER");
	%players = $zsstats::mapplayers;
	if (!%players) 
		zs::AddMapPlayer(%id);
	else {
		%ismapplayer = 0;
		%name = Client::GetName(%id);
		for (%i = 1; %i <= %players; %i++) {
			%player = $zsstats::mapplayer[%i];
			if (%name == %player)
				%ismapplayer = 1;
		}
		if (!%ismapplayer)
			zs::AddMapPlayer(%id);
		else {
			if ($zsstats::onteam[%name] == 1)
				GameBase::SetTeam(%id,1);
		}
	}	
}

function zs::AddMapPlayer(%id)
{
	echo("ADDING TO MAP");
	$zsstats::mapplayers++;
	%name = Client::GetName(%id);
	%playeron = $zsstats::mapplayers;
	$zsstats::mapplayer[%playeron] = %name;
	zs::defaultStats(%id);
}

function zs::saveMapStats()
{
	MessageAll(2,"Saving stats...");
	%players = $zsstats::mapplayers;
	if (%players) {
		for (%i = 1; %i <= %players; %i++) {
			%name = $zsstats::mapplayer[%i];
			zs::PlayerPoints(%name);
		}
	}
	MessageAll(2,"Save completed!");
	echo("ZSSAVE");
	zs::DefaultMapPlayers();
	zs::FreshCheckLogin();
}

function zs::CheckSurvZombTimes()
{
	echo("Final Team Times...");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		%team = Client::GetTeam(%cl);
		%name = client::GetName(%cl);
		if (%team == 0) {
			%survivetime = getSimTime() - $zsstats::starttime[%name];
			$zsstats::survive[%name] = $zsstats::survive[%name] + %survivetime;
		}
		if (%team == 1) {
			%curundead = $zsstats::undead[%name];
			%startundead = $zsstats::startundead[%name];
			%addundead = getSimTime() - %startundead;
			$zsstats::undead[%name] = %curundead + %addundead;	
		}
	}
}

function zs::PlayerPoints(%name) 
{
	echo("ZS PLAYER POINTS");
	echo("ZS PLAYER POINTS NAME " @ %name);
	%killedz = $zsstats::killedz[%name];
	%killedh = $zsstats::killedh[%name];
	%dmgtoz = $zsstats::dmgtoz[%name];
	%dmgtoh = $zsstats::dmgtoh[%name];
	%survive = $zsstats::survive[%name];
	%redeem = $zsstats::redeem[%name];
	%id = $zs::id[%name];

	%matchtime = 1200 - $zsendtime;
	%percentUndead = $zsstats::undead[%name] / %matchtime;
	%pointUndead = %matchtime * %percentUndead;
	%pointUndead = floor(%pointUndead / 50);
	if (%pointsUndead == "")
		%pointsUndead = 0;

	%pointsKilledz = floor(%killedz / 2);
	%pointsKilledh = floor(%killedh / 0.20);
	%pointsDmgtoz = floor(%dmgtoz / 355);
	%pointsDmgtoh = floor(%dmgtoh / 20);
	%pointsSurvive = floor(%survive / 50);
	if (%pointsSurvive == "")
		%pointsSurvive = 0;
	%pointsRedeem = floor(%redeem * 10);

	echo("POINTS KILLEDZ " @ %pointskilledz);
	echo("POINTS KILLEDH " @ %pointsKilledh);
	echo("POINTS DMGTOZ " @ %pointsDmgtoz);
	echo("POINTS DMGTOH " @ %pointsDmgtoh);
	echo("POINTS SURVIVE " @ %pointsSurvive);
	echo("POINTS REDEEM " @ %pointsRedeem);
	echo("POINTS UNDEAD " @ %pointsUndead);

	%total = %pointsKilledz + %pointsKilledh + %pointsDmgtoz + %pointsDmgtoh + %pointsSurvive + %pointsRedeem + %pointsUndead;
	echo("ZSADDPOINTS:"@%name@":"@%total);

	echo("ZS POINTS ID " @ %id);
	if (Client::GetName(%id) == %name) {
		Client::SendMessage(%id,3,"You gained " @ %total @ " points this round!");
	}
}

function zs::defaultStats(%id)
{
	%name = Client::GetName(%id);
	$zsstats::killedz[%name] = 0;
	$zsstats::killedh[%name] = 0;
	$zsstats::dmgtoz[%name] = 0;
	$zsstats::dmgtoh[%name] = 0;
	$zsstats::starttime[%name] = getSimTime();
	$zsstats::survive[%name] = 0;
	$zsstats::redeem[%name] = 0;
	$zsstats::undead[%name] = 0;
	$zsstats::startundead[%name] = 0;
	$zsstats::onteam[%name] = 0;
	$zsstats::onmap[%name] = $zs::mapon;
}

//----------------------------------
// END SCREEN RANKING
//----------------------------------

function TestRanks() 
{
	$zsstats::mapplayers = 5;
	$zsstats::mapplayer[3] = testerB;
	$zsstats::mapplayer[4] = testerC;
	$zsstats::mapplayer[5] = testerD;
	$zsstats::survive["testerB"] = 600;
	$zsstats::survive["testerC"] = 300;
	$zsstats::survive["testerD"] = 900;
	$zsstats::dmgtoz["<ndi>rjm3"] = 900;
	$zsstats::dmgtoz["testerB"] = 600;
	$zsstats::dmgtoz["testerC"] = 300;
	$zsstats::dmgtoz["testerD"] = 443;
	$zsstats::killedh["<ndi>rjm3"] = 3;
	$zsstats::killedh["testerB"] = 9;
	$zsstats::killedh["testerC"] = 6;
	$zsstats::killedh["testerD"] = 55;
	$zsstats::dmgtoh["<ndi>rjm3"] = 3;
	$zsstats::dmgtoh["testerB"] = 6;
	$zsstats::dmgtoh["testerC"] = 9;
	$zsstats::dmgtoh["testerD"] = 32;
}
	
function zs::Ranks() 
{
	//TestRanks();
	zs::EndScreenRank("survive");
	zs::EndScreenRank("dmgtoz");
	zs::EndScreenRank("killedh");
	zs::EndScreenRank("dmgtoh");
}

function zs::EndScreenRank(%type)
{
	echo("DOING END SCREEN");
	$zsrank::ranked[%type] = 0;
	%players = $zsstats::mapplayers;
	if (%players) {
		for (%i = 1; %i <= %players; %i++) {
			%name = $zsstats::mapplayer[%i];
			if (%name != "")
				zs::FindEndRank(%name,%type);
		}
	}
}

function zs::FindEndRank(%name,%type) 
{
	if (%type == "survive")
		%score = $zsstats::survive[%name];
	if (%type == "dmgtoz") 
		%score = $zsstats::dmgtoz[%name];
	if (%type == "killedh") 
		%score = $zsstats::killedh[%name];
	if (%type == "dmgtoh") 
		%score = $zsstats::dmgtoh[%name];

	//echo("SCORE " @ %score @ " TYPE " @ %type);

	zs::InsertRank(%name,%score,%type);
}

function zs::InsertRank(%name,%score,%type)
{
	%ranked = $zsrank::ranked[%type];
	%rankfound = 0;
	if (!%ranked) {
		//echo("Not Ranked!");
		$zsrank::endrank[%type,"rank",1] = %name;
		$zsrank::endrank[%type,"score",1] = %score;
		$zsrank::ranked[%type]++;
		%rankfound = 1;
	}
	else  {
		%ranked = $zsrank::ranked[%type];
		%i = 1;
		while (%i <= (%ranked + 1) && %rankfound != 1) {
			%currank = $zsrank::endrank[%type,"score",%i];
			if (%score >= %currank) {
				%rankfound = 1;
				zs::BumpRank(%type,%i);
				$zsrank::endrank[%type,"rank",%i] = %name;
				$zsrank::endrank[%type,"score",%i] = %score;
				$zsrank::ranked[%type]++;
			}
			if (%i == (%ranked + 1) && !%rankfound) {
				%rankfound = 1;
				$zsrank::endrank[%type,"rank",%i] = %name;
				$zsrank::endrank[%type,"score",%i] = %score;
				$zsrank::ranked[%type]++;
			}
			%i++;
		}
	}
}

function zs::BumpRank(%type,%num)
{
	//echo("BUMPING PLAYER");
	%ranked = $zsrank::ranked[%type];
	%on = %ranked;
	while (%on >= %num) {
		%onplus = %on + 1;
		%lastrank = $zsrank::endrank[%type,"rank",%on];
		%lastscore = $zsrank::endrank[%type,"score",%on];
		$zsrank::endrank[%type,"rank",%onplus] = %lastrank;
		$zsrank::endrank[%type,"score",%onplus] = %lastscore;
		%on--;
	}
}

function zs::EndScreenDisplay()
{
	// SURVIVE TIME
	echo("ZS END SCREEN DISPLAY");
	%survive = $zsrank::ranked["survive"];
	%dmgtoz = $zsrank::ranked["dmgtoh"];
	%l = 5;
	Team::setObjective(0, %l, "<f3><L25>   Survival Times<L70>   Brains Eaten");
	if (%survive) {
		%i = 1;	
		while (%i <= %survive && %i <= 5) {
			echo("ADDING PLAYER " @ %i);
			%person = $zsrank::endrank["survive","rank",%i];
			%score = $zsrank::endrank["survive","score",%i];
			%score = zs::SimToMin(floor((%score - 21)));
			%person2 = $zsrank::endrank["killedh","rank",%i];
			%score2 = $zsrank::endrank["killedh","score",%i];
			%score2 = floor(%score2);
			Team::setObjective(0, %l++, "<L20><f0>" @ %i @ " <f2><L25>" @ %person @ " <L55><f1>" @ %score @ "<L75><f0>" @ %i @ " <L80><f2>" @ %person2 @ " <L110><f1>" @ %score2);
			%i++;
		}
	}
	%l = %l + %survive;
	%l = %l + 2;
	%dmgtoz = $zsrank::ranked["dmgtoz"];
	%killedh = $zsrank::ranked["killedh"];
	Team::setObjective(0, %l, "<f3><L25>   Damage To Undead<L70>   Damage to Humans");
	if (%dmgtoz) {
		%i = 1;	
		while (%i <= %dmgtoz && %i <= 5) {
			%person = $zsrank::endrank["dmgtoz","rank",%i];
			%score = $zsrank::endrank["dmgtoz","score",%i];
			%score = floor(%score);
			%person2 = $zsrank::endrank["dmgtoh","rank",%i];
			%score2 = $zsrank::endrank["dmgtoh","score",%i];
			%score2 = floor(%score2);
			Team::setObjective(0, %l++, "<L20><f0>" @ %i @ " <f2><L25>" @ %person @ " <L55><f1>" @ %score @ "<L75><f0>" @ %i @ " <L80><f2>" @ %person2 @ " <L110><f1>" @ %score2);
			%i++;
		}
	}
}

function zs::SimToMin(%time)
{
	%min = 0;
	%sec = 0;
	while (%time > 60) {
		%min++;
		%time = %time - 60;
	}
	if (%time < 10)
		%time = "0" @ %time;
	if (%time < 0)
		return "0:00";
	else
		return %min @ ":" @ %time;
}

//---------------------------------------------------------------------------------------------------

function zs::GrabKills(%id)
{
	%team = Client::GetTeam(%id);
	%name = Client::GetName(%id);
	if (%team == 0)
		%kills = $zs::killedzombies[%name];
	if (%team == 1)
		%kills = $zs::killedhumans[%name];
	return %kills;
}

function zs::GrabScore(%id)
{
	%name = Client::GetName(%id);
	%score = $zsstats::points[%name];
	return %score;
}

//-------------------------
// ZS RANKS

$zsrank[1] = 0;
$zsrank[2] = 500;
$zsrank[3] = 1000;
$zsrank[4] = 1500;
$zsrank[5] = 2000;
$zsrank[6] = 2500;
$zsrank[7] = 3250;
$zsrank[8] = 4000;
$zsrank[9] = 4750;
$zsrank[10] = 5500;
$zsrank[11] = 6250;
$zsrank[12] = 7000;
$zsrank[13] = 7750;

$zsrank[14] = 9000;
$zsrank[15] = 10000;
$zsrank[16] = 11000;
$zsrank[17] = 12500;
$zsrank[18] = 14000;
$zsrank[19] = 15000;
$zsrank[20] = 16750;
$zsrank[21] = 18500;
$zsrank[22] = 20500;
$zsrank[23] = 22500;
$zsrank[24] = 25000;

function zs::GrabRankName(%id)
{
	%name = Client::GetName(%id);
	%points = $zsstats::points[%name];
	if (%points >= $zsrank[1])
		%rank = "Civilian";
	if (%points >= $zsrank[2])
		%rank = "Private";
	if (%points >= $zsrank[3])
		%rank = "Private First Class";
	if (%points >= $zsrank[4])
		%rank = "Specialist";
	if (%points >= $zsrank[5])
		%rank = "Corporal";
	if (%points >= $zsrank[6])
		%rank = "Sergeant";
	if (%points >= $zsrank[7])
		%rank = "Staff Sergeant";
	if (%points >= $zsrank[8])
		%rank = "Sergeant First Class";
	if (%points >= $zsrank[9])
		%rank = "Master Sergeant";
	if (%points >= $zsrank[10])
		%rank = "First Sergeant";
	if (%points >= $zsrank[11])
		%rank = "Sergeant Major";
	if (%points >= $zsrank[12])
		%rank = "Command Sergeant Major";
	if (%points >= $zsrank[13])
		%rank = "Sergeant Major Of The Army";
	//------------------------------------------------
	if (%points >= $zsrank[14])
		%rank = "Second Lieutenant";
	if (%points >= $zsrank[15])
		%rank = "First Lieutenant";
	if (%points >= $zsrank[16])
		%rank = "Captian";
	if (%points >= $zsrank[17])
		%rank = "Major";
	if (%points >= $zsrank[18])
		%rank = "Lieutenant Colonel";
	if (%points >= $zsrank[19])
		%rank = "Colonel";
	if (%points >= $zsrank[20])
		%rank = "Brigadier General";
	if (%points >= $zsrank[21])
		%rank = "Major General";
	if (%points >= $zsrank[22])
		%rank = "Lieutenant General";
	if (%points >= $zsrank[23])
		%rank = "General";
	if (%points >= $zsrank[24])
		%rank = "General Of The Army";
	return %rank;	
}

function zs::GrabTabRank(%id)
{
	%name = Client::GetName(%id);
	%points = $zsstats::points[%name];
	if (%points >= $zsrank[1])
		%rank = "CIV";
	if (%points >= $zsrank[2])
		%rank = "PVT";
	if (%points >= $zsrank[3])
		%rank = "PFC";
	if (%points >= $zsrank[4])
		%rank = "SPC";
	if (%points >= $zsrank[5])
		%rank = "CPL";
	if (%points >= $zsrank[6])
		%rank = "SGT";
	if (%points >= $zsrank[7])
		%rank = "SSG";
	if (%points >= $zsrank[8])
		%rank = "SFC";
	if (%points >= $zsrank[9])
		%rank = "MSG";
	if (%points >= $zsrank[10])
		%rank = "1SG";
	if (%points >= $zsrank[11])
		%rank = "SGM";
	if (%points >= $zsrank[12])
		%rank = "CSM";
	if (%points >= $zsrank[13])
		%rank = "SMA";
	//------------------------------------------------
	if (%points >= $zsrank[14])
		%rank = "2LT";
	if (%points >= $zsrank[15])
		%rank = "1LT";
	if (%points >= $zsrank[16])
		%rank = "CPT";
	if (%points >= $zsrank[17])
		%rank = "MAJ";
	if (%points >= $zsrank[18])
		%rank = "LTC";
	if (%points >= $zsrank[19])
		%rank = "COL";
	if (%points >= $zsrank[20])
		%rank = "BG ";
	if (%points >= $zsrank[21])
		%rank = "MG ";
	if (%points >= $zsrank[22])
		%rank = "LTG";
	if (%points >= $zsrank[23])
		%rank = "GEN";
	if (%points >= $zsrank[24])
		%rank = "GOA";
	return %rank;	
}

function zs::GrabRank(%name)
{
	
	%points = $zsstats::points[%name];
	
	//--------------------------------------
	// ENLISITED RANKS
	if (%points >= $zsrank[1])
		%insig = "<bCIV.bmp>";
	if (%points >= $zsrank[2])
		%insig = "<bE1.bmp>";
	if (%points >= $zsrank[3])
		%insig = "<bE2.bmp>";
	if (%points >= $zsrank[4])
		%insig = "<bE3.bmp>";
	if (%points >= $zsrank[5])
		%insig = "<bECPL.bmp>";
	if (%points >= $zsrank[6])
		%insig = "<bE4.bmp>";
	if (%points >= $zsrank[7])
		%insig = "<bE5.bmp>";
	if (%points >= $zsrank[8])
		%insig = "<bE6.bmp>";
	if (%points >= $zsrank[9])
		%insig = "<bE7.bmp>";
	if (%points >= $zsrank[10])
		%insig = "<bE8.bmp>";
	if (%points >= $zsrank[11])
		%insig = "<bE9.bmp>";
	if (%points >= $zsrank[12])
		%insig = "<bE10.bmp>";
	if (%points >= $zsrank[13])
		%insig = "<bE11.bmp>";

	//--------------------------------------
	// OFFICER RANKS
	if (%points >= $zsrank[14])
		%insig = "<bO1.bmp>";
	if (%points >= $zsrank[15])
		%insig = "<bO2.bmp>";
	if (%points >= $zsrank[16])
		%insig = "<bO3.bmp>";
	if (%points >= $zsrank[17])
		%insig = "<bO4.bmp>";
	if (%points >= $zsrank[18])
		%insig = "<bO5.bmp>";
	if (%points >= $zsrank[19])
		%insig = "<bO6.bmp>";
	if (%points >= $zsrank[20])
		%insig = "<bO7.bmp>";
	if (%points >= $zsrank[21])
		%insig = "<bO8.bmp>";
	if (%points >= $zsrank[22])
		%insig = "<bO9.bmp>";
	if (%points >= $zsrank[23])
		%insig = "<bO10.bmp>";
	if (%points >= $zsrank[24])
		%insig = "<bGOA.bmp>";

	return %insig;	
}

function zs::GetInfo(%player)
{
	echo("ZS GETINFO ");
	%id = GameBase::getOwnerClient(%player);
	%name = client::getName(%id);
	if (GameBase::getLOSinfo(%player, 75)) {
		%own = Client::getOwnedObject(%id);
		%team = Client::GetTeam(%id);
		%pos = $los::position;
		%obj = getObjectType($los::object);
		if (%obj == "Player") {
			//client::sendMessage(%id,3,"Object found looking up info.. " @ %pos @ " ID#:" @ $los::object);
			%lookid = GameBase::GetOwnerClient($los::object);
			%lookteam = Client::GetTeam(%lookid);
			%lookname = Client::GetName(%lookid);
			%lookarmor = Player::GetArmor(%lookid);
			if (%lookarmor == "armorHuman")
				%maxhp = 100;
			else if (%lookarmor == "armorHumanF")
				%maxhp = 100;
			else if (%lookarmor == "armorZombie")
				%maxhp = 400;
			else if (%lookarmor == "armorHeadcrab")
				%maxhp = 82;
			else if (%lookarmor == "armorFheadcrab")
				%maxhp = 52;
			else if (%lookarmor == "armorFzombie")
				%maxhp = 123;
			else if (%lookarmor == "armorPheadcrab")
				%maxhp = 128;
			else if (%lookarmor == "armorCzombie")
				%maxhp = 135;
			%lookhp = %maxhp - GameBase::getDamageLevel($los::object);
			if (%team == %lookteam)
				BottomPrint(%id,"<jc>" @ zs::grabRank(%lookname) @ "\n\n\n\n<f2>" @ %lookname @ " <f0>(" @ $zsstats::points[%lookname] @ ")\n<f1>Health: " @ floor(%lookhp),3);
			else
				BottomPrint(%id,"<jc>" @ zs::grabRank(%lookname) @ "\n\n\n\n<f2>" @ %lookname @ " <f0>(" @ $zsstats::points[%lookname] @ ")",3);
		}
		else {
			%armor = Player::GetArmor(%player);
			if (%armor == "armorHuman")
				%maxhp = 100;
			else if (%armor == "armorHumanF")
				%maxhp = 100;
			else if (%armor == "armorZombie")
				%maxhp = 400;
			else if (%armor == "armorHeadcrab")
				%maxhp = 82;
			else if (%armor == "armorFheadcrab")
				%maxhp = 52;
			else if (%armor == "armorFzombie")
				%maxhp = 123;
			else if (%armor == "armorPheadcrab")
				%maxhp = 128;
			else if (%armor == "armorCzombie")
				%maxhp = 135;
			%hp = %maxhp - GameBase::getDamageLevel(%player);
			BottomPrint(%id,"<jc>" @ zs::grabRank(%name) @ "\n\n\n\n<f2>" @ %name @ " <f0>(" @ $zsstats::points[%name] @ ")\n<f1>Health: " @ floor(%hp),3);
		}
	}
}

//---------------------------------------------------------------------------------------------------

function zs::CheckOutArea(%cl)
{
	%name = Client::GetName(%cl);
	if ($zs::outarea[%name]) {
		zs::outAreaKill(%cl);
	}
}

function zs::outAreaKill(%cl)
{
	%out = 1;
	%player = Client::getOwnedObject(%cl);
	if (%out) {
		GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) + 999999);
		Player::BlowUp(%player);
		Player::Kill(%cl);
		%team = Client::GetTeam(%cl);
		client::sendMessage(%cl,2,"You were killed for abandoning the mission!");
		MessageAll(0,"[Out Of Bounds] " @ client::GetName(%cl));
		if (%team == 0) {
			%pname = Client::GetName(%cl);
			MessageAll(1,%pname @ " has died and joined the zombies!");
			%survivetime = getSimTime() - $zsstats::starttime[%pname];
			$zsstats::survive[%pname] = $zsstats::survive[%pname] + %survivetime;
			$zsstats::startundead[%pname] = getSimTime();
			$zs::newzombie[%pname] = 1;
			GameBase::SetTeam(%cl,1);
			zs::defaultPlayerNoLock(%cl);
			zs::GameOverCheck();
		}
	}
}

//---------------------------------------------------------------------------------------------------

function zs::changeClass(%id,%class)
{
	%name = Client::GetName(%id);
	
	if (Client::GetOwnedObject(%id) != -1) {

		if (%class == "zombie") {
			if ($zs::infliction >= 0) {
				$zs::zombieclass[%name] = "zombie";
				Client::SendMessage(%id,2,"You will respawn as a Zombie.");
			}
		}
		if (%class == "headcrab") {
			if ($zs::infliction >= 1) {
				$zs::zombieclass[%name] = "headcrab";
				Client::SendMessage(%id,2,"You will respawn as a Head Crab.");
			}
		}
		if (%class == "fheadcrab") {
			if ($zs::infliction >= 2) {
				$zs::zombieclass[%name] = "fheadcrab";
				Client::SendMessage(%id,2,"You will respawn as a Fast Head Crab.");
			}
		}
		if (%class == "fzombie") {
			if ($zs::infliction >= 3) {
				$zs::zombieclass[%name] = "fzombie";
				Client::SendMessage(%id,2,"You will respawn as a Fast Zombie.");
			}
		}
		if (%class == "pheadcrab") {
			if ($zs::infliction >= 4) {
				$zs::zombieclass[%name] = "pheadcrab";
				Client::SendMessage(%id,2,"You will respawn as a Poison Head Crab.");
			}
		}
		if (%class == "czombie") {
			if ($zs::infliction >= 5) {
				$zs::zombieclass[%name] = "czombie";
				Client::SendMessage(%id,2,"You will respawn as a Chemical Zombie.");
			}
		}
	}

	else
		Client::SendMessage(%id,2,"You must be alive to change classes!");
}

//---------------------------------------------------------------------------------------------------

function zs::specialWeapon(%player)
{
	//echo(%player @ " triggered special weapon!");
	%client = Player::GetClient(%player);
	%armor = Player::GetArmor(%client);
	%name = Client::GetName(%client);
	if (%armor == "armorZombie") {
		if (!$zs::specialweapon[%name]) {
			$zs::specialweapon[%name] = 1;
			%trans = GameBase::getMuzzleTransform(%player);
	     		%vel = Item::getVelocity(%player);
			%snd = floor(getRandom() * 5);
			if (%snd == 0)
				Projectile::spawnProjectile("SndZombieCall1",%trans,%player,%vel);
			else if (%snd == 1)
				Projectile::spawnProjectile("SndZombieCall2",%trans,%player,%vel);
			else if (%snd == 2)
				Projectile::spawnProjectile("SndZombieCall3",%trans,%player,%vel);
			else if (%snd == 3)
				Projectile::spawnProjectile("SndZombieCall4",%trans,%player,%vel);
			else if (%snd == 4)
				Projectile::spawnProjectile("SndZombieCall5",%trans,%player,%vel);
			schedule("zs::resetspecial(\""@%name@"\");",4);
		}
	}
	if (%armor == "armorHeadcrab") {
		if (!$zs::specialweapon[%name]) {
			$zs::specialweapon[%name] = 1;
			zs::impulse(%client,26,60);
			schedule("zs::resetspecial(\""@%name@"\");",3);
		}
	}
	if (%armor == "armorFheadcrab") {
		if (!$zs::specialweapon[%name]) {
			$zs::specialweapon[%name] = 1;
			zs::impulse(%client,31,60);
			schedule("zs::resetspecial(\""@%name@"\");",3);
		}
	}
	if (%armor == "armorPheadcrab") {
		if (!$zs::specialweapon[%name]) {
			$zs::specialweapon[%name] = 1;
			zs::impulse(%client,21,60);
			schedule("zs::resetspecial(\""@%name@"\");",3.99);
		}
	}
	if (%armor == "armorFzombie") {
		if (!$zs::specialweapon[%name]) {
			$zs::specialweapon[%name] = 1;
			%trans = GameBase::getMuzzleTransform(%player);
	     		%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("SndFzScream",%trans,%player,%vel);
			zs::impulse(%client,42,70);
			schedule("zs::resetspecial(\""@%name@"\");",3.5);
		}
	}
	if (%armor == "armorCzombie") {
		if (!$zs::specialweapon[%name]) {
			BottomPrint(%client,"<jc><f1>You are NOW invisable!");
			$zs::specialweapon[%name] = 1;
			gamebase::startFadeOut(%client);
			schedule("gamebase::StartFadeIn("@%client@");",10.0);
			schedule("BottomPrint("@%client@",\"<jc><f1>You are NO LONGER invisable!\");",12.0);
			schedule("zs::resetspecial(\""@%name@"\");",16.0);
		}
	}
	if (%armor == "armorHuman") {
		%weapon = Player::GetMountedItem(%client,0);
		if (%weapon == "Glock") {
			if(!$zs::specialweapon[%name]) {
				BottomPrint(%client,"<jc>Glock fire mode: <f2>BURST",3);
				$zs::specialweapon[%name] = 1;
			}
			else {
				BottomPrint(%client,"<jc>Glock fire mode: <f2>SINGLE",3);
				$zs::specialweapon[%name] = 0;
			}
		}
	}
}

function zs::resetspecial(%name)
{
	$zs::specialweapon[%name] = 0;
}

//---------------------------------------------------------------------------------------------------

function zs::CheckRevive(%id)
{
	%name = Client::GetName(%id);
	if ($zs::killedhumans[%name] >= 3) {
		%armor = Player::GetArmor(%id);
		$zs::teamchange[%name] = 1;
		GameBase::SetTeam(%id,0);
		%player = Client::getOwnedObject(%id);
		player::setArmor(%id,armorHuman);
		client::setSkin(%id,rpghuman0);
		player::setItemCount(%id,classHuman,1);
		player::setItemCount(%id,Fiveseven,1);
		player::setItemCount(%id,FivesevenAmmo,20);
		player::setItemCount(%id,Clip57MM,40);
		player::setItemCount(%id,Grenade,1);
		player::setItemCount(%id,Knife,1);
		player::setItemCount(%id,KnifeAmmo,1);
		player::setItemCount(%id,Beacon,1);
		player::setItemCount(%id,RepairPack,1);
		if (%armor == "armorZombie") {
			player::setItemCount(%id,classZombie,0);
			player::setItemCount(%id,ZombieS,0);
			player::setItemCount(%id,ZombieSAmmo,0);
		}
		if (%armor == "armorHeadcrab") {
			player::setItemCount(%id,classHeadcrab,0);
			player::setItemCount(%id,Headcrab,0);
			player::setItemCount(%id,HeadcrabAmmo,0);
			player::setItemCount(%id,HeadcrabPack,0);
		}
		if (%armor == "armorFheadcrab") {
			player::setItemCount(%id,classFHeadcrab,0);
			player::setItemCount(%id,Headcrab,0);
			player::setItemCount(%id,HeadcrabAmmo,0);
			player::setItemCount(%id,HeadcrabPack,0);
		}
		if (%armor == "armorFzombie") {
			player::setItemCount(%id,classFzombie,0);
			player::setItemCount(%id,FzombieS,0);
			player::setItemCount(%id,FzombieSAmmo,0);
		}
		if (%armor == "armorPheadcrab") {
			player::setItemCount(%id,classPHeadcrab,0);
			player::setItemCount(%id,Pheadcrab,0);
			player::setItemCount(%id,PheadcrabAmmo,0);
			player::setItemCount(%id,PheadcrabPack,0);
			player::setItemCount(%id,PheadcrabSAmmo,0);
			player::setItemCount(%id,PheadcrabS,0);
		}
		MessageAll(1,%name @ " has been redeemed!");
		$zsstats::redeem[%name]++;
		%curundead = $zsstats::undead[%name];
		%startundead = $zsstats::startundead[%name];
		%addundead = getSimTime() - %startundead;
		$zsstats::undead[%name] = %curundead + %addundead;
		GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) - 150);
		zs::defaultPlayerNoLock(%id);
		$zs::onspawn[%name]++;
		$zsstats::onteam[%name] = 0;
		schedule("player::MountItem("@%id@",Fiveseven,0,0);",0.01);
		schedule("player::UseItem("@%player@",RepairPack);",0.02);
	}
}

//---------------------------------------------------------------------------------------------------

// ZOMBIE INFLICTION

// 20 SEC / 1 RATE
$zs::inflictionon = 0;
$zs::inflictionrate = 8;

function zs::inflictioncheck()
{
	$zs::inflictionon++;
	if ($zs::inflictionon >= $zs::inflictionrate) {
		zs::infliction();
		$zs::inflictionon = 0;
	}
}

$zs::classunlock[1] = "Head Crab";
$zs::classunlock[2] = "Fast Head Crab";
$zs::classunlock[3] = "Fast Zombie";
$zs::classunlock[4] = "Poison Head Crab";
$zs::classunlock[5] = "Chemical Zombie";

function zs::infliction()
{
	echo("ZS INFLICTION");
	$zs::infliction++;
	if ($zs::infliction <= 5) {
		%on = $zs::infliction;
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
			CenterPrint(%cl,"<jc><f2> " @ $zs::classunlock[%on] @ " <f1>Unlocked!",2);	
		}
	}
	// 0 zombie, 1 headcrab, 2 fastheadcrab, 3 fastzombie, 4 poisonheadcrab, 5 chemzombie
}

//---------------------------------------------------------------------------------------------------

// AMMO REGEN

//-----------------------------------
// 20 SECONDS PER 1 RATE
$zs::regenon = 0;
$zs::regenrate = 3;
//-----------------------------------

$zs::regenammo[Fiveseven] = 40;
$zs::regenclip[Fiveseven] = "Clip57MM";
$zs::regenname[Fiveseven] = "5.7MM";

$zs::regenammo[P228] = 30;
$zs::regenclip[P228] = "Clip9MM";
$zs::regenname[P228] = "9MM";

$zs::regenammo[Beretta] = 34;
$zs::regenclip[Beretta] = "Clip9MM";
$zs::regenname[Beretta] = "9MM";

$zs::regenammo[Glock] = 34;
$zs::regenclip[Glock] = "Clip9MM";
$zs::regenname[Glock] = "9MM";

$zs::regenammo[Deagle] = 21;
$zs::regenclip[Deagle] = "Clip50AE";
$zs::regenname[Deagle] = ".50 AE";

$zs::regenammo[MP5] = 90;
$zs::regenclip[MP5] = "Clip9MM";
$zs::regenname[MP5] = "9MM";

$zs::regenammo[MAC10] = 90;
$zs::regenclip[MAC10] = "Clip45CAL";
$zs::regenname[MAC10] = ".45 CAL";

$zs::regenammo[M1014] = 21;
$zs::regenclip[M1014] = "Clip00Buck";
$zs::regenname[M1014] = "3\" 00 Buck";

// "
// FIX COLORS

function zs::regencheck()
{
	$zs::regenon++;
	if ($zs::regenon >= $zs::regenrate) {
		zs::regen();
		$zs::regenon = 0;
	}
}

function zs::rankRegenBonus(%id)
{
	%name = Client::GetName(%id);
	%points = $zsstats::points[%name];
	//--------------------------------------
	if (%points >= $zsrank[1])
		%bonus = 0;
	if (%points >= $zsrank[2])
		%bonus = 0.10;
	if (%points >= $zsrank[3])
		%bonus = 0.20;
	if (%points >= $zsrank[4])
		%bonus = 0.30;
	if (%points >= $zsrank[5])
		%bonus = 0.40;
	if (%points >= $zsrank[6])
		%bonus = 0.50;
	if (%points >= $zsrank[7])
		%bonus = 0.60;
	if (%points >= $zsrank[8])
		%bonus = 0.70;
	if (%points >= $zsrank[9])
		%bonus = 0.80;
	if (%points >= $zsrank[10])
		%bonus = 0.90;
	if (%points >= $zsrank[11])
		%bonus = 1.00;
	if (%points >= $zsrank[12])
		%bonus = 1.10;
	if (%points >= $zsrank[13])
		%bonus = 1.20;
	//--------------------------------------
	if (%points >= $zsrank[14])
		%bonus = 1.30;
	if (%points >= $zsrank[15])
		%bonus = 1.40;
	if (%points >= $zsrank[16])
		%bonus = 1.50;
	if (%points >= $zsrank[17])
		%bonus = 1.60;
	if (%points >= $zsrank[18])
		%bonus = 1.70;
	if (%points >= $zsrank[19])
		%bonus = 1.80;
	if (%points >= $zsrank[20])
		%bonus = 1.90;
	if (%points >= $zsrank[21])
		%bonus = 2.00;
	if (%points >= $zsrank[22])
		%bonus = 2.20;
	if (%points >= $zsrank[23])
		%bonus = 2.40;
	if (%points >= $zsrank[24])
		%bonus = 2.60;
	return %bonus;	
}

function zs::regen()
{
	echo("ZS AMMO REGEN ACTIVATED");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		%team = Client::GetTeam(%cl);
		if (%team == 0) {
			%weapon = Player::GetMountedItem(%cl,0);
			if (%weapon != -1) {
				if (%weapon == "Knife")
					%weapon = "Fiveseven";
				%bonus = zs::rankRegenBonus(%cl);
				%kills = zs::GrabKills(%cl);
				%clipammo = Player::GetItemCount(%cl,$zs::regenclip[%weapon]);
				%clipregen = %clipammo + ($zs::regenammo[%weapon] + floor((0.25 + %bonus) * $zs::regenammo[%weapon]));
				//%clipregen = %clipregen + floor(%clipregen * (0.25 + %bonus));
				%regendisp = $zs::regenammo[%weapon] + floor((0.25 + %bonus) * $zs::regenammo[%weapon]);
				player::SetItemCount(%cl,$zs::regenclip[%weapon],%clipregen);
				client::SendMessage(%cl,2,"You recieved " @ %regendisp @ " " @ $zs::regenname[%weapon] @ " ammunition.");
				client::sendMessage(%cl,3,"~wBEEPSPAC.wav");
				echo("KILLS " @ %kills);
				if (%kills >= 5) {
					%clipammo = Player::GetItemCount(%cl,$zs::regenclip[Fiveseven]);
					%clipregen = %clipammo + floor($zs::regenammo[Fiveseven] * (0.25 + %bonus));
					player::SetItemCount(%cl,Clip57MM,%clipregen);
					%clipammo = Player::GetItemCount(%cl,$zs::regenclip[P228]);
					%clipregen = %clipammo + floor($zs::regenammo[P228] * (0.25 + %bonus));
					player::SetItemCount(%cl,Clip9MM,%clipregen);
					if (%kills >= 15) {
						%clipammo = Player::GetItemCount(%cl,$zs::regenclip[Beretta]);
						%clipregen = %clipammo + floor($zs::regenammo[Beretta] * (0.25 + %bonus));
						player::SetItemCount(%cl,Clip9MM,%clipregen);
						if (%kills >= 25) {
							%clipammo = Player::GetItemCount(%cl,$zs::regenclip[Glock]);
							%clipregen = %clipammo + floor($zs::regenammo[Glock] * (0.25 + %bonus));
							player::SetItemCount(%cl,Clip9MM,%clipregen);
							if (%kills >= 30) {
								%clipammo = Player::GetItemCount(%cl,$zs::regenclip[Deagle]);
								%clipregen = %clipammo + floor($zs::regenammo[Deagle] * (0.25 + %bonus));
								player::SetItemCount(%cl,Clip50AE,%clipregen);
								if (%kills >= 40) {
									%clipammo = Player::GetItemCount(%cl,$zs::regenclip[MP5]);
									%clipregen = %clipammo + floor($zs::regenammo[MP5] * (0.25 + %bonus));
									player::SetItemCount(%cl,Clip9MM,%clipregen);
									if (%kills >= 45) {
										%clipammo = Player::GetItemCount(%cl,$zs::regenclip[MAC10]);
										%clipregen = %clipammo + floor($zs::regenammo[MAC10] * (0.25 + %bonus));
										player::SetItemCount(%cl,Clip45CAL,%clipregen);
										if (%kills >= 55) {
											%clipammo = Player::GetItemCount(%cl,$zs::regenclip[M1014]);
											%clipregen = %clipammo + floor($zs::regenammo[M1014] * (0.25 + %bonus));
											player::SetItemCount(%cl,Clip00Buck,%clipregen);
										}
									}
								}
							}
						}	
					}
				}
			}
		}
	}
}

//---------------------------------------------------------------------------------------------------

// WEAPON UPGRADES

function zs::checkGunUp(%id) 
{
	echo("ZS GUNUPGRADE");
	%name = Client::GetName(%id);
	%kills = $zs::killedzombies[%name];
	if (%kills == 5) {
		CenterPrint(%id,"<jc><f2>Arsenal Upgraded!",3);
		player::incItemCount(%id,Clip57MM,20);
		player::setItemCount(%id,P228,1);
		player::setItemCount(%id,P228Ammo,15);
		player::incItemCount(%id,Clip9MM,30);
	}
	if (%kills == 10) {
		CenterPrint(%id,"<jc><f2>Medikit and Ammo Upgrade!",3);
		%player = Client::GetOwnedObject(%id);
		GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) - 35);
		player::incItemCount(%id,Clip57MM,40);
		player::incItemCount(%id,Clip9MM,30);
		$zs::poison[%name]++;
	}
	if (%kills == 15) {
		CenterPrint(%id,"<jc><f2>Arsenal Upgraded!",3);
		player::incItemCount(%id,Clip57MM,20);
		player::setItemCount(%id,Beretta,1);
		player::setItemCount(%id,BerettaAmmo,17);
		player::incItemCount(%id,Clip9MM,47);
	}
	if (%kills == 20) {
		CenterPrint(%id,"<jc><f2>Medikit and Ammo Upgrade!",3);
		%player = Client::GetOwnedObject(%id);
		GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) - 35);
		player::incItemCount(%id,Clip57MM,40);
		player::incItemCount(%id,Clip9MM,37);
		$zs::poison[%name]++;
	}
	if (%kills == 25) {
		CenterPrint(%id,"<jc><f2>Arsenal Upgraded!",3);
		player::incItemCount(%id,Clip57MM,20);
		player::incItemCount(%id,Clip9MM,66);
		player::setItemCount(%id,Glock,1);
		player::setItemCount(%id,GlockAmmo,17);
	}
	if (%kills == 30) {
		CenterPrint(%id,"<jc><f2>Arsenal Upgraded!",3);
		player::incItemCount(%id,Clip57MM,20);
		player::incItemCount(%id,Clip9MM,32);
		player::setItemCount(%id,Deagle,1);
		player::setItemCount(%id,DeagleAmmo,7);
		player::incItemCount(%id,Clip50AE,21);
	}
	if (%kills == 35) {
		CenterPrint(%id,"<jc><f2>Medikit and Ammo Upgrade!",3);
		%player = Client::GetOwnedObject(%id);
		GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) - 35);
		player::incItemCount(%id,Clip57MM,40);
		player::incItemCount(%id,Clip9MM,100);
		player::incItemCount(%id,Clip50AE,21);
		$zs::poison[%name]++;
	}
	if (%kills == 40) {
		CenterPrint(%id,"<jc><f2>Arsenal Upgraded!",3);
		player::incItemCount(%id,Clip57MM,20);
		player::incItemCount(%id,Clip9MM,154);
		player::setItemCount(%id,MP5,1);
		player::setItemCount(%id,MP5Ammo,30);
		player::incItemCount(%id,Clip50AE,21);
	}
	if (%kills == 45) {
		CenterPrint(%id,"<jc><f2>Arsenal Upgraded!",3);
		player::incItemCount(%id,Clip57MM,20);
		player::incItemCount(%id,Clip9MM,79);
		player::setItemCount(%id,MAC10,1);
		player::setItemCount(%id,MAC10Ammo,30);
		player::incItemCount(%id,Clip45CAL,90);
	}
	if (%kills == 50) {
		CenterPrint(%id,"<jc><f2>Medikit and Ammo Upgrade!",3);
		%player = Client::GetOwnedObject(%id);
		GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) - 35);
		player::incItemCount(%id,Clip57MM,40);
		player::incItemCount(%id,Clip9MM,100);
		player::incItemCount(%id,Clip50AE,21);
		player::incItemCount(%id,Clip45CAL,60);
		$zs::poison[%name]++;
	}
	if (%kills == 55) {
		CenterPrint(%id,"<jc><f2>Arsenal Upgraded!",3);
		player::incItemCount(%id,Clip57MM,20);
		player::incItemCount(%id,Clip9MM,79);
		player::incItemCount(%id,Clip45CAL,30);
		player::setItemCount(%id,M1014,1);
		player::setItemCount(%id,M1014Ammo,7);
		player::incItemCount(%id,Clip00Buck,21);
	}
}


//---------------------------------------------------------------------------------------------------

$zs::ammo[Fiveseven] = 20;
$zs::clip[Fiveseven] = "Clip57MM";
$zs::reloadtime[Fiveseven] = 1.87;
$zs::ammoname[Fiveseven] = "5.7MM";

$zs::ammo[P228] = 15;
$zs::clip[P228] = "Clip9MM";
$zs::reloadtime[P228] = 2.13;
$zs::ammoname[P228] = "9MM";

$zs::ammo[Beretta] = 17;
$zs::clip[Beretta] = "Clip9MM";
$zs::reloadtime[Beretta] = 2.34;
$zs::ammoname[Beretta] = "9MM";

$zs::ammo[Glock] = 17;
$zs::clip[Glock] = "Clip9MM";
$zs::reloadtime[Glock] = 2.14;
$zs::ammoname[Glock] = "9MM";

$zs::ammo[Deagle] = 7;
$zs::clip[Deagle] = "Clip50AE";
$zs::reloadtime[Deagle] = 2.55;
$zs::ammoname[Deagle] = ".50 AE";

$zs::ammo[MP5] = 30;
$zs::clip[MP5] = "Clip9MM";
$zs::reloadtime[MP5] = 3.18;
$zs::ammoname[MP5] = "9MM";

$zs::ammo[MAC10] = 30;
$zs::clip[MAC10] = "Clip45CAL";
$zs::reloadtime[MAC10] = 2.25;
$zs::ammoname[MAC10] = ".45 CAL";

$zs::ammo[M1014] = 7;
$zs::clip[M1014] = "Clip00Buck";
$zs::reloadtime[M1014] = 5.1;
$zs::ammoname[M1014] = "3\" 00 Buck";


// "
// FIX COLORS

$zs::reloadsound["Fiveseven",0] = "SndFivesevenClipOut";
$zs::reloadsound["Fiveseven",1] = "SndFivesevenClipIn";
$zs::playreload["Fiveseven"] = 0.88;
$zs::reloadsound["P228",0] = "SndP228ClipOut";
$zs::reloadsound["P228",1] = "SndP228ClipIn";
$zs::playreload["P228"] = 1.48;
$zs::reloadsound["Beretta",0] = "SndBerettaClipOut";
$zs::reloadsound["Beretta",1] = "SndBerettaClipIn";
$zs::playreload["Beretta"] = 1.91;
$zs::reloadsound["Glock",0] = "SndGlockClipOut";
$zs::reloadsound["Glock",1] = "SndGlockClipIn";
$zs::playreload["Glock"] = 1.48;
$zs::reloadsound["Deagle",0] = "SndDeagleClipOut";
$zs::reloadsound["Deagle",1] = "SndDeagleClipIn";
$zs::playreload["Deagle"] = 1.90;
$zs::reloadsound["MP5",0] = "SndMP5ClipOut";
$zs::reloadsound["MP5",1] = "SndMP5ClipIn";
$zs::playreload["MP5"] = 2.46;
$zs::reloadsound["MAC10",0] = "SndMAC10ClipOut";
$zs::reloadsound["MAC10",1] = "SndMAC10ClipIn";
$zs::playreload["MAC10"] = 1.53;
$zs::reloadsound["M1014",0] = "SndM1014InsertShell";

function zs::ReloadSound(%client,%weapon)
{
	%clipout = $zs::reloadsound[%weapon,0];
	%clipin = $zs::reloadsound[%weapon,1];
	%intime = $zs::playreload[%weapon];
	%player = Client::GetOwnedObject(%client);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile(%clipout,%trans,%player,%vel);
	schedule("zs::ClipInSound("@%clipin@","@%player@");",%intime);
}

function zs::ClipInSound(%sound,%player)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile(%sound,%trans,%player,%vel);
}

function zs::ReloadShotSound(%client,%missing)
{
	%sound = "SndM1014InsertShell";
	%player = Client::GetOwnedObject(%client);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile(%sound,%trans,%player,%vel);
	%missing--;
	%soundon = 0.36;
	while (%missing > 0) {
		schedule("zs::ReloadShotSoundNew("@%sound@","@%player@");",%soundon);
		%missing--;
		%soundon = %soundon + 0.36;
	}
}

function zs::ReloadShotSoundNew(%sound,%player)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile(%sound,%trans,%player,%vel);
}

function zs::ReloadWeapon(%client)
{
	%weapon = Player::GetMountedItem(%client,0);
	if (%weapon != -1 || %weapon != "Knife") {
		%name = Client::GetName(%client);
		$zs::reloading[%name] = 1;
		%ammo = player::GetItemCount(%client,%weapon @ "Ammo");
		%clip = Player::GetItemCount(%client,$zs::clip[%weapon]);

		if (%ammo == $zs::ammo[%weapon] || %clip == 0) {
			bottomPrint(%client,"<jc><f1>" @ %weapon @ "\n<f2>" @ %ammo @ " / " @ %clip,3);
			$zs::reloading[%name] = 0;
		}

		if (%ammo < $zs::ammo[%weapon]) {
			if (%clip) {
				%missing = $zs::ammo[%weapon] - %ammo;
				if (%clip >= %missing) {
					if (%weapon != "M1014") {
						bottomPrint(%client,"<jc>Reloading <f1>" @ %weapon @ "\n<f2>" @ %ammo @ " / " @ %clip,$zs::reloadtime[%weapon]);
						zs::ReloadSound(%client,%weapon);
						schedule("zs::Reload("@%client@","@%weapon@","@%missing@");",$zs::reloadtime[%weapon]);
					}
					else {
						%shotmiss = %missing;
						%reloadtime = 0;
						while (%shotmiss > 0) {
							%reloadtime = %reloadtime + 0.36;
							%shotmiss = %shotmiss - 1;
						}
						bottomPrint(%client,"<jc>Reloading <f1>" @ %weapon @ "\n<f2>" @ %ammo @ " / " @ %clip,%reloadtime);
						zs::ReloadShotSound(%client,%missing);
						schedule("zs::Reload("@%client@","@%weapon@","@%missing@");",%reloadtime);
					}
				}
				if (%clip < %missing) {
					%missing = %clip;
					if (%weapon != "M1014") {
						bottomPrint(%client,"<jc>Reloading <f1>" @ %weapon @ "\n<f2>" @ %ammo @ " / " @ %clip,$zs::reloadtime[%weapon]);
						zs::ReloadSound(%client,%weapon);
						schedule("zs::Reload("@%client@","@%weapon@","@%missing@");",$zs::reloadtime[%weapon]);
					}
					else {
						%shotmiss = %missing;
						%reloadtime = 0;
						while (%shotmiss > 0) {
							%reloadtime = %reloadtime + 0.36;
							%shotmiss = %shotmiss - 1;
						}
						bottomPrint(%client,"<jc>Reloading <f1>" @ %weapon @ "\n<f2>" @ %ammo @ " / " @ %clip,%reloadtime);
						zs::ReloadShotSound(%client,%missing);
						schedule("zs::Reload("@%client@","@%weapon@","@%missing@");",%reloadtime);
					}
				}	
			}
		}
	}
}

function zs::resetreload(%name)
{
	$zs::reloading[%name] = 0;
}

function zs::Reload(%client,%weapon,%missing)
{
	player::DecItemCount(%client,$zs::clip[%weapon],%missing);
	player::IncItemCount(%client,%weapon @ "Ammo",%missing);
	%ammo = player::GetItemCount(%client,%weapon @ "Ammo");
	%clip = Player::GetItemCount(%client,$zs::clip[%weapon]);
	bottomPrint(%client,"<jc><f1>" @ %weapon @ "\n<f2>" @ %ammo @ " / " @ %clip,3);
	%name = Client::GetName(%client);
	$zs::reloading[%name] = 0;
}

//---------------------------------------------------------------------------------------------------

function zs::negtopos(%n)
{
	%len = string::len(%n) - 1;
	%crop = string::right(%n,%len);
	return %crop;
}

function zs::impulse(%id,%a,%za)
{
	%m = GameBase::GetMuzzleTransform(%id);
	%z = getWord(%m,5);
	if (%z > 0) {
		%zcrop = %z * %za;
		//%zm = "pos";
	}
	if (%z < 0) {
		%zcrop = %z * 100;
		%zcrop = zs::negtopos(%zcrop);
		//%zm = "neg";
	}
	%r = GameBase::GetRotation(%id);
	%v = Vector::getFromRot(%r);
	%x = getWord(%v,0);
	%y = getWord(%v,1);
	%xcrop = 100 - %zcrop;
	%xcrop = %xcrop / 100;
	%x = %x * %xcrop;
	%ycrop = 100 - %zcrop;
	%ycrop = %ycrop / 100;
	%y = %y * %ycrop;
	%zcrop = %zcrop / 100;
	%z = %a * %zcrop;
	%x = %x * %a;
	%y = %y * %a;
	Item::SetVelocity(%id,%x @ " " @ %y @ " " @ %z);
}

//---------------------------------------------------------------------------------------------------

// POISON HEADCRAB

function zs::checkPoison(%id)
{
	%name = Client::GetName(%id);
	%poson = $zs::poison[%name];
	schedule("zs::Poison("@%id@","@%poson@");",5);
	schedule("zs::Poison("@%id@","@%poson@");",10);
	schedule("zs::Poison("@%id@","@%poson@");",15);
	schedule("zs::Poison("@%id@","@%poson@");",20);
	schedule("zs::Poison("@%id@","@%poson@");",25);
}

function zs::Poison(%id,%poson)
{
	//echo("ZS POISON " @ %id @ " " @ %poson);
	%name = Client::GetName(%id);
	%curpos = $zs::poison[%name];
	%player = Client::getOwnedObject(%id);
	//echo("CUR POS " @ %curpos);
	if (%curpos == %poson) {
		%flash = Player::getDamageFlash(%player) + 0.1;
		if (%flash > 0.75)
			%flash = 0.75;
		Player::setDamageFlash(%player,%flash);
		if (GameBase::getDamageLevel(%player) >= 95) {
			GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) + 999);
			Player::BlowUp(%player);
			Player::Kill(%id);
			%name = Client::GetName(%id);
			%team = Client::GetTeam(%id);
			if (%team == 0) {
				if ($zs::lastdamage[%name] != "") {
					%kname = $zs::lastdamage[%name];
					MessageAll(0,%kname @ " [Poison Headcrab] " @ %name);
					$zs::killedhumans[%kname]++;
					GameBase::SetTeam(%id,1);
					zs::defaultPlayer(%id);
					zs::GameOverCheck();
				}
			}
		}
		else {
			GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) + 3);
		}
	}
}

//---------------------------------------------------------------------------------------------------

function zs::GameOverCheck()
{
	%humans = 0;
	%zombies = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		%team = Client::GetTeam(%cl);
		if (%team == 0)
			%humans++;
		if (%team == 1)
			%zombies++;
	}
		
	if (%humans >= 1) {
		if (%zombies == 0) {
  			if ($matchStarted) {
				MessageAll(0,"Humans won the game!");
				zs::CheckSurvZombTimes();
				zs::Ranks();
				ObjectiveMission::missionComplete();
			}
		}
		else {
			if (%humans == 1) {
				if ($matchStarted) {
					MessageAll(0,"Kill the last human!");
					$zs::lasthuman = 1;
				}
			}
		}
	}

	else if (%humans == 0) {
		if ($matchStarted) {
			MessageAll(0,"Zombies won the game!");
			$zombieswon = 1;
			zs::CheckSurvZombTimes();
			zs::Ranks();
			ObjectiveMission::missionComplete();
		}
	}
		
	//if (%zombies == 0 && %humans > 2) {
	//	zs::CheckForZombie();
	//}
}


