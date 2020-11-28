using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace APIGateway.Fliters
{
    public class AsyncActionFilter : IAsyncActionFilter, IAsyncExceptionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Do something before the action excutes
            var resultContext = await next();
            // Do someting after action executes;
            // resultContext.Result will be set.
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            // TODO
            await Task.Delay(0);
        }
    }
}
