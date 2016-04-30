using Realm.Library.Common.Data;
using Realm.Library.Common.Extensions;

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
        public Globals.Directions Direction => EnumerationExtensions.GetEnum<Globals.Directions>(Def.GetInt("DirectionID"));

        /// <summary>
        ///
        /// </summary>
        public SpaceDef SourceSpace => (SpaceDef)
            StaticDataManager.GetStaticData(Globals.SystemTypes.Space,
                Def.GetString("SourceSpaceID"));

        /// <summary>
        ///
        /// </summary>
        public SpaceDef TargetSpace => (SpaceDef)
            StaticDataManager.GetStaticData(Globals.SystemTypes.Space,
                Def.GetString("TargetSpaceID"));

        /// <summary>
        ///
        /// </summary>
        public string Keywords => Def.GetString("Keywords");

        /// <summary>
        ///
        /// </summary>
        public BarrierDef Barrier => (BarrierDef)
            StaticDataManager.GetStaticData(Globals.SystemTypes.Barrier,
                Def.GetString("BarrierID"));

        /// <summary>
        ///
        /// </summary>
        public bool IsHidden => Globals.PortalBits.IsHidden.HasBit(Def.GetInt("Bits"));

        /// <summary>
        ///
        /// </summary>
        public bool IsOneWay => Globals.PortalBits.IsOneWay.HasBit(Def.GetInt("Bits"));

        /// <summary>
        ///
        /// </summary>
        public bool IsTransparent => Globals.PortalBits.IsTransparent.HasBit(Def.GetInt("Bits"));

        /// <summary>
        ///
        /// </summary>
        public bool IsDynamic => Globals.PortalBits.IsDynamic.HasBit(Def.GetInt("Bits"));
    }
}