namespace HealthyFood.ViewModel
{
    public class ProductAddVM
    {
        [Required]
        [StringLength(200)]
        [MinLength(3)]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

       // public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
