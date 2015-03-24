using Realm.Library.Common;

namespace Realm.DAL.Enumerations
{
    public enum ItemTypes
    {
        [Value(1)]
        Weapon = 1,

        [Value(2)]
        Armor = 2,
        
        [Value(4)]
        Light = 3,

        [Value(8)]
        Container = 4,

        [Value(16)]
        DrinkContainer = 5,

        [Value(32)]
        Key = 6,

        [Value(64)]
        Tool = 7,

        [Value(128)]
        Machine = 8,

        [Value(256)]
        Resource = 9,

        [Value(512)]
        Furniture = 10,

        [Value(1024)]
        Book = 11,

        [Value(2048)]
        Vehicle = 12,

        [Value(4096)]
        Corpse = 13,

        [Value(8192)]
        Reagant = 14,

        [Value(16384)]
        Portal = 15,

        [Value(32768)]
        Food = 16,

        [Value(65536)]
        Treasure = 17,

        [Value(131072)]
        Potion = 18,

        [Value(262144)]
        ResourceNode = 19,

        [Value(524288)]
        Formula = 20,

        [Value(1048576)]
        Rune = 21,

        [Value(2097152)]
        Lock = 22,

        [Value(4194304)]
        Trap = 23,

        [Value(8388608)]
        QuestItem = 24,

        [Value(16777216)]
        MagicalNode = 25,

        [Value(33554432)]
        Simple = 26,

        [Value(67108864)]
        Boat = 27
    }
}
