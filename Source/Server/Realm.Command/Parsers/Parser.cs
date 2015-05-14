using Realm.Command.Interfaces;

namespace Realm.Command.Parsers
{
    public abstract class Parser : IParser
    {
        protected CommandManager CommandManager { get; private set; }

        protected Parser(ICommandManager commandManager)
        {
            CommandManager = (CommandManager)commandManager;
        }
    }
}