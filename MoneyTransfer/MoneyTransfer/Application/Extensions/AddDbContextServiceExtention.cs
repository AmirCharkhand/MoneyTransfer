using Microsoft.EntityFrameworkCore;
using MoneyTransfer.Infrastructure.Data;

namespace MoneyTransfer.Application.Extensions
{
    public static class AddDbContextServiceExtention
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DevelopmentConnectionString")));

            return services;
        }
    }
}