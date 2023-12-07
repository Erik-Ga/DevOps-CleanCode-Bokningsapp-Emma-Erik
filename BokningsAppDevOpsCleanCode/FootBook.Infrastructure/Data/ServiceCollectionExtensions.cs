using BokningsAppDevOpsCleanCode.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FootBook.Infrastructure.Data
{
    public static class ServiceCollectionExtensions
    {
        public static void AddFootBookDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<FootBookDbContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}
