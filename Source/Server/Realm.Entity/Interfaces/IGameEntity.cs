using Realm.Data.Definitions;
using Realm.Library.Common.Contexts;
using Realm.Library.Common.Entities;

namespace Realm.Entity.Interfaces
{
    public interface IGameEntity : IEntity, IInitializable
    {
        Definition Definition { get; set; }

        string Description { get; set; }

        string LongName { get; set; }

        string PluralName { get; set; }

        IGameEntity Location { get; set; }

        IContext GetContext(string typeName);
    }
}