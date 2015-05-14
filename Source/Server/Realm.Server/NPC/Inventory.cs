//// -----------------------------------------------------------------------
//// <copyright file="EquipmentHandler.cs" company="">
//// //     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
//// -----------------------------------------------------------------------

//using System.Collections.Generic;
//using System.Linq;
//using Realm.Entity.Entities;
//using Realm.Library.Common;
//using Realm.Server.Contexts;
//using Realm.Server.Events;
//using Realm.Server.Factories;
//using Realm.Server.Item;
//using Realm.Server.Zones;

//namespace Realm.Server.NPC
//{
//    public class Inventory
//    {
//        public Inventory(Biota biote)
//        {
//            Parent = biote;
//            Equipment = new EquipmentRepository();
//            Contents = new ContentsHandler(biote);
//        }

//        public Biota Parent { get; private set; }

//        public EquipmentRepository Equipment { get; private set; }
//        public ContentsHandler Contents { get; private set; }

//        public bool IsNaked { get { return Equipment.Count == 0; } }

//        public bool IsWearing(string aWearLocation)
//        {
//            return Equipment.Keys.Any(wearLoc => wearLoc.CompareName(aWearLocation));
//        }

//        public bool IsWearing(GameEntityInstance aEntity)
//        {
//            return Equipment.Values.Any(item => item == aEntity);
//        }

//        public bool IsWearing(ItemTemplate aTemplate)
//        {
//            return Equipment.Values.Any(item => item.Parent == aTemplate);
//        }

//        /// <summary>
//        /// Equips an item using the Template ID.
//        /// Can only equip from inventory.
//        /// </summary>
//        public long EquipItem(long id)
//        {
//            var entity = EntityManager.Instance.LuaGetTemplate(id);
//            if (entity.IsNull())
//            {
//                Game.Instance.Logger.InfoFormat("ItemTemplate[{0}] not found.", id);
//                return 0;
//            }
//            return EquipItem(entity as ItemTemplate);
//        }

//        /// <summary>
//        /// Equips an item using the Template Name.
//        /// Can only equip from inventory.
//        /// </summary>
//        public long EquipItem(string name)
//        {
//            var entity = EntityManager.Instance.LuaGetTemplate(name);
//            if (entity.IsNull())
//            {
//                Game.Instance.Logger.InfoFormat("ItemTemplate[{0}] not found.", name);
//                return 0;
//            }
//            return EquipItem(entity as ItemTemplate);
//        }

//        /// <summary>
//        /// Equips the item instance.
//        /// Can only equip from inventory.
//        /// </summary>
//        public long EquipItem(ItemInstance item)
//        {
//            if (item.IsNull()) return 0;
//            if (!item.CanBeWorn(Parent)) return 0;
//            if (Contents.Contains(item))
//                Contents.RemoveEntity(item);
//            Equipment.Add(item.GetWearLocation(1), item);
//            item.Location = Parent;

//            EventManager.Instance.ThrowEvent(Parent, new OnEquipItem("OnEquipItem"),
//                new EventTable {{"item", item}, {"wear_location", item.GetWearLocation(1)}});
//            return item.ID;
//        }

//        /// <summary>
//        /// Equips the item using the Template.
//        /// Can only equip from inventory.
//        /// </summary>
//        public long EquipItem(ItemTemplate template)
//        {
//            if (template.IsNull()) return 0;

//            var factory = new GameItemFactory();
//            var item = factory.CreateInstance(string.Empty, template) as ItemInstance;
//            if (item.IsNull())
//            {
//                Game.Instance.Logger.ErrorFormat("Failed to generate instance from Template[{0}]", template.ID);
//                return 0;
//            }

//            Game.Instance.SetManagerReferences(item);
//            return EquipItem(item);
//        }

//        public ItemInstance GetEquippedItem(string wearLocation)
//        {
//            var wearLoc = EnumerationExtensions.GetEnum<Globals.Globals.WearLocations>(wearLocation);
//            return Equipment.Contains(wearLoc) ? Equipment.Get(wearLoc) : null;
//        }

//        public IList<ItemInstance> GetItemFromBackpack(ItemTemplate template)
//        {
//            return Contents.Entities.Cast<ItemInstance>().Where(instance => instance.Parent == template).ToList();
//        }

//        public ItemInstance GetItemFromBackpack(long id)
//        {
//            return Contents.Contains(id) ? (ItemInstance) Contents.GetEntity(id) : null;
//        }

//        public ItemInstance GetItemFromBackpack(string name)
//        {
//            return Contents.Contains(name) ? (ItemInstance) Contents.GetEntity(name) : null;
//        }

//        /// <summary>
//        /// Holds the item using the Template Id.
//        /// Can only hold an item from the ground.
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        public long HoldItem(long id)
//        {
//            var entity = EntityManager.Instance.LuaGetTemplate(id);
//            if (entity.IsNull())
//            {
//                Game.Instance.Logger.ErrorFormat("ItemTemplate[{0}] not found.", id);
//                return 0;
//            }
//            return HoldItem(entity as ItemTemplate, 1);
//        }

//        /// <summary>
//        /// Holds the item using the Template ID with a given quantity.
//        /// Can only hold an item from the ground.
//        /// </summary>
//        public long HoldItem(long id, int quantity)
//        {
//            var entity = EntityManager.Instance.LuaGetTemplate(id);
//            if (entity.IsNull())
//            {
//                Game.Instance.Logger.ErrorFormat("ItemTemplate[{0}] not found.", id);
//                return 0;
//            }
//            return HoldItem(entity as ItemTemplate, quantity);
//        }

//        /// <summary>
//        /// Holds the item using the Template Name.
//        /// Can only hold an item from the ground.
//        /// </summary>
//        public long HoldItem(string name)
//        {
//            var entity = EntityManager.Instance.LuaGetTemplate(name);
//            if (entity.IsNull())
//            {
//                Game.Instance.Logger.ErrorFormat("ItemTemplate[{0}] not found.", name);
//                return 0;
//            }
//            return HoldItem(entity as ItemTemplate, 1);
//        }

//        /// <summary>
//        /// Holds the item using the Teplate Name with the given quantity.
//        /// Can only hold an item from the ground.
//        /// </summary>
//        public long HoldItem(string name, int quantity)
//        {
//            var entity = EntityManager.Instance.LuaGetTemplate(name);
//            if (entity.IsNull())
//            {
//                Game.Instance.Logger.ErrorFormat("ItemTemplate[{0}] not found.", name);
//                return 0;
//            }
//            return HoldItem(entity as ItemTemplate, quantity);
//        }

//        /// <summary>
//        /// Holds the item using the item instance.
//        /// Can hold an item from ground OR equipment.
//        /// </summary>
//        public long HoldItem(ItemInstance item)
//        {
//            if (item.IsNull()) return 0;
//            if (item.Location is Space)
//            {
//                var Space = item.Location as Space;
//                Space.Contents.RemoveEntity(item);
//            }
//            else if (item.Location is Biota)
//            {
//                var biote = item.Location as Biota;
//                biote.Inventory.Contents.RemoveEntity(item);
//            }
//            else
//            {
//                Game.Instance.Logger.ErrorFormat("Item[{0}, {1}] location is invalid.", item.ID, item.Name);
//                return 0;
//            }

//            //// is there an item with the same parent already there?
//            if (Contents.Contains(item.Parent))
//            {
//                var entity = Contents.GetEntity(item.Parent);
//                if (entity.IsNotNull())
//                {
//                    var existingItem = entity as ItemInstance;
//                    if (existingItem.IsNull()) return 0;
//                    if (existingItem.IsStackable)
//                    {
//                        existingItem.StackSize += item.StackSize;
//                        return 0;
//                    }
//                }
//            }
//            else
//            {
//                Contents.AddEntity(item);
//            }

//            EventManager.Instance.ThrowEvent(Parent, new OnTakeItem("OnTakeItem"), 
//                new EventTable { { "item", item }, { "Space", Parent.Location} });
//            return item.ID;
//        }

//        /// <summary>
//        /// Holds the item using the item Template.
//        /// Can only hold an item from the ground.
//        /// </summary>
//        public long HoldItem(ItemTemplate template)
//        {
//            return HoldItem(template, 1);
//        }

//        /// <summary>
//        /// Holds the item using the item Template and given quantity.
//        /// Can only hold an item from the ground.
//        /// </summary>
//        public long HoldItem(ItemTemplate template, int quantity)
//        {
//            if (template.IsNull()) return 0;

//            var factory = new GameItemFactory();
//            var entity = factory.CreateInstance(string.Empty, template) as ItemInstance;
//            if (entity.IsNull())
//            {
//                Game.Instance.Logger.ErrorFormat("Failed to generate Instance from Template[{0}]", template.ID);
//                return 0;
//            }

//            Game.Instance.SetManagerReferences(entity);
//            entity.StackSize = quantity;
//            return HoldItem(entity);
//        }

//        /// <summary>
//        /// Unequips an item using the Template Id.
//        /// Can only unequip items from equipment.
//        /// </summary>
//        public long UnequipItem(long id)
//        {
//            var entity = EntityManager.Instance.LuaGetInstance(id);
//            if (entity.IsNull()) return 0;

//            var item = entity as ItemInstance;
//            if (item.IsNull()) return 0;
//            if (!IsWearing(item)) return 0;

//            Equipment.Delete(item.GetWearLocation(1));
//            return HoldItem(item);
//        }

//        public long UnequipItem(ItemInstance aItem)
//        {
//            if (!IsWearing(aItem)) return 0;
//            Equipment.Delete(aItem.GetWearLocation(1));

//            EventManager.Instance.ThrowEvent(Parent, new OnUnequipItem("OnUnequipItem"), new EventTable { { "item", aItem } });
//            return HoldItem(aItem);
//        }

//        /// <summary>
//        /// Drops an item using the instance.
//        /// Can only drop items from inventory.
//        /// </summary>
//        public bool DropItem(ItemInstance aItem)
//        {
//            if (!Contents.Contains(aItem)) return false;
//            if (aItem.Location is Biota)
//            {
//                var biote = aItem.Location as Biota;
//                if (biote.Location is Space)
//                {
//                    var Space = biote.Location as Space;
//                    Space.Contents.AddEntity(aItem);
//                }

//            }
//            Contents.RemoveEntity(aItem);

//            EventManager.Instance.ThrowEvent(Parent, new OnDropItem("OnDropItem"), 
//                new EventTable { { "item", aItem }, {"Space", Parent.Location}});
//            return true;
//        }

//        public bool Contains(ItemInstance aEntity)
//        {
//            return Contents.Contains(aEntity) || Equipment.Values.Any(instance => instance == aEntity);
//        }

//        public bool Contains(long aId)
//        {
//            return Contents.Entities.OfType<ItemInstance>().Any(item => item.Parent.ID == aId)
//                || Equipment.Values.Any(item => item.Parent.ID == aId);
//        }

//        public bool Contains(string aName)
//        {
//            return Contents.Entities.Any(instance => instance.CompareName(aName))
//                || Equipment.Values.Any(instance => instance.CompareName(aName));
//        }

//        public bool Contains(ItemTemplate aTemplate)
//        {
//            return Contents.Entities.OfType<ItemInstance>().Any(item => item.Parent == aTemplate)
//                || Equipment.Values.Any(instance => instance.Parent == aTemplate);
//        }

//        public IList<ItemInstance> GetItems(Globals.Globals.ItemTypes aType)
//        {
//            return Items.Where(x => x.ItemType == aType).ToList();
//        }

//        public IList<ItemInstance> Items
//        {
//            get
//            {
//                var list = new List<ItemInstance>();
//                list.AddRange(Contents.Entities.OfType<ItemInstance>());
//                list.AddRange(Equipment.Values);
//                return list;
//            }
//        }
//    }
//}
