using API.HR.Filters;
using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace API.HR.Controllers
{
    [Route("api/hr/leave-status")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilterAttribute))]
    public class LeaveStatusController : ControllerBase
    {
        private readonly ILeaveStatusService _leaveStatusService;

        public LeaveStatusController(ILeaveStatusService leaveStatusService)
        {
            _leaveStatusService = leaveStatusService;
        }

        [HttpPost, Route("list")]
        public async Task<ResponseModel> List([FromBody] FilterModel filter)
        {
            var response = await _leaveStatusService.List(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        [AllowAnonymous]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _leaveStatusService.DropDownData();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _leaveStatusService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] LeaveStatusModel model)
        {
            var response = await _leaveStatusService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] LeaveStatusModel model)
        {
            var response = await _leaveStatusService.Update(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] DeleteModel model)
        {
            var response = await _leaveStatusService.Delete(model);
            return response;
        }
    }
}
