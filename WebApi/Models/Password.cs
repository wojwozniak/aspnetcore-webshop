using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Password
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Password_ID { get; set; }

        [Required]
        public int User_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Password_Hash { get; set; }

        [Required]
        public DateTime Created_At { get; set; } = DateTime.UtcNow;
    }
}
