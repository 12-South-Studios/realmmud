//// ----------------------------------------------------------------------
//// <copyright file="MobTemplate.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
//// </copyright>
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using System.Collections.Generic;
//using Realm.Library.Common;
//using Realm.Server.Ai;
//using Realm.Server.Item;
//using Realm.Server.Properties;

//namespace Realm.Server.NPC
//{
//    public abstract class MobTemplate : GameEntityTemplate
//    {
//        protected MobTemplate(long id, string name)
//            : base(id, name, null)
//        {
//        }

//        #region GameEntity
//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            var flag = (Flag)DataManager.Get("Flags", "mob");
//            if (flag.IsNull())
//            {
//                Log.ErrorFormat(ErrorResources.ERR_FLAG_NOT_FOUND, "mob");
//                return;
//            }
//            Flags.SetFlag(flag.Abbrev);

//            ItemsToEquip = new List<string>();
//            ItemsInInventory = new List<string>();
//        }
//        #endregion

//        #region ICloneable
//        public override void Clone(IGameEntity source)
//        {
//            var mob = source as MobTemplate;
//            if (mob.IsNull()) return;

//            base.Clone(source);
//            Flags.FlagList = source.GetFlagList();
//            ItemsToEquip = new List<string>(mob.ItemsToEquip);
//            ItemsInInventory = new List<string>(mob.ItemsInInventory);
//            ChatTree = mob.ChatTree;
//            Behavior = mob.Behavior;

//            foreach (var key in source.Properties.PropertyKeys)
//                Properties.SetProperty(key, source.Properties.GetProperty<object>(key));
//        }
//        #endregion

//        public ConversationTree ChatTree { get; private set; }
//        public Behavior Behavior
//        {
//            get { return (Behavior)DataManager.Get("behaviors", Properties.GetProperty<long>("behavior_id")); }
//            set { Properties.SetProperty("behavior_id", value.ID); }
//        }
//        public IList<string> ItemsToEquip { get; private set; }
//        public IList<string> ItemsInInventory { get; private set; }

//        public Globals.Globals.MonsterClassTypes MonsterClass
//        {
//            get { return EnumerationExtensions.GetEnum<Globals.Globals.MonsterClassTypes>(Properties.GetProperty<string>("monster_class")); }
//            set { Properties.SetProperty("monster_class", EnumerationExtensions.GetValue(value)); }
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

//        public bool EquipItem(long id)
//        {
//            var entity = EntityManager.LuaGetTemplate(id);
//            if (entity.IsNull()) return false;
//            if (ItemsToEquip.Contains(entity.Name)) return false;
//            ItemsToEquip.Add(entity.Name);
//            return true;
//        }

//        public bool EquipItem(string name)
//        {
//            var entity = EntityManager.LuaGetTemplate(name);
//            if (entity.IsNull()) return false;
//            if (ItemsToEquip.Contains(entity.Name)) return false;
//            ItemsToEquip.Add(entity.Name);
//            return true;
//        }

//        public bool EquipItem(GameEntityTemplate entity)
//        {
//            if (entity.IsNull()) return false;
//            if (ItemsToEquip.Contains(entity.Name)) return false;
//            ItemsToEquip.Add(entity.Name);
//            return true;
//        }

//        public bool EquipItem(ItemTemplate entity)
//        {
//            if (entity.IsNull()) return false;
//            if (ItemsToEquip.Contains(entity.Name)) return false;
//            ItemsToEquip.Add(entity.Name);
//            return true;
//        }

//        public bool HoldItem(long id)
//        {
//            var entity = EntityManager.LuaGetTemplate(id);
//            if (entity.IsNull()) return false;
//            if (ItemsInInventory.Contains(entity.Name)) return false;
//            ItemsInInventory.Add(entity.Name);
//            return true;
//        }

//        public bool HoldItem(string name)
//        {
//            var entity = EntityManager.LuaGetTemplate(name);
//            if (entity.IsNull()) return false;
//            if (ItemsInInventory.Contains(entity.Name)) return false;
//            ItemsInInventory.Add(name);
//            return true;
//        }

//        public bool HoldItem(GameEntityTemplate entity)
//        {
//            if (entity.IsNull()) return false;
//            if (ItemsInInventory.Contains(entity.Name)) return false;
//            ItemsInInventory.Add(entity.Name);
//            return true;
//        }

//        public bool HoldItem(ItemTemplate entity)
//        {
//            if (entity.IsNull()) return false;
//            if (ItemsInInventory.Contains(entity.Name)) return false;
//            ItemsInInventory.Add(entity.Name);
//            return true;
//        }

//        public void ClearEquippedItems()
//        {
//            ItemsToEquip.Clear();
//        }

//        public void ClearHeldItems()
//        {
//            ItemsInInventory.Clear();
//        }

//        public void ClearAllItems()
//        {
//            ClearEquippedItems();
//            ClearHeldItems();
//        }

//        public void AddChatTree(long id)
//        {
//#if TRACE
//            Log.InfoFormat("Mob[{0}, {1}] => ChatTree[{2}]", ID, Name, id);
//#endif

//            var tree = (ConversationTree)DataManager.Get("conversations", id);
//            if (tree.IsNotNull())
//                ChatTree = tree;
//        }

//        public virtual void AddShop(long id)
//        {
//            // This is overridden in the derived class
//            // It is only present here for Lua
//        }

//        public virtual void SetBehavior(long id)
//        {
//#if TRACE
//            Log.InfoFormat("Mob[{0}, {1}] => Behavior[{2}]", ID, Name, id);
//#endif
//            var behavior = (Behavior)DataManager.Get("behaviors", id);
//            if (behavior.IsNotNull())
//                Behavior = behavior;
//        }

//        public virtual void AddNode(long id, string state)
//        {
//            // This is overridden in the derived class
//            // It is only present here for Lua
//        }
//    }
//}
