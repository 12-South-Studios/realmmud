//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Entity.Entities;
//using Realm.Library.Common;
//using Realm.Library.Patterns.Command;
//using Realm.Server.Events;
//using Realm.Server.Factories;
//using Realm.Server.Item;
//using Realm.Server.NPC;
//using Realm.Server.Zones;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Commands
//// ReSharper restore CheckNamespace
//{
//    /// <summary>
//    /// Learn command
//    /// </summary>
//    public class PlayerBuyCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the PlayerBuyCommand class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerBuyCommand(int id, string name, Definition definition) : base(id, name, definition)
//        {
//            //// do nothing
//        }

//        /// <summary>
//        /// Executes the command
//        /// </summary>
//        public override void Execute()
//        {
//            var oUser = Game.CurrentUser();
//            if (oUser.IsNull()) return;

//            //// has the player greeted a shopkeeper?
//            var character = oUser.GetCurrentCharacter();
//            if (character.GreetedShop.IsNull())
//            {
//                CommandManager.ReportToCharacter("#must_greet#", oUser);
//                return;
//            }

//            var oShopkeeper = character.GreetedShop as VendorNpcInstance;
//            if (oShopkeeper.IsNull()) return;

//            //// Is the shopkeeper in the same Space as the player?
//            if (character.Location != oShopkeeper.Location)
//            {
//                CommandManager.ReportToCharacter("#not_in_Space#", oUser, oShopkeeper);
//                return;
//            }

//            var keyword = oUser.GetLastCommand();
//            if (string.IsNullOrEmpty(keyword))
//            {
//                oShopkeeper.Say(character, oShopkeeper.GetMerchantText(Globals.Globals.MerchantStmtTypes.BuyNoKeyword));
//                return;
//            }

//            // TODO: : Can the shopkeeper see you?
//            //if (!oShopkeeper.CanSee(oUser))
//            //{
//            //    CommandManager.Instance.Report(Globals.Globals.MessageScopeTypes.CHAR, "$N looks up briefly, but sees nothing, and goes back to work.", oUser, oShopkeeper, null, null, null);
//            //    return;
//            //}

//            //// does the shopkeeper have this item for sale?
//            var oItem = oShopkeeper.Shop.GetItemForSale(keyword);
//            if (oItem.IsNull())
//            {
//                oShopkeeper.Say(character, oShopkeeper.GetMerchantText(Globals.Globals.MerchantStmtTypes.BuyNoItem));
//                return;
//            }

//            //// can the player afford the item?
//            var adjustedPrice = oShopkeeper.Shop.AppraiseItemForPurchase(oItem);
//            if (character.Value < adjustedPrice)
//            {
//                oShopkeeper.Say(character, oShopkeeper.GetMerchantText(Globals.Globals.MerchantStmtTypes.BuyCannotAfford), oItem);
//                return;
//            }

//            //// move the money and adjust the new quantity
//            character.Value -= adjustedPrice;
//            oShopkeeper.Value += adjustedPrice;
//            oShopkeeper.Shop.SellItem(oItem.ID);

//            //// Create the new item
//            var factory = new GameItemFactory();
//            var newItem = factory.CreateInstance(string.Empty, oItem) as ItemInstance;

//            Game.SetManagerReferences(newItem);
//            character.HoldItem(newItem);

//            CommandManager.ReportToCharacter("#buy_self#", oUser, oShopkeeper, newItem);
//            CommandManager.ReportToSpaceLimited("#buy_other#", oUser, oShopkeeper, newItem);
//            oShopkeeper.Say(character, oShopkeeper.GetMerchantText(Globals.Globals.MerchantStmtTypes.BuyComplete));

//            var Space = oUser.Characters.Character.Location as Space;
//            if (Space.IsNull()) return;

//            EventManager.ThrowEvent<OnBuyItem>(oUser.Characters.Character, new EventTable
//                                                                               {
//                                                                                   {"Space", Space},
//                                                                                   {"item", newItem},
//                                                                                   {"shopkeeper", oShopkeeper}
//                                                                               });
//        }
//    }
//}
