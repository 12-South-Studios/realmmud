using Realm.Library.Common.Data;

namespace Realm.Data.Definitions
{
    /// <summary>
    /// Definition of an Archetype
    /// </summary>
    public class SocialDef : Definition
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SocialDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        public string DisplayName { get { return Def.GetString("DisplayName"); } }

        public string CharNoArg { get { return Def.GetString("CharNoArg"); } }

        public string OthersNoArg { get { return Def.GetString("OthersNoArg"); } }

        public string CharFound { get { return Def.GetString("CharFound"); } }

        public string OthersFound { get { return Def.GetString("OthersFound"); } }

        public string VictFound { get { return Def.GetString("VictFound"); } }

        public string CharAuto { get { return Def.GetString("CharAuto"); } }

        public string OthersAuto { get { return Def.GetString("OthersAuto"); } }
    }
}