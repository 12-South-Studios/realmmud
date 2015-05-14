using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Realm.DAL.Models
{
    [Table("MudProgs")]
    public class MudProg : Primitive
    {
        [Required]
        public virtual SystemString Data { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MudProg>()
                .HasRequired(x => x.DisplayName)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<MudProg>()
                .HasRequired(x => x.Data)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}