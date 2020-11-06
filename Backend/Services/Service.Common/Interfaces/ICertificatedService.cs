using Core.CommonModel;
using Core.Services.Interfaces;
using Service.Common.Models;
using System.Threading.Tasks;

namespace Service.Common.Interfaces
{
    public interface ICertificatedService : IBaseInterfaceService<CertificatedModel>
    {
        Task<ResponseModel> DropDownSelection();
    }
}
