-- VOID/ITEMS_LIGHT.LUA
-- This is the items-subfile for The Void
-- Revised: 2012.01.31
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(1);
if (zone.this == nil) then
	errorLog("void\/Items_light.lua was unable to retrieve a zone object");
	return
end

systemLog("=================== ZONE 'VOID' - ITEMS/LIGHT ===================");
-- ID RAnge 700 to 799

newItem = createItem(700, "lantern", "light");
item.this = newItem;
setLongName(item.this, "a lantern sits here.");
setDescription(item.this, "this lantern will illuminate up to thirty square feet.");
setItemProperties(item.this, ObjectSize.Small, 1, 20000, "glass", 100);
setItemBits(item.this, true, true, false, false);
item.this:AddWearLocation("wear_hand_left");
item.this:SetLiquidFuel(180, 32, "oil");
zone.this.Contents:AddEntity(item.this);

newItem = createItem(701, "hooded lantern", "light");
item.this = newItem;
setLongName(item.this, "a hooded lantern sits here.");
setDescription(item.this, "this lantern will illuminate up to thirty square feet.");
setItemProperties(item.this, ObjectSize.Small, 1, 70000, "glass", 100);
setItemBits(item.this, true, true, false, false);
item.this:AddWearLocation("wear_hand_left");
item.this:SetLiquidFuel(180, 32, "oil");
zone.this.Contents:AddEntity(item.this);

newItem = createItem(702, "torch", "light");
item.this = newItem;
setLongName(item.this, "a torch is here");
setPluralName(item.this, "torches");
setDescription(item.this, "A hastily made torch");
setItemProperties(item.this, ObjectSize.Small, 99, 1, "thin wood", 50);
setItemBits(item.this, true, true, false, false);
item.this:SetSolidFuel(300);
item.this:AddWearLocation("wear_hand_left");
zone.this.Contents:AddEntity(item.this);

newItem = createItem(703, "large torch", "light");
item.this = newItem;
setLongName(item.this, "a large torch is here");
setPluralName(item.this, "large torches");
setDescription(item.this, "this torch is three feet tall and attached to a thick wooden stake.");
setItemProperties(item.this, ObjectSize.Medium, 99, 25, "thick wood", 500);
setItemBits(item.this, true, true, false, false);
item.this:AddWearLocation("wear_hand_left");
item.this:SetSolidFuel(2400);
--item.this:Ignite(true);
zone.this.Contents:AddEntity(item.this);

newItem = createItem(704, "huge torch", "light");
item.this = newItem;
setLongName(item.this, "a huge torch is here");
setPluralName(item.this, "huge torches");
setDescription(item.this, "this massive torch is five feet tall and attached to a thick wooden stake.");
setItemProperties(item.this, ObjectSize.Large, 99, 0, "thick wood", 1000);
item.this.Bits:SetBit(ITEM_IS_TAKEABLE);
item.this:AddWearLocation("wear_hand_both");
item.this:SetSolidFuel(7200);
--item.this:Ignite(true);
zone.this.Contents:AddEntity(item.this);

newItem = createItem(705, "lamppost", "light");
item.this = newItem;
setLongName(item.this, "a lamppost is here.");
setDescription(item.this, "This is an ornate metal post mounted in the ground, with an attached lamp.");
setItemProperties(item.this, ObjectSize.Large, 99, 0, "hard metal", 2500);
item.this:SetLiquidFuel(180, 128, "oil");
zone.this.Contents:AddEntity(item.this);

newItem = createItem(706, "tallow candle", "light");
item.this = newItem;
setLongName(item.this, "a candle made of tallow is here.");
setDescription(item.this, "a candle made of tallow, animal fat");
setItemProperties(item.this, ObjectSize.Tiny, 99, 1, "food", 25);
setItemBits(item.this, true, true, false, false);
item.this:SetSolidFuel(75);
item.this:AddWearLocation("wear_hand_left");
zone.this.Contents:AddEntity(item.this);

newItem = createItem(707, "wax candle", "light");
item.this = newItem;
setLongName(item.this, "a candle made of wax is here.");
setDescription(item.this, "a candle made of wax");
setItemProperties(item.this, ObjectSize.Tiny, 99, 2, "food", 25);
setItemBits(item.this, true, true, false, false);
item.this:SetSolidFuel(150);
item.this:AddWearLocation("wear_hand_left");
zone.this.Contents:AddEntity(item.this);

-- EOF
