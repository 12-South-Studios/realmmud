//// ----------------------------------------------------------------------
//// <copyright file="PotionItemTemplate.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
////     subject to the Microsoft Public License.  All other rights reserved.
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using System;
//using Realm.Library.Common;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Item
//// ReSharper restore CheckNamespace
//{
//    public class PotionItemTemplate : ItemTemplate
//    {
//        public PotionItemTemplate(long id, string name)
//            : base(id, name)
//        {
//        }

//       // public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            var flag = (Flag) DataManager.Get("Flags", "potion");
//            if (flag.IsNull()) return;
//            Flags.SetFlag(flag.Abbrev);
//            ItemType = EnumerationExtensions.GetEnum<Globals.Globals.ItemTypes>("potion");
//        }

//        public bool IsCloseable
//        {
//            get { return Bits.HasBit(Globals.Globals.ItemBits.IsCloseable); }
//        }

//        public int MaxCharges
//        {
//            get { return Properties.GetProperty<int>("max_charges"); }
//            set { Properties.SetProperty("max_charges", value); }
//        }

//        public Liquid FilledWith
//        {
//            get
//            {
//                var liquidName = Properties.GetProperty<string>("filled_with");
//                if (liquidName.Equals("empty", StringComparison.OrdinalIgnoreCase)) return null;
//                return (Liquid)DataManager.Get("Liquids", liquidName);
//            }
//            set { Properties.SetProperty("filled_with", null == value ? "empty" : value.Name); }
//        }
//    }
//}
