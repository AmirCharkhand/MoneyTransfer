using MoneyTransfer.Application.Models;
using MoneyTransfer.CoreBusiness.Enums;
using MoneyTransfer.CoreBusiness.Models;

namespace MoneyTransfer.Infrastructure.PluginContracts
{
    public interface ITransactionRepository
    {
        public Task AddTransaction(NewTransaction newTransaction);
        public Task<List<Transaction>> GetDailyTransferAmountForAccount(int accountId, TransactionType? transctionType = null);
        public Task<List<Transaction>> GetLastTransactionsForAccount(int accountId, int numberOfTransactions);
    }
}
