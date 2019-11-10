using Ninject;
using Realm.Event;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Events;
using Realm.Library.Common.Logging;
using Realm.Library.Common.Objects;
using Realm.Library.Network;
using Realm.Network.Hash;
using Realm.Network.User;

namespace Realm.Network
{
    public class NetworkManager : GameSingleton, INetworkManager
    {
        private BooleanSet _loadingSet;
        private readonly HashRepository _hashRepository;
        private readonly GameUserRepository _userRepository;
        private readonly PendingUserRepository _pendingRepository;
        private DictionaryAtom _initAtom;
        private readonly HashLoader _hashLoader;

        public NetworkManager(ITcpServer tcpServer, IHashRepository hashRepository, IHashLoader hashLoader, 
            [Named("GameUserRepository")] IUserRepository gameUserRepository, 
            [Named("PendingUserRepository")] IUserRepository pendingUserRepository)
        {
            Server = (TcpServer) tcpServer;
            _hashRepository = (HashRepository) hashRepository;
            _hashLoader = (HashLoader) hashLoader;
            _userRepository = (GameUserRepository) gameUserRepository;
            _pendingRepository = (PendingUserRepository) pendingUserRepository;
        }

        [Inject]
        public IEventManager EventManager { get; set; }

        [Inject]
        public ILogWrapper Log { get; set; }

        ~NetworkManager()
        {
            if (Server != null && (Server.Status != TcpServerStatus.Shutdown
                || Server.Status != TcpServerStatus.ShuttingDown))
                Server.Shutdown("Shutdown");
        }

        public TcpServer Server { get; }

        public void OnInit(DictionaryAtom initAtom)
        {
            Validation.IsNotNull(initAtom, "initAtom");

            EventManager.RegisterListener(this, typeof(OnGameInitialize), Instance_OnGameInitialize);
            _initAtom = initAtom;

            Log.DebugFormat("Created new TcpServer on {0}:{1}", Server.Host, Server.Port);
            Server.OnTcpUserStatusChanged += OnTcpUserStatusChanged;
        }

        /// <summary>
        /// Handles game initialization actions
        /// </summary>
        public override void Instance_OnGameInitialize(RealmEventArgs args)
        {
            Log.DebugFormat("{0} received Event OnGameInitialize", GetType());

            _loadingSet = args.GetValue("BooleanSet") as BooleanSet;

            Log.Debug("Initialized the HashLoader");
            _hashLoader.Load(OnLoadComplete);
        }

        /// <summary>
        /// Completes the loading and final initialization of the manager
        /// </summary>
        /// <param name="args"></param>
        private void OnLoadComplete(RealmEventArgs args)
        {
            args.Data["BooleanSet"] = _loadingSet;
            base.Instance_OnGameInitialize(args);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTcpUserStatusChanged(object sender, NetworkEventArgs e)
        {
            if (!(sender is ITcpUser)) return;

            var tcpUser = sender as ITcpUser;

            switch (e.SocketStatus)
            {
                case TcpSocketStatus.Connected:
                    ConnectUser(tcpUser);
                    break;

                case TcpSocketStatus.Disconnected:
                    DisconnectUser(tcpUser);
                    break;
            }
        }

        /// <summary>
        /// Handles connections
        /// </summary>
        /// <param name="tcpUser"></param>
        private void ConnectUser(ITcpUser tcpUser)
        {
            if (_pendingRepository.Contains(tcpUser.IpAddress) || _userRepository.Contains(tcpUser.IpAddress))
            {
                Log.InfoFormat("User {0} already exists.", tcpUser.IpAddress);
                return;
            }

            var gameUser = new GameUser(tcpUser.IpAddress, tcpUser, _initAtom);
            _pendingRepository.Add(tcpUser.IpAddress, gameUser);

            gameUser.SendMenu("MainMenu");
        }

        /// <summary>
        /// Handles disconnections
        /// </summary>
        /// <param name="tcpUser"></param>
        private void DisconnectUser(ITcpClientWrapper tcpUser)
        {
            if (!_pendingRepository.Contains(tcpUser.IpAddress) && !_userRepository.Contains(tcpUser.IpAddress))
            {
                Log.InfoFormat("User {0} does not exist.", tcpUser.IpAddress);
                return;
            }

            if (_pendingRepository.Contains(tcpUser.IpAddress))
                _pendingRepository.Delete(tcpUser.IpAddress);
            else if (_userRepository.Contains(tcpUser.IpAddress))
                _userRepository.Delete(tcpUser.IpAddress);
            else
                Log.InfoFormat("User {0} not found.", tcpUser.IpAddress);
        }

        #region Hash Repository

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public Hash.Hash GetRandomValue()
        {
            return _hashRepository.GetRandomValue();
        }

        #endregion Hash Repository
    }
}