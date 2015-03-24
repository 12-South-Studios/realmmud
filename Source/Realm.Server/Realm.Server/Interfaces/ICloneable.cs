using Realm.Entity;

namespace Realm.Server.Interfaces
{
    public interface ICloneable
    {
        void Clone(IGameEntity source);
    }
}
