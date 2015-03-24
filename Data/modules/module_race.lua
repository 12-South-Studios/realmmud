-- MODULE_RACE.LUA
-- This is the Race Module for the MUD
-- Revised: 2012.03.02
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();

function setRaceDetails(race, is_player, base_health, base_mana, base_stamina)
	setProperty(race, "player_race", is_player);
	setProperty(race, "base_health", base_health);
	setProperty(race, "base_mana", base_mana);
	setProperty(race, "base_stamina", base_stamina);
end

-- EOF
