using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("MobileEquipments")]
    public class MobileEquipment : Entity
    {
        public virtual Item Item { get; set; }

        public virtual WearLocation WornAt { get; set; }

        public int Quantity { get; set; }

        [Required]
        public int MobileId { get; set; }

        [ForeignKey("MobileId")]
        public Mobile Mobile { get; set; }
    }
}