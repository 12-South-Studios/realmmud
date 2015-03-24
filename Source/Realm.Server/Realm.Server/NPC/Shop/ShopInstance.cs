//// ----------------------------------------------------------------------
//// <copyright file="ShopInstance.cs" company="12-South Studios">
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
//using Realm.Server.Events;
//using Realm.Server.Item;
//using Realm.Server.Properties;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.NPC
//// ReSharper restore CheckNamespace
//{
//    public class ShopInstance : GameEntityInstance
//    {
//        public ShopInstance(long id, ShopTemplate parent, MobInstance owner)
//            : base(parent, id)
//        {
//            var flag = DataManager.GetFlag("shop");
//            Flags.SetFlag(flag.Abbrev);

//            Sales = new List<SaleItem>(parent.Sales);
//            Owner = owner;
//            EventManager.RegisterListener(this, Game, typeof(OnGameRevolution), Instance_OnGameRevolution);
//        }


//        public MobInstance Owner { get; private set; }
//        public IList<SaleItem> Sales { get; private set; }

//        public float BuyMarkup
//        {
//            get
//            {
//                var parent = Parent as ShopTemplate;
//                return parent.IsNull() ? 100.0f : parent.BuyMarkup;
//            }
//        }

//        public float SellMarkup
//        {
//            get
//            {
//                var parent = Parent as ShopTemplate;
//                return parent.IsNull() ? 100.0f : parent.SellMarkup;
//            }
//        }

//        public int AppraiseItemForSale(IGameEntity item)
//        {
//            var adjValue = item.Value * (SellMarkup / 100);
//            return (int)(Math.Round(adjValue));
//        }

//        public int AppraiseItemForPurchase(IGameEntity item)
//        {
//            var adjValue = item.Value * (BuyMarkup / 100);
//            return (int)(Math.Round(adjValue));
//        }

//        public bool WillBuy(ItemInstance item)
//        {
//            var parent = Parent as ShopTemplate;
//            return parent.IsNotNull() && parent.BuyTypes.Any(type => type == item.ItemType);
//        }

//        public bool SellItem(long itemId)
//        {
//            var parent = Parent as ShopTemplate;
//            if (parent.IsNull()) return false;
//            if (!parent.IsForSale(itemId)) return false;
//            foreach (var item in Sales.Where(item => item.SaleItemId == itemId))
//            {
//                item.QuantityInStock--;
//                return true;
//            }
//            return false;
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

//        /*public void OnMobReplenishStock(MUDEventArgs aArgs)
//        {
//            if (Owner.IsAsleep)
//            {
//                return;
//            }

//            foreach (SaleItem item in _saleItems)
//            {
//                item.QuantityInStock = item.ReplenishQuantity;
//            }

//            ShopkeeperMobInstance shopkeep = Owner as ShopkeeperMobInstance;
//            CommandManager.Instance.Report(Globals.Globals.MessageScopeTypes.Space, shopkeep.GetMerchantText(MerchantStatementType.Restock), Owner);

//            LogSystem("onMobReplenishStock", "Mob[" + Owner.GetName() + "]");
//        }*/

//        #region Events
//        void Instance_OnGameRevolution(RealmEventArgs e)
//        {
//            //if (Owner.AiBrain.IsAsleep) return;
//            foreach (var item in Sales)
//                item.QuantityInStock = item.ReplenishQuantity;

//            var shopkeep = Owner as VendorNpcInstance;
//            if (shopkeep.IsNull()) return;
//            CommandManager.Report(Globals.Globals.MessageScopeTypes.Space,
//                shopkeep.GetMerchantText(Globals.Globals.MerchantStmtTypes.Restock), Owner);

//            EventManager.ThrowEvent<OnShopReplenish>(shopkeep, new EventTable
//                                                                   {
//                                                                       { "Space", shopkeep.Location }
//                                                                   });
//        }
//        #endregion
//    }
//}
