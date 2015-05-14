using Realm.Library.Common;
using Realm.Library.Common.Data;

namespace Realm.Data.Definitions
{
    /// <summary>
    /// Definition of an Archetype
    /// </summary>
    public class ChannelDef : Definition
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ChannelDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        public string DisplayName { get { return Def.GetString("DisplayName"); } }

        public Globals.Globals.ChannelTypes ChannelType
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.ChannelTypes>(Def.GetInt("ChannelTypeID")); }
        }

        public bool ReadOnly
        {
            get { return Globals.Globals.ChannelBits.ReadOnly.HasBit(Def.GetInt("Bits")); }
        }

        public bool Admin
        {
            get { return Globals.Globals.ChannelBits.Admin.HasBit(Def.GetInt("Bits")); }
        }
    }
}