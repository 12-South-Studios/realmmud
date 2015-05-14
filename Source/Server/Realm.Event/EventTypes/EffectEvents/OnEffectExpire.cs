using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnEffectExpire : EventBase
    {
        public OnEffectExpire(string name)
        {
            Name = name;
        }
    }
}