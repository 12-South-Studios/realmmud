using System;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.Live.DAL.Models
{
    [Table("CharacterItems")]
    public class CharacterItem : Entity
    {
        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }

        public Int64? InstanceId { get; set; }
        public virtual Instance Instance { get; set; }

        public int? ItemId { get; set; }

        public int Quantity { get; set; }

        public int? WearLocationId { get; set; }

        public Int64? ContainedInItemId { get; set; }
        public virtual Instance ContainedInItem { get; set; }
    }
}
