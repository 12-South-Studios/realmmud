using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("SkillCategories")]
    public class SkillCategory : Primitive
    {
        public Statistic Statistic { get; set; }
    }
}