using System.Security.Cryptography;

namespace MoneyTransfer.Application.Services
{
    public class HashService
    {
        public void CreateHashWithSalt(string text, out byte[] textHash, out byte[] salt)
        {
            var hmac = new HMACSHA512();
            salt = hmac.Key;
            textHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(text));
        }
    }
}
