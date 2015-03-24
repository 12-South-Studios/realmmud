-- VOID/ABILITIES.LUA
-- This is the abilities-file for The Void
-- Revised: 2012.02.20
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_abilities.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(1);
if (zone.this == nil) then
	errorLog("void\/abilities.lua was unable to retrieve a zone object");
	return
end

systemLog("=================== ZONE 'VOID' - HUMANOID ABILITIES ===================");
-- ID RAnge: 3000-3499
newAbility = createAbility(3000, "1-H Weapon Attack");
ability.this = newAbility;
setDescription(ability.this, "1-Handed Weapon Attack");
setAbilityProperties(ability.this, 0, 5); 
setOffensiveSkill(ability.this, "1-h weapons");
setDefensiveStat(ability.this, "defense");
ability.this.Bits:SetBit(AUTO_ATTACK);
ability.this.Bits:SetBit(WEAPON_REQUIRED);

newAbility = createAbility(3001, "2-Handed Weapon Attack");
ability.this = newAbility;
setDescription(ability.this, "2-Handed Weapon Attack");
setAbilityProperties(ability.this, 0, 5); 
setOffensiveSkill(ability.this, "2-h weapons");
setDefensiveStat(ability.this, "defense");
ability.this.Bits:SetBit(AUTO_ATTACK);
ability.this.Bits:SetBit(WEAPON_REQUIRED);

newAbility = createAbility(3002, "Ranged Weapon Attack");
ability.this = newAbility;
setDescription(ability.this, "Ranged Weapon Attack");
setAbilityProperties(ability.this, 0, 5); 
setOffensiveSkill(ability.this, "ranged weapons");
setDefensiveStat(ability.this, "defense");
ability.this.Bits:SetBit(AUTO_ATTACK);
ability.this.Bits:SetBit(WEAPON_REQUIRED);


systemLog("=================== ZONE 'VOID' - MONSTER ABILITIES ===================");
-- ID Range: 3500 - 3999
newAbility = createAbility(3500, "Deer Kick Attack");
ability.this = newAbility;
setAbilityProperties(ability.this, 0, 5);
setOffensiveSkill(ability.this, "unarmed");
setDefensiveStat(ability.this, "defense");
ability.this.Bits:SetBit(AUTO_ATTACK);

-- bear claw (slash 1-3)
-- bear bite (pierce 1-6)

-- EOF