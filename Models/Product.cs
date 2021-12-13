using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProducttAPI.Models
{
    public class Product
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Sku { get; set; } = string.Empty;

        [Required]
        [MaxLength(32)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }

        [DefaultValue(false)]
        public bool IsAvailable { get; set; }

        [Required]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
    }
}

