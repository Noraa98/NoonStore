using System.ComponentModel.DataAnnotations;

namespace Noon.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }


        // Foreign key to Supplier
        public int SupplierId { get; set; }
        // Navigation property to Supplier
        public virtual Supplier Supplier { get; set; }



        // Navigation property for related order items   1 prod --- m orderItem
        public ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();

    }
}
