using Realm.Entity;

namespace Realm.Server.Interfaces
{
    public interface IExplorable
    {
        string Explore(IGameEntity entity);
    }
}
