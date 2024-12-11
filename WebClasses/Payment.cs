using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebClasses
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Payment_ID { get; set; }

        [Required]
        public int Order_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Payment_Method { get; set; }

        [Required]
        public DateTime Payment_Date { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(50)]
        public string Payment_Status { get; set; } = "P";

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        public Order Order { get; set; }
    }
}
