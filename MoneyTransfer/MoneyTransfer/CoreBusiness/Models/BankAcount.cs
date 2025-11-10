using System.ComponentModel.DataAnnotations;

namespace MoneyTransfer.CoreBusiness.Models
{
    public class BankAcount
    {
        public int Id { get; set; }

        public double Balance { get; set; }
    }
}