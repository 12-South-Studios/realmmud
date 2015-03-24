-- EFFECTS.LUA
-- This is the effects-file for the Void zone
-- Revised: 2012.03.08
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_effects.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(1);
if (zone.this == nil) then
	errorLog("void\/effects.lua was unable to retrieve a zone object");
	return
end

systemLog("=================== ZONE 'VOID' - EFFECTS ===================");

-- During the Winter Shrouding the element of Shadow is enhanced by 10% while 
-- the complementary elements of Earth and Water are enhanced by 5%.
newEffect = createEffect(4001, "Winter Shrouding", "StatMod");
effect.this = newEffect;
setElementMod(effect.this, "shadow", 10, 10);

-- During the Winter Shrouding the element of Light is penalized by 10% while 
-- the complementary elements of Fire and Air are penalized by 5%.
newEffect = createEffect(4002, "Winter Shrouding", "StatMod");
effect.this = newEffect;
setElementMod(effect.this, "light", 10, 10);

-- During the Summer Shrouding the element of Light is enhanced by 10% while 
-- the complementary elements of Fire and Air are enhanced by 5%.
newEffect = createEffect(4003, "Summer Shrouding", "StatMod");
effect.this = newEffect;
setElementMod(effect.this, "light", 10, 10);

-- During the Winter Shrouding the element of Shadow is penalized by 10% while 
-- the complementary elements of Earth and Water are penalized by 5%.
newEffect = createEffect(4004, "Summer Shrouding", "StatMod");
effect.this = newEffect;
setElementMod(effect.this, "shadow", 10, 10);

-- During the Winter Months (aside from the Winter Shrouding) the element of 
-- Water is in ascendance.
newEffect = createEffect(4005, "Winter Ascendance", "StatMod");
effect.this = newEffect;
setElementMod(effect.this, "water", 5, 5);

-- During the Spring Months the element of Air is in ascendance.
newEffect = createEffect(4006, "Spring Ascendance", "StatMod");
effect.this = newEffect;
setElementMod(effect.this, "air", 5, 5);

-- During the Summer Months (aside from the Summer Shrouding) the element of 
-- Fire is in ascendance.
newEffect = createEffect(4007, "Summer Ascendance", "StatMod");
effect.this = newEffect;
setElementMod(effect.this, "fire", 5, 5);

-- During the Fall Months the element of Earth is in ascendance.
newEffect = createEffect(4008, "Fall Ascendance", "StatMod");
effect.this = newEffect;
setElementMod(effect.this, "earth", 5, 5);

-- Some Generic Weather Effects
newEffect = createEffect(4009, "Test Weather", "StatMod");
effect.this = newEffect;

-- Ability Effects
newEffect = createEffect(4100, "1-H Weapon", "HealthChange");
effect.this = newEffect;
setHealthChange(effect.this, "damage", 4, 8, "weapon");

-- 

-- EOF