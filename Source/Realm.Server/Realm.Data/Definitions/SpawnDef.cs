using System.Collections.Generic;
using Realm.Library.Common;
using Realm.Library.Common.Data;

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

        public int MinQuantity { get { return Def.GetInt("MinQuantity"); } }

        public int MaxQuantity { get { return Def.GetInt("MaxQuantity"); } }

        public int Chance { get { return Def.GetInt("Chance"); } }

        public int RespawnPeriod { get { return Def.GetInt("RespawnPeriod"); } }

        public Globals.Globals.SpawnTypes SpawnType
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.SpawnTypes>(Def.GetInt("SpawnTypeID")); }
        }

        public int TagSetID { get { return Def.GetInt("TagSetID"); } }

        public IEnumerable<Atom> Locations { get { return Def.GetAtom<ListAtom>("Locations"); } }

        public IEnumerable<Atom> Primitives { get { return Def.GetAtom<ListAtom>("Primitives"); } }
    }
}