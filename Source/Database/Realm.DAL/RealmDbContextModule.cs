using System.Linq;
using log4net;
using Ninject.Modules;
using Realm.Library.Common.Logging;

namespace Realm.DAL
{
    public class RealmDbContextModule : NinjectModule
    {
        public override void Load()
        {
            if (!Kernel.GetBindings(typeof(ILogWrapper)).Any())
                Bind<ILogWrapper>()
                    .To<LogWrapper>()
                    .WithConstructorArgument("log", LogManager.GetLogger(typeof(RealmDbContext)))
                    .WithConstructorArgument("level", LogLevel.Error);
            if (!Kernel.GetBindings(typeof(IRealmDbContext)).Any())
                Bind<IRealmDbContext>().To<RealmDbContext>();
        }
    }
}
