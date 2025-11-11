using Microsoft.EntityFrameworkCore;
using MoneyTransfer.CoreBusiness.Models;
using MoneyTransfer.Infrastructure.Data;
using MoneyTransfer.Infrastructure.PluginContracts;

namespace MoneyTransfer.Infrastructure.Repositories.SqlServer
{
    public class SqlServerUserRepository(ApplicationDbContext dbContext) : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task AddUser(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => string.Equals(u.Email.ToLower(), email.ToLower()));

            return user;
        }

        public async Task<User?> GetUserByIdWhithAccounts(int id)
        {
            var user = await _dbContext.Users
                .Include(u => u.Accounts)
                .FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }
    }
}