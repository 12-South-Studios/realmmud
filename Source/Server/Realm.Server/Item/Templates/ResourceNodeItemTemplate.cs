//// ----------------------------------------------------------------------
//// <copyright file="ResourceNodeItemTemplate.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
//// </copyright>
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using System.Collections.Generic;
//using System.Linq;
//using Realm.Library.Common;

//
//namespace Realm.Server.Item
//
//{
//    public class ResourceNodeItemTemplate : ItemTemplate
//    {
//        public ResourceNodeItemTemplate(long id, string name)
//            : base(id, name)
//        {
//        }

//       // public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            var flag = (Flag) DataManager.Get("Flags", "resource node");
//            if (flag.IsNull()) return;
//            Flags.SetFlag(flag.Abbrev);
//            ItemType = EnumerationExtensions.GetEnum<Globals.Globals.ItemTypes>("resource node");
//            ToolTypes = new List<ResourceToolType>();
//        }

//        public override void Clone(IGameEntity source)
//        {
//            base.Clone(source);
//            var node = source as ResourceNodeItemTemplate;
//            if (node.IsNull()) return;
//            ToolTypes = new List<ResourceToolType>(node.ToolTypes);
//        }

//        public IList<ResourceToolType> ToolTypes { get; private set; }

//        public new void AddResource(long resourceId, string toolType, int gatherAmt, int minSkill)
//        {
//            var rtt = new ResourceToolType
//                          {
//                              ResourceId = resourceId,
//                              ToolType = EnumerationExtensions.GetEnum<Globals.Globals.ToolTypes>(toolType),
//                              GatherAmount = gatherAmt,
//                              MinimumSkill = minSkill
//                          };
//            if (!ToolTypes.Contains(rtt))
//                ToolTypes.Add(rtt);
//        }

//        public ResourceToolType GetToolType(long resourceId)
//        {
//            return ToolTypes.FirstOrDefault(rtt => rtt.ResourceId == resourceId);
//        }

//        public ResourceToolType GetToolType(string toolType)
//        {
//            var tt = EnumerationExtensions.GetEnum<Globals.Globals.ToolTypes>(toolType);
//            return GetToolType(tt);
//        }

//        public ResourceToolType GetToolType(Globals.Globals.ToolTypes toolType)
//        {
//            return ToolTypes.FirstOrDefault(rtt => rtt.ToolType == toolType);
//        }

//        public bool IsValidTool(Globals.Globals.ToolTypes toolType)
//        {
//            return GetToolType(toolType).IsNotNull();
//        }

//        public bool IsValidTool(ICollection<Globals.Globals.ToolTypes> toolTypes)
//        {
//            return toolTypes.Any(type => GetToolType(type).IsNotNull());
//        }
//    }
//}
