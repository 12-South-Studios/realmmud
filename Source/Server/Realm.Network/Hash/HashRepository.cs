using System.Linq;
using Realm.Standard.Patterns.Repository;

namespace Realm.Network.Hash
{
    /// <summary>
    ///
    /// </summary>
    public class HashRepository : Repository<long, Hash>, IHashRepository
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public Hash GetRandomValue()
        {
            var values = Values.ToList();
            return values[Library.Common.Random.Between(0, Count - 1)];
        }
    }
}