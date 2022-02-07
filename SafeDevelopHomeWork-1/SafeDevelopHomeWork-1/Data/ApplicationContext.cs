using Microsoft.AspNet.Identity.EntityFramework;
using SafeDevelopHomeWork_1.Models;
using Microsoft.EntityFrameworkCore;

namespace SafeDevelopHomeWork_1.Data
{
    public class ApplicationContext:IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
