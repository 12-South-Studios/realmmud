using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("Mobiles")]
    public class Mobile : Primitive
    {
        [Required]
        public virtual SystemString DisplayDescription { get; set; }

        public SizeTypes SizeType { get; set; }

        public MobileTypes MobileType { get; set; }

        public int Bits { get; set; }

        public virtual Race Race { get; set; }

        public virtual Conversation Conversation { get; set; }

        public int AccessLevel { get; set; }

        public GenderTypes GenderType { get; set; }

        public int Level { get; set; }

        public virtual Faction Faction { get; set; }

        public virtual TagSet TagSet { get; set; }

        public virtual ICollection<MobileAbility> Abilities { get; set; }

        public virtual ICollection<MobileAI> AIs { get; set; }

        public virtual ICollection<MobileEquipment> Equipment { get; set; }

        public virtual ICollection<MobileMudProg> MudProgs { get; set; }

        public virtual ICollection<MobileResource> Resources { get; set; }

        public virtual ICollection<MobileStatistic> Statistics { get; set; }

        public virtual ICollection<MobileTreasure> Treasures { get; set; }

        public virtual ICollection<MobileTreasureTable> TreasureTables { get; set; }

        public virtual ICollection<MobileVendor> Vendors { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mobile>()
                .HasRequired(x => x.DisplayName)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Mobile>()
                .HasRequired(x => x.DisplayDescription)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Mobile>()
                .HasOptional(x => x.TagSet)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Mobile>()
                .HasOptional(x => x.Abilities)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Mobile>()
                .HasOptional(x => x.AIs)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Mobile>()
                .HasOptional(x => x.Equipment)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Mobile>()
                .HasOptional(x => x.MudProgs)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Mobile>()
                .HasOptional(x => x.Resources)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Mobile>()
                .HasOptional(x => x.Statistics)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Mobile>()
                .HasOptional(x => x.Treasures)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Mobile>()
                .HasOptional(x => x.TreasureTables)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Mobile>()
                .HasOptional(x => x.Vendors)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}