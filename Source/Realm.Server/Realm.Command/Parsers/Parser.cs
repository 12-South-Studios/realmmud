using Realm.Command.Interfaces;

namespace Realm.Command.Parsers
{
    /// <summary>
    ///
    /// </summary>
    public abstract class Parser : IParser
    {
        protected CommandManager CommandManager { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="commandManager"></param>
        protected Parser(ICommandManager commandManager)
        {
            CommandManager = (CommandManager)commandManager;
        }
    }
}