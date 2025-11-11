using MoneyTransfer.Application.Exceptions;
using MoneyTransfer.Application.Models;
using MoneyTransfer.Application.Services;
using MoneyTransfer.CoreBusiness.Enums;
using MoneyTransfer.CoreBusiness.Models;
using MoneyTransfer.Infrastructure.PluginContracts;

namespace MoneyTransfer.Application.UseCases.AccountUseCases
{
    public class TransferMoneyUseCase(IAccountRepository accountRepository, ITransactionRepository transactionRepository, JwtService jwtService)
    {
        private readonly IAccountRepository _accountRepository = accountRepository;
        private readonly ITransactionRepository _transactionRepository = transactionRepository;
        private readonly JwtService _jwtService = jwtService;

        public async Task ExecuteAsync(int fromAccountId, int toAccountId, double amount)
        {
            var userId = _jwtService.GetUserIdFromToken()
                ?? throw new NotAuthenticatedException();

            var fromAccountOwner = await _accountRepository.GetAccountOwner(fromAccountId)
                ?? throw new AccountNotFoundException(fromAccountId);

            if (fromAccountOwner.Id != userId)
                throw new NotAuthorizedException();

            var fromAccount = await _accountRepository.GetBankAcountByIdAsync(fromAccountId);

            var toAccount = await _accountRepository.GetBankAcountByIdAsync(toAccountId)
                ?? throw new AccountNotFoundException(toAccountId);

            CheckFromAccountBalance(amount, fromAccount);

            await CheckDailyLimit(fromAccountId, amount);

            await CreateTransactions(fromAccountId, toAccountId, amount, fromAccount, toAccount);

            await UpdateBalances(fromAccountId, toAccountId, amount, fromAccount, toAccount);
        }

        private async Task CheckDailyLimit(int fromAccountId, double amount)
        {
            var dailyTransfers = await _transactionRepository.GetDailyTransferAmountForAccount(fromAccountId, TransactionType.Decremental);
            if (dailyTransfers.Sum(t => t.Amount) + amount > 10000000)
                throw new DailyTransferLimitReachedException();
        }

        private static void CheckFromAccountBalance(double amount, BankAcount fromAccount)
        {
            if (fromAccount.Balance < amount)
                throw new NotEnoughAccountBalanceException();
        }

        private async Task UpdateBalances(int fromAccountId, int toAccountId, double amount, BankAcount fromAccount, BankAcount toAccount)
        {
            await _accountRepository.UpdateAccountBalance(fromAccountId, fromAccount.Balance - amount);
            await _accountRepository.UpdateAccountBalance(toAccountId, toAccount.Balance + amount);
        }

        private async Task CreateTransactions(int fromAccountId, int toAccountId, double amount, BankAcount fromAccount, BankAcount toAccount)
        {
            var fromAccountTransaction = new NewTransaction(
                Guid.NewGuid(),
                fromAccountId,
                fromAccount,
                TransactionType.Decremental,
                fromAccount.Balance,
                amount);

            var toAccountTransaction = new NewTransaction(
                Guid.NewGuid(),
                toAccountId,
                toAccount,
                TransactionType.Incremental,
                toAccount.Balance,
                amount);

            await _transactionRepository.AddTransaction(fromAccountTransaction);
            await _transactionRepository.AddTransaction(toAccountTransaction);
        }
    }
}