using Core.CommonModel;
using Core.Utility;
using Service.HR.Models;
using System.Threading.Tasks;

namespace Service.HR.Interfaces
{
    public interface IApproveStatusService : IBaseService<ApproveStatusModel>
    {
        Task<ResponseModel> DropDownSelection();
    }
}
