using Microsoft.EntityFrameworkCore;
using MoneyTransfer.Application.Services;
using MoneyTransfer.Infrastructure.Data;

namespace MoneyTransfer.Application.Extensions
{
    public static class AddApplicationServicesExtension
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DevelopmentConnectionString")));

            services.AddTransient<HashService>();

            services
                .AddRepositories()
                .AddUseCases();
        }
    }
}
