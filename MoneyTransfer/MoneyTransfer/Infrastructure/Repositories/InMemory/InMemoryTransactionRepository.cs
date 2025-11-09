using MoneyTransfer.Application.Models;
using MoneyTransfer.CoreBusiness.Models;
using MoneyTransfer.Infrastructure.PluginContracts;

namespace MoneyTransfer.Infrastructure.Repositories.InMemory
{
    public class InMemoryTransactionRepository : ITransactionRepository
    {
        private readonly List<Transaction> _transactions = new();

        public async Task AddTransaction(NewTransaction newTransaction)
        {
            var transaction = new Transaction()
            {
                ID = _transactions.Count + 1,
                AccountId = newTransaction.AccountId,
                Acount = newTransaction.Acount,
                Amount = newTransaction.Amount,
                BalanceBefore = newTransaction.BalanceBefore,
                BalanceAfter = newTransaction.BalanceAfter,
                Type = newTransaction.Type,
                Number = newTransaction.Number,
                TransactionTime = newTransaction.TransactionTime
            };

            _transactions.Add(transaction);
            await Task.CompletedTask;
        }
    }
}
