using System.Collections.Generic;
using Realm.Library.Common.Data;

namespace Realm.Data.Definitions
{
    /// <summary>
    ///
    /// </summary>
    public class TreasureDef : Definition
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="definition"></param>
        public TreasureDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        public IEnumerable<Atom> Primitives { get { return Def.GetAtom<ListAtom>("Primitives"); } }
    }
}