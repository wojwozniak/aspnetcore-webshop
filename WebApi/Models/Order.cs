using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Order_ID { get; set; }

        [Required]
        public int User_ID { get; set; }

        [Required]
        public DateTime Order_Date { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "P";

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Total_Amount { get; set; }
    }
}
