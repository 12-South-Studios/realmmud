namespace Realm.Edit.Tags
{
    public class TagInfo
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Value { get; set; }
        public int Value2 { get; set; }

        public TagInfo(string aName, int aId, int aValue)
        {
            Init(aName, aId, aValue, 0);
        }

        public TagInfo(string aName, int aId, int aValue, int aValue2)
        {
            Init(aName, aId, aValue, aValue2);
        }

        private void Init(string aName, int aId, int aValue, int aValue2)
        {
            Name = aName;
            Id = aId;
            Value = aValue;
            Value2 = aValue2;
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
