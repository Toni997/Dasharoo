using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DasharooAPI.Data
{
    public class DasharooDbContext : IdentityDbContext<User>
    {
        public DasharooDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
