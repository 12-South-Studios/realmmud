using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ShopPrimitives")]
    public class ShopPrimitive : Entity
    {
        public int? PrimitiveId { get; set; }
        public virtual IPrimitive Primitive { get; set; }

        public int Quantity { get; set; }

        [Required]
        public int ShopId { get; set; }
        public virtual Shop Shop { get; set; }
    }
}