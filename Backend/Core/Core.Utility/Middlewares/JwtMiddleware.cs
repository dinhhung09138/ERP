using Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utility.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IJwtTokenSecurityService jwtTokenSerivice)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (!string.IsNullOrEmpty(token))
            {
                var tokenInfo = jwtTokenSerivice.ValidateToken(token);
                context.Items["isValidToken"] = true;
                context.Items["TokenInfo"] = tokenInfo;
            }
            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }
}
