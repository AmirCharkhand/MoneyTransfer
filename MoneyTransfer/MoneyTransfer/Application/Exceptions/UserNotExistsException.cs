namespace MoneyTransfer.Application.Exceptions
{
    public class UserNotExistsException : Exception
    {
        public override string Message => "The specified user does not exist.";
    }
}
