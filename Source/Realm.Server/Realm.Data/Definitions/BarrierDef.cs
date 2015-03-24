using Realm.Library.Common;
using Realm.Library.Common.Data;

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

        public string DisplayName { get { return Def.GetString("DisplayName"); } }

        public int TagSet
        {
            get { return Def.GetInt("TagSetID"); }
        }

        public Globals.Globals.MaterialTypes MaterialType
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.MaterialTypes>(Def.GetInt("MaterialTypeID")); }
        }

        public ItemDef KeyItem
        {
            get
            {
                return
                    (ItemDef)
                    StaticDataManager.GetStaticData(Globals.Globals.SystemTypes.Item,
                                                             Def.GetString("KeyItemID"));
            }
        }

        public ItemDef LockItem
        {
            get
            {
                return
                    (ItemDef)
                    StaticDataManager.GetStaticData(Globals.Globals.SystemTypes.Item,
                                                             Def.GetString("LockItemID"));
            }
        }

        public ItemDef TrapItem
        {
            get
            {
                return
                    (ItemDef)
                    StaticDataManager.GetStaticData(Globals.Globals.SystemTypes.Item,
                                                             Def.GetString("TrapItemID"));
            }
        }

        public bool IsCloseable
        {
            get { return Globals.Globals.BarrierBits.IsCloseable.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsClosed
        {
            get { return Globals.Globals.BarrierBits.IsClosed.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsOneWay
        {
            get { return Globals.Globals.BarrierBits.IsOneWay.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsTransparent
        {
            get { return Globals.Globals.BarrierBits.IsTransparent.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsDestroyable
        {
            get { return Globals.Globals.BarrierBits.IsDestroyable.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsDispellable
        {
            get { return Globals.Globals.BarrierBits.IsDispellable.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsLockable
        {
            get { return Globals.Globals.BarrierBits.IsLockable.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsJumpable
        {
            get { return Globals.Globals.BarrierBits.IsJumpable.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsClimbable
        {
            get { return Globals.Globals.BarrierBits.IsClimbable.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsSwimmable
        {
            get { return Globals.Globals.BarrierBits.IsSwimmable.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsDestroyed
        {
            get { return Globals.Globals.BarrierBits.IsDestroyed.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsTrapable
        {
            get { return Globals.Globals.BarrierBits.IsTrapable.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsLocked
        {
            get { return Globals.Globals.BarrierBits.IsLocked.HasBit(Def.GetInt("Bits")); }
        }
    }
}