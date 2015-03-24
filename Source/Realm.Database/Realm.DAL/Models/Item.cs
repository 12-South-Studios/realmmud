using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("Items")]
    public class Item : Primitive
    {
        public ItemTypes ItemType { get; set; }

        public int Weight { get; set; }

        public MaterialTypes MaterialType { get; set; }

        public int CoinValue { get; set; }

        public SizeTypes SizeType { get; set; }

        public int MaxStackSize { get; set; }

        public int Bits { get; set; }

        public ConditionTypes ConditionType { get; set; }

        public virtual Ability UseAbility { get; set; }

        public int UseAbilityFrequency { get; set; }

        public Statistic SpotStatistic { get; set; }

        public DifficultyTypes SpotDifficultyType { get; set; }

        public virtual Item TrapItem { get; set; }

        public virtual TagSet TagSet { get; set; }

        public ItemClassTypes ItemClassType { get; set; }

        public ItemSet ItemSet { get; set; }

        public SystemString DisplayDescription { get; set; }

        public virtual ICollection<ItemBook> Books { get; set; }

        public virtual ICollection<ItemContainer> Containers { get; set; }

        public virtual ICollection<ItemDrinkContainer> DrinkContainers { get; set; }

        public virtual ICollection<ItemFood> Foods { get; set; }

        public virtual ICollection<ItemFormula> Formulas { get; set; }

        public virtual ICollection<ItemFormulaResource> FormulaResources { get; set; }

        public virtual ICollection<ItemFurniture> Furnitures { get; set; }

        public virtual ICollection<ItemLight> Lights { get; set; }

        public virtual ICollection<ItemLock> Locks { get; set; }

        public virtual ICollection<ItemMachine> Machines { get; set; }

        public virtual ICollection<ItemMagicalNode> MagicalNodes { get; set; }

        public virtual ICollection<ItemMudProg> MudProgs { get; set; }

        public virtual ICollection<ItemPortal> Portals { get; set; }

        public virtual ICollection<ItemPotion> Potions { get; set; }

        public virtual ICollection<ItemPrerequisite> Prerequisites { get; set; }

        public virtual ICollection<ItemResourceNode> ResourceNodes { get; set; }

        public virtual ICollection<ItemStatistic> Statistics { get; set; }

        public virtual ICollection<ItemTool> Tools { get; set; }

        public virtual ICollection<ItemTrap> Traps { get; set; }

        public virtual ICollection<ItemTreasure> Treasures { get; set; }

        public virtual ICollection<ItemVehicle> Vehicles { get; set; }

        public virtual ICollection<ItemVehicleTerrain> VehicleTerrains { get; set; }

        public virtual ICollection<ItemWeapon> Weapons { get; set; }

        public virtual ICollection<ItemWearLocation> WearLocations { get; set; }
    }
}