using Realm.Library.Common;

// ReSharper disable CheckNamespace
namespace Realm.Event
// ReSharper restore CheckNamespace
{
    public class OnMobSpawn : EventBase
    {
        public OnMobSpawn(string name)
        {
            Name = name;
        }
    }
}