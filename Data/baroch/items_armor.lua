-- BAROCH/ITEMS_ARMOR.LUA
-- This is the items-subfile for the Vale of Baroch
-- Revised: 2012.01.31
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(2);
if (zone.this == nil) then
	errorLog("baroch\/Items_armor.lua was unable to retrieve a zone object");
	return
end

systemLog("=================== ZONE 'BAROCH' - ITEMS/ARMOR ===================");
newItem = createItem(21301, "Battered Chain Mail Hauberk", "Armor");
item.this = newItem;
setLongName(item.this, "a hauberk of battered chain mail lies here.");
setDescription(item.this, "a hauberk of chain mail that has seen better days, many of the links are broken and others show signs of recent repair. it is designed to protect chest and torso and is especially good against slashing attacks.");
setItemProperties(item.this, ObjectSize.Medium, 1, 25000, "hard metal", 100);
item.this:AddWearLocation("wear_chest");
setArmorBits(item.this);
--item.this:setACValue(30);
zone.this.Contents:AddEntity(item.this);


-- EOF