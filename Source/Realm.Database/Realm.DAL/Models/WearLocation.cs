using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("WearLocations")]
    public class WearLocation : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Value { get; set; }

        public string ShortNamne { get; set; }

        public string LongName { get; set; }

        public DateTime? CreateDateUtc { get; set; }
    }
}