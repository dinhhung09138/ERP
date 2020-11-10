using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.Training.Interfaces;
using Service.Training.Models;
using System.Threading.Tasks;

namespace API.Training.Controllers
{
    [Route("api/training/appraise-section")]
    [ApiController]
    public class AppraiseSectionController : ControllerBase
    {
        private readonly IAppraiseSectionService _appraiseSectionService;

        public AppraiseSectionController(IAppraiseSectionService appraiseSectionService)
        {
            _appraiseSectionService = appraiseSectionService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList([FromBody] FilterModel filter)
        {
            var response = await _appraiseSectionService.GetList(filter);
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _appraiseSectionService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] AppraiseSectionModel model)
        {
            var response = await _appraiseSectionService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] AppraiseSectionModel model)
        {
            var response = await _appraiseSectionService.Update(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] DeleteModel model)
        {
            var response = await _appraiseSectionService.Delete(model);
            return response;
        }
    }
}
