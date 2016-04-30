//// ----------------------------------------------------------------------
//// <copyright file="ShopTemplate.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
//// </copyright>
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Realm.Library.Common;
//using Realm.Server.Item;

//
//namespace Realm.Server.NPC
//
//{
//    public class ShopTemplate : GameEntityTemplate
//    {
//        // TODO: : Race restrictions
//        // TODO: : Class restrictions

//        public ShopTemplate(long id, string name)
//            : base(id, name, null)
//        {
//        }

//        public IList<SaleItem> Sales { get; private set; }
//        public IList<Globals.Globals.ItemTypes> BuyTypes { get; private set; }

//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            var flag = (Flag) DataManager.Get("Flags", "shop");
//            if (flag.IsNull())
//            {
//                Log.ErrorFormat("Unable to assign Flag[Shop] to ShopTemplate[{0}, {1}]", ID, Name);
//                return;
//            }
//            Flags.SetFlag(flag.Abbrev);
//            BuyMarkup = 100.0f;
//            SellMarkup = 100.0f;
//            Sales = new List<SaleItem>();
//            BuyTypes = new List<Globals.Globals.ItemTypes>();
//        }

//        public float BuyMarkup
//        {
//            get
//            {
//                var prop = Properties.GetProperty<object>("buy_markup");
//                return prop.IsNull() ? 0.0f : Convert.ToSingle(prop);
//            }
//            set { Properties.SetProperty("buy_markup", value < 1.0f ? 1.0f : value); }
//        }

//        public Single SellMarkup
//        {
//            get
//            {
//                var prop = Properties.GetProperty<object>("sell_markup");
//                return prop.IsNull() ? 0.0f : Convert.ToSingle(prop);
//            }
//            set { Properties.SetProperty("sell_markup", value < 1.0f ? 1.0f : value); }
//        }

//        public bool IsForSale(long itemId)
//        {
//            return (from item in Sales where item.SaleItemId == itemId select item.QuantityInStock > 0).FirstOrDefault();
//        }

//        public bool IsForSale(string itemName)
//        {
//            return (from item in Sales let template = EntityManager.LuaGetTemplate(item.SaleItemId) 
//                    where template.CompareName(itemName) select item.QuantityInStock > 0).FirstOrDefault();
//        }

//        public ItemTemplate GetItemForSale(string itemName)
//        {
//            foreach (var item in Sales)
//            {
//                var template = EntityManager.LuaGetTemplate(item.SaleItemId);
//                if (template.CompareName(itemName))
//                    return item.QuantityInStock > 0 ? template as ItemTemplate : null;
//            }
//            return null;
//        }

//        public void AddSaleItem(long itemId, int quantity)
//        {
//            var entity = EntityManager.LuaGetTemplate(itemId);
//            if (entity.IsNull()) return;
//            var item = entity as ItemTemplate;
//            if (item.IsNull()) return;
//            if (IsForSale(itemId)) return;

//            var si = new SaleItem(item.ID, quantity);
//            Sales.Add(si);
//            Log.InfoFormat("Item[{0}, {1}] added with a quantity of {2} to Shop[{3}]",
//                item.ID, item.Name, quantity, ID);
//        }

//        public void AddSaleItem(string itemName, int quantity)
//        {
//            var entity = EntityManager.LuaGetTemplate(itemName);
//            if (entity.IsNull()) return;
//            var item = entity as ItemTemplate;
//            if (item.IsNull()) return;
//            if (IsForSale(item.ID)) return;

//            var si = new SaleItem(item.ID, quantity);
//            Sales.Add(si);
//            Log.InfoFormat("Item[{0}, {1}] added with a quantity of {2} to Shop[{3}]", 
//                item.ID, item.Name, quantity, ID);
//        }

//        public void AddBuyType(string itemType)
//        {
//            //var it = (ItemType)DataManager.Get("ItemTypes", itemType);
//            var it = EnumerationExtensions.GetEnum<Globals.Globals.ItemTypes>(itemType);
//            if (BuyTypes.Contains(it)) return;
//            BuyTypes.Add(it);
//            Log.InfoFormat("ItemType[{0}] added to Buy List for Shop[{1}]", it.GetName(), ID);
//        }
//    }
//}
