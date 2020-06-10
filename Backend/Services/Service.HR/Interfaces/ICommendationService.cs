using Core.CommonModel;
using Service.HR.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.HR.Interfaces
{
    public interface ICommendationService
    {
        Task<ResponseModel> GetList(FilterModel filter);
        Task<ResponseModel> Save(CommendationModel model);
        Task<ResponseModel> Item(int id);
    }
}
