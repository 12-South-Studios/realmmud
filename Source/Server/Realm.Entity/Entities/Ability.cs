using System;
using Realm.Data.Definitions;
using Realm.Library.Common.Objects;

namespace Realm.Entity.Entities
{
    /// <summary>
    ///
    /// </summary>
    public class Ability : GameEntity
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="def"></param>
        public Ability(long id, string name, Definition def)
            : base(id, name, def)
        {
        }

        /// <summary>
        ///
        /// </summary>
        public AbilityDef AbilityDef => Definition.CastAs<AbilityDef>();

        /// <summary>
        ///
        /// </summary>
        public DateTime LastUse { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public bool CanBeUsed()
        {
            // TODO: Check recharge rate

            return false;
        }
    }
}