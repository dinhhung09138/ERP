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
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _appraiseSectionService.GetList(filter);
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _appraiseSectionService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert(AppraiseSectionModel model)
        {
            var response = await _appraiseSectionService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update(AppraiseSectionModel model)
        {
            var response = await _appraiseSectionService.Update(model);
            return response;
        }

        [HttpDelete, Route("delete")]
        public async Task<ResponseModel> Delete(int id)
        {
            var response = await _appraiseSectionService.Item(id);
            return response;
        }
    }
}
