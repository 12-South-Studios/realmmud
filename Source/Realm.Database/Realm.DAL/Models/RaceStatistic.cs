﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("RaceStatistics")]
    public class RaceStatistic : Entity
    {
        public Statistic Statistic { get; set; }

        public virtual Skill Skill { get; set; }

        public int ValueMod { get; set; }

        [Required]
        public int RaceId { get; set; }

        [ForeignKey("RaceId")]
        public Race Race { get; set; }
    }
}