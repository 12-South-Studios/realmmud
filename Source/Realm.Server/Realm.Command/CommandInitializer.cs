using System;
using System.Linq;
using Ninject;
using Realm.Command.Interfaces;
using Realm.Data.Definitions;
using Realm.Data.Interfaces;
using Realm.Library.Common;
using Realm.Library.Common.Data;

namespace Realm.Command
{
    /// <summary>
    ///
    /// </summary>
    public class CommandInitializer : ICommandInitializer
    {
        private IHelper<Action> Helper { get; set; }
        private readonly IStaticDataManager _staticDataManager;

        ///  <summary>
        /// 
        ///  </summary>
        ///  <param name="repository"></param>
        ///  <param name="helper"></param>
        /// <param name="staticDataManager"></param>
        public CommandInitializer(ICommandRepository repository, [Named("CommandHelper")] IHelper<Action> helper, 
            IStaticDataManager staticDataManager)
        {
            Repository = (CommandRepository)repository;
            Helper = helper;
            _staticDataManager = staticDataManager;
        }

        /// <summary>
        ///
        /// </summary>
        private CommandRepository Repository { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="initAtom"></param>
        public void OnInit(DictionaryAtom initAtom)
        {
            var commands = _staticDataManager.GetStaticData(Globals.Globals.SystemTypes.GameCommand);
            commands.Keys.ToList().ForEach(command => Repository.Add(command,
                                                                     new Tuple<Action, Definition>(Helper.Get(command),
                                                                                                   commands[command])));
        }
    }
}