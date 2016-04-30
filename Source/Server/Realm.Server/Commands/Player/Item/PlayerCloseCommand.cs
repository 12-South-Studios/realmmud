//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Entity.Entities;
//using Realm.Library.Common;
//using Realm.Server.Events;
//using Realm.Server.Item;
//using Realm.Server.NPC;
//using Realm.Server.Players;
//using Realm.Server.Zones;

//
//namespace Realm.Server.Commands
//
//{
//    /// <summary>
//    /// Bind command
//    /// </summary>
//    public class PlayerCloseCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerCloseCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerCloseCommand(int id, string name, Definition definition)
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

//            Execute(oUser.GetCurrentCharacter(), null, null, keyword, true);
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
//            var oSpace = oActor.Location as Space;
//            if (oSpace.IsNull()) return;
//            var ex = oSpace.GetPortal(aKeyword);
//            if (null != ex)
//            {
//                // is there a door?
//                if (null == ex.Door)
//                {
//                    if ((aMessage) && (oActor is Character))
//                        CommandManager.ReportToCharacter("#no_door#", oActor, null, ex.Name);
//                    return;
//                }

//                // is it already closed?
//                if (ex.Door.IsClosed)
//                {
//                    if ((aMessage) && (oActor is Character))
//                        CommandManager.ReportToCharacter("#door_already_closed#", oActor, null, ex.Door.Name);
//                    return;
//                }

//                // is it broken?
//                if (ex.Door.IsBroken)
//                {
//                    if ((aMessage) && (oActor is Character))
//                        CommandManager.ReportToCharacter("#door_broken#", oActor, null, ex.Door.Name);
//                    return;
//                }

//                // close it!
//                ex.Door.Close();

//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#door_close_self#", oActor, null, ex.Door.Name);
//                CommandManager.ReportToSpaceLimited("#door_close_other#", oActor, null, ex.Door.Name);
//            }
//            else
//            {
//                // Find the target somewhere
//                var validLocs = Globals.Globals.EntityLocationTypes.Space.GetValue()
//                    | Globals.Globals.EntityLocationTypes.Inventory.GetValue()
//                    | Globals.Globals.EntityLocationTypes.Equipment.GetValue();
//                var result = TargetLocation.FindTargetEntity(oActor, aKeyword, validLocs);
//                if (null == result.FoundEntity)
//                {
//                    if (aMessage && oActor is Character)
//                        CommandManager.ReportToCharacter("#no_item#", oActor);
//                    return;
//                }
//                var oItem = result.FoundEntity as ItemInstance;
//                if (oItem.IsNull()) return;

//                // is it a container?
//                if (!oItem.IsType("container"))
//                {
//                    if ((aMessage) && (oActor is Character))
//                        CommandManager.ReportToCharacter("#not_container#", oActor, null, oItem);
//                    return;
//                }

//                var container = oItem as ContainerItemInstance;
//                if (container.IsNull()) return;

//                // is it closeable?
//                if (!container.IsCloseable)
//                {
//                    if ((aMessage) && (oActor is Character))
//                        CommandManager.ReportToCharacter("#item_cannot_close#", oActor, null, oItem);
//                    return;
//                }

//                // is it already closed?
//                if (container.IsClosed)
//                {
//                    if ((aMessage) && (oActor is Character))
//                        CommandManager.ReportToCharacter("#item_already_closed#", oActor, null, oItem);
//                    return;
//                }

//                // close it
//                container.Close();

//                if ((aMessage) && (oActor is Character))
//                    CommandManager.ReportToCharacter("#item_close_self#", oActor, null, oItem);
//                CommandManager.ReportToSpaceLimited("#item_close_other#", oActor, null, oItem);

//                var Space = oActor.Location as Space;
//                if (Space.IsNull()) return;

//                EventManager.ThrowEvent<OnCloseItem>(oActor, new EventTable
//                                                                 {
//                                                                     { "Space", Space },
//                                                                     { "item", oItem }
//                                                                 });
//            }
//        }
//    }
//}
