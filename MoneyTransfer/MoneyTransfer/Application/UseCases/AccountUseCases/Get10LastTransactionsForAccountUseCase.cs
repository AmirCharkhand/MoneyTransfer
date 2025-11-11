using MoneyTransfer.CoreBusiness.Models;
using MoneyTransfer.Infrastructure.PluginContracts;

namespace MoneyTransfer.Application.UseCases.AccountUseCases
{
    public class Get10LastTransactionsForAccountUseCase(ITransactionRepository transactionRepository)
    {
        private readonly ITransactionRepository _transactionRepository = transactionRepository;

        public async Task<List<Transaction>> ExecuteAsync(int accountId)
        {
           return await _transactionRepository.GetLastTransactionsForAccount(accountId, 10);
        }
    }
}
