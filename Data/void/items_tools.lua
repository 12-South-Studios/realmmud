-- VOID/ITEMS_TOOLS.LUA
-- This is the items-subfile for The Void
-- Revised: 2012.01.31
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_items.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(1);
if (zone.this == nil) then
	errorLog("void\/items_tools.lua was unable to retrieve a zone object");
	return
end

systemLog("=================== ZONE 'VOID' - ITEMS/TOOLS ===================");

--================= TOOLS =================
--=========================================
newItem = createItem(2900, "axe", "Tool");
item.this = newItem;
setLongName(item.this, "an axe is lying here.");
setDescription(item.this, "this axe has a long wooden shaft and a sharpened metallic blade at the end.");
setItemProperties(item.this, ObjectSize.Medium, 1, 500, "thick wood", 250);
item.this:AddWearLocation("wear_hand_right");
item.this:AddToolType("logging");
zone.this.Contents:AddEntity(item.this);

newItem = createItem(2901, "hand saw", "Tool");
item.this = newItem;
setLongName(item.this, "a hand saw is lying here.");
setDescription(item.this, "this hand saw has a short wooden handle and a sharpened metallic blade at the end.");
setItemProperties(item.this, ObjectSize.Small, 1, 250, "thick wood", 125);
item.this:AddWearLocation("wear_hand_right");
item.this:AddToolType("logging");
item.this:AddToolType("woodworking");
zone.this.Contents:AddEntity(item.this);

newItem = createItem(2902, "pick", "Tool");
item.this = newItem;
setLongName(item.this, "a pick is lying here.");
setDescription(item.this, "this pick has a long wooden shaft and a sharpened metallic spike at the end.");
setItemProperties(item.this, ObjectSize.Medium, 1, 500, "thick wood", 250);
item.this:AddWearLocation("wear_hand_right");
item.this:AddToolType("mining");
zone.this.Contents:AddEntity(item.this);

newItem = createItem(2903, "sledgehammer", "Tool");
item.this = newItem;
setLongName(item.this, "a sledgehammer is lying here.");
setDescription(item.this, "this sledgehammer has a long wooden shaft and a heavy metallic head at the end.");
setItemProperties(item.this, ObjectSize.Medium, 1, 500, "thick wood", 250);
item.this:AddWearLocation("wear_hand_right");
item.this:AddToolType("quarrying");
zone.this.Contents:AddEntity(item.this);

newItem = createItem(2904, "shears", "Tool");
item.this = newItem;
setLongName(item.this, "a pair of shears are lying here.");
setPluralName(item.this, "shears");
setDescription(item.this, "these shears have two long metallic blades connected in the middle.");
setItemProperties(item.this, ObjectSize.Small, 1, 250, "hard metal", 125);
item.this:AddWearLocation("wear_hand_right");
item.this:AddToolType("shearing");
zone.this.Contents:AddEntity(item.this);

newItem = createItem(2905, "hunting knife", "Tool");
item.this = newItem;
setLongName(item.this, "a hunting knife is lying here.");
setPluralName(item.this, "hunting knives");
setDescription(item.this, "this large hunting knife has a long metallic blade and a leather-wrapped hilt.");
setItemProperties(item.this, ObjectSize.Small, 1, 250, "hard metal", 125);
item.this:AddWearLocation("wear_hand_right");
item.this:AddToolType("tanning");
item.this:AddToolType("butchering");
item.this:AddToolType("gathering");
zone.this.Contents:AddEntity(item.this);

-- Wooden Bucket
-- Scythe
-- Shovel

-- Adz
-- Cant Hook
-- Hide Scraper
-- Ingot Cast
-- Stone Wedge & Chisel
-- Bobbin
-- Wood Brick Frame


-- EOF
