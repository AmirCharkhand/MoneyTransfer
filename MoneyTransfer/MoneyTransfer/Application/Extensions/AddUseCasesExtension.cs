using MoneyTransfer.Application.UseCases.AccountUseCases;
using MoneyTransfer.Application.UseCases.AuthenticationUseCases;
using MoneyTransfer.Application.UseCases.UserUseCases;

namespace MoneyTransfer.Application.Extensions
{
    public static class AddUseCasesExtension
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services
                .AddTransient<GetAccountBalanceUseCase>()
                .AddTransient<TransferMoneyUseCase>()
                .AddTransient<Get10LastTransactionsForAccountUseCase>()
                .AddTransient<AddNewUserUseCase>()
                .AddTransient<LoginUseCase>();

            return services;
        }
    }
}