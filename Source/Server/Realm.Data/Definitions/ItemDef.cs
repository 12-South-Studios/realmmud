using System.Collections.Generic;
using Realm.Library.Common.Data;
using Realm.Library.Common.Extensions;

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

        public string DisplayName => Def.GetString("DisplayName");

        public string DisplayDescription => Def.GetString("DisplayDescription");

        public Globals.ItemTypes ItemType => EnumerationExtensions.GetEnum<Globals.ItemTypes>(Def.GetInt("ItemTypeID"));

        public int Weight => Def.GetInt("Weight");

        public Globals.MaterialTypes MaterialType => EnumerationExtensions.GetEnum<Globals.MaterialTypes>(Def.GetInt("MaterialTypeID"));

        public int CoinValue => Def.GetInt("CoinValue");

        public Globals.SizeTypes Size => EnumerationExtensions.GetEnum<Globals.SizeTypes>(Def.GetInt("SizeTypeID"));

        public int MaxStackSize => Def.GetInt("MaxStackSize");

        // Bits

        public Globals.ConditionTypes Condition => EnumerationExtensions.GetEnum<Globals.ConditionTypes>(Def.GetInt("ConditionTypeID"));

        public AbilityDef UseAbility => (AbilityDef)
            StaticDataManager.GetStaticData(Globals.SystemTypes.Ability,
                Def.GetString("UseAbilityID"));

        public int UseAbilityFrequency => Def.GetInt("UseAbilityFrequency");

        public Globals.Statistics SpotStatistic => EnumerationExtensions.GetEnum<Globals.Statistics>(Def.GetInt("SpotStatisticID"));

        public Globals.DifficultyTypes SpotDifficulty => EnumerationExtensions.GetEnum<Globals.DifficultyTypes>(Def.GetInt("SpotDifficultyTypeID"));

        public int TrapItemID => Def.GetInt("TrapItemID");

        public int TagSetID => Def.GetInt("TagSetID");

        public Globals.ItemClassTypes ItemClass => EnumerationExtensions.GetEnum<Globals.ItemClassTypes>(Def.GetInt("ItemClassTypeID"));

        public ItemSetDef ItemSet => (ItemSetDef)
            StaticDataManager.GetStaticData(Globals.SystemTypes.ItemSet,
                Def.GetString("ItemSetID"));

        public bool IsHidden => Globals.ItemBits.IsHidden.HasBit(Def.GetInt("Bits"));

        public bool IsTradeable => Globals.ItemBits.IsTradeable.HasBit(Def.GetInt("Bits"));

        public bool IsRepairable => Globals.ItemBits.IsRepairable.HasBit(Def.GetInt("Bits"));

        public bool IsTakeable => Globals.ItemBits.IsTakeable.HasBit(Def.GetInt("Bits"));

        public bool IsLockable => Globals.ItemBits.IsLockable.HasBit(Def.GetInt("Bits"));

        public bool IsCloseable => Globals.ItemBits.IsCloseable.HasBit(Def.GetInt("Bits"));

        public bool IsLocked => Globals.ItemBits.IsLocked.HasBit(Def.GetInt("Bits"));

        public bool IsRelockable => Globals.ItemBits.IsRelockable.HasBit(Def.GetInt("Bits"));

        public bool IsMagical => Globals.ItemBits.IsMagical.HasBit(Def.GetInt("Bits"));

        public bool DestroyedOnUse => Globals.ItemBits.DestroyedOnUse.HasBit(Def.GetInt("Bits"));

        public bool NotifyArea => Globals.ItemBits.NotifyArea.HasBit(Def.GetInt("Bits"));

        public bool IsClosed => Globals.ItemBits.IsClosed.HasBit(Def.GetInt("Bits"));

        public bool IsBreakable => Globals.ItemBits.IsBreakable.HasBit(Def.GetInt("Bits"));

        public bool IsThrowable => Globals.ItemBits.IsThrowable.HasBit(Def.GetInt("Bits"));

        public bool IsRemoveable => Globals.ItemBits.IsRemoveable.HasBit(Def.GetInt("Bits"));

        public IEnumerable<Atom> Books => Def.GetAtom<ListAtom>("Books");

        public IEnumerable<Atom> Containers => Def.GetAtom<ListAtom>("Containers");

        public IEnumerable<Atom> DrinkContainers => Def.GetAtom<ListAtom>("DrinkContainers");

        public IEnumerable<Atom> Foods => Def.GetAtom<ListAtom>("Foods");

        public IEnumerable<Atom> FormulaResources => Def.GetAtom<ListAtom>("FormulaResources");

        public IEnumerable<Atom> Formulas => Def.GetAtom<ListAtom>("Formulas");

        public IEnumerable<Atom> Furnitures => Def.GetAtom<ListAtom>("Furnitures");

        public IEnumerable<Atom> Lights => Def.GetAtom<ListAtom>("Lights");

        public IEnumerable<Atom> Locks => Def.GetAtom<ListAtom>("Locks");

        public IEnumerable<Atom> Machines => Def.GetAtom<ListAtom>("Machines");

        public IEnumerable<Atom> MagicalNodes => Def.GetAtom<ListAtom>("MagicalNodes");

        public IEnumerable<Atom> MudProgs => Def.GetAtom<ListAtom>("MudProgs");

        public IEnumerable<Atom> Portals => Def.GetAtom<ListAtom>("Portals");

        public IEnumerable<Atom> Potions => Def.GetAtom<ListAtom>("Potions");

        public IEnumerable<Atom> Prerequisites => Def.GetAtom<ListAtom>("Prerequisites");

        public IEnumerable<Atom> ResourceNodes => Def.GetAtom<ListAtom>("ResourceNodes");

        public IEnumerable<Atom> Statistics => Def.GetAtom<ListAtom>("Statistics");

        public IEnumerable<Atom> Tools => Def.GetAtom<ListAtom>("Tools");

        public IEnumerable<Atom> Traps => Def.GetAtom<ListAtom>("Traps");

        public IEnumerable<Atom> Treasures => Def.GetAtom<ListAtom>("Treasures");

        public IEnumerable<Atom> Vehicles => Def.GetAtom<ListAtom>("Vehicles");

        public IEnumerable<Atom> VehicleTerrains => Def.GetAtom<ListAtom>("VehicleTerrains");

        public IEnumerable<Atom> Weapons => Def.GetAtom<ListAtom>("Weapons");

        public IEnumerable<Atom> WearLocations => Def.GetAtom<ListAtom>("WearLocations");
    }
}