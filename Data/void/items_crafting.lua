-- VOID/ITEMS_CRAFTING.LUA
-- This is the items-subfile for The Void
-- Revised: 2012.01.31
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_items.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(1);
if (zone.this == nil) then
	errorLog("void\/Items_crafting.lua was unable to retrieve a zone object");
	return
end

systemLog("=================== ZONE 'VOID' - ITEMS/CRAFTING ===================");
--============== RESOURCES ================
--=========================================
-- 2000-2799
newItem = createItem(2000, "oak log", "Resource");
item.this = newItem;
setLongName(item.this, "a long log of freshly cut oak lies here.");
setDescription(item.this, "a long freshly cut log of oak.");
setItemProperties(item.this, ObjectSize.Medium, 100, 400, "thick wood", 500);
zone.this.Contents:AddEntity(item.this);

newItem = createItem(2001, "oak leaf", "Resource");
item.this = newItem;
setLongName(item.this, "a small leaf lies here");
setPluralName(item.this, "oak leaves");
setDescription(item.this, "a small green leaf that once hung from an oak tree.");
setItemProperties(item.this, ObjectSize.Tiny, 100, 20, "paper", 1);
setItemBits(item.this, true, true, false, false);
zone.this.Contents:AddEntity(item.this);

newItem = createItem(2002, "yellowed parchment", "Resource");
item.this = newItem;
setLongName(item.this, "a sheet of yellowed parchment lies here.");
setPluralName(item.this, "pages of yellowed parchment");
setDescription(item.this, "this ten-inch sheet of parchment would be usefull for writing upon.");
setItemProperties(item.this, ObjectSize.Small, 100, 10000, "paper", 1);
zone.this.Contents:AddEntity(item.this);

newItem = createItem(2003, "oak board", "Resource");
item.this = newItem;
setLongName(item.this, "a long narrow board of oak lies here.");
setDescription(item.this, "a long narrow board of oak.");
setItemProperties(item.this, ObjectSize.Medium, 100, 600, "thin wood", 250);
zone.this.Contents:AddEntity(item.this);

newItem = createItem(2004, "iron ore", "Resource");
item.this = newItem;
setLongName(item.this, "a pile of low-grade iron ore lies here.");
setPluralName(item.this, "iron ore");
setDescription(item.this, "a pile of low-grade iron ore.");
setItemProperties(item.this, ObjectSize.Small, 100, 400, "hard metal", 500);
zone.this.Contents:AddEntity(item.this);

newItem = createItem(2005, "huge sandstone block", "Resource");
item.this = newItem;
setLongName(item.this, "a massive block of sandstone is here.");
setDescription(item.this, "a large, heavy block of quarried sandstone.");
setItemProperties(item.this, ObjectSize.Huge, 100, 400, "brittle rock", 500);
zone.this.Contents:AddEntity(item.this);

-- Wool Fleece
newItem = createItem(2006, "wool fleece", "Resource");	-- was 207
item.this = newItem;
zone.this.Contents:AddEntity(item.this);

-- Deer Hide
newItem = createItem(2007, "white-tailed deer hide", "Resource");	-- was 208
item.this = newItem;
zone.this.Contents:AddEntity(item.this);

-- Oak Sticks
newItem = createItem(2008, "oak sticks", "Resource");	-- was 209
item.this = newItem;
zone.this.Contents:AddEntity(item.this);

-- Clay
newItem = createItem(2009, "common clay", "Resource");	-- was 210
item.this = newItem;
zone.this.Contents:AddEntity(item.this);

-- Deer Pelt	
newItem = createItem(2010, "white-tailed deer pelt", "Resource"); -- was 211
item.this = newItem;
zone.this.Contents:AddEntity(item.this);

-- Cotton Fiber
newItem = createItem(2011, "cotton fiber", "Resource");	 -- was 212
item.this = newItem;
zone.this.Contents:AddEntity(item.this);

-- Animal Bone
newItem = createItem(2012, "bone", "Resource");	-- 213
item.this = newItem;
zone.this.Contents:AddEntity(item.this);

-- Sand
newItem = createItem(2013, "sand", "Resource"); -- 214
item.this = newItem;
zone.this.Contents:AddEntity(item.this);

-- Raw Venison
newItem = createItem(2014, "raw venison", "Resource"); -- 215
item.this = newItem;
zone.this.Contents:AddEntity(item.this);

-- Raw Rabbit Meat
newItem = createItem(2015, "raw rabbit meat", "Resource"); -- 216
item.this = newItem;
zone.this.Contents:AddEntity(item.this);

-- Raw Mutton
newItem = createItem(2016, "raw mutton", "Resource"); -- 217
item.this = newItem;
zone.this.Contents:AddEntity(item.this);

-- Rabbit Pelt
newItem = createItem(2017, "cottontail rabbit pelt", "Resource");
item.this = newItem;
zone.this.Contents:AddEntity(item.this);

-- Deer Pelt
newItem = createItem(2018, "sheep hide", "Resource");
item.this = newItem;
zone.this.Contents:AddEntity(item.this);

-- Animal Bone
newItem = createItem(2019, "sinew", "Resource");
item.this = newItem;
zone.this.Contents:AddEntity(item.this);

-- White Clay
newItem = createItem(2020, "white clay", "Resource");
item.this = newItem;
zone.this.Contents:AddEntity(item.this);

-- Granite
newItem = createItem(2021, "huge granite block", "Resource");
item.this = newItem;
zone.this.Contents:AddEntity(item.this);

-- Limestone
newItem = createItem(2022, "huge limestone block", "Resource");
item.this = newItem;
zone.this.Contents:AddEntity(item.this);

-- Pine Log
newItem = createItem(2023, "white pine log", "Resource");
item.this = newItem;
setLongName(item.this, "a long log of freshly cut white pine lies here.");
setDescription(item.this, "a long freshly cut log of white pine.");
setItemProperties(item.this, ObjectSize.Medium, 100, 300, "thick wood", 400);
zone.this.Contents:AddEntity(item.this);

-- Firewood
-- Oak Timber
-- White Pine Board
-- White Pine Timber
-- Leather Bundle
-- Leather Pattern
-- High-grade Iron Ore
-- Iron Ingot
-- Sandstone Slab
-- Sandstone Building Block
-- Wool Bale
-- Wool Thread Spool
-- Deer Fur
-- Rabbit Fur
-- Cooked Venison
-- Cooked Rabbit Meat
-- Cooked Mutton
-- Clay Brick
-- White Clay Brick
-- Cotton Yarn Spool
-- Quicklime
-- Limestone Block



-- 2800-2899
if (doScript("void\/items_res_nodes.lua") == false) then
	errorLog("Unable to load items_res_nodes.lua for void zone");
end

-- 2900-2933
if (doScript("void\/items_tools.lua") == false) then
	errorLog("Unable to load items_tools.lua for void zone");
end

-- 2934-2966
if (doScript("void\/items_machines.lua") == false) then
	errorLog("Unable to load items_machines.lua for void zone");
end

-- 2967-2999
if (doScript("void\/items_formulas.lua") == false) then
	errorLog("Unable to load items_formulas.lua for void zone");
end

-- EOF
