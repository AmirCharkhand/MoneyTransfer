using MoneyTransfer.Application.Exceptions;
using MoneyTransfer.Application.Services;
using MoneyTransfer.Infrastructure.PluginContracts;

namespace MoneyTransfer.Application.UseCases.AccountUseCases
{
    public class GetAccountBalanceUseCase(IAccountRepository accountRepository, JwtService jwtService)
    {
        private readonly IAccountRepository _accountRepository = accountRepository;
        private readonly JwtService _jwtService = jwtService;

        public async Task<double?> ExecuteAsync(int accountId)
        {
            var userId = _jwtService.GetUserIdFromToken()
                ?? throw new NotAuthenticatedException();

            var owner = await _accountRepository.GetAccountOwner(accountId)
                ?? throw new AccountNotFoundException(accountId);

            if (owner.Id != userId)
                throw new NotAuthorizedException();

            return await _accountRepository.GetAccountBalanceAsync(accountId);
        }
    }
}