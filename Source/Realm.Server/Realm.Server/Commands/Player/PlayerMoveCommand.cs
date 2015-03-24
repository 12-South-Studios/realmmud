//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Entity.Entities;
//using Realm.Library.Common;
//using Realm.Library.Patterns.Command;
//using Realm.Server.Events;
//using Realm.Server.NPC;
//using Realm.Server.Players;
//using Realm.Server.Zones;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Commands
//// ReSharper restore CheckNamespace
//{
//    /// <summary>
//    /// move command
//    /// </summary>
//    public class PlayerMoveCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerMoveCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerMoveCommand(int id, string name, Definition definition) : base(id, name, definition)
//        {
//            //// do nothing
//        }

//        /// <summary>
//        /// Executes the command
//        /// </summary>
//        public override void Execute()
//        {
//            //// Do nothing
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
//            if (oActor is MobInstance)
//            {
//                var mob = oActor as IMobInstance;
//                if (mob.IsNull()) return;
//                if (!mob.CanMove(aKeyword, false, aMessage))
//                {
//                    //mob.AddMessage("I can't move " + aKeyword);
//                    return;
//                }
//            }
//            else if (oActor is Character)
//            {
//                var character = oActor as ICharacter;
//                if (character.IsNull()) return;
//                if (!character.CanMove(aKeyword, false, aMessage))
//                {
//                    if (aMessage && oActor is Character)
//                        CommandManager.ReportToCharacter("#cannot_move#", oActor, null, oActor.Position.GetName());
//                    return;
//                }
//            }

//            var oldSpace = oActor.Location as ISpace;
//            if (oldSpace.IsNull()) return;
//            var exit = oldSpace.GetPortal(aKeyword);
//            var newSpace = exit.Destination;

//            Game.SetProperty("last left Space", oActor);

//            if (aMessage && oActor is Character)
//                CommandManager.ReportToSpaceLimited("#move_self#", oActor, null, exit);
//            CommandManager.ReportToSpaceLimited("#move_other#", oActor, null, exit, null, oldSpace);

//            oldSpace.RemoveEntity(oActor);
//            newSpace.AddEntity(oActor);
//            oActor.Location = newSpace;

//            Game.SetProperty("last entered Space", oActor);

//            var SpaceTable = new EventTable
//                                    {
//                                        {"old_Space", oldSpace},
//                                        {"new_Space", newSpace},
//                                        {"biote", oActor}
//                                    };
//            EventManager.ThrowEvent<OnSpaceLeave>(oldSpace, SpaceTable);
//            EventManager.ThrowEvent<OnSpaceEnter>(newSpace, SpaceTable);

//            CommandManager.ReportToSpaceLimited("#arrive_other#", oActor, null, exit, null, newSpace);

//            // user isn't hidden, so send messages to area
//            if (oldSpace.Location != newSpace.Location)
//            {
//                // Throw ZoneLeave and ZoneEnter events
//                var zoneTable = new EventTable
//                                        {
//                                            {"old_zone", oldSpace.Location},
//                                            {"new_zone", newSpace.Location},
//                                            {"biote", oActor}
//                                        };
//                var zone = oldSpace.Location as Zone;
//                if (zone.IsNotNull())
//                    EventManager.ThrowEvent<OnZoneLeave>(zone, zoneTable);
//                zone = newSpace.Location as Zone;
//                if (zone.IsNotNull())
//                    EventManager.ThrowEvent<OnZoneEnter>(zone, zoneTable);
//            }

//            if (oActor is Character)
//            {
//                var character = oActor as ICharacter;
//                if (character.IsNull()) return;
//                CommandManager.Execute(character.User, "look");
//            }
//                //PlayerLookCommand.LookArea(oActor as ICharacter, oActor.Location);
//        }
//    }
//}
