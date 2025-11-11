using MoneyTransfer.CoreBusiness.Models;

namespace MoneyTransfer.Infrastructure.PluginContracts
{
    public interface IUserRepository
    {
        public Task AddUser(User user);
        public Task<User?> GetUserByEmail(string email);
    }
}