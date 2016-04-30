using Realm.Library.Common.Data;
using Realm.Library.Common.Extensions;

namespace Realm.Data.Definitions
{
    /// <summary>
    /// Definition of an Archetype
    /// </summary>
    public class BarrierDef : Definition
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BarrierDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        public string DisplayName => Def.GetString("DisplayName");

        public int TagSet => Def.GetInt("TagSetID");

        public Globals.MaterialTypes MaterialType => EnumerationExtensions.GetEnum<Globals.MaterialTypes>(Def.GetInt("MaterialTypeID"));

        public ItemDef KeyItem => (ItemDef)
            StaticDataManager.GetStaticData(Globals.SystemTypes.Item,
                Def.GetString("KeyItemID"));

        public ItemDef LockItem => (ItemDef)
            StaticDataManager.GetStaticData(Globals.SystemTypes.Item,
                Def.GetString("LockItemID"));

        public ItemDef TrapItem => (ItemDef)
            StaticDataManager.GetStaticData(Globals.SystemTypes.Item,
                Def.GetString("TrapItemID"));

        public bool IsCloseable => Globals.BarrierBits.IsCloseable.HasBit(Def.GetInt("Bits"));

        public bool IsClosed => Globals.BarrierBits.IsClosed.HasBit(Def.GetInt("Bits"));

        public bool IsOneWay => Globals.BarrierBits.IsOneWay.HasBit(Def.GetInt("Bits"));

        public bool IsTransparent => Globals.BarrierBits.IsTransparent.HasBit(Def.GetInt("Bits"));

        public bool IsDestroyable => Globals.BarrierBits.IsDestroyable.HasBit(Def.GetInt("Bits"));

        public bool IsDispellable => Globals.BarrierBits.IsDispellable.HasBit(Def.GetInt("Bits"));

        public bool IsLockable => Globals.BarrierBits.IsLockable.HasBit(Def.GetInt("Bits"));

        public bool IsJumpable => Globals.BarrierBits.IsJumpable.HasBit(Def.GetInt("Bits"));

        public bool IsClimbable => Globals.BarrierBits.IsClimbable.HasBit(Def.GetInt("Bits"));

        public bool IsSwimmable => Globals.BarrierBits.IsSwimmable.HasBit(Def.GetInt("Bits"));

        public bool IsDestroyed => Globals.BarrierBits.IsDestroyed.HasBit(Def.GetInt("Bits"));

        public bool IsTrapable => Globals.BarrierBits.IsTrapable.HasBit(Def.GetInt("Bits"));

        public bool IsLocked => Globals.BarrierBits.IsLocked.HasBit(Def.GetInt("Bits"));
    }
}