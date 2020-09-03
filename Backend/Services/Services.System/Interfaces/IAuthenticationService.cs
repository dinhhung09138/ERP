using Core.CommonModel;
using System.Threading.Tasks;

namespace Services.System.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ResponseModel> AuthencitateUser(LoginModel model);

        Task<ResponseModel> RefreshToken(TokenModel model);

        ResponseModel RevokeToken(TokenModel model);
    }
}
