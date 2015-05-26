using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Realm.DAL.Models
{
    [Table("Socials")]
    public class Social : Primitive
    {
        public string CharNoArg { get; set; }

        public string OthersNoArg { get; set; }

        public string CharFound { get; set; }

        public string OthersFound { get; set; }

        public string VictFound { get; set; }

        public string CharAuto { get; set; }

        public string OthersAuto { get; set; }
    }
}