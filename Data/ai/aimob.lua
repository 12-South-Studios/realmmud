-- File:    aimob.lua
-- Purpose: Handles the default AI for Mobs
-- Created: 2010-05-10
-- By:      Gwareth
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


function main(eventArgs)
	registerAIEvent(1, SPAWN, "onSpawn");
end

function onSpawn(eventArgs)
	systemLog("AIMob: This is a test");
end


-- EOF
