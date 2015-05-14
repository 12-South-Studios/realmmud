using Realm.Library.Common;
using Realm.Library.Common.Data;

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

        public string DisplayName { get { return Def.GetString("DisplayName"); } }

        public string DisplayDescription { get { return Def.GetString("DisplayDescription"); } }

        public Globals.Globals.ColorTypes ColorType
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.ColorTypes>(Def.GetInt("ColorTypeID")); }
        }

        public int ThirstPoints { get { return Def.GetInt("ThirstPoints"); } }

        public int DrunkPoints { get { return Def.GetInt("DrunkPoints"); } }

        public float CostPerCharge { get { return (float)Def.GetReal("CostPerCharge"); } }

        public Globals.Globals.FlammabilityTypes FlammabilityType
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.FlammabilityTypes>(Def.GetInt("FlammabilityTypeID")); }
        }

        public int TagSetID { get { return Def.GetInt("TagSetID"); } }
    }
}