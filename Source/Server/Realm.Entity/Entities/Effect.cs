using Realm.Data.Definitions;
using Realm.Library.Common;
using Realm.Library.Common.Data;

namespace Realm.Entity.Entities
{
    /// <summary>
    ///
    /// </summary>
    public class Effect : GameEntity
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="def"></param>
        public Effect(long id, string name, Definition def)
            : base(id, name, def)
        {
        }

        /// <summary>
        ///
        /// </summary>
        public EffectDef EffectDef { get { return Definition.CastAs<EffectDef>(); } }

        /// <summary>
        ///
        /// </summary>
        public new void OnInit(DictionaryAtom initAtom)
        {
            base.OnInit(initAtom);
        }
    }
}