using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.GameEvents

{
    public class OnGameStart : EventBase
    {
        public OnGameStart()
        {
            Name = "OnGameStart";
        }
    }
}