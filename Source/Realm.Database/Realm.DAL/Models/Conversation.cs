using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Realm.DAL.Models
{
    [Table("Conversations")]
    public class Conversation : Primitive
    {
        public bool IsDefault { get; set; }

        public virtual Faction RequiredFaction { get; set; }

        public int RequiredFactionLevel { get; set; }

        public virtual TagSet TagSet { get; set; }

        public virtual SystemString Keywords { get; set; }

        public virtual SystemString Text { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conversation>()
                .HasRequired(x => x.DisplayName)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Conversation>()
                .HasOptional(x => x.TagSet)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Conversation>()
                .HasOptional(x => x.Keywords)
                .WithMany()
                .WillCascadeOnDelete(true);
            
            modelBuilder.Entity<Conversation>()
                .HasOptional(x => x.Text)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}