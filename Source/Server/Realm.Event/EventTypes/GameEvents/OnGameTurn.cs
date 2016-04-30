using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.GameEvents

{
    public class OnGameTurn : EventBase
    {
        public OnGameTurn()
        {
            Name = "OnGameTurn";
        }
    }
}