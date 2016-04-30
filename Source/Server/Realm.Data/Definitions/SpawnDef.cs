using System.Collections.Generic;
using Realm.Library.Common.Data;
using Realm.Library.Common.Extensions;

namespace Realm.Data.Definitions
{
    /// <summary>
    ///
    /// </summary>
    public class SpawnDef : Definition
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="definition"></param>
        public SpawnDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        public int MinQuantity => Def.GetInt("MinQuantity");

        public int MaxQuantity => Def.GetInt("MaxQuantity");

        public int Chance => Def.GetInt("Chance");

        public int RespawnPeriod => Def.GetInt("RespawnPeriod");

        public Globals.SpawnTypes SpawnType => EnumerationExtensions.GetEnum<Globals.SpawnTypes>(Def.GetInt("SpawnTypeID"));

        public int TagSetID => Def.GetInt("TagSetID");

        public IEnumerable<Atom> Locations => Def.GetAtom<ListAtom>("Locations");

        public IEnumerable<Atom> Primitives => Def.GetAtom<ListAtom>("Primitives");
    }
}