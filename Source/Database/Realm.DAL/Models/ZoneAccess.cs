using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ZoneAccesses")]
    public class ZoneAccess : Entity
    {
        [Required]
        public virtual SystemString AccessName { get; set; }

        public int AccessValue { get; set; }

        [Required]
        public int ZoneId { get; set; }

        [ForeignKey("ZoneId")]
        public Zone Zone { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ZoneAccess>()
                .HasRequired(x => x.AccessName)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}