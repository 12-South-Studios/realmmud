-- VOID/RACES.LUA
-- This is the items-file for The Void
-- Revised: 2012.03.02
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_race.lua")();

-- Player Race ID range is 101 to 200
-- Non-Player Race ID range is 201 to 499

systemLog("=================== ZONE 'VOID' - PLAYER RACES ===================");
newRace = createRace(101, "Human");
race.this = newRace;
setDescription(race.this, "Your average run-of-the-mill human comes in many heights, shapes, and colors.  In Cardolania they average 5 ½ to 6 feet tall with dark hair and eyes and a more olive (e.g. Mediterranean) complexion.");
setRaceDetails(race.this, true, 100, 20, 20);
race.this:AddHitLocation("wear_head");
race.this:AddHitLocation("wear_face");
race.this:AddHitLocation("wear_neck");
race.this:AddHitLocation("wear_hand_left");
race.this:AddHitLocation("wear_hand_right");
race.this:AddHitLocation("wear_chest");
race.this:AddHitLocation("wear_waist");
race.this:AddHitLocation("wear_legs");
race.this:AddHitLocation("wear_arms");
race.this:AddHitLocation("wear_feet");

newRace = cloneRace(101, 102, "Dwarf");
race.this = newRace;
setDescription(race.this, "Known as the Taemier, all Dwarves hail originally from either The Empire or the Spine Mountains.  There are five races of Dwarves, but only one can ever be found outside of The Empire except in time of war – The Khamir. Khamir literally means   Khamir are usually 4 to 4 ½ feet in height, a stocky build, and have dark hair and eyes and a pale complexion.");
setRaceDetails(race.this, true, 100, 10, 30);

newRace = cloneRace(101, 103, "Caorlei");
race.this = newRace;
setDescription(race.this, "One of the four races of the Kaerove (which means “The Blood” in the language of the Elves), the Caorlei are the tallest of the Elves, averaging 6 ½ to 7 feet in height, and are often referred to as the Golden Elves.  They have a slim build, white or blonde hair, gray or sometimes golden eyes, and are almost universally pale.");
setRaceDetails(race.this, true, 90, 30, 20);

newRace = cloneRace(101, 104, "Teralei");
race.this = newRace;
setDescription(race.this, "One of the most common of the races of the Kaerove (which means “The Blood” in the language of the Elves), the Teralei or Silver Elves as they are sometimes called average 6 to 6 ½ feet in height with silver hair, blue eyes, and a pale complexion.");
setRaceDetails(race.this, true, 95, 25, 20);

newRace = cloneRace(101, 105, "Denorlei");
race.this = newRace;
setDescription(race.this, "The Denorlei, known as the Green Elves, are the shortest of the Kaerove (which means “The Blood” in the language of the Elves), averaging 5 to 5 ½ feet in height with jet black hair, eyes that can be violet or even jade in color, and a dark complexion.");
setRaceDetails(race.this, true, 95, 15, 30);

newRace = cloneRace(101, 106, "Gnome");
race.this = newRace;
setDescription(race.this, "Gnomes are a rare people in Cardolania or anywhere in the west.  They are a secretive race that, like the Dwarves, rarely reveals their secrets to outsiders.  Unlike the Dwarves, however, they are also more peaceful and prefer to spend their time in scholarly pursuits.  Gnomes average 4 to 4 ½ feet in height, but have a less stocky build than the common Dwarf.  They have dark hair, dark eyes and a dark complexion.");
setRaceDetails(race.this, true, 105, 15, 20);

newRace = cloneRace(101, 107, "Goblin");
race.this = newRace;
setDescription(race.this, "The Goblins are an energetic race that can be found across the world but often in the slums because many races shun them.  The slums are where the goblins prefer to be, however, where they are out of sight and therefore out of mind and they can conduct their business without distraction and interruption.\r\n\r\nGoblins are the smallest of the races, averaging 3 ½ to 4 feet in height.  They have brightly colored hair and eyes, often greens and blues or even red or orange, and a green complexion that ranges from a pale green to a dark green, depending upon their heritage.");
setRaceDetails(race.this, true, 110, 10, 20);


systemLog("=================== ZONE 'VOID' - NON-PLAYER RACES ===================");
newRace = createRace(201, "Deer");
race.this = newRace;
setDescription(race.this, "Light brown deer");
race.this:AddHitLocation("wear_body");

-- EOF