using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyTransfer.Application.Models;
using MoneyTransfer.Application.UseCases.AccountUseCases;
using MoneyTransfer.Controllers.ExceptionFilters;

namespace MoneyTransfer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController(
        GetAccountBalanceUseCase getAccountBalanceUseCase, 
        TransferMoneyUseCase transferMoneyUseCase,
        Get10LastTransactionsForAccountUseCase get10LastTransactionsForAccountUseCase) : ControllerBase
    {
        private readonly GetAccountBalanceUseCase _getAccountBalanceUseCase = getAccountBalanceUseCase;
        private readonly TransferMoneyUseCase _transferMoneyUseCase = transferMoneyUseCase;
        private readonly Get10LastTransactionsForAccountUseCase _get10LastTransactionsForAccountUseCase = get10LastTransactionsForAccountUseCase;

        [HttpGet("balance/{id}")]
        [Account_HandleAccountNotFoundExeption]
        public async Task<IActionResult> GetAccountBalance([FromRoute]int id)
        {
            var balance = await _getAccountBalanceUseCase.ExecuteAsync(id);
            return Ok(balance);
        }

        [HttpPost("transfer")]
        [Account_HandleAccountNotFoundExeption]
        [Account_HandleTransferExceptionsFilter]
        public async Task<IActionResult> TransferMoney([FromBody]MoneyTransferDto moneyTransferDto)
        {
            await _transferMoneyUseCase.ExecuteAsync(moneyTransferDto.FromAccountId, moneyTransferDto.ToAccountId, moneyTransferDto.Amount);
            return Ok();
        }

        [HttpGet("last-10-transactions/{id}")]
        [Account_HandleAccountNotFoundExeption]
        public async Task<IActionResult> GetLast10Transactions([FromRoute] int id)
        {
            var transactions = await _get10LastTransactionsForAccountUseCase.ExecuteAsync(id);
            return Ok(transactions);
        }
    }
}