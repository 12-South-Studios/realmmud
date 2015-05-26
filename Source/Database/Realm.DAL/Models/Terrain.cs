using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Realm.DAL.Models
{
    [Table("Terrains")]
    public class Terrain : Primitive
    {
        [Required]
        public string DisplayDescription { get; set; }

        public int Bits { get; set; }

        public int MovementCost { get; set; }

        public int? SkillId { get; set; }
        public virtual Skill Skill { get; set; }

        public virtual ICollection<TerrainRestriction> Restrictions { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Terrain>()
                .HasOptional(x => x.Restrictions)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}