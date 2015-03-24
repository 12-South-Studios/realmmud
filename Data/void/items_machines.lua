-- VOID/ITEMS_MACHINES.LUA
-- This is the items-subfile for The Void
-- Revised: 2012.01.31
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_items.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(1);
if (zone.this == nil) then
	errorLog("void\/items_machines.lua was unable to retrieve a zone object");
	return
end

systemLog("=================== ZONE 'VOID' - ITEMS/MACHINES ===================");
--============== MACHINES =================
--=========================================
newItem = createItem(2934, "Saw", "Machine");
item.this = newItem;
setLongName(item.this, "a saw sits here.");
setDescription(item.this, "a heavy metal saw stands affixed to a large wooden frame.");
setMaterial(item.this, "thick wood");
item.this.Machine = GetStaticData("machinetypes", "woodworking");
zone.this.Contents:AddEntity(item.this);

-- Sawhorse
-- Tanning Rack
-- Tanning Table
-- Ore Crusher
-- Smelter
-- Block & Tackle
-- Fleecing Table
-- Spinning Wheel
-- Cooking Fire
-- Kiln
-- Lime Kiln

-- EOF
