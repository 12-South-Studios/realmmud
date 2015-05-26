using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("MobileVendor")]
    public class MobileVendor : Entity
    {
        public int? ShopId { get; set; }
        public virtual Shop Shop { get; set; }

        public int Value { get; set; }

        [Required]
        public int MobileId { get; set; }
        public virtual Mobile Mobile { get; set; }
    }
}