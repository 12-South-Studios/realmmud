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

        public string DisplayName { get { return Def.GetString("DisplayName"); } }

        public string Keywords { get { return Def.GetString("Keywords"); } }

        public string Text { get { return Def.GetString("Text"); } }
    }
}