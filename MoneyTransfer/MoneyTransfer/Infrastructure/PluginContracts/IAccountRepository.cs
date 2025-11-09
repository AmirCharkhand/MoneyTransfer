using MoneyTransfer.CoreBusiness.Models;

namespace MoneyTransfer.Infrastructure.PluginContracts
{
    public interface IAccountRepository
    {
        public Task<BankAcount?> GetBankAcountByIdAsync(int id);
        public Task<double?> GetAccountBalanceAsync(int accountId);
        public Task UpdateAccountBalance(int accountId, double newBalance);
    }
}
