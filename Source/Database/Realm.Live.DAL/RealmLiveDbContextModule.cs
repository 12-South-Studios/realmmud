using System.Configuration;
using System.Linq;
using log4net;
using Ninject.Modules;
using Realm.Library.Common.Logging;

namespace Realm.Live.DAL
{
    public class RealmLiveDbContextModule : NinjectModule
    {
        public override void Load()
        {
            if (!Kernel.GetBindings(typeof(ILogWrapper)).Any())
                Bind<ILogWrapper>()
                    .To<LogWrapper>()
                    .WithConstructorArgument("log", LogManager.GetLogger(typeof(RealmLiveDbContext)))
                    .WithConstructorArgument("level", LogLevel.Error);
            if (!Kernel.GetBindings(typeof (IRealmLiveDbContext)).Any())
                Bind<IRealmLiveDbContext>().To<RealmLiveDbContext>()
                    .WithConstructorArgument("connectionString",
                        ConfigurationManager.ConnectionStrings["LiveDbContext"].ConnectionString);
        }
    }
}
