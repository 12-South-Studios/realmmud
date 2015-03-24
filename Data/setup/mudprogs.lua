-- MUDPROGS.LUA
-- This is the mudprogs data file
-- Revised: 2012.10.19
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


systemLog("=================== REALMMUD SETUP - MUDPROGS ===================");
createMudProg(0, "testprog", "\\mudprogs\\testprog.lua");


-- EOF