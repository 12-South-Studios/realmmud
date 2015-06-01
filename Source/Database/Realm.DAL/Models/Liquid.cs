using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Realm.DAL.Enumerations;

namespace Realm.DAL.Models
{
    [Table("Liquids")]
    public class Liquid : Primitive
    {
        [Required]
        public string DisplayDescription { get; set; }

        public int? ColorId { get; set; }
        public virtual Color Color { get; set; }

        public int ThirstPoints { get; set; }

        public int DrunkPoints { get; set; }

        public float CostPerCharge { get; set; }

        public FlammabilityTypes FlammabilityType { get; set; }

        public int? TagSetId { get; set; }
        public virtual TagSet TagSet { get; set; }
    }
}