namespace MoneyTransfer.Application.Exceptions
{
    public class DailyTransferLimitReachedException : Exception
    {
        public override string Message => "Daily transfer limit reached.";
    }
}
