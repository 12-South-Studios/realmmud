//using System.Linq;
//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Entity.Entities;
//using Realm.Library.Common;
//using Realm.Library.Patterns.Command;
//using Realm.Server.Events;
//using Realm.Server.NPC;
//using Realm.Server.Players;
//using Realm.Server.Zones;

//
//namespace Realm.Server.Commands
//
//{
//    /// <summary>
//    /// shout command
//    /// </summary>
//    public class PlayerShoutCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerShoutCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerShoutCommand(int id, string name, Definition definition) : base(id, name, definition)
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
//            if (string.IsNullOrEmpty(keyword))
//            {
//                CommandManager.ReportToCharacter("#shout_what#", oUser);
//                return;
//            }

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
//        public void Execute(IBiota oActor, GameEntityTemplate obj1, GameEntityTemplate obj2, string aKeyword, bool aMessage = false)
//        {
//            if (aMessage && oActor is Character)
//                CommandManager.ReportToCharacter("#shout_self#", oActor, null, aKeyword);
//            CommandManager.ReportToSpaceLimited("#shout_other#", oActor, null, aKeyword);

//            var Space = oActor.Location as Space;
//            if (Space.IsNull()) return;
//            foreach (var mob in Space.Contents.Entities.OfType<MobInstance>().Select(entity => entity))
//            {
//                EventManager.ThrowEvent<OnMobHear>(oActor, new EventTable
//                                                               {
//                                                                   {"mob", mob}, 
//                                                                   {"phrase", aKeyword}
//                                                               });
//            }
//        }
//    }
//}
