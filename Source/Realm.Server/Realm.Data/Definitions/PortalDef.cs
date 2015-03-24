using Realm.Library.Common;
using Realm.Library.Common.Data;

namespace Realm.Data.Definitions
{
    /// <summary>
    ///
    /// </summary>
    public class PortalDef : Definition
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="definition"></param>
        public PortalDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        /// <summary>
        ///
        /// </summary>
        public Globals.Globals.Directions Direction
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.Directions>(Def.GetInt("DirectionID")); }
        }

        /// <summary>
        ///
        /// </summary>
        public SpaceDef SourceSpace
        {
            get
            {
                return
                    (SpaceDef)
                    StaticDataManager.GetStaticData(Globals.Globals.SystemTypes.Space,
                                                             Def.GetString("SourceSpaceID"));
            }
        }

        /// <summary>
        ///
        /// </summary>
        public SpaceDef TargetSpace
        {
            get
            {
                return
                    (SpaceDef)
                    StaticDataManager.GetStaticData(Globals.Globals.SystemTypes.Space,
                                                             Def.GetString("TargetSpaceID"));
            }
        }

        /// <summary>
        ///
        /// </summary>
        public string Keywords { get { return Def.GetString("Keywords"); } }

        /// <summary>
        ///
        /// </summary>
        public BarrierDef Barrier
        {
            get
            {
                return
                    (BarrierDef)
                    StaticDataManager.GetStaticData(Globals.Globals.SystemTypes.Barrier,
                                                             Def.GetString("BarrierID"));
            }
        }

        /// <summary>
        ///
        /// </summary>
        public bool IsHidden
        {
            get { return Globals.Globals.PortalBits.IsHidden.HasBit(Def.GetInt("Bits")); }
        }

        /// <summary>
        ///
        /// </summary>
        public bool IsOneWay
        {
            get { return Globals.Globals.PortalBits.IsOneWay.HasBit(Def.GetInt("Bits")); }
        }

        /// <summary>
        ///
        /// </summary>
        public bool IsTransparent
        {
            get { return Globals.Globals.PortalBits.IsTransparent.HasBit(Def.GetInt("Bits")); }
        }

        /// <summary>
        ///
        /// </summary>
        public bool IsDynamic
        {
            get { return Globals.Globals.PortalBits.IsDynamic.HasBit(Def.GetInt("Bits")); }
        }
    }
}