using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("ItemResourceNodes")]
    public class ItemResourceNode : Entity
    {
        public Item ResourceItem { get; set; }

        public ToolTypes ToolType { get; set; }

        public Skill Skill { get; set; }

        public int MinSkill { get; set; }

        public int MinGatherAmount { get; set; }

        public int MaxGatherAmount { get; set; }
    }
}