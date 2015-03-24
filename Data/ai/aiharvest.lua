-- File:    aiharvest.lua
-- Purpose: Handles the Harvestable AI for Mobs
-- Created: 2012.02.13
-- By:      Gwareth
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


function main(eventArgs)
	registerAIEvent(3, SPAWN, "onSpawn");
end

function onSpawn(eventArgs)
	systemLog("AIHarvest: This is a test");
end


-- EOF
