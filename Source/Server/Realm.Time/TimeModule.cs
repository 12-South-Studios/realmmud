using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Events;
using Realm.Time.Interfaces;

namespace Realm.Time
{
    public class TimeModule : NinjectGameModule
    {
        public TimeModule(DictionaryAtom initAtom, BooleanSet initBooleanSet)
            : base(initAtom, initBooleanSet)
        {
        }

        public override void Load()
        {
            Bind<IGameStateLoader>().To<GameStateLoader>();
            Bind<ITimeManager>().To<TimeManager>()
                .InSingletonScope()
                .OnActivation(x =>
                {
                    InitBooleanSet.AddItem("TimeManager");
                    x.OnInit(InitAtom);
                    InitAtom.Set("TimeManager", x);
                });
        }
    }
}
