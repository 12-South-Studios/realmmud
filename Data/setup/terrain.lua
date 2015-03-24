-- TERRAIN.LUA
-- This is the terrain data file
-- Revised: 2012.03.24
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


systemLog("=================== REALMMUD SETUP - TERRAIN ===================");
newTerrain = createTerrain("Void");
terrain.this = newTerrain;
terrain.this.Cost = 0;
terrain.this.IsLitBySun = false;
terrain.this.Description = "Nothingness, empty";

-- Town terrains
newTerrain = createTerrain("Dirt Path");
terrain.this = newTerrain;
terrain.this.Cost = 2;
terrain.this.Skill = "streetwise";
terrain.this.IsLitBySun = true;
terrain.this.Description = "A rough path of beaten dirt";
terrain.this:AddRestrictedMovementMode(MovementMode.Swimming);
terrain.this:AddRestrictedMovementMode(MovementMode.Climbing);

newTerrain = createTerrain("Cobblestone Road");
terrain.this = newTerrain;
terrain.this.Cost = 1;
terrain.this.Skill = "streetwise";
terrain.this.IsLitBySun = true;
terrain.this.Description = "A road of carefully placed cobblestones";
terrain.this:AddRestrictedMovementMode(MovementMode.Swimming);
terrain.this:AddRestrictedMovementMode(MovementMode.Climbing);

newTerrain = createTerrain("Interior");
terrain.this = newTerrain;
terrain.this.Cost = 1;
terrain.this.Skill = "streetwise";
terrain.this.IsLitBySun = false;
terrain.this.Description = "The interior of a structure";
terrain.this:AddRestrictedMovementMode(MovementMode.Swimming);
terrain.this:AddRestrictedMovementMode(MovementMode.Climbing);

newTerrain = createTerrain("Stone Wall");
terrain.this = newTerrain;
terrain.this.Cost = 5;
terrain.this.Skill = "climbing";
terrain.this.IsLitBySun = true;
terrain.this.Description = "A wall of stacked stone.";
terrain.this:AddRestrictedMovementMode(MovementMode.Climbing);

-- Wilderness Terrain
newTerrain = createTerrain("Grassland");
terrain.this = newTerrain;
terrain.this.Cost = 2;
terrain.this.Skill = "pathfinding";
terrain.this.IsLitBySun = true;
terrain.this.Description = "Flowing knee-high grass";
terrain.this:AddRestrictedMovementMode(MovementMode.Swimming);
terrain.this:AddRestrictedMovementMode(MovementMode.Climbing);

newTerrain = createTerrain("Light Forest");
terrain.this = newTerrain;
terrain.this.Cost = 5;
terrain.this.Skill = "pathfinding";
terrain.this.IsLitBySun = true;
terrain.this.Description = "A forest of smaller, younger trees";
terrain.this:AddRestrictedMovementMode(MovementMode.Swimming);
terrain.this:AddRestrictedMovementMode(MovementMode.Climbing);

newTerrain = createTerrain("Heavy Forest");
terrain.this = newTerrain;
terrain.this.Cost = 10;
terrain.this.Skill = "nature"; 
terrain.this.IsLitBySun = true;
terrain.this.Description = "A forest of older larger trees";
terrain.this:AddRestrictedMovementMode(MovementMode.Flying);
terrain.this:AddRestrictedMovementMode(MovementMode.Swimming);
terrain.this:AddRestrictedMovementMode(MovementMode.Climbing);

newTerrain = createTerrain("Primeval Forest");
terrain.this = newTerrain;
terrain.this.Cost = 20;
terrain.this.Skill = "nature";
terrain.this.IsLitBySun = true;
terrain.this.Description = "An ancient forest of huge, primeval trees";
terrain.this:AddRestrictedMovementMode(MovementMode.Flying);
terrain.this:AddRestrictedMovementMode(MovementMode.Swimming);
terrain.this:AddRestrictedMovementMode(MovementMode.Climbing);

newTerrain = createTerrain("Massive Tree");
terrain.this = newTerrain;
terrain.this.Cost = 20;
terrain.this.Skill = "climbing";
terrain.this.IsLitBySun = true;
terrain.this.Description = "The trunk or branch of a massive tree.";
terrain.this:AddRestrictedMovementMode(MovementMode.Climbing);

-- Water Terrain

-- Underground Terrain
newTerrain = createTerrain("Smooth Cave");
terrain.this = newTerrain;
terrain.this.Cost = 2;
terrain.this.Skill = "dungeoneering";
terrain.this.IsLitBySun = false;
terrain.this.Description = "The interior of a worn cave";
terrain.this:AddRestrictedMovementMode(MovementMode.Flying);
terrain.this:AddRestrictedMovementMode(MovementMode.Swimming);
terrain.this:AddRestrictedMovementMode(MovementMode.Climbing);

newTerrain = createTerrain("Rough Cave");
terrain.this = newTerrain;
terrain.this.Cost = 5;
terrain.this.Skill = "spelunking";
terrain.this.IsLitBySun = false;
terrain.this.Description = "The interior of a rough cave";
terrain.this:AddRestrictedMovementMode(MovementMode.Flying);
terrain.this:AddRestrictedMovementMode(MovementMode.Swimming);
terrain.this:AddRestrictedMovementMode(MovementMode.Climbing);

-- Desert Terrain
newTerrain = createTerrain("Desert");
terrain.this = newTerrain;
terrain.this.Cost = 5;
terrain.this.Skill = "desert survival";
terrain.this.IsLitBySun = true;
terrain.this.Description = "Sandy desert";
terrain.this:AddRestrictedMovementMode(MovementMode.Flying);
terrain.this:AddRestrictedMovementMode(MovementMode.Swimming);
terrain.this:AddRestrictedMovementMode(MovementMode.Climbing);

-- Swamp Terrain
newTerrain = createTerrain("Marsh");
terrain.this = newTerrain;
terrain.this.Cost = 6;
terrain.this.Skill = "pathfinding";
terrain.this.IsLitBySun = true;
terrain.this.Description = "Wet, sodden ground.";
terrain.this:AddRestrictedMovementMode(MovementMode.Flying);
terrain.this:AddRestrictedMovementMode(MovementMode.Swimming);
terrain.this:AddRestrictedMovementMode(MovementMode.Climbing);

newTerrain = createTerrain("Swamp");
terrain.this = newTerrain;
terrain.this.Cost = 10;
terrain.this.Skill = "nature";
terrain.this.IsLitBySun = true;
terrain.this.Description = "Knee-deep water and muck-filled bogs.";
terrain.this:AddRestrictedMovementMode(MovementMode.Flying);
terrain.this:AddRestrictedMovementMode(MovementMode.Swimming);
terrain.this:AddRestrictedMovementMode(MovementMode.Climbing);

-- Snow Terrain

-- Sky Terrain

-- Cliff Terrain

-- EOF