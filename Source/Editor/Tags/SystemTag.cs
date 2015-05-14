namespace Realm.Edit.Tags
{
    public class SystemTag
    {
        public int Id { get; private set; }
        public string Name { get; set; }

        public SystemTag(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
