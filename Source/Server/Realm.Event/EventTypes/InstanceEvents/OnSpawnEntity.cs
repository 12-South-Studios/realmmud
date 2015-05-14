using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnSpawnEntity : EventBase
    {
        public OnSpawnEntity(string name)
        {
            Name = name;
        }
    }
}