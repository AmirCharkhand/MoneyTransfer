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

        public bool VerifyHash(string text, byte[] hashedText, byte[] salt)
        {
            var hmac = new HMACSHA512(salt);
            var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(text));
            return computeHash.SequenceEqual(hashedText);
        }
    }
}
