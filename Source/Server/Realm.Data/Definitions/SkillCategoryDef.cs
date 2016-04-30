using Realm.Library.Common.Data;
using Realm.Library.Common.Extensions;

namespace Realm.Data.Definitions
{
    /// <summary>
    /// Definition of an Archetype
    /// </summary>
    public class SkillCategoryDef : Definition
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SkillCategoryDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        public string DisplayName => Def.GetString("DisplayName");

        public Globals.Statistics Statistic => EnumerationExtensions.GetEnum<Globals.Statistics>(Def.GetInt("StatisticID"));
    }
}