-- VOID/MOBS.LUA
-- This is the mobs-file for The Void
-- Revised: 2009.10.27
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_mobs.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(1);
if (zone.this == nil) then
	errorLog("void\\mobs.lua was unable to retrieve a zone object");
	return
end


systemLog("=================== ZONE 'VOID' - MOBS ===================");

newMob = createMob(1001, "Bear", 5301);
mob.this = newMob;
setLongName(mob.this, "A large bear stands here.");
setDescription(mob.this, "A large furred bear with hungry eyes and blood-stained fur around its muzzle stares back at you.");
setMobProperties(mob.this, ObjectSize.Large, MonsterClass.Standard);
mob.this:EquipItem(901);
mob.this:EquipItem(902);
mob.this:SetBehavior(1);
zone.this.Contents:AddEntity(mob.this);

newMob = createMob(1002, "White-Tailed Deer", 5303);
mob.this = newMob;
setLongName(mob.this, "A white-tailed deer stands here.");
setPluralName(mob.this, "White-Tailed Deer");
setDescription(mob.this, "A large buck, a white-tailed deer, sniffs around in the underbrush.");
setMobProperties(mob.this, ObjectSize.Medium, MonsterClass.Minion);
mob.this.Bits:SetBit(MobBits.IsHarvestable);
mob.this:AddNode(528, "dead");
setRace(mob.this, "deer");
zone.this.Contents:AddEntity(mob.this);

-- Cottontail Rabbit
newMob = createMob(1003, "Cottontail Rabbit", 5303);
mob.this = newMob;
setLongName(mob.this, "A cottontail rabbit is here.");
setDescription(mob.this, "A small rabbit with a white cotton-tail sniffs around in the underbrush.");
setMobProperties(mob.this, ObjectSize.Small, MonsterClass.Minion);
mob.this.Bits:SetBit(MobBits.IsHarvestable);
mob.this:AddNode(515, "dead");	-- meat
mob.this:AddNode(512, "dead");	-- bone
mob.this:AddNode(517, "dead");	-- pelt
mob.this:AddNode(519, "dead");	-- sinew
zone.this.Contents:AddEntity(mob.this);

-- Sheep
newMob = createMob(1004, "Sheep", 5303);
mob.this = newMob;
setLongName(mob.this, "A sheep stands here.");
setPluralName(mob.this, "Sheep");
setDescription(mob.this, "A large white sheep chews on the grass idly.");
setMobProperties(mob.this, ObjectSize.Medium, MonsterClass.Minion);
mob.this.Bits:SetBit(MobBits.IsHarvestable);
mob.this:AddNode(516, "dead");	-- meat
mob.this:AddNode(518, "dead");	-- hide
mob.this:AddNode(512, "dead");	-- bone
mob.this:AddNode(519, "dead");	-- sinew
--mob.this:AddNode(304, "alive");
zone.this.Contents:AddEntity(mob.this);


-- Gran
newMob = createMob(1005, "Gran", 5300);
mob.this = newMob;
setLongName(mob.this, "An elderly woman stands here.");
setDescription(mob.this, "Hey, its Gran the Shopkeeper!  Grey hair tied into a bun, wire-rimmed glasses, and a faint smell of mothballs.");
setMobProperties(mob.this, ObjectSize.Medium, MonsterClass.Standard);
setRace(mob.this, "human");
mob.this.Bits:SetBit(MobBits.NoAttack);
mob.this.Bits:SetBit(MobBits.IsMerchant);
setValue(mob.this, 50000);
mob.this:ClearAllItems();
mob.this:AddShop(5100);
mob.this:AddChatTree(5200);
zone.this.Contents:AddEntity(mob.this);

-- EOF