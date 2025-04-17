using HealthyFood.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthyFood.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }  

        [Required]
        public string UserId { get; set; }  

        [Required]
        public int OrderId { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }  

        [StringLength(500)]
        public string Comment { get; set; }  

        [Required]
        public DateTime ReviewDate { get; set; }  

        
        [ForeignKey("UserId")]
        public User User { get; set; }  

        [ForeignKey("OrderId")]
        public Order Order { get; set; }  
    }
}
          
