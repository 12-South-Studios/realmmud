using System;
using System.Linq;
using Realm.Command.Interfaces;
using Realm.Entity;
using Realm.Entity.Entities;
using Realm.Library.Common;

namespace Realm.Command.Parsers
{
    public class MovementParser : Parser
    {
        public MovementParser(ICommandManager commandManager)
            : base(commandManager)
        {
        }

        /// <summary>
        /// Checks the validity of movement commands for each direction out of the current space
        /// </summary>
        public static bool CheckMovementCommands(IGameEntity entity, string verb)
        {
            Validation.IsNotNull(entity, "entity");
            Validation.IsNotNull(entity.Location, "entity.Location");

            var space = entity.Location.CastAs<Space>();
            const string delimeter = ";";

            return space.Portals.Select(portal => portal.Keywords.Split(delimeter.ToCharArray(),
                                                                        StringSplitOptions.RemoveEmptyEntries))
                .Select(words => words.Any(x => x.Equals(verb, StringComparison.OrdinalIgnoreCase))).FirstOrDefault();
        }
    }
}