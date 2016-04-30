using Realm.Entity.Interfaces;

namespace Realm.Server.Interfaces
{
    public interface IExplorable
    {
        string Explore(IGameEntity entity);
    }
}
