
namespace HealthyFood.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public string UserId { get; set; } 

        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }  

        [Range(0, double.MaxValue)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice { get; set; } 

        [Required]
        [StringLength(50)]
        public string Status { get; set; } 

        public ICollection<OrderDetails> OrderDetails { get; set; }
        public Review Review { get; set; }
    }
}
