-- LIQUIDS.LUA
-- This is the liquids data file
-- Revised: 2009.09.25
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


systemLog("=================== REALMMUD SETUP - LIQUIDS ===================");
local currencyRatio = getProperty(nil, "currency_ratio");

-- BASICS
newLiquid = createLiquid("Water");
liquid.this = newLiquid;
liquid.this.Color = "clear";
liquid.this.ThirstPoints = 10;
liquid.this.DrunkPoints = 0;
liquid.this.CostPerCharge = 0.0625;
liquid.this.Description = "a clear and pure liquid";


-- JUICES



-- ALCOHOLS
newLiquid = createLiquid("Osaran Ale");
liquid.this = newLiquid;
liquid.this.Color = "red";
liquid.this.ThirstPoints = 2;
liquid.this.DrunkPoints = 5;
liquid.this.CostPerCharge = 0.0625;
liquid.this.Description = "a reddish, frothy liquid";


-- SPECIAL
-- Blood
newLiquid = createLiquid("Oil");
liquid.this = newLiquid;
liquid.this.Color = "yellow";
liquid.this.CostPerCharge = 0.375;
liquid.this.Description = "a viscous, slimy liquid";
liquid.this.Flammability = 5;
-- ink
-- venom

-- EOF