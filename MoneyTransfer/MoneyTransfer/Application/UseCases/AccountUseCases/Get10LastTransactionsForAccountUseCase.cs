using MoneyTransfer.Application.Exceptions;
using MoneyTransfer.Application.Services;
using MoneyTransfer.CoreBusiness.Models;
using MoneyTransfer.Infrastructure.PluginContracts;

namespace MoneyTransfer.Application.UseCases.AccountUseCases
{
    public class Get10LastTransactionsForAccountUseCase(ITransactionRepository transactionRepository, IAccountRepository accountRepository, JwtService jwtService)
    {
        private readonly ITransactionRepository _transactionRepository = transactionRepository;
        private readonly IAccountRepository _accountRepository = accountRepository;
        private readonly JwtService _jwtService = jwtService;

        public async Task<List<Transaction>> ExecuteAsync(int accountId)
        {
            var userId = _jwtService.GetUserIdFromToken()
                ?? throw new NotAuthenticatedException();

            var owner = await _accountRepository.GetAccountOwner(accountId)
                ?? throw new AccountNotFoundException(accountId);

            if (owner.Id != userId)
                throw new NotAuthorizedException();

            return await _transactionRepository.GetLastTransactionsForAccount(accountId, 10);
        }
    }
}
