using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Common.Filters
{
    public class AuthorizationFilterAttribute : ActionFilterAttribute
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var ctrl = context.Controller as ControllerBase;

            var moduleName = "HR";
            var actionName = ctrl.ControllerContext.ActionDescriptor.ControllerName;
            var controllerName = ctrl.ControllerContext.ActionDescriptor.ActionName;
        }
    }
}
