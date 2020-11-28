using Core.CommonModel;
using Core.Services.Interfaces;
using Service.System.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.System.Interfaces
{
    public interface IRoleService : IBaseInterfaceService<RoleModel>
    {
        Task<ResponseModel> DropDownData();
    }
}
