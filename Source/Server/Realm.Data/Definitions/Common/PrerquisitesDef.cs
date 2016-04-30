using Realm.Library.Common.Data;
using Realm.Library.Common.Extensions;

namespace Realm.Data.Definitions.Common

{
    public class PrerquisitesDef : SubDefinition
    {
        public PrerquisitesDef(long id, DictionaryAtom definition)
            : base(id, definition)
        {
        }

        public int MinLevel => Def.GetInt("MinLevel");

        public int RaceID => Def.GetInt("RaceID");

        public int FactionID => Def.GetInt("FactionID");

        public int FactionLevel => Def.GetInt("FactionLevel");

        public Globals.Statistics Statistic => EnumerationExtensions.GetEnum<Globals.Statistics>(Def.GetInt("StatisticID"));

        public int StatisticValue => Def.GetInt("StatisticValue");

        public int SkillID => Def.GetInt("SkillID");

        public int SkillValue => Def.GetInt("SkillValue");
    }
}