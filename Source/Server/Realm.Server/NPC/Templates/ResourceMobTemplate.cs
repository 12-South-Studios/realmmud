//// ----------------------------------------------------------------------
//// <copyright file="HarvestableMobTemplate.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
//// </copyright>
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using System;
//using Realm.Library.Common;
//using Realm.Server.Item;

//
//namespace Realm.Server.NPC
//
//{
//    public class ResourceMobTemplate : RegularMobTemplate
//    {
//        public ResourceMobTemplate(long id, string name)
//            : base(id, name)
//        {
//        }

//        public ItemTemplate Node { get; private set; }
//        public Globals.Globals.MobileNodeTypes State { get; private set; }

//        public override void AddNode(long id, string state)
//        {
//            var entity = EntityManager.LuaGetTemplate(id);
//            if (entity.IsNull()) return;
//            State = (state.Equals("dead", StringComparison.OrdinalIgnoreCase)) 
//                ? Globals.Globals.MobileNodeTypes.Dead
//                : Globals.Globals.MobileNodeTypes.Alive;
//            Node = entity as ItemTemplate;
//        }
//    }
//}
