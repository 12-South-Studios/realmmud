using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Realm.DAL.Models
{
    [Table("Treasures")]
    public class Treasure : Primitive
    {
        public string SystemDescription { get; set; }

        public virtual ICollection<TreasurePrimitive> Primitives { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Treasure>()
                .HasOptional(x => x.Primitives)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}