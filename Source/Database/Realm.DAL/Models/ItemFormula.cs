using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Realm.DAL.Common;

namespace Realm.DAL.Models
{
    [Table("ItemFormulas")]
    public class ItemFormula : Entity
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public int? SkillId { get; set; }
        public virtual Skill Skill { get; set; }

        public int SkillValue { get; set; }

        public int? ProductItemId { get; set; }
        public virtual Item ProductItem { get; set; }

        public int ProductQuantity { get; set; }

        public int? MachineItemId { get; set; }
        public virtual Item MachineItem { get; set; }

        public int? ToolItemId { get; set; }
        public virtual Item ToolItem { get; set; }

        public int ExperienceValue { get; set; }

        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemFormula>()
                .HasRequired(x => x.ProductItem)
                .WithMany()
                .HasForeignKey(x => x.ProductItemId);
            modelBuilder.Entity<ItemFormula>()
                .HasOptional(x => x.MachineItem)
                .WithMany()
                .HasForeignKey(x => x.MachineItemId);
            modelBuilder.Entity<ItemFormula>()
                .HasOptional(x => x.ToolItem)
                .WithMany()
                .HasForeignKey(x => x.ToolItemId);
        }
    }
}