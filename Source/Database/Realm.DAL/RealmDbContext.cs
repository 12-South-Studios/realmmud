using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using Ninject;
using Realm.DAL.Common;
using Realm.DAL.Models;
using Realm.Library.Common.Logging;

namespace Realm.DAL
{
    public class RealmDbContext : DbContext, IRealmDbContext
    {
        private ILogWrapper Logger { get; }
        public ObjectContext ObjectContext { get; }

        private DateTime _lastSaveTimeUtc;

        public RealmDbContext() : base(ConfigurationManager.ConnectionStrings["RealmDbContext"].ConnectionString)
        {
            var kernel = new StandardKernel(new RealmDbContextModule());
            Logger = kernel.Get<ILogWrapper>();
            ObjectContext = ((IObjectContextAdapter) this).ObjectContext;
        }

        public RealmDbContext(string connectionString, ILogWrapper logger) : base(connectionString)
        {
            var kernel = new StandardKernel(new RealmDbContextModule());
            Logger = logger ?? kernel.Get<ILogWrapper>();
            ObjectContext = ((IObjectContextAdapter)this).ObjectContext;
        }

        public IDbSet<Ability> Abilities { get; set; }
        public IDbSet<Archetype> Archetypes { get; set; }
        public IDbSet<BankUpgrade> BankUpgrades { get; set; }
        public IDbSet<Barrier> Barriers { get; set; }
        public IDbSet<Behavior> Behaviors { get; set; }
        public IDbSet<Bit> Bits { get; set; }
        public IDbSet<Color> Colors { get; set; }
        public IDbSet<Conversation> Conversations { get; set; }
        public IDbSet<Effect> Effects { get; set; }
        public IDbSet<Element> Elements { get; set; }
        public IDbSet<Event> Events { get; set; } 
        public IDbSet<Faction> Factions { get; set; }
        public IDbSet<GameCommand> GameCommands { get; set; }
        public IDbSet<GameConstant> GameConstants { get; set; }
        public IDbSet<GuildLevel> GuildLevels { get; set; } 
        public IDbSet<Help> Helps { get; set; }
        public IDbSet<Item> Items { get; set; }
        public IDbSet<ItemSet> ItemSets { get; set; }
        public IDbSet<Liquid> Liquids { get; set; }
        public IDbSet<Mobile> Mobiles { get; set; }
        public IDbSet<Month> Months { get; set; }
        public IDbSet<MovementMode> MovementModes { get; set; } 
        public IDbSet<MudProg> MudProgs { get; set; }
        public IDbSet<Quest> Quests { get; set; }
        public IDbSet<Race> Races { get; set; }
        public IDbSet<Reset> Resets { get; set; } 
        public IDbSet<Ritual> Rituals { get; set; }
        public IDbSet<Shop> Shops { get; set; }
        public IDbSet<Skill> Skills { get; set; }
        public IDbSet<SkillCategory> SkillCategories { get; set; }
        public IDbSet<Social> Socials { get; set; }
        public IDbSet<Space> Spaces { get; set; }
        public IDbSet<Spawn> Spawns { get; set; }
        public IDbSet<SystemClass> SystemClasses { get; set; }
        public IDbSet<Tag> Tags { get; set; }
        public IDbSet<TagSet> TagSets { get; set; }
        public IDbSet<Terrain> Terrains { get; set; }
        public IDbSet<Treasure> Treasures { get; set; }
        public IDbSet<WearLocation> WearLocations { get; set; } 
        public IDbSet<Zone> Zones { get; set; }
 
        public override int SaveChanges()
        {
            _lastSaveTimeUtc = DateTime.UtcNow;

            ProcessEntities(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            try
            {
               return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                LogDbEntityValidationResults(e);
                throw;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            Effect.OnModelCreating(modelBuilder);
            ItemFormula.OnModelCreating(modelBuilder);
            ItemSetItem.OnModelCreating(modelBuilder);
        }

        private void LogDbEntityValidationResults(DbEntityValidationException e)
        {
            foreach (var eve in e.EntityValidationErrors)
            {
                var error =
                    $"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:";

                Console.WriteLine(error);
                Logger.Error(error);

                foreach (var ve in eve.ValidationErrors)
                {
                    var validationError = $"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"";

                    Console.WriteLine(validationError);
                    Logger.ErrorFormat(validationError);
                }
            }
        }

        private void ProcessEntities(Func<DbEntityEntry, bool> predicate)
        {
            foreach (var entry in ChangeTracker.Entries().Where(predicate))
            {
                var entity = entry.Entity as Entity;
                if (entity == null) continue;

                AddCreateDateToEntity(entry);
            }
        }

        private void AddCreateDateToEntity(DbEntityEntry entry)
        {
            var entity = entry.Entity as Entity;
            if (entity == null) return;

            if (entry.State == EntityState.Modified && !entity.CreateDateUtc.HasValue)//Migration entities don't have create date.
                entity.CreateDateUtc = entry.OriginalValues.GetValue<DateTime>("CreateDateUtc");
            
            if (entry.State == EntityState.Added)
                entity.CreateDateUtc = _lastSaveTimeUtc;

            if (!entity.CreateDateUtc.HasValue)
            {
                throw new InvalidOperationException(
                    $"Create date for object doesn't exist. This is required.  Object type: {entry.Entity.GetType().Name}");
            }
        }
    }
}