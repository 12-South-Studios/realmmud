using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("GameCommands")]
    public class GameCommand : Primitive
    {
        public LogActionTypes LogActionType { get; set; }

        public int Bits { get; set; }

        public virtual TagSet TagSet { get; set; }

        public virtual SystemString Keywords { get; set; }

        public virtual ICollection<GameCommandPosition> Positions { get; set; }

        public virtual ICollection<GameCommandUserState> UserStates { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameCommand>()
                .HasRequired(x => x.DisplayName)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<GameCommand>()
                .HasOptional(x => x.TagSet)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<GameCommand>()
                .HasOptional(x => x.Keywords)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<GameCommand>()
                .HasOptional(x => x.Positions)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<GameCommand>()
                .HasOptional(x => x.UserStates)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}