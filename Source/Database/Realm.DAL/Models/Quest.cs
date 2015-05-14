using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Realm.DAL.Models
{
    [Table("Quests")]
    public class Quest : Primitive
    {
        [Required]
        public virtual SystemString DisplayDescription { get; set; }

        public int Bits { get; set; }

        public int Timer { get; set; }

        public virtual TagSet TagSet { get; set; }

        public virtual ICollection<QuestAction> Actions { get; set; }

        public virtual ICollection<QuestProgress> ProgressSteps { get; set; }

        public virtual ICollection<QuestRequirement> Requirements { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quest>()
                .HasRequired(x => x.DisplayName)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Quest>()
                .HasRequired(x => x.DisplayDescription)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Quest>()
                .HasOptional(x => x.TagSet)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Quest>()
                .HasOptional(x => x.Actions)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Quest>()
                .HasOptional(x => x.ProgressSteps)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Quest>()
                .HasOptional(x => x.Requirements)
                .WithMany()
                .WillCascadeOnDelete(true);

            QuestAction.OnModelCreating(modelBuilder);
            QuestProgress.OnModelCreating(modelBuilder);
        }
    }
}