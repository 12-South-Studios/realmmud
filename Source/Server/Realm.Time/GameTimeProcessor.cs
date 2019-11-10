using System;
using System.Collections.Generic;
using Realm.Data;
using Realm.Event;
using Realm.Event.EventTypes.GameEvents;
using Realm.Library.Common.Events;
using Realm.Time.Events;

namespace Realm.Time
{
    public class GameTimeProcessor
    {
        private readonly IEventManager _eventManager;
        private readonly List<int> _months;

        public GameTimeProcessor(IEventManager eventManager, List<int> months)
        {
            _months = months;
            _eventManager = eventManager;
            _eventManager.RegisterListener(this, typeof(OnGameRound), Instance_OnGameRound);
        }

        public GameState GameState
        {
            get { return _gameState; }
            set
            {
                if (_gameState == null)
                    _gameState = value;
            }
        }
        private GameState _gameState;

        private void Instance_OnGameRound(RealmEventArgs e)
        {
            ProcessGameTimeState();
        }

        private void ProcessGameTimeState()
        {
            if (_gameState.DateTime.Minute > 60)
                ChangeHour();
            
            CheckTimeOfDayEvents();
        }

        private void ChangeHour()
        {
            _gameState.DateTime.Hour++;
            _gameState.DateTime.Minute = 1;

            if (_gameState.DateTime.Hour > 24)
                ChangeDay();
        }

        private void ChangeDay()
        {
            _gameState.DateTime.Day++;
            _gameState.DateTime.Hour = 1;

            if (_gameState.DateTime.Day > _gameState.Month.NumberOfDays)
                ChangeMonth();
        }

        private void ChangeMonth()
        {
            _gameState.DateTime.Day = 1;

            if (IsLastMonthOfYear(_gameState.Month.ID))
                _gameState.DateTime.Year++;

            _eventManager.ThrowEvent<OnMonthChange>(this, new EventTable {{"month", _gameState.Month}});

            // TODO: Something needs to handle the month change and instantiate global effects
        }

        private int GetNextMonth(long monthId)
        {
            return IsLastMonthOfYear(monthId) ? 0 : _months.FindIndex(x => x == monthId);
        }

        private bool IsLastMonthOfYear(long monthId)
        {
            return _months.Count == _months.FindIndex(x => x == monthId) + 1;
        }

        private Globals.DayStateTypes GameStateToDayState()
        {
            var returnVal = Globals.DayStateTypes.Daylight;
            if (_gameState.IsDawn) returnVal = Globals.DayStateTypes.Dawn;
            else if (_gameState.IsSunrise) returnVal = Globals.DayStateTypes.Daylight;
            else if (_gameState.IsDusk) returnVal = Globals.DayStateTypes.Dusk;
            else if (_gameState.IsSunset) returnVal = Globals.DayStateTypes.Night;
            return returnVal;
        }

        private void CheckTimeOfDayEvents()
        {
            Func<Globals.DayStateTypes> stateFunc = GameStateToDayState;
            ThrowTimeChangeEvent(stateFunc.Invoke());

            if (_gameState.IsDawn)
            {
                // TODO: : display to all Spaces that are lit_by_sun
                // TODO: : display to all Spaces
            }
            else if (_gameState.IsSunrise)
            {
                // TODO: : display message
            }
        }

        private void ThrowTimeChangeEvent(Globals.DayStateTypes state)
        {
            _eventManager.ThrowEvent<OnTimeChange>(this, new EventTable {{"daystate", state}});
        }
    }
}
