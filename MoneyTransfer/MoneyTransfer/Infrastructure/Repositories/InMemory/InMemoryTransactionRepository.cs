using MoneyTransfer.Application.Models;
using MoneyTransfer.CoreBusiness.Enums;
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

        public async Task<List<Transaction>> GetDailyTransferAmountForAccount(int accountId, TransactionType? transactionType = null)
        {
            var transactions = _transactions
                .Where(t => t.AccountId == accountId
                    && t.TransactionTime.Date == DateTime.Now.Date
                    && (!transactionType.HasValue || t.Type == transactionType))
                .ToList();

            await Task.CompletedTask;
            return transactions;
        }

        public async Task<List<Transaction>> GetLastTransactionsForAccount(int accountId, int numberOfTransactions)
        {
            var transactions = _transactions
                .Where(t => t.AccountId == accountId)
                .Reverse()
                .Take(numberOfTransactions)
                .ToList();

            await Task.CompletedTask;
            return transactions;
        }
    }
}
