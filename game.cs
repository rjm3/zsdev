exec("comchat.cs");

exec(core);

$SensorNetworkEnabled = false;

$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;


//  Global Variables

//---------------------------------------------------------------------------------
// Energy each team is given at beginning of game
//---------------------------------------------------------------------------------
$DefaultTeamEnergy = "Infinite";

//---------------------------------------------------------------------------------
// Team Energy variables
//---------------------------------------------------------------------------------
$TeamEnergy[-1] = $DefaultTeamEnergy; 
$TeamEnergy[0]  = $DefaultTeamEnergy; 
$TeamEnergy[1]  = $DefaultTeamEnergy; 
$TeamEnergy[2]  = $DefaultTeamEnergy; 
$TeamEnergy[3]  = $DefaultTeamEnergy; 
$TeamEnergy[4]  = $DefaultTeamEnergy; 
$TeamEnergy[5]  = $DefaultTeamEnergy; 
$TeamEnergy[6]  = $DefaultTeamEnergy; 				
$TeamEnergy[7]  = $DefaultTeamEnergy; 

//---------------------------------------------------------------------------------
// Time in sec player must wait before he can throw a Grenade or Mine after leaving
//	a station.
//---------------------------------------------------------------------------------
$WaitThrowTime = 2;

//---------------------------------------------------------------------------------
// If 1 then Team Spending Ignored -- Team Energy is set to $MaxTeamEnergy every
// 	$secTeamEnergy.
//---------------------------------------------------------------------------------
$TeamEnergyCheat = 0;

//---------------------------------------------------------------------------------
// MAX amount team energy can reach
//---------------------------------------------------------------------------------
$MaxTeamEnergy = 700000;

//---------------------------------------------------------------------------------
//  Time player has to put flag in flagstand before it gets returned to its last
//  location. 
//---------------------------------------------------------------------------------
$flagToStandTime = 180;	  

//---------------------------------------------------------------------------------
// Amount to inc team energy every ($secTeamEnergy) seconds
//---------------------------------------------------------------------------------
$incTeamEnergy = 700;

//---------------------------------------------------------------------------------
// (Rate is sec's) Set how often TeamEnergy is incremented
//---------------------------------------------------------------------------------
$secTeamEnergy = 30;

//---------------------------------------------------------------------------------
// (Rate is sec's) Items respwan
//---------------------------------------------------------------------------------
$ItemRespawnTime = 30;

//---------------------------------------------------------------------------------
//Amount of Energy remote stations start out with
//---------------------------------------------------------------------------------
$RemoteAmmoEnergy = 2500; 
$RemoteInvEnergy = 3000;

//---------------------------------------------------------------------------------
// TEAM ENERGY -  Warn team when teammate has spent x amount - Warn team that 
//				  energy level is low when it reaches x amount 
//---------------------------------------------------------------------------------
$TeammateSpending = -4000;  //Set = to 0 if don't want the warning message
$WarnEnergyLow = 4000;	    //Set = to 0 if don't want the warning message

//---------------------------------------------------------------------------------
// Amount added to TeamEnergy when a player joins a team
//---------------------------------------------------------------------------------
$InitialPlayerEnergy = 5000;

//---------------------------------------------------------------------------------
// REMOTE TURRET
//---------------------------------------------------------------------------------
$MaxNumTurretsInBox = 2;     //Number of remote turrets allowed in the area
$TurretBoxMaxLength = 50;    //Define Max Length of the area
$TurretBoxMaxWidth =  50;    //Define Max Width of the area
$TurretBoxMaxHeight = 25;    //Define Max Height of the area

$TurretBoxMinLength = 10;	  //Define Min Length from another turret
$TurretBoxMinWidth =  10;	  //Define Min Width from another turret
$TurretBoxMinHeight = 10;    //Define Min Height from another turret

//---------------------------------------------------------------------------------
//	Object Types	
//---------------------------------------------------------------------------------
$SimTerrainObjectType    = 1 << 1;
$SimInteriorObjectType   = 1 << 2;
$SimPlayerObjectType     = 1 << 7;

$MineObjectType		    = 1 << 26;	
$MoveableObjectType	    = 1 << 22;
$VehicleObjectType	 	 = 1 << 29;  
$StaticObjectType			 = 1 << 23;	   
$ItemObjectType			 = 1 << 21;	  

//---------------------------------------------------------------------------------
// CHEATS
//---------------------------------------------------------------------------------
$ServerCheats = 0;
$TestCheats = 0;

//---------------------------------------------------------------------------------
//Respawn automatically after X sec's -  If 0..no respawn
//---------------------------------------------------------------------------------
$AutoRespawn = 0;

//---------------------------------------------------------------------------------
// Player death messages - %1 = killer's name, %2 = victim's name
//       %3 = killer's gender pronoun (his/her), %4 = victim's gender pronoun
//---------------------------------------------------------------------------------
$deathMsg[$LandingDamageType, 0]      = "%2 falls to %3 death.";
$deathMsg[$LandingDamageType, 1]      = "%2 forgot to tie %3 bungie cord.";
$deathMsg[$LandingDamageType, 2]      = "%2 bites the dust in a forceful manner.";
$deathMsg[$LandingDamageType, 3]      = "%2 fall down go boom.";
$deathMsg[$ImpactDamageType, 0]      = "%1 makes quite an impact on %2.";
$deathMsg[$ImpactDamageType, 1]      = "%2 becomes the victim of a fly-by from %1.";
$deathMsg[$ImpactDamageType, 2]      = "%2 leaves a nasty dent in %1's fender.";
$deathMsg[$ImpactDamageType, 3]      = "%1 says, 'Hey %2, you scratched my paint job!'";
$deathMsg[$BulletDamageType, 0]      = "%1 ventilates %2 with %3 chaingun.";
$deathMsg[$BulletDamageType, 1]      = "%1 gives %2 an overdose of lead.";
$deathMsg[$BulletDamageType, 2]      = "%1 fills %2 full of holes.";
$deathMsg[$BulletDamageType, 3]      = "%1 guns down %2.";
$deathMsg[$EnergyDamageType, 0]      = "%2 dies of turret trauma.";
$deathMsg[$EnergyDamageType, 1]      = "%2 is chewed to pieces by a turret.";
$deathMsg[$EnergyDamageType, 2]      = "%2 walks into a stream of turret fire.";
$deathMsg[$EnergyDamageType, 3]      = "%2 ends up on the wrong side of a turret.";
$deathMsg[$PlasmaDamageType, 0]      = "%2 feels the warm glow of %1's plasma.";
$deathMsg[$PlasmaDamageType, 1]      = "%1 gives %2 a white-hot plasma injection.";
$deathMsg[$PlasmaDamageType, 2]      = "%1 asks %2, 'Got plasma?'";
$deathMsg[$PlasmaDamageType, 3]      = "%1 gives %2 a plasma transfusion.";
$deathMsg[$ExplosionDamageType, 0]   = "%2 catches a Frisbee of Death thrown by %1.";
$deathMsg[$ExplosionDamageType, 1]   = "%1 blasts %2 with a well-placed disc.";
$deathMsg[$ExplosionDamageType, 2]   = "%1's spinfusor caught %2 by surprise.";
$deathMsg[$ExplosionDamageType, 3]   = "%2 falls victim to %1's Stormhammer.";
$deathMsg[$ShrapnelDamageType, 0]    = "%1 blows %2 up real good.";
$deathMsg[$ShrapnelDamageType, 1]    = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$ShrapnelDamageType, 2]    = "%1 gives %2 a fatal concussion.";
$deathMsg[$ShrapnelDamageType, 3]    = "%2 never saw it coming from %1.";
$deathMsg[$LaserDamageType, 0]       = "%1 adds %2 to %3 list of sniper victims.";
$deathMsg[$LaserDamageType, 1]       = "%1 fells %2 with a sniper shot.";
$deathMsg[$LaserDamageType, 2]       = "%2 becomes a victim of %1's laser rifle.";
$deathMsg[$LaserDamageType, 3]       = "%2 stayed in %1's crosshairs for too long.";
$deathMsg[$MortarDamageType, 0]      = "%1 mortars %2 into oblivion.";
$deathMsg[$MortarDamageType, 1]      = "%2 didn't see that last mortar from %1.";
$deathMsg[$MortarDamageType, 2]      = "%1 inflicts a mortal mortar wound on %2.";
$deathMsg[$MortarDamageType, 3]      = "%1's mortar takes out %2.";
$deathMsg[$BlasterDamageType, 0]     = "%2 gets a blast out of %1.";
$deathMsg[$BlasterDamageType, 1]     = "%2 succumbs to %1's rain of blaster fire.";
$deathMsg[$BlasterDamageType, 2]     = "%1's puny blaster shows %2 a new world of pain.";
$deathMsg[$BlasterDamageType, 3]     = "%2 meets %1's master blaster.";
$deathMsg[$ElectricityDamageType, 0] = "%2 gets zapped with %1's ELF gun.";
$deathMsg[$ElectricityDamageType, 1] = "%1 gives %2 a nasty jolt.";
$deathMsg[$ElectricityDamageType, 2] = "%2 gets a real shock out of meeting %1.";
$deathMsg[$ElectricityDamageType, 3] = "%1 short-circuits %2's systems.";
$deathMsg[$CrushDamageType, 0]		 = "%2 didn't stay away from the moving parts.";
$deathMsg[$CrushDamageType, 1]		 = "%2 is crushed.";
$deathMsg[$CrushDamageType, 2]		 = "%2 gets smushed flat.";
$deathMsg[$CrushDamageType, 3]		 = "%2 gets caught in the machinery.";
$deathMsg[$DebrisDamageType, 0]		 = "%2 is a victim among the wreckage.";
$deathMsg[$DebrisDamageType, 1]		 = "%2 is killed by debris.";
$deathMsg[$DebrisDamageType, 2]		 = "%2 becomes a victim of collateral damage.";
$deathMsg[$DebrisDamageType, 3]		 = "%2 got too close to the exploding stuff.";
$deathMsg[$MissileDamageType, 0]	    = "%2 takes a missile up the keister.";
$deathMsg[$MissileDamageType, 1]	    = "%2 gets shot down.";
$deathMsg[$MissileDamageType, 2]	    = "%2 gets real friendly with a rocket.";
$deathMsg[$MissileDamageType, 3]	    = "%2 feels the burn from a warhead.";
$deathMsg[$MineDamageType, 0]	       = "%1 blows %2 up real good.";
$deathMsg[$MineDamageType, 1]	       = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$MineDamageType, 2]	       = "%1 gives %2 a fatal concussion.";
$deathMsg[$MineDamageType, 3]	       = "%2 never saw it coming from %1.";

// "you just killed yourself" messages
//   %1 = player name,  %2 = player gender pronoun

$deathMsg[-2,0]						 = "%1 ends it all.";
$deathMsg[-2,1]						 = "%1 takes %2 own life.";
$deathMsg[-2,2]						 = "%1 kills %2 own dumb self.";
$deathMsg[-2,3]						 = "%1 decides to see what the afterlife is like.";

$numDeathMsgs = 4;
//---------------------------------------------------------------------------------

$spawnBuyList[0] = classHuman;
$spawnBuyList[1] = Blaster;
$spawnBuyList[2] = Chaingun;
$spawnBuyList[3] = Disclauncher;
$spawnBuyList[4] = RepairKit;
$spawnBuyList[5] = "";

function remotePlayMode(%clientId)
{
   if(!%clientId.guiLock)
   {
      remoteSCOM(%clientId, -1);
      Client::setGuiMode(%clientId, $GuiModePlay);
   }
}

//function remoteCommandMode(%clientId)
//{
//   // can't switch to command mode while a server menu is up
//   if(!%clientId.guiLock)
//   {
//      remoteSCOM(%clientId, -1);  // force the bandwidth to be full command
//		if(%clientId.observerMode != "pregame")
//		   checkControlUnmount(%clientId);
//		Client::setGuiMode(%clientId, $GuiModeCommand);
//   }
//}

//function remoteInventoryMode(%clientId)
//{
//   if(!%clientId.guiLock && !Observer::isObserver(%clientId))
//   {
//      remoteSCOM(%clientId, -1);
//      Client::setGuiMode(%clientId, $GuiModeInventory);
//   }
//}

function remoteObjectivesMode(%clientId)
{
   if(!%clientId.guiLock)
   {
      remoteSCOM(%clientId, -1);
      Client::setGuiMode(%clientId, $GuiModeObjectives);
   }
}

function remoteScoresOn(%clientId)
{
   if(!%clientId.menuMode)
      Game::menuRequest(%clientId);
}

function remoteScoresOff(%clientId)
{
   Client::cancelMenu(%clientId);
}

//function remoteToggleCommandMode(%clientId)
//{
//	if (Client::getGuiMode(%clientId) != $GuiModeCommand)
//		//if (Client::GetTeam(%clientId))
//			remoteCommandMode(%clientId);
//	else
//		remotePlayMode(%clientId);
//}

//function remoteToggleInventoryMode(%clientId)
//{
//	if (Client::getGuiMode(%clientId) != $GuiModeInventory)
//		remoteInventoryMode(%clientId);
//	else
//		remotePlayMode(%clientId);
//}

function remoteToggleObjectivesMode(%clientId)
{
	if (Client::getGuiMode(%clientId) != $GuiModeObjectives)
		remoteObjectivesMode(%clientId);
	else
		remotePlayMode(%clientId);
}

function Time::getMinutes(%simTime)
{
   return floor(%simTime / 60);
}

function Time::getSeconds(%simTime)
{
   return %simTime % 60;
}

function Game::pickRandomSpawn(%team)
{
   %group = nameToID("MissionGroup/Teams/team" @ %team @ "/DropPoints/Random");
   %count = Group::objectCount(%group);
   if(!%count)
      return -1;
  	%spawnIdx = floor(getRandom() * (%count - 0.1));
  	%value = %count;
	for(%i = %spawnIdx; %i < %value; %i++) {
		%set = newObject("set",SimSet);
		%obj = Group::getObject(%group, %i);
		if(containerBoxFillSet(%set,$SimPlayerObjectType|$VehicleObjectType,GameBase::getPosition(%obj),2,2,4,0) == 0) {
			deleteObject(%set);
			return %obj;		
		}
		if(%i == %count - 1) {
			%i = -1;
			%value = %spawnIdx;
		}
		deleteObject(%set);
	}
   return false;
}

function Game::pickStartSpawn(%team)
{
   %group = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\DropPoints\\Start");
   %count = Group::objectCount(%group);
   if(!%count)
      return -1;

   %spawnIdx = $lastTeamSpawn[%team] + 1;
   if(%spawnIdx >= %count)
      %spawnIdx = 0;
   $lastTeamSpawn[%team] = %spawnIdx;
   return Group::getObject(%group, %spawnIdx);
}

function Game::pickTeamSpawn(%team, %respawn)
{
   if(%respawn)
      return Game::pickRandomSpawn(%team);
   else
   {
      %spawn = Game::pickStartSpawn(%team);
      if(%spawn == -1)
         return Game::pickRandomSpawn(%team);
      return %spawn;
   }
}

function Game::pickObserverSpawn(%client)
{
   %group = nameToID("MissionGroup\\ObserverDropPoints");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      %group = nameToID("MissionGroup\\Teams\\team" @ Client::getTeam(%client) @ "\\DropPoints\\Random");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      %group = nameToID("MissionGroup\\Teams\\team0\\DropPoints\\Random");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      return -1;
   %spawnIdx = %client.lastObserverSpawn + 1;
   if(%spawnIdx >= %count)
      %spawnIdx = 0;
   %client.lastObserverSpawn = %spawnIdx;
	return Group::getObject(%group, %spawnIdx);
}

function UpdateClientTimes(%time)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      remoteEval(%cl, "setTime", -%time);
}

function Game::notifyMatchStart(%time)
{
   messageAll(0, "Match starts in " @ %time @ " seconds.");
   UpdateClientTimes(%time);
}

function Game::startMatch()
{
   $matchStarted = true;
   $missionStartTime = getSimTime();
   messageAll(0, "Match started.");
	Game::resetScores();	

   %numTeams = getNumTeams();
   for(%i = 0; %i < %numTeams; %i = %i + 1) {
		if($TeamEnergy[%i] != "Infinite")
			schedule("replenishTeamEnergy(" @ %i @ ");", $secTeamEnergy);
	}

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
		if(%cl.observerMode == "pregame")
      {
         %cl.observerMode = "";
         Client::setControlObject(%cl, Client::getOwnedObject(%cl));
      }
   	Game::refreshClientScore(%cl);
	}
   Game::checkTimeLimit();
}

function Game::pickPlayerSpawn(%clientId, %respawn)
{
   return Game::pickTeamSpawn(Client::getTeam(%clientId), %respawn);
}

function Game::playerSpawn(%clientId, %respawn)
{
   if(!$ghosting)
      return false;

	Client::clearItemShopping(%clientId);
   %spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
   if(!%respawn)
   {
      // initial drop
      // bottomprint(%clientId, "<jc><f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 5);
   }
	if(%spawnMarker) {   
		%clientId.guiLock = "";
	 	%clientId.dead = "";
	   if(%spawnMarker == -1)
	   {
	      %spawnPos = "0 0 300";
	      %spawnRot = "0 0 0";
	   }
	   else
	   {
	      %spawnPos = GameBase::getPosition(%spawnMarker);
	      %spawnRot = GameBase::getRotation(%spawnMarker);
	   }

		if(!String::ICompare(Client::getGender(%clientId), "Male"))
	      %armor = "larmor";
		if (Client::GetTeam(%clientId) == 0) {
			echo("PLAYER SPAWNING WITH ARMOR HUMAN");
			%armor = "armorHuman";
		}
	   else
	      %armor = "armorHuman";

		//---------------------------------------------------------------------------------
		// SPAWN PLAYER
		//
		
		%cname = Client::GetName(%clientId);
		$zs::lastdamage[%cname] = "";

		$zs::lastmuzzle[%pname] = "";
		$zs::lastvel[%pname] = "";
		$zs::lastplayer[%pname] = "";

		if ($zs::newzombie[%cname]) {
			if ($zs::lastpos[%cname] != "") {
				%spawnPos = $zs::lastpos[%cname];
				%spawnRot = $zs::lastrot[%cname];
			}
		}
		
		echo(" TEST SPAWN ");
		
		if (!$zs::locked[%cname]) {
	   		%pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
			$zs::afk[%cname] = 0;
			$zs::onspawn[%cname]++;
		}

		//---------------------------------------------------------------------------------

	   echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
	   if(%pl != -1)
	   {
	      GameBase::setTeam(%pl, Client::getTeam(%clientId));
	      Client::setOwnedObject(%clientId, %pl);
	      Game::playerSpawned(%pl, %clientId, %armor, %respawn);
	      
	      if($matchStarted)
	         Client::setControlObject(%clientId, %pl);
	      else
	      {
	         %clientId.observerMode = "pregame";
	         Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	         Observer::setOrbitObject(%clientId, %pl, 3, 3, 3);
	      }
	   }
      return true;
	}
	else {
		Client::sendMessage(%clientId,0,"Sorry No Respawn Positions Are Empty - Try again later ");
      return false;
	}
}

function Game::playerSpawned(%pl, %clientId, %armor)
{						  
	%clientId.spawn= 1;
	%max = getNumItems();
	
	//-------------------------------------------------------------------------------
	//
	// HUMAN / ZOMBIE SPAWN
	//

	%name = Client::GetName(%clientId);
	$zs::poison[%name]++;

	%team = client::getTeam(%clientId);
	if (%team == 0) {
		echo("PLAYER IS TEAM 0");
		client::setSkin(%clientId,rpghuman0);
		if(!String::ICompare(Client::getGender(%clientId), "Male")) {
			player::SetArmor(%clientId,"armorHuman");
			player::setItemCount(%clientId,classHuman,1);
		}
		else {
			player::setArmor(%clientId,"armorHumanF");
			player::setItemCount(%clientId,classHumanF,1);
		}
		player::setItemCount(%clientId,Fiveseven,1);
		player::setItemCount(%clientId,FivesevenAmmo,20);
		player::setItemCount(%clientId,Clip57MM,40);
		player::setItemCount(%clientId,Grenade,1);
		player::setItemCount(%clientId,Knife,1);
		player::setItemCount(%clientId,KnifeAmmo,1);
		//player::setItemCounT(%clientId,TargetingLaser,1);
		player::setItemCounT(%clientId,Beacon,1);
		player::setItemCount(%clientId,MineAmmo,1);
		player::setItemCount(%clientId,RepairPack,1);
		player::useItem(%pl,Fiveseven);
		player::useItem(%pl,RepairPack);
	}
	if (%team == 1) {
		%name = Client::GetName(%clientId);
		%class = $zs::zombieclass[%name];
		if (%class == "zombie") {
			player::SetArmor(%clientId,armorZombie);
			Client::setSkin(%clientId,zombie);
			player::setItemCount(%clientId,classZombie,1);
			player::setItemCount(%clientId,ZombieS,1);
			player::setItemCount(%clientId,ZombieSAmmo,1);
			player::setItemCount(%clientId,MineAmmo,1);
			player::setItemCount(%clientId,RepairPack,1);
			player::useItem(%pl,ZombieS);
			player::useItem(%pl,RepairPack);
			if ($zs::newzombie[%name]) {
				echo("NEW ZOMBIE TAKE HIS HEALTH");
				$zs::newzombie[%name] = 0;
				GameBase::setDamageLevel(%pl,GameBase::getDamageLevel(%pl) + 280);
			}
		}
		else if (%class == "headcrab") {
			player::setArmor(%clientId,armorHeadcrab);
			player::setItemCount(%clientId,classHeadcrab,1);
			player::setItemCount(%clientId,Headcrab,1);
			player::setItemCount(%clientId,HeadcrabAmmo,1);
			player::setItemCount(%clientId,HeadcrabPack,1);
			player::setItemCount(%clientId,MineAmmo,1);
			player::setItemCount(%clientId,RepairPack,1);
			player::useItem(%pl,Headcrab);
			player::useItem(%pl,RepairPack);
			player::mountItem(%pl,HeadcrabPack,2,1);
		}
		else if (%class == "fheadcrab") {
			player::setArmor(%clientId,armorFheadcrab);
			player::setItemCount(%clientId,classFheadcrab,1);
			player::setItemCount(%clientId,Headcrab,1);
			player::setItemCount(%clientId,HeadcrabAmmo,1);
			player::setItemCount(%clientId,HeadcrabPack,1);
			player::setItemCount(%clientId,MineAmmo,1);
			player::setItemCount(%clientId,RepairPack,1);
			player::useItem(%pl,Headcrab);
			player::useItem(%pl,RepairPack);
			player::mountItem(%pl,HeadcrabPack,2,1);
		}
		else if (%class == "fzombie") {
			player::setArmor(%clientId,armorFzombie);
			Client::setSkin(%clientId,skel);
			player::setItemCount(%clientId,classFzombie,1);
			player::setItemCount(%clientId,MineAmmo,1);
			player::setItemCount(%clientId,FzombieS,1);
			player::setItemCount(%clientId,FzombieSAmmo,1);
			player::setItemCount(%clientId,RepairPack,1);
			player::useItem(%pl,FzombieS);
			player::useItem(%pl,RepairPack);
		}
		else if (%class == "pheadcrab") {
			player::setArmor(%clientId,armorPheadcrab);
			player::setItemCount(%clientId,classPheadcrab,1);
			player::setItemCount(%clientId,Pheadcrab,1);
			player::setItemCount(%clientId,PheadcrabAmmo,1);
			player::setItemCount(%clientId,PheadcrabPack,1);
			player::setItemCount(%clientId,PheadcrabS,1);
			player::setItemCount(%clientId,PheadcrabSAmmo,1);
			player::setItemCount(%clientId,MineAmmo,1);
			player::setItemCount(%clientId,RepairPack,1);
			player::useItem(%pl,Pheadcrab);
			player::useItem(%pl,RepairPack);
			player::mountItem(%pl,PheadcrabPack,2,1);
		}
		else if (%class == "czombie") {
			player::setArmor(%clientId,armorCzombie);
			Client::setSkin(%clientId,toxzombie0);
			player::setItemCount(%clientId,classCzombie,1);
			player::setItemCount(%clientId,MineAmmo,1);
			player::setItemCount(%clientId,CzombieS,1);
			player::setItemCount(%clientId,CzombieSAmmo,1);
			player::setItemCount(%clientId,RepairPack,1);
			player::useItem(%pl,CzombieS);
			player::useItem(%pl,RepairPack);
		}
	}
	
	Game::refreshClientScore(%clientId);

	//-------------------------------------------------------------------------------
	
   	//for(%i = 0; (%item = $spawnBuyList[%i]) != ""; %i++)
   	//{
	//	buyItem(%clientId,%item);	
	//	if(%item.className == Weapon) 
	//		%clientId.spawnWeapon = %item;
	//}

	%clientId.spawn= "";
	if(%clientId.spawnWeapon != "") {
		Player::useItem(%pl,%clientId.spawnWeapon);	
   	%clientId.spawnWeapon="";
	}
} 

function Game::autoRespawn(%client)
{
	if(%client.dead == 1)
		Game::playerSpawn(%client, "true");
}

function onServerGhostAlwaysDone()
{
}

function Game::initialMissionDrop(%clientId)
{

	//---------------------------------------------
		
	%name = Client::GetName(%clientId);
	%locked = $zs::locked[%name];
	if (%locked)
		zs::checkLogin(%clientId);
		
	Game::refreshClientScore(%clientId);

	//---------------------------------------------

	Client::setGuiMode(%clientId, $GuiModePlay);

   if($Server::TourneyMode)
      GameBase::setTeam(%clientId, -1);
   else
   {
      if(%clientId.observerMode == "observerFly" || %clientId.observerMode == "observerOrbit")
      {
	      %clientId.observerMode = "observerOrbit";
	      %clientId.guiLock = "";
         Observer::jump(%clientId);
         return;
      }
      %numTeams = getNumTeams();
      %curTeam = Client::getTeam(%clientId);

      if(%curTeam >= %numTeams || (%curTeam == -1 && (%numTeams < 2 || $Server::AutoAssignTeams)) )
         Game::assignClientTeam(%clientId);
   }    
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
   %camSpawn = Game::pickObserverSpawn(%clientId);
   Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn), 
	   GameBase::getRotation(%camSpawn), true, true);

   if(Client::getTeam(%clientId) == -1)
   {
      %clientId.observerMode = "pickingTeam";

      if($Server::TourneyMode && ($matchStarted || $matchStarting))
      {
         %clientId.observerMode = "observerFly";
         return;
      }
      else if($Server::TourneyMode)
      {
         if($Server::TeamDamageScale)
            %td = "ENABLED";
         else
            %td = "DISABLED";
         bottomprint(%clientId, "<jc><f1>Server is running in Competition Mode\nPick a team.\nTeam damage is " @ %td, 0);
      }
      Client::buildMenu(%clientId, "Pick a team:", "InitialPickTeam");
      Client::addMenuItem(%clientId, "0Observe", -2);
      Client::addMenuItem(%clientId, "1Automatic", -1);
      for(%i = 0; %i < getNumTeams(); %i = %i + 1)
         Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      %clientId.justConnected = "";
   }
   else 
   {
      Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
      if(%clientId.justConnected)
      {
         centerprint(%clientId, $Server::JoinMOTD, 3);
         %clientId.observerMode = "justJoined";
         %clientId.justConnected = "";
      }
      else if(%clientId.observerMode == "justJoined")
      {
         centerprint(%clientId, "");
         %clientId.observerMode = "";
         Game::playerSpawn(%clientId, false);
      }
      else
         Game::playerSpawn(%clientId, false);
	}
	if($TeamEnergy[Client::getTeam(%clientId)] != "Infinite")
		$TeamEnergy[Client::getTeam(%clientId)] += $InitialPlayerEnergy;
	%clientId.teamEnergy = 0;
}

function processMenuInitialPickTeam(%clientId, %team)
{
   if($Server::TourneyMode && $matchStarted)
      %team = -2;

   if(%team == -2)
   {
      Observer::enterObserverMode(%clientId);
   }
   if(%team == -1)
   {
      Game::assignClientTeam(%clientId);
      %team = Client::getTeam(%clientId);
   }
   if(%team != -2)
   {
      GameBase::setTeam(%clientId, %team);
		if($TeamEnergy[%team] != "Infinite")
			$TeamEnergy[%team] += $InitialPlayerEnergy;
      %clientId.teamEnergy = 0;
      Client::setControlObject(%clientId, -1);
      Game::playerSpawn(%clientId, false);
   }
   if($Server::TourneyMode && !$CountdownStarted)
   {
      if(%team != -2)
      {
         bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
         %clientId.notready = true;
         %clientId.notreadyCount = "";
      }
      else
      {
         bottomprint(%clientId, "", 0);
         %clientId.notready = "";
         %clientId.notreadyCount = "";
      }
   }
}

function Game::ForceTourneyMatchStart()
{
   %playerCount = 0;
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(%cl.observerMode == "pregame")
         %playerCount++;
   }
   if(%playerCount == 0)
      return;

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(%cl.observerMode == "pickingTeam")   
         processMenuInitialPickTeam(%cl, -2); // throw these guys into observer
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         %cl.notready = "";
         %cl.notreadyCount = "";
         bottomprint(%cl, "", 0);
      }
   }
   Server::Countdown(30);
}

function Game::CheckTourneyMatchStart()
{
   if($CountdownStarted || $matchStarted)
      return;
   
   // loop through all the clients and see if any are still notready
   %playerCount = 0;
   %notReadyCount = 0;

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(%cl.observerMode == "pickingTeam")
      {
         %notReady[%notReadyCount] = %cl;
         %notReadyCount++;
      }   
      else if(%cl.observerMode == "pregame")
      {
         if(%cl.notready)
         {
            %notReady[%notReadyCount] = %cl;
            %notReadyCount++;
         }
         else
            %playerCount++;
      }
   }
   if(%notReadyCount)
   {
      if(%notReadyCount == 1)
         MessageAll(0, Client::getName(%notReady[0]) @ " is holding things up!");
      else if(%notReadyCount < 4)
      {
         for(%i = 0; %i < %notReadyCount - 2; %i++)
            %str = Client::getName(%notReady[%i]) @ ", " @ %str;

         %str = %str @ Client::getName(%notReady[%i]) @ " and " @ Client::getName(%notReady[%i+1]) 
                     @ " are holding things up!";
         MessageAll(0, %str);
      }
      return;
   }

   if(%playerCount != 0)
   {
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         %cl.notready = "";
         %cl.notreadyCount = "";
         bottomprint(%cl, "", 0);
      }
      Server::Countdown(30);
   }
}

function Game::checkTimeLimit()
{
   // if no timeLimit set or timeLimit set to 0,
   // just reschedule the check for a minute hence
   $timeLimitReached = false;

   if(!$Server::timeLimit)
   {
      schedule("Game::checkTimeLimit();", 60);
      return;
   }
   %curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
   if(%curTimeLeft <= 0 && $matchStarted)
   {

	//----------------------------------------------
		
		zs::CheckSurvZombTimes();
		zs::Ranks();

	//----------------------------------------------

      	echo("GAME: Timelimit reached.");
      	$timeLimitReached = true;
      	Server::nextMission();
   }
   else
   {

	//----------------------------------------------------------------------
	
	$zs::checktime = 1;
	zs::regencheck();
	zs::inflictioncheck();
	
	zs::AfkList();

	//----------------------------------------------------------------------

      	schedule("Game::checkTimeLimit();", 20);
	echo("TIME LEFT" @ %curtimeleft);
      	UpdateClientTimes(%curTimeLeft);
   }
}

function Game::resetScores(%client)
{
	if(%client == "") {
	   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
	      %cl.scoreKills = 0;
   	   %cl.scoreDeaths = 0;
			%cl.ratio = 0;
      	%cl.score = 0;
		}
	}
	else {
      %client.scoreKills = 0;
  	   %client.scoreDeaths = 0;
		%client.ratio = 0;
     	%client.score = 0;
	}
}

function remoteSetArmor(%player, %armorType)
{
	if ($ServerCheats) {
		checkMax(Player::getClient(%player),%armorType);
	   Player::setArmor(%player, %armorType);
	}
	else if($TestCheats) {
	   Player::setArmor(%player, %armorType);
	}
}

//function Game::onPlayerConnected(%playerId)
//{
//   %playerId.scoreKills = 0;
//   %playerId.scoreDeaths = 0;
//	%playerId.score = 0;
//   %playerId.justConnected = true;
//   $menuMode[%playerId] = "None";
//   Game::refreshClientScore(%playerId);
//}

function Game::assignClientTeam(%playerId)
{
   if($teamplay)
   {
      %name = Client::getName(%playerId);
      %numTeams = getNumTeams();
      if($teamPreset[%name] != "")
      {
         if($teamPreset[%name] < %numTeams)
         {
            GameBase::setTeam(%playerId, $teamPreset[%name]);
            echo(Client::getName(%playerId), " was preset to team ", $teamPreset[%name]);
            return;
         }            
      }
      %numPlayers = getNumClients();
      for(%i = 0; %i < %numTeams; %i = %i + 1)
         %numTeamPlayers[%i] = 0;

      for(%i = 0; %i < %numPlayers; %i = %i + 1)
      {
         %pl = getClientByIndex(%i);
         if(%pl != %playerId)
         {
            %team = Client::getTeam(%pl);
            %numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
         }
      }
      %leastPlayers = %numTeamPlayers[0];
      %leastTeam = 0;
      for(%i = 1; %i < %numTeams; %i = %i + 1)
      {
         if( (%numTeamPlayers[%i] < %leastPlayers) || 
            ( (%numTeamPlayers[%i] == %leastPlayers) && 
            ($teamScore[%i] < $teamScore[%leastTeam] ) ))
         {
            %leastTeam = %i;
            %leastPlayers = %numTeamPlayers;
         }
      }
      GameBase::setTeam(%playerId, %leastTeam);
      echo(Client::getName(%playerId), " was automatically assigned to team ", %leastTeam);
   }
   else
   {
      GameBase::setTeam(%playerId, 0);
   }
}

function Client::onKilled(%playerId, %killerId, %damageType)
{
   echo("GAME: kill " @ %killerId @ " " @ %playerId @ " " @ %damageType);

   %playerId.guiLock = true;
   Client::setGuiMode(%playerId, $GuiModePlay);
	if(!String::ICompare(Client::getGender(%playerId), "Male"))
   {
      %playerGender = "his";
   }
	else
	{
		%playerGender = "her";
	}
	%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
	%victimName = Client::getName(%playerId);


   if(!%killerId)
   {
	%spname = Client::GetName(%playerId);
	if ($zs::lastdamage[%spname] == "") {
      		messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
	}
      %playerId.scoreDeaths++;
  }
   else if(%killerId == %playerId)
   {
	  %oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
      messageAll(0, %oopsMsg, $DeathMessageMask);
      %playerId.scoreDeaths++;
      %playerId.score--;
      Game::refreshClientScore(%playerId);
   }
   else
   {
		if(!String::ICompare(Client::getGender(%killerId), "Male"))
		{
			%killerGender = "his";
		}
		else
		{
			%killerGender = "her";
		}
      if($teamplay && (Client::getTeam(%killerId) == Client::getTeam(%playerId)))
      {
		if(%damageType != $MineDamageType) 
	    	messageAll(0, strcat(Client::getName(%killerId), 
   	        " mows down ", %killerGender, " teammate, ", %victimName), $DeathMessageMask);
		else 
	         messageAll(0, strcat(Client::getName(%killerId), 
   	     	" killed ", %killerGender, " teammate, ", %victimName ," with a mine."), $DeathMessageMask);
		 %killerId.scoreDeaths++;
       %killerId.score--;
       Game::refreshClientScore(%killerId);
      }
      else
      {
	     %obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId),
	       %victimName, %killerGender, %playerGender);
         messageAll(0, %obitMsg, $DeathMessageMask);
         %killerId.scoreKills++;
         %playerId.scoreDeaths++;  // test play mode
         %killerId.score++;
         Game::refreshClientScore(%killerId);
         Game::refreshClientScore(%playerId);
      }
   }
	
	//--------------------------------------------------------------------------------------------
	//	ZS KILL TRACKER
	//

  	//echo("CLIENT KILLED**************");
	%pteam = Client::GetTeam(%playerId);
	%kteam = Client::GetTeam(%killerId);
	%pname = Client::GetName(%playerId);
	%kname = Client::GetName(%killerId);

	$zs::poison[%pname]++;
	
	%parmor = Player::GetArmor(%playerId);
	if (%parmor == "armorCzombie") {
		// do nothing	
	}
	
	
	if (%kteam == 0) {
		if (%playerId != %killerId) {
			$zs::killedzombies[%kname]++;
			$zsstats::killedz[%kname]++;
			zs::checkGunUp(%killerId);
		}
		else {
			if ($zs::lastdamage[%pname] != "" && $zs::lastdamage[%pname] != %pname) {
				%lastdamage = $zs::lastdamage[%pname];
				$zs::killedhumans[%lastdamage]++;
				$zsstats::killedh[%lastdamage]++;
				MessageAll(2,%lastdamage @ " [Killed] " @ %pname);
			}
		}
	}
	if (%kteam == 1) {
		if (%playerId != %killerId) {
			$zs::killedhumans[%kname]++;
			$zsstats::killedh[%kname]++;
			zs::checkRevive(%killerId);
		}
		else {
			if ($zs::lastdamage[%pname] != "" && $zs::lastdamage[%pname] != %pname) {
				%lastdamage = $zs::lastdamage[%pname];
				$zs::killedzombies[%lastdamage]++;
				$zstats::killedz[%lastdamage]++;
				MessageAll(2,%lastdamage @ " [Killed] " @ %pname);
			}
		}
	}

	if (%pteam == 0) {
		GameBase::SetTeam(%playerId,1);
		player::setArmor(%playerId,armorZombie);
		player::setItemCount(%playerId,classZombie,1);
		Client::setSkin(%playerId,zombie);
		zs::defaultPlayerNoLock(%playerId);
		MessageAll(1,%pname @ " has died and joined the zombies!");
		%survivetime = getSimTime() - $zsstats::starttime[%pname];
		$zsstats::survive[%pname] = $zsstats::survive[%pname] + %survivetime;
		$zsstats::startundead[%pname] = getSimTime();
		$zs::newzombie[%pname] = 1;
		$zsstats::onteam[%pname] = 1;
		
		// CHECK FOR LAST/NO HUMAN/ZOMBIE
		
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
				MessageAll(0,"Humans won the game!");
				zs::CheckSurvZombTimes();
				zs::Ranks();
				ObjectiveMission::missionComplete();
			}
			else {
				if (%humans == 1) {
					MessageAll(0,"Kill the last human!");
					$zs::lasthuman = 1;
				}
			}
		}

		else if (%humans == 0) {
			$zsendtime = getSimTime();
			MessageAll(0,"Zombies won the game!");
			zs::CheckSurvZombTimes();
			zs::Ranks();
			$zombieswon = 1;
			ObjectiveMission::missionComplete();
		}
		
		//if (%zombies == 0) {
		//	zs::CheckForZombie();
		//}
	}

	Game::refreshClientScore(%killerId);

	//--------------------------------------------------------------------------------------------

   Game::clientKilled(%playerId, %killerId);
}

function Game::clientKilled(%playerId, %killerId)
{
	// do nothing
}

//function Client::leaveGame(%clientId)
//{
//   // do nothing
//}

function Player::enterMissionArea(%player)
{
	echo("Player " @ %player @ " entered the mission area.");
}

function Player::leaveMissionArea(%player)
{
	echo("Player " @ %player @ " left the mission area.");
	//%cl = player::GetClient(%player);
	//zs::outAreaKill(%cl)
}

function GameBase::getHeatFactor(%this)
{
   return 0.0;
}

