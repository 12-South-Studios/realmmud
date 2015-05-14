//// ----------------------------------------------------------------------
//// <copyright file="LightItemInstance.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
////     subject to the Microsoft Public License.  All other rights reserved.
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using System.Text;
//using Realm.Library.Common;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Item
//// ReSharper restore CheckNamespace
//{
//    public class LightItemInstance : ItemInstance
//    {
//        public LightItemInstance(long id, LightItemTemplate parent)
//            : base(id, parent)
//        {
//        }

//       // public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            var flag = (Flag) DataManager.Get("flags", "light");
//            if (flag.IsNull()) return;
//            Flags.SetFlag(flag.Abbrev);
//        }

//        public ItemFuel Fuel
//        {
//            get
//            {
//                var parent = Parent as LightItemTemplate;
//                return parent.IsNotNull() ? parent.Fuel : null;
//            }
//        }

//        public override string Explore(IGameEntity entity)
//        {
//            var sb = new StringBuilder();
//            var template = Parent as LightItemTemplate;
//            if (template.IsNull()) return string.Empty;

//            if (Fuel.FuelType.Equals("liquid"))
//            {
//                var liquidFuel = Fuel as LiquidFuel;
//                // TODO: Save Liquid Fuel - Fill this in
//            }
//            else
//            {
//                var solidFuel = Fuel as SolidFuel;
//                // TODO: Save Solid Fuel - Fill this in
//            }
//            return sb.ToString();
//        }

//        public override string Save(bool toggle = false)
//        {
//            var sb = new StringBuilder();

//            // TODO: solid vs liquid fuel
//            sb.Append(base.Save(toggle));

//            return sb.ToString();
//        }
//    }
//}
