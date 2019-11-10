using System;
using System.Collections.Generic;
using Ninject;
using Realm.Command.Interfaces;
using Realm.Command.Parsers;
using Realm.Data;
using Realm.Entity;
using Realm.Entity.Interfaces;
using Realm.Event;
using Realm.Library.Common.Data;
using Realm.Library.Common.Entities;
using Realm.Library.Common.Events;
using Realm.Library.Common.Extensions;
using Realm.Library.Common.Logging;
using Realm.Library.Common.Objects;

namespace Realm.Command
{
    public sealed class CommandManager : GameSingleton, ICommandManager
    {
        private Dictionary<string, IParser> _parsers;

        public IVariableHelper VariableHelper { get; }
        public IHelper<Action> CommandHelper { get; }
        public CommandExecutor CommandExecutor { get; private set; }
        public CommandRepository CommandRepository { get; }
        public CommandInitializer CommandInitializer { get; }
        [Inject]
        public IEventManager EventManager { get; set; }
        [Inject]
        public ILogWrapper Log { get; set; }
        public DictionaryAtom InitializationAtom { get; private set; }

        public CommandManager(IVariableHelper variableHelper, [Named("CommandHelper")] IHelper<Action> commandHelper, 
            ICommandRepository commandRepository, ICommandInitializer commandInitializer)
        {
            VariableHelper = variableHelper;
            CommandHelper = commandHelper;
            CommandRepository = (CommandRepository)commandRepository;
            CommandInitializer = (CommandInitializer) commandInitializer;
        }

        public void OnInit(DictionaryAtom initAtom)
        {
            InitializationAtom = initAtom;

            var kernel = (IKernel)initAtom.GetObject("Ninject.Kernel");

            CommandExecutor = (CommandExecutor)kernel.Get<ICommandExecutor>();

            _parsers = new Dictionary<string, IParser>
                           {
                               {"Command", kernel.Get<IParser>("CommandParser")},
                               {"Social", kernel.Get<IParser>("SocialCommandParser")},
                               {"Channel", kernel.Get<IParser>("PlayerChannelParser")},
                               {"Movement", kernel.Get<IParser>("MovementParser")}
                           };
            Log.DebugFormat("CommandManager registered {0} parsers.", _parsers.Count);

            VariableHelper.RegisterVariables();
            Log.DebugFormat("CommandManager registered {0} variables.", VariableHelper.Count);

            Log.DebugFormat("{0} setup.", GetType());
            EventManager.RegisterListener(this, typeof(OnGameInitialize), Instance_OnGameInitialize);
        }

        public override void Instance_OnGameInitialize(RealmEventArgs args)
        {
            CommandInitializer.OnInit(InitializationAtom);
            Log.DebugFormat("{0} commands registered with the initializer.", CommandRepository.Count);

            base.Instance_OnGameInitialize(args);
        }

        private void SetPropertiesOnGameManager(string verb, string phrase)
        {
            var game = InitializationAtom.GetObject("Game").CastAs<IGameEntity>();
            game.GetPropertyContext().SetProperty("last command verb", verb);
            game.GetPropertyContext().SetProperty("last command string", phrase);
            game.GetPropertyContext().SetProperty("last command", $"{verb} {phrase}");
        }

        private static void SetPropertiesOnUser(IGameEntity user, string verb, string phrase)
        {
            user.GetPropertyContext().SetProperty("last command verb", verb);
            user.GetPropertyContext().SetProperty("last command string", phrase);
            user.GetPropertyContext().SetProperty("last command", $"{verb} {phrase}");
        }

        public Parser GetParser(string name)
        {
            IParser value;
            return _parsers.TryGetValue(name, out value) ? (Parser)value : null;
        }

        public bool Execute(IGameEntity entity, string command)
        {
            return Execute(entity, command.FirstWord(), command.RemoveWord(0));
        }

        public bool Execute(IGameEntity entity, string verb, string phrase)
        {
            SetPropertiesOnGameManager(verb, phrase);
            SetPropertiesOnUser(entity, verb, phrase);

            return CommandExecutor.Execute(entity, verb, phrase);
        }

        public void Report(Globals.MessageScopeTypes scope, string message, IEntity oActor,
            IEntity oVictim = null, object oDirectObject = null, object oIndirectObject = null,
            IGameEntity oSpace = null, object oExtra = null)
        {
            CommandExecutor.Report(scope, message, oActor, oVictim, oDirectObject, oIndirectObject, oSpace, oExtra);
        }

        public void Report(Globals.MessageScopeTypes scope, string message, ReportData data)
        {
            CommandExecutor.Report(scope, message, data);
        }
    }
}