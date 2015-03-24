using Realm.Command.Interfaces;
using Realm.Command.Parsers;
using Realm.Library.Common;
using Realm.Library.Common.Data;

namespace Realm.Command
{
    public class CommandModule  : NinjectGameModule
    {
        public CommandModule(DictionaryAtom initAtom, BooleanSet initBooleanSet) : base(initAtom, initBooleanSet)
        {
        }

        public override void Load()
        {
            Bind<ICommandRepository>().To<CommandRepository>();
            Bind<ICommandExecutor>().To<CommandExecutor>();
            Bind<ICommandInitializer>().To<CommandInitializer>();
            Bind<IParser>().To<CommandParser>().Named("CommandParser");
            Bind<IParser>().To<MovementParser>().Named("MovementParser");
            Bind<IParser>().To<MovementParser>().Named("SocialCommandParser");
            Bind<IParser>().To<MovementParser>().Named("PlayerChannelParser");

            Bind<ICommandManager>().To<CommandManager>()
                .InSingletonScope()
                .OnActivation(x =>
                {
                    InitBooleanSet.AddItem("CommandManager");
                    x.OnInit(InitAtom);
                    InitAtom.Set("CommandManager", x);
                });
        }
    }
}
