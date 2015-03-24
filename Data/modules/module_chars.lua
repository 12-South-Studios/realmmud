-- MODULE_CHARS.LUA
-- This is the Characterss Module for the MUD
-- Revised: 2012.02.21
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();

function setCurrentHealth(char, cur_hp)
	setProperty(char, "current_health", cur_hp);
end

function setValue(char, value)
	setProperty(char, "value", value);
end

function getUsername(user)
	return getProperty(user, "name");
end

-- EOF
