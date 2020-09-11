using Core.CommonModel;
using System.Threading.Tasks;

namespace Service.System.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ResponseModel> AuthencitateUser(LoginModel model);

        Task<ResponseModel> RefreshToken(TokenModel model);

        ResponseModel RevokeToken(TokenModel model);

        Task<bool> CheckAuthorization(string moduleName, string controllerName, string actionName);
    }
}
