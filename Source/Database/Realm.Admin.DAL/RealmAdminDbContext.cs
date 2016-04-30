using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using Ninject;
using Realm.Admin.DAL.Models;
using Realm.DAL.Common;
using Realm.Library.Common.Logging;

namespace Realm.Admin.DAL
{
    public class RealmAdminDbContext : DbContext, IRealmAdminDbContext
    {
        private ILogWrapper Logger { get; set; }
        public ObjectContext ObjectContext { get; private set; }
        public IDbSet<EditorLog> EditorLogs { get; set; }
        public IDbSet<Log> Logs { get; set; }
        public IDbSet<Login> LoginHistory { get; set; }
        public IDbSet<RestrictedName> RestrictedNames { get; set; }
        public IDbSet<Session> Sessions { get; set; }

        private DateTime _lastSaveTimeUtc;

        public RealmAdminDbContext() : base(ConfigurationManager.ConnectionStrings["AdminDbContext"].ConnectionString)
        {
            var kernel = new StandardKernel(new RealmAdminDbContextModule());
            Logger = kernel.Get<ILogWrapper>();
            ObjectContext = ((IObjectContextAdapter) this).ObjectContext;
        }

        public RealmAdminDbContext(string connectionString, ILogWrapper logger) : base(connectionString)
        {
            var kernel = new StandardKernel(new RealmAdminDbContextModule());
            Logger = logger ?? kernel.Get<ILogWrapper>();
            ObjectContext = ((IObjectContextAdapter)this).ObjectContext;
        }

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