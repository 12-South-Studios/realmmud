namespace Realm.Server
{
    public class PrerequisiteMap
    {
        public int MinLevel { get; set; }
        public int RaceID { get; set; }
        public int FactionID { get; set; }
        public int FactionLevel { get; set; }
        public Globals.Globals.Statistics Statistic { get; set; }
        public int StatisticValue { get; set; }
        public int SkillID { get; set; }
        public int SkillValue { get; set; }
    }
}
