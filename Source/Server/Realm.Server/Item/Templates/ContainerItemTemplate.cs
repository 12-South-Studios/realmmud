//// ----------------------------------------------------------------------
//// <copyright file="ContainerItemTemplate.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
//// </copyright>
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
//    public class ContainerItemTemplate : ItemTemplate
//    {
//        public ContainerItemTemplate(long id, string name)
//            : base(id, name)
//        {
//        }

//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            var flag = (Flag) DataManager.Get("flags", "container");
//            if (flag.IsNull()) return;
//            Flags.SetFlag(flag.Abbrev);
//            ItemType = EnumerationExtensions.GetEnum<Globals.Globals.ItemTypes>("container");

//            VolumeLimit = 1;
//            WeightLimit = 1;
//            MouthSize = Globals.Globals.SizeTypes.Small;
//            Contents = new List<long>();
//        }

//        public override void Clone(IGameEntity source)
//        {
//            base.Clone(source);

//            var container = source as ContainerItemTemplate;
//            if (container.IsNull()) return;

//            Contents = new List<long>();
//            foreach(var item in Contents)
//                Contents.Add(item);
//        }

//        public new IList<long> Contents { get; private set; }

//        public bool IsCloseable 
//        { 
//            get { return Bits.HasBit(Globals.Globals.ItemBits.IsCloseable); }
//        }

//        public int VolumeLimit 
//        { 
//            get { return Properties.GetProperty<int>("volume_limit"); }
//            set { Properties.SetProperty("volume_limit", value); }
//        }

//        public int WeightLimit 
//        {
//            get { return Properties.GetProperty<int>("weight_limit"); }
//            set { Properties.SetProperty("weight_limit", value); }
//        }

//        public Globals.Globals.SizeTypes MouthSize 
//        {
//            get { return EnumerationExtensions.GetEnum<Globals.Globals.SizeTypes>(Properties.GetProperty<string>("mouth_size")); }
//            set { Properties.SetProperty("mouth_size", value.GetName()); }
//        }
//    }
//}
