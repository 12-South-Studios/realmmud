using Realm.Library.Common;
using Realm.Library.Common.Data;

namespace Realm.Help
{
    public class HelpModule : NinjectGameModule
    {
        public HelpModule(DictionaryAtom initAtom, BooleanSet initBooleanSet)
            : base(initAtom, initBooleanSet)
        {
        }

        public override void Load()
        {
            Bind<IHelpRepository>().To<HelpRepository>();
            Bind<IHelpLoader>().To<HelpLoader>();
            Bind<IHelpManager>().To<HelpManager>()
                .InSingletonScope()
                .OnActivation(x =>
                {
                    InitBooleanSet.AddItem("HelpManager");
                    x.OnInit(InitAtom);
                    InitAtom.Set("HelpManager", x);
                });
        }
    }
}
