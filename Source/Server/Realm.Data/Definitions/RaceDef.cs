using System.Collections.Generic;
using Realm.Library.Common;
using Realm.Library.Common.Data;

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

        public string DisplayName { get { return Def.GetString("DisplayName"); } }

        public string DisplayDescription { get { return Def.GetString("DisplayDescription"); } }

        public Globals.Globals.SizeTypes Size
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.SizeTypes>(Def.GetInt("SizeTypeID")); }
        }

        public int BaseHealth { get { return Def.GetInt("BaseHealth"); } }

        public int BaseMana { get { return Def.GetInt("BaseMana"); } }

        public int BaseStamina { get { return Def.GetInt("BaseStamina"); } }

        public string Abbreviation { get { return Def.GetString("Abbreviation"); } }

        public int TagSetID { get { return Def.GetInt("TagSetID"); } }

        public bool DetectInvisible
        {
            get { return Globals.Globals.RaceBits.DetectInvisible.HasBit(Def.GetInt("Bits")); }
        }

        public bool DetectHidden
        {
            get { return Globals.Globals.RaceBits.DetectHidden.HasBit(Def.GetInt("Bits")); }
        }

        public bool Infravision
        {
            get { return Globals.Globals.RaceBits.Infravision.HasBit(Def.GetInt("Bits")); }
        }

        public bool MoveSilently
        {
            get { return Globals.Globals.RaceBits.MoveSilently.HasBit(Def.GetInt("Bits")); }
        }

        public IEnumerable<Atom> Abilities
        {
            get { return Def.GetAtom<ListAtom>("Abilities"); }
        }

        public IEnumerable<Atom> HitLocations
        {
            get { return Def.GetAtom<ListAtom>("HitLocations"); }
        }

        public IEnumerable<Atom> Statistics
        {
            get { return Def.GetAtom<ListAtom>("Statistics"); }
        }
    }
}