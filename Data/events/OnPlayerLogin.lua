-- ONPLAYERLOGIN.LUA
-- Character menu screen when a player is logged in
-- Revised: 2012.03.20
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


user = getLastConnected();
if user == nil then 
     errorLog('OnPlayerLogin.lua -> getlastConnected returned nil');
     return
end

local str = " ACCOUNT / CHARACTER MENU\r\n" .. 
	"*=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=*\r\n";

-- Character List
--  "| Name    | Level # Race Gender Archetype | LastLogin\r\n" ..
characters = {}
characters = getCharacters(characters, user);
if (characters == nil) then
	errorLog('OnPlayerLogin.lua -> characters table is nil')
	return
end
	
for key, value in pairs(characters) do
	local char = {}
	char = value;

	paddedCharName = padStringToRight(char["character_name"], " ", GetAppSetting("maximumCharacterNameLength"));

	descriptor = " Level " .. char["level"] .. " " .. char["race"] .. " " .. char["gender"] .. " " .. char["archetype"];
	paddedClass = padStringToRight(descriptor, " ", 40);

	paddedLogin = padStringToRight(char["last_login"], " ", 10);

	str = str .. "| " .. paddedCharName .. " | " .. paddedClass .. " | " .. paddedLogin .. "|\r\n";
end

str = str .. "*=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=*\r\n" ..
    " Use " .. MxpTag("MenuCmd1") .. "CREATECHAR (Name)" .. MxpTag("/MenuCmd1") .. " to create a new character.\r\n" ..
    " Use " .. MxpTag("MenuCmd1") .. "SELECTCHAR (Name)" .. MxpTag("/MenuCmd1") .. " to login an existing character.\r\n" ..
    " Use " .. MxpTag("MenuCmd1") .. "DELETECHAR (Name)" .. MxpTag("/MenuCmd1") .. " to delete a character.\r\n" ..
    " Use " .. MxpTag("MenuCmd3") .. MxpTag("send") .. "QUIT" .. MxpTag("/send") .. MxpTag("/MenuCmd3") .. " to logout.\r\n" ..
    "*---------------------------------------------------------------------------*\r\n"

printString(MessageScope.Character, str, user, nil, nil, nil, nil);

-- EOF