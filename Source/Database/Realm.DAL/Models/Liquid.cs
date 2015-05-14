using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("Liquids")]
    public class Liquid : Primitive
    {
        [Required]
        public virtual SystemString DisplayDescription { get; set; }

        public virtual Color Color { get; set; }

        public int ThirstPoints { get; set; }

        public int DrunkPoints { get; set; }

        public float CostPerCharge { get; set; }

        public FlammabilityTypes FlammabilityType { get; set; }

        public virtual TagSet TagSet { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Liquid>()
                .HasRequired(x => x.DisplayName)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Liquid>()
                .HasRequired(x => x.DisplayDescription)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Liquid>()
                .HasOptional(x => x.TagSet)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}