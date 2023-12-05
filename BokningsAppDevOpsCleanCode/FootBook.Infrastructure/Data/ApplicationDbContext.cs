using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BokningsAppDevOpsCleanCode.Data
{
    public class FootBookDbContext : IdentityDbContext<IdentityUser>
    {
        public FootBookDbContext(DbContextOptions<FootBookDbContext> options)
            : base(options)
        {

        }
        public DbSet<Models.Booking> Bookings { get; set; }
    }
}