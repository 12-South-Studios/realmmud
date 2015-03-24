using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Realm.DAL.Models
{
    [Table("Factions")]
    public class Faction : Primitive
    {
        public virtual TagSet TagSet { get; set; }

        public virtual ICollection<FactionRelation> Relations { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faction>()
                .HasRequired(x => x.DisplayName)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Faction>()
                .HasOptional(x => x.TagSet)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Faction>()
                .HasOptional(x => x.Relations)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}