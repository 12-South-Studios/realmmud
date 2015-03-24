-- File:    ChangePassword.lua
-- Purpose: Handles a change password request
-- Created: 02/01/07
-- By:      Gwareth
f = loadfile(getDataPath() .. "modules/module_base.lua")();


local user = getCurrentUser();
	
-- Get the full command string
local str = getProperty(user, "raw command");
if (str == nil) then
	errorLog("ChangePassword.lua:main -> getProperty('raw command') returned a nil value", nil, nil, nil, nil);
	return;
end;

-- Get the existing password
local currentPass = parseWord(str, 1, WHITESPACE);
if (currentPass == nil) then
	errorLog("ChangePassword.lua:main -> parseWord(str, 1, WHITESPACE) returned a nil value", nil, nil, nil, nil);
	return;
end;

-- Get the new password
local newPass = parseWord(str, 2, WHITESPACE);
if (newPass == nil) then
	printString(CHAR, "#no_password#", user, nil, nil, nil, nil);
	return;
end;

if (string.len(newPass) < getGameProperty("password_min_len") then
	printString(CHAR, "#password_short#", user, nil, nil, nil, nil);
	return;	
end;

if (string.len(newPass) > getGameProperty("password_max_len") then
	printString(CHAR, "#password_long#", user, nil, nil, nil, nil);
	return;
end	
	
if (changePassword(user, currentPass, newPass) == false) then
	printString(CHAR, "#password_fail#", user, nil, nil, nil, nil);
	return;
end;

printString(CHAR, "#password_success#", user, nil, nil, nil, nil);
-- EOF
