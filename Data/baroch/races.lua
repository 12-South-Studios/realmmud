-- BAROCH/RACES.LUA
-- This is the items-file for Baroch
-- Revised: 2012.04.02
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_race.lua")();


systemLog("=================== ZONE 'BAROCH' - NON-PLAYER RACES ===================");
newRace = createRace(21200, "Zombie");
race.this = newRace;
setDescription(race.this, "a horrid decaying corpse");
race.this:AddHitLocation("wear_body");

newRace = createRace(21201, "Skeleton");
race.this = newRace;
setDescription(race.this, "gaunt skeleton with empty eye-sockets");
race.this:AddHitLocation("wear_body");

newRace = createRace(21202, "Skeletal Bear");
race.this = newRace;
setDescription(race.this, "gaunt skeleton of a large bear");
race.this:AddHitLocation("wear_body");

newRace = createRace(21203, "Dog");
race.this = newRace;
setDescription(race.this, "four legs and man's best friend");
race.this:AddHitLocation("wear_body");

newRace = createRace(21204, "Cat");
race.this = newRace;
setDescription(race.this, "Furred and fussy");
race.this:AddHitLocation("wear_body");

newRace = createRace(21205, "Horse");
race.this = newRace;
setDescription(race.this, "four-legged for riding or work");
race.this:AddHitLocation("wear_body");

-- EOF