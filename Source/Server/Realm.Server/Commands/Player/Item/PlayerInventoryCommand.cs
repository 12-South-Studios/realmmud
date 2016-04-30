//using System;
//using System.Text;
//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Library.Common;
//using Realm.Library.Network;
//using Realm.Library.Patterns.Command;
//using Realm.Server.Item;
//using Realm.Library.Network.Mxp;

//
//namespace Realm.Server.Commands
//
//{
//    /// <summary>
//    /// Bind command
//    /// </summary>
//    public class PlayerInventoryCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerInventoryCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerInventoryCommand(int id, string name, Definition definition) : base(id, name, definition)
//        {
//            //// do nothing
//        }

//        /// <summary>
//        /// Executes the command
//        /// </summary>
//        public override void Execute()
//        {
//            var oUser = Game.CurrentUser();

//            var sb = new StringBuilder();
//            sb.Append("#holding#");

//            var character = oUser.GetCurrentCharacter();
//            if (character.GetItems().Count == 0)
//            {
//                sb.AppendFormat("{0}  #nothing#", Environment.NewLine);
//                CommandManager.ReportToCharacter(sb.ToString(), oUser);
//                return;
//            }

//            foreach (var instance in character.GetItems())
//            {
//                var beginMxpTag = new StringBuilder();
//                var endMxpTag = new StringBuilder();
//                if (instance.IsType("drink container"))
//                {
//                    beginMxpTag.Append(("InvItem_DrinkCnt '" + instance.ID + "' '" + instance.Name + "'").MxpTag());
//                    endMxpTag.Append("/InvItem_DrinkCnt".MxpTag());
//                }
//                else if (instance.IsType("container"))
//                {
//                    beginMxpTag.Append(("InvItem_Cnt '" + instance.ID + "' '" + instance.Name + "'").MxpTag());
//                    endMxpTag.Append("/InvItem_Cnt".MxpTag());
//                }
//                else if (instance.IsType("weapon"))
//                {
//                    beginMxpTag.Append(("InvItem_Weapon '" + instance.ID + "' '" + instance.Name + "'").MxpTag());
//                    endMxpTag.Append("/InvItem_Weapon".MxpTag());
//                }
//                else if (instance.IsType("food"))
//                {
//                    beginMxpTag.Append(("InvItem_Food '" + instance.ID + "' '" + instance.Name + "'").MxpTag());
//                    endMxpTag.Append("/InvItem_Food".MxpTag());
//                }
//                else if (instance.IsType("formula"))
//                {
//                    var formula = instance as FormulaItemInstance;
//                    if (formula.IsNull()) continue;
//                    var product = EntityManager.LuaGetTemplate(formula.Product) as ItemTemplate;
//                    if (product.IsNull()) continue;

//                    beginMxpTag.Append(("InvItem_Recipe '" + instance.ID + "' '" + instance.Name +
//                                        "' '" + product.ID + "' '" + product.Name + "'").MxpTag());
//                    endMxpTag.Append("/InvItem_Recipe".MxpTag());
//                }
//                else
//                {
//                    beginMxpTag.Append(("InvItem '" + instance.ID + "' '" + instance.Name + "'").MxpTag());
//                    endMxpTag.Append("/InvItem".MxpTag());
//                }

//                if (character.Flags.IsAdmin())
//                {
//                    if (instance.StackSize > 1)
//                        sb.AppendFormat("{0}  (x{1}) ", Environment.NewLine, instance.StackSize);
//                    else
//                        sb.AppendFormat("{0} ", Environment.NewLine);

//                    sb.AppendFormat("{0}{1}{2}", beginMxpTag, instance.Name.AddArticle(), endMxpTag);
//                    sb.AppendFormat(" (#{0}{1}{2}{3})", ("WizItem '" + instance.ID + "'").MxpTag(), 
//                                    instance.ID, instance.GetFlags(), "/WizItem".MxpTag());
//                }
//                else
//                {
//                    if (instance.StackSize > 1)
//                        sb.AppendFormat("{0}  (x{1}) {2}{3}{4}", Environment.NewLine, instance.StackSize,
//                                        beginMxpTag, instance.Name.AddArticle(), endMxpTag);
//                    else
//                        sb.AppendFormat("{0}  {1}{2}{3}", Environment.NewLine, beginMxpTag, instance.Name.AddArticle(), endMxpTag);
//                }
//            }

//            CommandManager.ReportToCharacter(sb.ToString(), oUser);
//            CommandManager.ReportToCharacter("#carrying#", oUser, null, null, null, null, character.Value);
//        }
//    }
//}
