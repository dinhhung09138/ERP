using Core.CommonModel;
using Core.Services.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace Service.HR.Interfaces
{
    public interface IModelOfStudyService : IBaseInterfaceService<ModelOfStudyModel>
    {
        Task<ResponseModel> DropDownSelection();
    }
}
