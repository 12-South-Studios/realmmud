//using System;
//using System.Collections.Generic;
//using Realm.Server.Item;
//using Realm.Server.NPC;

//namespace Realm.Server.Test.Helpers
//{
//    public class FakeItemInstance : IItem
//    {
//        public int MaxStackSize { get; set; }
//        public int Weight { get; set; }
//        public Globals.Globals.MaterialTypes Material { get; set; }
//        public Globals.Globals.ItemTypes ItemType { get; set; }
//        public int Volume { get; private set; }
//        public IEnumerable<Globals.Globals.WearLocations> WearLocations { get; private set; }
//        public int ZoneLimit { get; set; }
//        public int GlobalLimit { get; set; }
//        public IEnumerable<Globals.Globals.Statistics> StatMods { get; private set; }
//        public bool IsTakeable { get; private set; }
//        public bool IsTradeable { get; private set; }
//        public bool IsRepairable { get; private set; }
//        public bool IsWearable { get; private set; }
//        public bool IsStackable { get; private set; }
//        public bool CanBeWorn(IBiota biota)
//        {
//            throw new NotImplementedException();
//        }

//        public bool IsType(string type)
//        {
//            return true;
//        }

//        public int GetStatMod(Globals.Globals.Statistics stat)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
