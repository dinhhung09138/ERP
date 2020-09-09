using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.HR.Filters
{
    public class AuthorizationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //TODO
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var ctrl = context.Controller as ControllerBase;

            var moduleName = "HR";
            var actionName = ctrl.ControllerContext.ActionDescriptor.ControllerName;
            var controllerName = ctrl.ControllerContext.ActionDescriptor.ActionName;

        }

    }
}
