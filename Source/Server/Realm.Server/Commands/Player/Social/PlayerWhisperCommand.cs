//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Library.Common;
//using Realm.Server.Events;
//using Realm.Server.NPC;
//using Realm.Server.Players;
//using Realm.Server.Properties;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Commands
//// ReSharper restore CheckNamespace
//{
//    /// <summary>
//    /// whisper command
//    /// </summary>
//    public class PlayerWhisperCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="PlayerWhisperCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public PlayerWhisperCommand(int id, string name, Definition definition)
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
//            var keyword = oUser.GetLastCommand();
//            if (string.IsNullOrEmpty(keyword))
//            {
//                CommandManager.ReportToCharacter("#whisper_what#", oUser);
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
//            var entityName = aKeyword.FirstWord();
//            var target = oActor.Location.Contents.GetEntity(entityName);
//            if (target.IsNull())
//            {
//                int result;
//                if (int.TryParse(entityName, out result))
//                    target = oActor.Location.Contents.GetEntity(result);
//                else
//                {
//                    if (aMessage && oActor is Character)
//                        CommandManager.ReportToCharacter("#whisper_noone_self#", oActor);
//                    CommandManager.ReportToSpaceLimited("#whisper_noone_other#", oActor);
//                    return;
//                }
//            }

//            var phrase = aKeyword.RemoveWord(0);
//            if (oActor == target)
//            {
//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter("#cannot_whisper_self#", oActor);
//                return;
//            }

//            var oTarget = target as IGameEntity;
//            if (oTarget.IsNull()) return;

//            if (oActor.Location != oTarget.Location)
//            {
//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter(MessageResources.MSG_NOT_IN_SPACE, oActor, target);
//                return;
//            }

//            if (string.IsNullOrEmpty(phrase))
//            {
//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter("#whisper_what#", oActor, target);
//                return;
//            }

//            if (oTarget is Character)
//            {
//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter("#whisper_target_self#", oActor, target, phrase);
//                CommandManager.ReportToCharacter("#whisper_target_target#", oActor, target, phrase);
//                CommandManager.ReportToSpaceLimited("#whisper_target_other#", oActor, target);
//                return;
//            }

//            if (oTarget is MobInstance && oTarget is IConversationalist)
//            {
//                var oMob = target as IConversationalist;
//                if (oMob.IsNull()) return;

//                //// does it have a conversation?
//                if (oMob.ChatTree.IsNull())
//                {
//                    if (aMessage && oActor is Character)
//                        CommandManager.ReportToCharacter("#cannot_whisper_mob#", oActor, oMob as MobInstance);
//                    return;
//                }

//                if (aMessage && oActor is Character)
//                    CommandManager.ReportToCharacter("#whisper_target_self#", oActor, oMob as MobInstance, phrase);
//                CommandManager.ReportToCharacter("#whisper_target_target#", oActor, oMob as MobInstance, phrase);

//                EventManager.ThrowEvent<OnMobHear>(oActor, new EventTable
//                                                               {
//                                                                   { "mob", oMob as MobInstance }, 
//                                                                   { "phrase", phrase }
//                                                               });
//            }
//        }
//    }
//}
