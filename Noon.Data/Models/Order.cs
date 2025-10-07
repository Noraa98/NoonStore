using System.ComponentModel.DataAnnotations.Schema;

namespace Noon.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderedAt { get; set; } = DateTime.UtcNow;
        public int TotalAmount { get; set; }


        // Foreign key to Customer
        public int CustomerId { get; set; }

        // Navigation property to Customer
        public virtual Customer Customer { get; set; }


        // Navigation property for related order items   1 order --- m orderItem
        public ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();

        // computed (not mapped) example
        [NotMapped]
        public decimal Total => ComputeTotal();
        private decimal ComputeTotal()
        {
            decimal sum = 0;
            foreach (var oi in OrderItems)
                sum += oi.Quantity * oi.UnitPrice;
            return sum;
        }


    }
}
