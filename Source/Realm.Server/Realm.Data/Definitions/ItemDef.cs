using System.Collections.Generic;
using Realm.Library.Common;
using Realm.Library.Common.Data;

namespace Realm.Data.Definitions
{
    /// <summary>
    /// Definition of an Item
    /// </summary>
    public class ItemDef : Definition
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ItemDef(long id, string name, DictionaryAtom definition)
            : base(id, name, definition)
        {
        }

        public string DisplayName
        {
            get { return Def.GetString("DisplayName"); }
        }

        public string DisplayDescription
        {
            get { return Def.GetString("DisplayDescription"); }
        }

        public Globals.Globals.ItemTypes ItemType
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.ItemTypes>(Def.GetInt("ItemTypeID")); }
        }

        public int Weight { get { return Def.GetInt("Weight"); } }

        public Globals.Globals.MaterialTypes MaterialType
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.MaterialTypes>(Def.GetInt("MaterialTypeID")); }
        }

        public int CoinValue { get { return Def.GetInt("CoinValue"); } }

        public Globals.Globals.SizeTypes Size
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.SizeTypes>(Def.GetInt("SizeTypeID")); }
        }

        public int MaxStackSize { get { return Def.GetInt("MaxStackSize"); } }

        // Bits

        public Globals.Globals.ConditionTypes Condition
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.ConditionTypes>(Def.GetInt("ConditionTypeID")); }
        }

        public AbilityDef UseAbility
        {
            get
            {
                return
                    (AbilityDef)
                    StaticDataManager.GetStaticData(Globals.Globals.SystemTypes.Ability,
                                                             Def.GetString("UseAbilityID"));
            }
        }

        public int UseAbilityFrequency { get { return Def.GetInt("UseAbilityFrequency"); } }

        public Globals.Globals.Statistics SpotStatistic
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.Statistics>(Def.GetInt("SpotStatisticID")); }
        }

        public Globals.Globals.DifficultyTypes SpotDifficulty
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.DifficultyTypes>(Def.GetInt("SpotDifficultyTypeID")); }
        }

        public int TrapItemID { get { return Def.GetInt("TrapItemID"); } }

        public int TagSetID { get { return Def.GetInt("TagSetID"); } }

        public Globals.Globals.ItemClassTypes ItemClass
        {
            get { return EnumerationExtensions.GetEnum<Globals.Globals.ItemClassTypes>(Def.GetInt("ItemClassTypeID")); }
        }

        public ItemSetDef ItemSet
        {
            get
            {
                return
                    (ItemSetDef)
                    StaticDataManager.GetStaticData(Globals.Globals.SystemTypes.ItemSet,
                                                             Def.GetString("ItemSetID"));
            }
        }

        public bool IsHidden
        {
            get { return Globals.Globals.ItemBits.IsHidden.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsTradeable
        {
            get { return Globals.Globals.ItemBits.IsTradeable.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsRepairable
        {
            get { return Globals.Globals.ItemBits.IsRepairable.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsTakeable
        {
            get { return Globals.Globals.ItemBits.IsTakeable.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsLockable
        {
            get { return Globals.Globals.ItemBits.IsLockable.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsCloseable
        {
            get { return Globals.Globals.ItemBits.IsCloseable.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsLocked
        {
            get { return Globals.Globals.ItemBits.IsLocked.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsRelockable
        {
            get { return Globals.Globals.ItemBits.IsRelockable.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsMagical
        {
            get { return Globals.Globals.ItemBits.IsMagical.HasBit(Def.GetInt("Bits")); }
        }

        public bool DestroyedOnUse
        {
            get { return Globals.Globals.ItemBits.DestroyedOnUse.HasBit(Def.GetInt("Bits")); }
        }

        public bool NotifyArea
        {
            get { return Globals.Globals.ItemBits.NotifyArea.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsClosed
        {
            get { return Globals.Globals.ItemBits.IsClosed.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsBreakable
        {
            get { return Globals.Globals.ItemBits.IsBreakable.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsThrowable
        {
            get { return Globals.Globals.ItemBits.IsThrowable.HasBit(Def.GetInt("Bits")); }
        }

        public bool IsRemoveable
        {
            get { return Globals.Globals.ItemBits.IsRemoveable.HasBit(Def.GetInt("Bits")); }
        }

        public IEnumerable<Atom> Books { get { return Def.GetAtom<ListAtom>("Books"); } }

        public IEnumerable<Atom> Containers { get { return Def.GetAtom<ListAtom>("Containers"); } }

        public IEnumerable<Atom> DrinkContainers { get { return Def.GetAtom<ListAtom>("DrinkContainers"); } }

        public IEnumerable<Atom> Foods { get { return Def.GetAtom<ListAtom>("Foods"); } }

        public IEnumerable<Atom> FormulaResources { get { return Def.GetAtom<ListAtom>("FormulaResources"); } }

        public IEnumerable<Atom> Formulas { get { return Def.GetAtom<ListAtom>("Formulas"); } }

        public IEnumerable<Atom> Furnitures { get { return Def.GetAtom<ListAtom>("Furnitures"); } }

        public IEnumerable<Atom> Lights { get { return Def.GetAtom<ListAtom>("Lights"); } }

        public IEnumerable<Atom> Locks { get { return Def.GetAtom<ListAtom>("Locks"); } }

        public IEnumerable<Atom> Machines { get { return Def.GetAtom<ListAtom>("Machines"); } }

        public IEnumerable<Atom> MagicalNodes { get { return Def.GetAtom<ListAtom>("MagicalNodes"); } }

        public IEnumerable<Atom> MudProgs { get { return Def.GetAtom<ListAtom>("MudProgs"); } }

        public IEnumerable<Atom> Portals { get { return Def.GetAtom<ListAtom>("Portals"); } }

        public IEnumerable<Atom> Potions { get { return Def.GetAtom<ListAtom>("Potions"); } }

        public IEnumerable<Atom> Prerequisites { get { return Def.GetAtom<ListAtom>("Prerequisites"); } }

        public IEnumerable<Atom> ResourceNodes { get { return Def.GetAtom<ListAtom>("ResourceNodes"); } }

        public IEnumerable<Atom> Statistics { get { return Def.GetAtom<ListAtom>("Statistics"); } }

        public IEnumerable<Atom> Tools { get { return Def.GetAtom<ListAtom>("Tools"); } }

        public IEnumerable<Atom> Traps { get { return Def.GetAtom<ListAtom>("Traps"); } }

        public IEnumerable<Atom> Treasures { get { return Def.GetAtom<ListAtom>("Treasures"); } }

        public IEnumerable<Atom> Vehicles { get { return Def.GetAtom<ListAtom>("Vehicles"); } }

        public IEnumerable<Atom> VehicleTerrains { get { return Def.GetAtom<ListAtom>("VehicleTerrains"); } }

        public IEnumerable<Atom> Weapons { get { return Def.GetAtom<ListAtom>("Weapons"); } }

        public IEnumerable<Atom> WearLocations { get { return Def.GetAtom<ListAtom>("WearLocations"); } }
    }
}