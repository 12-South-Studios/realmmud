//// ----------------------------------------------------------------------
//// <copyright file="MachineItemInstance.cs" company="12-South Studios">
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
//    public class MachineItemInstance : ItemInstance
//    {
//        public MachineItemInstance(long id, MachineItemTemplate parent)
//            : base(id, parent)
//        {
//        }

//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            var flag = (Flag) DataManager.Get("flags", "machine");
//            if (flag.IsNull()) return;
//            Flags.SetFlag(flag.Abbrev);
//        }

//        public Globals.Globals.MachineTypes Machine
//        {
//            get
//            {
//                var parent = Parent as MachineItemTemplate;
//                return parent.Machine;
//            }
//        }
//    }
//}
