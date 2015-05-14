//// ----------------------------------------------------------------------
//// <copyright file="MachineItemTemplate.cs" company="12-South Studios">
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
//    public class MachineItemTemplate : ItemTemplate
//    {
//        public MachineItemTemplate(long id, string name)
//            : base(id, name)
//        {
//        }

//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            var flag = (Flag) DataManager.Get("Flags", "machine");
//            if (flag.IsNull()) return;
//            Flags.SetFlag(flag.Abbrev);
//            ItemType = EnumerationExtensions.GetEnum<Globals.Globals.ItemTypes>("machine");
//        }

//        public Globals.Globals.MachineTypes Machine 
//        {
//            get { return EnumerationExtensions.GetEnum<Globals.Globals.MachineTypes>(Properties.GetProperty<string>("machine")); }
//            set { Properties.SetProperty("machine", value.GetName()); }
//        }
//    }
//}
