using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("QuestActions")]
    public class QuestAction : Entity
    {
        public bool IsStart { get; set; }

        public virtual Mobile Mobile { get; set; }

        public int Coin { get; set; }

        public int Experience { get; set; }

        public int? GivePrimitiveId { get; set; }

        [ForeignKey("GivePrimitiveId")]
        public virtual Primitive GivePrimitive { get; set; }

        public int? DeletePrimitiveId { get; set; }

        [ForeignKey("DeletePrimitiveId")]
        public virtual Primitive DeletePrimitive { get; set; }

        public int Quantity { get; set; }

        public virtual MudProg MudProg { get; set; }

        public virtual SystemString JournalEntry { get; set; }

        [Required]
        public int QuestId { get; set; }

        [ForeignKey("QuestId")]
        public Quest Quest { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestAction>()
                .HasOptional(x => x.JournalEntry)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}