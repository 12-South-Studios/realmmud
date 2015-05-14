using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("Skills")]
    public class Skill : Primitive
    {
        [Required]
        public virtual SystemString DisplayDescription { get; set; }

        public virtual SkillCategory SkillCategory { get; set; }

        public Statistic Statistic { get; set; }

        public int MaxValue { get; set; }

        public bool IsMasterable { get; set; }

        public virtual Skill ParentSkill { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>()
                .HasRequired(x => x.DisplayName)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Skill>()
                .HasRequired(x => x.DisplayDescription)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}