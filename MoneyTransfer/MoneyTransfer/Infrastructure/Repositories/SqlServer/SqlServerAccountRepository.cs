using Microsoft.EntityFrameworkCore;
using MoneyTransfer.CoreBusiness.Models;
using MoneyTransfer.Infrastructure.Data;
using MoneyTransfer.Infrastructure.PluginContracts;

namespace MoneyTransfer.Infrastructure.Repositories.SqlServer
{
    public class SqlServerAccountRepository(ApplicationDbContext dbContext) : IAccountRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<double?> GetAccountBalanceAsync(int accountId)
        {
            var account = await GetBankAcountByIdAsync(accountId);

            return account?.Balance;
        }

        public async Task<BankAcount?> GetBankAcountByIdAsync(int id)
        {
            return await _dbContext.BankAccounts
                .FirstOrDefaultAsync(ba => ba.Id == id);
        }

        public async Task UpdateAccountBalance(int accountId, double newBalance)
        {
            var account = await GetBankAcountByIdAsync(accountId);
            if (account is null || newBalance < 0)
                return;

            account.Balance = newBalance;
            await _dbContext.SaveChangesAsync();
        }
    }
}
