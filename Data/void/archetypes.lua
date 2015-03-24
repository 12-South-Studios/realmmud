-- ARCHETYPES.LUA
-- This is the archetypes data file for the void zone
-- Revised: 2012.03.05
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();

dataManager = GetSingleton("datamanager");

-- First, make sure I have the zone
zone.this = getEntityByID(1);
if (zone.this == nil) then
	errorLog("void\/archetypes.lua was unable to retrieve a zone object");
	return
end

systemLog("=================== ZONE 'VOID' - ARCHETYPES ===================");
newArchetype = createArchetype(1, "Soldier");
archetype.this = newArchetype;
archetype.this:AddPreferredSkillCategory(dataManager, "1-H Weapons");
archetype.this:AddPreferredSkillCategory(dataManager, "Shields");
archetype.this:AddPreferredSkillCategory(dataManager, "Heavy Armor");
archetype.this.AutoAttackAbility = 3000;

newArchetype = createArchetype(2, "Barbarian");
archetype.this = newArchetype;
archetype.this:AddPreferredSkillCategory(dataManager, "2-H Weapons");
archetype.this:AddPreferredSkillCategory(dataManager, "Light Armor");
archetype.this.AutoAttackAbility = 3001;

newArchetype = createArchetype(3, "Scout");
archetype.this = newArchetype;
archetype.this:AddPreferredSkillCategory(dataManager, "Unarmed");
archetype.this:AddPreferredSkillCategory(dataManager, "Ranged Weapons");
archetype.this:AddPreferredSkillCategory(dataManager, "Light Armor");
archetype.this.AutoAttackAbility = 3002;

-- EOF