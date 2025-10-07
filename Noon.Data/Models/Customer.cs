using System.ComponentModel.DataAnnotations;

namespace Noon.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }


        // Navigation property for related orders   1 cust --- m order
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
