-- HELP.LUA
-- This is the help data file
-- Revised: 2009.10.06
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


systemLog("=================== REALMMUD SETUP - HELP ===================");

newHelp = createHelp(1, "Main");
help.this = newHelp;
help.this.Data = "This is the default help file. Welcome to " .. getGameTitle() .. ".\r\n" ..
	"Available Entries:\r\n  ##$Commands$##\r\n";

newHelp = createHelp(2, "Commands");
help.this = newHelp;
help.this.Keyword = "commands";
help.this.Data = "List of available commands:\r\n" ..
	"  quit look say shout whisper who sit stand emote equipment inventory\r\n" ..
	" take drop equip unequip greet save appraise buy sell time help gather\r\n" ..
	" create score drink fill put";


-- EOF