-- File:    Who.lua
-- Purpose: Display a list of online players
-- Created: 02/01/07
-- By:      Gwareth
f = loadfile(getDataPath() .. "\\modules\\module_base.lua")();


local str = padString("", "=", 20, false) .. ' ONLINE PLAYER LIST ' .. padString("", "=", 20, false) .. '\n\r';

local user = getCurrentUser();
if user == nil then
	errorLog('Who.lua:main -> getCurrentUser returned a nil value');
	return
end

local count = getOnlinePlayerCount();
if count == nil then 
	errorLog('Who.lua:main -> getOnlinePlayerCount returned nil');
	return
end
	
local iHidden = 0 

if count > 0 then
	local players = {};
	players = getOnlinePlayerList(players);
	
	if (players == nil) then
		errorLog('Who.lua -> players table is nil');
		return
	end
	
	local hiddenCount = 0;
	
	
	for key, value in pairs(players) do		
	-- key is the userID
	-- value is the user object
		local state = user:getUserState();
		
		if (not(state == LOGGED_IN) and not(state == SHOPPING) and not(state == SHOPPING_PLAYER)) then
			hiddenCount = hiddenCount + 1;
			
		else	
			local name = user:getName();
			local title = user:getProperty("Title");
			local note = user:getNote();

			if (title == nil) then
				title = '';
			end
			name = name .. title;

			if user:hasFlag('F') == true then
				str = str .. '\n\r [AFK] ' .. padString(name, " ", 30, false) .. ' | ' .. note;
			elseif user:hasFlag('A') == true then
				str = str .. '\n\r [ADM] ' .. padString(name, " ", 30, false) .. ' | ' .. note;
			elseif user:hasFlag('W') == true then
				str = str .. '\n\r [WIZ] ' .. padString(name, " ", 30, false) .. ' | ' .. note;
			else
				str = str .. '\n\r       ' .. padString(name, " ", 30, false) .. ' | ' .. note;
			end
		end
	end
	
	count = count - hiddenCount;
end

str = str .. '\n\r\n\r' .. padString("", "=", 60, false);

if count == 1 then
	str = str .. '\n\rThere is 1 character online.';
elseif count == 0 then
	str = str .. '\n\rThere are no characters online.';
else
	str = str .. '\n\rThere are ' .. count .. ' characters online.';
end
	
printString(CHAR, str, user, nil, nil, nil, nil);

-- EOF
