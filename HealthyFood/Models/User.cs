using Microsoft.AspNetCore.Identity;

namespace HealthyFood.Models
{
    public class User: IdentityUser
    {
        public string Address { get; set; } 

        public ICollection<Order> Orders { get; set; } 
        public ICollection<Review> Reviews { get; set; }
    }
}
