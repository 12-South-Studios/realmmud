-- MODULE_MOBS.LUA
-- This is the Mobs Module for the MUD
-- Revised: 2012.02.19
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();

function setMobProperties(mob, size, class)
	setProperty(mob, "size", size);
	setProperty(mob, "monster_class", class);
end

function setValue(mob, value)
	setProperty(mob, "value", value);
end

function setRace(mob, race)
	setProperty(mob, "race", race);
end

function setAccess(mob, value)
	setProperty(mob, "access", value);
end

-- EOF
