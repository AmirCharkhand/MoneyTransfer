namespace MoneyTransfer.Application.Exceptions
{
    public class UserExistsException : Exception
    {
        public override string Message => "A user with the provided email already exists.";
    }
}
