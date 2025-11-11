using Microsoft.IdentityModel.Tokens;
using MoneyTransfer.CoreBusiness.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MoneyTransfer.Application.Services
{
    public class JwtService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public string GenerateToken(User user)
        {
            var secret = _configuration["JwtSecret"];
            if (string.IsNullOrEmpty(secret))
                throw new InvalidOperationException("JWT secret is not configured.");

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public int? GetUserIdFromToken()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user is null)
                return null;

            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim is null)
                return null;

            if (int.TryParse(userIdClaim.Value, out int userId))
                return userId;

            return null;
        }
    }
}
