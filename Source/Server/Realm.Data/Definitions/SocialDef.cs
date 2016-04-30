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

        public string DisplayName => Def.GetString("DisplayName");

        public string CharNoArg => Def.GetString("CharNoArg");

        public string OthersNoArg => Def.GetString("OthersNoArg");

        public string CharFound => Def.GetString("CharFound");

        public string OthersFound => Def.GetString("OthersFound");

        public string VictFound => Def.GetString("VictFound");

        public string CharAuto => Def.GetString("CharAuto");

        public string OthersAuto => Def.GetString("OthersAuto");
    }
}