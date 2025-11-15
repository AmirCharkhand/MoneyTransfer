using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MoneyTransfer.Application.Exceptions;

namespace MoneyTransfer.Controllers.ExceptionFilters
{
    public class Account_HandleAuthorizationExceptionsFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            if (context.Exception is NotAuthenticatedException || context.Exception is NotAuthorizedException)
            {
                context.ExceptionHandled = true;
                context.HttpContext.Response.StatusCode = 401;
                context.Result = new UnauthorizedObjectResult(context.Exception.Message);
            }
        }
    }
}
