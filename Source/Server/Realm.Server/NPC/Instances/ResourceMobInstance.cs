//// ----------------------------------------------------------------------
//// <copyright file="HarvestableMobInstance.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
//// </copyright>
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using Realm.Server.Item;

//
//namespace Realm.Server.NPC
//
//{
//    public class ResourceMobInstance : RegularMobInstance, IResourceMob
//    {
//        public ResourceMobInstance(long id, ResourceMobTemplate parent)
//            : base(id, parent)
//        {
//            Node = parent.Node;
//            State = parent.State;
//        }

//        #region IResourceMob
//        public ItemTemplate Node { get; private set; }

//        public Globals.Globals.MobileNodeTypes State { get; private set; }
//        #endregion

//        /*public new void OnEntitySpaceEnter(MUDEventArgs e)
//        {
//            if (e.Sender != Location)
//            {
//                return;
//            }

//            //// TODO: Push the AlertState onto the Stack
//        }*/

//        /*public new void OnEntitySpaceLeave(MUDEventArgs e)
//        {
//            if (e.Sender != Location)
//            {
//                return;
//            }

//            //// TODO: If there are no more players in the Space, pop the AlertState from the Stack
//        }*/
//    }
//}
