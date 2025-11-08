using MoneyTransfer.CoreBusiness.Models;
using MoneyTransfer.Infrastructure.PluginContracts;

namespace MoneyTransfer.Infrastructure.Repositories.InMemory
{
    public class AccountRepository : IAccountRepository
    {
        private readonly List<BankAcount> _accounts;

        public AccountRepository() 
        {
            _accounts = new List<BankAcount>()
            {
                new () { Id = 1, Balance = 1000, UserId = 1 },
                new () { Id = 2, Balance = 2500, UserId = 2 },
                new () { Id = 3, Balance = 500, UserId = 1 }
            };
        }
        public Task<double> GetAccountBalanceAsync(int accountId)
        {
            throw new NotImplementedException();
        }
    }
}
