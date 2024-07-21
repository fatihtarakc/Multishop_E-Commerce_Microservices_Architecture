using Microsoft.AspNetCore.Identity;

namespace Multishop.IdentityServer4.Data.Entities
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}