using API.HR.Filters;
using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace API.HR.Controllers
{
    [Route("api/hr/employee-relationship")]
    [ApiController]
    //[ServiceFilter(typeof(AuthorizationFilterAttribute))]
    public class EmployeeRelationshipController : ControllerBase
    {
        private readonly IEmployeeRelationshipService _emplRelationshipService;

        public EmployeeRelationshipController(IEmployeeRelationshipService emplRelationshipService)
        {
            _emplRelationshipService = emplRelationshipService;
        }

        /// <summary>
        /// Get list of data
        /// Including filter by employee id
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList([FromBody] FilterModel filter)
        {
            var response = await _emplRelationshipService.GetList(filter);
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _emplRelationshipService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] EmployeeRelationshipModel model)
        {
            var response = await _emplRelationshipService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] EmployeeRelationshipModel model)
        {
            var response = await _emplRelationshipService.Update(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] DeleteModel model)
        {
            var response = await _emplRelationshipService.Delete(model);
            return response;
        }
    }
}
