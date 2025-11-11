using MoneyTransfer.Application.Exceptions;
using MoneyTransfer.Application.Services;
using MoneyTransfer.CoreBusiness.Models;
using MoneyTransfer.Infrastructure.PluginContracts;

namespace MoneyTransfer.Application.UseCases.UserUseCases
{
    public class AddNewUserUseCase(IUserRepository userRepository, HashService hashService)
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly HashService _hashService = hashService;

        public async Task ExecuteAsync(string firstName, string lastName, string email, string password, string? phoneNumber = null)
        {
            if (await _userRepository.GetUserByEmail(email) is not null)
                throw new UserExistsException();

            var newUser = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber
            };

            _hashService.CreateHashWithSalt(password, out byte[] passwordHash, out byte[] passwordSalt);
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;

            await _userRepository.AddUser(newUser);
        }
    }
}