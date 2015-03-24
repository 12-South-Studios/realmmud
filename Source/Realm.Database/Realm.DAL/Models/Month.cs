﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("Months")]
    public class Month : Primitive
    {
        public int NumberDays { get; set; }

        public SeasonTypes SeasonType { get; set; }

        public bool IsShrouding { get; set; }

        public virtual ICollection<MonthEffect> Effects { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Month>()
                .HasRequired(x => x.DisplayName)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Month>()
                .HasOptional(x => x.Effects)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}