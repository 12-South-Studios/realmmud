//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Entity.Entities;
//using Realm.Library.Common;
//using Realm.Server.Factories;
//using Realm.Server.NPC;
//using Realm.Server.Properties;
//using Realm.Server.Zones;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Commands
//// ReSharper restore CheckNamespace
//{
//    /// <summary>
//    /// Admin Spawn command
//    /// </summary>
//    public class AdminSpawnCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="AdminSpawnCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public AdminSpawnCommand(int id, string name, Definition definition)
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

//            if (CommandManager.AdminFlagCheckAndNotify(oUser, character.Flags))
//                return;
//            var keyword = oUser.GetLastCommand();
//            if (CommandManager.KeywordCheckAndNotify(oUser, keyword))
//                return;

//            var entity = EntityManager.LuaGetTemplate(keyword);
//            if (null == entity)
//            {
//                CommandManager.ReportToCharacter(MessageResources.MSG_NO_MOB, oUser);
//                return;
//            }

//            if (!(entity is IRegularMob))
//            {
//                CommandManager.ReportToCharacter(MessageResources.MSG_ADMIN_NOT_MOB, oUser, null, entity);
//                return;
//            }

//            var mob = entity as MobTemplate;
//            if (mob.IsNull()) return;

//            var factory = new GameMobileFactory();
//            var instance = factory.CreateInstance(string.Empty, mob) as GameEntityInstance;
//            if (instance.IsNull()) return;

//            Game.SetManagerReferences(instance);

//            var Space = character.Location as Space;
//            if (Space.IsNull()) return;

//            Space.Contents.AddEntity(instance);
//            CommandManager.ReportToCharacter(MessageResources.MSG_ADMIN_SPAWN_SELF, oUser, null, instance);
//        }
//    }
//}
