using Core.CommonModel;
using Core.Services.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace Service.HR.Interfaces
{
    public interface IEmployeeInfoService : IBaseInterfaceService<EmployeeInfoModel>
    {
        Task<ResponseModel> UpdateName(int employeeId, string firstName, string lastName);
    }
}
