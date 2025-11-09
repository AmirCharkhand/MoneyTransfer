using MoneyTransfer.Infrastructure.PluginContracts;

namespace MoneyTransfer.Application.UseCases.Account
{
    public class GetAccountBalanceUseCase(IAccountRepository accountRepository)
    {
        private readonly IAccountRepository _accountRepository = accountRepository;

        public async Task<double> ExecuteAsync(int accountId)
        {
            double balance = await _accountRepository.GetAccountBalanceAsync(accountId);
            return balance;
        }
    }
}