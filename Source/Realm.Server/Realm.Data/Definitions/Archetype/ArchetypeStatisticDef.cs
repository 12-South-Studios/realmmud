using Realm.Library.Common;
using Realm.Library.Common.Data;

// ReSharper disable CheckNamespace
namespace Realm.Data.Definitions
// ReSharper restore CheckNamespace
{
    public class ArchetypeStatisticDef : SubDefinition
    {
        public ArchetypeStatisticDef(long id, DictionaryAtom definition)
            : base(id, definition)
        {
        }

        public Globals.Globals.Statistics Statistic
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.Statistics>(Def.GetInt("StatisticID")); }
        }

        public int SkillID { get { return Def.GetInt("SkillID"); } }

        public int ModValue { get { return Def.GetInt("ModValue"); } }

        public bool IsExempt { get { return Def.GetBool("IsExempt"); } }
    }
}