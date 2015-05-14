using System;
using Realm.Command.Interfaces;
using Realm.Data.Definitions;
using Realm.Library.Patterns.Repository;

namespace Realm.Command
{
    public class CommandRepository : Repository<string, Tuple<Action, Definition>>, ICommandRepository
    {
    }
}