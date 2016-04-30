using Realm.Library.Common.Data;
using Realm.Library.Common.Extensions;

namespace Realm.Data.Definitions
{
    /// <summary>
    /// Definition of an Archetype
    /// </summary>
    public class LiquidDef : Definition
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public LiquidDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        public string DisplayName => Def.GetString("DisplayName");

        public string DisplayDescription => Def.GetString("DisplayDescription");

        public Globals.ColorTypes ColorType => EnumerationExtensions.GetEnum<Globals.ColorTypes>(Def.GetInt("ColorTypeID"));

        public int ThirstPoints => Def.GetInt("ThirstPoints");

        public int DrunkPoints => Def.GetInt("DrunkPoints");

        public float CostPerCharge => (float)Def.GetReal("CostPerCharge");

        public Globals.FlammabilityTypes FlammabilityType => EnumerationExtensions.GetEnum<Globals.FlammabilityTypes>(Def.GetInt("FlammabilityTypeID"));

        public int TagSetID => Def.GetInt("TagSetID");
    }
}