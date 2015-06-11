using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("Shops")]
    public class Shop : IPrimitive
    {
        [Key]
        public int Id { get; set; }

        public DateTime? CreateDateUtc { get; set; }

        [Required]
        [MaxLength(255), MinLength(5)]
        public string SystemName { get; set; }

        [Required]
        public int? SystemClassId { get; set; }
        public virtual SystemClass SystemClass { get; set; }

        [Required]
        [MaxLength(255), MinLength(5)]
        public string DisplayName { get; set; }

        public int BuyMarkup { get; set; }

        public int SellMarkup { get; set; }

        public int Bits { get; set; }

        public ShopTypes ShopType { get; set; }

        public virtual ICollection<ShopBuyType> BuyTypes { get; set; }

        public virtual ICollection<ShopPrimitive> Primitives { get; set; }
    }
}