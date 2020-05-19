using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace APIGateway.Fliters
{
    /// <summary>
    /// Logging filter.
    /// Use for write log.
    /// </summary>
    public class LoggerFilter : IActionFilter
    {
        private readonly ILogger<LoggerFilter> _logger;
        public LoggerFilter(ILogger<LoggerFilter> log)
        {
            _logger = log;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("");
        }
    }
}
