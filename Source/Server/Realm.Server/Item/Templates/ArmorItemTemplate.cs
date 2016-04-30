//// ----------------------------------------------------------------------
//// <copyright file="ArmorItemTemplate.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
////     subject to the Microsoft Public License.  All other rights reserved.
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using Realm.Library.Common;

//
//namespace Realm.Server.Item
//
//{
//    public class ArmorItemTemplate : ItemTemplate
//    {
//        public ArmorItemTemplate(long id, string name)
//            : base(id, name) 
//        {
//        }

//       // public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            var flag = (Flag) DataManager.Get("Flags", "armor");
//            if (flag.IsNull()) return;
//            Flags.SetFlag(flag.Abbrev);
//            ItemType = EnumerationExtensions.GetEnum<Globals.Globals.ItemTypes>("armor");
//        }

//        public int Block
//        {
//            get { return Properties.GetProperty<int>("block"); }
//            set { Properties.SetProperty("block", value); }
//        }

//        public bool CanBlock
//        {
//            get { return Block > 0; }
//        }

//        public int Armor
//        {
//            get { return Properties.GetProperty<int>("armor"); }
//            set { Properties.SetProperty("armor", value); }
//        }
//    }
//}
