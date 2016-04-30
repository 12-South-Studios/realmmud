using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.GameEvents

{
    public class OnGameRound : EventBase
    {
        public OnGameRound()
        {
            Name = "OnGameRound";
        }
    }
}