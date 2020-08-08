using Core.CommonModel;

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

        bool ValidateToken(string token);
    }
}
