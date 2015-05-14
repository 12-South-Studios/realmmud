using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Realm.DAL.Models
{
    [Table("Socials")]
    public class Social : Primitive
    {
        public SystemString CharNoArg { get; set; }

        public SystemString OthersNoArg { get; set; }

        public SystemString CharFound { get; set; }

        public SystemString OthersFound { get; set; }

        public SystemString VictFound { get; set; }

        public SystemString CharAuto { get; set; }

        public SystemString OthersAuto { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Social>()
                .HasRequired(x => x.DisplayName)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Social>()
                .HasOptional(x => x.CharNoArg)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Social>()
                .HasOptional(x => x.OthersNoArg)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Social>()
                .HasOptional(x => x.CharFound)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Social>()
                .HasOptional(x => x.OthersFound)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Social>()
                .HasOptional(x => x.VictFound)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Social>()
                .HasOptional(x => x.CharAuto)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Social>()
                .HasOptional(x => x.OthersAuto)
                .WithMany()
                .WillCascadeOnDelete(true);

        }
    }
}