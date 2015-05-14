using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Realm.DAL.Enumerations;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("SpacePortals")]
    public class SpacePortal : Entity
    {
        public DirectionTypes Direction { get; set; }

        public int? TargetSpaceId { get; set; }

        [ForeignKey("TargetSpaceId")]
        public virtual Space TargetSpace { get; set; }

        public virtual Barrier Barrier { get; set; }

        public int Bits { get; set; }

        [Required]
        public virtual SystemString Keywords { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpacePortal>()
                .HasRequired(x => x.Keywords)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}