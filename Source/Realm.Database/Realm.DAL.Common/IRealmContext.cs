using System.Data.Entity.Core.Objects;

namespace Realm.DAL.Common
{
    public interface IRealmContext
    {
        ObjectContext ObjectContext { get; }
        int SaveChanges();
    }
}
