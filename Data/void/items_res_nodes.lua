-- VOID/ITEMS_RES_NODES.LUA
-- This is the items-subfile for The Void
-- Revised: 2012.01.31
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_items.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(1);
if (zone.this == nil) then
	errorLog("void\/items_res_nodes.lua was unable to retrieve a zone object");
	return
end

systemLog("=================== ZONE 'VOID' - ITEMS/RESOURCE NODES ===================");
--============ RESOURCE NODES =============
--=========================================
newItem = createItem(2800, "oak tree", "Resource Node");
item.this = newItem;
setLongName(item.this, "a large oak tree stands here.");
setDescription(item.this, "this massive oak tree has stood here for many years and stands tall and proud.");
setMaterial(item.this, "thick wood");
item.this:AddResource(2000, "logging", 1, 1);
item.this:AddResource(2001, "gathering", 2, 1);
zone.this.Contents:AddEntity(item.this);

newItem = createItem(2801, "iron ore vein", "Resource Node");
item.this = newItem;
setLongName(item.this, "a large vein of iron ore is here.");
setDescription(item.this, "this massive vein of stone and iron ore has been exposed by the weather.");
setMaterial(item.this, "hard rock");
item.this:AddResource(2004, "mining", 1, 1);
zone.this.Contents:AddEntity(item.this);

newItem = createItem(2802, "sandstone outcropping", "Resource Node");
item.this = newItem;
setLongName(item.this, "a large outcropping of sandstone is here.");
setDescription(item.this, "this massive outcropping of sandstone has been exposed by the weather.");
setMaterial(item.this, "brittle rock");
item.this:AddResource(2005, "quarrying", 1, 1);
zone.this.Contents:AddEntity(item.this);

newItem = createItem(2803, "deer carcass", "Resource Node");
item.this = newItem;
setLongName(item.this, "the carcass of a deer is here.");
setPluralName(item.this, "deer carcasses");
setDescription(item.this, "the freshly killed carcass of a deer lies here.");
setMaterial(item.this, "organic");
item.this:AddResource(2007, "tanning", 1, 1);
item.this:AddResource(2010, "tanning", 1, 1);
item.this:AddResource(2012, "gathering", 1, 1);
item.this:AddResource(2014, "butchering", 1, 1);
zone.this.Contents:AddEntity(item.this);

newItem = createItem(2804, "white pine tree", "Resource Node");
item.this = newItem;
setLongName(item.this, "a tall white pine tree stands here.");
setDescription(item.this, "this tall slender white pine tree stretches up towards the sun.");
setMaterial(item.this, "thick wood");
item.this:AddResource(2023, "logging", 1, 1);
--item.this:AddResource(202, "gathering", 2, 1);
zone.this.Contents:AddEntity(item.this);

newItem = createItem(2805, "rabbit carcass", "Resource Node");
item.this = newItem;
setLongName(item.this, "the carcass of a rabbit is here.");
setPluralName(item.this, "rabbit carcasses");
setDescription(item.this, "the freshly killed carcass of a rabbit lies here.");
setMaterial(item.this, "organic");
item.this:AddResource(2017, "tanning", 1, 1);
item.this:AddResource(2012, "gathering", 1, 1);
item.this:AddResource(2015, "butchering", 1, 1);
zone.this.Contents:AddEntity(item.this);

-- Sheep Carcass
-- Sheep (alive)

-- Clay Deposit
-- Cotton Plant
-- Sand Deposit
-- Limestone Outcropping
-- Granite Outcropping

-- EOF
