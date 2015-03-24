-- MODULE_ABILITIES.LUA
-- This is the Abilities Module for the MUD
-- Revised: 2012.02.20
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();

function setAbilityProperties(ability, manaCost, staminaCost)
	setProperty(ability, "mana cost", manaCost);
	setProperty(ability, "stamina cost", staminaCost);
end

function setOffensiveSkill(ability, skill)
	setProperty(ability, "offensive_skill", skill);
end

function setDefensiveStat(ability, stat)
	setProperty(ability, "defensive_stat", stat);
end

function setTiming(ability, predelay, postdelay)
	setProperty(ability, "predelay", predelay);
	setProperty(ability, "postdelay", postdelay);
end


-- EOF
