using Core.CommonModel;
using Core.Services.Interfaces;
using Service.Training.Models;
using System.Threading.Tasks;

namespace Service.Training.Interfaces
{
    public interface ISpecializedTrainingService : IBaseService<SpecializedTrainingModel>
    {
        Task<ResponseModel> DropDownSelection();
    }
}
