using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MoneyTransfer.Application.Exceptions;

namespace MoneyTransfer.Controllers.ExceptionFilters
{
    public class Account_HandleTransferExceptionsFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            if (context.Exception is NotEnoughAccountBalanceException)
            {
                context.ExceptionHandled = true;
                context.HttpContext.Response.StatusCode = 400;
                context.Result = new BadRequestObjectResult(context.Exception.Message);
            }
            else if (context.Exception is DailyTransferLimitReachedException)
            {
                context.ExceptionHandled = true;
                context.HttpContext.Response.StatusCode = 400;
                context.Result = new BadRequestObjectResult(context.Exception.Message);
            }
        }
    }
}
