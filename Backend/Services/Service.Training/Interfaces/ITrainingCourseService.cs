using Core.CommonModel;
using Core.Services.Interfaces;
using Service.Training.Models;
using System.Threading.Tasks;

namespace Service.Training.Interfaces
{
    public interface ITrainingCourseService : IBaseInterfaceService<TrainingCourseModel>
    {
        Task<ResponseModel> DropDownSelection();
    }
}
