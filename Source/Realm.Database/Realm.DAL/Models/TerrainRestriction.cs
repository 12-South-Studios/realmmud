﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("TerrainRestrictions")]
    public class TerrainRestriction : Entity
    {
        public MovementMode MoementMode { get; set; }

        [Required]
        public int TerrainId { get; set; }

        [ForeignKey("TerrainId")]
        public Terrain Terrain { get; set; }
    }
}