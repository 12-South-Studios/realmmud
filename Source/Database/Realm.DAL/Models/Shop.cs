using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("Shops")]
    public class Shop : Primitive
    {
        public int BuyMarkup { get; set; }

        public int SellMarkup { get; set; }

        public int Bits { get; set; }

        public ShopTypes ShopType { get; set; }

        public virtual ICollection<ShopBuyType> BuyTypes { get; set; }

        public virtual ICollection<ShopPrimitive> Primitives { get; set; }
    }
}