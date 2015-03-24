-- VOID/ITEMS_SHIELDS.LUA
-- This is the items-subfile for The Void
-- Revised: 2012.01.31
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_items.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(1);
if (zone.this == nil) then
	errorLog("void\/Items_Shields.lua was unable to retrieve a zone object");
	return
end

systemLog("=================== ZONE 'VOID' - ITEMS/SHIELDS ===================");
newItem = createItem(800, "Body Shield", "Armor");
item.this = newItem;
setLongName(item.this, "a large body shield lies here.");
setDescription(item.this, "this large body shield of metal bands provides extra protection against nearly any attack.");
setItemProperties(item.this, ObjectSize.Large, 1, 100000, "hard metal", 750);
setArmorBits(item.this);
item.this:AddWearLocation("wear_hand_left");
setBlock(item.this, 10);
--setArmorResistances(item.this, 6, 5, 3, 0, 0, 0);
zone.this.Contents:AddEntity(item.this);

newItem = createItem(801, "Target Shield", "Armor");
item.this = newItem;
setLongName(item.this, "a target shield lies here.");
setDescription(item.this, "this small shield is round, made of wood covered with metal strips, and is designed to be worn on the forearm instead of a hand.");
setItemProperties(item.this, ObjectSize.Small, 1, 20000, "hard metal", 200);
setArmorBits(item.this);
item.this:AddWearLocation("wear_hand_left");
setBlock(item.this, 4);
--setArmorResistances(item.this, 2, 1, 2, 0, 0, 0);
zone.this.Contents:AddEntity(item.this);

newItem = createItem(802, "Buckler", "Armor");
item.this = newItem;
setLongName(item.this, "a buckler shield lies here.");
setDescription(item.this, "this tiny shield is small and round and is designed to be held in one hand to deflect individual attacks.");
setItemProperties(item.this, ObjectSize.Small, 1, 10000, "hard metal", 150);
setArmorBits(item.this);
item.this:AddWearLocation("wear_hand_left");
setBlock(item.this, 3);
--setArmorResistances(item.this, 2, 1, 1, 0, 0, 0);
zone.this.Contents:AddEntity(item.this);

newItem = createItem(803, "Medium Shield", "Armor");
item.this = newItem;
setLongName(item.this, "a medium shield is lying here.");
setDescription(item.this, "this medium round shield of metal bands provides extra protection against some attacks.");
setItemProperties(item.this, ObjectSize.Medium, 1, 70000, "hard metal", 500);
setArmorBits(item.this);
item.this:AddWearLocation("wear_hand_left");
setBlock(item.this, 6);
--setArmorResistances(item.this, 4, 2, 2, 0, 0, 0);
zone.this.Contents:AddEntity(item.this);

newItem = createItem(804, "Medium Wooden Shield", "Armor");
item.this = newItem;
setLongName(item.this, "a medium wooden shield is lying here.");
setDescription(item.this, "this medium round shield is made of wood and provides extra protection against some attacks.");
setItemProperties(item.this, ObjectSize.Medium, 1, 60000, "thick wood", 400);
setArmorBits(item.this);
item.this:AddWearLocation("wear_hand_left");
setBlock(item.this, 6);
--setArmorResistances(item.this, 4, 1, 1, 0, 0, 0);
zone.this.Contents:AddEntity(item.this);

newItem = createItem(805, "Small Shield", "Armor");
item.this = newItem;
setLongName(item.this, "a small shield is lying here.");
setDescription(item.this, "this small round shield of metal bands provides extra protection against small attacks.");
setItemProperties(item.this, ObjectSize.Small, 1, 30000, "hard metal", 250);
setArmorBits(item.this);
item.this:AddWearLocation("wear_hand_left");
setBlock(item.this, 5);
--setArmorResistances(item.this, 3, 1, 1, 0, 0, 0);
zone.this.Contents:AddEntity(item.this);

newItem = createItem(806, "Small Wooden Shield", "Armor");
item.this = newItem;
setLongName(item.this, "a small wooden shield is lying here.");
setDescription(item.this, "this small round wooden shield provides extra protection against small attacks.");
setItemProperties(item.this, ObjectSize.Small, 1, 10000, "thick wood", 150);
setArmorBits(item.this);
item.this:AddWearLocation("wear_hand_left");
setBlock(item.this, 4);
--setArmorResistances(item.this, 2, 1, 0, 0, 0, 0);
zone.this.Contents:AddEntity(item.this);

newItem = createItem(807, "Studded Body Shield", "Armor");
item.this = newItem;
setLongName(item.this, "a large metal body shield covered with studs is here.");
setDescription(item.this, "this large body shield is covered with metal studs and made of overlapping plates of iron.");
setItemProperties(item.this, ObjectSize.Large, 1, 120000, "hard metal", 800);
setArmorBits(item.this);
item.this:AddWearLocation("wear_hand_left");
setBlock(item.this, 11);
--setArmorResistances(item.this, 7, 6, 3, 0, 0, 0);
zone.this.Contents:AddEntity(item.this);

-- EOF
