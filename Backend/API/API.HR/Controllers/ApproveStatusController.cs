using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace API.HR.Controllers
{
    [Route("api/hr/approve-status")]
    [ApiController]
    public class ApproveStatusController : ControllerBase
    {
        private readonly IApproveStatusService _approveStatusService;

        public ApproveStatusController(IApproveStatusService approveStatusService)
        {
            _approveStatusService = approveStatusService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _approveStatusService.GetList(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _approveStatusService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _approveStatusService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert(ApproveStatusModel model)
        {
            var response = await _approveStatusService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update(ApproveStatusModel model)
        {
            var response = await _approveStatusService.Update(model);
            return response;
        }

        [HttpDelete, Route("delete")]
        public async Task<ResponseModel> Delete(int id)
        {
            var response = await _approveStatusService.Item(id);
            return response;
        }
    }
}
