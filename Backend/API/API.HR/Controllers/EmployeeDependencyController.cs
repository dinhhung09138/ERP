using API.HR.Filters;
using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;


namespace API.HR.Controllers
{
    [Route("api/hr/employee-dependency")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilterAttribute))]
    public class EmployeeDependencyController : ControllerBase
    {
        private readonly IEmployeeDependencyService _emplDependencyService;

        public EmployeeDependencyController(IEmployeeDependencyService emplDependencyService)
        {
            _emplDependencyService = emplDependencyService;
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
            var response = await _emplDependencyService.List(filter);
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _emplDependencyService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] EmployeeDependencyModel model)
        {
            var response = await _emplDependencyService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] EmployeeDependencyModel model)
        {
            var response = await _emplDependencyService.Update(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] DeleteModel model)
        {
            var response = await _emplDependencyService.Delete(model);
            return response;
        }
    }
}
