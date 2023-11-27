using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BokningsAppDevOpsCleanCode.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Models.Booking> Bookings { get; set; }
        public DbSet<Models.Calander> Calenders { get; set; }
        public DbSet<Models.Day> Days { get; set; }
        public DbSet<Models.Time> Times { get; set; }
        public DbSet<Models.Week> Weeks { get; set; }
    }
}