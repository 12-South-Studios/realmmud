//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Entity.Entities;
//using Realm.Library.Common;
//using Realm.Server.Events;
//using Realm.Server.Properties;
//using Realm.Server.Zones;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Commands
//// ReSharper restore CheckNamespace
//{
//    /// <summary>
//    /// Admin Teleport command
//    /// </summary>
//    public class AdminTeleportCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="AdminTeleportCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public AdminTeleportCommand(int id, string name, Definition definition)
//            : base(id, name, definition)
//        {
//            // do nothing
//        }

//        /// <summary>
//        /// Executes the command
//        /// </summary>
//        public override void Execute()
//        {
//            var oUser = Game.CurrentUser();
//            var character = oUser.GetCurrentCharacter();

//            if (CommandManager.AdminFlagCheckAndNotify(oUser, character.Flags))
//                return;

//            var keyword = oUser.GetLastCommand();
//            if (string.IsNullOrEmpty(keyword))
//            {
//                CommandManager.ReportToCharacter(MessageResources.MSG_TEL_INVALID_DEST, oUser);
//                return;
//            }

//            var entity = EntityManager.LuaGetConcrete(keyword);
//            if (entity.IsNull())
//            {
//                CommandManager.ReportToCharacter(MessageResources.MSG_TEL_INVALID_DEST, oUser);
//                return;
//            }

//            //// it has to be a Space
//            if (!(entity is Space))
//            {
//                CommandManager.ReportToCharacter(MessageResources.MSG_TEL_INVALID_DEST, oUser);
//                return;
//            }

//            var oSpace = entity as Space;

//            var value = ~(character.Access & oSpace.Access);
//            if (value == 0)
//            {
//                CommandManager.ReportToCharacter(MessageResources.MSG_TEL_CANNOT_ENTER, oUser);
//                return;
//            }

//            var oldSpace = character.Location as Space;
//            if (oldSpace.IsNull()) return;

//            oldSpace.RemoveEntity(character);
//            oSpace.AddEntity(character);
//            character.Location = oSpace;

//            if (!character.Flags.HasFlag("Hidden"))
//            {
//                // user isn't hidden, so send messages to area
//                if (oldSpace.Location != oSpace.Location)
//                {
//                    // Throw ZoneLeave and ZoneEnter events
//                    var zoneTable = new EventTable
//                                        {
//                                            {"old_zone", oldSpace.Location},
//                                            {"new_zone", oSpace.Location},
//                                            {"biote", character}
//                                        };
//                    var zone = oldSpace.Location as Zone;
//                    if (zone.IsNotNull())
//                        EventManager.ThrowEvent<OnZoneLeave>(zone, zoneTable);
//                    zone = oSpace.Location as Zone;
//                    if (zone.IsNotNull())
//                        EventManager.ThrowEvent<OnZoneEnter>(zone, zoneTable);
//                }

//                // Throw SpaceLeave and SpaceEvent events
//                var SpaceTable = new EventTable
//                                    {
//                                        {"old_Space", oldSpace},
//                                        {"new_Space", oSpace},
//                                        {"biote", character}
//                                    };
//                EventManager.ThrowEvent<OnSpaceLeave>(oldSpace, SpaceTable);
//                EventManager.ThrowEvent<OnSpaceEnter>(oSpace, SpaceTable);
//            }

//            CommandManager.Execute(oUser, "look");
//            //PlayerLookCommand.LookArea(oUser.Characters.Character, oUser.Characters.Character.Location);
//        }
//    }
//}
