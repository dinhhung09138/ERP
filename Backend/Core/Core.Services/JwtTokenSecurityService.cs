﻿using Core.CommonMessage;
using Core.CommonModel;
using Core.Services.Constants;
using Core.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Core.Services
{
    /// <summary>
    /// JWT Token security service class.
    /// </summary>
    public class JwtTokenSecurityService : IJwtTokenSecurityService
    {
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _cache;
        private readonly ILoggerService _logger;

        /// <summary>
        /// Initializes a new instance of the class.
        /// Constructor.
        /// </summary>
        /// <param name="configuration">IConfiguration.</param>
        /// <param name="cache">IMemoryCache.</param>
        /// <param name="logger">ILogger.</param>
        public JwtTokenSecurityService(IConfiguration configuration, IMemoryCache cache, ILoggerService logger)
        {
            this._configuration = configuration;
            this._cache = cache;
            this._logger = logger;
        }

        /// <summary>
        /// Create token method.
        /// </summary>
        /// <param name="user">UserModel object.</param>
        /// <returns>JwtTokenModel.</returns>
        public JwtTokenModel CreateToken(UserModel user)
        {
            try
            {
                if (user == null)
                {
                    throw new Exception(ParameterMsg.ParameterInvalid);
                }

                var jwtSecurityToken = this.GetJwtSecurityToken(user);

                var token = new JwtTokenModel
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    Expiration = jwtSecurityToken.ValidTo.ToLocalTime().Ticks,
                    RefreshToken = GenerateRefreshToken(),
                    UserInfo = user,
                };

                var refreshTokenData = new TokenModel
                {
                    Token = token.RefreshToken,
                    UserId = user.Id.ToString(),
                };

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(jwtSecurityToken.ValidTo.ToLocalTime());
                this._cache.Set(token.RefreshToken, refreshTokenData, cacheEntryOptions);

                return token;
            }
            catch (Exception ex)
            {
                _logger.AddErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, user, ex);
                return null;
            }
        }

        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            // Get security key from app config
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration[JwtConstant.SECRET_KEY]));
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                Console.WriteLine(jwtToken);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private JwtSecurityToken GetJwtSecurityToken(UserModel user)
        {
            var accessTokenLifeTimeValue = double.Parse(this._configuration[JwtConstant.TOKEN_LIFE_TIME]);

            var now = DateTime.UtcNow;
            var accessTokenLifetime = now.AddMinutes(accessTokenLifeTimeValue);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
            };

            // Get security key from app config
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration[JwtConstant.SECRET_KEY]));
            // Creae Credentials
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(
                                        issuer: this._configuration[JwtConstant.ISSUER],
                                        audience: this._configuration[JwtConstant.AUDIENCE],
                                        claims: claims,
                                        notBefore: now,
                                        expires: accessTokenLifetime,
                                        signingCredentials: creds);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
