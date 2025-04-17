
namespace HealthyFood.Models
{
    public class User: IdentityUser
    {
        public City City { get; set; } 

        public ICollection<Order> Orders { get; set; } 
        public ICollection<Review> Reviews { get; set; }
    }
}
