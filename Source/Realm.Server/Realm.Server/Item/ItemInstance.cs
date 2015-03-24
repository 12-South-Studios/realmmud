//// ----------------------------------------------------------------------
//// <copyright file="ItemInstance.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
//// </copyright>
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using System.Collections.Generic;
//using System.Text;
//using Realm.Library.Common;
//using Realm.Server.NPC;
//using Realm.Server.Properties;

//namespace Realm.Server.Item
//{
//    public abstract class ItemInstance : GameEntityInstance, IItem
//    {
//        protected ItemInstance(long id, ItemTemplate parent)
//            : base(parent, id)
//        {
//        }

//        public string GetWearLocationName(int nbr)
//        {
//            var parent = Parent as ItemTemplate;
//            return parent.IsNotNull() ? parent.GetWearLocationName(nbr) : string.Empty;
//        }

//        public Globals.Globals.WearLocations GetWearLocation(int nbr)
//        {
//            var parent = Parent as ItemTemplate;
//            return parent.IsNotNull() ? parent.GetWearLocation(nbr) : Globals.Globals.WearLocations.wearbody;
//        }

//        #region GameEntityInstance
//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();

//            var parent = Parent as ItemTemplate;
//            if (parent.IsNull()) return;
//            Flags.FlagList = parent.GetFlagList();

//            var flag = (Flag)DataManager.Get("Flags", "instance");
//            if (flag.IsNull())
//            {
//                Log.ErrorFormat(ErrorResources.ERR_FLAG_NOT_FOUND, "instance");
//                return;
//            }
//            Flags.SetFlag(flag.Abbrev);
//        }

//        new public string Name { get { return Parent.IsNotNull() ? Parent.Name : string.Empty; } }
//        override public string Description { get { return Parent.IsNotNull() ? Parent.Description : string.Empty; } }
//        override public string LongName { get { return Parent.IsNotNull() ? Parent.LongName : string.Empty; } }
//        override public int Value { get { return Parent.IsNotNull() ? Parent.Value : 0; } }
//        override public Globals.Globals.SizeTypes Size { get { return Parent.IsNotNull() ? Parent.Size : Globals.Globals.SizeTypes.Small; } }
//        #endregion

//        #region IItem
//        int IItem.MaxStackSize { get; set; }
//        int IItem.Weight { get; set; }
//        Globals.Globals.MaterialTypes IItem.Material { get; set; }
//        Globals.Globals.ItemTypes IItem.ItemType { get; set; }

//        public int Weight
//        {
//            get
//            {
//                var parent = Parent as ItemTemplate;
//                return parent.IsNull() ? 0 : parent.Weight;
//            }
//        }

//        public int Volume
//        {
//            get
//            {
//                var parent = Parent as ItemTemplate;
//                return parent.IsNull() ? 0 : parent.Volume;
//            }
//        }

//        public IEnumerable<Globals.Globals.WearLocations> WearLocations
//        {
//            get
//            {
//                var parent = Parent as ItemTemplate;
//                return parent.IsNull() ? new List<Globals.Globals.WearLocations>() : parent.WearLocations;
//            }
//        }

//        public int ZoneLimit
//        {
//            get
//            {
//                var parent = Parent as ItemTemplate;
//                return parent.IsNull() ? 1 : parent.ZoneLimit;
//            }
//            set
//            {
//                // disallow
//            }
//        }

//        public int GlobalLimit
//        {
//            get
//            {
//                var parent = Parent as ItemTemplate;
//                return parent.IsNull() ? 1 : parent.GlobalLimit;
//            }
//            set
//            {
//                // disallow
//            }
//        }

//        public Globals.Globals.MaterialTypes Material
//        {
//            get
//            {
//                var parent = Parent as ItemTemplate;
//                return parent.IsNull() ? Globals.Globals.MaterialTypes.Organic : parent.Material;
//            }
//        }

//        public Globals.Globals.ItemTypes ItemType
//        {
//            get
//            {
//                var parent = Parent as ItemTemplate;
//                return parent.IsNull() ? Globals.Globals.ItemTypes.Simple : parent.ItemType;
//            }
//        }

//        public int StackSize
//        {
//            get
//            {
//                return GetIntProperty("stack quantity");
//            }
//            set
//            {
//                Properties.SetProperty("stack quantity", value);
//                if (StackSize < 0)
//                    Properties.SetProperty("stack quantity", 0);
//            }
//        }

//        public int MaxStackSize
//        {
//            get
//            {
//                var parent = Parent as ItemTemplate;
//                return parent.IsNull() ? 1 : parent.MaxStackSize;
//            }
//        }

//        public bool IsTakeable
//        {
//            get
//            {
//                var parent = Parent as ItemTemplate;
//                return parent.IsNotNull() && parent.IsTakeable;
//            }
//        }

//        public bool IsStackable
//        {
//            get
//            {
//                var parent = Parent as ItemTemplate;
//                return parent.IsNotNull() && parent.IsStackable;
//            }
//        }

//        public bool IsTradeable
//        {
//            get
//            {
//                var parent = Parent as ItemTemplate;
//                return parent.IsNotNull() && parent.IsTradeable;
//            }
//        }

//        public bool IsRepairable
//        {
//            get
//            {
//                var parent = Parent as ItemTemplate;
//                return parent.IsNotNull() && parent.IsRepairable;
//            }
//        }

//        public bool IsWearable
//        {
//            get
//            {
//                var parent = Parent as ItemTemplate;
//                return parent.IsNotNull() && parent.IsWearable;
//            }
//        }

//        public IEnumerable<Globals.Globals.Statistics> StatMods
//        {
//            get
//            {
//                var parent = Parent as ItemTemplate;
//                return parent.IsNotNull() ? parent.StatMods : new List<Globals.Globals.Statistics>();
//            }
//        }
//        public bool CanBeWorn(IBiota biota)
//        {
//            var parent = Parent as ItemTemplate;
//            return parent.IsNotNull() && parent.CanBeWorn(biota);
//        }

//        public bool IsType(string type)
//        {
//            var parent = Parent as ItemTemplate;
//            return parent.IsNotNull() && parent.IsType(type);
//        }

//        public int GetStatMod(Globals.Globals.Statistics stat)
//        {
//            var parent = Parent as ItemTemplate;
//            return parent.IsNotNull() ? parent.GetStatMod(stat) : 0;
//        }
//        #endregion

//        #region IHandler
//        /// <summary>
//        /// Returns the property by the given name on the ItemInstance, 
//        /// or if it doesn't exist it returns the property from the 
//        /// ItemTemplate Parent.
//        /// </summary>
//        public override object GetProperty(string aName)
//        {
//            var prop = base.GetProperty(aName);
//            if (prop.IsNotNull()) return prop;
//            return Parent.IsNotNull() ? Parent.Properties.GetProperty<object>(aName) : null;
//        }

//        public override string GetStringProperty(string aName)
//        {
//            var prop = base.GetProperty(aName);
//            if (prop.IsNotNull()) return prop.ToString();
//            return Parent.IsNotNull() ? Parent.Properties.GetProperty<string>(aName) : string.Empty;
//        }

//        public override int GetIntProperty(string aName)
//        {
//            var prop = base.GetProperty(aName);
//            if (prop.IsNotNull()) return 0;
//            return Parent.IsNotNull() ? Parent.Properties.GetProperty<int>(aName) : 0;
//        }

//        public override long GetLongProperty(string name)
//        {
//            var prop = base.GetProperty(name);
//            if (prop.IsNotNull()) return 0;
//            return Parent.IsNotNull() ? Parent.Properties.GetProperty<long>(name) : 0;
//        }
//        #endregion

//        #region ISaveable
//        public override string Save(bool toggle = false)
//        {
//            var sb = new StringBuilder();
//            if (toggle)
//                sb.AppendFormat("id = char.this:equipItem({0});    --{1}", Parent.ID, Parent.Name);
//            else
//                sb.AppendFormat("id = char.this:holdItem({0}, {1});    --{2}", Parent.ID, StackSize, Parent.Name);
//            return sb.ToString();
//        }
//        #endregion
//    }
//}
