using Core.CommonModel;
using Service.Gym.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Gym.Interfaces
{
    public interface IMuscleService
    {
        Task<ResponseModel> List(FilterModel filter);

        Task<ResponseModel> Create(MuscleModel model);

        Task<ResponseModel> Edit(MuscleModel model);

        Task<ResponseModel> Delete(MuscleModel model);
    }
}
