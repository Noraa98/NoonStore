namespace Noon.Data.Models
{
    public class OrderItem
    {

        // Composite key (OrderId, ProductId) will be configured in DbContext using Fluent API
        public int OrderId { get; set; }
        public Order Order { get; set; }


        public int ProductId { get; set; }
        public Product Product { get; set; }


        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
