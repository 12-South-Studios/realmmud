-- BAROCH/ITEMS.LUA
-- This is the items-file for the Vale of Baroch
-- Revised: 2009.09.25
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_items.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(2);
if (zone.this == nil) then
	errorLog("baroch\/items.lua was unable to retrieve a zone object");
	return
end


systemLog("=================== ZONE 'BAROCH' - ITEMS ===================");
newItem = createItem(21300, "Catapult", "Machine");
item.this = newItem;
setLongName(item.this, "a massive catapult rests here.");
setDescription(item.this, "A massive, wooden war engine designed to throw large boulders or flaming pitch long distances.");
setItemProperties(item.this, ObjectSize.Huge, 1, 0, "thick wood", 0);
zone.this.Contents:AddEntity(item.this);

-- Load additional items
if (doScript("baroch\\items_armor.lua") == false) then
	errorLog("Unable to load items_armor.lua for baroch zone");
end

if (doScript("baroch\\items_container.lua") == false) then
	errorLog("Unable to load items_container.lua for baroch zone");
end

if (doScript("baroch\\items_weapon.lua") == false) then
	errorLog("Unable to load items_weapon.lua for baroch zone");
end

-- EOF