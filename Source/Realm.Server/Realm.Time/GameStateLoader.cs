using System;
using System.Collections.Generic;
using Realm.Data;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Logging;
using Realm.Library.Database;
using Realm.Library.Database.Framework;
using Realm.Time.Interfaces;

namespace Realm.Time
{
    public class GameStateLoader : Entity, IGameStateLoader
    {
        private readonly IDatabaseManager _dbManager;
        private EventCallback<RealmEventArgs> _callback;
        private readonly DatabaseClient _client;
        private readonly ILogWrapper _log;

        public GameStateLoader(IDatabaseManager dbManager, ILogWrapper logger)
            : base(1, "GameStateLoader")
        {
            _dbManager = dbManager;
            _client = new DatabaseClient(this, _dbManager as IDatabaseLoadBalancer);
            _log = logger;
        }

        ~GameStateLoader()
        {
            _client.Dispose();
        }

 
        public void LoadGameState(EventCallback<RealmEventArgs> callback)
        {
            _callback = callback;
            _log.Debug("GameStateLoader initialized");

            try
            {
                _client.BeginTransaction();
                _client.AddCommand("live", "game_GetGameState");
                _client.PerformTransaction(OnLoadGameStateComplete, null);
            }
            catch (Exception ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordAndThrow);
            }
        }

        private void OnLoadGameStateComplete(RealmEventArgs args)
        {
            Validation.IsNotNull(args, "args");
            Validation.IsNotNull(args.Data, "args.Data");

            var data = args.Data.ToDictionaryAtom();
            if (!data.GetBool("success"))
                throw new ProcedureFailureException("Load Failure", GetType());

            var commandResults = data.GetAtom<ListAtom>("commandResult");
            var results = commandResults.GetEnumerator().Current.CastAs<DictionaryAtom>().GetAtom<ListAtom>("Results");
            var it = results.GetEnumerator();

            GameState newState = null;
            while (it.MoveNext())
            {
                var result = it.Current.CastAs<DictionaryAtom>();
                var obj = new GameState(new MudTime
                {
                    Year = result.GetInt("Year"),
                    Month = result.GetInt("MonthID"),
                    Day = result.GetInt("Day"),
                    Hour = result.GetInt("Hour"),
                    Minute = result.GetInt("Minute")
                });

                if (obj.IsNull())
                    throw new InstantiationException("Failed to instantiate GAmeState {0}", result.GetInt("GameStateID"));

                newState = obj;
            }

            _log.DebugFormat("GameStateLoader loaded the new game state: {0}", newState.ToString());

            if (_callback.IsNotNull())
                _callback.Invoke(new RealmEventArgs(new EventTable {{"GameState", newState}}));
        }

        public void LoadYear(EventCallback<RealmEventArgs> callback)
        {
            _callback = callback;

            try
            {
                _client.BeginTransaction();
                _client.AddCommand("live", "game_GetYear");
                _client.PerformTransaction(OnLoadYearComplete, null);
            }
            catch (Exception ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordAndThrow);
            }
        }

        private void OnLoadYearComplete(RealmEventArgs args)
        {
            Validation.IsNotNull(args, "args");
            Validation.IsNotNull(args.Data, "args.Data");

            var data = args.Data.ToDictionaryAtom();
            if (!data.GetBool("success"))
                throw new ProcedureFailureException("Load Failure", GetType());

            var commandResults = data.GetAtom<ListAtom>("commandResult");
            var results = commandResults.GetEnumerator().Current.CastAs<DictionaryAtom>().GetAtom<ListAtom>("Results");
            var it = results.GetEnumerator();

            var monthOrder = new List<int>();

            while (it.MoveNext())
            {
                var result = it.Current.CastAs<DictionaryAtom>();
                monthOrder.Add(result.GetInt("MonthID"));
            }

            if (_callback.IsNotNull())
                _callback.Invoke(new RealmEventArgs(new EventTable {{"Months", monthOrder}}));
        }
    }
}