using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.CharacterEvents

{
    public class OnAttributeRankup : EventBase
    {
        public OnAttributeRankup(string name)
        {
            Name = name;
        }
    }
}