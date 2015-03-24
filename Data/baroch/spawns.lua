-- BAROCH/SPAWNS.LUA
-- This is the spawns-file for the Vale of Baroch
-- Revised: 2012.04.02
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();

entityManager = GetSingleton("entitymanager");

-- First, make sure I have the zone
zone.this = getEntityByID(2);
if (zone.this == nil) then
	errorLog("baroch\\spawns.lua was unable to retrieve a zone object");
	return
end


systemLog("=================== ZONE 'BAROCH' - SPAWNS ===================");

-- Trees outside in the forest
newSpawn = createSpawn(21700, "Forest");
if (newSpawn ~= nil) then
	spawn.this = newSpawn;
	
	newLocation = spawn.this:CreateLocation(1, "Forest");
	if (newLocation ~= nil) then
		location.this = newLocation;
		location.this:SetType("access");
		location.this.Value = 1;
	else
		errorLog("Baroch\\Spawns.lua -> Unable to create Location[1] for Spawn[21700]");
	end
	
	newProfile = spawn.this:CreateProfile(1, "Oak Tree");
	if (newProfile ~= nil) then
		profile.this = newProfile;
		profile.this:AddEntity(entityManager, 2800);		-- Oak Tree
		profile.this.MinQuantity = 8;
		profile.this.MaxQuantity = 20;
		profile.this.Chance = 50;
		profile.this.Location = location.this;
	else
		errorLog("Baroch\\Spawns.lua -> Unable to create Profile[1] for Spawn[21700]");
	end
	
	zone.this.Contents:AddEntity(spawn.this);
end

-- EOF