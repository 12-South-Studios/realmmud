-- BAROCH/ITEMS_CONTAINER.LUA
-- This is the items-subfile for the Vale of Baroch
-- Revised: 2012.04.02
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_items.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(2);
if (zone.this == nil) then
	errorLog("baroch\\items_container.lua was unable to retrieve a zone object");
	return
end

systemLog("=================== ZONE 'BAROCH' - ITEMS/CONTAINER ===================");
newItem = cloneItem(400, 21302, "spring");
item.this = newItem;
setLongName(item.this, "A clear spring gurgles noisily down the hill.");
setDescription(item.this, "A bubbling spring pours out from some stones jutting out of the hill and rushes down a stone-lined route towards the river to the north.");
setDrinkContainerProperties(item.this, -1, "water");
zone.this.Contents:AddEntity(item.this);

newItem = cloneItem(401, 21303, "");
item.this = newItem;
setDrinkContainerProperties(item.this, 16, "oil");
zone.this.Contents:AddEntity(item.this);

newItem = cloneItem(402, 21304, "");
item.this = newItem;
setDrinkContainerProperties(item.this, 16, "water");
zone.this.Contents:AddEntity(item.this);

-- EOF