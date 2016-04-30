using System.Collections.Generic;
using Realm.Library.Common.Data;
using Realm.Library.Common.Extensions;

namespace Realm.Data.Definitions
{
    /// <summary>
    /// Definition of an Archetype
    /// </summary>
    public class RaceDef : Definition
    {
        /// <summary>
        /// Chann
        /// </summary>
        public RaceDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        public string DisplayName => Def.GetString("DisplayName");

        public string DisplayDescription => Def.GetString("DisplayDescription");

        public Globals.SizeTypes Size => EnumerationExtensions.GetEnum<Globals.SizeTypes>(Def.GetInt("SizeTypeID"));

        public int BaseHealth => Def.GetInt("BaseHealth");

        public int BaseMana => Def.GetInt("BaseMana");

        public int BaseStamina => Def.GetInt("BaseStamina");

        public string Abbreviation => Def.GetString("Abbreviation");

        public int TagSetID => Def.GetInt("TagSetID");

        public bool DetectInvisible => Globals.RaceBits.DetectInvisible.HasBit(Def.GetInt("Bits"));

        public bool DetectHidden => Globals.RaceBits.DetectHidden.HasBit(Def.GetInt("Bits"));

        public bool Infravision => Globals.RaceBits.Infravision.HasBit(Def.GetInt("Bits"));

        public bool MoveSilently => Globals.RaceBits.MoveSilently.HasBit(Def.GetInt("Bits"));

        public IEnumerable<Atom> Abilities => Def.GetAtom<ListAtom>("Abilities");

        public IEnumerable<Atom> HitLocations => Def.GetAtom<ListAtom>("HitLocations");

        public IEnumerable<Atom> Statistics => Def.GetAtom<ListAtom>("Statistics");
    }
}