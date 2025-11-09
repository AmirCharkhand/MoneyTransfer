using MoneyTransfer.CoreBusiness.Enums;

namespace MoneyTransfer.CoreBusiness.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        public Guid Number { get; set; }
        public int AccountId { get; set; }
        public BankAcount? Acount { get; set; }
        public TransactionType Type { get; set; }
        public double BalanceBefore { get; set; }
        public double Amount { get; set; }
        public double BalanceAfter { get; set; }
        public DateTime TransactionTime { get; set; }
    }
}