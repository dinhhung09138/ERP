using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.Training.Interfaces;
using Service.Training.Models;
using System.Threading.Tasks;

namespace API.Training.Controllers
{
    [Route("api/training/appraise-question")]
    [ApiController]
    public class AppraiseQuestionController : ControllerBase
    {
        private readonly IAppraiseQuestionService _AppraiseQuestionService;

        public AppraiseQuestionController(IAppraiseQuestionService AppraiseQuestionService)
        {
            _AppraiseQuestionService = AppraiseQuestionService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _AppraiseQuestionService.GetList(filter);
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _AppraiseQuestionService.Item(id);
            return response;
        }

        [HttpPost, Route("save")]
        public async Task<ResponseModel> Save(AppraiseQuestionModel model)
        {
            var response = await _AppraiseQuestionService.Save(model);
            return response;
        }
    }
}
