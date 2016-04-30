using System;
using System.Linq;
using Ninject;
using Realm.Command.Interfaces;
using Realm.Data;
using Realm.Data.Definitions;
using Realm.Data.Interfaces;
using Realm.Library.Common.Data;
using Realm.Library.Common.Entities;

namespace Realm.Command
{
    public class CommandInitializer : ICommandInitializer
    {
        private IHelper<Action> Helper { get; set; }
        private readonly IStaticDataManager _staticDataManager;
        private CommandRepository Repository { get; set; }

        public CommandInitializer(ICommandRepository repository, [Named("CommandHelper")] IHelper<Action> helper, 
            IStaticDataManager staticDataManager)
        {
            Repository = (CommandRepository)repository;
            Helper = helper;
            _staticDataManager = staticDataManager;
        }

        public void OnInit(DictionaryAtom initAtom)
        {
            var commands = _staticDataManager.GetStaticData(Globals.SystemTypes.GameCommand);
            commands.Keys.ToList().ForEach(command => Repository.Add(command,
                new Tuple<Action, Definition>(Helper.Get(command), commands[command])));
        }
    }
}