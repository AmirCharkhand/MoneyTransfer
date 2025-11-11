using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MoneyTransfer.Application.Exceptions;

namespace MoneyTransfer.Controllers.ExceptionFilters
{
    public class User_HandleUserNotExistsException : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            if (context.Exception is UserNotExistsException)
            {
                context.ExceptionHandled = true;
                context.HttpContext.Response.StatusCode = 404;
                context.Result = new NotFoundObjectResult(context.Exception.Message);
            }
        }
    }
}
