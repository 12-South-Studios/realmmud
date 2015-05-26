using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("ItemMachines")]
    public class ItemMachine : Entity
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public MachineTypes MachineType { get; set; }
    }
}