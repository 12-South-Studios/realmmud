-- TAGS.LUA
-- This is the tags data file
-- Revised: 2012.03.08
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


systemLog("=================== REALMMUD SETUP - TAGS ===================");
-- Zone Tags
createTag("system");
createTag("player");

-- Space Tags
createTag("underground");

-- Barrier Tags
createTag("wood");
createTag("stone");
createTag("metal");

-- Generic Tags
createTag("light");
createTag("shadow");
createTag("fire");
createTag("air");
createTag("water");
createTag("earth");
createTag("void");
createTag("martial");
createTag("magical");

-- Item Tags
createTag("light");
createTag("heavy");
createTag("cloth");
createTag("hide");
createTag("leather");
createTag("chain");
createTag("scale");
createTag("ring");
createTag("plate");
createTag("weapon");
createTag("implement");
createTag("shield");
createTag("helm");

-- Ability Tags
createTag("arcane");
createTag("mystical");
createTag("divine");
createTag("aoe");
createTag("friendly");
createTag("hostile");
createTag("ranged");

-- Effect Tags
createTag("crush");
createTag("slash");
createTag("pierce");
createTag("healing");
createTag("burn");
createTag("freeze");
createTag("disease");
createTag("fear");
createTag("poison");
createTag("spirit");
createTag("acid");
createTag("zone");
createTag("global");
createTag("buff");
createTag("debuff");

-- NPC Tags
createTag("elemental");
createTag("natural");
createTag("aberrant");
createTag("fey");
createTag("immortal");
createTag("undead");
createTag("construct");
createTag("animate");
createTag("dragon");
createTag("humanoid");
createTag("beast");
createTag("tiny");
createTag("small");
createTag("medium");
createTag("large");
createTag("huge");
createTag("gargantuan");
createTag("swarm");
createTag("blind");
createTag("spider");
createTag("reptile");

-- EOF