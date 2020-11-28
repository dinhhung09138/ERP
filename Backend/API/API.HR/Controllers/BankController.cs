using API.HR.Filters;
using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;
namespace API.HR.Controllers
{
    [Route("api/hr/bank")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilterAttribute))]
    public class BankController : ControllerBase
    {
        private readonly IBankService _bankService;

        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        [HttpPost, Route("list")]
        public async Task<ResponseModel> List([FromBody] FilterModel filter)
        {
            var response = await _bankService.List(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        [AllowAnonymous]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _bankService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _bankService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] BankModel model)
        {
            var response = await _bankService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] BankModel model)
        {
            var response = await _bankService.Update(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] DeleteModel model)
        {
            var response = await _bankService.Delete(model);
            return response;
        }
    }
}
