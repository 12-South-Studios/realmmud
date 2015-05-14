using System;
using System.Linq;
using Realm.Data.Properties;
using Realm.Event;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Logging;
using Realm.Library.Database.Framework;

namespace Realm.Data
{
    public sealed class DatabaseManager : GameSingleton, IDatabaseManager, IDatabaseLoadBalancer
    {
        private readonly IEventManager _eventManager;
        private readonly ILogWrapper _log;
        private DatabaseServerContext _serverContext;
        private int _numberServers;
        private string _connectionString;
        private ListAtom _loaderArgs;

        public DatabaseManager(IEventManager eventManager, ILogWrapper logger)
        {
            _eventManager = eventManager;
            _log = logger;
        }

        ~DatabaseManager()
        {
            if (_serverContext.IsNotNull())
                _serverContext.Dispose();
        }

        /// <summary>
        /// Do initialization that cannot be done at construction
        /// </summary>
        public void OnInit(DictionaryAtom args)
        {
            Validation.IsNotNull(args, "args");

            _connectionString = args.GetString("ConnectionString");
            Validation.IsNotNullOrEmpty(_connectionString, "_connectionString");

            _numberServers = args.GetInt("NumberDBServers");
            Validation.Validate<ArgumentOutOfRangeException>(_numberServers >= 1);
            _log.DebugFormat("{0} asked to spin up {1} database servers.", GetType(), _numberServers);

            InitDatabaseLoaders(args);
            _loaderArgs = args.GetAtom<ListAtom>("Loaders");

            _eventManager.RegisterListener(this, typeof(OnGameInitialize), Instance_OnGameInitialize);
        }

        private static void InitDatabaseLoaders(DictionaryAtom initAtom)
        {
            var loaderArgs = new ListAtom();
            {
                var loaderDbo = new DictionaryAtom();
                loaderDbo.Set("Catalog", "Realm");
                loaderDbo.Set("Schema", "dbo");
                loaderDbo.Set("Prefix", "game");
                loaderArgs.Add(loaderDbo);
            }
            {
                var loaderLive = new DictionaryAtom();
                loaderLive.Set("Catalog", "Realm");
                loaderLive.Set("Schema", "live");
                loaderLive.Set("Prefix", "game");
                loaderArgs.Add(loaderLive);
            }
            {
                var loaderRef = new DictionaryAtom();
                loaderRef.Set("Catalog", "Realm");
                loaderRef.Set("Schema", "ref");
                loaderRef.Set("Prefix", "cp");
                loaderArgs.Add(loaderRef);
            }
            {
                var loaderAdmin = new DictionaryAtom();
                loaderAdmin.Set("Catalog", "Realm");
                loaderAdmin.Set("Schema", "admin");
                loaderAdmin.Set("Prefix", "cp");
                loaderArgs.Add(loaderAdmin);
            }
            initAtom.Set("Loaders", loaderArgs);
        }

        /// <summary>
        /// Wraps execution of a pending transaction so that the database servers
        /// can be load-balanced.
        /// </summary>
        /// <param name="transaction"></param>
        public void ExecuteTransaction(PendingTransaction transaction)
        {
            Validation.IsNotNull(transaction, "transaction");

            var server = _serverContext.NextServer;
            if (server.IsNull())
                throw new GeneralException(Resources.ERR_DB_SERVER_NOT_FOUND, transaction.TransactionId);

            server.ExecuteTransaction(transaction);
        }

        /// <summary>
        /// Initialization event
        /// </summary>
        /// <param name="args"></param>
        public override void Instance_OnGameInitialize(RealmEventArgs args)
        {
            _log.DebugFormat("{0} received Event OnGameInitialize", GetType());

            try
            {
                var procedureLoaders =
                    _loaderArgs.Select(atom => atom.CastAs<DictionaryAtom>())
                        .Select(
                            loaderAtom =>
                                new SqlProcedureLoader((LogWrapper)_log, _connectionString,
                                    loaderAtom.GetString("Catalog"), loaderAtom.GetString("Schema"),
                                    loaderAtom.GetString("Prefix")))
                        .ToList();

                _serverContext = new DatabaseServerContext((LogWrapper)_log, _connectionString,
                    _numberServers, procedureLoaders);
                _log.InfoFormat(Resources.MSG_INIT_SERVER_CONTEXT, _serverContext.ServerCount);
            }
            catch (Exception ex)
            {
                ex.Handle<InitializationException>(ExceptionHandlingOptions.RecordAndThrow, _log,
                                                   Resources.ERR_FAIL_INITIALIZE_MANAGER, GetType());
            }

            base.Instance_OnGameInitialize(args);
        }
    }
}