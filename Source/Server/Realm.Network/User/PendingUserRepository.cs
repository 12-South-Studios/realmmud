using Realm.Standard.Patterns.Repository;

namespace Realm.Network.User
{
    public class PendingUserRepository : Repository<string, GameUser>, IUserRepository
    {
    }
}