// This file is generated from various Reference tables.
// Do not modify, change the values in the DB and
// build the server project instead.
//

using System;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using Realm.Library.Common.Attributes;

#pragma warning disable 1591

namespace Realm.Data
{
    [ExcludeFromCodeCoverage]
    [GeneratedCode("Realm.Build.Tool", "1.0.0.0")]
    public static class Globals
    {
        // Globals generated from RealmStatic.ref.BitType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum BitTypes
        {
            [Enum("Ability Bits", Value = 1)]
            AbilityBits,

            [Enum("Item Bits", Value = 2)]
            ItemBits,

            [Enum("Channel Bits", Value = 3)]
            ChannelBits,

            [Enum("Effect Bits", Value = 4)]
            EffectBits,

            [Enum("Race Bits", Value = 5)]
            RaceBits,

            [Enum("Barrier Bits", Value = 6)]
            BarrierBits,

            [Enum("Portal Bits", Value = 7)]
            PortalBits,

            [Enum("Space Bits", Value = 8)]
            SpaceBits,

            [Enum("Mobile Bits", Value = 9)]
            MobileBits,

            [Enum("Quest Bits", Value = 10)]
            QuestBits,

            [Enum("Ritual Bits", Value = 11)]
            RitualBits,

            [Enum("Spawn Bits", Value = 12)]
            SpawnBits,

            [Enum("Behavior Bits", Value = 13)]
            BehaviorBits,

            [Enum("Game Command Bits", Value = 14)]
            GameCommandBits,

            [Enum("Zone Bits", Value = 15)]
            ZoneBits,

            [Enum("Terrain Bits", Value = 16)]
            TerrainBits
        };

        // Globals generated from RealmStatic.ref.ShopType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum ShopTypes
        {
            [Enum("Item", Value = 1)]
            Item,

            [Enum("Ability", Value = 2)]
            Ability,

            [Enum("Service", Value = 3)]
            Service
        };

        // Globals generated from RealmStatic.ref.ItemClassType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum ItemClassTypes
        {
            [Enum("Common", Value = 10)]
            Common,

            [Enum("Uncommon", Value = 5)]
            Uncommon,

            [Enum("Rare", Value = 4)]
            Rare,

            [Enum("Legendary", Value = 17)]
            Legendary,

            [Enum("Epic", Value = 8)]
            Epic
        };

        // Globals generated from RealmStatic.ref.ChannelType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum ChannelTypes
        {
            [Enum("System", Value = 1)]
            System,

            [Enum("Player", Value = 2)]
            Player
        };

        // Globals generated from RealmStatic.ref.DamageType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum DamageTypes
        {
            [Enum("Slash", Value = 1)]
            Slash,

            [Enum("Pierce", Value = 2)]
            Pierce,

            [Enum("Crush", Value = 3)]
            Crush,

            [Enum("Burn", Value = 4)]
            Burn,

            [Enum("Freeze", Value = 5)]
            Freeze,

            [Enum("Disease", Value = 6)]
            Disease,

            [Enum("Fear", Value = 7)]
            Fear,

            [Enum("Poison", Value = 8)]
            Poison,

            [Enum("Spirit", Value = 9)]
            Spirit,

            [Enum("Acid", Value = 10)]
            Acid
        };

        // Globals generated from RealmStatic.ref.Direction
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum Directions
        {
            [Enum("North", Value = 1)]
            North,

            [Enum("South", Value = 2)]
            South,

            [Enum("East", Value = 3)]
            East,

            [Enum("West", Value = 4)]
            West,

            [Enum("Northeast", Value = 5)]
            Northeast,

            [Enum("Northwest", Value = 6)]
            Northwest,

            [Enum("Southeast", Value = 7)]
            Southeast,

            [Enum("Southwest", Value = 8)]
            Southwest,

            [Enum("Up", Value = 9)]
            Up,

            [Enum("Down", Value = 10)]
            Down
        };

        // Globals generated from RealmStatic.ref.EffectType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum EffectTypes
        {
            [Enum("Base", Value = 1)]
            Base,

            [Enum("Ablative", Value = 2)]
            Ablative,

            [Enum("Change Position", Value = 3)]
            ChangePosition,

            [Enum("Damage Shield", Value = 4)]
            DamageShield,

            [Enum("Drain Stat", Value = 5)]
            DrainStat,

            [Enum("Give Ability", Value = 6)]
            GiveAbility,

            [Enum("Give Entity", Value = 7)]
            GiveEntity,

            [Enum("Give Skill", Value = 8)]
            GiveSkill,

            [Enum("Health Change", Value = 9)]
            HealthChange,

            [Enum("Health Change-Over-Time", Value = 10)]
            HealthChangeOverTime,

            [Enum("Space Effect", Value = 11)]
            SpaceEffect,

            [Enum("StatMod", Value = 12)]
            StatMod,

            [Enum("StatMod Change-Over-Time", Value = 13)]
            StatModChangeOverTime,

            [Enum("Status Effect", Value = 14)]
            StatusEffect,

            [Enum("Teleport", Value = 15)]
            Teleport,

            [Enum("Temporary Entity", Value = 16)]
            TemporaryEntity,

            [Enum("Timed Effect", Value = 17)]
            TimedEffect
        };

        // Globals generated from RealmStatic.ref.ElementType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum ElementTypes
        {
            [Enum("Void", Value = 1, ShortName = "Void", ExtraData = "0;0;0")]
            Void,

            [Enum("Light", Value = 2, ShortName = "Light", ExtraData = "3;4;6")]
            Light,

            [Enum("Shadow", Value = 3, ShortName = "Shadow", ExtraData = "2;5;7")]
            Shadow,

            [Enum("Fire", Value = 4, ShortName = "Fire", ExtraData = "7;5;2")]
            Fire,

            [Enum("Earth",Value =  5, ShortName = "Earth", ExtraData = "6;4;3")]
            Earth,

            [Enum("Air",Value =  6, ShortName = "Air", ExtraData = "5;2;7")]
            Air,

            [Enum("Water", Value = 7, ShortName = "Water", ExtraData = "4;6;3")]
            Water
        };

        // Globals generated from RealmStatic.ref.EventType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum EventTypes
        {
            [Enum("OnAcquire", 1, "OnAcquire", "True;True;True")]
            OnAcquire,

            [Enum("OnHeartbeat", 2, "OnHeartbeat", "True;True;True")]
            OnHeartbeat,

            [Enum("OnPlayerAction", 3, "OnPlayerAction", "True;True;True")]
            OnPlayerAction,

            [Enum("OnPlayerChat", 4, "OnPlayerChat", "True;True;True")]
            OnPlayerChat,

            [Enum("OnPlayerDeath", 5, "OnPlayerDeath", "True;True;True")]
            OnPlayerDeath,

            [Enum("OnPlayerEquip", 6, "OnPlayerEquip", "True;True;True")]
            OnPlayerEquip,

            [Enum("OnPlayerLevelUp", 7, "OnPlayerLevelUp", "True;True;True")]
            OnPlayerLevelUp,

            [Enum("OnPlayerRespawn", 8, "OnPlayerRespawn", "True;True;True")]
            OnPlayerRespawn,

            [Enum("OnPlayerUnequip", 9, "OnPlayerUnequip", "True;True;True")]
            OnPlayerUnequip,

            [Enum("OnUnacquire", 10, "OnUnacquire", "True;True;True")]
            OnUnacquire,

            [Enum("OnZoneEnter", 11, "OnZoneEnter", "True;True;True")]
            OnZoneEnter,

            [Enum("OnZoneLeave", 12, "OnZoneLeave", "True;True;True")]
            OnZoneLeave,

            [Enum("OnClose", 13, "OnClose", "True;False;True")]
            OnClose,

            [Enum("OnFailToOpen", 14, "OnFailToOpen", "True;False;True")]
            OnFailToOpen,

            [Enum("OnLock", 15, "OnLock", "True;False;True")]
            OnLock,

            [Enum("OnOpen", 16, "OnOpen", "True;False;True")]
            OnOpen,

            [Enum("OnTrapTriggered", 17, "OnTrapTriggered", "True;False;False")]
            OnTrapTriggered,

            [Enum("OnUnlock", 18, "OnUnlock", "True;False;True")]
            OnUnlock,

            [Enum("OnUsed", 19, "OnUsed", "True;False;False")]
            OnUsed,

            [Enum("OnConversation", 20, "OnConversation", "False;True;False")]
            OnConversation,

            [Enum("OnDamaged", 21, "OnDamaged", "False;True;False")]
            OnDamaged,

            [Enum("OnDeath", 22, "OnDeath", "False;True;False")]
            OnDeath,

            [Enum("OnDisarm", 23, "OnDisarm", "False;True;False")]
            OnDisarm,

            [Enum("OnPerception", 24, "OnPerception", "False;True;False")]
            OnPerception,

            [Enum("OnPhysicalAttacked", 25, "OnPhysicalAttacked", "False;True;False")]
            OnPhysicalAttacked,

            [Enum("OnSpawn", 26, "OnSpawn", "False;True;False")]
            OnSpawn,

            [Enum("OnSpellCastAt", 27, "OnSpellCastAt", "False;True;False")]
            OnSpellCastAt,

            [Enum("OnStoreClosed", 28, "OnStoreClosed", "False;True;False")]
            OnStoreClosed,

            [Enum("OnEnter", 29, "OnEnter", "False;False;True")]
            OnEnter,

            [Enum("OnExit", 30, "OnExit", "False;False;True")]
            OnExit,

            [Enum("OnSunrise", 31, "OnSunrise", "False;False;True")]
            OnSunrise,

            [Enum("OnSunset", 32, "OnSunset", "False;False;True")]
            OnSunset
        };

        // Globals generated from RealmStatic.ref.GameConstant
        public static int GameConstant_TimeSegment = 0;

        public static int GameConstant_EventFrequency = 0;
        public static int GameConstant_AiProcessFrequency = 0;
        public static int GameConstant_AiBuckets = 0;
        public static int GameConstant_DefaultWanderChance = 0;
        public static int GameConstant_MaxMobMovementCost = 0;
        public static int GameConstant_MinimumPasswordLength = 0;
        public static int GameConstant_MaximumPasswordLength = 0;
        public static int GameConstant_MinimumUsernameLength = 0;
        public static int GameConstant_MaximumUsernameLength = 0;
        public static int GameConstant_MinimumCharacterNameLength = 0;
        public static int GameConstant_MaximumCharacterNameLength = 0;
        public static int GameConstant_StartSpaceId = 0;
        public static int GameConstant_MaxLevel = 0;
        public static int GameConstant_DefaultArchetypeId = 0;
        public static int GameConstant_MaxRandomHashAttempts = 0;
        public static int GameConstant_DefaultMana = 0;
        public static int GameConstant_DefaultHealth = 0;
        public static int GameConstant_DefaultStamina = 0;
        public static int GameConstant_CorpseDurationSecs = 0;
        public static int GameConstant_DeathHybridLevel = 0;
        public static int GameConstant_DefaultBindLocationId = 0;
        public static int GameConstant_DeathDurationSecs = 0;
        public static int GameConstant_TrainingPointsPerLevel = 0;
        public static int GameConstant_BaseXp = 0;
        public static int GameConstant_XpStep = 0;
        public static int GameConstant_BaseMonsterXp = 0;
        public static int GameConstant_MonsterXpStep = 0;
        public static int GameConstant_PlayerLevelHighXpMod = 0;
        public static int GameConstant_PlayerLevelLowerXpMod = 0;
        public static int GameConstant_MonsterMinionXpMod = 0;
        public static int GameConstant_MonsterStrongXpMod = 0;
        public static int GameConstant_MonsterEliteXpMod = 0;
        public static int GameConstant_MonsterBossXpMod = 0;
        public static int GameConstant_MonsterEliteBossXpMod = 0;
        public static int GameConstant_BaseNonCombatHealthRegenRate = 0;
        public static int GameConstant_BaseCombatHealthRegenRate = 0;
        public static int GameConstant_BaseNonCombatManaRegenRate = 0;
        public static int GameConstant_BaseCombatManaRegenRate = 0;
        public static int GameConstant_BaseNonCombatStaminaRegenRate = 0;
        public static int GameConstant_BaseCombatStaminaRegenRate = 0;
        public static int GameConstant_HealthTPRatio = 0;
        public static int GameConstant_ManaTPRatio = 0;
        public static int GameConstant_StaminaTPRatio = 0;
        public static int GameConstant_StatisticTPRatio = 0;
        public static int GameConstant_PreferredSkillTPRatio = 0;
        public static int GameConstant_NonPreferredSkillTPRatio = 0;
        public static int GameConstant_CombatMaxAvoidance = 0;
        public static int GameConstant_DefaultInterruptChance = 0;
        public static int GameConstant_DefaultAutoAttackDelay = 0;
        public static int GameConstant_CurrencyRatio = 0;
        public static int GameConstant_TerrainSkillReductionPercent = 0;
        public static int GameConstant_TerrainSkillMinimumRatingStep = 0;

        // Globals generated from RealmStatic.ref.GenderType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum GenderTypes
        {
            [Enum("Male", 1)]
            Male,

            [Enum("Female", 2)]
            Female,

            [Enum("Neuter", 3)]
            Neuter
        };

        // Globals generated from RealmStatic.ref.HealthChangeType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum HealthChangeTypes
        {
            [Enum("Damage", 1)]
            Damage,

            [Enum("Heal", 2)]
            Heal,

            [Enum("Resurrect", 3)]
            Resurrect,

            [Enum("Steal", 4)]
            Steal
        };

        // Globals generated from RealmStatic.ref.InstanceType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum InstanceTypes
        {
            [Enum("Item", 1)]
            Item,

            [Enum("Character", 2)]
            Character,

            [Enum("Channel", 3)]
            Channel,

            [Enum("Guild", 4)]
            Guild,

            [Enum("Auction", 5)]
            Auction,

            [Enum("Effect", 6)]
            Effect,

            [Enum("Ability", 7)]
            Ability,

            [Enum("Mobile", 8)]
            Mobile
        };

        // Globals generated from RealmStatic.ref.ItemType
        [Flags]
        public enum ItemTypes
        {
            [Enum("Weapon", 1)]
            Weapon,

            [Enum("Armor", 2)]
            Armor,

            [Enum("Light", 4)]
            Light,

            [Enum("Container", 8)]
            Container,

            [Enum("Drink Container", 16)]
            DrinkContainer,

            [Enum("Key", 32)]
            Key,

            [Enum("Tool", 64)]
            Tool,

            [Enum("Machine", 128)]
            Machine,

            [Enum("Resource", 256)]
            Resource,

            [Enum("Furniture", 512)]
            Furniture,

            [Enum("Book", 1024)]
            Book,

            [Enum("Vehicle", 2048)]
            Vehicle,

            [Enum("Corpse", 4096)]
            Corpse,

            [Enum("Reagant", 8192)]
            Reagant,

            [Enum("Portal", 16384)]
            Portal,

            [Enum("Food", 32768)]
            Food,

            [Enum("Treasure", 65536)]
            Treasure,

            [Enum("Potion", 131072)]
            Potion,

            [Enum("Resource Node", 262144)]
            ResourceNode,

            [Enum("Formula", 524288)]
            Formula,

            [Enum("Rune", 1048576)]
            Rune,

            [Enum("Lock", 2097152)]
            Lock,

            [Enum("Trap", 4194304)]
            Trap,

            [Enum("Quest Item", 8388608)]
            QuestItem,

            [Enum("Magical Node", 16777216)]
            MagicalNode,

            [Enum("Simple", 33554432)]
            Simple,

            [Enum("Boat", 67108864)]
            Boat
        };

        // Globals generated from RealmStatic.ref.LogActionType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum LogActionTypes
        {
            [Enum("Normal", 1)]
            Normal,

            [Enum("Always", 2)]
            Always,

            [Enum("Never", 3)]
            Never
        };

        // Globals generated from RealmStatic.ref.MachineType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum MachineTypes
        {
            [Enum("Table Saw", 1)]
            TableSaw,

            [Enum("Smelter", 2)]
            Smelter,

            [Enum("Anvil", 3)]
            Anvil
        };

        // Globals generated from RealmStatic.ref.MaterialType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum MaterialTypes
        {
            [Enum("Rope", 1)]
            Rope,

            [Enum("Pottery", 2)]
            Pottery,

            [Enum("Paper", 3)]
            Paper,

            [Enum("Cloth", 4)]
            Cloth,

            [Enum("Bone", 5)]
            Bone,

            [Enum("Flesh", 6)]
            Flesh,

            [Enum("Thin Glass", 7)]
            ThinGlass,

            [Enum("Thick Glass", 8)]
            ThickGlass,

            [Enum("Leather", 9)]
            Leather,

            [Enum("Soft Metal", 10)]
            SoftMetal,

            [Enum("Hard Metal", 11)]
            HardMetal,

            [Enum("Brittle Rock", 12)]
            BrittleRock,

            [Enum("Hard Rock", 13)]
            HardRock,

            [Enum("Thick Wood", 14)]
            ThickWood,

            [Enum("Thin Wood", 15)]
            ThinWood,

            [Enum("Organic", 16)]
            Organic,

            [Enum("Liquid", 17)]
            Liquid
        };

        // Globals generated from RealmStatic.ref.MerchantStatementType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum MerchantStmtTypes
        {
            [Enum("Welcome", 1)]
            Welcome,

            [Enum("Nothing For Sale", 2)]
            NothingForSale,

            [Enum("Stuff For Sale", 3)]
            StuffForSale,

            [Enum("Buy No Keyword", 4)]
            BuyNoKeyword,

            [Enum("Buy No Item", 5)]
            BuyNoItem,

            [Enum("Buy Cannot Afford", 6)]
            BuyCannotAfford,

            [Enum("Buy Complete", 7)]
            BuyComplete,

            [Enum("Sell No Keyword", 8)]
            SellNoKeyword,

            [Enum("Sell No Item", 9)]
            SellNoItem,

            [Enum("Sell No Interest", 10)]
            SellNoInterest,

            [Enum("Sell Cannot Afford", 11)]
            SellCannotAfford,

            [Enum("Sell Complete", 12)]
            SellComplete,

            [Enum("Appraise No Keyword", 13)]
            AppraiseNoKeyword,

            [Enum("Appraise No Item", 14)]
            AppraiseNoItem,

            [Enum("Appraise No Interest", 15)]
            AppraiseNoInterest,

            [Enum("Appraise Complete", 16)]
            AppraiseComplete,

            [Enum("Restock", 17)]
            Restock
        };

        // Globals generated from RealmStatic.ref.MobileType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum MobileTypes
        {
            [Enum("Regular", 1)]
            Regular,

            [Enum("Resource", 2)]
            Resource,

            [Enum("Static", 3)]
            Static,

            [Enum("Vendor", 4)]
            Vendor
        };

        // Globals generated from RealmStatic.ref.MonsterClassType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum MonsterClassTypes
        {
            [Enum("Minion", 1)]
            Minion,

            [Enum("Strong", 2)]
            Strong,

            [Enum("Elite", 3)]
            Elite,

            [Enum("Boss", 4)]
            Boss,

            [Enum("Elite Boss", 5)]
            EliteBoss
        };

        // Globals generated from RealmStatic.ref.MovementModeType
        [Flags]
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum MovementModeTypes
        {
            [Enum("Walking", 1, "Walk")]
            Walking,

            [Enum("Flying", 2, "Fly")]
            Flying,

            [Enum("Climbing", 3, "Climb")]
            Climbing,

            [Enum("Swimming", 8, "Swim")]
            Swimming,

            [Enum("Riding", 16, "Ride")]
            Riding,

            [Enum("Crawling", 32, "Crawl")]
            Crawling
        };

        // Globals generated from RealmStatic.ref.PositionType
        [Flags]
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum PositionTypes
        {
            [Enum("Any", 1)]
            Any,

            [Enum("Standing", 2)]
            Standing,

            [Enum("Sitting", 3)]
            Sitting,

            [Enum("Prone", 8)]
            Prone,

            [Enum("Crouching", 16)]
            Crouching,

            [Enum("Immobilized", 32)]
            Immobilized,

            [Enum("Incapacitated", 64)]
            Incapacitated,

            [Enum("Sleeping", 128)]
            Sleeping
        };

        // Globals generated from RealmStatic.ref.ResetLocationType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum ResetLocTypes
        {
            [Enum("Space", 1)]
            Space,

            [Enum("Access", 2)]
            Access
        };

        // Globals generated from RealmStatic.ref.ResetType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum ResetTypes
        {
            [Enum("Mob", 1)]
            Mob,

            [Enum("Item", 2)]
            Item,

            [Enum("Barrier", 3)]
            Barrier,

            [Enum("Container", 4)]
            Container,

            [Enum("Effect", 5)]
            Effect
        };

        // Globals generated from RealmStatic.ref.SeasonType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum SeasonTypes
        {
            [Enum("Summer", 1)]
            Summer,

            [Enum("Fall", 2)]
            Fall,

            [Enum("Winter", 3)]
            Winter,

            [Enum("Spring", 4)]
            Spring
        };

        // Globals generated from RealmStatic.ref.Statistic
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum Statistics
        {
            [Enum("Dexterity", 1)]
            Dexterity,

            [Enum("Vitality", 2)]
            Vitality,

            [Enum("Willpower", 3)]
            Willpower,

            [Enum("Agility", 4)]
            Agility,

            [Enum("Endurance", 5)]
            Endurance,

            [Enum("Strength", 6)]
            Strength,

            [Enum("Luck", 7)]
            Luck,

            [Enum("Spirit", 8)]
            Spirit,

            [Enum("Defense", 9)]
            Defense,

            [Enum("Faith", 10)]
            Faith,

            [Enum("Fortitude", 11)]
            Fortitude,

            [Enum("Warding", 12)]
            Warding,

            [Enum("Health", 13)]
            Health,

            [Enum("Mana", 14)]
            Mana,

            [Enum("Stamina", 15)]
            Stamina,

            [Enum("Dodge", 16)]
            Dodge,

            [Enum("Block", 17)]
            Block,

            [Enum("Parry", 18)]
            Parry,

            [Enum("Skill", 19)]
            Skill,

            [Enum("Element", 20)]
            Element,

            [Enum("Crush Resistance", 21)]
            CrushResistance,

            [Enum("Slash Resistance", 22)]
            SlashResistance,

            [Enum("Pierce Resistance", 23)]
            PierceResistance,

            [Enum("Burn Resistance", 24)]
            BurnResistance,

            [Enum("Freeze Resistance", 25)]
            FreezeResistance,

            [Enum("Disease Resistance", 26)]
            DiseaseResistance,

            [Enum("Fear Resistance", 27)]
            FearResistance,

            [Enum("Poison Resistance", 28)]
            PoisonResistance,

            [Enum("Spirit Resistance", 29)]
            SpiritResistance,

            [Enum("Acid Resistance", 30)]
            AcidResistance
        };

        // Globals generated from RealmStatic.ref.SystemType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum SystemTypes
        {
            [Enum("Zone", 1)]
            Zone,

            [Enum("Terrain", 2)]
            Terrain,

            [Enum("Space", 3)]
            Space,

            [Enum("Social", 4)]
            Social,

            [Enum("Skill", 5)]
            Skill,

            [Enum("Skill Category", 6)]
            SkillCategory,

            [Enum("Reset", 7)]
            Reset,

            [Enum("Race", 8)]
            Race,

            [Enum("Mud Prog", 9)]
            MudProg,

            [Enum("Month", 10)]
            Month,

            [Enum("Liquid", 11)]
            Liquid,

            [Enum("Item", 12)]
            Item,

            [Enum("Help Lookup", 13)]
            HelpLookup,

            [Enum("Game Command", 14)]
            GameCommand,

            [Enum("Faction", 15)]
            Faction,

            [Enum("Effect", 16)]
            Effect,

            [Enum("Archetype", 17)]
            Archetype,

            [Enum("Ability", 18)]
            Ability,

            [Enum("Behavior", 19)]
            Behavior,

            [Enum("Channel", 20)]
            Channel,

            [Enum("Conversation", 21)]
            Conversation,

            [Enum("Item Set", 22)]
            ItemSet,

            [Enum("Mobile", 23)]
            Mobile,

            [Enum("String", 24)]
            String,

            [Enum("Barrier", 25)]
            Barrier,

            [Enum("Quest", 26)]
            Quest,

            [Enum("Ritual", 27)]
            Ritual,

            [Enum("Treasure", 28)]
            Treasure,

            [Enum("Shop", 29)]
            Shop,

            [Enum("Spawn", 30)]
            Spawn
        };

        // Globals generated from RealmStatic.ref.TagCategoryType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum TagCategoryTypes
        {
            [Enum("Ability Tags", 1)]
            AbilityTags,

            [Enum("Item Tags", 2)]
            ItemTags,

            [Enum("Zone Tags", 3)]
            ZoneTags,

            [Enum("Space Tags", 4)]
            SpaceTags,

            [Enum("Barrier Tags", 5)]
            BarrierTags,

            [Enum("General Tags", 6)]
            GeneralTags,

            [Enum("Effect Tags", 7)]
            EffectTags,

            [Enum("Mobile Tags", 8)]
            MobileTags,

            [Enum("Archetype Tags", 9)]
            ArchetypeTags,

            [Enum("Behavior Tags", 10)]
            BehaviorTags,

            [Enum("Quest Tags", 11)]
            QuestTags,

            [Enum("Ritual Tags", 12)]
            RitualTags
        };

        // Globals generated from RealmStatic.ref.ToolType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum ToolTypes
        {
            [Enum("Logging", 1)]
            Logging,

            [Enum("Gathering", 2)]
            Gathering,

            [Enum("Mining", 3)]
            Mining,

            [Enum("Quarrying", 4)]
            Quarrying,

            [Enum("Butchering", 5)]
            Butchering,

            [Enum("Tanning", 6)]
            Tanning,

            [Enum("Woodworking", 7)]
            Woodworking,

            [Enum("Shearing", 8)]
            Shearing,

            [Enum("Smelting", 9)]
            Smelting,

            [Enum("Metalworking", 10)]
            Metalworking
        };

        // Globals generated from RealmStatic.ref.UserStateType
        public enum UserStateTypes
        {
            [Enum("None", 1)]
            None,

            [Enum("Main Menu", 2)]
            MainMenu,

            [Enum("Character Menu", 3)]
            CharacterMenu,

            [Enum("Create Character", 4)]
            CreateCharacter,

            [Enum("Delete Character", 5)]
            DeleteCharacter,

            [Enum("Logged In", 6)]
            LoggedIn,

            [Enum("Quitting", 7)]
            Quitting
        };

        // Globals generated from RealmStatic.ref.WearLocation
        [Flags]
        public enum WearLocations
        {
            [Enum("wear_head", 1, "Head", "Worn on Head")]
            wearhead,

            [Enum("wear_face", 2, "Face", "Worn on Face")]
            wearface,

            [Enum("wear_ear_left", 4, "Left Ear", "Worn in Left Ear")]
            wearearleft,

            [Enum("wear_ear_right", 8, "Right Ear", "Worn in Right Ear")]
            wearearright,

            [Enum("wear_brow", 16, "Brow", "Worn on Brow")]
            wearbrow,

            [Enum("wear_neck", 32, "Neck", "Worn about Neck")]
            wearneck,

            [Enum("wear_wrist_left", 64, "Left Wrist", "Worn on Left Wrist")]
            wearwristleft,

            [Enum("wear_wrist_right", 128, "Right Wrist", "Worn on Rigth Wrist")]
            wearwristright,

            [Enum("wear_wrist_both", 256, "Both Wrists", "Worn on Both Wrists")]
            wearwristboth,

            [Enum("wear_hand_left", 512, "Left Hand", "Held in Left Hand")]
            wearhandleft,

            [Enum("wear_hand_right", 1024, "Right Hand", "Held in Right Hand")]
            wearhandright,

            [Enum("wear_hand_both", 2048, "Both Hands", "Held in Both Hands")]
            wearhandboth,

            [Enum("wear_finger_left", 4096, "Left Ring Finger", "Worn on Left Ring Finger")]
            wearfingerleft,

            [Enum("wear_finger_right", 8192, "Right Ring Finger", "Worn on Right Ring Finger")]
            wearfingerright,

            [Enum("wear_chest", 16384, "Chest", "Worn on Torso")]
            wearchest,

            [Enum("wear_back", 32768, "Back", "Worn on Back")]
            wearback,

            [Enum("wear_waist", 65536, "Waist", "Worn about Waist")]
            wearwaist,

            [Enum("wear_legs", 131072, "Legs", "Worn on Legs")]
            wearlegs,

            [Enum("wear_arms", 262144, "Arms", "Worn on Arms")]
            weararms,

            [Enum("wear_ankle_left", 524288, "Left Ankle", "Worn on Left Ankle")]
            wearankleleft,

            [Enum("wear_ankle_right", 1048576, "Right Ankle", "Worn on Right Ankle")]
            wearankleright,

            [Enum("wear_ankle_both", 2097152, "Both Ankles", "Worn on Both Ankles")]
            wearankleboth,

            [Enum("wear_feet", 4194304, "Feet", "Worn on Feet")]
            wearfeet,

            [Enum("wear_body", 8388608, "Body", "Worn about Body")]
            wearbody,

            [Enum("none", 0, "None", "None")]
            none
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum AbilityBits
        {
            // Auto-Attack
            [Enum("AutoAttack", 1, "Auto-Attack", "1;1")]
            AutoAttack,

            // Not Interruptible
            [Enum("NotInterruptible", 2, "Not Interruptible", "2;1")]
            NotInterruptible,

            // Weapon Required
            [Enum("WeaponRequired", 4, "Weapon Required", "3;1")]
            WeaponRequired,

            // Implement Required
            [Enum("ImplementRequired", 8, "Implement Required", "4;1")]
            ImplementRequired,

            // Verbal Required
            [Enum("VerbalRequired", 16, "Verbal Required", "5;1")]
            VerbalRequired,

            [Enum("Passive", 32, "Passive", "6;1")]
            Passive,

            // Terrain Required
            [Enum("TerrainRequired", 64, "Terrain Required", "7;1")]
            TerrainRequired,

            // No Combat Use
            [Enum("NoCombatUse", 128, "No Combat Use", "8;1")]
            NoCombatUse,

            // Sight Required
            [Enum("SightRequired", 256, "Sight Required", "9;1")]
            SightRequired
        };

        // Globals generated from RealmStatic.ref.ConditionType
        [Flags]
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum ConditionTypes
        {
            [Enum("Pristine", 1, "Pristine", "1")]
            Pristine,

            [Enum("Slightly Damaged", 2, "Slightly Damaged", "2")]
            SlightlyDamaged,

            [Enum("Damaged", 4, "Damaged", "3")]
            Damaged,

            [Enum("Heavily Damaged", 8, "Heavily Damaged", "4")]
            HeavilyDamaged,

            [Enum("Drink Container", 16, "Drink Container", "5")]
            DrinkContainer,

            [Enum("Destroyed", 32, "Destroyed", "6")]
            Destroyed
        };

        // Globals generated from RealmStatic.ref.DifficultyType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum DifficultyTypes
        {
            [Enum("Very Easy", 1)]
            VeryEasy,

            [Enum("Easy", 2)]
            Easy,

            [Enum("Average", 3)]
            Average,

            [Enum("Hard", 4)]
            Hard,

            [Enum("Very Hard", 5)]
            VeryHard,

            [Enum("Impossible", 6)]
            Impossible
        };

        // Globals generated from RealmStatic.ref.FactionRelationshipType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum FactionRelationTypes
        {
            [Enum("Friendly", 1)]
            Friendly,

            [Enum("Unfriendly", 2)]
            Unfriendly,

            [Enum("Ally", 3)]
            Ally,

            [Enum("Kindred", 4)]
            Kindred,

            [Enum("Enemy", 5)]
            Enemy,

            [Enum("Nemesis", 6)]
            Nemesis,

            [Enum("Neutral", 7)]
            Neutral
        };

        // Globals generated from RealmStatic.ref.SizeType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum SizeTypes
        {
            [Enum("Tiny", 1)]
            Tiny,

            [Enum("Small", 2)]
            Small,

            [Enum("Medium", 3)]
            Medium,

            [Enum("Large", 4)]
            Large,

            [Enum("Huge", 5)]
            Huge,

            [Enum("Gargantuan", 6)]
            Gargantuan
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum ItemBits
        {
            [Enum("IsHidden", 1, "IsHidden", "10;2")]
            IsHidden,

            [Enum("IsTradeable", 2, "IsTradeable", "11;2")]
            IsTradeable,

            [Enum("IsRepairable", 4, "IsRepairable", "12;2")]
            IsRepairable,

            [Enum("IsTakeable", 8, "IsTakeable", "13;2")]
            IsTakeable,

            [Enum("IsLockable", 16, "IsLockable", "14;2")]
            IsLockable,

            [Enum("IsCloseable", 32, "IsCloseable", "15;2")]
            IsCloseable,

            [Enum("IsLocked", 64, "IsLocked", "16;2")]
            IsLocked,

            [Enum("IsRelockable", 128, "IsRelockable", "17;2")]
            IsRelockable,

            [Enum("IsMagical", 256, "IsMagical", "18;2")]
            IsMagical,

            // Destroyed On Use
            [Enum("DestroyedOnUse", 512, "Destroyed On Use", "19;2")]
            DestroyedOnUse,

            // Notify Area
            [Enum("NotifyArea", 1024, "Notify Area", "20;2")]
            NotifyArea,

            [Enum("IsClosed", 2048, "IsClosed", "21;2")]
            IsClosed,

            [Enum("IsBreakable", 4096, "IsBreakable", "22;2")]
            IsBreakable,

            [Enum("IsThrowable", 8192, "IsThrowable", "23;2")]
            IsThrowable,

            [Enum("IsRemoveable", 16384, "IsRemoveable", "24;2")]
            IsRemoveable
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum ChannelBits
        {
            [Enum("ReadOnly", 1, "ReadOnly", "25;3")]
            ReadOnly,

            [Enum("Admin", 2, "Admin", "26;3")]
            Admin
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum EffectBits
        {
            [Enum("IsRemoveable", 1, "IsRemoveable", "27;4")]
            IsRemoveable,

            [Enum("IsTavern", 2, "IsTavern", "28;4")]
            IsTavern,

            [Enum("IsSafe", 4, "IsSafe", "29;4")]
            IsSafe,

            [Enum("OnEnter", 8, "OnEnter", "30;4")]
            OnEnter,

            [Enum("OnTurn", 16, "OnTurn", "31;4")]
            OnTurn
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum RaceBits
        {
            // Detect Invisible
            [Enum("DetectInvisible", 1, "Detect Invisible", "32;5")]
            DetectInvisible,

            // Detect Hidden
            [Enum("DetectHidden", 2, "Detect Hidden", "33;5")]
            DetectHidden,

            [Enum("Infravision", 4, "Infravision", "34;5")]
            Infravision,

            // Move Silently
            [Enum("MoveSilently", 8, "Move Silently", "35;5")]
            MoveSilently
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum BarrierBits
        {
            [Enum("IsCloseable", 1, "IsCloseable", "36;6")]
            IsCloseable,

            [Enum("IsClosed", 2, "IsClosed", "37;6")]
            IsClosed,

            [Enum("IsOneWay", 4, "IsOneWay", "38;6")]
            IsOneWay,

            [Enum("IsTransparent", 8, "IsTransparent", "39;6")]
            IsTransparent,

            [Enum("IsDestroyable", 16, "IsDestroyable", "40;6")]
            IsDestroyable,

            [Enum("IsDispellable", 32, "IsDispellable", "41;6")]
            IsDispellable,

            [Enum("IsLockable", 64, "IsLockable", "42;6")]
            IsLockable,

            [Enum("IsJumpable", 128, "IsJumpable", "43;6")]
            IsJumpable,

            [Enum("IsClimbable", 256, "IsClimbable", "44;6")]
            IsClimbable,

            [Enum("IsSwimmable", 512, "IsSwimmable", "45;6")]
            IsSwimmable,

            [Enum("IsDestroyed", 1024, "IsDestroyed", "46;6")]
            IsDestroyed,

            [Enum("IsTrapable", 2048, "IsTrapable", "47;6")]
            IsTrapable,

            [Enum("IsLocked", 4096, "IsLocked", "48;6")]
            IsLocked
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum PortalBits
        {
            [Enum("IsHidden", 1, "IsHidden", "49;7")]
            IsHidden,

            [Enum("IsOneWay", 2, "IsOneWay", "50;7")]
            IsOneWay,

            [Enum("IsTransparent", 4, "IsTransparent", "51;7")]
            IsTransparent,

            [Enum("IsDynamic", 8, "IsDynamic", "103;7")]
            IsDynamic
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum SpaceBits
        {
            [Enum("NoMobAllowed", 1, "NoMobAllowed", "52;8")]
            NoMobAllowed,

            [Enum("NoRecall", 2, "NoRecall", "53;8")]
            NoRecall,

            [Enum("NoSummon", 4, "NoSummon", "54;8")]
            NoSummon,

            [Enum("IsSafe", 8, "IsSafe", "55;8")]
            IsSafe,

            [Enum("NoMagic", 16, "NoMagic", "56;8")]
            NoMagic,

            [Enum("IsShrine", 32, "IsShrine", "57;8")]
            IsShrine,

            [Enum("IsTavern", 64, "IsTavern", "58;8")]
            IsTavern,

            [Enum("IsDynamic", 128, "IsDynamic", "97;8")]
            IsDynamic,

            [Enum("AllowDynamic", 256, "AllowDynamic", "98;8")]
            AllowDynamic
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum MobileBits
        {
            [Enum("IsHarvestable", 1, "IsHarvestable", "59;9")]
            IsHarvestable,

            [Enum("IsTrainer", 2, "IsTrainer", "60;9")]
            IsTrainer,

            [Enum("IsPostman", 4, "IsPostman", "61;9")]
            IsPostman,

            [Enum("IsMerchant", 8, "IsMerchant", "62;9")]
            IsMerchant,

            [Enum("IsCoroner", 16, "IsCoroner", "63;9")]
            IsCoroner,

            [Enum("IsBanker", 32, "IsBanker", "64;9")]
            IsBanker,

            [Enum("IsBlacksmith", 64, "IsBlacksmith", "65;9")]
            IsBlacksmith,

            [Enum("IsHealer", 128, "IsHealer", "66;9")]
            IsHealer,

            [Enum("IsAuctioneer", 256, "IsAuctioneer", "67;9")]
            IsAuctioneer,

            [Enum("NoSummon", 512, "NoSummon", "68;9")]
            NoSummon,

            [Enum("NoAttack", 1024, "NoAttack", "69;9")]
            NoAttack,

            [Enum("NoCharm", 2048, "NoCharm", "70;9")]
            NoCharm,

            [Enum("NoBash", 4096, "NoBash", "71;9")]
            NoBash,

            [Enum("NoBlind", 8192, "NoBlind", "72;9")]
            NoBlind
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum QuestBits
        {
            [Enum("Cancellable", 1, "Cancellable", "78;10")]
            Cancellable,

            [Enum("FailOnDeath", 2, "FailOnDeath", "79;10")]
            FailOnDeath,

            [Enum("FailOnTimerExpire", 4, "FailOnTimerExpire", "80;10")]
            FailOnTimerExpire
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum RitualBits
        {
            [Enum("OnFail", 1, "OnFail", "81;11")]
            OnFail,

            [Enum("OnSuccess", 2, "OnSuccess", "82;11")]
            OnSuccess
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum SpawnBits
        {
            [Enum("OnBirth", 1, "OnBirth", "83;12")]
            OnBirth,

            [Enum("OnDeath", 2, "OnDeath", "84;12")]
            OnDeath,

            [Enum("OnHit", 4, "OnHit", "85;12")]
            OnHit
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum BehaviorBits
        {
            [Enum("Sentinel", 1, "Sentinel", "86;13")]
            Sentinel,

            [Enum("Guard", 2, "Guard", "87;13")]
            Guard,

            [Enum("Wimpy", 4, "Wimpy", "88;13")]
            Wimpy,

            [Enum("Scavenger", 8, "Scavenger", "89;13")]
            Scavenger,

            [Enum("StayArea", 16, "StayArea", "90;13")]
            StayArea,

            [Enum("NonCombatant", 32, "NonCombatant", "91;13")]
            NonCombatant,

            [Enum("Berserker", 64, "Berserker", "92;13")]
            Berserker,

            [Enum("Aggressive", 128, "Aggressive", "93;13")]
            Aggressive,

            [Enum("Grazer", 256, "Grazer", "94;13")]
            Grazer,

            [Enum("Healer", 512, "Healer", "106;13")]
            Healer,

            [Enum("Patroller", 1024, "Patroller", "107;13")]
            Patroller,

            [Enum("Psycho", 2048, "Psycho", "108;13")]
            Psycho,

            [Enum("CorpseEater", 4096, "CorpseEater", "109;13")]
            CorpseEater,

            [Enum("CorpseLooter", 8192, "CorpseLooter", "110;13")]
            CorpseLooter,

            [Enum("PortalGuardian", 16384, "PortalGuardian", "111;13")]
            PortalGuardian,

            [Enum("Stalker", 32768, "Stalker", "112;13")]
            Stalker,

            [Enum("Hireling", 65536, "Hireling", "113;13")]
            Hireling,

            [Enum("Thief", 131072, "Thief", "114;13")]
            Thief,

            [Enum("Scout", 262144, "Scout", "115;13")]
            Scout,

            [Enum("Leader", 524288, "Leader", "116;13")]
            Leader,

            [Enum("Generator", 1048576, "Generator", "117;13")]
            Generator,

            [Enum("Transformer", 2097152, "Transformer", "118;13")]
            Transformer,

            [Enum("Exploder", 4194304, "Exploder", "119;13")]
            Exploder,

            [Enum("Terrorizer", 8388608, "Terrorizer", "120;13")]
            Terrorizer
        };

        // Globals generated from RealmStatic.ref.FlammabilityType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum FlammabilityTypes
        {
            [Enum("None", 1)]
            None,

            [Enum("Low", 2)]
            Low,

            [Enum("Moderate", 3)]
            Moderate,

            [Enum("High", 4)]
            High,

            [Enum("Extreme", 5)]
            Extreme
        };

        // Globals generated from RealmStatic.ref.FuelType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum FuelTypes
        {
            [Enum("Solid", 1)]
            Solid,

            [Enum("Liquid", 2)]
            Liquid
        };

        // Globals generated from RealmStatic.ref.GuildRankType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum GuildRankTypes
        {
            [Enum("Leader", 1)]
            Leader,

            [Enum("Officer", 2)]
            Officer,

            [Enum("Member", 3)]
            Member,

            [Enum("Recruit", 4)]
            Recruit
        };

        // Globals generated from RealmStatic.ref.MobileNodeType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum MobileNodeTypes
        {
            [Enum("Alive", 1)]
            Alive,

            [Enum("Dead", 2)]
            Dead
        };

        // Globals generated from RealmStatic.ref.QuestProgressType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum QuestProgressTypes
        {
            [Enum("GoTo", 1)]
            GoTo,

            [Enum("Kill", 2)]
            Kill,

            [Enum("Talk", 3)]
            Talk,

            [Enum("Use", 4)]
            Use,

            [Enum("Get", 5)]
            Get,

            [Enum("Create", 6)]
            Create,

            [Enum("Destroy", 7)]
            Destroy,

            [Enum("Buy", 8)]
            Buy,

            [Enum("Sell", 9)]
            Sell,

            [Enum("Die", 10)]
            Die
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum GameCommandBits
        {
            [Enum("AdminOnly", 1, "AdminOnly", "95;14")]
            AdminOnly,

            [Enum("WizardOnly", 2, "WizardOnly", "96;14")]
            WizardOnly
        };

        // Globals generated from RealmStatic.ref.SkillTestResultType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum SkillTestResultTypes
        {
            [Enum("Failure", 1)]
            Failure,

            [Enum("Success", 2)]
            Success,

            [Enum("Critical Success", 3)]
            CriticalSuccess,

            [Enum("Critical Failure", 4)]
            CriticalFailure
        };

        // Globals generated from RealmStatic.ref.SpeedClassType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum SpeedClassTypes
        {
            [Enum("Very Fast", 1)]
            VeryFast,

            [Enum("Fast", 2)]
            Fast,

            [Enum("Average", 3)]
            Average,

            [Enum("Slow", 4)]
            Slow,

            [Enum("Very Slow", 5)]
            VerySlow
        };

        // Globals generated from RealmStatic.ref.TargetClassType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum TargetClassTypes
        {
            [Enum("Self", 1)]
            Self,

            [Enum("Global", 2)]
            Global,

            [Enum("Single Enemy", 3)]
            SingleEnemy,

            [Enum("Single Friendly", 4)]
            SingleFriendly,

            [Enum("Single Ally", 5)]
            SingleAlly,

            [Enum("Area Enemy", 6)]
            AreaEnemy,

            [Enum("Area Friendly", 7)]
            AreaFriendly,

            [Enum("Area Ally", 8)]
            AreaAlly,

            [Enum("Single Any", 9)]
            SingleAny,

            [Enum("Area Any", 10)]
            AreaAny,

            [Enum("Single Space", 11)]
            SingleSpace,

            [Enum("Area Spaces", 12)]
            AreaSpaces,

            [Enum("Single Item", 13)]
            SingleItem,

            [Enum("Area Items", 14)]
            AreaItems,

            [Enum("Single Barrier", 15)]
            SingleBarrier
        };

        // Globals generated from RealmStatic.ref.ColorType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum ColorTypes
        {
            [Enum("Blink On", 1, "Blink On", "&A;\033[5m")]
            BlinkOn,

            [Enum("Blink Off", 2, "Blink Off", "&a;\033[25m")]
            BlinkOff,

            [Enum("Black", 3, "Black", "&k;\033[30m")]
            Black,

            [Enum("Blue", 4, "Blue", "&b;\033[34m")]
            Blue,

            [Enum("Green", 5, "Green", "&g;\033[32m")]
            Green,

            [Enum("Cyan", 6, "Cyan", "&c;\033[36m")]
            Cyan,

            [Enum("Red", 7, "Red", "&r;\033[31m")]
            Red,

            [Enum("Purple", 8, "Purple", "&p;\033[35m")]
            Purple,

            [Enum("Brown", 9, "Brown", "&y;\033[33m")]
            Brown,

            [Enum("Gray", 10, "Gray", "&w;\033[37m")]
            Gray,

            [Enum("Dark Gray", 11, "Dark Gray", "&d;\033[1;30m")]
            DarkGray,

            [Enum("Light Blue", 12, "Light Blue", "&B;\033[1;34m")]
            LightBlue,

            [Enum("Light Green", 13, "Light Green", "&G;\033[1;32m")]
            LightGreen,

            [Enum("Light Cyan", 14, "Light Cyan", "&C;\033[1;36m")]
            LightCyan,

            [Enum("Light Red", 15, "Light Red", "&R;\033[1;31m")]
            LightRed,

            [Enum("Light Purple", 16, "Light Purple", "&P;\033[1;35m")]
            LightPurple,

            [Enum("Yellow", 17, "Yellow", "&Y;\033[1;33m")]
            Yellow,

            [Enum("White", 18, "White", "&W;\033[1;37m")]
            White,

            [Enum("Clear", 19, "Clear", "&x;\033[0m")]
            Clear
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum ZoneBits
        {
            [Enum("IsDynamic", 1, "IsDynamic", "99;15")]
            IsDynamic,

            [Enum("SpellCanClose", 2, "SpellCanClose", "100;15")]
            SpellCanClose,

            [Enum("BossDeathCanClose", 4, "BossDeathCanClose", "101;15")]
            BossDeathCanClose,

            [Enum("RefreshPortals", 8, "RefreshPortals", "102;15")]
            RefreshPortals
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum TerrainBits
        {
            [Enum("IsLitBySun", 1, "IsLitBySun", "105;15")]
            IsLitBySun
        }

        // Globals generated from RealmStatic.ref.GuildActionType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum GuildActionTypes
        {
            [Enum("Promote Member", 1)]
            PromoteMember,

            [Enum("Demote Member", 2)]
            DemoteMember,

            [Enum("Recruit New Member", 3)]
            RecruitNewMember,

            [Enum("Update Guild Information", 4)]
            UpdateGuildInformation,

            [Enum("Upgrade Bank Level", 5)]
            UpgradeBankLevel,

            [Enum("Withdraw From Bank", 6)]
            WithdrawFromBank,

            [Enum("Deposit To Bank", 7)]
            DepositToBank,

            [Enum("Kick From Guild", 8)]
            KickFromGuild
        };

        // Globals generated from RealmStatic.ref.ChannelStatusType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum ChannelStatusTypes
        {
            [Enum("On", 1)]
            On,

            [Enum("Off", 2)]
            Off
        };

        // Globals generated from RealmStatic.ref.MessageScopeType
        [Flags]
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum MessageScopeTypes
        {
            [Enum("Character", 1, "Character", "1")]
            Character,

            [Enum("Victim", 2, "Victim", "2")]
            Victim,

            [Enum("Space Limited", 4, "Space Limited", "3")]
            SpaceLimited,

            [Enum("Space", 8, "Space", "4")]
            Space,

            [Enum("Zone", 16, "Zone", "5")]
            Zone,

            [Enum("Game", 32, "Game", "6")]
            Game
        };

        // Globals generated from RealmStatic.ref.EntityLocationType
        [Flags]
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum EntityLocationTypes
        {
            [Enum("Space", 1, "Space", "1")]
            Space,

            [Enum("Inventory", 2, "Inventory", "2")]
            Inventory,

            [Enum("Equipment", 4, "Equipment", "3")]
            Equipment,

            [Enum("Container", 8, "Container", "4")]
            Container,

            [Enum("Mobile Inventory", 16, "Mobile Inventory", "5")]
            MobileInventory,

            [Enum("Mobile Equipment", 32, "Mobile Equipment", "6")]
            MobileEquipment,

            [Enum("Shop", 64, "Shop", "7")]
            Shop,

            [Enum("Ability", 128, "Ability", "8")]
            Ability,

            [Enum("Effects", 256, "Effects", "9")]
            Effects,

            [Enum("Recipes", 512, "Recipes", "10")]
            Recipes
        };

        // Globals generated from RealmStatic.ref.EffectDamageSourceType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum EffectDamageSourceTypes
        {
            [Enum("Weapon", 1)]
            Weapon,

            [Enum("Ability", 2)]
            Ability
        };

        // Globals generated from RealmStatic.ref.SpeechType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum SpeechTypes
        {
            [Enum("Tell", 1)]
            Tell,

            [Enum("Say", 2)]
            Say,

            [Enum("Shout", 3)]
            Shout,

            [Enum("Scream", 4)]
            Scream,

            [Enum("Whisper", 5)]
            Whisper
        };

        // Globals generated from RealmStatic.ref.CombatHitResultType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum CombatHitResultTypes
        {
            [Enum("Niss", 1)]
            Niss,

            [Enum("Hit", 2)]
            Hit,

            [Enum("Parry", 3)]
            Parry,

            [Enum("Dodge", 4)]
            Dodge,

            [Enum("Block", 5)]
            Block,

            [Enum("Glance", 6)]
            Glance,

            [Enum("Devastate", 7)]
            Devastate
        };

        // Globals generated from RealmStatic.ref.StatusEffectType
        [Flags]
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum StatusEffectTypes
        {
            [Enum("None", 0, "None", "1")]
            None,

            [Enum("Mesmerize", 1, "Mesmerize", "2")]
            Mesmerize,

            [Enum("Stun", 2, "Stun", "3")]
            Stun,

            [Enum("Blind", 4, "Blind", "4")]
            Blind,

            [Enum("Mute", 8, "Mute", "5")]
            Mute,

            [Enum("Immobilized", 16, "Immobilized", "6")]
            Immobilized,

            [Enum("Unconcious", 32, "Unconcious", "7")]
            Unconcious
        };

        // Globals generated from RealmStatic.ref.DayStateType
        [Flags]
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum DayStateTypes
        {
            [Enum("Dawn", 1, "Dawn", "1")]
            Dawn,

            [Enum("Daylight", 2, "Daylight", "2")]
            Daylight,

            [Enum("Dusk", 4, "Dusk", "3")]
            Dusk,

            [Enum("Night", 8, "Night", "4")]
            Night
        };

        // Globals generated from RealmStatic.ref.SpawnType
        [Flags]
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum SpawnTypes
        {
            [Enum("None", 1)]
            None,

            [Enum("Space", 2)]
            Space,

            [Enum("Access", 3)]
            Access
        };

        // Globals generated from RealmStatic.ref.StringType
        public static int StringType_DisplayName = 1;

        public static int StringType_DisplayDescription = 2;
        public static int StringType_PluralName = 3;
        public static int StringType_VerbalText = 4;
        public static int StringType_BeginUseText = 5;
        public static int StringType_UseText = 6;
        public static int StringType_ApplicationTextSelf = 7;
        public static int StringType_ApplicationTextOther = 8;
        public static int StringType_FadeTextSelf = 9;
        public static int StringType_FadeTextOther = 10;
        public static int StringType_Keywords = 11;
        public static int StringType_BookText = 12;
        public static int StringType_JournalEntry = 13;
        public static int StringType_ProgressName = 14;
        public static int StringType_TagName = 15;
        public static int StringType_SystemDescription = 16;
        public static int StringType_AccessName = 17;
        public static int StringType_Text = 18;
        public static int StringType_Data = 19;
        public static int StringType_CharNoArg = 20;
        public static int StringType_OthersNoArg = 21;
        public static int StringType_CharFound = 22;
        public static int StringType_OthersFound = 23;
        public static int StringType_VictFound = 24;
        public static int StringType_CharAuto = 25;
        public static int StringType_OthersAuto = 26;
    } // Globals
} // Realm.Globals

#pragma warning restore 1591