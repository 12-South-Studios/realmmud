-- VOID.LUA
-- This is the zone-file for The Void
-- Revised: 2009.09.25
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


--================ BEGIN ==================
--=========================================
systemLog("=================== ZONE 'VOID' INITIALIZING ===================");
zone.this = getEntityByID(1);
zone.this.Name = "The Void";
setDescription(zone.this, "Devoid of substance, this is the Void...");
zone.this.RepopTime = 0;


--============= ACCESS LIST ===============
--=========================================
systemLog("=================== ZONE 'VOID' - ACCESS LEVELS ===================");
zone.this:CreateAccessLevel("All", 1);


--================ SpaceS ==================
--=========================================
-- ID Range: 11 to 99
systemLog("=================== ZONE 'VOID' - SpaceS ===================");
newSpace = createSpace(11, "The Void");
Space.this = newSpace;
setDescription(Space.this, "Nothingness...");
setAccess(Space.this, 1);
zone.this.Contents:AddEntity(Space.this);
Space.this.Bits:SetBit(SpaceBits.IsShrine);
Space.this.Flags:SetFlag("shrine");

newSpace = createSpace(12, "The Void");
Space.this = newSpace;
setDescription(Space.this, "Nothingness...");
setAccess(Space.this, 1);
Space.this.Bits:SetBit(SpaceBits.IsTavern);
Space.this.Flags:SetFlag("tavern");
zone.this.Contents:AddEntity(Space.this);


--================ EXITS ==================
--=========================================
systemLog("=================== ZONE 'VOID' - EXITS ===================");

connectSpaces(11, 12, DirectionType.North, "north;n");
connectSpaces(12, 11, DirectionType.South, "south;s");


--============= TEMPLATES =================
--=========================================

-- ID Range: 4000-4999
if (doScript("void\\effects.lua") == false) then
	errorLog("Unable to load effects.lua for void zone");
end

if (doScript("void\\calendar.lua") == false) then
	errorLog("Unable to load calendar.lua for void zone");
end

-- ID Range: 3000-3999
if (doScript("void\\abilities.lua") == false) then
	errorLog("Unable to load abilities.lua for void zone");
end

if (doScript("void\\archetypes.lua") == false) then
	errorLog("Unable to load archetypes.lua for void zone");
end

-- ID Range: 5000-5099
if (doScript("void\\races.lua") == false) then
	errorLog("Unable to load races.lua for void zone");
end

-- ID Range: 100-999 and 2000-2999
if (doScript("void\\items.lua") == false) then
	errorLog("Unable to load items.lua for void zone");
end

-- ID Range: 5100-5199
if (doScript("void\\shops.lua") == false) then
	errorLog("Unable to load shops.lua for void zone");
end

-- ID Range: 5200-5299
if (doScript("void\\conversations.lua") == false) then
	errorLog("Unable to load conversations.lua for void zone");
end

-- ID Range: 5300-5399
if (doScript("void\\behaviors.lua") == false) then
	errorLog("Unable to load behaviors.lua for void zone");
end

-- ID Range: 1000-1999
if (doScript("void\\mobs.lua") == false) then
	errorLog("Unable to load mobs.lua for void zone");
end


--================ RESETS =================
if (doScript("void\\resets.lua") == false) then
	errorLog("Unable to load resets.lua for void zone");
end


--=============== MUDPROGS ================
createMudProg(0, "testprog", "\\mudprogs\\testprog.lua");


--================ FINAL ==================
--=========================================
systemLog("=================== ZONE 'VOID' (" .. zone.this.Contents:GetEntityCount() .. " entities) LOADED ===================");

-- EOF