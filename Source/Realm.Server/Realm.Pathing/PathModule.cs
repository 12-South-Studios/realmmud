using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Pathing.Interfaces;

namespace Realm.Pathing
{
    public class PathModule : NinjectGameModule
    {
        public PathModule(DictionaryAtom initAtom, BooleanSet initBooleanSet)
            : base(initAtom, initBooleanSet)
        {
        }

        public override void Load()
        {
            Bind<IGraphRepository>().To<GraphRepository>();
            Bind<IPathManager>().To<PathManager>()
                .InSingletonScope()
                .OnActivation(x =>
                {
                    InitBooleanSet.AddItem("PathManager");
                    x.OnInit(InitAtom);
                    InitAtom.Set("PathManager", x);
                });
        }
    }
}
