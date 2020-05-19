using Core.CommonModel;
using Service.Gym.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Gym.Interfaces
{
    public interface IExerciseLevelService
    {
        Task<ResponseModel> List(FilterModel filter);

        Task<ResponseModel> Create(ExerciseLevelModel model);

        Task<ResponseModel> Edit(ExerciseLevelModel model);

        Task<ResponseModel> Delete(ExerciseLevelModel model);
    }
}
