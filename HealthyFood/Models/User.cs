
namespace HealthyFood.Models
{
    public class User: IdentityUser
    {
        public string FullName { get; set; }
        public City City { get; set; } 

        public ICollection<Order> Orders { get; set; } 
        public ICollection<Review> Reviews { get; set; }
    }
}
