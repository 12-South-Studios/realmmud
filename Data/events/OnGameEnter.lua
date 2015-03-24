-- ONGAMEENTER.LUA
-- Initial character login actions
-- Revised: 2012.02.06
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


local str = "Welcome to "
	str = str .. "\r\n"
	str = str .. getGameTitle();
	str = str .. "!\r\n\r\n"
	str = str .. "2012.02.06 :: Welcome to the game!  Enjoy your stay!\r\n"
	str = str .. "--------------------------------------------------------------------------\r\n"
	
local user = getLastEnteredGame();
if user == nil then 
	errorLog("OnGameEnter.lua -> getProperty(last entered game) returned nil");
	return
end

printString(CHAR, str, user, nil, nil, nil, nil);
	 
throwZoneEnter(user:getMyZone(), user);

executeCommand(user, "look");
printString(Space_LIMITED, "#login_other#", user, nil, nil, nil, nil);

-- EOF
