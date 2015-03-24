-- MODULE_ITEMS.LUA
-- This is the Items Module for the MUD
-- Revised: 2012.02.19
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();

function setItemBits(item, take, trade, repair, close)
	if (take == true) then
		item.Bits:SetBit(ItemBits.IsTakeable);
	end
	if (trade == true) then
		item.Bits:SetBit(ItemBits.IsTradeable);
	end
	if (repair == true) then
		item.Bits:SetBit(ItemBits.IsRepairable);
	end
	if (close == true) then
		item.Bits:SetBit(ItemBits.IsCloseable);
	end
end

function setMaterial(item, material)
	setProperty(item, "material", material);
end

function setBlock(item, block)
	setProperty(item, "block", block);
end

function setParry(item, parry)
	setProperty(item, "parry", parry);
end

function setSkill(item, skill)
	setProperty(item, "skill", skill);
end

function setArmorBits(item)
	item.Bits:SetBit(ItemBits.IsTakeable);
	item.Bits:SetBit(ItemBits.IsTradeable);
	item.Bits:SetBit(ItemBits.IsRepairable);
end

function setClothingBits(item)
	item.Bits:SetBit(ItemBits.IsTakeable);
	item.Bits:SetBit(ItemBits.IsTradeable);
	item.Bits:SetBit(ItemBits.IsRepairable);
end

function setContainerBits(item)
	item.Bits:SetBit(ItemBits.IsTakeable);
	item.Bits:SetBit(v);
	item.Bits:SetBit(ItemBits.IsCloseable);
end

function setWeaponBits(item)
	item.Bits:SetBit(ItemBits.IsTakeable);
	item.Bits:SetBit(ItemBits.IsTradeable);
	item.Bits:SetBit(ItemBits.IsRepairable);
end

function setContainerProperties(item, volume, weight, mouth)
	setProperty(item, "volume_limit", volume);
	setProperty(item, "weight_limit", weight);
	setProperty(item, "mouth_size", mouth);
end

function setDrinkContainerProperties(item, max_charges, filled_with)
	setProperty(item, "max_charges", max_charges);
	setProperty(item, "filled_with", filled_with);
end

function setItemProperties(item, size, stack, value, material, weight)
	setProperty(item, "size", size);
	setProperty(item, "max_stack", stack);
	setProperty(item, "value", value);
	setProperty(item, "material", material);
	setProperty(item, "weight", weight);
end

function setFormulaDetails(item, skill, skill_value, product_id, product_quantity, machine, tool, xp_value)
	item:SetSkill(skill);
	setProperty(item, "skill_value", skill_value);
	setProperty(item, "product_id", product_id);
	setProperty(item, "product_quantity", product_quantity);
	setProperty(item, "machine_id", machine);
	setProperty(item, "tool_id", tool);
	setProperty(item, "xp_value", xp_value);
end

function setWeaponProperties(item, damageType, minDamage, maxDamage)
	setProperty(item, "damage_type", damageType);
	setProperty(item, "min_damage", minDamage);
	setProperty(item, "max_damage", maxDamage);
end

-- EOF
