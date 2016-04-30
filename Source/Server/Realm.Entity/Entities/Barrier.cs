using Realm.Data.Definitions;
using Realm.Library.Common.Objects;

namespace Realm.Entity.Entities
{
    /// <summary>
    ///
    /// </summary>
    public class Barrier : GameEntity
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="def"></param>
        public Barrier(long id, string name, Definition def)
            : base(id, name, def)
        {
        }

        /// <summary>
        ///
        /// </summary>
        public BarrierDef BarrierDef => Definition.CastAs<BarrierDef>();

        // TODO: State of the Barrier
    }
}