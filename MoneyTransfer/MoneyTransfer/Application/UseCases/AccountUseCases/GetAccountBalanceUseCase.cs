using MoneyTransfer.Application.Exceptions;
using MoneyTransfer.Infrastructure.PluginContracts;

namespace MoneyTransfer.Application.UseCases.AccountUseCases
{
    public class GetAccountBalanceUseCase(IAccountRepository accountRepository)
    {
        private readonly IAccountRepository _accountRepository = accountRepository;

        public async Task<double?> ExecuteAsync(int accountId)
        {
            return await _accountRepository.GetAccountBalanceAsync(accountId)
                ?? throw new AccountNotFoundException(accountId);
        }
    }
}