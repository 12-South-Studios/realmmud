﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("SpawnLocations")]
    public class SpawnLocation : Entity
    {
        public virtual Space Space { get; set; }

        public int AccessLevel { get; set; }

        [Required]
        public int SpawnId { get; set; }

        [ForeignKey("SpawnId")]
        public Spawn Spawn { get; set; }
    }
}