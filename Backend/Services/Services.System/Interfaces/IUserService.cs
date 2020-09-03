using Core.CommonModel;
using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.System.Interfaces
{
    public interface IUserService : IBaseInterfaceService<Models.UserModel>
    {
        Task<ResponseModel> ActiveOrDeactivation(Models.UserModel model);

        Task<ResponseModel> AdminChangepassword(Models.UserModel model);

        Task<ResponseModel> UserChangepassword(ChangePasswordModel model);

        Task<ResponseModel> ChangeRole(Models.UserModel model);

        Task<bool> Authorization(string moduleName, string controllerName, string actionName);
    }
}
