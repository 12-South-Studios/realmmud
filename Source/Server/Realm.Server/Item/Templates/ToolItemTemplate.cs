//// ----------------------------------------------------------------------
//// <copyright file="ToolItemTemplate.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
//// </copyright>
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Realm.Library.Common;

//
//namespace Realm.Server.Item
//
//{
//    public class ToolItemTemplate : ItemTemplate
//    {
//        public ToolItemTemplate(long id, string name)
//            : base(id, name)
//        {
//        }

//       // public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            var flag = (Flag) DataManager.Get("Flags", "tool");
//            if (flag.IsNull()) return;
//            Flags.SetFlag(flag.Abbrev);
//            ItemType = EnumerationExtensions.GetEnum<Globals.Globals.ItemTypes>("tool");
//            ToolTypes = new List<Globals.Globals.ToolTypes>();
//        }

//        public override void Clone(IGameEntity source)
//        {
//            base.Clone(source);
//            var tool = source as ToolItemTemplate;
//            if (tool.IsNull()) return;
//            ToolTypes = new List<Globals.Globals.ToolTypes>(tool.ToolTypes);
//        }

//        public IList<Globals.Globals.ToolTypes> ToolTypes { get; private set; }

//        public void AddToolType(string type)
//        {
//            if (HasToolType(type)) return;
//            var tool = EnumerationExtensions.GetEnum<Globals.Globals.ToolTypes>(type);
//            ToolTypes.Add(tool);
//        }

//        public bool HasToolType(string type)
//        {
//            return ToolTypes.Any(tt => tt.GetName().Equals(type, StringComparison.OrdinalIgnoreCase));
//        }
//    }
//}
