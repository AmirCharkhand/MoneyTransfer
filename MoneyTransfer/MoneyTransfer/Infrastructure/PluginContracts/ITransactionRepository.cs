using MoneyTransfer.Application.Models;
using MoneyTransfer.CoreBusiness.Enums;
using MoneyTransfer.CoreBusiness.Models;

namespace MoneyTransfer.Infrastructure.PluginContracts
{
    public interface ITransactionRepository
    {
        public Task AddTransaction(NewTransaction newTransaction);
        public Task<IEnumerable<Transaction>> GetDailyTransferAmountForAccount(int accountId, TransactionType? transctionType = null);
    }
}
