using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Internal;
using Service.System.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace API.System.Filters
{
    public class AuthorizationFilterAttribute : ActionFilterAttribute
    {
        private readonly IAuthenticationService _authService;

        public AuthorizationFilterAttribute(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context == null || context.HttpContext.Items["TokenInfo"] == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            bool hasAllowAnonymous = context.ActionDescriptor.EndpointMetadata.Any(m => m.GetType() == typeof(AllowAnonymousAttribute));

            if (hasAllowAnonymous == true)
            {
                await next.Invoke();
                return;
            }

            var ctrl = context.Controller as ControllerBase;

            var moduleName = "SYSTEM";
            var controllerName = ctrl.ControllerContext.ActionDescriptor.ControllerName;
            var actionName = GetActionName(ctrl.ControllerContext.ActionDescriptor.ActionName);

            var tokenInfo = context.HttpContext.Items["TokenInfo"] as JwtSecurityToken;
            var userId = tokenInfo.Claims.Where(m => m.Type == JwtRegisteredClaimNames.Sub).FirstOrDefault().Value;

            try
            {
                bool isAuthorize = await _authService.CheckAuthorization(int.Parse(userId), moduleName, controllerName, actionName);
                if (isAuthorize == true)
                {
                    await next.Invoke();
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
        }

        private string GetActionName(string action)
        {
            switch (action)
            {
                case "Item":
                    return "GetList";
                default:
                    return action;
            }
        }
    }
}
