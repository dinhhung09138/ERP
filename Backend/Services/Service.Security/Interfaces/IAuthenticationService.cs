using Core.CommonModel;
using System.Threading.Tasks;

namespace Service.Security.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ResponseModel> AuthencitateUser(LoginModel model);
    }
}
