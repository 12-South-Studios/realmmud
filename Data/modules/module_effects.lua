-- MODULE_EFFECTS.LUA
-- This is the Effects Module for the MUD
-- Revised: 2012.03.07
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


function setSkillMod(effect, skill, minValue, maxValue)
	setProperty(effect, "statistic", "skill");
	setProperty(effect, "skill", skill);
	setProperty(effect, "min_value", minValue);
	setProperty(effect, "max_value", maxValue);	
end

function setStatMod(effect, stat, minValue, maxValue)
	setProperty(effect, "statistic", skill);
	setProperty(effect, "min_value", minValue);
	setProperty(effect, "max_value", maxValue);	
end

function setElementMod(effect, element, minValue, maxValue)
	setProperty(effect, "statistic", "element");
	setProperty(effect, "element", element);
	setProperty(effect, "min_value", minValue);
	setProperty(effect, "max_value", maxValue);
end

function setHealthChange(effect, changeType, minDamage, maxDamage, damageType)
	setProperty(effect, "health_change_type", changeType);
	setProperty(effect, "min_damage", minDamage);
	setProperty(effect, "max_damage", maxDamage);
	setProperty(effect, "damage_type", damageType);
end

function setEffectOnApplicationText(effect, self_text, other_text)
	setProperty(effect, "application_text_self", self_text);
	setProperty(effect, "application_text_other", other_text);
end

function setEffectOnFadeText(effect, self_text, other_text)
	setProperty(effect, "fade_text_self", self_text);
	setProperty(effect, "fade_text_other", other_text);
end

function setEffectResist(effect, stat, onFailEffect, onResistEffect)
	setProperty(effect, "resist_stat", stat);
	setProperty(effect, "onfail_Effect_id", onFailEffect);
	setProperty(effect, "onresist_Effect_id", onResistEffect);
end

-- EOF
