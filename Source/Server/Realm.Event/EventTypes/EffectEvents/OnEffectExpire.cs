using Realm.Library.Common.Events;

namespace Realm.Event.EventTypes.EffectEvents

{
    public class OnEffectExpire : EventBase
    {
        public OnEffectExpire(string name)
        {
            Name = name;
        }
    }
}