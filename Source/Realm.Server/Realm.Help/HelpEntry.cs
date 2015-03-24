using Realm.Library.Common;

namespace Realm.Help
{
    public class HelpEntry : Cell
    {
        public HelpEntry(long id, string name)
        {
            ID = id;
            Name = name;
        }

        public HelpEntry(long id, string name, string keyword, string data, string category)
        {
            ID = id;
            Name = name;
            Keyword = keyword;
            Data = data;
            Category = category;
        }

        public string Keyword { get; private set; }
        public string Data { get; private set; }
        public string Category { get; private set; }
    }
}
