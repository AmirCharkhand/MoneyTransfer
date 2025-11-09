using Microsoft.AspNetCore.Mvc;
using MoneyTransfer.Application.UseCases.Account;

namespace MoneyTransfer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController(GetAccountBalanceUseCase getAccountBalanceUseCase) : ControllerBase
    {
        private readonly GetAccountBalanceUseCase _getAccountBalanceUseCase = getAccountBalanceUseCase;

        [HttpGet("balance/{id}")]
        public async Task<IActionResult> GetAccountBalance([FromRoute]int id)
        {
            var balance = await _getAccountBalanceUseCase.ExecuteAsync(id);
            return Ok(balance);
        }
    }
}
