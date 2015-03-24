-- LOGINCHARACTER.LUA
-- Handles the login verification
-- Revised: 2009.09.26
-- Author: Jason Murdick
f = loadfile(getDataPath() .. "\\modules\\module_base.lua")();


local user = getCurrentUser();
if user == nil then
	errorLog("LoginCharacter.lua: -> getCurrentUser returned a nil value");
	return
end

local str = user:getProperty("raw command");
if str == nil then
	errorLog('LoginCharacter.lua -> getProperty(raw command) returned a nil value');
	return
end
 
local verb = parseWord(str, 0, WHITESPACE);
if verb == nil then
	errorLog('LoginAccount.lua -> parseWord(verb) returned a nil value');
	return
end
			
local uname = parseWord(str, 1, WHITESPACE);
if uname == nil then
	uname=' ';
end
		
local pass = parseWord(str, 2, WHITESPACE);	
if pass == nil then
	pass=' ';
end
	
if (string.len(uname) > getGameProperty("username_max_len")) then
	printString(CHAR, '#username_long#', user, nil, nil, nil, nil);
	return
end

if (string.len(uname) < getGameProperty("username_min_len")) then
	printString(CHAR, "#username_short", user, nil, nil, nil, nil);
	return
end

if (checkPassword(uname, pass) == false) then
	printString(CHAR, "#invalid_login#", user, nil, nil, nil, nil);
	return
end

user:setProperty("lastlogin", dateStamp() .. ' ' .. timeStamp());
	
-- load character flags, properties, etc
if user:loadCharacter(uname) == false then
	errorLog("LoginCharacter.lua:LoadCharacter(" .. uname .. ") failed.");
	return
end
				
user:setUserState(LOGGED_IN);
setLastEnteredGame(user);

--newMessage = createMessage("MessageOnGameEnter");
--message.this = newMessage;
--message.this:Init(user, EVENT_GLOBAL);
throwGameEnter(user);

-- EOF
