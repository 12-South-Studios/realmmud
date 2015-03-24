-- VOID/ITEMS_ARMOR.LUA
-- This is the items-subfile for The Void
-- Revised: 2012.01.31
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_items.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(1);
if (zone.this == nil) then
	errorLog("void\/Items_armor.lua was unable to retrieve a zone object");
	return
end

systemLog("=================== ZONE 'VOID' - ITEMS/ARMOR ===================");
-- ID Range: 200 to 299
newItem = createItem(200, "Banded Mail Hauberk", "Armor");
item.this = newItem;
setLongName(item.this, "a hauberk of banded mail lies here.");
setDescription(item.this, "a functional piece of banded mail made of horizontal metal strips riveted together. this is a hauberk, designed to protect your chest and torso. thick leather straps loop over the top and let your shoulders support the weight of the armour.");
setItemProperties(item.this, ObjectSize.Medium, 1, 1400000, "hard metal", 1250);
setArmorBits(item.this);
item.this:AddWearLocation("wear_chest");
item.this:AddStatMod(Statistic.CrushResist, 15);
item.this:AddStatMod(Statistic.SlashResist, 9);
item.this:AddStatMod(Statistic.PierceResist, 5);
setSkill(item.this, "chainmail");
item.this.Tags:AddTag("martial");
item.this.Tags:AddTag("chain");
zone.this.Contents:AddEntity(item.this);

newItem = createItem(201, "Banded Mail Skirt", "Armor");
item.this = newItem;
setLongName(item.this, "a skirt of banded mail lies here.");
setDescription(item.this, "a functional piece of banded mail made of horizontal metal strips riveted together. this piece is formed into a skirt, designed to protect your thighs and waist.");
setItemProperties(item.this, ObjectSize.Medium, 1, 600000, "hard metal", 500);
setArmorBits(item.this);
item.this:AddWearLocation("wear_waist");
item.this:AddStatMod(Statistic.CrushResist, 15);
item.this:AddStatMod(Statistic.SlashResist, 9);
item.this:AddStatMod(Statistic.PierceResist, 5);
setArmorBits(item.this);
setSkill(item.this, "chainmail");
item.this.Tags:AddTag("martial");
item.this.Tags:AddTag("chain");
zone.this.Contents:AddEntity(item.this);

newItem = createItem(202, "Barbut Helm", "Armor");
item.this = newItem;
setLongName(item.this, "a barbut helm lies here.");
setDescription(item.this, "this helm covers the entire head with a small vertical slit for the nose and mouth and a horizontal one for the eyes.");
setItemProperties(item.this, ObjectSize.Small, 1, 100000, "hard metal", 300);
setArmorBits(item.this);
item.this:AddWearLocation("wear_head");
item.this:AddStatMod(Statistic.CrushResist, 4);
item.this:AddStatMod(Statistic.SlashResist, 1);
item.this:AddStatMod(Statistic.PierceResist, 2);
item.this.Tags:AddTag("martial");
item.this.Tags:AddTag("chain");
zone.this.Contents:AddEntity(item.this);

newItem = createItem(203, "Bascinet Helmet", "Armor");
item.this = newItem;
setLongName(item.this, "a bascinet helmet lies here.");
setDescription(item.this, "a dome shaped helmet that leaves the face exposed, but protects the rest of the head and ears.");
setItemProperties(item.this, ObjectSize.Small, 1, 80000, "hard metal", 250);
setArmorBits(item.this);
item.this:AddWearLocation("wear_head");
item.this:AddStatMod(Statistic.CrushResist, 5);
item.this:AddStatMod(Statistic.SlashResist, 1);
item.this:AddStatMod(Statistic.PierceResist, 2);
item.this.Tags:AddTag("martial");
item.this.Tags:AddTag("chain");
zone.this.Contents:AddEntity(item.this);

newItem = createItem(204, "Brigandine Hauberk", "Armor");
item.this = newItem;
setLongName(item.this, "a hauberk of brigandine is lying here.");
setDescription(item.this, "a functional piece of brigandine armour made of small metal plates sewn onto a leather shirt and looks a lot like fish scales. this is a hauberk, designed to protect your chest and torso.");
setItemProperties(item.this, ObjectSize.Medium, 1, 1200000, "hard metal", 1750);
setArmorBits(item.this);
item.this:AddWearLocation("wear_chest");
item.this:AddStatMod(Statistic.CrushResist, 17);
item.this:AddStatMod(Statistic.SlashResist, 10);
item.this:AddStatMod(Statistic.PierceResist, 6);
setSkill(item.this, "ringmail");
item.this.Tags:AddTag("martial");
item.this.Tags:AddTag("chain");
zone.this.Contents:AddEntity(item.this);


-- EOF
