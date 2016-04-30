using Realm.Command.Interfaces;
using Realm.Entity.Interfaces;
using Realm.Library.Ai;
using Realm.Library.Common.Data;
using Realm.Library.Common.Logging;

namespace Realm.Ai.States
{
    public abstract class BaseAiState : AiState
    {
        protected BaseAiState(string name, IAiAgent parent, DictionaryAtom initAtom)
            : base(name, parent)
        {
            //CommandManager = cmdManager;
            //Log = logger;
            //Game = game;
        }

        protected ICommandManager CommandManager { get; private set; }
        protected ILogWrapper Log { get; private set; }
        protected IGame Game { get; private set; }
    }
}
