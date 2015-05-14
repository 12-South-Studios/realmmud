using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ShopPrimitives")]
    public class ShopPrimitive : Entity
    {
        public virtual Primitive Primitive { get; set; }

        public int Quantity { get; set; }

        [Required]
        public int ShopId { get; set; }

        [ForeignKey("ShopId")]
        public Shop Shop { get; set; }
    }
}