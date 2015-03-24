using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
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

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>()
                .HasRequired(x => x.DisplayName)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Shop>()
                .HasOptional(x => x.BuyTypes)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Shop>()
                .HasOptional(x => x.Primitives)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}