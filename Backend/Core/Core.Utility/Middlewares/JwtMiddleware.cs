using Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utility.Middlewares
{
    public class JwtMiddleware : IMiddleware
    {
        private readonly IJwtTokenSecurityService _jwtTokenSerivice;

        public JwtMiddleware(IJwtTokenSecurityService jwtTokenSerivice)
        {
            _jwtTokenSerivice = jwtTokenSerivice;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var user = context.User;
            //var allow = context.Response.HttpContext.u

            if (!string.IsNullOrEmpty(token))
            {
                var tokenInfo = _jwtTokenSerivice.ValidateToken();
                context.Items["isValidToken"] = true;
                context.Items["TokenInfo"] = tokenInfo;
            }
            // Call the next delegate/middleware in the pipeline
            await next(context);
        }
    }
}
