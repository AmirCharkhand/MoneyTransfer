using System.ComponentModel.DataAnnotations;

namespace MoneyTransfer.CoreBusiness.Models
{
    public class BankAcount
    {
        public int Id { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Balance cannot be negative.")]
        public double Balance { get; set; }

        [Required]
        public int UserId { get; set; }

        public User? User { get; set; }
    }
}