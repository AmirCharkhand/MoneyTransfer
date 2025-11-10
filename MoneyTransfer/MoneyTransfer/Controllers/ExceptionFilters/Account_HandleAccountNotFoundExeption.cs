using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MoneyTransfer.Application.Exceptions;

namespace MoneyTransfer.Controllers.ExceptionFilters
{
    public class Account_HandleAccountNotFoundExeption : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            if (context.Exception is AccountNotFoundException)
            {
                context.ExceptionHandled = true;
                context.HttpContext.Response.StatusCode = 404;
                context.Result = new NotFoundObjectResult(context.Exception.Message);
            }
        }
    }
}