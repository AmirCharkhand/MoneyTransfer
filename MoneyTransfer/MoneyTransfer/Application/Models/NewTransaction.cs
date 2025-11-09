using MoneyTransfer.CoreBusiness.Enums;
using MoneyTransfer.CoreBusiness.Models;

namespace MoneyTransfer.Application.Models
{
    public class NewTransaction
    {
        public Guid Number { get; init; }
        public int AccountId { get; init; }
        public BankAcount Acount { get; init; }
        public TransactionType Type { get; init; }
        public double BalanceBefore { get; init; }
        public double Amount { get; init; }
        public double BalanceAfter { get; init; }
        public DateTime TransactionTime { get; init; }

        public NewTransaction(Guid number, int accountId, BankAcount acount, TransactionType type, double balanceBefore, double amount)
        {
            Number = number;
            AccountId = accountId;
            Acount = acount;
            Type = type;
            BalanceBefore = balanceBefore;
            Amount = amount;
            TransactionTime = DateTime.Now;
            BalanceAfter = CalculateBalanceAfter();
        }

        private double CalculateBalanceAfter()
        {
            switch (this.Type)
            {
                case TransactionType.Incremental:
                    return this.BalanceBefore + this.Amount;
                case TransactionType.Decremental:
                    return this.BalanceBefore - this.Amount;
                default:
                    throw new ArgumentOutOfRangeException(nameof(this.Type));
            }
        }
    }
}