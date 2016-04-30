using System.Collections.Generic;
using Realm.Library.Common.Data;
using Realm.Library.Common.Extensions;

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

        public string DisplayName => Def.GetString("DisplayName");

        public string DisplayDescription => Def.GetString("DisplayDescription");

        public int TagSetID => Def.GetInt("TagSetID");

        public int Timer => Def.GetInt("Timer");

        public bool Cancellable => Globals.QuestBits.Cancellable.HasBit(Def.GetInt("Bits"));

        public bool FailOnDeath => Globals.QuestBits.FailOnDeath.HasBit(Def.GetInt("Bits"));

        public bool FailOnTimerExpire => Globals.QuestBits.FailOnTimerExpire.HasBit(Def.GetInt("Bits"));

        public IEnumerable<Atom> Actions => Def.GetAtom<ListAtom>("Actions");

        public IEnumerable<Atom> Progress => Def.GetAtom<ListAtom>("Progress");

        public IEnumerable<Atom> Requirements => Def.GetAtom<ListAtom>("Requirements");
    }
}