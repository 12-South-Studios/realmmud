-- File:    aishop.lua
-- Purpose: Handles the Shopkeeper AI for Mobs
-- Created: 2012.02.13
-- By:      Gwareth
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


function main(eventArgs)
	registerAIEvent(2, SPAWN, "onSpawn");
end

function onSpawn(eventArgs)
	systemLog("AIShop: This is a test");
end


-- EOF
