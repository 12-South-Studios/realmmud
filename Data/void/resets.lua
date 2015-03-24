-- VOID/RESETS.LUA
-- This is the resets-file for The Void
-- Revised: 2012.02.18
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(1);
if (zone.this == nil) then
	errorLog("void\\resets.lua was unable to retrieve a zone object");
	return
end

systemLog("=================== ZONE 'VOID' - RESETS ===================");

-- ITEMS
createReset(zone.this, ResetType.Item, "Lamppost", 705, ResetLocationType.Space, 11, 1, 1);
createReset(zone.this, ResetType.Item, "Fountain", 400, ResetLocationType.Space, 11, 1, 1);
createReset(zone.this, ResetType.Item, "Waterskin", 402, ResetLocationType.Space, 11, 1, 1);

newReset = createReset(zone.this, ResetType.Container, "Backpack", 403, ResetLocationType.Space, 11, 1, 1);
reset.this = newReset;
reset.this:AddItem(200, 1);
reset.this.Closed = true;

createReset(zone.this, ResetType.Item, "Oak Tree", 2800, ResetLocationType.Space, 11, 1, 1);
createReset(zone.this, ResetType.Item, "Oak Leaf", 2001, ResetLocationType.Space, 11, 10, 2);

-- MOBS
createReset(zone.this, ResetType.Mob, "Gran", 1005, ResetLocationType.Space, 11, 1, 1);
createReset(zone.this, ResetType.Mob, "Deer", 1002, ResetLocationType.Space, 11, 1, 1);
 

-- EFFECTS
createReset(zone.this, ResetType.Effect, "Snow", 4009, ResetLocationType.Space, 12, 1, 1);

-- EOF
