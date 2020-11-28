using API.HR.Filters;
using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace API.HR.Controllers
{
    [Route("api/hr/employee-education")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilterAttribute))]
    public class EmployeeEducationController : ControllerBase
    {
        private readonly IEmployeeEducationService _emplEducationService;

        public EmployeeEducationController(IEmployeeEducationService emplEducationService)
        {
            _emplEducationService = emplEducationService;
        }

        /// <summary>
        /// Get list of data
        /// Including filter by employee id
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost, Route("list")]
        public async Task<ResponseModel> List([FromBody] FilterModel filter)
        {
            var response = await _emplEducationService.List(filter);
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _emplEducationService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] EmployeeEducationModel model)
        {
            var response = await _emplEducationService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] EmployeeEducationModel model)
        {
            var response = await _emplEducationService.Update(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] DeleteModel model)
        {
            var response = await _emplEducationService.Delete(model);
            return response;
        }
    }
}
