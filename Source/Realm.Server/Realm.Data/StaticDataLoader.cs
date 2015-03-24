using System.Linq;
using Realm.Data.Interfaces;
using Realm.Library.Common;
using Realm.Library.Common.Logging;

namespace Realm.Data
{
    /// <summary>
    /// Loads static data from the database
    /// </summary>
    public class StaticDataLoader : Entity, IStaticDataLoader
    {
        private readonly LoaderRepository _repository;
        private BooleanSet _loadingSet;
        private BooleanSet _loaderSet;
        private readonly ILogWrapper _log;

        /// <summary>
        ///
        /// </summary>
        /// <param name="loaderRepository"></param>
        public StaticDataLoader(ILoaderRepository loaderRepository, ILogWrapper log)
            : base(1, "StaticDataLoader")
        {
            _repository = (LoaderRepository)loaderRepository;
            _log = log;
        }

        /// <summary>
        ///
        /// </summary>
        public void Load(BooleanSet boolSet)
        {
            _loadingSet = boolSet;
            _loaderSet = new BooleanSet("Loaders", OnLoadersLoadCompleted);

            _repository.Values.ToList().ForEach(loader =>
                {
                    _loaderSet.AddItem(loader.IdColumn);
                    _log.DebugFormat("Loader {0} beginning loading: NameColumn={1}, IdColumn={2}.", loader.GetType(),
                                     loader.NameColumn, loader.IdColumn);
                    loader.Load(_loaderSet); 
                });
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="args"></param>
        private void OnLoadersLoadCompleted(RealmEventArgs args)
        {
            _log.DebugFormat("All Static Data Loaders have completed.");

            _loaderSet = null;
            _loadingSet.CompleteItem("StaticDataLoader");
        }
    }
}