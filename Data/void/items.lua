-- VOID/ITEMS.LUA
-- This is the items-file for The Void
-- Revised: 2009.09.25
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_items.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(1);
if (zone.this == nil) then
	errorLog("void\/items.lua was unable to retrieve a zone object");
	return
end

systemLog("=================== ZONE 'VOID' - ITEMS ===================");

--================ ITEMS ==================
--=========================================
-- ID Range: 100 to 199
newItem = createItem(100, "corpse", "corpse");	-- Was 101
item.this = newItem;
setLongName(item.this, "a corpse lies here.");
setDescription(item.this, "The corpse is not in good shape");
setItemProperties(item.this, ObjectSize.Medium, 1, 0, "bone", 300);
item.this:AddWearLocation("wear_hand_both");
zone.this.Contents:AddEntity(item.this);

newItem = createItem(101, "Wooden Key", "Key");	-- Was 116
item.this = newItem;
setLongName(item.this, "a tiny wooden key is here.");
setDescription(item.this, "this intricate key was carved out of a single piece of wood. It is probably used to open a small lock.");
setItemProperties(item.this, ObjectSize.Tiny, 99, 0, "thin wood", 5);
setItemBits(item.this, true, true, false, false);
zone.this.Contents:AddEntity(item.this);

-- ID Range: 200 to 299
if (doScript("void\\items_armor.lua") == false) then
	errorLog("Unable to load items_armor.lua for void zone");
end

-- ID Range: 300 to 399
if (doScript("void\\items_clothing.lua") == false) then
	errorLog("Unable to load items_clothing.lua for void zone");
end

-- ID Range: 400 to 499
if (doScript("void\\items_container.lua") == false) then
	errorLog("Unable to load items_container.lua for void zone");
end

-- ID Range: 600 to 699
if (doScript("void\\items_food.lua") == false) then
	errorLog("Unable to load items_food.lua for void zone");
end

-- ID Range: 700 to 799
if (doScript("void\\items_light.lua") == false) then
	errorLog("Unable to load items_light.lua for void zone");
end

-- ID Range: 800 to 899
if (doScript("void\\items_shields.lua") == false) then
	errorLog("Unable to load items_shields.lua for void zone");
end

-- ID Range: 900 to 999
if (doScript("void\\items_weapon.lua") == false) then
	errorLog("Unable to load items_weapon.lua for void zone");
end

-- Special Case: Crafting
-- ID Range: 2000 to 2999
if (doScript("void\\items_crafting.lua") == false) then
	errorLog("Unable to load items_crafting.lua for void zone");
end

-- EOF