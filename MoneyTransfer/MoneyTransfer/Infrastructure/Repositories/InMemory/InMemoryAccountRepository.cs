using MoneyTransfer.CoreBusiness.Models;
using MoneyTransfer.Infrastructure.PluginContracts;

namespace MoneyTransfer.Infrastructure.Repositories.InMemory
{
    public class InMemoryAccountRepository : IAccountRepository
    {
        private readonly List<BankAcount> _accounts;

        public InMemoryAccountRepository() 
        {
            _accounts = new List<BankAcount>()
            {
                new () { Id = 1, Balance = 10000000 },
                new () { Id = 2, Balance = 25000000 },
                new () { Id = 3, Balance = 5000000 }
            };
        }
        public async Task<double?> GetAccountBalanceAsync(int accountId)
        {
            var balance = _accounts.FirstOrDefault(a => a.Id == accountId)?.Balance;
            await Task.CompletedTask;
            return balance;
        }

        public async Task<BankAcount?> GetBankAcountByIdAsync(int id)
        {
            var account = _accounts.FirstOrDefault(a =>a.Id == id);
            await Task.CompletedTask;

            return account;

        }

        public async Task UpdateAccountBalance(int accountId, double newBalance)
        {
            var account = _accounts.FirstOrDefault(a => a.Id == accountId);

            if (account is null || newBalance < 0)
                return;

            account.Balance = newBalance;
            await Task.CompletedTask;
        }
    }
}