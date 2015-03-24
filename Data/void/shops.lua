-- VOID/SHOPS.LUA
-- This is the shops-file for the Void
-- Revised: 2012.02.20
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(1);
if (zone.this == nil) then
	errorLog("void\\shops.lua was unable to retrieve a zone object");
	return
end


systemLog("=================== ZONE 'VOID' - SHOPS ===================");

-- Merchant in Village
newShop = createShop(5100, "Merchant Shop");
if (newShop ~= nil) then
	shop.this = newShop;
	shop.this:AddSaleItem("torch", 10);
	shop.this:AddSaleItem("hooded lantern", 1);
	shop.this:AddSaleItem("waterskin", 10);		-- need to figure out how to fill this with water
	shop.this:AddSaleItem("flask", 3);			-- need to figure out how to fill this with oil
	shop.this:AddBuyType("all");
	shop.this.BuyMarkup = 75;
	shop.this.SellMarkup = 118;
end

-- EOF