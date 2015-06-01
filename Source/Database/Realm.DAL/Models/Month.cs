using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("Months")]
    public class Month : Primitive
    {
        public int NumberDays { get; set; }

        public SeasonTypes SeasonType { get; set; }

        public bool IsShrouding { get; set; }

        public int SortOrder { get; set; }

        public virtual ICollection<MonthEffect> Effects { get; set; }
    }
}