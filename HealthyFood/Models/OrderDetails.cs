
namespace HealthyFood.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailsId { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; } 

        [ForeignKey("Product")]
        public int ProductId { get; set; }  

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; } 

        [Range(0, double.MaxValue)]

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Subtotal { get; set; }
        public Order Order { get; set; }  
        public Product Product { get; set; }
    }
}
