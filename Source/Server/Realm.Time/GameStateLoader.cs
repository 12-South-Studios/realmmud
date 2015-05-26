using System;
using System.Linq;
using Realm.DAL;
using Realm.Library.Common;
using Realm.Library.Common.Logging;
using Realm.Library.Database;
using Realm.Live.DAL;
using Realm.Time.Interfaces;

namespace Realm.Time
{
    public class GameStateLoader : Entity, IGameStateLoader
    {
        private readonly IRealmLiveDbContext _liveDbContext;
        private readonly IRealmDbContext _dbContext;
        private EventCallback<RealmEventArgs> _callback;
        private readonly ILogWrapper _log;

        public GameStateLoader(IRealmLiveDbContext liveDbContext, IRealmDbContext dbContext, ILogWrapper logger)
            : base(1, "GameStateLoader")
        {
            _liveDbContext = liveDbContext;
            _dbContext = dbContext;
            _log = logger;
        }
 
        public void LoadGameState(EventCallback<RealmEventArgs> callback)
        {
            _callback = callback;
            _log.Debug("GameStateLoader initialized");

            try
            {
                var gameState = _liveDbContext.GameStates.LastOrDefault();
                if (gameState == null)
                    throw new ProcedureFailureException("Load Failure", GetType());

                var obj = new GameState(new MudTime
                {
                    Year = gameState.Year,
                    Month = gameState.MonthId,
                    Day = gameState.Day,
                    Hour = gameState.Hour,
                    Minute = gameState.Minute
                });

                _log.DebugFormat("GameStateLoader loaded the new game state: {0}", obj.ToString());

                if (_callback.IsNotNull())
                    _callback.Invoke(new RealmEventArgs(new EventTable { { "GameState", obj } }));
            }
            catch (Exception ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordAndThrow);
            }
        }

        public void LoadYear(EventCallback<RealmEventArgs> callback)
        {
            _callback = callback;

            try
            {
                var monthsInOrder = _dbContext.Months.OrderBy(x => x.SortOrder).Select(month => month.Id).ToList();
                if (_callback.IsNotNull())
                    _callback.Invoke(new RealmEventArgs(new EventTable { { "Months", monthsInOrder } }));
            }
            catch (Exception ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordAndThrow);
            }
        }
    }
}