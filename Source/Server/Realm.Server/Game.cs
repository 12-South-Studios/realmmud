using System;
using System.Collections.Generic;
using System.Linq;
using Realm.Command;
using Realm.Command.Interfaces;
using Realm.Communication;
using Realm.Data;
using Realm.Data.Definitions;
using Realm.Data.Interfaces;
using Realm.Entity;
using Realm.Entity.Entities;
using Realm.Event;
using Realm.Help;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Logging;
using Realm.Library.Network;
using Realm.Network;
using Realm.Pathing;
using Realm.Pathing.Interfaces;
using Realm.Server.Managers;
using Realm.Server.Players;
using Realm.Time;
using Ninject;
using Realm.Entity.Interfaces;
using Realm.Event.EventTypes.GameEvents;
using Realm.Library.Common.Contexts;
using Realm.Library.Common.Events;
using Realm.Library.Common.Exceptions;
using Realm.Library.Common.Extensions;
using Realm.Library.Common.Objects;
using Realm.Server.Extensions;
using Realm.Standard.Patterns.Singleton;
using Realm.Time.Interfaces;

namespace Realm.Server
{
    public sealed class Game : Singleton, IGame
    {
        public Game()
        {
            Properties = new PropertyContext(null);
        }

        #region Properties/Variables
        public event EventHandler<NetworkEventArgs> OnUserStatusChanged;
        public event EventHandler<NetworkEventArgs> OnServerStatusChanged;

        public LuaManager LuaMgr { get; private set; }
        public DatabaseManager DbMgr { get; private set; }
        public NetworkManager NetMgr { get; private set; }
        //public DataManager DataMgr { get; private set; }
        public EntityManager EntityMgr { get; private set; }
        public TimeManager TimeMgr { get; private set; }
        public ChannelManager ChannelMgr { get; private set; }
        public IPropertyContext Properties { get; private set; }
        //public EffectsHandler Effects { get; private set; }
        // public GameUserRepository UserRepository { get; private set; }
        public CommandManager CmdMgr { get; private set; }
        public HelpManager HelpMgr { get; private set; }
        //public CombatManager CombatMgr { get; private set; }
        public EventManager EventMgr { get; private set; }
        public PathManager PathMgr { get; private set; }
        public StaticDataManager StaticMgr { get; private set; }

        private BooleanSet InitBooleanSet { get; set; }
        private GameLoopProcessor LoopProcessor { get; set; }

        public IKernel NinjectKernel { get; private set; }

        public IList<IContext> Contexts { get; private set; }
        #endregion

        [Inject]
        // ReSharper disable once MemberCanBePrivate.Global
        public ILogWrapper Logger { get; set; }

        public bool IsRunning => NetMgr.IsNotNull() && NetMgr.Server.IsNotNull()
                                 && NetMgr.Server.Status == TcpServerStatus.Listening;

        private readonly List<Type> _ninjectGameModules = new List<Type>
        {
            typeof (EventModule),
            typeof (ServerModule),
            typeof (DataModule),
            typeof (EntityModule),
            typeof (CommunicationModule),
            typeof (CommandModule),
            typeof (PathModule),
            typeof (TimeModule),
            typeof (HelpModule),
            typeof (NetworkModule)
        };

        private readonly List<Type> _entityTypes = new List<Type>
        {
            typeof (Ability),
            typeof (Zone),
            typeof (Space),
            typeof (Mobile),
            typeof (Character),
            typeof (Channel),
            typeof (Entity.Entities.Item)
        };

        public void OnInit(DictionaryAtom initAtom)
        {
            try
            {
                NinjectKernel = initAtom.GetObject("Ninject.Kernel").CastAs<IKernel>();
                initAtom.Set("Logger", Logger);
                InitBooleanSet = new BooleanSet("OnGameInitialize", Game_OnInitializationComplete);

                NinjectKernel.Load(_ninjectGameModules.Select(
                    moduleType => (NinjectGameModule)Activator.CreateInstance(moduleType, initAtom, InitBooleanSet)));

                EventMgr = (EventManager)NinjectKernel.Get<IEventManager>();
                LuaMgr = (LuaManager) NinjectKernel.Get<ILuaManager>();
                DbMgr = (DatabaseManager) NinjectKernel.Get<IDatabaseManager>();
                StaticMgr = (StaticDataManager) NinjectKernel.Get<IStaticDataManager>();
                EntityMgr = (EntityManager) NinjectKernel.Get<IEntityManager>();
                EntityMgr.EntityInitializer.RegisterEntityTypes(_entityTypes);
                ChannelMgr = (ChannelManager) NinjectKernel.Get<IChannelManager>();
                CmdMgr = (CommandManager) NinjectKernel.Get<ICommandManager>();
                PathMgr = (PathManager) NinjectKernel.Get<IPathManager>();
                TimeMgr = (TimeManager) NinjectKernel.Get<ITimeManager>();
                NetMgr = (NetworkManager) NinjectKernel.Get<INetworkManager>();
                // todo DataManager?
                // todo CombatManager ?
                LoopProcessor = (GameLoopProcessor)NinjectKernel.Get<ILoopProcessor>();

                Contexts = new List<IContext> { new PropertyContext(this) };

                // Everything that needs early initialization done before this line
                // Now, lets begin regular setup (this will include game data)
                Logger.Debug("Completed initialization of Managers, throwing OnGameInitialize event.");
                EventMgr.ThrowEvent<OnGameInitialize>(this, new EventTable
                                                                {
                                                                    {"BooleanSet", InitBooleanSet},
                                                                    {"InitAtom", initAtom}
                                                                });
            }
            catch (Exception ex)
            {
                ex.Handle<InitializationException>(ExceptionHandlingOptions.RecordAndThrow, Logger);
            }
        }

        private void Game_OnInitializationComplete(RealmEventArgs args)
        {
            InitBooleanSet = null;

            Logger.Info("Game Managers initialized. Running configuration scripts.");
            var setupScript = this.GetStringConstant("gameSetupScript");
            try
            {
                var result = LuaMgr.Execute(setupScript, true);
                if (!result)
                {
                    Logger.InfoFormat("{0} failed to execute", setupScript);
                    return;
                }

                // TODO: Setup global Effects
            }
            catch (Exception ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordAndThrow, Logger, "{0} failed to execute", setupScript);
            }

            StartServer();
        }

        public void StartServer()
        {
#if !DISABLE_TCP
            var port = this.GetIntConstant("listenPort").GetValueOrDefault(9001);
            var ipAddress = this.GetStringConstant("hostAddress").ConvertToIpAddress();
            NetMgr.Server.Startup(port, ipAddress);
#endif
            LoopProcessor.Start();
            EventMgr.ThrowEvent<OnGameStart>(this);
        }

        public void StopServer()
        {
            LoopProcessor.Stop();
            NetMgr.Server.Shutdown(string.Empty);
            EventMgr.ThrowEvent(this, new OnGameStop());
        }

        /*private void ServerOnOnTcpServerStatusChanged(object sender, NetworkEventArgs e)
        {
            if (!(sender is ITcpServer)) return;

            if (e.ServerStatus == TcpServerStatus.ShuttingDown || e.ServerStatus == TcpServerStatus.Shutdown)
            {
                StopServer();
                if (OnServerStatusChanged.IsNotNull())
                    OnServerStatusChanged(sender, e);
            }
            else
            {
                StartServer();
                if (OnServerStatusChanged.IsNotNull())
                    OnServerStatusChanged(sender, e);
            }
        }
        void Server_OnTcpUserStatusChanged(object sender, NetworkEventArgs e)
        {
            if (!(sender is ITcpUser)) return;

            var tcpUser = sender as ITcpUser;
            GameUser user;

            if (e.SocketStatus == TcpSocketStatus.Connected)
            {
                user = new GameUser(tcpUser);
                if (UserRepository.Contains(tcpUser.Id))
                {
                    Logger.WarnFormat(ErrorResources.ERR_USER_ALREADY_EXISTS, tcpUser.Id);
                    return;
                }

                //SetManagerReferences(user);
                user.OnInit();
                Logger.InfoFormat(MessageResources.MSG_USER_ADDED, user.Id);

                user.UserState = Globals.Globals.UserStateTypes.MainMenu;
                UserRepository.Add(tcpUser.Id, user);
                this.SetProperty("last_connected", user);
                LuaManager.Instance.Execute("\\events\\OnClientEnter.lua", true);
            }
            else
            {
                user = UserRepository.Get(tcpUser.Id);
                if (user.IsNull())
                {
                    Logger.ErrorFormat(ErrorResources.ERR_USER_NOT_FOUND, tcpUser.Id);
                    return;
                }
                UserRepository.Delete(tcpUser.Id);
            }

            if (OnUserStatusChanged.IsNotNull())
                OnUserStatusChanged(user, e);
        }*/

        #region Unimplemented Methods from IGameEntity

        public long ID
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public Definition Definition
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string Description
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string LongName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string PluralName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public IGameEntity Location
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        #endregion

        #region IGameEntity Implementation

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public IContext GetContext(string typeName)
        {
            return Contexts.FirstOrDefault(context => context.GetType().Name
                                                          .Equals(typeName, StringComparison.OrdinalIgnoreCase));
        }

        #endregion
    }
}
