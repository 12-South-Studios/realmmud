using Realm.Library.Common.Data;
using Realm.Library.Common.Extensions;

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

        public string DisplayName => Def.GetString("DisplayName");

        public Globals.ChannelTypes ChannelType => EnumerationExtensions.GetEnum<Globals.ChannelTypes>(Def.GetInt("ChannelTypeID"));

        public bool ReadOnly => Globals.ChannelBits.ReadOnly.HasBit(Def.GetInt("Bits"));

        public bool Admin => Globals.ChannelBits.Admin.HasBit(Def.GetInt("Bits"));
    }
}