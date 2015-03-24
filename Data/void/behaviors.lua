-- VOID/BEHAVIORS.LUA
-- This is the behaviors-file for The Void
-- Revised: 2012.09.17
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();



systemLog("=================== ZONE 'VOID' - MOB BEHAVIORS ===================");
-- ID Range: 5300-5399
createBehavior(5300, "empty");

newBehavior = createBehavior(5301, "default");
behavior.this = newBehavior;
behavior.this.Bits:SetBit(BehaviorBits.Sentinel);

newBehavior = createBehavior(5302, "wanderer");
behavior.this = newBehavior;
behavior.this.Bits:SetBit(BehaviorBits.StayArea);

newBehavior = createBehavior(5303, "wimpy_wanderer");
behavior.this = newBehavior;
behavior.this.Bits:SetBit(BehaviorBits.StayArea);
behavior.this.Bits:SetBit(BehaviorBits.Wimpy);

newBehavior = createBehavior(5304, "npc");
behavior.this = newBehavior;
behavior.this.Bits:SetBit(BehaviorBits.Sentinel);
behavior.this.Bits:SetBit(BehaviorBits.NonCombatant);

newBehavior = createBehavior(5305, "npc_guard");
behavior.this = newBehavior;
behavior.this.Bits:SetBit(BehaviorBits.StayArea);
behavior.this.Bits:SetBit(BehaviorBits.Guard);

newBehavior = createBehavior(5306, "aggressive");
behavior.this = newBehavior;
behavior.this.Bits:SetBit(BehaviorBits.StayArea);
behavior.this.Bits:SetBit(BehaviorBits.Berserker);
behavior.this.Bits:SetBit(BehaviorBits.Aggressive);

-- EOF