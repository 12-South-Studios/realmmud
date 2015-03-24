//// ----------------------------------------------------------------------
//// <copyright file="ResourceNodeItemInstance.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
////     subject to the Microsoft Public License.  All other rights reserved.
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using System;
//using System.Collections.Generic;
//using System.Text;
//using Realm.Library.Common;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Item
//// ReSharper restore CheckNamespace
//{
//    public class ResourceNodeItemInstance : ItemInstance
//    {
//        public ResourceNodeItemInstance(long id, ResourceNodeItemTemplate parent)
//            : base(id, parent)
//        {
//        }

//       // public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            var flag = (Flag) DataManager.Get("flags", "resource node");
//            if (flag.IsNull()) return;
//            Flags.SetFlag(flag.Abbrev);
//        }

//        public ResourceToolType GetToolType(int resourceId)
//        {
//            var parent = Parent as ResourceNodeItemTemplate;
//            return parent.IsNotNull() ? parent.GetToolType(resourceId) : null;
//        }

//        public ResourceToolType GetToolType(string toolType)
//        {
//            var parent = Parent as ResourceNodeItemTemplate;
//            return parent.IsNotNull() ? parent.GetToolType(toolType) : null;
//        }

//        public ResourceToolType GetToolType(Globals.Globals.ToolTypes toolType)
//        {
//            var parent = Parent as ResourceNodeItemTemplate;
//            return parent.IsNotNull() ? parent.GetToolType(toolType) : null;
//        }

//        public bool IsValidTool(Globals.Globals.ToolTypes toolType)
//        {
//            var parent = Parent as ResourceNodeItemTemplate;
//            return parent.IsNotNull() && parent.IsValidTool(toolType);
//        }

//        public bool IsValidTool(ICollection<Globals.Globals.ToolTypes> toolTypes)
//        {
//            var parent = Parent as ResourceNodeItemTemplate;
//            return parent.IsNotNull() && parent.IsValidTool(toolTypes);
//        }     

//        public override string Explore(IGameEntity entity)
//        {
//            var sb = new StringBuilder();
//            var node = Parent as ResourceNodeItemTemplate;
//            if (node.IsNull()) return string.Empty;

//            foreach (var rtt in node.ToolTypes)
//            {
//                sb.AppendFormat("  {0} {1} using {2}{3}", rtt.GatherAmount,
//                                rtt.GatherAmount > 1
//                                    ? EntityManager.LuaGetTemplate(rtt.ResourceId).PluralName
//                                    : EntityManager.LuaGetTemplate(rtt.ResourceId).Name, rtt.ToolType.GetName(),
//                                Environment.NewLine);
//            }
//            return sb.ToString();
//        }
//    }
//}
