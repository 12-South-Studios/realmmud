using System.Linq;
using log4net;
using Ninject.Modules;
using Realm.Library.Common.Logging;
using Realm.Live.DAL.Interfaces;

namespace Realm.Live.DAL.DependencyModules
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
            if (!Kernel.GetBindings(typeof(IRealmLiveDbContext)).Any())
                Bind<IRealmLiveDbContext>().To<RealmLiveDbContext>();
        }
    }
}
