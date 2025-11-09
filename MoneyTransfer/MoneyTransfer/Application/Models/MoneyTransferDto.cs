using System.ComponentModel.DataAnnotations;

namespace MoneyTransfer.Application.Models
{
    public class MoneyTransferDto
    {
        [Required]
        public int FromAccountId { get; set; }

        [Required]
        public int ToAccountId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Amount { get; set; }
    }
}
