using Core.CommonModel;
using Core.Utility.Filters;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace API.HR.Controllers
{
    [Route("api/hr/employee-info")]
    [ApiController]
    [Authentication]
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

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] EmployeeInfoModel model)
        {
            var response = await _employeeInfoService.Update(model);
            return response;
        }

    }
}
