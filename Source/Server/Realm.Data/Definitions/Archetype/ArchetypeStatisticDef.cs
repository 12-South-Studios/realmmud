using Realm.Data.Definitions.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Extensions;

namespace Realm.Data.Definitions.Archetype

{
    public class ArchetypeStatisticDef : SubDefinition
    {
        public ArchetypeStatisticDef(long id, DictionaryAtom definition)
            : base(id, definition)
        {
        }

        public Globals.Statistics Statistic => EnumerationExtensions.GetEnum<Globals.Statistics>(Def.GetInt("StatisticID"));

        public int SkillID => Def.GetInt("SkillID");

        public int ModValue => Def.GetInt("ModValue");

        public bool IsExempt => Def.GetBool("IsExempt");
    }
}