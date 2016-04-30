using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.GameEvents

{
    public class OnGameEnter : EventBase
    {
        public OnGameEnter()
        {
            Name = "OnGameEnter";
        }
    }
}