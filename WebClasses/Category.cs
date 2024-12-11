using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebClasses
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Category_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Category_Name { get; set; }

        public int? Parent_Category_ID { get; set; }

        [ForeignKey(nameof(Parent_Category_ID))]
        public Category ParentCategory { get; set; }
        public ICollection<Category> ChildCategories { get; set; }
        public ICollection<Product> Products { get; set; }
    }

}
