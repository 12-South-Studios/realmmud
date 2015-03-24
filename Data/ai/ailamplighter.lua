-- File:    ailamplighter.lua
-- Purpose: Handles the Lamplighter AI for Mobs
-- Created: 2012.02.13
-- By:      Gwareth
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


function main(eventArgs)
	registerAIEvent(6, SPAWN, "onSpawn");
end

function onSpawn(eventArgs)
	systemLog("AILampLighter: This is a test");
end


-- EOF
