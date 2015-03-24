-- VOID/ITEMS_CLOTHING.LUA
-- This is the items-subfile for The Void
-- Revised: 2012.01.31
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_items.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(1);
if (zone.this == nil) then
	errorLog("void\/Items_clothing.lua was unable to retrieve a zone object");
	return
end

systemLog("=================== ZONE 'VOID' - ITEMS/CLOTHING ===================");
-- ID Range: 300 to 399
newItem = createItem(300, "Apron", "Armor");
item.this = newItem;
setLongName(item.this, "a plain white apron lies here.");
setDescription(item.this, "a simple cotton, off-white apron with two tie-strings.");
setItemProperties(item.this, ObjectSize.Small, 99, 1, "cloth", 50);
item.this:AddWearLocation("wear_chest");
setClothingBits(item.this);
--item.this:setCondition(ConditionType.Pristine);
--item.this:setArmorClass(ARMOR_CLASS_LIGHT);
--item.this:setArmorType(ARMOR_TYPE_CLOTH);
zone.this.Contents:AddEntity(item.this);

newItem = createItem(301, "Leather Belt", "Armor");
item.this = newItem;
setLongName(item.this, "a plain leather belt is lying here.");
setDescription(item.this, "a plain leather belt with a small metal buckle");
setItemProperties(item.this, ObjectSize.Small, 99, 300, "leather", 30);
item.this:AddWearLocation("wear_waist");
setClothingBits(item.this);
--item.this:setCondition(ConditionType.Pristine);
--item.this:setArmorClass(ARMOR_CLASS_LIGHT);
--item.this:setArmorType(ARMOR_TYPE_LEATHER);
zone.this.Contents:AddEntity(item.this);


-- EOF
