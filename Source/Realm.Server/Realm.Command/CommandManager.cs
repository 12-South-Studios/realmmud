using System;
using System.Collections.Generic;
using Ninject;
using Realm.Command.Interfaces;
using Realm.Command.Parsers;
using Realm.Entity;
using Realm.Event;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Logging;

namespace Realm.Command
{
    /// <summary>
    ///
    /// </summary>
    public sealed class CommandManager : GameSingleton, ICommandManager
    {
        private Dictionary<string, IParser> _parsers;

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public IVariableHelper VariableHelper { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public IHelper<Action> CommandHelper { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public CommandExecutor CommandExecutor { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public CommandRepository CommandRepository { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public CommandInitializer CommandInitializer { get; private set; }

        #endregion Properties

        public CommandManager(IVariableHelper variableHelper, [Named("CommandHelper")] IHelper<Action> commandHelper, 
            ICommandRepository commandRepository, ICommandInitializer commandInitializer)
        {
            VariableHelper = variableHelper;
            CommandHelper = commandHelper;
            CommandRepository = (CommandRepository)commandRepository;
            CommandInitializer = (CommandInitializer) commandInitializer;
        }

        [Inject]
        public IEventManager EventManager { get; set; }

        [Inject]
        public ILogWrapper Log { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DictionaryAtom InitializationAtom { get; private set; }


        /// <summary>
        ///
        /// </summary>
        /// <param name="initAtom"></param>
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
            game.GetPropertyContext().SetProperty("last command", String.Format("{0} {1}", verb, phrase));
        }

        private static void SetPropertiesOnUser(IGameEntity user, string verb, string phrase)
        {
            user.GetPropertyContext().SetProperty("last command verb", verb);
            user.GetPropertyContext().SetProperty("last command string", phrase);
            user.GetPropertyContext().SetProperty("last command", String.Format("{0} {1}", verb, phrase));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Parser GetParser(string name)
        {
            return _parsers.ContainsKey(name) ? (Parser)_parsers[name] : null;
        }

        #region Command Executor

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool Execute(IGameEntity entity, string command)
        {
            return Execute(entity, command.FirstWord(), command.RemoveWord(0));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="verb"></param>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public bool Execute(IGameEntity entity, string verb, string phrase)
        {
            SetPropertiesOnGameManager(verb, phrase);
            SetPropertiesOnUser(entity, verb, phrase);

            return CommandExecutor.Execute(entity, verb, phrase);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="message"></param>
        /// <param name="oActor"></param>
        /// <param name="oVictim"></param>
        /// <param name="oDirectObject"></param>
        /// <param name="oIndirectObject"></param>
        /// <param name="oSpace"></param>
        /// <param name="oExtra"></param>
        public void Report(Globals.Globals.MessageScopeTypes scope, string message, IEntity oActor,
            IEntity oVictim = null, object oDirectObject = null, object oIndirectObject = null,
            IGameEntity oSpace = null, object oExtra = null)
        {
            CommandExecutor.Report(scope, message, oActor, oVictim, oDirectObject, oIndirectObject, oSpace, oExtra);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        public void Report(Globals.Globals.MessageScopeTypes scope, string message, ReportData data)
        {
            CommandExecutor.Report(scope, message, data);
        }

        #endregion Command Executor
    }
}