using Microsoft.AspNetCore.Mvc;
using MoneyTransfer.Application.Models;
using MoneyTransfer.Application.UseCases.Account;

namespace MoneyTransfer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController(GetAccountBalanceUseCase getAccountBalanceUseCase, TransferMoneyUseCase transferMoneyUseCase) : ControllerBase
    {
        private readonly GetAccountBalanceUseCase _getAccountBalanceUseCase = getAccountBalanceUseCase;
        private readonly TransferMoneyUseCase _transferMoneyUseCase = transferMoneyUseCase;

        [HttpGet("balance/{id}")]
        public async Task<IActionResult> GetAccountBalance([FromRoute]int id)
        {
            var balance = await _getAccountBalanceUseCase.ExecuteAsync(id);
            return Ok(balance);
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> TransferMoney([FromBody]MoneyTransferDto moneyTransferDto)
        {
            await _transferMoneyUseCase.ExecuteAsync(moneyTransferDto.FromAccountId, moneyTransferDto.ToAccountId, moneyTransferDto.Amount);
            return Ok();
        }
    }
}
