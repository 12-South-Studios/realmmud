using System.ComponentModel.DataAnnotations.Schema;

namespace Realm.DAL.Models
{
    [Table("Helps")]
    public class Help : Primitive
    {
        public string Keywords { get; set; }

        public string Text { get; set; }
    }
}