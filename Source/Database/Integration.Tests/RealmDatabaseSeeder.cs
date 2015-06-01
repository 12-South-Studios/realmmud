using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Ninject;
using Realm.DAL;
using Realm.DAL.Enumerations;
using Realm.DAL.Models;

namespace Integration.Tests
{
    public static class RealmDatabaseSeeder
    {
        public static IKernel Kernel;

        public static void Seed()
        {
            using (var context = Kernel.Get<IRealmDbContext>())
            {
                SeedSystemClasses(context);
                SeedBits(context);
                SeedColors(context);
                SeedElements(context);
                SeedEvents(context);
                SeedGuildLevels(context);
                SeedMovementModes(context);
                SeedTags(context);
                SeedWearLocations(context);
                context.SaveChanges();
            }

            AddHelp();
            AddMonths();

            AddTerrain();
            AddBarriers();
            AddSpaces();
            AddZones();
        }

        #region Lookup Data
        private static void SeedSystemClasses(IRealmDbContext context)
        {
            foreach (var key in SystemClassTable.Keys)
            {
                var kvp = SystemClassTable[key];

                context.SystemClasses.AddOrUpdate(x => x.Id, new SystemClass
                {
                    Id = key,
                    Name = kvp.Key,
                    SystemType = kvp.Value
                });
            }
        }

        private static readonly Dictionary<int, KeyValuePair<string, SystemTypes>> SystemClassTable = new Dictionary
            <int, KeyValuePair<string, SystemTypes>>
        {
            {1, new KeyValuePair<string, SystemTypes>("rootZones", SystemTypes.Zone)},
            {2, new KeyValuePair<string, SystemTypes>("rootTerrains", SystemTypes.Terrain)},
            {3, new KeyValuePair<string, SystemTypes>("rootSpaces", SystemTypes.Space)},
            {4, new KeyValuePair<string, SystemTypes>("rootSocials", SystemTypes.Social)},
            {5, new KeyValuePair<string, SystemTypes>("rootSkills", SystemTypes.Skill)},
            {6, new KeyValuePair<string, SystemTypes>("rootSkillCategories", SystemTypes.SkillCategory)},
            {7, new KeyValuePair<string, SystemTypes>("rootResets", SystemTypes.Reset)},
            {8, new KeyValuePair<string, SystemTypes>("rootRaces", SystemTypes.Race)},
            {9, new KeyValuePair<string, SystemTypes>("rootMudProgs", SystemTypes.MudProg)},
            {10, new KeyValuePair<string, SystemTypes>("rootMonths", SystemTypes.Month)},
            {11, new KeyValuePair<string, SystemTypes>("rootLiquids", SystemTypes.Liquid)},
            {12, new KeyValuePair<string, SystemTypes>("rootItems", SystemTypes.Item)},
            {13, new KeyValuePair<string, SystemTypes>("rootHelpLookups", SystemTypes.HelpLookup)},
            {14, new KeyValuePair<string, SystemTypes>("rootGameCommands", SystemTypes.GameCommand)},
            {15, new KeyValuePair<string, SystemTypes>("rootFactions", SystemTypes.Faction)},
            {16, new KeyValuePair<string, SystemTypes>("rootEffects", SystemTypes.Effect)},
            {17, new KeyValuePair<string, SystemTypes>("rootArchetypes", SystemTypes.Archetype)},
            {18, new KeyValuePair<string, SystemTypes>("rootAbilities", SystemTypes.Ability)},
            {19, new KeyValuePair<string, SystemTypes>("rootBehaviors", SystemTypes.Behavior)},
            {20, new KeyValuePair<string, SystemTypes>("rootChannels", SystemTypes.Channel)},
            {21, new KeyValuePair<string, SystemTypes>("rootConversations", SystemTypes.Conversation)},
            {22, new KeyValuePair<string, SystemTypes>("rootItemSets", SystemTypes.ItemSet)},
            {23, new KeyValuePair<string, SystemTypes>("rootMobiles", SystemTypes.Mobile)},
            {24, new KeyValuePair<string, SystemTypes>("rootStrings", SystemTypes.String)},
            {25, new KeyValuePair<string, SystemTypes>("rootBarriers", SystemTypes.Barrier)},
            {26, new KeyValuePair<string, SystemTypes>("rootQuests", SystemTypes.Quest)},
            {27, new KeyValuePair<string, SystemTypes>("rootRituals", SystemTypes.Ritual)},
            {28, new KeyValuePair<string, SystemTypes>("rootTreasures", SystemTypes.Treasure)},
            {29, new KeyValuePair<string, SystemTypes>("rootShops", SystemTypes.Shop)},
            {30, new KeyValuePair<string, SystemTypes>("rootSpawns", SystemTypes.Spawn)}
        };

        private static void SeedBits(IRealmDbContext context)
        {
            foreach (var key in BitTable.Keys)
            {
                var values = BitTable[key];

                context.Bits.AddOrUpdate(x => x.Id, new Bit
                {
                    Id = key,
                    Name = (string)values[0],
                    Value = (int)values[1],
                    BitType = (BitTypes)values[2],
                    Description = values[3] == null ? string.Empty : (string)values[3],
                    UniqueGroup = values[4] == null ? string.Empty : (string)values[4]
                });
            }
        }

        private static readonly Dictionary<int, List<object>> BitTable = new Dictionary<int, List<object>>
        {
            {1, new List<object> {"AutoAttack", 1, BitTypes.AbilityBits, null, null}},
            {2, new List<object> {"NotInterruptible", 2, BitTypes.AbilityBits, "Not Interruptible", null}},
            {3, new List<object> {"WeaponRequired", 4, BitTypes.AbilityBits, "Weapon Required", null}},
            {4, new List<object> {"ImplementRequired", 8, BitTypes.AbilityBits, "Implement Required", null}},
            {5, new List<object> {"VerbalRequired", 16, BitTypes.AbilityBits, "Verbal Required", null}},
            {6, new List<object> {"Passive", 32, BitTypes.AbilityBits, null, null}},
            {7, new List<object> {"TerrainRequired", 64, BitTypes.AbilityBits, "Terrain Required", null}},
            {8, new List<object> {"NoCombatUse", 128, BitTypes.AbilityBits, "No Combat Use", null}},
            {9, new List<object> {"SightRequired", 256, BitTypes.AbilityBits, "Sight Required", null}},
            {10, new List<object> {"IsHidden", 1, BitTypes.ItemBits, null, null}},
            {11, new List<object> {"IsTradeable", 2, BitTypes.ItemBits, null, null}},
            {12, new List<object> {"IsRepairable", 4, BitTypes.ItemBits, null, null}},
            {13, new List<object> {"IsTakeable", 8, BitTypes.ItemBits, null, null}},
            {14, new List<object> {"IsLockable", 16, BitTypes.ItemBits, null, null}},
            {15, new List<object> {"IsCloseable", 32, BitTypes.ItemBits, null, null}},
            {16, new List<object> {"IsLocked", 64, BitTypes.ItemBits, null, null}},
            {17, new List<object> {"IsRelockable", 128, BitTypes.ItemBits, null, null}},
            {18, new List<object> {"IsMagical", 256, BitTypes.ItemBits, null, null}},
            {19, new List<object> {"DestroyedOnUse", 512, BitTypes.ItemBits, "Destroyed On Use", null}},
            {20, new List<object> {"NotifyArea", 1024, BitTypes.ItemBits, "Notify Area", null}},
            {21, new List<object> {"IsClosed", 2048, BitTypes.ItemBits, null, null}},
            {22, new List<object> {"IsBreakable", 4096, BitTypes.ItemBits, null, null}},
            {23, new List<object> {"IsThrowable", 8192, BitTypes.ItemBits, null, null}},
            {24, new List<object> {"IsRemoveable", 16384, BitTypes.ItemBits, null, null}},
            {25, new List<object> {"ReadOnly", 1, BitTypes.ChannelBits, null, null}},
            {26, new List<object> {"Admin", 2, BitTypes.ChannelBits, null, null}},
            {27, new List<object> {"IsRemoveable", 1, BitTypes.EffectBits, null, null}},
            {28, new List<object> {"IsTavern", 2, BitTypes.EffectBits, null, null}},
            {29, new List<object> {"IsSafe", 4, BitTypes.EffectBits, null, null}},
            {30, new List<object> {"OnEnter", 8, BitTypes.EffectBits, null, null}},
            {31, new List<object> {"OnTurn", 16, BitTypes.EffectBits, null, null}},
            {32, new List<object> {"DetectInvisible", 1, BitTypes.RaceBits, "Detect Invisible", null}},
            {33, new List<object> {"DetectHidden", 2, BitTypes.RaceBits, "Detect Hidden", null}},
            {34, new List<object> {"Infravision", 4, BitTypes.RaceBits, null, null}},
            {35, new List<object> {"MoveSilently", 8, BitTypes.RaceBits, "Move Silently", null}},
            {36, new List<object> {"IsCloseable", 1, BitTypes.BarrierBits, null, null}},
            {37, new List<object> {"IsClosed", 2, BitTypes.BarrierBits, null, null}},
            {38, new List<object> {"IsOneWay", 4, BitTypes.BarrierBits, null, null}},
            {39, new List<object> {"IsTransparent", 8, BitTypes.BarrierBits, null, null}},
            {40, new List<object> {"IsDestroyable", 16, BitTypes.BarrierBits, null, null}},
            {41, new List<object> {"IsDispellable", 32, BitTypes.BarrierBits, null, null}},
            {42, new List<object> {"IsLockable", 64, BitTypes.BarrierBits, null, null}},
            {43, new List<object> {"IsJumpable", 128, BitTypes.BarrierBits, null, null}},
            {44, new List<object> {"IsClimbable", 256, BitTypes.BarrierBits, null, null}},
            {45, new List<object> {"IsSwimmable", 512, BitTypes.BarrierBits, null, null}},
            {46, new List<object> {"IsDestroyed", 1024, BitTypes.BarrierBits, null, null}},
            {47, new List<object> {"IsTrapable", 2048, BitTypes.BarrierBits, null, null}},
            {48, new List<object> {"IsLocked", 4096, BitTypes.BarrierBits, null, null}},
            {49, new List<object> {"IsHidden", 1, BitTypes.PortalBits, null, null}},
            {50, new List<object> {"IsTransparent", 2, BitTypes.PortalBits, null, null}},
            {51, new List<object> {"NoMobAllowed", 1, BitTypes.SpaceBits, null, null}},
            {52, new List<object> {"NoRecall", 2, BitTypes.SpaceBits, null, null}},
            {53, new List<object> {"NoSummon", 4, BitTypes.SpaceBits, null, null}},
            {54, new List<object> {"IsSafe", 8, BitTypes.SpaceBits, null, null}},
            {55, new List<object> {"NoMagic", 16, BitTypes.SpaceBits, null, null}},
            {56, new List<object> {"IsShrine", 32, BitTypes.SpaceBits, null, null}},
            {57, new List<object> {"IsTavern", 64, BitTypes.SpaceBits, null, null}},
            {58, new List<object> {"IsHarvestable", 1, BitTypes.MobileBits, null, null}},
            {59, new List<object> {"IsTrainer", 2, BitTypes.MobileBits, null, null}},
            {60, new List<object> {"IsPostman", 4, BitTypes.MobileBits, null, null}},
            {61, new List<object> {"IsMerchant", 8, BitTypes.MobileBits, null, null}},
            {62, new List<object> {"IsCoroner", 16, BitTypes.MobileBits, null, null}},
            {63, new List<object> {"IsBanker", 32, BitTypes.MobileBits, null, null}},
            {64, new List<object> {"IsBlacksmith", 64, BitTypes.MobileBits, null, null}},
            {65, new List<object> {"IsHealer", 128, BitTypes.MobileBits, null, null}},
            {66, new List<object> {"IsAuctioneer", 256, BitTypes.MobileBits, null, null}},
            {67, new List<object> {"NoSummon", 512, BitTypes.MobileBits, null, null}},
            {68, new List<object> {"NoAttack", 1024, BitTypes.MobileBits, null, null}},
            {69, new List<object> {"NoCharm", 2048, BitTypes.MobileBits, null, null}},
            {70, new List<object> {"NoBash", 4096, BitTypes.MobileBits, null, null}},
            {71, new List<object> {"NoBlind", 8192, BitTypes.MobileBits, null, null}},
            {72, new List<object> {"Cancellable", 1, BitTypes.QuestBits, null, null}},
            {73, new List<object> {"FailOnDeath", 2, BitTypes.QuestBits, null, null}},
            {74, new List<object> {"FailOnTimerExpire", 4, BitTypes.QuestBits, null, null}},
            {75, new List<object> {"OnFail", 1, BitTypes.RitualBits, null, null}},
            {76, new List<object> {"OnSuccess", 2, BitTypes.RitualBits, null, null}},
            {77, new List<object> {"OnBirth", 1, BitTypes.SpawnBits, null, null}},
            {78, new List<object> {"OnDeath", 2, BitTypes.SpawnBits, null, null}},
            {79, new List<object> {"OnHit", 4, BitTypes.SpawnBits, null, null}},
            {80, new List<object> {"Sentinel", 1, BitTypes.BehaviorBits, null, null}},
            {81, new List<object> {"Guard", 2, BitTypes.BehaviorBits, null, null}},
            {82, new List<object> {"Wimpy", 4, BitTypes.BehaviorBits, null, null}},
            {83, new List<object> {"Scavenger", 8, BitTypes.BehaviorBits, null, null}},
            {84, new List<object> {"StayArea", 16, BitTypes.BehaviorBits, null, null}},
            {85, new List<object> {"NonCombatant", 32, BitTypes.BehaviorBits, null, null}},
            {86, new List<object> {"Berserker", 64, BitTypes.BehaviorBits, null, null}},
            {87, new List<object> {"Aggressive", 128, BitTypes.BehaviorBits, null, null}},
            {88, new List<object> {"Grazer", 256, BitTypes.BehaviorBits, null, null}},
            {89, new List<object> {"AdminOnly", 1, BitTypes.GameCommandBits, null, null}},
            {90, new List<object> {"WizardOnly", 2, BitTypes.GameCommandBits, null, null}},
            {91, new List<object> {"IsDynamic", 128, BitTypes.SpaceBits, null, null}},
            {92, new List<object> {"AllowDynamic", 256, BitTypes.SpaceBits, null, null}},
            {93, new List<object> {"IsDynamic", 1, BitTypes.ZoneBits, null, null}},
            {94, new List<object> {"SpellCanClose", 2, BitTypes.ZoneBits, null, null}},
            {95, new List<object> {"BossDeathCanClose", 4, BitTypes.ZoneBits, null, null}},
            {96, new List<object> {"RefreshPortals", 8, BitTypes.ZoneBits, null, null}},
            {97, new List<object> {"IsDynamic", 8, BitTypes.PortalBits, null, null}},
            {98, new List<object> {"IsStartup", 16, BitTypes.ZoneBits, null, null}},
            {99, new List<object> {"IsLitBySun", 1, BitTypes.TerrainBits, null, null}},
            {100, new List<object> {"Healer", 512, BitTypes.BehaviorBits, null, null}},
            {101, new List<object> {"Patroller", 1024, BitTypes.BehaviorBits, null, null}},
            {102, new List<object> {"Psycho", 2048, BitTypes.BehaviorBits, null, null}},
            {103, new List<object> {"CorpseEater", 4096, BitTypes.BehaviorBits, null, null}},
            {104, new List<object> {"CorpseLooter", 8192, BitTypes.BehaviorBits, null, null}},
            {105, new List<object> {"PortalGuardian", 16384, BitTypes.BehaviorBits, null, null}},
            {106, new List<object> {"Stalker", 32768, BitTypes.BehaviorBits, null, null}},
            {107, new List<object> {"Hireling", 65536, BitTypes.BehaviorBits, null, null}},
            {108, new List<object> {"Thief", 131072, BitTypes.BehaviorBits, null, null}},
            {109, new List<object> {"Scout", 262144, BitTypes.BehaviorBits, null, null}},
            {110, new List<object> {"Leader", 524288, BitTypes.BehaviorBits, null, null}},
            {111, new List<object> {"Generator", 1048576, BitTypes.BehaviorBits, null, null}},
            {112, new List<object> {"Transformer", 2097152, BitTypes.BehaviorBits, null, null}},
            {113, new List<object> {"Exploder", 4194304, BitTypes.BehaviorBits, null, null}},
            {114, new List<object> {"Terrorizer", 8388608, BitTypes.BehaviorBits, null, null}},
            {115, new List<object> {"Wizard", 4, BitTypes.ChannelBits, null, null}},
            {116, new List<object> {"Builder", 8, BitTypes.ChannelBits, null, null}},
            {117, new List<object> {"Player", 16, BitTypes.ChannelBits, null, null}},

        };

        private static void SeedColors(IRealmDbContext context)
        {
            foreach (var key in ColorsTable.Keys)
            {
                var values = ColorsTable[key];

                context.Colors.AddOrUpdate(x => x.Id, new Color
                {
                    Id = key,
                    Name = (string)values[0],
                    Ascii = (string)values[1],
                    Escape = (string)values[2]
                });
            }
        }

        private static readonly Dictionary<int, List<object>> ColorsTable = new Dictionary<int, List<object>>
        {
            {1, new List<object> {"Blink On", "&A", "\033[5m"}},
            {2, new List<object> {"Blink Off", "&a", "\033[25m"}},
            {3, new List<object> {"Black", "&k", "\033[30m"}},
            {4, new List<object> {"Blue", "&b", "\033[34m"}},
            {5, new List<object> {"Green", "&g", "\033[32m"}},
            {6, new List<object> {"Cyan", "&c", "\033[36m"}},
            {7, new List<object> {"Red", "&r", "\033[31m"}},
            {8, new List<object> {"Purple", "&p", "\033[35m"}},
            {9, new List<object> {"Brown", "&y", "\033[33m"}},
            {10, new List<object> {"Gray", "&w", "\033[37m"}},
            {11, new List<object> {"Dark Gray", "&d", "\033[1;30m"}},
            {12, new List<object> {"Light Blue", "&B", "\033[1;34m"}},
            {13, new List<object> {"Light Green", "&G", "\033[1;32m"}},
            {14, new List<object> {"Light Cyan", "&C", "\033[1;36m"}},
            {15, new List<object> {"Light Red", "&R", "\033[1;31m"}},
            {16, new List<object> {"Light Purple", "&P", "\033[1;35m"}},
            {17, new List<object> {"Yellow", "&Y", "\033[1;33m"}},
            {18, new List<object> {"White", "&W", "\033[1;37m"}},
            {19, new List<object> {"Clear", "&x", "\033[0m"}}
        };

        private static void SeedElements(IRealmDbContext context)
        {
            foreach (var key in ElementsTable.Keys)
            {
                var values = ElementsTable[key];

                context.Elements.AddOrUpdate(x => x.Id, new Element
                {
                    Id = key,
                    Name = (string)values[0],
                    OppositeElementId = (int)values[1],
                    LeftElementId = (int)values[2],
                    RightElementId = (int)values[3]
                });
            }
        }

        private static readonly Dictionary<int, List<object>> ElementsTable = new Dictionary<int, List<object>>
        {
            {1, new List<object> {"Void", 0, 0, 0}},
            {2, new List<object> {"Light", 3, 4, 6}},
            {3, new List<object> {"Shadow", 2, 5, 7}},
            {4, new List<object> {"Fire", 7, 5, 2}},
            {5, new List<object> {"Earth", 6, 4, 3}},
            {6, new List<object> {"Air", 5, 2, 7}},
            {7, new List<object> {"Water", 4, 6, 3}}
        };

        private static void SeedEvents(IRealmDbContext context)
        {
            foreach (var key in EventsTable.Keys)
            {
                var values = EventsTable[key];

                context.Events.AddOrUpdate(x => x.Id, new Event
                {
                    Id = key,
                    Name = (string)values[0],
                    IsItemEvent = (bool)values[1],
                    IsMobileEvent = (bool)values[2],
                    IsSpaceEvent = (bool)values[3]
                });
            }
        }

        private static readonly Dictionary<int, List<object>> EventsTable = new Dictionary<int, List<object>>
        {
            {1, new List<object> {"OnAcquire", true, true, true}},
            {2, new List<object> {"OnHeartbeat", true, true, true}},
            {3, new List<object> {"OnPlayerAction", true, true, true}},
            {4, new List<object> {"OnPlayerChat", true, true, true}},
            {5, new List<object> {"OnPlayerDeath", true, true, true}},
            {6, new List<object> {"OnPlayerEquip", true, true, true}},
            {7, new List<object> {"OnPlayerLevelUp", true, true, true}},
            {8, new List<object> {"OnPlayerRespawn", true, true, true}},
            {9, new List<object> {"OnPlayerUnequip", true, true, true}},
            {10, new List<object> {"OnUnacquire", true, true, true}},
            {11, new List<object> {"OnZoneEnter", true, true, true}},
            {12, new List<object> {"OnZoneLeave", true, true, true}},
            {13, new List<object> {"OnClose", true, false, true}},
            {14, new List<object> {"OnFailToOpen", true, false, true}},
            {15, new List<object> {"OnLock", true, false, true}},
            {16, new List<object> {"OnOpen", true, false, true}},
            {17, new List<object> {"OnTrapTriggered", true, false, false}},
            {18, new List<object> {"OnUnlock", true, false, true}},
            {19, new List<object> {"OnUsed", true, false, false}},
            {20, new List<object> {"OnConversation", false, true, false}},
            {21, new List<object> {"OnDamaged", false, true, false}},
            {22, new List<object> {"OnDeath", false, true, false}},
            {23, new List<object> {"OnDisarm", false, true, false}},
            {24, new List<object> {"OnPerception", false, true, false}},
            {25, new List<object> {"OnPhysicalAttacked", false, true, false}},
            {26, new List<object> {"OnSpawn", false, true, false}},
            {27, new List<object> {"OnSpellCastAt", false, true, false}},
            {28, new List<object> {"OnStoreClosed", false, true, false}},
            {29, new List<object> {"OnEnter", false, false, true}},
            {30, new List<object> {"OnExit", false, false, true}},
            {31, new List<object> {"OnSunrise", false, false, true}},
            {32, new List<object> {"OnSunset", false, false, true}}
        };

        private static void SeedGuildLevels(IRealmDbContext context)
        {
            foreach (var key in GuildLevelTable.Keys)
            {
                var values = GuildLevelTable[key];

                context.GuildLevels.AddOrUpdate(x => x.Id, new GuildLevel
                {
                    Id = key,
                    Level = (int)values[0],
                    XpRequired = (int)values[1],
                    MaxNumberOfMembers = (int)values[2]
                });
            }
        }

        private static readonly Dictionary<int, List<object>> GuildLevelTable = new Dictionary<int, List<object>>
        {
            {1, new List<object> {1, 0, 5}},
            {2, new List<object> {2, 1000, 10}},
            {3, new List<object> {3, 2500, 10}},
            {4, new List<object> {4, 4500, 15}},
            {5, new List<object> {5, 7000, 15}}
        };

        private static void SeedMovementModes(IRealmDbContext context)
        {
            foreach (var key in MovementModeTable.Keys)
            {
                var values = MovementModeTable[key];

                context.MovementModes.AddOrUpdate(x => x.Id, new MovementMode
                {
                    Id = key,
                    Name = (string)values[0],
                    Value = (int)values[1],
                    ShortNamne = (string)values[2]
                });
            }
        }

        private static readonly Dictionary<int, List<object>> MovementModeTable = new Dictionary<int, List<object>>
        {
            {1, new List<object> {"Walking", 1, "Walk"}},
            {2, new List<object> {"Flying", 2, "Fly"}},
            {3, new List<object> {"Climbing", 4, "Climb"}},
            {4, new List<object> {"Swimming", 8, "Swim"}},
            {5, new List<object> {"Riding", 16, "Ride"}},
            {6, new List<object> {"Crawling", 32, "Crawl"}}
        };

        private static void SeedTags(IRealmDbContext context)
        {
            foreach (var key in TagTable.Keys)
            {
                var values = TagTable[key];
                context.Tags.AddOrUpdate(x => x.Id, new Tag
                {
                    Id = key,
                    TagCategory = (TagCategoryTypes)values[0],
                    Name = (string)values[1],
                });
            }
        }

        private static readonly Dictionary<int, List<object>> TagTable = new Dictionary<int, List<object>>
        {
            {1, new List<object> {TagCategoryTypes.AbilityTags, "Arcane"}},
            {2, new List<object> {TagCategoryTypes.AbilityTags, "Mystical"}},
            {3, new List<object> {TagCategoryTypes.AbilityTags, "Divine"}},
            {4, new List<object> {TagCategoryTypes.AbilityTags, "AoE"}},
            {5, new List<object> {TagCategoryTypes.AbilityTags, "Friendly"}},
            {6, new List<object> {TagCategoryTypes.AbilityTags, "Hostile"}},
            {7, new List<object> {TagCategoryTypes.AbilityTags, "Ranged"}},

            {8, new List<object> {TagCategoryTypes.ItemTags, "Light"}},
            {9, new List<object> {TagCategoryTypes.ItemTags, "Heavy"}},
            {10, new List<object> {TagCategoryTypes.ItemTags, "Cloth"}},
            {11, new List<object> {TagCategoryTypes.ItemTags, "Hide"}},
            {12, new List<object> {TagCategoryTypes.ItemTags, "Leather"}},
            {13, new List<object> {TagCategoryTypes.ItemTags, "Chain"}},
            {14, new List<object> {TagCategoryTypes.ItemTags, "Scale"}},
            {15, new List<object> {TagCategoryTypes.ItemTags, "Ring"}},
            {16, new List<object> {TagCategoryTypes.ItemTags, "Plate"}},
            {17, new List<object> {TagCategoryTypes.ItemTags, "Weapon"}},
            {18, new List<object> {TagCategoryTypes.ItemTags, "Implement"}},
            {19, new List<object> {TagCategoryTypes.ItemTags, "Shield"}},
            {20, new List<object> {TagCategoryTypes.ItemTags, "Helm"}},

            {21, new List<object> {TagCategoryTypes.ZoneTags, "System"}},
            {22, new List<object> {TagCategoryTypes.ZoneTags, "Player"}},

            {23, new List<object> {TagCategoryTypes.SpaceTags, "Underground"}},

            {24, new List<object> {TagCategoryTypes.BarrierTags, "Wood"}},
            {25, new List<object> {TagCategoryTypes.BarrierTags, "Stone"}},
            {26, new List<object> {TagCategoryTypes.BarrierTags, "Metal"}},

            {27, new List<object> {TagCategoryTypes.GeneralTags, "Light"}},
            {28, new List<object> {TagCategoryTypes.GeneralTags, "Shadow"}},
            {29, new List<object> {TagCategoryTypes.GeneralTags, "Air"}},
            {30, new List<object> {TagCategoryTypes.GeneralTags, "Fire"}},
            {31, new List<object> {TagCategoryTypes.GeneralTags, "Water"}},
            {32, new List<object> {TagCategoryTypes.GeneralTags, "Earth"}},
            {33, new List<object> {TagCategoryTypes.GeneralTags, "Void"}},
            {34, new List<object> {TagCategoryTypes.GeneralTags, "Martial"}},
            {35, new List<object> {TagCategoryTypes.GeneralTags, "Magical"}},
            {36, new List<object> {TagCategoryTypes.GeneralTags, "Tiny"}},
            {37, new List<object> {TagCategoryTypes.GeneralTags, "Small"}},
            {38, new List<object> {TagCategoryTypes.GeneralTags, "Medium"}},
            {39, new List<object> {TagCategoryTypes.GeneralTags, "Large"}},
            {40, new List<object> {TagCategoryTypes.GeneralTags, "Huge"}},
            {41, new List<object> {TagCategoryTypes.GeneralTags, "Gargantuan"}},

            {42, new List<object> {TagCategoryTypes.EffectTags, "Crush"}},
            {43, new List<object> {TagCategoryTypes.EffectTags, "Slash"}},
            {44, new List<object> {TagCategoryTypes.EffectTags, "Pierce"}},
            {45, new List<object> {TagCategoryTypes.EffectTags, "Healing"}},
            {46, new List<object> {TagCategoryTypes.EffectTags, "Burn"}},
            {47, new List<object> {TagCategoryTypes.EffectTags, "Freeze"}},
            {48, new List<object> {TagCategoryTypes.EffectTags, "Disease"}},
            {49, new List<object> {TagCategoryTypes.EffectTags, "Fear"}},
            {50, new List<object> {TagCategoryTypes.EffectTags, "Poison"}},
            {51, new List<object> {TagCategoryTypes.EffectTags, "Spirit"}},
            {52, new List<object> {TagCategoryTypes.EffectTags, "Acid"}},
            {53, new List<object> {TagCategoryTypes.EffectTags, "Zone"}},
            {54, new List<object> {TagCategoryTypes.EffectTags, "Global"}},
            {55, new List<object> {TagCategoryTypes.EffectTags, "Buff"}},
            {56, new List<object> {TagCategoryTypes.EffectTags, "Debuff"}},
            {57, new List<object> {TagCategoryTypes.EffectTags, "Mesmerize"}},
            {58, new List<object> {TagCategoryTypes.EffectTags, "Stun"}},
            {59, new List<object> {TagCategoryTypes.EffectTags, "Blind"}},
            {60, new List<object> {TagCategoryTypes.EffectTags, "Root"}},
            {61, new List<object> {TagCategoryTypes.EffectTags, "Slow"}},
            {62, new List<object> {TagCategoryTypes.EffectTags, "Mute"}},
            {63, new List<object> {TagCategoryTypes.EffectTags, "Immobilize"}},
            {64, new List<object> {TagCategoryTypes.EffectTags, "Unconcious"}},

            {65, new List<object> {TagCategoryTypes.MobileTags, "Elemental"}},
            {66, new List<object> {TagCategoryTypes.MobileTags, "Natural"}},
            {67, new List<object> {TagCategoryTypes.MobileTags, "Aberrant"}},
            {68, new List<object> {TagCategoryTypes.MobileTags, "Fey"}},
            {69, new List<object> {TagCategoryTypes.MobileTags, "Immortal"}},
            {70, new List<object> {TagCategoryTypes.MobileTags, "Undead"}},
            {71, new List<object> {TagCategoryTypes.MobileTags, "Construct"}},
            {72, new List<object> {TagCategoryTypes.MobileTags, "Animate"}},
            {73, new List<object> {TagCategoryTypes.MobileTags, "Dragon"}},
            {74, new List<object> {TagCategoryTypes.MobileTags, "Humanoid"}},
            {75, new List<object> {TagCategoryTypes.MobileTags, "Beast"}},
            {76, new List<object> {TagCategoryTypes.MobileTags, "Swarm"}},
            {77, new List<object> {TagCategoryTypes.MobileTags, "Blind"}},
            {78, new List<object> {TagCategoryTypes.MobileTags, "Spider"}},
            {79, new List<object> {TagCategoryTypes.MobileTags, "Reptile"}},
            {80, new List<object> {TagCategoryTypes.MobileTags, "Avian"}}
        };

        private static void SeedWearLocations(IRealmDbContext context)
        {
            foreach (var key in WearLocationTable.Keys)
            {
                var values = WearLocationTable[key];

                context.WearLocations.AddOrUpdate(x => x.Id, new WearLocation
                {
                    Id = key,
                    Name = (string)values[0],
                    Value = (int)values[1],
                    ShortNamne = (string)values[2],
                    LongName = (string)values[3]
                });
            }
        }

        private static readonly Dictionary<int, List<object>> WearLocationTable = new Dictionary<int, List<object>>
        {
            {1, new List<object> {"wear_head", 1, "Head", "Worn on Head"}},
            {2, new List<object> {"wear_face", 2, "Face", "Worn on Face"}},
            {3, new List<object> {"wear_ear_left", 4, "Left Ear", "Worn in Left Ear"}},
            {4, new List<object> {"wear_ear_right", 8, "Right Ear", "Worn in Right ear"}},
            {5, new List<object> {"wear_brow", 16, "Brow", "Worn on Brow"}},
            {6, new List<object> {"wear_neck", 32, "Neck", "Worn about Neck"}},
            {7, new List<object> {"wear_wrist_left", 64, "Left Wrist", "Worn on Left Wrist"}},
            {8, new List<object> {"wear_wrist_right", 128, "Right Wrist", "Worn on Right Wrist"}},
            {9, new List<object> {"wear_wrist_both", 256, "Both Wrists", "Worn on Both Wrists"}},
            {10, new List<object> {"wear_hand_left", 512, "Left Hand", "Held in Left Hand"}},
            {11, new List<object> {"wear_hand_right", 1024, "Right Hand", "Held in Right Hand"}},
            {12, new List<object> {"wear_hand_both", 2048, "Both Hands", "Held in Both Hands"}},
            {13, new List<object> {"wear_finger_left", 4096, "Left Ring Finger", "Worn on Left Ring Finger"}},
            {14, new List<object> {"wear_finger_right", 8192, "Right Ring Finger", "Worn on Right Ring Finger"}},
            {15, new List<object> {"wear_chest", 16384, "Chest", "Worn on Torso"}},
            {16, new List<object> {"wear_back", 32768, "Back", "Worn on Back"}},
            {17, new List<object> {"wear_waist", 65536, "Waist", "Worn abotu Waist"}},
            {18, new List<object> {"wear_legs", 131072, "Legs", "Worn on Legs"}},
            {19, new List<object> {"wear_arms", 262144, "Arms", "Worn on Arms"}},
            {20, new List<object> {"wear_ankle_left", 524288, "Left Ankle", "Worn on Left Ankle"}},
            {21, new List<object> {"wear_ankle_right", 1048576, "Right Ankle", "Worn on Right Ankle"}},
            {22, new List<object> {"wear_ankle_both", 2097152, "Both Ankles", "Worn on Both Ankles"}},
            {23, new List<object> {"wear_feet", 4194304, "Feet", "Worn on Feet"}},
            {24, new List<object> {"wear_body", 8388608, "Body", "Worn about Body"}},
            {25, new List<object> {"none", 0, "None", "None"}},
        };
        #endregion

        private static void AddHelp()
        {
            using (var dbContext = Kernel.Get<IRealmDbContext>())
            {
                foreach (var values in HelpTable.Keys.Select(key => HelpTable[key]))
                {
                    dbContext.Helps.Add(new Help
                    {
                        SystemClass = dbContext.SystemClasses.First(x => x.Name == "rootHelpLookups"),
                        SystemName = (string)values[0],
                        DisplayName = (string)values[1],
                        Keywords = (string)values[2],
                        Text = (string)values[3]
                    });
                }
                dbContext.SaveChanges();
            } 
        }
        
        private static readonly Dictionary<int, List<object>> HelpTable = new Dictionary<int, List<object>>
        {
            {1, new List<object> {"LightElement", "Light Element", "Light", 
                "Primal element of Light, linked to the forces of good and Maron the Creator."}},
            {2, new List<object> {"ShadowElement", "Shadow Element", "Shadow", 
                "Primal element of Shadow, linked to the forces of evil and Urman the Destroyer."}},
            {3, new List<object> {"FireElement", "Fire Element", "Fire", 
                ""}},
            {4, new List<object> {"AirElement", "Air Element", "Air", 
                ""}},
            {5, new List<object> {"EarthElement", "Earth Element", "Earth", 
                ""}},
            {6, new List<object> {"WaterElement", "Water Element", "Water", 
                ""}},
            {7, new List<object> {"gods", "The gods", "gods", 
                "The gods are also known as the Athlei and are powerful beings that have existed for " + 
                "many thousands of years.  They helped create the world and the races that live on it " + 
                "and in ancient times even fought alongside the “lesser” races. They are divided into " + 
                "three groups, The Two, the Thirteen and The Hundred.  In total there are one-hundred " + 
                "and fifteen gods.  Each of the gods is tied to one or more of the core elements of the Realms."}},
            {8, new List<object> {"Maron", "Maron", "Maron", 
                "Known as The Creator or The One, Maron is the ruler of Amaron, the leader of the Athlei " + 
                "and the Armies of Light.  Maron works to rebuild what was lost during the Great Wars " + 
                "and to stop his brother, Urman, from causing more destruction.  Maron’s element is that of Light."}},
            {9, new List<object> {"Urman", "Urman", "Urman", 
                "Known as The Destroyer or The Great Shadow, Urman is the leader of the Armies of Darkness. " + 
                "Urman was chained to The Obelisk for the remainder of time after his defeat at the end of " + 
                "the Second Great War, but in the darkness he has vowed to destroy his brother, Maron, and bring " + 
                "chaos and destruction to the Seven Realms. Urman’s element is that of Shadow."}},

        }; 

        private static void AddMonths()
        {
            using (var dbContext = Kernel.Get<IRealmDbContext>())
            {
                foreach (var values in MonthTable.Keys.Select(key => MonthTable[key]))
                {
                    dbContext.Months.Add(new Month
                    {
                        SystemClass = dbContext.SystemClasses.First(x => x.Name == "rootMonths"),
                        SystemName = (string)values[0],
                        DisplayName = (string)values[1],
                        NumberDays = (int)values[2],
                        SeasonType = (SeasonTypes)values[3],
                        IsShrouding = (bool)values[4],
                        SortOrder = (int)values[5]
                    });
                }
                dbContext.SaveChanges();
            }
        }

        private static readonly Dictionary<int, List<object>> MonthTable = new Dictionary<int, List<object>>
        {
            {1, new List<object> {"Kaorola", "Kaorola", 20, SeasonTypes.Winter, false, 1}},
            {2, new List<object> {"WinterShrouding", "Shrouding", 3, SeasonTypes.Winter, true, 2}},
            {3, new List<object> {"Zeresa", "Zeresa", 20, SeasonTypes.Winter, false, 3}},
            {4, new List<object> {"Beja", "Beja", 20, SeasonTypes.Winter, false, 4}},
            {5, new List<object> {"Kaora", "Kaora", 20, SeasonTypes.Winter, false, 5}},
            {6, new List<object> {"Emata", "Emata", 20, SeasonTypes.Spring, false, 6}},
            {7, new List<object> {"Laisa", "Laisa", 20, SeasonTypes.Spring, false, 7}},
            {8, new List<object> {"Zeja", "Zeja", 20, SeasonTypes.Spring, false, 8}},
            {9, new List<object> {"Zevera", "Zevera", 20, SeasonTypes.Spring, false, 9}},
            {10, new List<object> {"Ogoena", "Ogoena", 20, SeasonTypes.Summer, false, 10}},
            {11, new List<object> {"Vedova", "Vedova", 20, SeasonTypes.Summer, false, 11}},
            {12, new List<object> {"SummerShrouding", "Shrouding", 3, SeasonTypes.Summer, true, 12}},
            {13, new List<object> {"Pala", "Pala", 20, SeasonTypes.Summer, false, 13}},
            {14, new List<object> {"Zema", "Zema", 20, SeasonTypes.Summer, false, 14}},
            {15, new List<object> {"Esola", "Esola", 20, SeasonTypes.Summer, false, 15}},
            {16, new List<object> {"Danara", "Danara", 20, SeasonTypes.Fall, false, 16}},
            {17, new List<object> {"Emuda", "Emuda", 20, SeasonTypes.Fall, false, 17}},
            {18, new List<object> {"Zeola", "Zeola", 20, SeasonTypes.Fall, false, 18}},
            {19, new List<object> {"Veola", "Veola", 20, SeasonTypes.Fall, false, 19}},
            {20, new List<object> {"Veorota", "Veorota", 20, SeasonTypes.Winter, false, 20}}
        };

        private static void AddTerrain()
        {
            using (var dbContext = Kernel.Get<IRealmDbContext>())
            {
                var defaultTerrain = new Terrain
                {
                    SystemClass = dbContext.SystemClasses.First(x => x.Name == "rootTerrains"),
                    SystemName = "Indoor Terrain (Default)",
                    DisplayName = "Indor Terrain",
                    DisplayDescription = "Indoor Terrain.  This is the MUD default.",
                    MovementCost = 1
                };
                dbContext.Terrains.Add(defaultTerrain);
                dbContext.SaveChanges();
            }
        }

        private static void AddBarriers()
        {
            using (var dbContext = Kernel.Get<IRealmDbContext>())
            {
                var door = new Barrier
                {
                    SystemClass = dbContext.SystemClasses.First(x => x.Name == "rootBarriers"),
                    SystemName = "Start Space Door",
                    DisplayName = "Wooden Door",
                    MaterialType = MaterialTypes.ThickWood,
                    Bits = 3
                };
                dbContext.Barriers.Add(door);
                dbContext.SaveChanges();
            }
        }

        private static void AddSpaces()
        {
            using (var dbContext = Kernel.Get<IRealmDbContext>())
            {
                var startSpace = new Space
                {
                    SystemClass = dbContext.SystemClasses.First(x => x.Name == "rootSpaces"),
                    SystemName = "Start Space",
                    DisplayName = "Unused Room",
                    DisplayDescription = "An empty room with a single door leading out.",
                    Bits = 31,
                    Terrain = dbContext.Terrains.First(x => x.SystemName == "Indoor Terrain (Default)"),
                    Portals = new List<SpacePortal>()
                };
                dbContext.Spaces.Add(startSpace);

                var commonRoomSpace = new Space
                {
                    SystemClass = dbContext.SystemClasses.First(x => x.Name == "rootSpaces"),
                    SystemName = "Common Room NW",
                    DisplayName = "Common Room (Northwest)",
                    DisplayDescription = "<Description Here>",
                    Bits = 31,
                    Terrain = dbContext.Terrains.First(x => x.SystemName == "Indoor Terrain (Default)"),
                    Portals = new List<SpacePortal>()
                };
                dbContext.Spaces.Add(commonRoomSpace);
                dbContext.SaveChanges();

                commonRoomSpace.Portals.Add(new SpacePortal
                {
                    Keywords = "west",
                    Direction = DirectionTypes.West,
                    TargetSpaceId = dbContext.Spaces.First(x => x.SystemName == "Start Space").Id,
                    BarrierId = dbContext.Barriers.First(x => x.SystemName == "Start Space Door").Id
                });
                startSpace.Portals.Add(new SpacePortal
                {
                    Keywords = "out leave exit east",
                    Direction = DirectionTypes.East,
                    TargetSpaceId = dbContext.Spaces.First(x => x.SystemName == "Common Room NW").Id,
                    BarrierId = dbContext.Barriers.First(x => x.SystemName == "Start Space Door").Id
                });
                dbContext.SaveChanges();
            }
        }

        private static void AddZones()
        {
            using (var dbContext = Kernel.Get<IRealmDbContext>())
            {
                var newZone = new Zone
                {
                    SystemClass = dbContext.SystemClasses.First(x => x.Name == "rootZones"),
                    SystemName = "Inn of the Seven Realms",
                    DisplayName = "Inn of the Seven Realms",
                    DisplayDescription = "The Inn is located in the center of Aran of the Southern Gate and " +
                        "is run by Bron Ma’Ganor, a tall but fan man of indeterminate age, who has lived in Aran his entire " +
                        "life. He is of Manargoan decent and is very conscious of the tensions between his people and those " +
                        "of Cardolania. Over his life in Aran he has amassed a small fortune running what is considered " +
                        "by some to be the best Inn in Dushara. It is a very large inn, nearly six stories with over " +
                        "one-hundred rooms and serves as the largest Adventurer’s Guild in the city of Dushara. Several " +
                        "large rooms, a host of serving girls, and three thousand stones worth of bouncers keep the crowd " +
                        "of Adventurers looking for jobs satisfied and in-line. Ma’Ganor’s rooms are small, and the prices " +
                        "aren’t cheap, but they are clean, the stew is always warm, the bread is always fresh, and the ale " +
                        "is always good. For those who have horses, Ma’Ganor provides stabling, for a modest fee, and for those " +
                        "who need weapons or armor repaired he has a deal with Atinae’s Weapons and The Troll’s Mane for " +
                        "discounts on repair fees.",
                    Bits = 16,
                    Spaces = new List<ZoneSpace>
                    {
                        new ZoneSpace
                        {
                            Space = dbContext.Spaces.First(x => x.SystemName == "Start Space")
                        },
                        new ZoneSpace
                        {
                            Space = dbContext.Spaces.First(x => x.SystemName == "Common Room NW")
                        }
                    }
                };
                dbContext.Zones.Add(newZone);

                newZone = new Zone
                {
                    SystemClass = dbContext.SystemClasses.First(x => x.Name == "rootZones"),
                    SystemName = "Catacombs",
                    DisplayName = "The Catacombs",
                    DisplayDescription = "Built millennia ago, the catacombs have been used by the residents of Aran " + 
                        "and other cities on the southern side of the Osara River for years.  Some used the Catacombs " + 
                        "to bury their family members, other used them as quarries for stone, and a few more used the " + 
                        "Catacombs as places to hide or conduct secret meetings.  In recent months they have become overrun " + 
                        "by the undead and few dare venture into their black depths any longer.  One known entrance to the " + 
                        "catacombs is through the cellar of the Inn of the Seven Planes in Aran."
                };
                dbContext.Zones.Add(newZone);

                newZone = new Zone
                {
                    SystemClass = dbContext.SystemClasses.First(x => x.Name == "rootZones"),
                    SystemName = "Aran",
                    DisplayName = "Aran of the Southern Gate",
                    DisplayDescription = "The largest of the communities of Lesser Dushara, Aran is also one of the oldest " + 
                        "communities in Dushara.  It serves as the prime location for many different residents, merchants, " + 
                        "temples and it also contains the Southern Gate, the only way out of the city on this side of the " + 
                        "river.  The ruler of Aran is a Baron by the name of Talor de’Sal."
                };
                dbContext.Zones.Add(newZone);

                dbContext.SaveChanges();
            }
        }
    }
}
