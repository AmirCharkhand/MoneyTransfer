namespace MoneyTransfer.Infrastructure.PluginContracts
{
    public interface IAccountRepository
    {
        public Task<double?> GetAccountBalanceAsync(int accountId);
    }
}
