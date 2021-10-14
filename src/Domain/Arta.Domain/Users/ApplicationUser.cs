using Microsoft.AspNetCore.Identity;

namespace Domain.Models.Users
{
    public class ApplicationUser: IdentityUser
    {
        public ApplicationUser()
        {

        }
        public User User { get; set; }
    }
}