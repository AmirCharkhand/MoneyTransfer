using MoneyTransfer.Application.Services;

namespace MoneyTransfer.Application.Extensions
{
    public static class AddApplicationServicesExtension
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services
                .AddDbContextService(configuration)
                .AddAuthenticationService(configuration)
                .AddHttpContextAccessor()
                .AddRepositories()
                .AddUseCases();

            services.AddTransient<HashService>();
            services.AddTransient<JwtService>();
        }
    }
}
