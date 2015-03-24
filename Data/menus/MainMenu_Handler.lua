-- MAINMENU_HANDLER.LUA
-- Handles all client interaction on the main menu
-- Revised: 2009.09.24
-- Author: Jason Murdick
f = loadfile(getDataPath() .. "\\modules\\module_base.lua")();


local user = getCurrentUser();
if user == nil then
	errorLog("MainMenu_Handler.lua -> getCurrentUser returned a nil value");
	return
end
	
local str = user:getProperty("raw command");
if str == nil then
	errorLog("MainMenu_Handler.lua -> getProperty(raw command) returned a nil value");
	return
end
	
local verb = parseWord(str, 0, WHITESPACE);	
if verb == nil then
	errorLog("MainMenu_Handler.lua -> parseWord(verb) returned a nil value");
	return
end	

verb = toLower(verb);

if verb == "create" then
	doScript("actions\\CreateCharacter.lua");
		
elseif verb == "connect" then
	doScript("actions\\LoginCharacter.lua");
	
elseif verb == 'credits' then
	doScript("actions\\Credits.lua");
	
elseif verb == 'quit' then
	user:setUserState(QUITTING);
	executeCommand(user, "quit");
	
else
	printString(CHAR, "#invalid_menu#", user, nil, nil, nil, nil);
	
end

-- EOF
