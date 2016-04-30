//// ----------------------------------------------------------------------
//// <copyright file="KeyItemInstance.cs" company="12-South Studios">
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
//    public class KeyItemInstance : ItemInstance
//    {
//        public KeyItemInstance(long id, KeyItemTemplate parent)
//            : base(id, parent)
//        {
//        }

//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            var flag = (Flag) DataManager.Get("flags", "key");
//            if (flag.IsNull()) return;
//            Flags.SetFlag(flag.Abbrev);
//        }
//    }
//}
