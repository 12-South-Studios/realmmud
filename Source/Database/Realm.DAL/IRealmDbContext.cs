using System;
using System.Data.Entity;
using Realm.DAL.Common;
using Realm.DAL.Models;

namespace Realm.DAL
{
    public interface IRealmDbContext : IDisposable, IRealmContext
    {
        IDbSet<Ability> Abilities { get; set; }
        IDbSet<Archetype> Archetypes { get; set; }
        IDbSet<BankUpgrade> BankUpgrades { get; set; }
        IDbSet<Barrier> Barriers { get; set; }
        IDbSet<Behavior> Behaviors { get; set; }
        IDbSet<Bit> Bits { get; set; }
        IDbSet<Color> Colors { get; set; }
        IDbSet<Conversation> Conversations { get; set; }
        IDbSet<Effect> Effects { get; set; }
        IDbSet<Element> Elements { get; set; } 
        IDbSet<Event> Events { get; set; }
        IDbSet<Faction> Factions { get; set; }
        IDbSet<GameCommand> GameCommands { get; set; }
        IDbSet<GameConstant> GameConstants { get; set; }
        IDbSet<GuildLevel> GuildLevels { get; set; }
        IDbSet<Help> Helps { get; set; }
        IDbSet<Item> Items { get; set; }
        IDbSet<ItemSet> ItemSets { get; set; }
        IDbSet<Liquid> Liquids { get; set; }
        IDbSet<Mobile> Mobiles { get; set; }
        IDbSet<Month> Months { get; set; }
        IDbSet<MovementMode> MovementModes { get; set; }
        IDbSet<MudProg> MudProgs { get; set; }
        IDbSet<Primitive> Primitives { get; set; }
        IDbSet<Quest> Quests { get; set; }
        IDbSet<Race> Races { get; set; }
        IDbSet<Reset> Resets { get; set; }
        IDbSet<Ritual> Rituals { get; set; }
        IDbSet<Shop> Shops { get; set; }
        IDbSet<Skill> Skills { get; set; }
        IDbSet<SkillCategory> SkillCategories { get; set; }
        IDbSet<Social> Socials { get; set; }
        IDbSet<Space> Spaces { get; set; }
        IDbSet<Spawn> Spawns { get; set; }
        IDbSet<SystemClass> SystemClasses { get; set; }
        IDbSet<Tag> Tags { get; set; }
        IDbSet<TagSet> TagSets { get; set; }
        IDbSet<Terrain> Terrains { get; set; }
        IDbSet<Treasure> Treasures { get; set; }
        IDbSet<WearLocation> WearLocations { get; set; }
        IDbSet<Zone> Zones { get; set; }
    }
}
