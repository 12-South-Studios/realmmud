//using System;
//using System.Text;
//using Realm.Command;
//using Realm.Data.Definitions;
//using Realm.Library.Common;
//using Realm.Server.Interfaces;
//using Realm.Server.Properties;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Commands
//// ReSharper restore CheckNamespace
//{
//    /// <summary>
//    /// Admin Examine command
//    /// </summary>
//    public class AdminExamineCommand : GameCommand
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="AdminExamineCommand"/> class
//        /// </summary>
//        /// <param name="name">Name of the command</param>
//        /// <param name="keywords">Keywords of the command</param>
//        /// <param name="action">Log action to take when executed</param>
//        public AdminExamineCommand(int id, string name, Definition definition)
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

//            //// get the object (must be an ID)
//            var entity = EntityManager.LuaGetEntity(Convert.ToInt32(keyword));
//            if (entity.IsNull() || !(entity is IExaminable))
//            {
//                CommandManager.ReportToCharacter(MessageResources.MSG_ADMIN_NOT_ENTITY, oUser);
//                return;
//            }

//            var sb = new StringBuilder();
//            sb.AppendFormat("{0} [#{1}]{2}", entity.Name, entity.ID, Environment.NewLine);

//            var exEntity = entity as IExaminable;
//            sb.Append(exEntity.Examine());

//            if (entity is IWizardExaminable)
//            {
//                var wizEntity = entity as IWizardExaminable;
//                sb.Append(wizEntity.WizExamine());
//            }

//            CommandManager.ReportToCharacter(sb.ToString(), oUser);
//        }
//    }
//}
