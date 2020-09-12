using Core.CommonModel;
using System.IdentityModel.Tokens.Jwt;

namespace Core.Services.Interfaces
{
    /// <summary>
    /// JWT token security interface.
    /// </summary>
    public interface IJwtTokenSecurityService
    {
        /// <summary>
        /// Create token method.
        /// </summary>
        /// <param name="user">UserModel object.</param>
        /// <returns>JwtTokenModel.</returns>
        JwtTokenModel CreateToken(UserModel user);

        TokenModel CheckRefreshToken(TokenModel refreshTokenModel);

        bool RevokeToken(TokenModel token);

        JwtSecurityToken ValidateToken(string token);
    }
}
