using MoneyTransfer.Application.Exceptions;
using MoneyTransfer.Application.Models;
using MoneyTransfer.Application.Services;
using MoneyTransfer.Infrastructure.PluginContracts;

namespace MoneyTransfer.Application.UseCases.AuthenticationUseCases
{
    public class LoginUseCase(IUserRepository userRepository, HashService hashService, JwtService jwtService)
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly HashService _hashService = hashService;
        private readonly JwtService _jwtService = jwtService;

        public async Task<LoginResponseDto> ExecuteAsync(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email)
                ?? throw new UserNotExistsException();

            if (_hashService.VerifyHash(password, user.PasswordHash, user.PasswordSalt))
            {
                var token = _jwtService.GenerateToken(user);

                return new LoginResponseDto
                {
                    Token = token,
                    Email = user.Email,
                    Succeeded = true
                };
            }
            else
            {
                return new LoginResponseDto
                {
                    Email = user.Email,
                    Succeeded = false
                };
            }
        }
    }
}
