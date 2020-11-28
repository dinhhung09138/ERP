using API.HR.Filters;
using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace API.HR.Controllers
{
    [Route("api/hr/employee-identification")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilterAttribute))]
    public class EmployeeIdentificationController : ControllerBase
    {
        private readonly IEmployeeIdentificationService _emplIdentificationService;

        public EmployeeIdentificationController(IEmployeeIdentificationService emplIdentificationService)
        {
            _emplIdentificationService = emplIdentificationService;
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
            var response = await _emplIdentificationService.List(filter);
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _emplIdentificationService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] EmployeeIdentificationModel model)
        {
            var response = await _emplIdentificationService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] EmployeeIdentificationModel model)
        {
            var response = await _emplIdentificationService.Update(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] DeleteModel model)
        {
            var response = await _emplIdentificationService.Delete(model);
            return response;
        }
    }
}
