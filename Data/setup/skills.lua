-- SKILLS.LUA
-- This is the skills data file
-- Revised: 2012.03.05
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


systemLog("=================== REALMMUD SETUP - MELEE (OFFENSIVE) SKILLS ===================");
-- Level 1 Weapon Skills
createSkillCategory("Melee (Offensive)", Statistic.Strength);
createSkill(501, "1-h weapons", "melee (offensive)", Statistic.Strength, 100, false, "");
createSkill(502, "2-h weapons", "melee (offensive)", Statistic.Strength, 100, false, "");
createSkill(503, "ranged weapons", "melee (offensive)", Statistic.Strength, 100, false, "");
createSkill(504, "unarmed", "melee (offensive)", Statistic.Strength, 100, false, "");

-- Level 2 Weapon Skills
createSkillCategory("1-H Weapons", Statistic.Strength);
createSkill(505, "1-h swords", "1-H Weapons", Statistic.Strength, 100, false, "1-h weapons");
createSkill(506, "1-h axes", "1-H Weapons", Statistic.Strength, 100, false, "1-h weapons");
createSkill(507, "1-h maces", "1-H Weapons", Statistic.Strength, 100, false, "1-h weapons");
createSkill(508, "warhammers", "1-H Weapons", Statistic.Strength, 100, false, "1-h weapons");
createSkill(509, "daggers", "1-H Weapons", Statistic.Strength, 100, false, "1-h weapons");
createSkill(510, "1-h spears", "1-H Weapons", Statistic.Strength, 100, false, "1-h weapons");
createSkill(511, "1-h exotics", "1-H Weapons", Statistic.Strength, 100, false, "1-h weapons");

createSkillCategory("2-H Weapons", Statistic.Strength);
createSkill(512, "2-h swords", "2-H Weapons", Statistic.Strength, 100, false, "2-h weapons");
createSkill(513, "2-h axes", "2-H Weapons", Statistic.Strength, 100, false, "2-h weapons");
createSkill(514, "2-h maces", "2-H Weapons", Statistic.Strength, 100, false, "2-h weapons");
createSkill(515, "2-h spears", "2-H Weapons", Statistic.Strength, 100, false, "2-h weapons");
createSkill(516, "2-h exotics", "2-H Weapons", Statistic.Strength, 100, false, "2-h weapons");

createSkillCategory("Ranged Weapons", Statistic.Strength);
createSkill(517, "bows", "Ranged Weapons", Statistic.Strength, 100, false, "ranged weapons");
createSkill(518, "crossbows", "Ranged Weapons", Statistic.Strength, 100, false, "ranged weapons");
createSkill(519, "thrown", "Ranged Weapons", Statistic.Strength, 100, false, "ranged weapons");
createSkill(520, "fired", "Ranged Weapons", Statistic.Strength, 100, false, "ranged weapons");

createSkillCategory("Unarmed", Statistic.Strength);
createSkill(521, "striking", "Unarmed", Statistic.Strength, 100, false, "unarmed");
createSkill(522, "grappling", "Unarmed", Statistic.Strength, 100, false, "unarmed");
createSkill(523, "kicking", "Unarmed", Statistic.Strength, 100, false, "unarmed");

-- Level 3 Weapon Skills
createSkill(524, "short sword", "melee (offensive)", Statistic.Strength, 150, true, "1-h swords");


systemLog("=================== REALMMUD SETUP - MELEE (DEFENSIVE) SKILLS ===================");
-- Level 1 Armor Skills
createSkillCategory("Melee (Defensive)", Statistic.Endurance);
createSkill(601, "shield", "melee (defensive)", Statistic.Endurance, 100, false, "");
createSkill(602, "light armor", "melee (defensive)", Statistic.Endurance, 100, false, "");
createSkill(603, "heavy armor", "melee (defensive)", Statistic.Endurance, 100, false, "");
createSkill(604, "magical armor", "melee (defensive)", Statistic.Endurance, 100, false, "");
createSkill(605, "helms", "melee (defensive)", Statistic.Endurance, 100, false, "");

-- Level 2 Armor Skills
createSkillCategory("Shield", Statistic.Endurance);
createSkill(606, "light shield", "Shield", Statistic.Endurance, 150, true, "shield");
createSkill(607, "heavy shield", "Shield", Statistic.Endurance, 150, true, "shield");

createSkillCategory("Light Armor", Statistic.Endurance);
createSkill(608, "hide armor", "Light Armor", Statistic.Endurance, 100, false, "light armor");
createSkill(609, "leather armor", "Light Armor", Statistic.Endurance, 100, false, "light armor");
createSkill(610, "ringmail armor", "Light Armor", Statistic.Endurance, 100, false, "light armor");
createSkill(611, "brigandine armor", "Light Armor", Statistic.Endurance, 100, false, "light armor");

createSkillCategory("Heavy Armor", Statistic.Endurance);
createSkill(612, "chainmail armor", "Heavy Armor", Statistic.Endurance, 100, false, "heavy armor");
createSkill(613, "scalemail armor", "Heavy Armor", Statistic.Endurance, 100, false, "heavy armor");
createSkill(614, "platemail armor", "Heavy Armor", Statistic.Endurance, 100, false, "heavy armor");

systemLog("=================== REALMMUD SETUP - ROGUE SKILLS ===================");

systemLog("=================== REALMMUD SETUP - SOCIAL SKILLS ===================");

systemLog("=================== REALMMUD SETUP - CRAFTING SKILLS ===================");
-- GATHERING skills
createSkill(101, "mining", "gathering", Statistic.Strength, 100, false, "");
createSkill(102, "logging", "gathering", Statistic.Strength, 100, false, "");
createSkill(103, "quarrying", "gathering", Statistic.Strength, 100, false, "");
createSkill(104, "shearing", "gathering", Statistic.Agility, 100, false, "");
createSkill(105, "tanning", "gathering", Statistic.Agility, 100, false, "");
createSkill(106, "gathering", "gathering", Statistic.Agility, 100, false, "");
createSkill(107, "butchering", "gathering", Statistic.Endurance, 100, false, "");

-- PROCESSING skills
createSkill(201, "metalworking", "processing", Statistic.Strength, 100, false, "");
createSkill(202, "woodworking", "processing", Statistic.Agility, 100, false, "");
createSkill(203, "masonry", "processing", Statistic.Strength, 100, false, "");
createSkill(204, "tailoring", "processing", Statistic.Agility, 100, false, "");
createSkill(205, "enchanting", "processing", Statistic.Dexterity, 100, false, "");
createSkill(206, "cooking", "processing", Statistic.Dexterity, 100, false, "");


systemLog("=================== REALMMUD SETUP - ADVENTURING SKILLS ===================");
createSkillCategory("Adventuring", Statistic.Dexterity);
createSkill(800, "Nature Survival", "Adventuring", Statistic.Dexterity, 100, false, "");	-- Forest, Grassland, Hills
createSkill(801, "Dungeoneering", "Adventuring", Statistic.Dexterity, 100, false, "");	-- Dungeons, Tombs
createSkill(802, "Swimming", "Adventuring", Statistic.Dexterity, 100, false, "");			-- Lakes, Rivers
createSkill(803, "Streetwise", "Adventuring", Statistic.Dexterity, 100, false, "");		-- Roads, Interior, Paths

-- Advanced Adventuring skills
createSkill(820, "Wilderness Survival", "Adventuring", Statistic.Dexterity, 100, false, "Nature Survival");-- Heavy Forest, Swamps
createSkill(821, "Diving", "Adventuring", Statistic.Dexterity, 100, false, "Swimming");				-- Underwater	
createSkill(822, "Climbing", "Adventuring", Statistic.Dexterity, 100, false, "Dungeoneering");		-- Ravines, Cliffs, Walls, Trees
createSkill(823, "Spelunking", "Adventuring", Statistic.Dexterity, 100, false, "Dungeoneering");		-- Caves
createSkill(824, "Desert Survival", "Adventuring", Statistic.Dexterity, 100, false, "Nature Survival");-- Sand/Dunes/Desert
createSkill(825, "Snow Survival", "Adventuring", Statistic.Dexterity, 100, false, "Nature Survival");	-- Snow/Ice
-- Cloud
-- Mountaineering (Mountains)
-- Navigation/Sailing (Ocean, Deep Water)

-- EOF