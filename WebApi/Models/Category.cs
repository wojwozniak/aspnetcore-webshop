using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
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

        [NotMapped]
        public Category ParentCategory { get; set; }
        [NotMapped]
        public ICollection<Category> ChildCategories { get; set; }
        [NotMapped]
        public ICollection<Product> Products { get; set; }
    }

}
