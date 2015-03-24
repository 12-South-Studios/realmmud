-- BAROCH.LUA
-- This is the zone-file for the Vale of Baroch
-- Revised: 2012.04.02
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


--================ BEGIN ==================
--=========================================
systemLog("=================== ZONE 'BAROCH' INITIALIZING ===================");
zone.this = getEntityByID(2);
zone.this.Name = "Vale of Baroch";
setDescription(zone.this, "The Vale of Baroch, an idyllic valley nestled between high peaks, but beset by the undead.");

-- Repop time = 10 minutes x Segment Length (currently 500 milliseconds)
local segmentLength = GetAppSetting("timeSegment");
setProperty(zone.this, "repop_time", 1200 * segmentLength);


--============= ACCESS LIST ===============
--=========================================
systemLog("=================== ZONE 'BAROCH' - ACCESS LEVELS ===================");
zone.this:CreateAccessLevel("Valley Floor", 1);
zone.this:CreateAccessLevel("Village", 2);
zone.this:CreateAccessLevel("Main Barracks", 4);
zone.this:CreateAccessLevel("Inn", 8);
zone.this:CreateAccessLevel("Graveyard", 16);
zone.this:CreateAccessLevel("Clearing around Village", 32);
zone.this:CreateAccessLevel("Corral", 64);
zone.this:CreateAccessLevel("Villagers House", 128);
zone.this:CreateAccessLevel("Village Wall", 256);
zone.this:CreateAccessLevel("2nd Floor of Inn", 512);


--================ SpaceS ==================
--=========================================
systemLog("=================== ZONE 'BAROCH' - SpaceS ===================");
newSpace = createSpace(20001, "Winding Path");
Space.this = newSpace;
setDescription(Space.this, "This winding wagon path leads through the dense trees down a slope towards a noisy river. The wagon ruts in the ground are deep and look to have been made from years of travel. Grass has begun to grow over them now, an indication that there has been less travel on the path of late.\r\n\r\nAbove you in the distance you can see snow-capped mountains, both to the DirectionType.North and DirectionType.South. Below you deeper in the valley lies a winding and dark river.");
zone.this.Contents:AddEntity(Space.this);

newSpace = cloneSpace(20001, 20002);
zone.this.Contents:AddEntity(newSpace);

newSpace = cloneSpace(20001, 20003);
zone.this.Contents:AddEntity(newSpace);

newSpace = cloneSpace(20001, 20004);
zone.this.Contents:AddEntity(newSpace);

newSpace = cloneSpace(20001, 20005);
zone.this.Contents:AddEntity(newSpace);

newSpace = createSpace(20006, "On the path DirectionType.North of the River");
Space.this = newSpace;
setDescription(Space.this, "This winding wagon path leads up to an ancient bridge that crosses a dark and noisy river. The wagon ruts in the ground are deep and look to have been made from years of travel. Grass has begun to grow over them now, an indication that there has been less travel on the path of late.\r\n\r\nAbove you in the distance you can see snow-capped mountains, both to the DirectionType.North and DirectionType.South. Below you deeper in the valley lies a winding and dark river.");
zone.this.Contents:AddEntity(Space.this);

newSpace = createSpace(20007, "Ancient Bridge");
Space.this = newSpace;
setDescription(Space.this, "This ancient bridge spans the dark and foreboding waters of this unnamed river. Far above you the peak of the mountain is clothed in clouds and snow, but you can hear the screaming of the wind even at this distance. In a small clearing to the DirectionType.East you can see a small village, surrounded by a stark stone wall lies admist the dark, towering trees.\r\n\r\nUpon closer inspection, the bridge looks to be made of locally quarried stone, but appears to have seen its fair share of traffic over the years. The stones, in fact, are slick with the mist from the river and covered in places with green and brown lichen. Near the center of the bridge you can see where ruts have been gouged into the stone by years, if not decades, of wagon wheels.\r\n\r\nThe dark waters of the river race around sharp rocks which dot the surface of the waters, forming rapids and eddies in some places, and creating a heavy mist which cloaks much of the river as far as you can see in both directions. Eddies and sharp rocks dot the surface of the turbulent waters.\r\n\r\nThe path leads both DirectionType.North and DirectionType.South from where you stand. To the DirectionType.North it slopes steeply upwards, but is quickly lost from sight in the dense trees. To the DirectionType.South it leads into a small clearing in which you see a walled village.");
zone.this.Contents:AddEntity(Space.this);

newSpace = cloneSpace(20007, 20008);
zone.this.Contents:AddEntity(newSpace);

newSpace = cloneSpace(20007, 20009);
zone.this.Contents:AddEntity(newSpace);

newSpace = createSpace(20010, "On the path DirectionType.South of the River");
Space.this = newSpace;
setDescription(Space.this, "This winding wagon path leads up to an ancient bridge that crosses a dark and noisy river. The wagon ruts in the ground are deep and look to have been made from years of travel. Grass has begun to grow over them now, an indication that there has been less travel on the path of late.\r\n\r\nAbove you in the distance you can see snow-capped mountains, both to the DirectionType.North and DirectionType.South. Below you deeper in the valley lies a winding and dark river.");
zone.this.Contents:AddEntity(Space.this);

newSpace = cloneSpace(20001, 20011);
zone.this.Contents:AddEntity(newSpace);

newSpace = cloneSpace(20001, 20012);
zone.this.Contents:AddEntity(newSpace);

newSpace = cloneSpace(20001, 20013);
zone.this.Contents:AddEntity(newSpace);

newSpace = cloneSpace(20001, 20014);
zone.this.Contents:AddEntity(newSpace);

newSpace = cloneSpace(20001, 20015);
zone.this.Contents:AddEntity(newSpace);

newSpace = createSpace(20016, "Winding Path");
Space.this = newSpace;
setDescription(Space.this, "This winding wagon path leaves the dark trees and approaches a small hill in a wide clearing. On top of the hill you see a small, walled village. The wagon ruts in the ground are deep and look to have been made from years of travel. Grass has begun to grow over them now, an indication that there has been less travel on the path of late.\r\n\r\nAbove you in the distance you can see snow-capped mountains, both to the DirectionType.North and DirectionType.South. To the DirectionType.North you can hear the sounds of a noisy river.");
zone.this.Contents:AddEntity(Space.this);

newSpace = cloneSpace(20016, 20017);
zone.this.Contents:AddEntity(newSpace);

newSpace = cloneSpace(20016, 20018);
zone.this.Contents:AddEntity(newSpace);

newSpace = cloneSpace(20016, 20019);
zone.this.Contents:AddEntity(newSpace);

newSpace = createSpace(20020, "In front of the Village Gate");
Space.this = newSpace;
setDescription(Space.this, "A towering gatehouse and immense stone wall rise up above this clearing in the trees. Two enormous iron-bound doors block your entrance to the village that lies beyond. Atop the gatehouse you can see the slight movements of guards patrolling the walls and hear the sounds of the village banners flapping in the breeze.\r\n\r\nThe immense wall looks as if it was made from local stone and appears to have seen many years of both weather and battle. Many of the battle scars, however, seem to be relatively new and the shattered pieces of wood and bone lying at the base of the wall seem to confirm this. The huge doors are bound with iron and made of huge timbers, perhaps from the local trees, and seem to be in very poor shape. Great rents in the wood and dents in the iron were probably caused by a battering ram during recent battles around the village.");
setAccess(Space.this, 32);
zone.this.Contents:AddEntity(Space.this);

newSpace = createSpace(20021, "Inside the Village Gate");
Space.this = newSpace;
setDescription(Space.this, "This massive structure engulfs you as you walk beneath its stone arches. Above you in the gloom you can see murder-holes, meant to allow boiling oil to be dropped on invaders and at either end of the gatehouse you can see a raised iron portcullis. The air here in the gatehouse is cool and damp.\r\n\r\nBeneath your feet you can see broken paving stones that appear to be quite old and have seen many years of traffic. Covering much of the stones, however, are bones and other signs of battle, much of it recent.");
setAccess(Space.this, 2);
zone.this.Contents:AddEntity(Space.this);

newSpace = createSpace(20022, "Village Square (DirectionType.SouthDirectionType.West Corner)");
Space.this = newSpace;
setDescription(Space.this, "Broken paving stones and clumps of weeds cover much of what may have once been the busiest portion of this small village. The protective wall surrounding the village and an enormous gatehouse loom not far away and you can see two large war-engines resting atop it. You can hear the clanging of a hammer on an anvil to the DirectionType.North, while a large, foreboding building looms on the other side. The paving stones beneath your feet appear to have been quarried from local stone and show signs of great age and use. Many have been broken by years of weather and wagon traffic.\r\n\r\nTo the DirectionType.West a path leads through two large iron-bound doors and out of the walled village. Smoke and the sounds of hammering emanate from a building to the DirectionType.North while iron bars cover the windows and iron-straps the doors of a large building to the DirectionType.South. A path scattered with broken paving stones, but mostly covered with grass, leads DirectionType.East deeper into the village at the top of the hill.");
setAccess(Space.this, 2);
zone.this.Contents:AddEntity(Space.this);

newSpace = createSpace(20023, "Village Square (DirectionType.NorthDirectionType.West Corner)");
Space.this = newSpace;
setDescription(Space.this, "Broken paving stones and clumps of weeds cover much of what may have once been the busiest portion of this small village. The protective wall surrounding the village and an enormous gatehouse loom not far away and you can see two large war-engines resting atop it. You can hear the clanging of a hammer on an anvil to the DirectionType.North, while a large, foreboding building looms on the other side. The paving stones beneath your feet appear to have been quarried from local stone and show signs of great age and use. Many have been broken by years of weather and wagon traffic.\r\n\r\nStairs lead up to the top of the massive stone wall to the DirectionType.West. Smoke and the sounds of hammering emanate from a building to the DirectionType.North. The rest of the village square stretches DirectionType.East and DirectionType.South from here.");
setAccess(Space.this, 2);
zone.this.Contents:AddEntity(Space.this);

newSpace = createSpace(20024, "Village Square (DirectionType.NorthDirectionType.East Corner)");
Space.this = newSpace;
setDescription(Space.this, "Broken paving stones and clumps of weeds cover much of what may have once been the busiest portion of this small village. The protective wall surrounding the village can be seen to the DirectionType.West across the square. You can also hear the clanging of a hammer on an anvil to the DirectionType.West.\r\n\r\nA large well-kept house looms over the square to the DirectionType.North while a cluttered and yet inviting storefront is to the DirectionType.East. A sign out front indicates that all manner of goods can be purchased inside. The rest of the square stretches DirectionType.South and DirectionType.West from here.");
setAccess(Space.this, 2);
zone.this.Contents:AddEntity(Space.this);

newSpace = createSpace(20025, "Village Square (DirectionType.SouthDirectionType.East Corner)");
Space.this = newSpace;
setDescription(Space.this, "Broken paving stones and clumps of weeds cover much of what may have once been the busiest portion of this small village. The protective wall surrounding the village can be seen to the DirectionType.West across the square. You can also hear the clanging of a hammer on an anvil to the DirectionType.West.\r\n\r\nA corral and stable for horses runs alongside the path to the DirectionType.South. A well-travelled path leads up the hill to the DirectionType.East towards the rest of the village. The rest of the square stretches DirectionType.North and DirectionType.West from here.");
setAccess(Space.this, 2);
zone.this.Contents:AddEntity(Space.this);

newSpace = createSpace(20026, "Blacksmith Shop");
Space.this = newSpace;
setDescription(Space.this, "This building has a low-ceiling, bad lighting, and is filled with the acrid smells of sulfur, smoke and pitch. A large forge dominates the far end of the Space, as does a huge bin filled with iron. An enormous anvil and a rack of hammers sits in the middle of the floor, surrounded by all manner of half-finished and damaged weapons. A large sign with hastily scrawled script hangs near the entrance to the shop and lists the goods that are being sold. Through the door to your DirectionType.South and through a haze of smoke hanging in the air you can see the village square.");
setAccess(Space.this, 2);
zone.this.Contents:AddEntity(Space.this);
 
newSpace = cloneSpace(20026, 20027);
Space.this = newSpace;
setDescription(Space.this, "This building has a low-ceiling, bad lighting, and is filled with the acrid smells of sulfur, smoke and pitch. A large forge dominates this end of the Space, as does a huge bin filled with iron. Through the door to your DirectionType.South and through a haze of smoke hanging in the air you can see the village square.");
zone.this.Contents:AddEntity(Space.this);

newSpace = createSpace(20028, "Village Barracks");
Space.this = newSpace;
setDescription(Space.this, "This large Space has a low-ceiling and is filled with bunks, many of which appear to have been empty for some time. Large racks of weapons and suits of armor line one of the walls and most show signs of frequent use. Large iron-bound doors lead out of the barracks and back to the gatehouse. Large iron bars lay to either side of the doors and look to be used to bar the doors in case of emergency.");
setAccess(Space.this, 4);
zone.this.Contents:AddEntity(Space.this);

newSpace = cloneSpace(20028, 20029);
zone.this.Contents:AddEntity(newSpace);

newSpace = cloneSpace(20028, 20030);
zone.this.Contents:AddEntity(newSpace);

newSpace = cloneSpace(20028, 20031);
zone.this.Contents:AddEntity(newSpace);

newSpace = createSpace(20032, "Large House");
Space.this = newSpace;
setDescription(Space.this, "A large, mostly empty house. A thick layer of dust covers the furniture and the floor.");
setAccess(Space.this, 128);
zone.this.Contents:AddEntity(Space.this);

newSpace = cloneSpace(20032, 20033);
zone.this.Contents:AddEntity(newSpace);

newSpace = createSpace(20034, "General Store");
Space.this = newSpace;
setDescription(Space.this, "This general store's shelves used to be stocked with goods, but the last few months have seen the supplies dwindle as the wagon trains arriving in the village become less frequent. Only a few shelves have anything on them now and even those goods have been picked over by previous travellers.");
setAccess(Space.this, 2);
zone.this.Contents:AddEntity(Space.this);

newSpace = cloneSpace(20034, 20035);
zone.this.Contents:AddEntity(newSpace);

newSpace = createSpace(20036, "Village Road (DirectionType.West of Hill)");
Space.this = newSpace;
setDescription(Space.this, "Broken paving stones and clumps of weeds cover this portion of the once well-traveled road. The path leads up the hill towards an impressive building perched at the top beside a gushing spring. To the DirectionType.South lies the village stables, though there are few horses in the corral. To the DirectionType.West lies the village square and the massive gatehouse and wall.");
setAccess(Space.this, 2);
zone.this.Contents:AddEntity(Space.this);

newSpace = cloneSpace(20036, 20037);
zone.this.Contents:AddEntity(newSpace);

newSpace = cloneSpace(20036, 20038);
zone.this.Contents:AddEntity(newSpace);

newSpace = createSpace(20039, "Stables");
Space.this = newSpace;
setDescription(Space.this, "This is the village stables, though there are no horses in the stocks at the moment. Hay bales are piled up in one corner and several saddles hang on the wall.");
zone.this.Contents:AddEntity(Space.this);

newSpace = createSpace(20040, "Corral");
Space.this = newSpace;
setDescription(Space.this, "This is where the mounts (horses) are kept.");
setAccess(Space.this, 64);
zone.this.Contents:AddEntity(Space.this);

newSpace = cloneSpace(20040, 20041);
zone.this.Contents:AddEntity(newSpace);

newSpace = cloneSpace(20040, 20042);
zone.this.Contents:AddEntity(newSpace);

newSpace = createSpace(20043, "Hilltop");
Space.this = newSpace;
setDescription(Space.this, "Broken paving stones and clumps of weeds cover what was once a heavily traveled road through the center of the village. Years, even decades, of foot and wagon travel have carved ruts into the stone and earth alike. >From this vantage point you can see the entirety of the village in all directions and some of the countryside beyond, though most of it is covered in dense forest. Far above you looms the mountain, its upper slopes covered in snow and swirling clouds.\r\n\r\nA large, multi-storied building to the DirectionType.South obviously serves as the local Inn and from the sounds of laughter and music coming from within, the local tavern as well. Long balconies run the length of the building on all of the floors and it appears as if each Space has its own doorway to the outside. A large sign hanging out front of the building indicates that this establishment serves a threefold purpose; local Inn, tavern and a general store.\r\n\r\nThe grassy path leads in all directions down the hill from your vantage point high atop the hill. To the DirectionType.West you can see the village gate, to the DirectionType.East a large stone building with many columns. To the DirectionType.North the path leads towards some ricketey houses, while to the DirectionType.South wide steps lead up to an open doorway, beyond which several people can be seen dancing to the sounds of laughter and music. A bubbling spring pours out from some stones jutting out of the hill and rush down a stone-lined route towards the river to the DirectionType.North.");
setAccess(Space.this, 2);
zone.this.Contents:AddEntity(Space.this);


--================ EXITS ==================
--=========================================
systemLog("=================== ZONE 'BAROCH' - EXITS ===================");
--connectSpaces(20001, 20138, DirectionType.North, "north;n");
connectSpaces(20001, 20002, DirectionType.South, "south;s");

connectSpaces(20002, 20001, DirectionType.North, "north;n");
connectSpaces(20002, 20003, DirectionType.South, "south;s");

connectSpaces(20003, 20002, DirectionType.North, "north;n");
connectSpaces(20003, 20004, DirectionType.East, "east;e");

connectSpaces(20004, 20003, DirectionType.West, "west;w");
connectSpaces(20004, 20005, DirectionType.South, "south;s");

connectSpaces(20005, 20004, DirectionType.North, "north;n");
connectSpaces(20005, 20006, DirectionType.South, "south;s");

connectSpaces(20006, 20005, DirectionType.North, "north;n");
connectSpaces(20006, 20007, DirectionType.South, "south;s");

connectSpaces(20007, 20006, DirectionType.North, "north;n");
connectSpaces(20007, 20008, DirectionType.South, "south;s");

connectSpaces(20008, 20007, DirectionType.North, "north;n");
connectSpaces(20008, 20009, DirectionType.South, "south;s");

connectSpaces(20009, 20008, DirectionType.North, "north;n");
connectSpaces(20009, 20010, DirectionType.South, "south;s");

connectSpaces(20010, 20009, DirectionType.North, "north;n");
connectSpaces(20010, 20011, DirectionType.South, "south;s");

connectSpaces(20011, 20010, DirectionType.North, "north;n");
connectSpaces(20011, 20012, DirectionType.South, "south;s");

connectSpaces(20012, 20011, DirectionType.North, "north;n");
connectSpaces(20012, 20013, DirectionType.East, "east;e");

--connectSpaces(20013, 20139, DirectionType.East, "east;e");
connectSpaces(20013, 20012, DirectionType.West, "west;w");
connectSpaces(20013, 20014, DirectionType.South, "south;s");

connectSpaces(20014, 20013, DirectionType.North, "north;n");
connectSpaces(20014, 20140, DirectionType.East, "east;e");
connectSpaces(20014, 20015, DirectionType.South, "south;s");

connectSpaces(20015, 20014, DirectionType.North, "north;n");
connectSpaces(20015, 20016, DirectionType.East, "east;e");

--connectSpaces(20016, 20140, DirectionType.North, "north;n");
--connectSpaces(20016, 20148, DirectionType.East, "east;e");
connectSpaces(20016, 20015, DirectionType.West, "west;w");
connectSpaces(20016, 20017, DirectionType.South, "south;s");

connectSpaces(20017, 20016, DirectionType.North, "north;n");
--connectSpaces(20017, 20149, DirectionType.East, "east;e");
connectSpaces(20017, 20018, DirectionType.South, "south;s");

connectSpaces(20018, 20017, DirectionType.North, "north;n");
--connectSpaces(20018, 20150, DirectionType.East, "east;e");
connectSpaces(20018, 20019, DirectionType.South, "south;s");

connectSpaces(20019, 20018, DirectionType.North, "north;n");
connectSpaces(20019, 20020, DirectionType.East, "east;e");
--connectSpaces(20019, 20141, DirectionType.South, "south;s");

--connectSpaces(20020, 20150, DirectionType.North, "north;n");
connectSpaces(20020, 20021, DirectionType.East, "east;e");
connectSpaces(20020, 20019, DirectionType.West, "west;w");
--connectSpaces(20020, 20151, DirectionType.South, "south;s");

connectSpaces(20021, 20020, DirectionType.West, "west;w");
connectSpaces(20021, 20022, DirectionType.East, "east;e");

connectSpaces(20022, 20021, DirectionType.West, "west;w");
connectSpaces(20022, 20023, DirectionType.North, "north;n");
connectSpaces(20022, 20025, DirectionType.East, "east;e");
connectSpaces(20022, 20028, DirectionType.South, "south;s");

connectSpaces(20023, 20026, DirectionType.North, "north;n");
connectSpaces(20023, 20024, DirectionType.East, "east;e");
--connectSpaces(20023, 20087, DirectionType.West, "west;w");
connectSpaces(20023, 20022, DirectionType.South, "south;s");

connectSpaces(20024, 20032, DirectionType.North, "north;n");
connectSpaces(20024, 20034, DirectionType.East, "east;e");
connectSpaces(20024, 20023, DirectionType.West, "west;w");
connectSpaces(20024, 20025, DirectionType.South, "south;s");

connectSpaces(20025, 20024, DirectionType.North, "north;n");
connectSpaces(20025, 20036, DirectionType.East, "esat;e");
connectSpaces(20025, 20022, DirectionType.West, "west;w");

connectSpaces(20026, 20027, DirectionType.North, "north;n");
connectSpaces(20026, 20023, DirectionType.South, "south;s");

connectSpaces(20027, 20026, DirectionType.South, "south;s");

connectSpaces(20028, 20022, DirectionType.North, "north;n");
connectSpaces(20028, 20029, DirectionType.East, "east;e");
--connectSpaces(20028, 20096, DirectionType.West, "west;w");
connectSpaces(20028, 20031, DirectionType.South, "south;s");

connectSpaces(20029, 20028, DirectionType.West, "west;w");
connectSpaces(20029, 20030, DirectionType.South, "south;s");

connectSpaces(20030, 20029, DirectionType.North, "north;n");
connectSpaces(20030, 20031, DirectionType.West, "west;w");

connectSpaces(20031, 20028, DirectionType.North, "north;n");
connectSpaces(20031, 20030, DirectionType.East, "east;e");

connectSpaces(20032, 20033, DirectionType.North, "north;n");
connectSpaces(20032, 20024, DirectionType.South, "south;s");

connectSpaces(20033, 20032, DirectionType.South, "south;s");

connectSpaces(20034, 20035, DirectionType.East, "east;e");
connectSpaces(20034, 20024, DirectionType.West, "west;w");

connectSpaces(20035, 20034, DirectionType.West, "west;w");

connectSpaces(20036, 20037, DirectionType.East, "east;e");
connectSpaces(20036, 20025, DirectionType.West, "west;w");
connectSpaces(20036, 20039, DirectionType.South, "south;s");

connectSpaces(20037, 20038, DirectionType.East, "east;e");
connectSpaces(20037, 20036, DirectionType.West, "west;w");

connectSpaces(20038, 20043, DirectionType.East, "east;e");
connectSpaces(20038, 20037, DirectionType.West, "west;w");

connectSpaces(20039, 20036, DirectionType.North, "north;n");
connectSpaces(20039, 20040, DirectionType.East, "east;e");

connectSpaces(20040, 20039, DirectionType.West, "west;w");
connectSpaces(20040, 20041, DirectionType.South, "south;s");

connectSpaces(20041, 20040, DirectionType.North, "north;n");
connectSpaces(20041, 20042, DirectionType.West, "west;w");

connectSpaces(20042, 20041, DirectionType.East, "east;e");

--connectSpaces(20043, 20056, DirectionType.North, "north;n");
--connectSpaces(20043, 20062, DirectionType.East, "east;e");
connectSpaces(20043, 20038, DirectionType.West, "west;w");
--connectSpaces(20043, 20044, DirectionType.South, "south;s");


--============= TEMPLATES =================
--=========================================
-- ID Range: 21000-21099
if (doScript("baroch\\effects.lua") == false) then
	errorLog("Unable to load effects.lua for baroch zone");
end

-- ID Range: 21100-21199
if (doScript("baroch\\abilities.lua") == false) then
	errorLog("Unable to load abilities.lua for baroch zone");
end

-- ID Range: 21200-21229
if (doScript("baroch\\races.lua") == false) then
	errorLog("Unable to load races.lua for baroch zone");
end

-- ID Range: 21300-21499
if (doScript("baroch\\items.lua") == false) then
	errorLog("Unable to load items.lua for baroch zone");
end

-- ID Range: 21230-21249
if (doScript("baroch\\shops.lua") == false) then
	errorLog("Unable to load shops.lua for baroch zone");
end

-- ID Range: 21250-21299
if (doScript("baroch\\conversations.lua") == false) then
	errorLog("Unable to load conversations.lua for baroch zone");
end
	
-- ID Range: 21500-21699
if (doScript("baroch\\mobs.lua") == false) then
	errorLog("Unable to load mobs.lua for baroch zone");
end

-- ID Range: 21700-21719
if (doScript("baroch\\spawns.lua") == false) then
	errorLog("Unable to load spawns.lua for baroch zone");
end


--================ RESETS =================
if (doScript("baroch\\resets.lua") == false) then
	errorLog("Unable to load resets.lua for baroch zone");
end


--================ FINAL ==================
--=========================================
systemLog("=================== ZONE 'BAROCH' (" .. zone.this.Contents:GetEntityCount() .. " entities) LOADED ===================");

-- EOF