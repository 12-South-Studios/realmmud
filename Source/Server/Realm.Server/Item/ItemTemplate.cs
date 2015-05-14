//// ----------------------------------------------------------------------
//// <copyright file="ItemTemplate.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
//// </copyright>
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using System;
//using System.Collections.Generic;
//using System.Data;
//using Realm.Library.Common;
//using Realm.Server.NPC;

//namespace Realm.Server.Item
//{
//    public abstract class ItemTemplate : GameEntityTemplate, IItem
//    {
//        private List<Globals.Globals.WearLocations> _wearLocations;
//        private Dictionary<Globals.Globals.Statistics, int> _statMods;

//        protected ItemTemplate(long id, string name)
//            : base(id, name, null)
//        {
//        }

//        #region GameEntityTemplate
//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            var flag = (Flag)DataManager.Get("flags", "item");
//            if (flag.IsNull())
//            {
//                Log.ErrorFormat("Unable to locate Flag[item] for Item[{0}, {1}]", ID, Name);
//                return;
//            }
//            Flags.SetFlag(flag.Abbrev);
//            MaxStackSize = 1;
//            _wearLocations = new List<Globals.Globals.WearLocations>();
//            _statMods = new Dictionary<Globals.Globals.Statistics, int>();
//        }
//        public int MaxStackSize
//        {
//            get { return Properties.GetProperty<int>("max_stack"); }
//            set { Properties.SetProperty("max_stack", value); }
//        }

//        public int Weight
//        {
//            get { return Properties.GetProperty<int>("weight"); }
//            set { Properties.SetProperty("weight", value); }
//        }

//        public Globals.Globals.MaterialTypes Material
//        {
//            get { return EnumerationExtensions.GetEnum<Globals.Globals.MaterialTypes>(Properties.GetProperty<string>("material")); }
//            set { Properties.SetProperty("material", value.GetName()); }
//        }

//        public Globals.Globals.ItemTypes ItemType
//        {
//            get { return EnumerationExtensions.GetEnum<Globals.Globals.ItemTypes>(Properties.GetProperty<string>("item_type")); }
//            set { Properties.SetProperty("item_type", value.GetName()); }
//        }

//        public bool IsTakeable
//        {
//            get { return Bits.HasBit(Globals.Globals.ItemBits.IsTakeable); }
//        }

//        public bool IsTradeable
//        {
//            get { return Bits.HasBit(Globals.Globals.ItemBits.IsTradeable); }
//        }

//        public bool IsRepairable
//        {
//            get { return Bits.HasBit(Globals.Globals.ItemBits.IsRepairable); }
//        }

//        public bool IsWearable
//        {
//            get { return null == _wearLocations || _wearLocations.Count > 0; }
//        }

//        public int Volume
//        {
//            get { return EnumerationExtensions.GetValue(Size); }
//        }

//        public IEnumerable<Globals.Globals.WearLocations> WearLocations
//        {
//            get { return _wearLocations; }
//        }

//        public bool IsStackable
//        {
//            get { return MaxStackSize > 1; }
//        }

//        public int ZoneLimit
//        {
//            get { return Properties.GetProperty<int>("zone_limit"); }
//            set { Properties.SetProperty("zone_limit", value); }
//        }

//        public int GlobalLimit
//        {
//            get { return Properties.GetProperty<int>("global_limit"); }
//            set { Properties.SetProperty("global_limit", value); }
//        }

//        public IEnumerable<Globals.Globals.Statistics> StatMods
//        {
//            get { return _statMods.Keys; }
//        }
//        public int GetStatMod(Globals.Globals.Statistics stat)
//        {
//            return _statMods.ContainsKey(stat) ? _statMods[stat] : 0;
//        }

//        public bool CanBeWorn(IBiota biota)
//        {
//            //// does the biota have an open slot for this item?
//            foreach (var loc in _wearLocations)
//            {
//                if (loc.GetName().IndexOf("both", StringComparison.Ordinal) > -1)
//                {
//                    //// first, just check the base name
//                    if (biota.Inventory.IsWearing(loc.GetName()))
//                        return false;

//                    //// then since its a two-handed item, check both left and right
//                    var subName = loc.GetName().Substring(0, loc.GetName().IndexOf("both", StringComparison.Ordinal) - 1);
//                    if (biota.Inventory.IsWearing(subName + "_left"))
//                        return false;
//                    if (biota.Inventory.IsWearing(subName + "_right"))
//                        return false;
//                }
//                else
//                {
//                    if (biota.Inventory.IsWearing(loc.GetName()))
//                        return false;
//                }
//            }
//            return true;
//        }

//        public bool IsType(string type)
//        {
//            return ItemType.GetName().Equals(type, StringComparison.OrdinalIgnoreCase);
//        }

//        #endregion

//        #region ICloneable
//        public override void Clone(IGameEntity source)
//        {
//            base.Clone(source);
//            var item = source as ItemTemplate;
//            if (item.IsNull()) return;

//            Bits.SetBits(item.Bits.GetBits);
//            Flags.FlagList = item.GetFlagList();

//            _wearLocations = new List<Globals.Globals.WearLocations>(item.WearLocations);
//            // TODO: : Add Entities?
//            //AddEntities(item.GetEntities(), true);

//            _statMods = new Dictionary<Globals.Globals.Statistics, int>();
//            foreach (var stat in item.StatMods)
//                _statMods.Add(stat, item.GetStatMod(stat));

//            foreach (var key in item.Properties.PropertyKeys)
//            {
//                var prop = item.Properties.GetProperty<object>(key);
//                Properties.SetProperty(key, prop);
//            }
//        }
//        #endregion


//        public void AddStatMod(Globals.Globals.Statistics stat, int value)
//        {
//            _statMods.Add(stat, value);
//        }


//        public string GetWearLocationName(int nbr)
//        {
//            if (_wearLocations.Count == 0 || nbr > _wearLocations.Count || nbr == 0)
//                return string.Empty;
//            return _wearLocations[nbr - 1].GetName();
//        }

//        public Globals.Globals.WearLocations GetWearLocation(int nbr)
//        {
//            if (_wearLocations.Count == 0 || nbr > _wearLocations.Count || nbr == 0)
//                throw new ObjectNotFoundException("Wear Location with index " + nbr + " not found");
//            return _wearLocations[nbr - 1];
//        }

//        public void AddWearLocation(string loc)
//        {
//            var wear = EnumerationExtensions.GetEnum<Globals.Globals.WearLocations>(loc);
//            if (_wearLocations.Contains(wear)) return;
//            _wearLocations.Add(wear);
//            Log.InfoFormat("Item[{0}, {1}] gained WearLocation[{2}]", ID, Name, loc);
//        }

//        public virtual void AddItemToContents(long id)
//        {
//            //// do nothing
//        }

//        public virtual void AddResource(long id, int qty)
//        {
//            //// do nothing
//        }

//        public virtual void AddResource(long resourceId, string toolType, int gatherAmt, int minSkill) 
//        {
//            //// do nothing
//        }
//    }
//}
