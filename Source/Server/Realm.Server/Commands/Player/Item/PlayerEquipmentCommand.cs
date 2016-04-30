//using System;
//using System.Text;
//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Library.Common;
//using Realm.Library.Network;
//using Realm.Library.Patterns.Command;
//using Realm.Library.Network.Mxp;

//
//namespace Realm.Server.Commands
//
//{
//    /// <summary>
//    /// Bind command
//    /// </summary>
//    public class PlayerEquipmentCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerEquipmentCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerEquipmentCommand(int id, string name, Definition definition) : base(id, name, definition)
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
//            sb.Append("#wearing#");

//            var character = oUser.GetCurrentCharacter();
//            if (character.IsNaked())
//            {
//                sb.Append(Environment.NewLine);
//                sb.Append(" #nothing#");
//                CommandManager.ReportToCharacter(sb.ToString(), oUser);
//                return;
//            }

//            foreach (var wearLocation in character.GetEquippedWearLocations())
//            {
//                var instance = character.GetEquippedItem(wearLocation);
//                var mxpTag = new StringBuilder();
//                sb.Append(("EqItem '" + instance.ID + "' '" + instance.Name + "'").MxpTag());
//                sb.AppendFormat("{0} {1}", Environment.NewLine, wearLocation.GetExtraData().PadRight(30, '.'));

//                if (character.Flags.IsBuilder())
//                {
//                    sb.AppendFormat("{0}{1}{2}", mxpTag, instance.Name, "/EqItem".MxpTag());
//                    sb.AppendFormat(" (#{0}{1}{2}{3})", ("WizItem '" + instance.ID + "'").MxpTag(),
//                                    instance.ID, instance.GetFlags(), "/WizItem".MxpTag());
//                }
//                else
//                    sb.AppendFormat("{0}{1}{2}", mxpTag, instance.Name, "/EqItem".MxpTag());
//            }

//            CommandManager.ReportToCharacter(sb.ToString(), oUser);
//        }
//    }
//}
