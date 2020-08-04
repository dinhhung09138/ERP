using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Utility.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthenticationAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Items["isValidToken"] == null || (bool)context.HttpContext.Items["isValidToken"] == false)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
