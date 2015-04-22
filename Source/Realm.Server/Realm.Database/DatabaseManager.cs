using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Realm.Admin.DAL.Interfaces;
using Realm.DAL.Interfaces;
using Realm.Event;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Logging;
using Realm.Live.DAL.Interfaces;

namespace Realm.Database
{
    public class DatabaseManager : GameSingleton
    {
        private readonly IEventManager _eventManager;
        private readonly ILogWrapper _log;
        private string _connectionString;
        private IKernel _kernel;

        public DatabaseManager(IEventManager eventManager, ILogWrapper logger)
        {
            _eventManager = eventManager;
            _log = logger;
        }

        public void OnInit(DictionaryAtom args)
        {
            Validation.IsNotNull(args, "args");

            _connectionString = args.GetString("ConnectionString");
            Validation.IsNotNullOrEmpty(_connectionString, "_connectionString");

            _kernel = (IKernel)args.GetObject("Ninject.Kernel");
            _eventManager.RegisterListener(this, typeof(OnGameInitialize), Instance_OnGameInitialize);
        }

        private IRealmAdminDbContext _adminDbContext;
        private IRealmDbContext _dbContext;
        private IRealmLiveDbContext _liveDbContext;

        //public void ExecuteTransaction(PendingTransaction transaction)
        //{
        //    Validation.IsNotNull(transaction, "transaction");

        //    var server = _serverContext.NextServer;
        //    if (server.IsNull())
        //        throw new GeneralException(Resources.ERR_DB_SERVER_NOT_FOUND, transaction.TransactionId);

        //    server.ExecuteTransaction(transaction);
        //}

        public override void Instance_OnGameInitialize(RealmEventArgs args)
        {
            _log.DebugFormat("{0} received Event OnGameInitialize", GetType());

            try
            {
                _adminDbContext = _kernel.Get<IRealmAdminDbContext>();
                _dbContext = _kernel.Get<IRealmDbContext>();
                _liveDbContext = _kernel.Get<IRealmLiveDbContext>();
            }
            catch (Exception ex)
            {
                ex.Handle<InitializationException>(ExceptionHandlingOptions.RecordAndThrow, _log,
                                                   "Failed to initialize {0}", GetType());
            }

            base.Instance_OnGameInitialize(args);
        }
    }
}
