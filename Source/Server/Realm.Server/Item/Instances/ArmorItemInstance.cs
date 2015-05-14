//// ----------------------------------------------------------------------
//// <copyright file="ArmorItemInstance.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
////     subject to the Microsoft Public License.  All other rights reserved.
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//// ReSharper disable CheckNamespace

//using Realm.Library.Common;

//namespace Realm.Server.Item
//// ReSharper restore CheckNamespace
//{
//    public class ArmorItemInstance : ItemInstance
//    {
//        public ArmorItemInstance(long id, ArmorItemTemplate parent)
//            : base(id, parent)
//        {
//        }

//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            var flag = (Flag) DataManager.Get("Flags", "armor");
//            if (flag.IsNull()) return;
//            Flags.SetFlag(flag.Abbrev);
//        }

//        public int Block
//        {
//            get
//            {
//                var parent = Parent as ArmorItemTemplate;
//                return parent.IsNotNull() ? parent.Block : 0;
//            }
//        }

//        public bool CanBlock
//        {
//            get
//            {
//                var parent = Parent as ArmorItemTemplate;
//                return parent.IsNotNull() && parent.CanBlock;
//            }
//        }

//        public int Armor
//        {
//            get
//            {
//                var parent = Parent as ArmorItemTemplate;
//                return parent.IsNotNull() ? parent.Armor : 0;
//            }
//        }
//    }
//}
