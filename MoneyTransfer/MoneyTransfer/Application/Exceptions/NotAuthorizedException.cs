namespace MoneyTransfer.Application.Exceptions
{
    public class NotAuthorizedException : Exception
    {
        public override string Message => "User is not authorized to perform this action.";
    }
}
