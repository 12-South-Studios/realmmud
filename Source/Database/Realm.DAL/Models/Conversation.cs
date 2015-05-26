using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Realm.DAL.Models
{
    [Table("Conversations")]
    public class Conversation : Primitive
    {
        public bool IsDefault { get; set; }

        public int? RequiredFactionId { get; set; }
        public virtual Faction RequiredFaction { get; set; }

        public int RequiredFactionLevel { get; set; }

        public int? TagSetId { get; set; }
        public virtual TagSet TagSet { get; set; }

        public string Keywords { get; set; }

        public string Text { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conversation>()
                .HasOptional(x => x.TagSet)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}