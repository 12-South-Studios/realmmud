﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Realm.Command.Interfaces;
using Realm.Command.Parsers;
using Realm.Command.Properties;
using Realm.Data.Definitions;
using Realm.Entity;
using Realm.Entity.Entities;
using Realm.Library.Common;
using Realm.Library.Common.Logging;

namespace Realm.Command
{
    /// <summary>
    ///
    /// </summary>
    public class CommandExecutor : ICommandExecutor
    {
        private ICommandManager CommandManager { get; set; }
        private IEntityManager EntityManager { get; set; }
        private ILogWrapper Logger { get; set; }

        ///  <summary>
        /// 
        ///  </summary>
        ///  <param name="commandManager"></param>
        ///  <param name="entityManager"> </param>
        /// <param name="log"></param>
        public CommandExecutor(ICommandManager commandManager, IEntityManager entityManager, ILogWrapper log)
        {
            CommandManager = commandManager;
            EntityManager = entityManager;
            Logger = log;
        }

        private delegate void SendMessageScope(StringBuilder sb, ReportData data);

        private readonly Dictionary<Globals.Globals.MessageScopeTypes, SendMessageScope> _messageScopeTable = new Dictionary<Globals.Globals.MessageScopeTypes, SendMessageScope>()
            {
                { Globals.Globals.MessageScopeTypes.Character, SendMessageScopeCharacter },
                { Globals.Globals.MessageScopeTypes.Space, SendMessageScopeSpace },
                { Globals.Globals.MessageScopeTypes.SpaceLimited, SendMessageScopeSpaceLimited },
                { Globals.Globals.MessageScopeTypes.Victim, SendMessageScopeVictim }
            };

        /// <summary>
        /// Executes a command for a given entity
        /// </summary>
        public bool Execute(IGameEntity entity, string command)
        {
            return Execute(entity, command.FirstWord(), command.RemoveWord(0));
        }

        /// <summary>
        /// Executes a command (with the given verb and phrase) for a given entity
        /// </summary>
        public bool Execute(IGameEntity entity, string verb, string phrase)
        {
            Validation.IsNotNull(entity, "entity");
            Validation.IsNotNullOrEmpty(verb, "verb");

            if (!string.IsNullOrEmpty(phrase))
                phrase = phrase.Trim('\'');

            verb = verb.Replace(Environment.NewLine, string.Empty);

            var tuple = CommandManager.CommandRepository.Get(verb);
            if (tuple.IsNotNull())
                return ExecuteVerb(tuple, entity, phrase);
            
            var channel =
                CommandManager.GetParser("Channel").CastAs<PlayerChannelParser>().CheckChannelHandle(
                    entity as ICharacter, verb);
            if (channel.IsNotNull())
            {
                channel.SendText(entity as ICharacter, phrase);
                return true;
            }

            var social = CommandManager.GetParser("Social").CastAs<SocialCommandParser>().GetSocial(entity as IBiota,
                                                                                                    verb);
            if (social.IsNotNull())
            {
                CommandManager.GetParser("Social").CastAs<SocialCommandParser>().ParseSocial(entity as IBiota, social,
                                                                                             phrase);
                return true;
            }

            if (MovementParser.CheckMovementCommands(entity as IBiota, verb))
            {
                // TODO: How to handle a movement command
                /*var moveCmd = GetCommand("move");
                var args = PopulateCommandArgs(oUser.Characters.Character, null, null, verb, true);
                moveCmd.Execute(args);*/
                return true;
            }

            Report(Globals.Globals.MessageScopeTypes.Character, Resources.MSG_NOT_UNDERSTAND, entity);
            return false;
        }

        /// <summary>
        /// Executes the given action
        /// </summary>
        /// <param name="tuple"></param>
        /// <param name="entity"></param>
        /// <param name="phrase"></param>
        /// <returns></returns>
        private bool ExecuteVerb(Tuple<Action, Definition> tuple, IGameEntity entity, string phrase)
        {
            var action = tuple.Item1.CastAs<Action>();
            var commandDef = tuple.Item2.CastAs<GameCommandDef>();

            if (commandDef.AdminOnly && !CommandManager.AdminFlagCheckAndNotify(entity, entity.GetFlagContext()))
                return false;

            if (commandDef.LogAction == Globals.Globals.LogActionTypes.Always)
                Logger.InfoFormat("Entity[{0}, {1}] executed Action[{2}, {3}]", entity.ID, entity.Name,
                                  commandDef.ID, commandDef.Name);

            action.DynamicInvoke(phrase);
            return true;
        }

        /// <summary>
        /// Submits the given string to a filtered list of users (determined by scope)
        /// and after parsing any variables contained within the string.
        /// </summary>
        public void Report(Globals.Globals.MessageScopeTypes scope, string message, IEntity oActor,
            IEntity oVictim = null, object oDirectObject = null, object oIndirectObject = null,
            IGameEntity oSpace = null, object oExtra = null)
        {
            Validation.IsNotNullOrEmpty(message, "message");
            Validation.IsNotNull(oActor, "oActor");

            Report(scope, message,
                   CommandParser.ToReportData(oActor, oVictim, oDirectObject, oIndirectObject, oSpace, oExtra));
        }

        /// <summary>
        /// Submits the given string to a filtered list of users (determined by scope)
        /// and after parsing any variables contained within the string.
        /// </summary>
        public void Report(Globals.Globals.MessageScopeTypes scope, string message, ReportData data)
        {
            Validation.IsNotNullOrEmpty(message, "message");
            Validation.IsNotNull(data, "data");

            try
            {
                var sb = new StringBuilder();
                sb.Append(CommandManager.GetParser("Command").CastAs<CommandParser>().ParseRegex(message,
                                                                                                 data.Actor.CastAs
                                                                                                     <IGameEntity>()));
                sb = sb.ParseString(CommandManager.VariableHelper,
                                    CommandManager.GetParser("Command").CastAs<CommandParser>(), data);
                if (sb.Length == 0) return;

                sb.Insert(0, Environment.NewLine);

                if (_messageScopeTable.ContainsKey(scope))
                    _messageScopeTable[scope].DynamicInvoke(sb, data);
                else
                {
                    EntityManager.GetEntities().OfType<ICharacter>().ToList()
                        .ForEach(x => x.CastAs<ICharacter>().User.SendText(sb.ToString()));
                }
            }
            catch (Exception ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordAndThrow);
            }
        }

        private static IGameUser GetUserFromEntity(IEntity entity)
        {
            if (entity is ICharacter)
                return entity.CastAs<ICharacter>().User;
            if (entity is IGameUser)
                return entity.CastAs<IGameUser>();
            return null;
        }

        private static Space GetEntitySpace(IEntity entity)
        {
            Space space = null;
            if (entity is ICharacter)
                space = entity.CastAs<ICharacter>().Location.CastAs<Space>();
            else if (entity is IGameUser)
                space = entity.CastAs<IGameUser>().CurrentCharacter.Location.CastAs<Space>();
            return space;
        }

        /// <summary>
        /// Sends the message to the actor
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="data"></param>
        private static void SendMessageScopeCharacter(StringBuilder sb, ReportData data)
        {
            GetUserFromEntity(data.Actor).SendText(sb.ToString());
        }

        /// <summary>
        /// Sends the message to the victim
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="data"></param>
        private static void SendMessageScopeVictim(StringBuilder sb, ReportData data)
        {
            GetUserFromEntity(data.Victim).SendText(sb.ToString());
        }

        /// <summary>
        /// Sends the message to all occupants of the current space
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="data"></param>
        private static void SendMessageScopeSpace(StringBuilder sb, ReportData data)
        {
            GetEntitySpace(data.Actor).GetEntities().OfType<ICharacter>().ToList().ForEach(
                x => x.User.SendText(sb.ToString()));
        }

        /// <summary>
        /// Sends the message to all occupants (except the actor) of the current space
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="data"></param>
        private static void SendMessageScopeSpaceLimited(StringBuilder sb, ReportData data)
        {
            GetEntitySpace(data.Actor).GetEntities().OfType<ICharacter>().Where(x => !x.Equals(data.Actor)).ToList().
                ForEach(x => x.User.SendText(sb.ToString()));
        }
    }
}