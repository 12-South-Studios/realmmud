using Realm.Library.Patterns.Repository;

namespace Realm.Network.User
{
    public class PendingUserRepository : Repository<string, GameUser>, IUserRepository
    {
    }
}