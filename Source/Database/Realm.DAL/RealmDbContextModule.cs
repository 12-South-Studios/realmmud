using System.Configuration;
using System.Linq;
using Ninject.Modules;
using Realm.Library.Common.Logging;

namespace Realm.DAL
{
    public class RealmDbContextModule : NinjectModule
    {
        public override void Load()
        {
            if (!Kernel.GetBindings(typeof (ILogWrapper)).Any())
                Bind<ILogWrapper>().To<LogWrapper>();
            if (!Kernel.GetBindings(typeof (IRealmDbContext)).Any())
                Bind<IRealmDbContext>().To<RealmDbContext>()
                    .WithConstructorArgument("connectionString",
                        ConfigurationManager.ConnectionStrings["RealmDbContext"].ConnectionString);
        }
    }
}
