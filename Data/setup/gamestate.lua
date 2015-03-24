-- GAMESTATE.LUA
-- This is the gamestate data file
-- Revised: 10/30/2009
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")()


systemLog("=================== REALMMUD SETUP - GAME STATE ===================");


createGameState(6051, 01, 01, 12, 0, "daylight");


-- EOF
