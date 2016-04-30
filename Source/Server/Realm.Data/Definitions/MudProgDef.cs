using Realm.Library.Common.Data;

namespace Realm.Data.Definitions
{
    /// <summary>
    /// Definition of an Archetype
    /// </summary>
    public class MudProgDef : Definition
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MudProgDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        public string Data => Def.GetString("Data");
    }
}