using Core.CommonModel;
using Service.Gym.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Gym.Interfaces
{
    public interface IExerciseService
    {
        Task<ResponseModel> List(FilterModel filter);

        Task<ResponseModel> Create(ExerciseModel model);

        Task<ResponseModel> Edit(ExerciseModel model);

        Task<ResponseModel> Delete(ExerciseModel model);
    }
}
