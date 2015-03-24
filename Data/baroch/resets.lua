-- BAROCH/RESETS.LUA
-- This is the resets-file for Baroch
-- Revised: 2012.04.02
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(2);
if (zone.this == nil) then
	errorLog("baroch\\resets.lua was unable to retrieve a zone object");
	return
end

systemLog("=================== ZONE 'BAROCH' - RESETS ===================");

-- ITEMS
createReset(zone.this, ResetType.Item, "HugeTorch", 704, ResetLocationType.Space, 20022, 1, 1);
createReset(zone.this, ResetType.Item, "HugeTorch", 704, ResetLocationType.Space, 20023, 1, 1);
createReset(zone.this, ResetType.Item, "HugeTorch", 704, ResetLocationType.Space, 20024, 1, 1);
createReset(zone.this, ResetType.Item, "HugeTorch", 704, ResetLocationType.Space, 20025, 1, 1);
createReset(zone.this, ResetType.Item, "HugeTorch", 704, ResetLocationType.Space, 20026, 1, 1);
createReset(zone.this, ResetType.Item, "TableSaw", 2934, ResetLocationType.Space, 20026, 1, 1);

-- MOBS
createReset(zone.this, ResetType.Mob, "Village Gate Guards", 21500, ResetLocationType.Space, 20022, 2, 2);
createReset(zone.this, ResetType.Mob, "Village Gate Mastiffs", 21501, ResetLocationType.Space, 20022, 1, 1);
createReset(zone.this, ResetType.Mob, "Blacksmith", 21502, ResetLocationType.Space, 20026, 1, 1);
createReset(zone.this, ResetType.Mob, "Blacksmith Guards", 21500, ResetLocationType.Space, 20026, 1, 1);
createReset(zone.this, ResetType.Mob, "Village Barracks Captain", 21503, ResetLocationType.Space, 20028, 1, 1);
createReset(zone.this, ResetType.Mob, "Village Barracks Guards", 21500, ResetLocationType.Space, 20028, 4, 2);
createReset(zone.this, ResetType.Mob, "Forest Skeletons", 21520, ResetLocationType.Access, 1, 4, 2);
createReset(zone.this, ResetType.Mob, "Forest Bears", 21521, ResetLocationType.Access, 1, 1, 1);

-- EOF
