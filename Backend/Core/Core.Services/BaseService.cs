using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
            var tokenInfo = _httpContext.HttpContext.Items["TokenInfo"] as JwtSecurityToken;

            if (tokenInfo == null)
            {
                throw new Exception();
            }

            var userId = tokenInfo.Claims.Where(m => m.Type == JwtRegisteredClaimNames.Sub).FirstOrDefault().Value;

            return int.Parse(userId);
        }
    }
}
