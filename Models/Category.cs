using System.ComponentModel.DataAnnotations;

namespace ProducttAPI.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string? Name { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}

