-- File:    aiguard.lua
-- Purpose: Handles the Guard AI for Mobs
-- Created: 2012.02.13
-- By:      Gwareth
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


function main(eventArgs)
	registerAIEvent(5, SPAWN, "onSpawn");
end

function onSpawn(eventArgs)
	systemLog("AIGuard: This is a test");
end


-- EOF
