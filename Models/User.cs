using System.ComponentModel.DataAnnotations;

namespace ProducttAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        public virtual List<Order> Orders { get; set; }

    }
}

