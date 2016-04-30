using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Entities;
using Realm.Library.Common.Events;
using Realm.Library.Network;
using Realm.Network.Hash;
using Realm.Network.User;

namespace Realm.Network
{
    public class NetworkModule : NinjectGameModule
    {
        public NetworkModule(DictionaryAtom initAtom, BooleanSet initBooleanSet) : base(initAtom, initBooleanSet)
        {
        }

        public override void Load()
        {
            Bind<ITcpUserRepository>().To<TcpUserRepository>();
            Bind<ITcpServer>().To<TcpServer>();
            Bind<IHashRepository>().To<HashRepository>();
            Bind<IHashLoader>().To<HashLoader>()
                .WithConstructorArgument("owner", (IEntity) null);
            Bind<IUserRepository>().To<GameUserRepository>().Named("GameUserRepository");
            Bind<IUserRepository>().To<PendingUserRepository>().Named("PendingUserRepository");
            Bind<IMenuHandler>().To<MainMenuHandler>().Named("MainMenu");
            Bind<IGameUserLoader>().To<GameUserLoader>();

            Bind<INetworkManager>().To<NetworkManager>()
                .InSingletonScope()
                .OnActivation(x =>
                {
                    InitBooleanSet.AddItem("NetworkManager");
                    x.OnInit(InitAtom);
                    InitAtom.Set("NetworkManager", x);
                });
        }
    }
}
