namespace MoneyTransfer.Application.Models
{
    public class LoginResponseDto
    {
        public string? Token { get; set; }
        public string? Email { get; set; }
        public bool Succeeded { get; set; }
    }
}
