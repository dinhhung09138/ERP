using Core.CommonModel;
using Core.Services.Interfaces;
using Service.Common.Models;
using System.Threading.Tasks;

namespace Service.Common.Interfaces
{
    public interface IProfessionalQualificationService : IBaseInterfaceService<ProfessionalQualificationModel>
    {
        Task<ResponseModel> DropDownData();
    }
}
