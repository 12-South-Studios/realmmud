using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Realm.DAL.Models
{
    [Table("Spaces")]
    public class Space : Primitive
    {
        [Required]
        public string DisplayDescription { get; set; }

        public int Bits { get; set; }

        public int? TerrainId { get; set; }
        public virtual Terrain Terrain { get; set; }

        public int AccessLevel { get; set; }

        public int? TagSetId { get; set; }
        public virtual TagSet TagSet { get; set; }

        public virtual ICollection<SpacePortal> Portals { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Space>()
                .HasOptional(x => x.TagSet)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Space>()
                .HasOptional(x => x.Portals)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}