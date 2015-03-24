-- BAROCH/MOBS.LUA
-- This is the mobs-file for the Vale of Baroch
-- Revised: 2009.09.25
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(2);
if (zone.this == nil) then
	errorLog("baroch\\mobs.lua was unable to retrieve a zone object");
	return
end


systemLog("=================== ZONE 'BAROCH' - MOBS ===================");

newMob = createMob(21500, "Village Guard", 5305);
mob.this = newMob;
setLongName(mob.this, "A haggard-looking armored warrior stands here.");
setDescription(mob.this, "This weary-looking man of average height and build is guarding the village from danger. Though his physique looks as if he is ready for battle at any moment, his eyes and stance betray his thoughts of despair and hopelessness.");
setRace(mob.this, "human");
setAccess(mob.this, 62);
setMobProperties(mob.this, ObjectSize.Medium, MonsterClass.Standard);
mob.this:EquipItem("battered chain mail hauberk");
mob.this:EquipItem("dented helmet");
mob.this:EquipItem("dented shield");
mob.this:EquipItem("short spear");
mob.this:AddChatTree(21250);
mob.this.Bits:SetBit(MobBits.StayArea);
zone.this.Contents:AddEntity(mob.this);

newMob = createMob(21501, "Snarling Mastiff", 5305);
mob.this = newMob;
setLongName(mob.this, "An enormous, snarling mastiff is prowling here.");
setDescription(mob.this, "This huge dog is nearly four feet at the shoulder, has canines that are nearly three inches long, and powerful muscles and jaws. Its eyes blaze with a ferocious intensity and an incredible amount of drool falls from its open maw.");
setRace(mob.this, "dog");
setMobProperties(mob.this, ObjectSize.Small, MonsterClass.Standard);
zone.this.Contents:AddEntity(mob.this);

newMob = createMob(21502, "Blacksmith", 5302);
mob.this = newMob;
setLongName(mob.this, "A heavily-muscled man stands here forging weapons and armor.");
setDescription(mob.this, "This large, burly man looks as if he has seen many years of both combat and working in the forge. His muscled arms are nearly as large around as tree trunks, his entire body is covered with soot, and his grizzled face is dripping with sweat.");
setRace(mob.this, "human");
setValue(mob.this, 50000);
mob.this:ClearAllItems();
mob.this.Bits:SetBit(MobBits.IsSentinel);
mob.this.Bits:SetBit(MobBits.IsMerchant);
mob.this:AddShop(21230);
zone.this.Contents:AddEntity(mob.this);

newMob = cloneMob(21500, 21503, "Captain of the Guard");
mob.this = newMob;
setLongName(mob.this, "A tall man in shining armor who is shouting orders is here.");
setDescription(mob.this, "This tall, well-built man carries himself with great poise and confidence. His appearance is well-gSpaceed, clean and trimmed and, unlike the village guard, his eyes have an intensity that is bordering on insanity.");
setAccess(mob.this, 4);
setMobProperties(mob.this, ObjectSize.Medium, MonsterClass.Strong);
mob.this:ClearAllItems();
mob.this:EquipItem("scale mail hauberk");
mob.this:EquipItem("horned great helm");
mob.this:EquipItem("fur lined boots");
mob.this:EquipItem("studded shield");
mob.this:EquipItem("moleskin gloves");
mob.this:EquipItem("engraved longsword");
mob.this.Bits:SetBit(MobBits.StayArea);
zone.this.Contents:AddEntity(mob.this);

newMob = cloneMob(21500, 21504, "Stablehand");
mob.this = newMob;
setLongName(mob.this, "A dirty and worn-out looking man stands here with a bSpace.");
setDescription(mob.this, "This dirt-covered man in overalls looks to be the village stablehand. He has a bit of straw in his mouth that he is chewing on and is carrying a bSpace that he's using to sweep the floor of the stable.");
mob.this:ClearAllItems();
zone.this.Contents:AddEntity(mob.this);

newMob = createMob(21505, "Worn-out horse", 5301);
mob.this = newMob;
setLongName(mob.this, "A tired and worn-out horse is here.");
setDescription(mob.this, "This horse has seen many years of heavy and hard work. It is eating quietly on the sparse grass in the corral and barely notices your presence.");
setRace(mob.this, "horse");
setAccess(mob.this, 64);
setMobProperties(mob.this, ObjectSize.Large, MobBits.Minion);
--mob.this:addAttack("natural", "kick", 1, 6, 0);
--mob.this:addAttack("natural", "bite", 1, 3, 0);
zone.this.Contents:AddEntity(mob.this);

newMob = cloneMob(21502, 21506, "Merchant");
mob.this = newMob;
setLongName(mob.this, "A grumpy, elderly man stands here.");
setDescription(mob.this, "This portly man with graying hair has a scowl on his face.");
mob.this:ClearAllItems();
mob.this:AddShop(21231);
zone.this.Contents:AddEntity(mob.this);

newMob = cloneMob(21500, 21507, "Sergeant of the Guard");
mob.this = newMob;
setLongName(mob.this, "A haggard-looking armored warrior stands here.");
setDescription(mob.this, "This weary-looking man of average height and build is guarding the village from danger. Though his physique looks as if he is ready for battle at any moment, his eyes and stance betray his thoughts of despair and hopelessness.");
zone.this.Contents:AddEntity(mob.this);

newMob = cloneMob(21502, 21508, "Temple Healer");
mob.this = newMob;
setLongName(mob.this, "A tall man with a flowing white robe and a staff is here.");
setDescription(mob.this, "This tall, well-kept man with clear, blue eyes is talking about the greatness of Saidar. His robe is extremely clean and has the symbol of Saidar, the Sword of Justice, on its breast. His voice is loud and carries across the roadway.");
mob.this:ClearAllItems();
zone.this.Contents:AddEntity(mob.this);

newMob = cloneMob(21502, 21509, "Innkeeper");
mob.this = newMob;
setLongName(mob.this, "A large, rotund man with a beard and bellowing voice is here.");
setDescription(mob.this, "This extremely large man with a beard that reaches to his chest and long, braided hair is cleaning the bar. His hands are huge, his fingers thick, but he carefully washes every mug and glass without breaking them.");
mob.this:ClearAllItems();
zone.this.Contents:AddEntity(mob.this);

newMob = cloneMob(21500, 21510, "Drunken villager");
mob.this = newMob;
setLongName(mob.this, "A villager who has obviously had too much to drink is here.");
setDescription(mob.this, "This haphazardly dressed man appears to be extremely drunk, both from his posture (his head is resting on the table in a puddle of dark liquid) and from the extremely loud snoring that is emanating from his mouth.");
mob.this:ClearAllItems();
zone.this.Contents:AddEntity(mob.this);

newMob = cloneMob(21500, 21511, "Weary Traveler");
mob.this = newMob;
setLongName(mob.this, "A weary woman with travel-stained clothing is here.");
setDescription(mob.this, "This tall woman is wearing clothing that is covered with dust and sweat. A large pack, which most likely contains her belongings, rests next to her chair. A long bow and quiver of arrows rest in the chair next to her and a leather helmet lies on the table in front.");
mob.this:ClearAllItems();
zone.this.Contents:AddEntity(mob.this);

newMob = cloneMob(21500, 21512, "Weary Traveler");
mob.this = newMob;
setLongName(mob.this, "A weary-looking traveler who is nursing a mug of ale is here.");
setDescription(mob.this, "This traveler has settled into a booth along the wall and is nursing a large mug of ale. He is wearing travel-stained clothing, though he appears to have bathed recently. His eyes dart from side to side, as though he is nervous.");
mob.this:ClearAllItems();
zone.this.Contents:AddEntity(mob.this);

newMob = cloneMob(21502, 21513, "Cook");
mob.this = newMob;
setLongName(mob.this, "A short, round woman with a stained apron is here.");
setDescription(mob.this, "This short, round woman has a food-stained apron and is currently mixing some food together to make a pie. Her long, grey hair is pulled back behind her in a braid and her face is a rosy red, probably due to the effort she is putting into her cooking and the warmth of the Space.");
mob.this:ClearAllItems();
mob.this.Bits:SetBit(MobBits.IsSentinel);
zone.this.Contents:AddEntity(mob.this);

newMob = createMob(21514, "Cat", 5301);
mob.this = newMob;
setLongName(mob.this, "A large, purring, black and white cat is here.");
setDescription(mob.this, "This very large cat with black and white spots is lapping up milk out of a large bowl near the fireplace. A contented purr emanates from the cat and its tail swishes back and forth.");
setRace(mob.this, "cat");
setAccess(mob.this, 8);
setMobProperties(mob.this, ObjectSize.Tiny, MonsterClass.Minion);
mob.this.Bits:SetBit(MobBits.IsSentinel);
--mob.this:addAttack("natural", "bite", 1, 1, 0);
--mob.this:addAttack("natural", "claw", 1, 2, 0);
zone.this.Contents:AddEntity(mob.this);

newMob = cloneMob(21502, 21515, "Priest of the White");
mob.this = newMob;
setLongName(mob.this, "A tall man with a flowing white robe and open arms is here.");
setDescription(mob.this, "This tall, well-kept man with clear, blue eyes is talking about the greatness of Saidar. His white robe is extremely clean and has the symbol of Saidar, the Sword of Justice, on its breast. His voice is loud and carries throughout the temple and the smile upon his face is reflected in his eyes.");
mob.this:ClearAllItems();
zone.this.Contents:AddEntity(mob.this);

newMob = cloneMob(21500, 21516, "Nervous Woman");
mob.this = newMob;
setLongName(mob.this, "A nervous and poorly dressed woman is here.");
setDescription(mob.this, "This poorly dressed woman looks about nervously. Her eyes are shadowed with fear and with no small amount of hopelessness.");
mob.this:ClearAllItems();
zone.this.Contents:AddEntity(mob.this);

newMob = cloneMob(21500, 21517, "Dirty Child");
mob.this = newMob;
setLongName(mob.this, "A dirty child in tattered clothing is here.");
setDescription(mob.this, "This small child is extremely dirty and is wearing nothing but a few rags. The child’s eyes are filled with fear and despair.");
setMobProperties(mob.this, ObjectSize.Small, MonsterClass.Minion);
mob.this:ClearAllItems();
zone.this.Contents:AddEntity(mob.this);

newMob = cloneMob(21500, 21518, "Torch Bearer");
mob.this = newMob;
setLongName(mob.this, "A poorly-dressed torch bearer stands here.");
setDescription(mob.this, "This thin, dirty man is wearing the garb of one of the village guard. His eyes have a haunted look to them and his stance betrays his thoughts of despair.");
mob.this:ClearAllItems();
mob.this:EquipItem("battered chain mail hauberk");
mob.this:EquipItem("dented helmet");
mob.this:EquipItem("dented shield");
mob.this:EquipItem("large torch");
zone.this.Contents:AddEntity(mob.this);

newMob = createMob(21519, "Moaning Zombie", 5306);
mob.this = newMob;
setLongName(mob.this, "A rotting corpse with tattered, bloody clothing stands here.");
setDescription(mob.this, "This decaying corpse has bits of flesh still hanging on its frame, though you can see bones in several places. Tattered and bloody clothing hang on the remains of the body, though they do little to disguise or cover the putrid body underneath.");
setRace(mob.this, "zombie");
setMobProperties(mob.this, ObjectSize.Medium, MonsterClass.Minion);
setAccess(mob.this, 16);
--mob.this:addImmunity("sleep");
--mob.this:addImmunity("charm");
--mob.this:addImmunity("hold");
--mob.this:addImmunity("fear");
--mob.this:addImmunity("death_magic");
--mob.this:addImmunity("cold");
--mob.this:addImmunity("poison");
--mob.this:addImmunity("paralyze");
--mob.this:MakeUndead(2);
--mob.this:GetAI():addHateValue("living", 99);
zone.this.Contents:AddEntity(mob.this);

newMob = createMob(21520, "Skeletal Figure", 5306);
mob.this = newMob;
setLongName(mob.this, "A gaunt, skeletal figure stands here.");
setDescription(mob.this, "The skeletal remains of a humanoid stand here, its empty eye-sockets staring in your direction.");
setRace(mob.this, "skeleton");
setMobProperties(mob.this, ObjectSize.Medium, MonsterClass.Minion);
setAccess(mob.this, 1);
--mob.this:addImmunity("sleep");
--mob.this:addImmunity("charm");
--mob.this:addImmunity("hold");
--mob.this:addImmunity("fear");
--mob.this:addImmunity("death_magic");
--mob.this:addImmunity("cold");
--mob.this:addImmunity("poison");
--mob.this:addImmunity("paralyze");
--mob.this:MakeUndead(1);
--mob.this:addResistance("slash", 0.5);
--mob.this:addResistance("pierce", 0.5);
--mob.this:GetAI():addHateValue("living", 99);
--mob.this:GetAI():setIntelligence(0);
zone.this.Contents:AddEntity(mob.this);

newMob = createMob(21521, "Skeletal Bear", 5306);
mob.this = newMob;
setLongName(mob.this, "A large skeletal bear stands here.");
setDescription(mob.this, "The skeletal remains of some sort of large bear prowl here. The bear's empty eye-sockets stare in your direction.");
setRace(mob.this, "skeletal bear");
setMobProperties(mob.this, ObjectSize.Large, MonsterClass.Strong);
--mob.this:addImmunity("sleep");
--mob.this:addImmunity("charm");
--mob.this:addImmunity("hold");
--mob.this:addImmunity("fear");
--mob.this:addImmunity("death_magic");
--mob.this:addImmunity("cold");
--mob.this:addImmunity("poison");
--mob.this:addImmunity("paralyze");
--mob.this:MakeUndead(1);
--mob.this:addResistance("slash", 0.5);
--mob.this:addResistance("pierce", 0.5);
--mob.this:GetAI():addHateValue("living", 99);
--mob.this:GetAI():setIntelligence(0);
zone.this.Contents:AddEntity(mob.this);

-- EOF