using API.HR.Filters;
using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace API.HR.Controllers
{
    [Route("api/hr/employee-info")]
    [ApiController]
    [AuthorizationFilter]
    public class EmployeeInfoController : ControllerBase
    {
        private readonly IEmployeeInfoService _employeeInfoService;

        public EmployeeInfoController(IEmployeeInfoService employeeInfoService)
        {
            _employeeInfoService = employeeInfoService;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _employeeInfoService.Item(id);
            return response;
        }

        [HttpGet, Route("item-by-employee")]
        public async Task<ResponseModel> ItemByEmployee([FromQuery] int employeeId)
        {
            var response = await _employeeInfoService.ItemByEmployeeId(employeeId);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] EmployeeInfoModel model)
        {
            var response = await _employeeInfoService.Update(model);
            return response;
        }

    }
}
