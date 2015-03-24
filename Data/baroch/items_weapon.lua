-- BAROCH/ITEMS_WEAPON.LUA
-- This is the items-subfile for the Vale of Baroch
-- Revised: 2012.01.31
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_items.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(2);
if (zone.this == nil) then
	errorLog("baroch\\items_weapon.lua was unable to retrieve a zone object");
	return
end

systemLog("=================== ZONE 'BAROCH' - ITEMS/WEAPON ===================");
newItem = createItem(21305, "engraved longsword", "weapon");
item.this = newItem;
setLongName(item.this, "an engraved longsword lies here.");
setDescription(item.this, "A beautifully crafted longsword engraved with silver runes.");
setItemProperties(item.this, ObjectSize.Medium, 99, 40000, "hard metal", 200);
item.this:AddWearLocation("wear_hand_right");
setWeaponProperties(item.this, "slash", 2, 8);
setWeaponBits(item.this);
zone.this.Contents:AddEntity(item.this);


-- EOF