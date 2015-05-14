// This file is generated from various Reference tables.
// Do not modify, change the values in the DB and
// build the server project instead.
//

using System;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable 1591

namespace Realm.Globals
{
    [ExcludeFromCodeCoverage]
    [GeneratedCode("Realm.Build.Tool", "1.0.0.0")]
    public static class Globals
    {
        // Globals generated from RealmStatic.ref.BitType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum BitTypes
        {
            [Realm.Library.Common.Enum("Ability Bits", Value = 1)]
            AbilityBits,

            [Realm.Library.Common.Enum("Item Bits", Value = 2)]
            ItemBits,

            [Realm.Library.Common.Enum("Channel Bits", Value = 3)]
            ChannelBits,

            [Realm.Library.Common.Enum("Effect Bits", Value = 4)]
            EffectBits,

            [Realm.Library.Common.Enum("Race Bits", Value = 5)]
            RaceBits,

            [Realm.Library.Common.Enum("Barrier Bits", Value = 6)]
            BarrierBits,

            [Realm.Library.Common.Enum("Portal Bits", Value = 7)]
            PortalBits,

            [Realm.Library.Common.Enum("Space Bits", Value = 8)]
            SpaceBits,

            [Realm.Library.Common.Enum("Mobile Bits", Value = 9)]
            MobileBits,

            [Realm.Library.Common.Enum("Quest Bits", Value = 10)]
            QuestBits,

            [Realm.Library.Common.Enum("Ritual Bits", Value = 11)]
            RitualBits,

            [Realm.Library.Common.Enum("Spawn Bits", Value = 12)]
            SpawnBits,

            [Realm.Library.Common.Enum("Behavior Bits", Value = 13)]
            BehaviorBits,

            [Realm.Library.Common.Enum("Game Command Bits", Value = 14)]
            GameCommandBits,

            [Realm.Library.Common.Enum("Zone Bits", Value = 15)]
            ZoneBits,

            [Realm.Library.Common.Enum("Terrain Bits", Value = 16)]
            TerrainBits
        };

        // Globals generated from RealmStatic.ref.ShopType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum ShopTypes
        {
            [Realm.Library.Common.Enum("Item", Value = 1)]
            Item,

            [Realm.Library.Common.Enum("Ability", Value = 2)]
            Ability,

            [Realm.Library.Common.Enum("Service", Value = 3)]
            Service
        };

        // Globals generated from RealmStatic.ref.ItemClassType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum ItemClassTypes
        {
            [Realm.Library.Common.Enum("Common", Value = 10)]
            Common,

            [Realm.Library.Common.Enum("Uncommon", Value = 5)]
            Uncommon,

            [Realm.Library.Common.Enum("Rare", Value = 4)]
            Rare,

            [Realm.Library.Common.Enum("Legendary", Value = 17)]
            Legendary,

            [Realm.Library.Common.Enum("Epic", Value = 8)]
            Epic
        };

        // Globals generated from RealmStatic.ref.ChannelType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum ChannelTypes
        {
            [Realm.Library.Common.Enum("System", Value = 1)]
            System,

            [Realm.Library.Common.Enum("Player", Value = 2)]
            Player
        };

        // Globals generated from RealmStatic.ref.DamageType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum DamageTypes
        {
            [Realm.Library.Common.Enum("Slash", Value = 1)]
            Slash,

            [Realm.Library.Common.Enum("Pierce", Value = 2)]
            Pierce,

            [Realm.Library.Common.Enum("Crush", Value = 3)]
            Crush,

            [Realm.Library.Common.Enum("Burn", Value = 4)]
            Burn,

            [Realm.Library.Common.Enum("Freeze", Value = 5)]
            Freeze,

            [Realm.Library.Common.Enum("Disease", Value = 6)]
            Disease,

            [Realm.Library.Common.Enum("Fear", Value = 7)]
            Fear,

            [Realm.Library.Common.Enum("Poison", Value = 8)]
            Poison,

            [Realm.Library.Common.Enum("Spirit", Value = 9)]
            Spirit,

            [Realm.Library.Common.Enum("Acid", Value = 10)]
            Acid
        };

        // Globals generated from RealmStatic.ref.Direction
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum Directions
        {
            [Realm.Library.Common.Enum("North", Value = 1)]
            North,

            [Realm.Library.Common.Enum("South", Value = 2)]
            South,

            [Realm.Library.Common.Enum("East", Value = 3)]
            East,

            [Realm.Library.Common.Enum("West", Value = 4)]
            West,

            [Realm.Library.Common.Enum("Northeast", Value = 5)]
            Northeast,

            [Realm.Library.Common.Enum("Northwest", Value = 6)]
            Northwest,

            [Realm.Library.Common.Enum("Southeast", Value = 7)]
            Southeast,

            [Realm.Library.Common.Enum("Southwest", Value = 8)]
            Southwest,

            [Realm.Library.Common.Enum("Up", Value = 9)]
            Up,

            [Realm.Library.Common.Enum("Down", Value = 10)]
            Down
        };

        // Globals generated from RealmStatic.ref.EffectType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum EffectTypes
        {
            [Realm.Library.Common.Enum("Base", Value = 1)]
            Base,

            [Realm.Library.Common.Enum("Ablative", Value = 2)]
            Ablative,

            [Realm.Library.Common.Enum("Change Position", Value = 3)]
            ChangePosition,

            [Realm.Library.Common.Enum("Damage Shield", Value = 4)]
            DamageShield,

            [Realm.Library.Common.Enum("Drain Stat", Value = 5)]
            DrainStat,

            [Realm.Library.Common.Enum("Give Ability", Value = 6)]
            GiveAbility,

            [Realm.Library.Common.Enum("Give Entity", Value = 7)]
            GiveEntity,

            [Realm.Library.Common.Enum("Give Skill", Value = 8)]
            GiveSkill,

            [Realm.Library.Common.Enum("Health Change", Value = 9)]
            HealthChange,

            [Realm.Library.Common.Enum("Health Change-Over-Time", Value = 10)]
            HealthChangeOverTime,

            [Realm.Library.Common.Enum("Space Effect", Value = 11)]
            SpaceEffect,

            [Realm.Library.Common.Enum("StatMod", Value = 12)]
            StatMod,

            [Realm.Library.Common.Enum("StatMod Change-Over-Time", Value = 13)]
            StatModChangeOverTime,

            [Realm.Library.Common.Enum("Status Effect", Value = 14)]
            StatusEffect,

            [Realm.Library.Common.Enum("Teleport", Value = 15)]
            Teleport,

            [Realm.Library.Common.Enum("Temporary Entity", Value = 16)]
            TemporaryEntity,

            [Realm.Library.Common.Enum("Timed Effect", Value = 17)]
            TimedEffect
        };

        // Globals generated from RealmStatic.ref.ElementType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum ElementTypes
        {
            [Realm.Library.Common.Enum("Void", Value = 1, ShortName = "Void", ExtraData = "0;0;0")]
            Void,

            [Realm.Library.Common.Enum("Light", Value = 2, ShortName = "Light", ExtraData = "3;4;6")]
            Light,

            [Realm.Library.Common.Enum("Shadow", Value = 3, ShortName = "Shadow", ExtraData = "2;5;7")]
            Shadow,

            [Realm.Library.Common.Enum("Fire", Value = 4, ShortName = "Fire", ExtraData = "7;5;2")]
            Fire,

            [Realm.Library.Common.Enum("Earth",Value =  5, ShortName = "Earth", ExtraData = "6;4;3")]
            Earth,

            [Realm.Library.Common.Enum("Air",Value =  6, ShortName = "Air", ExtraData = "5;2;7")]
            Air,

            [Realm.Library.Common.Enum("Water", Value = 7, ShortName = "Water", ExtraData = "4;6;3")]
            Water
        };

        // Globals generated from RealmStatic.ref.EventType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum EventTypes
        {
            [Realm.Library.Common.Enum("OnAcquire", 1, "OnAcquire", "True;True;True")]
            OnAcquire,

            [Realm.Library.Common.Enum("OnHeartbeat", 2, "OnHeartbeat", "True;True;True")]
            OnHeartbeat,

            [Realm.Library.Common.Enum("OnPlayerAction", 3, "OnPlayerAction", "True;True;True")]
            OnPlayerAction,

            [Realm.Library.Common.Enum("OnPlayerChat", 4, "OnPlayerChat", "True;True;True")]
            OnPlayerChat,

            [Realm.Library.Common.Enum("OnPlayerDeath", 5, "OnPlayerDeath", "True;True;True")]
            OnPlayerDeath,

            [Realm.Library.Common.Enum("OnPlayerEquip", 6, "OnPlayerEquip", "True;True;True")]
            OnPlayerEquip,

            [Realm.Library.Common.Enum("OnPlayerLevelUp", 7, "OnPlayerLevelUp", "True;True;True")]
            OnPlayerLevelUp,

            [Realm.Library.Common.Enum("OnPlayerRespawn", 8, "OnPlayerRespawn", "True;True;True")]
            OnPlayerRespawn,

            [Realm.Library.Common.Enum("OnPlayerUnequip", 9, "OnPlayerUnequip", "True;True;True")]
            OnPlayerUnequip,

            [Realm.Library.Common.Enum("OnUnacquire", 10, "OnUnacquire", "True;True;True")]
            OnUnacquire,

            [Realm.Library.Common.Enum("OnZoneEnter", 11, "OnZoneEnter", "True;True;True")]
            OnZoneEnter,

            [Realm.Library.Common.Enum("OnZoneLeave", 12, "OnZoneLeave", "True;True;True")]
            OnZoneLeave,

            [Realm.Library.Common.Enum("OnClose", 13, "OnClose", "True;False;True")]
            OnClose,

            [Realm.Library.Common.Enum("OnFailToOpen", 14, "OnFailToOpen", "True;False;True")]
            OnFailToOpen,

            [Realm.Library.Common.Enum("OnLock", 15, "OnLock", "True;False;True")]
            OnLock,

            [Realm.Library.Common.Enum("OnOpen", 16, "OnOpen", "True;False;True")]
            OnOpen,

            [Realm.Library.Common.Enum("OnTrapTriggered", 17, "OnTrapTriggered", "True;False;False")]
            OnTrapTriggered,

            [Realm.Library.Common.Enum("OnUnlock", 18, "OnUnlock", "True;False;True")]
            OnUnlock,

            [Realm.Library.Common.Enum("OnUsed", 19, "OnUsed", "True;False;False")]
            OnUsed,

            [Realm.Library.Common.Enum("OnConversation", 20, "OnConversation", "False;True;False")]
            OnConversation,

            [Realm.Library.Common.Enum("OnDamaged", 21, "OnDamaged", "False;True;False")]
            OnDamaged,

            [Realm.Library.Common.Enum("OnDeath", 22, "OnDeath", "False;True;False")]
            OnDeath,

            [Realm.Library.Common.Enum("OnDisarm", 23, "OnDisarm", "False;True;False")]
            OnDisarm,

            [Realm.Library.Common.Enum("OnPerception", 24, "OnPerception", "False;True;False")]
            OnPerception,

            [Realm.Library.Common.Enum("OnPhysicalAttacked", 25, "OnPhysicalAttacked", "False;True;False")]
            OnPhysicalAttacked,

            [Realm.Library.Common.Enum("OnSpawn", 26, "OnSpawn", "False;True;False")]
            OnSpawn,

            [Realm.Library.Common.Enum("OnSpellCastAt", 27, "OnSpellCastAt", "False;True;False")]
            OnSpellCastAt,

            [Realm.Library.Common.Enum("OnStoreClosed", 28, "OnStoreClosed", "False;True;False")]
            OnStoreClosed,

            [Realm.Library.Common.Enum("OnEnter", 29, "OnEnter", "False;False;True")]
            OnEnter,

            [Realm.Library.Common.Enum("OnExit", 30, "OnExit", "False;False;True")]
            OnExit,

            [Realm.Library.Common.Enum("OnSunrise", 31, "OnSunrise", "False;False;True")]
            OnSunrise,

            [Realm.Library.Common.Enum("OnSunset", 32, "OnSunset", "False;False;True")]
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
            [Realm.Library.Common.Enum("Male", 1)]
            Male,

            [Realm.Library.Common.Enum("Female", 2)]
            Female,

            [Realm.Library.Common.Enum("Neuter", 3)]
            Neuter
        };

        // Globals generated from RealmStatic.ref.HealthChangeType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum HealthChangeTypes
        {
            [Realm.Library.Common.Enum("Damage", 1)]
            Damage,

            [Realm.Library.Common.Enum("Heal", 2)]
            Heal,

            [Realm.Library.Common.Enum("Resurrect", 3)]
            Resurrect,

            [Realm.Library.Common.Enum("Steal", 4)]
            Steal
        };

        // Globals generated from RealmStatic.ref.InstanceType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum InstanceTypes
        {
            [Realm.Library.Common.Enum("Item", 1)]
            Item,

            [Realm.Library.Common.Enum("Character", 2)]
            Character,

            [Realm.Library.Common.Enum("Channel", 3)]
            Channel,

            [Realm.Library.Common.Enum("Guild", 4)]
            Guild,

            [Realm.Library.Common.Enum("Auction", 5)]
            Auction,

            [Realm.Library.Common.Enum("Effect", 6)]
            Effect,

            [Realm.Library.Common.Enum("Ability", 7)]
            Ability,

            [Realm.Library.Common.Enum("Mobile", 8)]
            Mobile
        };

        // Globals generated from RealmStatic.ref.ItemType
        [Flags]
        public enum ItemTypes
        {
            [Realm.Library.Common.Enum("Weapon", 1)]
            Weapon,

            [Realm.Library.Common.Enum("Armor", 2)]
            Armor,

            [Realm.Library.Common.Enum("Light", 4)]
            Light,

            [Realm.Library.Common.Enum("Container", 8)]
            Container,

            [Realm.Library.Common.Enum("Drink Container", 16)]
            DrinkContainer,

            [Realm.Library.Common.Enum("Key", 32)]
            Key,

            [Realm.Library.Common.Enum("Tool", 64)]
            Tool,

            [Realm.Library.Common.Enum("Machine", 128)]
            Machine,

            [Realm.Library.Common.Enum("Resource", 256)]
            Resource,

            [Realm.Library.Common.Enum("Furniture", 512)]
            Furniture,

            [Realm.Library.Common.Enum("Book", 1024)]
            Book,

            [Realm.Library.Common.Enum("Vehicle", 2048)]
            Vehicle,

            [Realm.Library.Common.Enum("Corpse", 4096)]
            Corpse,

            [Realm.Library.Common.Enum("Reagant", 8192)]
            Reagant,

            [Realm.Library.Common.Enum("Portal", 16384)]
            Portal,

            [Realm.Library.Common.Enum("Food", 32768)]
            Food,

            [Realm.Library.Common.Enum("Treasure", 65536)]
            Treasure,

            [Realm.Library.Common.Enum("Potion", 131072)]
            Potion,

            [Realm.Library.Common.Enum("Resource Node", 262144)]
            ResourceNode,

            [Realm.Library.Common.Enum("Formula", 524288)]
            Formula,

            [Realm.Library.Common.Enum("Rune", 1048576)]
            Rune,

            [Realm.Library.Common.Enum("Lock", 2097152)]
            Lock,

            [Realm.Library.Common.Enum("Trap", 4194304)]
            Trap,

            [Realm.Library.Common.Enum("Quest Item", 8388608)]
            QuestItem,

            [Realm.Library.Common.Enum("Magical Node", 16777216)]
            MagicalNode,

            [Realm.Library.Common.Enum("Simple", 33554432)]
            Simple,

            [Realm.Library.Common.Enum("Boat", 67108864)]
            Boat
        };

        // Globals generated from RealmStatic.ref.LogActionType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum LogActionTypes
        {
            [Realm.Library.Common.Enum("Normal", 1)]
            Normal,

            [Realm.Library.Common.Enum("Always", 2)]
            Always,

            [Realm.Library.Common.Enum("Never", 3)]
            Never
        };

        // Globals generated from RealmStatic.ref.MachineType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum MachineTypes
        {
            [Realm.Library.Common.Enum("Table Saw", 1)]
            TableSaw,

            [Realm.Library.Common.Enum("Smelter", 2)]
            Smelter,

            [Realm.Library.Common.Enum("Anvil", 3)]
            Anvil
        };

        // Globals generated from RealmStatic.ref.MaterialType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum MaterialTypes
        {
            [Realm.Library.Common.Enum("Rope", 1)]
            Rope,

            [Realm.Library.Common.Enum("Pottery", 2)]
            Pottery,

            [Realm.Library.Common.Enum("Paper", 3)]
            Paper,

            [Realm.Library.Common.Enum("Cloth", 4)]
            Cloth,

            [Realm.Library.Common.Enum("Bone", 5)]
            Bone,

            [Realm.Library.Common.Enum("Flesh", 6)]
            Flesh,

            [Realm.Library.Common.Enum("Thin Glass", 7)]
            ThinGlass,

            [Realm.Library.Common.Enum("Thick Glass", 8)]
            ThickGlass,

            [Realm.Library.Common.Enum("Leather", 9)]
            Leather,

            [Realm.Library.Common.Enum("Soft Metal", 10)]
            SoftMetal,

            [Realm.Library.Common.Enum("Hard Metal", 11)]
            HardMetal,

            [Realm.Library.Common.Enum("Brittle Rock", 12)]
            BrittleRock,

            [Realm.Library.Common.Enum("Hard Rock", 13)]
            HardRock,

            [Realm.Library.Common.Enum("Thick Wood", 14)]
            ThickWood,

            [Realm.Library.Common.Enum("Thin Wood", 15)]
            ThinWood,

            [Realm.Library.Common.Enum("Organic", 16)]
            Organic,

            [Realm.Library.Common.Enum("Liquid", 17)]
            Liquid
        };

        // Globals generated from RealmStatic.ref.MerchantStatementType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum MerchantStmtTypes
        {
            [Realm.Library.Common.Enum("Welcome", 1)]
            Welcome,

            [Realm.Library.Common.Enum("Nothing For Sale", 2)]
            NothingForSale,

            [Realm.Library.Common.Enum("Stuff For Sale", 3)]
            StuffForSale,

            [Realm.Library.Common.Enum("Buy No Keyword", 4)]
            BuyNoKeyword,

            [Realm.Library.Common.Enum("Buy No Item", 5)]
            BuyNoItem,

            [Realm.Library.Common.Enum("Buy Cannot Afford", 6)]
            BuyCannotAfford,

            [Realm.Library.Common.Enum("Buy Complete", 7)]
            BuyComplete,

            [Realm.Library.Common.Enum("Sell No Keyword", 8)]
            SellNoKeyword,

            [Realm.Library.Common.Enum("Sell No Item", 9)]
            SellNoItem,

            [Realm.Library.Common.Enum("Sell No Interest", 10)]
            SellNoInterest,

            [Realm.Library.Common.Enum("Sell Cannot Afford", 11)]
            SellCannotAfford,

            [Realm.Library.Common.Enum("Sell Complete", 12)]
            SellComplete,

            [Realm.Library.Common.Enum("Appraise No Keyword", 13)]
            AppraiseNoKeyword,

            [Realm.Library.Common.Enum("Appraise No Item", 14)]
            AppraiseNoItem,

            [Realm.Library.Common.Enum("Appraise No Interest", 15)]
            AppraiseNoInterest,

            [Realm.Library.Common.Enum("Appraise Complete", 16)]
            AppraiseComplete,

            [Realm.Library.Common.Enum("Restock", 17)]
            Restock
        };

        // Globals generated from RealmStatic.ref.MobileType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum MobileTypes
        {
            [Realm.Library.Common.Enum("Regular", 1)]
            Regular,

            [Realm.Library.Common.Enum("Resource", 2)]
            Resource,

            [Realm.Library.Common.Enum("Static", 3)]
            Static,

            [Realm.Library.Common.Enum("Vendor", 4)]
            Vendor
        };

        // Globals generated from RealmStatic.ref.MonsterClassType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum MonsterClassTypes
        {
            [Realm.Library.Common.Enum("Minion", 1)]
            Minion,

            [Realm.Library.Common.Enum("Strong", 2)]
            Strong,

            [Realm.Library.Common.Enum("Elite", 3)]
            Elite,

            [Realm.Library.Common.Enum("Boss", 4)]
            Boss,

            [Realm.Library.Common.Enum("Elite Boss", 5)]
            EliteBoss
        };

        // Globals generated from RealmStatic.ref.MovementModeType
        [Flags]
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum MovementModeTypes
        {
            [Realm.Library.Common.Enum("Walking", 1, "Walk")]
            Walking,

            [Realm.Library.Common.Enum("Flying", 2, "Fly")]
            Flying,

            [Realm.Library.Common.Enum("Climbing", 3, "Climb")]
            Climbing,

            [Realm.Library.Common.Enum("Swimming", 8, "Swim")]
            Swimming,

            [Realm.Library.Common.Enum("Riding", 16, "Ride")]
            Riding,

            [Realm.Library.Common.Enum("Crawling", 32, "Crawl")]
            Crawling
        };

        // Globals generated from RealmStatic.ref.PositionType
        [Flags]
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum PositionTypes
        {
            [Realm.Library.Common.Enum("Any", 1)]
            Any,

            [Realm.Library.Common.Enum("Standing", 2)]
            Standing,

            [Realm.Library.Common.Enum("Sitting", 3)]
            Sitting,

            [Realm.Library.Common.Enum("Prone", 8)]
            Prone,

            [Realm.Library.Common.Enum("Crouching", 16)]
            Crouching,

            [Realm.Library.Common.Enum("Immobilized", 32)]
            Immobilized,

            [Realm.Library.Common.Enum("Incapacitated", 64)]
            Incapacitated,

            [Realm.Library.Common.Enum("Sleeping", 128)]
            Sleeping
        };

        // Globals generated from RealmStatic.ref.ResetLocationType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum ResetLocTypes
        {
            [Realm.Library.Common.Enum("Space", 1)]
            Space,

            [Realm.Library.Common.Enum("Access", 2)]
            Access
        };

        // Globals generated from RealmStatic.ref.ResetType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum ResetTypes
        {
            [Realm.Library.Common.Enum("Mob", 1)]
            Mob,

            [Realm.Library.Common.Enum("Item", 2)]
            Item,

            [Realm.Library.Common.Enum("Barrier", 3)]
            Barrier,

            [Realm.Library.Common.Enum("Container", 4)]
            Container,

            [Realm.Library.Common.Enum("Effect", 5)]
            Effect
        };

        // Globals generated from RealmStatic.ref.SeasonType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum SeasonTypes
        {
            [Realm.Library.Common.Enum("Summer", 1)]
            Summer,

            [Realm.Library.Common.Enum("Fall", 2)]
            Fall,

            [Realm.Library.Common.Enum("Winter", 3)]
            Winter,

            [Realm.Library.Common.Enum("Spring", 4)]
            Spring
        };

        // Globals generated from RealmStatic.ref.Statistic
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum Statistics
        {
            [Realm.Library.Common.Enum("Dexterity", 1)]
            Dexterity,

            [Realm.Library.Common.Enum("Vitality", 2)]
            Vitality,

            [Realm.Library.Common.Enum("Willpower", 3)]
            Willpower,

            [Realm.Library.Common.Enum("Agility", 4)]
            Agility,

            [Realm.Library.Common.Enum("Endurance", 5)]
            Endurance,

            [Realm.Library.Common.Enum("Strength", 6)]
            Strength,

            [Realm.Library.Common.Enum("Luck", 7)]
            Luck,

            [Realm.Library.Common.Enum("Spirit", 8)]
            Spirit,

            [Realm.Library.Common.Enum("Defense", 9)]
            Defense,

            [Realm.Library.Common.Enum("Faith", 10)]
            Faith,

            [Realm.Library.Common.Enum("Fortitude", 11)]
            Fortitude,

            [Realm.Library.Common.Enum("Warding", 12)]
            Warding,

            [Realm.Library.Common.Enum("Health", 13)]
            Health,

            [Realm.Library.Common.Enum("Mana", 14)]
            Mana,

            [Realm.Library.Common.Enum("Stamina", 15)]
            Stamina,

            [Realm.Library.Common.Enum("Dodge", 16)]
            Dodge,

            [Realm.Library.Common.Enum("Block", 17)]
            Block,

            [Realm.Library.Common.Enum("Parry", 18)]
            Parry,

            [Realm.Library.Common.Enum("Skill", 19)]
            Skill,

            [Realm.Library.Common.Enum("Element", 20)]
            Element,

            [Realm.Library.Common.Enum("Crush Resistance", 21)]
            CrushResistance,

            [Realm.Library.Common.Enum("Slash Resistance", 22)]
            SlashResistance,

            [Realm.Library.Common.Enum("Pierce Resistance", 23)]
            PierceResistance,

            [Realm.Library.Common.Enum("Burn Resistance", 24)]
            BurnResistance,

            [Realm.Library.Common.Enum("Freeze Resistance", 25)]
            FreezeResistance,

            [Realm.Library.Common.Enum("Disease Resistance", 26)]
            DiseaseResistance,

            [Realm.Library.Common.Enum("Fear Resistance", 27)]
            FearResistance,

            [Realm.Library.Common.Enum("Poison Resistance", 28)]
            PoisonResistance,

            [Realm.Library.Common.Enum("Spirit Resistance", 29)]
            SpiritResistance,

            [Realm.Library.Common.Enum("Acid Resistance", 30)]
            AcidResistance
        };

        // Globals generated from RealmStatic.ref.SystemType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum SystemTypes
        {
            [Realm.Library.Common.Enum("Zone", 1)]
            Zone,

            [Realm.Library.Common.Enum("Terrain", 2)]
            Terrain,

            [Realm.Library.Common.Enum("Space", 3)]
            Space,

            [Realm.Library.Common.Enum("Social", 4)]
            Social,

            [Realm.Library.Common.Enum("Skill", 5)]
            Skill,

            [Realm.Library.Common.Enum("Skill Category", 6)]
            SkillCategory,

            [Realm.Library.Common.Enum("Reset", 7)]
            Reset,

            [Realm.Library.Common.Enum("Race", 8)]
            Race,

            [Realm.Library.Common.Enum("Mud Prog", 9)]
            MudProg,

            [Realm.Library.Common.Enum("Month", 10)]
            Month,

            [Realm.Library.Common.Enum("Liquid", 11)]
            Liquid,

            [Realm.Library.Common.Enum("Item", 12)]
            Item,

            [Realm.Library.Common.Enum("Help Lookup", 13)]
            HelpLookup,

            [Realm.Library.Common.Enum("Game Command", 14)]
            GameCommand,

            [Realm.Library.Common.Enum("Faction", 15)]
            Faction,

            [Realm.Library.Common.Enum("Effect", 16)]
            Effect,

            [Realm.Library.Common.Enum("Archetype", 17)]
            Archetype,

            [Realm.Library.Common.Enum("Ability", 18)]
            Ability,

            [Realm.Library.Common.Enum("Behavior", 19)]
            Behavior,

            [Realm.Library.Common.Enum("Channel", 20)]
            Channel,

            [Realm.Library.Common.Enum("Conversation", 21)]
            Conversation,

            [Realm.Library.Common.Enum("Item Set", 22)]
            ItemSet,

            [Realm.Library.Common.Enum("Mobile", 23)]
            Mobile,

            [Realm.Library.Common.Enum("String", 24)]
            String,

            [Realm.Library.Common.Enum("Barrier", 25)]
            Barrier,

            [Realm.Library.Common.Enum("Quest", 26)]
            Quest,

            [Realm.Library.Common.Enum("Ritual", 27)]
            Ritual,

            [Realm.Library.Common.Enum("Treasure", 28)]
            Treasure,

            [Realm.Library.Common.Enum("Shop", 29)]
            Shop,

            [Realm.Library.Common.Enum("Spawn", 30)]
            Spawn
        };

        // Globals generated from RealmStatic.ref.TagCategoryType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum TagCategoryTypes
        {
            [Realm.Library.Common.Enum("Ability Tags", 1)]
            AbilityTags,

            [Realm.Library.Common.Enum("Item Tags", 2)]
            ItemTags,

            [Realm.Library.Common.Enum("Zone Tags", 3)]
            ZoneTags,

            [Realm.Library.Common.Enum("Space Tags", 4)]
            SpaceTags,

            [Realm.Library.Common.Enum("Barrier Tags", 5)]
            BarrierTags,

            [Realm.Library.Common.Enum("General Tags", 6)]
            GeneralTags,

            [Realm.Library.Common.Enum("Effect Tags", 7)]
            EffectTags,

            [Realm.Library.Common.Enum("Mobile Tags", 8)]
            MobileTags,

            [Realm.Library.Common.Enum("Archetype Tags", 9)]
            ArchetypeTags,

            [Realm.Library.Common.Enum("Behavior Tags", 10)]
            BehaviorTags,

            [Realm.Library.Common.Enum("Quest Tags", 11)]
            QuestTags,

            [Realm.Library.Common.Enum("Ritual Tags", 12)]
            RitualTags
        };

        // Globals generated from RealmStatic.ref.ToolType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum ToolTypes
        {
            [Realm.Library.Common.Enum("Logging", 1)]
            Logging,

            [Realm.Library.Common.Enum("Gathering", 2)]
            Gathering,

            [Realm.Library.Common.Enum("Mining", 3)]
            Mining,

            [Realm.Library.Common.Enum("Quarrying", 4)]
            Quarrying,

            [Realm.Library.Common.Enum("Butchering", 5)]
            Butchering,

            [Realm.Library.Common.Enum("Tanning", 6)]
            Tanning,

            [Realm.Library.Common.Enum("Woodworking", 7)]
            Woodworking,

            [Realm.Library.Common.Enum("Shearing", 8)]
            Shearing,

            [Realm.Library.Common.Enum("Smelting", 9)]
            Smelting,

            [Realm.Library.Common.Enum("Metalworking", 10)]
            Metalworking
        };

        // Globals generated from RealmStatic.ref.UserStateType
        public enum UserStateTypes
        {
            [Realm.Library.Common.Enum("None", 1)]
            None,

            [Realm.Library.Common.Enum("Main Menu", 2)]
            MainMenu,

            [Realm.Library.Common.Enum("Character Menu", 3)]
            CharacterMenu,

            [Realm.Library.Common.Enum("Create Character", 4)]
            CreateCharacter,

            [Realm.Library.Common.Enum("Delete Character", 5)]
            DeleteCharacter,

            [Realm.Library.Common.Enum("Logged In", 6)]
            LoggedIn,

            [Realm.Library.Common.Enum("Quitting", 7)]
            Quitting
        };

        // Globals generated from RealmStatic.ref.WearLocation
        [Flags]
        public enum WearLocations
        {
            [Realm.Library.Common.Enum("wear_head", 1, "Head", "Worn on Head")]
            wearhead,

            [Realm.Library.Common.Enum("wear_face", 2, "Face", "Worn on Face")]
            wearface,

            [Realm.Library.Common.Enum("wear_ear_left", 4, "Left Ear", "Worn in Left Ear")]
            wearearleft,

            [Realm.Library.Common.Enum("wear_ear_right", 8, "Right Ear", "Worn in Right Ear")]
            wearearright,

            [Realm.Library.Common.Enum("wear_brow", 16, "Brow", "Worn on Brow")]
            wearbrow,

            [Realm.Library.Common.Enum("wear_neck", 32, "Neck", "Worn about Neck")]
            wearneck,

            [Realm.Library.Common.Enum("wear_wrist_left", 64, "Left Wrist", "Worn on Left Wrist")]
            wearwristleft,

            [Realm.Library.Common.Enum("wear_wrist_right", 128, "Right Wrist", "Worn on Rigth Wrist")]
            wearwristright,

            [Realm.Library.Common.Enum("wear_wrist_both", 256, "Both Wrists", "Worn on Both Wrists")]
            wearwristboth,

            [Realm.Library.Common.Enum("wear_hand_left", 512, "Left Hand", "Held in Left Hand")]
            wearhandleft,

            [Realm.Library.Common.Enum("wear_hand_right", 1024, "Right Hand", "Held in Right Hand")]
            wearhandright,

            [Realm.Library.Common.Enum("wear_hand_both", 2048, "Both Hands", "Held in Both Hands")]
            wearhandboth,

            [Realm.Library.Common.Enum("wear_finger_left", 4096, "Left Ring Finger", "Worn on Left Ring Finger")]
            wearfingerleft,

            [Realm.Library.Common.Enum("wear_finger_right", 8192, "Right Ring Finger", "Worn on Right Ring Finger")]
            wearfingerright,

            [Realm.Library.Common.Enum("wear_chest", 16384, "Chest", "Worn on Torso")]
            wearchest,

            [Realm.Library.Common.Enum("wear_back", 32768, "Back", "Worn on Back")]
            wearback,

            [Realm.Library.Common.Enum("wear_waist", 65536, "Waist", "Worn about Waist")]
            wearwaist,

            [Realm.Library.Common.Enum("wear_legs", 131072, "Legs", "Worn on Legs")]
            wearlegs,

            [Realm.Library.Common.Enum("wear_arms", 262144, "Arms", "Worn on Arms")]
            weararms,

            [Realm.Library.Common.Enum("wear_ankle_left", 524288, "Left Ankle", "Worn on Left Ankle")]
            wearankleleft,

            [Realm.Library.Common.Enum("wear_ankle_right", 1048576, "Right Ankle", "Worn on Right Ankle")]
            wearankleright,

            [Realm.Library.Common.Enum("wear_ankle_both", 2097152, "Both Ankles", "Worn on Both Ankles")]
            wearankleboth,

            [Realm.Library.Common.Enum("wear_feet", 4194304, "Feet", "Worn on Feet")]
            wearfeet,

            [Realm.Library.Common.Enum("wear_body", 8388608, "Body", "Worn about Body")]
            wearbody,

            [Realm.Library.Common.Enum("none", 0, "None", "None")]
            none
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum AbilityBits
        {
            // Auto-Attack
            [Realm.Library.Common.Enum("AutoAttack", 1, "Auto-Attack", "1;1")]
            AutoAttack,

            // Not Interruptible
            [Realm.Library.Common.Enum("NotInterruptible", 2, "Not Interruptible", "2;1")]
            NotInterruptible,

            // Weapon Required
            [Realm.Library.Common.Enum("WeaponRequired", 4, "Weapon Required", "3;1")]
            WeaponRequired,

            // Implement Required
            [Realm.Library.Common.Enum("ImplementRequired", 8, "Implement Required", "4;1")]
            ImplementRequired,

            // Verbal Required
            [Realm.Library.Common.Enum("VerbalRequired", 16, "Verbal Required", "5;1")]
            VerbalRequired,

            [Realm.Library.Common.Enum("Passive", 32, "Passive", "6;1")]
            Passive,

            // Terrain Required
            [Realm.Library.Common.Enum("TerrainRequired", 64, "Terrain Required", "7;1")]
            TerrainRequired,

            // No Combat Use
            [Realm.Library.Common.Enum("NoCombatUse", 128, "No Combat Use", "8;1")]
            NoCombatUse,

            // Sight Required
            [Realm.Library.Common.Enum("SightRequired", 256, "Sight Required", "9;1")]
            SightRequired
        };

        // Globals generated from RealmStatic.ref.ConditionType
        [Flags]
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum ConditionTypes
        {
            [Realm.Library.Common.Enum("Pristine", 1, "Pristine", "1")]
            Pristine,

            [Realm.Library.Common.Enum("Slightly Damaged", 2, "Slightly Damaged", "2")]
            SlightlyDamaged,

            [Realm.Library.Common.Enum("Damaged", 4, "Damaged", "3")]
            Damaged,

            [Realm.Library.Common.Enum("Heavily Damaged", 8, "Heavily Damaged", "4")]
            HeavilyDamaged,

            [Realm.Library.Common.Enum("Drink Container", 16, "Drink Container", "5")]
            DrinkContainer,

            [Realm.Library.Common.Enum("Destroyed", 32, "Destroyed", "6")]
            Destroyed
        };

        // Globals generated from RealmStatic.ref.DifficultyType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum DifficultyTypes
        {
            [Realm.Library.Common.Enum("Very Easy", 1)]
            VeryEasy,

            [Realm.Library.Common.Enum("Easy", 2)]
            Easy,

            [Realm.Library.Common.Enum("Average", 3)]
            Average,

            [Realm.Library.Common.Enum("Hard", 4)]
            Hard,

            [Realm.Library.Common.Enum("Very Hard", 5)]
            VeryHard,

            [Realm.Library.Common.Enum("Impossible", 6)]
            Impossible
        };

        // Globals generated from RealmStatic.ref.FactionRelationshipType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum FactionRelationTypes
        {
            [Realm.Library.Common.Enum("Friendly", 1)]
            Friendly,

            [Realm.Library.Common.Enum("Unfriendly", 2)]
            Unfriendly,

            [Realm.Library.Common.Enum("Ally", 3)]
            Ally,

            [Realm.Library.Common.Enum("Kindred", 4)]
            Kindred,

            [Realm.Library.Common.Enum("Enemy", 5)]
            Enemy,

            [Realm.Library.Common.Enum("Nemesis", 6)]
            Nemesis,

            [Realm.Library.Common.Enum("Neutral", 7)]
            Neutral
        };

        // Globals generated from RealmStatic.ref.SizeType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum SizeTypes
        {
            [Realm.Library.Common.Enum("Tiny", 1)]
            Tiny,

            [Realm.Library.Common.Enum("Small", 2)]
            Small,

            [Realm.Library.Common.Enum("Medium", 3)]
            Medium,

            [Realm.Library.Common.Enum("Large", 4)]
            Large,

            [Realm.Library.Common.Enum("Huge", 5)]
            Huge,

            [Realm.Library.Common.Enum("Gargantuan", 6)]
            Gargantuan
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum ItemBits
        {
            [Realm.Library.Common.Enum("IsHidden", 1, "IsHidden", "10;2")]
            IsHidden,

            [Realm.Library.Common.Enum("IsTradeable", 2, "IsTradeable", "11;2")]
            IsTradeable,

            [Realm.Library.Common.Enum("IsRepairable", 4, "IsRepairable", "12;2")]
            IsRepairable,

            [Realm.Library.Common.Enum("IsTakeable", 8, "IsTakeable", "13;2")]
            IsTakeable,

            [Realm.Library.Common.Enum("IsLockable", 16, "IsLockable", "14;2")]
            IsLockable,

            [Realm.Library.Common.Enum("IsCloseable", 32, "IsCloseable", "15;2")]
            IsCloseable,

            [Realm.Library.Common.Enum("IsLocked", 64, "IsLocked", "16;2")]
            IsLocked,

            [Realm.Library.Common.Enum("IsRelockable", 128, "IsRelockable", "17;2")]
            IsRelockable,

            [Realm.Library.Common.Enum("IsMagical", 256, "IsMagical", "18;2")]
            IsMagical,

            // Destroyed On Use
            [Realm.Library.Common.Enum("DestroyedOnUse", 512, "Destroyed On Use", "19;2")]
            DestroyedOnUse,

            // Notify Area
            [Realm.Library.Common.Enum("NotifyArea", 1024, "Notify Area", "20;2")]
            NotifyArea,

            [Realm.Library.Common.Enum("IsClosed", 2048, "IsClosed", "21;2")]
            IsClosed,

            [Realm.Library.Common.Enum("IsBreakable", 4096, "IsBreakable", "22;2")]
            IsBreakable,

            [Realm.Library.Common.Enum("IsThrowable", 8192, "IsThrowable", "23;2")]
            IsThrowable,

            [Realm.Library.Common.Enum("IsRemoveable", 16384, "IsRemoveable", "24;2")]
            IsRemoveable
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum ChannelBits
        {
            [Realm.Library.Common.Enum("ReadOnly", 1, "ReadOnly", "25;3")]
            ReadOnly,

            [Realm.Library.Common.Enum("Admin", 2, "Admin", "26;3")]
            Admin
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum EffectBits
        {
            [Realm.Library.Common.Enum("IsRemoveable", 1, "IsRemoveable", "27;4")]
            IsRemoveable,

            [Realm.Library.Common.Enum("IsTavern", 2, "IsTavern", "28;4")]
            IsTavern,

            [Realm.Library.Common.Enum("IsSafe", 4, "IsSafe", "29;4")]
            IsSafe,

            [Realm.Library.Common.Enum("OnEnter", 8, "OnEnter", "30;4")]
            OnEnter,

            [Realm.Library.Common.Enum("OnTurn", 16, "OnTurn", "31;4")]
            OnTurn
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum RaceBits
        {
            // Detect Invisible
            [Realm.Library.Common.Enum("DetectInvisible", 1, "Detect Invisible", "32;5")]
            DetectInvisible,

            // Detect Hidden
            [Realm.Library.Common.Enum("DetectHidden", 2, "Detect Hidden", "33;5")]
            DetectHidden,

            [Realm.Library.Common.Enum("Infravision", 4, "Infravision", "34;5")]
            Infravision,

            // Move Silently
            [Realm.Library.Common.Enum("MoveSilently", 8, "Move Silently", "35;5")]
            MoveSilently
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum BarrierBits
        {
            [Realm.Library.Common.Enum("IsCloseable", 1, "IsCloseable", "36;6")]
            IsCloseable,

            [Realm.Library.Common.Enum("IsClosed", 2, "IsClosed", "37;6")]
            IsClosed,

            [Realm.Library.Common.Enum("IsOneWay", 4, "IsOneWay", "38;6")]
            IsOneWay,

            [Realm.Library.Common.Enum("IsTransparent", 8, "IsTransparent", "39;6")]
            IsTransparent,

            [Realm.Library.Common.Enum("IsDestroyable", 16, "IsDestroyable", "40;6")]
            IsDestroyable,

            [Realm.Library.Common.Enum("IsDispellable", 32, "IsDispellable", "41;6")]
            IsDispellable,

            [Realm.Library.Common.Enum("IsLockable", 64, "IsLockable", "42;6")]
            IsLockable,

            [Realm.Library.Common.Enum("IsJumpable", 128, "IsJumpable", "43;6")]
            IsJumpable,

            [Realm.Library.Common.Enum("IsClimbable", 256, "IsClimbable", "44;6")]
            IsClimbable,

            [Realm.Library.Common.Enum("IsSwimmable", 512, "IsSwimmable", "45;6")]
            IsSwimmable,

            [Realm.Library.Common.Enum("IsDestroyed", 1024, "IsDestroyed", "46;6")]
            IsDestroyed,

            [Realm.Library.Common.Enum("IsTrapable", 2048, "IsTrapable", "47;6")]
            IsTrapable,

            [Realm.Library.Common.Enum("IsLocked", 4096, "IsLocked", "48;6")]
            IsLocked
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum PortalBits
        {
            [Realm.Library.Common.Enum("IsHidden", 1, "IsHidden", "49;7")]
            IsHidden,

            [Realm.Library.Common.Enum("IsOneWay", 2, "IsOneWay", "50;7")]
            IsOneWay,

            [Realm.Library.Common.Enum("IsTransparent", 4, "IsTransparent", "51;7")]
            IsTransparent,

            [Realm.Library.Common.Enum("IsDynamic", 8, "IsDynamic", "103;7")]
            IsDynamic
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum SpaceBits
        {
            [Realm.Library.Common.Enum("NoMobAllowed", 1, "NoMobAllowed", "52;8")]
            NoMobAllowed,

            [Realm.Library.Common.Enum("NoRecall", 2, "NoRecall", "53;8")]
            NoRecall,

            [Realm.Library.Common.Enum("NoSummon", 4, "NoSummon", "54;8")]
            NoSummon,

            [Realm.Library.Common.Enum("IsSafe", 8, "IsSafe", "55;8")]
            IsSafe,

            [Realm.Library.Common.Enum("NoMagic", 16, "NoMagic", "56;8")]
            NoMagic,

            [Realm.Library.Common.Enum("IsShrine", 32, "IsShrine", "57;8")]
            IsShrine,

            [Realm.Library.Common.Enum("IsTavern", 64, "IsTavern", "58;8")]
            IsTavern,

            [Realm.Library.Common.Enum("IsDynamic", 128, "IsDynamic", "97;8")]
            IsDynamic,

            [Realm.Library.Common.Enum("AllowDynamic", 256, "AllowDynamic", "98;8")]
            AllowDynamic
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum MobileBits
        {
            [Realm.Library.Common.Enum("IsHarvestable", 1, "IsHarvestable", "59;9")]
            IsHarvestable,

            [Realm.Library.Common.Enum("IsTrainer", 2, "IsTrainer", "60;9")]
            IsTrainer,

            [Realm.Library.Common.Enum("IsPostman", 4, "IsPostman", "61;9")]
            IsPostman,

            [Realm.Library.Common.Enum("IsMerchant", 8, "IsMerchant", "62;9")]
            IsMerchant,

            [Realm.Library.Common.Enum("IsCoroner", 16, "IsCoroner", "63;9")]
            IsCoroner,

            [Realm.Library.Common.Enum("IsBanker", 32, "IsBanker", "64;9")]
            IsBanker,

            [Realm.Library.Common.Enum("IsBlacksmith", 64, "IsBlacksmith", "65;9")]
            IsBlacksmith,

            [Realm.Library.Common.Enum("IsHealer", 128, "IsHealer", "66;9")]
            IsHealer,

            [Realm.Library.Common.Enum("IsAuctioneer", 256, "IsAuctioneer", "67;9")]
            IsAuctioneer,

            [Realm.Library.Common.Enum("NoSummon", 512, "NoSummon", "68;9")]
            NoSummon,

            [Realm.Library.Common.Enum("NoAttack", 1024, "NoAttack", "69;9")]
            NoAttack,

            [Realm.Library.Common.Enum("NoCharm", 2048, "NoCharm", "70;9")]
            NoCharm,

            [Realm.Library.Common.Enum("NoBash", 4096, "NoBash", "71;9")]
            NoBash,

            [Realm.Library.Common.Enum("NoBlind", 8192, "NoBlind", "72;9")]
            NoBlind
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum QuestBits
        {
            [Realm.Library.Common.Enum("Cancellable", 1, "Cancellable", "78;10")]
            Cancellable,

            [Realm.Library.Common.Enum("FailOnDeath", 2, "FailOnDeath", "79;10")]
            FailOnDeath,

            [Realm.Library.Common.Enum("FailOnTimerExpire", 4, "FailOnTimerExpire", "80;10")]
            FailOnTimerExpire
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum RitualBits
        {
            [Realm.Library.Common.Enum("OnFail", 1, "OnFail", "81;11")]
            OnFail,

            [Realm.Library.Common.Enum("OnSuccess", 2, "OnSuccess", "82;11")]
            OnSuccess
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum SpawnBits
        {
            [Realm.Library.Common.Enum("OnBirth", 1, "OnBirth", "83;12")]
            OnBirth,

            [Realm.Library.Common.Enum("OnDeath", 2, "OnDeath", "84;12")]
            OnDeath,

            [Realm.Library.Common.Enum("OnHit", 4, "OnHit", "85;12")]
            OnHit
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum BehaviorBits
        {
            [Realm.Library.Common.Enum("Sentinel", 1, "Sentinel", "86;13")]
            Sentinel,

            [Realm.Library.Common.Enum("Guard", 2, "Guard", "87;13")]
            Guard,

            [Realm.Library.Common.Enum("Wimpy", 4, "Wimpy", "88;13")]
            Wimpy,

            [Realm.Library.Common.Enum("Scavenger", 8, "Scavenger", "89;13")]
            Scavenger,

            [Realm.Library.Common.Enum("StayArea", 16, "StayArea", "90;13")]
            StayArea,

            [Realm.Library.Common.Enum("NonCombatant", 32, "NonCombatant", "91;13")]
            NonCombatant,

            [Realm.Library.Common.Enum("Berserker", 64, "Berserker", "92;13")]
            Berserker,

            [Realm.Library.Common.Enum("Aggressive", 128, "Aggressive", "93;13")]
            Aggressive,

            [Realm.Library.Common.Enum("Grazer", 256, "Grazer", "94;13")]
            Grazer,

            [Realm.Library.Common.Enum("Healer", 512, "Healer", "106;13")]
            Healer,

            [Realm.Library.Common.Enum("Patroller", 1024, "Patroller", "107;13")]
            Patroller,

            [Realm.Library.Common.Enum("Psycho", 2048, "Psycho", "108;13")]
            Psycho,

            [Realm.Library.Common.Enum("CorpseEater", 4096, "CorpseEater", "109;13")]
            CorpseEater,

            [Realm.Library.Common.Enum("CorpseLooter", 8192, "CorpseLooter", "110;13")]
            CorpseLooter,

            [Realm.Library.Common.Enum("PortalGuardian", 16384, "PortalGuardian", "111;13")]
            PortalGuardian,

            [Realm.Library.Common.Enum("Stalker", 32768, "Stalker", "112;13")]
            Stalker,

            [Realm.Library.Common.Enum("Hireling", 65536, "Hireling", "113;13")]
            Hireling,

            [Realm.Library.Common.Enum("Thief", 131072, "Thief", "114;13")]
            Thief,

            [Realm.Library.Common.Enum("Scout", 262144, "Scout", "115;13")]
            Scout,

            [Realm.Library.Common.Enum("Leader", 524288, "Leader", "116;13")]
            Leader,

            [Realm.Library.Common.Enum("Generator", 1048576, "Generator", "117;13")]
            Generator,

            [Realm.Library.Common.Enum("Transformer", 2097152, "Transformer", "118;13")]
            Transformer,

            [Realm.Library.Common.Enum("Exploder", 4194304, "Exploder", "119;13")]
            Exploder,

            [Realm.Library.Common.Enum("Terrorizer", 8388608, "Terrorizer", "120;13")]
            Terrorizer
        };

        // Globals generated from RealmStatic.ref.FlammabilityType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum FlammabilityTypes
        {
            [Realm.Library.Common.Enum("None", 1)]
            None,

            [Realm.Library.Common.Enum("Low", 2)]
            Low,

            [Realm.Library.Common.Enum("Moderate", 3)]
            Moderate,

            [Realm.Library.Common.Enum("High", 4)]
            High,

            [Realm.Library.Common.Enum("Extreme", 5)]
            Extreme
        };

        // Globals generated from RealmStatic.ref.FuelType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum FuelTypes
        {
            [Realm.Library.Common.Enum("Solid", 1)]
            Solid,

            [Realm.Library.Common.Enum("Liquid", 2)]
            Liquid
        };

        // Globals generated from RealmStatic.ref.GuildRankType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum GuildRankTypes
        {
            [Realm.Library.Common.Enum("Leader", 1)]
            Leader,

            [Realm.Library.Common.Enum("Officer", 2)]
            Officer,

            [Realm.Library.Common.Enum("Member", 3)]
            Member,

            [Realm.Library.Common.Enum("Recruit", 4)]
            Recruit
        };

        // Globals generated from RealmStatic.ref.MobileNodeType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum MobileNodeTypes
        {
            [Realm.Library.Common.Enum("Alive", 1)]
            Alive,

            [Realm.Library.Common.Enum("Dead", 2)]
            Dead
        };

        // Globals generated from RealmStatic.ref.QuestProgressType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum QuestProgressTypes
        {
            [Realm.Library.Common.Enum("GoTo", 1)]
            GoTo,

            [Realm.Library.Common.Enum("Kill", 2)]
            Kill,

            [Realm.Library.Common.Enum("Talk", 3)]
            Talk,

            [Realm.Library.Common.Enum("Use", 4)]
            Use,

            [Realm.Library.Common.Enum("Get", 5)]
            Get,

            [Realm.Library.Common.Enum("Create", 6)]
            Create,

            [Realm.Library.Common.Enum("Destroy", 7)]
            Destroy,

            [Realm.Library.Common.Enum("Buy", 8)]
            Buy,

            [Realm.Library.Common.Enum("Sell", 9)]
            Sell,

            [Realm.Library.Common.Enum("Die", 10)]
            Die
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum GameCommandBits
        {
            [Realm.Library.Common.Enum("AdminOnly", 1, "AdminOnly", "95;14")]
            AdminOnly,

            [Realm.Library.Common.Enum("WizardOnly", 2, "WizardOnly", "96;14")]
            WizardOnly
        };

        // Globals generated from RealmStatic.ref.SkillTestResultType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum SkillTestResultTypes
        {
            [Realm.Library.Common.Enum("Failure", 1)]
            Failure,

            [Realm.Library.Common.Enum("Success", 2)]
            Success,

            [Realm.Library.Common.Enum("Critical Success", 3)]
            CriticalSuccess,

            [Realm.Library.Common.Enum("Critical Failure", 4)]
            CriticalFailure
        };

        // Globals generated from RealmStatic.ref.SpeedClassType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum SpeedClassTypes
        {
            [Realm.Library.Common.Enum("Very Fast", 1)]
            VeryFast,

            [Realm.Library.Common.Enum("Fast", 2)]
            Fast,

            [Realm.Library.Common.Enum("Average", 3)]
            Average,

            [Realm.Library.Common.Enum("Slow", 4)]
            Slow,

            [Realm.Library.Common.Enum("Very Slow", 5)]
            VerySlow
        };

        // Globals generated from RealmStatic.ref.TargetClassType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum TargetClassTypes
        {
            [Realm.Library.Common.Enum("Self", 1)]
            Self,

            [Realm.Library.Common.Enum("Global", 2)]
            Global,

            [Realm.Library.Common.Enum("Single Enemy", 3)]
            SingleEnemy,

            [Realm.Library.Common.Enum("Single Friendly", 4)]
            SingleFriendly,

            [Realm.Library.Common.Enum("Single Ally", 5)]
            SingleAlly,

            [Realm.Library.Common.Enum("Area Enemy", 6)]
            AreaEnemy,

            [Realm.Library.Common.Enum("Area Friendly", 7)]
            AreaFriendly,

            [Realm.Library.Common.Enum("Area Ally", 8)]
            AreaAlly,

            [Realm.Library.Common.Enum("Single Any", 9)]
            SingleAny,

            [Realm.Library.Common.Enum("Area Any", 10)]
            AreaAny,

            [Realm.Library.Common.Enum("Single Space", 11)]
            SingleSpace,

            [Realm.Library.Common.Enum("Area Spaces", 12)]
            AreaSpaces,

            [Realm.Library.Common.Enum("Single Item", 13)]
            SingleItem,

            [Realm.Library.Common.Enum("Area Items", 14)]
            AreaItems,

            [Realm.Library.Common.Enum("Single Barrier", 15)]
            SingleBarrier
        };

        // Globals generated from RealmStatic.ref.ColorType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum ColorTypes
        {
            [Realm.Library.Common.Enum("Blink On", 1, "Blink On", "&A;\033[5m")]
            BlinkOn,

            [Realm.Library.Common.Enum("Blink Off", 2, "Blink Off", "&a;\033[25m")]
            BlinkOff,

            [Realm.Library.Common.Enum("Black", 3, "Black", "&k;\033[30m")]
            Black,

            [Realm.Library.Common.Enum("Blue", 4, "Blue", "&b;\033[34m")]
            Blue,

            [Realm.Library.Common.Enum("Green", 5, "Green", "&g;\033[32m")]
            Green,

            [Realm.Library.Common.Enum("Cyan", 6, "Cyan", "&c;\033[36m")]
            Cyan,

            [Realm.Library.Common.Enum("Red", 7, "Red", "&r;\033[31m")]
            Red,

            [Realm.Library.Common.Enum("Purple", 8, "Purple", "&p;\033[35m")]
            Purple,

            [Realm.Library.Common.Enum("Brown", 9, "Brown", "&y;\033[33m")]
            Brown,

            [Realm.Library.Common.Enum("Gray", 10, "Gray", "&w;\033[37m")]
            Gray,

            [Realm.Library.Common.Enum("Dark Gray", 11, "Dark Gray", "&d;\033[1;30m")]
            DarkGray,

            [Realm.Library.Common.Enum("Light Blue", 12, "Light Blue", "&B;\033[1;34m")]
            LightBlue,

            [Realm.Library.Common.Enum("Light Green", 13, "Light Green", "&G;\033[1;32m")]
            LightGreen,

            [Realm.Library.Common.Enum("Light Cyan", 14, "Light Cyan", "&C;\033[1;36m")]
            LightCyan,

            [Realm.Library.Common.Enum("Light Red", 15, "Light Red", "&R;\033[1;31m")]
            LightRed,

            [Realm.Library.Common.Enum("Light Purple", 16, "Light Purple", "&P;\033[1;35m")]
            LightPurple,

            [Realm.Library.Common.Enum("Yellow", 17, "Yellow", "&Y;\033[1;33m")]
            Yellow,

            [Realm.Library.Common.Enum("White", 18, "White", "&W;\033[1;37m")]
            White,

            [Realm.Library.Common.Enum("Clear", 19, "Clear", "&x;\033[0m")]
            Clear
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum ZoneBits
        {
            [Realm.Library.Common.Enum("IsDynamic", 1, "IsDynamic", "99;15")]
            IsDynamic,

            [Realm.Library.Common.Enum("SpellCanClose", 2, "SpellCanClose", "100;15")]
            SpellCanClose,

            [Realm.Library.Common.Enum("BossDeathCanClose", 4, "BossDeathCanClose", "101;15")]
            BossDeathCanClose,

            [Realm.Library.Common.Enum("RefreshPortals", 8, "RefreshPortals", "102;15")]
            RefreshPortals
        };

        // Globals generated from RealmStatic.ref.Bit
        public enum TerrainBits
        {
            [Realm.Library.Common.Enum("IsLitBySun", 1, "IsLitBySun", "105;15")]
            IsLitBySun
        }

        // Globals generated from RealmStatic.ref.GuildActionType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum GuildActionTypes
        {
            [Realm.Library.Common.Enum("Promote Member", 1)]
            PromoteMember,

            [Realm.Library.Common.Enum("Demote Member", 2)]
            DemoteMember,

            [Realm.Library.Common.Enum("Recruit New Member", 3)]
            RecruitNewMember,

            [Realm.Library.Common.Enum("Update Guild Information", 4)]
            UpdateGuildInformation,

            [Realm.Library.Common.Enum("Upgrade Bank Level", 5)]
            UpgradeBankLevel,

            [Realm.Library.Common.Enum("Withdraw From Bank", 6)]
            WithdrawFromBank,

            [Realm.Library.Common.Enum("Deposit To Bank", 7)]
            DepositToBank,

            [Realm.Library.Common.Enum("Kick From Guild", 8)]
            KickFromGuild
        };

        // Globals generated from RealmStatic.ref.ChannelStatusType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum ChannelStatusTypes
        {
            [Realm.Library.Common.Enum("On", 1)]
            On,

            [Realm.Library.Common.Enum("Off", 2)]
            Off
        };

        // Globals generated from RealmStatic.ref.MessageScopeType
        [Flags]
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum MessageScopeTypes
        {
            [Realm.Library.Common.Enum("Character", 1, "Character", "1")]
            Character,

            [Realm.Library.Common.Enum("Victim", 2, "Victim", "2")]
            Victim,

            [Realm.Library.Common.Enum("Space Limited", 4, "Space Limited", "3")]
            SpaceLimited,

            [Realm.Library.Common.Enum("Space", 8, "Space", "4")]
            Space,

            [Realm.Library.Common.Enum("Zone", 16, "Zone", "5")]
            Zone,

            [Realm.Library.Common.Enum("Game", 32, "Game", "6")]
            Game
        };

        // Globals generated from RealmStatic.ref.EntityLocationType
        [Flags]
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum EntityLocationTypes
        {
            [Realm.Library.Common.Enum("Space", 1, "Space", "1")]
            Space,

            [Realm.Library.Common.Enum("Inventory", 2, "Inventory", "2")]
            Inventory,

            [Realm.Library.Common.Enum("Equipment", 4, "Equipment", "3")]
            Equipment,

            [Realm.Library.Common.Enum("Container", 8, "Container", "4")]
            Container,

            [Realm.Library.Common.Enum("Mobile Inventory", 16, "Mobile Inventory", "5")]
            MobileInventory,

            [Realm.Library.Common.Enum("Mobile Equipment", 32, "Mobile Equipment", "6")]
            MobileEquipment,

            [Realm.Library.Common.Enum("Shop", 64, "Shop", "7")]
            Shop,

            [Realm.Library.Common.Enum("Ability", 128, "Ability", "8")]
            Ability,

            [Realm.Library.Common.Enum("Effects", 256, "Effects", "9")]
            Effects,

            [Realm.Library.Common.Enum("Recipes", 512, "Recipes", "10")]
            Recipes
        };

        // Globals generated from RealmStatic.ref.EffectDamageSourceType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum EffectDamageSourceTypes
        {
            [Realm.Library.Common.Enum("Weapon", 1)]
            Weapon,

            [Realm.Library.Common.Enum("Ability", 2)]
            Ability
        };

        // Globals generated from RealmStatic.ref.SpeechType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum SpeechTypes
        {
            [Realm.Library.Common.Enum("Tell", 1)]
            Tell,

            [Realm.Library.Common.Enum("Say", 2)]
            Say,

            [Realm.Library.Common.Enum("Shout", 3)]
            Shout,

            [Realm.Library.Common.Enum("Scream", 4)]
            Scream,

            [Realm.Library.Common.Enum("Whisper", 5)]
            Whisper
        };

        // Globals generated from RealmStatic.ref.CombatHitResultType
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum CombatHitResultTypes
        {
            [Realm.Library.Common.Enum("Niss", 1)]
            Niss,

            [Realm.Library.Common.Enum("Hit", 2)]
            Hit,

            [Realm.Library.Common.Enum("Parry", 3)]
            Parry,

            [Realm.Library.Common.Enum("Dodge", 4)]
            Dodge,

            [Realm.Library.Common.Enum("Block", 5)]
            Block,

            [Realm.Library.Common.Enum("Glance", 6)]
            Glance,

            [Realm.Library.Common.Enum("Devastate", 7)]
            Devastate
        };

        // Globals generated from RealmStatic.ref.StatusEffectType
        [Flags]
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum StatusEffectTypes
        {
            [Realm.Library.Common.Enum("None", 0, "None", "1")]
            None,

            [Realm.Library.Common.Enum("Mesmerize", 1, "Mesmerize", "2")]
            Mesmerize,

            [Realm.Library.Common.Enum("Stun", 2, "Stun", "3")]
            Stun,

            [Realm.Library.Common.Enum("Blind", 4, "Blind", "4")]
            Blind,

            [Realm.Library.Common.Enum("Mute", 8, "Mute", "5")]
            Mute,

            [Realm.Library.Common.Enum("Immobilized", 16, "Immobilized", "6")]
            Immobilized,

            [Realm.Library.Common.Enum("Unconcious", 32, "Unconcious", "7")]
            Unconcious
        };

        // Globals generated from RealmStatic.ref.DayStateType
        [Flags]
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum DayStateTypes
        {
            [Realm.Library.Common.Enum("Dawn", 1, "Dawn", "1")]
            Dawn,

            [Realm.Library.Common.Enum("Daylight", 2, "Daylight", "2")]
            Daylight,

            [Realm.Library.Common.Enum("Dusk", 4, "Dusk", "3")]
            Dusk,

            [Realm.Library.Common.Enum("Night", 8, "Night", "4")]
            Night
        };

        // Globals generated from RealmStatic.ref.SpawnType
        [Flags]
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
        public enum SpawnTypes
        {
            [Realm.Library.Common.Enum("None", 1)]
            None,

            [Realm.Library.Common.Enum("Space", 2)]
            Space,

            [Realm.Library.Common.Enum("Access", 3)]
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