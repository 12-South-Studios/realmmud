using Realm.DAL.Common;
using Realm.DAL.Models;

namespace Realm.DAL
{
    public interface IPrimitive : IEntity
    {
        string SystemName { get; set; }

        SystemClass SystemClass { get; set; }

        string DisplayName { get; set; }
    }
}
