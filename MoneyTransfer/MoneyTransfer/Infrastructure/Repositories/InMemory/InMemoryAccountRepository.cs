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
                new () { Id = 1, Balance = 1000, UserId = 1 },
                new () { Id = 2, Balance = 2500, UserId = 2 },
                new () { Id = 3, Balance = 500, UserId = 1 }
            };
        }
        public async Task<double?> GetAccountBalanceAsync(int accountId)
        {
            var balance = _accounts.FirstOrDefault(a => a.Id == accountId)?.Balance;
            await Task.CompletedTask;
            return balance;
        }
    }
}