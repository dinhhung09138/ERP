using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Core.Services
{
    public class BaseService
    {
        protected IHttpContextAccessor _httpContext;

        protected int UserId
        {
            get
            {
                return GetCurrentUserId();
            }
        }

        public BaseService()
        {
        }

        private int GetCurrentUserId()
        {
            var context = _httpContext.HttpContext;

            if (context == null)
            {
                throw new Exception();
            }

            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            return int.Parse(userId);
        }
    }
}
