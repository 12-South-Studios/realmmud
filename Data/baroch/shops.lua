-- BAROCH/SHOPS.LUA
-- This is the shops-file for the Vale of Baroch
-- Revised: 2009.09.25
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(2);
if (zone.this == nil) then
	errorLog("baroch\\shops.lua was unable to retrieve a zone object");
	return
end


systemLog("=================== ZONE 'BAROCH' - SHOPS ===================");

-- blacksmith in village
newShop = createShop(21230, "Blacksmith Shop");
shop.this = newShop;
shop.this:AddSaleItem("longsword", 5);
shop.this:AddSaleItem("short spear", 2);
shop.this:AddSaleItem("chain mail hauberk", 2);
shop.this:AddSaleItem("chain mail mitten", 2);
shop.this:AddSaleItem("chain mail vambraces", 2);
shop.this:AddSaleItem("chain mail coif", 2);
shop.this:AddSaleItem("chain mail chausses", 2);
shop.this:AddSaleItem("chain mail aventail", 2);
shop.this:AddSaleItem("bascinet helmet", 4);
shop.this:AddSaleItem("medium wooden shield", 3);
shop.this:AddBuyType("weapon");
shop.this:AddBuyType("armor");
shop.this.BuyMarkup = 75;
shop.this.SellMarkup = 118;


-- Merchant in Village
newShop = createShop(21231, "Merchant Shop");
shop.this = newShop;
shop.this:AddSaleItem("dry rations", 5);
shop.this:AddSaleItem("backpack", 2);
shop.this:AddSaleItem("large sack", 2);
shop.this:AddSaleItem("small sack", 5);
shop.this:AddSaleItem("torch", 10);
shop.this:AddSaleItem("hooded lantern", 1);
shop.this:AddSaleItem("wax candle", 10);
shop.this:AddSaleItem("small belt pouch", 5);
shop.this:AddSaleItem("waterskin", 10);		-- need to figure out how to fill this with water
shop.this:AddSaleItem("flask", 3);			-- need to figure out how to fill this with oil
shop.this:AddBuyType("all");
shop.this.BuyMarkup = 75;
shop.this.SellMarkup = 118;

-- EOF