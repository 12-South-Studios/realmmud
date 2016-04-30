//using System.Text;
//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Library.Common;
//using Realm.Library.Patterns.Command;
//using Realm.Server.Item;
//using Realm.Server.NPC;

//
//namespace Realm.Server.Commands
//
//{
//    /// <summary>
//    /// Learn command
//    /// </summary>
//    public class PlayerAppraiseCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the PlayerAppraiseCommand class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerAppraiseCommand(int id, string name, Definition definition) : base(id, name, definition)
//        {
//            //// do nothing
//        }

//        /// <summary>
//        /// Executes the command
//        /// </summary>
//        public override void Execute()
//        {
//            var oUser = Game.CurrentUser();
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
//                oShopkeeper.Say(character, oShopkeeper.GetMerchantText(Globals.Globals.MerchantStmtTypes.AppraiseNoKeyword));
//                return;
//            }

//            //// is this item actually in your inventory?
//            var oItem = character.Inventory.Contents.GetEntity(keyword) as ItemInstance;
//            if (oItem.IsNull())
//            {
//                CommandManager.ReportToCharacter(oShopkeeper.GetMerchantText(Globals.Globals.MerchantStmtTypes.AppraiseNoItem), oUser);
//                return;
//            }

//            // TODO: : Can the shopkeeper see you?
//            //if (!oShopkeeper.CanSee(oUser))
//            //{
//            //    CommandManager.Instance.Report(Globals.Globals.MessageScopeTypes.CHAR, "$N looks up briefly, but sees nothing, and goes back to work.", oUser, oShopkeeper, null, null, null);
//            //    return;
//            //}

//            var sb = new StringBuilder();
//            if (!oShopkeeper.Shop.WillBuy(oItem))
//            {
//                sb.Append(oShopkeeper.GetMerchantText(Globals.Globals.MerchantStmtTypes.AppraiseNoInterest));
//                oShopkeeper.Say(character, sb.ToString(), oItem);
//                return;
//            }

//            var adjustedPrice = oShopkeeper.Shop.AppraiseItemForPurchase(oItem.Parent as ItemTemplate);

//            sb.Append(oShopkeeper.GetMerchantText(Globals.Globals.MerchantStmtTypes.AppraiseComplete));
//            sb.Replace("%c", Currency.ConvertCurrency(adjustedPrice, false));
//            oShopkeeper.Say(character, sb.ToString(), oItem);
//        }
//    }
//}
