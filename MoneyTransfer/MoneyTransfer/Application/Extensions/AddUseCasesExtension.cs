using MoneyTransfer.Application.UseCases.Account;

namespace MoneyTransfer.Application.Extensions
{
    public static class AddUseCasesExtension
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services
                .AddTransient<GetAccountBalanceUseCase>()
                .AddTransient<TransferMoneyUseCase>();

            return services;
        }
    }
}