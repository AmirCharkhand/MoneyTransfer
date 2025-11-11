using MoneyTransfer.Infrastructure.PluginContracts;
using MoneyTransfer.Infrastructure.Repositories.InMemory;
using MoneyTransfer.Infrastructure.Repositories.SqlServer;

namespace MoneyTransfer.Application.Extensions
{
    public static class AddRepositoriesExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services
                .AddScoped<IAccountRepository, SqlServerAccountRepository>()
                .AddScoped<ITransactionRepository, SqlServerTransactionRepository>()
                .AddScoped<IUserRepository, SqlServerUserRepository>();

            return services;
        }
    }
}
