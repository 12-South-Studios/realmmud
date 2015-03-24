-- VOID/ITEMS_WEAPON.LUA
-- This is the items-subfile for The Void
-- Revised: 2012.01.31
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_items.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(1);
if (zone.this == nil) then
	errorLog("void\/Items_weapon.lua was unable to retrieve a zone object");
	return
end

systemLog("=================== ZONE 'VOID' - ITEMS/WEAPON ===================");
-- ID RAnge: 900 to 999
newItem = createItem(900, "short spear", "Weapon");	-- was 113
item.this = newItem;
setLongName(item.this, "a short spear that has been battered from frequent use is here.");
setDescription(item.this, "this spear has a short wooden shaft and a long sharpened, though slightly rusty blade.");
setItemProperties(item.this, ObjectSize.Medium, 99, 600, "thick wood", 250);
setWeaponBits(item.this);
item.this:AddWearLocation("wear_hand_right");
setWeaponProperties(item.this, "pierce", 1, 6);
zone.this.Contents:AddEntity(item.this);

-- EOF
