using Realm.Library.Patterns.Repository;

namespace Realm.Network.User
{
    /// <summary>
    /// Stores Game Users with the User's Guid as the key
    /// </summary>
    public class GameUserRepository : Repository<string, GameUser>, IUserRepository
    {
    }
}