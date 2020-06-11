using Core.CommonModel;
using Service.HR.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.HR.Interfaces
{
    public interface IDisciplineService
    {
        Task<ResponseModel> GetList(FilterModel filter);
        Task<ResponseModel> Save(DisciplineModel model);
        Task<ResponseModel> Item(int id);
    }
}
