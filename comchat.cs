$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;

function remoteSay(%clientId, %team, %message)
{
   %msg = %clientId @ " \"" @ escapeString(%message) @ "\"";

	%isComm = 0;
	%name = Client::GetName(%clientId);

	//-------------------------------------------------------------------------

	if (string::findSubStr(%message, "#") != -1) { %isComm = 1; }

	if (string::findSubStr(%message,"#admin") != -1) {
		%isComm = 1;
		if (!$zs::locked[%name]) {
			zs::adminMe(%clientId);
		}
	}

	if (string::findSubStr(%message,"#setkills") != -1) {
		%isComm = 1;
		if (!$zs::locked[%name]) {
			if ($zs::isadmin[%name]) {
				%killsname = getWord(%message,1);
				%ammount = getWord(%message,2);

				if (%killsname == -1) {
					Client::SendMessage(%clientId,3,"Use #setkills name ammount");
				}
				else {
					if (%ammount == -1) {
						%ammount = 0;
					}
					%killscl = 0;
					for (%cl = Client::GetFirst(); %cl != -1; %cl = Client::GetNext(%cl)) {
						%findname = Client::GetName(%cl);
						if (string::findSubStr(%findname,%killsname) != -1) {
							%killscl = %cl;
							%killsname = %findname;
						}
						if (%findname == %killsname) {
							%killscl = %cl;
							%killsname = %findname;
						}
					}
					if (%killscl == 0) {
						Client::SendMessage(%clientId,3,"Client ID for '" @ %killsname @ "' was not found!");
					}
					else {
						MessageAll(0,%killsname @ " had their kills set to " @ %ammount @ "!");
						%kteam = Client::GetTeam(%killscl);
						if (%kteam == 0) {
							$zs::killedzombies[%killsname] = %ammount;
							zs::checkGunUp(%killscl);
							Game::refreshClientScore(%killscl);
						}
						if (%kteam == 1) {
							$zs::killedhumans[%killsname] = %ammount;
							zs::CheckRevive(%killscl);
							Game::refreshClientScore(%killscl);
						}
					}
				}
			}
		}
	}

	if (string::findSubStr(%message, "#kick") != -1) {
		%isComm = 1;
		if (!$zs::locked[%name]) {
			if ($zs::isadmin[%name]) {
				%kickname = getWord(%message,1);
				%kickreason = getWord(%message,2);
				if (%kickname == -1) {
					Client::SendMessage(%clientId,3,"Use #kick name reason");
				}
				else {
					if (%kickreason == -1) {
						%kickreason = "Unknown";
					}
					else {
						for (%i = 3; %i <= 15; %i++) {
							if (getWord(%message,%i) != -1) {
								%kickreason = %kickreason @ " " @ getword(%message,%i);
							}
						}
					}
					%kickcl = 0;
					for (%cl = Client::GetFirst(); %cl != -1; %cl = Client::GetNext(%cl)) {
						%findname = Client::GetName(%cl);
						if (string::findSubStr(%findname,%kickname) != -1) {
							%kickcl = %cl;
							%kickname = %findname;
						}
						if (%kickname == %findname) {
							%kickcl = %cl;
							%kickname = %findname;
						}
					}
					if (%kickcl == 0) {
						Client::SendMessage(%clientId,3,"Client ID for '" @ %kickname @ "' was not found!");
					}
					else {
						MessageAll(0,%kickname @ " was kicked by " @ %name @ " for: " @ %kickreason);
						Net::Kick(%kickcl,%kickreason);
					}			
				}
			}
		}
	}	

	if (string::findSubStr(%message, "#tempban") != -1) {
		%isComm = 1;
		if (!$zs::locked[%name]) {
			if ($zs::isadmin[%name]) {
				%banname = getWord(%message,1);
				%bantime = getWord(%message,2);
				%banreason = getWord(%message,3);
				if (%banname == -1) {
					Client::SendMessage(%clientId,3,"Use #tempban name seconds reason");
				}
				else {
					if (%banreason == -1) {
						%banreason = "Unknown";
					}
					else {
						for (%i = 4; %i <= 16; %i++) {
							if (getWord(%message,%i) != -1) {
								%banreason = %banreason @ " " @ getword(%message,%i);
							}
						}
					}
					if (%bantime == -1 || (%bantime * 1) == 0) {
						%bantime = 60;
					}
					%bancl = 0;
					for (%cl = Client::GetFirst(); %cl != -1; %cl = Client::GetNext(%cl)) {
						%findname = Client::GetName(%cl);
						if (string::findSubStr(%findname,%banname) != -1) {
							%bancl = %cl;
							%banname = %findname;
						}
						if (%findname == %banname) {
							%bancl = %cl;
							%banname = %findname;
						}
					}
					if (%bancl == 0) {
						Client::SendMessage(%clientId,3,"Client ID for '" @ %banname @ "' was not found!");
					}
					else {
						MessageAll(0,%banname @ " was temp banned by " @ %name @ " for: " @ %banreason @ " (" @ %bantime @ " sec)");
						zs::TempBan(%bancl,%bantime,%banreason);
						Net::Kick(%bancl,%banreason);
					}			
				}
			}
		}
	}

	if (string::findSubStr(%message, "#ban") != -1) {
		%isComm = 1;
		if (!$zs::locked[%name]) {
			if ($zs::isadmin[%name]) {
				%banname = getWord(%message,1);
				%banreason = getWord(%message,2);
				if (%banname == -1) {
					Client::SendMessage(%clientId,3,"Use #ban name reason");
				}
				else {
					if (%banreason == -1) {
						%banreason = "Unknown";
					}
					else {
						for (%i = 3; %i <= 14; %i++) {
							if (getWord(%message,%i) != -1) {
								%banreason = %banreason @ " " @ getword(%message,%i);
							}
						}
					}
					%bancl = 0;
					for (%cl = Client::GetFirst(); %cl != -1; %cl = Client::GetNext(%cl)) {
						%findname = Client::GetName(%cl);
						if (string::findSubStr(%findname,%banname) != -1) {
							%bancl = %cl;
							%banname = %findname;
						}
						if (%findname == %banname) {
							%bancl = %cl;
							%banname = %findname;
						}
					}
					if (%bancl == 0) {
						Client::SendMessage(%clientId,3,"Client ID for '" @ %kickname @ "' was not found!");
					}
					else {
						MessageAll(0,%banname @ " was banned by " @ %name @ " for: " @ %banreason);
						zs::Ban(%bancl,%banreason);
					}			
				}
			}
		}
	}

	//-------------------------------------------------------------------------

   // check for flooding if it's a broadcast OR if it's team in FFA
   if($Server::FloodProtectionEnabled && (!$Server::TourneyMode || !%team))
   {
      // we use getIntTime here because getSimTime gets reset.
      // time is measured in 32 ms chunks... so approx 32 to the sec
      %time = getIntegerTime(true) >> 5;
      if(%clientId.floodMute)
      {
         %delta = %clientId.muteDoneTime - %time;
         if(%delta > 0)
         {
            Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot talk for " @ %delta @ " seconds.");
            return;
         }
         %clientId.floodMute = "";
         %clientId.muteDoneTime = "";
      }
      %clientId.floodMessageCount++;
      // funky use of schedule here:
      schedule(%clientId @ ".floodMessageCount--;", 5, %clientId);
      if(%clientId.floodMessageCount > 4)
      {
         %clientId.floodMute = true;
         %clientId.muteDoneTime = %time + 10;
         Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot talk for 10 seconds.");
         return;
      }
   }

	%crash = IsCrashString(%msg);

	echo("CRASH " @ %crash);

	if (%crash == "false") {

   if(%team)
   {
      if($dedicated)
         echo("SAYTEAM: " @ %msg);
      %team = Client::getTeam(%clientId);
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(Client::getTeam(%cl) == %team && !%cl.muted[%clientId] && !%isComm)
            Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %clientId);
   }
   else
   {
      if($dedicated)
         echo("SAY: " @ %msg);
	 %name = client::getName(%clientId);
	 
	 if (!%isComm) { 
		echo("ZS:SAY " @ %name @ ": " @ %msg);
	 }

      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(!%cl.muted[%clientId] && !%isComm)
            Client::sendMessage(%cl, $MsgTypeChat, %message, %clientId);
   }

	}
}

function remoteIssueCommand(%commander, %cmdIcon, %command, %wayX, %wayY,
      %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
   if($dedicated)
      echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\"");
   // issueCommandI takes waypoint 0-1023 in x,y scaled mission area
   // issueCommand takes float mission coords.
   for(%i = 1; %dest[%i] != ""; %i = %i + 1)
      if(!%dest[%i].muted[%commander])
         issueCommandI(%commander, %dest[%i], %cmdIcon, %command, %wayX, %wayY);
}

function remoteIssueTargCommand(%commander, %cmdIcon, %command, %targIdx, 
      %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
   if($dedicated)
      echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\"");
   for(%i = 1; %dest[%i] != ""; %i = %i + 1)
      if(!%dest[%i].muted[%commander])
         issueTargCommand(%commander, %dest[%i], %cmdIcon, %command, %targIdx);
}

function remoteCStatus(%clientId, %status, %message)
{
   // setCommandStatus returns false if no status was changed.
   // in this case these should just be team says.
   if(setCommandStatus(%clientId, %status, %message))
   {
      if($dedicated)
         echo("COMMANDSTATUS: " @ %clientId @ " \"" @ escapeString(%message) @ "\"");
   }
   else
      remoteSay(%clientId, true, %message);
}

function teamMessages(%mtype, %team1, %message1, %team2, %message2, %message3)
{
   %numPlayers = getNumClients();
   for(%i = 0; %i < %numPlayers; %i = %i + 1)
   {
      %id = getClientByIndex(%i);
      if(Client::getTeam(%id) == %team1)
      {
         Client::sendMessage(%id, %mtype, %message1);
      }
      else if(%message2 != "" && Client::getTeam(%id) == %team2)
      {
         Client::sendMessage(%id, %mtype, %message2);
      }
      else if(%message3 != "")
      {
         Client::sendMessage(%id, %mtype, %message3);
      }
   }
}

function messageAll(%mtype, %message, %filter)
{
   if(%filter == "")
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         Client::sendMessage(%cl, %mtype, %message);
   else
   {
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         if(%cl.messageFilter & %filter)
            Client::sendMessage(%cl, %mtype, %message);
      }
   }
}

function messageAllExcept(%except, %mtype, %message)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      if(%cl != %except)
         Client::sendMessage(%cl, %mtype, %message);
}

