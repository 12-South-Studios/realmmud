using System;
using Realm.Command.Interfaces;
using Realm.Data.Definitions;
using Realm.Standard.Patterns.Repository;

namespace Realm.Command
{
    public class CommandRepository : Repository<string, Tuple<Action, Definition>>, ICommandRepository
    {
    }
}