using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HealthyFood.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }  

        [Required]
        [StringLength(200)]
        public string Name { get; set; }  

        [Range(0, double.MaxValue)]

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }  

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }
        public string ImageUrl { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }  
        public Category Category { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }

    }
}
