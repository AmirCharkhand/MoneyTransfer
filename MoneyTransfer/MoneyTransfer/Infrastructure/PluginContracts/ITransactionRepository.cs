using MoneyTransfer.Application.Models;

namespace MoneyTransfer.Infrastructure.PluginContracts
{
    public interface ITransactionRepository
    {
        public Task AddTransaction(NewTransaction newTransaction);
    }
}
