using System.Linq;
using log4net;
using Ninject.Modules;
using Realm.Library.Common.Logging;

namespace Realm.Edit
{
    public class MainModule : NinjectModule
    {
        public override void Load()
        {
            if (!Kernel.GetBindings(typeof(ILogWrapper)).Any())
                Bind<ILogWrapper>()
                    .To<LogWrapper>()
                    .WithConstructorArgument("log", LogManager.GetLogger(typeof(MainForm)))
                    .WithConstructorArgument("level", LogLevel.Error);
        }
    }
}
