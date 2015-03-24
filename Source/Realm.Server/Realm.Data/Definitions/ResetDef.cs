using Realm.Library.Common;
using Realm.Library.Common.Data;

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
        public Globals.Globals.ResetTypes ResetType
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.ResetTypes>(Def.GetInt("ResetTypeID")); }
        }

        /// <summary>
        ///
        /// </summary>
        public Globals.Globals.ResetLocTypes ResetLocationType
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.ResetLocTypes>(Def.GetInt("ResetLocationTypeID")); }
        }

        /// <summary>
        ///
        /// </summary>
        public SpaceDef Space
        {
            get
            {
                return
                    (SpaceDef)
                    StaticDataManager.GetStaticData(Globals.Globals.SystemTypes.Space, Def.GetString("SpaceID"));
            }
        }

        /// <summary>
        ///
        /// </summary>
        public int Limit { get { return Def.GetInt("Limit"); } }

        /// <summary>
        ///
        /// </summary>
        public int Quantity { get { return Def.GetInt("Quantity"); } }

        /// <summary>
        ///
        /// </summary>
        public int ObjectID { get { return Def.GetInt("ObjectID"); } }
    }
}