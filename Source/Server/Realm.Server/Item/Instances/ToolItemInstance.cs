//// ----------------------------------------------------------------------
//// <copyright file="ToolItemInstance.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
////     subject to the Microsoft Public License.  All other rights reserved.
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using System.Collections.Generic;
//using Realm.Library.Common;

//
//namespace Realm.Server.Item
//
//{
//    public class ToolItemInstance : ItemInstance
//    {
//        public ToolItemInstance(long id, ToolItemTemplate parent)
//            : base(id, parent)
//        {
//        }

//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            var flag = (Flag) DataManager.Get("flags", "tool");
//            if (flag.IsNull()) return;
//            Flags.SetFlag(flag.Abbrev);
//        }

//        public IList<Globals.Globals.ToolTypes> ToolTypes
//        {
//            get
//            {
//                var parent = Parent as ToolItemTemplate;
//                return parent.IsNotNull() ? parent.ToolTypes : new List<Globals.Globals.ToolTypes>();
//            }
//        }

//        public bool HasToolType(string type)
//        {
//            var parent = Parent as ToolItemTemplate;
//            return parent.IsNotNull() && parent.HasToolType(type);
//        }
//    }
//}
