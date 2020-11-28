using Core.CommonModel;
using Core.Services.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace Service.HR.Interfaces
{
    public interface IEmployeeService : IBaseInterfaceService<EmployeeModel>
    {
        Task<ResponseModel> DropDownData();
        Task<ResponseModel> EmployeeWithoutAccount();
    }
}
