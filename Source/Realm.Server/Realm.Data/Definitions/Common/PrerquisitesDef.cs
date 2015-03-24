using Realm.Library.Common;
using Realm.Library.Common.Data;

// ReSharper disable CheckNamespace
namespace Realm.Data.Definitions
// ReSharper restore CheckNamespace
{
    public class PrerquisitesDef : SubDefinition
    {
        public PrerquisitesDef(long id, DictionaryAtom definition)
            : base(id, definition)
        {
        }

        public int MinLevel { get { return Def.GetInt("MinLevel"); } }

        public int RaceID { get { return Def.GetInt("RaceID"); } }

        public int FactionID { get { return Def.GetInt("FactionID"); } }

        public int FactionLevel { get { return Def.GetInt("FactionLevel"); } }

        public Globals.Globals.Statistics Statistic
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.Statistics>(Def.GetInt("StatisticID")); }
        }

        public int StatisticValue { get { return Def.GetInt("StatisticValue"); } }

        public int SkillID { get { return Def.GetInt("SkillID"); } }

        public int SkillValue { get { return Def.GetInt("SkillValue"); } }
    }
}