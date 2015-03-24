-- VOID/ITEMS_CONTAINER.LUA
-- This is the items-subfile for The Void
-- Revised: 2012.01.31
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_items.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(1);
if (zone.this == nil) then
	errorLog("void\/Items_container.lua was unable to retrieve a zone object");
	return
end

systemLog("=================== ZONE 'VOID' - ITEMS/CONTAINER ===================");
-- ID RAnge: 400 to 499
newItem = createItem(400, "fountain", "Drink container"); -- was 110
item.this = newItem;
setLongName(item.this, "a beautiful stone fountain sits here");
setDescription(item.this, "this large ornate stone fountain provides pure water for passers by. It is shaped like a large curved vase with water spewing from it's mouth.");
setItemProperties(item.this, ObjectSize.Huge, 1, 0, "hard rock", 99999);
setDrinkContainerProperties(item.this, -1, "water");
zone.this.Contents:AddEntity(item.this);

newItem = createItem(401, "flask", "Potion");	-- was 111
item.this = newItem;
setLongName(item.this, "a small flask lies here.");
setDescription(item.this, "this small flask could hold a small amount of liquid.");
setItemProperties(item.this, ObjectSize.Tiny, 99, 300, "thin glass", 10);
setItemBits(item.this, true, true, false, false);
setDrinkContainerProperties(item.this, 16, "empty");
zone.this.Contents:AddEntity(item.this);

newItem = createItem(402, "waterskin", "Drink Container");	-- was 112
item.this = newItem;
setLongName(item.this, "a small skin of leather is here.");
setDescription(item.this, "this is a small skin made of cured animal hide with a stopper attached to one end.");
setItemProperties(item.this, ObjectSize.Small, 99, 800, "leather", 10);
setContainerBits(item.this);
setDrinkContainerProperties(item.this, 16, "water");
zone.this.Contents:AddEntity(item.this);

newItem = createItem(403, "backpack", "Container");	-- was 114
item.this = newItem;
setLongName(item.this, "a leather backpack is lying here.");
setDescription(item.this, "this large pack is designed to hold many items while worn comfortably on your back.");
setItemProperties(item.this, ObjectSize.Medium, 1, 20000, "leather", 100);
setContainerBits(item.this);
item.this:AddWearLocation("wear_back");
setContainerProperties(item.this, 450, 450, ObjectSize.Medium);
item.this:AddItemToContents(200);
zone.this.Contents:AddEntity(item.this);

-- EOF
