using Realm.Library.Common.Data;
using Realm.Library.Common.Extensions;

namespace Realm.Data.Definitions
{
    /// <summary>
    ///
    /// </summary>
    public class ResetDef : Definition
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="definition"></param>
        public ResetDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        /// <summary>
        ///
        /// </summary>
        public Globals.ResetTypes ResetType => EnumerationExtensions.GetEnum<Globals.ResetTypes>(Def.GetInt("ResetTypeID"));

        /// <summary>
        ///
        /// </summary>
        public Globals.ResetLocTypes ResetLocationType => EnumerationExtensions.GetEnum<Globals.ResetLocTypes>(Def.GetInt("ResetLocationTypeID"));

        /// <summary>
        ///
        /// </summary>
        public SpaceDef Space => (SpaceDef)
            StaticDataManager.GetStaticData(Globals.SystemTypes.Space, Def.GetString("SpaceID"));

        /// <summary>
        ///
        /// </summary>
        public int Limit => Def.GetInt("Limit");

        /// <summary>
        ///
        /// </summary>
        public int Quantity => Def.GetInt("Quantity");

        /// <summary>
        ///
        /// </summary>
        public int ObjectID => Def.GetInt("ObjectID");
    }
}