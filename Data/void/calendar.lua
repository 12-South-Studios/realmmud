-- CALENDAR.LUA
-- This is the calendar data file
-- Revised: 2012.03.06
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(1);
if (zone.this == nil) then
	errorLog("void\/calendar.lua was unable to retrieve a zone object");
	return
end

systemLog("=================== ZONE 'VOID' - CALENDAR ===================");

newMonth = createMonth(1, "Kaorola", 20, "winter", false);
month.this = newMonth;
month.this:AddEffect(4005);

newMonth = createMonth(2, "Winter Shrouding", 3, "winter", true);
month.this = newMonth
month.this:AddEffect(4001);
month.this:AddEffect(4002);

newMonth = createMonth(3, "Zeresa", 20, "winter", false);
month.this = newMonth;
month.this:AddEffect(4005);

newMonth = createMonth(4, "Beja", 20, "winter", false);
month.this = newMonth;
month.this:AddEffect(4005);

newMonth = createMonth(5, "Kaora", 20, "winter", false);
month.this = newMonth;
month.this:AddEffect(4005);

newMonth = createMonth(6, "Emata", 20, "spring", false);
month.this = newMonth;
month.this:AddEffect(4006);

newMonth = createMonth(7, "Laisa", 20, "spring", false);
month.this = newMonth;
month.this:AddEffect(4006);

newMonth = createMonth(8, "Zeja", 20, "spring", false);
month.this = newMonth;
month.this:AddEffect(4006);

newMonth = createMonth(9, "Zevera", 20, "spring", false);
month.this = newMonth;
month.this:AddEffect(4006);

newMonth = createMonth(10, "Ogoena", 20, "summer", false);
month.this = newMonth;
month.this:AddEffect(4007);

newMonth = createMonth(11, "Vedova", 20, "summer", false);
month.this = newMonth;
month.this:AddEffect(4007);

newMonth = createMonth(12, "Summer Shrouding", 3, "summer", true);
month.this = newMonth
month.this:AddEffect(4003);
month.this:AddEffect(4004);

newMonth = createMonth(13, "Pala", 20, "summer", false);
month.this = newMonth;
month.this:AddEffect(4007);

newMonth = createMonth(14, "Zema", 20, "summer", false);
month.this = newMonth;
month.this:AddEffect(4007);

newMonth = createMonth(15, "Esola", 20, "summer", false);
month.this = newMonth;
month.this:AddEffect(4007);

newMonth = createMonth(16, "Danara", 20, "fall", false);
month.this = newMonth;
month.this:AddEffect(4008);

newMonth = createMonth(17, "Emuda", 20, "fall", false);
month.this = newMonth;
month.this:AddEffect(4008);

newMonth = createMonth(18, "Zeola", 20, "fall", false);
month.this = newMonth;
month.this:AddEffect(4008);

newMonth = createMonth(19, "Veola", 20, "fall", false);
month.this = newMonth;
month.this:AddEffect(4008);

newMonth = createMonth(20, "Veorota", 20, "winter", false);
month.this = newMonth;
month.this:AddEffect(4005);

--setGameProperty("start_year", 6051);
setGameProperty("bright_moon", "Annis");
setGameProperty("shadow_moon", "Uthoran");
setGameProperty("shrouding_fade_in", "#shadow_moon#, the Shadow Moon, passes in front of the Bright Moon and the #month# Begins!");
setGameProperty("shrouding_fade_out", "#bright_moon#, the Bright Moon, once again shines down upon the land as the #month# Ends!");
-- sunset
-- sunrise
-- sun at apex

if (doScript("setup\\gamestate.lua") == false) then
	errorLog("Unable to load gamestate.lua");
	return
end

-- EOF