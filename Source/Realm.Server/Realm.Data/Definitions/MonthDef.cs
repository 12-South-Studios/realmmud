using System.Collections.Generic;
using Realm.Library.Common;
using Realm.Library.Common.Data;

namespace Realm.Data.Definitions
{
    /// <summary>
    /// Definition of an Archetype
    /// </summary>
    public class MonthDef : Definition
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MonthDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        public string DisplayName { get { return Def.GetString("DisplayName"); } }

        public int NumberOfDays { get { return Def.GetInt("NumberDays"); } }

        public Globals.Globals.SeasonTypes Season
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.SeasonTypes>(Def.GetInt("SeasonTypeID")); }
        }

        public bool IsShrouding { get { return Def.GetBool("IsShrouding"); } }

        public IEnumerable<Atom> Effects
        {
            get { return Def.GetAtom<ListAtom>("Effects"); }
        }
    }
}