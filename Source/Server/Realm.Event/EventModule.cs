using Ninject;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Events;

namespace Realm.Event
{
    public class EventModule : NinjectGameModule
    {
        public EventModule(DictionaryAtom initAtom, BooleanSet initBooleanSet)
            : base(initAtom, initBooleanSet)
        {
        }

        public override void Load()
        {
            Bind<IEventHandler>().To<EventHandler>();
            Bind<IEventManager>().To<EventManager>()
                .InSingletonScope()
                .OnActivation(x =>
                {
                    InitBooleanSet.AddItem("EventManager");
                    x.OnInit(InitAtom, Kernel.Get<IEventHandler>());
                    InitAtom.Set("EventManager", x);
                });
        }
    }
}
