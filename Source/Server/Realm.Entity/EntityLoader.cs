using System;
using System.Collections.Generic;
using Realm.Data.Interfaces;
using Realm.Entity.Interfaces;
using Realm.Entity.Properties;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Events;
using Realm.Library.Common.Exceptions;
using Realm.Library.Common.Extensions;
using Realm.Library.Common.Logging;
using Realm.Library.Common.Objects;
using Realm.Library.Database;
using Realm.Library.Database.Framework;

namespace Realm.Entity
{
    /// <summary>
    ///
    /// </summary>
    public class EntityLoader : Library.Common.Objects.Entity, IEntityLoader
    {
        private static readonly Dictionary<string, int> StartupZones = new Dictionary<string, int>();
        private readonly IDatabaseManager _dbManager;
        private readonly ILogWrapper _log;
        private EventCallback<RealmEventArgs> _callback;

        /// <summary>
        ///
        /// </summary>
        /// <param name="dbManager"></param>
        /// <param name="log"> </param>
        public EntityLoader(IDatabaseManager dbManager, ILogWrapper log)
            : base(1, "EntityLoader")
        {
            _dbManager = dbManager;
            _log = log;
        }

        /// <summary>
        /// Generates a list of Entity IDs
        /// </summary>
        public void LoadStartupEntities(EventCallback<RealmEventArgs> callback)
        {
            _callback = callback;

            try
            {
                var client = new DatabaseClient(this, _dbManager as IDatabaseLoadBalancer);
                client.BeginTransaction();
                client.AddCommand("dbo", "game_GetStartupZones", null, callback);
                client.PerformTransaction(OnLoadStartupEntitiesCompleted, null);
            }
            catch (Exception ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordAndThrow);
            }
        }

        private void OnLoadStartupEntitiesCompleted(RealmEventArgs args)
        {
            _log.Debug("OnLoadStartupEntities completed.");

            Validation.IsNotNull(args, "args");
            Validation.IsNotNull(args.Data, "args.Data");

            var data = args.Data.ToDictionaryAtom();
            if (!data.GetBool("success"))
                throw new ProcedureFailureException(Resources.ERR_LOAD_FAILURE, GetType());

            var commandResults = data.GetAtom<ListAtom>("commandResult");
            var it = commandResults.GetEnumerator();
            while (it.MoveNext())
            {
                var commandResult = it.Current.CastAs<DictionaryAtom>();
                var commandName = commandResult.GetString("CommandName");
                var results = commandResult.GetAtom<ListAtom>("Results");

                if (commandName.Equals("game_GetStartupZones"))
                {
                    var itResult = results.GetEnumerator();
                    while (itResult.MoveNext())
                    {
                        var result = itResult.Current.CastAs<DictionaryAtom>();
                        StartupZones.Add(result.GetString("Name"), result.GetInt("ID"));
                    }
                }
            }

            _callback.Invoke(new RealmEventArgs(new EventTable {{"zones", StartupZones}}));
        }
    }
}