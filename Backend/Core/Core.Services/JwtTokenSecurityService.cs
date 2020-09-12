using Core.CommonMessage;
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

        /// <summary>
        /// Initializes a new instance of the class.
        /// Constructor.
        /// </summary>
        /// <param name="configuration">IConfiguration.</param>
        public JwtTokenSecurityService(IConfiguration configuration)
        {
            _configuration = configuration;
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
                var jwtSecurityToken = GetJwtSecurityToken(user);

                var refreshTokenData = new TokenModel
                {
                    Token = jwtSecurityToken.RefreshToken,
                    UserId = user.Id,
                };
                
                // TODO
                // Save to database;

                return jwtSecurityToken;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TokenModel CheckRefreshToken(TokenModel refreshTokenModel)
        {
            try
            {
                //var cacheTokenModel = _cache.Get(refreshTokenModel.Token) as TokenModel;

                // Remove current cache
                //_cache.Remove(refreshTokenModel.Token);

                //if (cacheTokenModel != null && cacheTokenModel.UserId == refreshTokenModel.UserId)
                //{
                //    return cacheTokenModel;
                //}
                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RevokeToken(TokenModel token)
        {
            try
            {
                // _cache.Remove(token.Token);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public JwtSecurityToken ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            // Get security key from app config
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[JwtConstant.SECRET_KEY]));
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

                return jwtToken;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private JwtTokenModel GetJwtSecurityToken(UserModel user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[JwtConstant.SECRET_KEY]));
            var accessTokenLifeTimeValue = double.Parse(_configuration[JwtConstant.TOKEN_LIFE_TIME]);

            var now = DateTime.UtcNow;
            var accessTokenLifetime = now.AddMinutes(accessTokenLifeTimeValue);

            ClaimsIdentity claims = new ClaimsIdentity(new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = accessTokenLifetime,
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenObj = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);
            string token = new JwtSecurityTokenHandler().WriteToken(tokenObj);

            return new JwtTokenModel
            {
                AccessToken = token,
                Expiration = accessTokenLifetime.ToLocalTime().Ticks,
                RefreshToken = GenerateRefreshToken(),
                UserInfo = user,
            };
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
