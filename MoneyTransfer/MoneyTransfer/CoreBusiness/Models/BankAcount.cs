using System.Text.Json.Serialization;

namespace MoneyTransfer.CoreBusiness.Models
{
    public class BankAcount
    {
        public int Id { get; set; }
        public double Balance { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
    }
}