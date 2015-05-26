using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Realm.DAL.Models
{
    [Table("MudProgs")]
    public class MudProg : Primitive
    {
        [Required]
        public string Data { get; set; }
    }
}