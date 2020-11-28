using API.HR.Filters;
using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace API.HR.Controllers
{
    [Route("api/hr/approve-status")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilterAttribute))]
    public class ApproveStatusController : ControllerBase
    {
        private readonly IApproveStatusService _approveStatusService;

        public ApproveStatusController(IApproveStatusService approveStatusService)
        {
            _approveStatusService = approveStatusService;
        }

        [HttpPost, Route("list")]
        public async Task<ResponseModel> List([FromBody] FilterModel filter)
        {
            var response = await _approveStatusService.List(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        [AllowAnonymous]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _approveStatusService.DropDownData();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _approveStatusService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] ApproveStatusModel model)
        {
            var response = await _approveStatusService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] ApproveStatusModel model)
        {
            var response = await _approveStatusService.Update(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] DeleteModel model)
        {
            var response = await _approveStatusService.Delete(model);
            return response;
        }
    }
}
