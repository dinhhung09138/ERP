using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.Training.Interfaces;
using Service.Training.Models;
using System.Threading.Tasks;

namespace API.Training.Controllers
{
    [Route("api/training/appraise-answer")]
    [ApiController]
    public class AppraiseAnswerController : ControllerBase
    {
        private readonly IAppraiseAnswerService _AppraiseAnswerService;

        public AppraiseAnswerController(IAppraiseAnswerService AppraiseAnswerService)
        {
            _AppraiseAnswerService = AppraiseAnswerService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _AppraiseAnswerService.GetList(filter);
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _AppraiseAnswerService.Item(id);
            return response;
        }

        [HttpPost, Route("save")]
        public async Task<ResponseModel> Save(AppraiseAnswerModel model)
        {
            var response = await _AppraiseAnswerService.Save(model);
            return response;
        }
    }
}
