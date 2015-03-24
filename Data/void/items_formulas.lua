-- VOID/ITEMS_FORMULAS.LUA
-- This is the items-subfile for The Void
-- Revised: 2012.01.31
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_items.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(1);
if (zone.this == nil) then
	errorLog("void\/items_formulas.lua was unable to retrieve a zone object");
	return
end

systemLog("=================== ZONE 'VOID' - ITEMS/FORMULAS ===================");
--=============== FORMULAS ================
--=========================================
newItem = createItem(2967, "Oak Board Recipe", "Formula");
item.this = newItem;
setFormulaDetails(item.this, "woodworking", 1, 2003, 2, 2934, 2900, 100);	-- Woodworking, Oak Board, Table Saw, Tree Axe
item.this:AddResource(2000, 1);-- Oak Log
zone.this.Contents:AddEntity(item.this);

--How to split a log for firewood.
--How to shape a log for timber.
--How to cut a timber into boards with a hand saw.
--How to cut a timber into boards at a sawmill.
--How to tan a hide into leather.
--How to prepare patterns from a bundle.
--How to process low-grade ore.
--How to smelt high-grade ore into ingots.
--How to shape stone blocks into slabs.
--How to cut stone slabs into building blocks.
--How to skirt a fleece.
--How to spin thread from a bale.
--How to cure a pelt for fur.
--How to cook meat.
--How to make a clay brick.
--How to process fiber into yarn.
--How to make quicklime.


-- EOF
