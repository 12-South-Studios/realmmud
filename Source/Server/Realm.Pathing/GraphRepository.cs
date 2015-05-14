using Realm.Library.Patterns.Repository;
using Realm.Pathing.Core;
using Realm.Pathing.Interfaces;

namespace Realm.Pathing
{
    public class GraphRepository : Repository<long, Graph>, IGraphRepository
    {
    }
}