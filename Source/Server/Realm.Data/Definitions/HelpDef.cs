using Realm.Library.Common.Data;

namespace Realm.Data.Definitions
{
    /// <summary>
    /// Definition of an Archetype
    /// </summary>
    public class HelpDef : Definition
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public HelpDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        public string DisplayName => Def.GetString("DisplayName");

        public string Keywords => Def.GetString("Keywords");

        public string Text => Def.GetString("Text");
    }
}