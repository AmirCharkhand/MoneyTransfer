namespace MoneyTransfer.Application.Exceptions
{
    public class NotAuthenticatedException : Exception
    {
        public override string Message => "User is not authenticated.";
    }
}
