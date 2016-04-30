using System.Collections.Generic;
using System.Linq;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Entities;
using Realm.Library.Common.Events;
using Realm.Library.Common.Logging;
using Realm.Library.Common.Objects;
using Realm.Library.Database.Framework;

namespace Realm.Network.Hash
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class HashLoader : DatabaseClient, IHashLoader
    {
        private readonly ILogWrapper Log;
        private EventCallback<RealmEventArgs> _callback;
        private readonly HashRepository _repository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="loadBalancer"></param>
        /// <param name="log"></param>
        /// <param name="repository"></param>
        public HashLoader(IEntity owner, IDatabaseLoadBalancer loadBalancer, ILogWrapper log, 
            IHashRepository repository)
            : base(owner, loadBalancer)
        {
            Log = log;
            _repository = (HashRepository)repository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public bool Load(EventCallback<RealmEventArgs> callback)
        {
            Validation.IsNotNull(callback, "callback");

            Log.Debug("Executing stored procedure 'game_GetHashes'");
            _callback = callback;
            return BuildAndExecuteTransaction(new Dictionary<string, string> { { "game_GetHashes", "" } });
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="args"></param>
        private void OnLoadComplete(RealmEventArgs args)
        {
            Validation.IsNotNull(args, "args");
            Validation.IsNotNull(args.Data, "args.Data");

            var data = args.Data.ToDictionaryAtom();
            if (!data.GetBool("success"))
            {
                Log.ErrorFormat("Failure to load data in {0}", GetType());
                return;
            }

            var commandResult = data.GetAtom<ListAtom>("commandResult").Get(0).CastAs<DictionaryAtom>();
            PopulateHashRepository(commandResult.GetAtom<ListAtom>("Results"));

            Log.DebugFormat("{0} hashes loaded.", _repository.Count);
            if (_callback.IsNotNull())
                _callback.Invoke(new RealmEventArgs());
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="commandResults"></param>
        private void PopulateHashRepository(IEnumerable<Atom> commandResults)
        {
            Validation.IsNotNull(commandResults, "commandResults");

            var itResult = commandResults.GetEnumerator();
            while (itResult.MoveNext())
            {
                var result = itResult.Current.CastAs<DictionaryAtom>();
                var newHash = new Hash(result.GetInt("HashID"), result.GetString("Value"));
                if (newHash.IsNull())
                {
                    Log.ErrorFormat("Unable to instantiate a new Hash {0}", result.GetInt("HashID"));
                    continue;
                }

                _repository.Add(newHash.ID, newHash);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="commands"></param>
        /// <returns></returns>
        private bool BuildAndExecuteTransaction(Dictionary<string, string> commands)
        {
            BeginTransaction();

            commands.Keys.ToList().ForEach(command => AddCommand("live", command));

            PerformTransaction(OnLoadComplete, null);

            return true;
        }
    }
}