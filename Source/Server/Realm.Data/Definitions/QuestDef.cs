using System.Collections.Generic;
using Realm.Library.Common;
using Realm.Library.Common.Data;

namespace Realm.Data.Definitions
{
    /// <summary>
    /// Definition of an Archetype
    /// </summary>
    public class QuestDef : Definition
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public QuestDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        public string DisplayName { get { return Def.GetString("DisplayName"); } }

        public string DisplayDescription { get { return Def.GetString("DisplayDescription"); } }

        public int TagSetID { get { return Def.GetInt("TagSetID"); } }

        public int Timer { get { return Def.GetInt("Timer"); } }

        public bool Cancellable
        {
            get { return Globals.Globals.QuestBits.Cancellable.HasBit(Def.GetInt("Bits")); }
        }

        public bool FailOnDeath
        {
            get { return Globals.Globals.QuestBits.FailOnDeath.HasBit(Def.GetInt("Bits")); }
        }

        public bool FailOnTimerExpire
        {
            get { return Globals.Globals.QuestBits.FailOnTimerExpire.HasBit(Def.GetInt("Bits")); }
        }

        public IEnumerable<Atom> Actions
        {
            get { return Def.GetAtom<ListAtom>("Actions"); }
        }

        public IEnumerable<Atom> Progress
        {
            get { return Def.GetAtom<ListAtom>("Progress"); }
        }

        public IEnumerable<Atom> Requirements
        {
            get { return Def.GetAtom<ListAtom>("Requirements"); }
        }
    }
}