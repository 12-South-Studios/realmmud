using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("GuildLevels")]
    public class GuildLevel : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int Level { get; set; }

        public int XpRequired { get; set; }

        public int MaxNumberOfMembers { get; set; }

        public DateTime? CreateDateUtc { get; set; }
    }
}