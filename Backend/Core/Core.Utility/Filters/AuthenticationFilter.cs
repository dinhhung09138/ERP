using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace Core.Utility.Filters
{
    public class AuthenticationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowInAction = context.ActionDescriptor.EndpointMetadata.Any(m => m.GetType() == typeof(AllowAnonymousAttribute));
            
            if (allowInAction == true)
            {
                return;
            }

            if (context.HttpContext.Items["isValidToken"] == null || (bool)context.HttpContext.Items["isValidToken"] == false)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
