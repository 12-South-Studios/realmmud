using System;
using Realm.Data;
using Realm.Data.Definitions;
using Realm.Data.Interfaces;
using Realm.Entity.Interfaces;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Events;
using Realm.Library.Common.Exceptions;
using Realm.Library.Common.Extensions;
using Realm.Library.Common.Logging;
using Realm.Library.Common.Objects;
using Realm.Library.Database;
using Realm.Library.Database.Framework;

namespace Realm.Communication
{
    public class ChannelLoader : Library.Common.Objects.Entity
    {
        private readonly IDatabaseManager _dbManager;
        private readonly IEntityManager _entityManager;
        private readonly IStaticDataManager _staticDataManager;
        private EventCallback<RealmEventArgs> _callback;
        private readonly ChannelRepository _repository;
        private readonly ILogWrapper _log;

        ///  <summary>
        /// 
        ///  </summary>
        ///  <param name="initAtom"></param>
        ///  <param name="repository"></param>
        /// <param name="logger"></param>
        public ChannelLoader(DictionaryAtom initAtom, ChannelRepository repository, ILogWrapper logger)
            : base(1, "ChannelLoader")
        {
            _dbManager = initAtom.GetObject("DatabaseManager").CastAs<IDatabaseManager>();
            _entityManager = initAtom.GetObject("EntityManager").CastAs<IEntityManager>();
            _staticDataManager = initAtom.GetObject("StaticDataManager").CastAs<IStaticDataManager>();

            _repository = repository;
            _log = logger;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="callback"></param>
        public void LoadChannels(EventCallback<RealmEventArgs> callback)
        {
            _callback = callback;
            _log.Debug("Executing stored procedure 'game_GetChannels'");

            try
            {
                var client = new DatabaseClient(this, _dbManager as IDatabaseLoadBalancer);
                client.BeginTransaction();
                client.AddCommand("live", "game_GetChannels");
                client.PerformTransaction(OnLoadChannelsComplete, null);
            }
            catch (Exception ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordAndThrow);
            }
        }

        private void OnLoadChannelsComplete(RealmEventArgs args)
        {
            Validation.IsNotNull(args, "args");
            Validation.IsNotNull(args.Data, "args.Data");

            var data = args.Data.ToDictionaryAtom();
            if (!data.GetBool("success"))
                throw new ProcedureFailureException("Load Failure", GetType());

            var commandResults = data.GetAtom<ListAtom>("commandResult");
            var results = commandResults.GetEnumerator().Current.CastAs<DictionaryAtom>().GetAtom<ListAtom>("Results");
            using (var it = results.GetEnumerator())
            {
                while (it.MoveNext())
                {
                    var result = it.Current.CastAs<DictionaryAtom>();
                    var channelDef = (ChannelDef)_staticDataManager.GetStaticData(Globals.SystemTypes.Channel, result.GetInt("ChannelPrimitiveID").ToString());
                    var obj = _entityManager.Create<Channel>(result.GetInt("ChannelID"), result.GetString("Name"), result, channelDef);
                    if (obj == null)
                        throw new InstantiationException("Failed to instantiate Channel {0}", result.GetInt("ChannelID"));

                    obj.OnInit(_entityManager.InitializationAtom);
                    _repository.Add(obj.ID, obj);
                }
            }

            _log.DebugFormat("Loaded {0} channels.", _repository.Count);
            _callback?.Invoke(new RealmEventArgs());
        }
    }
}