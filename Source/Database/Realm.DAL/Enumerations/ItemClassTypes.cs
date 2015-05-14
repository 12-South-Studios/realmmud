using Realm.DAL.Common.Attributes;

namespace Realm.DAL.Enumerations
{
    public enum ItemClassTypes
    {
        [Color(10)]
        Common = 1,

        [Color(5)]
        Uncommon = 2,

        [Color(4)]
        Rare = 3,

        [Color(17)]
        Legendary = 4,

        [Color(8)]
        Epic = 5
    }
}
