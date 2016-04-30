using System.Collections.Generic;
using Realm.Library.Common.Data;
using Realm.Library.Common.Extensions;

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

        public string DisplayName => Def.GetString("DisplayName");

        public int NumberOfDays => Def.GetInt("NumberDays");

        public Globals.SeasonTypes Season => EnumerationExtensions.GetEnum<Globals.SeasonTypes>(Def.GetInt("SeasonTypeID"));

        public bool IsShrouding => Def.GetBool("IsShrouding");

        public IEnumerable<Atom> Effects => Def.GetAtom<ListAtom>("Effects");
    }
}