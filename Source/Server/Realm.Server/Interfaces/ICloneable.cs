using Realm.Entity.Interfaces;

namespace Realm.Server.Interfaces
{
    public interface ICloneable
    {
        void Clone(IGameEntity source);
    }
}
