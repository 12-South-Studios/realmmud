using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Ninject.Infrastructure.Language;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL
{
    public static class ContextExtensions
    {
        public static IPrimitive GetPrimitive(this IRealmDbContext dbContext, SystemTypes systemType, int id)
        {
            IQueryable<IPrimitive> queryableSet = GetQueryableSet(dbContext, systemType);
            return queryableSet.SingleOrDefault(x => x.Id == id);
        }

        public static IEnumerable<IPrimitive> GetPrimitives(this IRealmDbContext dbContext, SystemTypes systemType, 
            int classId)
        {
            IQueryable<IPrimitive> queryableSet = GetQueryableSet(dbContext, systemType);
            if (queryableSet == null) return null;

            return queryableSet.Where(x => x.SystemClass.SystemType == systemType)
                        .Where(x => x.SystemClass.Id == classId)
                        .ToEnumerable();
        }

        private static IQueryable<IPrimitive> GetQueryableSet(IRealmDbContext dbContext, SystemTypes systemType) 
        {
            IQueryable<IPrimitive> queryableSet;
            switch (systemType)
            {
                case SystemTypes.Ability:
                    queryableSet = dbContext.Abilities.Include(x => x.SystemClass); break;
                case SystemTypes.Archetype:
                    queryableSet = dbContext.Archetypes.Include(x => x.SystemClass); break;
                case SystemTypes.Barrier:
                    queryableSet = dbContext.Barriers.Include(x => x.SystemClass); break;
                case SystemTypes.Behavior:
                    queryableSet = dbContext.Behaviors.Include(x => x.SystemClass); break;
                case SystemTypes.Conversation:
                    queryableSet = dbContext.Conversations.Include(x => x.SystemClass); break;
                case SystemTypes.Effect:
                    queryableSet = dbContext.Effects.Include(x => x.SystemClass); break;
                case SystemTypes.Faction:
                    queryableSet = dbContext.Factions.Include(x => x.SystemClass); break;
                case SystemTypes.GameCommand:
                    queryableSet = dbContext.GameCommands.Include(x => x.SystemClass); break;
                case SystemTypes.HelpLookup:
                    queryableSet = dbContext.Helps.Include(x => x.SystemClass); break;
                case SystemTypes.Item:
                    queryableSet = dbContext.Items.Include(x => x.SystemClass); break;
                case SystemTypes.ItemSet:
                    queryableSet = dbContext.ItemSets.Include(x => x.SystemClass); break;
                case SystemTypes.Liquid:
                    queryableSet = dbContext.Liquids.Include(x => x.SystemClass); break;
                case SystemTypes.Mobile:
                    queryableSet = dbContext.Mobiles.Include(x => x.SystemClass); break;
                case SystemTypes.Month:
                    queryableSet = dbContext.Months.Include(x => x.SystemClass); break;
                case SystemTypes.MudProg:
                    queryableSet = dbContext.MudProgs.Include(x => x.SystemClass); break;
                case SystemTypes.Quest:
                    queryableSet = dbContext.Quests.Include(x => x.SystemClass); break;
                case SystemTypes.Race:
                    queryableSet = dbContext.Races.Include(x => x.SystemClass); break;
                case SystemTypes.Reset:
                    queryableSet = dbContext.Resets.Include(x => x.SystemClass); break;
                case SystemTypes.Ritual:
                    queryableSet = dbContext.Rituals.Include(x => x.SystemClass); break;
                case SystemTypes.Shop:
                    queryableSet = dbContext.Shops.Include(x => x.SystemClass); break;
                case SystemTypes.Skill:
                    queryableSet = dbContext.Skills.Include(x => x.SystemClass); break;
                case SystemTypes.SkillCategory:
                    queryableSet = dbContext.SkillCategories.Include(x => x.SystemClass); break;
                case SystemTypes.Social:
                    queryableSet = dbContext.Socials.Include(x => x.SystemClass); break;
                case SystemTypes.Space:
                    queryableSet = dbContext.Spaces.Include(x => x.SystemClass); break;
                case SystemTypes.Spawn:
                    queryableSet = dbContext.Spawns.Include(x => x.SystemClass); break;
                case SystemTypes.Terrain:
                    queryableSet = dbContext.Terrains.Include(x => x.SystemClass); break;
                case SystemTypes.Treasure:
                    queryableSet = dbContext.Treasures.Include(x => x.SystemClass); break;
                case SystemTypes.Zone:
                    queryableSet = dbContext.Zones.Include(x => x.SystemClass); break;
                default:
                    throw new InvalidDataException();
            }

            return queryableSet;
        }
    }
}
