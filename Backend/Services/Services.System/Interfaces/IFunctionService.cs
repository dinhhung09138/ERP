using Core.CommonModel;
using Core.Services.Interfaces;
using Services.System.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.System.Interfaces
{
    public interface IFunctionService
    {
        Task<ResponseModel> GetAllFunctions();
        Task<List<ModuleModel>> GetListPageUserCanAccess(int userId);
    }
}
