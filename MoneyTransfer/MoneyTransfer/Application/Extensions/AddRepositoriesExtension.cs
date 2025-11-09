using MoneyTransfer.Infrastructure.PluginContracts;
using MoneyTransfer.Infrastructure.Repositories.InMemory;

namespace MoneyTransfer.Application.Extensions
{
    public static class AddRepositoriesExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        { 
            services.AddSingleton<IAccountRepository,InMemoryAccountRepository> ();
            return services;
        }
    }
}
