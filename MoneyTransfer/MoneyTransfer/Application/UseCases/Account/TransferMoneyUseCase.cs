using MoneyTransfer.Application.Models;
using MoneyTransfer.CoreBusiness.Enums;
using MoneyTransfer.Infrastructure.PluginContracts;

namespace MoneyTransfer.Application.UseCases.Account
{
    public class TransferMoneyUseCase(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
    {
        private readonly IAccountRepository _accountRepository = accountRepository;
        private readonly ITransactionRepository _transactionRepository = transactionRepository;

        public async Task ExecuteAsync(int fromAccountId, int toAccountId, double amount)
        {
            var fromAccount = await _accountRepository.GetBankAcountByIdAsync(fromAccountId);
            var toAccount = await _accountRepository.GetBankAcountByIdAsync(toAccountId);

            if (fromAccount is null || toAccount is null)
                return;

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

            await Task.WhenAll(
                _transactionRepository.AddTransaction(fromAccountTransaction),
                _transactionRepository.AddTransaction(toAccountTransaction));

            await Task.WhenAll(
                _accountRepository.UpdateAccountBalance(fromAccountId, fromAccount.Balance - amount),
                _accountRepository.UpdateAccountBalance(toAccountId, toAccount.Balance + amount));
        }
    }
}