using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("MobileEquipments")]
    public class MobileEquipment : Entity
    {
        public int? ItemId { get; set; }
        public virtual Item Item { get; set; }

        public int? WornAtId { get; set; }
        public virtual WearLocation WornAt { get; set; }

        public int Quantity { get; set; }

        [Required]
        public int MobileId { get; set; }
        public virtual Mobile Mobile { get; set; }
    }
}