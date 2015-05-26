using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("ItemResourceNodes")]
    public class ItemResourceNode : Entity
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public int? ResourceItemId { get; set; }
        public virtual Item ResourceItem { get; set; }

        public ToolTypes ToolType { get; set; }

        public int? SkillId { get; set; }
        public virtual Skill Skill { get; set; }

        public int MinSkill { get; set; }

        public int MinGatherAmount { get; set; }

        public int MaxGatherAmount { get; set; }
    }
}