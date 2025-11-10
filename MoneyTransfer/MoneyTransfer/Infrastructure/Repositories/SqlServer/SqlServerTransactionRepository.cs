using Microsoft.EntityFrameworkCore;
using MoneyTransfer.Application.Models;
using MoneyTransfer.CoreBusiness.Enums;
using MoneyTransfer.CoreBusiness.Models;
using MoneyTransfer.Infrastructure.Data;
using MoneyTransfer.Infrastructure.PluginContracts;

namespace MoneyTransfer.Infrastructure.Repositories.SqlServer
{
    public class SqlServerTransactionRepository(ApplicationDbContext dbContext) : ITransactionRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task AddTransaction(NewTransaction newTransaction)
        {
            _dbContext.Transactions.Add(new Transaction
            {
                AccountId = newTransaction.AccountId,
                Amount = newTransaction.Amount,
                BalanceAfter = newTransaction.BalanceAfter,
                BalanceBefore = newTransaction.BalanceBefore,
                Number = newTransaction.Number,
                TransactionTime = newTransaction.TransactionTime,
                Type = newTransaction.Type
            });

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Transaction>> GetDailyTransferAmountForAccount(int accountId, TransactionType? transctionType = null)
        {
            var transactions = await _dbContext.Transactions
                .Where(t => t.AccountId == accountId
                    && t.TransactionTime.Date == DateTime.Now.Date
                    && (!transctionType.HasValue || t.Type == transctionType))
                .ToListAsync();

            return transactions;
        }

        public async Task<List<Transaction>> GetLastTransactionsForAccount(int accountId, int numberOfTransactions)
        {
            var transactions = await _dbContext.Transactions
                .Where(t => t.AccountId == accountId)
                .OrderByDescending(t => t.TransactionTime)
                .Take(numberOfTransactions)
                .ToListAsync();

            return transactions;
        }
    }
}
