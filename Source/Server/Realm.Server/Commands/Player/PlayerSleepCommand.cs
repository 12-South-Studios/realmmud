﻿//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Library.Common;
//using Realm.Library.Patterns.Command;
//using Realm.Server.Events;
//using Realm.Server.NPC;
//using Realm.Server.Players;

//
//namespace Realm.Server.Commands
//
//{
//    /// <summary>
//    /// sleep command
//    /// </summary>
//    public class PlayerSleepCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerSleepCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerSleepCommand(int id, string name, Definition definition) : base(id, name, definition)
//        {
//            // do nothing
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
//            if (oActor.Position != Globals.Globals.PositionTypes.Sleeping)
//            {
//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter("#already_asleep#", oActor);
//                return;
//            }

//            // Can only sleep if your position is Standing/Prone/Sitting
//            // and movement mode is Walking
//            if ((oActor.Position == Globals.Globals.PositionTypes.Standing 
//                || oActor.Position == Globals.Globals.PositionTypes.Prone 
//                || oActor.Position == Globals.Globals.PositionTypes.Sitting)
//                && oActor.Movement == Globals.Globals.MovementModeTypes.Walking)
//            {
//                oActor.Position = Globals.Globals.PositionTypes.Sleeping;

//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter("#sleep_self#", oActor);
//                CommandManager.ReportToSpaceLimited("#sleep_other#", oActor);

//                EventManager.ThrowEvent<OnChangePosition>(oActor, new EventTable
//                                                                      {
//                                                                          {"position", Globals.Globals.PositionTypes.Sleeping }
//                                                                      });
//                return;
//            }

//            if (aMessage && oActor is Character)
//                CommandManager.ReportToCharacter("#cannot_sleep#", oActor);
//        }
//    }
//}
