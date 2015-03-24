-- SETUP.LUA
-- Main MUD Setup file
-- Revised: 2012.03.03
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


systemLog("=================== REALMMUD SETUP - INITIALIZING ===================");


--=============== CONSTANTS ===============
--=========================================
systemLog("================= REALMMUD SETUP - CONSTANTS =================");
-- Basic Game Values
setGameProperty("tp_per_level", 10);					-- TrainingPoints gained per level
setGameProperty("base_xp", 1000);						-- Base XP Required for a level
setGameProperty("xp_step", 500);						-- XP Step Multiplier
														-- XP Calculation:  (level x base_xp) + ((level - 1) x xp_step)
setGameProperty("base_monster_xp", 100);				-- Base XP for Monster Reward
setGameProperty("monster_xp_step", 25);					-- XP Step Multiplier
														-- Monster XP Calculation: (level x base_monster_xp) + ((level - 1) x monster_xp_step)
setGameProperty("player_level_higher_xp_mod", 25);		-- Percent the XP Reward is lowered by if the player's level is higher than the monster
setGameProperty("player_level_lower_xp_mod", 10);		-- Percent the XP Reward is raised by if the player's level is lower than the monster
setEnumGameProperty(MonsterClass.Minion, 25);			-- XP Multiplier for Minion Monsters
setEnumGameProperty(MonsterClass.Strong, 125);			-- XP Multiplier for Strong Monsters
setEnumGameProperty(MonsterClass.Elite, 200);			-- XP Multiplier for Elite Monsters
setEnumGameProperty(MonsterClass.Boss, 325);			-- XP Multiplier for Boss Monsters
setEnumGameProperty(MonsterClass.EliteBoss, 500);		-- XP Multiplier for Elite Boss Monsters

-- Terrain Values
setGameProperty("terrain_skill_lvl_1_reduction", 25);	-- cost reduction for first skill level
setGameProperty("terrain_skill_lvl_1_rating", 40);		-- minimum skill for reduction
setGameProperty("terrain_skill_lvl_2_reduction", 50);	
setGameProperty("terrain_skill_lvl_2_rating", 70);		
setGameProperty("terrain_skill_lvl_3_reduction", 75);
setGameProperty("terrain_skill_lvl_3_rating", 100);

-- Stat Related Values
setGameProperty("base_noncombat_health_regen_rate", 8);	-- Rate at which health regens outside of combat (plus vitality/endurance mods)
setGameProperty("base_combat_health_regen_rate", 3);	-- Rate at which health regens inside of combat (plus vitality/endurance mods)
setGameProperty("base_noncombat_mana_regen_rate", 5);	-- Rate at which mana regens outside of combat (plus vitality mod)
setGameProperty("base_combat_mana_regen_rate", 1);		-- Rate at which mana regens inside of combat (plus vitality mod)
setGameProperty("base_noncombat_stamina_regen_rate", 5);-- Rate at which stamina regens outside of combat (plus endurance mod)
setGameProperty("base_combat_stamina_regen_rate", 1);	-- Rate at which stamina regens inside of combat (plus endurance mod)

-- Training Values
setGameProperty("health_tp_ratio", 10);					-- TrainingPoint to HealthPoint Ratio (how much Health you get per TP)
setGameProperty("mana_tp_ratio", 10);					-- TrainingPoint to ManaPoint Ratio (how much Mana you get per TP)
setGameProperty("stamina_tp_ratio", 10);				-- TrainingPoint to StaminaPoint Ratio (how much Stamina you get per TP)
setGameProperty("stat_tp_ratio", 7);					-- TrainingPoint to StatPoint Ratio (cost in TP to train a statistic 1 point)
setGameProperty("preferred_skill_tp_ratio", 4);			-- TrainingPoint to SkillPoint Ratio for Preferred Skills (cost in TP to train a preferred skill 1 point)
setGameProperty("normal_skill_tp_ratio", 7);			-- TrainingPoint to SkillPoint Ratio for Normal (non-preferred Skills) (cost in TP to train a non-preferred skill 1 point)

-- Combat Values
setGameProperty("max_avoidance", 15);					-- Max Avoidance %
setGameProperty("default_interrupt_chance", 25);		-- Default % chance for an interruptible ability to be interrupted when the user is hit (before mods)
setGameProperty("default_autoattack_delay", 5);			-- Default Delay (in seconds) of an auto-attack ability

-- Other Values
setGameProperty("currency_ratio", 1000);				-- Base currency ratio for each currency level (copper -> silver -> gold -> etc)
setGameProperty("max_thirst", 1440);


--================ FLAGS ==================
--=========================================
systemLog("=================== REALMMUD SETUP - FLAGS ===================");
createFlag("Admin", "A", true);
createFlag("Builder", "B", true);
createFlag("Channel", "C", false);
-- D
createFlag("Exit", "E", false);
createFlag("Away-From-Keyboard", "F", true);
createFlag("Garbage", "G", true);
createFlag("Hidden", "H", true);
createFlag("Item", "I", false);
createFlag("Effect", "J", false);
-- K
-- L
createFlag("Mob", "M", false);
createFlag("Shop", "N", false);
-- O
createFlag("Player", "P", false);
createFlag("Ability", "Q", false);
createFlag("Space", "R", false);
createFlag("Spawn", "S", false);
createFlag("Tavern", "T", false);
createFlag("User", "U", false);
createFlag("Merchant", "V", false);
createFlag("Wizard", "W", true);
createFlag("Immortal", "X", true);
createFlag("Shrine", "Y", false);
createFlag("Zone", "Z", false);

createFlag("Armor", "a", false);
-- b
createFlag("Container", "c", false);
createFlag("Dark", "d", true);
createFlag("Food", "e", false);
createFlag("Furniture", "f", false);
-- g
-- h
createFlag("Instance", "i", false);
createFlag("Jewelry", "j", false);
createFlag("Key", "k", false);
createFlag("Drink Container", "l", false);
createFlag("Machine", "m", false);
createFlag("Resource Node", "n", false);
createFlag("Scroll", "o", false);
createFlag("Potion", "p", false);
createFlag("Formula", "q", false);
createFlag("Resource", "r", false);
createFlag("Spell", "s", false);
createFlag("Tool", "t", false);
createFlag("Boat", "u", false);
createFlag("Light", "v", false);
createFlag("Weapon", "w", false);
createFlag("Safe", "x", true);
createFlag("Corpse", "y", false);
createFlag("Stopped", "z", true);


--============== MATERIALS ================
--=========================================
systemLog("=================== REALMMUD SETUP - MATERIALS ===================");
createMaterial("Rope");
createMaterial("Pottery");
createMaterial("Paper");
createMaterial("Cloth");
createMaterial("Bone");
createMaterial("Flesh");
createMaterial("Thin Glass");
createMaterial("Thick Glass");
createMaterial("Leather");
createMaterial("Soft Metal");
createMaterial("Hard Metal");
createMaterial("Brittle Rock");
createMaterial("Hard Rock");
createMaterial("Thick Wood");
createMaterial("Thin Wood");
createMaterial("Organic");
createMaterial("Liquid");

	
--============== COMMANDS =================
--=========================================
if (doScript("setup\\commands.lua") == false) then
	errorLog("Unable to load commands.lua");
	return
end

if (doScript("setup\\socials.lua") == false) then
	errorLog("Unable to load socials.lua");
	return
end


--============== CHANNELS =================
--=========================================
if (doScript("setup\\channels.lua") == false) then
	errorLog("Unable to load channels.lua");
	return
end


--============ ELEMENT TYPES ==============
--=========================================
systemLog("=================== REALMMUD SETUP - ELEMENT TYPES ===================");
createElement(1, "Void", 0, 0, 0);
createElement(2, "Light", 3, 4, 6);
createElement(3, "Shadow", 2, 5, 7);
createElement(4, "Fire", 7, 5, 2);
createElement(5, "Earth", 6, 4, 3);
createElement(6, "Air", 5, 2, 7);
createElement(7, "Water", 4, 6, 3);


--============= ITEM TYPES ================
--=========================================
systemLog("=================== REALMMUD SETUP - ITEM TYPES ===================");
createItemType("Weapon", 1);
createItemType("Armor", 2);
createItemType("Light", 4);
createItemType("Container", 8);
createItemType("Drink Container", 16);
createItemType("Key", 32);
createItemType("Tool", 64);
createItemType("Machine", 128);
createItemType("Resource", 256);
createItemType("Furniture", 512);
createItemType("Book", 1024);
createItemType("Vehicle", 2048);
createItemType("Corpse", 4096);
createItemType("Reagant", 8192);
createItemType("Portal", 16384);
createItemType("Food", 32768);
createItemType("Treasure", 65536);
createItemType("Potion", 131072);
createItemType("Resource Node", 262144);
createItemType("Formula", 524288);
createItemType("Rune", 1048576);
createItemType("Lock", 2097152);
createItemType("Trap", 4194304);
createItemType("Quest Item", 8388608);
createItemType("Magical Node", 16777216);


--============= ENTITY TAGS ===============
--=========================================
if (doScript("setup\\tags.lua") == false) then
	errorLog("Unable to load tags.lua");
	return
end


--========= EFFECT TYPES ============
--=========================================
systemLog("=================== REALMMUD SETUP - EFFECT TYPES ===================");
createEffectType("Base");
createEffectType("Ablative");
createEffectType("ChangePosition");
createEffectType("DamageShield");
createEffectType("DrainStat");
createEffectType("GiveAbility");
createEffectType("GiveEntity");
createEffectType("GiveSkill");
createEffectType("HealthChange");
createEffectType("HealthChangeOverTime");
createEffectType("SpaceEffect");
createEffectType("StatMod");
createEffectType("StatModChangeOverTime");
createEffectType("StatusEffect");
createEffectType("Teleport");
createEffectType("TemporaryEntity");
createEffectType("TimedEffect");


--============= TOOL TYPES ================
--=========================================
systemLog("=================== REALMMUD SETUP - TOOL TYPES ===================");
createToolType("logging");
createToolType("gathering");
createToolType("mining");


--============ MACHINE TYPES ==============
--=========================================
systemLog("=================== REALMMUD SETUP - MACHINE TYPES ===================");
createMachineType("woodworking");
createMachineType("smelting");



--============ TERRAIN TYPES ==============
--=========================================
if (doScript("setup\\terrain.lua") == false) then
	errorLog("Unable to load terrain.lua");
	return
end


--=========== WEAR LOCATIONS ==============
--=========================================
systemLog("=================== REALMMUD SETUP - WEAR LOCATIONS ===================");
createWearLocation("wear_head", 1, "Head", "Worn on Head");
createWearLocation("wear_face", 2, "Face", "Worn on Face");
createWearLocation("wear_ear_left", 4, "Left Ear", "Worn in Left Ear");
createWearLocation("wear_ear_right", 8, "Right Ear", "Worn in Right Ear");
createWearLocation("wear_brow", 16, "Brow", "Worn on Brow");
createWearLocation("wear_neck", 32, "Neck", "Worn about Neck");
createWearLocation("wear_wrist_left", 64, "Left Wrist", "Worn on Left Wrist");
createWearLocation("wear_wrist_right", 128, "Right Wrist", "Worn on Right Wrist");
createWearLocation("wear_wrist_both", 256, "Both Wrists", "Worn on Both Wrists");
createWearLocation("wear_hand_left", 512, "Left Hand", "Held in Left Hand");
createWearLocation("wear_hand_right", 1024, "Right Hand", "Held in Right Hand");
createWearLocation("wear_hand_both", 2048, "Both Hands", "Held in Both Hands");
createWearLocation("wear_finger_left", 4096, "Left Ring Finger", "Worn on Left Ring Finger");
createWearLocation("wear_finger_right", 8192, "Right Ring Finger", "Worn on Right Ring Finger");
createWearLocation("wear_chest", 16384, "Chest", "Worn on Torso");
createWearLocation("wear_back", 32768, "Back", "Worn on Back");
createWearLocation("wear_waist", 65536, "Waist", "Worn about Waist");
createWearLocation("wear_legs", 131072, "Legs", "Worn on Legs");
createWearLocation("wear_arms", 262144, "Arms", "Worn on Arms");
createWearLocation("wear_ankle_left", 524288, "Left Ankle", "Worn on Left Ankle");
createWearLocation("wear_ankle_right", 1048576, "Right Ankle", "Worn on Right Ankle");
createWearLocation("wear_ankle_both", 2097152, "Both Ankles", "Worn on Both Ankles");
createWearLocation("wear_feet", 4194304, "Feet", "Worn on Feet");
createWearLocation("wear_body", 8388608, "Body", "Worn about Body");


--============= SKILLS ================
--=========================================
if (doScript("setup\\skills.lua") == false) then
	errorLog("Unable to load skills.lua");
	return
end


--=============== LIQUIDS =================
--=========================================
if (doScript("setup\\liquids.lua") == false) then
	errorLog("Unable to load liquids.lua");
	return
end


--=============== POISONS =================
--=========================================
--systemLog("=================== REALMMUD SETUP - POISONS ===================");
--if (doScript("setup\\poisons.lua") == false) then
--	errorLog("Unable to load poisons.lua");
--	return
--end


--=============== SPELLS =================
--=========================================
--systemLog("=================== REALMMUD SETUP - SPELLS ===================");
--if (doScript("setup\\spells.lua") == false) then
--	errorLog("Unable to load spells.lua");
--	return
--end


--=============== PROGS =================
--=========================================
--systemLog("=================== REALMMUD SETUP - PROGS ===================");
--if (doScript("setup\\mudprogs.lua") == false) then
--	errorLog("Unable to load mudprogs.lua");
--	return
--end


--================ ZONES ==================
--=========================================
systemLog("=================== REALMMUD SETUP - ZONES ===================");
void = createZone(1, "void");
if (loadZone(void) == false) then
	errorLog("Unable to load void.lua zone");
	return
end

baroch = createZone(2, "baroch");
if (loadZone(baroch) == false) then
	errorLog("Unable to load baroch.lua zone");
	return
end

-- Connect zones to each other
if (doScript("links.lua") == false) then
	errorLog("Unable to process links.lua");
	return
end


--=============== HELP =================
--=========================================
if (doScript("setup\\help.lua") == false) then
	errorLog("Unable to load help.lua");
	return
end


--============ STATIC STRINGS =============
--=========================================
if (doScript("setup\\strings.lua") == false) then
	errorLog("Unable to load strings.lua");
	return
end


-- FINAL
systemLog("=================== REALMMUD SETUP - COMPLETE ===================");

-- EOF
