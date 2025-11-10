namespace MoneyTransfer.Application.Exceptions
{
    public class NotEnoughAccountBalanceException : Exception
    {
        public override string Message => "Not enough account balance to perform the transfer.";
    }
}