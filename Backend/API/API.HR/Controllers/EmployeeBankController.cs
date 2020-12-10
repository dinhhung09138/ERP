using API.HR.Filters;
using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace API.HR.Controllers
{
    [Route("api/hr/employee-bank")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilterAttribute))]
    public class EmployeeBankController : ControllerBase
    {
        private readonly IEmployeeBankService _emplBankService;

        public EmployeeBankController(IEmployeeBankService emplBankService)
        {
            _emplBankService = emplBankService;
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
            var response = await _emplBankService.List(filter);
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _emplBankService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] EmployeeBankModel model)
        {
            var response = await _emplBankService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] EmployeeBankModel model)
        {
            var response = await _emplBankService.Update(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] DeleteModel model)
        {
            var response = await _emplBankService.Delete(model);
            return response;
        }
    }
}
