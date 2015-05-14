using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Realm.DAL.Enumerations;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("QuestProgresses")]
    public class QuestProgress : Entity
    {
        public QuestProgressTypes QuestProgressType { get; set; }

        public virtual Primitive Primitive { get; set; }

        public int Quantity { get; set; }

        public virtual SystemString ProgressName { get; set; }

        [Required]
        public int QuestId { get; set; }

        [ForeignKey("QuestId")]
        public Quest Quest { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestProgress>()
                .HasOptional(x => x.ProgressName)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}