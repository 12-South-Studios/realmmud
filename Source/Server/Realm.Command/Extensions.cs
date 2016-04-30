using System.Text;
using Realm.Command.Interfaces;
using Realm.Command.Parsers;
using Realm.Command.Properties;
using Realm.Data;
using Realm.Entity;
using Realm.Entity.Contexts;
using Realm.Entity.Interfaces;
using Realm.Library.Common;
using Realm.Library.Common.Entities;
using Realm.Library.Common.Extensions;
using Realm.Library.Common.Objects;

namespace Realm.Command
{
    public static class Extensions
    {
        public static StringBuilder ParseString(this StringBuilder sb, IVariableHelper helper,
            CommandParser parser, ReportData data = null)
        {
            int varPosition;
            var startIndex = 0;

            do
            {
                const string chars = "$%&";
                var anyOf = chars.ToCharArray();

                varPosition = sb.IndexOfAny(anyOf, startIndex);
                if (varPosition == -1) continue;

                //// Is it a valid variable?
                if (helper.GetDelegate(sb.Substring(varPosition, 2)).IsNotNull())
                    sb.ReplaceFirst(sb.Substring(varPosition, 2), parser.ParseVariable(sb.Substring(varPosition, 2), data));

                startIndex = varPosition + 1;
            }
            while (varPosition != -1);

            return sb;
        }

        /// <summary>
        /// Validates the keyword string to determine if its empty and sends a standardized
        /// message to the user.
        /// </summary>
        public static bool KeywordCheckAndNotify(this ICommandManager commandManager, IEntity user, string keyword)
        {
            bool returnVal = true;
            try
            {
                Validation.IsNotNull(commandManager, "commandManager");
                Validation.IsNotNull(user, "user");
                Validation.IsNotNullOrEmpty(keyword, "keyword");
            }
            catch
            {
                returnVal = false;
                commandManager.ReportToCharacter(Resources.MSG_NOT_UNDERSTAND, user);
            }

            return returnVal;
        }

        /// <summary>
        /// Validates the user's keywords for admin flags and sends a standardized message
        /// to the user.
        /// </summary>
        public static bool AdminFlagCheckAndNotify(this ICommandManager commandManager, IEntity user, IFlagContext FlagContext)
        {
            bool returnVal = true;
            try
            {
                Validation.IsNotNull(commandManager, "commandManager");
                Validation.IsNotNull(user, "user");
                Validation.IsNotNull(FlagContext, "FlagContext");
                Validation.Validate(FlagContext.IsAdmin());
            }
            catch
            {
                returnVal = false;
                commandManager.ReportToCharacter(Resources.MSG_NOT_AUTHORIZED, user);
            }

            return returnVal;
        }

        /// <summary>
        /// Sends a report directly to the character
        /// </summary>
        public static void ReportToCharacter(this ICommandManager manager, string message, IEntity oActor,
                                             IEntity oVictim = null, object oDirectObject = null, object oIndirectObject = null,
                                             IGameEntity oSpace = null, object oExtra = null)
        {
            Validation.IsNotNull(manager, "manager");

            manager.Report(Globals.MessageScopeTypes.Character, message,
                           CommandParser.ToReportData(oActor, oVictim, oDirectObject, oIndirectObject, oSpace, oExtra));
        }

        /// <summary>
        /// Sends a report directly to the space
        /// </summary>
        public static void ReportToSpace(this ICommandManager manager, string message, IEntity oActor,
                                         IEntity oVictim = null, object oDirectObject = null, object oIndirectObject = null,
                                         IGameEntity oSpace = null, object oExtra = null)
        {
            Validation.IsNotNull(manager, "manager");

            manager.Report(Globals.MessageScopeTypes.Space, message,
                           CommandParser.ToReportData(oActor, oVictim, oDirectObject, oIndirectObject, oSpace, oExtra));
        }

        /// <summary>
        /// Sends a report directly to the space (limited)
        /// </summary>
        public static void ReportToSpaceLimited(this ICommandManager manager, string message, IEntity oActor,
                                                IEntity oVictim = null, object oDirectObject = null, object oIndirectObject = null,
                                                IGameEntity oSpace = null, object oExtra = null)
        {
            Validation.IsNotNull(manager, "manager");

            manager.Report(Globals.MessageScopeTypes.SpaceLimited, message,
                           CommandParser.ToReportData(oActor, oVictim, oDirectObject, oIndirectObject, oSpace, oExtra));
        }

        /// <summary>
        /// Sends a report directly to the game
        /// </summary>
        public static void ReportToGame(this ICommandManager manager, string message, IEntity oActor,
                                        IEntity oVictim = null, object oDirectObject = null, object oIndirectObject = null,
                                        IGameEntity oSpace = null, object oExtra = null)
        {
            Validation.IsNotNull(manager, "manager");

            manager.Report(Globals.MessageScopeTypes.Game, message,
                           CommandParser.ToReportData(oActor, oVictim, oDirectObject, oIndirectObject, oSpace, oExtra));
        }

        /// <summary>
        /// Sends a report directly to the zone
        /// </summary>
        public static void ReportToZone(this ICommandManager manager, string message, IEntity oActor,
                                        IEntity oVictim = null, object oDirectObject = null, object oIndirectObject = null,
                                        IGameEntity oSpace = null, object oExtra = null)
        {
            Validation.IsNotNull(manager, "manager");

            manager.Report(Globals.MessageScopeTypes.Zone, message,
                           CommandParser.ToReportData(oActor, oVictim, oDirectObject, oIndirectObject, oSpace, oExtra));
        }

        /// <summary>
        /// Sends a report directly to the victim
        /// </summary>
        public static void ReportToVictim(this ICommandManager manager, string message, IEntity oActor,
                                          IEntity oVictim = null, object oDirectObject = null, object oIndirectObject = null,
                                          IGameEntity oSpace = null, object oExtra = null)
        {
            Validation.IsNotNull(manager, "manager");

            manager.Report(Globals.MessageScopeTypes.Victim, message,
                           CommandParser.ToReportData(oActor, oVictim, oDirectObject, oIndirectObject, oSpace, oExtra));
        }
    }
}