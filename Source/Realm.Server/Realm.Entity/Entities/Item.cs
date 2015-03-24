using Realm.Data.Definitions;
using Realm.Library.Common;

namespace Realm.Entity.Entities
{
    /// <summary>
    ///
    /// </summary>
    public class Item : GameEntity
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="def"></param>
        public Item(long id, string name, Definition def)
            : base(id, name, def)
        {
        }

        /// <summary>
        ///
        /// </summary>
        public ItemDef ItemDef
        {
            get { return Definition.CastAs<ItemDef>(); }
        }
    }
}