﻿//// ----------------------------------------------------------------------
//// <copyright file="KeyItemInstance.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
////     subject to the Microsoft Public License.  All other rights reserved.
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using Realm.Library.Common;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Item
//// ReSharper restore CheckNamespace
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
