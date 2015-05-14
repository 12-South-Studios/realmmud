//using Realm.Library.Common;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Item
//// ReSharper restore CheckNamespace
//{
//    public class LightItemTemplate : ItemTemplate
//    {
//        public LightItemTemplate(long id, string name)
//            : base(id, name)
//        {
//        }

//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            var flag = (Flag) DataManager.Get("flags", "light");
//            if (flag.IsNull()) return;
//            Flags.SetFlag(flag.Abbrev);
//            ItemType = EnumerationExtensions.GetEnum<Globals.Globals.ItemTypes>("light");
//        }

//        public override void Clone(IGameEntity source)
//        {
//            base.Clone(source);
//            var light = source as LightItemTemplate;
//            if (light.IsNull()) return;
//            Fuel = light.Fuel;
//        }

//        public ItemFuel Fuel { get; private set; }

//        public void SetLiquidFuel(int burnRate, int charges, string liquidName)
//        {
//            var liquid = (Liquid)DataManager.Get("Liquids", liquidName);
//            if (null == liquid) return;
//            Fuel = new LiquidFuel(burnRate, charges, liquid);
//        }

//        public void SetSolidFuel(int burnTime)
//        {
//            Fuel = new SolidFuel(burnTime);
//        }
//    }
//}
