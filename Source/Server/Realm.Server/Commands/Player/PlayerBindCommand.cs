//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Library.Common;
//using Realm.Server.Events;
//using Realm.Server.Zones;

//
//namespace Realm.Server.Commands
//
//{
//    /// <summary>
//    /// Bind command
//    /// </summary>
//    public class PlayerBindCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerBindCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerBindCommand(int id, string name, Definition definition)
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
//            var character = oUser.GetCurrentCharacter();
//            var location = character.Location as ICell;
//            if (location.IsNull())
//            {
//                Game.Logger.ErrorFormat("Character[{0}] has an invalid location.", character.ID);
//                CommandManager.ReportToCharacter("#error#", oUser);
//                return;
//            }

//            var Space = EntityManager.LuaGetConcrete(location.ID) as ISpace;
//            if (Space.IsNull())
//            {
//                Game.Logger.ErrorFormat("Space[{0}] is invalid to bind to.", location.ID);
//                CommandManager.ReportToCharacter("#error#", oUser);
//                return;
//            }

//            if (!Space.Bits.HasBit(Globals.Globals.SpaceBits.IsShrine))
//            {
//                CommandManager.ReportToCharacter("#Space_not_shrine#", oUser);
//                return;
//            }

//            if (character.Position != Globals.Globals.PositionTypes.Standing
//                && character.Movement != Globals.Globals.MovementModeTypes.Walking)
//            {
//                CommandManager.ReportToCharacter("#cannot_bind_state#", oUser);
//                return;
//            }

//            character.SetBindLocation(Space.ID);
//            CommandManager.ReportToCharacter("#Space_bind_self#", oUser, null, Space);

//            EventManager.ThrowEvent<OnBind>(character, new EventTable
//                                 {
//                                     { "Space", Space }, 
//                                     { "character", character }
//                                 });
//        }
//    }
//}
