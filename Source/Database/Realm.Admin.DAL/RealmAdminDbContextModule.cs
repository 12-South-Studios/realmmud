using System.Configuration;
using System.Linq;
using log4net;
using Ninject.Modules;
using Realm.Library.Common.Logging;

namespace Realm.Admin.DAL
{
    public class RealmAdminDbContextModule : NinjectModule
    {
        public override void Load()
        {
            if (!Kernel.GetBindings(typeof(ILogWrapper)).Any())
                Bind<ILogWrapper>()
                    .To<LogWrapper>()
                    .WithConstructorArgument("log", LogManager.GetLogger(typeof(RealmAdminDbContext)))
                    .WithConstructorArgument("level", LogLevel.Error);
            if (!Kernel.GetBindings(typeof (IRealmAdminDbContext)).Any())
                Bind<IRealmAdminDbContext>().To<RealmAdminDbContext>()
                    .WithConstructorArgument("connectionString",
                        ConfigurationManager.ConnectionStrings["AdminDbContext"].ConnectionString);
        }
    }
}
