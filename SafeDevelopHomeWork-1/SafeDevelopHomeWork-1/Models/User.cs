using Microsoft.AspNet.Identity.EntityFramework;

namespace SafeDevelopHomeWork_1.Models
{
    public class User:IdentityUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }


    }
}
