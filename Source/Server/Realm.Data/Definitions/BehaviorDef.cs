using Realm.Library.Common;
using Realm.Library.Common.Data;

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

        public int TagSet
        {
            get { return Def.GetInt("TagSetID"); }
        }

        public bool Aggressive
        {
            get { return Globals.Globals.BehaviorBits.Aggressive.HasBit(Def.GetInt("Bits")); }
        }

        public bool Berserker
        {
            get { return Globals.Globals.BehaviorBits.Berserker.HasBit(Def.GetInt("Bits")); }
        }

        public bool Grazer
        {
            get { return Globals.Globals.BehaviorBits.Grazer.HasBit(Def.GetInt("Bits")); }
        }

        public bool Guard
        {
            get { return Globals.Globals.BehaviorBits.Guard.HasBit(Def.GetInt("Bits")); }
        }

        public bool NonCombatant
        {
            get { return Globals.Globals.BehaviorBits.NonCombatant.HasBit(Def.GetInt("Bits")); }
        }

        public bool Scavenger
        {
            get { return Globals.Globals.BehaviorBits.Scavenger.HasBit(Def.GetInt("Bits")); }
        }

        public bool Sentinel
        {
            get { return Globals.Globals.BehaviorBits.Sentinel.HasBit(Def.GetInt("Bits")); }
        }

        public bool StayArea
        {
            get { return Globals.Globals.BehaviorBits.StayArea.HasBit(Def.GetInt("Bits")); }
        }

        public bool Wimpy
        {
            get { return Globals.Globals.BehaviorBits.Wimpy.HasBit(Def.GetInt("Bits")); }
        }
    }
}