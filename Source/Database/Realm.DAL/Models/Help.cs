using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Realm.DAL.Models
{
    [Table("Helps")]
    public class Help : Primitive
    {
        public virtual SystemString Keywords { get; set; }

        public virtual SystemString Text { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Help>()
                .HasRequired(x => x.DisplayName)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Help>()
                .HasOptional(x => x.Keywords)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Help>()
                .HasOptional(x => x.Text)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}