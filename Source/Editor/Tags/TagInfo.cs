namespace Realm.Edit.Tags
{
    public class TagInfo
    {
        public string Name { get; set; }
        public int Id { get; private set; }
        public int Value { get; set; }
        public int Value2 { get; set; }

        public TagInfo(string name, int id, int value)
        {
            Init(name, id, value, 0);
        }

        public TagInfo(string name, int id, int value, int value2)
        {
            Init(name, id, value, value2);
        }

        private void Init(string name, int id, int value, int value2)
        {
            Name = name;
            Id = id;
            Value = value;
            Value2 = value2;
        }

        /// <summary>
        /// This is necessary for the DataGridView
        /// http://mikehadlow.blogspot.com/2006/09/problems-with-datagridviewcomboboxcolu.html
        /// </summary>
        public TagInfo This => this;

        public override string ToString()
        {
            return Name;
        }
    }
}
