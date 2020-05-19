using Core.CommonModel;
using Service.Gym.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Gym.Interfaces
{
    public interface IExerciseResourceService
    {
        Task<ResponseModel> List(FilterModel filter);

        Task<ResponseModel> Create(ExerciseResourceModel model);

        Task<ResponseModel> Edit(ExerciseResourceModel model);

        Task<ResponseModel> Delete(ExerciseResourceModel model);
    }
}
