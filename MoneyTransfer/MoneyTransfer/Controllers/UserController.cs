using Microsoft.AspNetCore.Mvc;
using MoneyTransfer.Application.Models;
using MoneyTransfer.Application.UseCases.AuthenticationUseCases;
using MoneyTransfer.Controllers.ExceptionFilters;

namespace MoneyTransfer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(LoginUseCase loginUseCase) : ControllerBase
    {
        private readonly LoginUseCase _loginUseCase = loginUseCase;

        [HttpPost("login")]
        [User_HandleUserNotExistsException]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var response = await _loginUseCase.ExecuteAsync(request.Email, request.Password);
            return Ok(response);
        }
    }
}
