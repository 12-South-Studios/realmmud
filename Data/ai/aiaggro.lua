-- File:    aiaggro.lua
-- Purpose: Handles the Aggressive AI for Mobs
-- Created: 2012.02.13
-- By:      Gwareth
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


function main(eventArgs)
	registerAIEvent(4, SPAWN, "onSpawn");
end

function onSpawn(eventArgs)
	systemLog("AIAggro: This is a test");
end


-- EOF
