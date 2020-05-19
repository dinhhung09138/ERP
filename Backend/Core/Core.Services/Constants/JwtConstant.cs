using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Constants
{
    /// <summary>
    /// JWT token constant.
    /// </summary>
    public static class JwtConstant
    {
        /// <summary>
        /// Token life time.
        /// JwtSecurityToken:AccessTokenLifetime.
        /// </summary>
        public static readonly string TOKEN_LIFE_TIME = "Jwt:AccessTokenLifetime";

        /// <summary>
        /// Secret key.
        /// JwtSecurityToken:SecretKey.
        /// </summary>
        public static readonly string SECRET_KEY = "Jwt:SecretKey";

        /// <summary>
        /// Issuer.
        /// JwtSecurityToken:Issuer.
        /// </summary>
        public static readonly string ISSUER = "Jwt:Issuer";

        /// <summary>
        /// Audience.
        /// JwtSecurityToken:Audience.
        /// </summary>
        public static readonly string AUDIENCE = "Jwt:Audience";
    }
}
