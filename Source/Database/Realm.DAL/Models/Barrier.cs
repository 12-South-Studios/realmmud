using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("Barriers")]
    public class Barrier : Primitive
    {
        public MaterialTypes MaterialType { get; set; }

        public int Bits { get; set; }

        public int? KeyItemId { get; set; }
        public virtual Item KeyItem { get; set; }

        public int? LockItemId { get; set; }
        public virtual Item LockItem { get; set; }

        public int? TrapItemId { get; set; }
        public virtual Item TrapItem { get; set; }

        public int? TagSetId { get; set; }
        public virtual TagSet TagSet { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barrier>()
                .HasOptional(x => x.TagSet)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}