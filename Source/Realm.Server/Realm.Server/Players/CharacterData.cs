namespace Realm.Server.Players
{
    public class CharacterData
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public long LocationID { get; set; }
        public string LastLogin { get; set; }
        public int Level { get; set; }
        public string Archetype { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
    }
}
