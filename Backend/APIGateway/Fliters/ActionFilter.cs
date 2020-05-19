using Microsoft.AspNetCore.Mvc.Filters;

namespace APIGateway.Fliters
{
    public class ActionFilter : IActionFilter, IExceptionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //TODO
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //TODO
        }

        public void OnException(ExceptionContext context)
        {
            //TODO do something.
        }
    }
}
