using Realm.Data.Interfaces;
using Realm.Data.Loaders;
using Realm.Library.Patterns.Repository;

namespace Realm.Data
{
    /// <summary>
    /// Stores loader objects indexed by Globals.Globals.SystemTypes value
    /// </summary>
    public class LoaderRepository : Repository<int, ILoader>, ILoaderRepository
    {
    }
}