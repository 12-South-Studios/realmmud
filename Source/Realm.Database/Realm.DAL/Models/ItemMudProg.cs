using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemMudProgs")]
    public class ItemMudProg : Entity
    {
        public Event Event { get; set; }

        public MudProg MudProg { get; set; }

        public float PercentChance { get; set; }
    }
}