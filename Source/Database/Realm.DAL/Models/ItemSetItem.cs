using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemSetItems")]
    public class ItemSetItem : Entity
    {
        public int ItemSetId { get; set; }
        public virtual ItemSet ItemSet { get; set; }

        public int? ItemId { get; set; }
        public virtual Item Item { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemSetItem>().HasRequired(x => x.ItemSet)
                .WithMany().HasForeignKey(x => x.ItemSetId);
            modelBuilder.Entity<ItemSetItem>().HasOptional(x => x.Item)
                .WithMany().HasForeignKey(x => x.ItemId);
        }
    }
}