using System.Collections.Generic;
using Ninject;
using Realm.Data;
using Realm.Event;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Logging;
using Realm.Time.Interfaces;

namespace Realm.Time
{
    public sealed class TimeManager : GameSingleton, ITimeManager
    {
        private BooleanSet _loadingSet;
        private DictionaryAtom _initAtom;
        private readonly GameStateLoader _loader;
        private GameTimeProcessor _processor;

        public TimeManager(IEventManager eventManager, ILogWrapper logWrapper, IDatabaseManager databaseManager, 
            IGameStateLoader gameStateLoader)
        {
            _loader = (GameStateLoader) gameStateLoader;
            EventManager = eventManager;
            Log = logWrapper;
            DatabaseManager = databaseManager;
        }

        private IEventManager EventManager { get; set; }
        private ILogWrapper Log { get; set; }
        private IDatabaseManager DatabaseManager { get; set; }
        public GameState CurrentGameState { get; private set; }

        public void OnInit(DictionaryAtom initAtom)
        {
            Validation.IsNotNull(initAtom, "initAtom");

            _initAtom = initAtom;

            Log.DebugFormat("{0} setup.", GetType());
            EventManager.RegisterListener(this, typeof(OnGameInitialize), Instance_OnGameInitialize);
            EventManager.RegisterListener(this, typeof(OnGameStop), Instance_OnGameStop);
        }

        public override void Instance_OnGameInitialize(RealmEventArgs args)
        {
            Log.DebugFormat("{0} received Event OnGameInitialize", GetType());

            _loadingSet = args.GetValue("BooleanSet") as BooleanSet;

            _loader.LoadGameState(OnLoadGameStateComplete);
        }

        private void Instance_OnGameStop(RealmEventArgs args)
        {
            CurrentGameState.Save();
        }

        private void OnLoadGameStateComplete(RealmEventArgs args)
        {
            CurrentGameState = args.GetValue("GameState").CastAs<GameState>();
            if (CurrentGameState.IsNull())
                CurrentGameState = new GameState(
                    new MudTime
                    {
                        Year = _initAtom.GetInt("DefaultGameYear"),
                        Month = _initAtom.GetInt("DefaultGameMonth"),
                        Day = _initAtom.GetInt("DefaultGameDay"),
                        Hour = _initAtom.GetInt("DefaultGameHour"),
                        Minute = _initAtom.GetInt("DefaultGameMinute")
                    });

            Log.Debug("GameStateLoad completed. Loading the Year.");
            _loader.LoadYear(OnLoadYearComplete);
        }

        private void OnLoadYearComplete(RealmEventArgs args)
        {
            _loadingSet.CompleteItem("TimeManager");

            _processor = new GameTimeProcessor(EventManager, args.GetValue("Months").CastAs<List<int>>())
            {
                GameState = CurrentGameState
            };

            args.Data["BooleanSet"] = _loadingSet;
            base.Instance_OnGameInitialize(args);
        }
    }
}
