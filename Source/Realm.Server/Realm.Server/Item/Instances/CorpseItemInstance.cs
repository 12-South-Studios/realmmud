//// ----------------------------------------------------------------------
//// <copyright file="CorpseItemInstance.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
//// </copyright>
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using Realm.Library.Common;
//using Realm.Server.NPC;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Item
//// ReSharper restore CheckNamespace
//{
//    public class CorpseItemInstance : ContainerItemInstance
//    {
//        public CorpseItemInstance(long id, CorpseItemTemplate parent)
//            : base(id, parent)
//        {
//        }

//       // public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            var flag = (Flag) DataManager.Get("Flags", "corpse");
//            if (flag.IsNull()) return;
//            Flags.SetFlag(flag.Abbrev);
//        }

//        public IBiota LockedTo { get; set; }
//    }
//}
