using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Events;

namespace Realm.Communication
{
    public class CommunicationModule : NinjectGameModule
    {
        public CommunicationModule(DictionaryAtom initAtom, BooleanSet initBooleanSet)
            : base(initAtom, initBooleanSet)
        {
        }

        public override void Load()
        {
            Bind<IChannelHelper>().To<ChannelHelper>();
            Bind<IChannelManager>().To<ChannelManager>()
                .InSingletonScope()
                .OnActivation(x =>
                {
                    InitBooleanSet.AddItem("ChannelManager");
                    x.OnInit(InitAtom);
                    InitAtom.Set("ChannelManager", x);
                });
        }
    }
}
