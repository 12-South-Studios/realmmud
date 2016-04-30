//using System.Collections.Generic;
//using Realm.Server.NPC;

//
//namespace Realm.Server.Item
//
//{
//    public interface IItem
//    {
//        int MaxStackSize { get; set; }
//        int Weight { get; set; }
//        Globals.Globals.MaterialTypes Material { get; set; }
//        Globals.Globals.ItemTypes ItemType { get; set; }
//        int Volume { get; }
//        IEnumerable<Globals.Globals.WearLocations> WearLocations { get; }
//        int ZoneLimit { get; set; }
//        int GlobalLimit { get; set; }
//        IEnumerable<Globals.Globals.Statistics> StatMods { get; }

//        bool IsTakeable { get; }
//        bool IsTradeable { get; }
//        bool IsRepairable { get; }
//        bool IsWearable { get; }
//        bool IsStackable { get; }

//        bool CanBeWorn(IBiota biota);
//        bool IsType(string type);
//        int GetStatMod(Globals.Globals.Statistics stat);
//    }
//}
