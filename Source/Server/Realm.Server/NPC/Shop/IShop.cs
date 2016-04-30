//using System;
//using System.Collections.Generic;
//using Realm.Server.Item;

//
//namespace Realm.Server.NPC
//
//{
//    public interface IShop
//    {
//        MobInstance Owner { get; }
//        IList<SaleItem> Sales { get; }
//        IList<Globals.Globals.ItemTypes> BuyTypes { get; }
//        float BuyMarkup { get; set; }
//        Single SellMarkup { get; set; }
//        bool IsForSale(long itemId);
//        bool IsForSale(string itemName);
//        ItemTemplate GetItemForSale(string itemName);

//        void AddSaleItem(long itemId, int quantity);
//        void AddSaleItem(string itemName, int quantity);
//        void AddBuyType(string itemType);

//        int AppraiseItemForSale(IGameEntity item);
//        int AppraiseItemForPurchase(IGameEntity item);
//        bool WillBuy(ItemInstance item);
//        bool SellItem(long itemId);
//    }
//}
