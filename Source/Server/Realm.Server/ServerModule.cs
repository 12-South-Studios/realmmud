using Realm.Command.Interfaces;
using System;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Lua;
using Realm.Server.Commands;
using Realm.Server.Managers;

namespace Realm.Server
{
    public class ServerModule : NinjectGameModule
    {
        public ServerModule(DictionaryAtom initAtom, BooleanSet initBooleanSet)
            : base(initAtom, initBooleanSet)
        {
        }

        public override void Load()
        {
            Bind<ILuaLoadBalancer, ILuaManager>().To<LuaManager>()
                .InSingletonScope()
                .OnActivation(x =>
                {
                    InitBooleanSet.AddItem("LuaManager");
                    x.OnInit(InitAtom);
                    InitAtom.Set("LuaManager", x);
                });

            Bind<ILoopProcessor>().To<GameLoopProcessor>()
                .InSingletonScope()
                .OnActivation(x => x.SegmentTimer.Interval = InitAtom.GetInt("TimeSegment"));

            Bind<IVariableHelper>().To<VariableHelper>();
            Bind<IHelper<Action>>().To<CommandHelper>().Named("CommandHelper");
        }
    }
}
