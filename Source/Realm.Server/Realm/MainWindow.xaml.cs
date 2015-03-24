using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceProcess;
using System.Timers;
using System.Windows;
using Realm.Library.Common;
using Realm.Monitors;
using log4net;
using Realm.Library.Common.Data;
using Realm.Library.Common.Logging;
using Realm.Library.Network;
using Realm.Server;
using Ninject;

namespace Realm
{
    public sealed partial class MainWindow : IDisposable
    {
        private readonly Timer _timer = new Timer {Interval = 1000};
        
        private int _numberCallstacks;

        private ILogWrapper Logger { get; set; }

        private IGame GameService { get; set; }

        private ServiceController ServerService { get; set; }

        private IEnumerable<IMonitor> Monitors { get; set; }

        private IKernel NinjectKernel { get; set; }

        public MainWindow()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            InitializeComponent();
            try
            {
                InitializeNinject();
                Initialize();
            }
            catch (ApplicationException aex)
            {
                Logger.Fatal(aex);
                Application.Current.Shutdown();
            }
        }

        private void InitializeNinject()
        {
            NinjectKernel = new StandardKernel();
            
            NinjectKernel.Bind<ILogWrapper>()
                .To<LogWrapper>()
                .WithConstructorArgument("log", LogManager.GetLogger(typeof(MainWindow)))
                .WithConstructorArgument("level", LogLevel.Error);
            NinjectKernel.Bind<IMonitor>()
                .To<ServerTimeMonitor>()
                .Named("ServerTime")
                .WithConstructorArgument("control", ServerUpTime)
                .OnActivation(x => _timer.Elapsed += x.OnTimerElapsed);
            NinjectKernel.Bind<IMonitor>()
                .To<ServerServiceStatusMonitor>()
                .Named("ServerStatus")
                .WithConstructorArgument("control", ServerServiceStatus)
                .WithConstructorArgument("controller", ServerService)
                .OnActivation(x => _timer.Elapsed += x.OnTimerElapsed);
            NinjectKernel.Bind<ITimer>()
                .To<CommonTimer>()
                .Named("EventTimer")
                .OnActivation(x => x.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["EventFrequency"]));
            NinjectKernel.Bind<ITimer>()
                .To<CommonTimer>()
                .Named("RecycleTimer")
                .OnActivation(x => x.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["RecycleFrequency"]));
            NinjectKernel.Bind<ITimer>()
                .To<CommonTimer>()
                .Named("GameTimer")
                .OnActivation(x => x.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["TimeSegment"]));
            NinjectKernel.Bind<IGame>()
                .To<Game>()
                .InSingletonScope()
                .OnActivation(x =>
                {
                    x.OnUserStatusChanged += _game_OnUserStatusChanged;
                    x.OnServerStatusChanged += _game_OnServerStatusChanged;
                    x.OnInit(SetupInitData());
                });

            Monitors = new List<IMonitor>();
            Monitors = NinjectKernel.GetAll<IMonitor>();

            //NinjectKernel.Load("Realm.*.dll");
        }

        private void Initialize()
        {
            Logger = NinjectKernel.Get<ILogWrapper>();
            
            OnStartup_ServerServiceInitialization();

            SetupLabels();

            ServerUpImage.Visibility = Visibility.Hidden;
            ServerDownImage.Visibility = Visibility.Visible;

            StartButton.Visibility = Visibility.Visible;
            StopButton.Visibility = Visibility.Hidden;

            GameService = NinjectKernel.Get<IGame>();
        }

        private void SetupLabels()
        {
            TitleLabel.Content = ConfigurationManager.AppSettings["gameTitle"];
            PortHostLabel.Content = String.Format("{0}:{1}",
                ConfigurationManager.AppSettings["hostAddress"],
                ConfigurationManager.AppSettings["listenPort"]);
            ServerUpTime.Content = "Up-Time: 00:00:00";
            UsersConnectedLabel.Content = "0 Users Connected";
        }

        private void OnStartup_ServerServiceInitialization()
        {
            //_serverSvcController = new ServiceController(ConfigurationManager.AppSettings["ServerServiceName"],
            //                                                  ConfigurationManager.AppSettings["ServerServiceUrl"]);
           // _serverSvcController.Start();
        }

        private void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            if (unhandledExceptionEventArgs.IsTerminating)
            {
                Logger.Fatal(unhandledExceptionEventArgs.ExceptionObject.CastAs<Exception>());
                Application.Current.Shutdown();
                return;
            }

            Logger.Error(unhandledExceptionEventArgs.ExceptionObject.CastAs<Exception>());
        }

        private DictionaryAtom SetupInitData()
        {
            var initAtom = new DictionaryAtom();

            initAtom.Set("Ninject.Kernel", NinjectKernel);
            initAtom.Set("ConnectionString", ConfigurationManager.ConnectionStrings["Realm"].ConnectionString);
            initAtom.Set("NumberDBServers", Convert.ToInt32(ConfigurationManager.AppSettings["NumberDatabaseServers"]));
            initAtom.Set("NumberLuaVMs", Convert.ToInt32(ConfigurationManager.AppSettings["NumberLuaVirtualMachines"]));
            initAtom.Set("EventFrequency", Convert.ToInt32(ConfigurationManager.AppSettings["EventFrequency"]));
            initAtom.Set("RecycleFrequency", Convert.ToInt32(ConfigurationManager.AppSettings["RecycleFrequency"]));
            initAtom.Set("TimeSegment", Convert.ToInt32(ConfigurationManager.AppSettings["TimeSegment"]));
            initAtom.Set("DataPath", ConfigurationManager.AppSettings["DataPath"]);
            initAtom.Set("AdminBackdoorPassword", ConfigurationManager.AppSettings["AdminBackdoorPassword"]);
            initAtom.Set("PathCacheDuration", Convert.ToInt32(ConfigurationManager.AppSettings["PathCacheDuration"]));
            initAtom.Set("MaxMobileMovementCost", Convert.ToInt32(ConfigurationManager.AppSettings["MaxMobileMovementCost"]));
            initAtom.Set("DefaultGameYear", ConfigurationManager.AppSettings["DefaultGameYear"]);
            initAtom.Set("DefaultGameMonth", ConfigurationManager.AppSettings["DefaultGameMonth"]);
            initAtom.Set("DefaultGameDay", ConfigurationManager.AppSettings["DefaultGameDay"]);
            initAtom.Set("DefaultGameHour", ConfigurationManager.AppSettings["DefaultGameHour"]);
            initAtom.Set("DefaultGameMinute", ConfigurationManager.AppSettings["DefaultGameMinute"]);

            return initAtom;
        }

        #region Log Events

        private delegate void LogUpdate(LogLevel logLevel, string eventName, string eventLog);

        private void UpdateLogList(LogLevel logLevel, string eventName, string eventLog)
        {
            txtLogs.AppendText(string.Format("[{0}][{1}] {2}:{3}{4}", DateTime.Now,
                logLevel, eventName, eventLog, Environment.NewLine));
            _numberCallstacks++;
            lblCallstackCount.Content = _numberCallstacks + " callstacks.";
        }

        private void _logWrapper_OnLoggingEvent(object sender, LogEventArgs e)
        {
            var del = new LogUpdate(UpdateLogList);
            Dispatcher.Invoke(del, new object[] { e.Level, e.Name, e.Text });
        }

        #endregion

        #region Server Status

        #region Server Startup

        private delegate void ServerStartDelegate(TcpServerStatus status);

        private void ServerStartup(TcpServerStatus status)
        {
            ServerUpImage.Visibility = Visibility.Visible;
            ServerDownImage.Visibility = Visibility.Hidden;

            StartButton.Visibility = Visibility.Hidden;
            StopButton.Visibility = Visibility.Visible;

            _timer.Start();
        }

        #endregion

        #region Server Shutdown

        private delegate void ServerStopDelegate(TcpServerStatus status);

        private void ServerShutdown(TcpServerStatus status)
        {
            ServerUpImage.Visibility = Visibility.Hidden;
            ServerDownImage.Visibility = Visibility.Visible;

            StartButton.Visibility = Visibility.Visible;
            StopButton.Visibility = Visibility.Hidden;

            _timer.Stop();
        }

        #endregion

        private void _game_OnServerStatusChanged(object sender, NetworkEventArgs e)
        {
            if (e.ServerStatus == TcpServerStatus.Starting || e.ServerStatus == TcpServerStatus.Listening)
            {
                var del = new ServerStartDelegate(ServerStartup);
                Dispatcher.Invoke(del, new object[] { e.ServerStatus });
            }
            else
            {
                var del = new ServerStopDelegate(ServerShutdown);
                Dispatcher.Invoke(del, new object[] { e.ServerStatus });
            }
        }

        #endregion


        private void _game_OnUserStatusChanged(object sender, NetworkEventArgs e)
        {
            
            // TODO: Implement handling of user status changes
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Logger.Info("Shutting the game down!");
            if (_timer != null)
                _timer.Stop();
            if (GameService != null)
                GameService.StopServer();
            if (ServerService != null)
            {
                ServerService.Stop();
                ServerService.Dispose();
            }
            LogManager.Shutdown();
        }

        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            if (!GameService.IsRunning)
                GameService.StartServer();
            if (ServerService != null && ServerService.Status != ServiceControllerStatus.Running)
                ServerService.Start();
        }

        private void StopButtonClick(object sender, RoutedEventArgs e)
        {
            if (GameService.IsRunning)
                GameService.StopServer();
            if (ServerService != null && ServerService.Status != ServiceControllerStatus.Stopped)
                ServerService.Stop();
        }

        #region Implementation of IDisposable

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_timer != null)
                    _timer.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Implementation of IDisposable
    }
}