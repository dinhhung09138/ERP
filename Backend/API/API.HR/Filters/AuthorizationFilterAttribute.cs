using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Service.System.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net;

namespace API.HR.Filters
{
    public class AuthorizationFilterAttribute : ActionFilterAttribute
    {
        private readonly ILogger<AuthorizationFilterAttribute> _logger;
        private readonly IAuthenticationService _authorizationService;
        
        public AuthorizationFilterAttribute(ILogger<AuthorizationFilterAttribute> logger, IAuthenticationService authorizationService)
        {
            _logger = logger;
            _authorizationService = authorizationService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            bool hasAllowAnonymous = context.ActionDescriptor.EndpointMetadata.Any(m => m.GetType() == typeof(AllowAnonymousAttribute));

            if (hasAllowAnonymous == true)
            {
                await next.Invoke();
            }

            var ctrl = context.Controller as ControllerBase;

            var moduleName = "HR";
            var controllerName = ctrl.ControllerContext.ActionDescriptor.ControllerName;
            var actionName = ctrl.ControllerContext.ActionDescriptor.ActionName;
            try
            {
                bool isAuthorize = await _authorizationService.CheckAuthorization(moduleName, controllerName, actionName);
                if (isAuthorize == true)
                {
                    await next.Invoke();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            var response = context.HttpContext.Response;

            response.StatusCode = (int)HttpStatusCode.Forbidden;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;


        }

    }
}
