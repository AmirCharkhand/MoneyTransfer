using System.ComponentModel.DataAnnotations;

namespace MoneyTransfer.CoreBusiness.Models
{
    public class BankAcount
    {
        public int Id { get; set; }
        public double Balance { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}