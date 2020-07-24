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
        private readonly IAppraiseSectionService _AppraiseSectionService;

        public AppraiseSectionController(IAppraiseSectionService AppraiseSectionService)
        {
            _AppraiseSectionService = AppraiseSectionService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _AppraiseSectionService.GetList(filter);
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _AppraiseSectionService.Item(id);
            return response;
        }

        [HttpPost, Route("save")]
        public async Task<ResponseModel> Save(AppraiseSectionModel model)
        {
            var response = await _AppraiseSectionService.Save(model);
            return response;
        }
    }
}
