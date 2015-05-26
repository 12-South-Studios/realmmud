using Realm.DAL.Models;

namespace Realm.DAL
{
    public interface IPrimitive
    {
        string SystemName { get; set; }

        SystemClass SystemClass { get; set; }
    }
}
