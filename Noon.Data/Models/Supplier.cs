using System.ComponentModel.DataAnnotations;

namespace Noon.Data.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        // Navigation property for related products    1 sup --- m prod
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
