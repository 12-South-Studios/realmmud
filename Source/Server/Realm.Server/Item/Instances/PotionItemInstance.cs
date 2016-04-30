//// ----------------------------------------------------------------------
//// <copyright file="PotionItemInstance.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
////     subject to the Microsoft Public License.  All other rights reserved.
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using System;
//using Realm.Library.Common;

//
//namespace Realm.Server.Item
//
//{
//    public class PotionItemInstance : ItemInstance
//    {
//        public PotionItemInstance(long id, PotionItemTemplate parent)
//            : base(id, parent)
//        {
//        }

//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            var flag = (Flag) DataManager.Get("flags", "potion");
//            if (flag.IsNull()) return;
//            Flags.SetFlag(flag.Abbrev);
//        }

//        public bool IsCloseable
//        {
//            get
//            {
//                var parent = Parent as PotionItemTemplate;
//                return parent.IsNotNull() && parent.IsCloseable;
//            }
//        }

//        public int MaxCharges
//        {
//            get
//            {
//                var parent = Parent as PotionItemTemplate;
//                return parent.IsNotNull() ? parent.MaxCharges : 0;
//            }
//        }

//        public Liquid FilledWith
//        {
//            get
//            {
//                var parent = Parent as PotionItemTemplate;
//                return parent.IsNotNull() ? parent.FilledWith : null;
//            }
//        }

//        public int CurrentCharges
//        {
//            get
//            {
//                object prop = GetProperty("current_charges");
//                return prop.IsNotNull() ? Convert.ToInt32(prop) : 0;
//            }
//        }

//        public bool IsFull
//        {
//            get { return CurrentCharges >= MaxCharges; }
//        }

//        public bool IsEmpty
//        {
//            get { return CurrentCharges <= 0; }
//        }

//        public bool IsClosed
//        {
//            get 
//            {
//                return IsCloseable && Bits.HasBit(Globals.Globals.ItemBits.IsClosed);
//            }
//            set
//            {
//                if (!IsCloseable) return;
//                if (value)
//                    Bits.SetBit(Globals.Globals.ItemBits.IsClosed);
//                else
//                    Bits.UnsetBit(Globals.Globals.ItemBits.IsClosed);
//            }
//        }
//    }
//}
