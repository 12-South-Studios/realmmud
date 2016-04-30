using Realm.Library.Common.Attributes;

namespace Realm.DAL.Enumerations
{
    public enum EntityLocationTypes
    {
        [Value(1)]
        Space = 1,

        [Value(2)]
        Inventory = 2,

        [Value(4)]
        Equipment = 3,

        [Value(8)]
        Container = 4,

        [Value(16)]
        MobileInventory = 5,

        [Value(32)]
        MobileEquipment = 6,

        [Value(64)]
        Shop = 7,

        [Value(128)]
        Ability = 8,

        [Value(256)]
        Effects = 9,

        [Value(512)]
        Recipes = 10
    }
}
