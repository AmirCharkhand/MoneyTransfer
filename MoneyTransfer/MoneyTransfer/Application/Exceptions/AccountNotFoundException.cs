namespace MoneyTransfer.Application.Exceptions
{
    public class AccountNotFoundException(int accountId) : Exception
    {
        public override string Message => $"Account with ID {accountId} was not found.";
    }
}