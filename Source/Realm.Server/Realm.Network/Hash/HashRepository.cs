using System.Collections.Generic;
using System.Linq;
using Realm.Library.Patterns.Repository;

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
            List<Hash> values = Values.ToList();
            return values[Library.Common.Random.Between(0, Count - 1)];
        }
    }
}