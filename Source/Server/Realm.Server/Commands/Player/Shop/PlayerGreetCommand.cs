//using System.Text;
//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Library.Common;
//using Realm.Library.Network;
//using Realm.Server.Events;
//using Realm.Server.Item;
//using Realm.Server.NPC;
//using Realm.Server.Players;
//using Realm.Library.Network.Mxp;

//
//namespace Realm.Server.Commands
//
//{
//    /// <summary>
//    /// Learn command
//    /// </summary>
//    public class PlayerGreetCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the PlayerGreetCommand class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerGreetCommand(int id, string name, Definition definition)
//            : base(id, name, definition)
//        {
//            //// do nothing
//        }

//        /// <summary>
//        /// Executes the command
//        /// </summary>
//        public override void Execute()
//        {
//            var oUser = Game.CurrentUser();
//            var keyword = oUser.GetLastCommand();
//            if (CommandManager.KeywordCheckAndNotify(oUser, keyword))
//                return;

//            var character = oUser.GetCurrentCharacter();

//            //// find the shopkeeper
//            var validLocs = Globals.Globals.EntityLocationTypes.Space.GetValue();
//            var result = TargetLocation.FindTargetEntity(character, keyword, validLocs);
//            if (null == result.FoundEntity)
//            {
//                CommandManager.ReportToCharacter("#noone_here#", character);
//                return;
//            }
//            var biote = result.FoundEntity as Biota;
//            if (biote.IsNull()) return;

//            //// You can't greet yourself
//            if (biote == character)
//            {
//                CommandManager.ReportToCharacter("#cannot_greet_self#", character);
//                return;
//            }

//            //// other players
//            if (biote is Character)
//            {
//                CommandManager.ReportToCharacter("#cannot_greet_player#", character);
//                return;
//            }

//            //// is this mob even a shopkeeper?
//            var oMob = biote as MobInstance;
//            if (oMob.IsNull()) return;
//            if (!oMob.Bits.HasBit(Globals.Globals.MobileBits.IsMerchant))
//            {
//                CommandManager.ReportToCharacter("#greet_not_merchant#", character, oMob);
//                return;
//            }

//            // TODO: : Can the shopkeeper see you?
//            //if (!oMob.CanSee(oUser))
//            //{
//            //    CommandManager.Instance.Report(Globals.Globals.MessageScopeTypes.CHAR, "$N looks up briefly, but sees nothing, and goes back to work.", oUser, oMob, null, null, null);
//            //    return;
//            //}

//            Execute(character, oMob, null, keyword, true);
//        }

//        /// <summary>
//        /// Executes the command
//        /// </summary>
//        /// <param name="oActor"><see cref="Biota"/> object doing the action</param>
//        /// <param name="obj1">first object being acted upon</param>
//        /// <param name="obj2">second object being acted upon</param>
//        /// <param name="aKeyword">Phrase or keyword string</param>
//        /// <param name="aMessage">Flag indicating whether or not to send the message to the client</param>
//        public void Execute(IBiota oActor, IGameEntity obj1, IGameEntity obj2, string aKeyword, bool aMessage = false)
//        {
//            if (!(obj1 is MobInstance))
//                return;

//            var oMob = obj1 as MobInstance;

//            if (!(oActor is Character))
//                return;

//            var character = oActor as Character;
//            character.GreetedShop = oMob;

//            Game.SetProperty("last greeted", character);
//            Game.SetProperty("last mob greeted", oMob);

//            var shopkeeper = oMob as VendorNpcInstance;
//            if (shopkeeper.IsNull()) return;
//            var sb = new StringBuilder();

//            if (shopkeeper.Shop.Sales.Count == 0)
//            {
//                sb.Append(shopkeeper.GetMerchantText(Globals.Globals.MerchantStmtTypes.Welcome));
//                sb.Append(shopkeeper.GetMerchantText(Globals.Globals.MerchantStmtTypes.NothingForSale));
//            }
//            else
//            {
//                sb.Append(shopkeeper.GetMerchantText(Globals.Globals.MerchantStmtTypes.Welcome));
//                sb.Append(shopkeeper.GetMerchantText(Globals.Globals.MerchantStmtTypes.StuffForSale));

//                var qty = 0;
//                var i = 0;
//                foreach (var saleItem in shopkeeper.Shop.Sales)
//                {
//                    if (saleItem.QuantityInStock <= 0) continue;
//                    qty++;
//                    var item = EntityManager.LuaGetTemplate(saleItem.SaleItemId) as ItemTemplate;
//                    if (item.IsNull()) continue;
//                    var mxpTag = ("ShopItem '" + shopkeeper.Name + "' '" + item.ID + "' '" + item.Name + "'").MxpTag();

//                    if (i == 0)
//                        sb.AppendFormat(" {0}", mxpTag);
//                    else if (i == (shopkeeper.Shop.Sales.Count - 1))
//                        sb.AppendFormat(" and {0}", mxpTag);
//                    else
//                        sb.AppendFormat(", {0}", mxpTag);

//                    sb.AppendFormat("{0}{1} (x{2}", item.Name.AddArticle(), "/ShopItem".MxpTag(), saleItem.QuantityInStock);

//                    var adjustedValue = shopkeeper.Shop.AppraiseItemForSale(item);
//                    sb.AppendFormat(") for {0}", Currency.ConvertCurrency(adjustedValue, false));
//                    i++;
//                }

//                if (qty == 0)
//                {
//                    sb.Append(shopkeeper.GetMerchantText(Globals.Globals.MerchantStmtTypes.Welcome));
//                    sb.Append(shopkeeper.GetMerchantText(Globals.Globals.MerchantStmtTypes.NothingForSale));
//                }
//                else
//                    sb.Append(".");
//            }
//            shopkeeper.Say(character, sb.ToString());

//            EventManager.ThrowEvent<OnMobGreet>(character, new EventTable
//                                                              {
//                                                                  {"shopkeeper", shopkeeper}
//                                                              });
//        }
//    }
//}
