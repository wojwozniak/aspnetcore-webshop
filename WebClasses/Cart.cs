using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebClasses
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cart_ID { get; set; }

        [Required]
        public int User_ID { get; set; }

        [Required]
        public int Product_ID { get; set; }

        [Required]
        public int Quantity { get; set; } = 1;

        public User User { get; set; }
        public Product Product { get; set; }
    }
}
