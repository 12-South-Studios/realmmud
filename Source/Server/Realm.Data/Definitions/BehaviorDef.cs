using Realm.Library.Common.Data;
using Realm.Library.Common.Extensions;

namespace Realm.Data.Definitions
{
    /// <summary>
    /// Definition of an Archetype
    /// </summary>
    public class BehaviorDef : Definition
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BehaviorDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        public int TagSet => Def.GetInt("TagSetID");

        public bool Aggressive => Globals.BehaviorBits.Aggressive.HasBit(Def.GetInt("Bits"));

        public bool Berserker => Globals.BehaviorBits.Berserker.HasBit(Def.GetInt("Bits"));

        public bool Grazer => Globals.BehaviorBits.Grazer.HasBit(Def.GetInt("Bits"));

        public bool Guard => Globals.BehaviorBits.Guard.HasBit(Def.GetInt("Bits"));

        public bool NonCombatant => Globals.BehaviorBits.NonCombatant.HasBit(Def.GetInt("Bits"));

        public bool Scavenger => Globals.BehaviorBits.Scavenger.HasBit(Def.GetInt("Bits"));

        public bool Sentinel => Globals.BehaviorBits.Sentinel.HasBit(Def.GetInt("Bits"));

        public bool StayArea => Globals.BehaviorBits.StayArea.HasBit(Def.GetInt("Bits"));

        public bool Wimpy => Globals.BehaviorBits.Wimpy.HasBit(Def.GetInt("Bits"));
    }
}