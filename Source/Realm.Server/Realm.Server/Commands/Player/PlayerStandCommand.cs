//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Library.Common;
//using Realm.Library.Patterns.Command;
//using Realm.Server.Events;
//using Realm.Server.NPC;
//using Realm.Server.Players;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Commands
//// ReSharper restore CheckNamespace
//{
//    /// <summary>
//    /// stand command
//    /// </summary>
//    public class PlayerStandCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerStandCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerStandCommand(int id, string name, Definition definition) : base(id, name, definition)
//        {
//            //// do nothing
//        }

//        /// <summary>
//        /// Executes the command
//        /// </summary>
//        public override void Execute()
//        {
//            Execute(Game.CurrentUser().GetCurrentCharacter(), null, null, string.Empty, true);
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
//            if (oActor.Position == Globals.Globals.PositionTypes.Standing)
//            {
//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter("#already_standing#", oActor);
//                return;
//            }

//            // Can't stand if your Movement mode isn't Walking
//            if (oActor.Movement != Globals.Globals.MovementModeTypes.Walking)
//            {
//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter("#cannot_stand#", oActor);
//                return;
//            }

//            if (oActor.Position == Globals.Globals.PositionTypes.Sitting ||
//                oActor.Position == Globals.Globals.PositionTypes.Prone ||
//                oActor.Position == Globals.Globals.PositionTypes.Crouching)
//            {
//                oActor.Position = Globals.Globals.PositionTypes.Standing;
//                oActor.Movement = Globals.Globals.MovementModeTypes.Walking;

//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter("#stand_self#", oActor);
//                CommandManager.ReportToSpaceLimited("#stand_other#", oActor);

//                EventManager.ThrowEvent<OnChangePosition>(oActor, new EventTable
//                                                                      {
//                                                                          { "position", Globals.Globals.PositionTypes.Standing},
//                                                                          { "movement", Globals.Globals.MovementModeTypes.Walking}
//                                                                      });
//            }
//        }
//    }
//}
