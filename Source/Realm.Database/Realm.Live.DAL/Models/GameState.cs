using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Realm.Live.DAL.Models
{
    [Table("GameStates")]
    public class GameState
    {
        [Key]
        public int Id { get; set; }

        public DateTime Sessionstart { get; set; }

        public DateTime SessionEnd { get; set; }

        public int Year { get; set; }

        public int MonthId { get; set; }

        public int Day { get; set; }

        public int Hour { get; set; }

        public int Minute { get; set; }
    }
}
