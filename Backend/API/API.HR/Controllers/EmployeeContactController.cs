using API.HR.Filters;
using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace API.HR.Controllers
{

    [Route("api/hr/employee-contact")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilterAttribute))]
    public class EmployeeContactController : ControllerBase
    {
        private readonly IEmployeeContactService _emplContactService;
        public EmployeeContactController(IEmployeeContactService emplContactService)
        {
            _emplContactService = emplContactService;
        }

        [HttpGet, Route("item-by-employee")]
        public async Task<ResponseModel> ItemByEmployee([FromQuery] int employeeId)
        {
            var response = await _emplContactService.ItemByEmployeeId(employeeId);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] EmployeeContactModel model)
        {
            var response = await _emplContactService.Update(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] EmployeeContactModel model)
        {
            var response = await _emplContactService.Update(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] DeleteModel model)
        {
            var response = await _emplContactService.Delete(model);
            return response;
        }
    }
}
