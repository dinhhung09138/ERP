using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace API.HR.Controllers
{
    [Route("api/hr/employee-working-status")]
    [ApiController]
    public class EmployeeWorkingStatusController : ControllerBase
    {
        private readonly IEmployeeWorkingStatusService _employeeWorkingStatusService;

        public EmployeeWorkingStatusController(IEmployeeWorkingStatusService employeeWorkingStatusService)
        {
            _employeeWorkingStatusService = employeeWorkingStatusService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _employeeWorkingStatusService.GetList(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _employeeWorkingStatusService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _employeeWorkingStatusService.Item(id);
            return response;
        }

        [HttpPost, Route("save")]
        public async Task<ResponseModel> Save(EmployeeWorkingStatusModel model)
        {
            var response = await _employeeWorkingStatusService.Save(model);
            return response;
        }
    }
}
