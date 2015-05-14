//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Entity.Entities;
//using Realm.Library.Common;
//using Realm.Library.Patterns.Command;
//using Realm.Server.Events;
//using Realm.Server.Item;
//using Realm.Server.NPC;
//using Realm.Server.Properties;
//using Realm.Server.Zones;
//using Realm.Server;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Commands
//// ReSharper restore CheckNamespace
//{
//    /// <summary>
//    /// Learn command
//    /// </summary>
//    public class PlayerSellCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the PlayerSellCommand class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerSellCommand(int id, string name, Definition definition) : base(id, name, definition)
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
//                CommandManager.ReportToCharacter(MessageResources.MSG_NOT_IN_SPACE, oUser, oShopkeeper);
//                return;
//            }

//            var keyword = oUser.GetLastCommand();
//            if (string.IsNullOrEmpty(keyword))
//            {
//                oShopkeeper.Say(character, oShopkeeper.GetMerchantText(Globals.Globals.MerchantStmtTypes.SellNoKeyword));
//                return;
//            }

//            //// is this item actually in your inventory?
//            var oItem = character.GetItemFromBackpack(keyword);
//            if (oItem.IsNull())
//            {
//                oShopkeeper.Say(character, oShopkeeper.GetMerchantText(Globals.Globals.MerchantStmtTypes.SellNoItem));
//                return;
//            }

//            // TODO: : Can the shopkeeper see you?
//            //if (!oShopkeeper.CanSee(oUser))
//            //{
//            //    CommandManager.Instance.Report(Globals.Globals.MessageScopeTypes.CHAR, "$N looks up briefly, but sees nothing, and goes back to work.", oUser, oShopkeeper, null, null, null);
//            //    return;
//            //}

//            if (!oShopkeeper.Shop.WillBuy(oItem))
//            {
//                oShopkeeper.Say(character, oShopkeeper.GetMerchantText(Globals.Globals.MerchantStmtTypes.SellNoInterest), oItem);
//                return;
//            }

//            var adjustedPrice = oShopkeeper.Shop.AppraiseItemForPurchase(oItem.Parent as ItemTemplate);

//            //// can the shopkeeper afford the item?
//            if (oShopkeeper.Value < adjustedPrice)
//            {
//                oShopkeeper.Say(character, oShopkeeper.GetMerchantText(Globals.Globals.MerchantStmtTypes.SellCannotAfford), oItem);
//                return;
//            }

//            //// move the money and adjust the new quantity
//            character.Value += adjustedPrice;
//            oShopkeeper.Value -= adjustedPrice;
//            character.Inventory.Contents.RemoveEntity(oItem);

//            CommandManager.ReportToCharacter("#sell_self#", oUser, oShopkeeper, oItem);
//            CommandManager.ReportToSpaceLimited("#sell_other#", oUser, oShopkeeper, oItem);
//            oShopkeeper.Say(character, oShopkeeper.GetMerchantText(Globals.Globals.MerchantStmtTypes.SellComplete));

//            var Space = character.Location as Space;
//            if (Space.IsNull()) return;

//            EventManager.ThrowEvent<OnSellItem>(oUser.Characters.Character, new EventTable
//                                                                                {
//                                                                                    {"Space", Space},
//                                                                                    {"item", oItem},
//                                                                                    {"shopkeeper", oShopkeeper}
//                                                                                });
//        }
//    }
//}
